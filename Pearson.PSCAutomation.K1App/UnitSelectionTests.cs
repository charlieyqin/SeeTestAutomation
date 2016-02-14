using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class UnitSelectionTests
    {
        public AutomationAgent UnitSelectionAutomationAgent;

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(28)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionCriticalFunctionalities1()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("MTC28: Verify the display of UI elements in Unit Selection Screen"))
            {
                try
                {
                    
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifySystemTrayIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyColumnsTitles(UnitSelectionAutomationAgent);
                    string[] ela_column_position = UnitSelectionCommonMethods.GetELAColumnPosition(UnitSelectionAutomationAgent);
                    string[] math_column_position = UnitSelectionCommonMethods.GetMathColumnPosition(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, Int32.Parse(ela_column_position[0]) < Int32.Parse(math_column_position[0]));
                    UnitSelectionCommonMethods.VerifyScreenBackground(UnitSelectionAutomationAgent);
                    //TC19965
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfVisible(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyRectangularPortionVisible(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC27059", true);

                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, randLesson);
                    UnitSelectionCommonMethods.VerifyLessonNumber(UnitSelectionAutomationAgent, randLesson);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19223", true);
                    NavigationCommonMethods.ClickOnLessonStandard(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIconFromLessonStandard(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyLessonStandardRightBeforeBookLog(UnitSelectionAutomationAgent), "Fail as booklog is not last activity");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC30027", true);

                    UnitSelectionCommonMethods.ClickToOpenVideoFromTodayshelf(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent), "Video Song Not Open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMediaPlayer(UnitSelectionAutomationAgent), "BackButton Not Found");
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Today Shelf Not Open");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20747", true);

                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyNotebookCanvasToolsInBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC21882", true);

                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToGetNextLesson(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickToCloseBooklogCameraMode(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20857", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19965", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19966", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19974", true);

                    int positionToday = UnitSelectionCommonMethods.GetTodayButtonPosition(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int positionTodayAfterClosing = UnitSelectionCommonMethods.GetTodayButtonPosition(UnitSelectionAutomationAgent);
                    Assert.IsTrue(positionTodayAfterClosing > positionToday, "Fail if screen is not animates down after tapping on Today button");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19220", true);

                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Todays shelf not open");
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyRubricShelfNotDisplayedInTodayShelf(UnitSelectionAutomationAgent), "Fail if Rubric Shelf is displayed in today shelf");
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyRopeImages(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Todays shelf not open");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC26288", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC43479", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19572", true);

                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                    

                    

                    

                   
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19252)]
        [Priority(3)]
        public void VerifyNoContentDownloadedButton()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19252: Verify that ELA or Math Unit buttons are displayed as grey when there is no content downloaded for that Unit"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    UnitSelectionCommonMethods.VerifyNoContentDownloadedELAButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyNoContentDownloadedMathButton(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19250)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyWidhtOfColumns()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19250: Verify that the width of ELA and Math columns is same through out the the page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWidhtOfColumns(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19251)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitsButtonsPosition()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19251: Verify that ELA Unit buttons/Units are displayed on the left column and Math Units buttons/Units are displayed on the right"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    string[] ela_column_position = UnitSelectionCommonMethods.GetELAColumnPosition(UnitSelectionAutomationAgent);
                    string[] math_column_position = UnitSelectionCommonMethods.GetMathColumnPosition(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, Int32.Parse(ela_column_position[0]) < Int32.Parse(math_column_position[0]));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19958)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionImportantFunctionalities1()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19958: Verify that the status bar display should be white in home screen"))
            {
                try
                {
                    
                    LoginCommonMethods.VerifyHomeScreenStudentButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19958", true);
                    LoginCommonMethods.VerifyAndSetupStudent(UnitSelectionAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnStudentLogin(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19954", true);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19955", true);
                    LoginCommonMethods.VerifyAndSetupStudent(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 2);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19956", true);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19957", true);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19959", true);
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19960", true);
                    NavigationCommonMethods.ClickToOpenNotebook(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19961", true);
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackButtonatMTE(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19962", true);
                    NavigationCommonMethods.ClickOnBackPack(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19964", true);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnSettingsButtons(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19967", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19968", true);
                    NavigationCommonMethods.ClickOnBookBuilder(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19970", true);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(UnitSelectionAutomationAgent, "B");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);                   
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19973", true);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19954)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnStudentScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19954: Verify that the status bar display should be white in Student screen "))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(UnitSelectionAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnStudentLogin(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19955)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnTeacherAdminLoginScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19955: Verify that the status bar display should be white in Teacher login screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19956)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnPicturePasswordSetupScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19956: Verify that the status bar display should be white in picture password setup screens "))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19957)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnUnitSelectionScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19957: Verify that the status bar display should be white in Unit selection screen "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19959)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnMediaLibraryScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19959: Verify that the status bar display should be white in Media Library screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19960)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnNotebookBrowserScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19960: Verify that the status bar display should be white in notebook browser"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19961)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnNotebookScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19961: Verify that the status bar display should be white in notebook screen"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19962)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarMTE_CCScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19962: Verify that the status bar display should be white in MTE/CC screen"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackButtonatMTE(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19963)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnTeacherModeScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19963: Verify that the status bar display should be white while teacher mode is open"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19964)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnBackPackScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19964: Verify that the status bar display should be white while back pack is open"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19967)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarWhileSystemTrayOpen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19967 :Verify that the status bar display should be white while system tray is open "))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19968)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnSettingsScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19968 :Verify that the status bar display should be white while settings screen is open  "))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19969)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarTeacherSupportScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19969:Verify that the status bar display should be white while teacher support is open "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19970)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarOnBookBuilderScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19970 :Verify that the status bar display should be white while Book Builder screen is open  "))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19973)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarWhenBookBuilderPageOpen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19973 :Verify that the status bar display should be white while book builder page is open"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(UnitSelectionAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(UnitSelectionAutomationAgent, "B");
                    BookBuilderCommonMethods.ClickToEditBookPage(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 3);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19965)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnBookLogScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19965: Verify that the status bar display should be white while book log is open"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19966)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnBookLogEntryScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19966: Verify that the status bar display should be white while book log screen is open"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 2);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20857)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEachUserHasOneCommonBookLog()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20857: Verify that each user has only one common book log regardless of the lesson it is accessed from."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToGetNextLesson(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(22073)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCapturingPictureInBooklog()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC22073: Verify the ability of the user to capture a picture in Booklog"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyBooklogCameraModeOpen(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyBookLogCameraModeOptions(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyOptionsWhenPhotoCaptured(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToCloseBooklogCameraMode(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(22075)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClickingOnGreenMarkCapturPicture()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC22075: Verify that user can save booklog image by tapping green check"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWidhtOfCrossAndCameraIcon(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWidhtOfCrossAndGreenIcon(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyBooklogCameraModeOpen(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(22078)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnCrossIconInBooklogCameraMode()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC22078: Verify camera mode must be closed and the Book Log must be displayed when tapping on red cross mark"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyBookLogCameraModeOptions(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToCloseBooklogCameraMode(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyBooklogCameraModeOpen(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
    /*    [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19974)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStatusBarDisappearWhenCameraIsOn()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19974: Verify that the status bar display will not get displayed when camera is open"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickToCloseBooklogCameraMode(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20728)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyFlashCardOpen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20728:Ensuring that tapping a flash card from the Today Shelf opens as image viewer"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnFlashCard(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyFlashCardOpen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(UnitSelectionAutomationAgent, 600, 600);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20729)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRedirectionAfterHittingBackInFashCard()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20729:Ensuring that tapping on back button on flash card viewer returns to Unit Overview screen "))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "4");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnFlashCard(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyFlashCardOpen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(UnitSelectionAutomationAgent, 600, 600);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19971)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarOnBookBrowserOpen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19971 :Verify that the status bar display should be white while book browser is open"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19972)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStatusBarWhilePageBrowserOpen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19972:Verify that the status bar display should be white while page browser is open"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(UnitSelectionAutomationAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIcon(UnitSelectionAutomationAgent);
                    BookBuilderCommonMethods.ClickOnNewLandscapeBookIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 2);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(29999)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentAlertInBonusContent()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC29999: Verify student facing offline alert in Bonus content"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(UnitSelectionAutomationAgent, TurnWifiOff);
                    UnitSelectionAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "4");
                    LoginCommonMethods.VerifyNoInternetMessage(UnitSelectionAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "4");
                    LoginCommonMethods.VerifyNoInternetMessage(UnitSelectionAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(UnitSelectionAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(27438)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUnitSelectionOfflineCriticalFunctionalities4()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC27438: Verify teacher facing offline alert in Bonus content"))
            {
                try
                {
                    
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnNonDownloadedELAUnit(UnitSelectionAutomationAgent, 3);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyDownloadIsInPropgress(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyCancelDownloadButton(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyUnitDownloaded(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyCancelDownloadButton(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC24345", true);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(UnitSelectionAutomationAgent, TurnWifiOff);
                    UnitSelectionAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "4");
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyNoInternetAlertForBonusContent(UnitSelectionAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "4");
                    UnitSelectionCommonMethods.VerifyNoInternetAlertForBonusContent(UnitSelectionAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC27438", true);

                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyNoInternetAlertMessageOnELAUnit(UnitSelectionAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyNoInternetAlertMessageOnMathUnit(UnitSelectionAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20416", true);

                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "4");
                    LoginCommonMethods.VerifyNoInternetMessage(UnitSelectionAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "4");
                    LoginCommonMethods.VerifyNoInternetMessage(UnitSelectionAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC29999", true);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(UnitSelectionAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(24279)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRedirectionToUnitHomeScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC24279: Verify units will open when tapped in unit selection screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "1");
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20416)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAlertMessageAfterTappingBonusContentInOfflineMode()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20416: Verify that In ELA and MAth, Tap on Bonus content icon from navigation when the device is offline mode"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ChangeWiFiConnectivity(UnitSelectionAutomationAgent, true);
                    UnitSelectionAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyNoInternetAlertMessageOnELAUnit(UnitSelectionAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyNoInternetAlertMessageOnMathUnit(UnitSelectionAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(UnitSelectionAutomationAgent, false);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest"), TestCategory("K1SmokeTests")]
        [WorkItem(24345)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCancelUnitDownloadButton()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC24345: Verify the display of Cancel Unit Download button at unit selection screen. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnNonDownloadedELAUnit(UnitSelectionAutomationAgent, 2);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyDownloadIsInPropgress(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyCancelDownloadButton(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyUnitDownloaded(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyCancelDownloadButton(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19219)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRopeImages()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19219: Verify that Rope images should appear in correct place"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyRopeImages(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19221)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySwipeHasSameEffectAsTapOnToday()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19221: Verify that Swipe has same effect as tap on Today"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.Swipe(UnitSelectionAutomationAgent, Direction.Down, 100, 500);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.Swipe(UnitSelectionAutomationAgent, Direction.Up, 100, 500);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest"), TestCategory("K1SmokeTests")]
        [WorkItem(19738)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUnitIntroVideoInHomeScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19738: Verify that tapping on the Play button displayed in the Unit Home screen opens and plays the Unit introductory video in video/Media overlay"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.ClickOnUnitIntroVideoButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19224)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNavigationBetweenLessons()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19224: Verify that Tapping forward and back on arrow next to lesson navigates between lessons (wrapping around at first and last lesson)"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int rand = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, rand);
                    UnitSelectionCommonMethods.VerifyLessonNumber(UnitSelectionAutomationAgent, rand);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19581)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyELAGradeTitle()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19581: Verify that Grade [Kindergarten] displays at top of ELA unit selection column"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyELAGradeTitle(UnitSelectionAutomationAgent), "Title Not found");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19739)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionImportantFunctionalities2()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19739: Verify that when the user taps on the content item which is displayed as Video in Today's shelf ,Particular video will be opened in an overlay and starts playing."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.Swipe(UnitSelectionAutomationAgent, Direction.Down, 100, 500);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.Swipe(UnitSelectionAutomationAgent, Direction.Up, 100, 500);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19221", true);
                    UnitSelectionCommonMethods.ClickOnUnitIntroVideoButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19738", true);

                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    
                    UnitSelectionCommonMethods.ClickToOpenVideoFromTodayshelf(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent), "Video Song Not Open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMediaPlayer(UnitSelectionAutomationAgent), "BackButton Not Found");
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Today Shelf Not Open");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19739", true);

                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWidhtOfCrossAndCameraIcon(UnitSelectionAutomationAgent));
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyBooklogCameraModeOpen(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyBookLogCameraModeOptions(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWidhtOfCrossAndGreenIcon(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyOptionsWhenPhotoCaptured(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToCloseBooklogCameraMode(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyBooklogCameraModeOpen(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC22073", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC22078", true);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyBooklogCameraModeOpen(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC22075", true);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyPartialAssetAtBottomOfCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC21777", true);
                   
                    

                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnFlashCard(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyFlashCardOpen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(UnitSelectionAutomationAgent, 600, 600);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20728", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20729", true);

                    NavigationCommonMethods.ClickOnTeacherMode(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19963", true);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(UnitSelectionAutomationAgent);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyWhiteStatusBar(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19969", true);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "1");
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC24279", true);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19739)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionImportantFunctionalities3()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19739: Verify that when the user taps on the content item which is displayed as Video in Today's shelf ,Particular video will be opened in an overlay and starts playing."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSec02"));

                    UnitSelectionCommonMethods.VerifyELAKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyMAthKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC31595", true);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    int bookLogItemCount = UnitSelectionCommonMethods.GetAllAddedBookLogItemsCount(UnitSelectionAutomationAgent);
                    int addedItemPosition = UnitSelectionCommonMethods.GetAddedBooklogItemPosition(UnitSelectionAutomationAgent, bookLogItemCount);
                    int addButtonPosition = UnitSelectionCommonMethods.GetAddBooklogButtonPosition(UnitSelectionAutomationAgent);
                    Assert.IsTrue(addedItemPosition < addButtonPosition, "Fail if added item is not right to Add button");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20814", true);

                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyClearAllButtonExist(UnitSelectionAutomationAgent), "ClearAll button found");
                    NotebookCommonMethods.VerifyUNDOandREDOicon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC31615", true);
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 1);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCloudIsScrollable(UnitSelectionAutomationAgent, 0, -1100);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Book reading overlay not found");
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 3);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20803", true);
                    DateTime date = DateTime.Today;
                    var exactdate = date.ToString("MMMM dd, yyyy ");
                    string[] text = exactdate.Split(',');
                    string datebelowitem = UnitSelectionCommonMethods.GetDateLabelOfItemInBookLog(UnitSelectionAutomationAgent);
                    Assert.IsTrue(text[0].Equals(datebelowitem));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20815", true);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);

                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19739)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyUnitSelectionImportantFunctionalities4()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19739: Verify that when the user taps on the content item which is displayed as Video in Today's shelf ,Particular video will be opened in an overlay and starts playing."))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(UnitSelectionAutomationAgent, "TeacherAdbul");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyUnit1Image(UnitSelectionAutomationAgent), "Image Not found");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, randLesson);
                    UnitSelectionCommonMethods.VerifyThumbnailActivitiesForLesson(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19225", true);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyArrowsInreadingOverlay(UnitSelectionAutomationAgent), "Arrows not found");
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC21667", true);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    int xCoordinateOfAddBooklogButton = UnitSelectionCommonMethods.GetAddBooklogButtonPosition(UnitSelectionAutomationAgent);
                    int tcount = 0;
                    while (UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent) && tcount <= 3)
                    {
                        UnitSelectionCommonMethods.ClickOnAddBooklogButton(UnitSelectionAutomationAgent);
                        NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                        NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                        tcount++;
                    }
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent), "Add booklog button is still present");
                    int xCoordinateOfLastAddedBooklogItem = UnitSelectionCommonMethods.GetAddedBooklogItemPosition(UnitSelectionAutomationAgent, 4);
                    Assert.IsTrue(xCoordinateOfAddBooklogButton.Equals(xCoordinateOfLastAddedBooklogItem), "Fail As last added booklog not expanded to empty space");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20856", true);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);

                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyGrade1AppearOnGrade1Units(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19582", true);
                    UnitSelectionCommonMethods.VerifyELAKindergartenUnitsOrder(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyELAGrade1UnitsOrder(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyELAKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyMAthKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC31592", true);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC31590", true);
                    UnitSelectionCommonMethods.VerifyUnitSelectionBackground(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC24339", true);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyUnitNumberDisplayedByDefault(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC31591", true);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "9");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyUnit9Image(UnitSelectionAutomationAgent), "Image Not found");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19216", true);
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfVisible(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyRectangularPortionVisible(UnitSelectionAutomationAgent));
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC27060", true);
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifySelectedInteractiveInCentre(UnitSelectionAutomationAgent), "Interactive not found in centre after returning from different browser");
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifySelectedInteractiveInCentre(UnitSelectionAutomationAgent), "Interactive not found in centre after returning from different browser");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20721", true);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyArrowsInreadingOverlay(UnitSelectionAutomationAgent), "Arrows not found");
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCloudIsScrollable(UnitSelectionAutomationAgent, 0, -1100);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC21662", true);
                    UnitSelectionCommonMethods.VerifyBooksInReadingOverlay(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC21671", true);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 1);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC21656", true);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBooklogIsLastActivity(UnitSelectionAutomationAgent), "Fail as booklog is not last activity");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC19226", true);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19739)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionImportantFunctionalities5()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19739: Verify that when the user taps on the content item which is displayed as Video in Today's shelf ,Particular video will be opened in an overlay and starts playing."))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(UnitSelectionAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyCroppingRectangleWithWhiteBorder(UnitSelectionAutomationAgent), "Cropping rectangle not found");
                    string pos = NotebookCommonMethods.GetPositionOfLeftDragLines(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.DragLeftCroppingLine(UnitSelectionAutomationAgent);
                    string pos_after_drag = NotebookCommonMethods.GetPositionOfLeftDragLines(UnitSelectionAutomationAgent);
                    Assert.AreNotEqual(pos, pos_after_drag, "Position got match after dragging the cropping area");
                    Assert.IsTrue(NotebookCommonMethods.VerifyFourResizableDots(UnitSelectionAutomationAgent), "Dots not found");
                    NavigationCommonMethods.ClickOnCrossButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC33690", true);

                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMTEscreenOpen(UnitSelectionAutomationAgent), "MTE screen not open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMTEscreen(UnitSelectionAutomationAgent), "Back Button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyCCscreenOpen(UnitSelectionAutomationAgent), "CC screen not open.");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInCCScreen(UnitSelectionAutomationAgent), "Back button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20296", true);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 1);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyCameraIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if camera or audio icons display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 2);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyCameraIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if camera does not display");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 3);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 4);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 5);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyCameraIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if camera does not display");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyNoCameraIconsInMediaLibrary(UnitSelectionAutomationAgent), "Fail if camera icon display in media library");
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyNoAudioIconsInMediaLibrary(UnitSelectionAutomationAgent), "Fail if camera icon display in media library");
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC43782", true);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19216)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBackgroundImageForEachUnit()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19216: Verify that background image is specific to each unit in todays's view"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyUnit1Image(UnitSelectionAutomationAgent), "Image Not found");
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "9");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyUnit9Image(UnitSelectionAutomationAgent), "Image Not found");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20160)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySettingsScreenOpenFromDifferentScreen()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20160: Verify that the settings page opens while settings option is tapped in system tray"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserOnSettingsscreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserOnSettingsscreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserOnSettingsscreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19225)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyThumbnailActivityForCurrentLesson()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19225: Verify that Thumbnails for activities for current lesson are displayed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, randLesson);
                    UnitSelectionCommonMethods.VerifyThumbnailActivitiesForLesson(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest"), TestCategory("K1SmokeTests")]
        [WorkItem(19223)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCurrentLessonNumber()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19223: Verify that Current lesson number is displayed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, randLesson);
                    UnitSelectionCommonMethods.VerifyLessonNumber(UnitSelectionAutomationAgent, randLesson);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21882)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddingNotebookPageAsBooklog()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21882: Verify the ability of user to add a notebook page as booklog"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyNotebookCanvasToolsInBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21777)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyPartialAssetAtBottomOfCloud()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21777: Verify Book overlay show partial book asset image(s) at bottom of Media librray cloud"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyPartialAssetAtBottomOfCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21656)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAbilityToEditBooklogFromDifferentELAUnit()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21656: Verify that user is able to Edit the Booklog entry added from any other ELA Units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetRandomUnitNumber(UnitSelectionAutomationAgent).ToString());
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 1);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20856)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookLogItemFillAddButtonSpace()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20856: Verify that  If add item button is hidden, book log collection will expand to fill empty space"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    int xCoordinateOfAddBooklogButton = UnitSelectionCommonMethods.GetAddBooklogButtonPosition(UnitSelectionAutomationAgent);
                    int tcount = 0;
                    while (UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent) && tcount <= 4)
                    {
                        UnitSelectionCommonMethods.ClickOnAddBooklogButton(UnitSelectionAutomationAgent);
                        NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                        NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                        tcount++;
                    }
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent), "Add booklog button is still present");
                    int xCoordinateOfLastAddedBooklogItem = UnitSelectionCommonMethods.GetAddedBooklogItemPosition(UnitSelectionAutomationAgent, 4);
                    Assert.IsTrue(xCoordinateOfAddBooklogButton.Equals(xCoordinateOfLastAddedBooklogItem), "Fail As last added booklog not expanded to empty space");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20801)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddingThreeBooklogItemFromOtherUnits()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20801: Verify that user is allowed to add/Edit permitted three booklog items from Multiple ELA units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 2);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetRandomUnitNumber(UnitSelectionAutomationAgent).ToString());
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    int tcount = 0;
                    while (tcount <= 3)
                    {
                        UnitSelectionCommonMethods.ClickOnAddBooklogButton(UnitSelectionAutomationAgent);
                        NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                        NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                        tcount++;
                    }
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent), "Fail as Add booklog button is still present");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19226)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookLogIsLastActivityInTodayShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19226: Verify that Last activity for ELA is always Book Log"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBooklogIsLastActivity(UnitSelectionAutomationAgent), "Fail as booklog is not last activity");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


   /*     [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19481)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookLogIsLastActivityForEachELAUnit()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19481: Verify that the Booklog icon is displayed as the last item in Today's shelf for each ELA Unit"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetRandomUnitNumber(UnitSelectionAutomationAgent).ToString());
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBooklogIsLastActivity(UnitSelectionAutomationAgent), "Fail as booklog is not last activity");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19220)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnTodayAnimatesDown()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19220: Verify that Screen animates down on tap of Today button"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int positionToday = UnitSelectionCommonMethods.GetTodayButtonPosition(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    int positionTodayAfterClosing = UnitSelectionCommonMethods.GetTodayButtonPosition(UnitSelectionAutomationAgent);
                    Assert.IsTrue(positionTodayAfterClosing > positionToday, "Fail if screen is not animates down after tapping on Today button");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(24339)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUnitSelectionBackground()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC24339: Verify that the background of Unit Selection screen matches"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    UnitSelectionCommonMethods.VerifyUnitSelectionBackground(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


    /*    [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19582)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyGrade1AppearOnGrade1Units()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19582: Verify that [Grade 1] appears above Grade 1 units upon scrolling down in either column"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    UnitSelectionCommonMethods.VerifyGrade1AppearOnGrade1Units(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


   /*     [TestMethod()]
        [TestCategory("UnitSelectionTest"), TestCategory("K1SmokeTests")]
        [WorkItem(29863)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySystemTrayElementsForStudent()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC29863: Verify Elements on System tray for student"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    LoginCommonMethods.VerifyDisplayNameAtSystemTray(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyStudentImageAtSystemTray(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTeacherSupportAtSystemTray(UnitSelectionAutomationAgent), "Fail if teacher support will be available for student");
                    UnitSelectionCommonMethods.VerifySettingsAtSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyBookBuilderAtSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyInboxAtSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUnitSlectionButton(UnitSelectionAutomationAgent);
                    LoginCommonMethods.ClickOnLogoutButton(UnitSelectionAutomationAgent);
                    LoginCommonMethods.VerifyLogoutPopupUI(UnitSelectionAutomationAgent);
                    LoginCommonMethods.ClicktoCancelLogout(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(26288)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRopeImagesAfterTransitionFromTOdayShelfActivity()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC26288: verify that when navigating back from an activity to the Today Shelf, the rope in the background should be immediately visible."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyRopeImages(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("LoginTest"), TestCategory("K1SmokeTests")]
        [WorkItem(43479)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRubricShelfDoesNotDisplayInTodayShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC43479: Verify that the Rubric Shelf does not get displayed in the today's shelf"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyRubricShelfNotDisplayedInTodayShelf(UnitSelectionAutomationAgent), "Fail if Rubric Shelf is displayed in today shelf");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(26287)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVisibilityoFTodayShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC26287: verify that during transition to Unit Overview, activities on Today Shelf should not be visible and only the rectangular portion of view should be visible once transition is complete"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfVisible(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyRectangularPortionVisible(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(31591)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyIfUnitLabelNotAvailableUnitNumberDisplayedByDefault()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC31591: Verify that if the unit label is not available, unit number is displayed by default."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyUnitNumberDisplayedByDefault(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(27059)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVisibilityoFTodayShelfAfterComingFromMediaLibrary()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC27059: verify that during transition to Unit Overview, activities on Today Shelf should not be visible and only the rectangular portion of view should be visible once transition is complete"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfVisible(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyRectangularPortionVisible(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    UnitSelectionAutomationAgent.CaptureScreenshot(ex.Message);
                    UnitSelectionAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.CaptureScreenshot(ex.Message);
                    UnitSelectionAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(27060)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVisibilityoFTodayShelfAfterComingFromNoteBookBrowser()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC27060: Verify that during transition to Unit Overview, activities on Today Shelf should not be visible and only the rectangular portion of view should be visible once transition is complete"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfVisible(UnitSelectionAutomationAgent));
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyRectangularPortionVisible(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    UnitSelectionAutomationAgent.CaptureScreenshot(ex.Message);
                    UnitSelectionAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.CaptureScreenshot(ex.Message);
                    UnitSelectionAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20721)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLastActivityOpenedFromTodayShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20721: Verify State of the Lesson and Activity when user accessess a unit."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.VerifyUserOnUnitHome(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifySelectedInteractiveInCentre(UnitSelectionAutomationAgent), "Interactive not found in centre after returning from different browser");
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifySelectedInteractiveInCentre(UnitSelectionAutomationAgent), "Interactive not found in centre after returning from different browser");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    UnitSelectionAutomationAgent.CaptureScreenshot(ex.Message);
                    UnitSelectionAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.CaptureScreenshot(ex.Message);
                    UnitSelectionAutomationAgent.GetDeviceLog();
                    throw ex;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21671)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfBookAndPoemsInReadingOverlay()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21671: Verify the display of books and poems when a unit is newly downloaded while Reading Selection overlay is active in Booklog"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyArrowsInreadingOverlay(UnitSelectionAutomationAgent), "Arrows not found");
                    UnitSelectionCommonMethods.VerifyBooksInReadingOverlay(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(31592)]
        [Priority(2)]
        public void VerifyOrderingOfUnitNumber()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC31592: Verify that the order of units in the Unit Selection view is still based on the unit number."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    UnitSelectionCommonMethods.VerifyELAKindergartenUnitsOrder(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyELAGrade1UnitsOrder(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(43463)]
        [Priority(3)]
        public void VerifyUnitSelectionCloudAsset()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC43463: Verify that Unit Selection Cloud Asset is updated"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    UnitSelectionCommonMethods.VerifyUnitSelectionBackground(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21662)]
        [Priority(2)]
        public void VerifyBooklogMedialibraryAndItsScrolling()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21662: Verify display of scrolling collection of poem and book item types in the Media Library for current unit."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCloudIsScrollable(UnitSelectionAutomationAgent, 0, -1100);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20805)]
        [Priority(2)]
        public void VerifyBehaviourOfReadingSelctionOverlay()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20805: Verify Behaviour of tapped Book/Peom in Reading selecting overlay when tapped"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Book reading overlay not found");
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 1);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21667)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfArrows()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21667: Validate the display of arrows in reading selection overlay If no other units are available arrows are hidden."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    List<string> downloadedUnitsList = NavigationCommonMethods.GetDownloadedUnitList(UnitSelectionAutomationAgent);
                    Assert.IsTrue(downloadedUnitsList.Count.Equals(1), "Invalid because more than one units is downloaded");
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyArrowsInreadingOverlay(UnitSelectionAutomationAgent), "Arrows not found");
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20803)]
        [Priority(2)]
        public void VerifyScrollingthroughReadingOverlay()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20803: Ensure that User is able to scroll through items in reading selection overlay and tap on it"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCloudIsScrollable(UnitSelectionAutomationAgent, 0, -1100);
                    UnitSelectionCommonMethods.VerifyLibraryCollectionInCloud(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Book reading overlay not found");
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 3);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(27155)]
        [Priority(2)]
        public void VerifyPreviousCreatedBooklogSync()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC27155: Verify previous created book log synch"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    DateTime dateOfPreviousBL = UnitSelectionCommonMethods.GetTimeStampOfBooklog(UnitSelectionAutomationAgent);
                    if (!dateOfPreviousBL.Equals(null))
                        Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayCloudAtBooklog(UnitSelectionAutomationAgent), "Fail is today cloud display for previous created Booklog");
                    for (int i = 1; i <= 3; i++)
                        if (UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent))
                        {
                            UnitSelectionCommonMethods.ClickOnAddBooklogButton(UnitSelectionAutomationAgent);
                            NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                            NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                        }
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent), "Fail if add button display");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20169)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVideoPlayerFadesOut()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20169: Verify that the video player fades out when the user taps on the back button on the video player"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.ClickOnUnitIntroVideoButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(UnitSelectionAutomationAgent);
                    Assert.IsFalse(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent));
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20168)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVideoPlayerFadesIN()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20168: Verify that the Video player fades in when the user tries to open a video"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    UnitSelectionCommonMethods.ClickOnUnitIntroVideoButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20815)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDateBelowBookLogItem()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20815: Ensure that date and month is displayed with the added item in booklog"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 1);
                    DateTime date = DateTime.Today;
                    var exactdate = date.ToString("MMMM dd, yyyy ");
                    string[] text = exactdate.Split(',');
                    string datebelowitem = UnitSelectionCommonMethods.GetDateLabelOfItemInBookLog(UnitSelectionAutomationAgent);
                    Assert.IsTrue(text[0].Equals(datebelowitem));
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(44567)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnCameraAndVideoFromTodayShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC44567: Verify that tapping on the Camera and/or Audio tiles on the Today Shelf, user should be taken to straight to the Notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 2);
                    NavigationCommonMethods.ClickOnCameraInTodayShelf(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 3);
                    NavigationCommonMethods.ClickOnAudioIconInTodayShelf(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

    /*    [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(43787)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLastVisitedActivityIsHighlightedOnTodayShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC43787: Verify that scroll position is intact and last visited activity is highlighted on Today Shelf when user taps on Back icon in the Notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 2);
                    NavigationCommonMethods.ClickOnCameraInTodayShelf(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCameraHighlightedInTodayShelf(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 3);
                    NavigationCommonMethods.ClickOnAudioIconInTodayShelf(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyAudioIconHighlightedInTodayShelf(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(30027)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLessonStandardAtTheEndOFEachLesson()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC30027: Verify that Lesson Standards will be displayed on the Today Shelf at the end of each lesson, right before book log. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnLessonStandard(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIconFromLessonStandard(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyLessonStandardRightBeforeBookLog(UnitSelectionAutomationAgent), "Fail as booklog is not last activity");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(43782)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCameraAndAudioVissibilityPerLessons()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC43782: Verify visibility of camera and microphone icon as per lessons"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 1);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyCameraIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if camera or audio icons display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 2);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyCameraIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if camera does not display");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 3);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 4);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 5);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyCameraIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if camera does not display");
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyAudioIconInTodayShelf(UnitSelectionAutomationAgent), "Fail if audio does not display");
                    NavigationCommonMethods.ClickOnMediaLibrary(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyNoCameraIconsInMediaLibrary(UnitSelectionAutomationAgent), "Fail if camera icon display in media library");
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyNoAudioIconsInMediaLibrary(UnitSelectionAutomationAgent), "Fail if camera icon display in media library");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(33690)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyInitialStateOfCroppingTool()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC33690: verify the Initial state of cropping tool immediately after taking a photo"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyCroppingRectangleWithWhiteBorder(UnitSelectionAutomationAgent), "Cropping rectangle not found");
                    string pos = NotebookCommonMethods.GetPositionOfLeftDragLines(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.DragLeftCroppingLine(UnitSelectionAutomationAgent);
                    string pos_after_drag = NotebookCommonMethods.GetPositionOfLeftDragLines(UnitSelectionAutomationAgent);
                    Assert.AreNotEqual(pos, pos_after_drag, "Position got match after dragging the cropping area");
                    Assert.IsTrue(NotebookCommonMethods.VerifyFourResizableDots(UnitSelectionAutomationAgent), "Dots not found");
                    NavigationCommonMethods.ClickOnCrossButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(31595)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyELAAndMathUnitsLabelsCharacters()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC31595: Verify that for both ELA and Math units, Label names will be 2-5 characters and if real state is not available to display completely "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    UnitSelectionCommonMethods.VerifyELAKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyMAthKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(43788)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionCriticalFunctionalities2()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC43788: Verify redirection to notebook whne camera is open from todays shelf"))
            {
                try
                {
                    
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSec02"));
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    int count = NotebookCommonMethods.GetCountOfNotebookPages(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 3);
                    NavigationCommonMethods.ClickOnAudioIconInTodayShelf(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyAudioIconHighlightedInTodayShelf(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 2);
                    NavigationCommonMethods.ClickOnCameraInTodayShelf(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC44567", true);
                    int countwhennotebookopen = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(UnitSelectionAutomationAgent, count + 1);
                    Assert.IsTrue(countwhennotebookopen.Equals(count + 1));
                    Assert.IsTrue(NotebookCommonMethods.VerifyMediaOverlay(UnitSelectionAutomationAgent), "Media overlay not found after clicking on media button");
                    NavigationCommonMethods.TapOnScreen(UnitSelectionAutomationAgent, 1000, 1000);
                    Assert.IsFalse(NotebookCommonMethods.VerifyMediaOverlay(UnitSelectionAutomationAgent), "Media overlay stiil found after clicking outside overlay");
                    NotebookCommonMethods.ClickOnGraphicTool(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyCameraHighlightedInTodayShelf(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC43787", true);
                    NavigationCommonMethods.ClickOnNotebookBrowser(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNumberLineInNotebook(UnitSelectionAutomationAgent), "Numver line tool not found");
                    NotebookCommonMethods.ClickOnClearAllButton(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC43788", true);

                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMTEscreenOpen(UnitSelectionAutomationAgent), "MTE screen not open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMTEscreen(UnitSelectionAutomationAgent), "Back Button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyCCscreenOpen(UnitSelectionAutomationAgent), "CC screen not found");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInCCScreen(UnitSelectionAutomationAgent), "Back button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20297", true);

                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyStudentImageAtSystemTray(UnitSelectionAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTeacherSupportAtSystemTray(UnitSelectionAutomationAgent), "Fail if teacher support will be available for student");
                    UnitSelectionCommonMethods.VerifySettingsAtSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyBookBuilderAtSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyInboxAtSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUnitSlectionButton(UnitSelectionAutomationAgent);
                    LoginCommonMethods.ClickOnLogoutButton(UnitSelectionAutomationAgent);
                    LoginCommonMethods.VerifyLogoutPopupUI(UnitSelectionAutomationAgent);
                    LoginCommonMethods.ClicktoCancelLogout(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC29863", true);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                    
                    
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(33691)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitSelectionCriticalFunctionalities3()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC33691: verify the functionality of Drag Handles to resize the Crop Area"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraInBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(UnitSelectionAutomationAgent);
                    string pos = NotebookCommonMethods.GetpositionOfResizableBorder(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.DragToCropThePhoto(UnitSelectionAutomationAgent, 200, 200);
                    string pos_after_drag = NotebookCommonMethods.GetpositionOfResizableBorder(UnitSelectionAutomationAgent);
                    Assert.IsTrue(!pos.Equals(pos_after_drag), "Positon got match after resizing the cropping area");
                    string posofleftline = NotebookCommonMethods.GetPositionOfLeftDragLines(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.DragLeftCroppingLine(UnitSelectionAutomationAgent);
                    string pos_after_drag_line = NotebookCommonMethods.GetPositionOfLeftDragLines(UnitSelectionAutomationAgent);
                    Assert.AreNotEqual(posofleftline, pos_after_drag_line, "Position got match after dragging the cropping area");
                    string posoftopline = NotebookCommonMethods.GetPositionOfTopDragLines(UnitSelectionAutomationAgent);
                    NotebookCommonMethods.DragTopCroppingLine(UnitSelectionAutomationAgent);
                    string pos_after_drag_top_line = NotebookCommonMethods.GetPositionOfTopDragLines(UnitSelectionAutomationAgent);
                    Assert.AreNotEqual(posoftopline, pos_after_drag_top_line, "Position got match after dragging the cropping area");
                    NotebookCommonMethods.DragTheCroppingArea(UnitSelectionAutomationAgent, 100, 100);
                    Assert.IsTrue(NotebookCommonMethods.VerifyRectangleAndDragHandleNotOutsidetheCropArea(UnitSelectionAutomationAgent), "Rectangle and drag handle are outside the cropping area.");
                    NavigationCommonMethods.ClickOnCrossButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC33691", true);

                    //TC20804
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 1);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    UnitSelectionCommonMethods.VerifySelectedBookAtBooklog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 3);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    UnitSelectionCommonMethods.VerifySelectedPoemAtBooklog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport("TC20804", true);

                    //TCTC27155
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    DateTime dateOfPreviousBL = UnitSelectionCommonMethods.GetTimeStampOfBooklog(UnitSelectionAutomationAgent);
                    if (!dateOfPreviousBL.Equals(null))
                        Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayCloudAtBooklog(UnitSelectionAutomationAgent), "Fail is today cloud display for previous created Booklog");
                    for (int i = 1; i <= 3; i++)
                        if (UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent))
                        {
                            UnitSelectionCommonMethods.ClickOnAddBooklogButton(UnitSelectionAutomationAgent);
                            NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                            NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                        }
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyAddBooklogButton(UnitSelectionAutomationAgent), "Fail if add button display");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);

                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(31590)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyELAAndMathUnitsLabel()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC31590: Verify that for both ELA and Math units, display unit label instead of unit number next to the word Unit on the unit selection screen."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    UnitSelectionCommonMethods.VerifyELAKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyMAthKindergartenUnitLabels(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(21669)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCorrectUnitSelectionAtBooklogReadingOverlay()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC21669: Verify that the Book log Reading selection overlay displays Correct unit medallion"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "1");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyBooklogReadingOverlayUnitMedallion(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.CloseMediaLibraryCloud(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20814)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRecentAddedItemInBooklog()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20814: Verify that most recent item added to booklog is displayed as the right most item"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "1");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUserHasOneCommonBookLog(UnitSelectionAutomationAgent);
                    int bookLogItemCount = UnitSelectionCommonMethods.GetAllAddedBookLogItemsCount(UnitSelectionAutomationAgent);
                    int addedItemPosition = UnitSelectionCommonMethods.GetAddedBooklogItemPosition(UnitSelectionAutomationAgent, bookLogItemCount);
                    int addButtonPosition = UnitSelectionCommonMethods.GetAddBooklogButtonPosition(UnitSelectionAutomationAgent);
                    Assert.IsTrue(addedItemPosition < addButtonPosition, "Fail if added item is not right to Add button");
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20804)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnBookOrPoemCloseTheReadingOverlay()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20804: Verify that reading selection overlay closes when the user taps on Peom and book and selected item is added to booklog"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, "1");
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(UnitSelectionAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 1);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    UnitSelectionCommonMethods.VerifySelectedBookAtBooklog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibraryIconInBooklogPopup(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToSelectLibraryFromCloud(UnitSelectionAutomationAgent, 3);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyBookReadingOverlayAppers(UnitSelectionAutomationAgent), "Overlay didnt close after selecting itme from it");
                    UnitSelectionCommonMethods.VerifySelectedPoemAtBooklog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20297)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySingleSignOnAuthenticatedOnBonusContentForStudent()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20297: Verify whether single sign on is authenticated and the bonus content is opened where the Student don't require to key in there username and password."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMTEscreenOpen(UnitSelectionAutomationAgent), "MTE screen not open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMTEscreen(UnitSelectionAutomationAgent), "Back Button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyCCscreenOpen(UnitSelectionAutomationAgent), "CC screen not found");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInCCScreen(UnitSelectionAutomationAgent), "Back button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20296)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySingleSignOnAuthenticatedOnBonusContentForTeacher()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20296: Verify whether single sign on is authenticated and the bonus content is opened where the Teacher don't require to key in there username and password."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMTEscreenOpen(UnitSelectionAutomationAgent), "MTE screen not open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMTEscreen(UnitSelectionAutomationAgent), "Back Button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(UnitSelectionAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyCCscreenOpen(UnitSelectionAutomationAgent), "CC screen not open.");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInCCScreen(UnitSelectionAutomationAgent), "Back button not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(UnitSelectionAutomationAgent), "No loading indicator");
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

    /*    [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20747)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyVideoOpenFromTodayShelfStudent()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20747: Verify Video Open From Today Shelf"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToOpenVideoFromTodayshelf(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent), "Video Song Not Open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMediaPlayer(UnitSelectionAutomationAgent), "BackButton Not Found");
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Today Shelf Not Open");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                   
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(20749)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVideoOpenFromTodayShelfTeacher()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC20749: Verify Video Open From Today Shelf"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    UnitSelectionCommonMethods.ClickToOpenVideoFromTodayshelf(UnitSelectionAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyOpenVideoSong(UnitSelectionAutomationAgent), "Video Song Not Open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMediaPlayer(UnitSelectionAutomationAgent), "BackButton Not Found");
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Today Shelf Not Open");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(31615)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClearAllOption()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC31615: Verify that Book log canvas doesnt have clear all functionality. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenBooklogPopup(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(UnitSelectionAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyClearAllButtonExist(UnitSelectionAutomationAgent), "ClearAll button found");
                    NotebookCommonMethods.VerifyUNDOandREDOicon(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(UnitSelectionAutomationAgent, 2);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);
                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19570)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUseAbleToAddInteractiveFromTodaysShelf()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19570: Verify whether the user is able to launch interactive from any lessons in ELA _TODAYS SHELF."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }

                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(19572)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRedirectionFromInteractivePlayer()
        {
            using (UnitSelectionAutomationAgent = new AutomationAgent("TC19572: Verify when back button is tapped in the interactive player the user redirected to the previous screen in this case todays shelf open."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(UnitSelectionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(UnitSelectionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(UnitSelectionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Todays shelf not open");
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(UnitSelectionAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(UnitSelectionAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(UnitSelectionAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayShelfOpen(UnitSelectionAutomationAgent), "Todays shelf not open");
                    LoginCommonMethods.Logout(UnitSelectionAutomationAgent);

                }
                catch (Exception ex)
                {
                    UnitSelectionAutomationAgent.Sleep(2000);
                    UnitSelectionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    UnitSelectionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
    }
}
