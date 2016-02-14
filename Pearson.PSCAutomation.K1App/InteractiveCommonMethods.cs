using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;



namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class InteractiveCommonMethods
    {
        /// <summary>
        /// Verify the UI Of Interactive
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation object</param>
        public static bool VerifyUIelementsOfInteractive(AutomationAgent notebookAutomationAgent)
        {
            int xBackButton = Int32.Parse(notebookAutomationAgent.GetAllValues("eReaderView", "GoBackButton", "x")[0]);
            int XSendtoNotebookbutton = Int32.Parse(notebookAutomationAgent.GetAllValues("UnitSelection", "SaveToNotebookButton", "x")[0]);

            if (xBackButton < XSendtoNotebookbutton && notebookAutomationAgent.IsElementFound("MediaLibrary", "InteractiveTitle"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Click on the send to notebook button
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation object</param>
        public static void ClickOnSendToNotebookButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("UnitSelection", "SaveToNotebookButton");
        }
        /// <summary>
        /// Verify the UI elements Of send to notebook pop up 
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation object</param>
        public static void VerifyUIElementsOfSendToNotebookPopUp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
            notebookAutomationAgent.VerifyElementFound("UnitSelection", "AcceptLogOut");
            notebookAutomationAgent.VerifyElementFound("UnitSelection", "SaveToNotebookButton");
        }
        /// <summary>
        /// Verify interactive header 
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyInteractiveHeader(AutomationAgent InteractiveAutomationAgent)
        {
            string text = InteractiveAutomationAgent.GetAllValues("MediaLibrary", "InteractiveTitle", "text")[0];
            if (text.Equals("Interactive"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify send to notebook button in interactive
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySendToNotebookButton(AutomationAgent InteractiveAutomationAgent)
        {
            return InteractiveAutomationAgent.IsElementFound("UnitSelection", "SaveToNotebookButton");
        }
        /// <summary>
        /// Verify body of interactive
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        public static void VerifyBodyOfInteractive(AutomationAgent InteractiveAutomationAgent)
        {
            InteractiveAutomationAgent.VerifyElementFound("UnitSelection", "InteractiveBody");
        }

        /// <summary>
        /// Get dragabble element count
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        /// <returns></returns>
        public static int GetDragableElementCount(AutomationAgent InteractiveAutomationAgent)
        {
            InteractiveAutomationAgent.WaitforElement("WEB", "MediaLibrary", "InteractiveDragabbleElementCount", "", WaitTime.DefaultWaitTime);
            return InteractiveAutomationAgent.GetElementCount("WEB", "MediaLibrary", "InteractiveDragabbleElementCount", "");
        }

        /// <summary>
        /// Verify draggable elements of interactive
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        /// <param name="dragableElementCount">element count which need to be verify</param>
        public static bool VerifyDraggableElement(AutomationAgent InteractiveAutomationAgent, int dragableElementCount)
        {
            return dragableElementCount.Equals(InteractiveAutomationAgent.GetElementCount("WEB", "MediaLibrary", "InteractiveDragabbleElementCount", ""));
        }

        /// <summary>
        /// Verify thumbnail selected at notebook canvas when sending interactive to notebook
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        /// <returns>True: if thumbnail is in selected state</returns>
        public static bool VerifyThumbnailSelectedState(AutomationAgent InteractiveAutomationAgent)
        {
            InteractiveAutomationAgent.VerifyElementFound("NotebookView", "RemoveButton");
            return (InteractiveAutomationAgent.GetAllValues("NotebookView", "InteractiveInNotebook", "top")[0]).Equals("true");
        }

        /// <summary>
        /// Verify back button at intercative screen 
        /// </summary>
        /// <param name="notebookAutomationAgent">Automation object</param>
        public static void VerifyBackButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("eReaderView", "GoBackButton");
        }

        /// <summary>
        /// Verify that when the interactive is added to notebook, the file name and timestamp information below the interactive thumbnail DOES NOT exist
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        /// <returns>true: when timestamp does not display</returns>
        public static bool VerifyTimeStampDoenNotExistBelowSnapshot(AutomationAgent InteractiveAutomationAgent)
        {
            string textBelowStamp = InteractiveAutomationAgent.GetTextIn("NotebookView", "InteractiveInNotebook", "Down", "");
            return (!textBelowStamp.Contains("Interactive:") && !textBelowStamp.Contains("Last Modified:"));
        }

        /// <summary>
        /// Verify send to notebbok confirmation popup
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        public static void VerifySendtoNotebookConfirmationPopup(AutomationAgent InteractiveAutomationAgent)
        {
            InteractiveAutomationAgent.VerifyElementFound("UnitSelection", "AcceptLogOut");
            InteractiveAutomationAgent.VerifyElementFound("NotebookView", "AddIconConfirm");
            InteractiveAutomationAgent.VerifyElementFound("NotebookView", "AddToNotebookLabel");
            InteractiveAutomationAgent.VerifyElementFound("NotebookView", "DeletePopup");
        }

        /// <summary>
        /// Drag interactive to container
        /// </summary>
        /// <param name="InteractiveAutomationAgent">Automation object</param>
        public static void DragInteractiveElementToContainer(AutomationAgent BackPackAutomationAgent)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "InteractiveDragabbleElementCount", "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "InteractiveDragabbleElementCount", "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "InteractiveDragabbleElementCount", "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "InteractiveDragabbleElementCount", "height"))[0]);

            int xCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("NotebookView", "InteractiveContainer", "x"))[0]);
            int yCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("NotebookView", "InteractiveContainer", "y"))[0]);
            int widthOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("NotebookView", "InteractiveContainer", "width"))[0]);
            int heightOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("NotebookView", "InteractiveContainer", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(5000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfBP + (widthOfBP / 2), yCoordinateOfBP + (heightOfBP / 2), 2000);
        }

        /// <summary>
        /// Verify intercative player is open
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">Automation object</param>
        public static void VerifyInteractivePlayer(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "InteractivePlayer");
        }

        public static bool VerifyGamePausedCanvas(AutomationAgent MediaLibraryAutomationAgent)
        {
            return MediaLibraryAutomationAgent.IsElementFound("UnitSelection", "InteractiveCanvas");
        }
    }
}
