using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    /// <summary>
    /// Summary description for ShareFunctionalityTests
    /// </summary>
    [TestClass]
    public class ShareFunctionalityTests
    {
        public AutomationAgent sharefunctionalityAutomationAgent;
        public ShareFunctionalityTests()
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
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23158)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void SelectPagesOverlayVerification()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23158:Notebook:Tapping share/upload icon on notebook nav bar triggers 'Select Pages Overlay'"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySelectPageOvelayPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickSharingCancelButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22132)]
        [Priority(3)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void SharingTitleBarIconsFunctionality()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22132:Shared Notebooks :Title Bar Icons Functionality verification'"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 40, 340, 1);
                    NotebookCommonMethods.AddNewNotebookPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickRightArrowIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySelectPageOvelayPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickSharingCancelButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookRegionPresent(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23173)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void WorkBrowserDoneButtonFunctionality()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23173:Shared Notebooks : Verify if [Done] button returns to proper Work Browser view (My Class/My Teacher)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyClassFilter(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnReceivedWork(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyMyClassPage(sharefunctionalityAutomationAgent, taskInfo.Grade.ToString());
                    WorkBrowserCommonMethods.ClickMyClassViewingFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnReceivedWork(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyMyTeacherPage(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22173)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void ReceivedandSentWorkOverlayClosure()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22173: Received work and Sent work overlays, tapping outside the overlay closes overlay"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TestNote");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);

                    Login loginstud = Login.GetLogin("StudentBruceSec9Apatton");

                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginstud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginstud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnReceivedWork(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSentButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentWokOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }

        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22458)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void TeacherSharedWorkDropDown()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22458: Shared Work drop down for Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestWork(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnReceivedWork(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickSharedWorkGoToWorkBrowser(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifySharedNotebookWorkBrowserViewNotFound(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickTeacherMyClass(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyDefaultAssociatedSectionPresent(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(20152)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void SectionTeacherSharedHistoryIcon()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC20152: Section Teacher-Show shared history icon in every screen (chrome bar)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    ShareFunctionalityCommonMethods.VerifyShareNotebookIconPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 120, 50, 1);

                    NavigationCommonMethods.NavigateToELA(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyShareNotebookIconPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 120, 50, 1);

                    NavigationCommonMethods.ClickOnUnitWithinLesson(sharefunctionalityAutomationAgent, 1);
                    ShareFunctionalityCommonMethods.VerifyShareNotebookIconPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 120, 50, 1);

                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(sharefunctionalityAutomationAgent, 1);
                    ShareFunctionalityCommonMethods.VerifyShareNotebookIconPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 120, 50, 1);

                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(sharefunctionalityAutomationAgent, 2);
                    ShareFunctionalityCommonMethods.VerifyShareNotebookIconPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 120, 50, 1);

                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyShareNotebookIconPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySharedWorkOverlayPresent(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }
        }



        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22466)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void SentWorkOverlay()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22466: Sent Work Overlay"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep(10000);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickFilterDropDown(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSectionPeriod(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    System.Threading.Thread.Sleep(4000);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 278, 924, 1);
                    ShareFunctionalityCommonMethods.ClickOnSentButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentDetails(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyNumberofPages(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyStudentBruce(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickCloseButtonInSentWorkOverlay(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22768)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void NotebookSharingWithOtherStudents()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22768: Student can share notebooks with other students"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));

                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);

                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectAllPagesButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentCampisano(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23359)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifyConfrimationofReceivingNotebook()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23359: Confirm receipt of notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    string work = "TestNote";
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TestNote");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectAllPagesButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");

                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickDropDownButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickToOpenLatestReceivedWork(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 304, 40, 1);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyWorkRecieved(sharefunctionalityAutomationAgent, work), "Work send note saved");
                    NotebookCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(14404)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void SectionStudentShowSharedHistoryIconInEveryScreenChromeBar()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC14404: Section Student-Show shared history icon in every screen (chrome bar)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(sharefunctionalityAutomationAgent), "Dashboard page is not present");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySharedWorkNotificationIcon(sharefunctionalityAutomationAgent), "shared work notification icon not present");
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySharedWorkList(sharefunctionalityAutomationAgent), "Shared Work list not present");
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySharedWorkNotificationIcon(sharefunctionalityAutomationAgent), "shared work notification icon not present");
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22770)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifyReceivedSentNotebooksInWorkBrowser()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22770: Students and teacher should be able to view received notebooks in their work browser"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnRecievedWork(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyRecievedWorkOverlayPresent(sharefunctionalityAutomationAgent), "Received work overlay not found");
                    sharefunctionalityAutomationAgent.ClickOnScreen(2000, 300);
                    ShareFunctionalityCommonMethods.ClickOnSentButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentDetails(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.ClickOnScreen(2000, 300);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22350)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifySharedDateAndSentDate()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22350: Shared work date is always based on the ‘sent’ date"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    string dateStr1 = DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("yy");
                    string dateStr2 = DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + "-" + DateTime.Now.ToString("yy");
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TEST");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyDateOfSentNotebook(sharefunctionalityAutomationAgent, dateStr1, dateStr2), "Date of sent notebook not found");
                    sharefunctionalityAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(20595)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifyStudentToggleBetweenChoices()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC20595: Verify that student cantoggle between choices"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(sharefunctionalityAutomationAgent), "Dashbaord Page not present");
                    NavigationCommonMethods.NavigateMyDashboard(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(sharefunctionalityAutomationAgent), "Dashboard page not present");
                    NavigationCommonMethods.VerifySystemTraySubMenu(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(sharefunctionalityAutomationAgent), "ELA Page not present");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(sharefunctionalityAutomationAgent);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();
                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyShareOverlay(sharefunctionalityAutomationAgent), "Overlay not found after ");
                    Login loginTchr = Login.GetLogin("Sec9Apatton");
                    NotebookCommonMethods.SelectTeacherRecipient(sharefunctionalityAutomationAgent, loginTchr.PersonName);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyRecepientSelected(sharefunctionalityAutomationAgent), "not selected");
                    NotebookCommonMethods.SelectTeacherRecipient(sharefunctionalityAutomationAgent, loginTchr.PersonName);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyRecepientSelected(sharefunctionalityAutomationAgent), "not selected");
                    ShareFunctionalityCommonMethods.CLickonCancelInCommonReadShareOverlay(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(20596), WorkItem(22037)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifySharingAnnotationFromTheCommonRead()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC20596 & TC22037: Sharing annotation from the common read"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    CommonReadCommonMethods.OpenCommonRead(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(sharefunctionalityAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();

                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.VerifyElementsInShareButtonPopUp(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyShareOverlay(sharefunctionalityAutomationAgent), "Overlay not found after ");
                    ShareFunctionalityCommonMethods.CLickonCancelInCommonReadShareOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyShareOverlay(sharefunctionalityAutomationAgent), "Overlay found after pressing cancel");
                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifySendActive(sharefunctionalityAutomationAgent), "Send button note active");
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifySendButtonEnabledColor(sharefunctionalityAutomationAgent), "Send button is active");
                    
                    Login loginTeacher = Login.GetLogin("Sec9Apatton");
                    NotebookCommonMethods.SelectRecipientsForShare(sharefunctionalityAutomationAgent, loginTeacher.PersonName);
                    
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySendActive(sharefunctionalityAutomationAgent), "Send button note active");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySendButtonEnabledColor(sharefunctionalityAutomationAgent), "Send button is active");
                    CommonReadCommonMethods.ClickSend(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(sharefunctionalityAutomationAgent);

                    CommonReadCommonMethods.SelectAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(21726)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifyAnnotationCreatedInSharedMode()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC21726:Verify user able to create annotation in shared open."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    CommonReadCommonMethods.OpenCommonRead(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(sharefunctionalityAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();

                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.SelectSectionPeriod(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginstud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginstud.PersonName);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginstud);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyELACommonReadSharedWork(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnCommonReadSharedWork(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SelectTeacherRecipient(sharefunctionalityAutomationAgent, login.PersonName);
                    Assert.IsTrue(CommonReadCommonMethods.CreateAnnotationWhileSharedAnnoation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0], "Annotation menu found"));

                    sharefunctionalityAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }


            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22335)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void VerifySharedDateofWork()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22335: Shared work date is always based on the ‘sent’ date"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    string dateStr1 = DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("yy");
                    string dateStr2 = DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + "-" + DateTime.Now.ToString("yy");
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TEST");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyDateOfSentNotebook(sharefunctionalityAutomationAgent, dateStr1, dateStr2), "Date of sent notebook not found");
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23361)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void ConfirmReceiptofSharedNotebooks()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23361: Notebook Sharing - Student - Log in as recipient and confirm receipt of notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));

                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);

                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");

                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ConfirmNotebookShare(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SuccessNotebookShare(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickDropDownButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 40, 304, 1);
                    ShareFunctionalityCommonMethods.VerifySentWorkRecieved(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23159)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void OverlayHeading()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23159: Overlay heading"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickOnNotebookAddPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyNextButtonLowerRightCorner(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySelectAllButtonOnLowerLeftCorner(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyPagesSelectedInCentre(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23157)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SelectPagesOverlayDisplaysOnlyNotebooksWithMultiplePages()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23157: “Select Pages” overlay displays only with notebooks with multiple pages"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickOnNotebookAddPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySelectPagesOverlayDislayed(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23162), WorkItem(23161)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifySelectingPageInSelectPagesOverlay()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23162 & TC23161: verifies a selected page(s) in select pages overlay"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickOnNotebookAddPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySelectPagesOverlayDislayed(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyPagesInShareSelectPagesOverlay(sharefunctionalityAutomationAgent, 2), "Pages and numbers below them are not shown");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyNoCheckboxIsDisplayed(sharefunctionalityAutomationAgent, 2), "Checkbox is displayed");
                    ShareFunctionalityCommonMethods.ClickPageInSelectSharePagesOverlay(sharefunctionalityAutomationAgent, 2);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySelectedPage(sharefunctionalityAutomationAgent, 2), "Selected page not displayd properly");
                    ShareFunctionalityCommonMethods.ClickSelectAllButtonInOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySelectAllButtonChecked(sharefunctionalityAutomationAgent), "Select All button is not highlighted");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyAllPagesSelected(sharefunctionalityAutomationAgent, 2), "All pages are not selected");
                    ShareFunctionalityCommonMethods.ClickSelectAllButtonInOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyAllPagesSelected(sharefunctionalityAutomationAgent, 2), "Pages are selected");
                    ShareFunctionalityCommonMethods.ClickXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22612), WorkItem(22128)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyColorOfELATile()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22612 & TC22128: verifies the color ELA tile"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyELATileColor(sharefunctionalityAutomationAgent), "Tile background color doesn't match");
                    ShareFunctionalityCommonMethods.ClickXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22613)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyColorOfMathTile()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22613: verifies the color Math tile"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyMathTileColor(sharefunctionalityAutomationAgent), "Tile background color doesn't match");
                    ShareFunctionalityCommonMethods.ClickXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(23160)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifySelectPagesOverlayHeadingActions()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC23160: verifies select pages overlay heading actions"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickOnNotebookAddPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "Second Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySelectPagesOverlayDislayed(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyNextButtonEnabled(sharefunctionalityAutomationAgent), "Next button is enabled");
                    ShareFunctionalityCommonMethods.ClickPageInSelectSharePagesOverlay(sharefunctionalityAutomationAgent, 2);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyNextButtonEnabled(sharefunctionalityAutomationAgent), "Next button is not enabled");
                    Assert.AreEqual<int>(1, ShareFunctionalityCommonMethods.GetNoOfPagesSelected(sharefunctionalityAutomationAgent, "1 Page"), "No of selected pages is not corrected");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySelectAllButtonOnLowerLeftCorner(sharefunctionalityAutomationAgent), "Select All button is not found");
                    ShareFunctionalityCommonMethods.ClickPageInSelectSharePagesOverlay(sharefunctionalityAutomationAgent, 1);
                    Assert.AreEqual<int>(2, ShareFunctionalityCommonMethods.GetNoOfPagesSelected(sharefunctionalityAutomationAgent, "2 Pages"), "No of selected pages is not corrected");
                    ShareFunctionalityCommonMethods.ClickOnNextButtonInSelectPageOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyShareOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickXButtonOnUpperRightCorner(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22460)]
        [Priority(3)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void StudentSharedWorkDropdown()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22460:Shared Work drop down for Student"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton"); 
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(sharefunctionalityAutomationAgent);
                    System.Threading.Thread.Sleep(4000);
                    ShareFunctionalityCommonMethods.ClickSharedWorkGoToWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyMyTeacherPage(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);


                    Login loginStud1 = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    Login loginStudBruce = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStudBruce.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStudBruce);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnLatestSharedWork(sharefunctionalityAutomationAgent);
                    System.Threading.Thread.Sleep(4000);
                    ShareFunctionalityCommonMethods.ClickSharedWorkGoToWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyMyClassPage(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);



                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }
        }



        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(16078)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void NotificationsPopUpLayotVerifaction()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC16078:  Notifications Pop Up - Open popup and verify layot"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));

                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    string dateStr1 = DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("yy");
                    string dateStr2 = DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + "-" + DateTime.Now.ToString("yy");

                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStud);
                    NavigationCommonMethods.NavigateMyDashboard(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWorkNotificationIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySenderAvatar(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyNotificationSharedWorkDetails(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyDateOfSentNotebook(sharefunctionalityAutomationAgent, dateStr1, dateStr2), "Date of sent notebook not found");
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }

        }



        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(21951)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void CommonReadAnnotationDisplay()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC21951: Common Read baseball cards open and displays shared annotations"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    CommonReadCommonMethods.OpenCommonRead(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(sharefunctionalityAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();

                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginstud = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginstud.PersonName);
                    CommonReadCommonMethods.ClickSend(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginstud);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyWorkViewingFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyTeacherFilter(sharefunctionalityAutomationAgent);
                    WorkBrowserCommonMethods.ClickMyTeacherViewingFilter(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 340, 140, 1);
                    ShareFunctionalityCommonMethods.VerifyCommonRead(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSharedWork(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NotebookCommonMethods.SelectTeacherRecipient(sharefunctionalityAutomationAgent, login.PersonName);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 538, 304, 1);
                    CommonReadCommonMethods.SelectAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0]);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyAnnotationMenuPresent(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[1]), "Annotation menu found");
                    NotebookCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22247)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void SentWork()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22247: Sent work"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    Login loginStud = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TestNote");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyDemonstrationResponseSharedNotebook(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentButtonPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSentButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyToLabel(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyStudentBruce(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentDetails(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickCloseInSentWorkOverlay(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(sharefunctionalityAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();

                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStud.PersonName);
                    CommonReadCommonMethods.ClickSend(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);


                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyCommonRead(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnTapToDownload(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentButtonPresent(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnSentButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifySentWokOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyCommonReadSentDetails(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyToLabel(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyStudentBruce(sharefunctionalityAutomationAgent);
                    string dateStr1 = DateTime.Now.ToString("MMM") + " " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("HH:mm:ss");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyDateOfSentNotebook(sharefunctionalityAutomationAgent, dateStr1), "Date of sent notebook not found");
                    ShareFunctionalityCommonMethods.ClickCloseInSentWorkOverlay(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(20771)]
        [Priority(2)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void RecievedSharedWork()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC20771: Viewing Shared Overlay for Received Shared Work in Work Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    Login loginTchr = Login.GetLogin("Sec9Apatton"); 
                    NotebookCommonMethods.SelectTeacherRecipient(sharefunctionalityAutomationAgent, loginTchr.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginTchr);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyAltagraciaSectionView(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyFirstSharedWork(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyDemonstrationResponseSharedNotebook(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnRecievedWork(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyELAunitDetails(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyDemonstrationResponseSharedNotebook(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyStudentBruce(sharefunctionalityAutomationAgent);
                    string dateStr = DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("yy");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyDateOfSentNotebook(sharefunctionalityAutomationAgent, dateStr), "Date of sent notebook not found");
                    ShareFunctionalityCommonMethods.ClickCloseInSentWorkOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyRecievedWorkOverlayPresent(sharefunctionalityAutomationAgent));
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyGoToWorkBrowserPresent(sharefunctionalityAutomationAgent));
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }

            }


        }


        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22325)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.laul)")]
        public void RecievedWorkChronologicalOrder()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22325: Display received items from each student reversed chronologically (last item modified first)"))
            {
                try
                {

                    Login login = Login.GetLogin("Loist");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    Login loginStudBruce = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginStudBruce.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "First Page");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginStudBruce);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickDropDownButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyClassFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyDemonstrationResponseSharedNotebook(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickToOpenLatestReceivedWork(sharefunctionalityAutomationAgent);
                    System.Threading.Thread.Sleep(4000);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1250, 750, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1290, 750, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "LatestEdited");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1350, 500, 1);
                    ShareFunctionalityCommonMethods.ClickWorkBrowserDoneButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickDropDownButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickMyClassFilter(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOutsideOverlay(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyDemonstrationResponseSharedNotebook(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyFirstSharedWork(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }


            }

        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests"), TestCategory("212SmokeTests")]
        [WorkItem(24356)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AnnotationsSharingVerifyYourWorkWasSentAlert()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC24356: Annotations Sharing - verify Your work was sent alert"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(sharefunctionalityAutomationAgent);

                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[2], "Test1");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.CreateAnnotation(sharefunctionalityAutomationAgent, AnnotationType.Gist, words[4], "Test2");
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    sharefunctionalityAutomationAgent.Sleep();
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnAnnotatedText(sharefunctionalityAutomationAgent, words[2]);
                    CommonReadCommonMethods.ClickAnnotationShareButton(sharefunctionalityAutomationAgent);
                    Login loginTchr = Login.GetLogin("Sec9Apatton");
                    NotebookCommonMethods.SelectTeacherRecipient(sharefunctionalityAutomationAgent, loginTchr.PersonName);
                    CommonReadCommonMethods.ClickSend(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWorkSentMessage(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginTchr);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(sharefunctionalityAutomationAgent, 1);
                    NavigationCommonMethods.ClickNotebooksInMyClass(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(sharefunctionalityAutomationAgent, 1);
                    NavigationCommonMethods.ClickFirstELACommonRead(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.ClickOnScreen(104, 434, 1);
                    sharefunctionalityAutomationAgent.Sleep(5000);
                    CommonReadCommonMethods.ClickOnAnnotatedText(sharefunctionalityAutomationAgent, words[2]);
                    CommonReadCommonMethods.ClickSharedAnnotations(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickOnBruceSender(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickOnAnnotatedText(sharefunctionalityAutomationAgent, words[4]);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(sharefunctionalityAutomationAgent));
                    sharefunctionalityAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickViewMyAnnotations(sharefunctionalityAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);

                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22608)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyWifiRequiredMessageForReceivedNotebooks()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22608: Verify Wifi required message for received notebooks"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TestNote");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);

                    Login loginTchr = Login.GetLogin("Sec9Apatton");

                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, loginTchr.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);


                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, loginTchr);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, loginTchr.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(sharefunctionalityAutomationAgent, true);
                    sharefunctionalityAutomationAgent.LaunchApp();
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnTapToDownload(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNoWifiMessageOnTapToDownload(sharefunctionalityAutomationAgent), "No Wifi message is not displayed");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(sharefunctionalityAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    NavigationCommonMethods.ChangeWiFiConnectivity(sharefunctionalityAutomationAgent, false);
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22605)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyReceivedNotebooksCounter()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22605: Verify received notebooks counter changes"))
            {
                try
                {
                    Login teacherlogin = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, teacherlogin);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, teacherlogin.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    int oldNoOfNotebooksReceived = NotebookCommonMethods.GetNumerOfReceivedBooksFromTitle(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent, true);
                    Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, studentLogin);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, teacherlogin.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickDrawingIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1250, 650, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectAllPagesButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SelectRecipientsForShare(sharefunctionalityAutomationAgent, teacherlogin.PersonName);
                    NotebookCommonMethods.ClickNextNotebookShare(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.SendText("Sharing with teacher");
                    NotebookCommonMethods.ClickSendNotebookShare(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ConfirmNotebookShare(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NotebookCommonMethods.SuccessNotebookShare(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, teacherlogin);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, teacherlogin.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    int newNoOfNotebooksReceived = NotebookCommonMethods.GetNumerOfReceivedBooksFromTitle(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickXBrowserNoteXButton(sharefunctionalityAutomationAgent);
                    Assert.AreEqual<int>(oldNoOfNotebooksReceived + 1, newNoOfNotebooksReceived, "No of received notebooks didn't increase by 1 after sharing one notebook");
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22604)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyOverlayWithReceivedNotebooks()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22604: Verify received notebooks tile in work browser overlay when notebooks received"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNumerOfReceivedBooksFromTitle(sharefunctionalityAutomationAgent), "Received Notebooks number is not matching with the number of tiles");
                    Assert.IsTrue(NotebookCommonMethods.VerifySenderInfoInTiles(sharefunctionalityAutomationAgent), "Received Notebook tiles doesn't have sender details");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22429)]
        [Priority(1)]
        [Owner("Narsimhan Narayanan(narsimhan.narayanan)")]
        public void VerifyNoteBookPreviewFromSharedWorkDropDown()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22429: To Verify Notebook Preview from shared work drop down"))
            {
                try
                {
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, Login.GetLogin("Sec9Apatton"));
                    CommonReadCommonMethods.ClickOnSharedWorkIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnReceivedWorkTile(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnImageViewButton(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyNotebookShareIconPresent(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22609)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyDownloadingReceivedNotebooks()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22609: Verify downloading received notebooks"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnTapToDownload(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyReceivedNBDownloadInProgress(sharefunctionalityAutomationAgent), "Downloding progress bar is not found");
                    NotebookCommonMethods.ClickXBrowserNoteXButton(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(26299)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookHeaderShareButtonFunctionality()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC26299: Notebook Header share button functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    string taskName = NotebookCommonMethods.GetTaskName(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "Tester");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(sharefunctionalityAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnCommonReads(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(sharefunctionalityAutomationAgent, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 104, 434, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookShareButton(sharefunctionalityAutomationAgent), "Notebook share button not present");
                    NotebookCommonMethods.ClickNotebookShareButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookSharingWorkflow(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickCancelButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookSnapshotDone(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22611)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void BrowseNotesOpenDownloadedReceivedNotebook()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22611: Browse Notes overlay - Received Notebooks - open downloaded Received Notebook"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "TestNote");
                    NotebookCommonMethods.TapOnScreen(sharefunctionalityAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickShareNotebookIcon(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.SelectSharingSection(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    login = Login.GetLogin("StudentBruceSec9Apatton");
                    ShareFunctionalityCommonMethods.SelectStudentForSharing(sharefunctionalityAutomationAgent, login.PersonName);
                    ShareFunctionalityCommonMethods.ClickOnNextButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.SendText(sharefunctionalityAutomationAgent, "my teacher");
                    ShareFunctionalityCommonMethods.ClickOnSendButton(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.VerifyWokWillBeSentMessage(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyWorkSuccesfulyShared(sharefunctionalityAutomationAgent);
                    sharefunctionalityAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent, true);

                    
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(sharefunctionalityAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnFolderIcon(sharefunctionalityAutomationAgent);
                    NotebookCommonMethods.ClickOnTapToDownload(sharefunctionalityAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyReceivedNBDownloadInProgress(sharefunctionalityAutomationAgent), "Downloding progress bar is not found");
                    ShareFunctionalityCommonMethods.WaitForReceivedNotebookToDownload(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.ClickRecievedNotebookInBrowseOverlay(sharefunctionalityAutomationAgent);
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyBrowseNotesOverlayPresent(sharefunctionalityAutomationAgent), "Browse Notes Overlay is present");
                    Assert.IsFalse(ShareFunctionalityCommonMethods.VerifyUserNotebookIsOpened(sharefunctionalityAutomationAgent), "NotebookCommonMethods is opened");
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifySharedNotebookOpen(sharefunctionalityAutomationAgent), "Shared Notebook not opened");
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(20273)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NotificationButton()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC20273: Notification button"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(sharefunctionalityAutomationAgent);
                    DashboardCommonMethods.ClickOnNotificationIconInChrome(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyNotificationDropdownDisplayed(sharefunctionalityAutomationAgent);
                    ShareFunctionalityCommonMethods.VerifyMostRecentNotificationDispalyedFirst(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ShareFunctionalityTests")]
        [WorkItem(22001)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TileFooterDisplaysXReceived()
        {
            using (sharefunctionalityAutomationAgent = new AutomationAgent("TC22001: Tile footer displays “x number” received if common reads have been received"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(sharefunctionalityAutomationAgent, login);
                    NavigationCommonMethods.NavigateMyDashboard(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.NavigateWorkBrowser(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(sharefunctionalityAutomationAgent, 1);
                    NavigationCommonMethods.ClickNotebooksInMyClass(sharefunctionalityAutomationAgent);
                    NavigationCommonMethods.ClickDownChevronIcon(sharefunctionalityAutomationAgent, 1);
                    Assert.IsTrue(ShareFunctionalityCommonMethods.VerifyXNumberOfNotebooksReceived(sharefunctionalityAutomationAgent), "Number of Received items are not present");
                    NavigationCommonMethods.Logout(sharefunctionalityAutomationAgent);
                }
                catch (Exception ex)
                {
                    sharefunctionalityAutomationAgent.Sleep(2000);
                    sharefunctionalityAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    sharefunctionalityAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
