using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pearson.PSCAutomation._212App
{
    public static class LoginLogoutCommonMethods
    {

        /// <summary>
        /// Verifies UserName Field exists on the login screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyUsernameFieldPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "UserName");
        }
        /// <summary>
        /// Verifies Password Field Exists on the login screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyPasswordFieldPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "Password");
        }
        /// <summary>
        /// verifies login button present on the login screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyLoginButtonPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "Login");
        }
        /// <summary>
        /// click on the ok button when login credentials are invalid and message pops up
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">Automation object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void ClickUsernamePasswordOkButton(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "OkButton");
        }
        /// <summary>
        /// verifies that no internet connection message pops up  
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns> string object: true if message exists</returns>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static string NoInternetConnectPopupHeader(AutomationAgent LoginLogoutAutomationAgent)
        {
            return (LoginLogoutAutomationAgent.IsElementFound("LoginView", "NoInternetConnection")).ToString();
        }
        /// <summary>
        /// check that that message of unsuccessful login exists
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object :true if the message exists</returns>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static bool VerifyLoginFailed(AutomationAgent LoginLogoutAutomationAgent)
        {
            while (LoginLogoutAutomationAgent.IsElementFound("LoginView", "LoggingInButton"))
            {
                LoginLogoutAutomationAgent.Sleep();
            }
            if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "LoginFailedPopup") && LoginLogoutAutomationAgent.IsElementFound("LoginView", "LoginFailedPopupBody"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// click on the ok button during unsuccesful login
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickOnOkButton(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "OkButton");
        }
        /// <summary>
        /// verifies that after clicking on login button it changes to loggingIn
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void VerifyLoggingInButtonExist(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "LoggingInButton");
        }
        /// <summary>
        /// verifies that after clicking on login button the spinner exists
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void VerifyLoggingInSpinner(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "LoggingInSpinner");
        }
        /// <summary>
        /// Sets the text passed in Username Field
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <param name="username">string: text</param>
        public static void SetTextInUsername(AutomationAgent LoginLogoutAutomationAgent, string username)
        {
            LoginLogoutAutomationAgent.SetText("LoginView", "UserName", "u");
            LoginLogoutAutomationAgent.SendText("{BKSP}");
            LoginLogoutAutomationAgent.SendText(username);
        }
        /// <summary>
        /// Sets the text passed in Password field
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <param name="password">string: text</param>
        public static void SetTextInPassword(AutomationAgent LoginLogoutAutomationAgent, string password)
        {
            LoginLogoutAutomationAgent.SetText("LoginView", "Password", "p");
            LoginLogoutAutomationAgent.SendText("{BKSP}");
            LoginLogoutAutomationAgent.SendText(password);
        }
        /// <summary>
        /// Clicks on the Log in Button present in the Log in Screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLoginButton(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "Login");
            NavigationCommonMethods.WaitForSystemTrayToAppear(LoginLogoutAutomationAgent);
        }
        /// <summary>
        /// Verifies the Pop up message generated when username left empty 
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifyUsernameRequiredPopUp(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "LoginFailedPopup");
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "UserNameRequiredPopUp");
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "OkButton");
        }
        /// <summary>
        /// Gets the text from Username Field
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text in Username field</returns>
        public static string GetTextFromUsername(AutomationAgent LoginLogoutAutomationAgent)
        {
            string text = LoginLogoutAutomationAgent.GetTextIn("LoginView", "UserName", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Gets the text from Password Field 
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text in password field</returns>
        public static string GetTextFromPassword(AutomationAgent LoginLogoutAutomationAgent)
        {
            string text = LoginLogoutAutomationAgent.GetTextIn("LoginView", "Password", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Gets the First Name of the Current User Logged in
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>string: First name of the Current User</returns>
        public static string GetCurrentUserFirstName(AutomationAgent LoginLogoutAutomationAgent)
        {
            string s = LoginLogoutAutomationAgent.GetTextIn("SystemTrayMenuView", "CurrentUserName", "Inside", "");
            string[] s1 = s.Split(' ');
            return s1[0];
        }
        /// <summary>
        /// Gets the Last Name of the Current User Logged in
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Last name of the current user</returns>
        public static string GetCurrentUserLastName(AutomationAgent LoginLogoutAutomationAgent)
        {
            string s = LoginLogoutAutomationAgent.GetTextIn("SystemTrayMenuView", "CurrentUserName", "Inside", "");
            string[] s1 = s.Split(' ');
            return s1[1].Replace("\t\n", "");
        }
        /// <summary>
        /// Verifies the Login screen containing username, password field and Login Button
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifyLoginScreen(AutomationAgent LoginLogoutAutomationAgent)
        {
            if (NavigationCommonMethods.IsSystemTrayAvailable(LoginLogoutAutomationAgent))
            {
                NavigationCommonMethods.Logout(LoginLogoutAutomationAgent, true);
            }
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "UserName");
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "Password");
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "Login");
        }
        /// <summary>
        /// Verifies the Pop Up generated when Wifi is off 
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyNoWifiPopUp(AutomationAgent LoginLogoutAutomationAgent)
        {
            if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "InternetOfflinePopUp") && LoginLogoutAutomationAgent.IsElementFound("LoginView", "InternetOfflinePopUpBody"))
                return true;
            else if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "NetworkUnavailablePopUp") && LoginLogoutAutomationAgent.IsElementFound("LoginView", "NetworkUnavailablePopUpBody"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies System tray is Open
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifySystemTrayOpen(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("SystemTrayMenuView", "SystemTrayHighLighted");
        }
        /// <summary>
        /// Clicks on the System Tray Button 
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickSystemTrayButton(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
        }
        /// <summary>
        /// Verifies that System Tray button is available after Login is present or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent"></param>
        /// <returns>bool: true(if system tray button available), false(if system tray button is not avaialble)</returns>
        public static bool VerifySystemTrayButtonAvaialble(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton");
        }
        /// <summary>
        /// Verifies User is on Dashboard
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyDashboard(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("DashboardView", "MyDashboardTitle");
        }

        /// <summary>
        /// Verifies Network Unavaialble Pop Up present
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Pop Up avaialble), flase(if Pop Up not avaialble)</returns>
        public static bool VerifyNetworkUnavailablePopUp(AutomationAgent LoginLogoutAutomationAgent)
        {
            if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "NetworkUnavailablePopUp") && LoginLogoutAutomationAgent.IsElementFound("LoginView", "NetworkUnavailablePopUpBody"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets the code from Pearson App config code in iPad settings
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent"></param>
        /// <returns></returns>
        public static string GetCodeInIpadSettings(AutomationAgent LoginLogoutAutomationAgent)
        {

            LoginLogoutAutomationAgent.SendText("{HOME}");
            LoginLogoutAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (LoginLogoutAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                LoginLogoutAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            LoginLogoutAutomationAgent.SendText("Settings");
            LoginLogoutAutomationAgent.ClickCoordinate(196, 242, 1);
            //Swipe check

            for (int i = 0; i < 4; i++)
            {
                if (LoginLogoutAutomationAgent.IsElementFound("iPadCommonView", "iPadTableView"))
                {
                    LoginLogoutAutomationAgent.SwipeElement("iPadCommonView", "iPadTableView", Direction.Down, 500, 2000);
                }
            }
            LoginLogoutAutomationAgent.Click("iPadCommonView", "AppNameInSettings");

            string AppCode = LoginLogoutAutomationAgent.GetTextIn("iPadCommonView", "AppCode212", "NATIVE", "Inside", "");
            for (int j = 0; j < 4; j++)
            {
                if (LoginLogoutAutomationAgent.IsElementFound("iPadCommonView", "iPadTableView"))
                {
                    LoginLogoutAutomationAgent.SwipeElement("iPadCommonView", "iPadTableView", Direction.Up, 500, 2000);
                }
            }
            LoginLogoutAutomationAgent.SendText("{HOME}");
            return AppCode;
        }

        /// <summary>
        /// Clears the username and password fields
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClearUsernamePasswordField(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.SetText("LoginView", "UserName", "u");
            LoginLogoutAutomationAgent.SendText("{BKSP}");
            LoginLogoutAutomationAgent.SetText("LoginView", "Password", "p");
            LoginLogoutAutomationAgent.SendText("{BKSP}");
        }
        /// <summary>
        /// Verify New Logo on Login Screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Logo avaialble), flase(if Logo not avaialble)</returns>
        public static bool VerifyNewLogoOnLoginScreen(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("LoginView", "LoginScreenLogo");
        }
        /// <summary>
        /// Clicks on Terms Of Use Link present in the log in screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickTermsOfUseLinkOnLogInScreen(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "TermsOfUse");
        }
        /// <summary>
        /// Verifies If Terms of Use Overlay is present or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyTermsOfUseOverlayPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("LoginView", "TermsOfUseOverlay");
        }

        /// <summary>
        /// Verify X Icon in Password Field present or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyXIconInPasswordField(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("LoginView", "XIconInPassword");
        }

        /// <summary>
        /// Verify X Icon in Username Field present or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyXIconInUsernameField(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("LoginView", "XIconInUsername");
        }

        /// <summary>
        /// Click X Icon in Username Field
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickXIconInUsernameField(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "XIconInUsername");
        }
        /// <summary>
        /// Click X Icon in Password Field
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickXIconInPasswordField(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "XIconInPassword");
        }
        /// <summary>
        /// Verifies Copyright notice Present at the bottom of the Log in screen or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCopyrightNotice(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.WaitForElement("LoginView", "CopyrightNotice", WaitTime.DefaultWaitTime);
            int xPos = Int32.Parse(LoginLogoutAutomationAgent.GetAllValues("LoginView", "CopyrightNotice", "x")[0]);
            if (xPos == 478)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Terms Of Use Link Present at the bottom of the Log in screen or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyTermsOfUseLink(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.WaitForElement("LoginView", "TermsOfUse", WaitTime.DefaultWaitTime);
            int xPos = Int32.Parse(LoginLogoutAutomationAgent.GetAllValues("LoginView", "TermsOfUse", "x")[0]);
            if (xPos == 1190)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Privacy Policy link Present at the bottom of the Log in screen or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPrivacyPolicyLink(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.WaitForElement("LoginView", "PrivacyPolicy", WaitTime.DefaultWaitTime);
            int xPos = Int32.Parse(LoginLogoutAutomationAgent.GetAllValues("LoginView", "PrivacyPolicy", "x")[0]);
            if (xPos == 1422)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the Links Terms of Use and Privacy Policy are underlined 
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnderlinedLinks(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "TOUandPPLink");
        }
        /// <summary>
        /// Verifies Supporting text in the text fields of Log in screen are in contrast with the backgroound
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if in contrast), false(if not in contrast)</returns>
        public static bool VerifyTextInContrastWithBackground(AutomationAgent LoginLogoutAutomationAgent)
        {
            string usernameFieldColor = LoginLogoutAutomationAgent.GetAllValues("LoginView", "UserName", "textColor")[0];
            string passwordFieldColor = LoginLogoutAutomationAgent.GetAllValues("LoginView", "Password", "textColor")[0];
            string usernameColor = LoginLogoutAutomationAgent.GetAllValues("LoginView", "UsernameLabel", "textColor")[0];
            string passwordColor = LoginLogoutAutomationAgent.GetAllValues("LoginView", "PasswordLabel", "textColor")[1];
            if (usernameFieldColor == "0x000000" && passwordFieldColor == "0x000000" && usernameColor == "0x666666" && passwordColor == "0x666666")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify Password field is hidden or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPasswordTextIsHidden(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("LoginView", "PasswordHidden");
        }
        /// <summary>
        /// Verifies the Password Required pop up present or not
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPasswordRequiredPopUp(AutomationAgent LoginLogoutAutomationAgent)
        {
            if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "PasswordRequiredPopUp") &&
               LoginLogoutAutomationAgent.IsElementFound("LoginView", "LoginFailedPopup"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on the Log in Button present in the Log in Screen
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickLoginButton(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "Login");
        }

        public static void CloseTermsOfUseOverlay(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.Click("LoginView", "CloseTermsOfUse");
        }

        public static bool VerifyTermsOfUseText(AutomationAgent LoginLogoutAutomationAgent)
        {
            string actualTermsOfUse = LoginLogoutAutomationAgent.GetElementText("LoginView", "TermsOfUseBody");
            string expectedTermsOfUse = "\nWelcome to our Application for the Pearson System of Courses (“PSoC” and the Application hereinafter called the “App” or “Application”).  The Application operates on an App Supported Device from which you may access Pearson’s PSoC product, which is a software application that delivers Math and ELA instructional content on a mobile digital device or other computing system.  The terms of Use set out below govern the use of the App and the software and digital content contained within it (the “Terms of Use”).  “App Supported Device” means a mobile, computer or other electronic device with an operating system that is capable of running and supporting the App.\n\nPearson Education, Inc., and its subsidiaries and affiliates (collectively referred to herein as \"Pearson\", “we”, “our” or “us”) are providing you this Application based on your school or school district’s adoption of the PSoC.\n\n\nYour use of the Application is subject to all terms and policies stated herein (including the Privacy Statement). If you are under 18 years of age, please be sure to read this Terms of Use with your teacher, parent or guardian and ask questions about things you do not understand.\n\n\nIt is important to us that the Application provides you with a helpful and reliable experience. To protect our rights and yours, we have prepared the Terms of Use that apply to all users of the Application. Please note that the usage terms and/or privacy policies of other Pearson and third-party products and services linked to or from this Application may vary from the terms herein so please make sure to check the terms and policies applicable to such other products and applications prior to use.\n\n\nUser License:\n\nPursuant to a license granted to your school or school district, you are granted a limited, personal, non-exclusive, non-assignable, and non-transferable license to access, install and use the Application for non-commercial, personal use only on an App Supported Device. Except as stated herein, you may not adapt, download, revise, broadcast, reverse engineer, duplicate, publish, modify, disseminate, display, perform, transfer, or otherwise distribute any content or other material on the Application, unless specifically authorized by Pearson or this Terms of Use.\n\nYou agree that the Application may automatically download and install updates, upgrades or other enhancements from time to time.  You acknowledge and agree that Pearson shall have no obligation to support any previous version(s) of the Application that may be discontinued due any update of the Application.  This Terms of Use shall apply to any new version of the Application if such version is not distributed with a separate terms of use.\n\nUse of the Application for any purpose other than as contemplated in the Terms of Use is a violation of Pearson’s and/or its licensors’ copyright and proprietary rights. All rights not expressly granted herein are reserved by Pearson.\n\nCertain features of this Application may be provided by third parties and the use of such features may be conditioned upon your agreement to such third parties’ terms of use and privacy policies. You understand that the Terms of Use apply only to the parts of the Application that reside on Pearson’s (or its service provider’s) servers and not to those that reside on third-party servers not controlled by Pearson.\n\nUploads:\n\nTo the extent that the Application may provide you with an opportunity to upload material (“Uploads”), be advised that Pearson has no obligation to screen, edit, or review such uploads prior to their appearance in the Application, and Uploads do not necessarily reflect the views of Pearson. To the fullest extent permitted by applicable laws, in no event shall Pearson have any responsibility or liability for the Uploads (or the loss thereof for any reason) or for any claims, damages, or losses resulting from their use (or loss) and/or appearance on the Application. Please keep in mind that Uploads may be discoverable by, and viewable to, other users of the Application. Pearson reserves the right to monitor the Uploads and to remove anything which it considers in its absolute discretion to be offensive, ineffective or otherwise in breach of the Terms of Use or for any other reason as Pearson deems necessary.\n\nYou hereby represent and warrant that your Uploads shall not contain any viruses or other contaminating or destructive devices or features; that your Uploads will not contain any defamatory, indecent, offensive, tortious, or otherwise unlawful material or content; and that your Uploads will not be used to carry out or solicit any unlawful activity and/or be used to make commercial solicitations. You further represent and warrant that you have all necessary rights in and to the Uploads to be used in connection with the Application and that your Uploads will not infringe any intellectual, proprietary or other rights of third parties.\n\nRestrictions and Prohibited Conduct:\n\nAs a condition of your use of the Application, you warrant to Pearson that you will not use the Application for any purpose that is unlawful or prohibited by the Terms of Use. You agree not to obtain or attempt to obtain any materials or information not intentionally made available to you on the Application.\n\nExcept as may be expressly permitted by these App Terms of Use and to the maximum extent permitted by applicable local law, you may not, directly or indirectly: (i) use the App on any device other than an App Supported Device; (ii) use, copy, reproduce, modify, distribute copies of, display publicly or transmit the App; (iii) open, service or tamper with the App, disassemble, reverse engineer, emulate, decompile, tamper with, create derivative works from the App or the digital content contained therein or otherwise attempt to discover the source code of the App or the technology used to provide App, or attempt to reduce the App to human-readable form; (iv) bypass, modify, defeat, tamper with or circumvent any of the security features of the App, including altering any digital rights management (“DRM”) functionality of the App; (v) share access to the App, whether through a network, resale or other means; (vi) transfer the App (or any individual component thereof) from one device to another device or computer; (vii) infringe, violate, or interfere with any patent, trademark, trade secret, copyright, right of publicity or any other right of any party; (viii) violate any law, rule or regulation of the local laws applicable to you in your use of the App; (ix) sublicense, assign in whole or in part, rent, lease, lend, resell or in any way transfer any rights to all or any portion of the App to any third party; (x) broadcast, transmit or distribute any digital content in any manner, such as online streaming or making the digital content available for download; (xi) interfere with or damage the App, including, through the use of viruses, cancel bots, Trojan horses, harmful code, flood pings, denial of service attacks, packet or IP spoofing, forged routing or electronic mail address information or similar methods or technology; (xii) delete, destroy or alter in any manner the proprietary rights notices, markings and legends appearing on the App; or (xiii) assist or encourage any third party in engaging in any activity prohibited by these Terms of Use, or any applicable local laws or regulations.\n\nPearson reserves the right at any time, and from time to time, to discontinue, temporarily or permanently, the Application or any part thereof or terminate any user’s access to the Application or any part thereof if you violate the Terms of Use.\n\nLinks to and from Other Websites:\n\nThe Application may provide links to other third-party websites or resources (collectively, “3P Sites”). Because we do not control such 3P Sites you acknowledge and agree that Pearson is not responsible or liable for the content, products or performance of those 3P Sites, and you hereby irrevocably waive any claim against Pearson with respect to such sites. Pearson reserves the right to terminate any link at any time without notice. The inclusion of a link to such 3P Sites does not constitute or imply an endorsement, authorization, sponsorship, or affiliation by Pearson of that 3P Site, or any products or services provided therein. The information practices of those 3P Sites are not covered by the Terms of Use or any other policies or terms applicable to the Application. We recommend that you review any terms of use and privacy policy of these 3P Sites linked to the Application before providing any information to those websites or using their products and services.\n\nPlease note that the Application may also provide links to other sites brought to you by Pearson. The privacy statement and terms of use of other Pearson sites may vary from the Terms of Use. Please review the privacy statements, terms of use and other policies or terms that may apply to other Pearson sites prior to your use of such sites.\n\nCopyright and Trademark Notices:\n\n\nThe entire content of the Application and any supporting software are the proprietary property of Pearson and/or its licensors, and are protected by U.S. and international copyright and other intellectual property laws. The reproduction, redistribution, modification or publication of any part of the Application without the express written consent of Pearson and/or its licensors is strictly prohibited.\n\nUnless otherwise indicated, trademarks that appear on this Application are trademarks of Pearson or its affiliates. All other trademarks not owned by Pearson or its affiliates that appear in the Application are the property of their respective owners, who may or may not be affiliated with, connected to, or sponsored by Pearson or its affiliates. You agree not to display, disparage, dilute, or taint our trademarks or use any confusing similar marks or use our trademarks in such a way that would misrepresent the ownership of such marks. Any permitted use of our trademarks by you shall be to the benefit of Pearson.\n\nDisclaimer of Warranties:\n\nYOU EXPRESSLY UNDERSTAND AND AGREE THAT:\n\n(a) YOUR USE OF THE APPLICATION IS AT YOUR OWN RISK. THE APPLICATION IS PROVIDED ON AN “AS IS” AND “AS AVAILABLE” BASIS. YOU ACKNOWLEDGE AND AGREE THAT NO WARRANTIES OF ANY KIND, WHETHER EXPRESS OR IMPLIED, ARE MADE BY PEARSON OR ITS LICENSORS AND PEARSON AND ITS LICENSORS EXPRESSLY DISCLAIM ALL WARRANTIES OF ANY KIND, WHETHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT;\n\n(b) ANY MATERIAL UPLOADED/DOWNLOADED OR OTHERWISE OBTAINED FROM THE APPLICATION IS DONE AT YOUR OWN DISCRETION AND RISK; NEITHER PEARSON NOR ITS LICENSORS SHALL BE LIABLE, AND YOU WILL BE SOLELY RESPONSIBLE, FOR ANY AND ALL LOSS, OR CORRUPTION, OF DATA UPLOADED OR INPUTTED BY YOU THROUGH THE USE OF THE APPLICATION, AND ALL SERVICING, REPAIR, OR CORRECTION AND ANY DAMAGE TO YOUR HARDWARE AND SOFTWARE THAT MAY RESULT FROM THE USE OF THE APPLICATION.\n\nLimitation of Liability:\n\nIN NO EVENT SHALL PEARSON OR ITS EMPLOYEES, AGENTS, LICENSORS, OR CONTRACTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, CONSEQUENTIAL, PUNITIVE OR EXEMPLARY DAMAGES, DAMAGES FOR LOSS OF PROFITS, GOODWILL, USE OF DATA, OR OTHER INTANGIBLE LOSSES (EVEN IF SUCH PARTY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES), RESULTING FROM: (i) THE LOSS OF DATA AND/OR THE USE OR THE INABILITY TO USE THE APPLICATION; (ii) THE COST OF PROCUREMENT OF SUBSTITUTE GOODS AND SERVICES RESULTING FROM ANY GOODS, DATA, INFORMATION OR SERVICES PURCHASED OR OBTAINED OR MESSAGES RECEIVED OR TRANSACTIONS ENTERED INTO THROUGH OR FROM THE APPLICATION; (iii) UNAUTHORIZED ACCESS TO OR ALTERATION OF YOUR TRANSMISSIONS OR DATA; (iv) STATEMENTS OR CONDUCT OF ANY THIRD PARTY ON THE APPLICATION; OR (v) ANY OTHER MATTER RELATING TO THE APPLICATION.\n\nSome jurisdictions do not allow the exclusion of certain warranties or the limitation or exclusion of liability for incidental or consequential damages. Accordingly, the limitations above may not apply to you.\n\nDigital Millennium Copyright Act Compliance:\n\nIf you have any copyright concerns about any materials posted on the Application by others, please let us know. We comply with the provisions of the Digital Millennium Copyright Act applicable to Internet service providers (17 U.S.C. § 512). Unless otherwise stated in any specific DMCA designation provided by Pearson, please provide us with written notice (“Notice”) by contacting our Designated Agent at the following address:\n\nDMCA Designated Agent \nPearson Education, Inc. \n200 Old Tappan Road \nOld Tappan, NJ 07675 \nFacsimile: (201)785-2721 \nemail: dmca.agent@pearsoned.com \n\nTo be effective, the Notice must include the following:\n\nA physical or electronic signature of the owner, or a person authorized to act on behalf of the owner, (“Complaining Party”) of an exclusive right that is allegedly being infringed upon;\n\nInformation reasonably sufficient to permit Pearson to contact the Complaining Party, such as an address, telephone number, and if available, an electronic mail address;\n\nIdentification of the allegedly infringing material on the Application (“Infringing Material”), and information reasonably sufficient to permit Pearson to locate such material on the Application;\n\nIdentification of the copyrighted work claimed to have been infringed upon (“Infringed Material”), or if multiple copyrighted works on the Application are covered by a single Notice, a list of each copyrighted work claimed to have been infringed (please be specific as to which Infringing Material is infringing on which Infringed Material);\n\nA statement that the Complaining Party has a good faith belief that use of Infringing Material in the manner complained of is not authorized by the copyright owner, its agent, or the law; and\n\nA statement that the information in the Notice is accurate, and under penalty of perjury, that the Complaining Party is the owner or is authorized to act on behalf of the owner of an exclusive right that is allegedly infringed.\n\nGeneral Information:\n\nThe Terms of Use govern your use of the Application. You also may be subject to additional terms and conditions that may apply when you use affiliated services, third-party content or third-party software. The failure of Pearson to exercise or enforce any right or provision of the Terms of Use shall not constitute a waiver of such right or provision.\n\nOwnership:\n\nThis Application is owned and operated by Pearson and the contents of this Application are protected by copyright of Pearson and/or its licensors.\n\nViolations:\n\nPlease report any violations of the Terms of Use by Contacting Us.\n\nLast Update to Terms of Use: August, 2014\nCopyright © 2014 Pearson Education, Inc. All rights reserved.\n\n\n\n\n";
            return actualTermsOfUse == expectedTermsOfUse;
        }
        /// <summary>
        /// Select Grade on initial login and click on continue button
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>


        public static void ClickAndContinueGradeSelected(AutomationAgent LoginLogoutAutomationAgent)
        {
            bool notAddedGrade = false;
            int i = 2;
            while (!notAddedGrade)
            {
                if (LoginLogoutAutomationAgent.GetElementProperty("SelectGradeView", "GradeButton", "enabled", i.ToString(), WaitTime.DefaultWaitTime).Equals("true"))
                {
                    LoginLogoutAutomationAgent.Click("SelectGradeView", "GradeButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    notAddedGrade = true;
                }
                i++;
            }
            LoginLogoutAutomationAgent.Click("SelectGradeView", "ContinueButton");
        }
        /// <summary>
        /// Preparing Lessons Step (1 of 2) can be observed
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifyPreparingLessonsStep1(AutomationAgent LoginLogoutAutomationAgent)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((LoginLogoutAutomationAgent.WaitForElement("LoginView", "PreparingLessonsStep1", WaitTime.SmallWaitTime)))
                    break;
                else
                {
                    if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "PreparingLessonsStep1"))
                    {
                        LoginLogoutAutomationAgent.Sleep();
                    }
                    else
                    {
                        Assert.Fail("Automation not able to find the control, prepairing lessons step 1 of 2. Application might have crashed");
                    }
                }
            }
        }
        /// <summary>
        /// Preparing Lessons Step (2 of 2) can be observed
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifyPreparingLessonsStep2(AutomationAgent LoginLogoutAutomationAgent)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((LoginLogoutAutomationAgent.WaitForElement("LoginView", "PreparingLessonsStep2", WaitTime.SmallWaitTime)))
                    break;
                else
                {
                    if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "PreparingLessonsStep2"))
                    {
                        LoginLogoutAutomationAgent.Sleep();
                    }
                    else
                    {
                        Assert.Fail("Automation not able to find the control, prepairing lessons step 2 of 2. Application might have crashed");
                    }
                }
            }
        }
        /// <summary>
        /// Adds the specified grade from the Garde View
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void AddSpecifiedGrade(AutomationAgent LoginLogoutAutomationAgent, int gradeNumber)
        {
            LoginLogoutAutomationAgent.Click("SelectGradeView", "GradeButton", gradeNumber.ToString(), 1, WaitTime.DefaultWaitTime);
            LoginLogoutAutomationAgent.Click("SelectGradeView", "ContinueButton");
        }
        /// <summary>
        /// Gets the Prepairing Lesson Step 1 Text
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text</returns>
        public static string GetPrepairingLessonStep1Text(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.GetTextIn("LoginView", "PreparingLessonsStep1", "inside", "");
        }
        /// <summary>
        /// Gets the Prepairing Lesson Step 2 Text 
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text</returns>
        public static string GetPrepairingLessonStep2Text(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.GetTextIn("LoginView", "PreparingLessonsStep2", "inside", "");
        }
        /// <summary>
        /// Verrifies Prepairing Lesson Step 1 of 1
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void VerifyPrepairingLessonStepOne(AutomationAgent LoginLogoutAutomationAgent)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((LoginLogoutAutomationAgent.WaitForElement("LoginView", "PreparingLessonsGrade12Step", WaitTime.SmallWaitTime)))
                    break;
                else
                {
                    if (LoginLogoutAutomationAgent.IsElementFound("LoginView", "PreparingLessonsGrade12Step"))
                    {
                        LoginLogoutAutomationAgent.Sleep();
                    }
                    else
                    {
                        Assert.Fail("Automation not able to find the control, prepairing lessons step 1 of 2. Application might have crashed");
                    }
                }
            }
        }

        /// <summary>
        /// Verifies Selected Grade is present
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent Object</param>
        /// <param name="GradeNumber"></param>
        /// <returns>bool</returns>
        public static bool VerifyGradeIsPresent(AutomationAgent LoginLogoutAutomationAgent, int GradeNumber)
        {
            return LoginLogoutAutomationAgent.IsElementFound("SelectGradeView", "GradeLabel", GradeNumber.ToString());
        }

        public static bool VerifyIfFirstLoginForNonSectionedUser(AutomationAgent LoginLogoutAutomationAgent)
        {
            return LoginLogoutAutomationAgent.IsElementFound("SelectGradeView", "CancelButton");
        }
    }
}