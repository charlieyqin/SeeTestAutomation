using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{

    public static class GalleryProblemCommonMethods
    {
        /// <summary>
        /// Clicks on Gallery Problem in Lesson Task
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void OpenGalleryProblem(AutomationAgent GalleryProblemAutomationAgent)
        {
            GalleryProblemAutomationAgent.Click("GalleryView", "GalleryProblemInLessonTask");
            GalleryProblemAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verifies the Gallery Page present or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGalleryProblemPage(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.IsElementFound("GalleryView", "TextToFind", "Concept");

        }
        /// <summary>
        /// Verifies if Done Button Present in the Gallery Page or not
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDoneButtonInGalleryProblemPage(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.IsElementFound("GalleryView", "DoneButton");
        }
        /// <summary>
        /// Clicks on Gallery Problem Done Button
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickGalleryProblemDoneButton(AutomationAgent GalleryProblemAutomationAgent)
        {
            GalleryProblemAutomationAgent.Sleep();
            if (GalleryProblemAutomationAgent.IsElementFound("GalleryView", "DoneButton"))
            {
                GalleryProblemAutomationAgent.Click("GalleryView", "DoneButton");
            }
        }
        /// <summary>
        /// Verifies the Gallery Problem LEsson Task Page
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Lesson Task Page is opened), false(if Lesson Task Page is not open)</returns>
        public static bool VerifyGalleryProblemLessonTaskPage(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.IsElementFound("GalleryView", "GalleryProblemLessonTask");
        }

        public static string GetUnitBackButtonText(AutomationAgent GalleryProblemAutomationAgent)
        {
            GalleryProblemAutomationAgent.VerifyElementFound("LessonBrowserView", "LessonBrowserBackButton");
            GalleryProblemAutomationAgent.Sleep();
            string[] s = GalleryProblemAutomationAgent.GetTextIn("LessonBrowserView", "LessonBrowserBackButton", "NATIVE", "Inside", "", 0, 0).Split(' ');
            string[] s1 = s[1].Split('\t');
            return s[0] + " " + s1[0];
        }

        /// <summary>
        /// Verifies if all the Icons are Present or not in the App chrome for teacher 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGalleryLessonChromeIconsForTeacher(AutomationAgent GalleryProblemAutomationAgent)
        {
            if (GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "NotebookIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "ConceptCornerIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "SharingNotificationIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "TeacherModeIcon")
               )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies if all the Icons are Present or not in the App chrome for Students 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGalleryLessonChromeIconsForStudents(AutomationAgent GalleryProblemAutomationAgent)
        {
            if (GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "NotebookIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "ConceptCornerIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "SharingNotificationIcon")
               )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies all the Icons present in the Gallery Problem chrome bar
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGalleryProblemChromeBarIcons(AutomationAgent GalleryProblemAutomationAgent)
        {
            if (GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("TasksTopMenuView", "NotebookIcon") &&
                GalleryProblemAutomationAgent.IsElementFound("GalleryView", "DoneButton")
               )
                return true;
            else
                return false;
        }

        public static string GetGalleryProblemPosition(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.GetPosition("GalleryView", "GalleryProblemInLessonTask");
        }

        public static bool VerifyPaginationIndicatorPresence(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.IsElementFound("GalleryView", "GalleryProblemPaginationIndicator");
        }

        public static int GetGalleryProblemThumbnails(AutomationAgent GalleryProblemAutomationAgent)
        {
            int thumbnailcount = 1;
            while (GalleryProblemAutomationAgent.IsElementFound("GalleryView", "GalleryProblemThumbnail", thumbnailcount.ToString()))
            {
                thumbnailcount++;
            }
            return (thumbnailcount - 1);
        }
        /// <summary>
        /// Verify gallery lesson opens in full screen 
        /// </summary>
        /// <param name="GalleryProblemAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyGalleryLessonFullScreen(AutomationAgent GalleryProblemAutomationAgent)
        {
            int length = Int32.Parse(GalleryProblemAutomationAgent.GetAllValues("LessonBrowserView", "LessonBrowserPageTitle", "width")[0]);
            return length.Equals(2048);
        }

        public static bool VerifyGalleryProblemInLessonTaskPage(AutomationAgent GalleryProblemAutomationAgent)
        {
            return GalleryProblemAutomationAgent.IsElementFound("GalleryView", "GalleryProblemInLessonTask");
        }
        /// <summary>
        /// Open gallery problem
        /// </summary>
        /// <param name="GalleryProblemAutomationAgent">AutomationAgent object</param>
        public static void OpenGalleryProblemWithMultiplePages(AutomationAgent GalleryProblemAutomationAgent)
        {
            GalleryProblemAutomationAgent.Click("GalleryView", "MultipleGalleryProblem");
        }
        /// <summary>
        /// open image in gallery task page
        /// </summary>
        /// <param name="GalleryProblemAutomationAgent">AutomationAgent object</param>
        public static void OpenImageInGalleryTaskPage(AutomationAgent GalleryProblemAutomationAgent, int pageNumber)
        {
            GalleryProblemAutomationAgent.Sleep();
            for (int swipe = 1; swipe < pageNumber; swipe++)
            {
                GalleryProblemAutomationAgent.Swipe(Direction.Right);
            }
            GalleryProblemAutomationAgent.Click("GalleryView", "GalleryProblemImage");
            GalleryProblemAutomationAgent.Sleep(3000);
        }

        public static void NavigateToTaskPageInGalleryProblem(AutomationAgent navigationAutomationAgent, int taskNumber)
        {
            int currentTaskNumber = int.Parse(navigationAutomationAgent.GetElementText("GalleryView", "CurrentPageLabel"));
            int numberOfPagesToTraverse = 0;
            if (currentTaskNumber > taskNumber)
            {
                numberOfPagesToTraverse = currentTaskNumber - taskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    navigationAutomationAgent.Click("GalleryView", "PreviousButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
            else if (currentTaskNumber < taskNumber)
            {
                numberOfPagesToTraverse = taskNumber - currentTaskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    navigationAutomationAgent.Click("GalleryView", "NextButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
}
