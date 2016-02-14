using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class CAAdoptionTests
    {
        public AutomationAgent CAAdoptionAutomationAgent;
        public CAAdoptionTests()
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

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(26310)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AccessingVocabularyListSoUserEnableToSelectVocabularyForFurtherStudy()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC26310: CAAdoptionAutomationAgent: Accessing Vocabulary List so user enable to select vocabulary for further study"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyELAUnitLibraryPage(CAAdoptionAutomationAgent));
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(CAAdoptionAutomationAgent), "Resource Library icon not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryFlyOutMenu(CAAdoptionAutomationAgent), "Resource Library Fly out menu not present");
                    string title = CAAdoptionCommonMethods.GetResourceLibraryIconHeading(CAAdoptionAutomationAgent);
                    Assert.AreEqual(title, "Resource Library", "Title of the Fly out menu is not Resource Library");
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyVolabularyPage(CAAdoptionAutomationAgent), "Vocabulary Page not Present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyELAUnitLibraryPage(CAAdoptionAutomationAgent), "ELA Unit sLibrary page not present");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(26311)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AccessingVocabularyListHeaderChromeSoUserEnableToSelectVocabularyAndSendItNotebook()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC26311: Accessing Vocabulary List Header Chrome so user enable to select vocabulary and send it Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryFlyOutMenu(CAAdoptionAutomationAgent), "Resource Library Fly out menu not present");
                    string title = CAAdoptionCommonMethods.GetResourceLibraryIconHeading(CAAdoptionAutomationAgent);
                    Assert.AreEqual(title, "Resource Library", "Title of the Fly out menu is not Resource Library");
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyVolabularyPage(CAAdoptionAutomationAgent), "Vocabulary Page not Present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyDoneButton(CAAdoptionAutomationAgent), "Done Button Not present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyTitlePopulated(CAAdoptionAutomationAgent), "Title Populated not correct");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(CAAdoptionAutomationAgent), "Resource Library icon not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibrarySubmenu(CAAdoptionAutomationAgent), "Resource Library submenu not present");
                    CAAdoptionCommonMethods.ClicksOnResourceLibrarySubmenu(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySnapshotToolMenu(CAAdoptionAutomationAgent), "Snapshot MEnu not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySendToNotebookIcon(CAAdoptionAutomationAgent), "Send to notebook icon not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(27034)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AccessingVocabularyListSoUserEnableToSelectVocabularyForFurtherStudyCopy()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27034: (Copy of) Accessing Vocabulary List so user enable to select vocabulary for further study"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryFlyOutMenu(CAAdoptionAutomationAgent), "Resource Library Fly out menu not present");
                    string title = CAAdoptionCommonMethods.GetResourceLibraryIconHeading(CAAdoptionAutomationAgent);
                    Assert.AreEqual(title, "Resource Library", "Title of the Fly out menu is not Resource Library");
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyVolabularyPage(CAAdoptionAutomationAgent), "Vocabulary page still present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyELAUnitLibraryPage(CAAdoptionAutomationAgent), "ELA Unit Library page is not present");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(43978)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ResourceLibraryDropdownMenzuLanguageELAUnitPage()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC43978: 2-8_IOS_Resource Library_Dropdown menzu_Language_ELA Unit's page"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyLanguageSubMenuOpened(CAAdoptionAutomationAgent), "Language submenu is not opened");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyLanguageSubMenuOptions(CAAdoptionAutomationAgent), "Language submenu options are not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(44280)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WorkBrowserDefaultFilterShouldBeELAMath()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC44280: 2-8_iOS_Work browser_Default filter should be ELA+Math"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyDefaultFilterInWorkBrowser(CAAdoptionAutomationAgent), "Default Filter is not present in work browser");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(44276)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WorkBrowserHeaderOfTheWorkTileInWorkBrowserShouldAppearBlueInColor()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC44276: 2-8_iOS_Work browser_Header of the Work tile in Work browser should appear blue in color"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnMyWorkDropDown(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.DeSelectMathFilterInMyWork(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 0, 132, 1);
                    String ELAHeadercolor = NavigationCommonMethods.VerifyELAHeaderTitleColor(CAAdoptionAutomationAgent, login);
                    Assert.AreEqual(ELAHeadercolor, "0x0031C3");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnMyWorkDropDown(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.SelectPersonalNotesFilterInMyWork(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 0, 132, 1);
                    String PersonalNotesHeadercolor = NavigationCommonMethods.VerifyPersonalNotesHeaderTitleColor(CAAdoptionAutomationAgent, login);
                    Assert.AreEqual(PersonalNotesHeadercolor, "0xEE8700");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod]
        [TestCategory("CAAdoptionTests")]
        [Priority(2)]
        [WorkItem(43971)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ResourceLibraryIdentifySubMenusOfTheDropdownMenuItemELAUnitPage()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC43971: 2-8_IOS_Resource Library_identify sub menus of the Dropdown menu item_ELA Unit's page"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyRightArrowForLanguageMenu(CAAdoptionAutomationAgent), "Right arrow is not present for language menu");
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyLanguageSubMenuOptions(CAAdoptionAutomationAgent), "Language submenu options are not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(44514)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NotebookMultimediaSnapshotIsCancelled()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC44514: 2-8_IOS _ Notebook_ Multimedia_snapshot is cancelled"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(CAAdoptionAutomationAgent), "SnapShot Grid is not present");
                    NotebookCommonMethods.ClickCaptureSnapShot(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnImageIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSnapShotIcon(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(CAAdoptionAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickOnXIcon(CAAdoptionAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(CAAdoptionAutomationAgent), "Photo exists");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(43948)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UnitDisplayInGrade2()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC43948: 2-8_iOS_UnitDisplay_in Grade2"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(CAAdoptionAutomationAgent);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "SingleEpisodeUnit");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(CAAdoptionAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(CAAdoptionAutomationAgent, taskInfo.Unit);
                    int width = LessonBrowserCommonMethods.GetWidthOfPageIndicator(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySingleEpisodesPresence(CAAdoptionAutomationAgent), "Single Episodes are not present");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31609)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLSentenceCombinersInteractivesTappingDoneMovesToPreviousLocation()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31609: (03.) CA: RL >> Sentence Combiners interactives - tapping [Done] moves user to their previous location in app"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Page is not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickSentenceCombinersInLanguageStudies(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBugleHornInSentenceCombiners(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Page is not present");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27175)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingNotebookSpellingNotebookTitlePopulatedFromLessonTaskSpellingWeekDay()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27175: CA - Spelling - Notebook - Spelling Notebook title is populated from Lesson Task: Spelling, i.e. [Week #], [Day #]"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.CopyNotebookTitle(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1450, 484, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1450, 484, 1);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1480, 494, 1);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1480, 514, 1);
                    CAAdoptionCommonMethods.PasteTitleInNotebook(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    string NotebookTitle = NotebookCommonMethods.GetTextInTextZone(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookTitle.Contains("Week 1, Day 1"));
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27064)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingContextAwarenessTask1OpenedByDefaultIfSpellingLessonOpenedForFirstTime()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27064: CA - Spelling - Context awareness - Task 1 is opened by default if Spelling Lesson is opened for the first time"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek2MenuOfSpelling(CAAdoptionAutomationAgent);
                    int taskpagenumber = NavigationCommonMethods.GetTaskPageNumberInLesson(CAAdoptionAutomationAgent);
                    Assert.AreEqual<int>(1, taskpagenumber, "Task Page Number are not equal");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27165)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingChromeCenterTitleIsSpelling()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27165:  CA - Spelling - Chrome - Center title is Spelling"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySpellingHeaderChromeTitle(CAAdoptionAutomationAgent), "Spelling Header is not at the centre");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27166)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingChromeRightIconSetForStudentIsNotebookAndResourceLibraryMenu()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27166:  CA - Spelling - Chrome - Right icon set for Student is Notebook and Resource Library Menu"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyNotebookIcon(CAAdoptionAutomationAgent), "Notebook Icon is not present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(CAAdoptionAutomationAgent), "Resource Library Icon is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27167)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingChromeRightIconSetForTeacherIsNotebookResourceLibraryMenuTeacherGuide()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27167: CA - Spelling - Chrome - Right icon set for Teacher is Notebook, Resource Library Menu and Teacher Guide"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyNotebookIcon(CAAdoptionAutomationAgent), "Notebook Icon is not present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(CAAdoptionAutomationAgent), "Resource Library Icon is not present");
                    Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIcon(CAAdoptionAutomationAgent), "Teacher Mode Icon is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(24407)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void BlobBustersOpensAndClosesProperly()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC24407: dynamic chrome menu - Blob Busters opens and closes properly"))
            {
                try
                {
                    int i;
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    for (i = 1; i <= 3; i++)
                    {
                        CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                        CAAdoptionAutomationAgent.Sleep(2000);
                        CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                        CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                        Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                        CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(24408)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DynamicChromeMenuYouCanOpenBlobBustersFromEachApplicationeview()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC24408: (03)dynamic chrome menu - you can open Blob Busters from each application (Grade, Unit Preview, Lesson Browser, Lesson Preview, Lesson)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickELAUnit(CAAdoptionAutomationAgent, taskInfo.Unit);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(CAAdoptionAutomationAgent, taskInfo.Unit);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(CAAdoptionAutomationAgent, taskInfo.Lesson);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(CAAdoptionAutomationAgent, taskInfo.Lesson);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29938)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SpellingNotebookVerifyHeaderLayoutInSpellingLessonView()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29938: Spelling Notebook - verify header layout in Spelling Lesson view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("0x0031C3", CAAdoptionCommonMethods.VerifySpellingNotebookHeaderColor(CAAdoptionAutomationAgent), "Title bar of notebook is not same");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyFolderIcon(CAAdoptionAutomationAgent), "Folder Icon is enabled");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyShareIcon(CAAdoptionAutomationAgent), "Share Icon is enabled");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27178)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingSavingInteractivesVerifySendToNotebookIconAlert()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27178: CA - Spelling - Saving Interactives - verify [send to Notebook] icon alert"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CAInteractive");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, taskInfo.TaskNumber);
                    NotebookCommonMethods.OpenInteractive(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySendToNotebookIconPresent(CAAdoptionAutomationAgent), "Send To Notebook Icon is not Present");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyAlertOnSendToNotebookIconClick(CAAdoptionAutomationAgent), "Alert on send to notebook click is not present");
                    CAAdoptionCommonMethods.ClickAlertCancelButton(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyAlertMessagePresent(CAAdoptionAutomationAgent), "Alert message is present");
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(CAAdoptionAutomationAgent), "Interactive Page is not open");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyInteractivePageOpen(CAAdoptionAutomationAgent), "Interactive Page is open");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(CAAdoptionAutomationAgent), "Notebook is not open");
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveAtCenterOfNotebook(CAAdoptionAutomationAgent), "Interactive is not at the centre of the notebook");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27066)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingContextAwarenessPreviouslyViewedTaskOpenedByDefaultSpellingLessonReopened()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27066: CA - Spelling - Context awareness - previously viewed task is opened by default if Spelling Lesson reopened"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnNextButtonInTask(CAAdoptionAutomationAgent);
                    int taskpagenumber = NavigationCommonMethods.GetTaskPageNumberInLesson(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    int taskpagenumber2 = NavigationCommonMethods.GetTaskPageNumberInLesson(CAAdoptionAutomationAgent);
                    Assert.AreEqual<int>(taskpagenumber, taskpagenumber2, "Task Page numbers are not equal");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27171)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingNotebookChromeNotebookIconIsHighlightedBlueOpeningSpellingNotebook()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27171: CA - Spelling - Notebook - Chrome Notebook icon is highlighted blue on opening Spelling Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookIconSelectedState(CAAdoptionAutomationAgent), "Notebook Icon is not in selected state");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(CAAdoptionAutomationAgent), "Notebook is not opened");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31606)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingLessonsStudentsDontSeeTeacherGuideIconInSpellingLessons()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31606: CA Spelling Lessons: students don't see the teacher guide icon in spelling lessons"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(CAAdoptionAutomationAgent), "Teacher Mode Icon is present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27169)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingNotebookHeaderColorBlueAndWrenchToolbarIconInactiveLikeInELANotebooks()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27169: CA - Spelling - Notebook - header color is blue and wrench toolbar icon is inactive like in ELA Notebooks"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookHeaderColorBlue(CAAdoptionAutomationAgent), "Notebook Header Colour is not blue");
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyWrenchIconActive(CAAdoptionAutomationAgent), "Wrench Icon is active");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27164)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingChromeLeftDoneButtonClosesSpellingLessonBringsBackPreviousLocationOnApp()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27164: CA - Spelling - Chrome - Left [Done] button closes Spelling Lesson and brings back to previous location on the app"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDoneButtonAtUpperLeftCorner(CAAdoptionAutomationAgent), "Done button is not present at upper left corner");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifySpellingPageOpen(CAAdoptionAutomationAgent), "Spelling Page is opened");
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31222)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingLessonsWHENTappedDoneThenSpellingLessonDismissesAndUserReturnsToPreviousLocation()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31222: CA Spelling Lessons: WHEN tapped Done, THEN the Spelling Lesson dismisses and the user returns to their previous location"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySpellingPageOpen(CAAdoptionAutomationAgent), "Spelling Page is not opened");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifySpellingPageOpen(CAAdoptionAutomationAgent), "Spelling Page is opened");
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31605)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingLessonsOnlyTaskGuideActiveOnTeacherGuideFlyOut()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31605: CA Spelling Lessons: only Task Guide is active on Teacher Guide fly-out"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(CAAdoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(CAAdoptionAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyUnitOverviewExpands(CAAdoptionAutomationAgent), "Unit Overview expands");
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(CAAdoptionAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyLessonOverviewExpands(CAAdoptionAutomationAgent), "Lesson Overview expands");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(CAAdoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(CAAdoptionAutomationAgent), "Task Guide doesnt expands");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27173)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingNotebookClosingNotebookSavesContent()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27173: CA - Spelling - Notebook - closing Notebook saves the content"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextIconActive(CAAdoptionAutomationAgent), "Text Icon is not active");
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1460, 792, 1);
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyTextBorderPresent(CAAdoptionAutomationAgent), "Text border is not present");
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1490, 822, 1);
                    NotebookCommonMethods.SendText(CAAdoptionAutomationAgent, "TEST");
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 1580, 600, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone(CAAdoptionAutomationAgent);
                    Assert.AreEqual<bool>(true, WordsInTextBox.Contains("TEST"), "Word entered is not saved into Notebook");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27179)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingSavingInteractivesVerifyTitleThumbnailTimeStamp()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27179: CA - Spelling - Saving Interactives - verify title, thumbnail and time stamp"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "CAInteractive"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, 2);
                    NotebookCommonMethods.OpenInteractive(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    string DtCurrent = DateTime.Now.ToString("h:mmtt").ToLower().Replace("am", "").Replace("pm", "");
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveAtCenterOfNotebook(CAAdoptionAutomationAgent), "Interactive Thumbnail is not at the centre of the notebook");
                    string TextDesmos = NotebookCommonMethods.GetDesmosModifiedTime(CAAdoptionAutomationAgent);
                    Assert.AreEqual(true, TextDesmos.Contains("Interactive"), "Modified Interactive Thumbnail is not present");
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveThumbnailPresent(CAAdoptionAutomationAgent), "Interactive Thumbnail is not present");
                    Assert.AreEqual(true, TextDesmos.Contains(DtCurrent), "Interactive Thumbnail is not of current date");
                    NotebookCommonMethods.ClickEraseIconInNotebook(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29929)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerNotebookPickerCloseModalTappingOutsideModal()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29929: Graphic Organizer - Notebook Picker - close modal by tapping outside of modal"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal doesnt exists");
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 948, 66, 1);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal exists");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29928)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerNotebookPickerCloseModalUsingXIcon()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29928: Graphic Organizer - Notebook Picker - close modal using [X] icon"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal doesnt exists");
                    CAAdoptionCommonMethods.ClickXIconInWorkBrowserModal(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal exists");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29927)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerNotebookPickerHeadingTitleIsSelectANotebook()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29927: Graphic Organizer - Notebook Picker - heading title is Select a Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal doesnt Exists");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyWorkBrowserHeaderTitle(CAAdoptionAutomationAgent), "Work Browser Header Title is not present");
                    CAAdoptionCommonMethods.ClickXIconInWorkBrowserModal(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal Exists");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29926)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerSendToNotebookIconTriggersCancelContinueAlert()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29926: Graphic Organizer - [send to Notebook] icon triggers cancel/continue alert"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickAlertCancelButton(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyAlertMessagePresent(CAAdoptionAutomationAgent), "Alert message is present");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal doesnt Exists");
                    CAAdoptionCommonMethods.ClickXIconInWorkBrowserModal(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29944)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VocabularyNotebookVerifyHeaderLayoutInVocabularyListView()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29944:Vocabulary Notebook - verify header layout in Vocabulary list view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, taskInfo);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.SelectAndCopyVocabularyWord(CAAdoptionAutomationAgent, words[0]);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("0x0031C3", CAAdoptionCommonMethods.VerifyVocabularyNotebookHeaderColor(CAAdoptionAutomationAgent), "Title bar of notebook is not same");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyFolderIcon(CAAdoptionAutomationAgent), "Folder Icon is enabled");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyShareIcon(CAAdoptionAutomationAgent), "Share Icon is enabled");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29905)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerSendGOOpenedFromRLMNotebookOpensNotebookPickerModal()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29905:Graphic Organizer - send GO opened from RLM to Notebook opens Notebook picker modal"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "Notebook Picker Work Browser Modal doesnt Exists");
                    CAAdoptionCommonMethods.ClickXIconInWorkBrowserModal(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31658)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLGlossaryInteractiveProperChromeTitleDoneButtonAppearOnChrome()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31658:CA: RL >> Glossary interactive - proper chrome title and [Done] button appear on chrome"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGlossaryInResourceLibarary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyChromeHeaderForGlossary(CAAdoptionAutomationAgent), "Chrome Header Glossary is not present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyDoneButton(CAAdoptionAutomationAgent), "Done button is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31659)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLGlossaryInteractiveTeacherModeIsNotAvailableInGlossary()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31659:CA: RL >> Glossary interactive - teacher mode is not available in the Glossary"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGlossaryInResourceLibarary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(3000);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(CAAdoptionAutomationAgent), "Teacher Mode Icon is present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31656)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLReadingLogInteractiveTeacherModeIsNotAvailableInReadingLog()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31656: CA: RL >> Reading Log interactive - teacher mode is not available in the Reading Log"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickReadingLogInResourceLibarary(CAAdoptionAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(CAAdoptionAutomationAgent), "Teacher Mode Icon is present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31232)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLGraphicOrganizersFromTheResourceLibraryMenuAccessibleForTeacherStudent()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31232:CA: RL Graphic Organizers from the Resource Library menu is accessible for a Teacher or Student."))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyStoryMapHeaderInGraphicOrganizers(CAAdoptionAutomationAgent), "Story Map Header is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31623)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLReadingLogInteractiveHeaderShouldSayReadingLog()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31623:CA: RL >> Reading Log interactive - the header should say Reading Log"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickReadingLogInResourceLibarary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyReadingLogHeaderInChrome(CAAdoptionAutomationAgent), "Reading Log Header is not present in Chrome");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31620)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLReadingLogInteractiveTappingDoneMovesUserToTheirPreviousLocationInApp()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31620:CA: RL >> Reading Log interactive - tapping [Done] moves user to their previous location in app"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Page is not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickReadingLogInResourceLibarary(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Page is not present");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27170)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingNotebookLessonContentRearrangesOnOpeningSpellingNotebook()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27170:CA - Spelling - Notebook - lesson content rearranges on opening Spelling Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyLessonContentOnLeftOfScreen(CAAdoptionAutomationAgent));
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookIsOnRightOfScreen(CAAdoptionAutomationAgent), "Notebook is not on right side of screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31234)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLGraphicOrganizersWhenTappedGraphicOrganizerItemOpensFullScreenOverlay()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31234: CA: RL Graphic Organizers: When tapped, the Graphic Organizer item opens in Full screen overlay."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Graphic Organizer is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31221)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingLessonsOnTapOfWeekItemButtonSpellingLessonContentOverlayOpensFullScreen()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31221: CA Spelling Lessons: On tap of a Week menu item button, the Spelling Lesson Content overlay opens in full screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Spelling Lesson is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31619)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLReadingLogInteractiveOpensProperlyFullscreenJustInteractives()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31619:CA: RL >> Reading Log interactive opens properly in fullscreen, just like interactives do"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyReadingLogIsPresentInResourceLibraryMenu(CAAdoptionAutomationAgent), "Reading Log is not present in Resource Library Menu");
                    CAAdoptionCommonMethods.ClickReadingLogInResourceLibarary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Reading Log is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31657)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLGlossaryInteractiveOpensProperlyFullscreenJustLikeInteractives()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31657:CA: RL >>Glossary interactive opens properly in fullscreen, just like interactives do"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyGlossaryIsPresentInResourceLibraryMenu(CAAdoptionAutomationAgent), "Glossary is not present in Resource Library Menu");
                    CAAdoptionCommonMethods.ClickGlossaryInResourceLibarary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Glossary is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29923)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerOpenGOFromResourceLibraryMenu()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29923:Graphic Organizer - open GO from Resource Library Menu"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickTChartInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Graphic Organizer is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31223)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VideosInteractivesAvailableSpellingLessonContentWHENTappedThenVideosInteractiveOpensFullScreenOverlay()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31223:CA Spelling Lessons: Videos and Interactives are available in the Spelling Lesson content, WHEN tapped THEN videos and interactive opens within the full screen overlay"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CAInteractive");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, taskInfo.TaskNumber);
                    NotebookCommonMethods.OpenInteractive(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySpellingInteractiveFullScreen(CAAdoptionAutomationAgent), "Spelling Interactive is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31607)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLSentenceCombinersInteractivesOpenProperlyFullscreenJustLikeInteractivesDo()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31607: (01.) CA: RL >> Sentence Combiners interactives open properly in fullscreen, just like interactives do"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySentenceCombinersIsPresentInResourceLibrary(CAAdoptionAutomationAgent), "Sentence Combiners is not present in Resource Library");
                    CAAdoptionCommonMethods.ClickSentenceCombinersInLanguageStudies(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBugleHornInSentenceCombiners(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Sentence Combiners is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31608)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLSentenceCombinersInteractivesOnlyProperChromeTitleDoneButtonAppearOnChromeBar()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31608: (02.04.06.) CA: RL >> Sentence Combiners interactives - ONLY proper chrome title and [Done] button appear on chrome bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickSentenceCombinersInLanguageStudies(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBugleHornInSentenceCombiners(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBugleHornChromeHeader(CAAdoptionAutomationAgent), "Bugle Horn Chrome Header is not Bugle Horn");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyDoneButton(CAAdoptionAutomationAgent), "Done button is not present");
                    Assert.AreEqual<string>("False", NotebookCommonMethods.VerifyNotebookIconPresent(CAAdoptionAutomationAgent), "Notebook Icon is present");
                    Assert.IsFalse(NotebookCommonMethods.VerifySendToNotebookIconPresent(CAAdoptionAutomationAgent), "Send To Notebook Icon is present");
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(CAAdoptionAutomationAgent), "Resource Library Icon is present");
                    Assert.IsFalse(DashboardCommonMethods.VerifyMoreToExploreButton(CAAdoptionAutomationAgent), "More To Explore is present");
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(CAAdoptionAutomationAgent), "Teacher Mode Icon is present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31220)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingLessonsWhenUserTapsSpellingFromRLMenuOpensLessonContentSpecificDropdown()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31220:CA Spelling Lessons: When user taps the Spelling from the RL menu, opens lesson content specific dropdown."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySpellingLessonLists(CAAdoptionAutomationAgent), "Spelling Lesson Lists not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31233)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLGraphicOrganizerInteractivesAccessibleVisibleWithinApp()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31233:CA: RL Graphic Organizer interactives are accessible and visible within the app"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyStoryMapVisibleAndAccessibleInGraphicOrganizers(CAAdoptionAutomationAgent), "Story Map is not Visible and accessible in Graphic Organizers");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(33496)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CAToVerifyBlueBoundingBoxInEditableELANotebookSpellingLessonNotebook()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC33496: CA-To verify blue bounding box in editable ELA notebook in spelling lesson notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickNotebookTitleToEdit(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlueBoundingBoxOfNotebook(CAAdoptionAutomationAgent), "Blue bounding box of notebook is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(31793)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLInteractivesGraphicOrganizersTheTeacherGuideClipboardIconAreNotAvailable()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC31793: CA - RL Interactives - Graphic Organizers: The Teacher Guide & the clipboard icon are not available."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyFullScreenOverlay(CAAdoptionAutomationAgent), "Graphic Organizer is not opened in full screen");
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(CAAdoptionAutomationAgent), "Teacher Mode Icon is present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(CAAdoptionAutomationAgent), "ELA Units Page is not opened");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27180)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CASpellingSavingInteractivesMoveInteractiveRegion()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27180: CA - Spelling - Saving Interactives - move interactive region"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CAInteractive");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, taskInfo);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek3MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, taskInfo.TaskNumber);
                    NotebookCommonMethods.OpenInteractive(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    string ImagePosBefore = CAAdoptionCommonMethods.GetImageCoordinate(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.MoveIntearctiveInNoteBook(CAAdoptionAutomationAgent);
                    string ImagePosAfter = CAAdoptionCommonMethods.GetImageCoordinate(CAAdoptionAutomationAgent);
                    Assert.AreNotEqual<string>(ImagePosBefore, ImagePosAfter, "Image not moved");
                    NotebookCommonMethods.ClickEraseIconInNotebook(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29910)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerSavingGOToNotebookDoesNotAffectInitialBlankStateOfGO()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29910:Graphic Organizer - saving GO to Notebook does not affect initial blank state of GO"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 950, 300, 1);
                    NotebookCommonMethods.SendText(CAAdoptionAutomationAgent, "TEST");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyStoryMapInitialStateInGraphicOrganizers(CAAdoptionAutomationAgent, "TEST"), "Graphic Organizers is not opened in Initial State");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29911)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerEditingGOSavedToNotebookDoesNotAffectInitialBlankStateGO()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29911: Graphic Organizer - editing GO saved to Notebook does not affect initial blank state of GO"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 950, 300, 1);
                    NotebookCommonMethods.SendText(CAAdoptionAutomationAgent, "TEST");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickInteractiveThumbnail(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 950, 300, 1);
                    NotebookCommonMethods.SendText(CAAdoptionAutomationAgent, "TEST1");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyStoryMapInitialStateInGraphicOrganizers(CAAdoptionAutomationAgent, "TEST"), "Graphic Organizers is not opened in Initial State");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29939)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SpellingNotebookVerifyHeaderLayoutSpellingLessonEPubView()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29939: Spelling Notebook - verify header layout in Spelling Lesson ePub view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, taskInfo);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek3MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, 3);
                    CAAdoptionCommonMethods.OpenEPubInSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("0x0031C3", CAAdoptionCommonMethods.VerifySpellingNotebookHeaderColor(CAAdoptionAutomationAgent), "Title bar of notebook is not same");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyFolderIcon(CAAdoptionAutomationAgent), "Folder Icon is enabled");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyShareIcon(CAAdoptionAutomationAgent), "Share Icon is enabled");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29909)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GraphicOrganizerSaveMultipleInstancesGOToSameNotebook()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29909: Graphic Organizer - save multiple instances of GO to the same Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 950, 300, 1);
                    NotebookCommonMethods.SendText(CAAdoptionAutomationAgent, "TEST");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGraphicOrganizersInTools(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickStoryMapInGraphicOrganizersMenu(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 950, 300, 1);
                    NotebookCommonMethods.SendText(CAAdoptionAutomationAgent, "TEST1");
                    CAAdoptionAutomationAgent.Sleep(60000);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickSavedGraphicOrganizer(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyMultipleInstancesAreSaved(CAAdoptionAutomationAgent), "Multiple Instances are not saved");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyMultipleInstancesHaveTimeStamp(CAAdoptionAutomationAgent), "Multiple Instances dont have timestamp");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27118)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLVerifyMediaHeaderChromeEPub()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27118: CA - RL - Verify Media header Chrome-ePub"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "CACommonRead"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek3MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, 3);
                    CAAdoptionCommonMethods.OpenEPubInSpelling(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyDoneButton(CAAdoptionAutomationAgent), "Done button is not present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyEpubTitleHeader(CAAdoptionAutomationAgent), "Epub Title header is not present");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(CAAdoptionAutomationAgent), "Resource Library Icon ios not present");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickToolsInResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySnapshotToolMenu(CAAdoptionAutomationAgent), "Snapshot tool menu is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27185)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CARLDONEButtonEPubOfSpellingLesson()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27185: CA - RL - DONE button in ePub of Spelling Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "CACommonRead"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek3MenuOfSpelling(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(CAAdoptionAutomationAgent, 3);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySpellingPageOpen(CAAdoptionAutomationAgent), "Spelling Page is not opened");
                    CAAdoptionCommonMethods.OpenEPubInSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifySpellingPageOpen(CAAdoptionAutomationAgent), "Spelling Page is not opened");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(34063)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CAWHENTeacherTapsTeacherSupportTHENCASpecificTecherGuideSiteOpensInWebview()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC34063: CA - WHEN teacher taps Teacher Support on the Dashboard THEN CA-specific techer guide site opens in webview"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(CAAdoptionAutomationAgent));
                    TeacherSupportCommonMethods.ClickTeacherSupportButtonDashboard(CAAdoptionAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnFirstUrl(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.VerifyFirstUrlInWebViewCA(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnSecondUrl(CAAdoptionAutomationAgent);
                    TeacherSupportCommonMethods.VerifySecondUrlInWebView(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnThirdUrl(CAAdoptionAutomationAgent);
                    TeacherSupportCommonMethods.VerifyThirdUrlInWebView(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(34065)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CAWHENStudentTeacherTapsMTEDashboardTHENCASpecificMTEWebview()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC34065:CA - WHEN Student/Teacher taps on MTE on the Dashboard THEN CA-specific MTE opens in webview"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(CAAdoptionAutomationAgent));
                    NavigationCommonMethods.ClickMoreToExploreButtonInDashboard(CAAdoptionAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePage(CAAdoptionAutomationAgent), "More To Explore Page not present");
                    NavigationCommonMethods.ClickOnDone(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }




        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(24406)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DynamicChromeMenuUserSeeInteractivesGamesPublishedForSpecificGrade()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC24406: dynamic chrome menu - user can see interactives/games published for specific Grade"))
            {
                try
                {

                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);

                    taskInfo = login.GetTaskInfo("ELA", "AnotherRLGrade");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGamesinResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickBobBustersInGames(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlobBusterPage(CAAdoptionAutomationAgent), "Blob Buster Page not present for grade 9");
                    CAAdoptionCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29943)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VocabularyNotebookVerifyHeaderLayoutInNotebookPreviewView()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29943:Vocabulary Notebook - verify header layout in Notebook preview view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.SelectAndCopyVocabularyWord(CAAdoptionAutomationAgent, "commercial");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(CAAdoptionAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAFilter(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickELA(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.DeSelectMathFilterInMyWork(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabulary(CAAdoptionAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAFilter(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyTile(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("0x0031C3", CAAdoptionCommonMethods.VerifyVocabularyNotebookHeaderColor(CAAdoptionAutomationAgent), "Title bar of notebook is not same");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyFolderIcon(CAAdoptionAutomationAgent), "Folder Icon is enabled");
                    Assert.AreEqual<string>("false", CAAdoptionCommonMethods.VerifyShareIcon(CAAdoptionAutomationAgent), "Share Icon is enabled");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29942)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VocabularyNotebookVerifyTileHeaderColourWorkBrowserView()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29942:Vocabulary Notebook - verify tile header colour in WorkBrowser view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.SelectAndCopyVocabularyWord(CAAdoptionAutomationAgent, "commercial");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(CAAdoptionAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAFilter(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickELA(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.DeSelectMathFilterInMyWork(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabulary(CAAdoptionAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAFilter(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyTile(CAAdoptionAutomationAgent);
                    Assert.AreEqual<string>("0x0031C3", CAAdoptionCommonMethods.VerifyVocabularyNotebookHeaderColor(CAAdoptionAutomationAgent), "Title bar of notebook is not same");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(33494)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CAToVerifyBlueBoundingBoxEditableELANotebookVocabulary()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC33494:CA-To verify Blue bounding box in editable ELA notebook in vocabulary"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.SelectAndCopyVocabularyWord(CAAdoptionAutomationAgent, "commercial");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickNotebookTitleToEdit(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyBlueBoundingBoxOfNotebook(CAAdoptionAutomationAgent), "Blue bounding box of notebook is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(44083)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void IOSResourceLibraryVocabularyContentCopy()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC44083:2-8_IOS_Resource Library _Vocabulary_Content copy"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickVocabularyInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickOnUnitInVocabulary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.SelectAndCopyVocabularyWord(CAAdoptionAutomationAgent, "commercial");
                    Assert.AreEqual<string>("true", CAAdoptionCommonMethods.VerifyVocabularyWordCopied(CAAdoptionAutomationAgent), "");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyNotebookPickerWorkBrowserModalExists(CAAdoptionAutomationAgent), "");
                    CAAdoptionCommonMethods.ClickCreateNotebookInNotebookPicker(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyVocabularyScreenSplitted(CAAdoptionAutomationAgent), "");
                    CAAdoptionCommonMethods.TapOnVocabularyPage(CAAdoptionAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(CAAdoptionAutomationAgent), "");
                    CAAdoptionCommonMethods.SelectAndCopyVocabularyWord(CAAdoptionAutomationAgent, "commercial");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickSavedVocabularyPage(CAAdoptionAutomationAgent);
                    int pagenumber = NotebookCommonMethods.GetNotebookPage(CAAdoptionAutomationAgent);
                    Assert.AreEqual<int>(pagenumber, 2);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(29945)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ResourceLibraryContentExistsSmokeTestingofContentDownload()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC29945: Resource library content exists - smoke testing of content download "))
            {
                try
                {

                    Login login = Login.GetLogin("GustadMody9");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyGamesinResourceLibrary(CAAdoptionAutomationAgent), "Games menu not found");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);

                    login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyGamesinResourceLibrary(CAAdoptionAutomationAgent), "Games menu not found");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);


                    login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyGamesinResourceLibrary(CAAdoptionAutomationAgent), "Games menu not found");
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);

                    login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyGamesinResourceLibrary(CAAdoptionAutomationAgent), "Games menu not found");
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(23155)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CAResourceLibraryToVerifyMenuHeadingChangesFromResourceLibraryToMenuItem()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC23155: CA - Resource Library-To verify the Menu heading changes from Resource library to Menu item"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(CAAdoptionAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickOnToolsIcon(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep();
                    string heading = NavigationCommonMethods.GetToolsIconHeading(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep();
                    Assert.AreEqual(heading, "Resource Library", "Heading is not Resource Library");
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep();
                    string newHeading = NavigationCommonMethods.GetToolsIconHeading(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep();
                    Assert.AreEqual(newHeading, "Spelling", "Heading is not Spelling");
                    NavigationCommonMethods.ClickOnToolsIcon(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27047)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DoneButtonInteractiveSpellingLesson()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27047:- DONE button in Interactive of Spelling Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "CAInteractive"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSpellingMenuItem(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickWeek1MenuOfSpelling(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.OpenInteractive(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyDoneButton(CAAdoptionAutomationAgent), "Done button is not present");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27026)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GrammarGrabsVideoAccessiblity()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27026:- Grammar Grabs video accessiblity"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGrammerGrabInLanguageStudies(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickAdverbsGrammerGrab(CAAdoptionAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyVideoFullScreenOverlay(CAAdoptionAutomationAgent), "Video is not opened in full screen");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27105)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AllVideoControlFunction()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27105:-Verify All video controls function"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGrammerGrabInLanguageStudies(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickAdverbsGrammerGrab(CAAdoptionAutomationAgent);
                    CAAdoptionAutomationAgent.Sleep(2000);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(CAAdoptionAutomationAgent), "Video Functionality is not found");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAAdoptionTests")]
        [WorkItem(27028)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GrammerGrabVidepPlayability()
        {
            using (CAAdoptionAutomationAgent = new AutomationAgent("TC27028:-Grammar Grabs -Video playability"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(CAAdoptionAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(CAAdoptionAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    CAAdoptionCommonMethods.ClickResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickLanguageStudiesInResourceLibrary(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickGrammerGrabInLanguageStudies(CAAdoptionAutomationAgent);
                    CAAdoptionCommonMethods.ClickAdverbsGrammerGrab(CAAdoptionAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(CAAdoptionAutomationAgent), "Video Functionality is not found");
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyVideoPlayTillEnd(CAAdoptionAutomationAgent), "Video does not play till end");
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(CAAdoptionAutomationAgent);
                    NavigationCommonMethods.Logout(CAAdoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAAdoptionAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
