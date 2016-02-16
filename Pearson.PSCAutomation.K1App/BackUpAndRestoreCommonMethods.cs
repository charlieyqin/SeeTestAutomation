using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;
using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
   public class BackUpAndRestoreCommonMethods
    {
        /// <summary>
        /// Click On Camera Icon 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda (lakshmi.brunda)</author>
        public static void ClickOnCameraIcon(AutomationAgent BackUpAndRestoreAutomationAgent)
        {

            BackUpAndRestoreAutomationAgent.Click("BookBuilderView", "CameraIcon");
        }

        /// <summary>
        /// Selects Image From Camera Roll
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ImageSelectionFromCameraRoll(AutomationAgent BackUpAndRestoreAutomationAgent)
        {


            BackUpAndRestoreAutomationAgent.ElementListSelect("BookBuilderView", "ImageSelection","July 27 11:32 AM");
            BackUpAndRestoreAutomationAgent.Click("BookBuilderView", "ImageSelection", "July 27 11:32 AM");
            BackUpAndRestoreAutomationAgent.Sleep(WaitTime.LargeWaitTime);

        }
        /// <summary>
        /// Clicks On Camera Roll Option
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda (lakshmi.brunda)</author>
        public static void ClickOnCameraRoll(AutomationAgent BackUpAndRestoreAutomationAgent)
        {

            BackUpAndRestoreAutomationAgent.Click("BookBuilderView", "CameraIcon");
        }
        /// <summary>
        /// Clicks On Camera Roll Option
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda (lakshmi.brunda)</author>
        public static void ClickOnLogoutButton(AutomationAgent BackUpAndRestoreAutomationAgent)
        {
            int tCount = 0;
            while (!BackUpAndRestoreAutomationAgent.IsElementFound("UnitSelection", "SystemTray") && tCount <= 20)
            {
                if (BackUpAndRestoreAutomationAgent.IsElementFound("StudentSetup", "BackButton"))
                {
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                }
                tCount++;
            }

            if ((BackUpAndRestoreAutomationAgent.IsElementFound("UnitSelection", "SystemTray")) && (BackUpAndRestoreAutomationAgent.IsElementFound("SystemTray", "AssessmentReport")))
            {
                
                BackUpAndRestoreAutomationAgent.Click("UnitSelection", "LogOutButton");
                BackUpAndRestoreAutomationAgent.Click("UnitSelection", "Logout");
                BackUpAndRestoreAutomationAgent.Sleep();
            }

            else if(BackUpAndRestoreAutomationAgent.IsElementFound("UnitSelection", "SystemTray"))
            {
                BackUpAndRestoreAutomationAgent.Click("UnitSelection", "SystemTray");
                BackUpAndRestoreAutomationAgent.Click("UnitSelection", "LogOutButton");
                BackUpAndRestoreAutomationAgent.Click("UnitSelection", "Logout");
                BackUpAndRestoreAutomationAgent.Sleep();
            }
        }

        public static void NavigateTillBookBuilder(AutomationAgent BackUpAndRestoreAutomationAgent)
        {
            
            NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
            NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);

        }

        /// <summary>
        /// Verify SnapShot send to Book Page
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifyImageSnapShotSendToPage(AutomationAgent BackUpAndRestoreAutomationAgent)

        {
            return BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "ImageId");
        }
        /// <summary>
        /// Verify Audio send to Book Page
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAudioSnapShotSendToPage(AutomationAgent BackUpAndRestoreAutomationAgent)
        {
            return BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "AudioId");
        }

        /// <summary>
        /// Clicks On Add Page button in Page browser
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda (lakshmi.brunda)</author>
        public static void ClickOnPlusButtonInBookBuilderPage(AutomationAgent BackUpAndRestoreAutomationAgent)
        {

            BackUpAndRestoreAutomationAgent.Click("BackUpAndRestoreView", "AddPageInBookBuilder");
        }

        /// <summary>
        /// Clicks On Add Page button in Page browser
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda (lakshmi.brunda)</author>
        public static void ClickOnSpecificPageNumber(AutomationAgent BackUpAndRestoreAutomationAgent,String pageNumber)
        {

            BackUpAndRestoreAutomationAgent.Click("BackUpAndRestoreView", "ClickOnPageNumber", pageNumber);
        }
       public static ArrayList GetNotebookWorkId(AutomationAgent BackUpAndRestoreAutomationAgent)
        {
            ArrayList assetWorkId = new ArrayList();
            string[] strArray0 = BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "WorkId", "accessibilityIdentifier");
            for( int i =1;i<=strArray0.Length;i++)
            {
                if ((strArray0.Contains("Notebook.audio")) || (strArray0.Contains("Notebook.Image.NotebookKit Images")))
                    assetWorkId.Add(strArray0);


            }

            return assetWorkId;
        }
       public static int GetCountOfWorkIds(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           ArrayList assetWorkId = new ArrayList();
           int numberOfassetWorkIds = 0;
           string[] strArray0 = BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "WorkId", "accessibilityIdentifier");
           for (int i = 1; i <= strArray0.Length; i++)
           {
               if ((strArray0.Contains("Notebook.audio")) || (strArray0.Contains("Notebook.Image")))
               {
                   assetWorkId.Add(BackUpAndRestoreAutomationAgent.GetTextIn("BackUpAndRestoreView", "WorkId", "Inside", i.ToString()));
                   numberOfassetWorkIds++;
               }

           }

           return numberOfassetWorkIds;
       }
       


       /// <summary>
       /// Verifies to get the title of Book
       /// </summary>
       /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
       /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
       public static string GetTitleFromBook(AutomationAgent AssessmentAutomationAgent)
       {
           string text = AssessmentAutomationAgent.GetElementText("BackUpAndRestoreView", "BookTitle",1);
           string newText = text.Replace("\t\n", "");
           return newText;
       }
       /// <summary>
       /// Verifies to get the title of Book
       /// </summary>
       /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
       /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
       public static string GetAuthorNameFromBook(AutomationAgent AssessmentAutomationAgent)
       {
           string text = AssessmentAutomationAgent.GetElementText("NotebookView", "AuthorTiTle", 1);
           string newText = text.Replace("\t\n", "");
           return newText;
       }

       public static void ClickOnNewBookButtonInLeftCorner(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           if (!BackUpAndRestoreAutomationAgent.IsElementFound("BookBuilderView", "NewBookButton"))
           {
               BookBuilderCommonMethods.ClickOnNewBookIcon(BackUpAndRestoreAutomationAgent);
               BookBuilderCommonMethods.ClickOnNewPortraitBookIcon(BackUpAndRestoreAutomationAgent);
               BookBuilderCommonMethods.CreateBook(BackUpAndRestoreAutomationAgent, "bookName", "authorName");
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
           }
           BackUpAndRestoreAutomationAgent.Click("BookBuilderView", "NewBookButton");
       }

       public static bool VerifyPageNumber(AutomationAgent BackUpAndRestoreAutomationAgent, int pagePosition)
       {
           return BackUpAndRestoreAutomationAgent.IsElementFound("BackUpAndRestoreView", "PageNumber", pagePosition.ToString());
       }

       public static void AddingImageAndAudioAssets(AutomationAgent BackUpAndRestoreAutomationAgent)
       {

           ClickOnCameraIcon(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickonCamerabutton(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreAutomationAgent.Sleep(WaitTime.SmallWaitTime);
           NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(BackUpAndRestoreAutomationAgent);
           LoginCommonMethods.ClickGreenMark(BackUpAndRestoreAutomationAgent);        
           
           

           ClickOnCameraIcon(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnAudionIcon(BackUpAndRestoreAutomationAgent);
           InboxCommonMethods.ClickOnRecordButton(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreAutomationAgent.Sleep(WaitTime.SmallWaitTime);
           InboxCommonMethods.ClickOnRecordButton(BackUpAndRestoreAutomationAgent);
       }
       public static void VerifyBookName(AutomationAgent BackUpAndRestoreAutomationAgent,string bookTitle)
       {
           while (!BackUpAndRestoreAutomationAgent.IsElementFound("BackUpAndRestoreView", "BookTitle", bookTitle))
           {
               BackUpAndRestoreAutomationAgent.Swipe(Direction.Right, 500, 731);
           }
           BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
       }
       public static void InitialStepsToReachNotebookBrowser(AutomationAgent BackUpAndRestoreAutomationAgent,string teacherName)
       {
           
           LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin(teacherName));
           TaskInfo taskInfo = Login.GetLogin(teacherName).GetTaskInfo("ELA", "Notebook");
           String[] UnitStatus = LoadUnitStatusFromAdditionalInfo(taskInfo);
           NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnUnitSlectionButton(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent,"1");
           NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
       }
       public static void CreateDataInNoteBookCanvas(AutomationAgent BackUpAndRestoreAutomationAgent, string note)
       {

           NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnTextButton(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickInsideTextBox(BackUpAndRestoreAutomationAgent);
           BookBuilderCommonMethods.SendText(BackUpAndRestoreAutomationAgent, note);
           
           NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
       }
       public static int DeleteNotebookPage(AutomationAgent BackUpAndRestoreAutomationAgent,int pageNo)
       {
           NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
           int pageCount = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
           if((pageNo+2).Equals(pageCount))
           {
               BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
               NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);   
           }
           return pageCount;


       }

       /// <summary>
       /// Draged library to trash can
       /// </summary>
       /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
       public static void DragElementToTrash(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           int xCoordinateOfLib = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPagetoDelete", "x"))[0]);
           int yCoordinateOfLib = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPagetoDelete", "y"))[0]);
           int widthOfLib = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPagetoDelete", "width"))[0]);
           int heightOfLib = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPagetoDelete", "height"))[0]);

           int xCoordinateOfTrash = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPageTrashCan", "x"))[0]);
           int yCoordinateOfTrash = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPageTrashCan", "y"))[0]);
           int widthOfTrash = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPageTrashCan", "width"))[0]);
           int heightOfTrash = Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookPageTrashCan", "height"))[0]);

           BackUpAndRestoreAutomationAgent.SetDragStartDelay(5000);
           BackUpAndRestoreAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfTrash + (widthOfTrash / 2), yCoordinateOfTrash + (heightOfTrash / 2), 2000);

       }
       public static void EditNotebook(AutomationAgent BackUpAndRestoreAutomationAgent, string note)
       {
           NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 330, 690);
           NotebookCommonMethods.ClickInsideTextBox(BackUpAndRestoreAutomationAgent);
           BookBuilderCommonMethods.SendText(BackUpAndRestoreAutomationAgent, note);
           NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
       }

       public static void AddImageInNotebookCanvas(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
           
           NotebookCommonMethods.ClickOnMediaButton(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickonCamerabutton(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(BackUpAndRestoreAutomationAgent);
           LoginCommonMethods.ClickGreenMark(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent);
           
           

       }

       public static void AddAudioInNotebookCanvas(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
           int pagecount = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnMediaButton(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnAudionIcon(BackUpAndRestoreAutomationAgent);
           InboxCommonMethods.ClickOnRecordButton(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreAutomationAgent.Sleep(2000);
           InboxCommonMethods.ClickOnRecordButton(BackUpAndRestoreAutomationAgent);
           
           
       }

       public static int GetXValueOfAudio(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookAudio", "x"))[0]);
       }

       public static int GetYValueOfAudio(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookAudio", "y"))[0]);
       }

       public static int GetXValueOfImage(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookImage", "x"))[0]);
       }

       public static int GetYValueOfImage(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return Int32.Parse((BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "NotebookImage", "y"))[0]);
       }

       public static void RemoveAudio(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           if (!NotebookCommonMethods.VerifyHandToolActive(BackUpAndRestoreAutomationAgent))
           {
               NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
           }
           int xValue = BackUpAndRestoreCommonMethods.GetXValueOfAudio(BackUpAndRestoreAutomationAgent);
           int yValue = BackUpAndRestoreCommonMethods.GetYValueOfAudio(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, xValue, yValue);
           NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);
           
       }
       public static void RemoveImage(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           if (!NotebookCommonMethods.VerifyHandToolActive(BackUpAndRestoreAutomationAgent))
           {
               NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
           }
           int xValue = BackUpAndRestoreCommonMethods.GetXValueOfImage(BackUpAndRestoreAutomationAgent);
           int yValue = BackUpAndRestoreCommonMethods.GetYValueOfImage(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, xValue, yValue);
           NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);
       }

       public static void verifyAssets(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           BackUpAndRestoreAutomationAgent.VerifyElementNotFound("NotebookView", "NotebookInteractive");
           BackUpAndRestoreAutomationAgent.VerifyElementNotFound("BackUpAndRestoreView", "NotebookAudio");
           BackUpAndRestoreAutomationAgent.VerifyElementNotFound("BackUpAndRestoreView", "NotebookImage");
       }

       public static void InitialStepsToReachBookBuilder(AutomationAgent BackUpAndRestoreAutomationAgent,string studentName)
       {
           NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
           LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin(studentName));
           NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);
       }

       /// <summary>
       /// Verify notebook updated popup
       /// </summary>
       /// <param name="inboxAutomationAgent">AutomationAgent object</param>
       /// <returns>True: if displayed</returns>
       public static bool VerifyNotebookUpdatedPopup(AutomationAgent inboxAutomationAgent)
       {
           return (inboxAutomationAgent.GetText("TEXT").Replace("\n", " ")).Contains("Your Notebook was updated.A newer version of your Notebook has been downloaded.");
       }

       public static bool VerifyTableTool(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           string[] strArray0 = BackUpAndRestoreAutomationAgent.GetAllValues("BackUpAndRestoreView", "TableTool", "backgroundColor");
           
               if (strArray0.Contains("0x3AAEC3"))
                   return true;
               else
                   return false;                
       }
       public static void addMultiplePageNumbers(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           for (int i = 1; i < 3; i++)
           {
               NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
               NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
               BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

           }
       }

       public static void ClickOnNewBookIconInPageMiddle(AutomationAgent BackUpAndRestoreAutomationAgent, string option)
       {

           if (!BackUpAndRestoreAutomationAgent.IsElementFound("BookBuilderView", "NewBookIcon"))
           {
               BackUpAndRestoreAutomationAgent.Click("BookBuilderView", "NewBookButton");

               switch (option)
               {
                   case "A":
                       BookBuilderCommonMethods.ChoosePortraitBookShape(BackUpAndRestoreAutomationAgent);

                       break;
                   case "B":
                       BookBuilderCommonMethods.ChooseLandscapeBookShape(BackUpAndRestoreAutomationAgent);

                       break;
                   case "C":
                       BookBuilderCommonMethods.ChooseSquareBookShape(BackUpAndRestoreAutomationAgent);

                       break;
               }
           }
           else
           {
               BackUpAndRestoreAutomationAgent.Click("BookBuilderView", "NewBookIcon");
               switch (option)
               {
                   case "A":
                       BookBuilderCommonMethods.ClickOnNewPortraitBookIcon(BackUpAndRestoreAutomationAgent);

                       break;
                   case "B":
                       BookBuilderCommonMethods.ClickOnNewLandscapeBookIcon(BackUpAndRestoreAutomationAgent);

                       break;
                   case "C":
                       BookBuilderCommonMethods.ClickOnNewSquareBookIcon(BackUpAndRestoreAutomationAgent);

                       break;
               }

           }
       }

       public static void InitialStepsToReachEreader(AutomationAgent BackUpAndRestoreAutomationAgent, string teacherName)
       {

           //Login login = Login.GetLogin(teacherName);
           NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
           LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("TeacherAdbul"));
           TaskInfo taskInfo = Login.GetLogin("TeacherAdbul").GetTaskInfo("ELA", "Notebook");
           String[] UnitStatus = LoadUnitStatusFromAdditionalInfo(taskInfo);
           NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, UnitStatus[0]);
           NavigationCommonMethods.ClickOnTodayButton(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 1024, 500);
           
       }
       public static string[] LoadUnitStatusFromAdditionalInfo(TaskInfo taskInfo)
       {
           String additionalInfo = taskInfo.AdditionalInfo;
           String[] unitStatus = additionalInfo.Split(',');
           return unitStatus;
       }
       public static void ClickOnStampOption(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           BackUpAndRestoreAutomationAgent.Click("NotebookView", "Stamp");
       }

       public static bool VerifyReviewAudioWindow(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return BackUpAndRestoreAutomationAgent.IsElementFound("InboxView", "ReviewAudio");
       }
       public static bool VerifyStudentFeedbackPopUp(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return (BackUpAndRestoreAutomationAgent.GetText("TEXT").Replace("\n", " ")).Contains("Your Student Feedback was updated.A newer version of your student feedback has been downloaded.");
       }
       public static bool VerifyCommentCharacterCount(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return BackUpAndRestoreAutomationAgent.IsElementFound("InboxView", "CommentOverlayCharacterCount");
       }
       public static string GetCharacterCount(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           string text = BackUpAndRestoreAutomationAgent.GetElementText("InboxView", "CommentOverlayCharacterCount");
           string newText = text.Replace("\t\n", "");
           return newText;
       }
       public static void EnterMaximumCountOfCharacters(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           String character = "a";
           for(int i =1;i<149;i++)
           {
               BackUpAndRestoreAutomationAgent.SendText(character);

           }
       }
       public static string GetEnteredTextInTextArea(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           string text = BackUpAndRestoreAutomationAgent.GetElementText("InboxView", "CommentOverlayTextArea");
           string newText = text.Replace("\t\n", "");
           return newText;
       }
       public static void CheckingCharacterCountVariation(AutomationAgent BackUpAndRestoreAutomationAgent)
       {

           NotebookCommonMethods.ClickOnCommentButton(BackUpAndRestoreAutomationAgent);
           Assert.IsTrue(BackUpAndRestoreCommonMethods.VerifyCommentCharacterCount(BackUpAndRestoreAutomationAgent));
           String characterContent = GetEnteredTextInTextArea(BackUpAndRestoreAutomationAgent);
           if (!characterContent.Equals(""))
           {
               for (int i = 0; i < characterContent.Length; i++)
               {
                   BackUpAndRestoreAutomationAgent.SendText("{BKSP}");
               }
           }
           BackUpAndRestoreAutomationAgent.SendText("a");
           String characterCount1 = BackUpAndRestoreCommonMethods.GetCharacterCount(BackUpAndRestoreAutomationAgent);
           Assert.IsTrue(characterCount1.Contains("1 of 150 characters"));
           BackUpAndRestoreAutomationAgent.SendText("a");
           if (BackUpAndRestoreAutomationAgent.IsElementFound("StudentSetup", "AutoCorrectionCell"))
           {
               Assert.IsTrue(InboxCommonMethods.VerifyAutoCorrectForCommentEnable(BackUpAndRestoreAutomationAgent), "Auto-Correct found enabled");
           }
           EnterMaximumCountOfCharacters(BackUpAndRestoreAutomationAgent);
           String characterCount2 = GetCharacterCount(BackUpAndRestoreAutomationAgent);
           Assert.IsTrue(characterCount2.Contains("150 of 150 characters"));
           BackUpAndRestoreAutomationAgent.SendText("b");
           String characterText = GetEnteredTextInTextArea(BackUpAndRestoreAutomationAgent);
           Assert.IsFalse(characterText.Contains("b"));
           BackUpAndRestoreAutomationAgent.SendText("{BKSP}");
           String characterCount3 = GetCharacterCount(BackUpAndRestoreAutomationAgent);
           Assert.IsTrue(characterCount3.Contains("149 of 150 characters"));
           
       }

       public static void CreatingBookInBookBuilder(AutomationAgent BackUpAndRestoreAutomationAgent,String bookName,String authorName,String bookType)
       {
           //ClickOnNewBookIconInPageMiddle(BackUpAndRestoreAutomationAgent, bookType);
           //BookBuilderCommonMethods.CreateBook(BackUpAndRestoreAutomationAgent, bookName, authorName);
           //NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
           //BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
           String bookName1 = BookBuilderCommonMethods.GetNameOfBook(BackUpAndRestoreAutomationAgent);
           if (bookName.Equals(bookName1))
           {
               BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
               BackUpAndRestoreCommonMethods.AddingImageAndAudioAssets(BackUpAndRestoreAutomationAgent);
           }
           else
               Assert.Fail("Else Loop");
       }

       public static void DeleteAssetsinBookBuilder(AutomationAgent BackUpAndRestoreAutomationAgent,String bookName,String authorName)
       {
           BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
           String bookName1 = BookBuilderCommonMethods.GetNameOfBook(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
           if (bookName.Equals(bookName1))
           {
               RemoveAudio(BackUpAndRestoreAutomationAgent);
               RemoveImage(BackUpAndRestoreAutomationAgent);
           }
           else
               Assert.Fail("Else Loop");

       }

       public static void addInteractiveImageAndAudioInNoteBook(AutomationAgent BackUpAndRestoreAutomationAgent,int numberOfflow)
       {
           for (int i = 0; i < numberOfflow; i++)
           {
               NavigationCommonMethods.ClickOnMediaLibrary(BackUpAndRestoreAutomationAgent);
               MediaLibraryCommonMethods.DragMediaLibraryScreenTillIntercative(BackUpAndRestoreAutomationAgent);
               MediaLibraryCommonMethods.ClickToOpenInteractive(BackUpAndRestoreAutomationAgent);

               InteractiveCommonMethods.VerifyInteractivePlayer(BackUpAndRestoreAutomationAgent);
               InteractiveCommonMethods.ClickOnSendToNotebookButton(BackUpAndRestoreAutomationAgent);
               NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(BackUpAndRestoreAutomationAgent);
               NotebookCommonMethods.VerifyNotebookdrawRegionExists(BackUpAndRestoreAutomationAgent);
               int pageNumber = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
               NotebookCommonMethods.VerifyInteractiveInNotebook(BackUpAndRestoreAutomationAgent);
               NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 2);

               NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
               NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
               BackUpAndRestoreAutomationAgent.WaitforElement("NotebookView", "HandTool", "", WaitTime.MediumWaitTime);
               int pageNumber1 = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
               if (pageNumber == pageNumber1)
               {
                   NotebookCommonMethods.ClickOnMediaButton(BackUpAndRestoreAutomationAgent);
                   NotebookCommonMethods.ClickonCamerabutton(BackUpAndRestoreAutomationAgent);
                   NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(BackUpAndRestoreAutomationAgent);
                   LoginCommonMethods.ClickGreenMark(BackUpAndRestoreAutomationAgent);
                   NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent);

                   NotebookCommonMethods.ClickOnMediaButton(BackUpAndRestoreAutomationAgent);
                   NotebookCommonMethods.ClickOnAudionIcon(BackUpAndRestoreAutomationAgent);
                   InboxCommonMethods.ClickOnRecordButton(BackUpAndRestoreAutomationAgent);
                   BackUpAndRestoreAutomationAgent.Sleep(2000);
                   InboxCommonMethods.ClickOnRecordButton(BackUpAndRestoreAutomationAgent);
                   InboxCommonMethods.VerifyAudioCapturedOnNotebook(BackUpAndRestoreAutomationAgent);
                   NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 1);

               }
               else
                   Assert.Fail("Else Condition");
           }
           

       }

       public static int DeleteAssetsInNotebookCanvas(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreAutomationAgent.WaitforElement("NoteBookView", "HandTool", "", WaitTime.MediumWaitTime);
           verifyAssets(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreCommonMethods.RemoveAudio(BackUpAndRestoreAutomationAgent);
           BackUpAndRestoreCommonMethods.RemoveImage(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickToSelectIntercativeImageFromNotebook(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);
           int pageNumber1 = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
           return pageNumber1;

       }
       public static bool VerifyInteractiveInNotebook(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           return BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "NotebookInteractive");
       }

       public static void VerifyCreateEditAndDeletedPages(AutomationAgent BackUpAndRestoreAutomationAgent, int pageNo,int pageDeleted,string editnote,string createnote)
       {
           if (BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
           {
               NotebookCommonMethods.ClickOnNextArrow(BackUpAndRestoreAutomationAgent);
           }
           Assert.IsTrue(NotebookCommonMethods.VerifyArrowsNotPresentInNotebookCanvas(BackUpAndRestoreAutomationAgent), "Page is not deleted");                        
           int pageCreate = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);           
           
           while((pageNo+1).Equals(pageCreate))
           {
               NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
               Assert.IsTrue(InboxCommonMethods.VerifyDataSaved(BackUpAndRestoreAutomationAgent, "Created Page"),"Page is not created");
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

           }
           NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
           int pageEdit = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
           while(pageEdit.Equals(pageNo))
           {
               NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
               Assert.IsTrue(InboxCommonMethods.VerifyDataSaved(BackUpAndRestoreAutomationAgent, "Edited Page"),"Page is not edited");
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
               if(BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
               {
                   NotebookCommonMethods.ClickOnNextArrow(BackUpAndRestoreAutomationAgent);
               }

           }
           

       }

       public static int VerifyOfflineBehaviorforNotebook(AutomationAgent BackUpAndRestoreAutomationAgent,string loginName)
       {          
           
           BackUpAndRestoreAutomationAgent.Sleep(5000);
           NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
           int pagecountWhenWifiOff = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
           EditNotebook(BackUpAndRestoreAutomationAgent, "Edited Offline Page");
           CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Created Offline Page");
           int deletedPageInOffline = DeleteNotebookPage(BackUpAndRestoreAutomationAgent, pagecountWhenWifiOff);

           LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
           InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, loginName);
           VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountWhenWifiOff, deletedPageInOffline, "Edited Offline Page", "Created Offline Page");
           return deletedPageInOffline;
       }

       public static void DeleteStampInNotebookCanvas(AutomationAgent BackUpAndRestoreAutomationAgent)
       {
           NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
           Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(BackUpAndRestoreAutomationAgent), "Tool not active");
           NotebookCommonMethods.ClickOnStampButton(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickToChooseStampCone(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 600, 400);
           NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 600, 400);
           Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(BackUpAndRestoreAutomationAgent), "Dashed line not found");
           NotebookCommonMethods.VerifyRemoveBUtton(BackUpAndRestoreAutomationAgent);
           NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);
           Assert.IsFalse(NotebookCommonMethods.VerifySelectedStampWithDashedLine(BackUpAndRestoreAutomationAgent), "Dashed line found");
           BackUpAndRestoreAutomationAgent.Sleep(5000);
           NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

       }

       public static void VerifyOfflineCreateEditAndDeletedPagesInDevices(AutomationAgent BackUpAndRestoreAutomationAgent, int pageNo, int pageDeleted)
       {
           if (BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
           {
               NotebookCommonMethods.ClickOnNextArrow(BackUpAndRestoreAutomationAgent);
           }
           Assert.IsTrue(NotebookCommonMethods.VerifyArrowsNotPresentInNotebookCanvas(BackUpAndRestoreAutomationAgent), "Page is not deleted");
           int pageDelete = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
           while ((pageDeleted).Equals(pageDelete + 2))
           {
               Assert.IsTrue(NotebookCommonMethods.VerifyArrowsNotPresentInNotebookCanvas(BackUpAndRestoreAutomationAgent), "Offline deleted Page is not restored");               

           }
           NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
           int pageOnlineCreate = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
           while (pageOnlineCreate.Equals(pageNo+1))
           {
               NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
               Assert.IsTrue(InboxCommonMethods.VerifyDataSaved(BackUpAndRestoreAutomationAgent, "Created Page"), "Online Created Page is not present");
               NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
               NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 600, 400);
               Assert.IsFalse(NotebookCommonMethods.VerifySelectedStampWithDashedLine(BackUpAndRestoreAutomationAgent), "Dashed line found");
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
           }
               NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
               int pageOnlineEdit = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
               while (pageOnlineEdit.Equals(pageNo))
            {
               NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
               Assert.IsTrue(InboxCommonMethods.VerifyDataSaved(BackUpAndRestoreAutomationAgent, "Edited Page"),"Page is not edited");
               NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
               if(BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "PageArrowRight"))
               {
                   NotebookCommonMethods.ClickOnNextArrow(BackUpAndRestoreAutomationAgent);
               }

           }


       }
       public static string InitialStepsToReachUnitSelectionScreen(AutomationAgent BackUpAndRestoreAutomationAgent, string teacherName)
       {

           LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin(teacherName));
           TaskInfo taskInfo = Login.GetLogin(teacherName).GetTaskInfo("ELA", "Notebook");
           String[] UnitStatus = LoadUnitStatusFromAdditionalInfo(taskInfo);
           NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
           NavigationCommonMethods.ClickOnUnitSlectionButton(BackUpAndRestoreAutomationAgent);
           return UnitStatus[0];
          
       }

       


       



    }
}
