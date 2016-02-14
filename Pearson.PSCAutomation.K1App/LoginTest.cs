using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;

using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class LoginTest
    {
        public AutomationAgent LoginAutomationAgent;

        [TestMethod()]
        [TestCategory("LoginTest"), TestCategory("K1SmokeTests")]
        [WorkItem(23638)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLogoutPopuUI()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC23638: Verify styled dialog box displays when user tries to log out."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(LoginAutomationAgent);
                    LoginCommonMethods.ClickOnLogoutButton(LoginAutomationAgent);
                    LoginCommonMethods.VerifyLogoutPopupUI(LoginAutomationAgent);
                    LoginCommonMethods.ClicktoCancelLogout(LoginAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginCommonMethods.VerifyHomeScreenStudentButton(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22562)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBlankSchoolName()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22562: Verify that the blank school name is displayed when no user have logged in the device."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBlankSchoolName(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19323)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLoginIntroScreenUI()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19323: Verify the UI elements and whether the user the taken to the K1 intro screen when the app is launched"))
            {
                try
                {
                    LoginCommonMethods.VerifyBlueCloudBackground(LoginAutomationAgent);
                    LoginCommonMethods.VerifyTeacherAdminIcon(LoginAutomationAgent);
                    LoginCommonMethods.VerifyDarkBluePearsonCloud(LoginAutomationAgent);
                    LoginCommonMethods.VerifyStudentAvatar(LoginAutomationAgent);
                    LoginCommonMethods.VerifyCopyrightStatements(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(27435)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyIncorrectCredentialPopupAtTeacherAdminLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC27435: Verify the UI elements of poupu when username & password are incorrect into Teacher admin login screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(27436)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAuthenticationServerPopupAtTeacherAdminLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC27436: Verify the UI elements of pouup when authentication error popup display at teacher admin login screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyAuthenticationServerErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyPreservedUserNameAndEmptyPasswordFields(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(27437), WorkItem(19335)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNoInternetPopupAtTeacherAdminLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC27437 and TC19335: Verify the UI elements of offline error pop up at teacher admin login screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, true);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoInternetPopup(LoginAutomationAgent), "Pop up not found");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyPreservedUserNameAndEmptyPasswordFields(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, false);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20703)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySetUpProcessForStudentsPreviouslySetup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20703: Verify Student Password Setup process for Students previously setup"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyUIOfCorrectCredentialSetupPopupMessage(LoginAutomationAgent));
                    LoginCommonMethods.ClickOnCancelAndReturnToLogin(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22185)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyErrorPopMessagesOnTeacherAdminScreenForGivenCondition()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22185: Check the various alert/error overlay that should display in Teacher Admin login page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyUsername"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyUsernameErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyPasswordErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoInternetPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22561)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCorrectSchoolForLastLoggedUser()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22561: Verify that the correct school name is displayed in the bottom right corner of the teacher/Login screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifySchoolName(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20414)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyErrorPopMessagesOnTeacherAdminLoginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20414: Check the various alert/error overlay that should display in Teacher Admin login page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyUsername"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyUsernameErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyPasswordErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoInternetPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22184)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyErrorPopMessagesOnTeacherAdminLoginScreenForGivenCondition()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22184: Check the various alert/error overlay that should display in Teacher Admin login page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyUsername"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyUsernameErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyPasswordErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoInternetPopup(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22182)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTheErrorMessagesDisplayed()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22182:Verify the error messages displayed after entering wrong picture password."))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyHelpPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    LoginCommonMethods.VerifyLoginStartUpScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22183)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyOfflineAlertMessageInBonusContent()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22183: Verify the offline error message while trying to access bonus content."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    string currentUnit = NavigationCommonMethods.GetCurrentUnitNumber(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(LoginAutomationAgent, currentUnit);
                    LoginCommonMethods.VerifyNoInternetMessage(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(LoginAutomationAgent, "0");
                    LoginCommonMethods.VerifyNoInternetMessage(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                }

                catch (AssertFailedException ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19336)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRedirectionToAdminLoginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19336: Verify whether the user is taken back to the admin/login screen if thet tap on the OK button displayed in the incorrect username and password dialog"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19408)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyKeyBoardPopUpAfterTappingInsideUsernamrField()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19408: Verify that tapping on Username field under Student Setup screen invokes app keyboard. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19478)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageDuringSudentSetupLoginWIthWiFiOff()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19478: Verify that the below error message is displayed when Device is offline in the Student Password Setup,initial Login screen Error Message:You must be connected to the internet to log in. Please check your internet connection and try again. with OK button"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoInternetPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19425)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinner()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19425: Verify that When the user enters invalid username and valid password then taps on Begin Setup button, Verify that animated loading sun activity indicator displays while authenticating."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInBeginSetupScreen(LoginAutomationAgent, Login.GetLogin("InvalidUsernameCorrectPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19491)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerWhenIncorrectCredentialsUsed()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19491: When the user enters invalid username and invalid password then taps on Begin Setup button, Verify that animated loading sun activity indicator displays while authenticating."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInBeginSetupScreen(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19333)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEmptyUNAndPWdFieldsAFterClosingTheErrorPopupMessage()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19333: Verify if Username or password incorrect (Login Fail): The username or password you entered was incorrect. Please try again. message is displayed Where Tapping ok takes user back to login screen with empty UN/pwd"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent), "Fail if incorrect credentials error popup does not dislay");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19474)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMessageDuringWrongPasswordLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19474: Verify that the below error message is displayed when incorrect USername and password are entered in the Student Password Setup,initial Login screen Error Message:The username or password you entered was incorrect. Please try again with OK button"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent), "Fail if error popup does not match with requirement");
                    LoginCommonMethods.VerifyCloseButton(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19490), WorkItem(19422)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySunSpinnerWhenIncorrectCredentialsUsedInTeacherLoginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19490 and TC19422: Verify Display of animated loading sun activity indicator while authenticating after entering invalid credentials"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerAfterLogIn(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent), "Sun spinner not in centre");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20316)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMessageAfterAttemptingWrongPicPwdForTwoTimes()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20316: Verify Display of Pop up Error Message when the student selects incorrect password for second consecutive time."))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19390)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyKeyBoardHidesAfterTappingOutsideTheTextFields()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19390: Verify that Keyboard hides when user taps on any section outside of text fields."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameFieldOFStudentSetUpScreen(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 700, 300);
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19409)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyKeyBoardPopUpAfterTappingInsidePWDField()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19409: Verify that tapping on Password field under Student Setup screen invokes app keyboard."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordFieldOfStudentSetup(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19411)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyKeyBoardClosesAfterTappingBeginSetup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19411: Verify that tapping on Begin setup button under Student Setup screen closes app keyboard. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordFieldOfStudentSetup(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    LoginCommonMethods.ClickOnBeginSetupButton(LoginAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19420)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDuringValidUsernameInvalidPWD()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19420: Verify that Display of animated loading sun activity indicator while authenticating after entering valid userid and invalid password"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerAfterLogIn(LoginAutomationAgent, Login.GetLogin("ValidUsernameInvalidPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19402)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVisibilityOfLoginButtonWhenTappedInUsernamefield()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19402: Verify that on Teacher log in screen, when the text field cursor is at the username field, or when the user is entering username on username field, the Log In button is fully visible. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyLogInButtonVisible(LoginAutomationAgent));
                    LoginCommonMethods.VerifyLogInButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19404)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVisibilityOfLoginButtonWHenTappedInPasswordField()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19404: Verify that on Log in screen, when the text field cursor is at the password field, Log in button is fully visible and and user should be able to tap on the button."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordField(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyLogInButtonVisible(LoginAutomationAgent));
                    LoginCommonMethods.VerifyLogInButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19407)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyKeyBoardPopUpAfterTappingInsidePWDFieldOnTeacherAdminLoginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19407: Verify that Tapping on Password field or when the Cursor is at the password field, app keyboard should get invoked. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordField(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19328)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageWhenUserNamePWDIsEmpty()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19328: Validate If both username & password are empty: Please enter a username and password to continue. Tapping OK takes user back to login screen with empty UN/pwd"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19421)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDurinValidUsernameInvalidPWDInStudentSetupScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19421: Verify that Display of animated loading sun activity indicator while authenticating after entering valid userid and invalid password"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInBeginSetupScreen(LoginAutomationAgent, Login.GetLogin("ValidUsernameInvalidPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 1600, 100);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19394)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVisibilityOfBeginSetupButton()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19394: Verify that Begin Setup button under Student Setup screen is fully visible on full screen mode"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyBeginSetupButtonVisible(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19406)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyKeyBoardPopUpAfterTappingInsideUserNameFieldOnTeacherAdminLoginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19406: Verify that Tapping on Password field or when the Cursor is at the password field, app keyboard should get invoked. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19413)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBeginSetupButtonFunctionality()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19413: Verify that Begin Setup Button displaying under student setup screen functions while tapping on it"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameFieldOFStudentSetUpScreen(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBeginSetupButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19405)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBeginSetupButtonTappableWHenCursonrOnPwdField()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19405: Verify that on Begin Setup screen, when the text field cursor is at the password field, Begin Setup button is fully visible and and user should be able to tap on the button."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordFieldOfStudentSetup(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBeginSetupButtonVisible(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBeginSetupButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19410)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyKeyBoardClosesAfterTappingLoginButton()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19410: Verify that tapping on Login button under Teacher Log in screen closes app keyboard."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    LoginCommonMethods.ClickOnLoginButton(LoginAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19412)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLoginButtonFunctionality()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19412: Verify that when the user taps on the Login button displaying under Teacher log in screen, it functions. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    LoginCommonMethods.VerifyLogInButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19417)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDuringValidCredentialsInTeacherLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19417: Verify that animated loading sun activity displays and is in the center while authenticating after the user enters valid log in credentials and taps on log in button"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerAfterLogIn(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19419)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySunSpinnerDuringValidCredentialsInStudentSetupScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19419: Verify that Display of animated loading sun activity indicator while authenticating after entering valid credentials"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInBeginSetupScreen(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunSpinnerInCentre(LoginAutomationAgent));
                    if (LoginCommonMethods.VerifyStudentAlreadySetupMessage(LoginAutomationAgent))
                        LoginCommonMethods.ClickOnCancelAndReturnToLogin(LoginAutomationAgent);
                    else
                        NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19403)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVisibilityAndFunctionalityOfBeginSetupButton()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19403: Verify that on Begin Setup screen, when the text field cursor is at the username field, or when the user is entering username on username field,Begin Setup button is fully visible above keyboard ."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameFieldOFStudentSetUpScreen(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyBeginSetupButtonAboveKeyboard(LoginAutomationAgent));
                    Assert.IsTrue(LoginCommonMethods.VerifyBeginSetupButtonVisible(LoginAutomationAgent));
                    LoginCommonMethods.VerifyBeginSetupButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19329)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageWhenUserNameIsEmpty()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19329: Verify If username is empty: Please enter a username to continue message is diaplyed to the user where tapping OK takes user back to login screen with empty UN/pwd"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyUsername"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyUsernameErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19385)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutoCorrectEnable()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19385: Verify that when user types on the username field auto-correct/ auto-suggest is disabled. Text should not be auto corrected when user tries to type on the username field."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    BookBuilderCommonMethods.SendText(LoginAutomationAgent, "username");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19386)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutoCorrectEnableWhenTapInPWD()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19386: Verify that when user types on the Password field auto-correct/ auto-suggest is disabled. Text should not be auto corrected when user tries to type on the Password field."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordField(LoginAutomationAgent);
                    BookBuilderCommonMethods.SendText(LoginAutomationAgent, "username");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19387)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutoCorrectEnableWhenTapInUserNameOFstudentsetup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19387: Verify that when user types on the username field auto-correct/ auto-suggest is disabled. Text should not be auto corrected when user tries to type on the username field"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameFieldOFStudentSetUpScreen(LoginAutomationAgent);
                    BookBuilderCommonMethods.SendText(LoginAutomationAgent, "username");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19388)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutoCorrectEnableWhenTapInPWDOFstudentsetup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19388: Verify that when user types on the password field auto-correct/ auto-suggest is disabled. Text should not be auto corrected when user tries to type on the password field."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsidePasswordFieldOfStudentSetup(LoginAutomationAgent);
                    BookBuilderCommonMethods.SendText(LoginAutomationAgent, "username");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19227)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyControlsOnStudentSetUP()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19227: Verify the display of UI elements in Student setup screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyStudentSetUpUIElements(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19228)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUsernameTextBoxIsEditable()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19228: Verify whether the username textbox is editable"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyUserNameIsEditable(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19229)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPasswordTextBoxIsEditable()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19229: Verfiy whether the password textbox is editable"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyPasswordIsEditable(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19230)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyIncorrectCredentialsErrorPopup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19230: Verify whether the error message is displayed in a pop up when the user enters incorrect credentials"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19231)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEmptyCredentialsErrorPopup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19231: Verify whether the error message is displayed in a pop up when the user enters empty credentials"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    LoginAutomationAgent.Sleep();
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19232)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIOfIncorrectCredentialsErrorPopup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19232: Verify the UI elements of error message displayed in a pop up when the user enters incorrect credentials"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyUIOfIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19233)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUIOfEmptyCredentialsErrorPopup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19233: Verify UI elements of the error message is displayed in a pop up when the user enters empty credentials"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    LoginAutomationAgent.Sleep();
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyUIOfEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19234)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClosingEmptyCredentialsErrorPopup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19234: Verify tapping on the Cross Icon Button in Empty credentials error message pop will close the pop up"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    LoginAutomationAgent.Sleep();
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginAutomationAgent.Sleep();
                    Assert.AreEqual<bool>(false, LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(23926)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClosingIncorrectCredentialErrorPopup()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC23926: Verify tapping on the Cross Icon Button in Incorrect credentials error message pop will close the pop up"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    LoginAutomationAgent.Sleep();
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginAutomationAgent.Sleep();
                    Assert.AreEqual<bool>(false, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19238)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRedirectionToHomeScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19238: Verify tapping on the cancel button in User already setup up takes the user to the home screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyStudentAlreadySetupMessage(LoginAutomationAgent));
                    LoginCommonMethods.ClickOnCancelAndReturnToLogin(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyHomeScreenStudentButton(LoginAutomationAgent));

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19448)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStudentNameOnPasswordItemScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19448: Verify that the student first name and last initial is displayed in the top left corner of the Password Item Screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.VerifyTheNameOftheUser(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickCrossMarkAtPicturePasswordScreen(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19449)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySelectedColorAndCaptain()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19449: Verify that the Color, Captain and Boat user selected in Picture Password Setup will be displayed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    int randomPicItem = NavigationCommonMethods.randomInteger(10);
                    LoginCommonMethods.SelectColoredCircle(LoginAutomationAgent, randomPicItem);
                    NavigationCommonMethods.ClickOnNextArrow(LoginAutomationAgent);
                    LoginCommonMethods.SelectCaptain(LoginAutomationAgent, randomPicItem);
                    LoginCommonMethods.VerifySelectedColorAndCaptain(LoginAutomationAgent, randomPicItem);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20625)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentLoginOfflineErrorMessage()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20625: Verify Student Login offline error message"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.VerifyNoInternetMessage(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    bool TurnWifiOn = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOn);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(21702)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHighlightedTeacherName()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC21702: Verify that tapping a teacher's name highlights button, bolds text and displays check mark button to continue to next view."))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    int TeacherIndex = NavigationCommonMethods.randomInteger(4);
                    LoginCommonMethods.SelectTeacher(LoginAutomationAgent, TeacherIndex);
                    LoginCommonMethods.VerifyTeacherHighlight(LoginAutomationAgent);
                    LoginCommonMethods.VerifyGreenMark(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20709)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNoInternetAlertMessageOnWhoIsTeacherPage()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20709: Verify no internet alert message is displayed on \"who is your teacher ?\" screen , if user is offline while tapping to continue from \"Who is your teacher?\" view "))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    int TeacherIndex = NavigationCommonMethods.randomInteger(4);
                    LoginCommonMethods.SelectTeacher(LoginAutomationAgent, TeacherIndex);
                    LoginAutomationAgent.Sleep();
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.VerifyNoInternetMessage(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19447)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyConfirmationAfterSelectingPicPassword()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19447: Verify that the password confirmation screen is displayed after the student selects the pic password and taps on next arrow button in last image selection screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.VerifyPasswordConfirmationScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickCrossMarkAtPicturePasswordScreen(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20336)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStudentIsAbleToLoginWhenResetProcessIsStopped()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20336: Verify that Student is still able to login with old password if the student Password reset process is not completed successfully"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.LoginStudentUsingPicPassword(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginCommonMethods.IncompleteResetPicPasswordProcess(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.LoginStudentUsingPicPassword(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.VerifyDisplayNameAtSystemTray(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20321)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStudentPasswordSaveLocally()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20321: Verify that Student login to the same device on which he/she was setup after other student and teacher accessess the device"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.LoginStudentUsingPicPassword(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginCommonMethods.LoginStudentUsingPicPassword(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19452)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnRedCrossMark()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19452: Verify that tapping on the cross mark takes the user to the student login startup view"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.ClickCrossMarkAtPicturePasswordScreen(LoginAutomationAgent);
                    LoginCommonMethods.VerifyIamNotLinkExists(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20627)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySelectingTeacher2DeselectTheTeacher1()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20627: Verify Selecting Teacher2 will deselect the Teacher1, if teacher is already selected"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectTeacher(LoginAutomationAgent, 0);
                    string teacherName1 = LoginCommonMethods.GetHighlightedTeacherName(LoginAutomationAgent);
                    LoginCommonMethods.SelectTeacher(LoginAutomationAgent, 1);
                    string teacherName2 = LoginCommonMethods.GetHighlightedTeacherName(LoginAutomationAgent);
                    Assert.AreEqual<bool>(false, teacherName1.Equals(teacherName2));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20720)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyPicPasswordItemsSizeAndCount()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20720: Verify the size of password items  displayed for student password setup"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyColorSize(LoginAutomationAgent).Equals(9));
                    LoginCommonMethods.SelectColoredCircle(LoginAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnNextArrow(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyCaptainSize(LoginAutomationAgent).Equals(9));
                    LoginCommonMethods.SelectCaptain(LoginAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnNextArrow(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyFruitsSize(LoginAutomationAgent).Equals(9));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19325)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRedirectionToScreenAfterTappingBackOnTeacherLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19325: Verify whether the user is taken back to the K-1 Intro screen when the backbutton is tapped"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    LoginCommonMethods.VerifyHomeScreenStudentButton(LoginAutomationAgent);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19326)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRedirectionWhenTappingOnSetUpButton()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19326: Verify whether the user is allowed to see the Student setup screen when the Red setup Button is tapped."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyStudentSetUpTitle(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19327)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageAfterWrongCredentials()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19327:Verify that The username and password entered in incorrect. Pls try again message is dispalyed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("IncorrectCredential"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19337)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDisplay()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19337:Verify whether the activity indicator or sun spinner is displayed when login is processing. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerAfterLogIn(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19324)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherAdminLoginScreenUI()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19324: Verify the UI elements of Teacher/Admin login screen."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBackIcon(LoginAutomationAgent);
                    LoginCommonMethods.VerifyDarkBluePearsonCloud(LoginAutomationAgent);
                    LoginCommonMethods.VerifyAeroplaneIconWithTeacherAdminLogo(LoginAutomationAgent);
                    LoginCommonMethods.VerifyUserNameAndPwdField(LoginAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 1600, 100);
                    LoginCommonMethods.VerifyOrangeLoginButton(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    LoginCommonMethods.VerifySchoolName(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19450)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBoatAndTides()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19450: Verify that the Boat look like behind the tides in the screen."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBoatAndTides(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(23639)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentAlreadySetUpPopupItems()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC23639: Verify styled dialog box displays when user tries to log out."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyUIOfCorrectCredentialSetupPopupMessage(LoginAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 1600, 500);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyUIOfCorrectCredentialSetupPopupMessage(LoginAutomationAgent));
                    LoginCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpModes(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickOnCancelAndReturnToLogin(LoginAutomationAgent);
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyHomeScreenStudentButton(LoginAutomationAgent));
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20481)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentLoginPasswordErrorMessage()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20481: In Student Setup page, enter the wrong picture password and verify attempt message"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 4, 5, 6);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 4, 5, 6);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 4, 5, 6);
                    LoginCommonMethods.VerifyHelpPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19472)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageWhenPWDIsEmptyInStudentSetupScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19472: Verify that the below error message is displayed when password is empty in the Student Password Setup,initial Login screen Error Message:Please enter a password to continue with OK button"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifyEmptyPasswordErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19468)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageWhenUserNamePWDIsEmptyInStudentSetupScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19468: Verify that the below error message is displayed when both username & password are empty in the Student Password Setup,initial Login screen Error Message:Please enter a username and password to continue with OK button"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifyEmptyCredentialsErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19330)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageWhenPasswordIsEmpty()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19330: Verify If username is empty: Please enter a username to continue message is diaplyed to the user where tapping OK takes user back to login screen with empty UN/pwd"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifyEmptyPasswordErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyPreservedUserNameAndEmptyPasswordFields(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19391)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHelpTextOnteacherLoginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19391: Verify that Active text Log into your account or help a student create his/her own by tapping Set up area should be centered vertically in visible area above keyboard."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyHelpTextAbovekeyborad(LoginAutomationAgent));
                    Assert.IsTrue(LoginCommonMethods.VerifyHelpTextCentered(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19392)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyHelpTextOnStudentSetupScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19392: Verify that Active text Please enter the student user name and password provided by your school and /or district area is  centered vertically in visible area above keyboard."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameFieldOFStudentSetUpScreen(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyHelpTextAbovekeyboradInStudentSetUpScreen(LoginAutomationAgent));
                    Assert.IsTrue(LoginCommonMethods.VerifyHelpTextCenteredInStudentSetUpScreen(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19943)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCursorOnStudentSetupScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19943:  Verify that when the cursor is at active text area i.e username or password field, the cursor is centered vertically in visible area above keyboard."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameFieldOFStudentSetUpScreen(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyCursorAbovekeyboradInStudentSetUpScreen(LoginAutomationAgent));
                    Assert.IsTrue(LoginCommonMethods.VerifyCursorCenteredInStudentSetUpScreen(LoginAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19942)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCursorOnTeacherAdminLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19942: Verify that when the cursor is at active text area i.e username or password field, the cursor is centered vertically in visible area above keyboard."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.ClickInsideUsernameField(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyCursorAbovekeyboradInTeacherLogin(LoginAutomationAgent));
                    Assert.IsTrue(LoginCommonMethods.VerifyCursorCenteredInTeacherLogin(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(31229)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageWhenLaunchingTheFreshApplication()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC31229: Verify Message 'Extracting content...' on fresh installation of app"))
            {
                try
                {
                    LoginCommonMethods.VerifyExtractContentMessage(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19495)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDoesnotdisplay()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19495: When both the username and password fields are left empty then tapped on Begin Setup button, Verify that animated loading sun activity indicator  doesn't display."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunnySpinnerDisappeared(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19493)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDoesnotdisplayOnTeacherlogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19493: When either of the username or password field is empty and when the user taps on  Log in button, Verify that animated loading sun activity indicator does not display."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunnySpinnerDisappeared(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19496)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDoesnotdisplayEitherFieldEmpty()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19496: When either of the username or password field are left empty then tapped on Begin Setup button, Verify that animated loading sun activity indicator does not display."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("EmptyPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunnySpinnerDisappeared(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19492)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunSpinnerDoesnotdisplayOnTeacherloginScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19492: When both the Username and password fields are left empty then tapped on Log in button, Verify that animated loading sun activity indicator does not display."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyCredential"));
                    Assert.IsTrue(LoginCommonMethods.VerifySunnySpinnerDisappeared(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19909)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySecondRoundofPractice()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19909: Verify that second round of practice starts after first round of password practice and confirmation, tapping on red arrow in the confirmation screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnResetPassword(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 1, 1);
                    Assert.IsTrue(LoginCommonMethods.VerifySecondRoundPracticeStarts(LoginAutomationAgent), "Element not found");
                    LoginCommonMethods.ClickCrossMarkAtPicturePasswordScreen(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest"), TestCategory("K1SmokeTests")]
        [WorkItem(20329)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStudentResetPassword()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20329: Verify Resetting of Student Password from Student already Setup password overlay"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.ResetStudentPicPassword(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20311)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyInitialPicturePwdSelectionScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20311: Verify that Student is taken to the initial picture password selection screen if the student select incorrect password images "))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBoatAndTides(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19154)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInitialStudentPasswordSetUPScreen()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19154: Verify the UI elements in the initial student password setup screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.VerifyUIelementsAtStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22214)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyIdentifyingTeacherAndHimselfAfterClickingOnBack()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22214: Verify that Student is able to repeat the Identifying Teacher and himself process again after selection "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifyIamNotLinkExists(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22211)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyIdentifyingTeacherAndHimselfAfterSelectingNonSetUpStudent()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22211: Verify that Student is able to repeat the Identifying Teacher and himself process again after selecting Non setup student"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentStephen"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyYouNeedToSetUpPopup(LoginAutomationAgent), "Fail as you need to setup popup does not display");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.VerifyIamNotLinkExists(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22210)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentlistAndSelectingSetUpStudent()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22210: Verify Student is able to select themselves after selecting appropriate teacher and complete the identifying process"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.VerifyStudentListDisplay(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.VerifyIamNotLinkExists(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (AssertFailedException ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20716)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyValidStudentlistDisplayAfterSelectingTeacher()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20716: Verify the valid list of students to be displayed for teacher selected"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.VerifyStudentListDisplay(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (AssertFailedException ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20714)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentListDisplayAndSortingAndGreenMarkAfterSelecting()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20714: Verify student list sorting and first last display and green mark after selecting student"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    Assert.IsTrue(LoginCommonMethods.VerifySortingOfStudentName(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn")), "Fail if sorting of student is not per mentioned last name in excel");
                    Assert.IsTrue(LoginCommonMethods.VerifyStudentFirstAndLastNameDisplay(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn")), "Fail if student name does not contain first and last name mentioned in excel");
                    LoginCommonMethods.VerifyGreenMark(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (AssertFailedException ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20713)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyErrorMessageWhenFetchingStudentList()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20713: Verify that if there is an error fetching student list, student-style error message is displayed on 'who is your teacher ?' screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    LoginCommonMethods.ClickGreenMark(LoginAutomationAgent);
                    LoginCommonMethods.VerifyNoInternetMessage(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20693)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyValidTeacherList()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20693: Verify valid list of teachers to be displayed for each student user"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.VerifyTeacherListDisplay(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (AssertFailedException ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19393)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVisibilityOfLoginButton()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19393: Verify that the Log in button on the teacher log in screen is fully visible on full screen mode.  "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifyLogInButtonVisible(LoginAutomationAgent), "fail if Log In button not Visible");
                    LoginCommonMethods.VerifyLogInButtonTappable(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19471)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEmptyCredentialPopupAtStudentSetUp()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19471: Verify that the user is taken back to login screen with empty UN/pwd ,after tapping on the ok button in error message prompt when username is empty in the Student Password Setup,initial Login screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("EmptyUsername"));
                    Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyEmptyUsernameErrorPopup(LoginAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20624)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherListAndItsSorting()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20624: Verify valid list of teachers first, last name, gender and its sorting"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.VerifyPrefixDependingOnGender(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    Assert.IsTrue(LoginCommonMethods.VerifyTeacherFirstAndLastNameDisplay(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn")), "Fail if teacher name does not contain first and last name mentioned in excel");
                    Assert.IsTrue(LoginCommonMethods.VerifySortingOfTeacherName(LoginAutomationAgent, Login.GetLogin("TeacherJoshalyn")), "Fail if sorting of teacher is not per mentioned last name in excel");
                    LoginCommonMethods.VerifyTeacherListDisplay(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (AssertFailedException ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginAutomationAgent.CaptureScreenshot(ex.Message);
                    ReadContentMethods.ReleaseExcelObjects();
                    LoginAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20626)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyErrorMessageWhenFetchingTeacherList()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20626: Verify error message is displayed while error is observed in fetching teacher list "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(LoginAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(LoginAutomationAgent, Login.GetLogin("TeacherLIZZIE"));
                    LoginCommonMethods.VerifyTeacherHasNoStudent(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(23883)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunnyProgressNotDisplayForNONBundleContentBuild()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC23883: Verify that if bundle content is not present then sunny progress indicator is not displayed"))
            {
                try
                {
                    Assert.IsTrue(LoginCommonMethods.VerifySunnySpinnerDisappeared(LoginAutomationAgent), "Sun spinner displayed");
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(27011)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyPearsonCloudAssetsUpdatedAndReplaced()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC27011: Verify 'Pearson cloud' assets will be updated and replaced"))
            {
                try
                {
                    LoginAutomationAgent.SendText("{HOME}");
                    LoginCommonMethods.VerifyAppIcon(LoginAutomationAgent);
                    LoginAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    LoginCommonMethods.VerifyDarkBluePearsonCloud(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                    LoginCommonMethods.VerifyDarkBluePearsonCloud(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(26284)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySectionHeadingFormatting()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC26284: Verify Terms Of Use and Privacy Statement Section Heading Formatting"))
            {
                try
                {
                    LoginCommonMethods.ClickOnTermsOfUse(LoginAutomationAgent);
                    LoginCommonMethods.VerifyTermsOfUseBoldedHeader(LoginAutomationAgent);
                    LoginCommonMethods.VerifyTermsOfUseFormatting(LoginAutomationAgent);
                    LoginCommonMethods.CloseTermsOfUsePopup(LoginAutomationAgent);
                    LoginCommonMethods.ClickOnPrivacyStatement(LoginAutomationAgent);
                    LoginCommonMethods.VerifyPrivacyStatementBoldedHeader(LoginAutomationAgent);
                    LoginCommonMethods.VerifyPrivacyStatementFormatting(LoginAutomationAgent);
                    LoginCommonMethods.ClosePrivacyStatementPopUp(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(24343)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDisplayOfProgressBarForRestartedFailedUnitsDownload()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC24343: Verify Display of Progress bar when download restarted for failed Unit"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    ArrayList nonUnitDownloadedNumber = NavigationCommonMethods.GetNonDownloadedUnitNumber(LoginAutomationAgent);
                    NavigationCommonMethods.ClickToDownLoadUnit(LoginAutomationAgent, nonUnitDownloadedNumber[0].ToString());
                    NavigationCommonMethods.ClickOnCancelDownload(LoginAutomationAgent);
                    NavigationCommonMethods.ClickToDownLoadUnit(LoginAutomationAgent, nonUnitDownloadedNumber[0].ToString());
                    Assert.IsTrue(LoginCommonMethods.VerifyProgressbarForUnitDownloading(LoginAutomationAgent, nonUnitDownloadedNumber[0].ToString()));
                    NavigationCommonMethods.ClickOnCancelDownload(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22402)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLoggedInOfflineModeOfPreviousLoggedInUser()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22402: Verify user should be able to login in successfully offline mode using previously logged in user credentials in online mode."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginAutomationAgent.ApplicationClose();
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, true);
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(LoginAutomationAgent, "IncorrectConfigCode");
                    LoginAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, false);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(20317)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageAfterAttemptingWrongPicPwdForThreeTimes()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC20317: Verify the Display of Error Message pop up when the Student selects incorrect password entry for third consecutive attempt"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(LoginAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyHelpPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19332)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyIfPasswordIsIncorrect()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19332: Verify if password incorrect (Login Fail)"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("ValidUsernameInvalidPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent), "Fail if incorrect credentials error popup does not dislay");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(19331)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyIfUserNameIsIncorrect()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC19331: Verify if Username incorrect (Login Fail)"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("InvalidUsernameCorrectPassword"));
                    Assert.IsTrue(LoginCommonMethods.VerifyIncorrectCredentialsErrorPopup(LoginAutomationAgent), "Fail if incorrect credentials error popup does not dislay");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyEmptyUserNameAndPasswordFields(LoginAutomationAgent);
                    LoginCommonMethods.VerifySetUpIcon(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(46613)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDisplayOfProgressIndicatorForDownloadingUnit()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC46613: Verify that user  should be able to see the progress indicator within the unit download button as each bundle is being downloaded in sequence."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    ArrayList nonUnitDownloadedNumber = NavigationCommonMethods.GetNonDownloadedUnitNumber(LoginAutomationAgent);
                    NavigationCommonMethods.ClickToDownLoadUnit(LoginAutomationAgent, nonUnitDownloadedNumber[0].ToString());
                    Assert.IsTrue(LoginCommonMethods.VerifyProgressbarForUnitDownloading(LoginAutomationAgent, nonUnitDownloadedNumber[0].ToString()), "Progress bar for unit downloading not found");
                    NavigationCommonMethods.ClickOnCancelDownload(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22587)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutologinSessionInOnlineModeWhenUserNotSignedOut()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22587: Verify the last user who was signed into the app will be automatically signed in and taken to unit selection view even in ONLINE mode"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginAutomationAgent.ApplicationClose();
                    LoginAutomationAgent.LaunchApp();
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(29931)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNewStudentSetUpFunctionality()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC29931: Verify Functionality when a new student(not previously set up) logs in"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    Assert.IsFalse(LoginCommonMethods.VerifyStudentAlreadySetupMessage(LoginAutomationAgent), "Student is already setup should not display");
                    LoginCommonMethods.VerifyHelloBannerAtBeginSetUpScreen(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22589)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAutologinSessionInOfflineModeWhenUserNotSignedOut()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22589: Verify the last user who was signed into the app will be automatically signed in and taken to unit selection view even in offline mode"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                    LoginAutomationAgent.LaunchApp();
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(LoginAutomationAgent);
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(LoginAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(29930)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherAttemptErrorAtStudentSetUp()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC29930: Verify error message when teacher attempts to login from the student setup page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLoginInHomeScreen(LoginAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(LoginAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    Assert.IsTrue(LoginCommonMethods.VerifyTeacherAttemptErrorAtStudentSetupScreen(LoginAutomationAgent), "Student is already setup should not display");
                    LoginCommonMethods.CloseErrorPopUp(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(31648)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCopyRightYearInformation()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC31648: Verify that Pearson copyright information has changed from 2014 to 2015 in three places:"))
            {
                try
                {
                    LoginCommonMethods.VerifyCopyrightYearTag(LoginAutomationAgent);
                    LoginCommonMethods.ClickOnTermsOfUse(LoginAutomationAgent);
                    LoginCommonMethods.VerifyCopyrightAtPopup(LoginAutomationAgent);
                    LoginCommonMethods.CloseTermsOfUsePopup(LoginAutomationAgent);
                    LoginCommonMethods.ClickOnPrivacyStatement(LoginAutomationAgent);
                    LoginCommonMethods.VerifyCopyrightAtPopup(LoginAutomationAgent);
                    LoginCommonMethods.ClosePrivacyStatementPopUp(LoginAutomationAgent);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22588)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySessionOutWhenUserAlreadySignedOut()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22588: Verify that if last user signed out, they will not be automatically logged in on app startup."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(LoginAutomationAgent);
                    LoginAutomationAgent.ApplicationClose();
                    LoginAutomationAgent.LaunchApp();
                    Assert.IsTrue(LoginCommonMethods.VerifyHomeScreenStudentButton(LoginAutomationAgent), "Launching app after logged out should open Home Screen");
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22027)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySetUpIconAtBottomLeft()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22027: Verify that Set up button displays at the left-bottom of Teacher log in screen and tapping on the button will take the user to Begin Setup screen "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(LoginAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifySetUpIconAtBottomLeft(LoginAutomationAgent));
                    NavigationCommonMethods.ClickOnSetUp(LoginAutomationAgent);
                    LoginCommonMethods.VerifyBeginSetupButtonVisible(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LoginTest")]
        [WorkItem(22028)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIelmentsAtStudentLogin()
        {
            using (LoginAutomationAgent = new AutomationAgent("TC22028: Verify that the following UI elements should be present in the Begin setup Start up View"))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(LoginAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(LoginAutomationAgent);
                    LoginCommonMethods.VerifyUIelementsAtStudentLogin(LoginAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(LoginAutomationAgent, 1);

                }

                catch (Exception ex)
                {
                    LoginAutomationAgent.Sleep(2000);
                    LoginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LoginAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


    }
}
