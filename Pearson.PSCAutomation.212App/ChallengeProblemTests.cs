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
    public class ChallengeProblemTests
    {
        public AutomationAgent ChallengeProblemAutomationAgent;
        public ChallengeProblemTests()
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19455)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SystemDisplaysChallengeProblemButtonAndUserIsAllowedToAccessIt()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19455: 1/2. System displays challenge problem (button) and user is allowed to access it"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    Assert.AreEqual<bool>(true, ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.AreEqual<bool>(true, ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19456)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ChallengeProblemNotebookIsIndependentFromNotebookInTask()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19456: 5.2.3. Challenge Problem notebook is independent from the notebook in Task"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(ChallengeProblemAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(ChallengeProblemAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(ChallengeProblemAutomationAgent, "Sample text for testing");
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.CloseKeyboard();
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone(ChallengeProblemAutomationAgent);
                    Assert.AreEqual<bool>(false, WordsInTextBox.Contains("Sample text for testing"));
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19462)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ChallengeProblemCanBeClosedWhileNotebookIsDisplaying()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19462: 5.2.4. Challenge Problem - can be closed, while notebook is displaying"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(ChallengeProblemAutomationAgent);
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    ChallengeProblemAutomationAgent.Sleep(4000);
                    Assert.IsFalse(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    NotebookCommonMethods.VerifyNotebookOpen(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent));
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19458)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ChallengeProblemOpensAsOverlayWithSlideUpTransitionAndDoneAndnotebookIconOnChrome()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19458: Challenge problem opens as a overlay with slide up transition and Done & notebook icon on chrome"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyNotebookIcon(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19459)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DoneButtonFunctionalityInChallengeProblemSlideDownTransition()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19459: 5.1. Done button functionality in challenge problem - slide down transition"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    ChallengeProblemAutomationAgent.Sleep(1000);
                    Assert.IsFalse(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent));
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19461)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookBehaviorInChallengeProblemPageResizedNotebookClosesAfterTappingOutside()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19461: 5.2.1/2. Notebook behavior in Challenge Problem - page resized, Notebook closes after you tapped outside"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(ChallengeProblemAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(ChallengeProblemAutomationAgent, 74, 329, 1);
                    NotebookCommonMethods.VerifyNotebookNotOpen(ChallengeProblemAutomationAgent);
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19465)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ChallengeProblemOpensFullscreenEvenIfNotebookWasOpenedWhenTappingChallengeProblemButton()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19465: 4.1.Challenge Problem - opens fullscreen, even if notebook was opened when you tapped Challenge Problem button"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(ChallengeProblemAutomationAgent);
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    NotebookCommonMethods.VerifyOpenNotebookButton(ChallengeProblemAutomationAgent);
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(2)]
        [WorkItem(19460)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ChallengeProblemTitleShouldSayChallengeProblem()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC19460:5.3. challenge problem title should say: Challenge Problem"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemTitleInCenter(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(2)]
        [WorkItem(20475)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ThreeContextIconsAreToolsGamesNotebookTeacherContentIcon()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC20475:4. Three context icons are: tools & games, notebook, teacher content icon"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(ChallengeProblemAutomationAgent));
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyNotebookIcon(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ChallengeProblemTests")]
        [Priority(3)]
        [WorkItem(21741)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GivenTeacherModeOpenedWhenIOpenChallengeProblemThenTeacherModeStaysOpened()
        {

            using (ChallengeProblemAutomationAgent = new AutomationAgent("TC21741: GIVEN teacher mode is opened, WHEN I open a Challenge Problem THEN teacher mode stays opened"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyTeacherModeOpen(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyTeacherModeOpen(ChallengeProblemAutomationAgent));
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [Priority(1)]
        [WorkItem(19455), WorkItem(19456), WorkItem(19462), WorkItem(19458), WorkItem(19459), WorkItem(19461), WorkItem(19465), WorkItem(19460), WorkItem(20475), WorkItem(21741)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ChallengeProblemBasicTestCases()
        {
            using (ChallengeProblemAutomationAgent = new AutomationAgent("MTC20: ChallengeProblem - Multiple challenge problem test cases"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(ChallengeProblemAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(ChallengeProblemAutomationAgent, login.GetTaskInfo("Math", "ChallengeProblem"));
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent), "1. ChallengeProblem button doesn't exist");
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyTeacherModeOpen(ChallengeProblemAutomationAgent), "1. Teacher mode isn't opened");
                    ChallengeProblemCommonMethods.ClickChallengeProblemButton(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(ChallengeProblemAutomationAgent), "Teacher mode icon is not present");
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyTeacherModeOpen(ChallengeProblemAutomationAgent), "2. Teacher mode isn't opened");
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyResourceLibraryIcon(ChallengeProblemAutomationAgent), "Resource library icon isn't present");
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(ChallengeProblemAutomationAgent), "1. Notebook isn't opened");
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent), "ChallengeProblem page isn't opened");
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemTitleInCenter(ChallengeProblemAutomationAgent), "ChallengeProblem title isn't in center");
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent), "Done button doesn't exist");
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyNotebookIcon(ChallengeProblemAutomationAgent), "Notebook icon is not present");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(ChallengeProblemAutomationAgent), "2. Notebook isn't opened");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(ChallengeProblemAutomationAgent), "Lesson window isn't split");
                    NotebookCommonMethods.TapOnScreen(ChallengeProblemAutomationAgent, 74, 329, 1);
                    ChallengeProblemAutomationAgent.Sleep(3000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookNotOpen(ChallengeProblemAutomationAgent), "1. Notebook is opened");
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(ChallengeProblemAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(ChallengeProblemAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(ChallengeProblemAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(ChallengeProblemAutomationAgent, "Sample text for testing");
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.CloseKeyboard();
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem(ChallengeProblemAutomationAgent);
                    ChallengeProblemAutomationAgent.Sleep(4000);
                    Assert.IsFalse(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(ChallengeProblemAutomationAgent), "ChallengeProblem is not closed");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookNotOpen(ChallengeProblemAutomationAgent), "2. Notebook is opened");
                    NotebookCommonMethods.ClickOnNotebookIcon(ChallengeProblemAutomationAgent);
                    Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(ChallengeProblemAutomationAgent), "1. ChallengeProblem button doesn't exist");
                    string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone(ChallengeProblemAutomationAgent);
                    Assert.IsFalse(WordsInTextBox.Contains("Sample text for testing"), "Notebook text exists");
                    NavigationCommonMethods.Logout(ChallengeProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    ChallengeProblemAutomationAgent.Sleep(2000);
                    ChallengeProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    ChallengeProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
