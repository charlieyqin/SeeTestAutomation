using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Pearson.PSCAutomation.K1App
{

    public class NotebookCommonMethods
    {
        /// <summary>
        /// Verify the notebook draw region exists
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyNotebookdrawRegionExists(AutomationAgent notebookautomationagent)
        {
            notebookautomationagent.VerifyElementFound("NotebookView", "NoteBookDrawRegion");
        }

        /// <summary>
        /// Click on the text button
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnTextButton(AutomationAgent notebookautomationagent)
        {
            notebookautomationagent.Click("NotebookView", "TextIcon");
        }

        /// <summary>
        /// Verify whether the PRESSED STATE is displayed on NOTEBOOK icon when tapped on it.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if notebook nav icon hidden property is false</returns>
        public static bool VerifyNotebookIconIsInPressedState(AutomationAgent notebookAutomationAgent)
        {
            //string[] hiddenProperty = notebookAutomationAgent.GetAllValues("NotebookView", "NotebookNavIconPressedState", "hidden");
            //if (hiddenProperty[0].Equals("false"))
            //    return true;
            //else
            //    return false;
            return notebookAutomationAgent.IsElementFound("UnitSelection", "SelectedNotebook");
        }

        /// <summary>
        /// Verify whether the PRESSED STATE is displayed on Media Library nav icon when tapped on it.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if Media library nav icon hidden property is false</returns>
        public static bool VerifyMediaLibraryNavIconIsInPressedState(AutomationAgent notebookAutomationAgent)
        {
            //string[] hiddenProperty = notebookAutomationAgent.GetAllValues("NotebookView", "MediaLibraryNavIconPressedState", "hidden");
            //if (hiddenProperty[0].Equals("false"))
            //    return true;
            //else
            //    return false;

            return notebookAutomationAgent.IsElementFound("UnitSelection", "MediaLibrarySelected");
        }

        /// <summary>
        /// Verify whether the PRESSED STATE is displayed on Home nav icon when tapped on it.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if Unit Home nav icon hidden property is false</returns>
        public static bool VerifyHomeNavIconIsInPressedState(AutomationAgent notebookAutomationAgent)
        {
            //string[] hiddenProperty = notebookAutomationAgent.GetAllValues("NotebookView", "HomeNavIconPressedState", "hidden");
            //if (hiddenProperty[0].Equals("false"))
            //    return true;
            //else
            //    return false;

            return notebookAutomationAgent.IsElementFound("UnitSelection", "SelectedUnitHome");
        }
        /// <summary>
        /// verify that the text box region is found or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTextBoxRegionFound(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "RemoveButton");
        }
        /// <summary>
        /// Clicks on the fullscreen icon in notebook toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnFullScreenIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "FullScreenIcon");
        }
        /// <summary>
        /// Click on the add page tile in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToAddPageInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "AddPageTile");
        }
        /// <summary>
        /// Click on the delete icon in notebook toolbar
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDeleteIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "DeleteIcon");
        }
        /// <summary>
        /// Verify delete pop up message
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyPopUpMessage(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "DeletePopup");
        }
        /// <summary>
        /// Click on the cancel button in delete pop up 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "DeletePopup");
        }

        /// <summary>
        /// verify the existence of navigation bar.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyNavigationBar(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("UnitSelection", "NavigationBar");
        }
        /// <summary>
        /// verify the page no. below the notebook icon.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoteBookPageNumber(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "PageCountLabel");
        }
        /// <summary>
        /// verify that NoteBook in when notebook browser open
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoteBookOnFocus(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("UnitSelection", "OpenNotebookIcon");
        }
        /// <summary>
        /// verify unit number and title.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitNumberAndTitle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "NotebookUnitTitle");
        }
        /// <summary>
        /// clicks on the stamp button in the notebook toolbar.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnStampButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampButton");
        }
        /// <summary>
        /// Verify that the default item selected in the stamp overlay is box.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyDefaultItemSelectedInStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampToolShapeHighlighted");
        }
        /// <summary>
        /// clicks on the letter tool in the stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnToolLettersInStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampToolLetters");
        }
        /// <summary>
        /// Verifies that the tool letter is stamp overlay is highlighted after selecting it
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyToolLetterInStampOverlayhighlighted(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampToolLettersHighlighted");
        }
        /// <summary>
        /// clicks on the object tool in stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnToolObjectsInStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampToolObject");
        }
        /// <summary>
        /// verify that the tool object is highlighted after selecting it.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyToolObjectInStampOverlayHighlighted(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampToolObjecthighlighted");
        }
        /// <summary>
        /// clicks on the animal tool in stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnToolAnimalInStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampToolAnimal");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyToolAnimalInStampOverlayHighlighted(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampToolAnimalHighlighted");
        }
        /// <summary>
        /// clicks on the weather tool in stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent"></param>
        public static void ClickOnToolWeatherInStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampToolWeather");
        }
        /// <summary>
        /// Verify that weather tool is highlighted after selecting it
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyToolWeatherInStampOverlayHighlighted(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampToolWeatherHighlighted");
        }
        /// <summary>
        /// Verify stamps when tool shape is selected from th stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyStampWhenToolsshapeSelected(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampCone");
        }
        /// <summary>
        /// Verify stamps when tool object is selected from th stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyStampWhenToolObjectSelected(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampAnalogClock");
        }
        /// <summary>
        /// Verify stamps when tool animal is selected from th stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyStampWhenToolAnimalSelected(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampAnt");
        }
        /// <summary>
        /// Verify stamps when tool letters is selected from th stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyStampWhenToolLettersSelected(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampLetterZero");
        }
        /// <summary>
        /// Verify stamps when tool weather is selected from th stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyStampsWhenToolWeatherSelected(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampWind");
        }

        /// <summary>
        /// Verify the user is on notebook browser.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if notebook nav icon hidden property is false</returns>
        public static bool VerifyUserOnNotebookbrowser(AutomationAgent notebookAutomationAgent)
        {
            string[] hiddenProperty = notebookAutomationAgent.GetAllValues("NotebookView", "NotebookNavIconPressedState", "hidden");
            if (hiddenProperty[0].Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click on the plus button which is on the notebook editor
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPlusButtonInNotebookEditor(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "PlusButtonInNoteBookEditor");
        }
        /// <summary>
        /// verify the state of delete icon in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true if found in active state</returns>
        public static bool VerifyDeleteIconInActiveState(AutomationAgent notebookAutomationAgent)
        {
            string enabled = notebookAutomationAgent.GetElementProperty("NotebookView", "DeleteIcon", "enabled");
            if (enabled.Equals("true"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on the graphic tool in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGraphicTool(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "GraphicTool");
        }
        /// <summary>
        /// Clicks on the table tool
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTableTool(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "TableTool");
        }
        /// <summary>
        /// Clicks on the red cross button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRemoveButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "RemoveButton");
        }
        /// <summary>
        /// Verify that table is deleted from the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if find</returns>
        public static bool VerifyTableDeleted(AutomationAgent notebookAutomationAgent)
        {
            return (notebookAutomationAgent.IsElementFound("NotebookView", "RemoveButton"));

        }
        /// <summary>
        /// Click on the yes button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnYesbutton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("UnitSelection", "AcceptLogOut");
        }
        /// <summary>
        /// get the page count no.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static int GetCountOfNotebookPages(AutomationAgent notebookAutomationAgent)
        {
            string[] pagecount = notebookAutomationAgent.GetTextIn("NotebookView", "PageCountLabel", "Inside", "").Split(' ');
            return Int32.Parse(pagecount[2].Replace("\t\n", ""));
        }
        /// <summary>
        /// Clicks on the continue button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnContinueButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "Continuebutton");
        }
        /// <summary>
        /// Verify text button active or inactive
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTextButtonActive(AutomationAgent notebookAutomationAgent)
        {
            string hidden = notebookAutomationAgent.GetAllValues("NotebookView", "TextIcon", "hidden")[0];
            return hidden.Equals("false");
        }
        /// <summary>
        /// verify remove button exist or not
        /// </summary>
        /// <param name="notebookAutomationAgent"></param>
        public static void VerifyRemoveBUtton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "RemoveButton");
        }
        /// <summary>
        /// Click on the plus icon in the notebook browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClicktoAddPageFromNotebookBrowser(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "AddIconInNotebookBrowser");

        }
        /// <summary>
        /// get label of notebook pages 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object:label of notebook pages</returns>
        public static string GetLabelOfNotebookPages(AutomationAgent notebookAutomationAgent)
        {
            string label = notebookAutomationAgent.GetTextIn("NotebookView", "PageCountLabel", "Inside", "").Replace("\t\n", "").Replace(" of ", "/");
            return label;
        }
        /// <summary>
        /// get count of notebook pages in the notebook editor
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: the count of the pages added</returns>
        public static int GetCountOfNotebookPagesInNotebookEditor(AutomationAgent notebookAutomationAgent, int count)
        {
            string label = notebookAutomationAgent.GetAllValues("NotebookView", "CountLabelInNoteBookEditor", count.ToString(), "text")[0];
            return Int32.Parse(label);
        }

        /// <summary>
        /// get count of notebook pages in the notebook editor
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: the count of the pages added</returns>
        public static string GetCountOfNotebookPagesInNotebookEditor(AutomationAgent notebookAutomationAgent)
        {
            string label = notebookAutomationAgent.GetTextIn("NotebookView", "CountLabelInNoteBookEditor", "Inside", "").Replace("(null) (", "").Replace(")\t\n", "");
            return label;
        }
        /// <summary>
        /// Verify UI of add page pop up
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUIofAddPagePopup(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("UnitSelection", "AcceptLogOut");
            CAadoptionAutomationAgent.VerifyElementFound("UnitSelection", "CancelLogOut");
            CAadoptionAutomationAgent.VerifyElementFound("BookBuilderView", "AddPageNewIdentifier");
        }
        /// <summary>
        /// Verify clear all button exist whennotebook open from book log
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyClearAllButtonExist(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.IsElementFound("NotebookView", "ClearAllButton");
        }
        /// <summary>
        /// Verify undo redo icon present 
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUNDOandREDOicon(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("NotebookView", "RedoButton");
            CAadoptionAutomationAgent.VerifyElementFound("NotebookView", "UndoButton");
        }
        /// <summary>
        /// Verify the remove button at top left corner of the image in notebook.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyRemoveButtonAtTopLeftCornerOfImage(AutomationAgent CAadoptionAutomationAgent)
        {

        }
        /// <summary>
        /// Verify teacher mode icon in pressed state
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTeacherModeIconPressedState(AutomationAgent navigationAutomationAgent)
        {
            string topproperty = navigationAutomationAgent.GetAllValues("TeacherMode", "TeacherModeNavIcon", "top")[0];
            if (topproperty.Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Choose the shape from stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ChooseTheShapeFromStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampCone");
        }
        /// <summary>
        /// Verify stamp overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyStampOverlay(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "StampMenu");
        }
        /// <summary>
        /// Click insdie text box
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickInsideTextBox(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "TextBoxRegion").Split(',');

            notebookAutomationAgent.ClickOnScreen(Int32.Parse(pos[0]), Int32.Parse(pos[1]) + 40);
        }
        /// <summary>
        /// VErify Data Saved 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="p">string object: data saved </param>
        public static bool VerifySavedData(AutomationAgent notebookAutomationAgent, string saveddata)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "ClearAllButton"))
            {
                string text = notebookAutomationAgent.GetElementText("InboxView", "CommentOverlayTextArea");
                if (text.Contains(saveddata))
                    return true;
                else
                    return false;
            }
            else
            {
                string text = notebookAutomationAgent.GetElementText("InboxView", "CommentOverlayTextArea");
                if (text.Contains(saveddata))
                    return true;
                else
                    return false;
            }

        }
        /// <summary>
        /// Verify navigation arrow present 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <return>bool object : true if found</return>
        public static bool VerifyNavigationArrowPresent(AutomationAgent notebookAutomationAgent)
        {

            if (VerifyNavigationArrowPresentSupportMethod(notebookAutomationAgent))
                return true;

            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                }

                return (VerifyNavigationArrowPresentSupportMethod(notebookAutomationAgent));
            }
        }
        /// <summary>
        /// Verify Navigation Arrow Present support method
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if found</returns>
        public static bool VerifyNavigationArrowPresentSupportMethod(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft") && notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
                return true;

            else if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft"))
            {
                notebookAutomationAgent.DragElement("NotebookView", "PageSwipeview", 500, 0);
                return (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft") && notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"));

            }

            else if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
            {
                notebookAutomationAgent.DragElement("NotebookView", "PageSwipeview", -500, 0);
                return (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft") && notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"));
            }

            else
                return false;
        }

        /// <summary>
        /// Click on the previous arrow
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPrevArrow(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft"))
            {
                notebookAutomationAgent.Click("NotebookView", "PageArrowLeft");
            }
            else
            {
                notebookAutomationAgent.Swipe(Direction.Right, 500);
                notebookAutomationAgent.Click("NotebookView", "PageArrowLeft");
            }

        }
        /// <summary>
        /// Click on the next arrow 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNextArrow(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
            {
                notebookAutomationAgent.Click("NotebookView", "PageArrowRight");
            }
            else
            {
                notebookAutomationAgent.Swipe(Direction.Left, 500);
                notebookAutomationAgent.Click("NotebookView", "PageArrowRight");
            }
        }
        /// <summary>
        /// Get position of notebook pages in notebook browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: position of page</returns>
        public static int GetPositionOfNotebookPages(AutomationAgent notebookAutomationAgent)
        {
            string[] pagecount = notebookAutomationAgent.GetTextIn("NotebookView", "PageCountLabel", "Inside", "").Split(' ');
            return Int32.Parse(pagecount[0].Replace("\t", ""));
        }
        /// <summary>
        /// Verify tool menu pop up
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifYToolMenuPopUp(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "ToolMenuPanel");
        }
        /// <summary>
        /// Click on the Number line button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNumberLineButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NumberLineButton");
        }
        /// <summary>
        /// Verify Number line in notebook 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>Bool object: true if found</returns>
        public static bool VerifyNumberLineInNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NumberLineExtender");
        }
        /// <summary>
        /// Click on clear all button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnClearAllButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "ClearAllButton");
        }
        /// <summary>
        /// Verify color selection menu view
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyColorSelectionMenu(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "CrossButtonInColorMenu");
        }
        /// <summary>
        /// Verify colored circles count in the color selection menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyElevenCircleInColorSelectionMenu(AutomationAgent notebookAutomationAgent)
        {
            int count = notebookAutomationAgent.GetElementCount("NotebookView", "ColorButtons");
            if (count.Equals(11))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify close button in color selction menu
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCloseButtonInColorSelectionMenu(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "CrossButtonInColorMenu");
        }
        /// <summary>
        /// Click to get the color selection menu button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToGetColorSelectionMenu(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "TableNumberButton");
        }
        /// <summary>
        /// Get the position of number line tool
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if found</returns>
        public static string[] GetPositionOfNumberLineTool(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "NumberLineExtender").Split(',');
            return pos;
        }
        /// <summary>
        /// Verify Back ground image button.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyBackGroundImageButton(AutomationAgent notebookAutomationAgent)
        {
            int xcoordinate = Int32.Parse(notebookAutomationAgent.GetAllValues("BookBuilderView", "BackgroundPaper", "x")[0]);
            int ycoordinates = Int32.Parse(notebookAutomationAgent.GetAllValues("BookBuilderView", "BackgroundPaper", "y")[0]);
            if (xcoordinate < 50 & ycoordinates < 1000)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Click on the back ground image button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackGroundButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("BookBuilderView", "BackgroundPaper");
        }
        /// <summary>
        /// Verify background image button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyBackGroundImagePopup(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "BackgroundImageTool");
        }
        /// <summary>
        /// Verify the count background images
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTheCountOfBackgrounds(AutomationAgent notebookAutomationAgent)
        {
            int count = notebookAutomationAgent.GetElementCount("NotebookView", "BackgroundImages");
            if ((count - 1).Equals(7))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click to choose the background from the background image pop up .
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToChooseBackground(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "GridBackground");
        }
        /// <summary>
        /// Verify that selected background on notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySelectedBackGroundOnNoteBook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "GridBackgroundImage");
        }
        /// <summary>
        /// Verify table tool in the toll overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyTableTool(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "TableTool");
        }
        /// <summary>
        /// Verify Table on the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTableAdded(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "VerticalDragHandle");
        }
        /// <summary>
        /// Verify heading area in the table
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyHeadingArea(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "HeadingAreaOfTable");
        }
        /// <summary>
        /// Verify rows and columns 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyRowsAndColumns(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "RowsInTable");
            notebookAutomationAgent.VerifyElementFound("NotebookView", "ColumnsInTable");
        }
        /// <summary>
        /// Verify Expansion Contraction Button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerfiyExpansionContractionButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "VerticalDragHandle");
            notebookAutomationAgent.VerifyElementFound("NotebookView", "HorizontalDragHandle");
        }
        /// <summary>
        /// Verify hand tool active
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyHandToolActive(AutomationAgent notebookAutomationAgent)
        {

            return notebookAutomationAgent.IsElementFound("NotebookView", "HandToolOn");

        }
        /// <summary>
        /// Drag to increase the columns
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragRightToIncreaseColumns(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookView", "HorizontalDragHandle", Direction.Left, 0, 2000);
        }
        /// <summary>
        /// Drag to increase rows in the table.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragDownToIncreaseRows(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookView", "VerticalDragHandle", Direction.Up, 0, 2000);
        }
        /// <summary>
        /// Drag to increase rows in the table.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragUpToDecreaseRows(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookView", "VerticalDragHandle", Direction.Down, 0, 2000);
        }
        /// <summary>
        /// Get the count of rows 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: count of rows</returns>
        public static int GetCountOfRows(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementCount("NotebookView", "RowsInTable");
        }
        /// <summary>
        /// Get count of columns
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: count of rows</returns>
        public static int GetCountOfColumns(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementCount("NotebookView", "ColumnsInTable");
        }
        /// <summary>
        /// Verify stamp button active
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyStampButtonActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "StampOn");

        }
        /// <summary>
        /// Verify gradient in the stamp overlay popup 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyGradientInPopUp(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "MenuGradient");
        }
        /// <summary>
        /// Click on the cone stamp
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToChooseStampCone(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampCone");
        }
        /// <summary>
        /// Click on hand button 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnHandButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "HandButton");
        }
        /// <summary>
        /// Verify selected stamp with dashed line
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySelectedStampWithDashedLine(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "StampSelectedInDashedLine");
        }
        /// <summary>
        /// Verify table and data saved 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTableAndDataSaved(AutomationAgent notebookAutomationAgent, string datasaved)
        {
            string text = notebookAutomationAgent.GetText("TEXT");
            if (text.Contains(datasaved) & NotebookCommonMethods.VerifyHeadingArea(notebookAutomationAgent))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify interactive in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyInteractiveInNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "InteractiveInNotebook");
        }
        /// <summary>
        /// Drag left to decrease columns
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragLeftToDecreaseColumns(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookView", "VerticalDragHandle", Direction.Right, 0, 2000);
        }
        /// <summary>
        /// Verify resizable dots of text box
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyResizableDotsOfTextBox(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "ResizableDotsOfTextBox");
        }
        /// <summary>
        /// Get the position of text box
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <return>int object: position</return>
        public static string[] GetPositionOfTextBox(AutomationAgent notebookAutomationAgent)
        {
            string[] position = notebookAutomationAgent.GetPosition("NotebookView", "TextBoxRegion").Split(',');

            return position;

        }
        /// <summary>
        /// Drag text box right Dot
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragTextBoxRightDot(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookView", "RightDotOfTextBox", x, y);
        }
        /// <summary>
        /// Verify table active when added
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTableActive(AutomationAgent notebookAutomationAgent)
        {
            string backgroundcolor = notebookAutomationAgent.GetAllValues("NotebookView", "TableView", "backgroundColor")[0];
            if (backgroundcolor.Equals("0xBDBEBE"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Get the position of the table
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: position</returns>
        public static string[] GetPositionOfTable(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "TableView").Split(',');
            return pos;
        }
        /// <summary>
        /// Drag table
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragTable(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SwipeElement("NotebookView", "TableView", Direction.Up, 0, 2000);
        }

        internal static void VerifyNumberLinesInNumberLineTool(AutomationAgent notebookAutomationAgent)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Verify Grab handle in number line tool
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyGrabHandle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "NumberLineExtender");
        }
        /// <summary>
        /// Get count of number lines
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: count of number line</returns>
        public static int GetCountOfNumberLines(AutomationAgent notebookAutomationAgent)
        {
            int count = notebookAutomationAgent.GetElementCount("NotebookView", "NumberLines");
            return count;
        }
        /// <summary>
        /// drag grab handle left
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragGrabHandleLeft(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookView", "NumberLineExtender", -100, 0);
        }
        /// <summary>
        /// Drag handle right 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragGrabHandleRight(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookView", "NumberLineExtender", 1000, 0);
        }
        /// <summary>
        /// Verify max size of number lines in number line tool
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if match</returns>
        public static bool VerifyMaximumSizeOfNumberLines(AutomationAgent notebookAutomationAgent)
        {

            int count = notebookAutomationAgent.GetElementCount("NotebookView", "NumberLines");
            if (count.Equals(21))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify No cancel button on unselected table
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if match</returns>
        public static bool VerifyNoCancelButtonOnUnselectedTable(AutomationAgent notebookAutomationAgent)
        {
            int count = notebookAutomationAgent.GetElementCount("NotebookView", "RemoveButton");
            if (count.Equals(1))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify User able to type in Heading Area
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUserAbleToTypeInHeadingArea(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SendText("TEST");
            notebookAutomationAgent.Sleep();
            string name = notebookAutomationAgent.GetText("TEXT");
            if (name.Contains("TEST"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Tap inside heading area 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void TapInsideHeadingArea(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "HeadingAreaOfTable").Split(',');

            notebookAutomationAgent.ClickOnScreen(Int32.Parse(pos[0]), Int32.Parse(pos[1]) + 40);
        }
        /// <summary>
        /// Tap inside orange column area
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void TapInsideColumnArea(AutomationAgent notebookAutomationAgent)
        {
            string x = notebookAutomationAgent.GetAllValues("NotebookView", "ColumnField", "x")[0];
            string y = notebookAutomationAgent.GetAllValues("NotebookView", "ColumnField", "y")[0];

            notebookAutomationAgent.ClickOnScreen(Int32.Parse(x), (Int32.Parse(y) + 54));
        }
        /// <summary>
        /// Verify user able to type inside column area
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object true: if found</returns>
        public static bool VerifyUserAbleToTypeInColumnArea(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SendText("PEARSON");
            notebookAutomationAgent.Sleep();
            return notebookAutomationAgent.IsElementFound("NotebookView", "TextInColumn");
        }
        /// <summary>
        /// Tap insdie row field 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void TapInsideRowField(AutomationAgent notebookAutomationAgent)
        {

            string x = notebookAutomationAgent.GetAllValues("NotebookView", "RowField", "x")[0];
            string y = notebookAutomationAgent.GetAllValues("NotebookView", "RowField", "y")[0];
            notebookAutomationAgent.ClickOnScreen(Int32.Parse(x), (Int32.Parse(y)));

        }
        /// <summary>
        /// Verify user able to type inside the row field
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUserAbleToTypeInRowField(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.SendText("PEARSONK1");
            notebookAutomationAgent.Sleep();
            string name = notebookAutomationAgent.GetTextIn("NotebookView", "RowField", "Inside", "");
            if (name.Equals("PEARSONK1"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify notebook page number at bottom
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="pagecount">int object: page count</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyNotebookPageNumberAtBottom(AutomationAgent notebookAutomationAgent, int pagecount)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "CountLabelInNoteBookEditor", pagecount.ToString()))
            {
                string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "CountLabelInNoteBookEditor", pagecount.ToString()).Split(',');

                if (Int32.Parse(pos[1]) < 1600)

                    return true;
                else
                    return false;
            }
            else
                return false;

        }
        /// <summary>
        /// Verify arrows not present in the notebook canvas
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyArrowsNotPresentInNotebookCanvas(AutomationAgent notebookAutomationAgent)
        {
            return (!(notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight") & notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft")));
        }
        /// <summary>
        /// Swipe text box
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="p1">int object: xoffset</param>
        /// <param name="p2">int object: yoffset</param>
        public static void SwipeTextBox(AutomationAgent notebookAutomationAgent, int xoffset, int yoffset)
        {
            notebookAutomationAgent.DragElement("NotebookView", "NoteBookTextRegion", xoffset, yoffset);
        }

        public static void ClickToUndo(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "UndoButton");
        }
        /// <summary>
        /// Get the positon of notebook text region
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: position</returns>
        public static string[] GetPositionOfNoteBookTextRegion(AutomationAgent notebookAutomationAgent)
        {
            string[] position = notebookAutomationAgent.GetPosition("NotebookView", "NoteBookTextRegion").Split(',');

            return position;
        }
        /// <summary>
        /// Click to get text box region over given text in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToGetTextBoxOverText(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NoteBookTextRegion");
        }
        /// <summary>
        /// CLick to do the redo
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToRedo(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "RedoButton");
        }
        /// <summary>
        /// Get the position of the stamp inserted
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: position of dtamp</returns>
        public static string[] GetPositionOfStamp(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "StampSelectedInDashedLine").Split(',');
            return pos;
        }
        /// <summary>
        /// Drag stamp
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragStamp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookView", "StampSelectedInDashedLine", 500, 500);
        }
        /// <summary>
        /// Verify Dotted Lines Present around snapshot
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object :true if found</returns>
        public static bool VerifyDottedLinePresent(AutomationAgent eReaderAutomationAgent)
        {
            return eReaderAutomationAgent.IsElementFound("NotebookView", "DottedLines");
        }
        /// <summary>
        /// Verify swipping of pages
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void SwippingOfPages(AutomationAgent notebookAutomationAgent)
        {
            if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft") && notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
            {
                notebookAutomationAgent.DragElement("NotebookView", "PageSwipeview", 500, 0);

            }

            else if (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowLeft"))
            {
                notebookAutomationAgent.DragElement("NotebookView", "PageSwipeview", 500, 0);
            }

            else
            {
                notebookAutomationAgent.DragElement("NotebookView", "PageSwipeview", -500, 0);
            }


        }

        /// <summary>
        /// verify only one notebook display when only one unit is downloaded
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: Next and Prev button is disabled</returns>
        public static bool VerifyOnlyOneNotebookDisplay(AutomationAgent notebookAutomationAgent)
        {
            return (!notebookAutomationAgent.IsElementFound("NotebookView", "NextNotebookButton") && !notebookAutomationAgent.IsElementFound("NotebookView", "PrevNotebookButton"));
        }

        /// <summary>
        /// Verify notebook sharing icon
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: when notebook sharing icon display</returns>
        public static bool VerifyNotebookSharingIcon(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookSharingButton");
        }

        /// <summary>
        /// Verify notebook add page button display
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>true: when add button display</returns>
        public static bool VerifyNotebookAddPageButton(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "AddIconInNotebookBrowser");
        }

        /// <summary>
        /// click to delete intercative image from notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToSelectIntercativeImageFromNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NotebookInteractive");
        }
        /// <summary>
        /// Click on the camera gallery button in the notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMediaButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "MediaButton");
        }
        /// <summary>
        /// Verify items in camera gallery  
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyItemsInCameragalleryOverlay(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "MicrophoneButton");
            notebookAutomationAgent.VerifyElementFound("NotebookView", "CameraButton");
            notebookAutomationAgent.VerifyElementFound("NotebookView", "GalleryButton");
        }
        /// <summary>
        /// Verify Items enabled in media overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyItemsEnabledInMediaOverlay(AutomationAgent notebookAutomationAgent)
        {
            string Microphone_enabled = notebookAutomationAgent.GetAllValues("NotebookView", "MicrophoneButton", "enabled")[0];

            string Camera_enabled = notebookAutomationAgent.GetAllValues("NotebookView", "CameraButton", "enabled")[0];

            string Gallery_Enabled = notebookAutomationAgent.GetAllValues("NotebookView", "GalleryButton", "enabled")[0];

            if (Microphone_enabled.Equals("false") && Camera_enabled.Equals("false") && Gallery_Enabled.Equals("false"))
                return false;

            else
                return true;
        }
        /// <summary>
        /// Verify Media Overlay
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMediaOverlay(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "ToolMenuPanel");
        }
        /// <summary>
        /// Verify left arrow present
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyLeftArrowPresent(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "PageArrowLeftAtBook");
        }
        /// <summary>
        /// Verify background byutton active 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if found</returns>
        public static bool VerifyBackgroundButtonActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "BackgroundImageTool");
        }
        /// <summary>
        /// Verify updated snapshot On notebook brwoser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="p">string object : text</param>
        public static bool VerifyUpdatedSnapShotOnNotebookBrwoser(AutomationAgent notebookAutomationAgent, string text)
        {
            notebookAutomationAgent.Sleep();
            string text_on_notebook_browser = notebookAutomationAgent.GetText("TEXT");

            return (text_on_notebook_browser.Contains(text));
        }
        /// <summary>
        /// Verify updated background on notebook browser
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUpdatedBackgroundOnNotebookBrowser(AutomationAgent notebookAutomationAgent)
        {

            return notebookAutomationAgent.IsElementFound("NotebookView", "UpdatedBackgroundOnBrowser_1");
        }
        /// <summary>
        /// Drag down the number line table
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragNumberLineTool(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookView", "NumberLineToolRegion", x, y);
        }
        /// <summary>
        /// Get count of number line tables
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int object: number of table in notebook</returns>
        public static int GetCountOfNumberLineTable(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementCount("NotebookView", "NumberLineExtender");
        }
        /// <summary>
        /// Click on the crayon button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickonCrayonButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("BookBuilderView", "Crayon");
        }
        /// <summary>
        /// Get color to be selected 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: color that is going to be slected</returns>
        public static string GetColorToBeselected(AutomationAgent notebookAutomationAgent, int colornumber)
        {
            return notebookAutomationAgent.GetAllValues("NotebookView", "ColorInColorSelectionMenu", colornumber.ToString(), "backgroundColor")[0];
        }
        /// <summary>
        /// Verify that color selected from the color selction menu reflects on the number line tool
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="color_selected">selected color</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySelectedColorInNumberLineTool(AutomationAgent notebookAutomationAgent, string color_selected)
        {
            string color = notebookAutomationAgent.GetAllValues("NotebookView", "ColorinTable", "backgroundColor")[0];

            if (color.Equals(color_selected))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Click on the color in the color slection menu view
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="colornumber">int object: </param>
        public static void ClickOntheColor(AutomationAgent notebookAutomationAgent, int colornumber)
        {
            notebookAutomationAgent.Click("NotebookView", "ColorInColorSelectionMenu", colornumber.ToString());
        }

        /// <summary>
        /// click on left column of stamp
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLeftColumnOfStamp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "StampLeftColumn");
        }

        /// <summary>
        /// Click on color settector from notebook canvas tools
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnColorSelector(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("BookBuilderView", "ColorPicker");
        }

        /// <summary>
        /// Click on red color settector from notebook canvas tools
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRedColorSelector(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("BookBuilderView", "RedColorPicker");
        }

        /// <summary>
        /// Verify red color display on stamp canvas tool
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyRedColorOnStamp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("BookBuilderView", "RedStamp");
        }
        /// <summary>
        /// Click on the camera button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickonCamerabutton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "CameraButton");
        }
        /// <summary>
        /// Verify Camera Icon
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyCameraIconWhenCameraOpen(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("UnitSelection", "CameraIconInBookogCamMode");
        }

        /// <summary>
        /// Verify Cross Mark icon
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyCrossMarkIcon(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "CrossIconInBookogCamMode");
        }
        /// <summary>
        /// Verify User on notebook canvas
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserOnNOtebookCanvas(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "UndoButton");
        }
        /// <summary>
        /// Verify cropping area
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyCroppingArea(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "Snaposhotgrip");
        }
        /// <summary>
        /// Get the position of resizable borders
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static string GetpositionOfResizableBorder(AutomationAgent notebookAutomationAgent)
        {
            string pos = notebookAutomationAgent.GetPosition("NotebookView", "Snaposhotgrip");
            return pos;
        }
        /// <summary>
        /// Drag to crop the photo captured
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x corrdinate</param>
        /// <param name="p2">int object: y corrdinate</param>
        public static void DragToCropThePhoto(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookView", "Snaposhotgrip", x, y);
        }
        /// <summary>
        /// Verify photo captured at top left
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyPhotoCapturedOnNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "NotebookImage");
        }
        /// <summary>
        /// Get positon of resizable dot of image in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static string GetPositonOfResizableDotOfImageInNotebook(AutomationAgent notebookAutomationAgent)
        {
            string pos = notebookAutomationAgent.GetPosition("NotebookView", "RightDotOfTextBox");
            return pos;
        }
        /// <summary>
        /// Drag image on the noteboook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x coordinate</param>
        /// <param name="p2">int object: y coordinate</param>
        public static void DragImage(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookView", "NotebookImage", x, y);
        }
        /// <summary>
        /// Get positon of image added
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: coordinates</returns>
        public static string[] GetPositionOfImage(AutomationAgent notebookAutomationAgent)
        {
            string[] pos = notebookAutomationAgent.GetPosition("NotebookView", "NotebookImage").Split(',');
            return pos;
        }

        /// <summary>
        /// Verify annotation layer on student notebook page
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyAnnotationLayerOnNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("InboxView", "AnnotationLayerOn");
        }

        /// <summary>
        /// Verify annotation layer off on student notebook page
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyAnnotationLayerOFFNotebook(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("InboxView", "AnnotationLayerOFF");
        }
        /// <summary>
        /// verify multiple images in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMultipleImagesInNotebook(AutomationAgent notebookAutomationAgent)
        {
            int count = notebookAutomationAgent.GetElementCount("NotebookView", "NotebookImage");
            return (count > 1);
        }
        /// <summary>
        /// Verify cropping rectangle with white border
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCroppingRectangleWithWhiteBorder(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.Sleep();
            string color = UnitSelectionAutomationAgent.GetAllValues("NotebookView", "CroppingArea", "backgroundColor")[0];
            return color.Equals("0x000000");
        }
        /// <summary>
        /// Get position of drag lines
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: positon</returns>
        public static string GetPositionOfLeftDragLines(AutomationAgent UnitSelectionAutomationAgent)
        {
            string pos = UnitSelectionAutomationAgent.GetPosition("NotebookView", "LeftCroppingLine");
            return pos;
        }
        /// <summary>
        /// drag the cropping lines 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void DragLeftCroppingLine(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.DragElement("NotebookView", "LeftCroppingLine", 100, 0);
        }
        /// <summary>
        /// Verify the resizable dots 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matches</returns>
        public static bool VerifyFourResizableDots(AutomationAgent UnitSelectionAutomationAgent)
        {
            int count = UnitSelectionAutomationAgent.GetElementCount("NotebookView", "Snaposhotgrip");
            return count.Equals(4);
        }
        /// <summary>
        /// Verify clear all pop up elements
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyClearAllPopUpElements(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("NotebookView", "NotebookClearAllImage");
            bookBuilderAutomatinAgent.VerifyElementFound("UnitSelection", "AcceptLogOut");
            bookBuilderAutomatinAgent.VerifyElementFound("UnitSelection", "CancelLogOut");
        }
        /// <summary>
        /// Get positon of top left line
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: position of top drag lines</returns>
        public static string GetPositionOfTopDragLines(AutomationAgent UnitSelectionAutomationAgent)
        {
            string pos = UnitSelectionAutomationAgent.GetPosition("NotebookView", "TopCroppingLine");
            return pos;
        }
        /// <summary>
        /// drag the cropping area
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x offset</param>
        /// <param name="p2">int object: y offset</param>
        public static void DragTheCroppingArea(AutomationAgent UnitSelectionAutomationAgent, int p1, int p2)
        {
            UnitSelectionAutomationAgent.DragElement("NotebookView", "Snapshotgridview", p1, p2);
        }
        /// <summary>
        /// Verify rectangle and drag handle not outside the crop area
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyRectangleAndDragHandleNotOutsidetheCropArea(AutomationAgent UnitSelectionAutomationAgent)
        {
            int xrectangle = Int32.Parse(UnitSelectionAutomationAgent.GetAllValues("NotebookView", "Snapshotgridview", "x")[0]);
            int xdraghandle = Int32.Parse(UnitSelectionAutomationAgent.GetAllValues("NotebookView", "Snaposhotgrip", "x")[0]);
            if (xrectangle < 1808 && xrectangle > 0 && xdraghandle < 1808 && xdraghandle > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Drag top cropping line
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void DragTopCroppingLine(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.DragElement("NotebookView", "TopCroppingLine", 0, 200);
        }
        /// <summary>
        /// Click on photo gallery button.
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPhotoGalleryButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "GalleryButton");
        }
        /// <summary>
        /// Click on camera roll 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCameraRoll(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "Cameraroll");
        }
        /// <summary>
        /// Choose picture from gallery
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ChoosePictureFromGallery(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "Photoview");
        }

        /// <summary>
        /// Verify stamp overlay popup
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyStampOverlayPopUp(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StampOverLayPopup");
        }
        /// <summary>
        /// Click on review sticker
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnReviewSticker(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.WaitforElement("NotebookView", "ReviewSticker", "", WaitTime.LargeWaitTime);
            inboxAutomationAgent.Click("NotebookView", "ReviewSticker");
        }
        /// <summary>
        /// Verify sticker overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyStickerOverlay(AutomationAgent inboxAutomationAgent)

        {
            inboxAutomationAgent.WaitforElement("NotebookView", "StickerOverlay", "", WaitTime.MediumWaitTime);
            return inboxAutomationAgent.IsElementFound("NotebookView", "StickerOverlay");
        }
        /// <summary>
        /// Click to choose sticker from the sticker overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickToChooseSticker(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("BookBuilderView", "RedColorPicker");
        }
        /// <summary>
        /// Verify sticker on notebook
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyStickerOnNotebook(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("NotebookView", "NotebookImage");
        }
        /// <summary>
        /// Verify sticker highlighted
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyStickerHighlighted(AutomationAgent inboxAutomationAgent)
        {
            return inboxAutomationAgent.IsElementFound("NotebookView", "RemoveButton");
        }

        /// <summary>
        /// Verify for following options in same order under tools menu. 1.microphone 2.camera 3. gallery
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyMediaIconsOrder(AutomationAgent notebookAutomationAgent)
        {
            int microphonePosition = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "MicrophoneButton", "y")[0]);
            int cameraPosition = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "CameraButton", "y")[0]);
            int gallaryPosition = Int32.Parse(notebookAutomationAgent.GetAllValues("NotebookView", "GalleryButton", "y")[0]);

            Assert.IsTrue(microphonePosition < cameraPosition && cameraPosition < gallaryPosition, "Fail if tool menu is not in order");
        }
        /// <summary>
        /// Verify items in the sticker overlay
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void VerifyItemsInStickerOverlay(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StcikerTerrific");
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StickerYouDidIt");
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StickerWoW");
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StcikerWellDOne");
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StickerGreatWork");
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StickerStar");
            inboxAutomationAgent.VerifyElementFound("NotebookView", "StickerSmiley");
        }

        /// <summary>
        /// Click on the comment button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCommentButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("NotebookView", "CommentBox");
        }

        /// <summary>
        /// Click on next page until CURRENT PAGE DOES NOT DISPLAY
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickUntillCurrentPageNotDisplay(AutomationAgent notebookAutomationAgent)
        {
            int tCount = 0;
            while (notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight") && tCount <= 10)
            {
                notebookAutomationAgent.Click("NotebookView", "PageArrowRight");
                tCount++;
            }
        }

        /// <summary>
        /// Verify right notebook bleeding 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyRightNotebookBleeding(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "NextNotebookButton");
        }

        /// <summary>
        /// Verify left notebook bleeding 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyLeftNotebookBleeding(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "PrevNotebookButton");
        }

        /// <summary>
        /// Verify notebopok wood background
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotebookWoodBackground(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "NotebookWoodBackground");
        }
        /// <summary>
        /// Verify Next numerical notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNextNumericalNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "UNIT2Title");
        }
        /// <summary>
        /// Click right notebook bleeding 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickRightNotebookBleeding(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NextNotebookButton");
        }

        /// <summary>
        /// Click left notebook bleeding 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickLeftNotebookBleeding(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "PrevNotebookButton");
        }

        /// <summary>
        /// Verify previous numerical notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyPreviousNumericalNotebook(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "UnitTitleAndNumber");
        }
        /// <summary>
        /// Verify next numerical notebook in math unit
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyNextNumericalNotebookInMAthUnit(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "MathUnit1");
        }
        /// <summary>
        /// Verify previous numerical notebook in math unit
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyPreviousNumericalNotebookInMathUnit(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookView", "MathUnit0");
        }

        /// <summary>
        /// Click on audio icon in notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAudionIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "MicrophoneButton");
        }

        /// <summary>
        /// verify progress label while recording 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyProgressLabelWhileRecording(AutomationAgent notebookAutomationAgent)
        {
            return !(notebookAutomationAgent.IsElementFound("NotebookView", "CountLabelInNoteBookEditor", ""));
        }
        public static bool VerifyInactiveHandIcon(AutomationAgent notebookAutomationAgent)
        {
            string topproperty = notebookAutomationAgent.GetAllValues("NotebookView", "HandTool", "top")[0];
            if (topproperty.Equals("true"))
                return true;
            else
                return false;
        }
        public static bool VerifyRightArrowInNotebookBrowser(AutomationAgent notebookAutomationAgent)
        {

            return notebookAutomationAgent.IsElementFound("NotebookView", "PageArrowRight");
            
        }

        
    }

}



