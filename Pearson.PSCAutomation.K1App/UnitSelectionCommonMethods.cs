using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;

using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pearson.PSCAutomation.K1App
{

    public static class UnitSelectionCommonMethods
    {

        /// <summary>
        /// Verify System Tray Icon is available on left corner after login
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void VerifySystemTrayIcon(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "SystemTray");
        }

        /// <summary>
        /// Verify ELA and MATHS Columns titles Images (by taking controls from default folder) and title KINDERGARTEN
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void VerifyColumnsTitles(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "ELAUnitTitleImage");
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "MATHUnitTitleImage");
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "ELAColumnTitle");
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "MathColumnTitle");
        }

        /// <summary>
        /// Get ELA Unit Column coordinate and store in str array 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>string: coordinate of ELA unit columns</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static string[] GetELAColumnPosition(AutomationAgent UnitSelectionAutomationAgent)
        {
            string ela_coordinate = UnitSelectionAutomationAgent.GetPosition("UnitSelection", "ELAUnitColumn");
            string[] str = ela_coordinate.Split(',');
            return str;

        }

        /// <summary>
        /// Get Math Unit Column coordinate and store in str array 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>string: coordinate of ELA unit columns</returns>
        /// <author>Namrita (namrita.agarwal)</author>
        public static string[] GetMathColumnPosition(AutomationAgent UnitSelectionAutomationAgent)
        {
            string math_coordinate = UnitSelectionAutomationAgent.GetPosition("UnitSelection", "MathUnitColumn");
            string[] str = math_coordinate.Split(',');
            return str;
        }

        /// <summary>
        /// Verify Screen Background and take controls from default folder
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void VerifyScreenBackground(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "ScreenBackground");
        }

        /// <summary>
        /// Verify ELA Unit Button display grey if content is not downloaded
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoContentDownloadedELAButton(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "ScreenBackground");
        }

        /// <summary>
        /// Verify Math Unit Button display grey if content is not downloaded
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoContentDownloadedMathButton(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "ScreenBackground");
        }

        /// <summary>
        /// Verify that the width of ELA and Math columns is same through out the the page
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static bool VerifyWidhtOfColumns(AutomationAgent UnitSelectionAutomationAgent)
        {
            string[] elaColumn_width = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "ELAUnitColumn", "width");
            string[] mathColumn_width = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "MathUnitColumn", "width");
            if (elaColumn_width[0].Equals(mathColumn_width[0]))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify that the status bar display should be white
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <param name="statusBarIndex">int object: passing status bar index</param>
        public static bool VerifyWhiteStatusBar(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "StatusBar");
        }
        /// <summary>
        /// Verify that user is on the unit selection screen
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitSlectionScreen(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "ELAColumnTitle");
        }

        /// <summary>
        /// Verify that the  each user has only one book log 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserHasOneCommonBookLog(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("UnitSelection", "BookLogItemImage", "1"))
            {
                navigationAutomationAgent.VerifyElementFound("UnitSelection", "BookLogItemImage", "1");
            }
            else
            {
                navigationAutomationAgent.Click("UnitSelection", "AddButtonInBookLog");
                NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(navigationAutomationAgent);
                NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                navigationAutomationAgent.VerifyElementFound("UnitSelection", "BookLogItemImage", "1");
            }
        }

        /// <summary>
        /// Verify Camera Icon display in booklog popup
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyCameraInBooklogPopup(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "CameraInBookogPopup");
        }

        /// <summary>
        /// Verify Book Log Camera mode opened
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyBooklogCameraModeOpen(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CameraIconInBookogCamMode");
        }

        /// <summary>
        /// Verify below items when camera mode open in booklog
        /// 1. Red cross icon
        /// 2. Photo imgae
        /// 3. Green tick mark icon
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyBookLogCameraModeOptions(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "CrossIconInBookogCamMode");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "PhotoImageInBookogCamMode");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "CameraIconInBookogCamMode");
        }

        /// <summary>
        /// Verify below items when camera mode open in booklog
        /// 1. Red cross icon
        /// 2. Photo imgae
        /// 3. Green tick mark icon
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyOptionsWhenPhotoCaptured(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "CrossIconInBookogCamMode");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "GreenIconInBookogCamMode");
        }

        /// <summary>
        /// Verify the width of camera and cross icon is same
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>return: true if width of camera icon and cross icon is same</returns>
        public static bool VerifyWidhtOfCrossAndCameraIcon(AutomationAgent UnitSelectionAutomationAgent)
        {
            string[] cameraIcon = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "CameraIconInBookogCamMode", "width");
            string[] crossIcon = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "CrossIconInBookogCamMode", "width");
            if (cameraIcon[0].Equals(crossIcon[0]))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Verify the width of green tick and red cross icon is same
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>return: true if width of camera icon and cross icon is sam</returns>
        public static bool VerifyWidhtOfCrossAndGreenIcon(AutomationAgent UnitSelectionAutomationAgent)
        {
            string[] greenTickIcon = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "GreenIconInBookogCamMode", "width");
            string[] crossIcon = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "CrossIconInBookogCamMode", "width");
            if (greenTickIcon[0].Equals(crossIcon[0]))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Navigate to lesson
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonnumber">int object: lesson number</param>
        public static void NavigateToLesson(AutomationAgent UnitSelectionAutomationAgent, int lessonnumber)
        {
            int tcount = 0;
            while (!UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "LessonNumber", lessonnumber.ToString()) && tcount <= 20)
            {
                NavigationCommonMethods.ClickToGetNextLesson(UnitSelectionAutomationAgent);
                tcount++;
            }
        }
        /// <summary>
        /// verify that flash open in image viewer
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyFlashCardOpen(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "FLashCardImageViewer");
        }
        /// <summary>
        /// verify that user is on unit homescreen
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserOnUnitHome(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "TodayButton");
        }


        /// <summary>
        /// Verify column header images
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyColumnHeaderImages(AutomationAgent PicturePasswordLoginAutomationAgent)
        {
            PicturePasswordLoginAutomationAgent.IsElementFound("UnitSelection", "ELAUnitTitleImage");
            PicturePasswordLoginAutomationAgent.IsElementFound("UnitSelection", "MATHUnitTitleImage");
        }

        /// <summary>
        /// Verify Today shelf when Today button clicked from unit home screen
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if today shelf is openend</returns>
        public static bool VerifyTodayShelf(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("UnitSelection", "LessonNumber", "1");
        }

        /// <summary>
        /// verify No internet connection message for teacher when try to download bonus content in offline mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if message matched</returns>
        public static bool VerifyNoInternetAlertForBonusContent(AutomationAgent UnitSelectionAutomationAgent)
        {
            string TextonScreen = UnitSelectionAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("No internet connection. You must be connected to the Internet to download units.");
        }
        /// <summary>
        /// Verify the alert message when wi fi is off In ELA unit
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyNoInternetAlertMessageOnELAUnit(AutomationAgent UnitSelectionAutomationAgent)
        {
            string message = UnitSelectionAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return message.Contains("No internet connection. You must be connected to the Internet to access More To Explore");
        }
        /// <summary>
        /// Verify the alert message when wi fi is off in MATH unit
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyNoInternetAlertMessageOnMathUnit(AutomationAgent UnitSelectionAutomationAgent)
        {
            string message = UnitSelectionAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return message.Contains("You must be connected to the Internet to access Concept Corner.");
        }

        /// <summary>
        /// Verify Cancel Download button 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <return>True: if cancel download button display</return>
        public static bool VerifyCancelDownloadButton(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CancelDownload");
        }

        /// <summary>
        /// Verify cliking on unit button which is not downloaded yet display is waiting text..
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>True: if "waiting.." display in unit button</returns>
        public static bool VerifyDownloadIsInPropgress(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "DownloadInProgress");
        }

        /// <summary>
        /// Verify when unit is downloaded
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>True: if unit button is downloaded</returns>
        public static void VerifyUnitDownloaded(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.WaitForElementToVanish("UnitSelection", "DownloadInProgress", WaitTime.MediumWaitTime);
            UnitSelectionAutomationAgent.WaitForElement("UnitSelection", "Downloading");
            while (!UnitSelectionAutomationAgent.WaitForElementToVanish("UnitSelection", "Downloading", WaitTime.MediumWaitTime))
                UnitSelectionAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verify rope images 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyRopeImages(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LeftRope");
            UnitSelectionAutomationAgent.Sleep();
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "RightRope");
        }
        /// <summary>
        /// Verify today shelf open
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTodayShelfOpen(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "LessonNumberImage");
        }
        /// <summary>
        /// Click on the unit intro video button
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitIntroVideoButton(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.Click("UnitSelection", "TodayViewUnitIntroVideoButton");
        }
        /// <summary>
        /// Click to open video from todays shelf
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenVideoFromTodayshelf(AutomationAgent CAadoptionAutomationAgent)
        {
            if (CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayShelfVideo", "", "Right"))
            {
            }
            else
                CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayShelfVideo", "", "Left");
        }
        /// <summary>
        /// Verify lesson Number when todays shelf open.
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <param name="i">int object : lesson number</param>
        public static void VerifyLessonNumber(AutomationAgent UnitSelectionAutomationAgent, int i)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LessonNumber", i.ToString());
        }
        /// <summary>
        /// Verify the title 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if found</returns>
        public static bool VerifyELAGradeTitle(AutomationAgent UnitSelectionAutomationAgent)
        {
            string titletext = (UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "KinderGartenTitle", "text")[0]).Replace("\n", "");

            if (titletext.Equals("KINDERGARTEN"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify Unit 4 image 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUnit1Image(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "UNIT1");
        }
        /// <summary>
        /// Verify Unit 9 image
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUnit9Image(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "Unit9");
        }

        /// <summary>
        /// Verify thumbnail activities display for lessons
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyThumbnailActivitiesForLesson(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "TodayShelfThumbnail");
        }

        /// <summary>
        /// Verify Notebook icon in booklog popup 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotebookIconInBooklogPopup(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "NotebookIconInBookLogItem");
        }

        /// <summary>
        /// Verify Notebook canvas tools in booklog 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotebookCanvasToolsInBookLog(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("BookBuilderView", "Crayon");
            UnitSelectionAutomationAgent.VerifyElementFound("BookBuilderView", "Marker");
            UnitSelectionAutomationAgent.VerifyElementFound("BookBuilderView", "Brush");
            UnitSelectionAutomationAgent.VerifyElementFound("BookBuilderView", "ColorPicker");
            UnitSelectionAutomationAgent.VerifyElementFound("BookBuilderView", "Eraser");
        }

        /// <summary>
        /// Verify partial assert in media library cloud
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyPartialAssetAtBottomOfCloud(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LibraryInCloud", "5");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LibraryInCloud", "6");
        }

        /// <summary>
        /// Click on cross icon to close media library cloud from booklog
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void CloseMediaLibraryCloud(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.Click("UnitSelection", "CloudCloseIcon");
        }

        /// <summary>
        /// Click to select library from media library cloud 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickToSelectLibraryFromCloud(AutomationAgent UnitSelectionAutomationAgent, int index)
        {
            UnitSelectionAutomationAgent.Click("UnitSelection", "LibraryInCloud", index.ToString());
        }

        /// <summary>
        /// Verify if add button present for book log
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if add button is present</returns>
        public static bool VerifyAddBooklogButton(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "AddButtonInBookLog");
        }


        /// <summary>
        /// Click on add button for bookog
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAddBooklogButton(AutomationAgent UnitSelectionAutomationAgent)
        {
            if (UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "AddButtonInBookLog"))
            {
                UnitSelectionAutomationAgent.Click("UnitSelection", "AddButtonInBookLog");
            }
        }

        /// <summary>
        /// Get x coordinate of add button of booklog
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>int: x coordinate of add button of booklog</returns>
        public static int GetAddBooklogButtonPosition(AutomationAgent UnitSelectionAutomationAgent)
        {
            return Int32.Parse(UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "AddButtonInBookLog", "x")[0]);
        }

        /// <summary>
        /// Get x coordinate of last added booklog item
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>int x coordinate of last added booklog item </returns>
        public static int GetAddedBooklogItemPosition(AutomationAgent UnitSelectionAutomationAgent, int itemNo)
        {
            return Int32.Parse(UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "BookLogItemImage", itemNo.ToString(), "x")[0]);
        }

        /// <summary>
        /// Verify booklog is last activity in today shelf 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>False: If there is no element after booklog activity</returns>
        public static bool VerifyBooklogIsLastActivity(AutomationAgent UnitSelectionAutomationAgent)
        {
            //int activityCount = UnitSelectionAutomationAgent.GetElementCount("UnitSelection", "TodayActivityCell");
            UnitSelectionAutomationAgent.GetElementProperty("UnitSelection", "TodayActivityCell", "accessibilityIdentifier", "5").Contains("Booklog");
            return UnitSelectionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayActivityCell", "6", "Right");
        }

        /// <summary>
        /// Get today button position 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>int: today button postion</returns>
        public static int GetTodayButtonPosition(AutomationAgent UnitSelectionAutomationAgent)
        {
            return Int32.Parse(UnitSelectionAutomationAgent.GetPosition("UnitSelection", "TodayButton").Split(',')[1]);
        }

        /// <summary>
        /// Verify unit selction background
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitSelectionBackground(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "UnitSelectionELABackground");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "UnitSelectionMATHBackground");
        }

        /// <summary>
        /// Verify that [Grade 1] appears above Grade 1 units upon scrolling down in either column
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyGrade1AppearOnGrade1Units(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "Grade1WithUnits");
        }

        /// <summary>
        /// Verify student image at system tray
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentImageAtSystemTray(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "TopBarAtSystemTray");
        }

        /// <summary>
        /// Verify teacher support nav icon at system tray
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>True: if system tray will be available</returns>
        public static bool VerifyTeacherSupportAtSystemTray(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "TeacherSupport");
        }

        /// <summary>
        /// Verify Settings nav icon at system tray
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifySettingsAtSystemTray(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "SettingsButton");
        }

        /// <summary>
        /// Verify book builder nav icon at system tray
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyBookBuilderAtSystemTray(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "BookBuilderButton");
        }

        /// <summary>
        /// Verify Inbox nav icon at system tray
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyInboxAtSystemTray(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "InboxButton");
        }

        /// <summary>
        /// Verify Rubric shelf should not display intoday shelf
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyRubricShelfNotDisplayedInTodayShelf(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "eReaderView", "RubricShelf", "", "Right");
        }
        /// <summary>
        /// Verify today shelf Visible after transitioning from unit selection to unit overview screen
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTodayShelfVisible(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "LessonNumberImage");
        }
        /// <summary>
        /// Verify rectangular portion
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyRectangularPortionVisible(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "TodayButton");
        }
        /// <summary>
        /// Verify unit number displayed by default
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUnitNumberDisplayedByDefault(AutomationAgent UnitSelectionAutomationAgent)
        {
            string unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(UnitSelectionAutomationAgent);
            return (!unitNumber.Equals(null));

        }
        /// <summary>
        /// Get the position of the interactive
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: position of interactive</returns>
        public static string[] GetPositionOfInteractive(AutomationAgent UnitSelectionAutomationAgent)
        {
            int tCount = 0;
            while (!UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "TodayShelfInteractive") && tCount <= 10)
            {
                UnitSelectionAutomationAgent.Swipe(Direction.Right);
                tCount++;
            }
            string[] Coordinates = UnitSelectionAutomationAgent.GetPosition("UnitSelection", "TodayShelfInteractive").Split(',');
            return Coordinates;
        }
        /// <summary>
        /// Verify selected interactive in centre 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static bool VerifySelectedInteractiveInCentre(AutomationAgent UnitSelectionAutomationAgent)
        {
            string[] Coordinates = UnitSelectionAutomationAgent.GetPosition("UnitSelection", "TodayShelfInteractive").Split(',');
            int WidthOfNavigationBar = Int32.Parse(UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);

            return ((WidthOfNavigationBar / 2) == Int32.Parse(Coordinates[0]) ? true : false);

        }
        /// <summary>
        /// Verify arrows in reading overlay
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyArrowsInreadingOverlay(AutomationAgent UnitSelectionAutomationAgent)
        {
            return (UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "NextButtonInReadingOverlay") && UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "PrevButtonInReadingOverlay"));

        }
        /// <summary>
        /// Verify books in reading overlay
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyBooksInReadingOverlay(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "BookLogMediaLibraryicon");
        }

        /// <summary>
        /// Verify ELA KINDERGARTEN units order 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyELAKindergartenUnitsOrder(AutomationAgent UnitSelectionAutomationAgent)
        {
            ArrayList getUnitNumber = new ArrayList();

            int kindergartenUnitsCount = UnitSelectionAutomationAgent.GetElementCount("UnitSelection", "KINDERGARTENUnits");

            for (int i = 0; i < kindergartenUnitsCount; i++)
            {
                getUnitNumber.Add(UnitSelectionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i, 0, 0).Replace("\t\n", "").Substring(5));
            }

            getUnitNumber.Sort();

            for (int i = 0; i < getUnitNumber.Count; i++)
            {
                string unitNumberAtScreen = UnitSelectionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i, 0, 0).Replace("\t\n", "").Substring(5);
                getUnitNumber[i].Equals(unitNumberAtScreen);
            }
        }

        /// <summary>
        /// Verify ELA Grade1 units order 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyELAGrade1UnitsOrder(AutomationAgent UnitSelectionAutomationAgent)
        {
            ArrayList getUnitNumber = new ArrayList();

            int grade1UnitsCount = UnitSelectionAutomationAgent.GetElementCount("UnitSelection", "Grade1Units");

            for (int i = 0; i < grade1UnitsCount; i++)
            {
                getUnitNumber.Add(UnitSelectionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i, 0, 0).Replace("\t\n", "").Substring(5));
            }

            getUnitNumber.Sort();

            for (int i = 0; i < getUnitNumber.Count; i++)
            {
                string unitNumberAtScreen = UnitSelectionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i, 0, 0).Replace("\t\n", "").Substring(5);
                getUnitNumber[i].Equals(unitNumberAtScreen);
            }
        }

        /// <summary>
        /// Verify diferent library diusplay in cloud
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyLibraryCollectionInCloud(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LibraryInCloud", "1");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LibraryInCloud", "2");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LibraryInCloud", "3");
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "LibraryInCloud", "4");
        }

        /// <summary>
        /// Verify cloud is scrollable
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <param name="xOffset">xOffset</param>
        /// <param name="yOffset">yOffset</param>
        public static void VerifyCloudIsScrollable(AutomationAgent UnitSelectionAutomationAgent, int xOffset, int yOffset)
        {
            UnitSelectionAutomationAgent.DragElement("UnitSelection", "BooklogCloudCollection", xOffset, yOffset);
        }
        /// <summary>
        /// Verify book reading overlay appear/disappears
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <return>bool object: true if found</return>
        public static bool VerifyBookReadingOverlayAppers(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CloudCloseIcon");
        }

        /// <summary>
        /// Get time stamp for already created booklog
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>return: timestamp</returns>
        public static DateTime GetTimeStampOfBooklog(AutomationAgent UnitSelectionAutomationAgent)
        {
            DateTime timeStamp = DateTime.MinValue;
            if (UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "BookLogCreatedDateLabel"))
            {
                timeStamp = DateTime.Parse(UnitSelectionAutomationAgent.GetElementText("UnitSelection", "BookLogCreatedDateLabel"));
            }
            return timeStamp;
        }

        /// <summary>
        /// Verify today cloud at book log entry
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if display</returns>
        public static bool VerifyTodayCloudAtBooklog(AutomationAgent UnitSelectionAutomationAgent)
        {
            string[] hiddenProperty = UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "TodayAtBookLogItem", "hidden");
            return hiddenProperty[0].Equals("false");
        }
        /// <summary>
        /// Get the label below the item of the book log
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: label of the date</returns>
        public static string GetDateLabelOfItemInBookLog(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.GetAllValues("UnitSelection", "BookLogCreatedDateLabel", "text")[0];
        }

        /// <summary>
        /// Verify Camera icon is highlighted in today shelf
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyCameraHighlightedInTodayShelf(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "HighlightedCameraInTodayShelf");
        }

        /// <summary>
        /// Verify Audio icon is highlighted in today shelf
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyAudioIconHighlightedInTodayShelf(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("UnitSelection", "HighlightedAudioInTodayShelf");
        }

        /// <summary>
        /// Verify that Lesson Standards is displaying on the Today Shelf at the end of each lesson, right before book log
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>True: If display correctly</returns>
        public static bool VerifyLessonStandardRightBeforeBookLog(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.GetElementProperty("UnitSelection", "TodayActivityCell", "accessibilityIdentifier", "4").Contains("Unknown type");
            return UnitSelectionAutomationAgent.GetElementProperty("UnitSelection", "TodayActivityCell", "accessibilityIdentifier", "5").Contains("Booklog");
        }

        /// <summary>
        /// Verify camera icon displayed in today shelf 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if element found</returns>
        public static bool VerifyCameraIconInTodayShelf(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "CameraIconInTodayShelf", "", "Right", 100, 2000, 1000, 5, false);
        }

        /// <summary>
        /// Verify audio icon displayed in today shelf 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if element found</returns>
        public static bool VerifyAudioIconInTodayShelf(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "CameraIconInTodayShelf", "", "Right", 100, 2000, 1000, 5, false);
        }

        /// <summary>
        /// Verify ELA Kindergarten unit labels (if unit number not displayed )
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyELAKindergartenUnitLabels(AutomationAgent UnitSelectionAutomationAgent)
        {
            int availableUnitCount = UnitSelectionAutomationAgent.GetElementCount("UnitSelection", "KINDERGARTENUnits");
            for (int i = 0; i < availableUnitCount; i++)
            {
                string KindergartenUnitNumber = UnitSelectionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i, 0, 0).Replace("\t\n", "").Substring(5);
                if (KindergartenUnitNumber.Length > 1)
                {
                    Assert.IsTrue(KindergartenUnitNumber.Length >= 2 && KindergartenUnitNumber.Length <= 5, "Fail if unit label is not between 2-5 characters");
                }
            }
        }

        /// <summary>
        /// Verify MATH Kindergarten unit labels (if unit number not displayed )
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyMAthKindergartenUnitLabels(AutomationAgent UnitSelectionAutomationAgent)
        {
            int availableUnitCount = UnitSelectionAutomationAgent.GetElementCount("UnitSelection", "KINDERGARTENMathUnits");
            for (int i = 0; i < availableUnitCount; i++)
            {
                string KindergartenUnitNumber = UnitSelectionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENMathUnits", "Inside", "", i, 0, 0).Replace("\t\n", "").Substring(5);
                if (KindergartenUnitNumber.Length > 1)
                {
                    Assert.IsTrue(KindergartenUnitNumber.Length >= 2 && KindergartenUnitNumber.Length <= 5, "Fail if unit label is not between 2-5 characters");
                }
            }
        }

        /// <summary>
        /// Verify that the Book log Reading selection overlay displays Correct unit medallion
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifyBooklogReadingOverlayUnitMedallion(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("MediaLibrary", "MedialibraryUnitTitle");
        }

        /// <summary>
        /// Get all added book log items count
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>int: booklog items count</returns>
        public static int GetAllAddedBookLogItemsCount(AutomationAgent UnitSelectionAutomationAgent)
        {
            return UnitSelectionAutomationAgent.GetElementCount("UnitSelection", "BookLogItemImage");
        }

        /// <summary>
        /// Verify selected book updated in booklog
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifySelectedBookAtBooklog(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("", "");
        }

        /// <summary>
        /// Verify selected poem updated in booklog
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void VerifySelectedPoemAtBooklog(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.VerifyElementFound("", "");
        }
    }
}
