using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;

namespace Pearson.PSCAutomation._212App
{
    public static class NotebookCommonMethods
    {
        /// <summary>
        /// Opens notebook using task top menu
        /// Clicks on Notebook icon in task top menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNotebookIcon(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "NotebookIcon");
            notebookAutomationAgent.Sleep();
            if (VerifyNotebookNotOpen(notebookAutomationAgent))
            {
                notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "ChooseNotebook", "", WaitTime.LargeWaitTime);
                if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
                {
                    SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
                }
                else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
                {
                    SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
                }
            }
        }

        public static void SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "OnIpadNotebook", "", WaitTime.LargeWaitTime);
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "OnIpadNotebook"))
            {
                notebookAutomationAgent.Click("ConflictResolutionPopUp", "OnIpadNotebook");
                notebookAutomationAgent.Click("ConflictResolutionPopUp", "ContinueButton");
            }
            else
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }

        public static void SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "OnCloudNotebook", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.Click("ConflictResolutionPopUp", "OnCloudNotebook");
            while (!notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "DownloadCheckMark"))
            {
                notebookAutomationAgent.Sleep(WaitTime.MediumWaitTime);
            }
            notebookAutomationAgent.Click("ConflictResolutionPopUp", "ContinueButton");
        }
        /// <summary>
        /// Adds new page to the notebook
        /// Clicks on (+) icon on notebook top menu for adding a new page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void AddNewNotebookPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookTopMenuView", "AddNewPage", "", WaitTime.MediumWaitTime);
            notebookAutomationAgent.Click("NotebookTopMenuView", "AddNewPage");
            notebookAutomationAgent.Sleep(4000);
        }

        /// <summary>
        /// Moves to prevoius page in notebook
        /// Clicks on left arrow icon on notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickLeftArrowIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "LeftArrow");
            notebookAutomationAgent.Sleep();
        }

        /// <summary>
        /// Moves to next page in notebook
        /// Clicks on right arrow icon on notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickRightArrowIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "RightArrow");
        }

        /// <summary>
        /// Deletes latest opened page from notebook
        /// 1. Clicks on delete icon in bottom menu
        /// 2. Clicks continue of confirmation dialog 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DeleteNotebookPage(AutomationAgent notebookAutomationAgent)
        {

            while (GetNotebookPage(notebookAutomationAgent) != 1)
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "DeleteIcon");
                if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ContinueLabel"))
                {
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "ContinueLabel");
                    notebookAutomationAgent.Sleep();
                }
            }

        }

        /// <summary>
        /// Verifies if current page is first page of notebook
        /// Checks if the left arrow icon doesn't exist
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyLeftArrowNotExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookTopMenuView", "LeftArrow");
        }

        /// <summary>
        /// Checks lesson number on the current page matches the one passed as a parameter
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">lesson number to be matched</param>
        /// <returns>Boolean object: true if lesson number matches</returns>
        public static Boolean VerifyLessonNumber(AutomationAgent notebookAutomationAgent, string lessonNumber)
        {
            string lessonDetails = notebookAutomationAgent.GetElementText("LessonBrowserView", "LessonNumber");
            if (lessonDetails.Substring(lessonDetails.Length - 1).Equals(lessonNumber))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifies if current page is last page of notebook
        /// Checks if the right arrow icon doesn't exist
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyRightArrowNotExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookTopMenuView", "RightArrow");
        }

        /// <summary>
        /// Checks if the delete icon is disabled in notebook bottom menu
        /// Checks enabled property of delete icon control
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: true if delete is enabled</returns>
        public static string GetDeleteIconEnabledStatus(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DeleteIcon", "enabled");
        }

        /// <summary>
        /// Verifies task notebook exists by checking the element of task notebook name
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyTaskNotebookFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookTopMenuView", "TaskNotebookName");
        }

        /// <summary>
        /// Opens notebook work browser
        /// Clicks on Notebook work browser icon 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void NotebookWorkBrowserView(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIcon"))
            {
                notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserIcon");
                notebookAutomationAgent.Sleep(2000);
            }
            else if (notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "PersonalNotesFoldericonCheck"))
            {
                notebookAutomationAgent.Click("NotebookTopMenuView", "PersonalNotesFoldericonCheck");
                notebookAutomationAgent.Sleep(2000);
            }
        }

        /// <summary>
        /// Opens noteboook work broswer from shared notebook
        /// Clicks on work browser icon on shared notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SharedNotebookWorkBrowserView(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("ReceivedWorkView", "SharedWorkBrowserIcon");
        }

        /// <summary>
        /// Verifies if the shared work browser element not found
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifySharedNotebookWorkBrowserViewNotFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("ReceivedWorkView", "SharedWorkBrowserIcon");
        }

        /// <summary>
        /// Opens personal notebook from notebook work browser
        /// Clicks on personal notebook link
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickPersonalNotesLink(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "PersonalNotes");
            notebookAutomationAgent.Sleep(2000);
        }

        /// <summary>
        /// Opens received notebooks browser
        /// Clicks on received notebook link 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickReceivedNotebookLink(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "ReceivedNotebook");
        }
        public static void ClickReceivedNotebookTile(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("RecievedWorkView", "ReceivedNotebookTile");
        }

        /// <summary>
        /// Opens work browser from notebook browser
        /// Clicks on work browser link
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickWorkBrowserButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserButton");
        }

        /// <summary>
        /// Verifies if the personal note link present in notebook brower
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyPersonalNoteLinkPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "PersonalNotes");
        }

        /// <summary>
        /// Opens existing personal note
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void OpenExistingPersonalNotes(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNotesTitle");
        }

        /// <summary>
        /// Opens task one by clicking on the title
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void CurrentTaskOneTitle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "TaskOneTitle");
        }

        /// <summary>
        /// Verifies received notebook link is available
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyReceivedNotebookLinkPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "ReceivedNotebook");
        }

        /// <summary>
        /// Verifies if work browser button exists
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyWorkBrowserButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "WorkBrowserButton");
        }

        /// <summary>
        /// Opens new personal notebook dialog
        /// Clicks on create new note tile
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCreateNoteInPersonalNote(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNoteCreateNote");
            notebookAutomationAgent.Sleep(2000);

        }

        /// <summary>
        /// Creates a new personal notebook
        /// Clicks on create button on dialog
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickPersonalNoteCreateButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNoteCreateButton");
            notebookAutomationAgent.Sleep(2000);
        }

        /// <summary>
        /// Sets personal note name
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="personalNoteName">personal note name to be added</param>
        public static void SetNameToPersonalNote(AutomationAgent notebookAutomationAgent, string personalNoteName)
        {
            if (personalNoteName != string.Empty)
            {
                notebookAutomationAgent.SetText("PersonalNotesView", "PersonalNoteTitlePlaceholderToEdit", personalNoteName);
                notebookAutomationAgent.SendText(" ");
                if (personalNoteName == " ")
                    notebookAutomationAgent.SendText("{BKSP}");
            }
            else
                notebookAutomationAgent.SendText("{BKSP}");
        }

        /// <summary>
        /// Verifies personal note name is not found
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyPersonalNoteFound(AutomationAgent notebookAutomationAgent, string name = "My Personal")
        {
            notebookAutomationAgent.Sleep();
            return notebookAutomationAgent.IsElementFound("PersonalNotesTopView", "PersonalNoteNameDynamic", name);
        }

        /// <summary>
        /// Cancels deletion of notebook page from confirmation dialog
        /// Clicks on Cancel button on dialog
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void CancelDeleteNotebookPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "DeleteIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CancelLabel");
        }

        /// <summary>
        /// Selects text menu from bottom menu
        /// Clicks on Text icon in bottom menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickTextIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            while (!VerifyTextIconActive(notebookAutomationAgent))
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "TextIcon");
            }
        }

        /// <summary>
        /// Enters text in notebook
        /// Clicks on T, E, S, T alphabets and closes keyboard
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void EnterTextInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
            notebookAutomationAgent.Click("NotebookView", "AlphabetE");
            notebookAutomationAgent.Click("NotebookView", "AlphabetS");
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
            notebookAutomationAgent.Click("NotebookView", "CloseKeyboard");
        }

        /// <summary>
        /// Selects drawing or pen icon from notebook bottom menu
        /// Clicks on pen icon in bottom menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickPenIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "PenIcon");
        }

        /// <summary>
        /// Selects erase icon from notebook bottom menu
        /// Clicks on erase icon in bottom menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickEraserIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraserIcon");
        }

        /// <summary>
        /// Opens share notebook dialog
        /// Clicks on Share icon in notebook top menu view
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickShareNotebookIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "ShareIcon");
        }

        /// <summary>
        /// Selects teacher for sharing notebook
        /// Clicks on Teacher name
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SelectTeacherNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "TeacherRow");
        }

        /// <summary>
        /// Moves to next page on share dialog
        /// Clicks on Next button on Share notebook dialog
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickNextNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "NextButton");
        }

        /// <summary>
        /// Shares notebook with the receiver selected 
        /// Clicks on Send button on Share notebook dialog
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickSendNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "SendButton");
        }

        /// <summary>
        /// Sets message for sharing a notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void EnterSharingMessage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
            notebookAutomationAgent.Click("NotebookView", "AlphabetE");
            notebookAutomationAgent.Click("NotebookView", "AlphabetS");
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
        }

        /// <summary>
        /// Confirms before sharing a notebook 
        /// 1. Verifies confirmation popup appears
        /// 2. Clicks on OK to share the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ConfirmNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("PopUpView", "NotebookShareMessage", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.VerifyElementFound("PopUpView", "NotebookShareMessage");
            notebookAutomationAgent.Click("PopUpView", "NotebookShareOkLabel");
        }

        /// <summary>
        /// Confirms success message on sharing notebook
        /// 1. Verifies notebook share success dialog appears
        /// 2. Clicks on OK for closing the confirmation
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SuccessNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("PopUpView", "NotebookShareSuccessMessage", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.VerifyElementFound("PopUpView", "NotebookShareSuccessMessage");
            notebookAutomationAgent.Click("PopUpView", "NotebookShareOkLabel");
        }

        /// <summary>
        /// Downloads and open received notebook
        /// 1. Verifies if tap to download link is available
        /// 2. Clicks to download if not already downloaded
        /// 3. Opens shared notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnReceivedWork(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("ReceivedWorkView", "LatestSharedWork"))
            {
                notebookAutomationAgent.Click("ReceivedWorkView", "LatestSharedWork");
            }
            else
            {
                string[] parentHidden;
                if (notebookAutomationAgent.IsElementFound("ReceivedWorkView", "TapToDownloadReceived"))
                {
                    parentHidden = notebookAutomationAgent.GetAllValues("ReceivedWorkView", "TapToDownloadReceived", "parentHidden");
                    if (parentHidden == null || parentHidden[0] == "NULL")
                    {
                        notebookAutomationAgent.Click("ReceivedWorkView", "TapToDownloadReceived");
                        while (WorkBrowserCommonMethods.VerifyProgressBarForCRDownloadedItem(notebookAutomationAgent))
                        {
                            System.Threading.Thread.Sleep(10000);
                        }
                    }
                }
                notebookAutomationAgent.Click("ReceivedWorkView", "LatestSharedWork");
            }
        }

        /// <summary>
        /// Verifies text found in Comments with shared notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyTextInComment(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "CommentText");
        }

        public static void VerifyStudentNameInComment(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StudentName");
        }

        public static void VerifyCommentTextNotFoundInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookView", "CommentText");
        }

        public static void VerifyCommentIconNotFoundInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookTopMenuView", "CommentIcon");
        }

        public static void ClickCommentIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "CommentIcon");
        }
        public static void ClickELANotebookTile(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "ELANotebookTile", "Lincoln in Context");
        }
        public static void ClickViewInLessonButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "ViewInLessonButton");
        }
        public static void ReceivedWorkOverlayFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("ReceivedWorkView", "ReceivedWorkTitle");
        }
        public static void VerifyGradeNotAvailableAlert(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowserView", "GradeNotAvailableAlert");
        }


        public static int GetCountAssociated(AutomationAgent notebookAutomationAgent, string notesType)
        {
            if (notesType == "ReceivedNotes")
            {
                string text = notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "ReceivedNotebook", "text");
                return int.Parse(text.Substring(text.IndexOf('('), text.IndexOf(')') - text.IndexOf('(')));
            }
            else if (notesType == "PersonalNotes")
            {
                string text = notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "PersonalNotes", "text");
                return int.Parse(text.Substring(text.IndexOf('('), text.IndexOf(')') - text.IndexOf('(')));
            }
            else
            {
                return 0;
            }
        }


        public static void ClickCancelPersonalNoteCrate(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNoteCancelButton");
        }

        public static void VerifyPersonalNoteTitle(AutomationAgent notebookAutomationAgent, string name)
        {
            Assert.AreEqual<string>(name, notebookAutomationAgent.GetElementProperty("PersonalNotesTopView", "PersonalNoteName", "text"));
        }

        public static void VerifyPenColorPopup(AutomationAgent notebookAutomationAgent, bool onScreen)
        {
            Assert.AreEqual<bool>(onScreen, bool.Parse(notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "SelectColorPopup", "onScreen")));
        }

        public static void VerifyEraserPopup(AutomationAgent notebookAutomationAgent, bool onScreen)
        {

            Assert.AreEqual<bool>(onScreen, bool.Parse(notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "SelectColorPopup", "onScreen")));

        }

        public static void VerifyNoteBookIsClosed(AutomationAgent notebookAutomationAgent, bool onScreen)
        {
            Assert.AreEqual<bool>(onScreen, bool.Parse(notebookAutomationAgent.GetElementProperty("NotebookView", "NotebookPanel", "onScreen")));
        }

        public static void ClickNoteBookEmptyPage(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookTextBoxCursor");
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookPredictionKeyboard");
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            notebookAutomationAgent.ClickCoordinate(x + 800, y);
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.DragElement("NotebookView", "NotebookTextBox", x, y);
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraserIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ClearPage");
        }
        public static void EditMovingTextBox(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookTextBoxCursor");
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookPredictionKeyboard");
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            notebookAutomationAgent.ClickCoordinate(x + 800, y);
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.DragElement("NotebookView", "NotebookTextBox", x, y);
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            //xpath for moved text box is copied 
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookMovedTextBoxValue");
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookPredictionKeyboardBackspace");
        }

        public static void SetPersonalNoteTextBoxtoEmpty(AutomationAgent notebookAutomationAgent, string textBoxValue)
        {
            //while((notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookMovedTextBoxValue")!=string.Empty))
            notebookAutomationAgent.SendText("{BKSP}");
            notebookAutomationAgent.SendText("{BKSP}");
            Assert.IsTrue(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookEditEmptyTextBox") == string.Empty);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraserIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ClearPage");
        }

        public static void ClickEraseIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraseIcon");
        }

        public static bool VerifyEraseSliderExists(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ResizeEraserSlider");
        }

        public static void ClickOnWrenchIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "WrenchIcon");
        }

        public static void VerifyDesmosTool(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "GraphingTool");
        }

        public static void VerifyUndoRedoButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "UndoRedoIcon", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "UndoRedoIcon");
        }

        public static void VerifyUndoRedoSubMenu(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "UndoIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "RedoIcon");
        }


        public static void ClickSharedWorkBrowserView(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "SharedWorkBrowserIcon");
        }

        public static void ClickTaskNoteBookButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "TaskNoteBookButton");
        }

        public static bool VerifyNotebookBrowserExists(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIcon");
        }

        public static void VerifyTaskNotebookButtonExistInSharedNotebook(AutomationAgent notebookAutomationAgent, string taskName)
        {
            notebookAutomationAgent.VerifyElementFound("ReceivedWorkView", "TaskNotebookInSharedNotebook", taskName);
        }

        public static void ClickTaskNotebookButtonExistInSharedNotebook(AutomationAgent notebookAutomationAgent, string taskName)
        {
            notebookAutomationAgent.Click("ReceivedWorkView", "TaskNotebookInSharedNotebook", taskName);
        }

        public static void VerifyDeleteIconExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "DeleteIcon");
        }

        public static void VerifyWrenchToolSubMenuExists(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "WrenchIconSubMenuPanel", "", WaitTime.MediumWaitTime))
            {
                notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "WrenchIconSubMenuPanel");
            }
        }

        public static void ClickOnUndoRedoIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UndoRedoIcon");
        }
        public static void ClickOnNotebookDrawView(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookDrawView", "DrawViewPanel");
        }



        public static void TapOnScreen(AutomationAgent annotationAutomationAgent, int x, int y, int clickcount)
        {
            annotationAutomationAgent.Sleep(1000);
            annotationAutomationAgent.ClickOnScreen(x, y, clickcount);
        }


        public static void ClickUndoRedoIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UndoRedoIcon");
        }

        public static string VerifyRedoButtonActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "RedoIcon", "enabled");
        }

        public static string VerifyUndoButtonActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "UndoIcon", "enabled");
        }

        public static void ClickUndoIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "UndoIcon", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UndoIcon");
        }


        public static void ClickRedoIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "RedoIcon");
        }


        public static string GetTextInTextZone(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetText("TEXT");
        }

        public static string GetTextInsideElement(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetTextIn("PersonalNotesTopView", "PersonalNotebookTitleText", "NATIVE", "Inside", "", 0, 0);
        }

        public static string GetTextBoxContent(AutomationAgent notebookAutomationAgent, string Dynamictext)
        {
            return notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxContent", Dynamictext);
        }


        public static void ClickDrawingIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "DrawingIcon");
        }

        public static string IsDrawingIconPopUpOpen(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DrawingIconPopup", "enabled");
        }

        public static string VerfiyDrawingIconPopUpOpen(AutomationAgent notebookAutomationAgent)
        {
            return (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "DrawingIconPopup")).ToString();
        }

        public static void SendText(AutomationAgent notebookAutomationAgent, string Text)
        {
            notebookAutomationAgent.SendText(Text);
        }

        public static void Swipe(AutomationAgent notebookAutomationAgent, Direction direction, int offset, int time)
        {
            notebookAutomationAgent.Swipe(direction, offset, time);

        }

        public static void ClickHandIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "HandIcon");
        }

        public static void VerifyNotebookToolbarActiveInactiveIcons(AutomationAgent notebookAutomationAgent)
        {
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "FullscreenIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "HandIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "TextIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "PenIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "EraseIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "ImageIcon", "enabled").ToString()));
            Assert.AreEqual<string>("false", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "ToolIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "BackgroundIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "UndoRedoIcon", "enabled").ToString()));
            Assert.AreEqual<string>("false", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DeleteIcon", "enabled").ToString()));
        }


        public static void SwipeTextBoxControl(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "NotebookTextBoxRegion", x, y);

        }


        public static bool VerifyNotebookOpen(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookDrawRegion"))
            {
                string onscreen = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "onScreen")[0];
                return bool.Parse(onscreen);
            }
            return false;
        }

        public static bool VerifyNotebookNotOpen(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookDrawRegion"))
            {
                string onscreen = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "onScreen")[0];
                return !bool.Parse(onscreen);
            }
            return true;
        }

        public static void VerifyCurrentPageNumber(AutomationAgent notebookAutomationAgent, string taskTitle, int currentPageNumber, int totalPageNumbers)
        {
            notebookAutomationAgent.VerifyElementFoundInZone("Native", GetNotebookTitleWithPageNumbers(taskTitle, currentPageNumber, totalPageNumbers), 0);
        }

        public static string GetNotebookTitleWithPageNumbers(string taskTitle, int currentPageNumber, int totalPageNumbers)
        {
            return "accessibilityLabel=" + taskTitle + " (" + currentPageNumber.ToString() + "/" + totalPageNumbers.ToString() + ")";
        }

        public static int GetWidthOfNavigationBar(AutomationAgent notebookAutomationAgent)
        {
            string[] width = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookBackgroundBlack", "width");
            return Int32.Parse(width[0]);
        }

        public static int GetWidthOfLessonTemplate(AutomationAgent notebookAutomationAgent)
        {
            string[] width = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "DivLessonTemplate", "width");
            return Int32.Parse(width[0]);
        }

        public static string VerifyNotebookIcon(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("TasksTopMenuView", "NotebookIcon").ToString();
        }

        public static bool VerifyHandIconActiveHighlight(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "HandIconHighlightImage");
        }

        public static string VerifyHandIconActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "HandIcon", "enabled");

        }

        public static string VerifyKeyboardPresence(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("KeyboardView", "KeyBoardPresenceElement").ToString();
        }

        public static void ClickOnImageIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");
            notebookAutomationAgent.Sleep(2000);

        }

        public static void ResizeImageInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "ResizePhoto", 100, 100);
        }
        public static void SwipeImage(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "PhotoRegion", x, y);


        }
        public static string VerifyEraseIconActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "EraserIcon", "enabled");
        }

        public static void AddImageInNoteBook(AutomationAgent notebookAutomationAgent, bool CancelSelectedPhoto)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "AddPhoto");

            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "OKButton", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }
            bool albumOpen = false;
            while (!albumOpen)
            {
                if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "Album"))
                {
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "Album");
                    albumOpen = true;
                }
                notebookAutomationAgent.Sleep(WaitTime.SmallWaitTime);
            }
            
            int i = 3;
            bool photoExists = true;
            bool PhotoNotAvailable = true;

            while (photoExists)
            {
                if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "SelectPhoto", (i + 2).ToString()))
                {
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "SelectPhoto", (i + 2).ToString(), 1, WaitTime.DefaultWaitTime);

                    if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "IsThumbnailVideo"))
                    {
                        //video
                        notebookAutomationAgent.Click("NotebookBottomMenuView", "VideoBackButton");
                        i++;
                    }

                    else
                    {
                        PhotoNotAvailable = false;
                        i++;
                        break;
                    }

                }
                else
                {
                    photoExists = false;
                }
            }

            if (PhotoNotAvailable)
            {
                AddPhotoFromCamera(notebookAutomationAgent);
            }

            else
            {
                if (CancelSelectedPhoto)
                {
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageCancelButton");
                    if(notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ImageCancelButton")) 
                    {
                        notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageCancelButton");
                    }
                }
                else
                {
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");
                }
            }
            notebookAutomationAgent.Sleep(2000);

        }


        public static void AddPhotoFromCamera(AutomationAgent notebookAutomationAgent)
        {

            notebookAutomationAgent.Click("NotebookBottomMenuView", "CameraButton");
            System.Threading.Thread.Sleep(2000);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CameraButton");
            notebookAutomationAgent.Click("CameraView", "CAMShutterButton");
            System.Threading.Thread.Sleep(2000);
            notebookAutomationAgent.Click("CameraView", "UsePhotoButton");
        }

        public static string ImageSizeInNoteBookBeforeResize(AutomationAgent notebookAutomationAgent)
        {
            if (!VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent))
            {
                ClickOnImageInNotebook(notebookAutomationAgent);
            }
            string[] strArray = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "PhotoWidthBefore", "width");
            return strArray[0];
        }

        public static string ImageSizeInNoteBookAfterResize(AutomationAgent notebookAutomationAgent)
        {
            if (!VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent))
            {
                ClickOnImageInNotebook(notebookAutomationAgent);
            }
            string[] strArray = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "PhotoWidthAfter", "width");
            return strArray[0];
        }

        public static void MoveImageInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookBottomMenuView", "PhotoWidthBefore", Direction.Left, 10, WaitTime.DefaultWaitTime);
        }

        public static string GetImageCoordinate(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "PhotoWidthBefore");
        }


        public static void ClickHandIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "HandIcon");
        }

        public static void ClickOnImageInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "PhotoWidthAfter");
        }

        public static string VerifyImageDeleteIcon(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "ImageDeleteIcon", "enabled");
        }

        public static void DeletePicture(AutomationAgent notebookAutomationAgent)
        {
            if (!notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ImageDeleteIcon")) 
            {
                ClickOnImageInNotebook(notebookAutomationAgent);
            }
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageDeleteIcon");
            notebookAutomationAgent.WaitForElementToVanish("NotebookBottomMenuView", "PhotoRegion");
        }

        public static void ClickOnLesson(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("LessonView", "AnotherLesson");
        }

        public static void ClickOnContinue(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("LessonsOverView", "ELALessonContinueButton");
        }

        public static string VerifyNotebookClosed(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DrawingIconPopup", "enabled");
        }


        public static string VerifyNotebookIconPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "WorkBrowserNotebookIcon").ToString();
        }

        public static void ClickNotebookIconFromBrowser(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "WorkBrowserNotebookIcon");
        }

        public static void ResizeTextRegion(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "TextRegionResizeIcon", 100, 100);
        }


        public static string GetCoordinatesForTextRegionResize(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "TextRegionResizeIcon").ToString();
        }

        public static string VerifyTextRegionPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "TextRegion").ToString();
        }

        public static void ClickOnFolderIcon(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIcon"))
                notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserIcon");
            else if (notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIconNonShared"))
                notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserIconNonShared");
        }

        public static void ClickOnPersonalNotes(AutomationAgent notebookAutomationAgent, string dynamicvalue)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNotesTitle", dynamicvalue);
        }

        public static void ClickOnClosePersonalNotes(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonaNoteTabClose");
        }

        public static bool VerifyNotebookRegionPresent(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookDrawRegion"))
            {
                string onscreen = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "onScreen")[0];
                return bool.Parse(onscreen);
            }
            return false;
        }

        public static void ClickOnGotoBrowserButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "GoToWorkBrowser");
        }

        public static string VerifyFolderIcon(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIcon").ToString();

        }

        public static string VerifyFontSizeMedium(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "FontSizeMedium").ToString();
        }

        public static void ClickClearPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "ClearPage", "", WaitTime.SmallWaitTime);
            if(!notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ClearPage"))
            {
                ClickEraseIconInNotebook(notebookAutomationAgent);
            }
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ClearPage");
            notebookAutomationAgent.WaitForElementToVanish("NotebookBottomMenuView", "ClearPage");
        }

        public static string GetxCoordinatesDrawingSlider(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "ResizeDrawingSlider").ToString();
        }


        public static void ResizeDrawingSlider(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "ResizeDrawingSlider", 100, 100);
        }

        public static string GetCoordinatesOfEraser(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "ResizeEraserSlider").ToString();
        }

        public static void ResizeEraserSlider(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "ResizeEraserSlider", 100, 100);
        }

        public static void LongClickOnText(AutomationAgent notebookAutomationAgent, string text)
        {
            notebookAutomationAgent.LongClick("NotebookBottomMenuView", "TextBoxText", text);

        }

        public static void ClickOnSelectAllAnnotation(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TextEditView", "SelectAll");
        }


        public static void ClickOnColorInKeyboard(AutomationAgent notebookAutomationAgent, string color)
        {
            notebookAutomationAgent.Click("KeyboardView", "Color", color);
        }

        public static string GetTextColor(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("KeyboardView", "TextBoxText", "Doctor", "textColor");
        }

        public static string TextBackgroundWhite(AutomationAgent notebookAutomationAgent)
        {
            string[] str;
            str = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "TextBackgroundWhite", "backgroundColor");
            return str[0];
        }

        public static string GetPositionOfTextBox(AutomationAgent notebookAutomationAgent, string text)
        {
            return notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "TextBoxText", text).ToString();
        }

        public static void SwipeTextBoxControlEditMode(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "TextBoxText", x, y);
        }

        public static string VerifyTextBorderPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookTextBoxRegion").ToString();
        }

        public static void VerifySelectedColorbuttonActive(AutomationAgent notebookAutomationAgent, string color)
        {
            switch (color)
            {
                case "red":
                    Assert.AreEqual<string>("True", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "red").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "blue").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "black").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "green").ToString()));
                    break;
                case "blue":
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "red").ToString()));
                    Assert.AreEqual<string>("True", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "blue").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "black").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "green").ToString()));
                    break;
                case "black":
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "red").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "blue").ToString()));
                    Assert.AreEqual<string>("True", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "black").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "green").ToString()));
                    break;
                case "green":
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "red").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "blue").ToString()));
                    Assert.AreEqual<string>("False", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "black").ToString()));
                    Assert.AreEqual<string>("True", (notebookAutomationAgent.IsElementFound("KeyboardView", "ColorSelected", "green").ToString()));
                    break;
            }
        }

        public static void CreatePersonalNote(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "CreatePersonalNoteTile");
            notebookAutomationAgent.Click("PersonalNotesView", "CreatePersonalNoteCreateButton");
        }

        public static void VerifyOpenNotebookButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("LessonBrowserView", "OpenNotebookButton");
        }

        public static bool VerifyUndoRedoSubMenuFound(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "UndoIconInactive") && notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "RedoIconInactive"))
                return true;
            else
                return false;
        }

        public static void TapNotebooksTabToCloseNotebook(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitForElement("WorkBrowser", "WorkBrowserMenu", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
            }
            notebookAutomationAgent.Click("WorkBrowser", "NotebooksLink");
            notebookAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
        }

        public static void TapNotebooksTabToOpenNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
            notebookAutomationAgent.Click("WorkBrowser", "NotebooksLink");
            notebookAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
        }

        public static string VerifyNotebooksExistsInWorkBrowser(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("WorkBrowser", "Notebook", "enabled");
        }

        public static void VerifyNotebooksDoesnotExistInWorkBrowser(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("WorkBrowser", "Notebook");
        }

        public static void DrawDiamondImageInNotebook(AutomationAgent notebookAutomationAgent, int startingX1, int startingY1)
        {
            notebookAutomationAgent.DrawDiamondImage(startingX1, startingY1);
        }

        public static void VerifyDiamondImageExistsInNB(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "NotebookDiamondDraw");
        }

        public static void VerifyDiamondImageNotExistsInNB(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookView", "NotebookDiamondDraw");
        }

        public static string GetTaskName(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Sleep();
            return notebookAutomationAgent.GetElementProperty("NotebookTopMenuView", "TaskName", "text");
        }

        public static int GetFullScreenNavigationBarWidth(AutomationAgent notebookAutomationAgent)
        {
            string[] navigationbarwidth = notebookAutomationAgent.GetAllValues("LessonView", "NavigationBar", "width");
            return Int32.Parse(navigationbarwidth[0]);

        }

        public static int GetFullScreenFooterWidth(AutomationAgent notebookAutomationAgent)
        {

            string[] footerscreenwidth = notebookAutomationAgent.GetAllValues("LessonView", "FullScreenFooter", "width");
            return Int32.Parse(footerscreenwidth[0]);
        }



        public static void AddVideoInNotebook(AutomationAgent notebookAutomationAgent, bool VideoLengthGreaterThan60)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "AddPhoto");
            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "OKButton", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }

            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "Videos"))
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "Videos");
                notebookAutomationAgent.Sleep(2000);
                int i = 1;
                bool photoExists = true;
                while (photoExists)
                {
                    if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "SelectVideo", i.ToString()))
                    {
                        notebookAutomationAgent.Click("NotebookBottomMenuView", "SelectVideo", (i).ToString(), 1, WaitTime.DefaultWaitTime);

                        if (VideoLengthGreaterThan60)
                        {
                            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "VideoTooLongMessage")) //IsElemetFound==true
                            {
                                notebookAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");
                                break;
                            }
                            else
                            {
                                notebookAutomationAgent.Click("NotebookBottomMenuView", "VideoBackButton");
                                i++;
                            }
                        }
                        else //User Requirement less then60
                        {
                            bool value = (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "VideoTooLongMessage"));
                            if (!(notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "VideoTooLongMessage")))//IsElemetFound==false
                            {
                                notebookAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");
                                break;
                            }
                            else
                            {
                                notebookAutomationAgent.Click("NotebookBottomMenuView", "VideoBackButton");
                                i++;

                            }

                        }

                    }
                    else
                    {
                        photoExists = false;
                    }
                }

            }

            else
            {
                if (VideoLengthGreaterThan60)
                {
                    CreateVideoFromCamera(notebookAutomationAgent, 70000);
                    notebookAutomationAgent.Sleep(5000);
                }

                else
                {
                    CreateVideoFromCamera(notebookAutomationAgent, 10000);
                    notebookAutomationAgent.Sleep(4000);
                }
            }

        }

        public static void AddVideoInNotebookAndKillApp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");
            System.Threading.Thread.Sleep(2000);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CameraButton");
            System.Threading.Thread.Sleep(2000);
            notebookAutomationAgent.Swipe(Direction.Up, 1000, 500);
            notebookAutomationAgent.Click("CameraView", "StartRecordVideoButton");
            System.Threading.Thread.Sleep(70000);
            VerifyInsertVideo60SecLimitPopup(notebookAutomationAgent);
            notebookAutomationAgent.ApplicationClose();
        }


        public static void CreateVideoFromCamera(AutomationAgent notebookAutomationAgent, int VideoLength)
        {
            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "OKButton", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CameraButton");
            System.Threading.Thread.Sleep(2000);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CameraButton");
            System.Threading.Thread.Sleep(2000);
            notebookAutomationAgent.Swipe(Direction.Up, 1000, 500);
            notebookAutomationAgent.Click("CameraView", "StartRecordVideoButton");
            System.Threading.Thread.Sleep(VideoLength);

            if (VideoLength < 60000)
            {
                notebookAutomationAgent.Click("CameraView", "StopRecordVideoButton");
                notebookAutomationAgent.Click("CameraView", "UseVideoButton");
            }
            else
            {
                VerifyInsertVideo60SecLimitPopup(notebookAutomationAgent);
            }
            notebookAutomationAgent.WaitForElementToVanish("CameraView", "AttachingVideo");
        }

        public static bool VerifyVideoThumbnailFound(AutomationAgent notebookAutomationAgent, string dynamic)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "VideoThumbnailMultiple", dynamic);
        }

        public static bool VerifyVideoThumbnailFound(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "VideoThumbnail");
        }

        public static bool VerifyPhotoExists(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "PhotoRegion"))
            {
                return bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "PhotoRegion", "onScreen")[0]);
            }
            return false;
        }

        public static bool VerifyTextRegionDeleteXIconPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookBoundingRemove");
        }

        public static void ClickTextRegionDeleteXIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NotebookBoundingRemove");
            notebookAutomationAgent.WaitForElementToVanish("NotebookView", "NotebookBoundingRemove");
        }
        public static bool VerifyTextRegionFound(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookTextBoxRegion");

        }

        public static bool VerifyTextRegionTextFound(AutomationAgent notebookAutomationAgent, string text)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "TextBoxText", text);
        }
        public static bool VerifyTextRegionResizeDotsFound(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "TextRegionResizeIcon");
        }

        public static void ClickOnViewLessons(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "View In-Lesson");
        }

        public static void ClickOnNotebookPasteIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "PasteInNotebookText");
        }
        public static void ClickBackpaceButtonInKeyboard(AutomationAgent notebookAutomationAgent)
        {

            notebookAutomationAgent.Click("KeyboardView", "BackSpaceButton");
        }

        public static void AddVideoInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "AddPhoto");
            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "OKButton", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }
            notebookAutomationAgent.Click("NotebookBottomMenuView", "Videos");
            int i = 1;
            bool photoExists = true;
            while (photoExists)
            {
                if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "SelectPhoto", i.ToString()))
                {
                    i++;
                }
                else
                {
                    photoExists = false;
                }
            }
            notebookAutomationAgent.Click("NotebookBottomMenuView", "SelectPhoto", (i - 1).ToString(), 1, WaitTime.DefaultWaitTime);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");
        }

        public static void SwipeTextBoxNotInEditMode(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "NotebookTextBoxRegionNotInEditMode", x, y);

        }

        public static void ClickOnSectionDropMenu(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitForElement("WorkBrowser", "WorkBrowserMenu", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
            }

        }

        public static void ClickOnMyWork(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
        }

        public static void VerifyNotebooksLinkExistsInSection(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowser", "NotebooksLink");
        }

        public static bool VerifyNotebookTile(AutomationAgent notebookAutomationAgent, string title)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowser", "NotebookTile", title);
        }

        public static void ClickOnNotebookSnapshot(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "NotebookSnapshot");
        }

        public static void ClickOnNotebookSnapshotDone(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "NotebookSnapshotDoneButton");
            notebookAutomationAgent.Sleep();
        }

        public static void ClickOnNotebookAddPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NotebookAddPageButton");
            notebookAutomationAgent.Sleep();
        }

        public static bool IsWorkBrowserIconFolderIconFound(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIcon");
        }
        public static void WorkBrowserIconNonShared(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserIconNonShared");
        }

        public static string GetTextIn(AutomationAgent notebookAutomationAgent, string direction)
        {
            return notebookAutomationAgent.GetTextIn("PersonalNotesView", "PersonalNotesTitleText", direction, "");

        }

        public static void ClickDemonstrationResponse(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "DemonstrationResponse");
        }

        public static bool IsDemonstrationResponseTileFound(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("PersonalNotesView", "DemonstrationResponse");
        }

        public static bool VerifyShareIconPresentForNotebookNotForPersonalNotes(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("PersonalNotesView", "ShareIcon");

        }
        public static bool VerifyShareIconPresentForNotebookNotForPersonalNotesNoConnection(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("PersonalNotesView", "ShareIconConnection");

        }

        public static bool IsPersonalNotesPresentNotHavingShareIcon(AutomationAgent notebookAutomationAgent)
        {
            if (NotebookCommonMethods.VerifyShareIconPresentForNotebookNotForPersonalNotes(notebookAutomationAgent) || NotebookCommonMethods.VerifyShareIconPresentForNotebookNotForPersonalNotesNoConnection(notebookAutomationAgent))
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        /// <summary>
        /// clicks on the graphic tool tab which pops out when you select Wrench Icon.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent Object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>

        public static void ClickOnGraphicTool(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "GraphingTool");
            notebookAutomationAgent.Sleep();
        }
        /// <summary>
        /// clicks on the graphic calculator which is on the bottom left of the screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickOnGraphicCalculator(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "GraphicCalculator");
        }
        /// <summary>
        /// verifies graphic calculator gets open by checking the div of the calculator
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: ture if the calculator is open</returns>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static bool VerifyGraphicCalculatorOpen(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "GraphicCalculatorOpen");
        }
        /// <summary>
        /// click on the done button to go back to the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickOnDoneButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("CommonReadTopMenuView", "DoneButton");
        }
        /// <summary>
        /// click on the continue button to exit from the calculator
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickOnContinueButtonToExitCalculator(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ContinueButtonToExitGraphicCalculator");
        }

        /// <summary>
        /// Cancels create Personal Note
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnCreatePersonalNoteCancel(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitforElement("PersonalNotesTopView", "PersonalNoteNameCancel", "", WaitTime.MediumWaitTime))
            {
                notebookAutomationAgent.Click("PersonalNotesTopView", "PersonalNoteNameCancel");
            }
        }

        /// <summary>
        /// Verifies if current page is not first page of notebook
        /// Checks if the left arrow icon exists
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyLeftArrowExists(AutomationAgent notebookAutomationAgent)
        {
            string[] hidden;
            hidden = notebookAutomationAgent.GetAllValues("NotebookTopMenuView", "LeftArrow", "hidden");
            bool hiddenvalue = bool.Parse(hidden[0]);
            if (hiddenvalue == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Verifies Toolbar Button available in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyToolbarButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("TasksTopMenuView", "ToolsIcon", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.VerifyElementFound("TasksTopMenuView", "ToolsIcon");
        }
        /// <summary>
        /// Clicks on Play Button In the Video
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnVideoPlayButtonInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "VideoThumbnail");
        }
        /// <summary>
        /// Verifies the Blue Title Bar present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static string VerifyTitleBarOfNotebook(AutomationAgent notebookAutomationAgent)
        {
            string[] str;
            str = notebookAutomationAgent.GetAllValues("NotebookTopMenuView", "NotebookTitleBar", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Clicks on the Toolbar Button Present 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnToolbarButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "ToolsIcon");
            notebookAutomationAgent.WaitForElementToVanish("DashboardView", "ResourceLibraryFlyOutMenu", "", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verifies Wrench Icon present in Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyWrenchIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "WrenchIcon");
        }

        /// <summary>
        /// Clicks on photos button present in notebook bottom tool Multimedia icon
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickPhotosIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "AddPhoto");
            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "OKButton", WaitTime.SmallWaitTime))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }

        }
        /// <summary>
        /// Verifies the Pop-Up msg while inserting video greater than 60 sec
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyInsertVideo60SecLimitPopup(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "VideoRecStopMsgHeader");
            notebookAutomationAgent.VerifyElementFound("NotebookView", "VideoRecStopMsgBody");
            notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            notebookAutomationAgent.Click("CameraView", "UseVideoButton");
        }
        /// <summary>
        /// Clicks on ToolBar Button Present at the top 
        /// Clicks on Tools Button available in toolbar menu
        /// Clicks on Snapshot tool 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void OpenSnapShot(AutomationAgent notebookAutomationAgent)
        {
            ClickOnToolbarButton(notebookAutomationAgent);
            notebookAutomationAgent.Click("TasksTopMenuView", "ResourceLibraryToolsMenu");
            notebookAutomationAgent.Sleep(2000);
            notebookAutomationAgent.Click("TasksTopMenuView", "SnapshotIcon");
            notebookAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verifies Snapshot grid available on screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifySnapShotGridPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("TasksTopMenuView", "SnapShotGridView");
        }
        /// <summary>
        /// Clicks on Capture Button for capturing snapshot
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCaptureSnapShot(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "CaptureSnapshotButton");
        }
        /// <summary>
        /// Clicks on Snapshot button available in the multimedia icon in notebook bottom toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSnapShotIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "SnapshotIcon");
            notebookAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verifies Open Notebook Button Present in Lesson screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if present), false (if not present)</returns>
        public static bool VerifyOpenNotebookButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            string onScreen = notebookAutomationAgent.GetElementProperty("LessonBrowserView", "OpenNotebookButton", "onScreen");
            return bool.Parse(onScreen);

        }
        /// <summary>
        /// Verifies wether notebook covers the half part of the screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if width is half of the screen), false (if width is not half of the screen)</returns>
        public static bool VerifyNotebookSplitsLessonWindow(AutomationAgent notebookAutomationAgent)
        {
            string WindowSize = notebookAutomationAgent.GetAllValues("NoteBookTouchView", "ScreenSizeHTML", "width")[0];
            string notebookWindowSize = "0";
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookWidthControl"))
            {
                notebookWindowSize = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookWidthControl", "width")[0];

            }
            return (Int32.Parse(notebookWindowSize) * 2 == Int32.Parse(WindowSize)) ? true : false;
        }
        /// <summary>
        /// Clicks on the Open Notebook Button Present in the Lesson screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnOpenNotebookButton(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            notebookAutomationAgent.Click("NotebookView", "OpenNotebookButton");
            notebookAutomationAgent.Sleep(6000);
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "ChooseNotebook", "", WaitTime.LargeWaitTime);
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Clicks on the Open Notebook Button in Math Present in the Lesson screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnOpenNotebookButtonMath(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "OpenNotebookButtonMath");
        }
        /// <summary>
        /// Verifies Open Notebook Button in Math Present in Lesson screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if present), false (if not present)</returns>
        public static bool VerifyOpenNotebookButtonMathPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "OpenNotebookButtonMath");
        }
        /// <summary>
        /// Verifies the sub menu of Toolbar button present
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyToolbarSubMenu(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("DashboardView", "ResourceLibraryFlyOutMenu", "", WaitTime.LargeWaitTime);
            notebookAutomationAgent.VerifyElementFound("DashboardView", "ResourceLibraryFlyOutMenu");
        }

        /// <summary>
        /// To verify All Notebook Bottom Toolbars Active or Inactive
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if Active Inactive as expected), false (if not per expectations)</returns>
        public static bool VerifyAllBottomToolbarsActiveInactive(AutomationAgent notebookAutomationAgent)
        {
            bool controlsExist = false;

            controlsExist =
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "FullscreenIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "HandIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "TextIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "PenIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "EraserIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "ImageIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "WrenchIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "BackgroundIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "UndoRedoIcon", "onScreen")[0]) &&
            bool.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "DeleteIcon", "onScreen")[0]);
                
            
            return controlsExist;
        }
        /// <summary>
        /// Verifies Personal Note Create Default Header and Title
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>Returns default Title</returns>
        public static string VerifyPersonalNoteDefaultTitleAndPopup(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("PersonalNotesView", "PersonalNoteCreatePopupHeader");
            notebookAutomationAgent.VerifyElementFound("PersonalNotesView", "PersonalNoteTitlePlaceholder");
            return notebookAutomationAgent.GetTextIn("PersonalNotesView", "PersonalNoteTitlePlaceholder", "Inside", "");
        }

        /// <summary>
        /// Verifies whether Create Button Enabled or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if Enabled), false (if disabled)</returns>
        public static bool VerifyCreateButtonPersonalNotesEnabled(AutomationAgent notebookAutomationAgent)
        {
            return bool.Parse(notebookAutomationAgent.GetElementProperty("PersonalNotesView", "PersonalNoteCreateButton", "enabled"));
        }

        /// <summary>
        /// Clicks on Already available Personal Notes 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickExistingPersonalNoteCell(AutomationAgent notebookAutomationAgent, string title = "MyTitle", bool selectOnCloudNotebook = false)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "ExistingPersonalNoteCell", title);
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "ChooseNotebook", "", WaitTime.MediumWaitTime);
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Verifies whether Personal Notes already available
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if Available), false (if not available)</returns>
        public static bool VerifyExistingPersonalNoteCellAvailable(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("PersonalNotesView", "ExistingPersonalNoteCell");
        }

        /// <summary>
        /// Edits the Personal Notes Title as Sent by User
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="EnteredText">Text to be Modified as per Title</param>
        public static void EditPersonalNotesTitle(AutomationAgent notebookAutomationAgent, string EnteredText, string name = "My Personal")
        {
            notebookAutomationAgent.Sleep(2000);
            notebookAutomationAgent.SetText("PersonalNotesTopView", "PersonalNoteNameDynamic", EnteredText, WaitTime.DefaultWaitTime, name);
        }

        /// <summary>
        /// Verifies the New Title of Personal Notes
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (If found), false (if not found)</returns>
        public static bool VerifyNewPersonalNotesTitle(AutomationAgent notebookAutomationAgent, string title)
        {
            notebookAutomationAgent.Sleep(3000);
            return notebookAutomationAgent.IsElementFound("PersonalNotesTopView", "PersonalNoteNameEdited", title);
        }


        public static bool VerifyPersonalNotesTitle(AutomationAgent notebookAutomationAgent, string title)
        {
            return notebookAutomationAgent.IsElementFound("PersonalNotesTopView", "PersonalNoteNameEditedDynamic", title);
        }

        /// <summary>
        /// Click On Cancel Button available in Image Selection
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelPhotoSelection(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageCancelButton");
        }
        /// <summary>
        /// Click X icon To delete inserted Image
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickXIconNewPersonalNote(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "XIconNewPersonalNote");
        }
        /// <summary>
        /// Verifies that image is at the center of the notebook page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if image is at the center of the notebook page), false (if image not at center)</returns>
        public static bool VerifyImageInCenterOfNotebook(AutomationAgent notebookAutomationAgent)
        {

            string NotebookPos = notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "NotebookDrawRegion");
            string[] strArray = NotebookPos.Split(',');
            int NotebookX = Int32.Parse(strArray[0]);
            int NotebookY = Int32.Parse(strArray[1]);
            int NotebookViewInner = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "NotebookViewInner", "x")[0]);
            int NotebookDrawX = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "x")[0]);
            int BorderDiff = NotebookViewInner - NotebookDrawX;
            string ThumbnailPos = notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "PhotoRegion");
            string[] strArray1 = ThumbnailPos.Split(',');
            int ThumbnailX = Int32.Parse(strArray1[0]);
            int ThumbnailY = Int32.Parse(strArray1[1]);
            if (((NotebookX + (BorderDiff) - ThumbnailX) < 5 || (NotebookX + (BorderDiff) - ThumbnailX) > 5)
                && ((NotebookY + BorderDiff) - ThumbnailY) < 5 || ((NotebookY + BorderDiff) - ThumbnailY) > 5)
                return true;
            else
                return false;
        }
        /// <summary>
        /// To Verify the Global Navigation bar is present for Math Lesson 1
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyGlobalNavBarPresentInMathLesson2(AutomationAgent notebookAutomationAgent, string title)
        {

            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "GlobalNavBarInMathLesson1", title);
        }

        /// <summary>
        /// To Verify Send to Notebook Button is present for New Desmos creation
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if element is present), false (if element is not present)</returns>
        public static bool VerifySendToNotebookIconPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "SendToNotebookBtnDesmos");

        }

        /// <summary>
        /// To Click on Send to Notebook Button  for New Desmos creation
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSendToNotebookIcon(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "SendToNotebookBtnDesmos");
            notebookAutomationAgent.Sleep();
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }
        /// <summary>
        /// Verifies Confirmation Pop Up for new desmos
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyAlertMessageforConfirmationNewDesmos(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookTopMenuView", "DoneBtnNewDesmosPopUpMsg");
        }
        /// <summary>
        /// Clicks on Done Button for new desmos creation 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDoneButtonNewlyCreateDesmos(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            notebookAutomationAgent.Sleep();
            notebookAutomationAgent.Click("NotebookTopMenuView", "DoneBtnNewDesmos");
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "ChooseNotebook", "", WaitTime.MediumWaitTime);
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }
        /// <summary>
        /// Clicks on Continue Button in Pop Up Message
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickContinueOnAlertMessageforConfirmationNewDesmos(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Sleep(2000);
            notebookAutomationAgent.Click("CommonReadAnnotationsPanelView", "ContinueButton");
            notebookAutomationAgent.Sleep(2000);
        }

        /// <summary>
        /// Verifies if user is on Desmos Page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if desmos page is present), false (if desmos page is not present)</returns>
        public static bool VerifyNewDesmosPagePresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "GraphingToolTitleBar");
        }
        /// <summary>
        /// Clicks on Cancel Button in Pop Up Message
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelOnAlertMessageforConfirmationNewDesmos(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "CancelButton");
        }
        /// <summary>
        /// Verifies Desmos thumbnail present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true (if thumbnail is present), false (if thumbnail is not present)</returns>
        public static bool VerifyDesmosIsPresentInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Sleep(3000);
            return notebookAutomationAgent.IsElementFound("NotebookView", "DesmosThumbnail");
        }
        /// <summary>
        /// Clicks on Desmos Thumbnail present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDesmosThumbnail(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Sleep(3000);
            notebookAutomationAgent.Click("NotebookView", "DesmosThumbnail");
        }
        /// <summary>
        /// Clicks on Personal Notes Title in Notebook at Top 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPersonalNotesTitleInNotebook(AutomationAgent notebookAutomationAgent, string name = "My Personal")
        {
            notebookAutomationAgent.Click("PersonalNotesTopView", "PersonalNoteNameDynamic", name);
        }
        /// <summary>
        /// Clicks on X Icon Present in the personal note title's text region
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickXIconInNotebookTitle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "XIconNotebookTitle");
        }
        /// <summary>
        /// Verifies Notebook Title present at the top
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Title name of the Notebook</returns>
        public static string VerifyNotebookTitle(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetTextIn("PersonalNotesTopView", "PersonalNotebookTitle", "Inside", "");
        }
        /// <summary>
        /// Verifies Notebook's Title which is edited 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Edited title of the notebook</returns>
        public static string GetNotebookTitleEdited(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.IsElementFound("PersonalNotesTopView", "PersonalNotebookTitle");
            return notebookAutomationAgent.GetTextIn("PersonalNotesTopView", "PersonalNotebookTitle", "inside", "");
        }
        /// <summary>
        /// Gets the X and Y position of the video in the notebook and Pinch the video
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ResizeVideo(AutomationAgent notebookAutomationAgent)
        {
            int VideoPosX = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "VideoInNotebook", "x")[0]);
            int VideoPosY = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "VideoInNotebook", "y")[0]);
            notebookAutomationAgent.PinchOut(VideoPosX, VideoPosY);
        }
        /// <summary>
        /// Gets width of the video present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int: Width of the video</returns>
        public static int GetWidthOfVideoInNotebook(AutomationAgent notebookAutomationAgent)
        {
            return Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "VideoInNotebook", "width")[0]);
        }
        /// <summary>
        /// Verifies Buttons Present in the Alert Message 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyAlertMessageButtons(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "ContinueButton");
            notebookAutomationAgent.VerifyElementFound("SelectRecipientsView", "CancelButton");
        }
        /// <summary>
        /// Verifies Go to Work Browser Button present in the notebook browser view icon in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyGoToWorkBrowserButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowserView", "GoToWorkBrowserButton");
        }
        /// <summary>
        /// Clicks on the Go to Work Browser Button Present in the notebook browser view icon in the notebook 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickGoToWorkBrowserButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "GoToWorkBrowserButton");
            notebookAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies Work Browser Page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyWorkBrowserPageOpened(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowserView", "WorkBrowserHeader");
        }
        /// <summary>
        /// Verifies Overlay of Work Browser pops up after clicking on notebook browser view icon in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyWorkBrowserOverlayPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowserView", "BrowserNoteOverlay");
        }
        /// <summary>
        /// Verifies X icon present in the Overlay of work browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyBrowserNoteXButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowserView", "BrowserNoteCloseButton");
        }
        /// <summary>
        /// Clicks on the X icon present in the Overlay of work browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickXBrowserNoteXButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "BrowserNoteCloseButton");
            notebookAutomationAgent.WaitForElementToVanish("WorkBrowserView", "BrowserNoteCloseButton");
        }
        /// <summary>
        /// Gets the Coordinated of Desmos present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: width of the desmos thumbnail</returns>
        public static string GetDesmosCoordinate(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookView", "DesmosThumbnail");
        }
        /// <summary>
        /// Moves the Desmos thumbnail present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void MoveDesmosInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookView", "DesmosThumbnailBody", Direction.Left, 10, WaitTime.DefaultWaitTime);
        }

        /// <summary>
        /// Drags the image from a specified coordinate to a specified coordinate
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void EditDesmos(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Drag(1050, 600, 1100, 700, 2000);
            notebookAutomationAgent.Sleep(60000);
        }
        /// <summary>
        /// Gets the modified title and time of the Desmos at which it was created
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static string GetDesmosModifiedTime(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetTextIn("NotebookView", "DesmosThumbnailBody", "inside", "");
        }
        /// <summary>
        /// Verifies the Done button present in the notebook snapshot
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNotebookSnapshotDone(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowser", "NotebookSnapshotDoneButton");
        }
        /// <summary>
        /// Verifies that desmos region is at the center of the notebook page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:- true (if desmos is at the center), false (if desmos is not at the center)</returns>
        public static bool VerifyDesmosAtCenterOfNotebook(AutomationAgent notebookAutomationAgent)
        {
            string NotebookPos = notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "NotebookDrawRegion");
            string[] strArray = NotebookPos.Split(',');
            int NotebookX = Int32.Parse(strArray[0]);
            int NotebookY = Int32.Parse(strArray[1]);
            int NotebookViewInner = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "NotebookViewInner", "x")[0]);
            int NotebookDrawX = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "x")[0]);
            int BorderDiff = NotebookViewInner - NotebookDrawX;
            string ThumbnailPos = notebookAutomationAgent.GetPosition("NotebookView", "DesmosThumbnailBody");
            string[] strArray1 = ThumbnailPos.Split(',');
            int ThumbnailX = Int32.Parse(strArray1[0]);
            int ThumbnailY = Int32.Parse(strArray1[1]);
            if ((NotebookX + (BorderDiff - 1) == ThumbnailX) && (NotebookY + BorderDiff == ThumbnailY))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets the Desmos region's width present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static string GetDesmosSize(AutomationAgent notebookAutomationAgent)
        {
            string[] strArray = notebookAutomationAgent.GetAllValues("NotebookView", "DesmosThumbnailBody", "width");
            return strArray[0];
        }
        /// <summary>
        /// Gets the Position of the Desmos region in the notebook and pinch out with X and Y position
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ResizeDesmosInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            int DesmosPosX = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "DesmosThumbnailBody", "x")[0]);
            int DesmosPosY = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "DesmosThumbnailBody", "y")[0]);
            notebookAutomationAgent.PinchOut(DesmosPosX, DesmosPosY);
        }
        /// <summary>
        /// Clicks on Full screen icon present in the notebook bottom toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickFullScreenIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "FullscreenIcon");
        }
        /// <summary>
        /// Verifies that Notebook is in full screen or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyNotebookFullScreenWindow(AutomationAgent notebookAutomationAgent)
        {
            string WindowSize = notebookAutomationAgent.GetAllValues("NoteBookTouchView", "FullWindow", "width")[0];

            string notebookWindowWidth = "0";
            notebookWindowWidth = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookWidthControl", "width")[0];

            string addPageWindowWidth = "0";
            if(notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "AddPageRegionOfNotebook"))
            {
                addPageWindowWidth = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "AddPageRegionOfNotebook", "width")[0];
            } else {
                addPageWindowWidth = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookWidthControl", "width")[1];
            }
            

            return (Int32.Parse(notebookWindowWidth) + Int32.Parse(addPageWindowWidth) == Int32.Parse(WindowSize)) ? true : false;
        }
        /// <summary>
        /// Gets the notebook Last page number
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int: Current Page Number</returns>
        public static int GetNotebookPage(AutomationAgent notebookAutomationAgent)
        {
            string s = notebookAutomationAgent.GetTextIn("NotebookTopMenuView", "TaskName", "inside", "");
            string[] s1 = s.Split('/');
            int pageNo = Int32.Parse(s1[1].Replace(")\t\n", ""));
            return pageNo;
        }
        /// <summary>
        /// Gets the Notebook page number with current page number
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: notebook page no. with current page no.</returns>
        public static string GetNoteBookPageNosWithCurrentPage(AutomationAgent notebookAutomationAgent)
        {
            string s = notebookAutomationAgent.GetTextIn("NotebookTopMenuView", "TaskName", "inside", "");
            return s.Substring(s.IndexOf('(')).Replace("\n", "").Replace("\t", "");
        }
        /// <summary>
        /// Clicks on Other Grades in Work Browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnOtherGrades(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "OtherGrades");
        }
        /// <summary>
        /// Gets the notebook First page number
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int: Current Page Number</returns>
        public static int GetNotebookFirstPage(AutomationAgent notebookAutomationAgent)
        {
            string s = notebookAutomationAgent.GetTextIn("NotebookTopMenuView", "TaskName", "inside", "");
            string[] s1 = s.Split('(');
            string s2 = s1[1].Replace("\t\n", "");
            string[] s3 = s2.Split('/');
            string s4 = s3[0].Replace("(", "");
            int pageNo = Int32.Parse(s4);
            return pageNo;
        }
        /// <summary>
        /// Verifies Browse Notes Overlay heading 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Browse Notes heading is at top center), false(if result is not as expected)</returns>
        public static bool VerifyOverlayHeading(AutomationAgent notebookAutomationAgent)
        {
            int WindowSize = Int32.Parse(notebookAutomationAgent.GetAllValues("NoteBookTouchView", "ScreenSizeHTML", "width")[0]);

            int XPosBrowseNotes = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowserView", "BrowserNoteOverlay", "x")[0]);
            int YPosBrowseNotes = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowserView", "BrowserNoteOverlay", "y")[0]);
            int widthBrowseOverlay = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowserView", "BrowserNoteOverlay", "width")[0]);


            if ((WindowSize / 2 - 9) == (XPosBrowseNotes + widthBrowseOverlay / 2) && YPosBrowseNotes < 200)
                return true;

            else
                return false;

        }

        /// <summary>
        /// Verifies if current page isn't last page of notebook
        /// Checks if the right arrow icon exists
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyRightArrowExists(AutomationAgent notebookAutomationAgent)
        {
            string[] hidden;
            hidden = notebookAutomationAgent.GetAllValues("NotebookTopMenuView", "RightArrow", "hidden");
            bool hiddenvalue = bool.Parse(hidden[0]);
            if (hiddenvalue == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifies if the notebook contains more than one page and deletes extra pages
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotebookSinglePageAndDeleteAdditionalPages(AutomationAgent notebookAutomationAgent)
        {
            string taskName = GetTaskName(notebookAutomationAgent);
            int startIndex = taskName.IndexOf("/");
            int endIndex = taskName.IndexOf(")");
            string pageNumberStr = taskName.Substring(startIndex + 1, endIndex - startIndex - 1).TrimEnd();
            int pageNumber = Int32.Parse(pageNumberStr);
            if (pageNumber > 1)
            {
                while (notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "RightArrow"))
                {
                    ClickRightArrowIcon(notebookAutomationAgent);
                }
                for (int i = 0; i < pageNumber - 1; i++)
                {
                    DeleteNotebookPage(notebookAutomationAgent);
                }
            }
        }

        /// <summary>
        /// Gets the Position of Desmos thumbnail present in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: position of Desmos Thumbnail</returns>
        public static string GetPositionOfDesmos(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookView", "DesmosThumbnail");
        }
        /// <summary>
        /// Gets the Width of the Desmos thumbnail present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: width of Desmos</returns>
        public static string GetWidthOfDesmos(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetAllValues("NotebookView", "DesmosThumbnail", "width")[0].ToString();
        }
        /// <summary>
        /// Clicks on Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNotebooks(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "Notebooks");
        }
        /// <summary>
        /// Gets the Position of the Video In Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: position of video</returns>
        public static string GetPositionOfVideo(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookView", "VideoInNotebook");
        }
        /// <summary>
        /// Verifies Video is at Center of notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>object: true(if Video is at center of notebook), false(if not)</returns>
        public static bool VerifyVideoAtCenterOfNotebook(AutomationAgent notebookAutomationAgent)
        {
            int windowWidth = int.Parse(notebookAutomationAgent.GetAllValues("NoteBookTouchView", "ScreenSizeHTML", "width")[0]);
            int NotebookPosWidth = int.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookWidthControl", "width")[0]);
            string ThumbnailPos = notebookAutomationAgent.GetPosition("NotebookView", "VideoInNotebook");
            string[] strArray1 = ThumbnailPos.Split(',');
            int ThumbnailX = Int32.Parse(strArray1[0]) - (windowWidth/2);
            int ThumbnailWidth = int.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "VideoInNotebook", "width")[0]);
            if ((NotebookPosWidth / 2) == ThumbnailX)
                return true;
            else
                return false;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyNotebookShareButton(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "ShareIcon");
        }
        /// <summary>
        /// Clicks on Notebook share button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickNotebookShareButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "ShareIcon");
        }
        /// <summary>
        /// Verifies Notebook sharing work flow
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotebookSharingWorkflow(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowserView", "SharingWorkflow");
        }
        /// <summary>
        /// Clicks on Cancel Button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesTopView", "PersonalNoteNameCancel");
        }
        /// <summary>
        /// Clicks on X Icon Present with the Video thubnail to delete it 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnXIcon(AutomationAgent notebookAutomationAgent)
        {
            if (!NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(notebookAutomationAgent))
            {
                NotebookCommonMethods.ClickOnImageInNotebook(notebookAutomationAgent);
            }
            notebookAutomationAgent.Click("NotebookView", "NotebookBoundingRemove");
        }

        public static void ClickOnXIconOnVideo(AutomationAgent notebookAutomationAgent)
        {
            if (!notebookAutomationAgent.IsElementFound("NotebookView", "NotebookBoundingRemove"))
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "VideoThumbnail");
            }
            notebookAutomationAgent.Click("NotebookView", "NotebookBoundingRemove");
        }
        /// <summary>
        /// Verifies the status of Redo button is Active or Inactive
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Redu Button inactie), false(if Redo button active)</returns>
        public static bool VerifyRedoButtonInactive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "RedoIconInactive");
        }
        /// <summary>
        /// Verifies the Don Button is at Upper Left corner
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Done button at top left), false(if not)</returns>
        public static bool VerifyDoneButtonAtUpperLeftCorner(AutomationAgent notebookAutomationAgent)
        {
            int XPosBrowseNotes = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowser", "NotebookSnapshotDoneButton", "x")[0]);
            int YPosBrowseNotes = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowser", "NotebookSnapshotDoneButton", "y")[0]);
            if (XPosBrowseNotes < 20 && YPosBrowseNotes < 60)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Video Watermark is Blue for Video inserted in ELA Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyVideoBlueWaterMark(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "VideoBlueWatermark");
        }
        /// <summary>
        /// Verifies Video Watermark is Green for Video inserted in Math Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyVideoGreenWaterMark(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "VideoGreenWatermark");
        }

        /// <summary>
        /// Verifies Camera and Photos menu are present
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyCameraAndPhotosMenu(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "CameraButton");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "ImageIcon");
        }
        /// <summary>
        /// Clicks on the Math notebook present in the work browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMathNotebookInWorkBrowser(AutomationAgent notebookAutomationAgent)
        {
            int i = 15;
            while (!notebookAutomationAgent.IsElementFound("WorkBrowserView", "MathNotebookInWorkBrowser") && i > 0)
            {
                notebookAutomationAgent.Swipe(Direction.Down, 200, 500);
                i--;
            }
            notebookAutomationAgent.Click("WorkBrowserView", "MathNotebookInWorkBrowser");
        }
        /// <summary>
        /// Verifies All Tools present in the notebook bottom toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyAllNotebookTools(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "FullscreenIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "HandIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "TextIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "PenIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "EraserIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "ImageIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "ToolIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "BackgroundIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "UndoRedoIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "DeleteIcon");
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "FullscreenIcon");
        }
        /// <summary>
        /// Verifies if X icon is present in the image or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyImageXIconPresent(AutomationAgent notebookAutomationAgent)
        {
            if (!notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ImageDeleteIcon"))
            {
                TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
            }
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ImageDeleteIcon");
        }

        public static bool VerifyImageXIconNotPresent(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ImageDeleteIcon"))
            {
                TapOnScreen(notebookAutomationAgent, 1200, 700, 1);
            }
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ImageDeleteIcon");
        }
        /// <summary>
        /// Verifies If Text Icon is Active or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: true(if enabled true), false(if enabled false)</returns>
        public static bool VerifyTextIconActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "TextIconHighlighted");
        }
        /// <summary>
        /// Clicks on Single Page Icon present in the Notebook Bottom Menu Toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickSinglePageIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "SinglePageIcon", "", WaitTime.SmallWaitTime);
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "SinglePageIcon"))
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "SinglePageIcon");
            }
        }

        public static bool VerifySinglePageViewOfNotebookInWorkBrowser(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "FullscreenIcon", "", WaitTime.LargeWaitTime);
            int xPos = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "x")[0]);
            int yPos = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "y")[0]);
            if (xPos == 512 && yPos == 222)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Drawing Icon Sub menus consisting of a box to choose color & thickness of the pencil should appear
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Menu exists), false(if menu doesn't exists)</returns>
        public static bool VerfiyDrawingIconSubmenus(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "DrawingIconPopup");
        }
        /// <summary>
        /// Clicks on Delete Icon present in the notebook bottom toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickDeleteIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "DeleteIcon");
        }
        /// <summary>
        /// Verifies Delete Icon Pop Up consisting of Message, Cancel and Continue Label
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if all conditions met), false(if any condition is not met)</returns>
        public static bool VerifyDeleteIconPopUp(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "DeleteIconPopUp") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "CancelLabel") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ContinueLabel"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Cancel in Delete Icon Pop Up
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelInDeleteIconPopUp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CancelLabel");
        }
        /// <summary>
        /// Clicks on Continue in Delete Icon Pop Up
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickContinueInDeleteIconPopUp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.WaitforElement("NotebookBottomMenuView", "ContinueLabel", "", WaitTime.MediumWaitTime);
            while (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ContinueLabel"))
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "ContinueLabel");
            }
        }
        /// <summary>
        /// Verifies Image Thumbnail present in Notebook or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyImageThumbnailInNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "ImageThumbnail");
        }
        /// <summary>
        /// Clicks on Background Icon in Notebook Bottom Menu toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickBackgroundIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "BackgroundIcon");
        }
        /// <summary>
        /// Verifies the Background tools avaialble in Background Icon in Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if available), false(if not avaialable)</returns>
        public static bool VerifyBackgroundTools(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "BlankBackgroundButton") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "VennBackgroundButton") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "RuledBackgroundButton") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "BigGraphBackgroundButton") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "PenmanshipBackgroundButton") &&
               notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "SmallGraphBackgroundButton"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Selects the Blank Background from the menus
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SelectSmallGraphBackground(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "SmallGraphBackgroundButton");
        }
        /// <summary>
        /// Verifies the Small Graph Background of the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if notebook small graph background avaialble), false(if not available)</returns>
        public static bool VerifySmallGraphNotebookBackground(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookSmallGraphBackground");
        }
        /// <summary>
        /// Clicks on Blank Baground Option
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SelectBlankBackground(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "BlankBackgroundButton");
        }
        /// <summary>
        /// Verifies the Submenu Of Eraser Icon 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if submenu available), false(if not available)</returns>
        public static bool VerifyEraseIconSubMenu(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ClearPage");
        }
        /// <summary>
        /// Verifies Snapshot Message 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifySnapshotSavedMessage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "SnapshotSavedMessage");
            notebookAutomationAgent.VerifyElementFound("NotebookView", "SnapshotMessageBody");
        }
        /// <summary>
        /// Clicks on Continue Button 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickSendToNotebookContinueButton(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            if (notebookAutomationAgent.WaitforElement("InteractiveView", "SendToNotebookContinue", "", WaitTime.LargeWaitTime))
            {
                notebookAutomationAgent.Click("InteractiveView", "SendToNotebookContinue");
                notebookAutomationAgent.Sleep(2000);
            }
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Clicks on Interactive Present in Lesson Task 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void OpenInteractive(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("InteractiveView", "InteractiveInLessonTask");
            notebookAutomationAgent.Sleep(WaitTime.MediumWaitTime);
        }

        /// <summary>
        /// Drag the element from one place to another
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void EditInteractive(AutomationAgent notebookAutomationAgent, int x, int y, int clickcount)
        {
            notebookAutomationAgent.Sleep(1000);
            notebookAutomationAgent.ClickOnScreen(x, y, clickcount);
            notebookAutomationAgent.SendText("test edit");
            notebookAutomationAgent.Sleep(6000);
        }

        /// <summary>
        /// Verifies if interactive is open or not ?
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Interactive page is open), false(if interactive page is not open)</returns>
        public static bool VerifyInteractivePageOpen(AutomationAgent notebookAutomationAgent)
        {
            return bool.Parse(notebookAutomationAgent.GetElementProperty("InteractiveView", "InteractivePage", "onScreen", 0));
        }

        /// <summary>
        /// Verifies that Interactive thumbnail is at the center of the notebook page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:- true (if interactive thumbnail is at the center), false (if interactive thumbnail is not at the center)</returns>
        public static bool VerifyInteractiveAtCenterOfNotebook(AutomationAgent notebookAutomationAgent)
        {
            string NotebookPos = notebookAutomationAgent.GetPosition("NotebookBottomMenuView", "NotebookDrawRegion");
            string[] strArray = NotebookPos.Split(',');
            int NotebookX = Int32.Parse(strArray[0]);
            int NotebookY = Int32.Parse(strArray[1]);
            int NotebookViewInner = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "NotebookViewInner", "x")[0]);
            int NotebookDrawX = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "x")[0]);
            int BorderDiff = NotebookViewInner - NotebookDrawX;
            string ThumbnailPos = notebookAutomationAgent.GetPosition("NotebookView", "InteractiveThumbnail");
            string[] strArray1 = ThumbnailPos.Split(',');
            int ThumbnailX = Int32.Parse(strArray1[0]);
            int ThumbnailY = Int32.Parse(strArray1[1]);
            if ((NotebookX + (BorderDiff - 1) == ThumbnailX) && (NotebookY + BorderDiff == ThumbnailY))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Selects the Recipient named Altagracia
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void SelectTeacherRecipient(AutomationAgent notebookAutomationAgent, string teacher)
        {
            notebookAutomationAgent.Click("AnnotationMenuView", "Teacher", teacher);
        }
        /// <summary>
        /// Adds the message during sharing any notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="message">AutomationAgent object</param>
        public static void AddMessage(AutomationAgent notebookAutomationAgent, string message)
        {
            notebookAutomationAgent.SendText(message);
        }
        /// <summary>
        /// Verifies Work Will be sent message and clicks on OK button in the Message
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void VerifyWokWillBeSentMessage(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "WorkWillBeSentMessage", WaitTime.LargeWaitTime))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }
        }
        /// <summary>
        /// Verifies the Work is sent message 
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void VerifyWorkSentMessage(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitForElement("AnnotationMenuView", "WorkSentMessage"))
            {
                notebookAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }
        }
        /// <summary>
        /// Verifies all the edit menus present
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if all menus are present), false(if any of the menu is not present)</returns>
        public static bool VerifyAllEditMenus(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "CutMenu") &&
               notebookAutomationAgent.IsElementFound("NotebookView", "CopyMenu") &&
               notebookAutomationAgent.IsElementFound("NotebookView", "PasteMenu") &&
               notebookAutomationAgent.IsElementFound("NotebookView", "DefineMenu")
              )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Common Reads Link present in Drop Down Menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCommonReads(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "CommonReadsInMyClass");
        }

        public static DateTime GetPersonalNoteTitleTime(String NotesDefaultTitle)
        {
            NotesDefaultTitle = NotesDefaultTitle.Replace("My Personal Note ", "");
            //NotesDefaultTitle = NotesDefaultTitle.Remove(NotesDefaultTitle.Length - 3, 3);
            //string[] dateAndTime = NotesDefaultTitle.Split(' ');
            //string[] dateComponents = dateAndTime[0].Split('-');
            //string[] timeComponents = dateAndTime[1].Split(':');
            //DateTime titleDate = new DateTime(Int32.Parse(dateComponents[2]), Int32.Parse(dateComponents[1]), Int32.Parse(dateComponents[0]),
            //    Int32.Parse(timeComponents[0]), Int32.Parse(timeComponents[1]), 0);
            DateTime titleDate = DateTime.Parse(NotesDefaultTitle);
            return titleDate;
        }
        /// <summary>
        /// Clicks on the Cancel Button While taking Snapshot
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelSnapShot(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "SnapshotCancelButton");
        }
        /// <summary>
        /// Clicks on Interactive thumbnail present in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickInteractiveThumbnail(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "InteractiveThumbnail");
            notebookAutomationAgent.Sleep();
        }


        public static void ClickInteractiveThumbnailWithTwoThumbnails(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "InteractiveThumbnail");
            notebookAutomationAgent.Sleep();
            if (notebookAutomationAgent.IsElementFound("NotebookView", "InteractiveThumbnail"))
            {
                notebookAutomationAgent.Click("NotebookView", "InteractiveThumbnail");
                notebookAutomationAgent.Click("NotebookView", "InteractiveThumbnail");
                notebookAutomationAgent.WaitForElementToVanish("NotebookView", "InteractiveThumbnail");
            }
        }

        /// <summary>
        /// Verifies if Interactive thumbnail is present or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyInteractiveThumbnailPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "InteractiveThumbnail");
        }
        /// <summary>
        /// Verifies if Task Notebooks button is active in browse notes overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>String:true(when enabled), false(if not enabled)</returns>
        public static string VerifyTaskNotebooksButtonActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("WorkBrowserView", "TaskNotebookInBrowseNotes", "enabled");
        }
        /// <summary>
        /// Verify if Task Notebooks button is present.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyTaskNotebooksButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowserView", "TaskNotebookInBrowseNotes");
        }
        /// <summary>
        /// Verify if Personal Notes button is present.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPersonalNotesButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "PersonalNotesLink");
        }
        /// <summary>
        /// Verify that My Notebook and Received notebook tile are present in Task Notebooks.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyTaskNotebooksElements(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "MyNotebookInTaskNotebooks");
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "RecievedNotebooksInTaskNotebooks");
        }
        /// <summary>
        /// Verify Task Title in Task Notebooks
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>String object: title</returns>
        public static string GetTaskTitleInTaskNotebooks(AutomationAgent notebookAutomationAgent)
        {
            string[] s = notebookAutomationAgent.GetTextIn("NotebookWorkBrowserView", "TaskNotebooksHeaderView", "inside", "").Split('\t');
            return s[0];
        }
        /// <summary>
        /// Gets the My Notebook Title from Browse Notes Overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static string GetMyNotebookTitle(AutomationAgent notebookAutomationAgent)
        {
            string s = notebookAutomationAgent.GetTextIn("LessonBrowserView", "MyNoteBookCell", "inside", "");
            return s;
        }
        /// <summary>
        /// Verify Header colour is blue 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if blue color header), false(header color not blue)</returns>
        public static bool VerifyNotebookHeaderColorBlue(AutomationAgent notebookAutomationAgent)
        {
            string s = notebookAutomationAgent.GetElementProperty("LessonBrowserView", "BackgroundColor", "backgroundColor");
            if (s == "0x0031C3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ResizeSnapshotGrid(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("TasksTopMenuView", "SnapShotGridResize", Direction.Right, 0, 2000);
        }

        public static int GetWidthofSnapshotGrid(AutomationAgent notebookAutomationAgent)
        {
            string[] width = notebookAutomationAgent.GetAllValues("TasksTopMenuView", "SnapShotGridView", "width");
            return Int32.Parse(width[0]);
        }

        public static string GetSnapshotGridPosition(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("TasksTopMenuView", "SnapShotGridView");
        }

        public static void SwipeSnapshotGrid(AutomationAgent notebookAutomationAgent, int offset = 500)
        {
            notebookAutomationAgent.Swipe(Direction.Left, offset);
        }
        /// <summary>
        /// Verifies Cancel button in Alert Message
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if cancel button found), false(not found)</returns>
        public static bool VerifyCancelButton(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("SelectRecipientsView", "CancelButton");

        }
        /// <summary>
        /// Verifies Continue button in Alert Message
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if continue button found), false(not found)</returns>
        public static bool VerifyContinueButton(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("CommonReadAnnotationsPanelView", "ContinueButton");
        }
        /// <summary>
        ///  Verifies Tools Menu PopUp
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if ToolsMenuPopUp button found), false(not found)</returns>
        public static bool VerifyToolsMenuPopUp(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "ToolsMenuPopUp");
        }
        /// <summary>
        /// Verifies only one current task notebook tile exists in top left of tile container wrapper
        /// </summary>
        /// <param name="notebookAutomationAgent">AtuomationAgent object</param>
        /// <returns>current task found result</returns>
        public static bool VerifyMyNotebookTileExists(AutomationAgent notebookAutomationAgent, out string failureMessage)
        {
            bool result = true;
            failureMessage = string.Empty;
            if (!notebookAutomationAgent.IsElementFound("LessonBrowserView", "MyNoteBookCell"))
            {
                failureMessage = "My Notebook Tile is not found.";
                result = false;
            }
            else
            {
                if (!(notebookAutomationAgent.GetElementCount("LessonBrowserView", "MyNoteBookCell") == 1))
                {
                    failureMessage = " More than one My Notebook Tile found";
                    result = false;
                }
                int notebookTileX = int.Parse(notebookAutomationAgent.GetElementProperty("LessonBrowserView", "MyNoteBookCell", "X"));
                int notebookTileY = int.Parse(notebookAutomationAgent.GetElementProperty("LessonBrowserView", "MyNoteBookCell", "Y"));
                int wrapperHeight = int.Parse(notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "NotesCollectionWrapper", "height"));
                int wrapperWidth = int.Parse(notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "NotesCollectionWrapper", "width"));
                int wrapperX = int.Parse(notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "NotesCollectionWrapper", "X"));
                int wrapperY = int.Parse(notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "NotesCollectionWrapper", "Y"));
                if (notebookTileX > wrapperX + (wrapperWidth / 4) || notebookTileY > wrapperY + (wrapperHeight / 4))
                {
                    failureMessage = "My Notebook Tile is not found Top Left of the Tile container wrapper";
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Clicks on My Notebook Tile in the Notebook browser
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        public static void ClickMyNotebookTile(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.WaitforElement("LessonBrowserView", "MyNoteBookCell", "", WaitTime.MediumWaitTime))
            {
                notebookAutomationAgent.Click("LessonBrowserView", "MyNoteBookCell");
            }

        }
        /// <summary>
        /// Gets the number of received books within the paranthesis from the title in the Notebook browser
        /// </summary>
        /// <param name="notebookAutomationAgent">Autoamtion Agent object</param>
        /// <returns></returns>
        public static int GetNumerOfReceivedBooksFromTitle(AutomationAgent notebookAutomationAgent)
        {
            string receivedNoteBooksTitle = notebookAutomationAgent.GetElementText("NotebookWorkBrowserView", "RecievedNotebooksInTaskNotebooks");
            return int.Parse(receivedNoteBooksTitle.Substring(receivedNoteBooksTitle.IndexOf('(') + 1, (receivedNoteBooksTitle.Length - 2) - receivedNoteBooksTitle.IndexOf('(')));
        }

        /// <summary>
        /// Verifies the No Received notebooks text in the notebook browser
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>Whether the No received notebooks text is found</returns>
        public static bool VerifyNoReceivedNotebooksText(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookWorkBrowserView", "NoReceivedNotebooksText");
        }

        /// <summary>
        /// Verifies the Number of received books in the title against number of tiles available
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>Whether the number in title is greater than or equal to number of tiles available</returns>
        public static bool VerifyNumerOfReceivedBooksFromTitle(AutomationAgent notebookAutomationAgent)
        {
            return GetNumerOfReceivedBooksFromTitle(notebookAutomationAgent) >= notebookAutomationAgent.GetElementCount("NotebookWorkBrowserView", "TaskNotebookCell");
        }

        /// <summary>
        /// Verifies sender info UIViews in notebook browser overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>Whether the number in title is greater than or equal to number of Greeting UIViews available</returns>
        public static bool VerifySenderInfoInTiles(AutomationAgent notebookAutomationAgent)
        {
            return GetNumerOfReceivedBooksFromTitle(notebookAutomationAgent) >= notebookAutomationAgent.GetElementCount("NotebookWorkBrowserView", "GreetingUIView");
        }

        public static string GetTitleTaskOfInteractiveInNotebook(AutomationAgent notebookAutomationAgent)
        {
            string s = notebookAutomationAgent.GetTextIn("NotebookView", "NoteBookGraphingTitle", "inside", "");
            return s.Replace("\t\n", "");
        }

        /// <summary>
        /// Selects recipients names in the notebook share
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <param name="recipientsNames">params string array of recipients names</param>
        public static void SelectRecipientsForShare(AutomationAgent notebookAutomationAgent, params string[] recipientsNames)
        {
            foreach (string recipientName in recipientsNames)
            {
                notebookAutomationAgent.WaitforElement("SelectRecipientsView", "RecipientRow", recipientName, WaitTime.LargeWaitTime);
                notebookAutomationAgent.Click("SelectRecipientsView", "RecipientRow", recipientName);
            }
        }

        /// <summary>
        /// Verifies No Wifi message controls available
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>boolean status of contols availability</returns>
        public static bool VerifyNoWifiMessageOnTapToDownload(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowserView", "NetworkAwareButton") && notebookAutomationAgent.IsElementFound("WorkBrowserView", "NoWifiTileImage");
        }

        /// <summary>
        /// Clicks on Tap to download button
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        public static void ClickOnTapToDownload(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("WorkBrowserView", "TileTapToDownload"))
            {
                notebookAutomationAgent.Click("WorkBrowserView", "TileTapToDownload");
            }
        }
        /// <summary>
        /// Verifies Downloading in progress status for a received notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>boolean status of downloading in progress controls for a received notebook</returns>
        public static bool VerifyReceivedNBDownloadInProgress(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowserView", "DownloadProgressBar") && notebookAutomationAgent.IsElementFound("WorkBrowserView", "DownloadingLabel");
        }

        public static void ClickOnTaskNotebooksButtoninBrowseNotes(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "TaskNotebookInBrowseNotes");
        }

        public static bool VerifyPersonalNoteCreateTile(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("PersonalNotesView", "PersonalNoteCreateNote");
        }
        /// <summary>
        /// Verfies Done Button In Newly Created Desmos
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>bool</returns>
        public static bool VerifyDoneButtonInNewlyCreatedDesmos(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "DoneBtnNewDesmos");
        }
        /// <summary>
        /// Click on the Interactive added to notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        public static void ClickOnNoteBookRegionPanel(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookRegionPanel", 1);

        }
        /// <summary>
        /// Add Text In Interactive 
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        public static void AddTextInInteractive(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "PlusIconOnInteractive");
            notebookAutomationAgent.Click("NotebookTopMenuView", "ClickToEnterTextInteractive", "text");
            notebookAutomationAgent.SendText("Test");
        }
        /// <summary>
        /// Verifies Previous Value is Present IN Interactive
        /// </summary>
        /// <param name="notebookAutomationAgent"></param>
        /// <param name="SentTextInteractive">Automation Agent object</param>
        /// <returns>bool</returns>
        public static bool VerifyPreviousValuePresent(AutomationAgent notebookAutomationAgent, string SentTextInteractive)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "ClickToEnterTextInteractive", "Test");
        }

        /// <summary>
        /// Verifies Desmos Graphic Calculator Tool Open
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <returns>bool</returns>
        public static bool VerifyDesmosGraphicCalculatorToolOpen(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "GraphingToolTitleBar");
        }

        /// <summary>
        /// Add new text to interactive
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        public static void AddNewValueInteractive(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "PlusIconOnInteractive");
            notebookAutomationAgent.Click("NotebookTopMenuView", "ClickToEnterTextInteractive", "text");
            notebookAutomationAgent.SendText("NewValue");
        }

        /// <summary>
        /// Verifies New Value added to interactive is present
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation Agent object</param>
        /// <param name="NewSendTextInteractive"></param>
        /// <returns>bool</returns>
        public static bool VerifyModifiedNewValuePresent(AutomationAgent notebookAutomationAgent, string NewSendTextInteractive)
        {
            return notebookAutomationAgent.IsElementFound("NotebookTopMenuView", "ClickToEnterTextInteractive", "NewValue");
        }

        /// <summary>
        /// Verify Last modified time is present
        /// </summary>
        /// <param name="time">Automation Agent object</param>
        /// <returns>bool</returns>
        public static bool VerifyLastModifiedTime(string time)
        {
            return time.StartsWith("Last Modified") && (time.EndsWith("am") || time.EndsWith("pm"));
        }
        /// <summary>
        /// Click on Othe Grades under my work
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SelectOtherGrades(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "SelectOtherGradesMyWork");
        }
        /// <summary>
        /// Click sent in notebook bottom tile
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickSentInNotbookBottomTile(AutomationAgent notebookAutomationAgent)
        {

            for (int i = 1; i < 5; i++)
            {
                if (notebookAutomationAgent.IsElementFound("WorkBrowserView", "ClickSentInNotebookTile"))
                {
                    notebookAutomationAgent.Click("WorkBrowserView", "ClickSentInNotebookTile");
                    break;
                }
                else
                {
                    notebookAutomationAgent.Swipe(Direction.Down, 500);
                }
            }
        }
        /// <summary>
        /// Verify Sent Work Is centered
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if object centered)</returns>
        public static bool VerifySentWorkLabelCentered(AutomationAgent notebookAutomationAgent)
        {
            int screenwidth = Int32.Parse(notebookAutomationAgent.GetAllValues("LessonBrowserView", "LessonBrowserPageTitle", "width")[0]);

            string pos = notebookAutomationAgent.GetPosition("WorkBrowserView", "SentWorkOverlay");
            string[] position = pos.Split(',');
            int ControlCenterpos = Int32.Parse(position[0]);

            if ((ControlCenterpos - screenwidth / 2) < 20)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Click close in sent work overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickCloseButtonInSentWorkOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowserView", "ClickCloseInSentWorkOverlay");
        }
        /// <summary>
        /// Verify X Icon in image is Present or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyXIconPresent(AutomationAgent notebookAutomationAgent)
        {
            if (!notebookAutomationAgent.IsElementFound("NotebookView", "NotebookBoundingRemove"))
            {
                ClickInteractiveThumbnail(notebookAutomationAgent);
            }
        }

        public static void VerifyXIconPresentOnVideo(AutomationAgent notebookAutomationAgent)
        {
            if (!notebookAutomationAgent.IsElementFound("NotebookView", "NotebookBoundingRemove"))
            {
                notebookAutomationAgent.ClickOnScreen(1200, 650);
            }
        }
        /// <summary>
        /// Get the name of the task from browser overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present)</returns>
        public static string GetNameOfTask(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetTextIn("NotebookView", "TaskNameInOverlay", "Inside", "", "NATIVE", 0, 0, 0);
        }
        /// <summary>
        /// Verify X Icon Present In Image
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyXIconPresentInImage(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "NotebookBoundingRemove"))
            {

            }
            else
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "HandIcon");
                notebookAutomationAgent.Sleep(2000);
                notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageInNotebookXIcon");
                notebookAutomationAgent.Sleep(2000);
            }
        }
        /// <summary>
        /// Click on Sec34 Tile
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickSec34Tile(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "Sec34Per5InMyClass");
        }
        /// <summary>
        /// Click On ELA Notebook In WorkBrowser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnELANotebookInWorkBrowser(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            int i = 15;
            while (!notebookAutomationAgent.IsElementFound("WorkBrowserView", "ELANotebookInWorkBrowser") && i > 0)
            {
                notebookAutomationAgent.Swipe(Direction.Down, 200, 500);
                i--;
            }
            notebookAutomationAgent.Click("WorkBrowserView", "ELANotebookInWorkBrowser");
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "ChooseNotebook", "", WaitTime.MediumWaitTime);
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }
        /// <summary>
        /// Verify Ruled Graph Notebook Background
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyRuledGraphNotebookBackground(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookRuledGraphBackground");
        }
        /// <summary>
        /// Selects the Ruled Background from the menus
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SelectRuledGraphBackground(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "ChooseNotebookRuledBackground");
        }
        /// <summary>
        /// Verify Interactive Page is present or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyInteractivePageIsOpened(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("InteractiveView", "DoneButtonInInteractive");
        }
        /// <summary>
        /// Verify X Icon Present In Full Screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyXIconPresentInFullScreen(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "NotebookBoundingRemove"))
            {

            }
            else
            {
                notebookAutomationAgent.Click("NotebookBottomMenuView", "HandIcon");
                notebookAutomationAgent.Sleep(2000);
                notebookAutomationAgent.ClickCoordinate(266, 604, 1);
                notebookAutomationAgent.Sleep(2000);
            }
        }
        /// <summary>
        /// Verify Line Image Exists In NB
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyLineImageExistsInNB(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookLineDraw");
        }
        /// <summary>
        /// Draw Line In Notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="startingX1">X1</param>
        /// <param name="startingY1">Y1</param>
        public static void DrawLineInNotebook(AutomationAgent notebookAutomationAgent, int startingX1, int startingY1)
        {
            notebookAutomationAgent.DrawLineImage(startingX1, startingY1);

        }

        public static void ClickOnMyPersonalNoteTile(AutomationAgent notebookAutomationAgent, bool selectOnCloudNotebook = false)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "MyPersonalNotes");
            notebookAutomationAgent.WaitforElement("ConflictResolutionPopUp", "ChooseNotebook", "", WaitTime.MediumWaitTime);
            if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
            else if (notebookAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(notebookAutomationAgent);
            }
        }
        /// <summary>
        /// Verifies View In lesson in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent"></param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyViewInLessonButton(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("WorkBrowserView", "ViewInLessonButton");
        }
    }
}
