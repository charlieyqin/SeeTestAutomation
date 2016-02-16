using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    public static class AssessmentCommonMethods
    {
        /// <summary>
        /// Click on Assessment in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickAssessmentInAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentTitle)
        {
            if (!AssessmentAutomationAgent.IsElementFound("UnitSelection", "UnitSelectionELABackground"))
            {
                NavigationCommonMethods.ClickOnSystemTray(AssessmentAutomationAgent);
                NavigationCommonMethods.ClickOnUnitSlectionButton(AssessmentAutomationAgent);
            }            
            NavigationCommonMethods.ClickOnSystemTray(AssessmentAutomationAgent);
            if (!AssessmentAutomationAgent.IsElementFound("BookBuilderView", "BookPageCount", assessmentTitle))
            {
                NavigationCommonMethods.ClickonAssessmentManager(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep();
                AssessmentAutomationAgent.Click("BookBuilderView", "BookPageCount", assessmentTitle);
            }
            else
            {
                AssessmentAutomationAgent.Click("BookBuilderView", "BookPageCount", assessmentTitle);
            }
            AssessmentAutomationAgent.Sleep();
            WaitForPageToload(AssessmentAutomationAgent);
            VerifyAssessmentManagerTitlePresent(AssessmentAutomationAgent);
        }

        public static bool VerifyAssessmentManagerInSystemTray(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("UnitSelection", "AssessmentManagerButton");
        }


        /// <summary>
        /// Verifies Teacher is able to select particular unit from the dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void SelectUnitFromUnitSelectionScreen(AutomationAgent AssessmentAutomationAgent,int gradeNo,string unitName)
        {
            if (gradeNo.ToString().Equals("KG"))
            { 
                if(AssessmentAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "ELAUnitColumn", "UnitSelection", "ELAUNITButton", unitName, "Down"))
                {
                    while (AssessmentAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                    {
                        AssessmentAutomationAgent.WaitForElementToVanish("UnitSelection", "CancelDownload", WaitTime.LargeWaitTime);
                        if (!AssessmentAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                        {
                            AssessmentAutomationAgent.Click("UnitSelection", "ELAUNITButton", unitName);
                        }
                    }
                }
               
            }else
            {
                if(AssessmentAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "ELAUnitColumn", "UnitSelection", "ELAGrade1UNITButton", unitName, "Down"))
                {
                    while (AssessmentAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                    {
                        AssessmentAutomationAgent.WaitForElementToVanish("UnitSelection", "CancelDownload", WaitTime.LargeWaitTime);
                        if (!AssessmentAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                        {
                            AssessmentAutomationAgent.Click("UnitSelection", "ELAGrade1UNITButton", unitName);
                        }
                    }
                }              
            }           
            
        }


        public static void ClickOnELAGrade1Unit(AutomationAgent AssessmentAutomationAgent, string unitNo)
        {
            AssessmentAutomationAgent.Click("UnitSelection", "ELAGrade1UNITButton", unitNo.ToString());
            while (AssessmentAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
            {
                AssessmentAutomationAgent.WaitForElementToVanish("UnitSelection", "CancelDownload", WaitTime.LargeWaitTime);
                if (!AssessmentAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                {
                    AssessmentAutomationAgent.Click("UnitSelection", "ELAGrade1UNITButton", unitNo.ToString());
                }
            }
        }


        /// <summary>
        /// Verify title present in Assessment manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyAssessmentManagerTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentManagerTitle");
        }

        /// <summary>
        /// Verify title present in Assessment progress overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyAssessmentProgressOverviewTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmenProgressOverviewTitle");
        }

        /// <summary>
        /// Click on back Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickBackButtonInAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "BackButtonInAssessment");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static bool VerifyBackButtonEnabledinScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "BackButtonInAssessment", "enabled")[0];
            return Convert.ToBoolean(enabled);
        }

        /// <summary>
        /// Verify back button is present in Assessment manager screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyBackButtonPresentInAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "BackButtonInAssessment");
        }

        /// <summary>
        /// Click on Fixed Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="assessmentName">Dynamic variable</param>
        public static void ClickFixedAssessmentInManager(AutomationAgent AssessmentAutomationAgent,string assessmentName)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentNameInManagerScreen", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verify fixed assessment present in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyFixedAssessmentPresentInManagerScreen(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentNameInManagerScreen",assessmentName);
        }

        public static bool VerifyOngoingAssessmentTablePresentInManagerScreen(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OngoingAssessmentListInManagerScreen", assessmentName);
        }


        public static bool VerifyNavigationCellArrowInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DownArrowInAssessmentManager");
        }

        public static bool VerifyNavigationBarColourInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string s = AssessmentAutomationAgent.GetElementProperty("AssessmentView", "NavigationBarInManagerScreen", "backgroundColor");
            if (s == "0x000000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyUnitBackgroundColourInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string s = AssessmentAutomationAgent.GetElementProperty("AssessmentView", "UnitHeaderInManagerScreen", "backgroundColor");
            if (s == "0xC0CAE4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyScoresButtonEnabledinAssessmnetOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "ScoreButtonInOverview", "enabled")[0];
            return Convert.ToBoolean(enabled);
        }

        public static bool VerifyReportButtonEnabledinAssessmnetOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "ReportButtonInOverview", "enabled")[0];
            return Convert.ToBoolean(enabled);
        }

        public static bool VerifyRubricTableScrollableInPreview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "RubricTable", "knownSuperClass")[0];
            return enabled.Contains("UIScrollView");
        }

        public static bool VerifyScoreButtonPresentInOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoreButtonInOverview");
        }

        public static void ClickScoreButtonInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ScoreButtonInOverview");
            WaitForPageToload(AssessmentAutomationAgent);
        }


        public static bool VerifyViewReportButtonPresentInOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReportButtonInOverview");
        }

        public static void ClickReportButtonInOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ReportButtonInOverview");
        }

        public static bool VerifyReleaseScoreButtonPresentInOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseScoresButtonInOverview");
        }

        public static void ClickReleaseScoreButtonInOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ReleaseScoresButtonInOverview");
        }

        /// <summary>
        /// Verify refresh icon present in Assessment progress overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyRefreshIconPresentInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RefreshButtonInManagerScreen");
        }

        public static bool VerifyLastUpdatedLabelPresentInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LastUpdatedLabel");
        }

        /// <summary>
        /// Click on Refresh Icon In Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickRefreshIconInAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RefreshButtonInManagerScreen");            
        }

        public static void ClickRefreshIconInScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RefreshButtonInScoringOverview");
        }


        /// <summary>
        /// Click on Refresh Icon In Assessment Overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickRefreshIconInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RefreshButtonInOverviewScreen");
        }


        /// <summary>
        /// Click on Preview Assessment Link In Assessment Overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickPreviewAssessmentInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "PreviewAssessmentLinkInOverview");
        }


        public static bool VerifyPreviewAssessmentInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviewAssessmentLinkInOverview");
        }


        public static void ClickStandardTabInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StandardTabInPreviewAssessment");
        }

        public static void VerifyStandardDisplayedInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StandardTabInPreviewAssessmentSelected");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StandardHeaderInPreviewAssessment");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StandardTitleInPreviewAssessment");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StandardBodyInPreviewAssessment");
        }     


        /// <summary>
        /// Verify Date Time Stamp present in Assessment progress overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyDateTimeStampInOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DateAndTimeInOverviewScreen");
        }

        public static bool VerifyDateTimeStampInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DateAndTimeInManagerScreen");
        }

        public static bool VerifyDateAndTimeStampInScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            DateTime thisDay = DateTime.Today;
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "LastUpdatedLabel", "Down", "").Replace("\t\n", "");
            string []date = text.Split(new string[] { "at"}, StringSplitOptions.None);            
            return (date[0].Equals(thisDay.ToString())&&(date[1]).Contains("M"));
        }
        
        /// <summary>
        /// Verify Assessment Pending Status present in Assessment manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyAssessmentPendingStatusInManagerPresent(AutomationAgent AssessmentAutomationAgent,string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentPendingStatusInManagerScreen", assessmentName);
        }

        public static bool VerifyAssessmentInProgressStatusInManagerPresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentInProgressStatusInManagerScreen", assessmentName);
        }

        public static bool VerifyAssessmentScoringRequiredStatusInManagerPresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentScoringRequiredStatusInManagerScreen", assessmentName);
        }

        /// <summary>
        /// Verify Assessment Started Sub Status present in Assessment manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyAssessmentStartedSubStatusInManagerPresent(AutomationAgent AssessmentAutomationAgent,string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentStartedSubStatusInManagerScreen", assessmentName);
        }

        public static bool VerifyAssessmentScoredSubStatusInManagerPresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentScoredSubStatusInManagerScreen", assessmentName);
        }

        /// <summary>
        /// Verify Assessment Started Sub Status present in Assessment manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyStudentCountInManagerScreen(AutomationAgent AssessmentAutomationAgent,string studentCount)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "AssessmentStartedSubStatusInManagerScreen", "inside", "").Replace("\t\n", "");
            return text.Contains(studentCount);
        }

        /// <summary>
        /// Verifies Teacher is able to select particular unit from the dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void AssessmentUnitSelection(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            ClickUnitTitleDropdown(AssessmentAutomationAgent);
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "AssessmentUnitSelection", unitStatus);
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentUnitSelection", unitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Tap on Unit Title Dropdown        
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickUnitTitleDropdown(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "UnitTitleDropdownButtonInManager");            
        }

        /// <summary>
        /// Verify fixed and ongoing label present in Assessment manager        
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyFixedAndOngoingLabelPresentInManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return (AssessmentAutomationAgent.IsElementFound("AssessmentView", "FixedAssessmentLabelInManagerScreen") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "OngoingAssessmentLabelInManagerScreen"));
        }

        /// <summary>
        /// Loads the test data from addirional info in login.xml
        /// </summary>
        /// <param name="TaskInfo">TaskInfo object</param>        
        public static string[] LoadTestDataFromAdditionalInfo(TaskInfo taskInfo)
        {
            String additionalInfo = taskInfo.AdditionalInfo;
            String[] testData = additionalInfo.Split(',');
            return testData;
        }

        public static void Swipe(AutomationAgent AssessmentAutomationAgent, Direction direction, int offset, int time)
        {
            AssessmentAutomationAgent.Swipe(direction, offset, time);

        }

        public static bool VerifyUnitLabelPresentInManagerScreen(AutomationAgent AssessmentAutomationAgent,string unitName)
        {
            return (AssessmentAutomationAgent.IsElementFound("BookBuilderView", "BookPageCount", unitName));
        }

        public static bool VerifyAssessmentManagerScreenVerticallyScrollable(AutomationAgent AssessmentAutomationAgent)
        {
            Swipe(AssessmentAutomationAgent, Direction.Down, 500, 2000);
            return (AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentManagerScrollView"));
        }


        public static bool VerifyOverallAssessmentStatusInManagerScreen(AutomationAgent AssessmentAutomationAgent,string assessmentStatus)
        {
           return  AssessmentAutomationAgent.IsElementFound("BookBuilderView", "BookPageCount", assessmentStatus);
        }

        public static int VerifyUnitTitleDropDownValue(AutomationAgent AssessmentAutomationAgent)
        {
            int unitCount = AssessmentAutomationAgent.GetElementCount("AssessmentView", "UnitTitleDropDownContent");
            return unitCount;
        }

        public static bool VerifyUnlockAssessmentsLinkPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnlockAssessment");
            
        }

        public static bool VerifyUnlockModalScreenFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockUnlockOverlayScreen");
        }

        /// <summary>
        /// Click on Unlock Link In Assessment Progress Overview
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickUnlockAssessmentsInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "UnlockAssessment");
            AssessmentAutomationAgent.Click("AssessmentView", "UnlockAssessment");
        }

        public static void ClickDoneInLockUnlockOverlay(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "DoneButtonInLockOverlay");
            AssessmentAutomationAgent.Click("AssessmentView", "DoneButtonInLockOverlay");
            AssessmentAutomationAgent.Sleep();
        }

        public static bool VerifyLockAllButtonPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockAllButton");
        }

        public static bool VerifyUnLockAllButtonPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnLockAllButton");
        }

        /// <summary>
        /// Tap on UnLock All button
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickUnLockAllButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "UnLockAllButton");
            AssessmentAutomationAgent.Click("AssessmentView", "UnLockAllButton");
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Tap on Lock All button
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>        
        public static void ClickLockAllButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockAllButton");
            AssessmentAutomationAgent.Click("AssessmentView", "LockAllButton");
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Unlock or Lock an individual Student
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickOnStudentName(AutomationAgent AssessmentAutomationAgent, string studentname)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockStudentName");
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "StudentName", studentname);
            AssessmentAutomationAgent.Click("AssessmentView", "StudentName", studentname);
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verify section title in Overlay screen        
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifySectionTitleInUnlockOverlayScreen(AutomationAgent AssessmentAutomationAgent, string sectionTitle)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "SectionTitleInUnlockOverlayScreen", "inside", "").Replace("\t\n", "");
            return text.Contains(sectionTitle);
        }

        public static bool VerifySectionTitleInProgressOverviewScreen(AutomationAgent AssessmentAutomationAgent, string sectionTitle)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "SectionTitleInProgressOverview", "inside", "").Replace("\t\n", "");
            return text.Contains(sectionTitle);
        }

        public static bool VerifyTotalStudentsInProgressOverviewScreen(AutomationAgent AssessmentAutomationAgent, string totalStudents)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "SectionTitleInProgressOverview", "Right", "").Replace("\t\n", "");
            return text.Contains(totalStudents+" Students") && text.Contains("|");
        }

        public static bool VerifyAssessmentNameInOverviewScreen(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "AssessmentNameInProgressOverview", "inside", "").Replace("\t\n", "");
            return text.Contains(assessmentName);
        }

        public static string VerifyStatusInUnlockOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StatusInUnlockOverlayScreen", "inside", "").Replace("\t\n", "");
            return text;
        }

        public static string VerifyLockedForStudentCountInUnlockOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "LockedStudentCountInUnlockOverlayScreen", "inside", "").Replace("\t\n", "");
            return text;
        }

        public static bool VerifyStartedStatusPresentForStudentInOverlay(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentStudentStatusInOverlay");
        }

        /// <summary>
        /// Verify lock icon present in lock uinlock overlay screen
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyLockIconPresentForStudentInOverlay(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentStudentLockIcon");
        }

        /// <summary>
        /// Verify lock icon present in assessment manager screen
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyLockIconPresentInAssessmentManagerScreen(AutomationAgent AssessmentAutomationAgent,string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockIconInAssessmentManagerScreen",assessmentName);
        }

        /// <summary>
        /// Verify unlock icon present in assessment manager screen
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyUnLockIconPresentInAssessmentManagerScreen(AutomationAgent AssessmentAutomationAgent,string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnlockIconInAssessmentManagerScreen",assessmentName);
        }

        
        public static void WaitForPageToload(AutomationAgent AssessmentAutomationAgent)
        {
            while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "LoaderImage"))
            {
                AssessmentAutomationAgent.WaitForElementToVanish("AssessmentView", "LoaderImage");
            }
        }

        /// <summary>
        /// Verify Loader Image Is Present
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyLoaderImagePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LoaderImage");
        }

        public static void TeacherInAssessmentManagerScreen(AutomationAgent AssessmentAutomationAgent,string assessmentManager,string unitName)
        {        
           AssessmentCommonMethods.ClickAssessmentInAssessmentManager(AssessmentAutomationAgent, assessmentManager);
           AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, unitName);
        }


        public static void TeacherUnlocksAStudent(AutomationAgent AssessmentAutomationAgent,string assessmentName,string studentName)
        {
            AssessmentCommonMethods.ClickFixedAssessmentInManager(AssessmentAutomationAgent, assessmentName);
            AssessmentCommonMethods.ClickUnlockAssessmentsInAssessmentOverview(AssessmentAutomationAgent);
            AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, studentName);
            AssessmentCommonMethods.ClickDoneInLockUnlockOverlay(AssessmentAutomationAgent);
            AssessmentCommonMethods.ClickBackButtonInAssessment(AssessmentAutomationAgent);
        }

        public static void LockAndResetFromOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentCommonMethods.ClickUnlockAssessmentsInAssessmentOverview(AssessmentAutomationAgent);
            AssessmentCommonMethods.ClickLockAllResetData(AssessmentAutomationAgent);
            AssessmentCommonMethods.ClickLockAndResetButton(AssessmentAutomationAgent);
            //Verify Assessment is locked message displayed
        }

        public static void ClickLockAllResetData(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockAllAssessmentAndResetData");            
        }

        public static void ClickLockAndResetButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockAndResetButton");
        }

        public static bool VerifyStartedInlineStatusPresent(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StartedInlineStudentStatus", studentName);
        }

        public static bool VerifyStudentBackgroundColourInOverlay(AutomationAgent AssessmentAutomationAgent,string studentName)
        {
            string s = AssessmentAutomationAgent.GetElementProperty("AssessmentView", "StudentTableCellInUnlockOverlayScreen", "backgroundColor",studentName);
            if (s == "0xFFFFFF")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void StudentAnswersTheAssessment(AutomationAgent AssessmentAutomationAgent,string status)
        {
            NavigationCommonMethods.ClickOnTodayButton(AssessmentAutomationAgent);
            ClickAssessmentTile(AssessmentAutomationAgent);
            if (ColdWriteNotebookOverlayFound(AssessmentAutomationAgent))
            {
                ColdWriteCommonMethods.ClickOnOpenYourNotebook(AssessmentAutomationAgent);
                if (status.Equals("Start"))
                {
                    AssessmentAutomationAgent.VerifyElementFound("ColdWriteView", "BackHand");
                    AssessmentAutomationAgent.Click("ColdWriteView", "BackHand");

                }
                else if (status.Equals("Submit"))
                {
                    ColdWriteCommonMethods.ClickAeroplaneToSend(AssessmentAutomationAgent);
                    ColdWriteCommonMethods.VerifyStandardSendBoxIsPresent(AssessmentAutomationAgent);
                    ColdWriteCommonMethods.ClickOnSendButton(AssessmentAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifySentMessageIsPresent(AssessmentAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(AssessmentAutomationAgent);
                }            
            }
           
        }

        public static void ClickAssessmentTile(AutomationAgent AssessmentAutomationAgent)
        {
            int tCount = 0;
            while (!(AssessmentAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "AssessmentTileInTodayShelf", "", "Right")) && tCount <= 20)
            {
                NavigationCommonMethods.ClickToGetNextLesson(AssessmentAutomationAgent);
                if (AssessmentAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "AssessmentTileInTodayShelf", "", "Right"))
                    break;
                tCount++;
            }
        }

        public static bool ColdWriteNotebookOverlayFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("ColdWriteView", "ColdWriteNotebookButton");
        }

        public static bool VerifyItemPreviewTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviewAssessmentPageTile");
        }

        public static string VerifyPreviewAssessmentTitleLabel(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "PreviewAssessmentTitleLabel", "inside", "").Replace("\t\n", "");
            return text;
        }

        public static bool VerifyQuestionTabInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviewAssessmentQuestionTab");
        }

        public static bool VerifyStandardTabInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviewAssessmentStandardTab");
        }

        public static void ClickStandardsTabInPreviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "PreviewAssessmentStandardTab");
        }

        public static bool VerifyDefaultTabInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DefaultSelectionInPreviewScreen");
        }

        public static bool VerifyRubricPanelInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricPanelInPreviewScreen");
        }

        public static bool VerifyCommonCoreStandardsInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CommonCoreStandardsInPreviewScreen");
        }

        public static bool VerifyCommonCoreStandardsIDInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CommonCoreStandardsIDInPreviewScreen");
        }

        public static bool VerifyStandardsViewInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StandardsViewInPreviewScreen");
        }

        public static bool VerifyQuestionViewInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTabViewInPreviewScreen");
        }

        public static bool VerifyHideRubricInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricHideButton");
        }

        public static bool TapOnHideRubricInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricHideButton");
        }

        public static bool VerifyRubricContentInPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricContentInPreview");
        }

        public static void ClickOnRubricScoreButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RubricViewScoreButton");
        }

        public static bool VerifyRubricScoringFlyout(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricScoreFlyOut");
        }

        public static bool VerifyNotScoredTabTabInOngoingAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotScoredTabInProgressOverview");
        }

        public static bool VerifyScoredTabTabInOngoingAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredTabInProgressOverview");
        }

        public static void ClickNotScoredTabInOngoingAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "NotScoredTabInProgressOverview");
        }

        public static void ClickNotScoredTabInOngoingStopScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "NotScoredTabInStopScoringDialog");
        }

        public static void ClickScoredTabInOngoingAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ScoredTabInProgressOverview");
        }

        public static void ClickScoredTabInOngoingStopScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ScoredTabInStopScoringDialog");
        }

        public static bool VerifyNoStudentsMessageInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NoStudentsStatus");
        }

        public static ArrayList GetNotScoredStudentListFromAssessmentAccomplishment(AutomationAgent AssessmentAutomationAgent, int studentCount)
        {
            ArrayList notScoredStudentList = new ArrayList();

            for (int i = 1; i <= studentCount; i++)
            {
                notScoredStudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return notScoredStudentList;
        }

        /// <summary>
        /// Get scored student count from Assessment OverView Screen - Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>scored count</returns>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static int GetScoredCountFromAssessmentOverviewAccomplishment(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "ScoredTabInProgressOverview", "inside", "").Substring(0, 1));
        }

        public static int GetScoredCountFromStopScoringOngoing(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "ScoredTabInStopScoringDialog", "inside", "").Substring(0, 1));
        }

        /// <summary>
        /// Get Not Scored student count from Assessment OverView Screen - Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>Not scored count</returns>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static int GetNotScoredCountFromAssessmentOverviewAccomplishment(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "NotScoredTabInProgressOverview", "inside", "").Substring(0, 2));
        }

        public static int GetNotScoredCountFromStopScoringOngoing(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "NotScoredTabInStopScoringDialog", "inside", "").Substring(0, 2));
        }


        public static bool VerifyScoringOverviewTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoringOverviewTitle");
        }

        public static void ClickQuestionOneChecklist(AutomationAgent AssessmentAutomationAgent,string studentName)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ChecklistQuestion1Tile",studentName);
        }

        public static void ClickChecklistDoneButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ChecklistDoneButton");
        }

        public static void ClickYesButtonInStopScoringDialog(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StopScoringYesButton");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickNoButtonInStopScoringDialog(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StopScoringNoButton");
        }

        public static bool VerifyYesAndNoButtonPresentInStopScoring(AutomationAgent AssessmentAutomationAgent)
        {
            return (AssessmentAutomationAgent.IsElementFound("AssessmentView", "StopScoringYesButton") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "StopScoringNoButton"));
        }

        public static bool VerifyScoredTabSelectedByDefaultInStopScoring(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredTabSelectedInScoringDialog");
        }

        public static bool VerifyStopScoringTextPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StopScoringLabelInStopScoringDialog");
        }

        public static bool VerifyChecklistItemScoringTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ChecklistItemScoringTitle");
        }

        public static bool VerifyItemScoringTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ItemScoringTitle");
        }

        public static bool VerifySectionTitleInStopScoring(AutomationAgent AssessmentAutomationAgent, string sectionTitle)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "CourseNameInStopScoringDialog", "inside", "").Replace("\t\n", "");
            return text.Contains(sectionTitle);
        }

        public static bool VerifyStudentCountInStopScoring(AutomationAgent AssessmentAutomationAgent, string studentCount)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentCountInStopScoringDialog", "inside", "").Replace("\t\n", "");
            return text.Contains(studentCount);
        }

        public static ArrayList GetNotScoredStudentListFromStopScoring(AutomationAgent AssessmentAutomationAgent, int studentCount)
        {
            ArrayList notScoredStudentList = new ArrayList();

            for (int i = 1; i <= studentCount; i++)
            {
                notScoredStudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInStopScoringDialog", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return notScoredStudentList;
        }
    }
}
