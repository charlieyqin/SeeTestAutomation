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
    public class WorkBrowserTests
    {
        public AutomationAgent workbrowserAutomationAgent;
        public WorkBrowserTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        ////[AssemblyInitialize]
        ////public static void _212AssemblyInitialize(TestContext testContext)
        ////{

        ////}

        //[ClassInitialize]
        //public static void TeacherSupportTestsClassInitialize(TestContext testContext)
        //{
        //}
        //[TestInitialize]
        //public void TeacherSupportTestsTestInitialize()
        //{

        //}


        //[AssemblyCleanup]
        //public static void _212AssemblyCleanup()
        //{

        //}

        //[ClassCleanup]
        //public static void TeacherSupportTestsClassCleanup()
        //{

        //}
        //[TestCleanup]
        //public void TeacherSupportTestsTestCleanup()
        //{

        //}
        #endregion

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(34185)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TappingGoWorkBrowserBottomNotificationFromTeacher()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC34185: Tapping “Go to Work Browser” button at bottom of notification from the teacher, dropdown should close and Work Browser should open and filtered to “My Teacher”"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    DashboardCommonMethods.ClickOnNotificationIconInChrome(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickTopItemFromInNotificationOverlay(workbrowserAutomationAgent);
                    DashboardCommonMethods.ClickOnGoToWorkBrowserButton(workbrowserAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(workbrowserAutomationAgent));
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyTeacherFilter(workbrowserAutomationAgent));
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22328)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SharedWorkHasntDownloadedThereWillBeIndicationToDDoSo()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22328:If shared work hasn't been downloaded there will be an indication to do so"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);

                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");

                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    workbrowserAutomationAgent.Sleep(1000);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyTapToDownLoadForNotDownloadedItem(workbrowserAutomationAgent));
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22327)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnreadNotebookDisplayBlueDotIndicateTheyHaventBeenOpened()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22327:Unread notebook display a blue dot to indicate they haven’t been opened."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyTapToDownLoadForNotDownloadedItem(workbrowserAutomationAgent));
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyBlueDotForUnreadNotebook(workbrowserAutomationAgent));
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22345)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TappingGoWorkBrowserFromStudent()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22345: Tapping “Go to Work Browser” button at bottom of notification from student, dropdown should close and Work Browser should open and filtered to “My Class”"))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    DashboardCommonMethods.ClickOnNotificationIconInChrome(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickTopItemFromInNotificationOverlay(workbrowserAutomationAgent);
                    DashboardCommonMethods.ClickOnGoToWorkBrowserButton(workbrowserAutomationAgent);
                    DashboardCommonMethods.VerifyWorkBrowserPage(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.VerifyMyClassViewingFilter(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22347)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NavigatingFromNotificationDefaultDisplay()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22347: Navigating from notification dropdown to the Work Browser, tiles should by default display first section (not all sections)"))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login loginTchr = Login.GetLogin("Sec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginTchr.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginTchr);
                    DashboardCommonMethods.ClickOnNotificationIconInChrome(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickTopItemFromInNotificationOverlay(workbrowserAutomationAgent);
                    DashboardCommonMethods.ClickOnGoToWorkBrowserButton(workbrowserAutomationAgent);
                    DashboardCommonMethods.VerifyWorkBrowserPage(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.VerifyDefaultFirstSection(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22174)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SeeMoreChangedToMoreInSentWorkOverlay()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22174:“See more” is changed to “more” in sent work overlay"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.SelectStudentCampisano(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentMarkiva(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentDarien(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentIsao(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSec34(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSentButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.VerifyMoreButtonInSentOverlay(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickCloseInSentWorkOverlay(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(34180)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonDropdownShouldPopulateListLessons()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC34180:Lesson dropdown should populate with list of lessons for selected unit and should display All Lessons"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickAllUnitsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectUnitFromUnitDropdown(workbrowserAutomationAgent, "1");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    WorkBrowserCommonMethods.ClickAllLessonsFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyListOfLessonsAreDisplayed(workbrowserAutomationAgent), "list of lessons are not displayed");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(34181)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonDropdownDisplaysAllLessonsSelectingLesson()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC34181:The lesson dropdown still displays “All Lessons” after selecting a lesson"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickAllUnitsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectUnitFromUnitDropdown(workbrowserAutomationAgent, "1");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    WorkBrowserCommonMethods.ClickAllLessonsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFromLessonDropdown(workbrowserAutomationAgent, "1");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyListOfLessonsAreDisplayed(workbrowserAutomationAgent), "list of lessons are not displayed");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(34184)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UserAbleToSelectOneLessonAtTimeFromDropdown()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC34184: User able to select one lesson at a time from dropdown"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickAllUnitsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectUnitFromUnitDropdown(workbrowserAutomationAgent, "1");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    WorkBrowserCommonMethods.ClickAllLessonsFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonMenuArrowDisplayed(workbrowserAutomationAgent), "All lesson menu arrow is not displayed");
                    WorkBrowserCommonMethods.SelectLessonFromLessonDropdown(workbrowserAutomationAgent, "1");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyUserCanSelectOneLessonAtATime(workbrowserAutomationAgent, "2"), "user can select one lesson at a time");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(29810)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyPersonalNoteBookHeaderColorOrangeInWorkBrowser()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC29810:Verify Personal Notebook header in Work Browser- color (orange)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(workbrowserAutomationAgent, 1);
                    WorkBrowserCommonMethods.ClickOnPersonalNotesCell(workbrowserAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(workbrowserAutomationAgent, 1);
                    WorkBrowserCommonMethods.ClickOnPersonalNotesTile(workbrowserAutomationAgent);
                    String PersonalNotesHeadercolor = NavigationCommonMethods.VerifyPersonalNotesHeaderTitleColor(workbrowserAutomationAgent, login);
                    Assert.AreEqual(PersonalNotesHeadercolor, "0xEF8700");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29811)]
        [Priority(2)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyELANoteBookHeaderColorBrightBlueInWorkBrowser()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC29811:Verify ELA Notebook header in Work Browser- color (bright blue)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSec34(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickOnELANotebookTile(workbrowserAutomationAgent);
                    String NotebookColor = WorkBrowserCommonMethods.VerifyTitleColorOfNotebook(workbrowserAutomationAgent);
                    Assert.AreEqual<string>(NotebookColor, "0x0031C3");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29812)]
        [Priority(2)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyMathNoteBookHeaderColorBrightGreenInWorkBrowser()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC29812:Verify Math Notebook header in Work Browser- color (bright green )"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectOtherGrades(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickOnMathNotebookTile(workbrowserAutomationAgent);
                    String NotebookColor = WorkBrowserCommonMethods.VerifyTitleColorOfNotebook(workbrowserAutomationAgent);
                    Assert.AreEqual<string>(NotebookColor, "0x135A00");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29820)]
        [Priority(2)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyReceivedELANoteBookHeaderColorLightBlueInWorkBrowser()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC29820:Verify Received ELA Notebook header in Work Browser- color (light blue)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    string Receivednotebookcolor = WorkBrowserCommonMethods.VerifyReceivedELANotebookColor(workbrowserAutomationAgent);
                    Assert.AreEqual<string>(Receivednotebookcolor, "0xBEC7E4");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29821)]
        [Priority(2)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyReceivedMathNoteBookHeaderColorLightGreenInWorkBrowser()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC29821:Verify Received Math Notebook header in Work Browser- color (light green )"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    string color = WorkBrowserCommonMethods.VerifyReceivedMathNotebookColor(workbrowserAutomationAgent);
                    Assert.AreEqual<string>(color, "0xC4E4BE");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22337)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UserAbleSelectUnitAtTime()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22337: User able to select 1 unit at a time"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickAllUnitsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectUnitFromUnitDropdown(workbrowserAutomationAgent, "1");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllUnitsMenuArrowDisplayed(workbrowserAutomationAgent), "All Units menu arrow is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyUserCanSelectOneUnitAtATime(workbrowserAutomationAgent, "2"), "User cannot select one Unit At a time");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22011)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TappingDownloadTriggersDownloadProgressBar()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22011: Tapping download triggers download progress bar"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickTapToDownLoadForNotDownloadedCRItem(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyProgressBarForCRDownloadedItem(workbrowserAutomationAgent), "Progress Bar is not present for CR downloaded item");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22241)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void DefaultView()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22241: DefaultView"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkViewingFilter(workbrowserAutomationAgent), "My Work is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifySortedByMostRecentFilter(workbrowserAutomationAgent), "Sorted By Most Recent is not displayed");
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyDefaultMessageOnMyClassFilter(workbrowserAutomationAgent), "default message on MyClass filter is not displayed");
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyDefaultMessageOnMyWorkFilter(workbrowserAutomationAgent), "default message on MyWork filter is not displayed");
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectOtherGrades(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkOtherGradesFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyDefaultMessageOnOtherGradesFilter(workbrowserAutomationAgent), "default message on OtherGrades filter is not displayed");
                    WorkBrowserCommonMethods.ClickMyWorkOtherGradesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyDefaultMessageOnPersonalNotesFilter(workbrowserAutomationAgent), "default message on Personal Notes filter is not displayed");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22356)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonDropdownIsDisabledByDefaultUntilUserSelectsUnit()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22356: Lesson dropdown is disabled by default until user selects a unit"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickAllLessonsFilter(workbrowserAutomationAgent);
                    Assert.IsFalse(WorkBrowserCommonMethods.VerifyAllLessonMenuArrowDisplayed(workbrowserAutomationAgent), "All lesson menu arrow is displayed");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(34186)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ByDefaultWorkBrowserShouldSectionsSubjectsSortedMostRecent()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC34186: By default Work Browser should be filtered to show all sections/subjects sorted by Most Recent"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkViewingFilter(workbrowserAutomationAgent), "All subjects are not displayed by default");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifySortedByMostRecentFilter(workbrowserAutomationAgent), "Sorted by is not Most Recent");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22329)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SortingWorkByStudentGridWillDisplayTheNameStudentOnTop()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22329: Sorting work by student, grid will display the name of student on top"))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickStudentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentNameInGridIsDisplayedOnTop(workbrowserAutomationAgent), "Student Name on Top is not displayed");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22322)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SectionedStudentFiltersMyClass1Work()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22322: Sectioned student filters by “My Class” and 1 work and 1+ work type and selects sort by “student” displays in sort label below “sorted by”"))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickStudentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentDisplayedInSortedByLabel(workbrowserAutomationAgent), "Student is not displayed in Sorted By Label");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22330)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SortStudentShouldOrganizedAlphabeticallyFromAToZ()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22330: Sort by student should be organized by alphabetically from A to Z."))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login login1 = Login.GetLogin("Markiva");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, login1.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickStudentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentNameInGridIsDisplayedOnTop(workbrowserAutomationAgent), "Student Name on Top is not displayed");
                    WorkBrowserCommonMethods.VerifyStudentNamesDisplayedAlphabetically(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(20528)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SentWorkButtonInWorkBrowser()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC20528:Sent Work (button) in Work Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");

                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "SendTaskNotebook1"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSec34(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickCommonReads(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifySentButtonDisplayed(workbrowserAutomationAgent), "Sent Button is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyNumberOfNotebooksSent(workbrowserAutomationAgent), "Number Of Notebooks sent are not correct");
                    WorkBrowserCommonMethods.ClickOnSentButton(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifySentWorkOverlayOpened(workbrowserAutomationAgent), "Sent Work Overlay is not Opened");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyModalTitleOfSentWorkOverlay(workbrowserAutomationAgent), "Modal Title Of SentWork Overlay is not correct");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyUnitLessonTaskAndTitle(workbrowserAutomationAgent), "Unit Lesson Task And Title are not correct");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyPageNumberDisplayed(workbrowserAutomationAgent), "Page Number is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyToNamesOfAllRecipients(workbrowserAutomationAgent), "To Names Of All Recipients are not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyDateTimeDisplayed(workbrowserAutomationAgent), "Date Time is not displayed");
                    NotebookCommonMethods.ClickCloseButtonInSentWorkOverlay(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22005)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyClassTileAndTitleInMyClassTab()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22005: Verifies My class tab for class tile and title"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyClassTileColorAndTitle(workbrowserAutomationAgent, loginStud.SectionedGrades[0]), "My class tile color is not light blue");
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(20524)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WorkBrowserTabSelectionSORTEDBYDisplaysStudent()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC20524:Work Browser Tab Selection SORTED BY displays for Student"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentMauricioSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login,true);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(workbrowserAutomationAgent), "User is not on Dashboard");
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkELAMath(workbrowserAutomationAgent), "My Work ELA And Math is not present");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMathFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonDisplayed(workbrowserAutomationAgent), "Lesson Filter is not displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMathFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyAlphabeticalDisplayed(workbrowserAutomationAgent), "Alphabetically Filter is not displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyClassELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMathFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentDisplayed(workbrowserAutomationAgent), "Student Filter is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonDisplayed(workbrowserAutomationAgent), "Lesson Filter is not displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyTeacherELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMathFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonDisplayed(workbrowserAutomationAgent), "Lesson Filter is not displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22458)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SharedWorkDropDownForTeacher()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22458:Shared Work drop down for Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    Login loginteach = Login.GetLogin("Sec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginteach.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    Assert.AreEqual<string>(ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent), "Yor Work Sent message is not displayed");
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginteach);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(workbrowserAutomationAgent), "User is not on Dashboard");
                    DashboardCommonMethods.ClickOnNotificationIconInChrome(workbrowserAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkDropdownPresent(workbrowserAutomationAgent), "Shared Work Dropdown is not Present");
                    WorkBrowserCommonMethods.ClickTopItemFromInNotificationOverlay(workbrowserAutomationAgent);
                    DashboardCommonMethods.ClickOnGoToWorkBrowserButton(workbrowserAutomationAgent);
                    Assert.IsFalse(DashboardCommonMethods.VerifySharedWorkDropdownPresent(workbrowserAutomationAgent), "Shared Work Dropdown is Present");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyClassViewingFilter(workbrowserAutomationAgent), "My Class filter is not present");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyAssociatedSectionOfTiles(workbrowserAutomationAgent), "Associated Section is not present for tiles");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(20529)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WorkBrowserTabSelectionSORTEDBYDisplaysForTeacher()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC20529:Work Browser Tab Selection SORTED BY displays for Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(workbrowserAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(workbrowserAutomationAgent), "User is not on Dashboard");
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkViewingFilter(workbrowserAutomationAgent), "My Work Sec34 is not present");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonDisplayed(workbrowserAutomationAgent), "Lesson Filter is not displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyAlphabeticalDisplayed(workbrowserAutomationAgent), "Alphabetically Filter is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonDisplayed(workbrowserAutomationAgent), "Lesson Filter is not displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentDisplayed(workbrowserAutomationAgent), "Student Filter is not displayed");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonDisplayed(workbrowserAutomationAgent), "Lesson Filter is not displayed");
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22331)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UserWorkShouldBeGroupedByUnitAndLesson()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22331: User work should be grouped by Unit and Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Lesson");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    LessonBrowserCommonMethods.ClickUnitBackButton(workbrowserAutomationAgent, 1);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(workbrowserAutomationAgent, 2);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(workbrowserAutomationAgent, 2);
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Second Lesson");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickLessonDisplayed(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyWorkIsGroupedByUnitAndLesson(workbrowserAutomationAgent));
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22004)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyReceivedAndSendButtonAlignment()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22004: Verifies received and send button alignment below baseball card"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifySendButtonCentered(workbrowserAutomationAgent, "Classroom Rules and Routines"), "Sent button is not centered in the baseball card");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22246), WorkItem(22003)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyReceivedWorkOverlay()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22003 & TC22246: Verifies received work overlay"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickReceivedLabel(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(workbrowserAutomationAgent), "Received work overlay is not found");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedItemModalTile(workbrowserAutomationAgent), "Received item modal tile is not as per description");
                    WorkBrowserCommonMethods.ClickCloseButtonInReceivedWorkOverlay(workbrowserAutomationAgent);
                    Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(workbrowserAutomationAgent), "Received work overlay is found");
                    WorkBrowserCommonMethods.ClickReceivedLabel(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickOnScreen(workbrowserAutomationAgent);
                    Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(workbrowserAutomationAgent), "Received work overlay is found");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22002)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyNumberInBaseballItemTile()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22002: Verifies number in baseball item tile"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyNumberInItemTile(workbrowserAutomationAgent), "Number is not found in the item tile");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22245), WorkItem(22243)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyReceivedLabelByChangingFilter()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22245 & TC22243: Verifies received label by changing filter"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedLabel(workbrowserAutomationAgent), "Received label is not found");
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassELAMath(workbrowserAutomationAgent);
                    Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedLabel(workbrowserAutomationAgent), "Received label is found");
                    WorkBrowserCommonMethods.ClickMyClassELAMath(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherELAMath(workbrowserAutomationAgent);
                    Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedLabel(workbrowserAutomationAgent), "Received label is found");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22332)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CombinationOfUnitAndLessonShouldBeDescendingBasedOnUnitAndLessonNumbersDescending()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22332: The combination of Unit and Lesson should be descending, based on Unit and Lesson numbers descending."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Unit 1 Lesson 1");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    LessonBrowserCommonMethods.ClickUnitBackButton(workbrowserAutomationAgent, 1);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(workbrowserAutomationAgent, 2);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(workbrowserAutomationAgent, 4);
                    workbrowserAutomationAgent.Sleep(3000);
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Unit 1 Lesson 2");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "SendTaskNotebook1"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Unit 2 Lesson 1");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickLessonDisplayed(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyWorkIsDescendingBasedOnUnitAndLesson(workbrowserAutomationAgent));
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22326)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void MultipleItemsReceivedStudentReversedChronological()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22326: Multiple items received from a particular student, display in reversed chronological order with most recent item received first."))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TaskInfo taskInfo1 = login.GetTaskInfo("ELA", "Notebook");
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("Sec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "NonSectionedTask"));
                    TaskInfo taskInfo2 = login.GetTaskInfo("ELA", "SendTaskNotebook1");
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "Second");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyLastSentItemIsDisplayedFirst(workbrowserAutomationAgent, taskInfo2.Lesson), "");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyFirstSentItemDisplayedSecond(workbrowserAutomationAgent, taskInfo1.Lesson), "");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22324)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void DisplayReceivedItemsAlphabeticallyByStudentLastNamesFromAToZ()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22324: Display received items alphabetically by student last name from A to Z"))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    Login login1 = Login.GetLogin("Markiva");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, login1.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(workbrowserAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyYourWillWorkSent(workbrowserAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOkButton(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                    
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.VerifyReceivedItemsAreArrangedByLastName(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22348)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyChronologicalOrderOfItemsInWorkBrowser()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC22348: Verify most recent items are shown in chronological order"))
            {
                try
                {
                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(workbrowserAutomationAgent, taskInfo);
                    NotebookCommonMethods.ClickOnNotebookIcon(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(workbrowserAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 500, 1);
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1230, 500, 1);
                    NotebookCommonMethods.SendText(workbrowserAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyFirstItemLesson(workbrowserAutomationAgent, taskInfo.Unit, taskInfo.Lesson), "Recently edited item is not the first item in the work browser");
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyItemsInChronologicalOrder(workbrowserAutomationAgent), "Items are not in chronological order");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22171)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SingleButtonSentOrReceivedCenteredAcrossBottomTile()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22171: Single Button Sent Or Received Centered Across Bottom Tile"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(workbrowserAutomationAgent, 1);
                    NotebookCommonMethods.SelectOtherGrades(workbrowserAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(workbrowserAutomationAgent, 1);
                    NotebookCommonMethods.ClickSentInNotbookBottomTile(workbrowserAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySentWorkLabelCentered(workbrowserAutomationAgent), "SentWork Label not in center");
                    NotebookCommonMethods.ClickCloseButtonInSentWorkOverlay(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }

                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(23113)]
        [Priority(1)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyDownloadGradeAlertInNotebookPreview()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC23113: Notebook Preview - Verify Download Grade Alert when grade is not yet downloaded"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickELANotebookTile(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(workbrowserAutomationAgent);
                    NotebookCommonMethods.VerifyGradeNotAvailableAlert(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(20526)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WorkBrowserSortedByOtherField()
        {

            using (workbrowserAutomationAgent = new AutomationAgent("TC20526:SORTED BY other fields - Work Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToMyDashboard(workbrowserAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(workbrowserAutomationAgent), "User is not on Dashboard");
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkViewingFilter(workbrowserAutomationAgent), "My Work Sec34 is not present");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    workbrowserAutomationAgent.Sleep(1000);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassFilter(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickSec34Tile(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickOnCommonReads(workbrowserAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(workbrowserAutomationAgent, 1);
                    WorkBrowserCommonMethods.ClickSortByMostRecentFilter(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentDisplayed(workbrowserAutomationAgent), "MostRecent is not Displayed");
                    WorkBrowserCommonMethods.SelectLessonFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickAllUnitsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectUnitFromUnitDropdown(workbrowserAutomationAgent, "4");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    WorkBrowserCommonMethods.ClickAllLessonsFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectLessonFromLessonDropdown(workbrowserAutomationAgent, "1");
                    NotebookCommonMethods.TapOnScreen(workbrowserAutomationAgent, 104, 434, 1);
                    DateTime startDate = DateTime.ParseExact(WorkBrowserCommonMethods.GetMyClassNotebooksModifiedDate(workbrowserAutomationAgent, 65), "dd-MM-yy", null);
                    DateTime endDate = DateTime.ParseExact(WorkBrowserCommonMethods.GetMyClassNotebooksModifiedDate(workbrowserAutomationAgent, 67), "dd-MM-yy", null);
                    Assert.IsTrue(endDate < startDate, "date is not lesser then the next date");
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(21996)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyMyWorkTabDisplayBlueForElaAndGreenForMath()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC21996:Tile header in My Work tab displays dark blue for ELA and Dark Green for Maths & displays title"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.SelectOtherGrades(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickOnELANotebookTile(workbrowserAutomationAgent);
                    String NotebookColor = WorkBrowserCommonMethods.VerifyTitleColorOfNotebook(workbrowserAutomationAgent);
                    Assert.AreEqual<string>(NotebookColor, "0x0031C3");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(workbrowserAutomationAgent);
                    WorkBrowserCommonMethods.ClickOnMathNotebookTile(workbrowserAutomationAgent);
                    String NotebookColorMath = WorkBrowserCommonMethods.VerifyTitleColorOfNotebook(workbrowserAutomationAgent);
                    Assert.AreEqual<string>(NotebookColorMath, "0x135A00");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [Priority(2)]
        [WorkItem(22172)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ReceivedWorkOverlayThumbnailsBlurryModelAligned()
        {
            using (workbrowserAutomationAgent = new AutomationAgent("TC22172: Received work overlay thumbnails are not blurry, left, edge of modal is aligned"))
            {
                try
                {
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(workbrowserAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(workbrowserAutomationAgent);
                    NotebookCommonMethods.ClickOnReceivedWork(workbrowserAutomationAgent);
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceiveWorkLeftEdgeModalAligned(workbrowserAutomationAgent), "Receive Work Is not left Aligned");
                    NotebookCommonMethods.ClickCloseButtonInSentWorkOverlay(workbrowserAutomationAgent);
                    NavigationCommonMethods.Logout(workbrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    workbrowserAutomationAgent.Sleep(2000);
                    workbrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    workbrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}