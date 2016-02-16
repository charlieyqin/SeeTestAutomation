using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public static class LessonBrowserCommonMethods
    {
        /// <summary>
        /// Verifies Start Button found when clicking first time on Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="LessonNumber">Lesson number to be clicked</param>
        public static void StartButtonDisplayedFirstTimeClickOnLesson(AutomationAgent LessonBrowserAutomationAgent, int LessonNumber)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonsOverView", "ELALessonStartButton", LessonNumber.ToString());
        }
        /// <summary>
        /// Verifies Lesson Browser Panel present 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void VerifyLessonBrowserPanelPresent(AutomationAgent LessonBrowserAutomationAgent, string lessonNum)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "LessonBrowserPanel", "1");
        }


        public static void VerifyMathLessonBrowserPanelPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "MathLessonBrowserPanel");
        }

        public static void VerifyAddGradeButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "AddGradeButton");
        }
        /// <summary>
        /// Clicks on Add Grade Button 
        /// 1. To add grades 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAddGradeButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "AddGradeButton");
        }
        /// <summary>
        /// Adds grade for teacher 
        /// 1. Select grade amongst all the grades present
        /// 2. Click on continue button after selecting any grade
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="GradeNumber">Grade number in grades</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void AddGradeForTeacher(AutomationAgent LessonBrowserAutomationAgent, int GradeNumber)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "GradeButton", GradeNumber.ToString());
            LessonBrowserAutomationAgent.Click("SelectGradeView", "ContinueButton");
        }

        public static void ClickOnGalleryInMathLesson(AutomationAgent LessonBrowserAutomationAgent, int LessonNumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "GalleryTitleInMathUnit", LessonNumber.ToString());
        }

        public static void ClickCancelOnSelectGrade(AutomationAgent LessonBrowserAutomationAgent)
        {

            LessonBrowserAutomationAgent.Click("SelectGradeView", "CancelButton");
        }

        /// <summary>
        /// 1. Wait for the Unit to Download 
        /// 2. Verifies unit downloaded
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void WaitAndVerifyUnitIsDownloaded(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.WaitforElement("UnitLibraryView", "ELAUnitTile", "1", 900000);
        }
        /// <summary>
        /// Clicks on Remove Grade Button 
        /// It removes the grade from the grades available
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickRemoveGradeButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "RemoveGradeButton");
        }
        /// <summary>
        /// Clicks on Continue Button after clicking on Remove Grade Button to remove the grades
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickContinueButonToRemoveGrade(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("PopUpView", "RemoveGradeContinueButton");
        }
        /// <summary>
        /// Verifies More To Explore Button is present in Dashboard 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyMoreToExploreButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "MoreToExploreButton");
        }
        /// <summary>
        /// Verifies Concept Corner Button present in the Dashboard
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyConceptCornerButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "ConceptCornerButton");
        }
        /// <summary>
        /// Verifies Teacher Support Button present in the Dashboard
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyTeacherSupportButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "TeacherSupportButton");
        }
        /// <summary>
        /// Verifies particular Grade is present in the available grades
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="GradeNumber">Grade number to be verified</param>
        public static void VerifyGradeIsPresent(AutomationAgent LessonBrowserAutomationAgent, int GradeNumber)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "GradeLabel", GradeNumber.ToString());
        }
        /// <summary>
        /// Verifies particular Unit present in the List of Units
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="UnitNumber">Unit number to be verified</param>
        public static void VerifyUnitIsPresent(AutomationAgent LessonBrowserAutomationAgent, int UnitNumber)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("UnitLibraryView", "UnitNumber", UnitNumber.ToString());
        }
        /// <summary>
        /// Veifies Add Grade Pop Up is displayed after clicking on Add Grade button
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifyAddGradePopUpIsDisplayed(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "SelectGradeLabel");
        }

        public static void VerifyUsernameIsDisplayedOnSelectGrade(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "UserNameText");
        }

        public static void ClickUnitBackButton(AutomationAgent LessonBrowserAutomationAgent, int unit)
        {
            LessonBrowserAutomationAgent.Click("TasksTopMenuView", "UnitBackButton", unit.ToString(), 1, WaitTime.DefaultWaitTime);
        }

        public static void ClickUnitBackButton(AutomationAgent LessonBrowserAutomationAgent, string unit)
        {
            LessonBrowserAutomationAgent.Click("TasksTopMenuView", "UnitBackButton", unit.ToString(), 1, WaitTime.DefaultWaitTime);
        }

        public static void ClickGradeBackButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TasksTopMenuView", "GradeBackButton");
        }

        public static void ClickStartUnitButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("DashboardView", "StartUnitButton");
        }

        public static void ClickClassRosterLink(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("DashboardView", "ClassRosterLink");
        }

        public static void ClickClassWorkLink(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("DashboardView", "ClassWorkLink");
        }

        public static void ClickCameraIcon(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("DashboardView", "CameraIcon");
        }

        public static void VerifyStartUnitButtOnPresentOnDashboard(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "StartUnitButton");
        }

        public static void VerifyClassRosterLinkOnPresentOnDashboard(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "ClassRosterLink");
        }

        public static void VerifyClassWorkLinkOnPresentOnDashboard(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "ClassWorkLink");
        }

        public static void VerifyCameraIconOnPresentOnDashboard(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "CameraIcon");
        }

        public static void ClickMyDashboardBackButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TasksTopMenuView", "MyDashboardBackButton");
        }

        public static void VerifyClassRosterLink(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementNotFound("DashboardView", "ClassRosterLink");
        }

        /// <summary>
        /// Clicks on Play Button Present in the video as a thumbnail in Lesson Browser View 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void ClickOnPlayButtonInVideo(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "VideoPlayButton");
        }
        /// <summary>
        /// Verifies all the Functionalities in the Video which is in Play mode
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        /// <returns> true: if all are verified</returns>
        public static bool VerifyVideoFunctionalities(AutomationAgent LessonBrowserAutomationAgent)
        {
            try
            {
                if (!LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "VideoPlayerPause"))
                {
                    LessonBrowserAutomationAgent.ClickCoordinate(130, 226, 1);
                }
                LessonBrowserAutomationAgent.Click("LessonBrowserView", "VideoPlayerPause", 1, 0);
                string height = LessonBrowserAutomationAgent.GetAllValues("LessonBrowserView", "VideoPlayer", "height")[0];
                string width = LessonBrowserAutomationAgent.GetAllValues("LessonBrowserView", "VideoPlayer", "width")[0];
                if (width != "2048" || height != "1536")
                {
                    return false;
                }
                LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "VolumeSlider");
                LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "VideoPlayerPlay");
                LessonBrowserAutomationAgent.Click("LessonBrowserView", "VideoPlayerPlay");
                if (!LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "VideoPlayerPause"))
                {
                    LessonBrowserAutomationAgent.ClickCoordinate(130, 226, 1);
                }
                LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "VideoPlayerPause");
                while (!LessonBrowserAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton"))
                {
                    LessonBrowserAutomationAgent.Sleep();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Clicks on the Pause Button in the Video which is in Play mode 
        /// It waits for the pause button then it clicks on it and close the video 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void ClickOnPauseButtonInVideo(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Sleep(1000);
            if (!LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "VideoPlayerPause"))
            {
                LessonBrowserAutomationAgent.ClickCoordinate(130, 226, 1);
            }
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "VideoPlayerPause");
            LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "VolumeSlider");
            LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "VideoPlayButtonInVideo");
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "DoneButtonInVideo");

        }
        /// <summary>
        /// Verifies Lessons are in order 
        /// It verifies that the lessons in the lesson panel are in order as "left to right" and "top to bottom"
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyLessonsAreInOrder(AutomationAgent LessonBrowserAutomationAgent)
        {
            for (int i = 0; LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonNo", i.ToString()); i++)
            {
                string LessonText = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonNo", "Inside", i.ToString());
                LessonText = LessonText.Replace("\n", "").Replace("\t", "");
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<string>("Lesson " + (++i), LessonText);
            }
        }
        /// <summary>
        /// Verifies if start button is active or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string: true(if start button is active), false(if start button is not active)</returns>
        public static string VerifyELAStartButtonActive(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.GetElementProperty("LessonsOverView", "ELALessonCommonContinueButton", "enabled");
        }
        /// <summary>
        /// Verifies if ELA task is open or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if ELA task is open), false(if ELA task is not open)</returns>
        public static bool VerifyELATaskOpen(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "TaskHeader");
        }
        /// <summary>
        /// Verifies if Teacher Mode Icon is present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyTeacherModeIconPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            string onScreen = LessonBrowserAutomationAgent.GetAllValues("TasksTopMenuView", "TeacherModeIcon", "onScreen")[0];
            return bool.Parse(onScreen);
        }
        /// <summary>
        /// Clicks on the Teacher mode icon present 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeIcon(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TasksTopMenuView", "TeacherModeIcon");
        }
        /// <summary>
        /// Verifies if Teacher Mode is Open or not 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if Teacher Mode is open), false(if teacher mode is not open)</returns>
        public static bool VerifyTeacherModeOpen(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeOpened");
        }
        /// <summary>
        /// Clicks on the ELA Lesson Continue Button
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickELALessonContinueButton(AutomationAgent LessonBrowserAutomationAgent, bool retry = true)
        {
            if(LessonBrowserAutomationAgent.IsElementFound("LessonsOverView", "ELALessonCommonContinueButton")) {
                LessonBrowserAutomationAgent.Click("LessonsOverView", "ELALessonCommonContinueButton");
                LessonBrowserAutomationAgent.Sleep(3000);
            }
            if(retry) {
                ClickELALessonContinueButton(LessonBrowserAutomationAgent, false);
            }
        }
        /// <summary>
        /// Clicks on Unit Overview in Teacher Mode
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitOverviewInTeacherMode(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TeacherModeView", "UnitOverviewButton");
        }
        /// <summary>
        /// Clicks on About this Lesson in Teacher Mode
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAboutThisLessonInTeacherMode(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TeacherModeView", "AboutThisLessonButton");
        }
        /// <summary>
        /// Clicks on Teacher Guide in Teacher Mode
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherGuideInTeacherMode(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TeacherModeView", "TeacherGuideButton");
        }
        /// <summary>
        /// Verifies if Teacher Guide is open 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher guide is open), false(if teacher guide is not open)</returns>
        public static bool VerifyTeacherGuideExpands(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if Unit Overview is open
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyUnitOverviewExpands(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if About This Lesson is open 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if open), false(if not)</returns>
        public static bool VerifyAboutThisLessonExpands(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if Teacher Guide is Collapsed
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if teacher guide is collaped), false(if not)</returns>
        public static bool VerifyTeacherGuideCollapse(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies if Unit Overview is Collapsed
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if collapsed), false(if not)</returns>
        public static bool VerifyUnitOverviewCollapse(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies if About This Lesson is collapsed
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if collapsed), false(if not)</returns>
        public static bool VerifyAboutThisLessonCollapse(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Clicks on Back Button 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TeacherModeView", "BackButton");
        }
        /// <summary>
        /// Gets the Task Number in Teacher Guide in Teacher Mode 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Task Number</returns>
        public static string GetTaskNumberInTeacherGuide(AutomationAgent LessonBrowserAutomationAgent)
        {
            string s = LessonBrowserAutomationAgent.GetTextIn("TeacherModeView", "ButtonsActive", "Down", "");
            string[] str = s.Split(':');
            return str[0];
        }
        /// <summary>
        /// Gets the Task Page Number in Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>int: Task Page Number</returns>
        public static int GetTaskPageNumberInLesson(AutomationAgent LessonBrowserAutomationAgent)
        {
            int currentTaskNumber = int.Parse(LessonBrowserAutomationAgent.GetElementText("LessonView", "CurrentPageLabel"));
            return currentTaskNumber;
        }
        /// <summary>
        /// Clicks on the Next Button available in Task Page
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNextButtonInTask(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("LessonView", "NextButton");
        }
        /// <summary>
        /// Verifies if Add Grade button is active or disabled
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string VerifyAddGradeButtonActive(AutomationAgent LessonBrowserAutomationAgent)
        {
            string hidden = LessonBrowserAutomationAgent.GetAllValues("UnitLibraryView", "AddGrades", "hidden")[0];
            if (hidden == "true")
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }
        /// <summary>
        /// Verifies that Episode Cell in Lesson Browser is present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Episode Cell is present), false(if Episode Cell is not present)</returns>
        public static bool VerifyLessonBrowserEpisodeCell(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonBrowserEpisodeCell");
        }
        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Sectioned Teachers Logged In
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForSectionedTeachers(AutomationAgent LessonBrowserAutomationAgent)
        {
            if (LessonBrowserAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton") &&
                LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "BackButton") &&
                LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "UnitTitle") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "TeacherModeIcon") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Non Sectioned Students Logged In
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForNonSectionedStudents(AutomationAgent LessonBrowserAutomationAgent)
        {
            if (LessonBrowserAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton") &&
                LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "BackButton") &&
                LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "UnitTitle") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon"))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Sectioned Students Logged In
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForSectionedStudents(AutomationAgent LessonBrowserAutomationAgent)
        {
            if (LessonBrowserAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton") &&
                LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "BackButton") &&
                LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "UnitTitle") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Non Sectioned Teachers Logged In
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForNonSectionedTeachers(AutomationAgent LessonBrowserAutomationAgent)
        {
            if (LessonBrowserAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton") &&
                LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "BackButton") &&
                LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "UnitTitle") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon") &&
                LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "TeacherModeIcon"))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Video is Completed or not 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyVideoComplete(AutomationAgent LessonBrowserAutomationAgent)
        {
            while (LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "VolumeSlider"))
            {
                LessonBrowserAutomationAgent.Sleep();
                LessonBrowserAutomationAgent.ClickCoordinate(400, 400, 1);
            }
            if (!LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "VolumeSlider"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on The Math Lesson's Continue Button
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickMathLessonContinueButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("LessonsOverView", "ELALessonCommonContinueButton");
        }

        /// <summary>
        /// Verifies if ELA task is open or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if ELA task is open), false(if ELA task is not open)</returns>
        public static bool VerifyMathTaskOpen(AutomationAgent LessonBrowserAutomationAgent, string title)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "MathTaskHeader", title);
        }
        /// <summary>
        /// Verifies Grades selected(checked) or not(Unchecked)
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void VerifyCheckAndUncheckGrades(AutomationAgent LessonBrowserAutomationAgent)
        {
            bool notAddedGrade = false;
            int i = 2;
            LessonBrowserAutomationAgent.Click("UnitLibraryView", "AddGrades");
            LessonBrowserAutomationAgent.Sleep(2000);
            while (!notAddedGrade)
            {
                if (LessonBrowserAutomationAgent.GetAllValues("SelectGradeView", "GradesButton", i.ToString(), "textColor")[0].Equals("0x333333"))
                {
                    LessonBrowserAutomationAgent.Click("SelectGradeView", "GradesButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    notAddedGrade = true;
                }
                else
                {
                    i++;
                }
            }
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "SelectedGrade", (i).ToString());
            LessonBrowserAutomationAgent.Click("SelectGradeView", "GradeButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
            LessonBrowserAutomationAgent.VerifyElementNotFound("SelectGradeView", "SelectedGrade", (i - 1).ToString());
        }
        /// <summary>
        /// Verifies already downloded grade and the grade downloaded canno be selected
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">string: grade number to be verified</param>
        /// <returns>bool: true(if grade is already downloaded), false(if grade is not downloaded)</returns>
        public static bool VerifyAlreadyDownloadedGradeGrayedAndCannotBeSelected(AutomationAgent LessonBrowserAutomationAgent, string gradeNumber)
        {
            LessonBrowserAutomationAgent.Click("UnitLibraryView", "AddGrades");
            LessonBrowserAutomationAgent.Sleep(2000);
            if (LessonBrowserAutomationAgent.GetElementProperty("SelectGradeView", "GradeButton", "enabled", gradeNumber, WaitTime.DefaultWaitTime).Equals("true"))
            {
                LessonBrowserAutomationAgent.Click("SelectGradeView", "GradeButton", gradeNumber, 1, WaitTime.DefaultWaitTime);
            }
            LessonBrowserAutomationAgent.VerifyElementNotFound("SelectGradeView", "SelectedGrade");
            if (LessonBrowserAutomationAgent.GetAllValues("SelectGradeView", "GradeButton", gradeNumber, "backgroundColor")[0].Equals("0xEDEDED"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verfies Continue toggles active or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if continue button active), false(if continue button not active)</returns>
        public static bool VerifyContinueTogglesActive(AutomationAgent LessonBrowserAutomationAgent)
        {
            bool notAddedGrade = false;
            int i = 2;
            LessonBrowserAutomationAgent.Click("UnitLibraryView", "AddGrades");
            LessonBrowserAutomationAgent.Sleep(2000);
            while (!notAddedGrade && i<13)
            {
                if (LessonBrowserAutomationAgent.GetAllValues("SelectGradeView", "GradesButton", i.ToString(), "textColor")[0].Equals("0x333333"))
                {
                    LessonBrowserAutomationAgent.Click("SelectGradeView", "GradesButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    notAddedGrade = true;
                }
                else
                {
                    i++;
                }

            }
            if(notAddedGrade) 
            {
                LessonBrowserAutomationAgent.WaitforElement("SelectGradeView", "SelectedGrade", (i).ToString(), WaitTime.LargeWaitTime);
                LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "SelectedGrade", (i).ToString());
                return bool.Parse(LessonBrowserAutomationAgent.GetElementProperty("SelectGradeView", "ContinueButton", "enabled"));
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies that after tapping on cancel button user returns to the previous screen i.e Unit Browser
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">int: grade number selected</param>
        public static void VerifyCancelReturnsToPreviousScreen(AutomationAgent LessonBrowserAutomationAgent, int gradeNumber)
        {
            LessonBrowserAutomationAgent.Click("UnitLibraryView", "AddGrades");
            LessonBrowserAutomationAgent.Sleep(2000);
            LessonBrowserAutomationAgent.Click("SelectGradeView", "CancelButton");
            LessonBrowserAutomationAgent.VerifyElementFound("GradeSelectionMenuView", "ELAGradeButton", gradeNumber.ToString());
        }

        /// <summary>
        /// Verifies whether image is there in Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void VerifyImageinLesson(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonView", "ImageThumbnailInLesson");
        }
        /// <summary>
        /// Clicks On ImageInLesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnImageInLesson(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("LessonView", "ImageThumbnailInLessonClick");
        }

        /// <summary>
        /// Clicks On ImageInLesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnImageInLessonSecond(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("LessonView", "ImageThumbnailInLessonClickSecond");
        }
        /// <summary>
        /// Verifies Image in Full Screen On ImageInLesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// /// <returns>bool:true (if width equals device screen width), false(if width doesn't matches device width)</returns>
        public static bool VerifyImageFullScreen(AutomationAgent LessonBrowserAutomationAgent)
        {
            string WindowSize = LessonBrowserAutomationAgent.GetAllValues("NoteBookTouchView", "ScreenSizeHTML", "width")[0];
            string ImageSize = LessonBrowserAutomationAgent.GetAllValues("LessonView", "ImageFullScreenOpened", "width")[0];

            if (WindowSize == ImageSize)
                return true;

            else
                return false;

        }
        /// <summary>
        /// Clciks Done button available on screen
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickDoneButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("NotebookTopMenuView", "DoneBtnNewDesmos");
        }
        /// <summary>
        /// Verifies Lesson opened
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int</param>
        public static void VerifyLessonOpened(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "ELALessonCloseIcon", lessonNumber.ToString());
            LessonBrowserAutomationAgent.VerifyElementFound("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString());
        }
        /// <summary>
        /// Clicks on Start Button in Lesson Pop Up
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int</param>
        public static void ClickOnStartLessonButton(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            LessonBrowserAutomationAgent.Click("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString());
        }
        /// <summary>
        /// Verifies Lesson Opened to read
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void VerifyLessonOpenedToRead(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonView", "CurrentPageLabel");
            LessonBrowserAutomationAgent.VerifyElementFound("LessonView", "PreviousButton");
        }
        /// <summary>
        /// Verifies Wifi Icon present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(If Icon is present), false(If Icon is not present)</returns>
        public static bool VerifyWifiIcon(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("GradeSelectionMenuView", "NoWiFiIcon");
        }
        /// <summary>
        /// Verifies Lsson Browser App Chrome Title consists of Unit number(int type) and Unit name(string type)
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyLessonBrowserAppChromeTitle(AutomationAgent LessonBrowserAutomationAgent)
        {
            string s = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserPageTitle", "Inside", "");
            string[] s1 = s.Split('\t');
            string[] s2 = s1[2].Split(':');
            string[] s3 = s2[0].Split(' ');
            if (s3[0].Contains("Unit"))
            {
                int value = Int32.Parse(s3[1]);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Gets the Text of the Lesson Browser Back Button
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Back Button Text</returns>
        public static string GetLessonBrowserBackButtonText(AutomationAgent LessonBrowserAutomationAgent)
        {
            string s = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserBackButton", "Inside", "", 0, 0);
            string s1 = s.Replace("\t\n", "");
            return s1;
        }
        /// <summary>
        /// Gets the Subject Name
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Subject Name</returns>
        public static string GetSubjectName(AutomationAgent LessonBrowserAutomationAgent)
        {
            string s = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserPageTitle", "Inside", "");
            string[] s1 = s.Split('\t');
            string[] s2 = s1[1].Split(' ');
            return s2[0];
        }
        /// <summary>
        /// Gets Episode Label
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="episodeNumber">int</param>
        public static string GetEpisodeTitle(AutomationAgent LessonBrowserAutomationAgent, int episodeNumber)
        {
            return LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "EpisodeTitle", "NATIVE", "Inside", episodeNumber.ToString()).Replace("\t\n", "");
        }
        /// <summary>
        /// Gets the Episode Title present in any lesson Preview
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Episode Sub Title</returns>
        public static string GetEpisodeSubTitle(AutomationAgent LessonBrowserAutomationAgent)
        {
            string[] s = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "EpisodeSubTitle", "Inside", "").Split(':');
            return s[1];
        }
        /// <summary>
        /// Clicks on Lesson Browser Back Button
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLessonPreviewCloseButton(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "LessonPreviewCloseButton", lessonNumber.ToString());
        }
        /// <summary>
        /// Verifies If More than one episode exists
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="episodeNumber">int</param>
        /// <returns>bool: true(if more than one episode exist), false(if not)</returns>
        public static int GetWidthOfPageIndicator(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.WaitforElement("LessonBrowserView", "PaginationIndicator", "1", WaitTime.LargeWaitTime);
            string[] width = LessonBrowserAutomationAgent.GetAllValues("LessonBrowserView", "PaginationIndicator", "1", "width");
            return Int32.Parse(width[0]);
        }
        /// <summary>
        /// Navigate To Episode
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void NavigateEpisode(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Right, 10, 2000);
        }
        /// <summary>
        /// Verify Lesson Prgress Bar Exists or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int</param>
        /// <returns>bool: true(if Lesson Progress bar exists), false(if does not exists)</returns>
        public static bool VerifyLessonProgressBarExist(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonProgressBar", lessonNumber.ToString());
        }
        /// <summary>
        /// Verify Lesson Not Downloaded
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if lessons are  not downloaded), false(if all lesson are downloaded)</returns>
        public static bool VerifyLessonsNotDownloaded(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonDownloadButton");
        }
        /// <summary>
        /// Navigate to the Lessons from Lesson Preview
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void NavigateLesson(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Swipe(Direction.Right, 0, 100);
        }
        /// <summary>
        /// Navigates To the Previous Episode
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void NavigatePreviousEpisode(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Left, 10, 2000);
        }
        /// <summary>
        /// Verifies Lesson Preview Card avaialble
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if available), false(if not)</returns>
        public static bool VerifyLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonTitleInPreview");
        }
        /// <summary>
        /// Verifies Start Button In Lesson Preview is available or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if available), false(if not available)</returns>
        public static bool VerifyStartButtonForLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonsOverView", "ELALessonCommonContinueButton");
        }
        /// <summary>
        /// Verifies Pagination Indicator available
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if avaialable), false(if not)</returns>
        public static bool VerifyPaginationIndicatorInLessonPreview(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonsOverView", "LessonPreviewPaginationIndicator");
        }
        /// <summary>
        /// Verifies lesson Browser Page
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent"></param>
        /// <returns>bool: true(if avaialable), false(if not)</returns>
        public static bool VerifyLessonBrowserPage(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonBrowserCollection");
        }



        /// <summary>
        /// Clicks on Teacher Content Icon
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickTeacherContentIcon(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("TasksTopMenuView", "TeacherModeIcon");
        }
        /// <summary>
        /// Verifies Teacher Mode Is opened Or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyAccordionTeacherModeOpen(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeAccordionView");
        }


        /// <summary>
        /// Click on Start Unit Button in Unit Preview
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="unitnumber"></param>
        public static void ClickStartUnitButtonInUnitPreview(AutomationAgent LessonBrowserAutomationAgent, int unitnumber)
        {
            LessonBrowserAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitnumber.ToString());
        }
        /// <summary>
        /// Click on Lesson in Lesson Browser
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="unitnumber"></param>
        public static void ClickOnLessonInLessonBrowser(AutomationAgent LessonBrowserAutomationAgent, int unitnumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "ELALessonTile", unitnumber.ToString());
        }

        /// <summary>
        /// Click on Start Unit Button in Unit Preview
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="unitnumber"></param>
        public static void ClickStartUnitButtonInUnitPreview(AutomationAgent LessonBrowserAutomationAgent, string unitnumber)
        {
            LessonBrowserAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitnumber.ToString());
        }
        /// <summary>
        /// Click on Lesson in Lesson Browser
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="unitnumber"></param>
        public static void ClickOnLessonInLessonBrowser(AutomationAgent LessonBrowserAutomationAgent, string unitnumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "ELALessonTile", unitnumber.ToString());
        }
        /// <summary>
        /// Swipe the lesson preview Card
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="direction"></param>
        public static void SwipeLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent, Direction direction)
        {
            LessonBrowserAutomationAgent.Swipe(direction, 0, 2000);
        }
        /// <summary>
        /// Swipe the lesson preview Card in a particular direction
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="direction"></param>
        public static void SwipeLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent, int Lesson, Direction direction)
        {
            LessonBrowserAutomationAgent.SwipeElement("LessonsOverView", "LessonTitleInPreview", Lesson.ToString(), direction, 0, 2000);
            LessonBrowserAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verify Start Button is Grayed Out for Not Downloaded Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyStartButtonGrayedOutForNotDownLoadedLesson(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonView", "LessonGrayedOutStartButton");
        }

        /// <summary>
        /// Tap on Lesson on Not yet downloaded lesson For Downloading
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonnumber"></param>
        public static void TapOnLessonForDownloading(AutomationAgent LessonBrowserAutomationAgent, int lessonnumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "DownloadIconForLesson", lessonnumber.ToString());
        }
        /// <summary>
        /// Clicks on In Progress Downloading Lesson Thumbnail
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonnumber"></param>
        public static void ClickOnInProgressDownloadingLessonThumbnail(AutomationAgent LessonBrowserAutomationAgent, int lessonnumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "DownloadLessonThumbnail", lessonnumber.ToString());
        }


        /// <summary>
        /// Verify Lesson Preview Card for Not downloaded lesson is grayed
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonnumber"></param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyLessonPreviewCardContentIsGrayed(AutomationAgent LessonBrowserAutomationAgent, int lessonnumber)
        {
            String Value = LessonBrowserAutomationAgent.GetAllValues("LessonBrowserView", "LessonPreviewContentGrayed", lessonnumber.ToString(), "enabled")[0];
            if (Value == "false")
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// Verifies Progress Bar On Lesson Preview Card
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyProgressBarOnLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonProgressBar");
        }
        /// <summary>
        /// Verifies Progress Bar On Lesson Preview Card
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyProgressBarOnLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonsOverView", "LessonOverviewProgressBar", lessonNumber.ToString());
        }
        /// <summary>
        /// Clicks On Download Icon Of Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">Lesson to be downloaded</param>
        public static void ClickOnDownloadIconOfLesson(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "DownloadIconForLesson", lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies if Teacher mode is scaled properly or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher mode is scaled), false(if teacher mode is not scaled)</returns>
        public static bool VerifyTeacherModeScaledProperly(AutomationAgent LessonBrowserAutomationAgent)
        {
            string width = LessonBrowserAutomationAgent.GetAllValues("TeacherModeView", "TeacherModeContent", "width")[0];

            if (Int32.Parse(width) < 1024)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the Bottom Black Bar Present if Teacher Mode is opened
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyBottomBlackBar(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("TeacherModeView", "TeacherModeBottomBlackBar");
            string color = LessonBrowserAutomationAgent.GetElementProperty("TeacherModeView", "TeacherModeBottomBlackBar", "backgroundColor");
            if (color == "0x262626")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Math Unit Preview card
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if preview card present), false(if preview card is not present)</returns>
        public static bool VerifyMathUnitPreview(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("UnitOverView", "MathUnitPreviewCard");
        }
        /// <summary>
        /// Verifies Math Lesson Preview Card
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Present), false(if not present)</returns>
        public static bool VerifyMathLessonPreview(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonView", "MathLessonPreview");
        }
        /// <summary>
        /// Gets the Title of the Lesson Page
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Lesson number with name</returns>
        public static string GetLessonTitle(AutomationAgent LessonBrowserAutomationAgent)
        {
            string[] s = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserPageTitle", "Inside", "").Split('\t');
            return s[2];
        }

        /// <summary>
        /// Verifies the lesson's preview card by finding its title
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int</param>
        public static void VerifyLessonPreviewCard(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonsOverView", "LessonTitleInPreview", lessonNumber.ToString());
        }
        /// <summary>
        /// Verifies if back button present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyBackButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonBrowserBackButton");
        }
        /// <summary>
        /// Verifies if Resource Library icon is present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyResourceLibraryIconPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon");
        }
        /// <summary>
        /// Swipe Episode in Lesson Browser 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="direction">direction in which we need to be swiped</param>
        public static void SwipeEpisode(AutomationAgent LessonBrowserAutomationAgent, Direction direction)
        {
            LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", direction, 100, 2000);
        }
        /// <summary>
        /// Lessons panel can scroll vertically in episode.
        /// a)if lessons are less rhan equal to 6 then swipe to next episode
        /// b)if more than 6 lessons scroll within lesson panel.
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ScrollLessonsInLessonBrowser(AutomationAgent LessonBrowserAutomationAgent)
        {
            int j = LessonBrowserAutomationAgent.GetElementCountIn("LessonBrowserView", "LessonBrowserCollection", "inside", "LessonBrowserView", "ElaLessonCell");

            while (true)
            {
                if (j <= 6)
                {
                    LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Right, 100, 2000);
                    LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Down, 500, 1000);
                    break;
                }
                else
                {
                    LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Down, 500, 1000);
                    break;
                }
            }
        }
        /// <summary>
        ///  Lessons panel cannot scroll  in episode.
        /// a) if lesson are more than six it cannot swipe
        /// <param name="LessonBrowserAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyLessonsNotScrollable(AutomationAgent LessonBrowserAutomationAgent)
        {
            int j = LessonBrowserAutomationAgent.GetElementCountIn("LessonBrowserView", "LessonBrowserCollection", "inside", "LessonBrowserView", "ElaLessonCell");
            string s = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserCollection", "inside", "");
            while (true)
            {
                if (j > 6)
                {
                    LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Right, 10, 2000);
                    break;
                }
                else
                {
                    LessonBrowserAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Down, 500, 1000);
                    break;
                }
            }
            string s1 = LessonBrowserAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserCollection", "inside", "");
            if (s.Equals(s1))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verfies LessonBrowserPaginationIndicator
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>

        public static bool VerifyLessonBrowserPaginationIndicator(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "PaginationIndicator", "1");
        }

        public static void LessonProgressBarExistUntilDownloadComplete(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            bool lessonNotDownloaded = false;
            while (!lessonNotDownloaded)
            {
                if (LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonProgressBar", lessonNumber.ToString()))
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    lessonNotDownloaded = true;
                }
                break;
            }
        }
        /// <summary>
        /// Swipes till not downloaded lesson is found in lesson preview
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="direction">Right</param>
        public static void SwipeLessonPreviewTillContinueDisabled(AutomationAgent LessonBrowserAutomationAgent, Direction direction)
        {
            int j = LessonBrowserAutomationAgent.GetElementCount("LessonBrowserView", "MathLessonCount");
            for (int i = 1; i <= 6; i++)
            {
                if (bool.Parse(LessonBrowserAutomationAgent.GetAllValues("LessonsOverView", "MathLessonStartButton", i.ToString(), "top")[0]))
                {
                    LessonBrowserAutomationAgent.Swipe(direction);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Verifies Start button disabled in lesson Preview card.
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyStartButtonInLessonPreview(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonsOverView", "MathLessonStartButton");
        }
        /// <summary>
        /// Verfies No Wifi Icon In lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool NoWifiIconInLesson(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "NoWifiIconInLesson");
        }

        /// <summary>
        /// Waits for the lesson to download by verifying the lesson tile enabled status
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">Lesson Number</param>
        public static void WaitForLessonToDownloaded(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            while (!bool.Parse(LessonBrowserAutomationAgent.GetElementProperty("LessonBrowserView", "ELALessonTile", "enabled")))
            {
                LessonBrowserAutomationAgent.Sleep();
            }
        }

        internal static bool VerifyNotebookSplitsScreen()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Clicks the lesson which is not downloaded
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber"></param>
        public static void ClickLessonNotDownloadedInLessonPreview(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            if (LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonDownloadButton"))
            {
                LessonBrowserAutomationAgent.Click("LessonBrowserView", "LessonDownloadButton", lessonNumber.ToString());
                LessonBrowserAutomationAgent.Sleep();
                while (LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonProgressBar"))
                {

                }
            }
        }


        public static void ScrollToLastEpisode(AutomationAgent LessonBrowserAutomationAgent)
        {
            int noOfEpisodes = GetNumberOfEpisodesInLessonBrowser(LessonBrowserAutomationAgent);
            for (int i = 1; i <= noOfEpisodes; i++)
            {
                SwipeToEpisode(LessonBrowserAutomationAgent, true);
            }
        }

        private static void SwipeToEpisode(AutomationAgent LessonBrowserAutomationAgent, bool nextEpisode)
        {
            if (nextEpisode)
                LessonBrowserAutomationAgent.Drag(1300, 850, 500, 850);
            else
                LessonBrowserAutomationAgent.Drag(1000, 850, 1700, 850);
        }

        public static int GetNumberOfEpisodesInLessonBrowser(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.GetElementCount("LessonBrowserView", "UIPageNumberControl");
        }

        public static int GetLastLessonNumberInEpisode(AutomationAgent LessonBrowserAutomationAgent)
        {
            int noOFLessons = LessonBrowserAutomationAgent.GetElementCount("LessonBrowserView", "LessonNumberLabel");
            int[] lessonNumbers = new int[noOFLessons];
            for (int i = 0; i < noOFLessons; i++)
            {
                if (bool.Parse(LessonBrowserAutomationAgent.GetElementProperty("LessonBrowserView", "LessonNumberLabel", "onscreen", index: i)))
                    lessonNumbers[i] = int.Parse(LessonBrowserAutomationAgent.GetElementText("LessonBrowserView", "LessonNumberLabel", i));
            }
            return lessonNumbers.Max();
        }

        /// <summary>
        /// Verifies ELA start button active status
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent Object</param>
        /// <param name="lessonNumber"></param>
        public static bool VerifyELAStartButtonActive(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            return bool.Parse(navigationAutomationAgent.GetElementProperty("LessonsOverView", "ELALessonStartButton", "enabled", lessonNumber.ToString()));
        }
        /// <summary>
        /// Verifies Teacher Mode Opened
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>bool</returns>
        public static bool VerifyTeacherModeOpened(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeOpenedMath");
        }
        /// <summary>
        /// Click the pause buttton in video 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent Object</param>
        public static void ClickPauseButtonInVideo(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Sleep(1000);
            if (!LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "VideoPlayerPause"))
            {
                LessonBrowserAutomationAgent.ClickCoordinate(130, 226, 1);
            }
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "VideoPlayerPause");
            LessonBrowserAutomationAgent.Click("LessonBrowserView", "DoneButtonInVideo");

        }
        /// <summary>
        /// Verifies the Gallery Page present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGalleryProblemPage(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.IsElementFound("GalleryView", "GalleryProblemPage");

        }
    }
}