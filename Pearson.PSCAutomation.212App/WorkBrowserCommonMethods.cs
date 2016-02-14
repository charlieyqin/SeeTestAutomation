using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{

    public class WorkBrowserCommonMethods
    {
        /// <summary>
        /// Verify My Teacher Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMyTeacherFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("ShareView", "MyTeacherFilter");
        }
        ///<summary>
        ///Click on Top Item From Teacher In Notification Overlay
        ///</summary>
        ///<param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickTopItemFromInNotificationOverlay(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("DashboardView", "NewSharedTaskInNotification");
        }
        /// <summary>
        /// Verify TapToDownLoad For Not Downloaded Item
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if TapToDownload is present),false(if not)</returns>
        public static bool VerifyTapToDownLoadForNotDownloadedItem(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "TapToDownload");
        }
        /// <summary>
        /// Click MyTeacher Viewing Filter in work browser
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyTeacherViewingFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyTeacherViewingFilter");
        }
        /// <summary>
        /// Verify Blue Dot For Unread Notebook
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not present)</returns>
        public static bool VerifyBlueDotForUnreadNotebook(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "BlueDot");
        }

        public static bool VerifyMyClassFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("ShareView", "MyClassInMyWork");
        }
        /// <summary>
        /// Click MyClass Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyClassFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Sleep(1000);
            workbrowserAutomationAgent.Click("WorkBrowser", "MyClassInMyWork");
        }
        /// <summary>
        /// Verify MyClass Viewing Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMyClassViewingFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "MyClassViewingFilter");
        }
        public static void SelectTeacherAltagracia(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "SelectTeacherAltagracia");
        }
        /// <summary>
        /// Verify Default First Section
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyDefaultFirstSection(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("DashboardView", "SectionTitleInWorkBrowser");
        }
        /// <summary>
        /// Click SortBy MostRecent Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickSortByMostRecentFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Sleep(2000);
            workbrowserAutomationAgent.Click("WorkBrowserView", "SortByMostRecentFilter");
        }
        /// <summary>
        /// Verify List Of Lessons Are Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if displayed),false(if not)</returns>
        public static bool VerifyListOfLessonsAreDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "AllLessonDropdown");
        }
        /// <summary>
        /// Click AllLessons Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickAllLessonsFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Sleep(2000);
            workbrowserAutomationAgent.Click("WorkBrowserView", "AllLessonFilter");
        }
        /// <summary>
        /// Select Unit From Unit Dropdown
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="number">unit number</param>
        public static void SelectUnitFromUnitDropdown(AutomationAgent workbrowserAutomationAgent, string number)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "UnitFromAllUnitFilter", number, 1, WaitTime.DefaultWaitTime);
        }
        /// <summary>
        /// Select Lesson From Lesson Dropdown
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="number">Lesson number</param>
        public static void SelectLessonFromLessonDropdown(AutomationAgent workbrowserAutomationAgent, string number)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "LessonFromAllLessonFilter", number, 1, WaitTime.DefaultWaitTime);
        }
        /// <summary>
        /// Click AllUnits Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickAllUnitsFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "AllUnitsFilter");
        }
        /// <summary>
        /// Select Lesson Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void SelectLessonFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "LessonFilter");
            workbrowserAutomationAgent.Sleep(2000);
        }
        public static void ClickOnWorkBrowserbutton(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("SystemTrayMenuView", "WorkBrowser");
        }
        public static void ClickOnViewingDropDown(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("PersonalNotesTopView", "ViewingDropDown");
        }
        /// <summary>
        /// Verify User Can Select One Lesson At A Time
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="number">lesson number</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyUserCanSelectOneLessonAtATime(AutomationAgent workbrowserAutomationAgent, string number)
        {
            bool value = workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "LessonSelectedFromAllLessonFilter", number);
            if (value == false)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Verify All Lesson Menu Arrow Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyAllLessonMenuArrowDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "AllLessonDropdownArrow");
        }
        /// <summary>
        /// Verify All Units Menu Arrow Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyAllUnitsMenuArrowDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "AllLessonDropdownArrow");
        }
        /// <summary>
        /// Verify User Can Select One Unit At A Time
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="number">unit number</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyUserCanSelectOneUnitAtATime(AutomationAgent workbrowserAutomationAgent, string number)
        {
            bool value = workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "LessonSelectedFromAllLessonFilter", number);
            if (value == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click My Teacher Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyTeacherFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("ShareView", "MyTeacherFilter");
        }
        /// <summary>
        /// Click Tap To DownLoad For Not Downloaded CR Item
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickTapToDownLoadForNotDownloadedCRItem(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "CRTapToDownload");
        }
        /// <summary>
        /// Verify Progress Bar For CR Downloaded Item
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyProgressBarForCRDownloadedItem(AutomationAgent workbrowserAutomationAgent)
        {
            string[] parentHidden;
            if (workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "ProgressBarOnDownload"))
            {
                parentHidden = workbrowserAutomationAgent.GetAllValues("WorkBrowserView", "ProgressBarOnDownload", "parentHidden");
                return (parentHidden == null || parentHidden[0] == "NULL");
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify MyWork Viewing Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMyWorkViewingFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "MyWorkViewingFilter");
        }
        /// <summary>
        /// Verify SortedBy MostRecent Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySortedByMostRecentFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SortByMostRecentFilter");
        }
        /// <summary>
        /// Verify Default Message On MyClass Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyDefaultMessageOnMyClassFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "DefaultMessageOnMyClassFilter");
        }
        /// <summary>
        /// Click MyWork Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyWorkFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("ShareView", "MyWorkFilter");
        }
        /// <summary>
        /// Verify Default Message On MyWork Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyDefaultMessageOnMyWorkFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "DefaultMessageOnMyWorkFilter");
        }
        /// <summary>
        /// Select Other Grades
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void SelectOtherGrades(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "OtherGrades");
        }

        /// <summary>
        /// Click MyWork OtherGrades Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyWorkOtherGradesFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyWorkOtherGradesFilter");
        }
        /// <summary>
        /// Verify Default Message OnOther Grades Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyDefaultMessageOnOtherGradesFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "DefaultMessageOnOtherGradesFilter");
        }
        /// <summary>
        /// Select PersonalNotes Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void SelectPersonalNotesFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.WaitforElement("WorkBrowserView", "PersonalNotes", "", WaitTime.SmallWaitTime);
            workbrowserAutomationAgent.Click("WorkBrowserView", "PersonalNotes");
        }
        /// <summary>
        /// Click MyWork PersonalNotes Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyWorkPersonalNotesFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyWorkPersonalNotesFilter");
        }
        /// <summary>
        /// Verify Default Message On PersonalNotes Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyDefaultMessageOnPersonalNotesFilter(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "DefaultMessageOnOPersonalNotesFilter");
        }
        /// <summary>
        /// Click MyWork ELA Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyWorkELAFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MYWorkELA");
        }
        /// <summary>
        /// Verify StudentName In Grid Is Displayed On Top
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyStudentNameInGridIsDisplayedOnTop(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "StudentNameInGrid");
        }
        /// <summary>
        /// Click Student Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickStudentFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "StudentFilter");
        }
        /// <summary>
        /// Verify Student Displayed In SortedBy Label
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyStudentDisplayedInSortedByLabel(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "StudentLabelInSortedBy");
        }
        /// <summary>
        /// Verify Student Names Displayed Alphabetically
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyStudentNamesDisplayedAlphabetically(AutomationAgent workbrowserAutomationAgent)
        {
            string studentname1 = workbrowserAutomationAgent.GetTextIn("WorkBrowserView", "StudentNamesInGridDisplay1", "Inside", "", 0, 0);
            int student1 = Convert.ToInt32(studentname1[0]);
            string studentname2 = workbrowserAutomationAgent.GetTextIn("WorkBrowserView", "StudentNamesInGridDisplay2", "Inside", "", "TEXT", 0, 0, 0);
            int student2 = Convert.ToInt32(studentname2[0]);
            if (student2 > student1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click MyWork Viewing Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMyWorkViewingFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyWorkViewingFilter");
        }
        /// <summary>
        /// Click Sec34
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickSec34(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowser", "Sec34Per5InMyClass");
        }
        /// <summary>
        /// Click CommonReads
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickCommonReads(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "CommonReadsInMyClass");
        }
        /// <summary>
        /// Verify Sent Button Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySentButtonDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SentButton");

        }
        /// <summary>
        /// Verify Number Of Notebooks Sent
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyNumberOfNotebooksSent(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "NoOfNotebooksSent");
        }
        /// <summary>
        /// Click On Sent Button
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSentButton(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "SentButton");
        }
        /// <summary>
        /// Verify Sent Work Overlay Opened
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySentWorkOverlayOpened(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SentWorkOverlay");
        }
        /// <summary>
        /// Verify Modal Title Of Sent Work Overlay
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyModalTitleOfSentWorkOverlay(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SentWorkOverlayTitle");
        }
        /// <summary>
        /// Verify Unit Lesson Task And Title
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyUnitLessonTaskAndTitle(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "UnitLessonTaskTitle");
        }
        /// <summary>
        /// Verify Page Number Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyPageNumberDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "PageNumber");
        }
        /// <summary>
        /// Verify To Names Of All Recipients
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyToNamesOfAllRecipients(AutomationAgent workbrowserAutomationAgent)
        {
            if (workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "ToReceipient") && workbrowserAutomationAgent.IsElementFound("ShareView", "SelectStudentForSharing"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Date Time Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyDateTimeDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            DateTime currentDate = DateTime.Now;
            currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "", currentDate.Month + " " + currentDate.Day + ",");

        }
        /// <summary>
        /// Verifies My class tile color 
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <param name="grade">Grade Number</param>
        /// <returns>true if color code is "0x0031C3"</returns>
        public static bool VerifyMyClassTileColorAndTitle(AutomationAgent workbrowserAutomationAgent, int grade)
        {
            return workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "MyClassTile", "backgroundColor", grade.ToString()) == "0x0031C3" &&
               workbrowserAutomationAgent.GetTextIn("WorkBrowserView", "MyClassTile", "inside", grade.ToString()).Replace("\t\n", "") == "ELA - Grade " + grade.ToString();

        }
        /// <summary>
        /// Verify Most Recent Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMostRecentDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Sleep(2000);
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SortByMostRecentFilter");
        }
        /// <summary>
        /// Verify MyWork ELA and Math
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMyWorkELAMath(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "MyWorkELAMath");
        }
        /// <summary>
        /// Click MyWork ELA and Math
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickMyWorkELAMath(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyWorkELAMath");
        }
        /// <summary>
        /// Click Math Grade9
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickMathFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MathGrade9");
        }
        /// <summary>
        /// Verify Lesson Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyLessonDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "LessonInMostRecent");
        }
        /// <summary>
        /// Click PersonalNotes Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickPersonalNotesFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "PersonalNotes");
        }
        /// <summary>
        /// Verify Alphabetical Displayed
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyAlphabeticalDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "Alphabetical");
        }
        /// <summary>
        /// Click MyTeacher ELA and Math
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickMyTeacherELAMath(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyTeacherELAMath");
        }
        /// <summary>
        /// Click MyClass ELA And Math
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickMyClassELAMath(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyClassViewingFilter");
        }
        /// <summary>
        /// Verify Associated Section Of Tiles
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyAssociatedSectionOfTiles(AutomationAgent workbrowserAutomationAgent)
        {
            string section = workbrowserAutomationAgent.GetTextIn("WorkBrowserView", "DefaultSectionOfTiles", "Inside", "", 0, 0);
            if (section.Contains("Sec-34 Per-5"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click My Class Viewing Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickMyClassViewingFilter(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MyClassViewingFilter");
        }
        /// <summary>
        /// Verify Student is Displayed in Most Recent Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyStudentDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "StudentInMostRecent");
        }
        /// <summary>
        /// Click Lesson is Displayed in Most Recent Filter
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickLessonDisplayed(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "LessonInMostRecent");
        }
        /// <summary>
        /// Verify Work Is Grouped By Unit And Lesson
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyWorkIsGroupedByUnitAndLesson(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "GroupByUnitLesson");
        }
        /// <summary>
        /// Verifies whether the sent button is centered or not
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="taskName">Name of the task</param>
        /// <returns>boolean status of send button centered</returns>
        public static bool VerifySendButtonCentered(AutomationAgent workbrowserAutomationAgent, string taskName)
        {
            return workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "BaseballCard", "X", taskName) == workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "SentButtonInBaseballCard", "X", taskName) &&
                workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "BaseballCard", "width", taskName) == workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "SentButtonInBaseballCard", "width", taskName);
        }
        /// <summary>
        /// Clicks on the received label
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="taskName">Task Name</param>
        public static void ClickReceivedLabel(AutomationAgent workbrowserAutomationAgent)
        {
            for (int i = 0; i < 10; i++)
            {
                if (workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "ReceivedButtonInBaseballCard"))
                {
                    workbrowserAutomationAgent.Click("WorkBrowserView", "ReceivedButtonInBaseballCard");
                    break;
                }
                workbrowserAutomationAgent.Drag(900, 1200, 900, 550);
            }
        }
        /// <summary>
        /// Verifies the received work overlay
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyReceivedWorkOverlay(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("ReceivedWorkView", "ReceivedWorkTitle");
        }

        /// <summary>
        /// Verifies the Receivedwork tile
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyReceivedItemModalTile(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("ReceivedWorkView", "ReceivedWorkTile");
        }

        public static void ClickCloseButtonInReceivedWorkOverlay(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("ReceivedWorkView", "CloseButton");
        }
        /// <summary>
        /// Clicks on screen
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        public static void ClickOnScreen(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.ClickCoordinate(100, 100);
        }
        /// <summary>
        /// Verifies the number in item tile
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyNumberInItemTile(AutomationAgent workbrowserAutomationAgent)
        {
            bool result = false;
            for (int i = 0; i < 10; i++)
            {
                if (workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "NumberTextInItemTile"))
                {
                    result = true;
                    break;
                }
                workbrowserAutomationAgent.Drag(900, 1200, 900, 550);
            }
            return result;
        }
        /// <summary>
        /// Verifies if the Received label is found by scrolling down
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyReceivedLabel(AutomationAgent workbrowserAutomationAgent)
        {
            bool result = false;
            for (int i = 0; i < 10; i++)
            {
                if (!bool.Parse(workbrowserAutomationAgent.GetAllValues("WorkBrowserView", "ReceivedButtonInBaseballCard", "hidden")[0]))
                {
                    result = true;
                    break;
                }
                workbrowserAutomationAgent.Drag(900, 1200, 900, 550);
            }
            return result;
        }
        /// <summary>
        /// Verify Work Is Descending Based On Unit And Lesson
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent objects</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyWorkIsDescendingBasedOnUnitAndLesson(AutomationAgent workbrowserAutomationAgent)
        {
            int i = 2;
            string firstview = workbrowserAutomationAgent.GetTextIn("WorkBrowserView", "UnitLessonGroupingDescending", "Inside", (i - 1).ToString(), 0, 0);
            string secondview = workbrowserAutomationAgent.GetTextIn("WorkBrowserView", "UnitLessonGroupingDescending", "Inside", (i).ToString(), 0, 0);

            string[] firstgroup = firstview.Replace("\t\n", "").Split(',');
            string[] firstunit = firstgroup[0].Split(' ');
            string[] firstlesson = firstgroup[1].Split(' ');
            int unitfirst = int.Parse(firstunit[1]);
            int lessonfirst = int.Parse(firstlesson[2]);

            string[] secondgroup = secondview.Replace("\t\n", "").Split(',');
            string[] secondunit = secondgroup[0].Split(' ');
            string[] secondlesson = secondgroup[1].Split(' ');
            int unitsecond = int.Parse(secondunit[1]);
            int lessonsecond = int.Parse(secondlesson[2]);

            if (unitfirst == unitsecond)
            {
                if (lessonfirst > lessonsecond)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (unitfirst > unitsecond)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClickOnPersonalNotesCell(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("PersonalNotesTopView", "PersonalNotesCell");
        }
        public static void ClickOnPersonalNotesLink(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("NotebookWorkBrowserView", "PersonalNotesLink");
        }
        public static void ClickOnOpenScreenTile(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("PersonalNotesTopView", "OpenScreenTile");
        }
        public static void ClickOnELANotebookTile(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("PersonalNotesTopView", "ELANotebookTile");
        }
        public static void ClickOnELANotebookLink(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("WorkBrowserView", "ELANotebookLink");
        }
        public static void ClickOnELANotesCell(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("WorkBrowserView", "ELANotesCell");
        }
        public static void ClickOnPersonalNotesTile(AutomationAgent workBrowserAutomationAgent)
        {
            workBrowserAutomationAgent.Click("PersonalNotesTopView", "PersonalNotesTile");
        }

        /// <summary>
        /// Verify Last SentItem Is Displayed First
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent objects</param>
        /// <param name="lesson">lesson number</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyLastSentItemIsDisplayedFirst(AutomationAgent workbrowserAutomationAgent, int lesson)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "FirstItemsRecieved", lesson.ToString());
        }
        /// <summary>
        /// Verify First SentItem Displayed Second
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent objects</param>
        /// <param name="lesson">lesson number</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyFirstSentItemDisplayedSecond(AutomationAgent workbrowserAutomationAgent, int lesson)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SecondItemsRecieved", lesson.ToString());
        }
        /// <summary>
        /// Verify Received Items Are Arranged By Last Name
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent objects</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyReceivedItemsAreArrangedByLastName(AutomationAgent workbrowserAutomationAgent)
        {
            if (workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "SecondItemRecievedPerson") && workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "FirstItemRecievedPerson"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies the first item unit and lesson numbers
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent</param>
        /// <param name="unit">unit</param>
        /// <param name="lessonNumber">Lesson Number</param>
        /// <returns></returns>
        public static bool VerifyFirstItemLesson(AutomationAgent workbrowserAutomationAgent, string unit, int lessonNumber)
        {
            return workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "ItemInWorkBrowser", "AccessibilityLabel", 0).Contains("Unit " + unit + ", Lesson " + lessonNumber);
        }
        /// <summary>
        /// Verifies the work browser items chronological order
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyItemsInChronologicalOrder(AutomationAgent workbrowserAutomationAgent)
        {
            bool result = true;
            int itemsCount = workbrowserAutomationAgent.GetElementCount("WorkBrowserView", "ItemInWorkBrowser");
            DateTime currentItemTime =DateTime.Now, previousItemTime;
            string itemAccessiblityLabel = string.Empty;            
            for (int i = 0; i < itemsCount; i++)
            {
                itemAccessiblityLabel = workbrowserAutomationAgent.GetElementProperty("WorkBrowserView", "ItemInWorkBrowser", "AccessibilityLabel", i);
                previousItemTime = currentItemTime;
                currentItemTime = DateTime.Parse(itemAccessiblityLabel.Substring(itemAccessiblityLabel.Length - 21));
                if (currentItemTime > previousItemTime)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Verify More Button In SentOverlay
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMoreButtonInSentOverlay(AutomationAgent workbrowserAutomationAgent)
        {
            return workbrowserAutomationAgent.IsElementFound("WorkBrowserView", "MorebuttoninSentWorkOverlay");
        }

        /// <summary>
        /// Verifies the Blue Title Bar present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static string VerifyTitleColorOfNotebook(AutomationAgent workbrowserAutomationAgent)
        {
            string[] str;
            str = workbrowserAutomationAgent.GetAllValues("PersonalNotesTopView", "ELANotebookLink", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Click On Math Notebook Tile
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMathNotebookTile(AutomationAgent workbrowserAutomationAgent)
        {
            workbrowserAutomationAgent.Click("WorkBrowserView", "MathNotebookTile");
        }
        /// <summary>
        /// Verify Received ELA Notebook Color
        /// </summary>
        /// <param name="workbrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string:(color of notebook)</returns>
        public static string VerifyReceivedELANotebookColor(AutomationAgent workbrowserAutomationAgent)
        {
            string[] str;
            str = workbrowserAutomationAgent.GetAllValues("WorkBrowserView", "ReceivedWorkELA", "backgroundColor");
            return str[0];
        }

        /// <summary>
        /// Get My class Notebook Modified Date
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <param name="notebook"></param>
        /// <returns>true:(if present),false(if not)</returns>
        public static string GetMyClassNotebooksModifiedDate(AutomationAgent workbrowserAutomationAgent, int notebook)
        {
            string index = notebook.ToString();
            string s = workbrowserAutomationAgent.GetTextIn("WorkBrowser", "NotebookDate", "Inside", index, notebook, 0, 0);
            string s1 = s.Replace("\t\n", "");
            return s1;
        }

        public static string VerifyReceivedMathNotebookColor(AutomationAgent workbrowserAutomationAgent)
        {
            string[] str;
            str = workbrowserAutomationAgent.GetAllValues("WorkBrowserView", "ReceivedWorkMath", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Verifies Received Work Left Modal Aligned
        /// </summary>
        /// <param name="workbrowserAutomationAgent"></param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyReceiveWorkLeftEdgeModalAligned(AutomationAgent workbrowserAutomationAgent)
        {
            string position = workbrowserAutomationAgent.GetPosition("ShareView", "WorkBrowserTapToDownloadButton");
            string[] pos = position.Split(',');
            if (Int32.Parse(pos[0]) > 1000 && Int32.Parse(pos[1]) < 700)
                return true;

            else
                return false;
        }
    }
}
