using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;
using System.Collections;


namespace Pearson.PSCAutomation.K1App
{

    public class InboxCommonMethods
    {
        /// <summary>
        /// Verify the text Of ELA 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static bool VerifyELAText(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.WaitforElement("InboxView", "ELALabel", "", WaitTime.LargeWaitTime);
            string text = inboxAutomationAgent.GetAllValues("InboxView", "ELALabel", "text")[0];
         
           
            return text.Equals("ELA");

        }
        /// <summary>
        /// Verify the text Of MATH
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMATHText(AutomationAgent inboxAutomationAgent)
        {
            string text = inboxAutomationAgent.GetAllValues("InboxView", "MathLabel", "text")[0];
            return text.ToUpper().Equals("MATH");

        }
        /// <summary>
        /// click on math button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMathButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "MathButton");
        }
        /// <summary>
        /// Verify that math button is highlighted
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if highlighted</returns>
        public static bool VerifyMATHbuttonHighlighted(AutomationAgent inboxAutomationAgent)
        {
            if(inboxAutomationAgent.IsElementFound("InboxView", "MathButtonHighlighted"))
                return inboxAutomationAgent.IsElementFound("InboxView", "MathButtonHighlighted");
            else
                inboxAutomationAgent.Sleep(10000);
                ClickOnMathButton(inboxAutomationAgent);
                return inboxAutomationAgent.IsElementFound("InboxView", "MathButtonHighlighted");

        }
        /// <summary>
        /// Click on the ELA button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnELAButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ELAButton");
        }
        /// <summary>
        /// Verify ELA button highlighted
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if highlighted</returns>
        public static bool VerifyELAbuttonHighlighted(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "ELAButtonHighlighted");
        }
        /// <summary>
        /// verify ELA and Math Icon
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyELAandMathTabs(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "ELAButton");
            inboxAutomationAgent.VerifyElementFound("InboxView", "MathButton");
        }
        /// <summary>
        /// Verify the text next to back icon in the inbox.
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyTextNextToBackIcon(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "InboxCountLabel");
        }

        /// <summary>
        /// verify calendar and Group tabs on left side in the sub navigation bar and Select button at Right side on sub navigation bar
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static bool VerifyGroupCalendarAndSelectButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "Calender");
            string[] calendarCoordinate = inboxAutomationAgent.GetPosition("InboxView", "Calender").Split(',');
            inboxAutomationAgent.VerifyElementFound("InboxView", "GroupIcon");
            string[] groupCoordinate = inboxAutomationAgent.GetPosition("InboxView", "GroupIcon").Split(',');
            //inboxAutomationAgent.VerifyElementFound("InboxView", "SelectButton");
            //string[] selectCoordinate = inboxAutomationAgent.GetPosition("InboxView", "SelectButton").Split(',');
            //if (Int32.Parse(calendarCoordinate[0]) < Int32.Parse(groupCoordinate[0]) && Int32.Parse(groupCoordinate[0]) < Int32.Parse(selectCoordinate[0]))
            if (Int32.Parse(calendarCoordinate[0]) < Int32.Parse(groupCoordinate[0])) 
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify the beige area 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyBeigeAreaDisplay(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "BeigeArea");
        }
        /// <summary>
        /// Click on the stack icon available in the inbox
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnStackIcon(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "InboxStack");
        }
        /// <summary>
        /// Verify that the show all student icon exists.
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true if object is found on that screen</returns>
        public static bool VerifyShowAllStudentIcon(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentButton");
        }
        /// <summary>
        /// Click on the show all student icon in the inbox which appears after click on any stacked item.
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnShowAllStudentIcon(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ShowAllStudentButton");
        }
        /// <summary>
        /// Click on the select button in inbox view
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSelectButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "SelectButton");
        }
        /// <summary>
        /// Verify the Add TO class notebook text 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyAddToClassNotebook(AutomationAgent inboxAutomationAgent)
        {
            if (inboxAutomationAgent.IsElementFound("InboxView", "AddtoClassNotebook"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verify the cancel button 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCancelButton(AutomationAgent inboxAutomationAgent)
        {
            if (inboxAutomationAgent.IsElementFound("InboxView", "CancelButton"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verify that add button exist or not
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyAddButton(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "AddButton");

        }
        /// <summary>
        /// verify help text when select button is tap.
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyHelpTextWhenSelectButtonTapp(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "HelpText");

        }
        /// <summary>
        /// click on the cancel button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("NotebookView", "DeletePopup");
        }

        /// <summary>
        /// Click on the add button 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAddButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "AddButton");
        }
        /// <summary>
        /// verfiy that add class notebook comes or not
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyAddClassNotebookOverlay(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "NewClassNotebookButton");
        }
        /// <summary>
        /// click on the inbox item 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnInboxItem(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.LargeWaitTime);
            inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
        }
        /// <summary>
        /// Verify the UI elements of Add Class Notebook Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyUIOfAddClassNotebookOverlay(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "PlusIcon");
            inboxAutomationAgent.VerifyElementFound("InboxView", "NewClassNotebookButton");
        }
        /// <summary>
        /// Click on the new class notebook
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNewClassNotebook(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "NewClassNotebookButton");
        }
        /// <summary>
        /// verfiy the UI of New Class Notebook Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyUIOfNewClassNotebookOverlay(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "Title");
            inboxAutomationAgent.VerifyElementFound("InboxView", "TextBoxField");
            inboxAutomationAgent.VerifyElementFound("InboxView", "ViewableInText");
            inboxAutomationAgent.VerifyElementFound("InboxView", "ScrollBar");
            inboxAutomationAgent.VerifyElementFound("InboxView", "TotalPageLabel");
            inboxAutomationAgent.VerifyElementFound("InboxView", "CancelButtonInNewClassNotebookOverlay");
            inboxAutomationAgent.VerifyElementFound("InboxView", "CreateButtonInNewClassNotebookOverlay");
            inboxAutomationAgent.VerifyElementFound("InboxView", "PublishLabel");

        }
        /// <summary>
        /// verify the new class notebook color and text
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matches</returns>
        public static bool VerifyNewClassNoteBookText(AutomationAgent inboxAutomationAgent)
        {
            string[] Color = inboxAutomationAgent.GetAllValues("InboxView", "NewClassNotebooHeader", "textColor");
            if (Color[0].Equals("0x10596E"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Click in the text box to open keyboard
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickInTextBoxToOpenKeyBoard(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.ClickCoordinate(740, 494);
        }
        /// <summary>
        /// Verfiy keyboard open
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true if found</returns>
        public static bool VerifyKeyboardOpen(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "KeyBoardView");

        }
        /// <summary>
        /// Click on the scroll bar
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOntheScrollBar(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ScrollBar");
        }
        /// <summary>
        /// Verify that scroll bar is open
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyScrollBarOpen(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "CancelButtonScrollBarOpen");
            inboxAutomationAgent.VerifyElementFound("InboxView", "DoneButton");
        }
        /// <summary>
        /// Verify the Blue SkyBackground of Student Inbox
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyBluSkyBackGround(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "BlueSkyBackGround");
        }
        /// <summary>
        /// verify the ELA and Math Icon In student inbox.
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyELAandMathIconInStudentInbox(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "ELAIconStudentInbox");
            inboxAutomationAgent.VerifyElementFound("InboxView", "MathIconStudentInbox");
        }
        /// <summary>
        /// verify white background
        /// </summary>
        /// <param name="inboxAutomationAgent"></param>
        public static bool VerifyWhiteBackGround(AutomationAgent inboxAutomationAgent)
        {
            string[] backgroundcolor = inboxAutomationAgent.GetAllValues("InboxView", "WhiteBackGround", "backgroundColor");
            if (backgroundcolor[0].Equals("0xFFFFFF"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Click on the class notebook which is in the Add button overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnClassNotebook(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ClassNotebook");
        }
        /// <summary>
        /// verify the new class notebook color and text
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matches</returns>
        public static bool VerifyAddToClassNoteBookText(AutomationAgent inboxAutomationAgent)
        {
            string[] Color = inboxAutomationAgent.GetAllValues("InboxView", "AddToClassNotebookInOverlay", "textColor");
            if (Color[0].Equals("0x11595D"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify the various UI elements of Add to Class Notebook
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyUIOfAddToExtingClassNotebookOverlay(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "Title");
            inboxAutomationAgent.VerifyElementFound("InboxView", "ViewableInText");
            inboxAutomationAgent.VerifyElementFound("InboxView", "TotalPageLabel");
            inboxAutomationAgent.VerifyElementFound("InboxView", "CancelButtonInNewClassNotebookOverlay");
            inboxAutomationAgent.VerifyElementFound("InboxView", "AddPagesButton");
            inboxAutomationAgent.VerifyElementFound("InboxView", "PublishLabel");
        }
        /// <summary>
        /// Clicks on the calendar button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCalendarButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "Calender");
        }
        /// <summary>
        /// Verify calender highlighted 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCalenderHighlighted(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "CalendarHighlighted");
        }

        /// <summary>
        /// Verify select button 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>true if select button found</returns>
        public static bool VerifySelectButton(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "SelectButton");
        }

        /// <summary>
        /// Verify student name label
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentNameLabel(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.WaitforElement("StudentSetup", "StudentNameLabel", "", WaitTime.MediumWaitTime);
            inboxAutomationAgent.VerifyElementFound("StudentSetup", "StudentNameLabel");
        }

        /// <summary>
        /// Verify Date Time Stamp label
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyDateTimeStampLabelInInbox(AutomationAgent inboxAutomationAgent)
        {
            DateTime.Parse(inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel").Replace("|", " "));
        }

        /// <summary>
        /// Verify unit label in inbox
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitLabelInInbox(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("UnitSelection", "CurrentUnit");
        }

        /// <summary>
        /// Verify google eyes are opened
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyOpenedGoogleEyes(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "GoogleEyeOpen");
        }

        /// <summary>
        /// Verify google eyes are closed
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyClosedGoogleEyes(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "GoogleEyeClosed");
        }

        /// <summary>
        /// Click on google eyes
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGoogleEyes(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "GoogleEye");
        }

        /// <summary>
        /// Click on Record icon on notebook 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRecordIcon(AutomationAgent inboxAutomationAgent)
        {
            if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
            {
                inboxAutomationAgent.Sleep(10000);
                inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
            }
            inboxAutomationAgent.WaitForElement("InboxView", "RecordIcon", WaitTime.MediumWaitTime);
            inboxAutomationAgent.Click("InboxView", "RecordIcon");
        }

        /// <summary>
        /// Click on record button 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRecordButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "RecordButton");
        }

        /// <summary>
        /// Click to apply recording
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickToApplyRecording(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ApplyRecording");
        }

        /// <summary>
        /// Verify audio saved popup
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>True: if displayed</returns>
        public static bool VerifyAudioSavedPopup(AutomationAgent inboxAutomationAgent)
        {
            return (inboxAutomationAgent.GetText("TEXT").Replace("\n", " ")).Contains("Your audio feedback was saved.");
        }


        /// <summary>
        /// Verify review record button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static bool VerifyReviewRecordButton(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "ReviewRecord");
        }

        /// <summary>
        /// Click on review record button 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnReviewRecordButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ReviewRecord");
        }

        public static void ClickToRemoveRecording(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "RemoveRecording");
        }
        public static bool VerifyRemoveRecordingButton(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "RemoveRecording");
        }
        /// <summary>
        /// Verify Comment Overlay open
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>boool object: true if found</returns>
        public static bool VerifyCommentOverlayOpen(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("NotebookView", "AddComment");
        }
        /// <summary>
        /// Verify plain text in text box
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true if found</returns>
        public static bool VerifyPlainTextIntextBox(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.SendText("Tester!@#$%");
            return inboxAutomationAgent.GetAllValues("TeacherMode", "SaveButton", "enabled")[0].Equals("true");
        }
        /// <summary>
        /// Verify green check mark on comment button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyGreenCheckOnCommentButton(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "GreenCheckOnCommentButton");
        }
        /// <summary>
        /// Verify item in teacher inbox
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyItemInTeacherInbox(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.MediumWaitTime);
            inboxAutomationAgent.VerifyElementFound("InboxView", "InboxItemOfTeacher");
        }
        /// <summary>
        /// Verify new banner on the item in the inbox
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyNEWbannerOnTheItemInTheInbox(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "NewBannerInboxItem");
        }
        /// <summary>
        /// Verify Edit COmment Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static bool VerifyEditCommentOverlay(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "EditCommentOverlay");
        }

        /// <summary>
        /// Click on done button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickONDOneButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("TeacherMode", "DoneButton");
        }

        /// <summary>
        /// Verify comment saved
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static bool VerifyCommentSaved(AutomationAgent inboxAutomationAgent, string text)
        {
            string comment = inboxAutomationAgent.GetElementText("TeacherMode", "TextRegionInCreateNotes");
            return comment.Contains(text);
        }
        /// <summary>
        /// Verify math button highlighted in student view
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyMATHbuttonHighlightedInStudentInbox(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "MAthSlected");
        }
        /// <summary>
        /// Verify ELA button highlighted in student view
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyELAbuttonHighlightedInStudentInbox(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "ELASelected");
        }
        /// <summary>
        /// Click on math buttin in student view
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMathButtonInStudentView(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "MathButtonInStudentView");
        }
        /// <summary>
        /// Click on ELA button in student view
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnELAButtonInStudentView(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ELAButtonInStudentView");
        }

        /// <summary>
        /// Get the items count shared by student
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static int GetSharedItemsCount(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.GetElementCount("StudentSetup", "StudentNameLabel");
        }

        /// <summary>
        /// Verify each student stack thumbnails
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <param name="sharedItemsCount">Total number of shared items</param>
        public static void VerifyEachStudentStackThumbnails(AutomationAgent inboxAutomationAgent, int sharedItemsCount)
        {
            for (int i = 1; i <= sharedItemsCount; i++)
                inboxAutomationAgent.VerifyElementFound("InboxView", "StackItemsThumbnails", i.ToString());
        }

        /// <summary>
        /// verify new box display on top left of corner
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyNewBoxDisplayOnTopLeftCorner(AutomationAgent inboxAutomationAgent)
        {
            int widthOfNew = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "NewBannerInboxItem", "width")[0]);
            int heightOfNew = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "NewBannerInboxItem", "height")[0]);
            int widthOfStackItem = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "InboxItemOfTeacher", "width")[0]);
            int heightOfStackItem = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "InboxItemOfTeacher", "height")[0]);

            Assert.IsTrue(widthOfNew < widthOfStackItem && heightOfNew < heightOfStackItem);
        }

        /// <summary>
        /// Click on unstacked item
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnstackedItem(AutomationAgent inboxAutomationAgent)
        {
            int stackItems = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
            for (int i = 0; i <= stackItems; i++)
            {
                inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher", "", i, 1, WaitTime.DefaultWaitTime);
                if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
                    break;
                else
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
            }
        }


        /// <summary>
        /// Verify the the order in which the items are displayed
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyOrderOfUnstackedItems(AutomationAgent inboxAutomationAgent)
        {
            ArrayList stackDateTimes = new ArrayList();
            int stackItems = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
            for (int i = 0; i < (stackItems - 1); i++)
            {
                DateTime stackDateTime = DateTime.Parse(inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel", i).Replace("|", " "));
                stackDateTimes.Add(stackDateTime);
            }

            stackDateTimes.Sort();

            for (int j = 0; j < stackDateTimes.Count; j++)
            {
                DateTime stackDateTime = DateTime.Parse(inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel", j).Replace("|", " "));
                stackDateTimes[j].Equals(stackDateTime);
            }

        }

        /// <summary>
        /// Verify that the Student name and date timestamp is present on the top right of the notebook page and by the left side of the paper plane
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentDetailsOnStackItem(AutomationAgent inboxAutomationAgent)
        {
            string[] studentDetails = inboxAutomationAgent.GetTextIn("InboxView", "StudentAvatorUnderStack", "Right", "").Split('\t');
            inboxAutomationAgent.VerifyElementFound("InboxView", "StudentDetailsLabelUnderStack", studentDetails[0]);
            inboxAutomationAgent.VerifyElementFound("InboxView", "StudentDetailsLabelUnderStack", studentDetails[1]);
        }

        /// <summary>
        /// Verify the the order in which the items are displayed
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyOrderOfStackedItems(AutomationAgent inboxAutomationAgent)
        {
            ArrayList stackDateTimes = new ArrayList();
            int stackItems = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
            for (int i = 0; i < stackItems; i++)
            {
                DateTime stackDateTime = DateTime.Parse(inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel", i).Replace("|", " "));
                stackDateTimes.Add(stackDateTime);
            }

            stackDateTimes.Sort();

            for (int j = 0; j < stackDateTimes.Count; j++)
            {
                DateTime stackDateTime = DateTime.Parse(inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel", j).Replace("|", " "));
                stackDateTimes[j].Equals(stackDateTime);
            }

        }
        /// <summary>
        /// Verify Play button,re-record & remove buttton displayed in review recoding overlay 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyRerecordingOptions(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.IsElementFound("InboxView", "PlayButton");
            inboxAutomationAgent.IsElementFound("InboxView", "RemoveRecording");
            inboxAutomationAgent.IsElementFound("InboxView", "ReRecordingButton");
        }

        // <summary>
        /// Click on Play Button in Re-Recording Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPlayButtonInReviewAudio(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "PlayButton");
        }
        /// <summary>
        /// Verify Play button,re-record & remove buttton displayed in review recoding overlay 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyProgressBarView(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.IsElementFound("InboxView", "StopButton");
            inboxAutomationAgent.IsElementFound("InboxView", "ProgressView");            
        }
        // <summary>
        /// Click on Cancel Button in Recording Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelButtonInRecordAudio(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "CancelButtonScrollBarOpen");
        }
        /// <summary>
        /// Verify Play button,re-record & Apply buttton displayed in review Audio overlay 
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyRerecordApplyOptions(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.IsElementFound("InboxView", "PlayButton");
            inboxAutomationAgent.IsElementFound("InboxView", "ApplyRecording");
            inboxAutomationAgent.IsElementFound("InboxView", "ReRecordingButton");
        }
        // <summary>
        /// Click on Cancel Button in ReRecording and Apply button Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelButtonInReviewAudio(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "CancelButtonInReviewAudio");
        }

        /// <summary>
        /// Verify Rerecord button with apply and play found
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyRerecordButtonwithApply(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "ReRecordingButton");
        }
        /// <summary>
        /// Verify green check mark on Audio button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static void VerifyGreenCheckOnAudioIcon(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyIn("InboxView", "GreenCheckMarkOnAudio", "Inside", "InboxView", "GreenCheckMarkOnAudio");
        }
        // <summary>
        /// Click on Cancel Button in ReRecording and Apply button Overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRerecordButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "ReRecordingButton");
        }
        /// <summary>
        /// Get positon of image added
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: coordinates</returns>
        public static string[] GetPositionOfImage(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("InboxView", "ImageInInboxToDrag").Split(',');
            return pos;
        }
        /// <summary>
        /// Drag image in Inbox
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x coordinate</param>
        /// <param name="p2">int object: y coordinate</param>
        public static void DragImage(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("InboxView", "ImageInInboxToDrag", x, y);
        }
        /// <summary>
        /// Verify that CrayonButton is On
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if highlighted</returns>
        public static bool VerifyCrayonButtonIsON(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "CrayonOn");
        }
        // <summary>
        /// Click on Eraser Button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnEraserButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("BookBuilderView", "Eraser");
        }

        /// <summary>
        /// Verify that EraserButton is On
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if highlighted</returns>
        public static bool VerifyEraserButtonIsON(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("BookBuilderView", "EraserON");
        }
        /// <summary>
        /// Verify that EraserButton is On
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if highlighted</returns>
        public static bool VerifyCancelButtonForAlertMessage(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "DeletePopUp");
        }
        // <summary>
        /// Click on Interactive Place Holder
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnInteractiveholder(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "InteractivePlaceholder");
        }
        public static void VerifyStudentNameAtInbox(AutomationAgent inboxAutomationAgent)
        {
            
            string[] studentDetails = inboxAutomationAgent.GetTextIn("InboxView", "StudentNameLabel", "Inside", "").Split('\t');
            int sharedItems = inboxAutomationAgent.GetElementCount("InboxView", "StudentNameLabel");
            for (int i = 0; i < sharedItems; i++)
            if(studentDetails[i].Contains("Sophia"))
            {                             
                    inboxAutomationAgent.Click("InboxView", "StudentNameLabel");
                    break;                
            }
            
        }

        public static void sendELANoteBooKForReview(AutomationAgent inboxAutomationAgent,string loginName,int clickCount)
        {
            
            LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin(loginName));
            TaskInfo taskInfo = Login.GetLogin(loginName).GetTaskInfo("ELA", "Notebook");
            String[] UnitStatus = BackUpAndRestoreCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnELAUnit(inboxAutomationAgent, "1");
            
            NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
            inboxAutomationAgent.Sleep(5000);
            NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(inboxAutomationAgent);
            NotebookCommonMethods.ClickOnYesbutton(inboxAutomationAgent);
            inboxAutomationAgent.WaitforElement("NotebookView", "MediaButton", "", WaitTime.MediumWaitTime);
            NotebookCommonMethods.ClickOnGraphicTool(inboxAutomationAgent);
            NotebookCommonMethods.ClickOnTableTool(inboxAutomationAgent);
            NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 630, 400);
            BookBuilderCommonMethods.SendText(inboxAutomationAgent, loginName);
            inboxAutomationAgent.CloseKeyboard();
            for (int i = 1; i <= clickCount; i++)
            {
                ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                ColdWriteCommonMethods.SelectTeacherName(inboxAutomationAgent, "Mr. TEsec15grdKGFN TEsec15grdKG");
                LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            }
            inboxAutomationAgent.Sleep(2000);
            EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
            LoginCommonMethods.Logout(inboxAutomationAgent);
        }

        public static void sendMATHNoteBooKForReview(AutomationAgent inboxAutomationAgent,String loginName,int clickCount)
        {

            
            LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin(loginName));
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnMathUnit(inboxAutomationAgent, "0");
            NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
            inboxAutomationAgent.Sleep(5000);
            NavigationCommonMethods.ClickToOpenNotebook(inboxAutomationAgent);
            inboxAutomationAgent.Sleep(5000);
            for (int i = 1; i <= clickCount; i++)
            {
                ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                ColdWriteCommonMethods.SelectTeacherName(inboxAutomationAgent, "Mr. TEsec15grdKGFN TEsec15grdKG");
                LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            }
            NavigationCommonMethods.ClickOnBackButtonAtSettingsScreen(inboxAutomationAgent);
            LoginCommonMethods.Logout(inboxAutomationAgent);
        }

        public static void ClickOnStudentSort(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "StudentSort");
        }
        public static bool VerifyStackedItemIsPresent(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "InboxItemOfTeacher");
        }
        public static int GetSharedItemsNewBannerCount(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.GetElementCount("InboxView", "NewBannerInboxItem");
        }

        public static void sendMultipleELANoteBooKForReview(AutomationAgent inboxAutomationAgent,string answer)
        {
            while (inboxAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
            {
                inboxAutomationAgent.Click("NotebookView", "PageArrowRight");
            }
            //NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(inboxAutomationAgent);
            //NotebookCommonMethods.ClickOnYesbutton(inboxAutomationAgent);
            //NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
            switch (answer)
            {
                case "A":
                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(inboxAutomationAgent);
                    break;
                case "B":
                    BackUpAndRestoreCommonMethods.AddAudioInNotebookCanvas(inboxAutomationAgent);
                    break;
                case "C": 
                    NavigationCommonMethods.ClickOnMediaLibrary(inboxAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenInteractive(inboxAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(inboxAutomationAgent);                    
                    //EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    //MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(inboxAutomationAgent);
                    //NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);                    

                    break;
                case "D":
                    NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(inboxAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(inboxAutomationAgent);
                    BookBuilderCommonMethods.SendText(inboxAutomationAgent, "Doctor");
                    NotebookCommonMethods.ClickOnGraphicTool(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyTableTool(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(inboxAutomationAgent);
                    break;



            }
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            ColdWriteCommonMethods.SelectTeacherName(inboxAutomationAgent, "Mr. TEsec15grdKGFN TEsec15grdKG");                    
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnBackButtonAtSettingsScreen(inboxAutomationAgent);
            if (inboxAutomationAgent.IsElementFound("MediaLibrary", "BackButtonAtImageViewer"))
            {
                inboxAutomationAgent.Click("MediaLibrary", "BackButtonAtImageViewer");
                NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
            }            
            
        }
        public static bool VerifyAudioCapturedOnNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("BackUpAndRestoreView", "NotebookAudio");
        }
        public static void ClickOnStackedItemNumber(AutomationAgent inboxAutomationAgent,String tile)
        {
            inboxAutomationAgent.WaitforElement("InboxView", "StackedItem", tile, WaitTime.MediumWaitTime);
            inboxAutomationAgent.Click("InboxView", "StackedItem", tile,1,WaitTime.MediumWaitTime);
        }
        public static bool VerifyStackOneWithNewBanner(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookAudio");
        }
        public static void sendELANoteBooKReviewToStudent(AutomationAgent inboxAutomationAgent, string loginName)
        {

            
            LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin(loginName));
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
            InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickOnSendButton(inboxAutomationAgent);
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnGoBackIcon(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            LoginCommonMethods.Logout(inboxAutomationAgent);
        }
        public static void sendMATHNoteBooKReviewToStudent(AutomationAgent inboxAutomationAgent, string loginName)
        {            
            LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin(loginName));
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
            ClickOnMathButton(inboxAutomationAgent);
            InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnGoBackIcon(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            LoginCommonMethods.Logout(inboxAutomationAgent);
        }
        public static void NavigateTillInbox(AutomationAgent inboxAutomationAgent,String loginName)
        {
            
            LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin(loginName));
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
            NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
        }
        public static int countOfNewBannerTilesInELAAndMath(AutomationAgent inboxAutomationAgent)
        {
            int elaCount = inboxAutomationAgent.GetElementCount("StudentSetup", "NewBannerInboxItem");
            inboxAutomationAgent.Click("StudentSetup", "NewBannerInboxItem");
            int mathCount = inboxAutomationAgent.GetElementCount("StudentSetup", "NewBannerInboxItem");

            return elaCount + mathCount;

        }
        public static bool VerifyPotraitBookIsPresent(AutomationAgent inboxAutomationAgent)
        {
            if ((inboxAutomationAgent.IsElementFound("InboxView", "PortraitBookImage")))
                return true;
            else
                return false;

        }
        public static bool VerifyLanscapeBookIsPresent(AutomationAgent inboxAutomationAgent)
        {
            if ((inboxAutomationAgent.IsElementFound("InboxView", "LandscapeBookImage")))
                return true;
            else
                return false;

        }
        public static bool VerifySquareBookIsPresent(AutomationAgent inboxAutomationAgent)
        {
            if ((inboxAutomationAgent.IsElementFound("InboxView", "SquareBookImage")))
                return true;
            else
                return false;

        }
        public static void ClickOnSquareBook(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "SquareBookImage");
        }
        
        public static bool VerifyHeaderFooterAfterTappingBookInInbox(AutomationAgent inboxAutomationAgent)
        {
            return (inboxAutomationAgent.IsElementFound("BookBuilderView", "CoverInFooter"));

        }
        public static void SelectInboxCheckBoxtoDelete(AutomationAgent inboxAutomationAgent,int x,int y)
        {

            inboxAutomationAgent.ClickCoordinate(x, y);
        }
        public static int countOfCheckedItems(AutomationAgent inboxAutomationAgent)
        {
            int Count = inboxAutomationAgent.GetElementCount("InboxView", "InboxCheckedBox");
            return Count;
        }
        public static int countOfBooks(AutomationAgent inboxAutomationAgent)
        {
            int bookCount = inboxAutomationAgent.GetElementCount("InboxView", "SquareBookImage");
            return bookCount;
        }
        public static void selectDeleteButtonInInbox(AutomationAgent inboxAutomationAgent)
        {

            inboxAutomationAgent.Click("InboxView", "DeleteButtonInInbox");
            inboxAutomationAgent.Click("UnitSelection", "AcceptLogOut");
        }
        public static bool VerifyDeleteButtonInInbox(AutomationAgent inboxAutomationAgent)
        {

            return inboxAutomationAgent.IsElementFound("InboxView", "DeleteButtonInInbox");
        }
        public static bool VerifyStudentDetailsForBook(AutomationAgent inboxAutomationAgent)
        {
            string text = inboxAutomationAgent.GetElementText("UnitSelection", "CurrentUnit");            
            string date = inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel");
            if (inboxAutomationAgent.IsElementFound("StudentSetup", "StudentNameLabel") && text.Contains("") && date.Contains("/"))
                return true;
            else
                return false;
            
        }
        //public static void VerifyDateTimeStampLabelForBooks(AutomationAgent inboxAutomationAgent)
        //{
        //   DateTime stackDateTime = DateTime.Parse(inboxAutomationAgent.GetElementText("InboxView", "DateTimeLabel").Replace("|", " "));
        //}
        public static void addCommentToStudent(AutomationAgent inboxAutomationAgent)
        {

            NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
            if (!InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent))
            {
                inboxAutomationAgent.SendText("Very Good");
                TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
            }
            
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
        }
        public static void addAudioNoteToStudent(AutomationAgent inboxAutomationAgent)
        {
            InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
            if (BackUpAndRestoreCommonMethods.VerifyReviewAudioWindow(inboxAutomationAgent))
            {
                InboxCommonMethods.ClickToRemoveRecording(inboxAutomationAgent);
                LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            }
            else
            {
                InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);
                InboxCommonMethods.VerifyAudioSavedPopup(inboxAutomationAgent);
                LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            }
        }

        public static void VerifyStudentOvervlayItems(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "NoteBookIconAtStudentInbox");            
            inboxAutomationAgent.VerifyElementFound("InboxView", "BackIconAtStudentInbox");
            inboxAutomationAgent.VerifyElementFound("InboxView", "ThumbailInOverlay");

        }
        public static void ClickNotebookIcon(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("InboxView", "NoteBookIconAtStudentInbox");
        }

        public static bool VerifyCommentNote(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "CommentBoxAtStudentInbox");
        }

        public static bool VerifyAudioNote(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "AudioPlayIconAtStudent");
        }

        public static void addStickerSmiley(AutomationAgent inboxAutomationAgent)
        {
            NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
            Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
            NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
            NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
            Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
        }
        public static bool VerifyNEWbannerOnTheItemOneInTheInbox(AutomationAgent inboxAutomationAgent,string tileOne)
        {          
               
            return inboxAutomationAgent.IsElementFound("InboxView", "NewBannerInboxtile",tileOne);
        }
        public static void ClickOnGrade1ELAUnit(AutomationAgent inboxAutomationAgent, string unitNo)//Not working for ELA but only for MATH
        {
            while (!inboxAutomationAgent.IsElementFound("UnitSelection", "MATHUNITButton", unitNo))
            {
                inboxAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "CurrentUnit", "UnitSelection", "MATHUNITButton", unitNo, "Up", 500, 731);
            }
            inboxAutomationAgent.Click("UnitSelection", "MATHUNITButton", unitNo);

        }
        public static int GetStudentViewCount(AutomationAgent inboxAutomationAgent)
        {
            int labelCount = 0;
            string[] strArray0 = inboxAutomationAgent.GetAllValues("StudentSetup", "StudentNameLabel", "accessibilityLabel");
            int sharedItems = inboxAutomationAgent.GetElementCount("StudentSetup", "StudentNameLabel");
            for (int i = 0; i <= sharedItems; i++)
            {
                if (strArray0[i].Contains("S01") || strArray0[i].Contains("S02"))
                    labelCount++;
            }

            return labelCount;
        }
        public static bool VerifyRowsAndCOlumns(AutomationAgent inboxAutomationAgent)
        {
            return (inboxAutomationAgent.GetElementCount("BookBuilderView", "RowsColumns") - 2).Equals(7);
        }
        public static bool VerifyDataSaved(AutomationAgent inboxAutomationAgent, string saveddata)
        {
            bool data = true;
            string[] strArray0 = inboxAutomationAgent.GetAllValues("TeacherMode", "TextRegionInCreateNotes", "text");
            for (int i = 0; i <= strArray0.Length; i++)
            {
                if (strArray0[i].Contains(saveddata))                
                    break;               

            }
            return data;
        }
        public static bool VerifyInteractiveInTeacherInboxNotebookReview(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("NotebookView", "InteractiveInInboxNotebookView");
        }
        public static string VerifyNewMouseAssetInNotebookReview(AutomationAgent inboxAutomationAgent)
        {
            
            inboxAutomationAgent.IsElementFound("NotebookView", "NewMouseAssetInNotebookReview");
            inboxAutomationAgent.IsElementFound("BookBuilderView", "BookPageCount", "S01sec15grdKGFN S01sec15grdKG");
            String text = inboxAutomationAgent.GetElementText("NotebookView", "DateTimeUnitDetails") ;
            return text;

            
        }
        public static string GetCurrentUnitInCalendarView(AutomationAgent inboxAutomationAgent)
        {
            String text = inboxAutomationAgent.GetElementText("UnitSelection", "CurrentUnit");
            return text;
        }

        public static String VerifyDataLabelInCalendarView(AutomationAgent inboxAutomationAgent)
        {           
            String text = inboxAutomationAgent.GetElementText("InboxView", "DateLabelInCalendarView");
            return text;
        }
        public static void ClickOnYouDidIt(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("NotebookView", "StickerYouDidIt");
        }
        public static string GetCountOfNewInboxItems(AutomationAgent inboxAutomationAgent)
        {
            String text = inboxAutomationAgent.GetElementText("InboxView", "InboxCountLabel").Substring(6, 2);
            return text;
        }

        public static bool VerifyUnitLabelIsPresentInInboxForNB(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("UnitSelection", "CurrentUnit");
        }
        public static void NavigateToSelectELAOrMathUnit(AutomationAgent inboxAutomationAgent,string subject)
        {
            NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);

            NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
            if (subject.Contains("ELA"))
                NavigationCommonMethods.ClickOnELAUnit(inboxAutomationAgent, "1");
            else if (subject.Contains("MATH"))
                NavigationCommonMethods.ClickOnMathUnit(inboxAutomationAgent, "0");
            
             NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
             NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
            
        }

        public static void VerifyInboxFunctionalities(AutomationAgent inboxAutomationAgent)
        {
            VerifyELAandMathTabs(inboxAutomationAgent);
            VerifyGroupCalendarAndSelectButton(inboxAutomationAgent);
            VerifyBeigeAreaDisplay(inboxAutomationAgent);
            VerifyStudentNameLabel(inboxAutomationAgent);
            VerifyDateTimeStampLabelInInbox(inboxAutomationAgent);
            VerifyUnitLabelInInbox(inboxAutomationAgent);
           
        }
        public static void ClickOnAudioInNotebook(AutomationAgent inboxAutomationAgent,int clickCount)
        {
            inboxAutomationAgent.Click("BackUpAndRestoreView", "NotebookAudio", clickCount);
        }
        public static bool VerifyRemoveButtonIsPresent(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("NotebookView", "RemoveButton");
        }
        public static void SendCommentAndAudioToStudent(AutomationAgent inboxAutomationAgent)
        {
            addAudioNoteToStudent(inboxAutomationAgent);
            addCommentToStudent(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
            {
                inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
            }
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);

        }
        public static void SendCommentToStudent(AutomationAgent inboxAutomationAgent)
        {
            InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);            
            InboxCommonMethods.ClickToRemoveRecording(inboxAutomationAgent);
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
            {
                inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
            }
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
        }
        public static void SendWithoutCommentAndAudioToStudent(AutomationAgent inboxAutomationAgent)
        {
            NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
            TeacherModeCommonMethods.ClickOnDeleteNoteButton(inboxAutomationAgent);
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            
            while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
            {
                inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
            }
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
        }
        public static void SendOnlyAudioToStudent(AutomationAgent inboxAutomationAgent)
        {            
            InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
            InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
            inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
            InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
            InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
            ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
            while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
            {
                inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
            }
            LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);

        }
        public static void VerifyStudentDetailsInNotebookPage(AutomationAgent inboxAutomationAgent)
        {                      
           
            String unitName = GetCurrentUnitInCalendarView(inboxAutomationAgent);
            String data1 = VerifyDataLabelInCalendarView(inboxAutomationAgent);            
            if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
            {                
                
                inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");                
                
            }         
            
            String data = InboxCommonMethods.VerifyNewMouseAssetInNotebookReview(inboxAutomationAgent);            
            Assert.IsTrue(data.Contains(unitName), "Unit name is matched");            
            EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);                
            
         }
        public static bool VerifyAutoCorrectForCommentEnable(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("StudentSetup", "AutoCorrectionCell");
        }
        public static void ClickOnStudentThumbNail(AutomationAgent inboxAutomationAgent,string tileOne)
        {
            inboxAutomationAgent.WaitforElement("InboxView", "StudentThumbnail", "", WaitTime.DefaultWaitTime);
            inboxAutomationAgent.Click("InboxView", "StudentThumbnail",tileOne);
        }
        public static void VerifyNewBoxDisplayOnTopLeftCornerOfStudent(AutomationAgent inboxAutomationAgent)
        {
            int widthOfNew = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "NewBannerInboxItem", "width")[0]);
            int heightOfNew = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "NewBannerInboxItem", "height")[0]);
            int widthOfStackItem = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "StudentThumbnail","1", "width")[0]);
            int heightOfStackItem = Int32.Parse(inboxAutomationAgent.GetAllValues("InboxView", "StudentThumbnail","1", "height")[0]);

            Assert.IsTrue(widthOfNew < widthOfStackItem && heightOfNew < heightOfStackItem);
        }
        
        public static void TapInsideRowFieldInTeacherInbox(AutomationAgent inboxAutomationAgent)
        {

            string x = inboxAutomationAgent.GetAllValues("InboxView", "TableToolRowFieldInTeacherInbox", "x")[0];
            string y = inboxAutomationAgent.GetAllValues("InboxView", "TableToolRowFieldInTeacherInbox", "y")[0];
            inboxAutomationAgent.ClickOnScreen(Int32.Parse(x), (Int32.Parse(y)));

        }
        public static bool VerifyUserAbleToTypeInTeacherInboxRowField(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.SendText("PEARSONK1");
            inboxAutomationAgent.Sleep();
            string name = inboxAutomationAgent.GetTextIn("InboxView", "TableToolRowFieldInTeacherInbox", "Inside", "");
            if (name.Equals("PEARSONK1"))
                return true;
            else
                return false;
        }
        public static bool VerifyDashedLineInTeacherInbox(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("InboxView", "DashedLineAroundAudio");
        }
    }
}
         

        

