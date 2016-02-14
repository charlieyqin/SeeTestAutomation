using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using System.Net;
using Pearson.PSCAutomation.Framework;

namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class BackUpAndRestoreTests
    {
        public AutomationAgent backUpAndRestoreAutomationAgent;
        public BackUpAndRestoreTests()
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
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52657)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void SectionStudentShareNotebookOnline()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52657: Section student sharing notebook online"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "First");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyShareOverlay(backUpAndRestoreAutomationAgent), "Share Message Overlay is not available");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySelectRecipients(backUpAndRestoreAutomationAgent), "Select Recipients is not available");
                    ShareFunctionalityCommonMethods.CloseShareMessageOverLay(backUpAndRestoreAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyShareOverlay(backUpAndRestoreAutomationAgent), "Share Message Overlay is available");
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifySelectRecipients(backUpAndRestoreAutomationAgent), "Select Recipients is available");
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyUsernameHasCheckBoxAgainstIt(backUpAndRestoreAutomationAgent, "Altagracia D Lindie"), "Altagracia teacher is not marked with check mark");
                    ShareFunctionalityCommonMethods.ClickSelectAllButtonInOverlay(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyUsernameHasCheckBoxAgainstIt(backUpAndRestoreAutomationAgent, "Select All"), "Select All is marked not with check mark");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyAllStudentsSelected(backUpAndRestoreAutomationAgent), "All students are not selected");
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyUsernameHasCheckBoxAgainstIt(backUpAndRestoreAutomationAgent, "Altagracia D Lindie"), "Altagracia teacher is marked with check mark");
                    ShareFunctionalityCommonMethods.ClickSelectAllButtonInOverlay(backUpAndRestoreAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyUsernameHasCheckBoxAgainstIt(backUpAndRestoreAutomationAgent, "Select All"), "Select All is marked with check mark");
                    ShareFunctionalityCommonMethods.CloseShareMessageOverLay(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);                    
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52652)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void SharingVideoWithMaxSize()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52652: Sharing video at max size and verifying as recipient"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(backUpAndRestoreAutomationAgent, false);
                    NotebookCommonMethods.AddVideoInNotebook(backUpAndRestoreAutomationAgent, true);
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(65000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(backUpAndRestoreAutomationAgent), "Notebook is not open");
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    Login teacherLogin = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, teacherLogin);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    ShareFunctionalityCommonMethods.ClickTapToDownloadInSharedWorkNotification(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.WaitForReceivedNotebookToDownload(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnImageViewButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(65000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(backUpAndRestoreAutomationAgent), "Notebook is not open");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52677), WorkItem(52734)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void AlternatingBetweenSharedAndOwnNotebook()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52677 & TC52734: Verify alternating between shared notebook and own notebook and re-sharing the same notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "Shared Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    Login teacherLogin = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, teacherLogin);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, notebookTask);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "Own Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    ShareFunctionalityCommonMethods.ClickTapToDownloadInSharedWorkNotification(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.WaitForReceivedNotebookToDownload(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnImageViewButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "Shared Notebook"), "Shared Notebook text is not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(backUpAndRestoreAutomationAgent), "Notebook is not open");
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "Own Notebook"), "Own Notebook text is not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent,true);
                    //TC52794                    
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, notebookTask);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "My New Shared Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, teacherLogin);                    
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    ShareFunctionalityCommonMethods.ClickTapToDownloadInSharedWorkNotification(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.WaitForReceivedNotebookToDownload(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnImageViewButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "My New Shared Notebook"), "My New Shared Notebook is found");
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52587)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void CommonReadChangesInSameDevice()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52587: Verifying Common Read changes in the same device"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ClickOnRightArrow(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.CreateAnnotation(backUpAndRestoreAutomationAgent, AnnotationType.Gist, words[0], "Test10");
                    backUpAndRestoreAutomationAgent.ClickOnScreen(500, 500, 1);
                    backUpAndRestoreAutomationAgent.Sleep();
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(backUpAndRestoreAutomationAgent, AnnotationType.Gist, words[0]);
                    Assert.AreEqual(true, CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(backUpAndRestoreAutomationAgent));
                    CommonReadCommonMethods.ClickDeleteButton(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ClickOnRightArrow(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(backUpAndRestoreAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.VerifyAnnotationTextFound(backUpAndRestoreAutomationAgent, "Test10");
                    CommonReadCommonMethods.CreateAnnotation(backUpAndRestoreAutomationAgent, AnnotationType.Gist, words[0], "Test10");
                    backUpAndRestoreAutomationAgent.ClickOnScreen(500, 500, 1);
                    backUpAndRestoreAutomationAgent.Sleep();
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52669)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifySharedContentInAnotherDevice()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52669: Verify shared content in another device"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "Shared Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    Login teacherLogin = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, teacherLogin);                    
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    ShareFunctionalityCommonMethods.ClickTapToDownloadInSharedWorkNotification(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.WaitForReceivedNotebookToDownload(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnImageViewButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "Shared Notebook"), "Shared Notebook text is not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, notebookTask);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "Shared Notebook"), "Shared Notebook text is not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
               

        //This test method involves in deleting the app, while executing we need to make sure that we either run this at the end or beginning of execution
        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52593)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyNotebookBackupAfterDeletingApp()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52593: Verify Notebook backup is working fine after deleting the app"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "My Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    backUpAndRestoreAutomationAgent.UninstallApp(ConfigurationManager.AppSettings["DevLaunchingAppName"].ToString());
                    backUpAndRestoreAutomationAgent.InstallApp(ConfigurationManager.AppSettings["DevelopLocalIpaFilePath"].ToString());

                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.VerifyGradeSelectionScreen(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep();
                    LoginLogoutCommonMethods.AddSpecifiedGrade(backUpAndRestoreAutomationAgent, 4);
                    NavigationCommonMethods.WaitForUnitsToDownload(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(backUpAndRestoreAutomationAgent, 4);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(backUpAndRestoreAutomationAgent, 2);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(backUpAndRestoreAutomationAgent, 2);
                    backUpAndRestoreAutomationAgent.Sleep();
                    NavigationCommonMethods.WaitForLessonToDownload(backUpAndRestoreAutomationAgent, 2);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "My Notebook"), "My Notebook text is not found");
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests"), TestCategory("212SmokeTests")]
        [WorkItem(11111)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyBackupAndRestoreContentInAnotherDevice()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC11111: Verify backup and restore content in another device"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "B&R Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    
                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, notebookTask);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent, true);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "B&R Notebook"), "B&R Notebook text is not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52647)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifySectionedStudentSharingNotebook()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52647: Verify sectioned student sharing notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "Shared Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "Shared Notebook");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //Steps needs to be updatd in Rally
        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52653)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifySavingNotebookWhenWifiIsUnavailable()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52653: Verify saving notebook when wifi is not available"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.ChangeWiFiConnectivity(backUpAndRestoreAutomationAgent, true);
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    //To be Implemented
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52675)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void SharingVideoAndPlaying()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52675: Sharing video and playing"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.AddImageInNoteBook(backUpAndRestoreAutomationAgent, false);
                    NotebookCommonMethods.AddVideoInNotebook(backUpAndRestoreAutomationAgent, true);
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(65000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(backUpAndRestoreAutomationAgent), "Notebook is not open");
                    NotebookCommonMethods.ClickShareNotebookIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectTeacherAltagracia(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSendButton(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickonOKButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    Login teacherLogin = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, teacherLogin);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    ShareFunctionalityCommonMethods.ClickTapToDownloadInSharedWorkNotification(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.WaitForReceivedNotebookToDownload(backUpAndRestoreAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnImageViewButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickViewInLessonButton(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.Sleep(65000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(backUpAndRestoreAutomationAgent), "Notebook is not open");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52605)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void RetrievingNotebook()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52605: Retrieving Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, notebookTask);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(backUpAndRestoreAutomationAgent, "B&R Notebook");
                    NotebookCommonMethods.TapOnScreen(backUpAndRestoreAutomationAgent, 1100, 500, 1);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, notebookTask);
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent, true);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(backUpAndRestoreAutomationAgent, "B&R Notebook"), "B&R Notebook text is not found");
                    NotebookCommonMethods.ClickOnNotebookIcon(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52584)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void InteractiveBackupOnMultipleDevicesAndUsers()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52584: Verify Interactives backup on multiple devices by multiple users"))
            {
                try
                {
                    Login login1 = Login.GetLogin("GustadMody");
                    Login login2 = Login.GetLogin("KiranAnantapalli");
                    TaskInfo interactiveTask1 = login1.GetTaskInfo("Math", "Interactive");
                    TaskInfo interactiveTask2 = login2.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);                    
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "1", "1");
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "2", "3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login2);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask2);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "1", "3");
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "2", "1");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    backUpAndRestoreAutomationAgent.LaunchDevice1();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login2);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask2);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea1(backUpAndRestoreAutomationAgent, "2"), "Item 2 is not found in Drop area 1");
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea3(backUpAndRestoreAutomationAgent, "1"), "Item 1 is not found in Drop area 3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);

                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea1(backUpAndRestoreAutomationAgent, "1"), "Item 1 is not found in Drop area 1");
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea3(backUpAndRestoreAutomationAgent, "2"), "Item 2 is not found in Drop area 3");                    
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52627)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void InteractiveBackupOnMultipleDevices()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52627: Verify Interactives backup on multiple devices"))
            {
                try
                {
                    Login login1 = Login.GetLogin("GustadMody");
                    TaskInfo interactiveTask1 = login1.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "1", "1");
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "2", "3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);
                    
                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea1(backUpAndRestoreAutomationAgent, "1"), "Item 1 is not found in Drop area 1");
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea3(backUpAndRestoreAutomationAgent, "2"), "Item 2 is not found in Drop area 3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52624)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void InteractiveBackupOnSameDevice()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52624: Verify Interactives backup on same device"))
            {
                try
                {
                    Login login1 = Login.GetLogin("GustadMody");
                    TaskInfo interactiveTask1 = login1.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "1", "1");
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "2", "3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea1(backUpAndRestoreAutomationAgent, "1"), "Item 1 is not found in Drop area 1");
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea3(backUpAndRestoreAutomationAgent, "2"), "Item 2 is not found in Drop area 3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
                

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52681)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void RestoringDrawingInCR()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52681: Verify restoring drawing in a common read"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo commonReadTask = login.GetTaskInfo("ELA", "CommonRead");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));                    
                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.DrawDiamondImage(1000, 700);
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyDiamondImageExistsInNB(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52682)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void RestoringAnnotationsAndHighlightsInCR()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52681: Verify restoring annotations and highlights in a common read"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    TaskInfo commonReadTask = login.GetTaskInfo("ELA", "CommonRead");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);

                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(backUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyDiamondImageExistsInNB(backUpAndRestoreAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52582)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void CreateInteractiveOnSingleDevice()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52582: Verify creating interactive on single device"))
            {
                try
                {
                    Login login1 = Login.GetLogin("GustadMody");
                    TaskInfo interactiveTask1 = login1.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "1", "1");
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "2", "3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent, true);

                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea1(backUpAndRestoreAutomationAgent, "1"), "Item 1 is not found in Drop area 1");
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea3(backUpAndRestoreAutomationAgent, "2"), "Item 2 is not found in Drop area 3");
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);                    
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestoreTests")]
        [WorkItem(52583)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifygingInteractiveOnMultipleDevice()
        {
            using (backUpAndRestoreAutomationAgent = new AutomationAgent("TC52583: Verify restoring interactive on multiple device"))
            {
                try
                {
                    Login login1 = Login.GetLogin("GustadMody");
                    TaskInfo interactiveTask1 = login1.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "1", "1");
                    InteractiveCommonMethods.DropItemInArea(backUpAndRestoreAutomationAgent, "2", "3");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);

                    backUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.Login(backUpAndRestoreAutomationAgent, login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(backUpAndRestoreAutomationAgent, interactiveTask1);
                    InteractiveCommonMethods.OpenInteractive(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClosePopUp(backUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea1(backUpAndRestoreAutomationAgent, "1"), "Item 1 is not found in Drop area 1");
                    Assert.IsTrue(InteractiveCommonMethods.VerifyItemInDropArea3(backUpAndRestoreAutomationAgent, "2"), "Item 2 is not found in Drop area 3");
                    InteractiveCommonMethods.ClickResetButton(backUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton(backUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.Logout(backUpAndRestoreAutomationAgent);
                }
                catch (Exception ex)
                {
                    backUpAndRestoreAutomationAgent.Sleep(2000);
                    backUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    backUpAndRestoreAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
