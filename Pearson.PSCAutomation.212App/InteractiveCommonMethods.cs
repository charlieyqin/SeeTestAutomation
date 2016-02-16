using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public class InteractiveCommonMethods
    {
        /// <summary>
        /// Clicks on Interactive Thumbnail present in the Math's Task
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickOnInteractiveThumbnailMathTask(AutomationAgent interactiveAutomationAgent)
        {

            interactiveAutomationAgent.Click("InteractiveView", "InteractiveThumbnailInMathTask");
            //interactiveAutomationAgent.ClickOnScreen(1050, 400);
            //interactiveAutomationAgent.ClickOnScreen(1050, 400);
            interactiveAutomationAgent.ClickOnScreen(200, 200);
            interactiveAutomationAgent.Sleep(4000);
        }
        /// <summary>
        /// Verifies App Chrome is visible or not
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if app chrome is visible), false(if not)</returns>
        public static bool VerifyInteractiveAppChromeVisible(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Sleep();
            string onScreen = interactiveAutomationAgent.GetElementProperty("InteractiveView", "AppChrome", "onScreen");
            return bool.Parse(onScreen);


        }
        /// <summary>
        /// Verifies Done Button at Top Left Position
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Done button at the top Left), false(if not)</returns>
        public static bool VerifyTopLeftDoneButton(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.VerifyElementFound("InteractiveView", "DoneButtonInInteractive");
            int XPosBrowseNotes = Int32.Parse(interactiveAutomationAgent.GetAllValues("InteractiveView", "DoneButtonInInteractive", "x")[0]);
            int YPosBrowseNotes = Int32.Parse(interactiveAutomationAgent.GetAllValues("InteractiveView", "DoneButtonInInteractive", "y")[0]);
            if (XPosBrowseNotes < 20 && YPosBrowseNotes < 60)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Save to notebook Button avaialble in the app chrome or not
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if available), false(if not avaialable)</returns>
        public static bool VerifySendToNotebookIconAtTopRight(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.VerifyElementFound("InteractiveView", "SaveToNotebookButton");
            int xPos = Int32.Parse(interactiveAutomationAgent.GetAllValues("InteractiveView", "SaveToNotebookButton", "x")[0]);
            int yPos = Int32.Parse(interactiveAutomationAgent.GetAllValues("InteractiveView", "SaveToNotebookButton", "y")[0]);
            if (xPos == 1910 && yPos == 58)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Done Button present in the interactive
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickOnInteractiveDoneButton(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Click("InteractiveView", "DoneButtonInInteractive");
            interactiveAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies Lesson Task page available or not
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if available), false(if not available)</returns>
        public static bool VerifyLessonTaskPage(AutomationAgent interactiveAutomationAgent)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "LessonTaskChromeBar");
        }
        /// <summary>
        /// Clicks on Teacher Mode icon present at the Top
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeIcon(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Click("TasksTopMenuView", "TeacherModeIcon");
        }
        /// <summary>
        /// Verifies if Teacher Mode open or closed
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if closed)</returns>
        public static bool VerifyTeacherModeOpen(AutomationAgent interactiveAutomationAgent)
        {
            return interactiveAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeOpened");
        }
        /// <summary>
        /// Verifies Interactive is open or not
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Interactive is open), false(if interactive is closed)</returns>
        public static bool VerifyInteractiveOpen(AutomationAgent interactiveAutomationAgent)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "DoneButtonInInteractive");
        }

        /// <summary>
        /// Opens Interactive by clicking on Interactive Thumbnail present in the ELA Task
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void OpenInteractive(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Click("InteractiveView", "InteractiveThumbnailInELATask");
            interactiveAutomationAgent.Sleep();
        }
        /// <summary>
        /// Mark and Unmark the Box present in the interactive
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void MarkBoxInInteractive(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.ClickOnScreen(1726, 510, 1);
        }
        /// <summary>
        /// Clicks on the send to Notebook icon
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickSendToNotebookIcon(AutomationAgent interactiveAutomationAgent, bool selectOnCloudNotebook = false)
        {
            interactiveAutomationAgent.Click("InteractiveView", "SaveToNotebookButton");
            interactiveAutomationAgent.Sleep();
            if (interactiveAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                NotebookCommonMethods.SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(interactiveAutomationAgent);
            }
            else if (interactiveAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                NotebookCommonMethods.SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(interactiveAutomationAgent);
            }
        }
        /// <summary>
        /// Verifies the Save Interactive Pop up consisting of cancel and continue button 
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void VerifySaveInteractivePopUp(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.VerifyElementFound("InteractiveView", "SaveInteractivePopUpLabel");
            interactiveAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "CancelLabel");
            interactiveAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "ContinueButton");
        }
        /// <summary>
        /// Clicks on Continue Button present in the Save Interactive pop up 
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickContinue(AutomationAgent interactiveAutomationAgent, bool selectOnCloudNotebook = false)
        {
            interactiveAutomationAgent.Click("InteractiveView", "InteractiveOkaybutton");
            interactiveAutomationAgent.Sleep();
            if (interactiveAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && !selectOnCloudNotebook)
            {
                NotebookCommonMethods.SelectOnIpadNotebookAndContinueInConflictResolutionPopUp(interactiveAutomationAgent);
            }
            else if (interactiveAutomationAgent.IsElementFound("ConflictResolutionPopUp", "ChooseNotebook") && selectOnCloudNotebook)
            {
                NotebookCommonMethods.SelectOnCloudNotebookAndContinueInConflictResolutionPopUp(interactiveAutomationAgent);
            }
        }
        /// <summary>
        /// Verifies id Send To Notebook Icon is present or not
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySendToNotebookIconPresent(AutomationAgent interactiveAutomationAgent)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "SaveToNotebookButton");
        }
        /// <summary>
        /// Clicks on Cancel button present in the save interactive pop up 
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void ClickCancel(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Click("NotebookBottomMenuView", "CancelLabel");
        }

        /// <summary>
        /// Edits Math Interactive
        /// </summary>
        /// <param name="interactiveAutomationAgent">AutomationAgent object</param>
        public static void EditMathInteractive(AutomationAgent interactiveAutomationAgent, bool revert = false)
        {

            if (revert)
            {
                interactiveAutomationAgent.Drag(800, 600, 800, 200, 2000);
            }
            else
            {
                interactiveAutomationAgent.Drag(800, 200, 800, 600, 2000);
            }
        }

        /// <summary>
        /// Get X coordinate of Equation
        /// </summary>
        /// <param name="interactiveAutomationAgent"></param>
        /// <returns></returns>
        public static int GetXCoordinateOfEquation(AutomationAgent interactiveAutomationAgent, string index)
        {
            return interactiveAutomationAgent.GetElementProperty("InteractiveView", "InteractiveEquation", "x", index, WaitTime.SmallWaitTime)[0];
        }

        public static bool VerifyEditedInteractiveState(AutomationAgent interactiveAutomationAgent)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "InteractiveEquation");
        }

        public static void DropItemInArea(AutomationAgent interactiveAutomationAgent, string itemId, string areaId)
        {
            interactiveAutomationAgent.DragAndDrop("InteractiveView", "Item", itemId, "InteractiveView", "DroppableArea", areaId);
        }


        public static bool VerifyItemInDropArea1(AutomationAgent interactiveAutomationAgent, string itemId)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "ItemInDroppableArea1", itemId);
        }

        public static bool VerifyItemInDropArea2(AutomationAgent interactiveAutomationAgent, string itemId)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "ItemInDroppableArea2", itemId);
        }

        public static bool VerifyItemInDropArea3(AutomationAgent interactiveAutomationAgent, string itemId)
        {
            return interactiveAutomationAgent.IsElementFound("InteractiveView", "ItemInDroppableArea3", itemId);
        }

        public static void ClosePopUp(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Click("InteractiveView", "PopUpClose");
        }

        public static void ClickResetButton(AutomationAgent interactiveAutomationAgent)
        {
            interactiveAutomationAgent.Click("InteractiveView", "ResetButton");
        }
    }
}
