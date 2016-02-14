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
    public class InteractiveTests
    {
        public AutomationAgent interactiveAutomationAgent;
        public InteractiveTests()
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(22305)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OpenInteractiveFromLesson()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC22305: Open interactive from a lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));

                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyInteractiveAppChromeVisible(interactiveAutomationAgent));
                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyTopLeftDoneButton(interactiveAutomationAgent));
                    Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookIconAtTopRight(interactiveAutomationAgent), "Send To Notebook Icon is not present at top right");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(22307)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CloseInteractiveOpenedFromWithinLessonUsingDoneButton()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC22307: Close interactive opened from within a lesson using [Done] button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));

                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyInteractiveAppChromeVisible(interactiveAutomationAgent));
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    Assert.AreEqual<bool>(false, InteractiveCommonMethods.VerifyInteractiveAppChromeVisible(interactiveAutomationAgent));
                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyLessonTaskPage(interactiveAutomationAgent));
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(3)]
        [WorkItem(23923)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeOpensWhenTeacherIsOnInteractiveLesson()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23923: Teacher mode opens, when teacher is on Interactive Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));

                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyLessonTaskPage(interactiveAutomationAgent));
                    InteractiveCommonMethods.ClickOnTeacherModeIcon(interactiveAutomationAgent);
                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyTeacherModeOpen(interactiveAutomationAgent));
                    InteractiveCommonMethods.ClickOnTeacherModeIcon(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(3)]
        [WorkItem(23924)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeIsOpenedWhenIOpenInteractiveInLessonThenTeacherStaysOpened()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23924: Teacher mode is opened, when I open an Interactive in a lesson then teacher stays opened"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    InteractiveCommonMethods.ClickOnTeacherModeIcon(interactiveAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeOpened(interactiveAutomationAgent));
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    Assert.AreEqual<bool>(true, InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent));
                    InteractiveCommonMethods.ClickOnTeacherModeIcon(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23165)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SavingInteractivesSaveNewInteractiveAfterEditingIt()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23165: Saving Interactives - save new interactive after editing it"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive is not open");
                    Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookIconAtTopRight(interactiveAutomationAgent), "Send To Notebook icon is not at top right");
                    InteractiveCommonMethods.MarkBoxInInteractive(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive is still open");
                    NotebookCommonMethods.VerifyNotebookOpen(interactiveAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveAtCenterOfNotebook(interactiveAutomationAgent), "Interactive not at center of the notebook");
                    NotebookCommonMethods.ClickEraseIconInNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23265)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SendToNotebookButtonIsNotVisibleWhenInteractiveOpenedFromNotebook()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23265: Saving Interactives - [Send to Notebook] button is NOT visible when interactive is opened from Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveThumbnailPresent(interactiveAutomationAgent), "Interactive thumbnail not present");
                    NotebookCommonMethods.ClickInteractiveThumbnail(interactiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive not open");
                    Assert.IsFalse(InteractiveCommonMethods.VerifySendToNotebookIconPresent(interactiveAutomationAgent), "Send To Notebook icon is still present");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23271)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesTimeStampIsNotUpdatedWhenNoEditsAreMade()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23271: Saving Interactives - time stamp is NOT updated when no edits are made"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveThumbnailPresent(interactiveAutomationAgent), "Interactive thumbnail not present");
                    string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime(interactiveAutomationAgent);
                    NotebookCommonMethods.VerifyXIconPresent(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickInteractiveThumbnail(interactiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive not open");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime(interactiveAutomationAgent);
                    Assert.AreEqual(TextBefore, TextAfter);
                    NotebookCommonMethods.ClickEraseIconInNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23167)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesMoveInteractiveRegion()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23167: Saving Interactives - move interactive region"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveThumbnailPresent(interactiveAutomationAgent), "Interactive thumbnail not present");
                    string position = NotebookCommonMethods.GetPositionOfDesmos(interactiveAutomationAgent);
                    NotebookCommonMethods.MoveDesmosInNoteBook(interactiveAutomationAgent);
                    string newPosition = NotebookCommonMethods.GetPositionOfDesmos(interactiveAutomationAgent);
                    Assert.AreNotEqual(position, newPosition, "Desmos didn't move");
                    NotebookCommonMethods.ClickEraseIconInNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23164)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SaveNewInteractiveWithoutEditing()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23164: Saving Interactives - save new interactive without editing"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive is still open");
                    NotebookCommonMethods.VerifyNotebookOpen(interactiveAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveAtCenterOfNotebook(interactiveAutomationAgent), "Interactive in the notebook not at center");
                    NotebookCommonMethods.ClickEraseIconInNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23169)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DeleteInteractiveRegion()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23169: Saving Interactives - delete interactive region"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveThumbnailPresent(interactiveAutomationAgent), "Interactive thumnail not present in the notebook");
                    NotebookCommonMethods.ClickOnXIcon(interactiveAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyInteractiveThumbnailPresent(interactiveAutomationAgent), "Interactive thumnail is still present in the notebook");
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23163)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifySendToNotebookIconAlert()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23163: Saving Interactives - verify [send to Notebook] icon alert"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    InteractiveCommonMethods.OpenInteractive(interactiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookIconAtTopRight(interactiveAutomationAgent), "Send To Notebook Icon is not at the top right corner");
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.VerifySaveInteractivePopUp(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickCancel(interactiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive is not open");
                    InteractiveCommonMethods.ClickSendToNotebookIcon(interactiveAutomationAgent);
                    InteractiveCommonMethods.ClickContinue(interactiveAutomationAgent);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveOpen(interactiveAutomationAgent), "Interactive is still open");
                    NotebookCommonMethods.VerifyNotebookOpen(interactiveAutomationAgent);
                    NotebookCommonMethods.VerifyInteractiveAtCenterOfNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(interactiveAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(1)]
        [WorkItem(23887)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyInteractiveAutoSaves()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23887: 2D interactive auto-saves every 30 seconds"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    interactiveAutomationAgent.SetDefaultClickDownTime();
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    InteractiveCommonMethods.EditMathInteractive(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(30000);
                    interactiveAutomationAgent.ApplicationClose();
                    interactiveAutomationAgent.Sleep();
                    interactiveAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(30000);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyEditedInteractiveState(interactiveAutomationAgent), "Interactive is not auto-saved");
                    InteractiveCommonMethods.EditMathInteractive(interactiveAutomationAgent, true);
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(3)]
        [WorkItem(23888)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyInteractiveSavesOnExit()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23888: 2D interactive - saves on exit"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    interactiveAutomationAgent.SetDefaultClickDownTime();
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    InteractiveCommonMethods.EditMathInteractive(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(28000);
                    interactiveAutomationAgent.ApplicationClose();
                    interactiveAutomationAgent.Sleep();
                    interactiveAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(30000);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyEditedInteractiveState(interactiveAutomationAgent), "Interactive is not auto-saved");
                    InteractiveCommonMethods.EditMathInteractive(interactiveAutomationAgent, true);
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(3)]
        [WorkItem(23889)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyInteractiveSavesUserBasis()
        {

            using (interactiveAutomationAgent = new AutomationAgent("TC23889: 2D interactive - saves PER USER"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    interactiveAutomationAgent.SetDefaultClickDownTime();
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    InteractiveCommonMethods.EditMathInteractive(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(28000);
                    interactiveAutomationAgent.ApplicationClose();
                    interactiveAutomationAgent.Sleep();
                    interactiveAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(30000);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyEditedInteractiveState(interactiveAutomationAgent), "Interactive is not auto-saved");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);

                    Login login2 = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(interactiveAutomationAgent, login2);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(interactiveAutomationAgent, login.GetTaskInfo("Math", "Interactive"));
                    InteractiveCommonMethods.ClickOnInteractiveThumbnailMathTask(interactiveAutomationAgent);
                    interactiveAutomationAgent.Sleep(30000);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyEditedInteractiveState(interactiveAutomationAgent), "Interactive is not auto-saved");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(interactiveAutomationAgent);
                    NavigationCommonMethods.Logout(interactiveAutomationAgent);
                }
                catch (Exception ex)
                {
                    interactiveAutomationAgent.Sleep(2000);
                    interactiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    interactiveAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
