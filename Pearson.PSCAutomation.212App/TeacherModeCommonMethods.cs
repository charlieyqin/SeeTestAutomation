using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public class TeacherModeCommonMethods
    {
        /// <summary>
        /// Clicks on Teacher Mode icon present at the Top
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeIcon(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TasksTopMenuView", "TeacherModeIcon");
            teachermodeAutomationAgent.Sleep();
        }

        /// <summary>
        /// Clicks on Teacher Mode On icon present at the Top
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeOnIcon(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TasksTopMenuView", "TeacherModeOnIcon");
            teachermodeAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies if Teacher Mode open or closed
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if closed)</returns>
        public static bool VerifyTeacherModeOpen(AutomationAgent teachermodeAutomationAgent)
        {
            if (teachermodeAutomationAgent.IsElementFound("TasksTopMenuView", "TeacherModeDropDown") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "UnitOverview") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "LessonOverview") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "TaskGuide")
                )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets the Teacher Mode Fly Out's Header Title
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Title of the Fly Out Menu</returns>
        public static string GetTeacherModeFlyOutHeader(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetTextIn("TasksTopMenuView", "TeacherModeFlyOutHeader", "TEXT", "Inside", "");
        }
        /// <summary>
        /// Verifies the Teacher Mode Fly Out Header displaying Teacher Guide
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher Guide Fly Out Header found), false(if Fly Out header not found)</returns>
        public static bool VerifyTeacherGuideFlyOutHeader(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TasksTopMenuView", "TeacherModeTeacherGuideTitle");
        }
        /// <summary>
        /// Verifies the Unit Overview Button is highlighted or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string VerifyUnitOverviewHighlighted(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetElementProperty("TeacherModeView", "UnitOverviewButton", "enabled");
        }
        /// <summary>
        /// Verifies the Lesson Overview Button is highlighted or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string VerifyLessonOverviewHighlighted(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetElementProperty("TeacherModeView", "LessonOverview", "enabled");
        }
        /// <summary>
        /// Verifies the Task Guide Button is highlighted or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string VerifyTaskGuideHighlighted(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetElementProperty("TeacherModeView", "TaskGuide", "enabled");

        }
        /// <summary>
        /// Gets the text color of Unit Overview 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Text Color</returns>
        public static string GetUnitOverviewTextColor(AutomationAgent teachermodeAutomationAgent)
        {
            string[] str;
            str = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "UnitOverview", "textColor");
            return str[1];
        }
        /// <summary>
        /// Gets the text color of Lesson Overview
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Text Color</returns>
        public static string GetLessonOverviewTextColor(AutomationAgent teachermodeAutomationAgent)
        {
            string[] str;
            str = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "LessonOverviewText", "textColor");
            return str[0];
        }
        /// <summary>
        /// Gets the text color of Task Guide
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Text Color</returns>
        public static string GetTaskGuideTextColor(AutomationAgent teachermodeAutomationAgent)
        {
            string[] str;
            str = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "TaskGuideText", "textColor");
            return str[0];
        }
        /// <summary>
        /// Verifies Lesson Preview
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyLessonPreview(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("LessonsOverView", "ELALessonCommonContinueButton");
        }
        /// <summary>
        /// Verifies Lesson Browser Page
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyLessonBrowserPage(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            return teachermodeAutomationAgent.IsElementFound("LessonBrowserView", "LessonEpisodeCell");
        }
        /// <summary>
        /// Verifies Lesson Task Page
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyLessonTaskPage(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("LessonView", "CurrentPageLabel");
        }
        /// <summary>
        /// Clicks on Lesson Overview in Teacher Mode Fly out menu
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickLessonOverview(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "LessonOverview");
        }
        /// <summary>
        /// Clicks On Canvas To Add Notes
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCanvasToAddNotes(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            teachermodeAutomationAgent.Click("TeacherModeView", "AddNotesButton");

        }
        /// <summary>
        /// Verifies all the elements present in Add Notes Overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAddNoteOverlayElements(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "AddYourNotesOverlayTitle") &&
            teachermodeAutomationAgent.IsElementFound("TeacherModeView", "CancelButton")  &&
            teachermodeAutomationAgent.IsElementFound("TeacherModeView", "TextBox") &&
            teachermodeAutomationAgent.IsElementFound("TeacherModeView", "CreateButton") &&
            teachermodeAutomationAgent.IsElementFound("TeacherModeView", "CloseButton") &&
            teachermodeAutomationAgent.IsElementFound("TeacherModeView", "CharacterCount");
        }
        /// <summary>
        /// Clicks on Close Button In Add Your Notes Overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickCloseButtonInAddNotesOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "CloseButton");
        }
        /// <summary>
        /// Sends the Text into the text box in Add Your Notes Overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="Text">string</param>
        public static void SendText(AutomationAgent teachermodeAutomationAgent, string Text)
        {
            teachermodeAutomationAgent.Sleep();
            teachermodeAutomationAgent.SendText(Text);
        }

        public static bool VerifyKeyboardPresence(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            return teachermodeAutomationAgent.IsElementFound("KeyboardView", "KeyBoardPresenceElement");
        }
        /// <summary>
        /// Clicks on the Cancel Button present in the Add Your Notes Overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelInAddNotesOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "CancelButton");
            teachermodeAutomationAgent.Sleep();
        }
        /// <summary>
        /// Gets the Text Present in the Text Zone
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: texts present</returns>
        public static string GetTextInTextZone(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetText("TEXT");
        }
        /// <summary>
        /// Gets the Text Present inside the Canvas
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text present in the Canvas</returns>
        public static string GetMessageInCanvas(AutomationAgent teachermodeAutomationAgent)
        {
            string[] s = teachermodeAutomationAgent.GetTextIn("TeacherModeView", "AddNotesButton", "Inside", "", "NATIVE", 0, 0, 0).Split('\t');
            return s[0];
        }
        /// <summary>
        /// Clicks on Create Button Present in Add Your Notes Overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickCreateInAddNotesOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "CreateButton");
        }
        /// <summary>
        /// Gets the enabled property of the Create Button Present in the Add Your notes overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: enabled property</returns>
        public static string VerifyCreateButtonActive(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetElementProperty("TeacherModeView", "CreateButton", "enabled", "");
        }
        /// <summary>
        /// Deletes the text present in the text box in Add Your notes overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void DeleteTextInTextBox(AutomationAgent teachermodeAutomationAgent, string text)
        {
            for (int i = 0; i < text.Length; i++)
                teachermodeAutomationAgent.SendText("{BKSP}");
            teachermodeAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies the Edit button Present in the Canvas
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if edit button is present), false(if edit button is not present)</returns>
        public static bool VerifyEditButtonInCanvas(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "EditButton");
        }
        /// <summary>
        /// Gets the note in My Task notes 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: note present in my task notes</returns>
        public static string GetDefaultMyTaskNotes(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            return teachermodeAutomationAgent.GetAllValues("TeacherModeView", "AddNotesButton", "text")[0];            
        }

        public static string GetCharacterCount(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            return teachermodeAutomationAgent.GetAllValues("TeacherModeView", "CharacterCount", "text")[0];
        }

        public static string GetNoteInMyTaskNotes(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            return teachermodeAutomationAgent.GetAllValues("TeacherModeView", "NoteInMyTaskNotes", "text")[0];
        }
        /// <summary>
        /// Clicks on Edit Button Present in the Canvas
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickEditInCanvas(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "EditButton");
        }
        /// <summary>
        /// Click on Delete Button present in Edit Your Notes Overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickDeleteInEditYourNotes(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "DeleteButton");
            teachermodeAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies All the Elements Present in Edit Your Notes Overlay 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void VerifyEditNoteOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.VerifyElementFound("TeacherModeView", "EditYourNotesOverlayTitle");
            teachermodeAutomationAgent.VerifyElementFound("TeacherModeView", "DeleteButton");
            teachermodeAutomationAgent.VerifyElementFound("TeacherModeView", "DoneButton");
            teachermodeAutomationAgent.VerifyElementFound("TeacherModeView", "CharacterCount");
            teachermodeAutomationAgent.VerifyElementFound("TeacherModeView", "CloseButton");
        }
        /// <summary>
        /// Verifies Close Button Present in the Edit Your Notes overlay is at Upper Right Corner
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyCloseButton(AutomationAgent teachermodeAutomationAgent)
        {
            int xPos = Int32.Parse(teachermodeAutomationAgent.GetAllValues("TeacherModeView", "CloseButton", "x")[0]);
            int yPos = Int32.Parse(teachermodeAutomationAgent.GetAllValues("TeacherModeView", "CloseButton", "y")[0]);
            if (xPos == 1534 && yPos == 64)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Done button present in Edit Your Notes
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickDoneInEditYourNotes(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep();
            teachermodeAutomationAgent.Click("TeacherModeView", "DoneButton");
        }
        /// <summary>
        /// Verifies If Add Your Notes Oerlay Present or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAddNoteOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "AddYourNotesOverlayTitle");
        }
        /// <summary>
        /// gets the text from the textbox
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text present in the text box</returns>
        public static string GetTextFromTextBox(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetTextIn("TeacherModeView", "TextBox", "Inside", "");
        }

        /// <summary>
        /// Click on Teacher Guide Icon
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherGuideIcon(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TasksTopMenuView", "TeacherModeIcon");
        }


        /// <summary>
        /// Verify Teacher Guide Content is displayed or not by verifying if expand arrow in teacher mode is present or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher Guide Content is present), false(if Teacher Guide Content is not present)</returns>
        public static bool VerifyTeacherGuideContentDisplayed(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ExpandArrowInTeacherMode");
        }

        /// <summary>
        /// Verify Close button is present in Teacher Content overlay or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Close button is present), false(if  Close button is not present)</returns>
        public static bool VerifyCloseButtonInTeacherContentOverlayPresent(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "TeacherContentCloseButton");
        }

        /// <summary>
        /// Click on Unit Overview in Teacher Guide overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickUnitOverviewFromTeacherGuideOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "UnitOverview");
            teachermodeAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verify Close button is active in Teacher Content overlay or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Close button is active), false(if  Close button is not active)</returns>
        public static bool VerifyCloseButtonInTeacherContentOverlayActive(AutomationAgent teachermodeAutomationAgent)
        {
            string value = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "TeacherContentCloseButton", "enabled")[0];
            if (value == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click on Close button in teacher content overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickCloseButtonInTeacherContentOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "TeacherContentCloseButton");
            teachermodeAutomationAgent.Sleep();
        }

        /// <summary>
        /// Click on Lesson Overview in Teacher Guide overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickLessonOverviewFromTeacherGuideOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.WaitforElement("TeacherModeView", "LessonOverview","", 3000);
            teachermodeAutomationAgent.Click("TeacherModeView", "LessonOverview");
            teachermodeAutomationAgent.Sleep();
        }
        /// <summary>
        /// Click on Task Guide in Teacher Guide overlay
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickTaskGuideInTeacherGuideOverlay(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "TaskGuide");
            teachermodeAutomationAgent.Sleep();
        }

        /// <summary>
        /// Clicks on Teacher Guide Icon in Teacher Guide Content
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickTeacherGuideIconInTeacherGuideContent(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "TeacherGuideIconInTeacherGuideContent");
        }
        /// <summary>
        /// Verify Teacher Guide Flyout opens or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher Guide Flyout opens), false(if  Teacher Guide Flyout doesnt opens)</returns>
        public static bool VerifyTeacherGuideFlyOutOpened(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "TeacherGuideFlyout");
        }
        /// <summary>
        /// Clicks on Define Menu present in the Contextual Menu
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDefineMenu(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("NotebookView", "DefineMenu");
        }
        /// <summary>
        /// Verifies if Done button is enabled or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: true(if enable true), false(if enable false)</returns>
        public static string VerifyDoneButtonIsEnabled(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetElementProperty("TeacherModeView", "DoneButton", "enabled");
        }
        /// <summary>
        /// Verifies if Teacher Mode is opened or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not open)</returns>
        public static bool VerifyAccordionTeacherModeOpen(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeAccordionView");
        }
        /// <summary>
        /// Verifies if Unit Overview is open
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyUnitOverviewExpands(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if About This Lesson is open 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if open), false(if not)</returns>
        public static bool VerifyAboutThisLessonExpands(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if Teacher Guide is open 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher guide is open), false(if teacher guide is not open)</returns>
        public static bool VerifyTeacherGuideExpands(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if Teacher Guide is Collapsed
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if teacher guide is collaped), false(if not)</returns>
        public static bool VerifyTeacherGuideCollapse(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies if Unit Overview is Collapsed
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if collapsed), false(if not)</returns>
        public static bool VerifyUnitOverviewCollapse(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies if About This Lesson is collapsed
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if collapsed), false(if not)</returns>
        public static bool VerifyAboutThisLessonCollapse(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies Teacher Contol Panel is on the right 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherContentPanelOnTheRight(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.VerifyIn("TeacherModeView", "Screen", "Right", "TeacherModeView", "TeacherGuideUnitOverviewPanel");
        }
        /// <summary>
        /// Gets the Screen Size 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>int: screen size</returns>
        public static int GetScreenSize(AutomationAgent teachermodeAutomationAgent)
        {
            string WindowSize = teachermodeAutomationAgent.GetAllValues("LessonBrowserView", "LessonBrowserPageTitle", "width")[0];
            if (teachermodeAutomationAgent.IsElementFound( "TeacherModeView", "Screen")) 
            {
                string s = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "Screen", "width")[0];
                return Int32.Parse(s);
            }
            return Int32.Parse(WindowSize);
        }
        /// <summary>
        /// Click On Text In Task Notes
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="text">Text to be clicked</param>
        public static void ClickOnText(AutomationAgent teachermodeAutomationAgent, string text)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "TextBox", text);
        }
        /// <summary>
        /// Click on Select Menu
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void SelectMenu(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "Select");
        }
        /// <summary>
        /// Verifies Task Guide is opened or closed
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if opened), false(if closed)</returns>
        public static bool VerifyTaskGuideOpened(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "TaskGuideInTeacherMode");
        }
        /// <summary>
        /// Verifies Edit Button Is Hidden In Canvas or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if hidden), false(if not hidden)</returns>
        public static bool VerifyEditButtonHiddenInCanvas(AutomationAgent teachermodeAutomationAgent)
        {
            string hidden = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "EditbuttonInCanvas", "hidden")[0];
            return bool.Parse(hidden);

        }
        /// <summary>
        /// Verifies If My Task Notes Button is hidden or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if hidden), false(if not hidden)</returns>
        public static bool VerifyMyTaskNotesButtonHidden(AutomationAgent teachermodeAutomationAgent)
        {
            string hidden = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "MyTaskNotesButton", "hidden")[0];
            return bool.Parse(hidden);
        }
        /// <summary>
        ///  Verifies If My Class Button is hidden or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if hidden), false(if not hidden)</returns>
        public static bool VerifyMyClassButtonHidden(AutomationAgent teachermodeAutomationAgent)
        {
            string hidden = teachermodeAutomationAgent.GetAllValues("TeacherModeView", "MyClassButton", "hidden")[0];
            return bool.Parse(hidden);
        }
        /// <summary>
        /// Verifies MyClass Button is visible
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>true if MyClass is visible</returns>
        public static bool VerifyMyClassButtonVisible(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "MyClassButton");
        }
        /// <summary>
        /// Gets the Lesson Title Present in the Lesson Preview 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int: lesson number to check for the title</param>
        /// <returns></returns>
        public static string GetLessonTitleInPreview(AutomationAgent teachermodeAutomationAgent, int lessonNumber)
        {
            string[] s = teachermodeAutomationAgent.GetTextIn("LessonsOverView", "LessonTitleInPreview", "Inside", lessonNumber.ToString()).Split(':');
            return s[1].Replace("\t\n", "");
        }
        /// <summary>
        /// Gets the Lesson Title Present in the Teacher Mode
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int: lesson number to check for the title</param>
        /// <returns></returns>
        public static string GetLessonTitleInTeacherMode(AutomationAgent teachermodeAutomationAgent, int lessonNumber)
        {
            string s = teachermodeAutomationAgent.GetTextIn("LessonsOverView", "LessonTitleInTeacherMode", "Inside", lessonNumber.ToString());
            return s.Replace("\t\n", "");
        }
        /// <summary>
        /// Navigates through Lessons 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">lesson number to swipe</param>
        public static void NavigateThroughLessons(AutomationAgent teachermodeAutomationAgent, int p)
        {
            teachermodeAutomationAgent.SwipeElement("LessonBrowserView", "LessonPreviewContentGrayed", Direction.Right, -100, 1000);
        }
        /// <summary>
        /// Select Correct Word In Contextual Menu
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void SelectCorrectWordContextualMenu(AutomationAgent teachermodeAutomationAgent, string word = "taste")
        {
            teachermodeAutomationAgent.Sleep();
            teachermodeAutomationAgent.Click("TeacherModeView", "CorrectContextualMenuWord", word, 1, 0);
        }
        /// <summary>
        /// Clicks on the Teacher Mode Arrow Icon 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeArrowIcon(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherModeView", "TeacherModeArrowButton");
            teachersupportAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies Lesson OverView Header In TeacherMode
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="lesson">lesson to verify</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyLessonOverViewHeaderInTeacherMode(AutomationAgent teachermodeAutomationAgent, int lesson)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "LessonOverviewHeaderTeacherMode", lesson.ToString());
        }
        /// <summary>
        /// Verifies Notes Area appear in task notes or not
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNotesAreaAppearsInTaskNotes(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "NoteInMyTaskNotes");
        }

        /// <summary>
        /// Get the Lesson Overview Content Heading
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Lesson Overview Content Heading</returns>
        public static string GetLessonOverviewContentHeading(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.WaitForElement("TeacherModeView", "LessonOverviewContentHeaderTeacherMode", WaitTime.MediumWaitTime);
            return teachermodeAutomationAgent.GetElementText("TeacherModeView", "LessonOverviewContentHeaderTeacherMode");
            //return teachermodeAutomationAgent.GetTextIn("TeacherModeView", "LessonOverviewContentHeaderTeacherMode", "Inside", "", 0, 0);
        }
        /// <summary>
        /// Verify My Task Notes Header
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: My Task Notes Header</returns>
        public static string VerifyMyTaskNotesHeader(AutomationAgent teachermodeAutomationAgent)
        {
            string NotesHeading = teachermodeAutomationAgent.GetTextIn("TeacherModeView", "MyTaskNotesHeader", "Inside", "", 0, 0);
            return NotesHeading.Replace("\t\n", "");
        }
        /// <summary>
        /// Verify Unit OverView Header In Teacher Mode 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="unit">unit number</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyUnitOverViewHeaderInTeacherMode(AutomationAgent teachermodeAutomationAgent, int unit)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "UnitOverviewHeaderTeacherMode", unit.ToString());
        }

        /// <summary>
        /// Verify Unit OverView Header In Teacher Mode 
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <param name="unit">unit number</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyUnitOverViewHeaderInTeacherMode(AutomationAgent teachermodeAutomationAgent, string unit)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "UnitOverviewHeaderTeacherMode", unit.ToString());
        }
        /// <summary>
        /// Verify Instructional Message In TaskNotes Box In Task
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Instructional Message</returns>
        public static string VerifyInstructionalMessageInTaskNotesBoxInTask(AutomationAgent teachermodeAutomationAgent)
        {
            string InsMessage = teachermodeAutomationAgent.GetTextIn("TeacherModeView", "TaskNotesInstructionalMessageInTask", "Inside", "", 0, 0);
            return InsMessage.Replace("\t\n", "");
        }
        /// <summary>
        /// Verify Instructional Message In TaskNotes Box Not In Task(In Lesson Browser,Unit Preview or Lesson Preview)
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Instructional Message</returns>
        public static string VerifyInstructionalMessageInTaskNotesBoxNotInTask(AutomationAgent teachermodeAutomationAgent)
        {
            string InsMessage = teachermodeAutomationAgent.GetTextIn("TeacherModeView", "TaskNotesInstructionalMessageNotInTask", "Inside", "", 0, 0);
            InsMessage = InsMessage.Replace("\n\n", "");
            InsMessage = InsMessage.Replace("\t\n", "");
            return InsMessage;
        }
        /// <summary>
        /// Click On Canvas To AddNotes No tAt Task Level
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCanvasToAddNotesNotAtTaskLevel(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "TaskNotesInstructionalMessageNotInTask");
        }
        /// <summary>
        /// Open CommonRead In Teacher Mode
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void OpenCommonReadInTeacherMode(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "CommonReadInTeacherMode");
        }
        /// <summary>
        /// Verify CommonRead Page Open
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyCommonReadOpen(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "CommonReadPageInTeacherMode");
        }
        /// <summary>
        /// Verify Section Headers Moved To Left in Teacher Mode
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if moved to left), false(if not moved to left)</returns>
        public static bool VerifySectionHeadersMovedToLeft(AutomationAgent teachermodeAutomationAgent)
        {
            int xPos = Int32.Parse(teachermodeAutomationAgent.GetAllValues("TeacherModeView", "ExtendedModeSectionHeader", "x")[0]);
            int yPos = Int32.Parse(teachermodeAutomationAgent.GetAllValues("TeacherModeView", "ExtendedModeSectionHeader", "y")[0]);
            if (xPos < 45 && yPos < 350)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify Supporting Text Moved To Right in Teacher Mode
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if moved to right), false(if not moved to right)</returns>
        public static bool VerifySupportingTextMovedToRight(AutomationAgent teachermodeAutomationAgent)
        {
            int xPos = Int32.Parse(teachermodeAutomationAgent.GetAllValues("TeacherModeView", "ExtendedModeSupportingText", "x")[0]);
            int yPos = Int32.Parse(teachermodeAutomationAgent.GetAllValues("TeacherModeView", "ExtendedModeSupportingText", "y")[0]);
            if (xPos < 900 && yPos < 778)
                return true;
            else
                return false;
        }

        public static bool VerifyMinimizeIcon(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "MinimiseArrow");
        }

        public static bool VerifyExtendIcon(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ExpandArrow");
        }
        /// <summary>
        /// Gets the Text from the teacher Mode header
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text</returns>
        public static string GetTextFromTeacherModeHeader(AutomationAgent teachermodeAutomationAgent)
        {
            string s = teachermodeAutomationAgent.GetTextIn("TeacherModeView", "ExpandArrowBarViewInTeacherMode", "inside", "");
            return s.Replace("\t\n", "");
        }

        /// <summary>
        /// Click On MyClass Button
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickMyClassButton(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "MyClassButton");

        }
        /// <summary>
        /// Click MyTask Notes Button
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickMyTaskNotesButton(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "MyTaskNotesHeader");
        }
        /// <summary>
        /// Verify MyClass Area Appears
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyMyClassAreaAppers(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "MyclassArea");
        }

        public static bool VerifyLessonOverviewExpands(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies student ico in My class
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyStudentIconInMyClassArea(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "MyclassRosterStudentCell");
        }

        /// <summary>
        /// Clicks Student icon
        /// </summary>
        /// <param name="teachermodeAutomationAgent"></param>
        public static void ClickStudentIconInMyClass(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "MyclassRosterStudentCell");
        }
        /// <summary>
        /// Verifies student information label in roster
        /// </summary>
        /// <param name="teachermodeAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyStudentInformationRosterOpened(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformationLabel");
        }
        /// <summary>
        /// Verfies Lesson Overview Panel On Right
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyLessonOverviewPanelOnRight(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "LessonOverviewExpandButton");
        }
        /// <summary>
        /// Verfies Student information controls
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyStudentInformationControls(AutomationAgent teachermodeAutomationAgent)
        {
            if (teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformationLabel") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentFullName") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformationSchoolName") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformationGrade") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformationGender") &&
                teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformationDOB"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClickOnTeacherModeExpandArrowIcon(AutomationAgent teachermodeAutomationAgent)
        {
            //Mp To check
            teachermodeAutomationAgent.Click("TeacherModeView", "ExpandArrow");
        }
        /// <summary>
        /// Verify class roster is open
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyClassRosterOpened(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ClassRosterChromeTitle");
        }
        /// <summary>
        /// Click on student tile in Class Roster
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickStudentTileInClassRoster(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "OpenStudentTileClassRoster");
        }
        /// <summary>
        /// Click back button to close student information page
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackButtonStudentInformationPage(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "BackButton");
        }


        public static string GetTeacherGuideTitle(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.GetTextIn("LessonBrowserView", "TaskPageTitleInTeacherMode", "NATIVE", "Inside", "", 0, 0);
        }

        public static void NavigateThroughLessonsTask(AutomationAgent teachermodeAutomationAgent, int p)
        {
            teachermodeAutomationAgent.SwipeElement("LessonBrowserView", "LessonPreviewContentGrayed", Direction.Right, -100, 1000);
        }
        /// <summary>
        /// Click on Student Roster Image
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickStudentRosterImage(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "StudentRosterImage");
        }
        /// <summary>
        /// Verifies Student Roster Is open
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyStudentRosterOpen(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "StudentInformation");
        }
        /// <summary>
        /// Verify Previous Button Disabled For First Task
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyPreviousButtonDisabledForFirstTask(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep(2000);
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "Task1PreviousButtonDisabled");
        }
        /// <summary>
        /// Verify Last Button Disabled For First Task
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyLastButtonDisabledForFirstTask(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Sleep(2000);
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "LastTaskNextButtonDisabled");
        }
        /// <summary>
        /// Verifes No Content Notice
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyNoContentNotice(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "NoContentNotice");
        }
        /// <summary>
        /// Click on Teacher Mode Icon in Math to close teacher mode button
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeIconClose(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "MathTeacherModeClose");
        }

        public static void ClickOnTeacherModeNext(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("LessonBrowserView", "TeacherModeContentNext");
        }

        public static void ClickOnTeacherModePrevious(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("LessonBrowserView", "TeacherModeContentPrevious");
        }

        public static bool VerifyTeacherModeNext(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("LessonBrowserView", "TeacherModeContentNext");
        }

        public static bool VerifyTeacherModePrevious(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("LessonBrowserView", "TeacherModeContentPrevious");
        }
    }
}
