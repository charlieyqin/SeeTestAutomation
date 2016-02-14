using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    /// <summary>
    /// Summary description for NotebookTests
    /// </summary>
    [TestClass]
    public class NotebookTests
    {
        public AutomationAgent notebookAutomationAgent;
        public NotebookTests()
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
        #endregion

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16002)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void InsertExistingVideoFromCameraRollShorterIntoBlankNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16002: Insert existing video from camera roll shorter than 1min into the blank notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video watermark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22133)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CommonReadNotebookVerifyIfTitleBarColorIsBlue()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22133: Common Read Notebook - verify if title bar color is blue"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
                    Assert.AreEqual<string>("0x0031C3", NotebookCommonMethods.VerifyTitleBarOfNotebook(notebookAutomationAgent), "Title bar of notebook is not same");
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22423)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ClosingNotebookByTappingOnLesson()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22423: Closing notebook by tapping on Notebook Icon"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22465)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ClosingNotebookByTappingLesson()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22465: Closing notebook by tapping on Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    notebookAutomationAgent.ClickOnScreen(500, 500, 1);
                    NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16010)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NativeNotebookVideoThumbnailDisplayedInNotebookAfterUserAddsVideo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16010: Native notebook: Video thumbnail is displayed in the notebook after the user adds a video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video Thumbnail not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16013)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NativeNotebookHandModeActiveAfterVideoHasBeenInserted()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16013: Native notebook: The hand mode have to be active after video has been inserted"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent), "Hand Icon not active");
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand icon not active and higlighted");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1150, 400, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16014)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NativeNotebookVideoShouldPlayAfterTapPlayButton()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16014: Native notebook: Video should play after tap Play button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail not found");
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(notebookAutomationAgent);
                    DateTime startDateTime = DateTime.Now;
                    LessonBrowserCommonMethods.ClickPauseButtonInVideo(notebookAutomationAgent);
                    DateTime endDateTime = DateTime.Now;
                    Assert.IsTrue((endDateTime.CompareTo(startDateTime) > 0), "end date time and start date time is not greater than zero");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(19307)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosUndoRedoButtonAvailableInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19307: Desmos - Undo/ redo button is available in the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUndoRedoButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(19309)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosSubMenuOpensWhenTappingUndoRedoIconInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19309: Desmos - Sub menu opens when tapping the undo/ redo icon in the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUndoRedoButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUndoRedoSubMenu(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(19310)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosUndoRedoMenuClosesWhenTappingOutsideCanvas()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19310: Desmos - Undo/ redo menu closes when tapping outside the canvas"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyUndoRedoSubMenuFound(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1150, 400, 1);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyUndoRedoSubMenuFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20422)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ToolBarButtonCanBeAccessed()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20422: Tool bar button can be accessed"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }




        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16003)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void InsertVideoTakenDirectlyFromCamera()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16003: Insert video taken directly from notebook into the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.CreateVideoFromCamera(notebookAutomationAgent, 10000);
                    notebookAutomationAgent.Sleep(4000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video Watermark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16005)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void InsertVideoTakenDirectlyFromCamera60SecLimit()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16005:  Inserting video taken from notebook - 60 sec limit"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.CreateVideoFromCamera(notebookAutomationAgent, 70000);
                    notebookAutomationAgent.Sleep(4000);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16007)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VideoShouldStopPlayingWhenFinishesNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16007: Video should stops playing when video finishes playing"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.CreateVideoFromCamera(notebookAutomationAgent, 10000);
                    notebookAutomationAgent.Sleep(4000);
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(15000);
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16210)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LaunchingSnapshotTool()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16210: Launching snapshot tool"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCaptureSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16216)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void PastingSnapshotIntoNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16216: Pasting snapshot into the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCaptureSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSnapShotIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon Not Active and highlighted");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(15964)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenNotebookFromELALesson()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC15964: Open Notebook from ELA Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    Assert.IsTrue(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(notebookAutomationAgent), "Open Notebook Button not present");
                    NotebookCommonMethods.ClickOnOpenNotebookButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent), "Notebook splits lesson window not found");
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyNotebookIcon(notebookAutomationAgent), "Notebook Icon not present ");
                    Assert.IsFalse(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(notebookAutomationAgent), "Open notebook button present");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16023)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookToolbarActiveInactive()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16023: Notebook toolbar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyAllBottomToolbarsActiveInactive(notebookAutomationAgent), "Bottom Toolbar Active or Inactive not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(18616)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreatePersonalNotebookDefaultTitle()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18616: Create new Personal Notebook - Default title is My Personal Note (mm/dd/yy hh:mm: am/pm)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);

                    DateTime currentDate = DateTime.Now;
                    //currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"), "Notes default title doesn't contain My Personal Note");
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");
                    NotebookCommonMethods.ClickOnCreatePersonalNoteCancel(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18617)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreatePersonalNotebookUserCanChangeDefaultTitle()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18617: Create new Personal Notebook - User is able to change default title"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    DateTime currentDate = DateTime.Now;
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"), "Notes default title doesn't contains My Personal Note");
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");

                    NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, "MyTitle");
                    Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent).Contains("MyTitle"), "Persoanl Note title Doesn't contain MyTitle");
                    NotebookCommonMethods.ClickOnCreatePersonalNoteCancel(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18620)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CreatePersonalNotebookCreateButtonDisabledAndEnabledWhenTextEntered()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18620: Create new Personal Notebook - Create button disabled unless a character is entered in text field"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    DateTime currentDate = DateTime.Now;
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"));
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");

                    NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, " ");
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyCreateButtonPersonalNotesEnabled(notebookAutomationAgent));
                    NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, "MyTitle ");
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent).Contains("MyTitle"));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyCreateButtonPersonalNotesEnabled(notebookAutomationAgent));
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18622)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookEnterCreationDialogAndConfirm()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18622: Create new Personal Notebook - Enter Creation dialog and confirm"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    DateTime currentDate = DateTime.Now;
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"));
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");

                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent), "Personal Notebook not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18623)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookEnterCreationDialogAndCancel()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18623: Create new Personal Notebook - Enter Creation dialog and cancel"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    DateTime currentDate = DateTime.Now;
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"));
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");

                    NotebookCommonMethods.ClickOnCreatePersonalNoteCancel(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent), "Personal Note is present");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18625)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookVerifyChromeIconOrange()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18625: Create new Personal Notebook - Verify Chrome icon color (orange)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    DateTime currentDate = DateTime.Now;
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"));
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");

                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent));
                    Assert.AreEqual<string>("0xEF8700", NotebookCommonMethods.VerifyTitleBarOfNotebook(notebookAutomationAgent), "Notebook title color is not orange");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(18627)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OpenExistingPersonalNotebookVerifyChromeIconOrange()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18627: Open existing Personal Notebook - Verify Chrome icon color (orange)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickExistingPersonalNoteCell(notebookAutomationAgent);
                    Assert.AreEqual<string>("0xEF8700", NotebookCommonMethods.VerifyTitleBarOfNotebook(notebookAutomationAgent), "TitleBar of notebook is not orange");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18632)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void OpenExistingPersonalNotebookChangeTitleAndConfirm()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18632: Edit existing Personal Notebook Title - change title and confirm by dismissing keyboard"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.EditPersonalNotesTitle(notebookAutomationAgent, "MyTitle");
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent)), "Failed to get Keyboard Presence");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 400, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNewPersonalNotesTitle(notebookAutomationAgent, "MyTitle"), "Personal Note Title not the same");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18633)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EditExistingPersonalNotebookTitleChangeTitleAndConfirmByTappingOutsideTitleBar()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18633: Edit existing Personal Notebook Title - change title and confirm by tapping outside title bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.EditPersonalNotesTitle(notebookAutomationAgent, "MyTitle");
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent)), "Keyboard not present");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 400, 1);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNewPersonalNotesTitle(notebookAutomationAgent, "MyTitle"), "Personal Note Title not the same");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20151)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreateNewPersonalNotebookUserIsAbleToClearTitleUsingXIcon()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20151: Create new Personal Notebook - User is able to clear title using [x] icon"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    DateTime currentDate = DateTime.Now;
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);

                    string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"));
                    TimeSpan differnce = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
                    Assert.IsTrue(differnce.Minutes < 4, "Title Time is not same as current time");

                    NotebookCommonMethods.ClickXIconNewPersonalNote(notebookAutomationAgent);
                    string NotesTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
                    Assert.AreEqual(true, NotesTitle.Equals("My Personal Note\t\n"), "Notes title not My Personal Note");
                    NotebookCommonMethods.ClickOnCreatePersonalNoteCancel(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20378)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ToVerifyCancelWhileAddingImageFromPhotos()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20378: To Verify cancel while adding image from Photos"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, true);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Exists");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(20448)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ImagesShouldBeAddedInDefaultSize()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20448: Images should be added in default size"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon not active");
                    if (!NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent))
                    {
                        NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    }
                    notebookAutomationAgent.Sleep();
                    string ImageWidth = NotebookCommonMethods.ImageSizeInNoteBookBeforeResize(notebookAutomationAgent);
                    Assert.AreEqual<string>("600", ImageWidth, "Image width not the same");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20449)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ImagesShouldBeInsertedInCenterOfNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20449: The image should be inserted in the center of the notebook page"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon not active");
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyImageInCenterOfNotebook(notebookAutomationAgent), "Image not at center");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20450)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void HandModeShouldBeActiveAfterImageIsInserted()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20450: Hand mode should be active after the image is inserted"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon Not active");
                    if (!NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent))
                    {
                        NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    }
                    string PosBefore = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.MoveImageInNoteBook(notebookAutomationAgent);
                    string PosAfter = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
                    Assert.AreNotEqual(PosAfter, PosBefore, "Position not changed");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18634)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EditExistingPersonalNotebookTitleClearTitleAndAttemptToSaveIt()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18634: Edit existing Personal Notebook Title - clear title and attempt to save it"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPersonalNotesTitleInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent)), "Keyboard not present");
                    NotebookCommonMethods.ClickXIconInNotebookTitle(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickXIconInNotebookTitle(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 400, 1);
                    string text = NotebookCommonMethods.GetTextInsideElement(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, text.Contains("My Personal"), "Edited notebook title doesn't contain My Personal string");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16012)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NativeNotebookInsertedVideoCantBeResize()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16012: Native notebook: Inserted video can't be resize"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(8000);
                    int VideoWidthBefore = NotebookCommonMethods.GetWidthOfVideoInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ResizeVideo(notebookAutomationAgent);
                    int VideoWidthAfter = NotebookCommonMethods.GetWidthOfVideoInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(VideoWidthBefore, VideoWidthAfter, "Width not same");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22625)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BrowseNotesOverlayOverlayHeaderGoToWorkBrowser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22625: Browse Notes overlay - Overlay Header - Go to Work Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyGoToWorkBrowserButtonPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickGoToWorkBrowserButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWorkBrowserPageOpened(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22627)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BrowseNotesOverlayOverlayHeaderCloseOverlay()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22627: Browse Notes overlay - Overlay Header - Close overlay"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay not Present");
                    NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay Present");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22249)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyNotebookIconInTopTaskMenuHighlightedWhenUserClicksOpenNotebookButton()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22249: Verify that Notebook icon in Top Task menu is highlighted when user clicks on Open Notebook button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnOpenNotebookButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent), "Notebook doesn't split Lesson window");
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyNotebookIcon(notebookAutomationAgent), "notebook icon not present");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20387)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyImageDeletionAfterUploadingThruCameraByTappingDeleteIcon()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20387: To verify the image deletion after uploading thru Camera"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.DeletePicture(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Exists");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Exists");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20388)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyImageResizeRepositionAfterImageTakenThruCamera()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20388: To verify the image resize / reposition after image taken thru Camera"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    string widthBefore = NotebookCommonMethods.ImageSizeInNoteBookBeforeResize(notebookAutomationAgent);
                    NotebookCommonMethods.ResizeImageInNoteBook(notebookAutomationAgent);
                    string widthAfter = NotebookCommonMethods.ImageSizeInNoteBookAfterResize(notebookAutomationAgent);
                    Assert.AreNotEqual<string>(widthBefore, widthAfter, "Image not been resized");
                    string ImagePosBefore = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.MoveImageInNoteBook(notebookAutomationAgent);
                    string ImagePosAfter = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
                    Assert.AreNotEqual<string>(ImagePosBefore, ImagePosAfter, "Image not moved");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20390)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyTheImageResizeRepositionAfterImageAddedThruPhotos()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20390: To verify the image resize / reposition after image added thru Photos"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    string widthBefore = NotebookCommonMethods.ImageSizeInNoteBookBeforeResize(notebookAutomationAgent);
                    NotebookCommonMethods.ResizeImageInNoteBook(notebookAutomationAgent);
                    string widthAfter = NotebookCommonMethods.ImageSizeInNoteBookAfterResize(notebookAutomationAgent);
                    Assert.AreNotEqual<string>(widthBefore, widthAfter, "Image not been resized");
                    string ImagePosBefore = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.MoveImageInNoteBook(notebookAutomationAgent);
                    string ImagePosAfter = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
                    Assert.AreNotEqual<string>(ImagePosBefore, ImagePosAfter, "Image not moved");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(20806)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosSendToNotebbokIconDisplayed()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20806: Desmos - [Send to Notebbok] icon is displayed when opening Desmos from Notebook toolbar button"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, taskInfo);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyGlobalNavBarPresentInMathLesson2(notebookAutomationAgent, taskInfo.Title));
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyDesmosTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyGlobalNavBarPresentInMathLesson2(notebookAutomationAgent, taskInfo.Title));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(20808)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosDoneButtonTriggersAlertMessage()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20808: Desmos - [Done] button triggers alert message in newly created Desmos"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(20809)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosAlertMessageCancelButtonBringsBackToDesmos()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20809: Desmos - alert message - [Cancel] button brings user back to Desmos"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(20810)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosAlertMessageContinueButtonClosesDesmosWithoutSavingChanges()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20810: Desmos - alert message - [Continue] button closes Desmos without saving changes"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(20807)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosSendToNotebookIconNotDisplayedWhenOpeningDesmosFromThumbnailNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20807: Desmos - [Send to Notebbok] icon is NOT displayed when opening Desmos from thumbnail in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    Assert.AreEqual(false, NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19315)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosMoveDesmosInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19315: Desmos - Move Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent));
                    string DesmosPosBefore = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.MoveDesmosInNoteBook(notebookAutomationAgent);
                    string DesmosPosAfter = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    Assert.AreNotEqual<string>(DesmosPosBefore, DesmosPosAfter);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19316)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosDeleteDesmosInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19316: Desmos - Delete Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickTextRegionDeleteXIcon(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19318)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UndoMoveImageInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19318: Native notebook: Undo moved image"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent));
                    string DesmosPosBeforeUndo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.MoveDesmosInNoteBook(notebookAutomationAgent);
                    string DesmosPosBeforeRedo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1250, 600, 1);
                    string DesmosPosAfterUndo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    Assert.AreEqual<string>(DesmosPosBeforeUndo, DesmosPosAfterUndo);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1250, 600, 1);
                    string DesmosPosAfterRedo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    Assert.AreEqual<string>(DesmosPosBeforeRedo, DesmosPosAfterRedo);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19319)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosUndoRedoDeleteDesmosInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19319: Desmos - Undo/Redo Delete Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickTextRegionDeleteXIcon(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 140, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19320)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosUndoRedoSaveDesmosInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19320: Desmos - Undo/Redo Save Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 140, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19317)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosEditDesmosInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19317: Desmos - Edit Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    Assert.AreEqual(false, NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.EditDesmos(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(60000);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    Assert.AreNotEqual(TextBefore, TextAfter);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20508)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookPreviewGlobalNavDismissPreviewUsingDoneButton()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20508: Notebook Preview - Global Nav - dismiss preview using [Done] button"))
            {
                try
                {
                    NavigationCommonMethods.Login(notebookAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
                    notebookAutomationAgent.Sleep();
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSnapshotDone(notebookAutomationAgent), "Notebook Snapshot Done button not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyDoneButtonAtUpperLeftCorner(notebookAutomationAgent), "Done button not at Upper Left corner");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.VerifyWorkBrowserPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(15965)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenNotebookFromMathLesson()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC15965: Open Notebook from Math Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "OpenNotebookButton"));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyOpenNotebookButtonMathPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnOpenNotebookButtonMath(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent), "Window not splited");
                    Assert.AreEqual("True", NotebookCommonMethods.VerifyNotebookIcon(notebookAutomationAgent), "Notebook icon not present");
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyOpenNotebookButtonMathPresent(notebookAutomationAgent), "Open Notebook button present");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23166)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesVerifyTitleThumbnailAndTimeStamp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23166: Saving Interactives - verify title, thumbnail and time stamp"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    string DtCurrent = DateTime.Now.ToString("h:mmtt").ToLower();
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(notebookAutomationAgent));
                    string TextDesmos = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    Assert.AreEqual(true, TextDesmos.Contains("Interactive"));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    Assert.AreEqual(true, TextDesmos.Contains(DtCurrent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23258)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesInteractiveRegionIsNOTResizable()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23258: Saving Interactives - interactive region is NOT resizable"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string widthBefore = NotebookCommonMethods.GetDesmosSize(notebookAutomationAgent);
                    NotebookCommonMethods.ResizeDesmosInNoteBook(notebookAutomationAgent);
                    string widthAfter = NotebookCommonMethods.GetDesmosSize(notebookAutomationAgent);
                    Assert.AreEqual<string>(widthBefore, widthAfter);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(23262)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractiveToNotebookDoesntAffectLessonInteractiveState()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23262: Saving Interactives - saving interactive to Notebook does not affect lesson interactive state"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.EditDesmos(notebookAutomationAgent);
                    string DtCurrent = DateTime.Now.ToString("HH:mm").ToLower();
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextDesmos = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    Assert.AreEqual(true, TextDesmos.Contains("Interactive: Graphing Calculator"));
                    Assert.AreEqual(true, TextDesmos.Contains(DtCurrent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23263)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesCloseInteractiveOpenedFromNotebookInHalfScreenMode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23263: Saving Interactives - close interactive opened from Notebook in half screen mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInteractiveThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23269)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesEditNotebookInteractiveNewStateReplacesTheOldOne()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23269: Saving Interactives - edit Notebook interactive - new state replaces the old one"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                    NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
                    notebookAutomationAgent.Sleep(60000);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    Assert.AreNotEqual(TextBefore, TextAfter);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(23270)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesTimeStampIsUpdatedWhenEditsAreMade()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23270: Saving Interactives - time stamp is updated when edits are made"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                    NotebookCommonMethods.EditDesmos(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    Assert.AreNotEqual(TextBefore, TextAfter);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(23272)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesVerify3dInteractiveSnapshotIsGenericImage()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23272: Saving Interactives - verify 3d interactive snapshot is a generic image"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.EditDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(notebookAutomationAgent));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23273)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesSaveMultipleLessonInteractivesToSameNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23273: Saving Interactives - save multiple lesson interactives to the same Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    int firstPage = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent);
                    int newPage = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    Assert.AreEqual(newPage, (firstPage + 1));
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23274)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesSavedInteractivePlacedInNewlyAddedPageAfterLastActiveOne()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23274: Saving Interactives - saved interactive is placed in newly added page, after last active one"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    int CurrentPageNo = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    int i = CurrentPageNo;
                    for (; i <= 3; i++)
                    {
                        if (i != CurrentPageNo)
                        {
                            NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                        }
                        NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);
                        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1250, 650, 1);
                    }
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 155, 1);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    string PageNoWithCurrentPage = NotebookCommonMethods.GetNoteBookPageNosWithCurrentPage(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    Assert.AreEqual(PageNoWithCurrentPage, "(" + (i - 1).ToString() + "/" + i.ToString() + ")");
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(19311)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosSelectionDefaultsToHandModeWhenUndoRedoMenuClosesWhenTappingOutsideCanvas()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19311: Desmos - Selection defaults to hand mode when Undo/ redo menu closes when tapping outside the canvas"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyUndoRedoSubMenuFound(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1150, 400, 1);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyUndoRedoSubMenuFound(notebookAutomationAgent));
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent));
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22626)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void BrowseNotesOverlayHeaderHeadingIsBrowseNotes()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22626: Browse Notes overlay - Overlay Header - verify heading is Browse Notes"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay Not Present");
                    Assert.IsTrue(NotebookCommonMethods.VerifyOverlayHeading(notebookAutomationAgent), "Overlay heading not as expected");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20514)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookPreviewHeaderVerifyIfTaskTitleIsCorrect()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20514: Notebook Preview - Header - verify if task title is correct"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTile(notebookAutomationAgent, taskName), "Notebook title is not similar");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22639)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookPreviewWorkBrowserWorkflowFix()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22639: Notebook Preview / Work Browser Workflow fix"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTile(notebookAutomationAgent, taskName), "Notebook title is not similar");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20518)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNotebookPaginationInFullscreenView()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20518: Verify pagination/numbering in full screen spread view in notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);

                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    int indexOfBracket = taskName.IndexOf("(");
                    string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(3/3)", "Page number is not 3/3");

                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/3)", "page number is not 2/3");
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(3/3)", "page number is not 3/3");

                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(1/3)", "page number is not 1/3");
                    Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/3)", "page number is not 2/3");
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(3/3)", "page number is not 3/3");

                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20517)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNotebookPagination()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20517: Verify if pagination arrows work correctly in notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);

                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20519)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAddingPagesWorkCorrectly()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20519: Verify if adding pages works correctly"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);

                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);

                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    int indexOfBracket = taskName.IndexOf("(");
                    string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/2)", "page number is not 2/2");

                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/3)", "page number is not 2/3");

                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent), "2. left arrow doesn't exist");
                    Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent), "2. right arrow doesn't exist");

                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent), "2a. left arrow doesn't exist");
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(1/3)", "page number is not 1/3");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    Assert.AreEqual<string>("First Page", NotebookCommonMethods.GetTextBoxContent(notebookAutomationAgent, "First Page"), "Text box content is not the same");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);

                    Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent), "3. left arrow doesn't exist");
                    Assert.IsFalse(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent), "3. left arrow doesn't exist");
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(3/3)", "page number is not 3/3");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    Assert.AreEqual<string>("Second Page", NotebookCommonMethods.GetTextBoxContent(notebookAutomationAgent, "Second Page"), "text box content is not the same");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);

                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(19303)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosToolBarButtonIsAvailableInTheNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19303: Desmos - Tool bar button is available in the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWrenchIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19304)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DesmosSubMenuOpensWhenTappingWrenchIconInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19304: Desmos - Sub menu opens when tapping the wrench icon in the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWrenchToolSubMenuExists(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19306)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")] 
        public void DesmosToolAvailableWhenTappingWrenchIconInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19306: Desmos - Desmos tool is available when tapping the wrench icon in the notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyDesmosTool(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(20811)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AlertsDoneButtonTriggersAlertMessageInNewlyCreatedDesmos()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20811: Alerts - [Done] button triggers alert message in newly created Desmos"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAlertMessageButtons(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent));
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23168)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesUndoRedoMoveInteractiveRegion()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23168: Saving Interactives - undo/redo move interactive region"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    string DesmosPosBeforeUndo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.MoveDesmosInNoteBook(notebookAutomationAgent);
                    string DesmosPosBeforeRedo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1250, 600, 1);
                    string DesmosPosAfterUndo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    Assert.AreEqual<string>(DesmosPosBeforeUndo, DesmosPosAfterUndo);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1250, 600, 1);
                    string DesmosPosAfterRedo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    Assert.AreEqual<string>(DesmosPosBeforeRedo, DesmosPosAfterRedo);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23170)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SavingInteractivesUndoRedoDeleteInteractiveRegion()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23170: Saving Interactives - undo/redo delete interactive region"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextRegionDeleteXIcon(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 140, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20516)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookPreviewHeaderVerifyIfPageNumberingWorksCorrectly()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20516: Notebook Preview - Header - verify if page numbering works correctly"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName2 = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickSec34Tile(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickSec34Tile(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
                    int pageno = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    while (pageno < 3)
                    {
                        NotebookCommonMethods.ClickOnNotebookAddPage(notebookAutomationAgent);
                        pageno = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    }
                    int firstpageno = NotebookCommonMethods.GetNotebookFirstPage(notebookAutomationAgent);
                    while (firstpageno > 1)
                    {
                        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                        firstpageno = NotebookCommonMethods.GetNotebookFirstPage(notebookAutomationAgent);
                    }
                    string s = NotebookCommonMethods.GetNoteBookPageNosWithCurrentPage(notebookAutomationAgent);
                    Assert.AreEqual(s, "(" + (firstpageno).ToString() + "/" + pageno + ")");
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19321)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosSaveMultipleDesmosInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19321: Desmos - Save multiple Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string PosDesmos1 = null;
                    string widthDesmos1 = null;
                    for (int i = 1; i < 4; i++)
                    {
                        NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                        NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                        NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                        NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                        Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent));
                        if (i == 1)
                        {
                            PosDesmos1 = NotebookCommonMethods.GetPositionOfDesmos(notebookAutomationAgent);
                            widthDesmos1 = NotebookCommonMethods.GetWidthOfDesmos(notebookAutomationAgent);
                        }
                        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                        int indexOfBracket = taskName.IndexOf("(");
                        string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                        Assert.AreEqual<string>(pageNumber, "(" + i + "/" + i + ")");
                        if (i != 1)
                        {
                            string PosDesmos = NotebookCommonMethods.GetPositionOfDesmos(notebookAutomationAgent);
                            string widthDesmos = NotebookCommonMethods.GetWidthOfDesmos(notebookAutomationAgent);
                            Assert.AreEqual(PosDesmos, PosDesmos1);
                            Assert.AreEqual(widthDesmos, widthDesmos1);

                        }
                    }
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20399)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyMultipleImagesAddedOnMultiplePages()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20399: To verify multiple images added on multiple pages"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doen't exists");
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent));
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    int indexOfBracket = taskName.IndexOf("(");
                    string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/2)");
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo doesn't exists");
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16004)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InsertExistingVideoLongerThan1minIntoBlankNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16004: Native notebook: Insert existing video longer than 1min into the blank notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, true);
                    notebookAutomationAgent.Sleep(17000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video Thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video watermark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16009)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void PressingHOMEButtonDuringInsertingTakenVideo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16009: Native notebook: Pressing HOME button during inserting taken video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.SendText("{HOME}");
                    notebookAutomationAgent.Sleep();
                    notebookAutomationAgent.LaunchApp();
                    notebookAutomationAgent.Sleep();
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video Thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video watermark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16011)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OverlappingVideo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16011: Native notebook: Overlapping video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent, "0"), "Video thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent));
                    string VideoPos1 = NotebookCommonMethods.GetPositionOfVideo(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyVideoAtCenterOfNotebook(notebookAutomationAgent), "Video not at the center of the notebook");
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent, "1"), "Video thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video Watermark not found");
                    string VideoPos2 = NotebookCommonMethods.GetPositionOfVideo(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyVideoAtCenterOfNotebook(notebookAutomationAgent), "Video not at the center of notebook");

                    Assert.AreEqual(VideoPos1, VideoPos2);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20511)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyIfLessonTitleIsCorrectForPreviewedNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20511: Notebook Preview - Global Nav - verify if lesson title is correct for previewed Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    string LessonTaskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NavigationCommonMethods.ClickCommonReadInMyClass(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
                    notebookAutomationAgent.Sleep();
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTile(notebookAutomationAgent, LessonTaskName), "Notebook title not the same");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16019)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void RedoDeletedVideo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16019: Native notebook: Redo deleted video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video Thumbnail not found");
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnXIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video Thumbnail found");
                    NotebookCommonMethods.ClickOnUndoRedoIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail not found");
                    Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyRedoButtonActive(notebookAutomationAgent), "Redo button Inactive");
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail found");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23928)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void InsertExistingVideoWatermarkPlayButtonColorIsDifferentForELAAndMath()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23928: Insert existing video - watermark [Play] button color is different for ELA nad Math"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyVideoBlueWaterMark(notebookAutomationAgent));
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyVideoGreenWaterMark(notebookAutomationAgent));
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16001)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyVideoPopupInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16001: Video popup should be available"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnOpenNotebookButton(notebookAutomationAgent);

                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);

                    NotebookCommonMethods.VerifyCameraAndPhotosMenu(notebookAutomationAgent);

                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video Thumbnail not found");

                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doen't exist");

                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);

                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(23257)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SavingInteractivesHandModeIsDefaultAfterSavingInteractiveToNotebook()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC23257: Saving Interactives - hand mode is default after saving interactive to Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageOpen(notebookAutomationAgent));
                    NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyInteractivePageOpen(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveAtCenterOfNotebook(notebookAutomationAgent));
                    Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29892)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ToolsVerifyIfAllToolsAreAvailableInMathNotebook()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29892: Tools - verify if all tools are available in Math Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickSec34Tile(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAllNotebookTools(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29893)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyDeleteIconAppearsOnClickingImageAndDisappearsOnTappingOutside()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29893: Tools - verify delete icon appears on clicking image and disappears on tapping outside"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyImageXIconPresent(notebookAutomationAgent));
                    NotebookCommonMethods.MoveImageInNoteBook(notebookAutomationAgent);
                    Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyImageXIconNotPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29894)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyTextIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29894: Tools - verify Text icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29895)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyBookIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29895: Tools - verify Book icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickFullScreenIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookFullScreenWindow(notebookAutomationAgent), "Full screen not appearing");
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySinglePageViewOfNotebookInWorkBrowser(notebookAutomationAgent), "Single page not appearing");
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29903)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAddPageIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29903: Tools - verify Add Page icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSec34Tile(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookAddPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 810, 760, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 840, 790, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "TEST");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 800, 600, 1);
                    string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, WordsInTextBox.Contains("TEST"));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29904)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDeleteIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29904: Tools - verify Delete icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookAddPage(notebookAutomationAgent);
                    int pageNoBefore = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickDeleteIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDeleteIconPopUp(notebookAutomationAgent));
                    NotebookCommonMethods.ClickCancelInDeleteIconPopUp(notebookAutomationAgent);
                    int pageNoAfter = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    Assert.AreEqual(pageNoAfter, pageNoBefore);
                    NotebookCommonMethods.ClickDeleteIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueInDeleteIconPopUp(notebookAutomationAgent);
                    int newPageNo = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
                    Assert.AreNotEqual(pageNoBefore, newPageNo);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29902)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyUndoRedoIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29902: Tools - verify Undo/Redo icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnUndoRedoIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUndoRedoSubMenu(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29900)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyToolIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29900: Tools - verify Tool icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnOtherGrades(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnMathNotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWrenchToolSubMenuExists(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29899)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyImagePhotosIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29899: Tools - verify Image Photos icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    Assert.IsTrue(NotebookCommonMethods.VerifyImageThumbnailInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29898)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyImageCameraIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29898: Tools - verify Image Camera icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSec34Tile(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyImageThumbnailInNotebook(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29901)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyBackgroundToolIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29901: Tools - verify Background tool icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSec34Tile(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickBackgroundIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyBackgroundTools(notebookAutomationAgent));
                    NotebookCommonMethods.SelectRuledGraphBackground(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyRuledGraphNotebookBackground(notebookAutomationAgent));
                    NotebookCommonMethods.ClickBackgroundIcon(notebookAutomationAgent);
                    NotebookCommonMethods.SelectBlankBackground(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29896)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyPencilIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29896: Tools - verify Pencil icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerfiyDrawingIconSubmenus(notebookAutomationAgent));
                    NotebookCommonMethods.DrawLineInNotebook(notebookAutomationAgent, 810, 790);
                    notebookAutomationAgent.Sleep(2000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLineImageExistsInNB(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29897)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyEraserIconFunctionality()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC29897: Tools - verify Eraser icon Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookAddPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 810, 760, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 840, 790, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "TEST");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 766, 716, 1);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyEraseIconSubMenu(notebookAutomationAgent));
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, WordsInTextBox.Contains("TEST"));
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(28346)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void EditingVocabularyNotebookTitle()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC28346: Editing Vocabulary Notebook title"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPersonalNotesTitleInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyAllEditMenus(notebookAutomationAgent), "All Edit Menus not present");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 500, 500, 1);
                    NotebookCommonMethods.EditPersonalNotesTitle(notebookAutomationAgent, "MyTitle");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 500, 500, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNewPersonalNotesTitle(notebookAutomationAgent, "MyTitle"), "Personal Note Title not the same");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22138)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void CommonReadNotebookVerifyTitleBarFolderArrowsAndPlusIconsFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22138: Common Read Notebook - verify title bar folder, arrows and plus icons functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);

                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    int indexOfBracket = taskName.IndexOf("(");
                    string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/2)", "page number is not 2/2");

                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(1/2)", "page number is not 1/2");

                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    indexOfBracket = taskName.IndexOf("(");
                    pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
                    Assert.AreEqual<string>(pageNumber, "(2/2)", "page number is not 2/2");

                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent));


                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20376)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ToVerifyAddingImageFromPhotos()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20376: To verify adding image from Photos"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Does not Exist");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22054)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAlertMessageCancelOrContinue()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22054: To Verify Alert message - Cancel or Continue"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickDeleteIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDeleteIconPopUp(notebookAutomationAgent), "Delete Icon Pop Up not present");
                    NotebookCommonMethods.ClickContinueInDeleteIconPopUp(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22242)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookScrolling()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22242: Notebook scrolling"))
            {
                try
                {
                    NavigationCommonMethods.Login(notebookAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyWorkIsScrollable(notebookAutomationAgent, 1), "Work is not scrollable");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(20430)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EnableTextModeViaNativeNotebookToolbarControl()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20430: Enable text mode via native notebook toolbar control"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextIconActive(notebookAutomationAgent), "Text Icon not active");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyTextRegionPresent(notebookAutomationAgent), "Text Region not present");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Test");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(notebookAutomationAgent, "Test"), "Text not found in the text region");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20431)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DisableTextModeViaNativeNotebookToolbarControl()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20431: Disable text mode via native notebook toolbar control"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextIconActive(notebookAutomationAgent), "Text Icon not active");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyTextRegionPresent(notebookAutomationAgent), "Text Region not present");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Test");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(notebookAutomationAgent, "Test"), "Text not found in the text region");
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    Assert.AreEqual<string>("False", NotebookCommonMethods.VerifyTextRegionPresent(notebookAutomationAgent), "Text Region still present");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22549)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void BrowseNotesOverlayGeneralVerifyLayout()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22549: Browse Notes overlay - General - verify layout"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay Present is not found");
                    NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyGoToWorkBrowserButtonPresent(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTaskNotebooksButtonPresent(notebookAutomationAgent), "Task ?Notebooks Button not present");
                    Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNotesButtonPresent(notebookAutomationAgent), "Personal Notes button not present");
                    Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyTaskNotebooksButtonActive(notebookAutomationAgent), "Task Notebooks button not active");
                    string s = NotebookCommonMethods.GetNameOfTask(notebookAutomationAgent);
                    string[] taskName = s.Split(':');
                    taskName[1] = taskName[1].Replace("\t\n", "");
                    string s1 = NotebookCommonMethods.GetTaskTitleInTaskNotebooks(notebookAutomationAgent);
                    string[] taskTitle = s1.Split(':');
                    Assert.AreEqual(taskName[1].Trim(), taskTitle[1].Trim());
                    NotebookCommonMethods.VerifyTaskNotebooksElements(notebookAutomationAgent);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22555)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void BrowseNotesOverlayMyNoteBookTileContainsTaskTitle()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22555:Browse Notes overlay - My Notebook - Tile header contains task title and is dark blue for ELA"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay Present is not found");
                    string s1 = NotebookCommonMethods.GetTaskTitleInTaskNotebooks(notebookAutomationAgent);
                    string[] taskTitle = s1.Split(':');
                    string s2 = NotebookCommonMethods.GetMyNotebookTitle(notebookAutomationAgent);
                    string[] MyNotebookTitle = s2.Split('\t');
                    Assert.AreEqual(MyNotebookTitle[0].Trim(), taskTitle[1].Trim(), "My Notebook Title not similar to the task title");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookHeaderColorBlue(notebookAutomationAgent), "notebook header colour is not blue");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22524)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SaveToNotebookButtonIsAvailableInInteractive()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22524: Save to Notebook button is available in the interactive"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16018)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NativeNotebookUndoDeletedVideo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16018: Native notebook: Undo deleted video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyUndoButtonActive(notebookAutomationAgent));
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23264)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SavingInteractivesCloseInteractiveOpenedFromNotebookInFullScreenMode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23264: Saving Interactives - close interactive opened from Notebook in full screen mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickFullScreenIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyXIconPresentInFullScreen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInteractiveThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyNotebookFullScreenWindow(notebookAutomationAgent));
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20465)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NativeNotebookConfirmTheSnapshotToolInNavigationBar()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20465:Native notebook: Confirm the snapshot tool in the navigation bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickCaptureSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsFalse(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSnapShotIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(23261)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SavingInteractivesOpenSavedInteractiveFromNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23261:Saving Interactives - open saved interactive from Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
                    NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveThumbnailPresent(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(1000);
                    NotebookCommonMethods.ClickInteractiveThumbnail(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageIsOpened(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16017)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NativeNotebookDeletingVideoInHandMode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16017:Native notebook: Deleting video in hand mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent));
                    NotebookCommonMethods.ClickHandIcon(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
                    NotebookCommonMethods.ClickOnXIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyUndoButtonActive(notebookAutomationAgent));
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16214)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NativeNotebookCancelSnapshotToolInNavigationBar()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16214:Native notebook: Cancel the snapshot tool in the navigation bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickCancelSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsFalse(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43541)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MathToolsMenuDisabledInElaWrenchGrayedout()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43541: Math tools menu is disabled in ELA, wrench is grayed out"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsFalse(CAAdoptionCommonMethods.VerifyWrenchIconActive(notebookAutomationAgent), "Wrench Icon is active");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43540)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserTapsDoneAlertMessageThenUserQuitsToolWithoutSaving()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43540: WHEN user taps [Continue] on the alert message THEN user quits the Tool without saving"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos Is Present In Notebook");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43543)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserTapsDoneAlertMessageThenGivingUserTwoOptions()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43543: WHEN user taps [Done] THEN alert message appears, giving user two options"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyCancelButton(notebookAutomationAgent), "Cancel Button is not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyContinueButton(notebookAutomationAgent), "Continue Button is not found");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43539)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MathToolsMenuGetsClosedTapWrenchIconSecondTimeAndTapOutsideToolsMenu()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43539: Math Tools menu gets closed: 1. when you tap wrench icon for the second time 2. when you tap anywhere outside the math tools menu"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyToolsMenuPopUp(notebookAutomationAgent), "Tools Menu Pop Up not found");
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyToolsMenuPopUp(notebookAutomationAgent), "Tools Menu Pop Up found");
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyToolsMenuPopUp(notebookAutomationAgent), "Tools Menu Pop Up not found");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1054, 252, 1);
                    Assert.IsFalse(NotebookCommonMethods.VerifyToolsMenuPopUp(notebookAutomationAgent), "Tools Menu Pop Up found");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22550)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyOnlyOneMyNotebookExistsPerTask()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22550: Verify only one my notebook exists per task"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyTaskNotebooksElements(notebookAutomationAgent);
                    string failureMessage;
                    Assert.IsTrue(NotebookCommonMethods.VerifyMyNotebookTileExists(notebookAutomationAgent, out failureMessage), failureMessage);
                    NotebookCommonMethods.ClickGoToWorkBrowserButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWorkBrowserPageOpened(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22552)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyOpenMyNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22552: Verify opening MY Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickMyNotebookTile(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser overlay is present");
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22556)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyMyNotebookInMath()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22556: Verify header tile MY Notebook In Math"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(notebookAutomationAgent);
                    string failureMessage;
                    NotebookCommonMethods.VerifyMyNotebookTileExists(notebookAutomationAgent, out failureMessage);
                    string s1 = NotebookCommonMethods.GetTaskTitleInTaskNotebooks(notebookAutomationAgent);
                    string[] taskTitle = s1.Split(':');
                    string s2 = NotebookCommonMethods.GetMyNotebookTitle(notebookAutomationAgent);
                    string[] MyNotebookTitle = s2.Split('\t');
                    Assert.AreEqual(MyNotebookTitle[0].Trim(), taskTitle[1].Trim(), "My Notebook Title not similar to the task title");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22603)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyOverlayWithNoReceivedNotebooks()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22603: Verify received notebooks tile in work browser overlay when no notebooks received"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(notebookAutomationAgent);
                    Assert.AreEqual<int>(0, NotebookCommonMethods.GetNumerOfReceivedBooksFromTitle(notebookAutomationAgent), "Received Notebooks number is not 0 in the title");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNoReceivedNotebooksText(notebookAutomationAgent), "No Received notebooks text not found");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43554)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserTapsCancelAlertMessageThenAlertGetsClosedToolResumes()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43554: WHEN user taps [Cancel] on the alert message THEN alert gets closed, tool functionality resumes"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    string pageTitle = NotebookCommonMethods.GetTitleTaskOfInteractiveInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    string pageTitle1 = NotebookCommonMethods.GetTitleTaskOfInteractiveInNotebook(notebookAutomationAgent);
                    Assert.AreEqual<string>(pageTitle, pageTitle1, "Text and Second text are not equal");
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22606)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyScrollingOverlayWithReceivedNotebooks()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22606: Verify scrolling in work browser overlay when notebooks received"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(notebookAutomationAgent);
                    NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Down, 500, 500);
                    NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Up, 500, 500);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(22628)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyTogglingTaskNBAndPersonalNotes()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22628: Verify toggling between Task notebooks and personal notes"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(notebookAutomationAgent);
                    string failureMessage;
                    NotebookCommonMethods.VerifyMyNotebookTileExists(notebookAutomationAgent, out failureMessage);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteCreateTile(notebookAutomationAgent), "Personal Note create tile is not found");
                    NotebookCommonMethods.ClickOnTaskNotebooksButtoninBrowseNotes(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyMyNotebookTileExists(notebookAutomationAgent, out failureMessage);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        
        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43553)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserTapsContinueAlertMessageThenToolGetsClosedSnapshotSavedNotebook()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43553: WHEN user taps [Continue] on the alert message THEN the tool closes AND snapshot is saved in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos Is Not Present In Notebook");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
       
        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43588)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ToolsWhichSavedNotebookOnlyDoneVisibleChromeBar()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43588:(07a.) tools which are saved to a Notebook have only [Done] visible on their chrome bar"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos Is Not Present In Notebook");
                    NotebookCommonMethods.ClickOnNoteBookRegionPanel(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDoneButtonInNewlyCreatedDesmos(notebookAutomationAgent), "Done Button is not found in Newly Created Desmos");
                    Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIcon(notebookAutomationAgent), "Teacher Guide Icon Not found");
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43545)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserTapsSaveToNotebookAlertMessageThenGivingUserTwoOptions()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43545: (05.) WHEN user taps [Save to notebook] icon THEN alert message appears, giving user two options"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    Assert.IsTrue(CAAdoptionCommonMethods.VerifyAlertOnSendToNotebookIconClick(notebookAutomationAgent), "Alert Message Save To Notebook NewDesmos is not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyCancelButton(notebookAutomationAgent), "Cancel Button is not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyContinueButton(notebookAutomationAgent), "Continue Button is not found");
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(18634)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EditExistingPersonalNotebookTitleClearTitle()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC18634: Edit existing Personal Notebook Title - clear title and attempt to save it"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                    NotebookCommonMethods.EditPersonalNotesTitle(notebookAutomationAgent, "");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 400, 1);
                    Assert.AreEqual(false, NotebookCommonMethods.VerifyPersonalNotesTitle(notebookAutomationAgent, ""), "Personal Notebook Title is blank");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43586)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserCanResumeWorkingWithPreviouslySavedInteractive()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43586:(07.) user can resume working with the previously saved interactive"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.AddTextInInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos Is Not Present In Notebook");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon Is Not Picked");
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnNoteBookRegionPanel(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPreviousValuePresent(notebookAutomationAgent, "Test"), "Previous entered value is not present in interactive");
                    NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);

                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43587)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserCanDeletePreviouslySavedInteractive()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43587:(07b.) user can delete the previously saved interactive"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.AddTextInInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon Is Not Picked");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1150, 400, 1);
                    NotebookCommonMethods.ClickOnDesmosThumbnail(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnXIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19313)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void DesmosCreateNewDesmosPressDone()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19313:Desmos - Create new Desmos and press [Done]"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19314)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void DesmosSaveDesmosNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19314: Desmos - Save Desmos in Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos is not present in the notebook");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(19312)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void DesmosGraphicCalculatorOpensWhenTappingGraphingCalculator()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19312: Desmos - Graphic calculator opens when tapping ‘graphing calculator’"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyDesmosGraphicCalculatorToolOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos is not present in the notebook");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43542)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenUserTapsDoneAndCancelAlertMessageThenAlertGetsClosedToolResumes()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43542: (03b.) WHEN user taps [Cancel] on the alert message THEN alert gets closed, tool functionality resumes"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    string pageTitle = NotebookCommonMethods.GetTitleTaskOfInteractiveInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    string pageTitle1 = NotebookCommonMethods.GetTitleTaskOfInteractiveInNotebook(notebookAutomationAgent);
                    Assert.AreEqual<string>(pageTitle, pageTitle1, "Text and Second text are not equal");
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43555)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ToolNameAndTimeStampAppearBelowToolSnapshot()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43555: Tool name and Time Stamp appear below tool snapshot"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    string TextDesmos = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
                    string[] nameAndTime = TextDesmos.Split('\n');
                    string name = nameAndTime[0].Split(':')[1].Trim();
                    string time = nameAndTime[1].Replace("\t", "");
                    Assert.IsTrue(NotebookCommonMethods.VerifyLastModifiedTime(time), "Time Stamp is not displayed");
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43589)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserCanSeeAlreadySavedInteractiveStateUpdated()
        {

            using (notebookAutomationAgent = new AutomationAgent("TC43589:(07c.) [Done] saves the state of the tool that's already saved into the Notebook, the tool gets closed"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.AddTextInInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnNoteBookRegionPanel(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPreviousValuePresent(notebookAutomationAgent, "Test"), "Previous entered value is not present in interactive");
                    NotebookCommonMethods.AddNewValueInteractive(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnNoteBookRegionPanel(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyModifiedNewValuePresent(notebookAutomationAgent, "NewValue"), "Previous entered value is not present in interactive");
                    NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20398)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ToVerifyMultipleImagesAddedSinglePage()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20398:To verify multiple images added in a single page"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.VerifyXIconPresentInImage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnXIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(20800)]
        [Priority(1)]
        [Owner("Narsimhan Narayanan (narsimhan.narayanan)")]
        public void VerifyViewInLessonInNoteBookPreview()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20800: To Verify View In Lesson Button in Notebook Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAFilter(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkELAFilter(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(notebookAutomationAgent);
                    NavigationCommonMethods.VerifyUnitBackButtonPresent(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()] desmos
        [TestCategory("NotebookTests")]
        [WorkItem(43544)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TwoIconsAppearChromeBarDoneButtonAndSavetoNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC43544: two icons appear on the chrome bar : Done button and save to Notebook icon"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyDoneButtonAtUpperLeftCorner(notebookAutomationAgent), "Done button not found");
                    NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(29946)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ResourceLibraryContentPppShouldShowSnapshotToolNoUnusualBehaviors()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC29946: resource library content doesn't exist - app should just show snapshot tool, etc. - no unusual behaviors should be observed"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent), "Snapshot grid not present");
                    NotebookCommonMethods.ClickCaptureSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(16016)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void KillAppDuringInsertingExistingVideo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC16016: Kill the app during inserting existing video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebookAndKillApp(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
                    notebookAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail is found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(20522)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GlobalNavVerifyViewInLessonButtonNotPresentPersonalNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20522:Notebook Preview - Global Nav - verify [View in Lesson] button is not present for Personal Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(notebookAutomationAgent);
                    WorkBrowserCommonMethods.SelectPersonalNotesFilter(notebookAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMyPersonalNoteTile(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyViewInLessonButton(notebookAutomationAgent), "View In Lesson is found in personal notes");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);

                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //Optimization
        [TestMethod()]
        [WorkItem(16002), WorkItem(16010), WorkItem(16013), WorkItem(16014), WorkItem(16012), WorkItem(16004), WorkItem(16009), WorkItem(16011), WorkItem(16019), WorkItem(16001), WorkItem(16018), WorkItem(16017)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VariousVideoRelatedCriticalTestCases()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC1: Notebook - Video related critical test cases"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyCameraAndPhotosMenu(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.SendText("{HOME}");
                    notebookAutomationAgent.Sleep(8000);
                    notebookAutomationAgent.LaunchApp();
                    notebookAutomationAgent.Sleep();
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video watermark not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand icon not active and highlighted");
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoBlueWaterMark(notebookAutomationAgent), "Video play button is not blue");
                    int VideoWidthBefore = NotebookCommonMethods.GetWidthOfVideoInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ResizeVideo(notebookAutomationAgent);
                    int VideoWidthAfter = NotebookCommonMethods.GetWidthOfVideoInNotebook(notebookAutomationAgent);
                    Assert.AreEqual(VideoWidthBefore, VideoWidthAfter, "Width is not same");
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(notebookAutomationAgent);
                    DateTime startDateTime = DateTime.Now;
                    LessonBrowserCommonMethods.ClickPauseButtonInVideo(notebookAutomationAgent);
                    DateTime endDateTime = DateTime.Now;
                    Assert.IsTrue((endDateTime.CompareTo(startDateTime) > 0), "end date time and start date time is not greater than zero");
                    string VideoPos1 = NotebookCommonMethods.GetPositionOfVideo(notebookAutomationAgent);
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyVideoAtCenterOfNotebook(notebookAutomationAgent), "Video not at the center of the notebook");
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent, "1"), "Video thumbnail is not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video Watermark is not found");
                    string VideoPos2 = NotebookCommonMethods.GetPositionOfVideo(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoAtCenterOfNotebook(notebookAutomationAgent), "Video is not in the centre of notebook");
                    Assert.AreEqual(VideoPos1, VideoPos2, "Videos are not overlapping");
                    NotebookCommonMethods.VerifyXIconPresentOnVideo(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnXIconOnVideo(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyXIconPresentOnVideo(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnXIconOnVideo(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "1. Video thumbnail is found");
                    NotebookCommonMethods.ClickOnUndoRedoIcon(notebookAutomationAgent);
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyUndoButtonActive(notebookAutomationAgent)), "Undo button is not active");
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail is not found");
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyRedoButtonActive(notebookAutomationAgent)), "Redo button Inactive");
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "2. Video thumbnail is found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doen't exist");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(22423), WorkItem(22465), WorkItem(20422), WorkItem(20430), WorkItem(20431)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookCriticalTestCasesOnGeneralScenarios()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC2: Notebook - General scenarios"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolbarSubMenu(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolbarButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent), "Notebook is found");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextIconActive(notebookAutomationAgent), "Text Icon not active");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyTextRegionPresent(notebookAutomationAgent)), "Text Region not present");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "Test");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(notebookAutomationAgent, "Test"), "Text not found in the text region");
                    NotebookCommonMethods.ClickHandIcon(notebookAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    Assert.IsFalse(bool.Parse(NotebookCommonMethods.VerifyTextRegionPresent(notebookAutomationAgent)), "Text Region still present");
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    notebookAutomationAgent.ClickOnScreen(500, 500, 1);
                    NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(19307), WorkItem(19309), WorkItem(19310), WorkItem(19318), WorkItem(19311), WorkItem(23928)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MathNotebookCriticalTestCases()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC3: Notebook - Math notebook critical functions"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUndoRedoButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUndoRedoSubMenu(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUndoRedoSubMenuFound(notebookAutomationAgent), "Undo Redo sub-menu is not found");
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1150, 400, 1);
                    Assert.IsFalse(NotebookCommonMethods.VerifyUndoRedoSubMenuFound(notebookAutomationAgent), "Undo Redo sub-menu is found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand icon is not active and highlighted");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
                    notebookAutomationAgent.Sleep(6000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoGreenWaterMark(notebookAutomationAgent), "Video play button isn't green");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(16003), WorkItem(16005), WorkItem(16007)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VariousCameraVideoRelatedCriticalTestCases()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC4: Notebook - Video related critical test cases"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
                    NotebookCommonMethods.CreateVideoFromCamera(notebookAutomationAgent, 70000);
                    notebookAutomationAgent.Sleep(10000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent), "Video Watermark not found");
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(70000);
                    NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(16210), WorkItem(16216), WorkItem(20465), WorkItem(16214), WorkItem(29946)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SnapshotToolCriticalFunctionalities()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC5: Notebook - Snapshot tool functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent));
                    NotebookCommonMethods.ClickCancelSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsFalse(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    NotebookCommonMethods.OpenSnapShot(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent), "Snapshot grid is not present");
                    NotebookCommonMethods.ClickCaptureSnapShot(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    Assert.IsFalse(NotebookCommonMethods.VerifySnapShotGridPresent(notebookAutomationAgent), "Snapshot grid is present");
                    NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnSnapShotIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon Not Active and highlighted");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(22242), WorkItem(20800)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WorkBrowserNotebookCriticalFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC6: Notebook - Work browser related functions"))
	        {
		        try
		        {
                    Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
			        NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
			        Assert.IsTrue(NavigationCommonMethods.VerifyWorkIsScrollable(notebookAutomationAgent, 1), "Work is not scrollable");
			        WorkBrowserCommonMethods.ClickMyWorkELAFilter(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
			        WorkBrowserCommonMethods.ClickMyWorkELAFilter(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
			        NotebookCommonMethods.ClickViewInLessonButton(notebookAutomationAgent);
			        NavigationCommonMethods.VerifyUnitBackButtonPresent(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(22549), WorkItem(22555)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void BrowseNotesOverlayCriticalTestCases()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC7: Notebook - Browse Notes overlay cases"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay Present is not found");
                    NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyGoToWorkBrowserButtonPresent(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTaskNotebooksButtonPresent(notebookAutomationAgent), "Task Notebooks Button not present");
                    Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNotesButtonPresent(notebookAutomationAgent), "Personal Notes button not present");
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyTaskNotebooksButtonActive(notebookAutomationAgent)), "Task Notebooks button not active");
                    string s = NotebookCommonMethods.GetNameOfTask(notebookAutomationAgent);
                    string[] taskName = s.Split(':');
                    taskName[1] = taskName[1].Replace("\t\n", "");
                    string s1 = NotebookCommonMethods.GetTaskTitleInTaskNotebooks(notebookAutomationAgent);
                    string[] taskTitle = s1.Split(':');
                    Assert.AreEqual(taskName[1].Trim(), taskTitle[1].Trim());
                    NotebookCommonMethods.VerifyTaskNotebooksElements(notebookAutomationAgent);
                    string s2 = NotebookCommonMethods.GetMyNotebookTitle(notebookAutomationAgent);
                    string[] MyNotebookTitle = s2.Split('\t');
                    Assert.IsTrue(MyNotebookTitle[0].Trim().Contains(taskTitle[1].Trim()), "My Notebook Title not similar to the task title");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookHeaderColorBlue(notebookAutomationAgent), "notebook header colour is not blue");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(15964), WorkItem(22249)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookImportantFunctionalities()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC8: Notebook - Open Notebook Button / Split view"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "OpenNotebookButton"));
                    Assert.IsTrue(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(notebookAutomationAgent), "Open Notebook Button not present");
                    NotebookCommonMethods.ClickOnOpenNotebookButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent), "Notebook splits lesson window not found");
                    Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyNotebookIcon(notebookAutomationAgent)), "Notebook Icon not present ");
                    Assert.IsFalse(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(notebookAutomationAgent), "Open notebook button present");
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [WorkItem(16023), WorkItem(29892), WorkItem(29894), WorkItem(29895), WorkItem(29903), WorkItem(29904), WorkItem(29902), WorkItem(29900), WorkItem(29899), WorkItem(29898), WorkItem(29901), WorkItem(29896), WorkItem(29897), WorkItem(20376), WorkItem(22054),WorkItem(43541)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookToolbarRelatedFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC9: Notebook - Toolbar functionalities"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        Assert.IsFalse(CAAdoptionCommonMethods.VerifyWrenchIconActive(notebookAutomationAgent), "Wrench Icon is active");
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyAllBottomToolbarsActiveInactive(notebookAutomationAgent), "Bottom Toolbar Active or Inactive not found");
			        NotebookCommonMethods.VerifyAllNotebookTools(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.ClickOnELANotebookInWorkBrowser(notebookAutomationAgent);
			        NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookAddPage(notebookAutomationAgent);
			        int pageNoBefore = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickDeleteIcon(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyDeleteIconPopUp(notebookAutomationAgent), "Delete Icon Pop Up not present");
			        NotebookCommonMethods.ClickCancelInDeleteIconPopUp(notebookAutomationAgent);
			        int pageNoAfter = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        Assert.AreEqual(pageNoAfter, pageNoBefore, "Page is deleted on cancel");
			        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
			        NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
                    notebookAutomationAgent.Sleep(3000);
			        string WordsInTextBox1 = NotebookCommonMethods.GetTextInTextZone(notebookAutomationAgent);
			        Assert.IsTrue(WordsInTextBox1.Contains("Tester"), "Test word is not present");
			        NotebookCommonMethods.ClickOnUndoRedoIcon(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyUndoRedoSubMenu(notebookAutomationAgent);
			        NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
			        string WordsInTextBox2 = NotebookCommonMethods.GetTextInTextZone(notebookAutomationAgent);
			        Assert.IsFalse(WordsInTextBox2.Contains("Tester"), "Test word is present");
			        NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
			        string WordsInTextBox3 = NotebookCommonMethods.GetTextInTextZone(notebookAutomationAgent);
			        Assert.IsTrue(WordsInTextBox3.Contains("Tester"), "Test word is not present");
                    NotebookCommonMethods.ClickHandIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyEraseIconSubMenu(notebookAutomationAgent));
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
			        string WordsInTextBox4 = NotebookCommonMethods.GetTextInTextZone(notebookAutomationAgent);
			        Assert.IsFalse(WordsInTextBox4.Contains("Tester"), "Text is not clear");
			        NotebookCommonMethods.ClickDeleteIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickContinueInDeleteIconPopUp(notebookAutomationAgent);
			        int newPageNo = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        Assert.AreNotEqual(pageNoBefore, newPageNo, "Page is not deleted on continue click");
			        NotebookCommonMethods.ClickFullScreenIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookFullScreenWindow(notebookAutomationAgent), "Full screen not appearing");
			        NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
			        Assert.IsTrue(NotebookCommonMethods.VerifySinglePageViewOfNotebookInWorkBrowser(notebookAutomationAgent), "Single page not appearing");
			        NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyWrenchToolSubMenuExists(notebookAutomationAgent);
			        NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
                    Assert.IsTrue(NotebookCommonMethods.VerifyImageThumbnailInNotebook(notebookAutomationAgent), "1. Image is not found");
			        Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Does not Exist");
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
			        NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyImageThumbnailInNotebook(notebookAutomationAgent), "2. Image is not found");
                    notebookAutomationAgent.Sleep();
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerfiyDrawingIconSubmenus(notebookAutomationAgent), "Drawing icon sub menu is not found");
			        NotebookCommonMethods.DrawLineInNotebook(notebookAutomationAgent, 810, 790);
			        notebookAutomationAgent.Sleep(4000);
			        Assert.IsTrue(NotebookCommonMethods.VerifyLineImageExistsInNB(notebookAutomationAgent), "Line image doesn't exists");
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickBackgroundIcon(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyBackgroundTools(notebookAutomationAgent), "Background tool is not found");
			        NotebookCommonMethods.SelectRuledGraphBackground(notebookAutomationAgent);
			        notebookAutomationAgent.Sleep(3000);
			        Assert.IsTrue(NotebookCommonMethods.VerifyRuledGraphNotebookBackground(notebookAutomationAgent), "Rules graph notebook background is not found");
			        NotebookCommonMethods.ClickBackgroundIcon(notebookAutomationAgent);
			        NotebookCommonMethods.SelectBlankBackground(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(18616), WorkItem(18617), WorkItem(18620), WorkItem(18622), WorkItem(18623), WorkItem(18625), WorkItem(18627), WorkItem(18632), WorkItem(18633), WorkItem(20151), WorkItem(18634), WorkItem(28346), WorkItem(18634)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void PersonalNotebookImportantFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC10: Notebook - Personal Notebook and it's functions"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
			        NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
			        NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
			        DateTime currentDate = DateTime.Now;
			        string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
			        Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note"), "Notes default title doesn't contain My Personal Note");
			        TimeSpan difference = NotebookCommonMethods.GetPersonalNoteTitleTime(NotesDefaultTitle).Subtract(currentDate);
			        Assert.IsTrue(difference.Minutes < 4, "Title Time is not same as current time");
			        NotebookCommonMethods.ClickXIconNewPersonalNote(notebookAutomationAgent);
			        string NotesTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent);
			        Assert.AreEqual(true, NotesTitle.Equals("My Personal Note\t\n"), "Notes title not My Personal Note");
			        NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, "");
			        Assert.IsFalse(NotebookCommonMethods.VerifyCreateButtonPersonalNotesEnabled(notebookAutomationAgent), "Create note button is enabled");
			        Assert.IsFalse(NotebookCommonMethods.VerifyPersonalNotesTitle(notebookAutomationAgent, ""), "Personal Notebook Title is blank");
			        NotebookCommonMethods.ClickOnCreatePersonalNoteCancel(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent), "Personal Note is present");
                    NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                    NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                    NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
			        NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, "MyTitle");
			        Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup(notebookAutomationAgent).Contains("MyTitle"), "Personal Note title Doesn't contain MyTitle");
			        Assert.IsTrue(NotebookCommonMethods.VerifyCreateButtonPersonalNotesEnabled(notebookAutomationAgent), "Create note button is disabled");
			        NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent, "MyTitle"), "Personal Notebook not found");
			        Assert.AreEqual<string>("0xEF8700", NotebookCommonMethods.VerifyTitleBarOfNotebook(notebookAutomationAgent), "TitleBar of notebook is not orange 1");
			        NotebookCommonMethods.ClickOnPersonalNotesTitleInNotebook(notebookAutomationAgent, "MyTitle");
			        Assert.IsTrue(NotebookCommonMethods.VerifyAllEditMenus(notebookAutomationAgent), "All Edit Menus not present");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 500, 500, 1);
			        NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
			        NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
			        NotebookCommonMethods.ClickExistingPersonalNoteCell(notebookAutomationAgent, "MyTitle");
			        Assert.AreEqual<string>("0xEF8700", NotebookCommonMethods.VerifyTitleBarOfNotebook(notebookAutomationAgent), "TitleBar of notebook is not orange 2");
                    NotebookCommonMethods.EditPersonalNotesTitle(notebookAutomationAgent, "EdittedTitle", "MyTitle");
			        Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent)), "Keyboard not present 1");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 400, 1);
			        Assert.IsTrue(NotebookCommonMethods.VerifyNewPersonalNotesTitle(notebookAutomationAgent, "EdittedTitle"), "Personal Note Title not the same 1");
                    NotebookCommonMethods.EditPersonalNotesTitle(notebookAutomationAgent, "EdittedTitle2", "EdittedTitle");
			        Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent)), "Keyboard not present");
			        NotebookCommonMethods.ClickXIconInNotebookTitle(notebookAutomationAgent);
			        notebookAutomationAgent.Sleep();
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1300, 400, 1);
			        string text = NotebookCommonMethods.GetTextInsideElement(notebookAutomationAgent);
			        Assert.IsTrue(text.Contains("EdittedTitle"), "Edited notebook title doesn't contain My Personal string");
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(20378), WorkItem(20448), WorkItem(20449), WorkItem(20450), WorkItem(20390), WorkItem(20399), WorkItem(29893), WorkItem(20398)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookImportantAddImageFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC11: Notebook - Image functionalities"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, true);
			        Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Exists");
			        NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
			        Assert.IsTrue(NotebookCommonMethods.VerifyImageXIconPresent(notebookAutomationAgent), "Delete icon not appearing");
			        Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand Icon not active");
			        Assert.IsFalse(NotebookCommonMethods.VerifyImageXIconNotPresent(notebookAutomationAgent), "Delete icon appearing");
			        Assert.IsTrue(NotebookCommonMethods.VerifyImageInCenterOfNotebook(notebookAutomationAgent), "Image not at center");
			        string widthBefore = NotebookCommonMethods.ImageSizeInNoteBookBeforeResize(notebookAutomationAgent);
			        NotebookCommonMethods.ResizeImageInNoteBook(notebookAutomationAgent);
			        string widthAfter = NotebookCommonMethods.ImageSizeInNoteBookAfterResize(notebookAutomationAgent);
			        Assert.AreNotEqual<string>(widthBefore, widthAfter, "Image not been resized");
			        string ImagePosBefore = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
			        NotebookCommonMethods.MoveImageInNoteBook(notebookAutomationAgent);
			        string ImagePosAfter = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
			        Assert.AreNotEqual<string>(ImagePosBefore, ImagePosAfter, "Image not moved");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
			        NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
			        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        int indexOfBracket = taskName.IndexOf("(");
			        string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(2/2)");
			        NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
			        NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo doesn't exists");
			        NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent, false);
			        NotebookCommonMethods.VerifyXIconPresentInImage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnXIcon(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(22625), WorkItem(22627), WorkItem(22626), WorkItem(22550), WorkItem(22552), WorkItem(22556), WorkItem(22603), WorkItem(22606), WorkItem(22628), WorkItem(22461)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void BrowseNotesOverlayOverlayImportantFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC12: Notebook - Browse Notes overlay"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay not Present");
			        NotebookCommonMethods.VerifyTaskNotebooksElements(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyOverlayHeading(notebookAutomationAgent), "Overlay heading not as expected");
			        string failureMessage;
			        Assert.IsTrue(NotebookCommonMethods.VerifyMyNotebookTileExists(notebookAutomationAgent, out failureMessage), failureMessage);
			        string s1 = NotebookCommonMethods.GetTaskTitleInTaskNotebooks(notebookAutomationAgent);
			        string[] taskTitle = s1.Split(':');
			        string s2 = NotebookCommonMethods.GetMyNotebookTitle(notebookAutomationAgent);
			        string[] MyNotebookTitle = s2.Split('\t');
			        Assert.IsTrue(MyNotebookTitle[0].Trim().Contains(taskTitle[1].Trim()), "My Notebook Title not similar to the task title");
			        Assert.AreEqual<int>(0, NotebookCommonMethods.GetNumerOfReceivedBooksFromTitle(notebookAutomationAgent), "Received Notebooks number is not 0 in the title");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNoReceivedNotebooksText(notebookAutomationAgent), "No Received notebooks text not found");
			        NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Down, 500, 500);
                    NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Up, 500, 500);
			        NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteCreateTile(notebookAutomationAgent), "Personal Note create tile is not found");
			        NotebookCommonMethods.ClickOnTaskNotebooksButtoninBrowseNotes(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyMyNotebookTileExists(notebookAutomationAgent, out failureMessage);
			        NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser Overlay Present");
			        NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
			        NotebookCommonMethods.ClickMyNotebookTile(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
			        Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Work Browser overlay is present");
			        NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
			        NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyGoToWorkBrowserButtonPresent(notebookAutomationAgent);
			        NotebookCommonMethods.ClickGoToWorkBrowserButton(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyWorkBrowserPageOpened(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(20387), WorkItem(20388)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookAddImageWithCameraImportantFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC13: Notebook - Camera Images"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnImageIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickPhotosIcon(notebookAutomationAgent);
			        NotebookCommonMethods.AddPhotoFromCamera(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
			        string widthBefore = NotebookCommonMethods.ImageSizeInNoteBookBeforeResize(notebookAutomationAgent);
			        NotebookCommonMethods.ResizeImageInNoteBook(notebookAutomationAgent);
			        string widthAfter = NotebookCommonMethods.ImageSizeInNoteBookAfterResize(notebookAutomationAgent);
			        Assert.AreNotEqual<string>(widthBefore, widthAfter, "Image not been resized");
			        string ImagePosBefore = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
			        NotebookCommonMethods.MoveImageInNoteBook(notebookAutomationAgent);
			        string ImagePosAfter = NotebookCommonMethods.GetImageCoordinate(notebookAutomationAgent);
			        Assert.AreNotEqual<string>(ImagePosBefore, ImagePosAfter, "Image not moved");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 1000, 1);
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "Photo Doesn't exists");
			        NotebookCommonMethods.DeletePicture(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "1. Photo Exists");
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(notebookAutomationAgent), "2. Photo Exists");
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(20508), WorkItem(20514), WorkItem(22639), WorkItem(20511), WorkItem(20522)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookInWorkBrowserImportantFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC14: Notebook - Workbrowser related functions"))
	        {
		        try
		        {
                    Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
			        NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
			        notebookAutomationAgent.Sleep();
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTile(notebookAutomationAgent, taskName), "Notebook title is not similar");
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSnapshotDone(notebookAutomationAgent), "Notebook Snapshot Done button not found");
			        Assert.IsTrue(NotebookCommonMethods.VerifyDoneButtonAtUpperLeftCorner(notebookAutomationAgent), "Done button not at Upper Left corner");
			        NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
			        WorkBrowserCommonMethods.ClickMyWorkViewingFilter(notebookAutomationAgent);
			        WorkBrowserCommonMethods.SelectPersonalNotesFilter(notebookAutomationAgent);
			        WorkBrowserCommonMethods.ClickMyWorkPersonalNotesFilter(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
			        NotebookCommonMethods.ClickOnMyPersonalNoteTile(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyViewInLessonButton(notebookAutomationAgent), "View In Lesson is found in personal notes");
			        GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(notebookAutomationAgent);
			        NavigationCommonMethods.VerifyWorkBrowserPage(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(15965), WorkItem(19303)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MathNotebookImportantFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC15: Notebook - Math test case"))
	        {
		        try
		        {
                    Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("Math", "OpenNotebookButton"));
			        Assert.IsTrue(NotebookCommonMethods.VerifyOpenNotebookButtonMathPresent(notebookAutomationAgent));
			        NotebookCommonMethods.ClickOnOpenNotebookButtonMath(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent), "Window not splited");
			        Assert.IsTrue(bool.Parse(NotebookCommonMethods.VerifyNotebookIcon(notebookAutomationAgent)), "Notebook icon not present");
			        Assert.IsFalse(NotebookCommonMethods.VerifyOpenNotebookButtonMathPresent(notebookAutomationAgent), "Open Notebook button present");
			        NotebookCommonMethods.VerifyWrenchIcon(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(23166), WorkItem(23258), WorkItem(23263), WorkItem(23269), WorkItem(23273), WorkItem(23274), WorkItem(23168), WorkItem(23170), WorkItem(23257), WorkItem(22524), WorkItem(23264), WorkItem(23261)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookELAInteractiveImportantFunctionalities()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC16: Notebook - ELA interactive and functions"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        int CurrentPageNo = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        int i = CurrentPageNo;
			        for (; i <= 3; i++)
			        {
				        if (i != CurrentPageNo)
				        {
					        NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
				        }
				        NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);
				        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1250, 650, 1);
			        }
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
			        NotebookCommonMethods.VerifySendToNotebookIconPresent(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(notebookAutomationAgent), "Desmos is not in center");
			        NotebookCommonMethods.ClickFullScreenIcon(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyXIconPresentInFullScreen(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyInteractivePageOpen(notebookAutomationAgent), "Interactive is still open");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(notebookAutomationAgent), "Hand icon is not active and highlighted");
			        Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos is not present in notebook");
                    string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
			        string DesmosPosBeforeUndo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
			        NotebookCommonMethods.MoveDesmosInNoteBook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
			        string DesmosPosBeforeRedo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
			        NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
			        NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 400, 400, 1);
			        string DesmosPosAfterUndo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
			        Assert.AreEqual<string>(DesmosPosBeforeUndo, DesmosPosAfterUndo, "Position aren't same after undo");
			        NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
			        NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 400, 400, 1);
                    notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
			        string DesmosPosAfterRedo = NotebookCommonMethods.GetDesmosCoordinate(notebookAutomationAgent);
			        Assert.AreEqual<string>(DesmosPosBeforeRedo, DesmosPosAfterRedo, "Position aren't same after redo");
			        NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
			        NotebookCommonMethods.ClickTextRegionDeleteXIcon(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Interactive is present");
			        NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
			        NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Interactive isn't present");
			        NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Interactive is present");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 400, 400, 1);
			        NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
			        string PageNoWithCurrentPage = NotebookCommonMethods.GetNoteBookPageNosWithCurrentPage(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyNewDesmosPagePresent(notebookAutomationAgent), "New desmos is not present");
			        NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
			        Assert.AreEqual(PageNoWithCurrentPage, "(" + (i - 1).ToString() + "/" + i.ToString() + ")");
			        int firstPageCount = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        int DtCurrent = int.Parse(DateTime.Now.ToString("mm").ToLower());
			        string TextDesmos = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
			        Assert.IsTrue(TextDesmos.Contains("Interactive"), "Desmos name doesn't contain Interactive");
                    string[] str = TextDesmos.Split(':');
                    string mnt = str[str.Length - 1];
                    mnt = mnt.Replace("pm\t\n", "");
                    mnt = mnt.Replace("am\t\n", "");
                    int desmosMnt = int.Parse(mnt);
                    int diff = 0;
                    if (DtCurrent - desmosMnt < 0)
                    {
                        diff = 60 - desmosMnt + DtCurrent;
                    }
                    else
                    {
                        diff = DtCurrent - desmosMnt;
                    }
                    Assert.IsTrue(diff < 20 , "Desmos name doesn't contain current date");
			        string widthBefore = NotebookCommonMethods.GetDesmosSize(notebookAutomationAgent);
			        NotebookCommonMethods.ResizeDesmosInNoteBook(notebookAutomationAgent);
			        string widthAfter = NotebookCommonMethods.GetDesmosSize(notebookAutomationAgent);
			        Assert.AreEqual<string>(widthBefore, widthAfter, "Desmos width is modified");
			        NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
			        NotebookCommonMethods.ClickInteractiveThumbnail(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent), "1. Notebook is open");
			        NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
			        notebookAutomationAgent.Sleep(60000);
			        NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(notebookAutomationAgent), "Lesson window is not split into two");
			        Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(notebookAutomationAgent), "Desmos is not present after edit");
			        string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime(notebookAutomationAgent);
			        Assert.AreNotEqual(TextBefore, TextAfter, "Desmos text is same after edit");
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.OpenInteractive(notebookAutomationAgent);
			        NotebookCommonMethods.EditInteractive(notebookAutomationAgent, 1487, 818, 1);
			        NotebookCommonMethods.ClickOnSendToNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickSendToNotebookContinueButton(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveThumbnailPresent(notebookAutomationAgent), "Interactive thumbnail is not found");
			        NotebookCommonMethods.VerifyXIconPresent(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(1000);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        int newPageCount = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        Assert.IsTrue(newPageCount > firstPageCount, "New page is not added: " + newPageCount + ": " + firstPageCount);
			        Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(notebookAutomationAgent), "Desmos is not in the center");
                    NotebookCommonMethods.ClickInteractiveThumbnailWithTwoThumbnails(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent), "2. Notebook is opened");
			        Assert.IsTrue(NotebookCommonMethods.VerifyInteractivePageIsOpened(notebookAutomationAgent), "Interactive page is not opened");
			        NotebookCommonMethods.ClickOnDoneButton(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyNotebookFullScreenWindow(notebookAutomationAgent), "Notebook is not full screen");
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(20518), WorkItem(20517), WorkItem(20519), WorkItem(22138)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookPagination()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC17: Notebook - Pagination"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(notebookAutomationAgent, "First Page");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
			        NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
			        NotebookCommonMethods.SendText(notebookAutomationAgent, "Second Page");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        int indexOfBracket = taskName.IndexOf("(");
			        string pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(2/2)", "page number is not 2/2");
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(2/3)", "page number is not 2/3");
			        Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent), "2. left arrow doesn't exist");
			        Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent), "2. right arrow doesn't exist");
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
			        notebookAutomationAgent.Sleep();
			        Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent), "2a. left arrow doesn't exist");
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(1/3)", "page number is not 1/3");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        Assert.AreEqual<string>("First Page", NotebookCommonMethods.GetTextBoxContent(notebookAutomationAgent, "First Page"), "Text box content is not the same");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
			        NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent), "3. left arrow doesn't exist");
			        Assert.IsFalse(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent), "3. left arrow doesn't exist");
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(3/3)", "page number is not 3/3");
                    NotebookCommonMethods.ClickViewInLessonButton(notebookAutomationAgent);
			        NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Overlay is not present");
			        NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(notebookAutomationAgent);
			        NotebookCommonMethods.ClickXBrowserNoteXButton(notebookAutomationAgent);
			        Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(notebookAutomationAgent), "Overlay is present");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        Assert.AreEqual<string>("Second Page", NotebookCommonMethods.GetTextBoxContent(notebookAutomationAgent, "Second Page"), "text box content is not the same");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(4/4)", "Page number is not 4/4");
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
			        Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
			        Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(3/4)", "page number is not 3/4");
			        NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(4/4)", "page number is not 4/4");
			        Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
			        Assert.IsFalse(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(1/4)", "page number is not 1/4");
			        Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent));
			        Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent));
			        NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(2/4)", "page number is not 2/4");
			        NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
			        taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        indexOfBracket = taskName.IndexOf("(");
			        pageNumber = taskName.Substring(indexOfBracket).TrimEnd();
			        Assert.AreEqual<string>(pageNumber, "(3/4)", "page number is not 3/4");
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);			
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(20516)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NotebookPreviewHeader()
        {
	        using (notebookAutomationAgent = new AutomationAgent("MTC18: Notebook - Preview header"))
	        {
		        try
		        {
			        Login login = Login.GetLogin("GustadMody");
			        NavigationCommonMethods.Login(notebookAutomationAgent, login);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        string taskName = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
			        NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Interactive"));
			        NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        string taskName2 = NotebookCommonMethods.GetTaskName(notebookAutomationAgent);
			        NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1230, 700, 1);
			        NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 1200, 300, 1);
			        NavigationCommonMethods.NavigateWorkBrowser(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        notebookAutomationAgent.Sleep();
			        NotebookCommonMethods.ClickOnCommonReads(notebookAutomationAgent);
			        NavigationCommonMethods.ClickDownChevronIcon(notebookAutomationAgent, 1);
			        NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
			        NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(2000);
                    NotebookCommonMethods.TapOnScreen(notebookAutomationAgent, 104, 434, 1);
			        int pageno = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickSinglePageIcon(notebookAutomationAgent);
			        while (pageno < 3)
			        {
				        NotebookCommonMethods.ClickOnNotebookAddPage(notebookAutomationAgent);
				        pageno = NotebookCommonMethods.GetNotebookPage(notebookAutomationAgent);
			        }
			        int firstpageno = NotebookCommonMethods.GetNotebookFirstPage(notebookAutomationAgent);
			        while (firstpageno > 1)
			        {
				        NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
				        firstpageno = NotebookCommonMethods.GetNotebookFirstPage(notebookAutomationAgent);
			        }
			        string s = NotebookCommonMethods.GetNoteBookPageNosWithCurrentPage(notebookAutomationAgent);
			        Assert.AreEqual(s, "(" + (firstpageno).ToString() + "/" + pageno + ")");
			        NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
			        NotebookCommonMethods.ClickOnNotebookSnapshotDone(notebookAutomationAgent);
			        NavigationCommonMethods.Logout(notebookAutomationAgent);
		        }
		        catch (Exception ex)
		        {
			        notebookAutomationAgent.Sleep(2000);
			        notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
			        notebookAutomationAgent.ApplicationClose();
			        throw;
		        }
	        }
        }

        [TestMethod()]
        [WorkItem(16016)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AppKillTest()
        {
            using (notebookAutomationAgent = new AutomationAgent("MTC19: Notebook - Kill the app during inserting existing video"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddVideoInNotebookAndKillApp(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(3000);
                    notebookAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(notebookAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(notebookAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent), "Video thumbnail is found");
                    NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
