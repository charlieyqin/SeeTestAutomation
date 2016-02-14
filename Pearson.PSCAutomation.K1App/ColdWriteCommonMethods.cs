using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;
using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    public class ColdWriteCommonMethods
    {

        /// <summary>
        /// clicks on the cold write image to open
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnColdWrite(AutomationAgent coldwriteAutomationAgent)
        {
            while(!coldwriteAutomationAgent.IsElementFound("ColdWriteView","ColdWriteImageInTodayShelf"))
            {
                coldwriteAutomationAgent.Swipe(Direction.Right);
            }

            coldwriteAutomationAgent.Click("ColdWriteView", "ColdWriteImageInTodayShelf");
        }

        /// <summary>
        /// Drag the media screen down to search Cold Write Icon
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void DragMediaLibraryScreenToSearchColdWrite(AutomationAgent coldwriteAutomationAgent)
        {
            for (int i = 0; i <= 7; i++)
            {
                while (!coldwriteAutomationAgent.IsElementFound("ColdWriteView", "HandwritingShelf"))
                {
                    if (coldwriteAutomationAgent.IsElementFound("ColdWriteView", "ColdWriteImageInTodayShelf"))
                    {
                        Assert.Fail("Cold Write is present in Media Library");
                    }
                    else
                        coldwriteAutomationAgent.Swipe(Direction.Down);
                }

            }
        }
        public static void VerifyColdWriteOverlay(AutomationAgent coldwriteAutomationAgent)
        {
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "Overlay");
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "BackHand");
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "NoteBookIconInOverlay");
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "ColdWriteNotebookButton");
        }


        /// <summary>
        /// Verify NoteBook icon centered in Overlay
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if matched</returns>
        public static bool VerifyNoteBookIconCenteredInColdWriteOverlay(AutomationAgent coldwriteAutomationAgent)
        {
            int width = Int32.Parse(coldwriteAutomationAgent.GetAllValues("ColdWriteView", "NoteBookIconInOverlay", "width")[0]);
            int Xcoordinate = Int32.Parse(coldwriteAutomationAgent.GetAllValues("ColdWriteView", "NoteBookIconInOverlay", "x")[0]);

            int WidthOfOverlay = Int32.Parse(coldwriteAutomationAgent.GetAllValues("ColdWriteView", "Overlay", "width")[0]);
            int X1coordinate = Int32.Parse(coldwriteAutomationAgent.GetAllValues("ColdWriteView", "Overlay", "x")[0]);
            return ((WidthOfOverlay / 2) + (X1coordinate) == (Xcoordinate) + (width / 2)) ? true : false;
        }

        public static string GetOpenYourNoteBookText(AutomationAgent coldwriteAutomationAgent)
        {
           string text= coldwriteAutomationAgent.GetElementText("ColdWriteView","OpenYourNotebook");
           string newText = text.Replace("\t\n", "");
           return newText;
            
        }

        public static void VerifyLeftSideToolsOfCanvas(AutomationAgent coldwriteAutomationAgent)
        {
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "ColdWriteNotebookinCanvas");
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "CalculatorIcon");
            coldwriteAutomationAgent.VerifyElementFound("BookBuilderView", "CameraIcon");
            coldwriteAutomationAgent.VerifyElementFound("BookBuilderView", "BackgroundPaper");
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "PaperAeroplane");
            
        }
        public static bool VerifyAddPageIconIsPresent(AutomationAgent coldwriteAutomationAgent)
        {
            return coldwriteAutomationAgent.IsElementFound("ColdWriteView", "AddNoteBookPageIcon");
        }
        
        public static void ClickAeroplaneToSend(AutomationAgent coldwriteAutomationAgent)
        {
            coldwriteAutomationAgent.Click("ColdWriteView", "PaperAeroplane");
            coldwriteAutomationAgent.Sleep(5000);
        }
        public static bool VerifyStandardSendBoxIsPresent(AutomationAgent coldwriteAutomationAgent)
        {
            return coldwriteAutomationAgent.IsElementFound("ColdWriteView", "SendDialogueBox");
        }

        
        public static void SelectTeacherName(AutomationAgent coldwriteAutomationAgent, string teacherName)
        {

            if (coldwriteAutomationAgent.IsElementFound("BookBuilderView", "BookName", teacherName))
                    {
                        coldwriteAutomationAgent.Click("BookBuilderView", "BookName", teacherName);
                        coldwriteAutomationAgent.VerifyElementFound("BookBuilderView", "AcceptShare");
                        coldwriteAutomationAgent.Click("BookBuilderView", "AcceptShare");
                        while (coldwriteAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                        {
                            coldwriteAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
                        }
        }
                    }      
                    
        public static void ClickOnOpenYourNotebook(AutomationAgent coldwriteAutomationAgent)
        {
            coldwriteAutomationAgent.VerifyElementFound("ColdWriteView", "ColdWriteNotebookButton");
            coldwriteAutomationAgent.Click("ColdWriteView", "ColdWriteNotebookButton");
        }
        public static bool VerifySendIconIsPresent(AutomationAgent coldwriteAutomationAgent)
        {
            
            return coldwriteAutomationAgent.IsElementFound("BookBuilderView", "AcceptShare");
        }
        public static void ClickOnSendButton(AutomationAgent coldwriteAutomationAgent)
        {
            coldwriteAutomationAgent.VerifyElementFound("BookBuilderView", "AcceptShare");
            coldwriteAutomationAgent.Click("BookBuilderView", "AcceptShare");
        }
        public static bool VerifyHelpMessageIsPresentwhenOffline(AutomationAgent coldwriteAutomationAgent)
        {
            return coldwriteAutomationAgent.IsElementFound("ColdWriteView", "HelpDialogueBox");
        }
        public static bool VerifySentMessageIsPresent(AutomationAgent coldwriteAutomationAgent)
        {
            return coldwriteAutomationAgent.IsElementFound("ColdWriteView", "SentDialogue");
        }

        public static void ChangeTo100PercentDataLoss(AutomationAgent coldwriteAutomationAgent)
        {
            coldwriteAutomationAgent.SendText("{HOME}");
            coldwriteAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (coldwriteAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                coldwriteAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            coldwriteAutomationAgent.SendText("Settings");
            coldwriteAutomationAgent.ClickCoordinate(196, 242, 1);
            while (!coldwriteAutomationAgent.IsElementFound("iPadCommonView", "DeveloperTool"))
            {
                coldwriteAutomationAgent.Swipe(Direction.Down);
                if (coldwriteAutomationAgent.IsElementFound("iPadCommonView", "DeveloperTool"))
                {
                    coldwriteAutomationAgent.Click("iPadCommonView", "DeveloperTool");
                    coldwriteAutomationAgent.Click("iPadCommonView", "StatusTabInDeveloperWindow");
                    coldwriteAutomationAgent.Click("iPadCommonView", "100PercentDataLossUIASwitch");
                }
            }
        }
        public static bool VerifyAeroplaneIconIsPresent(AutomationAgent coldwriteAutomationAgent)
        {
            return coldwriteAutomationAgent.IsElementFound("ColdWriteView", "PaperAeroplane");
        }
             


	         
	



                
            

             
    }
}
