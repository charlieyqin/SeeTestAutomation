using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using System.Linq;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    /// <summary>
    /// Summary description for NavigationTests
    /// </summary>
    [TestClass]
    public class NavigationTests
    {
        public AutomationAgent navigationAutomationAgent;
        public NavigationTests()
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
        [AssemblyInitialize]
        public static void _212AssemblyInitialize(TestContext testContext)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["ReportFolderPerRun"]))
            {
                AutomationAgent.CreateAndSetReportsFolder("212");
            }
        }

        [ClassInitialize]
        public static void NavigationTestsClassInitialize(TestContext testContext)
        {
        }
        [TestInitialize]
        public void NavigationTestsTestInitialize()
        {

        }


        [AssemblyCleanup]
        public static void _212AssemblyCleanup()
        {

        }

        [ClassCleanup]
        public static void NavigationTestsClassCleanup()
        {

        }
        [TestCleanup]
        public void NavigationTestsTestCleanup()
        {

        }
        #endregion

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16042)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NonSectionTeacherUpdateContentButtonImageInSystemTray()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16042: non section teacher Update Content button image in System Tray"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPage(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16043)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionTeacherUpdateContentButtonImageInSystemTray()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16043: Section Teacher Update Content button image in System Tray"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16050), WorkItem(16051)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AccessToUnitLibraryPageForSectionedTeachersTask()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16050, TC16051: Access to Unit Library page for sectioned teachers -task"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPosition(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);                   
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16069)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GlobalNavigationVerifyChromeIconSetForSectionedStudent()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16069: Global Navigation - Verify chrome icon set for sectioned student"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NavigationCommonMethods.VerifyChromeIconSetInMathStudent(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.VerifyChromeIconSetInELAStudent(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16070)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GlobalNavigationVerifyChromeIconSetForSectionedTeacher()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16070: Global Navigation - Verify chrome icon set for sectioned teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NavigationCommonMethods.VerifyChromeIconSetInMathTeacher(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.VerifyChromeIconSetInELATeacher(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16045), WorkItem(16049)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AccessToUnitLibraryPageForNonSectionedTeachersTask()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16045, TC16049: Access to Unit Library page for non-sectioned teachers -task"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPositionForNonSectionedUser(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(16044)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AddImageForLogOutButtonInSystemTraySectionTeacher()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16044: Add image for Log out button in System Tray -Section Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLogoutButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(16047)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AddImageForLogOutButtonInSystemTrayStudent()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16047: Add image for Log out button in System Tray -Student"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLogoutButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16052)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionTeacherPort3SystemTray()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16052: Section Teacher port 3 system tray"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyWorkBrowserPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateTeacherSupport(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyTeacherSupportPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    LoginLogoutCommonMethods.VerifyLoginButtonPresent(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(19066)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SectionStudentPort3SystemTray()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC19066: Section Student port 3 system tray"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyWorkBrowserPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    LoginLogoutCommonMethods.VerifyLoginButtonPresent(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(19380)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GlobalNavigationOpenToolsGamesIconAsStudent()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19380: Global Navigation open Tools & games icon as a Student"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySnapshotToolButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(19398)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GlobalNavigationOpenToolsGamesIconAsTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19398: Global Navigation Open Tools & games icon as a Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySnapshotToolButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(19418)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GlobalNavigationOpenToolsGamesIconWithinLesson()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19418: Global Navigation ,open Tools & Games icon within Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySnapshotToolButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20028)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeIconDisplaysForTheFollowingLocations()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20028: Teacher Mode ICON - displays for the following locations: Unit Preview, Lesson Browser, Lesson Preview, Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20027)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeContentDisplaysForUnitPreview()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20027: Teacher Mode CONTENT displays for Unit Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMathGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(navigationAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeOpened(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeOpened(navigationAutomationAgent));
                    NavigationCommonMethods.NavigateToMathGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20026)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherMode3SectionsAreUnitOverviewAboutThisLessonTeacherGuide()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20026: Teacher Mode 3 sections are: Unit Overview / About This Lesson / Teacher Guide"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20024)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenTeacherModeSwitchedOnAndNavigatesThroughContentThenTeacherContentChangesLive()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20024: WHEN Teacher Mode switched on AND teacher navigates through the content THEN teacher content changes live"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");

                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMathGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(navigationAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathUnitPreview(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(navigationAutomationAgent, 1);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickMathLessonContinueButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideExpands(navigationAutomationAgent));
                    int pageno = LessonBrowserCommonMethods.GetTaskPageNumberInLesson(navigationAutomationAgent);
                    while (pageno < 3)
                    {
                        string taskno = LessonBrowserCommonMethods.GetTaskNumberInTeacherGuide(navigationAutomationAgent);
                        Assert.AreEqual(true, taskno.Equals("Task " + pageno));
                        LessonBrowserCommonMethods.ClickOnNextButtonInTask(navigationAutomationAgent);
                        pageno = LessonBrowserCommonMethods.GetTaskPageNumberInLesson(navigationAutomationAgent);
                    }

                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeOpen(navigationAutomationAgent));
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20021)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OnlyOneTeacherModeSectionCanBeExpandedAtATime()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20021: only one Teacher Mode section can be expanded at a time"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeOpened(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(23151)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AddOrganizationEnhancementsToUnitsBrowsingForSectionTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23151: Add organization enhancements to Units Browsing for -section teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    string textColor = NavigationCommonMethods.GetTextColorOfGrades(navigationAutomationAgent, taskInfo.Grade);
                    Assert.AreEqual(textColor, "0xFFFFFF", "Color of grade is not the same");
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitsNumberInOrder(navigationAutomationAgent, taskInfo.Unit), "Unit number is not present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(23150)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SelectingUnitsInUnitLibraryHighlightsTheParticularSubject()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23150: Add organization enhancements to Units Browsing for -section teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    string ELAUnitColor = NavigationCommonMethods.VerifyELAUnitHighlight(navigationAutomationAgent);
                    Assert.AreEqual(ELAUnitColor, "0x649BFF", "ELA Unit color not the same");
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    string MathUnitColor = NavigationCommonMethods.VerifyMathUnitHighlight(navigationAutomationAgent);
                    Assert.AreEqual(MathUnitColor, "0x7EC437", "Math Unit color not the same");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(23149)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UnitLibraryButtonCollapsesTheCourseList()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23149: Add organization enhancements to Units Browsing for -section teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickUnitLibraryButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickUnitLibraryButton(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryCollapsed(navigationAutomationAgent), "Unit Library not collapsed");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(23148)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyUnitLibraryButtonExpandsAfterClickingOnUnitLibrary()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC23148: Add organization enhancements to Units Browsing for -section teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    DashboardCommonMethods.VerifyUserIsOnDashBoard(navigationAutomationAgent);
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyUnitLibraryButton(navigationAutomationAgent), "");
                    NavigationCommonMethods.VerifyUnitLibraryPosition(navigationAutomationAgent);
                    NavigationCommonMethods.ClickUnitLibraryButton(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryExpanded(navigationAutomationAgent));
                    string ELAUnitColor = NavigationCommonMethods.VerifyELAUnitHighlight(navigationAutomationAgent);
                    Assert.AreEqual(ELAUnitColor, "0x649BFF");
                    string MathUnitColor = NavigationCommonMethods.VerifyMathUnitHighlight(navigationAutomationAgent);
                    Assert.AreEqual(MathUnitColor, "0x7EC437");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(22867)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ThreeStatesForCoursePackageDownloadInProgress()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC22867: states for course package download in-progress"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int UnitNo = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, UnitNo);
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent), "Prepairing units not present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(22868)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ThreeStatesForCoursePackageDownloadQueued()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC22868: 3 states for course package download queued"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int UnitNo = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, UnitNo);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyActivitySpinnerExists(navigationAutomationAgent), "Activity spinner doesn't exist");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(16088)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ThreeStatesForCoursePackageDownloadCompleted()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16088: Verify Completed state for course package download"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.VerifyUnitThumbnails(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyImagesInDashboard(navigationAutomationAgent, taskInfo.Grade.ToString(), "ELA"), "Grade text is not the same");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(23154)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyHeadingOfFlyoutMenu()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23154: CA - Resource Library-To verify the heading of the flyout menu"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.ClickOnToolsIcon(navigationAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyResourceLibraryFlyOutMenu(navigationAutomationAgent), "Resource Library FlyOut Menu not present");
                    string heading = NavigationCommonMethods.GetToolsIconHeading(navigationAutomationAgent);
                    Assert.AreEqual(heading, "Resource Library", "Heading is not Resource Library");
                    NavigationCommonMethods.ClickOnToolsIcon(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15873)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyRemoveGradeButton()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15873: Verify remove this grade button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    bool isGradeAdded = true;
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15985)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitLibraryWhenWiFiOffDuringGradeDownloadThenNoWiFiIconVisible()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15985: 3c/ Unit Library WHEN wi-fi off during grade download THEN no-wifi icon visible"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    bool isGradeAdded = true;
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent), "Prepairing Units not present");
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, true);
                    navigationAutomationAgent.LaunchApp();
                    Assert.IsFalse(NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent), "Prepairing units present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(navigationAutomationAgent), "No Wifi Icon not present");
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, false);
                    navigationAutomationAgent.LaunchApp();
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15971)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitLibraryAddGradesButtonEnabledWhenDownloadInProgress()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15971: Unit Library: [Add grades] button is enabled when download in progress"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    bool isGradeAdded = true;
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 7;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    if (isGradeAdded)
                    {
                        Assert.AreEqual<string>("true", NavigationCommonMethods.VerifyAddGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    }
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(29936)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ELAMoreToExplore()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC29936: ELA- More to Explore"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);

                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.ClickMoreToExploreButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePage(navigationAutomationAgent), "More To Explore Page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(29937)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MATHConceptCorner()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC29937: MATH-Concept Corner"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);

                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);

                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NavigationCommonMethods.ClickConceptCornerButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPage(navigationAutomationAgent), "Concepot Corner page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(20440)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUnitXThumbnailIsTappedAndSwipedAndOpenedUnitYThenBackSendsUsToUnitYPreviewCard()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC20440: WHEN UnitX thumbnail is tapped, AND swiped & opened UnitY, THEN 'back' sends us to UnitY preview card"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(navigationAutomationAgent, Int32.Parse(taskInfo.Unit)), "Unit Preview card not present");
                    NavigationCommonMethods.SwipeUnit(navigationAutomationAgent, Direction.Right);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(navigationAutomationAgent, Int32.Parse(taskInfo.Unit) + 1);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(navigationAutomationAgent, Int32.Parse(taskInfo.Unit) + 1), "Unit preview card not present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(23156)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CAResourceLibraryToVerifyTheBackButtonOnMenuHeading()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC23156: CA - Resource Library-To verify the back button on Menu heading"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickOnToolsIcon(navigationAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyResourceLibraryFlyOutMenu(navigationAutomationAgent), "Resource Library Fly out menu not present");
                    string heading = NavigationCommonMethods.GetToolsIconHeading(navigationAutomationAgent);
                    Assert.AreEqual(heading, "Resource Library", "Heading is not Resource Library");
                    NavigationCommonMethods.ClickOnSpellingMenuItem(navigationAutomationAgent);
                    NavigationCommonMethods.ClickBackButtonOnResourceLibraryFlyOutMenu(navigationAutomationAgent);
                    string newheading = NavigationCommonMethods.GetToolsIconHeading(navigationAutomationAgent);
                    Assert.AreEqual(newheading, "Resource Library", "Heading is not Resource Library");
                    NavigationCommonMethods.ClickOnToolsIcon(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(30096)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentDashboardCCUserIsDirectedToSpecificWebpageRelevantToTheLessonThatIsLastViewedLesson()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC30096: STUDENT DASHBOARD: CC - User is directed to the specific webpage relevant to the lesson that is my last viewed lesson."))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));

                    NavigationCommonMethods.ClickConceptCornerButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPageRelevantToLastViewedLesson(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(30097)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentDashboardMTEUserIsDirectedToSpecificWebpage()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC30097: STUDENT DASHBOARD: MTE - User is directed to the specific webpage relevant to the lesson that is my last viewed lesson."))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    TaskInfo taskinfo = login.GetTaskInfo("Math", "Notebook");

                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    DashboardCommonMethods.ClickMoreToExploreButtonStudentDashboard(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePageRelevantToLastViewedLesson(navigationAutomationAgent, taskinfo.Grade.ToString(), taskinfo.Lesson.ToString()));
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15864)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SwipeLetfRightOnTheUnitPreviewScreenWhenThereAreMoreContentToBeDisplayed()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15864: Swipe letf/right on the unit preview screen when there are more content to be displayed"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(navigationAutomationAgent, taskInfo.Unit), "Unit Preview card not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreUnitsCardDisplayed(navigationAutomationAgent), "More Units card card not present");
                    NavigationCommonMethods.SwipeUnit(navigationAutomationAgent, Direction.Right);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEdgeOfNextUnitCardDisplayed(navigationAutomationAgent), "Edge of next unit card not present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15865)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void AppChromeScreenTitleCorrectUnitPreviewGradeXMathOrGradeXELA()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15865: App Chrome screen title correct (Unit Preview) = Grade X Math or Grade X ELA"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyUnitPreviewCard(navigationAutomationAgent, taskInfo.Unit));
                    string GradeText = NavigationCommonMethods.VerifyAppChromeTitleOnUnitPreviewScreen(navigationAutomationAgent, taskInfo.Grade);
                    Assert.AreEqual<bool>(true, GradeText.Contains("Grade " + taskInfo.Grade + " ELA"));
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16111)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitLibraryLowestGradeOnDeviceDefaultGradeShownInHighlightedState()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16111: Unit Library: the lowest grade on the device is default grade shown in the highlighted state"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryButtonPresent(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(navigationAutomationAgent, taskInfo.Grade), "Default grade not in highlited state");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(30112)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNewAppIcon()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC30112: Verify new app icon appears after app is installed"))
            {
                try
                {
                    navigationAutomationAgent.SendText("{HOME}");
                    Assert.IsTrue(NavigationCommonMethods.VerifyNewAppIconOnHomeScreen(navigationAutomationAgent), "New application icon doesn't exist");
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15874)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UsingBackNavigationButtonsYouReturnToUnitLibrary()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15874: NAVIGATION: if you browsed gradeX content, you return to unit library gradeX using back navigation buttons"))
            {
                try
                {
                    NavigationCommonMethods.Login(navigationAutomationAgent, Login.GetLogin("GustadMody"));
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(15967)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserAbleToAddAnyGradeByTapingAddGradesButton()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC15967: 10/ User able add any grade by taping [Add grades] button"))
            {
                try
                {
                    bool isGradeAdded = true;
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(15969)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserAbleToSeeGradeSelectionScreenByTapingAddGradesButton()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC15969: 4/ User able to see grade selection screen by taping [Add grades] button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyAddGradeButtonPresent(navigationAutomationAgent));
                    NavigationCommonMethods.TapAddgrade(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyAddGradePopUp(navigationAutomationAgent));
                    NavigationCommonMethods.ClickCancelInSelectGrade(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(15972)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AfterSelectingGradeToAddTheUserSeeNewGradesOnTopRibbonOfUnitLibrary()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC15972: Adding grades - after selecting which grade(s) to add, the user will see the new grade(s) on the top ribbon of the unit library."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    bool isGradeAdded = true;
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(15974)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void IfAddedMultipleGradesNewGradesWillBeginTheCourseLevelPackageDownload()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC15974: 7810/ if used ADDED multiple grades, The new grades will begin the course level package download"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    bool isGradeAdded = true;
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        //[TestCategory("NavigationTests")]
        //[Priority(2)]
        //[WorkItem(15980)]
        //[Owner("Mohammed Saquib(mohammed.saquib)")]
        //public void UsersNameIsVisibleOnTheGradeSelectionScreen()
        //{

        //    using (navigationAutomationAgent = new AutomationAgent("TC15980: 77/ user's name is visible on the grade selection screen"))
        //    {
        //        try
        //        {
        //            Login login = Login.GetLogin("GustadMody");
        //            string name = login.PersonName;
        //            NavigationCommonMethods.Login(navigationAutomationAgent, login);
        //            NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
        //            NavigationCommonMethods.TapAddgrade(navigationAutomationAgent);
        //            Assert.IsTrue(NavigationCommonMethods.VerifyAddGradePopUp(navigationAutomationAgent));
        //            string nameInPopUp = NavigationCommonMethods.GetUserNameInAddGradePopUp(navigationAutomationAgent);
        //            Assert.AreEqual(name, nameInPopUp);
        //            NavigationCommonMethods.ClickCancelInSelectGrade(navigationAutomationAgent);
        //            NavigationCommonMethods.Logout(navigationAutomationAgent);
        //        }
        //        catch (Exception ex)
        //        {
        //            navigationAutomationAgent.Sleep(2000);
        //            navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
        //            navigationAutomationAgent.ApplicationClose();
        //            throw;
        //        }
        //    }
        //}

        [TestMethod()]
        [TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        [WorkItem(16091)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitLibraryChromeTitlesAreELAUnitsAndMathUnits()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16091: Unit Library chrome titles are: ELA Units and Math Units"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16092)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NoBackButtonOnUnitLibrary()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16092: no 'back' button on Unit Library"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyBackButtonPresent(navigationAutomationAgent));
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(16108)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StudentsCantSeeRemoveThisGradeutton()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16108: Students can't see (Remove this grade) button"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyRemoveGradeButtonPresent(navigationAutomationAgent), "Remove Grade button is present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(16109)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void RemoveThisGradeRemovesTheGradeThatWeAreCurrentlyViewingInUnitLibrary()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16109: Remove this grade removes the grade that we're currently viewing in Unit Library"))
            {
                try
                {
                    bool isGradeAdded = true;
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    Assert.IsFalse(NavigationCommonMethods.VerifySpecificGradePresent(navigationAutomationAgent, gradeAdded), "Specified grade is present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(17696)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenTappedLogOutThenUserIsLoggedOutAndMovedToLoginScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC17696: WHEN tapped 'log out' THEN user is logged out and moved to login screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLogoutButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    NavigationCommonMethods.VerifyLoginScreen(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(34064)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CAWhenUserTapsOnMTEIconInLessonThenCASpecificMTEOpensInWebview()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC34064: CA - WHEN user taps on MTE icon in lesson THEN CA-specific MTE opens in webview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.ClickMoreToExploreButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePage(navigationAutomationAgent), "More To Explore Page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(20039)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUnitXThumbnailIsTappedThenUnitXPreviewCardIsOpened()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC20039: when UnitX thumbnail is tapped, then UnitX Preview Card is opened"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    string title = NavigationCommonMethods.GetUnitTitleFromUnitThumbnail(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    string newTitle = NavigationCommonMethods.GetUnitTitleFromUnitPreview(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual(title, newTitle, "Titles are not similar");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20098)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void QueueDownloadIndicatorVisibleInUnitLibraryForGradesQueued()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20098: QUEUE download indicator is visible (in Unit Library) for the grades queued"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeNo = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    int newGradeNo = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeNo);
                    NavigationCommonMethods.VerifyWaitingToDownload(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, newGradeNo);
                    NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent);
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeNo);
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    NavigationCommonMethods.RemoveGrades(navigationAutomationAgent, gradeNo, newGradeNo);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(19384)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LogOutRightAfterAddingNewGrades()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19384: log out right after adding new grades - no unexpected behaviors observed"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    NavigationCommonMethods.VerifyLoginScreen(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16087)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void RightAfterAddingGradesNewGradesAppearOnTopRibbonOfUnitLibrary()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16087: right after Adding grades new grade(s) appear on the top ribbon of the Unit Library"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    bool isGradeAdded = true;
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    if (gradeAdded == 0)
                    {
                        gradeAdded = 5;
                        isGradeAdded = false;
                    }
                    NavigationCommonMethods.VerifyNewGradeOnRibbon(navigationAutomationAgent, gradeAdded);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    if (isGradeAdded)
                    {
                        NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15921)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenNonSectionedTapsCANCELGradeSelectionTheyAreBroughtLogScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15921: 75/ When a non-sectioned user taps CANCEL on grade selection, they are brought to log in screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.VerifyGradeSelectionScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickCancelButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLoginScreen(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16074)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenNonSectionedLogsIn1stTimeThenUserIsMovedToUnitLibary()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16074: 3/ WHEN non-sectioned user logs in 1st time (content is already on device) THEN user is moved directly to Unit Libary"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent));
                    Assert.IsFalse(NavigationCommonMethods.VerifyGradeSelectionScreen(navigationAutomationAgent));
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(22144)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenNonsectionedUserLogsInFirstTimeUserIsPromptedToSelectGrade()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22144: when non-sectioned user logs in for the first time, user is prompted to select a grade"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(navigationAutomationAgent, login);
                    Assert.IsTrue(NavigationCommonMethods.VerifyGradeSelectionScreen(navigationAutomationAgent));
                    NavigationCommonMethods.VerifySelectOnlyOneGrade(navigationAutomationAgent);
                    NavigationCommonMethods.ClickCancelButton(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16090)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitLibraryGradesOnRibbonAreClickableAndGetHighlighted()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16090: Unit Library: grades on the ribbon are clickable and get highlighted"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeaddedX = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    int gradeaddedY = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyNewGradeOnRibbon(navigationAutomationAgent, gradeaddedX);
                    NavigationCommonMethods.ClickNewAddedGrade(navigationAutomationAgent, gradeaddedX);
                    NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyNewGradeOnRibbon(navigationAutomationAgent, gradeaddedY);
                    NavigationCommonMethods.ClickNewAddedGrade(navigationAutomationAgent, gradeaddedY);
                    NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent);
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickNewAddedGrade(navigationAutomationAgent, gradeaddedX);
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    NavigationCommonMethods.RemoveGrades(navigationAutomationAgent, gradeaddedX, gradeaddedY);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(17678)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UponFirstLogInNonSectionedShouldntSeeAnyGradesSelectedOnGradeSelectionScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC17678: Upon first log in, non-sectioned user shouldn't see any grades selected on the Grade Selection screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(navigationAutomationAgent, login);
                    Assert.IsTrue(NavigationCommonMethods.VerifyGradeSelectionScreen(navigationAutomationAgent));
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoGradeSelectedOnFirstLogin(navigationAutomationAgent));
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(16113)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UnitPreviewDisplaysTheFollowingThings()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC16113: Unit Preview - display with Unit Number, Title, Image(Math), Description(ELA) and 'Start' button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.VerifyELAUnitPreviewDetails(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(23147)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NonSectionedUsersDontSeeDashboard()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC23147: non sectioned users don't see MTE CC ( as they don't see the dashboard at all)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    Assert.IsFalse(DashboardCommonMethods.VerifyUserIsOnDashBoard(navigationAutomationAgent), "User Is not On DashBoard");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    Login login1 = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login1);
                    Assert.IsFalse(DashboardCommonMethods.VerifyUserIsOnDashBoard(navigationAutomationAgent), "User Is not On DashBoard");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15968)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenAllPossibleELAGradesAddedToTheDeviceAddGradeButtonDisable()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15968:when all possible ELA grades have been added to the device"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.AddAllGrades(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyAddGradeButtonPresent(navigationAutomationAgent), "Add grade button is still present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16112)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitPreviewCarouselAllUnitsDisplayedInAscendingOrderFromUnit1Unit2()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16112:Unit Preview Carousel - all units are displayed in the ascending order from unit 1 unit 2..."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "UnitOrderVerify");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.VerifyUnitsAreInOrder(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(31820)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UnitLabelsAreUpdatedInFollowingLocations()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC31820: Unit Preview - display with Unit Number, Title, Image(Math), Description(ELA) and 'Start' button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    string UnitNo = NavigationCommonMethods.GetUnitThumbnailText(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual(UnitNo, "Unit" + taskInfo.Unit, "UnitNo and Unit A are not equal");
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    string unitNo = NavigationCommonMethods.GetUnitLabelFromUnitPreview(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual(unitNo, "Unit" + taskInfo.Unit, "unitno and Unit A are not equal");
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    string lessonTitle = LessonBrowserCommonMethods.GetLessonTitle(navigationAutomationAgent);
                    Assert.AreEqual(lessonTitle, "Unit " + taskInfo.Unit + ": Signs and Symbols", "lesson title and Unit A are not equal");
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    string text1 = LessonBrowserCommonMethods.GetLessonBrowserBackButtonText(navigationAutomationAgent);
                    text1 = text1.TrimEnd();
                    Assert.AreEqual(text1, "Unit " + taskInfo.Unit, "Text1 and Unit A are not eaqual");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(20038)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NavigationIconShouldBeVisible()
        {

            using (navigationAutomationAgent = new AutomationAgent("TC20038: Unit Preview - navigation icons should be visible (tools, notification, teacher mode)"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(DashboardCommonMethods.VerifySharingNotificationIconInChrome(navigationAutomationAgent), "Sharing Notification IconIn Chrome is not found");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyResourceLibraryIconPresent(navigationAutomationAgent), "ResourceLibraryFlyOutMenu is not found");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teacher ModeIcon is not Present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22461)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ElaOrMathForStudent()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22461: ELA/MATH for Student"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(navigationAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(navigationAutomationAgent), "Work Browser Overlay is not Present");
                    NotebookCommonMethods.ClickGoToWorkBrowserButton(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyWorkBrowserPageOpened(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15979)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserRecommendedToSelectOnly2GradesWhenAddingGrades()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15979: user recommended to select only 2 grades when adding grades"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.TapAddgrade(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyRecommendationMessageAddGrade(navigationAutomationAgent), "Recommendation messag to add only 2 grade not found");
                    NavigationCommonMethods.ClickCancelInSelectGrade(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16212)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ResizingMovingTheSnapshotWindow()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16212: Resizing/moving the snapshot window"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NotebookCommonMethods.OpenSnapShot(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(navigationAutomationAgent));

                    int snapshotgridwidth = NotebookCommonMethods.GetWidthofSnapshotGrid(navigationAutomationAgent);
                    NotebookCommonMethods.ResizeSnapshotGrid(navigationAutomationAgent);
                    int snapshotgridwidthnew = NotebookCommonMethods.GetWidthofSnapshotGrid(navigationAutomationAgent);
                    Assert.AreNotEqual(snapshotgridwidth, snapshotgridwidthnew, "Snapshot not resized");


                    string gridpos = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    NotebookCommonMethods.SwipeSnapshotGrid(navigationAutomationAgent);
                    string gridposnew = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    Assert.AreNotEqual(gridpos, gridposnew, "snapshot grid not repositioned");


                    NotebookCommonMethods.SwipeSnapshotGrid(navigationAutomationAgent, 1000);
                    string gridposnewSwipeBeyondScreen = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    NotebookCommonMethods.SwipeSnapshotGrid(navigationAutomationAgent);
                    string gridposnewSwipeBeyondScreenAgain = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    Assert.AreEqual(gridposnewSwipeBeyondScreenAgain, gridposnewSwipeBeyondScreen, "snapshot grid repositioned above screen size");

                    NotebookCommonMethods.ClickCancelSnapShot(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(21756)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ELAMoreToExploreAndMathConceptCorner()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC21756: ELA- More to Explore and MATH-Concept Corner"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.ClickMoreToExploreButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePage(navigationAutomationAgent), "More To Explore Page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NavigationCommonMethods.ClickConceptCornerButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPage(navigationAutomationAgent), "Concepot Corner page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(31801)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CCSSStandardsButtonArrowUPWhenStandardsCollapsedDOWNWhenStandardsExpanded()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC31801:CCSS: standards button's arrow is UP when standards are collapsed and DOWN when standards are expanded"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    navigationAutomationAgent.Sleep(4000);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowUp(navigationAutomationAgent), "Educational Standard Arrow is not Up");
                    NavigationCommonMethods.ClickEducationalStandardArrowUp(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardExpands(navigationAutomationAgent), "Educational Standard does not Expands");
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowDown(navigationAutomationAgent), "Educational Standard Arrow is not Down");
                    NavigationCommonMethods.ClickEducationalStandardArrowDown(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardCollapses(navigationAutomationAgent), "Educational Standard does not Collapses");
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowUp(navigationAutomationAgent), "Educational Standard Arrow is not Up");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16105), WorkItem(16110)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyRemoveGradesButton()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC16105 & TC16110: Verify remove grades button for different users in different scenarios"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    string failureMessage;
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonForSectionedGradesInELA(navigationAutomationAgent, login, out failureMessage), failureMessage);
                    NavigationCommonMethods.ClickELAGradeInUnitLibrary(navigationAutomationAgent, NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent));
                    Assert.IsFalse(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove Grade button is Active for newly added grade");
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.AddGrades(navigationAutomationAgent, 12);
                    NavigationCommonMethods.ClickELAGradeInUnitLibrary(navigationAutomationAgent, 12);
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    int[] availableELAGrades = NavigationCommonMethods.GetAvailableGradesInELA(navigationAutomationAgent);
                    int[] gradesToRemove = availableELAGrades.Where(val => val != 12).ToArray();
                    NavigationCommonMethods.RemoveGrades(navigationAutomationAgent, gradesToRemove);
                    NavigationCommonMethods.ClickELAGradeInUnitLibrary(navigationAutomationAgent, 12);
                    Assert.IsFalse(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove Grade button is enabled for the only one grade available");
                    Assert.IsFalse(NavigationCommonMethods.VerifyMathUnitsInSystemTray(navigationAutomationAgent), "Math Units is found in the System tray");
                    NavigationCommonMethods.ClickSystemTrayButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(17698)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyAddingGradeStartsDownloadingGrade()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC17698: Verify adding grades downloads only grade package"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(navigationAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(navigationAutomationAgent, "ELA", gradeAdded), "Recently added grade is not downloading");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded);
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20099), WorkItem(20143)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyQueuedGradesResumeDownload()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20099 & TC20143: Verify queued grades resume download"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    int gradeAdded1 = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    int gradeAdded2 = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(navigationAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(navigationAutomationAgent, "ELA", gradeAdded2), "Recently added grade is not downloading");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeAdded2);
                    NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent);
                    NavigationCommonMethods.WaitForUnitsToDownload(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(navigationAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(navigationAutomationAgent, "ELA", gradeAdded1), "Grade in queue didn't start downloading");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(20042)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyUnitLibraryUnitsScrollable()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20042: Verify Units are scrollable in unit library"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "GradeToScroll");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    string[] unitLabelsInPage1 = NavigationCommonMethods.GetAllUnitLabels(navigationAutomationAgent);
                    navigationAutomationAgent.Swipe(Direction.Right);
                    string[] unitLabelsInPage2 = NavigationCommonMethods.GetAllUnitLabels(navigationAutomationAgent);
                    Assert.IsFalse(unitLabelsInPage1.Contains<string>(unitLabelsInPage2[0]), "1st unit in page2 is found in page1");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(31800), WorkItem(31799), WorkItem(31797)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CCSSStudentTeacherCommonCoreLessonLessonCarousel()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC31799, TC31797, TC31800: CCSS: Student or teacher can view common core stands for each lesson when tapping on the icon on the lesson carousel"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    navigationAutomationAgent.Sleep(4000);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    navigationAutomationAgent.Sleep(4000);
                    NavigationCommonMethods.ClickEducationalStandardArrowUp(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowDown(navigationAutomationAgent), "Educational Standard Arrow is not Down");
                    Assert.IsTrue(NavigationCommonMethods.VerifyTeacherViewsCommonCoreStands(navigationAutomationAgent), "Teacher doesnt view Common Standards");
                    NavigationCommonMethods.VerifyIfInformationIsMoreOnPanel(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyStartButtonAccessible(navigationAutomationAgent), "Start Button is Accessible");
                    NavigationCommonMethods.ClickEducationalStandardArrowDown(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyStartButtonAccessible(navigationAutomationAgent), "Start Button is not Accessible");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    
        
        [TestMethod()]
        [TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(15970)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AddGradesButtonDisabledWhenNoWifi()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15970: 4b81/ [Add grades] button disabled when no-wifi"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.AreEqual<string>("true", LessonBrowserCommonMethods.VerifyAddGradeButtonActive(navigationAutomationAgent));
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, true);
                    navigationAutomationAgent.LaunchApp();
                    Assert.AreEqual<string>("false", LessonBrowserCommonMethods.VerifyAddGradeButtonActive(navigationAutomationAgent));
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15984)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContinueTogglesActiveOnTappingNonExistingGrade()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15984: Verify that continues toggles active when user taps non-existing grade"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyContinueTogglesActive(navigationAutomationAgent));
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15922)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContinueButtonIsDisabledOnAddGradeIfNoGradeSelected()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15922: Continue button inactive if grade not selected"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.AreEqual<bool>(false, NavigationCommonMethods.VerifyAddGradeContinueButtonDisabled(navigationAutomationAgent));
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15981)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyUserCanCheckAndUncheckGrades()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15981: Verify that user can check and uncheck grades"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(navigationAutomationAgent);
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15982)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AlreadyDownloadedGradesAreGrayedAndCannotBeSelected()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15982: Verify that grades which are downloaded are grayed and user can't select/deselect them"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    LessonBrowserCommonMethods.VerifyAlreadyDownloadedGradeGrayedAndCannotBeSelected(navigationAutomationAgent, taskInfo.Grade.ToString());
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        [WorkItem(15983)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CancelReturnsToPreviousScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC15983: Verify that CANCEL returns to previous screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    LessonBrowserCommonMethods.VerifyCancelReturnsToPreviousScreen(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //optimization
        [TestMethod()]
        [Priority(1)]
        [WorkItem(16042), WorkItem(16045), WorkItem(16049), WorkItem(16111), WorkItem(16074), WorkItem(23154), WorkItem(23156), WorkItem(16113)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNavigationForNonSectionedTeacher()
        {

            using (navigationAutomationAgent = new AutomationAgent("MTC34: Navigation - Non-Sectioned Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    Assert.IsFalse(DashboardCommonMethods.VerifyUserIsOnDashBoard(navigationAutomationAgent), "User Is not On DashBoard");
                    NavigationCommonMethods.ClickOnToolsIcon(navigationAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyResourceLibraryFlyOutMenu(navigationAutomationAgent), "Resource Library FlyOut Menu not present");
                    string heading = NavigationCommonMethods.GetToolsIconHeading(navigationAutomationAgent);
                    Assert.AreEqual(heading, "Resource Library", "Heading is not Resource Library");
                    NavigationCommonMethods.ClickOnSpellingMenuItem(navigationAutomationAgent);
                    NavigationCommonMethods.ClickBackButtonOnResourceLibraryFlyOutMenu(navigationAutomationAgent);
                    string newheading = NavigationCommonMethods.GetToolsIconHeading(navigationAutomationAgent);
                    Assert.AreEqual(newheading, "Resource Library", "Heading is not Resource Library");
                    NavigationCommonMethods.ClickOnToolsIcon(navigationAutomationAgent);
			        Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent));
                    Assert.IsFalse(NavigationCommonMethods.VerifyGradeSelectionScreen(navigationAutomationAgent));
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(navigationAutomationAgent, taskInfo.Grade), "Default grade not in highlited state");
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryButtonPresent(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPage(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPositionForNonSectionedUser(navigationAutomationAgent);
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(1)]
        [WorkItem(16043), WorkItem(16050), WorkItem(16051), WorkItem(16070), WorkItem(16052), WorkItem(29936), WorkItem(29937), WorkItem(16091), WorkItem(17696), WorkItem(34064)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNavigationForSectionedTeacher()
        {

            using (navigationAutomationAgent = new AutomationAgent("MTC35: Navigation - Sectioned Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.VerifyChromeIconSetInELATeacher(navigationAutomationAgent);
                    NavigationCommonMethods.ClickMoreToExploreButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePage(navigationAutomationAgent), "More To Explore Page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPosition(navigationAutomationAgent);
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerButton(navigationAutomationAgent);
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyWorkBrowserPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateTeacherSupport(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyTeacherSupportPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NavigationCommonMethods.VerifyChromeIconSetInMathTeacher(navigationAutomationAgent);
                    NavigationCommonMethods.ClickConceptCornerButtonInNavBar(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPage(navigationAutomationAgent), "Concepot Corner page not present");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    LoginLogoutCommonMethods.VerifyLoginButtonPresent(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLoginScreen(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(1)]
        [WorkItem(16069), WorkItem(19066), WorkItem(30096), WorkItem(30097), WorkItem(31801), WorkItem(16108), WorkItem(21756), WorkItem(31800), WorkItem(31799), WorkItem(31797)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNavigationForSectionedStudent()
        {

            using (navigationAutomationAgent = new AutomationAgent("MTC36: Navigation - Sectioned Student"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    TaskInfo taskInfoMath = login.GetTaskInfo("Math", "Notebook");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(navigationAutomationAgent);
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTraySubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyRemoveGradeButtonPresent(navigationAutomationAgent), "Remove Grade button is present");
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowUp(navigationAutomationAgent), "Educational Standard Arrow is not Up");
                    NavigationCommonMethods.ClickEducationalStandardArrowUp(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardExpands(navigationAutomationAgent), "Educational Standard does not Expands");
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowDown(navigationAutomationAgent), "Educational Standard Arrow is not Down");
                    NavigationCommonMethods.VerifyIfInformationIsMoreOnPanel(navigationAutomationAgent, words[0]);
                    Assert.IsFalse(NavigationCommonMethods.VerifyStartButtonAccessible(navigationAutomationAgent), "Start Button is Accessible");
                    NavigationCommonMethods.ClickEducationalStandardArrowDown(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardCollapses(navigationAutomationAgent), "Educational Standard does not Collapses");
                    Assert.IsTrue(NavigationCommonMethods.VerifyEducationalStandardArrowUp(navigationAutomationAgent), "Educational Standard Arrow is not Up");
                    Assert.IsTrue(NavigationCommonMethods.VerifyStartButtonAccessible(navigationAutomationAgent), "Start Button is not Accessible");
                    Assert.IsTrue(NavigationCommonMethods.VerifyTeacherViewsCommonCoreStands(navigationAutomationAgent, words[0]), "Teacher doesnt view Common Standards");
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(navigationAutomationAgent, taskInfo.TaskNumber);
                    NavigationCommonMethods.VerifyChromeIconSetInELAStudent(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToMath(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(navigationAutomationAgent, taskInfoMath.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(navigationAutomationAgent, taskInfoMath.Lesson);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(navigationAutomationAgent, taskInfoMath.TaskNumber);
                    NavigationCommonMethods.VerifyChromeIconSetInMathStudent(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyWorkBrowserPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyContentManagerPage(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    DashboardCommonMethods.ClickMoreToExploreButtonStudentDashboard(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePageRelevantToLastViewedLesson(navigationAutomationAgent, taskInfo.Grade.ToString(), taskInfo.Unit.ToString()), "More to explore is not found");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    navigationAutomationAgent.Sleep();
                    DashboardCommonMethods.ClickConceptCornerButtonStudentDashboard(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPageRelevantToLastViewedLesson(navigationAutomationAgent, taskInfoMath.Grade.ToString(), taskInfoMath.Unit.ToString()), "Concept cover page not found");
                    NavigationCommonMethods.ClickOnDone(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    LoginLogoutCommonMethods.VerifyLoginButtonPresent(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(20028), WorkItem(20027), WorkItem(31820), WorkItem(20038)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNavigationForTeacherModeELA()
        {
            using (navigationAutomationAgent = new AutomationAgent("MTC37: Navigation - Teacher Mode ELA"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    string UnitNo = NavigationCommonMethods.GetUnitThumbnailText(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual(UnitNo, "Unit" + taskInfo.Unit, "UnitNo and Unit A are not equal");
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(DashboardCommonMethods.VerifySharingNotificationIconInChrome(navigationAutomationAgent), "Sharing Notification IconIn Chrome is not found");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyResourceLibraryIconPresent(navigationAutomationAgent), "ResourceLibraryFlyOutMenu is not found");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teacher ModeIcon is not Present");
                    string unitNo = NavigationCommonMethods.GetUnitLabelFromUnitPreview(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual(unitNo, "Unit" + taskInfo.Unit, "unitno and Unit A are not equal");
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    string lessonTitle = LessonBrowserCommonMethods.GetLessonTitle(navigationAutomationAgent);
                    Assert.AreEqual(lessonTitle, "Unit " + taskInfo.Unit + ": Signs and Symbols", "lesson title and Unit A are not equal");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(navigationAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent), "Teachermode icon not present");
                    string text1 = LessonBrowserCommonMethods.GetLessonBrowserBackButtonText(navigationAutomationAgent);
                    text1 = text1.TrimEnd();
                    Assert.AreEqual(text1, "Unit " + taskInfo.Unit, "Text1 and Unit A are not eaqual");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(20027), WorkItem(20026), WorkItem(20024), WorkItem(20021)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNavigationForTeacherModeMath()
        {
            using (navigationAutomationAgent = new AutomationAgent("MTC38: Navigation - Teacher Mode Math"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeOpened(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathUnitPreview(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(navigationAutomationAgent, 1);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickMathLessonContinueButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeOpened(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(navigationAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(navigationAutomationAgent);
                    int pageno = LessonBrowserCommonMethods.GetTaskPageNumberInLesson(navigationAutomationAgent);
                    while (pageno < 3)
                    {
                        string taskno = LessonBrowserCommonMethods.GetTaskNumberInTeacherGuide(navigationAutomationAgent);
                        Assert.AreEqual(true, taskno.Equals("Task " + pageno));
                        LessonBrowserCommonMethods.ClickOnNextButtonInTask(navigationAutomationAgent);
                        pageno = LessonBrowserCommonMethods.GetTaskPageNumberInLesson(navigationAutomationAgent);
                    }
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(navigationAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnBackButton(navigationAutomationAgent);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeOpen(navigationAutomationAgent));
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyMathPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(22867), WorkItem(22868), WorkItem(16088), WorkItem(15873), WorkItem(15985), WorkItem(15984), WorkItem(15922), WorkItem(15981), WorkItem(15982), WorkItem(15983), WorkItem(15971), WorkItem(15967), WorkItem(15969), WorkItem(15972), WorkItem(15974), WorkItem(16109), WorkItem(20098), WorkItem(19384), WorkItem(16087), WorkItem(16090), WorkItem(15968), WorkItem(15979), WorkItem(16105), WorkItem(16110), WorkItem(17698), WorkItem(20099), WorkItem(20143), WorkItem(15970)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNavigationAddGradeFunctionalities()
        {
            using (navigationAutomationAgent = new AutomationAgent("MTC39: Navigation - Verify all add grade test cases"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    Assert.IsFalse(NavigationCommonMethods.VerifyAddGradeContinueButtonDisabled(navigationAutomationAgent), "Add Grade Continue button is active");
                    Assert.IsTrue(NavigationCommonMethods.VerifyRecommendationMessageAddGrade(navigationAutomationAgent), "Recommendation messag to add only 2 grade not found");
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyContinueTogglesActive(navigationAutomationAgent), "Continue doesnt get active");
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    LessonBrowserCommonMethods.VerifyAlreadyDownloadedGradeGrayedAndCannotBeSelected(navigationAutomationAgent, taskInfo.Grade.ToString());
                    Assert.IsTrue(NavigationCommonMethods.VerifyAddGradePopUp(navigationAutomationAgent), "Add grade popup not present");
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(navigationAutomationAgent);
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    LessonBrowserCommonMethods.VerifyCancelReturnsToPreviousScreen(navigationAutomationAgent, taskInfo.Grade);
                    int firstGradeNumber = 12;
                    NavigationCommonMethods.ClickELAGradeInUnitLibrary(navigationAutomationAgent, 12);
                    int gradeNumber = NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyNewGradeOnRibbon(navigationAutomationAgent, gradeNumber);
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(navigationAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(navigationAutomationAgent, "ELA", gradeNumber), "Recently added grade is not downloading");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, firstGradeNumber);
                    NavigationCommonMethods.VerifyNewGradeOnRibbon(navigationAutomationAgent, firstGradeNumber);
                    NavigationCommonMethods.VerifyWaitingToDownload(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeNumber);
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent), "Prepairing units not present");
                    Assert.IsTrue(bool.Parse(NavigationCommonMethods.VerifyAddGradeButtonActive(navigationAutomationAgent)), "Remove grade button not active");
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyActivitySpinnerExists(navigationAutomationAgent), "Activity spinner doesn't exist");
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, true);
                    navigationAutomationAgent.LaunchApp();
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeNumber);
                    Assert.IsFalse(NavigationCommonMethods.VerifyPrepairingUnits(navigationAutomationAgent), "Prepairing units present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(navigationAutomationAgent), "No Wifi Icon not present");
                    Assert.IsFalse(bool.Parse(NavigationCommonMethods.VerifyAddGradeButtonActive(navigationAutomationAgent)), "Remove grade button is active");
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, false);
                    navigationAutomationAgent.LaunchApp();
                    while (!NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                    {
                        navigationAutomationAgent.Sleep();
                    }
                    Assert.IsTrue(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove grade button not active");
                    NavigationCommonMethods.VerifyUnitThumbnails(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.NavigateMyDashboard(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyImagesInDashboard(navigationAutomationAgent, taskInfo.Grade.ToString(), "ELA"), "Grade text is not the same");
                    NavigationCommonMethods.NavigateContentManager(navigationAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(navigationAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(navigationAutomationAgent, "ELA", firstGradeNumber), "Grade in queue didn't start downloading");
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, gradeNumber);
                    NavigationCommonMethods.ClickRemoveGradeButton(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySpecificGradePresent(navigationAutomationAgent, gradeNumber), "Specified grade is present");

                    int[] availableELAGrades = NavigationCommonMethods.GetAvailableGradesInELA(navigationAutomationAgent);
                    int[] gradesToRemove = availableELAGrades.Where(val => val != 12).ToArray();
                    NavigationCommonMethods.RemoveGrades(navigationAutomationAgent, gradesToRemove);
                    NavigationCommonMethods.ClickELAGradeInUnitLibrary(navigationAutomationAgent, 12);
                    Assert.IsFalse(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove Grade button is enabled for the only one grade available");
                    Assert.IsFalse(NavigationCommonMethods.VerifyMathUnitsInSystemTray(navigationAutomationAgent), "Math Units is found in the System tray");

                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.AddAllGrades(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyAddGradeButtonPresent(navigationAutomationAgent), "Add grade button is still present");
                    NavigationCommonMethods.Logout(navigationAutomationAgent, true);
                    NavigationCommonMethods.VerifyLoginScreen(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(22144), WorkItem(17678), WorkItem(30112), WorkItem(15921)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyInitialSetupCases()
        {
            using (navigationAutomationAgent = new AutomationAgent("MTC40: Navigation - Initial Setup Cases"))
            {
                try
                {
                    navigationAutomationAgent.SendText("{HOME}");
                    Assert.IsTrue(NavigationCommonMethods.VerifyNewAppIconOnHomeScreen(navigationAutomationAgent), "New application icon doesn't exist");
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    navigationAutomationAgent.LaunchApp();
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(navigationAutomationAgent, login);
                    Assert.IsTrue(NavigationCommonMethods.VerifyGradeSelectionScreen(navigationAutomationAgent));
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoGradeSelectedOnFirstLogin(navigationAutomationAgent));
                    NavigationCommonMethods.VerifySelectOnlyOneGrade(navigationAutomationAgent);
                    NavigationCommonMethods.CloseAddGradePopUp(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLoginScreen(navigationAutomationAgent);
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(navigationAutomationAgent, login);
                    NavigationCommonMethods.ClickAddGrade(navigationAutomationAgent, taskInfo.Grade);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(16044), WorkItem(19398), WorkItem(19418), WorkItem(23151), WorkItem(23150), WorkItem(23149), WorkItem(23148)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyImportantUnitLibraryFunctions()
        {

            using (navigationAutomationAgent = new AutomationAgent("MTC41: Navigation - Toolbar, Unit library"))
            {
                try
                {
                    NavigationCommonMethods.LogoutIfAlreadyLogin(navigationAutomationAgent);
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    DashboardCommonMethods.VerifyUserIsOnDashBoard(navigationAutomationAgent);
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLogoutButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitLibraryPosition(navigationAutomationAgent);
                    NavigationCommonMethods.ClickUnitLibraryButton(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryExpanded(navigationAutomationAgent));
                    string ELAUnitColor = NavigationCommonMethods.VerifyELAUnitHighlight(navigationAutomationAgent);
                    Assert.AreEqual(ELAUnitColor, "0x649BFF", "ELA Unit color not the same");
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    string textColor = NavigationCommonMethods.GetTextColorOfGrades(navigationAutomationAgent, taskInfo.Grade);
                    Assert.AreEqual(textColor, "0xFFFFFF", "Color of grade is not the same");
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitsNumberInOrder(navigationAutomationAgent, taskInfo.Unit), "Unit number is not present");
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    string MathUnitColor = NavigationCommonMethods.VerifyMathUnitHighlight(navigationAutomationAgent);
                    Assert.AreEqual(MathUnitColor, "0x7EC437", "Math Unit color not the same");
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySnapshotToolButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(16047), WorkItem(19380), WorkItem(23147), WorkItem(16212)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyToolbarSnapshotNavigation()
        {

            using (navigationAutomationAgent = new AutomationAgent("MTC42: Navigation - Toolbar, Snapshot"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    Assert.IsFalse(DashboardCommonMethods.VerifyUserIsOnDashBoard(navigationAutomationAgent), "User Is not On DashBoard");
                    NavigationCommonMethods.OpenSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyLogoutButton(navigationAutomationAgent);
                    NavigationCommonMethods.CloseSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.VerifySnapshotToolButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(navigationAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(navigationAutomationAgent));
                    int snapshotgridwidth = NotebookCommonMethods.GetWidthofSnapshotGrid(navigationAutomationAgent);
                    NotebookCommonMethods.ResizeSnapshotGrid(navigationAutomationAgent);
                    int snapshotgridwidthnew = NotebookCommonMethods.GetWidthofSnapshotGrid(navigationAutomationAgent);
                    Assert.AreNotEqual(snapshotgridwidth, snapshotgridwidthnew, "Snapshot not resized");
                    string gridpos = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    NotebookCommonMethods.SwipeSnapshotGrid(navigationAutomationAgent);
                    string gridposnew = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    Assert.AreNotEqual(gridpos, gridposnew, "snapshot grid not repositioned");
                    NotebookCommonMethods.SwipeSnapshotGrid(navigationAutomationAgent, 1000);
                    string gridposnewSwipeBeyondScreen = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    NotebookCommonMethods.SwipeSnapshotGrid(navigationAutomationAgent);
                    string gridposnewSwipeBeyondScreenAgain = NotebookCommonMethods.GetSnapshotGridPosition(navigationAutomationAgent);
                    Assert.AreEqual(gridposnewSwipeBeyondScreenAgain, gridposnewSwipeBeyondScreen, "snapshot grid repositioned above screen size");
                    NotebookCommonMethods.ClickCancelSnapShot(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(20440), WorkItem(15864), WorkItem(15865), WorkItem(15874), WorkItem(16092), WorkItem(20039), WorkItem(16113), WorkItem(16112), WorkItem(20042)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyUnitRelatedFunctions()
        {

            using (navigationAutomationAgent = new AutomationAgent("MTC43: Navigation - Unit preview "))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(navigationAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, taskInfo.Grade);
                    Assert.IsFalse(NavigationCommonMethods.VerifyRemoveGradeButtonActive(navigationAutomationAgent), "Remove Grade button is Active for newly added grade");
                    Assert.IsFalse(NavigationCommonMethods.VerifyBackButtonPresent(navigationAutomationAgent));
                    string[] unitLabelsInPage1 = NavigationCommonMethods.GetAllUnitLabels(navigationAutomationAgent);
                    navigationAutomationAgent.SwipeRight();
                    string[] unitLabelsInPage2 = NavigationCommonMethods.GetAllUnitLabels(navigationAutomationAgent);
                    Assert.IsFalse(unitLabelsInPage1.Contains<string>(unitLabelsInPage2[0]), "1st unit in page2 is found in page1");
                    navigationAutomationAgent.SwipeLeft();
                    string title = NavigationCommonMethods.GetUnitTitleFromUnitThumbnail(navigationAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELAUnit(navigationAutomationAgent, taskInfo.Unit);
                    string newTitle = NavigationCommonMethods.GetUnitTitleFromUnitPreview(navigationAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual(title, newTitle, "Titles are not similar");
                    NavigationCommonMethods.VerifyELAUnitPreviewDetails(navigationAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(navigationAutomationAgent, Int32.Parse(taskInfo.Unit)), "Unit Preview card not present");
                    NavigationCommonMethods.VerifyUnitsAreInOrder(navigationAutomationAgent);
                    NavigationCommonMethods.SwipeUnit(navigationAutomationAgent, Direction.Right);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEdgeOfNextUnitCardDisplayed(navigationAutomationAgent), "Edge of next unit card not present");
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(navigationAutomationAgent, words[0]);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(navigationAutomationAgent, words[0]), "Unit preview card not present");
                    string GradeText = NavigationCommonMethods.VerifyAppChromeTitleOnUnitPreviewScreen(navigationAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(GradeText.Contains("Grade " + taskInfo.Grade + " ELA"));
                    NavigationCommonMethods.ClickLessonBrowserBackButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyELAPage(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
