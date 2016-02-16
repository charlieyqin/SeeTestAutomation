using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class LoginLogoutTests
    {
        public AutomationAgent LoginLogoutAutomationAgent;

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17664)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ErrorMessageOnUnsuccessfulLogin()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17664: error message on unsuccessful login is a native iOS pop-up"))
            {
                try
                {
                    Login UserLogin = Login.GetLogin("GustadMody");
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, "");
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, UserLogin.Password);
                    LoginLogoutCommonMethods.ClickLoginButton(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyUsernameRequiredPopUp(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.ClickUsernamePasswordOkButton(LoginLogoutAutomationAgent);

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17665)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SupportingTextDisappearsFromUsernamePasswordFields()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17665: Supporting text disappears from username/password fields"))
            {
                try
                {
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, "");
                    string Username = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, "");
                    string Password = LoginLogoutCommonMethods.GetTextFromPassword(LoginLogoutAutomationAgent);
                    Assert.AreEqual(Username, "User Name", "Username not same");
                    Assert.AreEqual(Password, "Password", "Password not same");
                    Login UserLogin = Login.GetLogin("GustadMody");
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, UserLogin.UserName);
                    string newUserName = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, UserLogin.Password);
                    string newPassword = LoginLogoutCommonMethods.GetTextFromPassword(LoginLogoutAutomationAgent);
                    Assert.AreNotEqual(newUserName, "User Name", "new username is same as the previous one");
                    Assert.AreNotEqual(newPassword, "Password", "new password is same as the previous one");

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17669)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LoginScreenFieldsAreAsFollowsUserNamePasswordLogIn()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17669: Login screen fields are as follows:[ User Name / Password / LOG IN ]"))
            {
                try
                {
                    LoginLogoutCommonMethods.ClearUsernamePasswordField(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyUsernameFieldPresent(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPasswordFieldPresent(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyLoginButtonPresent(LoginLogoutAutomationAgent);
                    string userName = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    string password = LoginLogoutCommonMethods.GetTextFromPassword(LoginLogoutAutomationAgent);
                    Assert.AreEqual(userName, "User Name", "Username not same");
                    Assert.AreEqual(password, "Password", "Password not same");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17675)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LoginWithIncorrectPasswordResultsWithErrorMessage()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17675: Log in with incorrect password results with error message"))
            {
                try
                {

                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("WrongPwdTeacher"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyLoginFailed(LoginLogoutAutomationAgent), "Login Failed pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);


                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(17676), WorkItem(17687), WorkItem(15966), WorkItem(16077)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LogInButtonTextChangesWithSpinner()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17676, TC15966, TC16077 & TC17687: Log In button text changes to Logging in with spinner, Initial login download spinner text information: preparing lessons"))
            {
                try
                {
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody"));
                    LoginLogoutCommonMethods.VerifyLoggingInButtonExist(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyLoggingInSpinner(LoginLogoutAutomationAgent);

                    Assert.IsTrue(NavigationCommonMethods.VerifyNoGradeSelectedOnFirstLogin(LoginLogoutAutomationAgent), "Grade is selected On first Login");
                    NavigationCommonMethods.VerifySelectOnlyOneGrade(LoginLogoutAutomationAgent);

                    LoginLogoutCommonMethods.ClickAndContinueGradeSelected(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep1(LoginLogoutAutomationAgent);
                    string step1 = LoginLogoutCommonMethods.GetPrepairingLessonStep1Text(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep2(LoginLogoutAutomationAgent);
                    string step2 = LoginLogoutCommonMethods.GetPrepairingLessonStep2Text(LoginLogoutAutomationAgent);
                    Assert.AreEqual(step1, "prepairing lessons (step 1 of 2)", "Text is not step 1 of 2");
                    Assert.AreEqual(step2, "prepairing lessons (step 2 of 2)", "Text is not step 2 of 2");
                    NavigationCommonMethods.WaitForSystemTrayToAppear(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17679)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UsesFirstAndLastNameAppearInSystemTray()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17679: user's first and last name appear in the system tray"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, login);
                    NavigationCommonMethods.ClickSystemTrayButton(LoginLogoutAutomationAgent);
                    string UserFirstName = LoginLogoutCommonMethods.GetCurrentUserFirstName(LoginLogoutAutomationAgent);
                    string UserLastName = LoginLogoutCommonMethods.GetCurrentUserLastName(LoginLogoutAutomationAgent);
                    string[] name = login.PersonName.Split(' ');
                    Assert.AreEqual(UserFirstName, name[0], "User first name not the same");
                    Assert.AreEqual(UserLastName, name[1], "User last name not the same");
                    NavigationCommonMethods.ClickSystemTrayButton(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17677)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ErrorMessageOnUnsuccessfulLoginIsNativeIosPopUp()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17677: error message on unsuccessful login is a native iOS pop-up"))
            {
                try
                {
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("InvalidCredentials"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyLoginFailed(LoginLogoutAutomationAgent), "Login Failed pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17681)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AppWillRememberLastEnteredUsernameOnLoginScreenSuccessfulLogin()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17681: App will remember the last entered username on the login screen - successful login"))
            {
                try
                {
                    Login UserLogin = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, UserLogin);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    string UserName = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    Assert.AreEqual(UserLogin.UserName, UserName, "Username not similar");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17683)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenWifiOffAndUserInitiallyLogsInThenNetworkUnavailableMessageAppearsRequiresHardReset()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17683: When wifi is off and user INITIALY logs in - then ‘network unavailable’ message appears (requires hard reset)"))
            {
                try
                {
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("StudentBruceSec9Apatton"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNoWifiPopUp(LoginLogoutAutomationAgent), "No Wifi pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17670)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserIsLoggedOutWhenTappingLogOut()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17670: user is logged out when tapping 'log out' "))
            {
                try
                {
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody"));
                    LoginLogoutCommonMethods.ClickSystemTrayButton(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifySystemTrayOpen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.ClickSystemTrayButton(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(19114)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NoRemainingsOfPreviousScreenAreVisibleAfterLogOutUserIsBroughtBackToLoginScreen()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC19114: no remainings of previous screen are visible after log out - user is brought back to the login screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, login);
                    LoginLogoutCommonMethods.ClickSystemTrayButton(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifySystemTrayOpen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.ClickSystemTrayButton(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    Assert.IsFalse(LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent), "System Tray is present");
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17684)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AppRemembersUserForOfflineUseIfUserLoggedInAtLeastOnce()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17684: App remembers the user for offline use - if user logged in at least once"))
            {
                try
                {
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.CloseApplication();
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.VerifyELAPage(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);
                    LoginLogoutAutomationAgent.CloseApplication();
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(20515)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserGetsNoWifiMessageYouMustBeConnectedToTheInternetToLogIn()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC20515: wi-fi gets unavailable before first launch of the PSoC app - user gets no-wifi message (You must be connected to the internet to log in)"))
            {
                try
                {
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("KiranAnantapalli"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNetworkUnavailablePopUp(LoginLogoutAutomationAgent), "Netrowrk Unavailable Pop Up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);

                    string BlankCode = LoginLogoutCommonMethods.GetCodeInIpadSettings(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);

                    LoginLogoutAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, Login.GetLogin("KiranAnantapalli"));
                    Assert.IsFalse(LoginLogoutCommonMethods.VerifyNetworkUnavailablePopUp(LoginLogoutAutomationAgent), "Netrowrk Unavailable Pop Up present");
                    NavigationCommonMethods.VerifyELAPage(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(26212)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenWifiOffAndNonSectionedUserInitiallyLogsInThenNetworkUnavailableMessageAppears()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC26212: When wifi is off and user INITIALY logs in - then ‘network unavailable’ message appears (requires hard reset)"))
            {
                try
                {
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody9"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNetworkUnavailablePopUp(LoginLogoutAutomationAgent), "Netrowrk Unavailable Pop Up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(26213)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenWifiOffAndStaffUserInitiallyLogsInThenNetworkUnavailableMessageAppears()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC26213: When wifi is off and Staff user INITIALY logs in - then ‘network unavailable’ message appears (requires hard reset)"))
            {
                try
                {
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("awhite"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNetworkUnavailablePopUp(LoginLogoutAutomationAgent), "Network Unavailable Pop Up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(30108)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NewPearsonLOGOAppearAfterLaunchingTheApp()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC30108: new pearson LOGO appear after launching the app"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, login.UserName);
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, login.Password);
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNewLogoOnLoginScreen(LoginLogoutAutomationAgent), "New Logo is not present");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(30109)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NewPearsonSplashscreenAndLogoAppearAsExpectedWithTheExternalKeyobard()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC30109: new pearson splashscreen and logo appear as expected - with the external keyobard"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, login.UserName);
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, login.Password);
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNewLogoOnLoginScreen(LoginLogoutAutomationAgent), "New Logo is not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyKeyboardPresence(LoginLogoutAutomationAgent), "Keyboard is not present");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(3)]
        [WorkItem(22044)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ToVerifyOkAlerMessage()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC22044: To verify OK  - Alert message"))
            {
                try
                {
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("WrongPwdTeacher"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyLoginFailed(LoginLogoutAutomationAgent), "Login Failed pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17682)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void AppWillNotRememberLastEnteredUsernameOnLoginScreenLoginFailed()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17682: App will NOT remember the last entered username on the login screen - login failed"))
            {
                try
                {
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    string username = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("WrongPwdTeacher"));
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyLoginFailed(LoginLogoutAutomationAgent), "Login Failed Pop up body is note present");
                    LoginLogoutAutomationAgent.ApplicationClose();
                    LoginLogoutAutomationAgent.Sleep();
                    LoginLogoutAutomationAgent.LaunchApp();
                    LoginLogoutAutomationAgent.Sleep();
                    string newUsername = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    Assert.AreEqual(username, newUsername, "username and new username are not equal");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(19374)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UserThatHadLoggedOutAndMovedToLoginScreenCanLogBackIn()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC19374: user that had logged out and moved to login screen can log back in"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody9");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, login);
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent), "System Tray not visible");
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    Assert.IsFalse(LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent), "System Tray still visible");
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    string username = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    Assert.AreEqual(username, login.UserName);
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, login.Password);
                    LoginLogoutCommonMethods.ClickOnLoginButton(LoginLogoutAutomationAgent);
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent), "System Tray not visible");
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    Assert.IsFalse(LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent), "System Tray still visible");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17666)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void RemovalIconXExistsToRightOfUsernameAndPasswordFields()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17666: removal icon (X) exists to the right of the username and password fields"))
            {
                try
                {
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, "gmodyt8");
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyXIconInUsernameField(LoginLogoutAutomationAgent));
                    LoginLogoutCommonMethods.ClickXIconInUsernameField(LoginLogoutAutomationAgent);
                    String TextInUsername = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    Assert.AreEqual<String>(TextInUsername, "User Name");
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, "kitten77");
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyXIconInPasswordField(LoginLogoutAutomationAgent));
                    LoginLogoutCommonMethods.ClickXIconInPasswordField(LoginLogoutAutomationAgent);
                    String TextInPassword = LoginLogoutCommonMethods.GetTextFromPassword(LoginLogoutAutomationAgent);
                    Assert.AreEqual<String>(TextInPassword, "Password");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(30110)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void AllItemsExistingInAppAreVisibleAfterSplashChange()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC30110: all items existing in app are clearly visible after logo/splash change"))
            {
                try
                {
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyNewLogoOnLoginScreen(LoginLogoutAutomationAgent);
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, login);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17689)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LoginScreenCopyrightNoticeIsDisplayedAtBottom()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17689: login screen - copyright notice is displayed at the bottom"))
            {
                try
                {
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyCopyrightNotice(LoginLogoutAutomationAgent), "Copyright notice is not present");
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyTermsOfUseLink(LoginLogoutAutomationAgent), "Terms of use Link is not present");
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyPrivacyPolicyLink(LoginLogoutAutomationAgent), "Privacy Policy Link is not present");
                    LoginLogoutCommonMethods.VerifyUnderlinedLinks(LoginLogoutAutomationAgent);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(15932)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DefaultTextInEditFieldOfLogInScreenIsContrastWithBackground()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC15932: Default text user name & password in the edit field of Log in Screen should be contrast with background"))
            {
                try
                {
                    LoginLogoutCommonMethods.ClearUsernamePasswordField(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyUsernameFieldPresent(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPasswordFieldPresent(LoginLogoutAutomationAgent);
                    string userName = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    string password = LoginLogoutCommonMethods.GetTextFromPassword(LoginLogoutAutomationAgent);
                    Assert.AreEqual(userName, "User Name", "Username not same");
                    Assert.AreEqual(password, "Password", "Password not same");
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyTextInContrastWithBackground(LoginLogoutAutomationAgent), "User Name and Password are not in contrast with the background");

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(17667)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void PasswordTextIsHidden()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17667: Password text is hidden"))
            {
                try
                {
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, "kitten77");
                    LoginLogoutCommonMethods.VerifyPasswordTextIsHidden(LoginLogoutAutomationAgent);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(3)]
        [WorkItem(17668)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LogingInWithEmptyPasswordGivesErrorMessage()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17668: Loging in with empty password gives error message"))
            {
                try
                {
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.SetTextInUsername(LoginLogoutAutomationAgent, "gmodyt8");
                    LoginLogoutCommonMethods.SetTextInPassword(LoginLogoutAutomationAgent, "");
                    LoginLogoutCommonMethods.ClickLoginButton(LoginLogoutAutomationAgent);
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyPasswordRequiredPopUp(LoginLogoutAutomationAgent), "Password Required pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                    Assert.IsFalse(LoginLogoutCommonMethods.VerifyPasswordRequiredPopUp(LoginLogoutAutomationAgent), "Password Required pop up still present");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17682)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void AppWillNotRememberTheLastEnteredUsernameOnLoginScreenLoginFailed()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC17682: App will NOT remember the last entered username on the login screen - login failed"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, login);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    string FirUserUsername = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    Assert.IsNotNull(FirUserUsername);
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, Login.GetLogin("InvalidCredentials"));
                    LoginLogoutCommonMethods.VerifyLoginFailed(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.CloseApplication(LoginLogoutAutomationAgent);
                    LoginLogoutAutomationAgent.LaunchApp();
                    LoginLogoutCommonMethods.VerifyLoginScreen(LoginLogoutAutomationAgent);
                    string username = LoginLogoutCommonMethods.GetTextFromUsername(LoginLogoutAutomationAgent);
                    Assert.AreEqual<string>(FirUserUsername, username);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(19361)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserSelectGradeTwelveDownloadedPreparingLessonsOverlay()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC19361: When user selects a grade12 to be downloaded user will see overlay preparing lessons (step 1 of 1)(initial download)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, login);
                    if (!LoginLogoutCommonMethods.VerifyIfFirstLoginForNonSectionedUser(LoginLogoutAutomationAgent))
                    {
                        NavigationCommonMethods.NavigateToELA(LoginLogoutAutomationAgent);
                        NavigationCommonMethods.VerifyAddGradeContinueButtonDisabled(LoginLogoutAutomationAgent);
                    }
                    LoginLogoutCommonMethods.AddSpecifiedGrade(LoginLogoutAutomationAgent, 12);
                    LoginLogoutCommonMethods.VerifyPrepairingLessonStepOne(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.WaitForSystemTrayToAppear(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22143)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionedStudentBehaviourInitialLogin()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC22143: sectioned student proper behavior - initial login (if there's no sectioned grade)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, login);
                    LoginLogoutCommonMethods.ClickAndContinueGradeSelected(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep1(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep2(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.WaitForSystemTrayToAppear(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22147)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionedTeacherBehaviourInitialLogin()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC22147: IDL: sectioned Teacher proper behavior - initial login (fresh install)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, login);
                    LoginLogoutCommonMethods.ClickAndContinueGradeSelected(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep1(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep2(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.WaitForSystemTrayToAppear(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22157), WorkItem(16073)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void InitialLoginAfterNoWiFiAnotherUserLoggedIn()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC22157 & TC16073: IDL: initial login for sectioned & non-sectioned user - after no-wifi --> another user logged in"))
            {
                try
                {
                    Login login1 = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, login1);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    Assert.IsTrue(LoginLogoutCommonMethods.VerifyNoWifiPopUp(LoginLogoutAutomationAgent), "No Wifi pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(LoginLogoutAutomationAgent);
                    LoginLogoutAutomationAgent.ApplicationClose();

                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);
                    LoginLogoutAutomationAgent.LaunchApp();
                    Login login = Login.GetLogin("GustadMody9");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, login);
                    Assert.IsTrue(NavigationCommonMethods.VerifyAddGradeContinueButtonDisabled(LoginLogoutAutomationAgent), "Continue button is not present");
                    int UnitNo1 = NavigationCommonMethods.AddGradeForNonSectionedUser(LoginLogoutAutomationAgent);
                    Assert.IsFalse(LoginLogoutCommonMethods.VerifyGradeIsPresent(LoginLogoutAutomationAgent, 9), "Grade is present");
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(23124)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionedStudentProperBehaviourInitialLogin()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC23124: IDL: sectioned student proper behavior - initial login (app was freshly installed)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(LoginLogoutAutomationAgent, login);
                    LoginLogoutCommonMethods.ClickAndContinueGradeSelected(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep1(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPreparingLessonsStep2(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.WaitForSystemTrayToAppear(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifySystemTrayButtonAvaialble(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(26214)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AppRemembersUserAfterKillForOfflineUseIfUserLoggedInAtLeastOnce()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC26214: App remembers the user for offline use - if user logged in at least once"))
            {
                try
                {
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, true);
                    LoginLogoutAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(LoginLogoutAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.VerifyELAPage(LoginLogoutAutomationAgent);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginLogoutAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.Sleep(2000);
                    LoginLogoutAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginLogoutAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
