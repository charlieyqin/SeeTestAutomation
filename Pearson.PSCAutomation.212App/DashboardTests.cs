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
    public class DashboardTests
    {
        public AutomationAgent dashboardAutomationAgent;

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(15918)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionedStudentWillSeeHisAssociatedGradeOnTheDashboardOnInitialLogin()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC15918: sectioned student will see his associated grade on the dashboard on initial login"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    NavigationCommonMethods.NavigateToELA(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.IsSectionedUser(dashboardAutomationAgent, Login.GetLogin("StudentBruceSec9Apatton")));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(21952)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GoToWorkBrowserButtonTakesUserToWorkBrowser()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC21952: “Go To Work Browser” button takes user to Work Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickOnNotificationIconInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyNotificationOverlayPresent(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickOnItemInNotification(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyGoToWorkBrowserButton(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickOnGoToWorkBrowserButton(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyWorkBrowserPage(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22760), WorkItem(224870), WorkItem(22765), WorkItem(22766), WorkItem(22477)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherDashboardTappingOnCCOrMTETakesTeacherToTheLandingPage()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22760, TC22487, TC22765, TC22766 & TC22477: TEACHER DASHBOARD: tapping on CC or MTE takes teacher to the landing page"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyConceptCorner(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickConceptCornerButton(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerPage(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyMoreToExplore(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickMoreToExploreButton(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExplorePage(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(23252), WorkItem(23280), WorkItem(23279)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void StudentDashboardMyRecentWorkNotebooksVisibleMax5AtBottomOfDashboard()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC23252, TC23280, TC23279: STUDENT DASHBOARD: My Recent Work --> recently modified notebooks are visible (max 5) at the bottom of the dashboard"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyNotebooksAtBottomOfDashboard(dashboardAutomationAgent));
                    Assert.IsFalse(DashboardCommonMethods.VerifySeeAllButtonInDashboard(dashboardAutomationAgent), "See All Appears on Dashboard");
                    int noOfNotebooks = DashboardCommonMethods.GetCountOfNotebooksInDashboard(dashboardAutomationAgent);
                    if (noOfNotebooks < 6)
                    {
                        DashboardCommonMethods.AddNotebookInDashboard(dashboardAutomationAgent, taskInfo, (7 - noOfNotebooks));
                    }
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    noOfNotebooks = DashboardCommonMethods.GetCountOfNotebooksInDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(noOfNotebooks >= 6, "There are less than 6 notebooks");
                    //Assert.IsTrue(DashboardCommonMethods.VerifySeeAllButtonInDashboard(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(23253), WorkItem(23254)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void StudentDashboardMyRecentWorkNotebooksAppearInSequentialOrderSortedByDate()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC23253, TC23254: STUDENT DASHBOARD: My Recent Work --> notebooks appear in sequential order, sorted by date"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    Assert.IsTrue(DashboardCommonMethods.VerifyNotebooksAtBottomOfDashboard(dashboardAutomationAgent));
                    for (int i = 1; i <= 2; i++)
                    {
                        DashboardCommonMethods.ClickNotebookInDashboard(dashboardAutomationAgent, i);
                        NotebookCommonMethods.ClickEraseIconInNotebook(dashboardAutomationAgent);
                        NotebookCommonMethods.ClickClearPage(dashboardAutomationAgent);
                        NotebookCommonMethods.ClickTextIconInNotebook(dashboardAutomationAgent);
                        NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 732, 706, 1);
                        NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 762, 706, 1);
                        NotebookCommonMethods.SendText(dashboardAutomationAgent, "Test" + i);
                        NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 542, 252, 1);
                        DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                    }
                    int j = 1;
                    for (int k = 2; k >= 1; k--)
                    {
                        DashboardCommonMethods.ClickNotebookInDashboard(dashboardAutomationAgent, j);
                        dashboardAutomationAgent.Sleep();
                        Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserViewInLesson(dashboardAutomationAgent));
                        string WordsInTextBox = NotebookCommonMethods.GetTextBoxContent(dashboardAutomationAgent, "Test" + k);
                        Assert.AreEqual<bool>(true, WordsInTextBox.Contains("Test" + k));
                        DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                        j++;
                    }
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(33501)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OnlyNotebookThumbnailsAppearNotPersonalNotebooks()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC33501: STUDENT DASHBOARD: My Recent Work --> only NOTEBOOK thumbnails appear! (no personal notebooks)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(dashboardAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(dashboardAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(dashboardAutomationAgent);
                    NotebookCommonMethods.EditPersonalNotesTitle(dashboardAutomationAgent, "MyTitle");
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 500, 500, 1);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifyPersonalNotebookPresent(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(33503)]
        [Priority(12)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OnlyNotebookThumbnailsAppearNotCommonReads()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC33503: STUDENT DASHBOARD: My Recent Work --> only NOTEBOOK thumbnails appear! ( no common reads)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(dashboardAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(dashboardAutomationAgent);
                    CommonReadCommonMethods.CreateAnnotation(dashboardAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    dashboardAutomationAgent.ClickOnScreen(500, 500, 1);
                    dashboardAutomationAgent.Sleep();
                    CommonReadCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifyCommonReadPresent(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(33502)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OnlyNotebookThumbnailsAppearNotSharedNotebooks()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC33502: STUDENT DASHBOARD: My Recent Work --> only NOTEBOOK thumbnails appear! ( no shared notebooks)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(dashboardAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(dashboardAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(dashboardAutomationAgent, "Share DR for testing");
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(dashboardAutomationAgent);
                    Login loginStud = Login.GetLogin("Sec9Apatton");
                    NotebookCommonMethods.SelectRecipientsForShare(dashboardAutomationAgent, loginStud.PersonName);
                    NotebookCommonMethods.ClickNextNotebookShare(dashboardAutomationAgent);
                    NotebookCommonMethods.AddMessage(dashboardAutomationAgent, "Sharing notebook");
                    NotebookCommonMethods.ClickSendNotebookShare(dashboardAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(dashboardAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifySharedNotebooksPresent(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(21764), WorkItem(22116), WorkItem(21765), WorkItem(21778), WorkItem(21779), WorkItem(21780), WorkItem(22126), WorkItem(21763)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherCanTapAllPhotoAreaPromptCameraRoll()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC21764, TC22116, TC21765, TC21778, TC21779, TC21780, TC22126, TC21763: Teacher Dashboard- teacher can tap all photo area to prompt camera/camera roll."))
            {
                try
                {
                    Login login = Login.GetLogin("TeacherCyeRobledo");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.VerifyCameraIconInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(dashboardAutomationAgent), "camera roll button is not found");
                    DashboardCommonMethods.ClickCameraRollButton(dashboardAutomationAgent);
                    DashboardCommonMethods.AddPhotoInDashboardWithesizeAndReposition(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyDeleteButtonInDashboard(dashboardAutomationAgent), "Delete Button is not  present");
                    DashboardCommonMethods.ClickDeletePhotoInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifyDeleteButtonInDashboard(dashboardAutomationAgent), "Delete Button is present");

                    DashboardCommonMethods.ClickCameraIconDashboardPopUp(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickOnCameraShutterTakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickOnRetakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickOnCameraShutterTakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickOnRetakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickCancelPhotoSelection(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User Is not On DashBoard");

                    DashboardCommonMethods.ClickOnRightmostCameraIcon(dashboardAutomationAgent);
                    int RightmostCameraIcon = DashboardCommonMethods.GetRightmostCameraIconArrowPosition(dashboardAutomationAgent);
                    int CameraPopUpRighmost = DashboardCommonMethods.GetCameraPopUpPosition(dashboardAutomationAgent);
                    Assert.IsTrue(RightmostCameraIcon > CameraPopUpRighmost, "Camera PopUp does not appear on left of camera button");
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1000, 300, 1);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    int LeftmostCameraIcon = DashboardCommonMethods.GetLeftmostCameraIconPosition(dashboardAutomationAgent);
                    int CameraPopUpLeftMost = DashboardCommonMethods.GetCameraPopUpPosition(dashboardAutomationAgent);
                    Assert.IsTrue(CameraPopUpLeftMost > LeftmostCameraIcon, "Camera PopUp does not appear on right of camera button");

                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                    Login login1 = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login1);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifyDeleteButtonInDashboard(dashboardAutomationAgent), "Delete Button is present");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(21761), WorkItem(20689), WorkItem(21787), WorkItem(21762), WorkItem(21785), WorkItem(21786), WorkItem(20684), WorkItem(20690), WorkItem(20687)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyStudentDashboardItemsAndFunctions()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC21761, TC20689, TC21787, TC21762, TC21785, TC21786, TC20684, TC20690, TC20687: Verify various icons on student dashboard and their functions"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(dashboardAutomationAgent), "Camera roll not found in DashBoard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyDashboardPlaceHolderStudent(dashboardAutomationAgent), "Dashboard Place Holder is not found");

                    Assert.IsTrue(DashboardCommonMethods.VerifyToadaysDayAndDateonDashboard(dashboardAutomationAgent, login.PersonName), "Today's day and date not verified");
                    Assert.IsTrue(DashboardCommonMethods.VerifyToadaysDayAndDateAtTopRight(dashboardAutomationAgent), "Today's day and date is not at top right");

                    Assert.IsTrue(DashboardCommonMethods.VerifyDashboardChromeTitle(dashboardAutomationAgent), "My dashboard title not verified");
                    Assert.IsTrue(DashboardCommonMethods.VerifyHelloUserNameOnDashboard(dashboardAutomationAgent, login.PersonName), "Hello user name not verified");
                    Assert.IsTrue(DashboardCommonMethods.VerifyHelloUserNameAtTopLeft(dashboardAutomationAgent), "Hello user name is not at top left");

                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(dashboardAutomationAgent), "camera roll button is not found");
                    DashboardCommonMethods.ClickCameraRollButton(dashboardAutomationAgent);
                    DashboardCommonMethods.AddPhotoInDashboardWithesizeAndReposition(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickDeletePhotoInDashboard(dashboardAutomationAgent);

                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 78, 344, 1);
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(dashboardAutomationAgent), "camera roll button is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconDashboardPopUp(dashboardAutomationAgent), "Camera Icon In Dashboard PopUp is not found");
                    DashboardCommonMethods.ClickCameraRollButton(dashboardAutomationAgent);
                    DashboardCommonMethods.AddPhotoInDashboard(dashboardAutomationAgent, false);
                    DashboardCommonMethods.ClickCameraIconDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickCameraIconDashboardPopUp(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickOnCameraShutterTakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickOnRetakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickOnCameraShutterTakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickOnRetakePhoto(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickCancelPhotoSelection(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User Is not On DashBoard");

                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22619)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherCanEditToDoMaxLimit500Chars()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22619: teacher can edit TO-DOs, MAX limit is 500 chars"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, 500);
                    Assert.IsTrue(DashboardCommonMethods.VerifyMaxCharactersLimit(dashboardAutomationAgent), "Max Characters Limit is not found");
                    String CharacterCount = DashboardCommonMethods.GetMaxCharacterCount(dashboardAutomationAgent);
                    Assert.AreEqual<string>(CharacterCount, "500", "Character Count Is not equal to 500");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22315)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherCanSeeXREMINDERS()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22315: TEACHER DASHBOARD reminders - teacher can X REMINDERS where X is a dynamic number, reflecting the number of reminders created"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");

                    string remindertext = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarr = remindertext.Split(' ');
                    int initialremindercount = Int32.Parse(remindertextarr[0]);
                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);

                    string remindertextnew = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarrnew = remindertextnew.Split(' ');
                    int initialremindercountnew = Int32.Parse(remindertextarrnew[0]);
                    Assert.AreEqual(initialremindercount + 1, initialremindercountnew, "reminder count not as expected");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22616)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardCharacterCountwhenCreatingNewReminder()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22616: TEACHER DASHBOARD: Character Count when creating new Reminder"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");

                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent);
                    string charcounttext = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    string[] charcounttextarr = charcounttext.Split(' ');
                    int initialcharcount = Int32.Parse(charcounttextarr[0]);

                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent);
                    string remindertextnew = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    string[] remindertextarrnew = remindertextnew.Split(' ');
                    int initialcharcountnew = Int32.Parse(remindertextarrnew[0]);

                    Assert.AreEqual(initialcharcount * 2, initialcharcountnew, "caharcter count not as expected");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22617)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardCharacterCountwhenAddingEditingExistingReminder()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22617: TEACHER DASHBOARD: Character Count when adding/editing text on Existing Reminders"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");

                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);

                    DashboardCommonMethods.ClickToOpenExistingReminder(dashboardAutomationAgent);
                    string charcounttext = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    string[] charcounttextarr = charcounttext.Split(' ');
                    int initialcharcount = Int32.Parse(charcounttextarr[0]);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    charcounttext = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    charcounttextarr = charcounttext.Split(' ');
                    int EditAddcharcount = Int32.Parse(charcounttextarr[0]);
                    Assert.IsTrue(EditAddcharcount > initialcharcount, "char count not increased as added");
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "BKSP");
                    charcounttext = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    charcounttextarr = charcounttext.Split(' ');
                    int EditDeletecharcount = Int32.Parse(charcounttextarr[0]);

                    Assert.IsTrue(EditAddcharcount > EditDeletecharcount, "char count not decreased as deleted");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }

        }


        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22618)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CharacterLimitReflectsonCharacterCountInReminder()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22618: TEACHER DASHBOARD: Character limit reflects on Character Count in Reminders."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    string MaximumPermittedCharcountlabel = DashboardCommonMethods.GetMaxPermittedCharCountLabelReminder(dashboardAutomationAgent);

                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, 500);
                    Assert.IsTrue(DashboardCommonMethods.VerifyMaxCharactersLimit(dashboardAutomationAgent), "Max Characters Limit is not found");
                    string CharacterCount = DashboardCommonMethods.GetMaxCharacterCount(dashboardAutomationAgent);
                    Assert.AreEqual<string>(CharacterCount + MaximumPermittedCharcountlabel, "500/ 500 characters max", "Character Count Is not equal to 500");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22607)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardToDoNotesSavedAsPerUser()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22607: TEACHER DASHBOARD: TO-DO notes are saved per user"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    string remindertextnew = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarrnew = remindertextnew.Split(' ');
                    int initialremindercountuser1 = Int32.Parse(remindertextarrnew[0]);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);


                    Login login2 = Login.GetLogin("TeacherCyeRobledo");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login2);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    string remindertextnew1 = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarrnew1 = remindertextnew1.Split(' ');
                    int initialremindercountuser2 = Int32.Parse(remindertextarrnew1[0]);

                    if (initialremindercountuser1 == initialremindercountuser2)
                    {
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "ab");
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);

                        remindertextnew1 = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                        remindertextarrnew1 = remindertextnew1.Split(' ');
                        initialremindercountuser2 = Int32.Parse(remindertextarrnew1[0]);
                        NavigationCommonMethods.Logout(dashboardAutomationAgent);

                        login = Login.GetLogin("Sec9Apatton");
                        NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                        Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                        remindertextnew = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                        remindertextarrnew = remindertextnew.Split(' ');
                        initialremindercountuser1 = Int32.Parse(remindertextarrnew[0]);

                    }

                    Assert.IsTrue(initialremindercountuser1 != initialremindercountuser2, "reminders are saved as per user");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(20602), WorkItem(20544)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardStartUnitLinksToFirstUnitForMathELAofSectionedGrade()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC20602, TC20544:student dashboard: WHEN student initially loggs in, THEN button Start Unit links to the first unit for Math & ELA of his sectioned grade"))
            {
                try
                {
                    Login login = Login.GetLogin("Markiva");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);

                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentELAButton(dashboardAutomationAgent), "start unit not found");


                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NonSectionedTask");
                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.VerifyBackButtonPresent(dashboardAutomationAgent);
                    string GradeNo = DashboardCommonMethods.GetTextOfBackToParentButton(dashboardAutomationAgent);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);

                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(3000);
                    DashboardCommonMethods.ClickStartUnitInStudentDashboard(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(4000);
                    NavigationCommonMethods.VerifyBackButtonPresent(dashboardAutomationAgent);

                    string NewGrade = DashboardCommonMethods.GetTextOfBackToParentButton(dashboardAutomationAgent);
                    Assert.AreNotEqual<string>(GradeNo, NewGrade, "Gradeno and New Grade are equal");

                    Assert.IsTrue(NavigationCommonMethods.VerifyGradeAsPerSectionedforUser(login, NewGrade), "Users sectioned grade not found");

                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    string unitNum = DashboardCommonMethods.GetUnitNumberInUnitPreview(dashboardAutomationAgent);

                    Assert.IsTrue(unitNum.Contains("Unit\t1"), "unit not found");

                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(21711), WorkItem(22148), WorkItem(22108), WorkItem(21710), WorkItem(21851), WorkItem(23153), WorkItem(21708), WorkItem(21707), WorkItem(21728), WorkItem(21705), WorkItem(21706), WorkItem(21732), WorkItem(21727)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyVariousDashboardLinksAndFunctionalitiesForSectionedTeacher()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC21711, TC22148, TC21851, TC21710, TC23153, TC21707, TC21708, TC21728, TC21705, TC21706, TC21732 , TC22108 & TC21727: Verify various Dashboard links and functionalities for sectioned teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);

                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(dashboardAutomationAgent), "Start Unit is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(dashboardAutomationAgent), "Class roster is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(dashboardAutomationAgent), "Class work is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(dashboardAutomationAgent), "Camera is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExplore(dashboardAutomationAgent), "MTE is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyConceptCorner(dashboardAutomationAgent), "CC is not on Dashboard");
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportButtonDashboard(dashboardAutomationAgent), "Teacher Support is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifySharingNotificationIconInChrome(dashboardAutomationAgent), "Teacher Support is not on Chrome");
                    Assert.IsTrue(DashboardCommonMethods.VerifyDashboardChromeTitle(dashboardAutomationAgent), "Chrome title is not on Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyHelloTeacherNameOnDashboard(dashboardAutomationAgent), "Username is not on Dashboard");

                    DashboardCommonMethods.ClickOnResourceLibraryIcon(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyResourceLibraryFlyOutMenu(dashboardAutomationAgent));
                    DashboardCommonMethods.ClickOnResourceLibraryIcon(dashboardAutomationAgent);

                    NavigationCommonMethods.NavigateToELA(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.IsSectionedUser(dashboardAutomationAgent, Login.GetLogin("Sec9Apatton")));
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Grade12");
                    DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);

                    string Gradetext = DashboardCommonMethods.GetTextOfBackToParentButton(dashboardAutomationAgent);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyContinueLessonInDashboard(dashboardAutomationAgent), "start unit not found");

                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(dashboardAutomationAgent, 4, 2, taskInfo.Lesson, taskInfo.TaskNumber);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    string GradetextNew = DashboardCommonMethods.GetTextOfBackToParentButton(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(3000);
                    string GradetextFinal = DashboardCommonMethods.GetTextOfBackToParentButton(dashboardAutomationAgent);


                    Assert.AreNotEqual(GradetextFinal, GradetextNew, "Grade is one last visited by unit library");
                    //Assert.AreEqual(GradetextFinal, Gradetext, "Grade is not the one opened from dashboard");

                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22621)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherCanDeleteToDos()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22621: TEACHER DASHBOARD teacher can Delete TO-DOs"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");

                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    string remindertext = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarr = remindertext.Split(' ');
                    int initialremindercount = Int32.Parse(remindertextarr[0]);

                    DashboardCommonMethods.ClickToOpenExistingReminder(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickDeleteReminder(dashboardAutomationAgent);
                    string remindertextnew = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarrnew = remindertextnew.Split(' ');
                    int initialremindercountnew = Int32.Parse(remindertextarrnew[0]);

                    Assert.AreEqual(initialremindercount - 1, initialremindercountnew, "reminder count not as expected");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22622)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherCanEditToDos()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22622: TEACHER DASHBOARD teacher can Edit TO-DOs"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");

                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);

                    DashboardCommonMethods.ClickToOpenExistingReminder(dashboardAutomationAgent);
                    string charcounttext = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    string[] charcounttextarr = charcounttext.Split(' ');
                    int initialcharcount = Int32.Parse(charcounttextarr[0]);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    charcounttext = DashboardCommonMethods.GetCharacterCountFromNewReminderBox(dashboardAutomationAgent);
                    charcounttextarr = charcounttext.Split(' ');
                    int EditAddcharcount = Int32.Parse(charcounttextarr[0]);
                    Assert.IsTrue(EditAddcharcount > initialcharcount, "char count not increased as added");

                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [Priority(2)]
        [WorkItem(27223), WorkItem(27448)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TaskGuideTappingELAUnitOrMyDashboardClosesTeacherMode()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC27223, TC27448: Task Guide - Tapping on [ELA Units] or [My Dashboard] closes the Teacher Mode"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    if (DashboardCommonMethods.VerifyContinueLessonInDashboard(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                    }
                    else
                    {
                        DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);
                    }
                    
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(1000);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(dashboardAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(dashboardAutomationAgent), "Teacher guide content not visible");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(1000);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(1000);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(1000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(dashboardAutomationAgent), "Teacher guide content visible");

                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(dashboardAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(dashboardAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(dashboardAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(dashboardAutomationAgent), "Teacher guide content not visible");
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(1000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(dashboardAutomationAgent), "Teacher guide content visible");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(18612)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenSectionedGradesDownloadedUserMovedToDashboard()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC18612 :When sectioned grades are downloaded, user moved to Dashboard"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(dashboardAutomationAgent, taskInfo.Grade), "Default grade not in highlited state");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22614)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardToDORemindersAligndAtBottom()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22614: TEACHER DASHBOARD  To Do's (Reminder) are aligned at the bottom of the Teacher Dashboard"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyReminderBottomAligned(dashboardAutomationAgent), "eminders are not bottom aligned");
                    DashboardCommonMethods.SwipeRminders(dashboardAutomationAgent, Direction.Right);
                    Assert.IsTrue(DashboardCommonMethods.VerifyReminderBottomAligned(dashboardAutomationAgent), "eminders are not bottom aligned");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22316)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardNoRemindersThenNoMessageIsDisplayed()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22316: TEACHER DASHBOARD reminders - when there are no reminders, no message is displayed"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    while (DashboardCommonMethods.VerifyExistingReminderExists(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickToOpenExistingReminder(dashboardAutomationAgent);
                        DashboardCommonMethods.ClickDeleteReminder(dashboardAutomationAgent);
                    }
                    Assert.IsTrue(DashboardCommonMethods.VerifyReminderNoMessageDisplayed(dashboardAutomationAgent), "Reminder no message not found");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22318)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardVerifyReminderHeader()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22318: TEACHER DASHBOARD reminders - Verify the Reminders header."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    string remindertext = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarr = remindertext.Split(' ');
                    int initialremindercount = Int32.Parse(remindertextarr[0]);
                    DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifyReminderNoMessageDisplayed(dashboardAutomationAgent), "Reminder no message not found");
                    string remindertextnew = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarrnew = remindertextnew.Split(' ');
                    int initialremindercountnew = Int32.Parse(remindertextarrnew[0]);
                    Assert.AreEqual(initialremindercount + 1, initialremindercountnew, "reminder count not as expected");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22320)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardReminderExtendSwipeIndicatorVisible()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22320: TEACHER DASHBOARD reminders - if reminders extend beyond the page, Swipe Indicator is visible and teacher can swipe left to see reminders."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    for (int i = 0; i < 6; i++)
                    {
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    }

                    Assert.IsTrue(DashboardCommonMethods.VerifySwipeIndicatorPresent(dashboardAutomationAgent), "swipe indicator not found");
                    DashboardCommonMethods.SwipeRminders(dashboardAutomationAgent, Direction.Right);
                    Assert.IsTrue(DashboardCommonMethods.VerifyReminderBottomAligned(dashboardAutomationAgent), "eminders are not bottom aligned");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(21725)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherCanSeeSwipeTheSectionTilesLeftAndRight()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC21725:Teacher Dashboard- Teacher can see swipe the section tiles left and right, indicator visible"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.SwipeDashboard(dashboardAutomationAgent, Direction.Right);
                    DashboardCommonMethods.SwipeDashboard(dashboardAutomationAgent, Direction.Left);
                    DashboardCommonMethods.VerifyIndicatorDotsVisible(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22107)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StartButtonLinkToLastAccessedUnit()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22107:If teacher has accessed other UNITS (not lessons), button will link to last accessed unit"))
            {
                try
                {
                    Login login = Login.GetLogin("Ayshea1");
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    if (DashboardCommonMethods.VerifyContinueLessonInDashboard(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                    }
                    else
                    {
                        DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);
                    }
                    dashboardAutomationAgent.Sleep(4000);
                    string UnitTitle = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMathGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnit2FromUnitLibrary(dashboardAutomationAgent, "2");
                    string UnitTitle1 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreNotEqual<string>(UnitTitle, UnitTitle1, "Unit Title are equal");
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    if (DashboardCommonMethods.VerifyContinueLessonInDashboard(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                    }
                    else
                    {
                        DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);
                    }
                    dashboardAutomationAgent.Sleep(4000);
                    string UnitTitle2 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(UnitTitle1, UnitTitle2, "Unit Title are not equal and start button not links to last unit");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22762), WorkItem(22763)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentIfThereNoLasViewedLessonUserGetsRelevantSiteHomepage()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22762, TC22763: STUDENT DASHBOARD: MTE & CC - If there is no last viewed lesson - user gets to the relevant site homepage"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreStudentDashboard(dashboardAutomationAgent), "More To Explore is not found");
                    DashboardCommonMethods.ClickMoreToExploreButtonStudentDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExplorePageStudent(dashboardAutomationAgent));
                    Assert.IsFalse(DashboardCommonMethods.VerifySafariBrowserUrl(dashboardAutomationAgent), "Safari browser is open");
                    Assert.IsTrue(DashboardCommonMethods.VerifyDoneButtonInMTENativeView(dashboardAutomationAgent), "More To Explore done button not found in PSoC view");
                    DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                    DashboardCommonMethods.VerifyDashboardPlaceHolderStudent(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerStudentDashboard(dashboardAutomationAgent), "More To Explore is not found");
                    DashboardCommonMethods.ClickConceptCornerButtonStudentDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPage(dashboardAutomationAgent), "Concepot Corner page not present");
                    Assert.IsFalse(DashboardCommonMethods.VerifySafariBrowserUrl(dashboardAutomationAgent), "Safari browser is open");
                    Assert.IsTrue(DashboardCommonMethods.VerifyDoneButtonInCCNativeView(dashboardAutomationAgent), "Concept corner done button not found in PSoC view");
                    NavigationCommonMethods.ClickOnDone(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22106)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherDashboardSectionTitlesOnlySectionTags()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22106: TEACHER DASHBOARD: Section TITLEs are only section tags (like e.g. Sec-02 Per-01)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifySectionTitlesInDashboard(dashboardAutomationAgent), "Section Titles on Dashboard is not found");
                    String TileTitleDashboard = DashboardCommonMethods.GetSectionTitle(dashboardAutomationAgent);
                    String SectionTitle = TileTitleDashboard.Replace(" ", "");
                    NavigationCommonMethods.NavigateWorkBrowser(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifySectionTitlesInWorkBrowser(dashboardAutomationAgent), "Section Titles on Dashboard is not found");
                    String WorkBrowserTitle = DashboardCommonMethods.GetNewSectionTitle(dashboardAutomationAgent);
                    String[] s = WorkBrowserTitle.Split('|');
                    String NewSectionTitle = s[1].Replace(" ", "");
                    Assert.IsTrue(SectionTitle.Contains(NewSectionTitle), "Section title name are not same in dashboard and work browser");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22110)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherDashboardLinkedWithSectionedContent()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22110: Dashboard is linked with Sectioned content"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NonSectionedTask");
                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifyNonSectionedGradeInDashboard(dashboardAutomationAgent, taskInfo.Grade), "NonSectioned Grade is not found on dashboard");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22615)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardReminderExtendSwipeIndicatorVisibleReflectsThePages()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22615: TEACHER DASHBOARD: To Do's - Styling: there is Page Indicator (dot) at the bottom of dashbaord which reflects the pages all To-Do's are laid in"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    for (int i = 0; i < 6; i++)
                    {
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    }

                    Assert.IsTrue(DashboardCommonMethods.VerifySwipeIndicatorPresent(dashboardAutomationAgent), "swipe indicator not found");
                    DashboardCommonMethods.SwipeRminders(dashboardAutomationAgent, Direction.Right);

                    int paginationindicator1 = DashboardCommonMethods.GetPaginationIndicatorCount(dashboardAutomationAgent);
                    for (int i = 0; i < 6; i++)
                    {
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    }
                    int paginationindicator2 = DashboardCommonMethods.GetPaginationIndicatorCount(dashboardAutomationAgent);
                    Assert.IsTrue(paginationindicator2 > paginationindicator1, "pagination indicator count not increased");

                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22317)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardVerifyReminderModificationtime()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22317: TEACHER DASHBOARD Reminders - modification time visible, displaying in latest to oldest order"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    if (!DashboardCommonMethods.VerifyExistingReminderExists(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent);
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                        string GetRemindertimestampNow = DashboardCommonMethods.GetLatestReminderModificationTime(dashboardAutomationAgent);
                        Assert.AreEqual<String>(GetRemindertimestampNow, " Today", "Old Reminders are already present");

                    }
                    else
                    {
                        string GetRemindertimestamp = DashboardCommonMethods.GetOldReminderModificationTime(dashboardAutomationAgent);
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, 3);
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                        string GetRemindertimestampNow = DashboardCommonMethods.GetLatestReminderModificationTime(dashboardAutomationAgent);
                        Assert.AreNotEqual<String>(GetRemindertimestampNow, GetRemindertimestamp, "modification time is not displayed with created date");
                    }
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22111)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherLinkedLessonRemovedImageLinkingStartUnit()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22111: teacher dashbaord: When the teacher's linked lesson was removed, then button & image linking returns to 'Start Unit'"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    DashboardCommonMethods.ClickContinueLessonTeacherDashboard(dashboardAutomationAgent);
                    string ELAUnit = DashboardCommonMethods.GetTextOfBackToParentButton(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                    login = Login.GetLogin("GustadMody9");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(dashboardAutomationAgent);
                    NavigationCommonMethods.RemoveGrades(dashboardAutomationAgent, 12);
                    NavigationCommonMethods.ClickAddGrade(dashboardAutomationAgent, 12);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                    login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "dashboard not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(dashboardAutomationAgent), "Start Unit button not found");
                    DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);
                    string ELAUnitTitle2 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(ELAUnit, ELAUnitTitle2, "ELA Unit Title are not equal after add and remove grade");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(20546)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLinkedLessonRemovedImageLinkingStartUnit()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC20546: student dashbaord: When the student's linked lesson was removed, then button & image linking returns to 'Start Unit'"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    string ELAUnitTitle = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    TaskInfo taskInfo1 = login.GetTaskInfo("Math", "ChallengeProblem");
                    NavigationCommonMethods.NavigateToMathGrade(dashboardAutomationAgent, taskInfo1.Grade);
                    NavigationCommonMethods.ClickMathUnit(dashboardAutomationAgent, taskInfo1.Unit);
                    NavigationCommonMethods.ClickStartInMathUnitPreview(dashboardAutomationAgent, taskInfo1.Unit);
                    string MathUnitTitle = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(dashboardAutomationAgent, taskInfo1.Lesson);
                    NavigationCommonMethods.ClickStartInMathLessonPreview(dashboardAutomationAgent, taskInfo1.Lesson);
                    string MathLessonTitle = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    //Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentELAButton(dashboardAutomationAgent), "Start Unit button not found");
                    //Assert.IsTrue(DashboardCommonMethods.VerifyContinueMathLessonInStudentDashboard(dashboardAutomationAgent), "Math Continue lesson button not present");
                    DashboardCommonMethods.ClickStartUnitInStudentDashboard(dashboardAutomationAgent);
                    string ELAUnitTitle1 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickMathContinueLessonStudentDashboard(dashboardAutomationAgent);
                    string MathLessonTitle1 = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle1, "ELA Unit Title are not equal");
                    Assert.AreEqual<string>(MathLessonTitle, MathLessonTitle1, "Math Lesson Title are not equal");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    login = Login.GetLogin("GustadMody9");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(dashboardAutomationAgent);
                    NavigationCommonMethods.RemoveGrades(dashboardAutomationAgent, 9);
                    NavigationCommonMethods.AddGrades(dashboardAutomationAgent, 9);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "dashboard not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentELAButton(dashboardAutomationAgent), "Start Unit button not found");
                    DashboardCommonMethods.ClickStartUnitInStudentDashboard(dashboardAutomationAgent);
                    string ELAUnitTitle2 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitMathStudent(dashboardAutomationAgent);
                    string MathUnitTitle1 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle2, "ELA Unit Title are not equal after add and remove grade");
                    Assert.AreEqual<string>(MathUnitTitle, MathUnitTitle1, "Math Lesson Title are not equal after add and remove grade");
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentELAButton(dashboardAutomationAgent), "Start ELA Unit button not found");
                    Assert.IsFalse(DashboardCommonMethods.VerifyContinueMathLessonInStudentDashboard(dashboardAutomationAgent), "Math Continue lesson button present");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }




        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(20601)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLinkedUnitsButtonWillLinkToLastAccessedUnit()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC20601: Student dashboard: If user has accessed other UNITS (not lessons), button will link to last accessed unit"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentELAButton(dashboardAutomationAgent);

                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    string UnitTitle = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentELAButton(dashboardAutomationAgent);
                    string UnitTitle1 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(UnitTitle, UnitTitle1, "Unit Title are not equal and start button does not links to last unit");


                    taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                    NavigationCommonMethods.NavigateToMathGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInMathUnitPreview(dashboardAutomationAgent, taskInfo.Unit);
                    string UnitTitle2 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentMathButton(dashboardAutomationAgent);
                    string UnitTitle3 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(UnitTitle2, UnitTitle3, "Unit Title are not equal and start button does not links to last unit");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22716)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGradesSortingHighestGradeFirstELAThenMath()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22716:teacher dashboard - grades sorting: a) HIGHEST grade first b) ELA first, then all Math c) section"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    int UnitNumber1 = DashboardCommonMethods.GetTileUnitNumber(dashboardAutomationAgent);
                    int SectionNumber1 = DashboardCommonMethods.GetTileSectionNumber(dashboardAutomationAgent);
                    DashboardCommonMethods.SwipeDashboard(dashboardAutomationAgent, Direction.Right);
                    int UnitNumber2 = DashboardCommonMethods.GetLastTileUnitNumber(dashboardAutomationAgent);
                    int SectionNumber2 = DashboardCommonMethods.GetLastTileSectionNumber(dashboardAutomationAgent);
                    Assert.IsTrue(UnitNumber1 > UnitNumber2, "Section tiles does not appear in order, highest Unit first");
                    Assert.IsTrue(SectionNumber1 < SectionNumber2, "Section tiles does not appear in ascending Section Number");
                    DashboardCommonMethods.SwipeDashboard(dashboardAutomationAgent, Direction.Left);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(23255), WorkItem(23251)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void STUDENTDASHBOARDeEvenWHENLessonDoesnExistThenNotebookIsStillVisibleOnDashboard()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC23255, TC23251:SSTUDENT DASHBOARD: My Recent Work --> even WHEN lesson doesn't exist on device, then notebook is still visible on dashboard"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Dashboard");

                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(dashboardAutomationAgent, taskInfo);
                    NotebookCommonMethods.ClickOnNotebookIcon(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(dashboardAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(dashboardAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 732, 706, 1);
                    NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 762, 706, 1);
                    NotebookCommonMethods.SendText(dashboardAutomationAgent, "Test");
                    NotebookCommonMethods.ClickOnNotebookIcon(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    Login login1 = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(dashboardAutomationAgent);
                    NavigationCommonMethods.RemoveGrades(dashboardAutomationAgent, taskInfo.Grade);
                    dashboardAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    Login login2 = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login2);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyRecentWorkToDisplay(dashboardAutomationAgent), "Student notebook not found");
                    DashboardCommonMethods.ClickNotebookInDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyNotebookOpenedInWorkBrowser(dashboardAutomationAgent), "Work browser not opened");
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(dashboardAutomationAgent);
                    NavigationCommonMethods.AddGrades(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22109), WorkItem(20726)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherLinkstoRecentlyUsedContents()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22109, TC20726: teacher dashboard: links to recently used content are preserved for each user ( multiple users use the PSoC App )"))
            {
                try
                {
                    Login login = Login.GetLogin("Margret");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    string UnitTitle = "";
                    if (DashboardCommonMethods.VerifyContinueLessonInDashboard(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                        NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                        dashboardAutomationAgent.Sleep(1000);
                    }
                    else
                    {
                        Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(dashboardAutomationAgent), "Start Unit button not found");
                        DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);
                        UnitTitle = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                        TaskInfo taskInfo2 = login.GetTaskInfo("ELA", "Dashboard");
                        NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo2.Lesson);
                    }
                    
                    NavigationCommonMethods.NavigateToMathGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInMathUnitPreview(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    Login login1 = Login.GetLogin("Ayshea1");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login1);
                    taskInfo = login1.GetTaskInfo("ELA", "Notebook");
                    
                    if (DashboardCommonMethods.VerifyContinueLessonInDashboard(dashboardAutomationAgent))
                    {
                        DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                    }
                    else
                    {
                        Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(dashboardAutomationAgent), "Start Unit button not found"); 
                        DashboardCommonMethods.ClickStartUnitInDashboard(dashboardAutomationAgent);
                        NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    }
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    Login login2 = Login.GetLogin("Margret");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login2);
                    DashboardCommonMethods.ClickContinueLessonButton(dashboardAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(1000);
                    string UnitTitle2 = DashboardCommonMethods.GetUnitTiltleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(UnitTitle, UnitTitle2, "Unit Title and UnitTitle2 Are not equal");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);


                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(31822)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitLabelsAreUpdatedOnStudentDashboard()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC31822:Unit labels are updated on Student Dashboard"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentELAButton(dashboardAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(dashboardAutomationAgent);
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(dashboardAutomationAgent, Direction.Right);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(dashboardAutomationAgent, (Int32.Parse(taskInfo.Unit) + 1));
                    string episodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(dashboardAutomationAgent, 1);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentELAButton(dashboardAutomationAgent);
                    string episodeTitle1 = LessonBrowserCommonMethods.GetEpisodeTitle(dashboardAutomationAgent, 1);
                    Assert.AreEqual(episodeTitle, episodeTitle1, "Unit in start and navigated through Ela are not same");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(20796)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentSeperateLayoutAppearingForSectionedStudent()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC20796 student dashbaord: separate layouts are appearing for one-course sectioned students"))
            {
                try
                {

                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentELAButton(dashboardAutomationAgent), "Start Unit Student ELA Button is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentMathButton(dashboardAutomationAgent), "Start Unit Student Math Button Is not found ");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                    Login login1 = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login1);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitStudentELAButton(dashboardAutomationAgent), "Start Unit Student ELA Button is not found");
                    Assert.IsFalse(DashboardCommonMethods.VerifyStartUnitStudentMathButton(dashboardAutomationAgent), "Start Unit Student Math Button is found ");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22620)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherDashboardTeacherCanAddUnlimitedToDoNotes()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22620: TEACHER DASHBOARD: teacher can create an unlimited number of TO-DO notes"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent), "User is not on dashboard");
                    string remindertext = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarr = remindertext.Split(' ');
                    int initialremindercount = Int32.Parse(remindertextarr[0]);
                    for (int i = 1; i < 10; i++)
                    {
                        DashboardCommonMethods.ClickOnNewRemainderInDashboard(dashboardAutomationAgent);
                        DashboardCommonMethods.AddCharactersInNewReminder(dashboardAutomationAgent, "abc");
                        DashboardCommonMethods.ClickCreateNewReminder(dashboardAutomationAgent);
                    }
                    string remindertextnew = DashboardCommonMethods.GetReminderCountOnDashboard(dashboardAutomationAgent);
                    string[] remindertextarr1 = remindertext.Split(' ');
                    int initialremindercountnew = Int32.Parse(remindertextarr1[0]);
                    Assert.AreNotEqual(initialremindercount, initialremindercountnew, "reminder count not increased on adding multiple reminders");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22115)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ClassWorkAndClassRosterAppearingTeacherWith1CourseAndWith2Course()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22115: teacher dashboard: Class Work and Class Roster appearing for teacher with 1 class & 1 course AND teacher with 1 class & 2 courses"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyClassRosterInDashboard(dashboardAutomationAgent));
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyClassWorkInDashboard(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);

                    Login login1 = Login.GetLogin("Ayshea1");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(dashboardAutomationAgent));
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyClassRosterMathInDashboard(dashboardAutomationAgent));
                    Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyClassWorkMathInDashboard(dashboardAutomationAgent));
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22761)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentDashboardMTEAndCCUserDirectedToSpecificWebPageRelevantToLasViewedLesson()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22761:STUDENT DASHBOARD: MTE & CC - User is directed to the specific webpage relevant to the lesson that is my last viewed lesson."))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    string UnitTitle = DashboardCommonMethods.GetUnitTiltleName(dashboardAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickMoreToExploreButtonStudentDashboard(dashboardAutomationAgent);
                    string UnitTitle1 = DashboardCommonMethods.GetUnitTiltleNameInMorToExplore(dashboardAutomationAgent);
                    Assert.AreEqual<string>(UnitTitle, UnitTitle1, "Unit Title are not equal and No specific webpage as last viewed lesson in More To Explore");
                    DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);

                    NavigationCommonMethods.NavigateToMath(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMathGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(dashboardAutomationAgent, 1);
                    string[] UnitTitle2 = DashboardCommonMethods.GetUnitTiltleName(dashboardAutomationAgent).Split('c');
                    string NewUnitTitle = UnitTitle2[0] + "ction";
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    NavigationCommonMethods.ClickConceptCornerButtonInNavBar(dashboardAutomationAgent);
                    string UnitTitle3 = DashboardCommonMethods.GetUnitTitleNameConceptCorner(dashboardAutomationAgent);
                    Assert.AreEqual<string>(NewUnitTitle, UnitTitle3, "Unit Title are not equal and No specific webpage as last viewed lesson in Concept Corner");
                    DashboardCommonMethods.ClickOnDoneButton(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);


                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22114), WorkItem(22113)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DashboardButtonLinkingForTeacher()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC22114, TC22113:teacher dashbaord: dashboard button linking works like for STUDENT DASHBOARD for teacher with 1 class & 1 course AND teacher with 1 class & 2 courses"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUnitTileNumberInDashboard(dashboardAutomationAgent), "Unit Tile Number in dashboard is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifySectionDashboardTitle(dashboardAutomationAgent), "Section dashboard title is not found");
                    DashboardCommonMethods.SwipeDashboard(dashboardAutomationAgent, Direction.Right);
                    Assert.IsTrue(DashboardCommonMethods.VerifySectionGradeInDashboard(dashboardAutomationAgent), "Section Grade dashboard is found");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                    Login login1 = Login.GetLogin("Ayshea1");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login1);
                    taskInfo = login1.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(dashboardAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUnitTileNumberInDashboard(dashboardAutomationAgent), "Unit Tile Number in dashboard is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifySectionDashboardTitle(dashboardAutomationAgent), "Section dashboard title is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyScrollNotAvailableForSingleSectionedUser(dashboardAutomationAgent), "Section Grade dashboard is found");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(20634)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentLinksToRecentlyUsedContentArePreservedAfterAppCrash()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC20634:07. student dashboard: links to recently used content are preserved after app crashed / user logged out & in"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentELAButton(dashboardAutomationAgent);
                    dashboardAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    dashboardAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    dashboardAutomationAgent.Sleep(3000);
                    string ELALessonTitle = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickStartUnitStudentMathButton(dashboardAutomationAgent);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);
                    string MathLessonTitle = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);
                    dashboardAutomationAgent.Sleep(1000);
                    dashboardAutomationAgent.ApplicationClose();
                    dashboardAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    DashboardCommonMethods.ClickELAContinueLessonStudentDashboard(dashboardAutomationAgent);
                    string ELALessonTitle1 = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(ELALessonTitle, ELALessonTitle1, "UnitTitle and UnitTitle1 Are not equal");
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickMathContinueLessonStudentDashboard(dashboardAutomationAgent);
                    string MathLessonTitle1 = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(MathLessonTitle, MathLessonTitle1, "UnitTitle and UnitTitle1 Are not equal");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent, true);
                    dashboardAutomationAgent.Sleep(1000);
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    DashboardCommonMethods.ClickELAContinueLessonStudentDashboard(dashboardAutomationAgent);
                    string ELALessonTitle2 = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(ELALessonTitle, ELALessonTitle2, "UnitTitle and UnitTitle1 Are not equal");
                    NavigationCommonMethods.NavigateMyDashboard(dashboardAutomationAgent);
                    DashboardCommonMethods.ClickMathContinueLessonStudentDashboard(dashboardAutomationAgent);
                    string MathLessonTitle2 = DashboardCommonMethods.GetLessonTitleInChrome(dashboardAutomationAgent);
                    Assert.AreEqual<string>(MathLessonTitle, MathLessonTitle2, "UnitTitle and UnitTitle1 Are not equal");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);

                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(21721), WorkItem(22112)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherCanSeeAllSectionsTeachInDashboard()
        {
            using (dashboardAutomationAgent = new AutomationAgent("TC21721, TC22112:Teacher Dashboard- Teacher can see all sections they teach in their dashboard."))
            {
                try
                {
                    Login login = Login.GetLogin("Ayshea1");
                    NavigationCommonMethods.Login(dashboardAutomationAgent, login);
                    dashboardAutomationAgent.Sleep();
                    NavigationCommonMethods.NavigateToMyDashboard(dashboardAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUnitTileNumberInDashboard(dashboardAutomationAgent), "Unit Tile Number in dashboard is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifySectionDashboardTitle(dashboardAutomationAgent), "Section dashboard title is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifySecondSectionInDashboard(dashboardAutomationAgent), "Section  Section is not found in Dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyScrollNotAvailableForSingleSectionedUser(dashboardAutomationAgent), "Section Grade dashboard is found");
                    NavigationCommonMethods.Logout(dashboardAutomationAgent);
                }
                catch (Exception ex)
                {
                    dashboardAutomationAgent.Sleep(2000);
                    dashboardAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    dashboardAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

    }
}
