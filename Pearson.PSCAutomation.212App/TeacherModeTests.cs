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
    public class TeacherModeTests
    {
        public AutomationAgent teachermodeAutomationAgent;
        public TeacherModeTests()
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(23936)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void FlyOutMenuDisplaysWhenTeacherTapsOnTeacherGuideIcon()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC23936: A Fly out menu displays when teacher taps on Teacher Guide icon."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode not open");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(23937)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void FlyOutMenuDisplaysWithTeacherGuideHeader()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC23937: A Fly out menu displays with the header as Teacher Guide"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher Guide fly out header not present");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(23938)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void FlyOutMenuDisplaysWithUnitOverviewLessonOverviewTaskGuide()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC23938: A Fly out menu displays with Unit Overview Lesson Overview & Task Guide"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickOnELALessonContinueButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(23939)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherTapsAnywhereInTheAppFlyOutClosesOff()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC23939: Teacher taps anywhere in the app, a fly out closes off."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is open");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(24163)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGuideDisplaysForUnitPreviewAndUnitOverviewIsVisibleInBlack()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC24163: Teacher Guide displays for Unit Preview and Unit Overview is visible in black."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    string unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(unitOverviewColor, "0x000000", "Unit overview color is not the same");
                    string lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(lessonOverviewColor, "0xAAAAAA", "Lesson overview color is not the same");
                    string taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(taskGuideColor, "0xAAAAAA", "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(24164)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGuideDisplaysForLessonBrowserAndUnitOverviewIsVisibleInBlack()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC24164: Teacher Guide displays for Lesson Browser and Unit Overview is visible in black."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonBrowserPage(teachermodeAutomationAgent), "Lesson Browser Page not present");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    string unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(unitOverviewColor, "0x000000", "Unit overview color is not the same");
                    string lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(lessonOverviewColor, "0xAAAAAA", "Lesson overview color is not the same");
                    string taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(taskGuideColor, "0xAAAAAA", "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(24165)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGuideDisplaysForLessonPreviewAndUnitOverviewAndLessonOverviewAreVisibleInBlack()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC24165: Teacher Guide displays for Lesson Preview and Unit Overview and Lesson Overview are visible in black."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonBrowserPage(teachermodeAutomationAgent), "Lesson browser Page not present");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonPreview(teachermodeAutomationAgent), "Lesson preview not visible");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    string unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(unitOverviewColor, "0x000000", "Unit overview color is not the same");
                    string lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(lessonOverviewColor, "0x000000", "Lesson overview color is not the same");
                    string taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(taskGuideColor, "0xAAAAAA", "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(24166)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGuideDisplaysForLessonsAndAllLinksAreVisibleInBlack()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC24166: Teacher Guide displays for Lessons and all links are visible in black."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonBrowserPage(teachermodeAutomationAgent), "Lesson browser page not present");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonPreview(teachermodeAutomationAgent), "Lesson preview not present");
                    NavigationCommonMethods.ClickOnELALessonContinueButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonTaskPage(teachermodeAutomationAgent), "Lesson task page not present");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    string unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(unitOverviewColor, "0x000000", "Unit overview color is not the same");
                    string lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(lessonOverviewColor, "0x000000", "Lesson overview color is not the same");
                    string taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.AreEqual(taskGuideColor, "0x000000", "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25112)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreateNoteOverlayContainsInstructionalHeaderCancelButtonTextBoxCreateButtonCharacterCountDisplayCloseButtonInUpperRightCorner()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25112: (01) Create Note overlay contains instructional header, [Cancel] button, text box, [Create] button, character count display, close button in upper right corner"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyAddNoteOverlayElements(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInAddNotesOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25114)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreateNoteCancelButtonDismissTheKeyboardAndClosesOverlayWithoutSavingAnyText()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25114: (03a) Create Note - [Cancel] button dismiss the keyboard and closes the overlay without saving any text"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent), "Keyboard not present");
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCancelInAddNotesOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent), "Keyboard is present");
                    string WordsInTextBox = TeacherModeCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsFalse(WordsInTextBox.Contains("Test"), "Test word is present");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25115)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CreateNoteRevisitedNoteThatWasPreviouslyCancelledDisplaysTextMessage()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25115: (03b) Create Note - revisited Note, that was previously cancelled, displays text message..."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCancelInAddNotesOverlay(teachermodeAutomationAgent);
                    string textMessage = TeacherModeCommonMethods.GetMessageInCanvas(teachermodeAutomationAgent);
                    Assert.AreEqual(textMessage, "Tap Here To Add Your Notes For This Task", "text message not the same");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25116)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CreateNoteCreateButtonIsInactiveUntilUserInputsTextOrIfUserInputsAndRemovesAllText()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25116: (04) Create Note - [Create] button is inactive until user inputs text, or if user inputs & removes all text"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button is active");
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.DeleteTextInTextBox(teachermodeAutomationAgent, "Test");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button is active");
                    TeacherModeCommonMethods.ClickCloseButtonInAddNotesOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25117)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreateNoteCreateButtonBecomesActiveWhenUserInputsText()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25117: (05a) Create Note - [Create] button becomes active when user inputs text"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    string WordsInTextBox = TeacherModeCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(WordsInTextBox.Contains("Test"), "Test word not present");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25121)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreateNoteAfterTappingCreateNoteIsSuccessfullyCreatedAndVisibleInMyTaskNotesArea()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25121: (05b) Create Note - after tapping [Create], Note is successfully created & visible in My Task Notes area"))
            {
                try
                {
                    string note = "Test";

                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, note);
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    string noteInMyTaskNotes = TeacherModeCommonMethods.GetNoteInMyTaskNotes(teachermodeAutomationAgent);
                    Assert.AreEqual(noteInMyTaskNotes, note, "notes are not similar");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25123)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void EditNoteWhenNoteIsCreatedEditButtonAppearsOnTheCanvas()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25123: (08) Edit Note - when Note is created, [Edit] button appears on the canvas"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "Edit button in canvas not present");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25125)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EditNoteWhenUserTapsEditThenNoteOverlayOpensContainingTheHeaderDeleteButtonDoneButtonAndCharacterCountDisplayCloseButtonInUpperRightCorner()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25125: (09) Edit Note - when user taps [Edit], then Note overlay opens, containing the header, [Delete] button, [Done] button and character count display, close button in upper right corner"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyEditNoteOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButton(teachermodeAutomationAgent), "Close button not present");
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25128)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EditNoteAfterTappingDoneYourChangesAreSuccessfullySavedNoteIsVisibleInMyTaskNotesArea()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25128: (09) Edit Note - when user taps [Edit], then Note overlay opens, containing the header, [Delete] button, [Done] button and character count display, close button in upper right corner"))
            {
                try
                {
                    string firstNote = "Test";
                    string secondNote = "Doctor";
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, firstNote);
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.DeleteTextInTextBox(teachermodeAutomationAgent, firstNote);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, secondNote);
                    TeacherModeCommonMethods.ClickDoneInEditYourNotes(teachermodeAutomationAgent);
                    string editedNote = TeacherModeCommonMethods.GetNoteInMyTaskNotes(teachermodeAutomationAgent);
                    Assert.AreEqual(editedNote, secondNote, "edited note not the same");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25818)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreateNoteOverlayAppearsAfterYouTapOnTheCanvas()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25818: (01a) Create Note overlay appears after you tap on the canvas"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNoteOverlay(teachermodeAutomationAgent), "Add note overlay present");
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAddNoteOverlay(teachermodeAutomationAgent), "Add note overlay not present");
                    TeacherModeCommonMethods.ClickCloseButtonInAddNotesOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25821)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AfterTheNoteIsRemovedDefaultInstructionalMessageAppearsInMyTaskNotes()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25821: (12a) after the Note is removed, default instructional message appears in the My Task Notes"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden=TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if(hidden==false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    string msgInCanvas = TeacherModeCommonMethods.GetMessageInCanvas(teachermodeAutomationAgent);
                    Assert.AreEqual(msgInCanvas, "Tap Here To Add Your Notes For This Task", "message in canvas not the same");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25119)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreateNoteEditNoteAutocorrectIsEnabledInTaskNoteTextbox()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25119: (07) Create Note & Edit Note - autocorrect is enabled in Task Note textbox"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "This is to tast");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, " ");
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent,"{BKSP}");
                    TeacherModeCommonMethods.SelectCorrectWordContextualMenu(teachermodeAutomationAgent);
                    string text = TeacherModeCommonMethods.GetTextFromTextBox(teachermodeAutomationAgent);
                    text = text.Replace("\t\n", "");
                    Assert.IsFalse(text.Equals("This is to tast"), "tast word is present");
                    Assert.IsTrue(text.Equals("This is to taste"), "taste word is not present");
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27139)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TGUnitOverviewOneButtonClickToCloseTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27139: TG - Unit Overview - One-button click to close the teacher mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(teachermodeAutomationAgent), "Teacher guide icon not present");
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayPresent(teachermodeAutomationAgent), "Close button in Teacher content overlay not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayActive(teachermodeAutomationAgent), "Close button in teacher content overlay not active");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content is visible");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27142)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TGLessonOverviewOneButtonClickToCloseTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27142: TG: Lesson Overview - One-button click to close the teacher mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(teachermodeAutomationAgent), "Teacher guide icon not present");
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayPresent(teachermodeAutomationAgent), "Close button in Teacher content overlay not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayActive(teachermodeAutomationAgent), "Close button in teacher content overlay not active");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content is visible");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27145)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TGTaskGuideOneButtonClickToCloseTeacherModeContent()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27145: TG: Task Guide - One-button click to close the teacher mode content"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(teachermodeAutomationAgent), "Teacher guide icon not present");
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayPresent(teachermodeAutomationAgent), "Close button in Teacher content overaly not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayActive(teachermodeAutomationAgent), "Close button in Teacher content overlay not active");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content is visible");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27213)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ClipboardIconAlwaysOpensTeacherFlyoutUnitPreview()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27213: Clipboard Icon always opens Teacher Flyout - Unit Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher guide fly out not present");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27214)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ClipboardIconAlwaysOpensTeacherFlyoutLessonBrowser()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27214: Clipboard Icon always opens Teacher Flyout - Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher guide fly out not present");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27215)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ClipboardIconAlwaysOpensTeacherFlyoutLessonPreview()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27215: Clipboard Icon always opens Teacher Flyout - Lesson Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27216)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ClipboardIconAlwaysOpensTeacherFlyoutInLesson()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27216: Clipboard Icon always opens Teacher Flyout - in Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25118)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MyTaskNotesTextIsScrollableIfItExceedsTheViewableArea()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25118: (06) My Task Notes - text is scrollable if it exceeds the viewable area"))
            {
                try
                {
                    int i;
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test\n");
                    for (i = 0; i < 10; i++)
                    {
                        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "A\n");
                    }
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Swipe(Direction.Down, 50, 500);
                    string WordsInTextBox = TeacherModeCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsFalse(WordsInTextBox.Contains("TEST"), "TEST word present");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25135)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EditNoteWhenUserRemovesAllTextFromTheTextboxDoneIsInactive()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25135: (10) Edit Note - when user removes all text from the textbox, [Done] is inactive"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.DeleteTextInTextBox(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickDoneInEditYourNotes(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyDoneButtonIsEnabled(teachermodeAutomationAgent), "Done button is enabled");
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25140)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesAreSavedSeparatellyForEachUser()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25140: (13) Task Notes are saved separatelly for each user"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                    
                    Login login2 = Login.GetLogin("GustadMody9");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login2);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    bool hidden1 = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden1 == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    string note = TeacherModeCommonMethods.GetMessageInCanvas(teachermodeAutomationAgent);
                    Assert.AreEqual(note, "Tap Here To Add Your Notes For This Task");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25141), WorkItem(33958)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UnitOverviewOverlayPreviousTeacherModeIsStillWorkingCorrectInMath()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25141: (09) Unit Overview Overlay - previous Teacher Mode is still working correct in Math, TC33958: opening Teacher Guide after browsing Math Teacher mode causes no unexpected behaviors"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewExpands(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathUnitPreview(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAboutThisLessonExpands(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathLessonPreview(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideExpands(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25142)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenTappingUnitOverviewThenStudentFacingScreenShrinksTeacherContentDisplay()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25142: (02) Unit Overview - WHEN you tap Unit Overview button THEN student-facing screen shrinks AND the teacher content will display in a panel on the right"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    int size = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    int newSize = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    Assert.AreNotEqual(size, newSize);
                    TeacherModeCommonMethods.VerifyTeacherContentPanelOnTheRight(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25129)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void EditNoteDeleteButtonRemovesTheNoteFromTheSystemAndDismissesTheKeyboard()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25129: (12) Edit Note - [Delete] button removes the Note from the system and dismisses the keyboard"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent));
                    string WordsInTextBox = TeacherModeCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsFalse(WordsInTextBox.Contains("Test"), "TEST word is present");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25168)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitOverviewTappingOnSystemTrayHamburgerClosesTheTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25168: (06) Unit Overview - Tapping on System Tray Hamburger closes the Teacher Mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher mode opened");
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25472)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitOverviewOpensItNoLongerIncludesTheAccordion()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25472: (01) Unit Overview - opens, it no longer includes the accordion"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher mode not open");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent), "Accordion Teacher mode open");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent), "Accordion Teacher mode open");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25097)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TaskNotesBoxNotVisibleForStudents()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25097: Task Notes Box - not visible for students"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(teachermodeAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27224)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskGuideTappingOnSystemTrayHamburgerClosesTheTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27224: (07) Task Guide - Tapping on System Tray Hamburger closes the Teacher Mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(29823)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenNonSectionedTeacherLoggedInThenMyClassDoesntAppearAtAll()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC29823: WHEN NON-sectioned teacher logged in THEN [My Class] doesn't appear at all"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyTaskNotesButtonHidden(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassButtonHidden(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(20269)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeContentDisplaysForLessonPreview()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC20269: Teacher Mode CONTENT displays for Lesson Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27473)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherGuideMenuFlyoutAppearsAndWorksTheSameWayLikeInTheNarrowMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27473: Teacher Guide: Teacher Guide Menu Flyout appears and works the same way like in the narrow mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(15909)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenTeacherIsInLessonThenEachItemInAccordionCanBeDisplayed()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC15909: WHEN teacher is in lesson THEN each item in accordion can be displayed"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    string text = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(text.Contains("Signs and Symbols"), "Edited notebook title doesn't contain My Personal string");
                    teachermodeAutomationAgent.Swipe(Direction.Down, 50);
                    teachermodeAutomationAgent.Sleep();
                    string newText = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsFalse(newText.Contains("Signs and Symbols"), "Edited notebook title doesn't contain My Personal string");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27219)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TaskGuideOpensOnTapOfTaskGuideMenuItem()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27219: (01. 02.) Task Guide opens on tap of task guide menu item"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    int size = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    int newSize = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    Assert.AreNotEqual(size, newSize);
                    TeacherModeCommonMethods.VerifyTeacherContentPanelOnTheRight(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(16068)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenTeacherModeSwitchedOnAndTeacherBrowsesContentThenTeacherContentChangesLive()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC16068: WHEN Teacher Mode switched on AND teacher browses the content THEN teacher content changes live"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyUnitOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("false", TeacherSupportCommonMethods.VerifyLessonOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("false", TeacherSupportCommonMethods.VerifyTaskGuideButtonActive(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyUnitOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("false", TeacherSupportCommonMethods.VerifyLessonOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("false", TeacherSupportCommonMethods.VerifyTaskGuideButtonActive(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyUnitOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyLessonOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("false", TeacherSupportCommonMethods.VerifyTaskGuideButtonActive(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickOnELALessonContinueButton(teachermodeAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyUnitOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyLessonOverViewButtonActive(teachermodeAutomationAgent));
                    Assert.AreEqual<string>("true", TeacherSupportCommonMethods.VerifyTaskGuideButtonActive(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(15908)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeContentDisplaysForUnitPreviewLessonBrowserLessonPreviewLesson()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC15908: Teacher Mode: Content displays for the following locations: Unit Preview, Lesson Browser, Lesson Preview, Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(15906)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenLeftArrowWasTappedThenTeacherModeExtendedDisplayOpens()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC15906: WHEN 'left-arrow' was tapped THEN Teacher mode extended display opens"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeEnabled(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher mode not open");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeNormalState(teachermodeAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(20270)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeContentDisplaysForLessonBrowser()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC20270: Teacher Mode CONTENT displays for Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview is not highlighted");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview is highlighted");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide is highlighted");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Unit Overview not expanded");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Lesson Overview is expanded");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide is expanded");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27450)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TappingSystemTrayHamburgerClosesTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27450: 07) Lesson Overview - Tapping on System Tray Hamburger closes the Teacher Mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content still displayed");
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(28364)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ActiveButtonsInFlyOutAreUnitAndLessonOverview()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC28364: (05) Lesson Preview - active buttons on the fly-out are: unit overview and lesson overview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content is not visible");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content is not visible");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27470)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TextIsScrollableInTeacherGuideExtendedView()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27470: (01.) text is scrollable (when necessary) in Teacher Guide extended view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent), "Teacher Mode is not in extended view");
                    string text = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(text.Contains("Signs and Symbols"), "Edited notebook title doesn't contain My Personal string");
                    teachermodeAutomationAgent.Swipe(Direction.Down, 50);
                    teachermodeAutomationAgent.Sleep();
                    string newText = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsFalse(newText.Contains("Signs and Symbols"), "Edited notebook title doesn't contain My Personal string");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(29925)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGuideMenuFlyoutAppearsAndWorksTheSameWayLikeInNarrowMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC29925: Teacher Guide: Teacher Guide Menu Flyout appears and works the same way like in the narrow mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent), "Teacher Mode is not in extended view");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(21736)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GivenTeacherModeOpenWhenNotebookOpenThenTeacherModeClosed()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC21736: GIVEN teacher mode is opened, WHEN I open notebook in a lesson THEN teacher mode gets closed"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide not expanded");
                    NotebookCommonMethods.ClickOnOpenNotebookButton(teachermodeAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide still open");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(21760)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeIsSupportedOnFollowingLocations()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC21760: Teacher mode is supported on Unit Preview, Lesson Browser, Lesson Carousel and Lesson Player (checklist)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(20271)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeThreeSections()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC20271: Teacher Mode 3 sections are: Unit Overview / About This Lesson / Teacher Guide"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide not expanded");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(20272)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeContentDisplaysForFollowingLocations()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC20272: Teacher Mode: Content displays for the following locations: Unit Preview, Lesson Browser, Lesson Preview, Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    Assert.AreEqual<string>("false", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(28367)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskActiveButtonsOnFlyOutAreUnitOverviewLessonOverviewTaskGuide()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC28367: (05) Task - active buttons on the fly-out are: unit overview, lesson overview & task guide"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for unit overview is not visible");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for lesson overview is not visible");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for task guide is not visible");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27449)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonOverviewHeaderReflectsContentDisplayedTitleLessonXOverview()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27449: (04) Lesson Overview - header reflects the content displayed - title should say Lesson X Overview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for lesson overview is not visible");
                    TeacherModeCommonMethods.VerifyLessonOverViewHeaderInTeacherMode(teachermodeAutomationAgent,taskInfo.Lesson);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25088)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxMyClassDoesNTAppearForNonSectionedTeachers()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25088: (09b) Task Notes Box - My Class doesn'T appear for non-sectioned teachers"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for lesson overview is not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaAppearsInTaskNotes(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassButtonHidden(teachermodeAutomationAgent));                  
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(31841)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenViewingLessonOverviewAndSweepingBetweenLessonsThenLessonOverviewContentUpdates()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC31841: WHEN I'm viewing a Lesson Overview AND sweeping between lessons THEN Lesson Overview content updates live, depending on my location"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    String LessonXContent = TeacherModeCommonMethods.GetLessonOverviewContentHeading(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(teachermodeAutomationAgent, taskInfo.Lesson, Direction.Right);
                    String LessonYContent = TeacherModeCommonMethods.GetLessonOverviewContentHeading(teachermodeAutomationAgent);
                    Assert.AreNotEqual(LessonXContent, LessonYContent, "Lesson overview content not updated live");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25096)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxTaskNotesBoxHeaderIsMyTaskNotes()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25096: (01) Task Notes Box - task notes box header is 'My Task Notes'"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.AreEqual<String>("My Task Notes",TeacherModeCommonMethods.VerifyMyTaskNotesHeader(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25166)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void UnitOverviewHeaderReflectsContentDisplayedInTeacherGuidePanelItSaysUnitOverview()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25166: (05) Unit Overview - header reflects the content displayed in the Teacher Guide Panel - it says Unit # Overview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyUnitOverviewExpands(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25092)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxWhenTaskBeingViewedButNoNotesExistForTaskThenInstructionalMessageShouldBeDisplayedTapHereToAdd()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25092: (05) Task Notes Box - when Task is being viewed, but no Notes exist for a task, then instructional message should be displayed: Tap here to add"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyNotesAreaAppearsInTaskNotes(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }                
                    Assert.AreEqual<String>("Tap Here To Add Your Notes For This Task",TeacherModeCommonMethods.VerifyInstructionalMessageInTaskNotesBoxInTask(teachermodeAutomationAgent));        
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25093)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxWhenTaskNotBeingViewedMessageAppearsHeCreateNotesLessonYouCanCreateYour()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25093: (04) Task Notes Box - when Task is not being viewed, message appears explaining user he can create notes in a lesson: You can create your..."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.AreEqual<String>("You can create your own notes for each task of any lesson.Just open a lesson and get started!", TeacherModeCommonMethods.VerifyInstructionalMessageInTaskNotesBoxNotInTask(teachermodeAutomationAgent));                   
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(23924)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeOpenedWhenIOpenInteractiveLessonThenTeacherStaysOpened()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC23924: Teacher mode is opened, when I open an Interactive in a lesson then teacher stays opened."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    NotebookCommonMethods.OpenInteractive(teachermodeAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25094)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxTeacherMaintainNotesOnlyOnTaskLevel()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25094: (03) Task Notes Box - teacher can maintain notes only on Task level"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.VerifyLessonBrowserPage(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotesNotAtTaskLevel(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNoteOverlay(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent,taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    string WordsInTextBox = TeacherModeCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(WordsInTextBox.Contains("Test"), "Test word not present");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(21737)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GivenTeacherModeOpenedWhenIOpenCommonReaInLessonThenTeacherStaysOpened()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC21737:GIVEN teacher mode is opened, WHEN I open Common Read in a lesson THEN teacher stays opened"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.OpenCommonReadInTeacherMode(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCommonReadOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    CommonReadCommonMethods.ClickOnDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(21738)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GivenTeacherModeIsOpenedWhenIOpenVideoThenTeacherModeStaysOpened()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC21738:GIVEN teacher mode is opened, WHEN I open a video THEN teacher mode stays opened"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickDoneButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(29924)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherGuideCloseButtonWorksProperlyInBothNarrowAndExpandedMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC29924:Teacher Guide: close button works properly in both, narrow and expanded mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27469)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherGuideExtendsToFullscreenFormatSectionHeadersMovingLeftSupportingTextToRight()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27469:(01.)Teacher Guide extends to the fullscreen format, text formatting remains in place, section headers moving left, supporting text to the right"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifySectionHeadersMovedToLeft(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifySupportingTextMovedToRight(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25091)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxNotesDisplayOnlyWhenYouAreInLesson()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25091: (06) Task Notes Box - notes display only when you are in a lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test1");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    String NoteA=TeacherModeCommonMethods.GetNoteInMyTaskNotes(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnNextButtonInTask(teachermodeAutomationAgent);
                    bool hidden1 = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden1 == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test2");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    String NoteB = TeacherModeCommonMethods.GetNoteInMyTaskNotes(teachermodeAutomationAgent);
                    Assert.AreNotEqual<string>(NoteA, NoteB);                  
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25113)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CreateNoteEditNoteUnformattedTextCanBeAddedLimitedTo1000Characters()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25113: (02) Create Note & Edit a Note - unformatted text can be added, limited to 1000 characters"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "test1");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    string firstnew1 = TeacherModeCommonMethods.GetTextFromTextBox(teachermodeAutomationAgent).Replace("\t\n","");
                    int lengthofstring1 = firstnew1.Length;
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    for (int i = 1; i <= 100; i++)
                    {
                        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "abcdefghij");
                    }
                    string firstnew2 = TeacherModeCommonMethods.GetTextFromTextBox(teachermodeAutomationAgent);
                    int lengthofstring2 = firstnew2.Length;
                    Assert.AreNotEqual<int>(lengthofstring1, lengthofstring2);
                    TeacherModeCommonMethods.ClickDoneInEditYourNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(25838)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherContentIsNotVisibleForStudents()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25838:Teacher Content is not visible for Students"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(20267)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonCarouselScalesAlongWithMainAppScreenWhenOpeningTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC20267:Lesson Carousel scales along with the main app screen when opening teacher mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnUnitOverviewInTeacherMode(teachermodeAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeScaledProperly(teachermodeAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyBottomBlackBar(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27471)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void WhenTeacherGuidePanelExtendsFullscreenThenExpandIconWillRotateOppositeDirection()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27471: WHEN Teacher Guide panel extends to fullscreen, THEN the Expand Icon will rotate to point the opposite direction to become the Minimize Icon"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherSupportCommonMethods.VerifyTeacherModeNormalState(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyExtendIcon(teachermodeAutomationAgent);
                    TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMinimizeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(27222)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TaskGuideHeaderReflectsTaskName()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27222: (04) Task Guide - header reflects the content displayed - title of the Task should be displayed"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(teachermodeAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    string headerText = TeacherModeCommonMethods.GetTextFromTeacherModeHeader(teachermodeAutomationAgent);
                    Assert.IsTrue(taskName.Contains(headerText), "the task names and the header text in the teacher mode are not similar");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27472)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherGuideCloseButtonWorksProperlyBothNarrowExpandedMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27472:Teacher Guide: close button works properly in both, narrow and expanded mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25089)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxMyClassButtonAppearsForSectionedTeachers()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25089:[CA: OUT OF SCOPE](09a) Task Notes Box - My Class button appears for sectioned teachers"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaAppearsInTaskNotes(teachermodeAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyClassButtonHidden(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25095)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskNotesBoxMyTaskNotesMaySwitchedToMyClass()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25095:- [CA: OUT OF SCOPE](02a) Task Notes Box - My Task Notes may be switched to My Class"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaAppearsInTaskNotes(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassAreaAppers(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickMyTaskNotesButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(25470)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitOverviewTappingELAUnitOrMyDashboardClosesTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC25470: TGUnit Overview - Tapping on [ELA Units] or [My Dashboard] closes the Teacher Mode"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    DashboardCommonMethods.ClickContinueLessonButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(2000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content visible");

                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(1000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content visible");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27439)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherMyClassshouldActiveTeacherMode()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC27439: WHEN sectioned teacher logged in THEN [My Class] button should be active in teacher mode"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    DashboardCommonMethods.ClickContinueLessonButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassButtonVisible(teachermodeAutomationAgent),"My Class button not visible");
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassAreaAppers(teachermodeAutomationAgent),"My class area not found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27441)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherTapStudentIconOpenStudentRosterTeacherMode()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC27441: WHEN sectioned teacher taps student icon on the roster bottom panel THEN student roster opens, showing student information"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    DashboardCommonMethods.ClickContinueLessonButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentIconInMyClassArea(teachermodeAutomationAgent),"student icon not found");
                    TeacherModeCommonMethods.ClickStudentIconInMyClass(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent),"student information ot found");
                    CommonReadCommonMethods.ClickOnDoneButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(28356)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherSwitchestoMyClassAndBackMyTaskNoteEditButtonNotAppear()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC28356: WHEN sectioned teacher switches to My Class view AND back to My Task Notes THEN [Edit] button shouldn't be appearing"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    DashboardCommonMethods.ClickContinueLessonButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);

                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "edit button ot found");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyTaskNotesButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent), "edit button present on screen");                    
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27443)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENTeacherGuideBrowsingContentUpdatesLive()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC27443: WHEN I'm viewing teacher guide AND browsing content THEN teacher guide content updates live, depending on my location in app ( browsing Task -> Unit Preview )"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent), "task guide not opened");
                    
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent,taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(32206)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENTeacherGuideBrowsingContentUpdatesLiveSweepingBetwenUnits()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC32206: WHEN I'm viewing a Unit Overview AND sweeping between units THEN Unit Overview content updates live, depending on my location"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.SwipeUnit(teachermodeAutomationAgent, Direction.Right, taskInfo.Unit);
                    teachermodeAutomationAgent.Sleep(1000);
                    int Newunit = int.Parse(taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, Newunit + 1), "Unit overview not found for unit 2");
                    NavigationCommonMethods.SwipeUnit(teachermodeAutomationAgent, Direction.Left, Newunit + 1);
                    teachermodeAutomationAgent.Sleep(1000);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent); 
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(28357)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherOpensStudentRosterAnsMyClassAndBackMyTaskNoteWorkAsExpected()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC28357: WHEN sectioned teacher opens the student roster THEN My Task Notes and My Class work as expected, in & outside the lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    DashboardCommonMethods.ClickContinueLessonButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentIconInMyClassArea(teachermodeAutomationAgent), "student icon not found");
                    TeacherModeCommonMethods.ClickStudentIconInMyClass(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information ot found");
                    CommonReadCommonMethods.ClickOnDoneButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyTaskNotesButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "edit button ot found");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27442)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherSwitcheToMyClassEditButtonNotAvailable()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC27442: WHEN sectioned teacher switches to My Class view THEN [Edit] button shouldn't be available"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "edit button not found");
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent), "edit button found on screen");
                    TeacherModeCommonMethods.ClickMyTaskNotesButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "edit button ot found");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(20266)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENTeacherModeOnAndBrowsingContentUpdatesLive()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC20266: WHEN Teacher Mode switched on AND teacher browses the content THEN teacher content changes live"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent), "task guide not opened");

                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");

                    NavigationCommonMethods.SwipeUnit(teachermodeAutomationAgent, Direction.Right, taskInfo.Unit);
                    teachermodeAutomationAgent.Sleep(1000);
                    int Newunit = int.Parse(taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, Newunit + 1), "Unit overview not found for unit 2");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(27445)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonOverviewOpensWhenYouTapOfTaskGuideMenuItem()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC27445: (02) Lesson Overview - Lesson Overview opens when you tap of task guide menu item"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, 1);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, 1);
                    int size = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    int newSize = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    Assert.AreNotEqual(size, newSize);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverviewPanelOnRight(teachermodeAutomationAgent), "Lesson Overview Panel On Right is not found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(29921)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonOverviewTextScrollableWhenNecessaryInTeacherGuideExtendedView()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC29921:- Lesson Overview: text is scrollable (when necessary) in Teacher Guide extended view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    string text = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(text.Contains("Materials"), "");
                    teachermodeAutomationAgent.Swipe(Direction.Down, 50);
                    teachermodeAutomationAgent.Sleep();
                    string newText = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    if(newText.Contains("Materials"))
                    {
                        teachermodeAutomationAgent.AddSteptoSeeTestReport("Text is not scrollable", true);
                    }
                    else
                    {
                        teachermodeAutomationAgent.AddSteptoSeeTestReport("Text is scrollable", true);
                    }                    
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(23925)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeIsAvailableTeacherExitTeacherModeFromInteractive()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC23925: Teacher mode is opened, when I open an Interactive in a lesson then teacher stays opened."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent));
                    NotebookCommonMethods.OpenInteractive(teachermodeAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherModeIconClose(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(teachermodeAutomationAgent));
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(22432)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDetailPage()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC22432: Student Detail Page"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(teachermodeAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(teachermodeAutomationAgent), "Class roster not found");
                    DashboardCommonMethods.ClickClassRosterInDashboard(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyClassRosterOpened(teachermodeAutomationAgent), "Class roster not opened");
                    TeacherModeCommonMethods.ClickStudentTileInClassRoster(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information not found");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationControls(teachermodeAutomationAgent), "student infromation controls not found");
                    TeacherModeCommonMethods.ClickOnBackButtonStudentInformationPage(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(2000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information still found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(22430)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ClassRosterPage()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC22430: Class Roster Page"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(teachermodeAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(teachermodeAutomationAgent), "Class roster not found");
                    DashboardCommonMethods.ClickClassRosterInDashboard(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(teachermodeAutomationAgent), "User is not on dashboard");
                    DashboardCommonMethods.ClickClassRosterInDashboard(teachermodeAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterOpened(teachermodeAutomationAgent), "Class roster not opened");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterPageHeader(teachermodeAutomationAgent), "Class roster page controls not verified");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterStudentNameAndAvatar(teachermodeAutomationAgent), "Class roster student name tile and avatar controls not verified");
                    DashboardCommonMethods.ScrollClassRosterVertically(teachermodeAutomationAgent);
                    DashboardCommonMethods.ClickStudentTileInClassRoster(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationControls(teachermodeAutomationAgent), "student infromation cotrols not found");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information still found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(29922)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENTeacherGuidePanelExtendsArrowChangesOppDirection()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("TC29922: WHEN Teacher Guide panel extends to fullscreen, THEN the Expand Icon will rotate to point the opposite direction to become the Minimize Icon"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "teacher node not opened");
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyExtendIcon(teachermodeAutomationAgent), "Extend arrow not found");
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandArrowIcon(teachermodeAutomationAgent);
                    //Assert.IsTrue(TeacherModeCommonMethods.VerifyExtendIconRight(teachermodeAutomationAgent), "Extend icon pointing to right not found");
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandArrowIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyExtendIcon(teachermodeAutomationAgent), "Extend arrow not found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(31785)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENViewingTaskGuidExpandedViewTHENTaskGuideContentUpdatesLiveDependingonLocation()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC31785: WHEN I'm viewing a Task Guide *expanded view* AND browsing content THEN Task Guide content updates live, depending on my location"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content not displayed and expanded");
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.Lesson + 1);
                    string TaskGuideTitle = TeacherModeCommonMethods.GetTeacherGuideTitle(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    string NewTaskGuideTitle = TeacherModeCommonMethods.GetTeacherGuideTitle(teachermodeAutomationAgent);
                    Assert.AreEqual<string>(TaskGuideTitle, NewTaskGuideTitle, "Task Guide content not changes live");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(29824)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeIsStillWorkingCorrectInMath()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC29824: [CA: OUT OF SCOPE] Teacher Mode - previous Teacher Mode is still working correct in Math"))
            {
                try
                {
                    Login login = Login.GetLogin("TeacherAeddings");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickStudentRosterImage(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentRosterOpen(teachermodeAutomationAgent), "Student Roster is not found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(31786)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TaskGuideDisableForFirstAndLastTask()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC31786: Task Guide < and > are disabled for the first and the last task, not allowing to switch to non-existing tasks"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "OverviewPage");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyPreviousButtonDisabledForFirstTask(teachermodeAutomationAgent),"");
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, 9);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLastButtonDisabledForFirstTask(teachermodeAutomationAgent),"");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(33956)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherGuideIsUnavailableAlertSaysContentNotCurrentlyAvailable()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("TC33956:WHEN teacher guide is unavailable THEN alert saying: Content Unavailable This content is not currently available appears << collapsed and extended view"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "BlankTeacherContent");
                    NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNoContentNotice(teachermodeAutomationAgent), "Content Unavailable This content is not currently available: is not appearing");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //optimization
        [TestMethod()]
        [Priority(1)]
        [WorkItem(24163), WorkItem(24164), WorkItem(24165), WorkItem(24166), WorkItem(20269), WorkItem(16068), WorkItem(20270), WorkItem(20271), WorkItem(20272), WorkItem(20267), WorkItem(27222), WorkItem(20266), WorkItem(32206)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherGuideFlyoutInDifferentCases()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("MTC23: TeacherMode - Teacher Guide is flyout"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent)), "1.Unit Overview not clickable");
                    Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent)), "1. Lesson Overview not clickable");
                    Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent)), "1. Task Guide not clickable");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    string unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(unitOverviewColor.Equals("0x000000"), "Unit overview color is not the same");
                    string lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(lessonOverviewColor.Equals("0xAAAAAA"), "Lesson overview color is not the same");
                    string taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(taskGuideColor.Equals("0xAAAAAA"), "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonBrowserPage(teachermodeAutomationAgent), "Lesson Browser Page not present");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent)), "2. Unit Overview is not clickable");
                    Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent)), "2. Lesson Overview is highlighted");
                    Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent)), "2. Task Guide is highlighted");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(unitOverviewColor.Equals("0x000000"), "Unit overview color is not the same");
                    lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(lessonOverviewColor.Equals("0xAAAAAA"), "Lesson overview color is not the same");
                    taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(taskGuideColor.Equals("0xAAAAAA"), "task guide color is not the same");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Unit Overview not expanded");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Lesson Overview is expanded");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide is expanded");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonPreview(teachermodeAutomationAgent), "Lesson preview not visible");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher content is displayed");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent)), "3. Unit Overview is not clickable");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent)), "1. Lesson Overview is not highlighted");
                    Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent)), "3. Task Guide is highlighted");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeScaledProperly(teachermodeAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyBottomBlackBar(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(unitOverviewColor.Equals("0x000000"), "Unit overview color is not the same");
                    lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(lessonOverviewColor.Equals("0x000000"), "Lesson overview color is not the same");
                    taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(taskGuideColor.Equals("0xAAAAAA"), "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickOnELALessonContinueButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonTaskPage(teachermodeAutomationAgent), "Lesson task page not present");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent)), "4. Unit Overview not clickable");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent)), "2. Lesson Overview is not highlighted");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent)), "1. Task Guide not clickable");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher guide fly out header not present");
                    unitOverviewColor = TeacherModeCommonMethods.GetUnitOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(unitOverviewColor.Equals("0x000000"), "Unit overview color is not the same");
                    lessonOverviewColor = TeacherModeCommonMethods.GetLessonOverviewTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(lessonOverviewColor.Equals("0x000000"), "Lesson overview color is not the same");
                    taskGuideColor = TeacherModeCommonMethods.GetTaskGuideTextColor(teachermodeAutomationAgent);
                    Assert.IsTrue(taskGuideColor.Equals("0x000000"), "task guide color is not the same");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
                    NotebookCommonMethods.ClickOnNotebookIcon(teachermodeAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(teachermodeAutomationAgent);
                    taskName = taskName.Substring(0, 12);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide not expanded");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent), "task guide not opened");
                    string headerText = TeacherModeCommonMethods.GetTextFromTeacherModeHeader(teachermodeAutomationAgent);
                    headerText = headerText.Substring(0, 12);
                    Assert.IsTrue(taskName.Contains(headerText), "the task names and the header text in the teacher mode are not similar");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent)), "5. Unit Overview not clickable");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent)), "Lesson Overview not clickable");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent)), "2. Task Guide not clickable");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.SwipeUnit(teachermodeAutomationAgent, Direction.Right, taskInfo.Unit);
                    teachermodeAutomationAgent.Sleep(1000);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, words[0]), "Unit overview not found for unit next");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(1)]
        [WorkItem(15908), WorkItem(15906), WorkItem(29922)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeExpandButtonFunction()
        {
	        using (teachermodeAutomationAgent = new AutomationAgent("MTC24: TeacherMode - TeacherMode expand button"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
			        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
			        NavigationCommonMethods.NavigateToELA(teachermodeAutomationAgent);
			        NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
			        NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent), "1. Teacher mode doesn't expand");
			        TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
			        Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent), "1. Teacher mode expands");
			        TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent), "2. Teacher mode expands");
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent), "2. Teacher mode doesn't expand");
			        TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
			        NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent), "3. Teacher mode doesn't expand");
			        TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
			        NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
			        Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeEnabled(teachermodeAutomationAgent), "Teacher mode not enabled");
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher mode not open");
			        TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeButtonExpands(teachermodeAutomationAgent), "4. Teacher mode doesn't expand");
			        TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent), "Teacher mode not pulled out");
			        TeacherSupportCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeNormalState(teachermodeAutomationAgent), "Teacher mode is not in normal state");
			        TeacherSupportCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
			        TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "teacher node not opened");
			        TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyExtendIcon(teachermodeAutomationAgent), "1. Extend arrow not found");
			        TeacherModeCommonMethods.ClickOnTeacherModeExpandArrowIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickOnTeacherModeExpandArrowIcon(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyExtendIcon(teachermodeAutomationAgent), "2. Extend arrow not found");
			        NavigationCommonMethods.Logout(teachermodeAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        teachermodeAutomationAgent.Sleep(2000);
			        teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        teachermodeAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [Priority(1)]
        [WorkItem(25838), WorkItem(25097)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeForStudents()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("MTC25: TeacherMode - Student"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent), "1. Teacher mode icon is visible for student");
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent), "2. Teacher mode icon is visible for student");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent), "3. Teacher mode icon is visible for student");
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(teachermodeAutomationAgent), "4. Teacher mode icon is visible for student");
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(teachermodeAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent));
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(25112), WorkItem(25114), WorkItem(25115), WorkItem(25116), WorkItem(25117), WorkItem(25121), WorkItem(25123), WorkItem(25125), WorkItem(25128), WorkItem(25818), WorkItem(25821), WorkItem(25119), WorkItem(25118), WorkItem(25135), WorkItem(25140), WorkItem(25129), WorkItem(25092), WorkItem(25094), WorkItem(25113)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeNotesFunctionality()
        {
	        using (teachermodeAutomationAgent = new AutomationAgent("MTC26: TeacherMode - Notes"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
			        NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
			        NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
			        LessonBrowserCommonMethods.VerifyLessonBrowserPage(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
			        Assert.IsFalse(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent));
			        TeacherModeCommonMethods.ClickOnCanvasToAddNotesNotAtTaskLevel(teachermodeAutomationAgent);
			        Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNoteOverlay(teachermodeAutomationAgent));
			        TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
			        NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent,taskInfo.Lesson);
			        NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
			        NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
			        TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
			        bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
			        if (!hidden)
			        {
				        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
				        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
			        }
			        Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNoteOverlayElements(teachermodeAutomationAgent), "Add note overlay present");
			        TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyAddNoteOverlayElements(teachermodeAutomationAgent), "Add note overlay not present");
			        TeacherModeCommonMethods.ClickCloseButtonInAddNotesOverlay(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent), "Keyboard not present");
			        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
			        Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent)), "Create button not active");
			        TeacherModeCommonMethods.ClickCancelInAddNotesOverlay(teachermodeAutomationAgent);
			        Assert.IsFalse(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent), "Keyboard is present");
                    string textMessage = TeacherModeCommonMethods.GetDefaultMyTaskNotes(teachermodeAutomationAgent);
			        Assert.IsFalse(textMessage.Contains("Test"), "Test word is present");
			        Assert.AreEqual(textMessage, "Tap Here To Add Your Notes For This Task", "text message not the same");
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent));
			        TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
			        Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent)), "1. Create button is active");
			        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
			        Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent)), "Create button not active");
			        TeacherModeCommonMethods.DeleteTextInTextBox(teachermodeAutomationAgent, "Test");
			        Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent)), "2. Create button is active");
			        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
			        string firstnew1 = TeacherModeCommonMethods.GetTextFromTextBox(teachermodeAutomationAgent).Replace("\t\n","");
			        int lengthofstring1 = firstnew1.Length;			
			        TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    string WordsInTextBox = TeacherModeCommonMethods.GetNoteInMyTaskNotes(teachermodeAutomationAgent);
			        Assert.IsTrue(WordsInTextBox.Contains("Test"), "Test word not present");
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "Edit button in canvas not present");
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
			        Assert.IsTrue(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent));
			        TeacherModeCommonMethods.DeleteTextInTextBox(teachermodeAutomationAgent, "Test");
			        Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyDoneButtonIsEnabled(teachermodeAutomationAgent)), "Done button is enabled");
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Gingar ");
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "{BKSP}");
                    TeacherModeCommonMethods.SelectCorrectWordContextualMenu(teachermodeAutomationAgent, "Ginger");
			        TeacherModeCommonMethods.ClickDoneInEditYourNotes(teachermodeAutomationAgent);
                    string editedNote = TeacherModeCommonMethods.GetNoteInMyTaskNotes(teachermodeAutomationAgent);
			        editedNote = editedNote.Replace("\t\n", "").Trim();
			        Assert.IsFalse(editedNote.Equals("Gingar"), "Gingar word is present");
			        Assert.IsTrue(editedNote.Equals("Ginger"), "Ginger word is not present");
			        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.VerifyEditNoteOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButton(teachermodeAutomationAgent), "Close button not present");
			        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
			        Assert.IsFalse(TeacherModeCommonMethods.VerifyKeyboardPresence(teachermodeAutomationAgent));
                    string msgInCanvas = TeacherModeCommonMethods.GetDefaultMyTaskNotes(teachermodeAutomationAgent);
			        Assert.AreEqual(msgInCanvas, "Tap Here To Add Your Notes For This Task", "message in canvas not the same");
			        TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test\n");
			        for (int i = 0; i < 10; i++)
			        {
				        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "A\n");
			        }
			        TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
			        teachermodeAutomationAgent.Swipe(Direction.Down, 50, 500);
			        WordsInTextBox = TeacherModeCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
			        Assert.IsFalse(WordsInTextBox.Contains("TEST"), "TEST word present");
			        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
			        for (int i = 1; i <= 20; i++)
			        {
                        TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghij");
			        }
			        string firstnew2 = TeacherModeCommonMethods.GetTextFromTextBox(teachermodeAutomationAgent);
			        int lengthofstring2 = firstnew2.Length;
			        Assert.AreNotEqual<int>(lengthofstring1, lengthofstring2);
                    string count = TeacherModeCommonMethods.GetCharacterCount(teachermodeAutomationAgent);
                    Assert.IsTrue(count.Equals("1000/ 1000"), "Count is more than 1000");
			        TeacherModeCommonMethods.ClickDoneInEditYourNotes(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
			        NavigationCommonMethods.Logout(teachermodeAutomationAgent, true);
			
			        Login login2 = Login.GetLogin("GustadMody9");
			        NavigationCommonMethods.Login(teachermodeAutomationAgent, login2);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
			        TeacherModeCommonMethods.ClickLessonOverview(teachermodeAutomationAgent);
			        bool hidden1 = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
			        if (hidden1 == false)
			        {
				        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
				        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
			        }
                    string note = TeacherModeCommonMethods.GetDefaultMyTaskNotes(teachermodeAutomationAgent);
			        Assert.AreEqual(note, "Tap Here To Add Your Notes For This Task");
			        NavigationCommonMethods.Logout(teachermodeAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        teachermodeAutomationAgent.Sleep(2000);
			        teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        teachermodeAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(27139), WorkItem(27142), WorkItem(27145), WorkItem(27213), WorkItem(23936), WorkItem(23937), WorkItem(23938), WorkItem(23939), WorkItem(27214), WorkItem(27215), WorkItem(27216), WorkItem(25142), WorkItem(25472), WorkItem(29823), WorkItem(27473), WorkItem(15909), WorkItem(27219), WorkItem(28364), WorkItem(27470), WorkItem(29925), WorkItem(21736), WorkItem(21738), WorkItem(29924), WorkItem(27469), WorkItem(25091), WorkItem(27471), WorkItem(27472), WorkItem(27445), WorkItem(29921), WorkItem(31785)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeImportantFunction()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("MTC27: TeacherMode - various important functions"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    int size = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent); 
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(teachermodeAutomationAgent), "Teacher guide icon not present");
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent), "Accordion Teacher mode open");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    int newSize = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayPresent(teachermodeAutomationAgent), "Close button in Teacher content overlay not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayActive(teachermodeAutomationAgent), "Close button in teacher content overlay not active");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent), "Accordion Teacher mode open");
                    Assert.AreNotEqual(size, newSize, "1. teacher/ student facing screen doesn't shrink");
                    TeacherModeCommonMethods.VerifyTeacherContentPanelOnTheRight(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher guide fly out not present");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content is visible");
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutHeader(teachermodeAutomationAgent), "Teacher Guide fly out header not present");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickDoneButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible after video");
                    TeacherSupportCommonMethods.VerifyTeacherModeNormalState(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyExtendIcon(teachermodeAutomationAgent);
                    TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMinimizeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    string TaskGuideTitle = TeacherModeCommonMethods.GetTeacherGuideTitle(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeNext(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(WaitTime.LargeWaitTime);
                    string NewTaskGuideTitle = TeacherModeCommonMethods.GetTeacherGuideTitle(teachermodeAutomationAgent);
                    Assert.AreNotEqual<string>(TaskGuideTitle, NewTaskGuideTitle, "Task Guide content not changes live");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher guide fly out not present");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    newSize = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    Assert.AreNotEqual(size, newSize, "teacher/ student facing screen doesn't shrink");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverviewPanelOnRight(teachermodeAutomationAgent), "Lesson Overview Panel On Right is not found");
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifySectionHeadersMovedToLeft(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.VerifySupportingTextMovedToRight(teachermodeAutomationAgent);
                    string text = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(text.Contains(words[1]), "Word isn't found");
                    teachermodeAutomationAgent.Swipe(Direction.Down, 50);
                    teachermodeAutomationAgent.Sleep();
                    string newText = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    if (newText.Contains(words[1]))
                    {
                        teachermodeAutomationAgent.AddSteptoSeeTestReport("Text is not scrollable", true);
                    }
                    else
                    {
                        teachermodeAutomationAgent.AddSteptoSeeTestReport("Text is scrollable", true);
                    }

                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayPresent(teachermodeAutomationAgent), "Close button in Teacher content overlay not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayActive(teachermodeAutomationAgent), "Close button in teacher content overlay not active");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent)), "Unit overview isn't highlighted");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent)), "Lesson overview isn't highlighted");
                    Assert.IsFalse(bool.Parse(TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent)), "Task Guide is highlighted");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content is visible");
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent); 
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(teachermodeAutomationAgent), "Teacher Mode is not open");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModePulledOut(teachermodeAutomationAgent), "Teacher Mode is not in extended view");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyTaskNotesButtonHidden(teachermodeAutomationAgent), "My task notes not available");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassButtonHidden(teachermodeAutomationAgent), "My class button is available");
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    taskInfo = login.GetTaskInfo("ELA", "OpenNotebookButton");
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
                    NotebookCommonMethods.ClickOnOpenNotebookButton(teachermodeAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Task Guide still open");
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickTeacherGuideIconInTeacherGuideContent(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayPresent(teachermodeAutomationAgent), "Close button in Teacher content overaly not present");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCloseButtonInTeacherContentOverlayActive(teachermodeAutomationAgent), "Close button in Teacher content overlay not active");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content is visible");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    newSize = TeacherModeCommonMethods.GetScreenSize(teachermodeAutomationAgent);
                    Assert.AreNotEqual(size, newSize, "teacher/ student facing screen doesn't shrink");
                    TeacherModeCommonMethods.VerifyTeacherContentPanelOnTheRight(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    text = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsTrue(text.Contains(words[2]), "Edited notebook title doesn't contain My Personal string");
                    teachermodeAutomationAgent.Swipe(Direction.Down, 50);
                    teachermodeAutomationAgent.Sleep();
                    newText = NotebookCommonMethods.GetTextInTextZone(teachermodeAutomationAgent);
                    Assert.IsFalse(newText.Contains(words[2]), "Edited notebook title doesn't contain My Personal string");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(25141), WorkItem(33958), WorkItem(23925), WorkItem(29824)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeInMath()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("MTC28: TeacherMode - Math "))
            {
                try
                {
                    Login login = Login.GetLogin("ClassRosterTeacher");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.NavigateToMathGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent), "1. Teacher mode doesn't open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewExpands(teachermodeAutomationAgent), "Unit overview expands");
                    NavigationCommonMethods.ClickStartInMathUnitPreview(teachermodeAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent), "2. Teacher mode doesn't open");
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAboutThisLessonExpands(teachermodeAutomationAgent), "About this lesson doesn't expand");
                    NavigationCommonMethods.ClickStartInMathLessonPreview(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideExpands(teachermodeAutomationAgent), "Teacher guide doesn't expand");
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
                    TeacherModeCommonMethods.ClickStudentRosterImage(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentRosterOpen(teachermodeAutomationAgent), "Student Roster is not found");
                    CommonReadCommonMethods.ClickOnDoneButton(teachermodeAutomationAgent);
                    NotebookCommonMethods.OpenInteractive(teachermodeAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnTeacherModeIconClose(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAccordionTeacherModeOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(teachermodeAutomationAgent));
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(25168), WorkItem(27224), WorkItem(27450)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SystemTrayClosesTeacherMode()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("MTC29: TeacherMode - System tray closes TeacherMode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));

                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "1. Teacher mode opened");
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);

                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent));
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "2. Teacher mode opened");
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);

                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.VerifySystemTrayOpen(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "3. Teacher mode opened");
                    NavigationCommonMethods.ClickSystemTrayButton(teachermodeAutomationAgent);

                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(21760), WorkItem(28367), WorkItem(27449), WorkItem(25088), WorkItem(31841), WorkItem(25096), WorkItem(25166), WorkItem(25093), WorkItem(23924), WorkItem(21737), WorkItem(27443)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeOnVariousLocations()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("MTC30: TeacherMode - available in different location"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Interactive");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out not opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutOpened(teachermodeAutomationAgent), "Teacher Mode fly out still opened");
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyUnitOverviewHighlighted(teachermodeAutomationAgent), "Unit Overview not clickable");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for unit overview is not visible");
                    Assert.AreEqual<String>("You can create your own notes for each task of any lesson.Just open a lesson and get started!", TeacherModeCommonMethods.VerifyInstructionalMessageInTaskNotesBoxNotInTask(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.VerifyUnitOverviewExpands(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit));
                    Assert.IsTrue("My Task Notes".Equals(TeacherModeCommonMethods.VerifyMyTaskNotesHeader(teachermodeAutomationAgent)), "My Task Notes header is not correct");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyLessonOverviewHighlighted(teachermodeAutomationAgent), "Lesson Overview not clickable");
                    TeacherModeCommonMethods.ClickLessonOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for lesson overview is not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaAppearsInTaskNotes(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassButtonHidden(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.VerifyLessonOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for lesson overview is not visible");
                    LessonBrowserCommonMethods.ClickOnBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    String LessonXContent = TeacherModeCommonMethods.GetLessonOverviewContentHeading(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(teachermodeAutomationAgent, taskInfo.Lesson, Direction.Right);
                    String LessonYContent = TeacherModeCommonMethods.GetLessonOverviewContentHeading(teachermodeAutomationAgent);
                    Assert.AreNotEqual(LessonXContent, LessonYContent, "Lesson overview content not updated live");
                    TeacherModeCommonMethods.ClickCloseButtonInTeacherContentOverlay(teachermodeAutomationAgent);
                    //LessonBrowserCommonMethods.ClickOnBackButton(teachermodeAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnLessonPreviewCloseButton(teachermodeAutomationAgent, taskInfo.Lesson + 1);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.ClickContinueLessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    Assert.AreEqual<string>("true", TeacherModeCommonMethods.VerifyTaskGuideHighlighted(teachermodeAutomationAgent), "Task Guide not clickable");
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher Guide content for task guide is not visible");
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
                    NotebookCommonMethods.OpenInteractive(teachermodeAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    TeacherModeCommonMethods.ClickOnTeacherModeOnIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTaskGuideOpened(teachermodeAutomationAgent), "task guide not opened");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    TeacherModeCommonMethods.OpenCommonReadInTeacherMode(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCommonReadOpen(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent));
                    CommonReadCommonMethods.ClickOnDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewHeaderInTeacherMode(teachermodeAutomationAgent, taskInfo.Unit), "Unit overview not opened");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(25089), WorkItem(25095), WorkItem(27439), WorkItem(27441), WorkItem(28356), WorkItem(28357), WorkItem(27442)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyMyClassFunctionalityForSectionedTeacher()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("MTC31: TeacherMode - My Class Sectioned Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("ClassRosterTeacher");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassButtonVisible(teachermodeAutomationAgent), "My Class button not visible");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaAppearsInTaskNotes(teachermodeAutomationAgent));
                    bool hidden = TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent);
                    if (hidden == false)
                    {
                        TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                        TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    }
                    TeacherModeCommonMethods.ClickOnCanvasToAddNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.SendText(teachermodeAutomationAgent, "Test");
                    Assert.IsTrue(bool.Parse(TeacherModeCommonMethods.VerifyCreateButtonActive(teachermodeAutomationAgent)), "Create button not active");
                    TeacherModeCommonMethods.ClickCreateInAddNotesOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonInCanvas(teachermodeAutomationAgent), "1. edit button not found");
                    TeacherModeCommonMethods.ClickMyClassButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent), "1. edit button found on screen");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassAreaAppers(teachermodeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentIconInMyClassArea(teachermodeAutomationAgent), "student icon not found");
                    TeacherModeCommonMethods.ClickStudentIconInMyClass(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information not found");
                    CommonReadCommonMethods.ClickOnDoneButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickMyTaskNotesButton(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditButtonHiddenInCanvas(teachermodeAutomationAgent), "2. edit button found on screen");
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickEditInCanvas(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickDeleteInEditYourNotes(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(teachermodeAutomationAgent);
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(25470), WorkItem(22432), WorkItem(22430)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTeacherModeWhileNavigatingToDashboard()
        {
            using (teachermodeAutomationAgent = new AutomationAgent("MTC32: TeacherMode - Closes when moves to Dashboard / ELA"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    DashboardCommonMethods.ClickContinueLessonButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(2000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content visible");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content not visible");
                    NavigationCommonMethods.NavigateMyDashboard(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(1000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideContentDisplayed(teachermodeAutomationAgent), "Teacher guide content visible");
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(teachermodeAutomationAgent), "User is not on dashboard");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(teachermodeAutomationAgent), "Class roster not found");
                    DashboardCommonMethods.ClickClassRosterInDashboard(teachermodeAutomationAgent);
                    NavigationCommonMethods.ClickLessonBrowserBackButton(teachermodeAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(teachermodeAutomationAgent), "User is not on dashboard");
                    DashboardCommonMethods.ClickClassRosterInDashboard(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyClassRosterOpened(teachermodeAutomationAgent), "Class roster not opened");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterPageHeader(teachermodeAutomationAgent), "Class roster page controls not verified");
                    Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterStudentNameAndAvatar(teachermodeAutomationAgent), "Class roster student name tile and avatar controls not verified");
                    DashboardCommonMethods.ScrollClassRosterVertically(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickStudentTileInClassRoster(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information not found");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationControls(teachermodeAutomationAgent), "student information controls not found");
                    TeacherModeCommonMethods.ClickOnBackButtonStudentInformationPage(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep(2000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(teachermodeAutomationAgent), "student information still found");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(2)]
        [WorkItem(33956), WorkItem(31786)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNoContentAvailableTaskGuideDisableForFirstAndLastTask()
        {

            using (teachermodeAutomationAgent = new AutomationAgent("MTC33: TeacherMode - Content Unavailable / First and Last page"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(teachermodeAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "BlankTeacherContent");
                    NavigationCommonMethods.NavigateToELAGrade(teachermodeAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(teachermodeAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(teachermodeAutomationAgent, taskInfo.Lesson);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(teachermodeAutomationAgent);
                    teachermodeAutomationAgent.Sleep();
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNoContentNotice(teachermodeAutomationAgent), "Content Unavailable This content is not currently available: is not appearing");
                    taskInfo = login.GetTaskInfo("ELA", "FirstTaskPage");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teachermodeAutomationAgent, taskInfo);
                    TeacherModeCommonMethods.ClickOnTeacherGuideIcon(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickTaskGuideInTeacherGuideOverlay(teachermodeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyPreviousButtonDisabledForFirstTask(teachermodeAutomationAgent), "Previous button is not disabled");
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    taskInfo = login.GetTaskInfo("ELA", "LastTaskPage");
                    NavigationCommonMethods.NavigateToTaskPageInLesson(teachermodeAutomationAgent, taskInfo.TaskNumber);
                    TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon(teachermodeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLastButtonDisabledForFirstTask(teachermodeAutomationAgent), "Next button is not disabled");
                    NavigationCommonMethods.Logout(teachermodeAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachermodeAutomationAgent.Sleep(2000);
                    teachermodeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachermodeAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
