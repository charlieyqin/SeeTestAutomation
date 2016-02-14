using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{

    public static class ShareFunctionalityCommonMethods
    {

        /// <summary>
        /// Verify while sharing Shared Notebook overlay is present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifySelectPageOvelayPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("NotebookTopMenuView", "SelectPageOverlay")).ToString();
        }
        /// <summary>
        /// Click on Sharing Cancel Icon
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>       
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickSharingCancelButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("NotebookTopMenuView", "SharingCancelButton");
        }
        /// <summary>
        /// Tapping outside the overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOutsideOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("LessonBrowserView", "LessonBrowserPageTitle");

        }
        /// <summary>
        /// Clicking on sharing notification icon to view the notifications
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickSharedWorkIcon(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("TasksTopMenuView", "SharingNotificationIcon ");

        }
        /// <summary>
        /// Verfify RecievedWork Overlay Present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifyRecievedWorkOverlayPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ReceivedWorkView", "ReceivedWorkTitle"));
        }
        /// <summary>
        /// Clicking on done button to navigate back to work browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickDoneButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SharedWorkDoneButton");

        }

        /// <summary>
        /// Clicking on MyClassFilter under WorkBrowser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickMyClassFilter(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("WorkBrowser", "MyClassInMyWork");

        }

        /// <summary>
        /// Clicking on MyTeacherFilter under WorkBrowser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickMyTeacherFilter(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "MyTeacherFilter");

        }


        /// <summary>
        /// Verifying the user on MyClassfilter page
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void VerifyMyClassPage(AutomationAgent sharefunctionalityAutomationAgent, string grade = "9")
        {
            sharefunctionalityAutomationAgent.IsElementFound("ShareView", "MyClassGrade", grade);
        }
        /// <summary>
        /// Verifying the user on MyClassfilter page
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void VerifyMyTeacherPage(AutomationAgent sharefunctionalityAutomationAgent, string grade = "9")
        {
            sharefunctionalityAutomationAgent.IsElementFound("ShareView", "MyTeacherGrade", grade);

        }

        /// <summary>
        /// Click on MyWork Filter under Work Browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickonMyWorkFilter(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "MyWorkFilter");

        }


        /// <summary>
        /// Click on Recieved Work under Work Browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickOnRecievedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "RecievedWork");

        }

        /// <summary>
        /// Click on SharingWork Icon in Work Browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickOnWorkBrowserSharingIcon(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "RecievedWork");

        }


        /// <summary>
        /// Verify that SharedNotebook Icon is Present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static string VerifyShareNotebookIconPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("TasksTopMenuView", "SharingNotificationIcon")).ToString();
        }

        /// <summary>
        /// Verify that SharedWork Overlay is present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifySharedWorkOverlayPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SharedNotificationPresent")).ToString();
        }

        /// <summary>
        /// Click on SharedWork Icon while user at MyDashboard location
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnSharedWorkNotificationIcon(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SharingWorkNotificationIcon");

        }

        /// <summary>
        /// Verfify tiles would default show associated section 
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifyDefaultAssociatedSectionPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "AssociatedSectionSelected")).ToString();

        }

        /// <summary>
        /// Verfify Notebook Share icon is Present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifyNotebookShareIconPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ReceivedWorkView", "NotebookShareIcon")).ToString();

        }

        /// <summary>
        /// Click on latest Shared Work i.e. first tile in Notification 
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnLatestSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SharedNotificationPresent");

        }

        /// <summary>
        /// Click on Recieved Work Tile
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnReceivedWorkTile(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ReceivedWorkView", "ReceivedWorkTile");

        }

        /// <summary>
        /// Click on Image View Button
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnImageViewButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ReceivedWorkView", "ImageViewButton");

        }

        /// <summary>
        /// Click on Latest Share Work Tile in Work Browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnLatestWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "LatestSharedWork");

        }

        /// <summary>
        /// Click on Image View Button
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnSentButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SentIcon");

        }

        /// <summary>
        /// Verify the no. of pages Sent
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void VerifyNumberofPages(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SentWorkNumberofPages");

        }
        /// <summary>
        /// Verify Sent work details of ELA Unit1 DemonstrationResponse  Notebook
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void VerifySentDetails(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SentWorkDetails");

        }

        /// <summary>
        /// Select Section 34 per5 for teacher
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void SelectSharingSection(AutomationAgent sharefunctionalityAutomationAgent)
        {
            System.Threading.Thread.Sleep(2000);
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectSectionForShareWork");

        }

        /// <summary>
        /// Select Section 34 per5 for teacher
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickOnNextButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SharingNextButton");

        }

        /// <summary>
        /// Select Student Bruce P Buckingham
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void SelectStudentForSharing(AutomationAgent sharefunctionalityAutomationAgent, string personname)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectStudentForSharing", personname);
        }

        /// <summary>
        /// Click on Send Button
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnSendButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("SelectRecipientsView", "SendButton");

        }

        /// <summary>
        /// Click on My Work ELA Grade9
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickDropDownButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "WorkBrowserDropDownButton");

        }

        /// <summary>
        /// Verify Demostration Response Work is Revieved 
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static string VerifySentWorkRecieved(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SentWorkRecieved")).ToString();
        }

        /// <summary>
        /// Select student LOIS T N Campisano 
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void SelectStudentCampisano(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectStudentCampisano");

        }

        /// <summary>
        /// Verify message "Your Work Will be Sent"
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifyYourWillWorkSent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "WorkWillBeSentMessage")).ToString();

        }

        /// <summary>
        /// Click on OK button
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickOkButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.WaitforElement("GradeSelectionMenuView", "OKButton", "", WaitTime.LargeWaitTime))
            {
                sharefunctionalityAutomationAgent.Click("GradeSelectionMenuView", "OKButton");
            }
        }
        /// <summary>
        /// Verify the sent message and wait before click on OK button
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void VerifyWorkSuccesfulyShared(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.WaitForElement("ShareView", "WorkSharedSuccesfullyMessage", WaitTime.LargeWaitTime))
            {
                sharefunctionalityAutomationAgent.Click("ShareView", "WorkSharedSuccesfullyMessage");
                sharefunctionalityAutomationAgent.Click("AnnotationMenuView", "OKButton");
            }
        }

        /// <summary>
        /// Click to open latest received work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickToOpenLatestReceivedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.IsElementFound("ReceivedWorkView", "TapToDownloadReceived"))
            {
                sharefunctionalityAutomationAgent.Click("ReceivedWorkView", "TapToDownloadReceived");
                System.Threading.Thread.Sleep(10000);
            }
            sharefunctionalityAutomationAgent.Click("ReceivedWorkView", "ReceivedWorkFirstTile");
        }

        /// <summary>
        /// Verify work received
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <param name="work">string object: work received</param>
        public static bool VerifyWorkRecieved(AutomationAgent sharefunctionalityAutomationAgent, string work)
        {
            string s = sharefunctionalityAutomationAgent.GetText("TEXT");
            return s.Contains("TestNote");
        }

        /// <summary>
        /// Verifies Shared Work Notification Icon present or not
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySharedWorkNotificationIcon(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SharingWorkNotificationIcon");
        }

        /// <summary>
        /// Verifies Shared Work List present or not
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySharedWorkList(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "LatestSharedWork");
        }

        /// <summary>
        /// Verify date of sent notebook
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        public static bool VerifyDateOfSentNotebook(AutomationAgent sharefunctionalityAutomationAgent, string date1, string date2 = "")
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "DateOnReceivedNotebook", date1)
                || sharefunctionalityAutomationAgent.IsElementFound("ShareView", "DateOnReceivedNotebook", date2);
        }

        /// <summary>
        /// Verify elemnts in share button pop up
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        public static void VerifyElementsInShareButtonPopUp(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.VerifyElementFound("ShareView", "CancelButtonInShareOverlay");
            sharefunctionalityAutomationAgent.VerifyElementFound("ShareView", "NextButtonInShareOverlay");

        }

        /// <summary>
        /// Click on cancel button in common read share overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void CLickonCancelInCommonReadShareOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "CancelButtonInShareOverlay");
        }

        /// <summary>
        /// Verifies the share over lay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if ofund</returns>
        public static bool VerifyShareOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "ShareMessageOverlay");
        }

        /// <summary>
        /// VErify send button active 
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySendActive(AutomationAgent sharefunctionalityAutomationAgent)
        {
            string enable = sharefunctionalityAutomationAgent.GetAllValues("ShareView", "NextButtonInShareOverlay", "enabled")[0];
            return enable.Equals("true");
        }

        /// <summary>
        /// Verify teacher selected 
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        public static bool VerifyRecepientSelected(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SelectedTeacher");
        }

        public static bool VerifyAnnotationMenuPresent(AutomationAgent sharefunctionalityAutomationAgent, AnnotationType annotationType, string textToAnnotate)
        {
            try
            {
                sharefunctionalityAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                sharefunctionalityAutomationAgent.Sleep(3000);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify Next Button Lower Right Corner
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyNextButtonLowerRightCorner(AutomationAgent sharefunctionalityAutomationAgent)
        {
            int xPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayNextButton", "x")[0]);
            int yPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayNextButton", "y")[0]);
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "PageOverLayNextButton") && xPos < 1620 && yPos < 400)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify X Button On Upper Right Corner
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyXButtonOnUpperRightCorner(AutomationAgent sharefunctionalityAutomationAgent)
        {
            int xPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayXButton", "x")[0]);
            int yPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayXButton", "y")[0]);
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "PageOverLayXButton") && xPos < 1400 && yPos < 400)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify Pages Selected In Centre
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyPagesSelectedInCentre(AutomationAgent sharefunctionalityAutomationAgent)
        {
            int xPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayPagesSelected", "x")[0]);
            int yPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayPagesSelected", "y")[0]);
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "PageOverLayPagesSelected") && xPos < 400 && yPos < 400)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click X Button On Upper Right Corner
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        public static void ClickXButtonOnUpperRightCorner(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "PageOverLayXButton");
        }
        /// <summary>
        /// Verify SelectAll Button On Lower Left Corner
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySelectAllButtonOnLowerLeftCorner(AutomationAgent sharefunctionalityAutomationAgent)
        {
            int xPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLaySelectAllButton", "x")[0]);
            int yPos = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLaySelectAllButton", "y")[0]);
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "PageOverLaySelectAllButton") && xPos < 350 && yPos < 400)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify Select Pages Overlay Dislayed
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySelectPagesOverlayDislayed(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SelectPageOverlay");
        }

        /// <summary>
        /// Verify Teacher Shared Work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyTeacherSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "TeacherSharedWork");
        }

        /// <summary>
        /// Click on GoToWorkBrowser button under SahredNotificationDropDown
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static void ClickSharedWorkGoToWorkBrowser(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("TasksTopMenuView", "GoToWorkBrowserButton");
        }

        /// <summary>
        /// Click on Section35 Period 5 under My Work Filter for Teacher
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        ///  <author>Shivank Laul(shivank.laul)</author> 
        public static void SelectSectionPeriod(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "Section35Period5");
        }

        /// <summary>
        /// Click on My Work Filter for Teacher with assigned section
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickFilterDropDown(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "MyWorkDropFilter");
        }

        /// <summary>
        /// Click on the Selected Work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <param name="pageNumber"></param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnSentWorkSelection(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SentWorkSelection");
        }

        /// <summary>
        /// Verify Student Bruce Buckingham		
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <param name="pageNumber"></param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifyStudentBruce(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("AnnotationMenuView", "StudentBruce")).ToString();
        }


        /// <summary>
        /// Verify latest shared work details like Sender name , name of lesson ,unit and task underSharedNotificationDropDown
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <param name="pageNumber"></param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifyNotificationSharedWorkDetails(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SharedNotificationDetails")).ToString();
        }

        /// <summary>
        /// Verify the Sender Avatar under SharedNotification DroDown
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <param name="pageNumber"></param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static string VerifySenderAvatar(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("CommonReadPageView", "NotificationAvtar")).ToString();
        }

        /// <summary>
        /// Verifies the pages and page numbers in share overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <param name="noOfPages">No of pages</param>
        /// <returns>boolean status of page and page numbers existence</returns>
        public static bool VerifyPagesInShareSelectPagesOverlay(AutomationAgent sharefunctionalityAutomationAgent, int noOfPages)
        {
            bool result = false;
            for (int i = 1; i <= noOfPages; i++)
            {
                if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "PageItemInSelectPages", i.ToString()))
                {
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// Verifies if the checkbox is displayed
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <param name="noOfPages">No of pages</param>
        /// <returns>false if a checkbox is shown</returns>
        public static bool VerifyNoCheckboxIsDisplayed(AutomationAgent sharefunctionalityAutomationAgent, int noOfPages)
        {
            bool result = true;
            for (int i = 1; i <= noOfPages; i++)
            {
                if (!bool.Parse(sharefunctionalityAutomationAgent.GetElementProperty("ShareView", "CheckMarkInSelectPages", "hidden", i.ToString())))
                {
                    result = false;
                }
            }
            return result;
        }
        /// <summary>
        /// Selects a page by clicking on it
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <param name="pageNumber"></param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickPageInSelectSharePagesOverlay(AutomationAgent sharefunctionalityAutomationAgent, int pageNumber)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "PageItemInSelectPages", pageNumber.ToString());
        }
        /// <summary>
        /// Verifies the checkbox and outline of the selected page
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <param name="pageNumber">Page Number</param>
        /// <returns>boolean status</returns>
        public static bool VerifySelectedPage(AutomationAgent sharefunctionalityAutomationAgent, int pageNumber)
        {
            string boolVal1 = sharefunctionalityAutomationAgent.GetElementProperty("ShareView", "CheckMarkInSelectPages", "hidden", pageNumber.ToString());
            string boolVal2 = sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageItemInSelectPages", pageNumber.ToString(), "backgroundColor")[0];
            return bool.Parse(boolVal1) && boolVal2.Equals("0x198098");
        }
        /// <summary>
        /// Verifies if all the pages are selected
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent Object</param>
        /// <returns>boolean status</returns>
        public static bool VerifyAllPagesSelected(AutomationAgent sharefunctionalityAutomationAgent, int noOfPages)
        {
            bool result = false;
            for (int i = 1; i <= noOfPages; i++)
            {
                result = !bool.Parse(sharefunctionalityAutomationAgent.GetElementProperty("ShareView", "CheckMarkInSelectPages", "hidden", i.ToString())) &&
                    sharefunctionalityAutomationAgent.GetElementProperty("ShareView", "PageItemInSelectPages", "backgroundColor", i.ToString()) == "0x198098";
            }
            return result;
        }
        /// <summary>
        /// Clicks on the Select all button
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickSelectAllButtonInOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectAllButtonInOverlay");
        }
        /// <summary>
        /// Verifies if the select all button is checked
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns>boolean status of select all button checked</returns>
        public static bool VerifySelectAllButtonChecked(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "HighlightedSelectAllButtonInOverlay");
        }
        /// <summary>
        /// Verifies if the select all button is not checked
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns>boolean status of select all button checked</returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifySelectAllButtonNotChecked(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "NormalSelectAllButtonInOverlay");
        }
        /// <summary>
        /// Verifies if the next button is enabled
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean status of next button enabled</returns>
        public static bool VerifyNextButtonEnabled(AutomationAgent sharefunctionalityAutomationAgent)
        {
            string alpha = sharefunctionalityAutomationAgent.GetAllValues("ShareView", "PageOverLayNextButton", "", "alpha")[0];
            return alpha.Equals("1");
        }
        /// <summary>
        /// Clicks on Next button in select pages overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent Object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnNextButtonInSelectPageOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "PageOverLayNextButton");
        }
        /// <summary>
        /// Gets the No of pages selected
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent</param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static int GetNoOfPagesSelected(AutomationAgent sharefunctionalityAutomationAgent, string page)
        {
            string selectedPagesText = sharefunctionalityAutomationAgent.GetElementText("ShareView", "PageOverLayPagesSelected", page);
            string[] pageNoText = selectedPagesText.Split(' ');
            return int.Parse(pageNoText[0]);
        }

        /// Verifies if the Date is missing consider as Today's Work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyTodayWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "PageOverLayNextButton");
        }

        /// Verify Latest Work is Downloaded if not Click Tap on download
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "WorkBrowserTapToDownload"))
            {
                sharefunctionalityAutomationAgent.Click("ShareView", "WorkBrowserTapToDownload", 2);
                System.Threading.Thread.Sleep(10000);
            }
            sharefunctionalityAutomationAgent.Click("ShareView", "ELACommonRead");
        }

        /// Verifies if Latest Shared common read present in Work Browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static string VerifyCommonRead(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "ELACommonRead")).ToString();
        }
        /// <summary>
        /// Verifies the send button for disabled state
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifySendButtonDisabledColor(AutomationAgent sharefunctionalityAutomationAgent)
        {
            string alpha = sharefunctionalityAutomationAgent.GetAllValues("ShareView", "SendButtonEnabled", "alpha")[0];
            return !alpha.Equals("1");
        }
        /// <summary>
        /// Verifies the send button for enabled state
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifySendButtonEnabledColor(AutomationAgent sharefunctionalityAutomationAgent)
        {
            string alpha = sharefunctionalityAutomationAgent.GetAllValues("ShareView", "SendButtonEnabled", "alpha")[0];
            return alpha.Equals("1");
        }
        /// <summary>
        /// Verifies the color of the ELA tile
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifyELATileColor(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.GetElementProperty("ShareView", "ELATileHeader", "backgroundColor") == "0x0031C3";
        }
        /// <summary>
        /// Verifies the color of the Math tile
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifyMathTileColor(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.GetElementProperty("ShareView", "MathTileHeader", "backgroundColor") == "0x135A00";
        }



        /// <summary>
        /// Verifies Sent Button is present with no .of shared pages of Notebook sent under Work Browser My Work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifySentButtonPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SentIcon");

        }

        /// <summary>
        /// Verifies Sent Work Overlay present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifySentWokOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("WorkBrowserView", "SentWorkOverlayTitle");
        }

        /// <summary>
        /// Verifies To: label in Sent Work overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifyToLabel(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "Sent Work To:");
        }

        /// <summary>
        /// Clicks on Next button in select pages overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent Object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickCloseInSentWorkOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("WorkBrowserView", "ClickCloseInSentWorkOverlay");
        }

        // <summary>
        /// Verifies Demonstration response shared notebook
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifyDemonstrationResponseSharedNotebook(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("PersonalNotesView", "DemonstrationResponse");
        }

        // <summary>
        /// Verifies Common Read Sent Details under Sent Work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifyCommonReadSentDetails(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SentCommonReadDetails");
        }


        /// <summary>
        /// Verifies that latest edited work is at first position
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent"></param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void VerifyFirstSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            int NotebookX = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "FirstSharedWorkTile", "x")[0]);
            int NotebookY = Int32.Parse(sharefunctionalityAutomationAgent.GetAllValues("ShareView", "FirstSharedWorkTile", "y")[0]);
            sharefunctionalityAutomationAgent.Equals(NotebookX = 40);
            sharefunctionalityAutomationAgent.Equals(NotebookY = 304);
        }

        /// <summary>
        /// Verify Latest Shared Notebook is Downloaded if not Click Tap on download
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnSharedNotebook(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.IsElementFound("ReceivedWorkView", "TapToDownloadReceived"))
            {
                sharefunctionalityAutomationAgent.Click("ReceivedWorkView", "TapToDownloadReceived", 2);
                System.Threading.Thread.Sleep(10000);
            }
            sharefunctionalityAutomationAgent.Click("PersonalNotesView", "DemonstrationResponse");
        }

        /// <summary>
        /// Clicking on done button to navigate back to work browser
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickWorkBrowserDoneButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "WorkBrowserDoneButton");

        }
        /// <summary>
        /// Finding the Unit 1-Lesson 2-Task 4 Common read under My Work
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void VeriyReadAloudCommonRead(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "ReadAloudCommonRead");

        }

        /// <summary>
        /// Verify GoTo Work Browser Present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static bool VerifyGoToWorkBrowserPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return (sharefunctionalityAutomationAgent.IsElementFound("TasksTopMenuView", "GoToWorkBrowserButton"));


        }

        /// <summary>
        /// Click on OK button of Notebook/CommonRead after sharing
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void ClickonOKButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("AnnotationMenuView", "OKButton");
        }

        /// <summary>
        /// Click on Select All Button for Selecting pages
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static void SelectAllPagesButton(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectAllButton");

        }

        /// <summary>
        /// Verify default section selected for sectioned teacher Altagracia
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifyAltagraciaSectionView(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "MyWorkSec34Per5");

        }

        /// <summary>
        /// Verify ELA Unit1 Lesson 1 is shared
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifyELAunitDetails(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "ELASharedDetails");

        }

        /// <summary>
        /// Verify ELA Common Read shared by Altagracia Lindie,  verify under notification panel
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifyELACommonReadSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "ELACommonReadSharedWork");

        }


        /// <summary>
        /// Verify ELA Unit1 Lesson 1 is shared
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 

        public static bool VerifyAnnotationOptionPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "AnnotationButton");

        }

        /// <summary>
        /// Downloads and open received notebook
        /// 1. Verifies if tap to download link is available
        /// 2. Clicks to download if not already downloaded
        /// 3. Opens shared notebook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnWorkBrowserSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "WorkBrowserTapToDownloadButton"))
            {
                sharefunctionalityAutomationAgent.Click("ShareView", "WorkBrowserTapToDownloadButton");
                System.Threading.Thread.Sleep(5000);
            }
            sharefunctionalityAutomationAgent.Click("ShareView", "SharedWorkAvatar");
        }

        /// <summary>
        /// Clicks on MyClass ELA Grade 9 filter in Work Browser///</summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent Object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickMyClassDropDownFilter(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "MyClassGrade9Filter");
        }

        /// <summary>
        /// Downloads and open received common read under Shared Work Notification panel
        /// 1. Verifies if tap to download link is available
        /// 2. Clicks to download if not already downloaded
        /// 3. Opens shared common read
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickOnCommonReadSharedWork(AutomationAgent sharefunctionalityAutomationAgent)
        {
            if (sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SharedWorkCommonReadTapToDownload"))
            {
                sharefunctionalityAutomationAgent.Click("ShareView", "SharedWorkCommonReadTapToDownload");
                System.Threading.Thread.Sleep(5000);
            }
            sharefunctionalityAutomationAgent.Click("ShareView", "ImageButton");
        }

        /// <summary>
        /// Clicking on MyClassFilter under WorkBrowser for Sec-34 Per5
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <author>Shivank Laul(shivank.laul)</author> 
        public static void ClickTeacherMyClass(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("WorkBrowserView", "DefaultSectionOfTiles");

        }
        public static void SelectStudentIsao(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectStudentIsao");
        }

        public static void SelectStudentDarien(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectStudentDarien");
        }

        public static void SelectStudentMarkiva(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SelectStudentMarkiva");
        }

        public static void SelectTeacherAltagracia(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("WorkBrowserView", "SelectTeacherAltagracia");
        }

        public static void WaitForReceivedNotebookToDownload(AutomationAgent sharefunctionalityAutomationAgent)
        {
            while (sharefunctionalityAutomationAgent.IsElementFound("WorkBrowserView", "DownloadProgressBar") && sharefunctionalityAutomationAgent.IsElementFound("WorkBrowserView", "DownloadingLabel"))
            {
                sharefunctionalityAutomationAgent.WaitForElementToVanish("WorkBrowserView", "DownloadProgressBar");
            }
        }
        /// <summary>
        /// Click Recieved Notebook In Browse Overlay
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        public static void ClickRecievedNotebookInBrowseOverlay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SharedNotebookInBrowseOverlay");
        }
        /// <summary>
        /// Verify BrowseNotes Overlay is Present
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyBrowseNotesOverlayPresent(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("NotebookView", "BrowseNotesOverlay");
        }
        /// <summary>
        /// Verify Shared Notebook is Open or not
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySharedNotebookOpen(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("NotebookTopMenuView", "CommentIcon");
        }
        /// <summary>
        /// Verify User Notebook Is Opened or not
        /// </summary>
        /// <param name="sharefunctionalityAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyUserNotebookIsOpened(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("NotebookWorkBrowserView", "WorkBrowserIcon");
        }

        public static bool VerifyNotificationDropdownDisplayed(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "NotificationDropdown");
        }

        public static bool VerifyMostRecentNotificationDispalyedFirst(AutomationAgent sharefunctionalityAutomationAgent)
        {
            string TextinFirstItem = sharefunctionalityAutomationAgent.GetTextIn("ShareView", "ArrowInNotificationDropdown", "Left", "", 0, 0);
            string[] DateTimePart = TextinFirstItem.Split('\t');
            string[] sentdate = DateTimePart[2].Split(',');
            DateTime currentDate = DateTime.Now;
            currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0);
            string InFormat = currentDate.ToString();
            var date = DateTime.Parse(InFormat);
            string FormattedDate = date.ToString("MMM dd");
            if (FormattedDate == sentdate[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyXNumberOfNotebooksReceived(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "ReceivedTileNumber");
        }

        public static bool VerifySelectRecipients(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SelectRecipientsLabel");
        }

        public static void CloseShareMessageOverLay(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "CloseButtonInShareOverlay");
        }

        public static bool VerifyUsernameHasCheckBoxAgainstIt(AutomationAgent sharefunctionalityAutomationAgent, string userName)
        {
            return sharefunctionalityAutomationAgent.IsElementFound("ShareView", "SelectedUserCheckBox", userName);
        }

        public static bool VerifyAllStudentsSelected(AutomationAgent sharefunctionalityAutomationAgent)
        {
            return sharefunctionalityAutomationAgent.GetElementCount("ShareView", "SelectedTeacher") == sharefunctionalityAutomationAgent.GetElementCount("ShareView", "SelectRecipientsTableCell");
        }

        public static void ClickTapToDownloadInSharedWorkNotification(AutomationAgent sharefunctionalityAutomationAgent)
        {
            sharefunctionalityAutomationAgent.Click("ShareView", "SharedNotificationTapToDownload");
        }
    }

}

