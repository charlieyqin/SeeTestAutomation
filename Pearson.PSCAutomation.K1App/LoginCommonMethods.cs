using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    public static class LoginCommonMethods
    {
        /// <summary>
        /// Login to the application [teacher]
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void TeacherAdminLogin(AutomationAgent LoginAutomationAgent, Login login)
        {
            if (!LoginAutomationAgent.IsElementFound("HomeScreenView", "TeacherLoginIcon"))
            {
                int tCount = 0;
                while (!LoginAutomationAgent.IsElementFound("UnitSelection", "SystemTray") && tCount <= 5)
                {
                    if (LoginAutomationAgent.IsElementFound("StudentSetup", "BackButton"))
                    {
                        NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
            }
                    else
                    {
                        if (LoginAutomationAgent.IsElementFound("eReaderView", "GoBackButton"))
                        {
                            NavigationCommonMethods.ClickOnGoBackIcon(LoginAutomationAgent);
                        }
                        else

                            NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 1600, 100);
                        if (LoginAutomationAgent.IsElementFound("eReaderView", "GoBackButton"))
                        {
                            NavigationCommonMethods.ClickOnGoBackIcon(LoginAutomationAgent);
                        }
                    }

                    if (LoginAutomationAgent.IsElementFound("HomeScreenView", "StudentButton"))
                    {
                        break;
                    }
                    tCount++;
                }
                if (LoginAutomationAgent.GetElementText("SystemTray", "CurrentUsername") != login.PersonName || !bool.Parse(ConfigurationManager.AppSettings["UnitTestExecution"].ToString()))
                {
                    Logout(LoginAutomationAgent, true);
                    LoginAutomationAgent.Click("HomeScreenView", "TeacherLoginIcon");
                    LoginAutomationAgent.SetText("StudentSetup", "UserName", login.UserName);
                    LoginAutomationAgent.SetText("StudentSetup", "Password", login.Password);
                    LoginAutomationAgent.Click("StudentSetup", "LoginButton");
                    //Assert.IsTrue(WaitForUserTobeLoggedIn(LoginAutomationAgent), "User login failed");
                    LoginAutomationAgent.WaitforElement("UnitSelection", "SystemTray", "", WaitTime.LargeWaitTime);
                }
                if (!LoginAutomationAgent.IsElementFound("UnitSelection", "ELAColumnTitle"))
                {
                    NavigationCommonMethods.ClickOnSystemTray(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(LoginAutomationAgent);
                }
            }
            else
            {
                LoginAutomationAgent.WaitForElement("HomeScreenView", "TeacherLoginIcon");
                LoginAutomationAgent.Click("HomeScreenView", "TeacherLoginIcon");
            LoginAutomationAgent.SetText("StudentSetup", "UserName", login.UserName);
            LoginAutomationAgent.SetText("StudentSetup", "Password", login.Password);
            LoginAutomationAgent.Click("StudentSetup", "LoginButton");
            //Assert.IsTrue(WaitForUserTobeLoggedIn(LoginAutomationAgent), "User login failed");
            LoginAutomationAgent.WaitforElement("UnitSelection", "SystemTray", "", WaitTime.LargeWaitTime);
        }
        }

        /// <summary>
        /// Wait for User to be logged into application for 10 minutes, else go back to home screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>True: If user logged into application successfully</returns>
        public static bool WaitForUserTobeLoggedIn(AutomationAgent LoginAutomationAgent)
        {
            string[] sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
            int tCount = 0;
            while (sunSpinnerHiddenProperty[0].Equals("false") && tCount <= 4)
            {
                LoginAutomationAgent.WaitforElement("UnitSelection", "SystemTray", "", WaitTime.MediumWaitTime);
                sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
                if (sunSpinnerHiddenProperty[0].Equals("true") && LoginAutomationAgent.IsElementFound("UnitSelection", "SystemTray"))
                {
                    return true;
                }
                if (VerifyAuthenticationServerErrorPopup(LoginAutomationAgent))
                {
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                    return false;
                }

                tCount++;
            }

            if (sunSpinnerHiddenProperty[0].Equals("true") && LoginAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon"))
                return true;

            if (sunSpinnerHiddenProperty[0].Equals("true") && LoginAutomationAgent.IsElementFound("UnitSelection", "SystemTray"))
                return true;

            if (sunSpinnerHiddenProperty[0].Equals("false") && tCount.Equals(20))
                NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
            return false;

        }

        /// <summary>
        /// Login to the application from Student Setup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void StudentSetupLogin(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginAutomationAgent.SetText("StudentSetup", "UserNameField", login.UserName);
            LoginAutomationAgent.SetText("StudentSetup", "PasswordField", login.Password);
            LoginAutomationAgent.SendText("{CLOSEKEYBOARD}");
            LoginAutomationAgent.Click("StudentSetup", "BeginSetup");
            Assert.IsTrue(WaitStudentToBeSetUp(LoginAutomationAgent), "Student Setup login failed");
        }

        /// <summary>
        /// Wait for student to be logged in from student setup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>True: when in progress spinner will be vanish</returns>
        public static bool WaitStudentToBeSetUp(AutomationAgent LoginAutomationAgent)
        {
            string[] sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
            int tCount = 0;
            while (sunSpinnerHiddenProperty[0].Equals("false") && tCount <= 5)
            {
                LoginAutomationAgent.Sleep(WaitTime.LargeWaitTime);
                sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
                if (sunSpinnerHiddenProperty[0].Equals("true"))
                    return true;
                if (VerifyStudentAlreadySetupMessage(LoginAutomationAgent))
                    return true;
                if (VerifyAuthenticationServerErrorPopup(LoginAutomationAgent))
                {
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                    return false;
                }
                tCount++;
            }

            if (sunSpinnerHiddenProperty[0].Equals("true") && LoginAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon"))
                return true;

            if (sunSpinnerHiddenProperty[0].Equals("false") && tCount.Equals(20))
                NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
            return false;
        }


        /// <summary>
        /// Click on System Tray and click on Logout button 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void Logout(AutomationAgent LoginAutomationAgent, bool mandatoryLogout = false)
        {
            int tCount = 0;
            while (!LoginAutomationAgent.IsElementFound("UnitSelection", "SystemTray") && tCount <= 20)
            {
                if (LoginAutomationAgent.IsElementFound("StudentSetup", "BackButton"))
                {
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }
                else
                {
                    if (LoginAutomationAgent.IsElementFound("eReaderView", "GoBackButton"))
                    {
                        NavigationCommonMethods.ClickOnGoBackIcon(LoginAutomationAgent);
                    }
                    else

                        NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 1600, 100);
                    if (LoginAutomationAgent.IsElementFound("eReaderView", "GoBackButton"))
                    {
                        NavigationCommonMethods.ClickOnGoBackIcon(LoginAutomationAgent);
                    }
                }

                if (LoginAutomationAgent.IsElementFound("HomeScreenView", "StudentButton"))
                {
                    break;
                }

                tCount++;
            }

            if (!bool.Parse(ConfigurationManager.AppSettings["UnitTestExecution"].ToString()) || mandatoryLogout)
            {
                LoginAutomationAgent.Click("UnitSelection", "SystemTray");
                LoginAutomationAgent.Click("UnitSelection", "LogOutButton");
                LoginAutomationAgent.Click("UnitSelection", "Logout");
                LoginAutomationAgent.Sleep();
            }
        }

        /// <summary>
        /// Logs out of the application and release client
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void LogoutOnExceptionAndReleaseClient(AutomationAgent LoginAutomationAgent)
        {
            Logout(LoginAutomationAgent);
            LoginAutomationAgent.GenerateReportAndReleaseClient();
        }

        /// <summary>
        /// Verify if Student is already Setup, if its not setup then login with student credential to setup student 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void VerifyAndSetupStudent(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginAutomationAgent.Click("HomeScreenView", "StudentButton");
            if (LoginAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon"))
            {
                LoginAutomationAgent.Click("StudentSetup", "ErrorPopUpCloseIcon");
                LoginAutomationAgent.Click("HomeScreenView", "TeacherLoginIcon");
                LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, login);
                LoginAutomationAgent.Sleep();
                LoginCommonMethods.Logout(LoginAutomationAgent);
            }
            else
            {
                LoginAutomationAgent.Click("StudentSetup", "BackButton");
            }
        }


        /// <summary>
        /// Login into the application using pic password
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void LoginStudentUsingPicPassword(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
            if (LoginAutomationAgent.IsElementFound("StudentSetup", "TryAgainMessage"))
            {
                LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                LoginCommonMethods.ResetStudentPicPassword(LoginAutomationAgent, login);
            }

        }

        /// <summary>
        /// Select all first option in pic password selection screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void SelectPicPassword(AutomationAgent LoginAutomationAgent, int colorIndex, int captainIndex, int fruitIndex)
        {
            LoginAutomationAgent.Click("StudentSetup", "CircleColor", colorIndex.ToString());
            LoginAutomationAgent.Click("StudentSetup", "NextArrow");
            LoginAutomationAgent.Click("StudentSetup", "Captain", captainIndex.ToString());
            LoginAutomationAgent.Click("StudentSetup", "NextArrow");
            LoginAutomationAgent.Click("StudentSetup", "Fruits", fruitIndex.ToString());
            LoginAutomationAgent.Click("StudentSetup", "NextArrow");
        }

        /// <summary>
        /// Reset the Studen Pic password 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void ResetStudentPicPassword(AutomationAgent LoginAutomationAgent, Login login)
        {
            NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
            NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
            LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, login);
            NavigationCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
            LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
            LoginCommonMethods.ClickGreenMarkPicturePasswordScreen(LoginAutomationAgent);
            LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
            NavigationCommonMethods.ClickOnNextArrowAtLetsPractice(LoginAutomationAgent);
            LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
            NavigationCommonMethods.ClickOnLetsLoginArrow(LoginAutomationAgent);
            NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
            LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
        }

        /// <summary>
        /// Start the Resting Pic password but stopped it in between 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void IncompleteResetPicPasswordProcess(AutomationAgent LoginAutomationAgent, Login login)
        {
            NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
            NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
            LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, login);
            NavigationCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
            LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 2, 3, 4);
            LoginCommonMethods.ClickCrossMarkAtPicturePasswordScreen(LoginAutomationAgent);
        }

        /// <summary>
        /// Click on logout button from system tray nav bar
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLogoutButton(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("UnitSelection", "LogOutButton");
        }

        /// <summary>
        /// Verify the below items on logout popup
        /// 1. Accept button
        /// 2. Cancel Button
        /// 3. Logout Logo
        /// 4. Logout? text
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyLogoutPopupUI(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.WaitforElement("UnitSelection", "Logout", "", WaitTime.MediumWaitTime);
            LoginAutomationAgent.VerifyElementFound("UnitSelection", "Logout");
            LoginAutomationAgent.VerifyElementFound("UnitSelection", "CancelLogOut");
            LoginAutomationAgent.VerifyElementFound("UnitSelection", "LogOutLogo");
            LoginAutomationAgent.VerifyElementFound("UnitSelection", "LogOutText");
        }

        /// <summary>
        /// Click to close the logout popup
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClicktoCancelLogout(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("UnitSelection", "CancelLogOut");
        }
        /// <summary>
        /// Clicks inside the username field
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickInsideUsernameField(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "UserName");
        }
        /// <summary>
        /// Click inside username field of student setup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickInsideUsernameFieldOFStudentSetUpScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "UserNameField");
        }
        /// <summary>
        /// Click insdie the password field of Student setup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickInsidePasswordFieldOfStudentSetup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "PasswordField");
        }
        /// <summary>
        /// Veriy Login button visible
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyLogInButtonVisible(AutomationAgent LoginAutomationAgent)
        {
            string hidden = LoginAutomationAgent.GetAllValues("StudentSetup", "LoginButton", "hidden")[0];
            if (hidden.Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify login button tappable
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyLogInButtonTappable(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "LoginButton");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
        }
        /// <summary>
        /// Clicks inside the password field of teacher admin login
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickInsidePasswordField(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "Password");
        }
        /// <summary>
        /// Verify Begin Setup Button Is Fully Visible.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyBeginSetupButtonVisible(AutomationAgent LoginAutomationAgent)
        {
            string hidden = LoginAutomationAgent.GetAllValues("StudentSetup", "BeginSetup", "hidden")[0];
            if (hidden.Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify begin setup button tappable
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyBeginSetupButtonTappable(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "BeginSetup");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
        }
        /// <summary>
        /// Verify the begin set up button above keyboard
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyBeginSetupButtonAboveKeyboard(AutomationAgent LoginAutomationAgent)
        {
            int YCooridnateBeginSetupButton = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "BeginSetup", "y")[0]);
            int YCoordinateKeyboard = Int32.Parse(LoginAutomationAgent.GetAllValues("InboxView", "KeyBoardView", "y")[0]);
            if (YCooridnateBeginSetupButton < YCoordinateKeyboard)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify auto correct enable
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <return>bool object : true if found</return>
        public static bool VerifyAutoCorrectEnable(AutomationAgent LoginAutomationAgent)
        {
            return LoginAutomationAgent.IsElementFound("StudentSetup", "KyeboardPredictionCell");
        }

        public static void VerifyStudentSetUpUIElements(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "BackButton");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "StudentSetupTitle");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "HelpText");
            LoginAutomationAgent.GetTextIn("StudentSetup", "UserNameField", "Inside", "").Replace("\t\n", "").Equals("name");
            LoginAutomationAgent.GetTextIn("StudentSetup", "PasswordField", "Inside", "").Replace("\t\n", "").Equals("password");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "BeginSetup");
        }

        /// <summary>
        /// Verify that the help text in username textbox disappears when the user starts entering the characters in the username textbox
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true when it doesnt find the watermark "name" in the username field</returns>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static bool VerifyUserNameIsEditable(AutomationAgent LoginAutomationAgent)
        {
            string username_watermark = LoginAutomationAgent.GetTextIn("StudentSetup", "UserNameField", "Inside", "").Replace("\t\n", "");
            LoginAutomationAgent.Sleep();
            LoginAutomationAgent.Click("StudentSetup", "UserNameField");
            LoginAutomationAgent.SendText("user");
            LoginAutomationAgent.Sleep();
            string username_watermarkTextEntered = LoginAutomationAgent.GetTextIn("StudentSetup", "UserNameField", "Inside", "").Replace("\t\n", "");
            if (username_watermarkTextEntered.Contains(username_watermark))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Verify that the help text in Password textbox disappears when the user starts entering password in textbox
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true when it doesnt find the watermark "password" in the password field</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static bool VerifyPasswordIsEditable(AutomationAgent LoginAutomationAgent)
        {

            string username_watermark = LoginAutomationAgent.GetTextIn("StudentSetup", "PasswordField", "Inside", "").Replace("\t\n", "");
            LoginAutomationAgent.Sleep();
            LoginAutomationAgent.Click("StudentSetup", "PasswordField");
            LoginAutomationAgent.SendText("user");
            LoginAutomationAgent.Sleep();
            string username_watermarkTextEntered = LoginAutomationAgent.GetTextIn("StudentSetup", "PasswordField", "Inside", "").Replace("\t\n", "");
            if (username_watermarkTextEntered.Contains(username_watermark))
                return false;
            else
                return true;

        }

        /// <summary>
        /// Verify that the Incorrect Credentials Pop up is displayed when the user enters incorrect credentials and taps on the begin setup button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifyIncorrectCredentialsErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.WaitForElement("StudentSetup", "InprogressIcon");
            LoginAutomationAgent.WaitforElement("StudentSetup", "ErrorPopUpCloseIcon", "", WaitTime.MediumWaitTime);
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("The username or password you entered was incorrect. Please try again");
        }

        /// <summary>
        /// Verify that the Incorrect Credentials Pop up is displayed when the user enters empty credentials and taps on the begin setup button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true when the error message is found.</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static bool VerifyEmptyCredentialsErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("Please enter a username and password to continue.");
        }
        /// <summary>
        /// Tap on cross icon of Incorrect/Empty Credential popup
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void CloseErrorPopUp(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "ErrorPopUpCloseIcon");
        }

        /// <summary>
        /// Verify that below UI elements are displayed in Empty credentials pop up 1.Enabled OK Button (Cross Icon) and 2.Error Message
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true when the Cross Icon and Error message are found.</returns>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static bool VerifyUIOfEmptyCredentialsErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            if (TextonScreen.Contains("Please enter a username and password to continue.") && LoginAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify the error message when already setup student credentials are used to log in
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true when the error message is found</returns>
        public static bool VerifyStudentAlreadySetupMessage(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.WaitForElement("StudentSetup", "InprogressIcon");
            LoginAutomationAgent.WaitforElement("StudentSetup", "CancelAndReturnToLogin", "", WaitTime.MediumWaitTime);
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            if (TextonScreen.Contains("The password for this student already exists") && TextonScreen.Contains("Please choose from one of the following"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// click on the cancel and return to login button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelAndReturnToLogin(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "CancelAndReturnToLogin");
        }
        /// <summary>
        /// verify the UI elements of the error pop up when incorrect credentials are use to log in.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true when the error message and close Icon is found</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static bool VerifyUIOfIncorrectCredentialsErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return (TextonScreen.Contains("The username or password you entered was incorrect. Please try again.") && LoginAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon"));
        }
        /// <summary>
        /// verify the UI elements of the error pop up when already setup student credentials are used to log in.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true when the error message,reset passowrd button and cancel&return to login is found. </returns>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static bool VerifyUIOfCorrectCredentialSetupPopupMessage(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("The password for this student already exists") && TextonScreen.Contains(" Please choose from one of the following") && LoginAutomationAgent.IsElementFound("StudentSetup", "CancelAndReturnToLogin") && LoginAutomationAgent.IsElementFound("StudentSetup", "ResetPassword");
        }

        /// <summary>
        /// Verify the Studen Icon on Home Screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true when the Student Icon on Home Screen is found.</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static bool VerifyHomeScreenStudentButton(AutomationAgent LoginAutomationAgent)
        {
            return LoginAutomationAgent.IsElementFound("HomeScreenView", "StudentButton");
        }

        /// <summary>
        /// Verify that the student first name and last initial is displayed in the top left corner of the Password Item Screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="sname">String object: passing student name</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void VerifyTheNameOftheUser(AutomationAgent LoginAutomationAgent, Login login)
        {
            string[] str1 = (login.PersonName).Split(' ');
            string FName = str1[0];
            string LNameInitialChar = str1[1].Substring(0, 1);
            string displayname = LoginAutomationAgent.GetTextIn("StudentSetup", "DisplayName", "Inside", "", "TEXT", 0, 0, 0).Replace("\t\n", "");
            displayname.Contains(FName + LNameInitialChar);

        }

        /// <summary>
        /// Verify boat displayed at student login screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void VerifyPasswordSelectionScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "Boat");
        }

        /// <summary>
        /// Verify the Native iOs popup with the zone I have passed
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="zone">String Object: passing zone of element</param>
        /// <returns>bool object:true when the native zone is found</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static bool VerifyNativeIosPopUp(AutomationAgent LoginAutomationAgent, string zone)
        {
            return LoginAutomationAgent.IsElementFound("StudentSetup", "NativeIosPop", "Inside", zone);

        }

        /// <summary>
        /// Select any random cirle color at passowrd confirmation screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="randomPicItem">String Object: passing any random number between 1 to 9</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void SelectColoredCircle(AutomationAgent LoginAutomationAgent, int randomPicItem)
        {
            LoginAutomationAgent.WaitforElement("StudentSetup", "CircleColor", randomPicItem.ToString(), WaitTime.LargeWaitTime);
            LoginAutomationAgent.Click("StudentSetup", "CircleColor", randomPicItem.ToString());

        }

        /// <summary>
        /// Select any random Captain at passowrd confirmation screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="randomPicItem">String Object: passing any random number between 1 to 9</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void SelectCaptain(AutomationAgent LoginAutomationAgent, int randomPicItem)
        {
            LoginAutomationAgent.WaitforElement("StudentSetup", "Captain", randomPicItem.ToString(), WaitTime.LargeWaitTime);
            LoginAutomationAgent.Click("StudentSetup", "Captain", randomPicItem.ToString());
        }

        /// <summary>
        /// Verify the Selected Color and Captain display at password selection screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="randomPicItem">String Object: passing any random number between 1 to 9</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void VerifySelectedColorAndCaptain(AutomationAgent LoginAutomationAgent, int randomPicItem)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "SelectedColor", randomPicItem.ToString());
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "SelectedCaptain", randomPicItem.ToString());

        }

        /// <summary>
        /// Verify No internet message popup when no internet connection are available
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no internet message found</returns>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static bool VerifyNoInternetMessage(AutomationAgent LoginAutomationAgent)
        {
            string message = LoginAutomationAgent.GetTextIn("StudentSetup", "ErrorMessage", "Inside", "").Replace("\t\n", " ");
            return message.Contains("No internet connection.");
        }

        /// <summary>
        /// Select any random Teacher from "Who is your Teacher?" screen
        /// </summary>
        /// <param name="LoginAutomationAgent"AutomationAgent object></param>
        /// <param name="TeacherIndex">String Object: passing any random number between 1 to 5</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void SelectTeacher(AutomationAgent LoginAutomationAgent, int TeacherIndex)
        {
            LoginAutomationAgent.Click("StudentSetup", "SelectTeacher", "", TeacherIndex, 1, WaitTime.DefaultWaitTime);
        }

        /// <summary>
        /// Verify Selected Teacher should be higlights at "Who is your Teacher?" screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void VerifyTeacherHighlight(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "HighlightedTeacher");
        }

        /// <summary>
        /// Verify Green tick mark appreadred when Teacher has been selected
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void VerifyGreenMark(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "GreenCheckMark");
        }

        /// <summary>
        /// click on Green Tick Mark after Teacher has been selected
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickGreenMark(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "GreenCheckMark");
        }
        /// <summary>
        /// Verifies IamNot Link Exists or not on the student login screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyIamNotLinkExists(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "IAMNOTLink");
        }
        /// <summary>
        /// verifies password confirmation screen.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void VerifyPasswordConfirmationScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "YourPassword");
        }
        /// <summary>
        /// click on the green mark which is on the picture password selection screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickGreenMarkPicturePasswordScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "GreenCheckMarkAtPasswordReset");
        }

        /// <summary>
        /// click on the red cross mark which is on the picture password selection screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void ClickCrossMarkAtPicturePasswordScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "RedCrossMarkAtPasswordReset");
        }

        /// <summary>
        /// After login verify student display name.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyDisplayNameAtSystemTray(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginAutomationAgent.Click("UnitSelection", "SystemTray");
            Assert.IsTrue((login.PersonName).Contains(LoginAutomationAgent.GetElementText("StudentSetup", "DisplayName")), "Fail when display name does not match with logged in user");
            LoginAutomationAgent.Click("UnitSelection", "SystemTray");
        }

        /// <summary>
        /// Verify tapping on green check mark redirect to only practice mode
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyPracticeModeDisplay(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "PracticeMode");
        }

        /// <summary>
        /// Get the Highlighted Teacher Name and store it in variable
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>string: return Teacher Name</returns>
        public static string GetHighlightedTeacherName(AutomationAgent LoginAutomationAgent)
        {
            string teacherName = LoginAutomationAgent.GetTextIn("StudentSetup", "HighlightedTeacher", "Inside", "").Replace("\t\n", " ");
            return teacherName;
        }

        /// <summary>
        /// Verify all colors elements count is 9 and height and width are 260
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>int: color count</returns>
        public static int VerifyColorSize(AutomationAgent LoginAutomationAgent)
        {
            int colorCount = 1;
            for (colorCount = 1; colorCount <= 10; colorCount++)
            {
                if (LoginAutomationAgent.IsElementFound("StudentSetup", "CircleColor", colorCount.ToString()))
                {
                    string[] width = LoginAutomationAgent.GetAllValues("StudentSetup", "CircleColor", colorCount.ToString(), "width");
                    string[] height = LoginAutomationAgent.GetAllValues("StudentSetup", "CircleColor", colorCount.ToString(), "height");
                    if (width[0] == "260" && height[0] == "260")
                    {
                        continue;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                    break;
            }
            return --colorCount;
        }

        /// <summary>
        /// Verify all captain elements count is 9 and height and width are 260
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>int: color count</returns>
        public static int VerifyCaptainSize(AutomationAgent LoginAutomationAgent)
        {
            int captainCount = 1;
            for (captainCount = 1; captainCount <= 10; captainCount++)
            {
                if (LoginAutomationAgent.IsElementFound("StudentSetup", "Captain", captainCount.ToString()))
                {
                    string[] width = LoginAutomationAgent.GetAllValues("StudentSetup", "Captain", captainCount.ToString(), "width");
                    string[] height = LoginAutomationAgent.GetAllValues("StudentSetup", "Captain", captainCount.ToString(), "height");
                    if (width[0] == "260" && height[0] == "260")
                    {
                        continue;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                    break;
            }
            return --captainCount;
        }

        /// <summary>
        /// Verify all fruits elements count is 9 and height and width are 260
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>int: color count</returns>
        public static int VerifyFruitsSize(AutomationAgent LoginAutomationAgent)
        {
            int fruitsCount = 1;
            for (fruitsCount = 1; fruitsCount <= 10; fruitsCount++)
            {
                if (LoginAutomationAgent.IsElementFound("StudentSetup", "Fruits", fruitsCount.ToString()))
                {
                    string[] height = LoginAutomationAgent.GetAllValues("StudentSetup", "Fruits", fruitsCount.ToString(), "width");
                    string[] width = LoginAutomationAgent.GetAllValues("StudentSetup", "Fruits", fruitsCount.ToString(), "height");
                    if (width[0] == "260" && height[0] == "260")
                    {
                        continue;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                    break;
            }
            return --fruitsCount;
        }

        /// <summary>
        /// Verify Student Setup Title display
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentSetUpTitle(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "StudentSetupTitle");
        }

        /// <summary>
        /// Verify Login button at Login Startup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyLoginStartUpScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "Login");
        }
        /// <summary>
        /// Verifies that try again error comes up
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyTryAgainErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.IsElementFound("StudentSetup", "TryAgainMessage");
        }
        /// <summary>
        /// Veirfy the sun spinner icon after loggin in . 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void VerifySunSpinnerAfterLogIn(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginAutomationAgent.SetText("StudentSetup", "UserName", login.UserName);
            //LoginAutomationAgent.SendText("{BKSP}");
            //LoginAutomationAgent.SendText(login.UserName);
            LoginAutomationAgent.SetText("StudentSetup", "Password", login.Password);
            //LoginAutomationAgent.SendText("{BKSP}");
            //LoginAutomationAgent.SendText(login.Password);
            LoginAutomationAgent.Click("StudentSetup", "LoginButton");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "InprogressIcon");
        }
        /// <summary>
        /// verify the back icon button on the top left corner
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyBackIcon(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "BackButton");
        }
        /// <summary>
        /// Verify the set up icon on teacher admin login
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifySetUpIcon(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "SetUpIcon");
        }

        /// <summary>
        /// Verify Log in button with orange background and white color text.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyOrangeLoginButton(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "OrangLoginButton");
        }

        /// <summary>
        /// Verify Username Inputbox - with faded grey "name" text in the box and Password Inputbox - with faded grey "password" text in the box. 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserNameAndPwdField(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.SetText("StudentSetup", "UserName", "u");
            LoginAutomationAgent.SendText("{BKSP}");
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "FadedGreyUserName");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "UserName");
            LoginAutomationAgent.SetText("StudentSetup", "Password", "p");
            LoginAutomationAgent.SendText("{BKSP}");
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "FadedGreayPasswordName");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "Password");
        }


        /// <summary>
        /// Verify At the bottom right "School Name" relevant to login should be dispalyed.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifySchoolName(AutomationAgent LoginAutomationAgent)
        {
            string schoolName = LoginAutomationAgent.GetTextIn("HomeScreenView", "SchoolName", "Inside", "").Replace("\t\n", "");
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "SchoolLabel", schoolName);
        }

        /// <summary>
        /// Verify Dark Blue Pearson Cloud
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyDarkBluePearsonCloud(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "PearsonCloud");
        }

        /// <summary>
        /// Verify Aeroplane icon with Teacher Admin Login
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyAeroplaneIconWithTeacherAdminLogo(AutomationAgent LoginAutomationAgent)
        {

            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "TeacherLoginIcon");
        }

        /// <summary>
        /// Verify water tides with respect to boat
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyBoatAndTides(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "Boat");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "FrontWaterTides");
        }
        /// <summary>
        /// verifies that there is no school name when no user is logged in
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifyBlankSchoolName(AutomationAgent LoginAutomationAgent)
        {
            string schoolName = LoginAutomationAgent.GetTextIn("HomeScreenView", "SchoolName", "Inside", "").Replace("\t\n", "");
            return schoolName.Equals(null);
        }

        /// <summary>
        /// Click on Reset Password button on already student set up popup
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnResetPassword(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "ResetPassword");
        }

        /// <summary>
        /// Verify SetUp mode after tapping on reset password button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifySetUpModes(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "SetUpMode");
        }

        /// <summary>
        /// Verify Student avatar at login intro screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentAvatar(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "StudentButton");
        }

        /// <summary>
        /// Verify below items:
        /// 1. Copyrights
        /// 2. Term and Conditions
        /// 3. Privacy Statement
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyCopyrightStatements(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "Copyright");
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "TermOfUse");
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "PrivacyStatement");
        }

        /// <summary>
        /// Verify blue cloud background at login intro screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyBlueCloudBackground(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "BlueColorBackground");
        }

        /// <summary>
        /// Verify Teacher Admin Icon
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherAdminIcon(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "TeacherAdminLogo");
        }

        /// <summary>
        /// verify message when only empty password entered
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifyEmptyPasswordErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("Please enter a password to continue.");
        }

        /// <summary>
        /// Verify message when only empty username entered
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifyEmptyUsernameErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("Please enter a username to continue.");
        }

        /// <summary>
        /// Verify empty username and password fields display 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyEmptyUserNameAndPasswordFields(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "EmptyUserName");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "EmptyPassword");
        }

        /// <summary>
        /// Verify preserved username (As we entered incorrectUsername so verifying same) and empty password field display 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyPreservedUserNameAndEmptyPasswordFields(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "PreservedUserName", login.UserName);
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "EmptyPassword");
        }

        /// <summary>
        /// Verify authentication server error message poupup
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAuthenticationServerErrorPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("There was a problem connecting to the server. Please try again.");
        }

        /// <summary>
        /// Verify Help poup up in 3rd attempt
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyHelpPopup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.IsElementFound("StudentSetup", "HelpMessage");
        }

        /// <summary>
        /// Verify No internet message popup when no internet connection are available
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no internet message found</returns>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static bool VerifyNoInternetPopup(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            if (TextonScreen.Contains("You must be connected to the internet to log in") && TextonScreen.Contains("Please check your internet connection and try again"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify sun spineer in student setup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login Object</param>
        public static void VerifySunSpinnerInBeginSetupScreen(AutomationAgent LoginAutomationAgent, Login login)
        {
            LoginAutomationAgent.SetText("StudentSetup", "UserNameField", login.UserName);
            //LoginAutomationAgent.SendText("{BKSP}");
            //LoginAutomationAgent.SendText(login.UserName);
            LoginAutomationAgent.SetText("StudentSetup", "PasswordField", login.Password);
            //LoginAutomationAgent.SendText("{BKSP}");
            //LoginAutomationAgent.SendText(login.Password);
            LoginAutomationAgent.Click("StudentSetup", "BeginSetup");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "InprogressIcon");
        }
        /// <summary>
        /// Verify Sun Spinner in the centre of the screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifySunSpinnerInCentre(AutomationAgent LoginAutomationAgent)
        {
            int width = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressImage", "width")[0]);
            int Xcoordinate = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressImage", "x")[0]);

            int WidthOfNavigationBar = Int32.Parse(LoginAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            LoginAutomationAgent.Sleep();
            return ((WidthOfNavigationBar / 2) == (Xcoordinate) + (width / 2) - 1) ? true : false;
        }
        /// <summary>
        /// Verify Close button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyCloseButton(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
        }
        /// <summary>
        /// Clicks on the begin setup button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBeginSetupButton(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "BeginSetup");
        }
        /// <summary>
        /// Clicks on the login button in teacher admin login screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLoginButton(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("StudentSetup", "LoginButton");
        }
        /// <summary>
        /// Verify help text above keyboard
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyHelpTextAbovekeyborad(AutomationAgent LoginAutomationAgent)
        {
            int YCooridnateHelpText = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "HelpTextOnTeacherLogin", "y")[0]);
            int YCoordinateKeyboard = Int32.Parse(LoginAutomationAgent.GetAllValues("InboxView", "KeyBoardView", "y")[0]);
            if (YCooridnateHelpText < YCoordinateKeyboard)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify help text centered
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyHelpTextCentered(AutomationAgent LoginAutomationAgent)
        {
            int width = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "HelpTextOnTeacherLogin", "width")[0]);
            int Xcoordinate = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "HelpTextOnTeacherLogin", "x")[0]);

            int WidthOfNavigationBar = Int32.Parse(LoginAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            return ((WidthOfNavigationBar / 2) == (Xcoordinate) + (width / 2) - 2) ? true : false;
        }
        /// <summary>
        /// Verify help text above keyborad in student setup screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyHelpTextAbovekeyboradInStudentSetUpScreen(AutomationAgent LoginAutomationAgent)
        {
            int YCooridnateHelpText = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "HelpText", "y")[0]);
            int YCoordinateKeyboard = Int32.Parse(LoginAutomationAgent.GetAllValues("InboxView", "KeyBoardView", "y")[0]);
            if (YCooridnateHelpText < YCoordinateKeyboard)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify help text centered in student set up screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyHelpTextCenteredInStudentSetUpScreen(AutomationAgent LoginAutomationAgent)
        {
            int width = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "HelpText", "width")[0]);
            int Xcoordinate = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "HelpText", "x")[0]);

            int WidthOfNavigationBar = Int32.Parse(LoginAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            return ((WidthOfNavigationBar / 2) == (Xcoordinate) + (width / 2)) ? true : false;
        }
        /// <summary>
        /// Verify cursor above keyboard
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyCursorAbovekeyboradInStudentSetUpScreen(AutomationAgent LoginAutomationAgent)
        {
            int YCooridnateHelpText = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "Cursor", "y")[0]);
            int YCoordinateKeyboard = Int32.Parse(LoginAutomationAgent.GetAllValues("InboxView", "KeyBoardView", "y")[0]);
            if (YCooridnateHelpText < YCoordinateKeyboard)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify help text centered in student set up screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyCursorCenteredInStudentSetUpScreen(AutomationAgent LoginAutomationAgent)
        {
            int Xcoordinate = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "Cursor", "x")[0]);

            int WidthOfNavigationBar = Int32.Parse(LoginAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            return ((WidthOfNavigationBar / 2) == (Xcoordinate) + 64) ? true : false;
        }
        /// <summary>
        /// Verify cursor above keyboard
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyCursorAbovekeyboradInTeacherLogin(AutomationAgent LoginAutomationAgent)
        {
            int YCooridnateHelpText = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "Cursor", "y")[0]);
            int YCoordinateKeyboard = Int32.Parse(LoginAutomationAgent.GetAllValues("InboxView", "KeyBoardView", "y")[0]);
            if (YCooridnateHelpText < YCoordinateKeyboard)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify help text centered in student set up screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyCursorCenteredInTeacherLogin(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.SetText("StudentSetup", "UserName", "u");
            LoginAutomationAgent.SendText("{BKSP}");
            int Xcoordinate = Int32.Parse(LoginAutomationAgent.GetAllValues("StudentSetup", "Cursor", "x")[0]);
            int WidthOfNavigationBar = Int32.Parse(LoginAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            return ((WidthOfNavigationBar / 2) == (Xcoordinate) + 62) ? true : false;
        }

        /// <summary>
        /// Verify hello banner with begin set up screen
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyHelloBannerAtBeginSetUpScreen(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "HelloBanner");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "BeginSetup");
        }

        /// <summary>
        /// Verify error message when teacher try to login into application from student set up screen.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if message found</returns>
        public static bool VerifyTeacherAttemptErrorAtStudentSetupScreen(AutomationAgent LoginAutomationAgent)
        {
            string TextonScreen = LoginAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("You must be a Student to enter Begin Setup Please check your login credentials and try again.");
        }

        /// <summary>
        /// Verify copyright information has changed from 2014 to 2015 in Welcome screen footer
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if copyright contains 2015</returns>
        public static bool VerifyCopyrightYearTag(AutomationAgent LoginAutomationAgent)
        {
            String Text = LoginAutomationAgent.GetTextIn("HomeScreenView", "Copyright", "Inside", "", 0, 0);
            return (Text.Contains("Copyright © 2015 Pearson Education, Inc.  All rights reserved."));
        }

        /// <summary>
        /// Click on Terms of Use link from home screen
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTermsOfUse(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("HomeScreenView", "TermOfUse");
        }

        /// <summary>
        /// Click on Privacy Statement link from home screen
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPrivacyStatement(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("HomeScreenView", "PrivacyStatement");
        }

        /// <summary>
        ///  Close Terms Of Use poupup
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void CloseTermsOfUsePopup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("HomeScreenView", "CloseIconOfTermsOfUse");
        }

        /// <summary>
        /// Close Privacy Statement poupup
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClosePrivacyStatementPopUp(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("HomeScreenView", "CloseIconOfTermsOfUse");
        }

        /// <summary>
        /// Verify copy right statment at term of use and privacy statement poupup
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyCopyrightAtPopup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("HomeScreenView", "CopyRightStatementAtPopup");
        }
        /// <summary>
        /// verify setup icon at the bottom left 
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifySetUpIconAtBottomLeft(AutomationAgent CAadoptionAutomationAgent)
        {
            int Ycoordinate = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("HomeScreenView", "SetUpIcon", "y")[0]);

            if (Ycoordinate < 1400)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify UI Elements at student login screen.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUIelementsAtStudentLogin(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("StudentSetup", "HelloBanner");
            CAadoptionAutomationAgent.VerifyElementFound("StudentSetup", "AeroplaneImage");
            if (CAadoptionAutomationAgent.IsElementFound("StudentSetup", "LoginButton"))
            {
                CAadoptionAutomationAgent.VerifyElementFound("StudentSetup", "LoginButton");
            }
            else
            {
                CAadoptionAutomationAgent.VerifyElementFound("StudentSetup", "BeginSetup");
            }

            CAadoptionAutomationAgent.VerifyElementFound("StudentSetup", "BackButton");
            CAadoptionAutomationAgent.VerifyElementFound("StudentSetup", "StudentNameLabel");
            CAadoptionAutomationAgent.VerifyElementFound("HomeScreenView", "PearsonCloud");
        }

        /// <summary>
        /// Verify Extract content message on fresh installation of app
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyExtractContentMessage(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "ExtractingContent");
        }

        /// <summary>
        /// Wait for content to be extracted when application is freshly installed with bundle content
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void WaitForContentToBeExtracted(AutomationAgent LoginAutomationAgent)
        {
            int tCount = 10;
            while (LoginAutomationAgent.IsElementFound("StudentSetup", "ExtractingContent") && tCount <= 10)
            {
                LoginAutomationAgent.WaitforElement("HomeScreenView", "StudentButton", "", WaitTime.MediumWaitTime);
                if (LoginAutomationAgent.IsElementFound("HomeScreenView", "StudentButton"))
                    break;
                tCount++;
            }
        }

        /// <summary>
        /// Verify sunny spinner is disappeared from screen
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>True: when sun sppiner disappeared</returns>
        public static bool VerifySunnySpinnerDisappeared(AutomationAgent LoginAutomationAgent)
        {
            string[] sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
            return sunSpinnerHiddenProperty[0].Equals("true");
        }


        /// <summary>
        /// verify Hand writing activity does not display in today shelf
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifyHandwritingActivityNotDisplayedInTodayShelf(AutomationAgent LoginAutomationAgent)
        {
            return LoginAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "eReaderView", "HandwritingActivity", "", "Right");
        }

        /// <summary>
        /// Verify second round of practice starts after first round is being done
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static bool VerifySecondRoundPracticeStarts(AutomationAgent LoginAutomationAgent)
        {
            return LoginAutomationAgent.IsElementFound("StudentSetup", "SecondRoundPractice");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoginAutomationAgent"></param>
        /// <param name="login"></param>
        public static void SelectSpecificUserFromList(AutomationAgent LoginAutomationAgent, Login login)
        {
            int tCount = 0;

            string[] sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
            while (sunSpinnerHiddenProperty[0].Equals("false") && tCount <= 20)
            {
                LoginAutomationAgent.WaitforElement("StudentSetup", "UserList", "", WaitTime.MediumWaitTime);
                sunSpinnerHiddenProperty = LoginAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
                if (sunSpinnerHiddenProperty[0].Equals("true") && LoginAutomationAgent.IsElementFound("StudentSetup", "UserList"))
                {
                    break;
                }
            }

            while (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", login.PersonName) && tCount <= 15)
            {
                LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                if (LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", login.PersonName))
                {
                    break;
                }
            }

            LoginAutomationAgent.Click("StudentSetup", "UserLabel", login.PersonName);
        }

        /// <summary>
        /// Verify you need to SetUp Popup elements
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyYouNeedToSetUpPopup(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "ErrorBoy");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "HelpMessage");
            return LoginAutomationAgent.GetText("TEXT").Replace("\n", " ").Contains("You need to be set up on this device.");
        }

        /// <summary>
        /// Verify student list display as per attached excel "K1_iOs_StudentListAsPerSelecdTeacher"
        /// 1. Student Setup on device "Azyiah ALBRECHT BRYAN"
        /// 2. Selected Teacher "Ms. Joshalyn Peirre-Louis"
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentListDisplay(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_StudentListAsPerSelectedTeacher.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string selectedTeacherName = (string)(range.Cells[rCnt, 2]).Text;
                if (selectedTeacherName.Equals(login.PersonName))
                {
                    string studentName = (string)(range.Cells[rCnt, 3]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", studentName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }
                    LoginAutomationAgent.VerifyElementFound("StudentSetup", "UserLabel", studentName);
                }
            }

            ReadContentMethods.ReleaseExcelObjects();
        }

        /// <summary>
        /// Verify student list display as per attached excel "K1_iOs_StudentListAsPerSelecdTeacher"
        /// 1. Student Setup on device "Azyiah ALBRECHT BRYAN"
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherListDisplay(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_TeacherListAsPerSetUpStudent.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string setUpStudentName = (string)(range.Cells[rCnt, 1]).Text;
                if (setUpStudentName.Equals(login.PersonName))
                {
                    string teacherName = (string)(range.Cells[rCnt, 2]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", teacherName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }
                    LoginAutomationAgent.VerifyElementFound("StudentSetup", "UserLabel", teacherName);
                }
            }

            ReadContentMethods.ReleaseExcelObjects();
        }

        /// <summary>
        /// Verify student list sorting as per mentioned Last name in attached excel "K1_iOs_StudentListAsPerSelecdTeacher"
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if sorting is correct</returns>
        public static bool VerifySortingOfStudentName(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_StudentListAsPerSelectedTeacher.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string selectedTeacherName = (string)(range.Cells[rCnt, 2]).Text;
                if (selectedTeacherName.Equals(login.PersonName))
                {
                    string studentName = (string)(range.Cells[rCnt, 3]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", studentName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }

                    Assert.IsTrue(LoginAutomationAgent.GetTextIn("StudentSetup", "UserLabel", "Inside", studentName).Contains(((string)(range.Cells[rCnt, 5]).Text).Replace(" ", "")), "Fail when sorting of student does not work");
                }
            }

            ReadContentMethods.ReleaseExcelObjects();
            return true;
        }

        /// <summary>
        /// Verify student list contains first and last name as mentione in excel "K1_iOs_StudentListAsPerSelecdTeacher"
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if student name contain first name and last name</returns>
        public static bool VerifyStudentFirstAndLastNameDisplay(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_StudentListAsPerSelectedTeacher.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string selectedTeacherName = (string)(range.Cells[rCnt, 2]).Text;
                if (selectedTeacherName.Equals(login.PersonName))
                {
                    string studentName = (string)(range.Cells[rCnt, 3]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", studentName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }

                    string studentFNameInExcel = ((string)(range.Cells[rCnt, 4]).Text).Replace(" ", "");
                    string studentLNameInExcel = ((string)(range.Cells[rCnt, 5]).Text).Replace(" ", "");
                    string studentNameInApp = LoginAutomationAgent.GetTextIn("StudentSetup", "UserLabel", "Inside", studentName).Replace(" ", "");

                    Assert.IsTrue(studentNameInApp.Equals(studentFNameInExcel + studentNameInApp), "Fail when Student first name and last name does not display");
                }
            }

            ReadContentMethods.ReleaseExcelObjects();
            return true;
        }

        /// <summary>
        /// Verify Mr or Ms is prefixed depending on gender or omitted if not specified.
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="ReadContentMethod">ReadContentMethods ReadContentMethod</param>
        /// <param name="login">Login object</param>
        public static void VerifyPrefixDependingOnGender(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_TeacherListAsPerSetUpStudent.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string setUpStudentName = (string)(range.Cells[rCnt, 1]).Text;
                if (setUpStudentName.Equals(login.PersonName))
                {
                    string teacherName = (string)(range.Cells[rCnt, 2]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", teacherName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }

                    string teacherGender = (string)(range.Cells[rCnt, 5]).Text;
                    string techerNameInApp = LoginAutomationAgent.GetTextIn("StudentSetup", "UserLabel", "Inside", teacherName);
                    if (teacherGender.Equals("Female"))
                        Assert.IsTrue(techerNameInApp.Contains("Ms."), "Fail as female teacher does not have prefix Ms.");
                    if (teacherGender.Equals("Male"))
                        Assert.IsTrue(techerNameInApp.Contains("Mr."), "Fail as male teacher does not have prefix Mr.");
                    if (teacherGender.Equals("NA"))
                        Assert.IsTrue(!(techerNameInApp.Contains("Ms.") && techerNameInApp.Contains("Mr.")), "Fail as its not omitted while gender is not mentioned");
                }
            }

            ReadContentMethods.ReleaseExcelObjects();
        }

        /// <summary>
        /// Verify teacher first and last name display in application 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent</param>
        /// <param name="ReadContentMethod">ReadContentMethod</param>
        /// <param name="login">Login</param>
        /// <returns>true: if first name and last name dispaly</returns>
        public static bool VerifyTeacherFirstAndLastNameDisplay(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_TeacherListAsPerSetUpStudent.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string setUpStudentName = (string)(range.Cells[rCnt, 1]).Text;
                if (setUpStudentName.Equals(login.PersonName))
                {
                    string teacherName = (string)(range.Cells[rCnt, 2]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", teacherName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }

                    string studentFNameInExcel = ((string)(range.Cells[rCnt, 3]).Text).Replace(" ", "");
                    string studentLNameInExcel = ((string)(range.Cells[rCnt, 4]).Text).Replace(" ", "");
                    string studentNameInApp = LoginAutomationAgent.GetTextIn("StudentSetup", "UserLabel", "Inside", teacherName).Replace(" ", "");

                    Assert.IsTrue(studentNameInApp.Equals(studentFNameInExcel + studentNameInApp), "Fail when Teacher first name and last name does not display");

                }
            }

            ReadContentMethods.ReleaseExcelObjects();
            return true;
        }

        /// <summary>
        /// Verify sorting of teacher should be according to mentiuoned last name in excel
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent</param>
        /// <param name="ReadContentMethod">ReadContentMetho</param>
        /// <param name="login">Login</param>
        /// <returns>true: if sorting is correct</returns>
        public static bool VerifySortingOfTeacherName(AutomationAgent LoginAutomationAgent, Login login)
        {
            Excel.Range range = ReadContentMethods.ReadExcel("\\TestData\\K1_iOs_TeacherListAsPerSetUpStudent.xlsx", 1);

            for (int rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string setUpStudentName = (string)(range.Cells[rCnt, 1]).Text;
                if (setUpStudentName.Equals(login.PersonName))
                {
                    string teacherName = (string)(range.Cells[rCnt, 2]).Text;
                    if (!LoginAutomationAgent.IsElementFound("StudentSetup", "UserLabel", teacherName))
                    {
                        LoginAutomationAgent.DragElement("StudentSetup", "UserList", 0, -950);
                    }

                    Assert.IsTrue(LoginAutomationAgent.GetTextIn("StudentSetup", "UserLabel", "Inside", teacherName).Contains(((string)(range.Cells[rCnt, 2]).Text).Replace(" ", "")), "Fail when sorting of student does not work");
                }
            }

            ReadContentMethods.ReleaseExcelObjects();
            return true;
        }

        /// <summary>
        /// Verify This teacher has no students. popup element
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent</param>
        /// <returns>true: if poup display </returns>
        public static bool VerifyTeacherHasNoStudent(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "ErrorBoy");
            LoginAutomationAgent.VerifyElementFound("StudentSetup", "HelpMessage");
            return LoginAutomationAgent.GetText("TEXT").Replace("\n", " ").Contains("This teacher has no students.");
        }

        /// <summary>
        /// Verify student name at hello login screen 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent</param>
        /// <param name="login">Login</param>
        /// <return>True: when Student login startup page opens up with the selected student name. </return>
        public static bool VerifyStudentNameAtHelloScreen(AutomationAgent navigationAutomationAgent, Login login)
        {
            return navigationAutomationAgent.GetTextIn("StudentSetup", "StudentNameLabel", "Inside", "").Equals(login.PersonName);
        }

        /// <summary>
        /// Verify app icon 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyAppIcon(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementFound("iPadCommonView", "PSOCAppIcon");
        }

        /// <summary>
        /// Verify Terms of use bolded header
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyTermsOfUseBoldedHeader(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementNotFound("HomeScreenView", "HeaderTermsOfUse");
        }

        /// <summary>
        /// Verify Terms of use popup formating
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyTermsOfUseFormatting(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementNotFound("HomeScreenView", "FormattingTermsOfUse");
        }

        /// <summary>
        /// Verify Privacy statement bolded header
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyPrivacyStatementBoldedHeader(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementNotFound("HomeScreenView", "HeaderPrivacyStatement");
        }

        /// <summary>
        /// Verify Privacy statement popup formatting
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyPrivacyStatementFormatting(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.VerifyElementNotFound("HomeScreenView", "FormattingPrivacyStatement");
        }

        /// <summary>
        /// Verify progress bar display for unit downloading
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if inprogress bar is enabled</returns>
        public static bool VerifyProgressbarForUnitDownloading(AutomationAgent LoginAutomationAgent, string unitNumber)
        {
            string hiddenProperty = LoginAutomationAgent.GetElementProperty("UnitSelection", "ProgressBarForDownloadingUnit", "hidden", unitNumber);
            return hiddenProperty.Equals("false");
        }

        /// <summary>
        /// Wait for sun spinner to be disappeared 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void WaitForSpinnerToBeDisappeared(AutomationAgent navigationAutomationAgent)
        {
            string[] sunSpinnerHiddenProperty = navigationAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
            int tCount = 0;
            while (sunSpinnerHiddenProperty[0].Equals("false") && tCount <= 20)
            {
                navigationAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                sunSpinnerHiddenProperty = navigationAutomationAgent.GetAllValues("StudentSetup", "InprogressIcon", "hidden");
                if (sunSpinnerHiddenProperty[0].Equals("true"))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Verify if any type error message displayed
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true if error popup displayed</returns>
        public static bool VerifyErrorPopup(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon");
        }

    }
}


