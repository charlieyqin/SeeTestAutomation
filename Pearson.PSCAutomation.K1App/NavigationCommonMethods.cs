using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;

using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    /// <summary>
    /// To generate random number between 1 and given number
    /// </summary>
    public static class NavigationCommonMethods
    {
        public static int randomInteger(int n)
        {
            Random rnd = new Random();
            int randomInt = rnd.Next(1, n);
            return randomInt;
        }

        /// <summary>
        /// Tap on Teacher/Admin Login icon when application launched
        /// </summary>
        /// <param name="PicturePasswordLoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherAdminLogin(AutomationAgent navigationAutomationAgent)
        {
            //navigationAutomationAgent.WaitforElement("HomeScreenView", "TeacherLoginIcon", "", WaitTime.MediumWaitTime);
            //if (!navigationAutomationAgent.IsElementFound("HomeScreenView", "TeacherLoginIcon"))
            //{
            //    LoginCommonMethods.Logout(navigationAutomationAgent);
            //    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
            //    navigationAutomationAgent.Sleep();
            //}
            //else
            //{
            //    navigationAutomationAgent.Click("HomeScreenView", "TeacherLoginIcon");
            //    navigationAutomationAgent.Sleep();
            //}

        }

        /// <summary>
        /// Tap on Set Up icon on left below corner from Teacher/Admin Login screen
        /// </summary>
        /// <param name="PicturePasswordLoginAutomationAgent"></param>
        public static void ClickOnSetUp(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("HomeScreenView", "SetUpIcon");
            navigationAutomationAgent.Sleep();
        }

        /// <summary>
        /// Click on back icon to go previous page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackIcon(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "BackButton");
        }

        /// <summary>
        /// Click on Student icon from home screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnStudentLogin(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("HomeScreenView", "StudentButton");
        }

        /// <summary>
        /// Click on Login button for Student
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLogInButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "LoginButton");
        }

        /// <summary>
        /// Get student name from Hello screen after tapping on Login button 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>string: Name of Student from Hello Screen</returns>
        public static string GetStudentName(AutomationAgent navigationAutomationAgent)
        {
            string name = navigationAutomationAgent.GetTextIn("StudentSetup", "StudentName", "Inside", "");
            return name;
        }

        /// <summary>
        /// Click on next Arrow at password Confirmation screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNextArrow(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "NextArrow");
        }

        /// <summary>
        /// Click on I am not ... link
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnIamNot(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.Click("StudentSetup", "IAMNOTLink");
            navigationAutomationAgent.WaitForElement("StudentSetup", "InprogressIcon");
            navigationAutomationAgent.WaitforElement("StudentSetup", "SelectTeacher", "", WaitTime.MediumWaitTime);
        }

        /// <summary>
        /// Changes Wifi connectivity
        /// 1. Navigates to device home and opens Settings
        /// 2. Checks if Wifi has to be ON and if not already ON then changes the ON
        /// 3. Checks if Wifi has to be OFF and if not already OFF then changes the OFF
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <param name="TurnWifiOff">turn off / on wifi</param>
        public static void ChangeWiFiConnectivity(AutomationAgent LoginLogoutAutomationAgent, bool TurnWifiOff)
        {
            LoginLogoutAutomationAgent.SendText("{HOME}");
            LoginLogoutAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (LoginLogoutAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                LoginLogoutAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            LoginLogoutAutomationAgent.SendText("Settings");
            LoginLogoutAutomationAgent.ClickCoordinate(196, 242, 1);
            LoginLogoutAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsButton");

            if (TurnWifiOff)
            {
                if (LoginLogoutAutomationAgent.IsElementFound("iPadCommonView", "Wi-FiSettingsOnStatus"))
                {
                    LoginLogoutAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsUIASwitch");
                }
            }

            else
            {
                if (!LoginLogoutAutomationAgent.IsElementFound("iPadCommonView", "Wi-FiSettingsOnStatus"))
                {
                    LoginLogoutAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsUIASwitch");
                }
            }
        }

        /// <summary>
        /// Click on System Tray icon on left corner of screen after login
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSystemTray(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "SystemTray");
        }

        /// <summary>
        /// Click on Unit Selection button after expanding system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitSlectionButton(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("UnitSelection", "UnitSelectionButton"))
                navigationAutomationAgent.Click("UnitSelection", "UnitSelectionButton");
            else
                navigationAutomationAgent.Sleep(10000);
                navigationAutomationAgent.Click("UnitSelection", "UnitSelectionButton");
        }
                
        /// <summary>
        /// Click on ELA Unit Number. Unit Number is passed from Test class
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnELAUnit(AutomationAgent navigationAutomationAgent, string unitNo)
        {
            navigationAutomationAgent.Sleep(5000);
            if(navigationAutomationAgent.IsElementFound("UnitSelection", "ELAUNITButton1",unitNo.ToString()))
                navigationAutomationAgent.Click("UnitSelection", "ELAUNITButton1", unitNo.ToString());
            else
                navigationAutomationAgent.Click("UnitSelection", "ELAUNITButton", unitNo.ToString());
            navigationAutomationAgent.WaitForElementToVanish("UnitSelection", "ELAUNITButton", unitNo.ToString(), WaitTime.LargeWaitTime);
            while (navigationAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
            {
                navigationAutomationAgent.WaitForElementToVanish("UnitSelection", "CancelDownload", WaitTime.LargeWaitTime);
                if (!navigationAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                {
                    navigationAutomationAgent.Click("UnitSelection", "ELAUNITButton", unitNo.ToString());
                }
            }
        }

        /// <summary>
        /// Click on ELA Unit Number which is not downloaded yet. Unit Number is passed from Test class
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNonDownloadedELAUnit(AutomationAgent navigationAutomationAgent, int unitNo)
        {
            navigationAutomationAgent.Click("UnitSelection", "ELAUNITButton", unitNo.ToString());
        }

        /// <summary>
        /// Click on Math Unit Number. Unit Number is passed from Test class
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnMathUnit(AutomationAgent navigationAutomationAgent, string unitNo)
        {
            navigationAutomationAgent.Sleep(5000);
            if (navigationAutomationAgent.IsElementFound("UnitSelection", "MATHUNITButton1", unitNo.ToString()))
                navigationAutomationAgent.Click("UnitSelection", "MATHUNITButton1", unitNo.ToString());
            else
                navigationAutomationAgent.Click("UnitSelection", "MATHUNITButton", unitNo.ToString());
            navigationAutomationAgent.WaitforElement("UnitSelection", "MATHUNITButton", unitNo.ToString(), WaitTime.MediumWaitTime);
            navigationAutomationAgent.Click("UnitSelection", "MATHUNITButton", unitNo.ToString());
            while (navigationAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
            {
                navigationAutomationAgent.WaitForElementToVanish("UnitSelection", "CancelDownload");
                if (!navigationAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                {
                    navigationAutomationAgent.Click("UnitSelection", "MATHUNITButton", unitNo.ToString());
                }
            }
        }

        /// <summary>
        /// Click on Media Library
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void ClickOnMediaLibrary(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "MediaLibraryNavIcon");
            navigationAutomationAgent.Sleep();
        }

        /// <summary>
        /// Click on Notebook Browser
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void ClickOnNotebookBrowser(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "NotebookBrowserNavIcon");
        }

        /// <summary>
        /// Click To Open Notebook
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita (namrita.agarwal)</author>
        public static void ClickToOpenNotebook(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.WaitforElement("UnitSelection", "OpenNotebookIcon", "", WaitTime.LargeWaitTime);
            navigationAutomationAgent.Click("UnitSelection", "OpenNotebookIcon");
        }
        /// <summary>
        /// Click on back pack Icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnBackPack(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("BackPackView", "BackPack");
        }
        /// <summary>
        /// Click on Settings button in system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnSettingsButtons(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "SettingsButton");
        }
        /// <summary>
        /// Click on BookBuilder button in system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnBookBuilder(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "BookBuilderButton");
        }
        /// <summary>
        /// Click on teacher support in system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnTeacherSupport(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "TeacherSupport");
        }

        /// <summary>
        /// Click on MTE/CC nav icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnMTE_CCIcon(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "MTE/CCNavIcon");
        }
        /// <summary>
        /// Click on the Back Button which is present on the MORE TO EXPLORE(MTE) screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackButtonatMTE(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "BackButtonatMTE");
        }


        /// <summary>
        /// swipe the page to  the left side
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="direction">Direction object</param>
        /// <param name="offset">int : passing offset</param>
        /// <param name="time">int: passing time</param>
        public static void Swipe(AutomationAgent navigationAutomationAgent, Direction direction, int offset, int time)
        {
            navigationAutomationAgent.SwipeElement("UnitSelection", "TodayButton", direction, offset, time);

        }


        /// <summary>
        /// Click on Reset Password from student setup popup
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        public static void ClickOnResetPassword(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "ResetPassword");
        }

        /// <summary>
        /// Navigate to Home Screen from particuler screen
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <param name="noClickOnBackIcon">int: numbers click on back button</param>
        public static void NavigateToHome(AutomationAgent navigationAutomationAgent, int noClickOnBackIcon)
        {
            for (int i = 1; i <= noClickOnBackIcon; i++)
            {
                navigationAutomationAgent.Click("StudentSetup", "BackButton");
            }
        }
        /// <summary>
        /// clicks on the today button to open lesson shelf
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent</param>
        public static void ClickOnTodayButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "TodayButton");
        }

        /// <summary>
        /// clicks on the book log nutton to open
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBookLog(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "BookLogButton", "", "Right");
        }

        /// <summary>
        /// Click on Login button at student setup screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object<</param>
        public static void ClickOnStudentLoginButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "StudentLoginButton");
        }

        /// <summary>
        /// click on Next Arrow icon at Lets Practice screen 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNextArrowAtLetsPractice(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "NextArrowAtLetsPractice");
        }

        /// <summary>
        /// Click on Lets Login Arrow after Pic Password selection practice
        /// </summary>
        /// <param name="PicturePasswordLoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLetsLoginArrow(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("StudentSetup", "LetsLoginArrow");
        }
        /// <summary>
        /// Verify that user is on the home screen 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyUserIsOnHomeScreen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "TodayButton");
        }

        /// <summary>
        /// Verify that user is on notebook browser
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyUserOnNoteBookBrowser(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("NotebookView", "NotebookUnitTitle");
        }
        /// <summary>
        /// clicks to open the teacher mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherMode(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("TeacherMode", "TeacherModeNavIconInTeacherModeOpen"))
            {
                navigationAutomationAgent.Click("TeacherMode", "TeacherModeNavIconInTeacherModeOpen");
            }
            else
                navigationAutomationAgent.Click("TeacherMode", "TeacherModeNavIcon");
        }

        /// <summary>
        /// Click to Expand Teacher Mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickToExpandTeacherMode(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TeacherMode", "TeacherModeExpandBar");
        }

        /// <summary>
        /// Click On Home icon from global navigation bar
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitHomeNavIcon(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "HomeNavIcon");
        }
        /// <summary>
        /// click on edit icon in already added booklog item popup
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNotebookIconInBooklogPopup(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "NotebookIconInBookLogItem");
        }

        /// <summary>
        /// Click on Todat bubble to open booklog popup
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenBooklogPopup(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("UnitSelection", "TodayAtBookLogItem"))
                navigationAutomationAgent.Click("UnitSelection", "TodayAtBookLogItem");
            else
                navigationAutomationAgent.Click("UnitSelection", "AddButtonInBookLog");
        }

        /// <summary>
        /// clicks to get the next lesson 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickToGetNextLesson(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "RightArrowOfLesson");
        }

        /// <summary>
        /// Click on Camera Icon in booklog popup
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCameraInBooklogPopup(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "CameraInBookogPopup");
        }

        /// <summary>
        /// Click on Camera icon in book log camera mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCameraIconInBookLogCameraMode(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "CameraIconInBookogCamMode");
        }

        /// <summary>
        /// Click on cross icon to close the book log camera mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickToCloseBooklogCameraMode(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "CrossIconInBookogCamMode");
        }

        /// <summary>
        /// Click on cross icon to close the book log camera mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGreenIconInBookLogCameraMode(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "GreenIconInBookogCamMode");
        }

        /// <summary>
        /// click on the book builder screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void TapOnScreen(AutomationAgent navigationAutomationAgent, int xCoordinate, int yCoordinate)
        {
            navigationAutomationAgent.ClickCoordinate(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// clicks on the page in the page browser screen 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnBookPage(AutomationAgent bookBuilderAutomatinAgent, int pageCount)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "BookPage", pageCount.ToString());
        }

        /// <summary>
        /// verify MTE nav icon is pressed state
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyMTEIconIsInPressedState(AutomationAgent navigationAutomationAgent)
        {
            string[] hiddenProperty = navigationAutomationAgent.GetAllValues("NotebookView", "MTEIconPressedState", "hidden");
            if (hiddenProperty[0].Equals("false"))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Long click on MTE and CC icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void LongClickOnMTECCNavIcon(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("NotebookView", "MTEIconPressedState");
        }
        /// <summary>
        /// clicks on the flash card
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnFlashCard(AutomationAgent navigationAutomationAgent)
        {
            int tCount = 0;
            while (!(navigationAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "FlashCard", "", "Right")) && tCount <= 20)
            {
                NavigationCommonMethods.ClickToGetNextLesson(navigationAutomationAgent);
                if (navigationAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "FlashCard", "", "Right"))
                    break;
                tCount++;
            }


        }
        /// <summary>
        /// click on the back button at the flash card screen
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackButtonAtFlashCard(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "BackButtonAtFLashCard");
        }
        /// <summary>
        /// CLick on the back button which is on the media player
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackAtMediaPlayer(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("MediaLibrary", "BackButtonAtMediaPlayer");
        }

        /// <summary>
        /// Click on Show Password button for already setup student
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnShowPasswordForSetupStudent(AutomationAgent navigationAutomationAgent, Login login)
        {
            string[] studentFirstName = login.PersonName.Split(' ');
            navigationAutomationAgent.Click("TeacherMode", "ShowPasswordWithStudentLabel", studentFirstName[0], 2, WaitTime.DefaultWaitTime);
        }


        /// <summary>
        /// Click on show password button for student which does not setup 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnShowPasswordForNonSetupStudent(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TeacherMode", "ShowPassword");
        }
        /// <summary>
        /// Verify the different icons present in the navigation bar.
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyIconsInNavigationBar(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "SystemTray");
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "HomeNavIcon");
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "MediaLibraryNavIcon");
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "NotebookBrowserNavIcon");
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "MTE/CCNavIcon");
            if (navigationAutomationAgent.IsElementFound("BackPackView", "BackPack"))
            {
                navigationAutomationAgent.VerifyElementFound("BackPackView", "BackPack");
            }
            else
                navigationAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeNavIcon");

        }
        /// <summary>
        /// verif the size of global navigation bar icons
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if size matches</returns>
        public static bool VerifyGlobalNavIconsSize(AutomationAgent navigationAutomationAgent)
        {
            string[] homewidth = navigationAutomationAgent.GetAllValues("UnitSelection", "HomeNavIcon", "width");
            string[] homeHeight = navigationAutomationAgent.GetAllValues("UnitSelection", "HomeNavIcon", "height");
            string[] mediaLibwidth = navigationAutomationAgent.GetAllValues("UnitSelection", "MediaLibraryNavIcon", "width");
            string[] mediaLibheight = navigationAutomationAgent.GetAllValues("UnitSelection", "MediaLibraryNavIcon", "height");
            string[] notebookWidth = navigationAutomationAgent.GetAllValues("UnitSelection", "NotebookBrowserNavIcon", "width");
            string[] notebookHeight = navigationAutomationAgent.GetAllValues("UnitSelection", "NotebookBrowserNavIcon", "height");
            string[] mteWidth = navigationAutomationAgent.GetAllValues("UnitSelection", "MTE/CCNavIcon", "width");
            string[] mteHeight = navigationAutomationAgent.GetAllValues("UnitSelection", "MTE/CCNavIcon", "height");

            if (homewidth[0].Equals(mediaLibwidth[0]) && mediaLibwidth[0].Equals(notebookWidth[0]) && notebookWidth[0].Equals(mteWidth[0]) && homeHeight[0].Equals(mediaLibheight[0]) && mediaLibheight[0].Equals(notebookHeight[0]) && notebookHeight[0].Equals(mteHeight[0]))
                return true;
            else
                return false;

        }
        /// <summary>
        /// verif the size of MEdial Library Icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if size matches</returns>
        public static bool VerifySizeOfMEdialLibraryIcon(AutomationAgent navigationAutomationAgent)
        {
            string[] width = navigationAutomationAgent.GetAllValues("UnitSelection", "MediaLibraryNavIcon", "width");
            string[] height = navigationAutomationAgent.GetAllValues("UnitSelection", "MediaLibraryNavIcon", "height");
            if (width.Equals("200") && height.Equals("168"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verif the size of Notebook icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if size matches</returns>
        public static bool VerifySizeOfNotebookIcon(AutomationAgent navigationAutomationAgent)
        {
            string[] width = navigationAutomationAgent.GetAllValues("UnitSelection", "NotebookBrowserNavIcon", "width");
            string[] height = navigationAutomationAgent.GetAllValues("UnitSelection", "NotebookBrowserNavIcon", "height");
            if (width.Equals("200") && height.Equals("168"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verif the size of MTE/CC icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if size matches</returns>
        public static bool VerifySizeOfHomeMteCCIcon(AutomationAgent navigationAutomationAgent)
        {
            string[] width = navigationAutomationAgent.GetAllValues("UnitSelection", "MTE/CCNavIcon", "width");
            string[] height = navigationAutomationAgent.GetAllValues("UnitSelection", "MTE/CCNavIcon", "height");
            if (width.Equals("200") && height.Equals("168"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verif the size of Back Pack Icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if size matches</returns>
        public static bool VerifySizeOfBackPackIcon(AutomationAgent navigationAutomationAgent)
        {
            string[] width = navigationAutomationAgent.GetAllValues("BackPackView", "BackPack", "width");
            string[] height = navigationAutomationAgent.GetAllValues("BackPackView", "BackPack", "height");
            if (width[0].Equals("160") && height[0].Equals("240"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify the size of sytem tray icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if size matches</returns>
        public static bool VerifySizeOfSystemTray(AutomationAgent navigationAutomationAgent)
        {
            string[] width = navigationAutomationAgent.GetAllValues("UnitSelection", "SystemTray", "width");
            string[] height = navigationAutomationAgent.GetAllValues("UnitSelection", "SystemTray", "height");
            if (width[0].Equals("118") && height[0].Equals("154"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify that icons are equally spaced into global navigation bar.
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if equally spaced</returns>
        public static bool VerifyGlobalNavIconEquallySpaced(AutomationAgent navigationAutomationAgent)
        {
            string[] homeXcoordinates = navigationAutomationAgent.GetAllValues("UnitSelection", "HomeNavIcon", "x");
            string[] mediaLibXcoordinates = navigationAutomationAgent.GetAllValues("UnitSelection", "MediaLibraryNavIcon", "x");
            string[] notebookXcoordinates = navigationAutomationAgent.GetAllValues("UnitSelection", "NotebookBrowserNavIcon", "x");
            string[] mteXcoordinates = navigationAutomationAgent.GetAllValues("UnitSelection", "MTE/CCNavIcon", "x");
            int sizeBtwLibAndNotebook = Int32.Parse(notebookXcoordinates[0]) - Int32.Parse(mediaLibXcoordinates[0]);
            int sizeBtwNotebookAndMTE = Int32.Parse(mteXcoordinates[0]) - Int32.Parse(notebookXcoordinates[0]);

            if (sizeBtwLibAndNotebook.Equals(sizeBtwNotebookAndMTE))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on the inbox button in system tray
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnInboxButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "InboxButton");
        }
        /// <summary>
        /// Clicks on the terms of use link
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTermsOfUse(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("HomeScreenView", "TermsOfUse");
        }
        /// <summary>
        /// Verify that terms of use link on homescreen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyTermsOfUseLinkOnHomeScreen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("HomeScreenView", "TermsOfUse");
        }
        /// <summary>
        /// Verify the terms of use opens in dialog box
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTermsOfUseOpensInDialogBox(AutomationAgent navigationAutomationAgent)
        {
            return (navigationAutomationAgent.IsElementFound("HomeScreenView", "AgreementWebViewBackground"));


        }
        /// <summary>
        /// Verify gradient at bottom in box
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyGradientAtBottomInBox(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("HomeScreenView", "AgreementGradientView");
        }
        /// <summary>
        /// clicks on the cross button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCrossButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "CrossIconInBookogCamMode");
        }
        /// <summary>
        /// Verify the privacy statement link
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyPrivacyStatement(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("HomeScreenView", "PrivacyStatement");
        }
        /// <summary>
        /// click on the privacy statement link 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPrivacyStatementLink(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("HomeScreenView", "PrivacyStatement");
        }
        /// <summary>
        /// Verify the privacy statement opens in dialog box
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyPrivacyStatementOpensInDialogBox(AutomationAgent navigationAutomationAgent)
        {
            return (navigationAutomationAgent.IsElementFound("HomeScreenView", "AgreementWebViewBackground"));
        }
        /// <summary>
        /// Verify System Tray Open
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySystemTrayOpen(AutomationAgent inboxAutomationAgent)
        {
            string coordinates = inboxAutomationAgent.GetAllValues("UnitSelection", "SystemTray", "x")[0];
            if (Int32.Parse(coordinates) < 604)
                return false;
            else
                return true;

        }

        /// <summary>
        /// verify navigation bar inactive when system tray open
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNavigationBarActive(AutomationAgent navigationAutomationAgent)
        {
            NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
            return NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent);
        }
        /// <summary>
        /// Verify loading indicator 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyLoadingIndicator(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon");
        }

        /// <summary>
        /// Verify back button in MTE screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if back button displayed</returns>
        public static bool VerifyBackButtonInMTEscreen(AutomationAgent navigationAutomationAgent)
        {
            string[] pos = navigationAutomationAgent.GetPosition("UnitSelection", "BackButtonatMTE").Split(',');

            if (Int32.Parse(pos[0]) < 100 && Int32.Parse(pos[1]) < 150)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify the back button In CC screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if match</returns>
        public static bool VerifyBackButtonInCCScreen(AutomationAgent navigationAutomationAgent)
        {
            string[] pos = navigationAutomationAgent.GetPosition("UnitSelection", "BackButtonatMTE").Split(',');

            if (Int32.Parse(pos[0]) < 100 && Int32.Parse(pos[1]) < 150)
                return true;
            else
                return false;
        }
        /// <summary>
        /// VErify user on settings screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUserOnSettingsscreen(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("UnitSelection", "SettingsScreen");
        }
        /// <summary>
        /// Clicks on the back button at settings screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackButtonAtSettingsScreen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "BackButtonAtSettingsScreen");
        }
        /// <summary>
        /// Verify MTE screen open
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMTEscreenOpen(AutomationAgent navigationAutomationAgent)
        {
            string text = navigationAutomationAgent.GetElementText("UnitSelection", "MoreToExploreScreen");
            if (text.Equals("More To Explore"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verify concept screen open
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if match</returns>
        public static bool VerifyCCscreenOpen(AutomationAgent navigationAutomationAgent)
        {
            string text = navigationAutomationAgent.GetAllValues("UnitSelection", "ConceptCornerScreen", "text")[0];
            if (text.Equals("Concept Corner"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify MTE Text Top Centered
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if match</returns>
        public static bool VerifyMTETextTopCentered(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Sleep();
            string[] pos = navigationAutomationAgent.GetPosition("UnitSelection", "MoreToExploreTitle").Split(',');
            int Xcoordinate = Int32.Parse(navigationAutomationAgent.GetAllValues("UnitSelection", "MoreToExploreTitle", "x")[0]);
            int WidthOfNavigationBar = Int32.Parse(navigationAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            int width = Int32.Parse(navigationAutomationAgent.GetAllValues("UnitSelection", "MoreToExploreTitle", "width")[0]);
            if ((WidthOfNavigationBar / 2).Equals(Xcoordinate + (width / 2)) && (Int32.Parse(pos[1]) < 200))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify MTE Text Top Centered
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if match</returns>
        public static bool VerifyCCTextTopCentered(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Sleep();
            string[] pos = navigationAutomationAgent.GetPosition("UnitSelection", "ConceptCornerTitle").Split(',');
            int Xcoordinate = Int32.Parse(navigationAutomationAgent.GetAllValues("UnitSelection", "ConceptCornerTitle", "x")[0]);
            int WidthOfNavigationBar = Int32.Parse(navigationAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            int width = Int32.Parse(navigationAutomationAgent.GetAllValues("UnitSelection", "ConceptCornerTitle", "width")[0]);
            if ((WidthOfNavigationBar / 2).Equals(Xcoordinate + (width / 2) + 1) && (Int32.Parse(pos[1]) < 200))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get current unit number which is on first at row
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>Int: Unit number</returns>
        public static string GetCurrentUnitNumber(AutomationAgent CAadoptionAutomationAgent)
        {
            if (CAadoptionAutomationAgent.IsElementFound("UnitSelection", "ELAUNITButton", "1"))
                return CAadoptionAutomationAgent.GetTextIn("UnitSelection", "ELAUNITButton", "Inside", "1", 0, 0).Replace("\t\n", "").Substring(5);
            else
                return CAadoptionAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", 0, 0).Replace("\t\n", "").Substring(5);
        }

        /// <summary>
        /// click on back button
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGoBackIcon(AutomationAgent LoginAutomationAgent)
        {
            if (!LoginAutomationAgent.IsElementFound("eReaderView", "GoBackButton"))
            {
                NavigationCommonMethods.TapOnScreen(LoginAutomationAgent, 1000, 500);
            }
            LoginAutomationAgent.Click("eReaderView", "GoBackButton");
        }
        /// <summary>
        /// Verify back button at the top left corner
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyBackButtonInMediaPlayer(AutomationAgent CAadoptionAutomationAgent)
        {
            string[] pos = CAadoptionAutomationAgent.GetPosition("UnitSelection", "BackButtonatMTE").Split(',');

            if (Int32.Parse(pos[0]) < 100 && Int32.Parse(pos[1]) < 150)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify back pack open
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool verifyBackPackOpen(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.IsElementFound("BackPackView", "BackPackZip");
        }
        /// <summary>
        /// Click to open the interactive from todays shelf
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenInteractiveFromTodaysShelf(AutomationAgent notebookAutomationAgent)
        {
            int tCount = 0;
            while (!(notebookAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayShelfInteractive", "", "Right")) && tCount <= 20)
            {
                NavigationCommonMethods.ClickToGetNextLesson(notebookAutomationAgent);
                if (notebookAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayShelfInteractive", "", "Right"))
                    break;
                tCount++;
            }
        }

        /// <summary>
        /// Clicks to open todays shelf from todays shelf.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenEreaderFromTodaysShelf(AutomationAgent CAadoptionAutomationAgent)
        {
            if (CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayShelfBook", "", "Right"))
            {
            }
            else
                CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TodayShelfBook", "", "Left");

        }

        /// <summary>
        /// Enable the Auto-Correction of device if its not enabled already
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void EnableDeviceAutoCorrectionFeature(AutomationAgent TeacherModeAutomationAgent, bool TurnAutoCorrectionON)
        {
            TeacherModeAutomationAgent.SendText("{HOME}");
            TeacherModeAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (TeacherModeAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                TeacherModeAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            TeacherModeAutomationAgent.SendText("Settings");
            TeacherModeAutomationAgent.ClickCoordinate(380, 304, 1);
            TeacherModeAutomationAgent.Click("iPadCommonView", "GeneralSettingButton");
            TeacherModeAutomationAgent.Swipe(Direction.Down, 200, 1000);
            TeacherModeAutomationAgent.WaitForElement("iPadCommonView", "KeyboardButton", WaitTime.DefaultWaitTime);
            TeacherModeAutomationAgent.Click("iPadCommonView", "KeyboardButton");
            TeacherModeAutomationAgent.WaitforElement("iPadCommonView", "AutoCorrection", "status",WaitTime.DefaultWaitTime);
            string[] status = TeacherModeAutomationAgent.GetAllValues("iPadCommonView", "AutoCorrection", "status");
            if (TurnAutoCorrectionON)
            {
                if (!status[0].Equals("on"))
                    TeacherModeAutomationAgent.Click("iPadCommonView", "AutoCorrection");
            }
            else
            {
                if (!status[0].Equals("off"))
                    TeacherModeAutomationAgent.Click("iPadCommonView", "AutoCorrection");
            }
        }


        /// <summary>
        /// Get random unit number from given unit list
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>int: unit number</returns>
        public static string GetRandomUnitNumber(AutomationAgent BackPackAutomationAgent)
        {
            List<string> downloadedUnitList = GetDownloadedUnitList(BackPackAutomationAgent);
            return downloadedUnitList[NavigationCommonMethods.randomInteger(downloadedUnitList.Count)];
            //int randUnit = NavigationCommonMethods.randomInteger(presentUnitCounts);
            //string randUnitNumber = BackPackAutomationAgent.GetTextIn("UnitSelection", "CurrentUnit", "Inside", "", randUnit, 0, 0).Replace("\t\n", "").Substring(5);
            //return Int32.Parse(randUnitNumber);
        }

        /// <summary>
        /// Click on media library icon in booklog popup
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMediaLibraryIconInBooklogPopup(AutomationAgent UnitSelectionAutomationAgent)
        {
            UnitSelectionAutomationAgent.Click("UnitSelection", "MediaLibraryIconInBooklogPopup");
        }

        /// <summary>
        /// Click on Interactive image from notebook
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnIntercativeImageFromNotebook(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("NotebookView", "InteractiveInNotebook"))
            {
                navigationAutomationAgent.Click("NotebookView", "InteractiveInNotebook");
            }
            else
                navigationAutomationAgent.Click("NotebookView", "NotebookInteractive", 2);
        }

        /// <summary>
        /// Get downloaded unit count
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int: downloaded unti count</returns>
        public static List<string> GetDownloadedUnitList(AutomationAgent navigationAutomationAgent)
        {
            List<string> downloadedUnitList = new List<string>();
            int availableUnitCount = navigationAutomationAgent.GetElementCount("UnitSelection", "KINDERGARTENUnits");
            for (int i = 1; i < availableUnitCount; i++)
            {
                string unitNumber = navigationAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i - 1, 0, 0).Replace("\t\n", "").Substring(5);
                navigationAutomationAgent.Click("UnitSelection", "ELAUNITButton", unitNumber);
                if (LoginCommonMethods.VerifyErrorPopup(navigationAutomationAgent))
                {
                    LoginCommonMethods.CloseErrorPopUp(navigationAutomationAgent);
                }
                if (!navigationAutomationAgent.IsElementFound("UnitSelection", "CancelDownload") && !navigationAutomationAgent.IsElementFound("UnitSelection", "ELAColumnTitle"))
                {
                    downloadedUnitList.Add(unitNumber);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(navigationAutomationAgent);
                }
                if (navigationAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                    navigationAutomationAgent.Click("UnitSelection", "CancelDownload");

            }

            return downloadedUnitList;

        }

        /// <summary>
        /// Enable the Emojis Key on Keyboard of device if its not enabled already
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void EnableDeviceKeyboardEmojisKey(AutomationAgent TeacherModeAutomationAgent, bool TurnEmojisKeyON)
        {
            TeacherModeAutomationAgent.SendText("{HOME}");
            TeacherModeAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (TeacherModeAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                TeacherModeAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            TeacherModeAutomationAgent.SendText("Settings");
            if(TeacherModeAutomationAgent.IsElementFound("iPadCommonView", "SettingsMenu"))
            {
                TeacherModeAutomationAgent.Click("iPadCommonView", "SettingsMenu");
            }
            else
            {
                TeacherModeAutomationAgent.ClickCoordinate(196, 242, 1);
            }
            TeacherModeAutomationAgent.ElementSwipeWhileNotFound("iPadCommonView", "MenuTable", "iPadCommonView", "GeneralSettingButton", "", "Up");
            TeacherModeAutomationAgent.Click("iPadCommonView", "GeneralSettingButton");
            TeacherModeAutomationAgent.Swipe(Direction.Down, 200, 1000);
            TeacherModeAutomationAgent.Click("iPadCommonView", "KeyboardButton");
            TeacherModeAutomationAgent.Click("iPadCommonView", "KeyboardsNavigationButton");
            if (TurnEmojisKeyON)
            {
                if (TeacherModeAutomationAgent.IsElementFound("iPadCommonView", "EmoJiAtKeyboards"))
                {
                }
                else
                {
                    TeacherModeAutomationAgent.Click("iPadCommonView", "AddNewKeyboard");
                    TeacherModeAutomationAgent.Click("iPadCommonView", "EmoJiAtAddNewKeyboardPopup");
                    TeacherModeAutomationAgent.VerifyElementFound("iPadCommonView", "EmoJiAtKeyboards");
                }

            }
            else
            {
                if (!TeacherModeAutomationAgent.IsElementFound("iPadCommonView", "EmoJiAtKeyboards"))
                {
                }
                else
                {
                    TeacherModeAutomationAgent.Click("iPadCommonView", "EditAlreadyAddedKeyboard");
                    TeacherModeAutomationAgent.Click("iPadCommonView", "RemoveIconOfEmojiKey");
                    TeacherModeAutomationAgent.Click("iPadCommonView", "DeleteIconOfEmojiKey");
                    TeacherModeAutomationAgent.Click("iPadCommonView", "DoneButtonAtKeyboard");
                    TeacherModeAutomationAgent.VerifyElementNotFound("iPadCommonView", "EmoJiAtKeyboards");
                }
            }
        }

        /// <summary>
        /// Verify Emoji key is disabled for keyboards open in applications screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>true: if emoji key is disabled at keyboards for application screen</returns>
        public static bool VerifyEmojKeyDisabledOnKeyboard(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("iPadCommonView", "EmoctionIconAtKeyboard");
            return (!bookBuilderAutomatinAgent.IsElementFound("iPadCommonView", "EmojiScrollViewAtKeyboard"));
        }

        /// <summary>
        /// Get non unit downloaded unit numbers
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <returns>arraylist of non unit downloaded numbers</returns>
        public static ArrayList GetNonDownloadedUnitNumber(AutomationAgent LoginAutomationAgent)
        {
            ArrayList nonDownloadedUnits = new ArrayList();
            int availableUnitCount = LoginAutomationAgent.GetElementCount("UnitSelection", "KINDERGARTENUnits");
            for (int i = 1; i <= availableUnitCount; i++)
            {
                string unitNumber = LoginAutomationAgent.GetTextIn("UnitSelection", "KINDERGARTENUnits", "Inside", "", i - 1, 0, 0).Replace("\t\n", "").Substring(5);
                LoginAutomationAgent.Click("UnitSelection", "ELAUNITButton", unitNumber);
                if (!LoginAutomationAgent.IsElementFound("UnitSelection", "CancelDownload"))
                {
                    nonDownloadedUnits.Add(unitNumber);
                    LoginAutomationAgent.Click("UnitSelection", "CancelDownload");
                }
                else
                    NavigationCommonMethods.ClickOnSystemTray(LoginAutomationAgent);
                NavigationCommonMethods.ClickOnUnitSlectionButton(LoginAutomationAgent);
            }
            return nonDownloadedUnits;
        }

        /// <summary>
        /// Click to download unit 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="nonUnitDownloadedNumber">unit number which is not downloaded yet</param>
        public static void ClickToDownLoadUnit(AutomationAgent LoginAutomationAgent, string nonUnitDownloadedNumber)
        {
            LoginAutomationAgent.Click("UnitSelection", "ELAUNITButton", nonUnitDownloadedNumber);
            LoginAutomationAgent.WaitForElement("UnitSelection", "CancelDownload");
        }

        /// <summary>
        /// Click to cancel download unit 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelDownload(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("UnitSelection", "CancelDownload");
        }

        /// <summary>
        /// Click to close the keyboard
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void CloseDeviceKeyboard(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.CloseKeyboard();
        }

        /// <summary>
        /// Click on update content button from settings screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUpdateContentButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("Settings", "UpdateContentButton");
        }

        /// <summary>
        /// Click on camera from today shelf
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCameraInTodayShelf(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("UnitSelection", "CameraIconInTodayShelf");
        }

        /// <summary>
        /// Click on audio icon from today shelf
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAudioIconInTodayShelf(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("UnitSelection", "CameraIconInTodayShelf");
        }

        /// <summary>
        /// Click on lesson standar from today shelf
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLessonStandard(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "MediaLibrary", "LessonStandards", "", "Right");
        }

        /// <summary>
        /// Click on back icon from lesson standard
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackIconFromLessonStandard(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("BookBuilderView", "BackHandButtonWhenBookOpen");
        }

        /// <summary>
        /// Enter given config code in device app settings 
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void EnterConfigCodeInDeviceAppsettings(AutomationAgent LoginAutomationAgent, string configCode)
        {
            LoginAutomationAgent.SendText("{HOME}");
            LoginAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (LoginAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                LoginAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            LoginAutomationAgent.SendText("Settings");
            LoginAutomationAgent.ClickCoordinate(196, 242, 1);
            LoginAutomationAgent.Swipe(Direction.Down, 0, 2000);
            LoginAutomationAgent.Click("iPadCommonView", "AppAtDeviceSettings");
            LoginAutomationAgent.SetText("iPadCommonView", "ConfigCodeAtDeviceSettings", configCode);
        }


        /// <summary>
        /// Verify itmes in assessments manager submenu
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyItemsInAssessmentManagersubmenu(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "KindergartenELAAssessmentButton");

            navigationAutomationAgent.VerifyElementFound("UnitSelection", "Grade1ELAAssessmentButton");
        }
        /// <summary>
        /// Click on Assessment Manager
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickonAssessmentManager(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "AssessmentManagerButton");
        }
        /// <summary>
        ///  Click on Assessment Reports
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickonAssessmentReports(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "AssessmentReportsButton");
        }
        /// <summary>
        /// Verify itmes in assessments Reports submenu
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyItemsInAssessmentReportssubmenu(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "Grade1ELAReportsButton");

            navigationAutomationAgent.VerifyElementFound("UnitSelection", "KindergartenELAReportsButton");
        }
        /// <summary>
        /// Click on kindergarten inbox button
        /// </summary>
        /// <param name="inboxAutomationAgent">AutomationAgent object</param>
        public static void ClickOnKindergartenInboxButton(AutomationAgent inboxAutomationAgent)
        {
            inboxAutomationAgent.Click("UnitSelection", "KinderGartenInboxButton");
        }

        /// <summary>
        /// click on share button for book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnShareButton(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "ShareBookIcon");
        }

        /// <summary>
        /// click on cancel button on share popup
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnCancelShare(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "CancleShare");
        }

        /// <summary>
        /// click on accept button of share popup
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnAcceptButtonOfShare(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "AcceptShare");
        }

        /// <summary>
        /// click on kindergarten sub menu of assessment report 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnKindergartenAssessmentReportButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "KindergartenELAReportsButton");
        }

        /// <summary>
        /// verify kindergarten assessment report view open 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyKindergartenAssessmentReportViewOpen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "KindergartenELAReportView");
        }

        /// <summary>
        /// click on grade ela assessment report button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGradeELAAssessmentReportButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitSelection", "Grade1ELAReportsButton");
        }

        /// <summary>
        /// verify grade ela assessment report view open 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyGradeELAAssessmentReportViewOpen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitSelection", "GradeELAReportView");
        }
        /// <summary>
        /// Verify Unit Selection button present after expanding system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitSlectionButton(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("UnitSelection", "UnitSelectionButton");
        }

        public static bool VerifySubMenuOfAssessmentManagerAndReports(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("BookBuilderView", "BookPageCount","CourseELAKGKG - Sec15KGELA");
        }
        /// <summary>
        /// Tap on Teacher/Admin Login icon when application launched
        /// </summary>
        /// <param name="PicturePasswordLoginAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherAdminLoginInHomeScreen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.WaitforElement("HomeScreenView", "TeacherLoginIcon", "", WaitTime.MediumWaitTime);
            navigationAutomationAgent.Click("HomeScreenView", "TeacherLoginIcon");
            navigationAutomationAgent.WaitforElement("HomeScreenView", "SetUpIcon", "", WaitTime.MediumWaitTime);   
           

        }

    }
}
