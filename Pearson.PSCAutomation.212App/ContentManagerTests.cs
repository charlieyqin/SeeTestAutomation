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
    public class ContentManagerTests
    {
        public AutomationAgent contentManagerAutomationAgent;
        public ContentManagerTests()
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
        [TestCategory("ContentManagerTests")]
        [WorkItem(23125)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyContentManageTimeStampColor()
        {
            using (contentManagerAutomationAgent = new AutomationAgent("TC23125: Content Manager: Timestamps appear for content downloaded, coloured ~teal ( #198098  or #187F97)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                    NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyTimestampAndColor(contentManagerAutomationAgent, "0x187F97"), "Color is not 187F97");
                    NavigationCommonMethods.Logout(contentManagerAutomationAgent);
                }
                catch (Exception ex)
                {
                    contentManagerAutomationAgent.Sleep(2000);
                    contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    contentManagerAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(21840)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
         public void UserSeesAppVersionInSettingsScreenContent()
        {
            using (contentManagerAutomationAgent = new AutomationAgent("TC21840:Content Manager - User sees App Version in Settings Screen Content"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                    NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                    ContentManagerCommonMethods.VerifyAppVersionLabel(contentManagerAutomationAgent);
                    NavigationCommonMethods.Logout(contentManagerAutomationAgent);
                }
                catch (Exception ex)
                {
                    contentManagerAutomationAgent.Sleep(2000);
                    contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    contentManagerAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21841)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void UserSeesConfigurationCodeInSettingsScreenContent()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21841:Content Manager-User sees Configuration Code in Settings Screen Content"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   ContentManagerCommonMethods.VerifyConfigurationCode(contentManagerAutomationAgent);
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21845)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void UserSeeDateAndTimeInUpperLeftCorner()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21845:Content Manager-User sees Date of most recent update in the upper left corner"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   string date = ContentManagerCommonMethods.GetUpdatedDateFromContentManager(contentManagerAutomationAgent);
                   DateTime date1 = DateTime.Parse(date);
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21827)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void UserViewsContentManagerButton()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21827:User views a button on the system tray: 'Content Manager'"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.ClickSystemTrayButton(contentManagerAutomationAgent);
                   NavigationCommonMethods.VerifyContentManagerButton(contentManagerAutomationAgent);
                   NavigationCommonMethods.ClickSystemTrayButton(contentManagerAutomationAgent);
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21878)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void UserSeesGlobalNavIconsTrayButtons()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21878:User sees Global Nav Icons tray button, games, shared items)"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(DashboardCommonMethods.VerifySharingNotificationIconInChrome(contentManagerAutomationAgent), "Sharing Notification IconIn Chrome is not found");
                   Assert.IsTrue(LessonBrowserCommonMethods.VerifyResourceLibraryIconPresent(contentManagerAutomationAgent), "ResourceLibraryFlyOutMenu is not found");
                   Assert.IsTrue(NavigationCommonMethods.IsSystemTrayAvailable(contentManagerAutomationAgent), "System tray button is not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }
       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21843)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void UserSeesCachingServerStatus()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21843:User sees Caching Server status in Settings Screen Content"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyCachingServerStatus(contentManagerAutomationAgent), "Caching Server Status is not found");
                   string status = ContentManagerCommonMethods.GetCachingServerStatus(contentManagerAutomationAgent);
                   Assert.AreEqual<string>(status, "Unavailable", "Caching Server Status are not equal");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21829)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void TapContentManagerButtonTakesUserToContentManagerScreen()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21829: When tapped 'Content Manager' button takes the user to the 'Content Manager' screen"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyContentManagerPageHeader(contentManagerAutomationAgent), "Content Manager Page Header is not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21792)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void UserCanSeeContentUpdateAndHistoreQueue()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21792: Content Manager - user can see Conent Updates in queue & history log."))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyContentManagerPageHeader(contentManagerAutomationAgent), "Content Manager Page Header is not found");
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyContentUpdateQueueHistory(contentManagerAutomationAgent), "Content update queue and hstory log not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21837)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void NoNewUpdatesAvailableAppearsIfNoUpdatesToDownload()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21837: Content Manager - 'No new updates available' appears if there are no updates to download"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear(contentManagerAutomationAgent);
                   ContentManagerCommonMethods.ClickCheckForUpdates(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewUpdatesAvailable(contentManagerAutomationAgent), "no new updates label not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(22406)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void DownloadItemsAreInQueueDownloadQueueiNotVisible()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC22406: Content Manager PAGE - When download items are in queue and user goes to setting page, download queue is not visible"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateToELA(contentManagerAutomationAgent);
                   int gradeAdded = NavigationCommonMethods.ClickAddGrade(contentManagerAutomationAgent);
                   contentManagerAutomationAgent.Sleep(20000);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(contentManagerAutomationAgent), "Show details no found");
                   ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear(contentManagerAutomationAgent);
                   ContentManagerCommonMethods.ClickCheckForUpdates(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewUpdatesAvailable(contentManagerAutomationAgent), "no new updates label not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

        

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(22407)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void DownloadItemsAreIncrementedIfAdded()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC22407: Content Manager PAGE - the queue is updated and the total number of download items is incremented if user adds new items"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   
                   int queuecount = ContentManagerCommonMethods.GetDownloadingContentCount(contentManagerAutomationAgent);
                   NavigationCommonMethods.NavigateToELA(contentManagerAutomationAgent);
                   int gradeAdded = NavigationCommonMethods.ClickAddGrade(contentManagerAutomationAgent);
                   contentManagerAutomationAgent.Sleep(20000);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(contentManagerAutomationAgent), "Show details no found");
                   int queuecountnew = ContentManagerCommonMethods.GetDownloadingContentCount(contentManagerAutomationAgent);
                    Assert.IsTrue(queuecountnew > queuecount, "Queue count not updated");
                   ContentManagerCommonMethods.ClickShowDetails(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(contentManagerAutomationAgent), "queue content not found");
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyAddedContentAvailableinQueue(contentManagerAutomationAgent, gradeAdded), "added grade content not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(22410)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void DownloadItemsAreDecrementedWhenDownloaded()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC22410: Content Manager PAGE - the queue is updated and the total number of download items in download queue is decremented"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   int queuecount = ContentManagerCommonMethods.GetDownloadingContentCount(contentManagerAutomationAgent);
                   contentManagerAutomationAgent.Sleep(20000);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(contentManagerAutomationAgent), "Show details no found");
                   int queuecountnew = ContentManagerCommonMethods.GetDownloadingContentCount(contentManagerAutomationAgent);
                   Assert.IsTrue(queuecountnew < queuecount, "Queue count not updated");
                   ContentManagerCommonMethods.ClickShowDetails(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(contentManagerAutomationAgent), "queue content not found");
                   ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear(contentManagerAutomationAgent);
                   Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingContentNoAppears(contentManagerAutomationAgent), "downloading content no appears");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }
       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21797)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void ContentUpdateLogShowsUpdatesByDate()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21797: Content Update log shows the updates by date."))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   string date = ContentManagerCommonMethods.GetUpdatedDateFromContentManager(contentManagerAutomationAgent);
                   DateTime date1 = DateTime.Parse(date);
                   string date2 = ContentManagerCommonMethods.GetSecondLastUpdatedDateContentManager(contentManagerAutomationAgent);
                   DateTime date3 = DateTime.Parse(date);
                   Assert.IsTrue(date1.CompareTo(date3) >= 0, "Log is not shown by date");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(22408)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void ThereAreNoDownloadsinProgressListofDownloadQueueIsBlank()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC22408:Content Manager PAGE - When there are no downloads in progress or no item in the queue, the list of download queue is blank."))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   ContentManagerCommonMethods.ClickShowDetails(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(contentManagerAutomationAgent), "queue content not found");
                   ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear(contentManagerAutomationAgent);
                   Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingContentNoAppears(contentManagerAutomationAgent), "downloading content no appears");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }


       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(22409)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void DownloadingItemsCompletedListofDownloadQueueIsBlank()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC22409: Content Manager PAGE - When all downloading items are completed, the list of download queue is blank."))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);

                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);

                   if (!ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(contentManagerAutomationAgent))
                   {
                       NavigationCommonMethods.NavigateToELA(contentManagerAutomationAgent);
                       int gradeAdded = NavigationCommonMethods.ClickAddGrade(contentManagerAutomationAgent);
                       contentManagerAutomationAgent.Sleep(20000);
                       NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   }

                   ContentManagerCommonMethods.ClickShowDetails(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(contentManagerAutomationAgent), "queue content not found");
                   ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear(contentManagerAutomationAgent);
                   Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingContentNoAppears(contentManagerAutomationAgent), "downloading content no appears");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21804)]
       [Priority(2)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void VerifyContentManageHistoryLog()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21804: Content Manager: Content Update History Log has a clear section header to indicate it's purpose."))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyHeaderAndHistoyLog(contentManagerAutomationAgent), "History log is not in order");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21793)]
       [Priority(3)]
       [Owner("Mohammed Saquib(mohammed.saquib)")]
       public void VerifyHistoryLogDisplayChangesOccurInCourses()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21793: Content Manager - history log displays only changes that occured to existing courses/units/lessons."))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingQueue(contentManagerAutomationAgent, "MATH", taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson), "Downloading history for sectioned content is not found");
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingQueue(contentManagerAutomationAgent, "MATH", 5, "1", 1, 3), "Downloading history for non-sectioned content is found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }

       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21839)]
       [Priority(2)]
       [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
       public void VerifyStatusMessagesInContentManager()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21839: Verify status messages in content manager"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                   TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   ContentManagerCommonMethods.ClickCheckForUpdates(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewUpdatesAvailable(contentManagerAutomationAgent), "No new updates available message is not found");
                    NavigationCommonMethods.NavigateToELAGrade(contentManagerAutomationAgent, taskInfo.Grade);
                   NavigationCommonMethods.ClickELAUnit(contentManagerAutomationAgent, taskInfo.Unit);
                   NavigationCommonMethods.ClickStartInELAUnitLibrary(contentManagerAutomationAgent, taskInfo.Unit);
                   contentManagerAutomationAgent.Sleep(8000);
                   NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
                   Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingItemsMessage(contentManagerAutomationAgent), "Downloading items message is not found");
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }



       [TestMethod()]
       [TestCategory("ContentManagerTests")]
       [WorkItem(21956)]
       [Priority(2)]
       [Owner("Madhav Purohit(madhav.purohit)")]
       public void ContentControlCodefieldExistsDeviceSetting()
       {
           using (contentManagerAutomationAgent = new AutomationAgent("TC21956: content Manager - Content Control Code field exists in device settings"))
           {
               try
               {
                   Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.Login(contentManagerAutomationAgent, login);
                    Assert.IsTrue(NavigationCommonMethods.VerifyContentControlCodefieldExistsDeviceSetting(contentManagerAutomationAgent), "config code control not available");
                   contentManagerAutomationAgent.LaunchApp();
                   NavigationCommonMethods.Logout(contentManagerAutomationAgent);
               }
               catch (Exception ex)
               {
                   contentManagerAutomationAgent.Sleep(2000);
                   contentManagerAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                   contentManagerAutomationAgent.ApplicationClose();
                   throw;
               }
           }
       }


    }
}
