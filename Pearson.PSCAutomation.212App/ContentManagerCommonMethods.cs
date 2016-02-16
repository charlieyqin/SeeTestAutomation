using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public static class ContentManagerCommonMethods
    {
        /// <summary>
        /// Verifies the App Version Label in Content manager
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        public static void VerifyAppVersionLabel(AutomationAgent contentManagerAutomationAgent)
        {
            contentManagerAutomationAgent.VerifyElementFound("ContentManagerView", "AppVersion");
        }
        /// <summary>
        /// Verifies the Config Code Label in Content manager
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        public static void VerifyConfigurationCode(AutomationAgent contentManagerAutomationAgent)
        {
            contentManagerAutomationAgent.VerifyElementFound("ContentManagerView", "ConfigurationCodeLabel");
        }
        /// <summary>
        /// Gets the Updated Date From Content Manager
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string GetUpdatedDateFromContentManager(AutomationAgent contentManagerAutomationAgent)
        {
            string[] s = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "AppVersion", "Down", "").Split('\t');
            return s[0].Replace("Content changes from ", "");
        }
        /// <summary>
        /// Verifies Catching Status is displayed
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        public static bool VerifyCachingServerStatus(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "CachingServerStatus");
        }
        /// <summary>
        /// Displays the status of caching server
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <returns>String: Caching server status</returns>
        public static string GetCachingServerStatus(AutomationAgent contentManagerAutomationAgent)
        {
            string s = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "CachingServerStatus", "Inside", "");
            return s.Replace("\t\n", "");
        }
        /// <summary>
        /// Verifies Content Manager Page Header
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(Content manager page header found), false(not found)</returns>
        public static bool VerifyContentManagerPageHeader(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentManagerPageHeader");
        }

        public static bool VerifyContentUpdateQueueHistory(AutomationAgent contentManagerAutomationAgent)
        {
            if ((!contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentHistoryTableView")) &&
                        (!contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentHistoryTableCell")))
            {
                NavigationCommonMethods.NavigateToELA(contentManagerAutomationAgent);
                int gradeAdded = NavigationCommonMethods.ClickAddGrade(contentManagerAutomationAgent);
                contentManagerAutomationAgent.Sleep(20000);
                NavigationCommonMethods.NavigateContentManager(contentManagerAutomationAgent);
            }

            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentHistoryTableView") &&
                        contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentHistoryTableCell");
        }


        public static void ClickCheckForUpdates(AutomationAgent contentManagerAutomationAgent)
        {
            contentManagerAutomationAgent.Click("ContentManagerView", "CheckForUpdates");
            contentManagerAutomationAgent.Sleep();
        }

        public static bool VerifyNoNewUpdatesAvailable(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "NoNewUpdatesAvailable") && bool.Parse(contentManagerAutomationAgent.GetElementProperty("ContentManagerView", "NoNewUpdatesAvailable", "onscreen"));
        }

        public static void WaitForCheckToUpdatesToAppear(AutomationAgent contentManagerAutomationAgent)
        {
            int trial = 20;
            while (!contentManagerAutomationAgent.IsElementFound("ContentManagerView", "CheckForUpdates") && trial > 0)
            {
                contentManagerAutomationAgent.Sleep();
                trial--;
            }
        }

        public static bool VerifyShowDetailsButtonPresent(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentShowDetailsLabel");
        }

        public static int GetDownloadingContentCount(AutomationAgent contentManagerAutomationAgent)
        {

            if (!VerifyShowDetailsButtonPresent(contentManagerAutomationAgent))
            {
                NavigationCommonMethods.NavigateToELA(contentManagerAutomationAgent);
                int gradeAdded = NavigationCommonMethods.ClickAddGrade(contentManagerAutomationAgent);
                contentManagerAutomationAgent.Sleep(20000);
            }


            return Int32.Parse(contentManagerAutomationAgent.GetElementText("ContentManagerView", "ContentDownloadingItemNos"));
        }

        public static void ClickShowDetails(AutomationAgent contentManagerAutomationAgent)
        {
            contentManagerAutomationAgent.Click("ContentManagerView", "ContentShowDetailsLabel");
        }

        public static bool VerifyQueueContent(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentDownloadQueueTableCell");
        }

        public static bool VerifyDownloadingContentNoAppears(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentDownloadingItemNos");
        }

        public static bool VerifyAddedContentAvailableinQueue(AutomationAgent contentManagerAutomationAgent, int gradeAdded)
        {
            string contenttext = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "ContentDownloadQueueTableCell", "Inside", "");
            if (contenttext.Contains(gradeAdded.ToString()))
                return true;

            else
                return false;
        }
        /// <summary>
        /// Get Second Last Updated Date in Content Manager
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <returns>String</returns>
        public static string GetSecondLastUpdatedDateContentManager(AutomationAgent contentManagerAutomationAgent)
        {
            String a = contentManagerAutomationAgent.GetElementProperty("ContentManagerView", "ContentSecondLastUpdatedDate", "text");
            return a.Replace("Content changes from ", "");
        }
        /// <summary>
        /// Get Third Last Updated Date in Content Manager
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <returns>String</returns>
        public static string GetThirdLastUpdatedDateContentManager(AutomationAgent contentManagerAutomationAgent)
        {
            String n = contentManagerAutomationAgent.GetElementProperty("ContentManagerView", "ContentThirdLastUpdatedDate", "text");
            return n.Replace("Content changes from ", "");
        }

        public static bool VerifyDownloadingUnit(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unit)
        {
            string dynamicVariable = subject + " Grade " + gradeNumber + " Unit " + unit;
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingLessonLabel", dynamicVariable);
        }

        /// <summary>
        /// Verifies the No Wifi status in content manager page and returns a bool
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <returns>No Wifi status</returns>
        public static bool VerifyNoWifiStatus(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "NoWifiImage") && contentManagerAutomationAgent.IsElementFound("ContentManagerView", "NoWifiLabel");
        }
        /// <summary>
        /// Verifies if the grade is displayed as downloading in content manager
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeAdded">Added grade number</param>
        /// <returns>boolean status of grade downloading</returns>
        public static bool VerifyDownloadingGrade(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber)
        {
            string dynamicVariable = subject + " Grade " + gradeNumber;
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingGradeLabel", dynamicVariable);
        }
        /// <summary>
        /// Verifies Time Stamp and colour
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <param name="colorToMatch"></param>
        /// <returns>string</returns>
        public static bool VerifyTimestampAndColor(AutomationAgent contentManagerAutomationAgent, string colorToMatch)
        {
            string text = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "ContentChangesCell", "Inside", "ELA");
            string timestamp = text.Split('\t')[3];
            DateTime timestampDateFormat = new DateTime(Convert.ToInt64(timestamp));
            string color = contentManagerAutomationAgent.GetAllValues("ContentManagerView", "ContentTimestamp", timestamp, "textColor")[0];
            return color.Equals(colorToMatch);
        }
        /// <summary>
        /// Verfies Header and history log
        /// </summary>
        /// <param name="contentManagerAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyHeaderAndHistoyLog(AutomationAgent contentManagerAutomationAgent)
        {
            string text1 = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "ContentChangesCell", "Inside", "ELA");
            string timestamp1 = text1.Split('\t')[3];
            DateTime timestampDateFormat1 = new DateTime(Convert.ToInt64(timestamp1));
            string timestampStr = timestampDateFormat1.ToString("MMMM dd, yyyy");
            string text2 = "";
            if (contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentChangesNextCell", "ELA"))
            {
                text2 = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "ContentChangesNextCell", "Inside", "ELA");
            }
            else
            {
                text2 = contentManagerAutomationAgent.GetTextIn("ContentManagerView", "ContentChangesNextCell", "Inside", "Math");
            }

            string timestamp2 = text2.Split('\t')[3];
            DateTime timestampDateFormat2 = new DateTime(Convert.ToInt64(timestamp2));
            int compare = timestampDateFormat1.CompareTo(timestampDateFormat2);
            bool headerFound = contentManagerAutomationAgent.IsElementFound("ContentManagerView", "ContentHeader", timestampStr);
            if (headerFound && compare >= 0)
            {
                return true;
            }
            return false;
        }

        public static bool VerifyDownloadingQueueForLessonSequence(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unitNumber, int maxLessonNumber)
        {
            string lessonInDownloadingQueue = subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + maxLessonNumber;
            bool lessonfound = false;
            for (int i = 0; i <= 10; i++)
            {
                if (contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingQueueLessonLabel", lessonInDownloadingQueue))
                {
                    for (int j = 0; j < i; j++)
                    {
                        for (int k = 1; k <= 8; k++)
                        {
                            lessonInDownloadingQueue = subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + maxLessonNumber;
                            lessonfound = contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingQueueLessonLabel", lessonInDownloadingQueue);
                            maxLessonNumber--;
                        }
                        if (contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingLessonLabel", ""))
                        {
                            break;
                        }
                        contentManagerAutomationAgent.Drag(1000, 250, 1000, 800);
                    }
                    break;
                }
                contentManagerAutomationAgent.Drag(1000, 800, 1000, 250);
            }
            return lessonfound;
        }

        public static bool VerifyDownloadingQueueForLessonByScrolling(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unitNumber, int lessonNumber)
        {
            string lessonInDownloadingQueue = subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + lessonNumber;
            bool lessonfound = false;
            for (int i = 0; i <= 10; i++)
            {
                if (contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingQueueLessonLabel", lessonInDownloadingQueue))
                {
                    lessonfound = true;
                    break;
                }
                contentManagerAutomationAgent.Drag(1000, 800, 1000, 250);
            }
            return lessonfound;
        }
        /// <summary>
        /// Verifies Downloading Queue 
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <param name="subject"></param>
        /// <param name="gradeNumber"></param>
        /// <param name="unitNumber"></param>
        /// <param name="lessonNumber"></param>
        /// <returns>bool</returns>
        public static bool VerifyDownloadingQueue(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unitNumber, int lessonNumber, int rounds = 50)
        {
            string lessonInDownloadingQueue = "Lesson - " + subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + lessonNumber;
            return contentManagerAutomationAgent.SwipeWhileNotFound("ContentManagerView", "ContentChangeLogCell", lessonInDownloadingQueue, Direction.Down.ToString(), 750, 0, 1000, rounds);
        }

        public static bool VerifyDownloadingItemsMessage(AutomationAgent contentManagerAutomationAgent)
        {
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingItems") && bool.Parse(contentManagerAutomationAgent.GetElementProperty("ContentManagerView", "DownloadingItems", "onscreen"));
        }
        /// <summary>
        /// Verifies if the lesson is downloading currently
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent"></param>
        /// <param name="subject"></param>
        /// <param name="grade"></param>
        /// <param name="lesson"></param>
        /// <param name="lessonNumber"></param>
        /// <returns></returns>
        public static bool VerifyLessonDownloadingCurrently(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unitNumber, int lessonNumber)
        {
            string lessonInDownloadingQueue = subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + lessonNumber;
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingLessonLabel", lessonInDownloadingQueue);
        }
        /// <summary>
        /// Verifies if the lesson is in the downloading queue without scrolling down
        /// </summary>
        /// <param name="contentManagerAutomationAgent">AutomationAgent object</param>
        /// <param name="subject">Subject</param>
        /// <param name="gradeNumber">Grade Number</param>
        /// <param name="unitNumber">Unit Number</param>
        /// <param name="lessonNumber">Lesson Number</param>
        /// <returns>boolean status of lesson availability in download queue</returns>
        public static bool VerifyDownloadingQueueForLessonWithoutScrolling(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unitNumber, int lessonNumber)
        {
            string lessonInDownloadingQueue = subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + lessonNumber;
            return contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingQueueLessonLabel", lessonInDownloadingQueue);
        }

        public static bool VerifyQueuedLessonStartsDownloading(AutomationAgent contentManagerAutomationAgent, string subject, int gradeNumber, string unitNumber, int lessonNumber1, int LessonNumber2)
        {
            string lessonInDownloadingQueue = subject + " Grade " + gradeNumber + " Unit " + unitNumber + " Lesson " + lessonNumber1;
            for (int i = 0; i <= 100; i++)
            {
                if (contentManagerAutomationAgent.IsElementFound("ContentManagerView", "DownloadingLessonLabel", lessonInDownloadingQueue))
                    break;
                contentManagerAutomationAgent.Sleep();
            }
            return VerifyLessonDownloadingCurrently(contentManagerAutomationAgent, subject, gradeNumber, unitNumber, LessonNumber2);
        }
    }
}


