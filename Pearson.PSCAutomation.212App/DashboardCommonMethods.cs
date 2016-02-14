using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public static class DashboardCommonMethods
    {
        /// <summary>
        /// 1. Clicks on the System Tray Button
        /// 2. Verifies My dashboard, ELA unit Library, Math Unit Library, Teacher Support, work browser and Content Manager Sub Menus
        /// 3. Verifies the Unit Library Button 
        ///     If active then verifies the sub menu (ELA Units and Math Units)
        ///     else click on Unit Library and then verifies the sub menu (ELA Units and Math Units)
        /// 4. Clicks on ELA Unit and verify grades present
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void VerifyAllUnitsPage(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "MyDashboard");
            dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "TeacherSupport");
            dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "WorkBrowser");
            dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ContentManager");
            dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "LogOutButton");
            if (dashboardAutomationAgent.WaitForElement("SystemTrayMenuView", "ELAUnitsButton", WaitTime.SmallWaitTime))
            {
                dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ELAUnitsButton");
                dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "MathUnitsButton");
                dashboardAutomationAgent.Click("SystemTrayMenuView", "ELAUnitsButton");
            }
            else
            {
                dashboardAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ELAUnitsButton");
                dashboardAutomationAgent.VerifyElementFound("SystemTrayMenuView", "MathUnitsButton");
                dashboardAutomationAgent.Click("SystemTrayMenuView", "ELAUnitsButton");
            }
            dashboardAutomationAgent.VerifyElementFound("GradeSelectionMenuView", "ELAUnitsTitle");
            dashboardAutomationAgent.VerifyElementFound("GradeSelectionMenuView", "GradesMenuView");
        }
        /// <summary>
        /// Verifies and saves the Current Login User name 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <param name="direction">Direction used to select the text of the control</param>
        /// <returns>Returns the text(name of the current user)</returns>
        public static string GetTextForCurrentUser(AutomationAgent dashboardAutomationAgent, string direction)
        {
            return dashboardAutomationAgent.GetTextIn("SystemTrayMenuView", "CurrentUserName", direction, "");
        }
        /// <summary>
        /// Verifies and saves the Position of the Current Login User Name
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>returns the Position of the element</returns>
        public static string GetPositionCurrentUserControl(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetPosition("SystemTrayMenuView", "CurrentUserName");
        }
        /// <summary>
        /// Swipes the Current User Control. It may be Vertical or horizontal 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <param name="direction">Ledt, Right, Up, Down are the Directions</param>
        /// <param name="offset">Distance for swiping</param>
        /// <param name="swipetime">Swipe Timing</param>
        public static void SwipeCurrentUserControl(AutomationAgent dashboardAutomationAgent, Direction direction, int offset, int swipetime)
        {
            dashboardAutomationAgent.SwipeElement("SystemTrayMenuView", "CurrentUserName", direction, offset, swipetime);
        }
        /// <summary>
        /// It Verifies the Unit Numbers of the Units present in a particular grade
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitsNumber(AutomationAgent dashboardAutomationAgent)
        {
            for (int i = 0; dashboardAutomationAgent.IsElementFound("UnitLibraryView", "UnitNo", i.ToString()); i++)
            {
                string UnitText = dashboardAutomationAgent.GetTextIn("UnitLibraryView", "UnitNo", "Inside", i.ToString());
                UnitText = UnitText.Replace("\n", "").Replace("\t", "");
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(true, UnitText.Contains("UNIT " + (i + 1)));
            }
        }
        /// <summary>
        /// verifies that user is on dashboard or not by 
        /// checking from the My Dashboard Tile
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if my dash board is found</returns>
        public static bool VerifyUserIsOnDashBoard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.WaitforElement("SystemTrayMenuView", "MyDashboard", "", WaitTime.MediumWaitTime);
            return dashboardAutomationAgent.IsElementFound("SystemTrayMenuView", "MyDashboard");
        }
        /// <summary>
        /// verifies that logout button exists or not by checking the image on the 
        /// left hand side of the text LOGOUT
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if image exists</returns>
        public static bool VerifyLogoutButtonExists(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("SystemTrayMenuView", "LogOutButtonImage");
        }
        /// <summary>
        /// click on the system tray icon to close system tray menu
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickToCloseSystemTray(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("SystemTrayMenuView", "SystemTrayHighLighted");

        }
        /// <summary>
        /// Verifies Start Unit Button Present in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyStartUnitInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "StartLessonButton");
        }
        /// <summary>
        /// Verifies Class Roster Button Present in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyClassRosterInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "ViewClassRosterButton", "", WaitTime.LargeWaitTime))
            {
                return dashboardAutomationAgent.IsElementFound("DashboardView", "ViewClassRosterButton");
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Verifies Class Work Button Present in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyClassWorkInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ClassWorkButtonDashboard");
        }
        /// <summary>
        /// Verifies Camera Button Present in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCameraIconInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "CameraButtonDashboard");
        }
        /// <summary>
        /// Clicks on Notification Icon present in the Chrome
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNotificationIconInChrome(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("TasksTopMenuView", "SharingNotificationIcon");
        }
        /// <summary>
        /// Verifies Notification Overlay Exists or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Overlay Exist), false(if overlay doesn't exist)</returns>
        public static bool VerifyNotificationOverlayPresent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("TasksTopMenuView", "NotificationOverlay");
        }
        /// <summary>
        /// Clicks on Item Present in the Notification Overlay
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnItemInNotification(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("TasksTopMenuView", "ItemInNotification", "", WaitTime.LargeWaitTime))
            {
                dashboardAutomationAgent.Click("TasksTopMenuView", "ItemInNotification");
            }

        }
        /// <summary>
        /// Verifies Go To Work Browser Button Present in the Item or Not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Present), false(if not present)</returns>
        public static bool VerifyGoToWorkBrowserButton(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("TasksTopMenuView", "GoToWorkBrowserButton");
        }
        /// <summary>
        /// Clicks on Go To Work Browser Button in the Item 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGoToWorkBrowserButton(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("TasksTopMenuView", "GoToWorkBrowserButton");
        }
        /// <summary>
        /// Verifies Work Browser Page present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyWorkBrowserPage(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("WorkBrowserView", "WorkBrowserHeader");
        }
        /// <summary>
        /// Clicks on Resource Library Icon present in the App chrome
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnResourceLibraryIcon(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("TasksTopMenuView", "ToolsIcon");
        }
        /// <summary>
        /// Verifies the Resource Library Fly Out Menu available or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if avaialble), false(if not avaialble)</returns>
        public static bool VerifyResourceLibraryFlyOutMenu(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ResourceLibraryFlyOutMenu");
        }
        /// <summary>
        /// Clicks On More Explore Button in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickMoreToExploreButton(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "MoreToExploreButton");
            dashboardAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Done buttton
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDoneButton(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("InteractiveView", "DoneButtonInInteractive");
        }
        /// <summary>
        /// Clicks on Concept corner button present in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickConceptCornerButton(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "ConceptCornerButton");
            dashboardAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Overlay Done Button
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnOverlayDoneButton(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "OverlayDoneButton");
        }
        /// <summary>
        /// Verifies Concept Corner Link is at top right corner
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyConceptCorner(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.VerifyElementFound("DashboardView", "ConceptCornerButton");
            int xpos = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "ConceptCornerButton", "x")[0]);
            int ypos = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "ConceptCornerButton", "y")[0]);
            if (xpos < 2000 && ypos < 250)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verifies Concept Corner Page
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static bool VerifyConceptCornerPage(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Sleep(15000);
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ConceptCornerLabel");
        }
        /// <summary>
        /// Verifies More To Explore Button present at the Top in Dashboard 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyMoreToExplore(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.VerifyElementFound("DashboardView", "MoreToExploreButton");
            int xpos = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "MoreToExploreButton", "x")[0]);
            int ypos = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "MoreToExploreButton", "y")[0]);
            if (xpos < 2000 && ypos < 250)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies More To Explore Page 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMoreToExplorePage(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "MoreToExploreLabel", "", WaitTime.MediumWaitTime))
            {
                return dashboardAutomationAgent.IsElementFound("DashboardView", "MoreToExploreLabel");
            }
            else
            {
                return false;
            }

        }

        public static bool VerifyMoreToExplorePageStudent(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "MoreToExploreLabelStudent", "", WaitTime.MediumWaitTime))
            {
                return dashboardAutomationAgent.IsElementFound("DashboardView", "MoreToExploreLabelStudent");
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Gets the COunt of the recent modified notebook Present in the dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int: count of notebooks</returns>
        public static int GetCountOfNotebooksInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            int count = dashboardAutomationAgent.GetElementCountIn("DashboardView", "MyRecentWork", "Down", "DashboardView", "RecentWorkViewCell");
            if(count == 5) {
                dashboardAutomationAgent.SwipeElement("DashboardView", "RecentWorkViewCellCollection", Direction.Down, 0, 2000);
                dashboardAutomationAgent.Sleep(3000);
                count = count + dashboardAutomationAgent.GetElementCountIn("DashboardView", "MyRecentWork", "Down", "DashboardView", "RecentWorkViewCell");
            }
            return count;
        }
        /// <summary>
        /// Verifies if the Notebooks present in the Dashboard are at the Bottom or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if at bottom), false(if not)</returns>
        public static bool VerifyNotebooksAtBottomOfDashboard(AutomationAgent dashboardAutomationAgent)
        {
            string s = dashboardAutomationAgent.GetAllValues("DashboardView", "RecentWorkViewCellCollection", "y")[0];
            if (Int32.Parse(s) >= 942)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on the Notebooks Present in the Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <param name="notebookNumber">int</param>
        public static void ClickNotebookInDashboard(AutomationAgent dashboardAutomationAgent, int notebookNumber)
        {
            dashboardAutomationAgent.Click("DashboardView", "RecentWorkNotebooks", notebookNumber.ToString());
            dashboardAutomationAgent.Sleep();
            bool notebookOpen = NotebookCommonMethods.VerifyNotebookOpen(dashboardAutomationAgent);
            int tryCount = 0;
            while (!notebookOpen)
            {
                dashboardAutomationAgent.Click("DashboardView", "RecentWorkNotebooks", notebookNumber.ToString());
                dashboardAutomationAgent.Sleep();
                notebookOpen = NotebookCommonMethods.VerifyNotebookOpen(dashboardAutomationAgent);
                tryCount++;
                if (tryCount == 3)
                {
                    notebookOpen = false;
                }
            }
        }
        /// <summary>
        /// Verifies View In Lesson Button Of Work Browser is Present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyWorkBrowserViewInLesson(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("WorkBrowserView", "ViewInLessonButton");
        }
        /// <summary>
        /// Verifies If Personal Notebook Is present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPersonalNotebookPresent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("WorkBrowserView", "MyTitlePersonalNotebook");
        }
        /// <summary>
        /// Verifies If Common Read Is present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCommonReadPresent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("WorkBrowserView", "ELACommonReadTitle");
        }
        /// <summary>
        /// Verifies If Shared Notebooks Is present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySharedNotebooksPresent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("WorkBrowserView", "ELANotebookTitle");
        }
        /// <summary>
        /// Verifies 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if See All button is present at the right), false(if not)</returns>
        public static bool VerifySeeAllButtonInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.WaitForElement("DashboardView", "SeeAllButton", WaitTime.DefaultWaitTime);
            int xPos = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "SeeAllButton", "x")[0]);
            int yPos = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "SeeAllButton", "y")[0]);
            if (xPos > 1800 && xPos < 1950 && yPos > 850 && yPos < 1000)
                return dashboardAutomationAgent.IsElementFound("DashboardView", "SeeAllButton");
            else
                return false;
        }
        /// <summary>
        /// Verify Sharing Notification Icon present In Chrome or not.
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifySharingNotificationIconInChrome(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("TasksTopMenuView", "SharingNotificationIcon");
        }
        /// <summary>
        /// Verify Dashboard Chrome Title
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyDashboardChromeTitle(AutomationAgent dashboardAutomationAgent)
        {
            string title = dashboardAutomationAgent.GetTextIn("SystemTrayMenuView", "MyDashboard", "Inside", "", 0, 0);
            title = title.Replace("\t\n", "");
            if (title == "My Dashboard")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Hello Teacher Name On Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyHelloTeacherNameOnDashboard(AutomationAgent dashboardAutomationAgent)
        {
            string message = dashboardAutomationAgent.GetTextIn("DashboardView", "HelloTeacherName", "Inside", "", 0, 0);
            message = message.Replace("\t\n", "");
            if (message.Contains("Hello"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// clicks camera Icon Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickCameraIconDashboard(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "CameraButtonDashboard", "", WaitTime.MediumWaitTime))
            {
                dashboardAutomationAgent.Click("DashboardView", "CameraButtonDashboard");
                if (dashboardAutomationAgent.WaitForElement("LoginView", "OkButton", WaitTime.SmallWaitTime))
                {
                    dashboardAutomationAgent.Click("LoginView", "OkButton");
                }
                if (dashboardAutomationAgent.WaitForElement("LoginView", "OK", WaitTime.SmallWaitTime))
                {
                    dashboardAutomationAgent.Click("LoginView", "OK");
                }
            }

        }
        /// <summary>
        /// Verifies camera roll button
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static bool VerifyCameraRollButton(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "CameraRollButton");
        }
        /// <summary>
        /// clicks on camera roll button
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickCameraRollButton(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "CameraRollButton");
        }
        /// <summary>
        /// Add Photo From camera roll in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <param name="CancelSelectedPhoto">AutomationAgent object</param>
        public static void AddPhotoInDashboard(AutomationAgent dashboardAutomationAgent, bool CancelSelectedPhoto)
        {
            dashboardAutomationAgent.Click("NotebookBottomMenuView", "Album");
            int i = 1;
            bool photoExists = true;
            bool PhotoNotAvailable = true;

            while (photoExists)
            {
                if (dashboardAutomationAgent.IsElementFound("NotebookBottomMenuView", "SelectPhoto", (i + 2).ToString()))
                {
                    dashboardAutomationAgent.Click("NotebookBottomMenuView", "SelectPhoto", (i + 3).ToString(), 1, WaitTime.DefaultWaitTime);

                    if (dashboardAutomationAgent.IsElementFound("NotebookBottomMenuView", "IsThumbnailVideo"))
                    {
                        //video
                        dashboardAutomationAgent.Click("NotebookBottomMenuView", "VideoBackButton");
                        i++;
                    }

                    else
                    {
                        PhotoNotAvailable = false;
                        i++;
                        //Photo
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
                dashboardAutomationAgent.Click("NotebookBottomMenuView", "ImageCancelButton");
                dashboardAutomationAgent.Sleep(1000);
                dashboardAutomationAgent.Click("DashboardView", "CameraButtonDashboard");
                dashboardAutomationAgent.Click("DashboardView", "CameraIconDashboardPopUp");
                dashboardAutomationAgent.Click("CameraView", "CAMShutterButton");
                dashboardAutomationAgent.Sleep(2000);
                dashboardAutomationAgent.Click("CameraView", "UsePhotoButton");
            }

            else
            {
                if (CancelSelectedPhoto)
                {
                    dashboardAutomationAgent.Click("NotebookBottomMenuView", "ImageCancelButton");
                }
                else
                {
                    dashboardAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");
                }
            }
        }
        /// <summary>
        /// Clicks Delete Photo From Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickDeletePhotoInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "DeletePhotoInDashboard");
        }
        /// <summary>
        /// verfies Delete Photo in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if delete button found), false(not found)</returns>
        public static bool VerifyDeleteButtonInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "DeletePhotoInDashboard");
        }
        /// <summary>
        /// Verifies Placeholder 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean:true(if Dashhboard placeholder found),False(not found)</returns>
        public static bool VerifyDashboardPlaceHolder(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "DashboardPlaceHolder");
        }
        /// <summary>
        /// Verifies CameraIcon In Dashboard Popup
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean:true(if Camera Icon in dashboard found),False(not found)</returns>
        public static bool VerifyCameraIconDashboardPopUp(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "CameraIconDashboardPopUp");
        }
        /// <summary>
        /// Clicks Camera Icon Dashboard popup
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickCameraIconDashboardPopUp(AutomationAgent dashboardAutomationAgent, bool retry = false)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "CameraIconDashboardPopUp", "", WaitTime.MediumWaitTime))
            {
                dashboardAutomationAgent.Click("DashboardView", "CameraIconDashboardPopUp");
            }
            else
            {
                if (!retry)
                {
                    ClickCameraIconDashboard(dashboardAutomationAgent);
                    ClickCameraIconDashboardPopUp(dashboardAutomationAgent, true);
                }
            }

        }
        /// <summary>
        /// Clicks Camera shutter Take photo
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCameraShutterTakePhoto(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("CameraView", "CAMShutterButton", "", WaitTime.LargeWaitTime))
            {
                dashboardAutomationAgent.Click("CameraView", "CAMShutterButton");
            }

        }
        /// <summary>
        /// clicks on Retake photo 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRetakePhoto(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Sleep(1000);
            dashboardAutomationAgent.Click("CameraView", "RetakeButton");
        }
        /// <summary>
        /// clicks on new Remainder in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNewRemainderInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "NewReminderDashboard");
        }
        /// <summary>
        /// Click Add Character in New Remainder until it reaches 500
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void AddCharactersInNewReminder(AutomationAgent dashboardAutomationAgent, int numberOfChars = 50)
        {
            int remainder = numberOfChars % 50;
            int loopCount = numberOfChars / 50;
            for (int i = 0; i < loopCount; i++)
            {
                dashboardAutomationAgent.SendText("Our education system needs change. We need to work");
            }
            for (int i = 0; i < remainder; i++)
            {
                dashboardAutomationAgent.SendText("t");
            }
        }


        /// <summary>
        /// Click Add Character in New Remainder until it reaches 500
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void AddCharactersInNewReminder(AutomationAgent dashboardAutomationAgent, string texttoadd)
        {
            if (texttoadd == "BKSP")
                dashboardAutomationAgent.SendText("{BKSP}");

            else
                dashboardAutomationAgent.SendText(texttoadd);

        }


        /// <summary>
        /// Verfies Maximum Character Limit In the Remainder
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMaxCharactersLimit(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "CharacterCountReminder");
        }
        /// <summary>
        /// Get maximum character count
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string GetMaxCharacterCount(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementText("DashboardView", "CharacterCountReminder");
        }

        /// <summary>
        /// Verify Hello Teacher Name On Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyHelloUserNameOnDashboard(AutomationAgent dashboardAutomationAgent, string Name)
        {
            string message = dashboardAutomationAgent.GetTextIn("DashboardView", "HelloStudentName", "Inside", "", 0, 0);
            message = message.Replace("\t\n", "");
            if (message.Contains("Hello, "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyHelloUserNameAtTopLeft(AutomationAgent dashboardAutomationAgent)
        {
            string position = dashboardAutomationAgent.GetPosition("DashboardView", "HelloStudentName");
            string[] pos = position.Split(',');
            if (Int32.Parse(pos[0]) < 600 && Int32.Parse(pos[1]) < 300)
                return true;

            else
                return false;
        }

        public static string GetReminderCountOnDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementText("DashboardView", "ReminderNoCountLabel").Replace("\t", "").Replace("\n", "");
        }

        public static void ClickCreateNewReminder(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "CreateButtonNewReminder");
            dashboardAutomationAgent.Sleep(1000);
        }

        public static string GetCharacterCountFromNewReminderBox(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementText("DashboardView", "CharacterCountLabelNewReminder").Replace("\t", "").Replace("\n", "");
        }

        public static void ClickToOpenExistingReminder(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "ExistingReminderDashboard");
        }


        public static string GetMaxPermittedCharCountLabelReminder(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementText("DashboardView", "MaxCharacterCountLabelNewReminder").Replace("\t", "").Replace("\n", "");
        }

        public static void AddPhotoInDashboardWithesizeAndReposition(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("NotebookBottomMenuView", "Album");
            int i = 2;
            bool photoExists = true;
            bool PhotoNotAvailable = true;

            while (photoExists)
            {
                if (dashboardAutomationAgent.IsElementFound("NotebookBottomMenuView", "SelectPhoto", (i).ToString()))
                {
                    dashboardAutomationAgent.Click("NotebookBottomMenuView", "SelectPhoto", (i).ToString(), 1, WaitTime.DefaultWaitTime);

                    if (dashboardAutomationAgent.IsElementFound("NotebookBottomMenuView", "IsThumbnailVideo"))
                    {
                        //video
                        dashboardAutomationAgent.Click("NotebookBottomMenuView", "VideoBackButton");
                        i++;
                    }

                    else
                    {
                        PhotoNotAvailable = false;
                        i++;
                        //Photo
                        break;

                    }

                }
                else
                {
                    photoExists = false;

                    break;
                }
            }

            if (dashboardAutomationAgent.IsElementFound("DashboardView", "NoPhotosCameraRoll"))
            {
                dashboardAutomationAgent.Click("NotebookBottomMenuView", "ImageCancelButton");
                dashboardAutomationAgent.Sleep(1000);
                dashboardAutomationAgent.Click("DashboardView", "CameraButtonDashboard");
                dashboardAutomationAgent.Click("DashboardView", "CameraIconDashboardPopUp");
                dashboardAutomationAgent.Click("CameraView", "CAMShutterButton");
                dashboardAutomationAgent.Sleep(2000);
                string imgpos1 = dashboardAutomationAgent.GetPosition("NotebookBottomMenuView", "ImageResizeRepos");
                string[] imgposition1 = imgpos1.Split(',');
                //Resize
                dashboardAutomationAgent.PinchOut(Int32.Parse(imgposition1[0]), Int32.Parse(imgposition1[1]));
                //repos
                dashboardAutomationAgent.Sleep(500);
                dashboardAutomationAgent.SwipeElement("NotebookBottomMenuView", "ImageResizeRepos", Direction.Right, 0, 2000);
                dashboardAutomationAgent.Click("CameraView", "UsePhotoButton");
            }
            else
            {
                //Resizing & Repositioning

                string imgpos = dashboardAutomationAgent.GetPosition("NotebookBottomMenuView", "ImageResizeRepos");
                string[] imgposition = imgpos.Split(',');
                //Resize
                dashboardAutomationAgent.PinchOut(Int32.Parse(imgposition[0]), Int32.Parse(imgposition[1]));
                //repos
                dashboardAutomationAgent.Sleep(500);
                dashboardAutomationAgent.SwipeElement("NotebookBottomMenuView", "ImageResizeRepos", Direction.Right, 0, 2000);

                dashboardAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");
            }
        }

        public static void ClickContinueLessonButton(AutomationAgent teachermodeAutomationAgent)
        {
            if(teachermodeAutomationAgent.IsElementFound("DashboardView", "ContinueLessonButtonTeacherDashboard")) 
            {
                teachermodeAutomationAgent.Click("DashboardView", "ContinueLessonButtonTeacherDashboard");
            }
            else if (teachermodeAutomationAgent.IsElementFound("DashboardView", "StartLessonButton"))
            {
                teachermodeAutomationAgent.Click("DashboardView", "StartLessonButton");
            }
        }



        public static string GetTextOfBackToParentButton(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetTextIn("UnitOverView", "UnitPreviewBackButton", "Inside", "").Replace("\t", "").Replace("\n", "");
        }

        public static bool VerifyContinueLessonInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ContinueLessonButtonTeacherDashboard");
        }

        public static void ClickDeleteReminder(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "DeleteReminderInDashboard");
        }

        public static bool VerifyReminderBottomAligned(AutomationAgent dashboardAutomationAgent)
        {
            string ReminderPosy = dashboardAutomationAgent.GetAllValues("DashboardView", "ExistingReminderDashboard", "y")[0];

            if (Int32.Parse(ReminderPosy) > 500)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Swipe reminders
        /// </summary>
        /// <param name="dashboardAutomationAgent"></param>
        /// <param name="direction"></param>
        public static void SwipeRminders(AutomationAgent dashboardAutomationAgent, Direction direction)
        {
            dashboardAutomationAgent.SwipeElement("DashboardView", "ReminderCollectionView", direction, 0, 2000);
        }
        /// <summary>
        /// Verify More Explore Button 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static bool VerifyMoreToExploreButton(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "MoreToExploreButton");
        }

        /// <summary>
        /// Verify todays day and date present on dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent"></param>
        /// <param name="p"></param>
        /// <returns>true:if present;false:not present</returns>
        public static bool VerifyToadaysDayAndDateonDashboard(AutomationAgent dashboardAutomationAgent, string p)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "TodayDayAndDate");

        }

        public static bool VerifyToadaysDayAndDateAtTopRight(AutomationAgent dashboardAutomationAgent)
        {
            int todayDayAndDateX = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "TodayDayAndDate", "x")[0]);
            int todayDayAndDateY = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "TodayDayAndDate", "y")[0]);

            if (todayDayAndDateX > 1000 && todayDayAndDateY > 200)
                return true;

            else
                return false;

        }
        /// <summary>
        /// Verifies reminder exists or not
        /// </summary>
        /// <param name="dashboardAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyExistingReminderExists(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ExistingReminderDashboard");
        }
        /// <summary>
        /// Verifies No message on remider displayed
        /// </summary>
        /// <param name="dashboardAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyReminderNoMessageDisplayed(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "NoMessageReminder");

        }
        /// <summary>
        /// Verifies Swipe indicator present
        /// </summary>
        /// <param name="dashboardAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifySwipeIndicatorPresent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ReminderPaginationIndicator");
        }

        public static void SwipeDashboard(AutomationAgent dashboardAutomationAgent, Direction direction)
        {
            dashboardAutomationAgent.Swipe(direction);
        }
        /// <summary>
        /// Verifies indicator dots are vissible
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyIndicatorDotsVisible(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "DashboardIndicatorDotsVisible");
        }

        /// <summary>
        /// Click start unit button in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickStartUnitInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.IsElementFound("DashboardView", "StartLessonButton", ""))
            {
                dashboardAutomationAgent.Click("DashboardView", "StartLessonButton");
            }
            else if (dashboardAutomationAgent.IsElementFound("DashboardView", "ContinueLessonButtonTeacherDashboard"))
            {
                dashboardAutomationAgent.Click("DashboardView", "ContinueLessonButtonTeacherDashboard");
                dashboardAutomationAgent.Click("TeacherModeView", "BackButton");
            }

        }
        /// <summary>
        /// Get unit title from chrome bar
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>string</returns>
        public static string GetUnitTiltleInChrome(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementText("LessonBrowserView", "UnitTitle");
        }
        /// <summary>
        /// Click on the rightmost camera button
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRightmostCameraIcon(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "RightCameraIcon");
        }
        /// <summary>
        /// Get x position of rightmost camera pop up arrow
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetRightmostCameraIconArrowPosition(AutomationAgent dashboardAutomationAgent)
        {
            return Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "RightmostCameraPopUpArrow", "x")[0]);
        }
        /// <summary>
        /// Get camera pop up x position
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetCameraPopUpPosition(AutomationAgent dashboardAutomationAgent)
        {
            return Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "CameraIconDashboardPopUp", "x")[0]);
        }
        /// <summary>
        /// Get leftmost camera icon x position
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static int GetLeftmostCameraIconPosition(AutomationAgent dashboardAutomationAgent)
        {
            return Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "CameraButtonDashboard", "x")[0]);
        }

        /// <summary>
        /// Verifies Section Titles IN Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifySectionTitlesInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "SectionTitle");
        }

        /// <summary>
        /// Gets The section Tiltle
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>String</returns>
        public static string GetSectionTitle(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetTextIn("DashboardView", "SectionTitle", "inside", "").Replace("\t", "").Replace("\n", "");
        }
        /// <summary>
        /// Verifies Section Titles In work browser
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifySectionTitlesInWorkBrowser(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "SectionTitleInWorkBrowser");
        }
        /// <summary>
        /// Gets New Section  Tiltle
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>String</returns>
        public static string GetNewSectionTitle(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetTextIn("DashboardView", "SectionTitleInWorkBrowser", "inside", "").Replace("\t", "").Replace("\n", "");
        }
        /// <summary>
        /// Verifies Nonsectioned Grade On Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static bool VerifyNonSectionedGradeInDashboard(AutomationAgent dashboardAutomationAgent, int grade)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "NonSectionGrade", grade.ToString());
        }

        public static void ClickMoreToExploreButtonStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "MoreToExploreButtonStudentDashboard");
            dashboardAutomationAgent.Sleep();
        }

        /// <summary>
        /// Gets the Grade no 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent Object</param>
        /// <returns></returns>
        public static string GetStringOfGradeSelected(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetTextIn("GradeSelectionMenuView", "Gradefour", "inside", "").Replace("\t", "").Replace("\n", "");
        }
        public static bool VerifySafariBrowserUrl(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("iPadCommonView", "SafariBrowserUrl");
        }

        public static bool VerifyDoneButtonInCCNativeView(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("TasksTopMenuView", "DoneButton");
        }
        public static bool VerifyDoneButtonInMTENativeView(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("TasksTopMenuView", "DoneButton");
        }
        /// <summary>
        /// Get reminder indicator dots count
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetPaginationIndicatorCount(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementCount("DashboardView", "ReminderPaginationIndicatorDots");
        }

        /// <summary>
        /// Click Class Roster Button Present in Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickClassRosterInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "ViewClassRosterButton");
        }
        /// <summary>
        /// Get grade number in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetTileUnitNumber(AutomationAgent dashboardAutomationAgent)
        {
            string s = dashboardAutomationAgent.GetTextIn("DashboardView", "UnitTitleDashboardTile", "Inside", "");
            string[] s1 = s.Split(' ');
            return Int32.Parse(s1[1]);

        }
        /// <summary>
        /// Get section number in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetTileSectionNumber(AutomationAgent dashboardAutomationAgent)
        {
            string s = dashboardAutomationAgent.GetTextIn("DashboardView", "SectionDashboardTile", "Inside", "");
            string[] s1 = s.Split('-');
            return Int32.Parse(s1[2].Replace(" Per", ""));
        }
        /// <summary>
        /// GEt last tile grade number in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetLastTileUnitNumber(AutomationAgent dashboardAutomationAgent)
        {
            string s = dashboardAutomationAgent.GetTextIn("DashboardView", "LastUnitTitleDashboardTile", "Inside", "");
            string[] s1 = s.Split(' ');
            return Int32.Parse(s1[1]);
        }
        /// <summary>
        /// Get last tile section number in dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>int</returns>
        public static int GetLastTileSectionNumber(AutomationAgent dashboardAutomationAgent)
        {
            string s = dashboardAutomationAgent.GetTextIn("DashboardView", "LastSectionDashboardTile", "Inside", "");
            string[] s1 = s.Split('-');
            return Int32.Parse(s1[2].Replace(" Per", ""));
        }

        /// <summary>
        /// Get old reminder time stamp 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>string: timestamp</returns>
        public static string GetOldReminderModificationTime(AutomationAgent dashboardAutomationAgent)
        {

            if (dashboardAutomationAgent.IsElementFound("DashboardView", "OldReminderTimeStamp"))
            {
                string timestamp = dashboardAutomationAgent.GetTextIn("DashboardView", "OldReminderTimeStamp", "inside", "");
                string[] s = timestamp.Split(':');
                return s[1].Replace("\t\n", "");
            }
            else
            {
                dashboardAutomationAgent.SwipeElement("DashboardView", "ReminderCollectionView", Direction.Right, 0, 2000);
                string timestamp = dashboardAutomationAgent.GetTextIn("DashboardView", "OldReminderTimeStamp", "inside", "");
                string[] s = timestamp.Split(':');
                return s[1].Replace("\t\n", "");
            }
        }

        /// <summary>
        /// Get Latest remimnder timestamp
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>string: timestamp</returns>
        public static string GetLatestReminderModificationTime(AutomationAgent dashboardAutomationAgent)
        {
            string datestamp = dashboardAutomationAgent.GetTextIn("DashboardView", "LatestReminderTimeStamp", "inside", "");
            string[] s1 = datestamp.Split(':');
            return s1[1].Replace("\t\n", "");
        }
        /// <summary>
        /// Verifies Recent work tile is displayed
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyRecentWorkToDisplay(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "StudentRecentWorkTile");
        }
        /// <summary>
        /// Click on Start unit in student dashboard.
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickStartUnitInStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "StartUnitButtonInStudentDashboard");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickNotebookInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "StudentRecentWorkTile");
        }
        /// <summary>
        /// Get Lesson Tilte in chrome bar
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>string: lesson title</returns>
        public static string GetLessonTitleInChrome(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.GetElementText("LessonBrowserView", "LessonTitle");
        }
        /// <summary>
        /// click on continue Math lesson button in student dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickMathContinueLessonStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "StudentContinueLessonButtonMath");
        }
        /// <summary>
        /// click on continue Math lesson button in teacher dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickContinueLessonTeacherDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "ContinueLessonButtonTeacherDashboard");
        }

        /// <summary>
        /// Verifies Start Unit ELA button In dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyStartUnitStudentELAButton(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "StartLessonButtonStudent");
        }
        /// <summary>
        /// Verifies Start Unit Math In Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyStartUnitStudentMathButton(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "StartMathLessonButtonStudent");
        }
        /// <summary>
        /// Verifies Unit Tile Number In dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyUnitTileNumberInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "UnitTitleInDashboardTile");
        }
        /// <summary>
        /// Verifies Section Dashboard Title
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifySectionDashboardTitle(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "SectionDashboardTile");
        }
        /// <summary>
        /// Verifies Section Grade In Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifySectionGradeInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "LastUnitTitleDashboardTile");
        }

        public static bool VerifyScrollNotAvailableForSingleSectionedUser(AutomationAgent dashboardAutomationAgent)
        {
            return Boolean.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "DashboardIndicatorDotsVisible", "hidden")[0]);
        }

        public static bool VerifyClassRosterMathInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "ViewClassRosterButton", "", WaitTime.LargeWaitTime))
            {
                return dashboardAutomationAgent.IsElementFound("DashboardView", "ViewClassRosterButton");
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyClassWorkMathInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "ClassWorkButtonDashboard");
        }

        public static string GetUnitTiltleName(AutomationAgent dashboardAutomationAgent)
        {
            string s = dashboardAutomationAgent.GetElementText("LessonBrowserView", "UnitTitle");
            string[] s1 = s.Split(':');
            return s1[1];
        }
        /// <summary>
        /// Gets Unit title name in more to explore
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object </param>
        /// <returns>string</returns>
        public static string GetUnitTiltleNameInMorToExplore(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.WaitforElement("LessonBrowserView", "UnitTitleMoreToExplore", "");
            string s = dashboardAutomationAgent.GetTextIn("LessonBrowserView", "UnitTitleMoreToExplore", "Inside", "");
            string[] s1 = s.Split(' ');
            return s1[1];
        }
        /// <summary>
        /// Gets the Unit Title in Concept Corner
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>Strin</returns>
        public static string GetUnitTitleNameConceptCorner(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.WaitforElement("DashboardView", "UnitTitleConceptCorner", "");
            string s = dashboardAutomationAgent.GetTextIn("DashboardView", "UnitTitleConceptCorner", "Inside", "").Replace("\t", "").Replace("\n", "");
            string[] s1 = s.Split(' ');
            return s1[1];

        }
        /// <summary>
        /// Clicks ELA Continue Lesson In Student dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent Object</param>
        public static void ClickELAContinueLessonStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "StudentContinueLessonButtonELA");
        }
        /// <summary>
        /// Clicks Start Unit In Math Student
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent Object</param>
        public static void ClickStartUnitMathStudent(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "StartMathLessonButtonStudent");
        }
        /// <summary>
        /// Verifies Second Section In Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent Object</param>
        /// <returns>bool</returns>
        public static bool VerifySecondSectionInDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "SecondSectionTitleDashboard");
        }
        /// <summary>
        /// Verify Shared Work Dropdown is Present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent Object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifySharedWorkDropdownPresent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "SharedWorkDropdown");
        }
        /// Verifies Class Roster Opened
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent Object</param>
        /// <returns>bool</returns>
        public static bool VerifyClassRosterOpened(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ClassRosterCollectionCell", "1");
        }
        /// <summary>
        /// Verifies Class Roster Page Header
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent Object</param>
        /// <returns>bool</returns>
        public static bool VerifyClassRosterPageHeader(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ClassRosterHeader");
        }
        /// <summary>
        /// Verifies Class Roster Student Name And Avatar
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent Object</param>
        /// <returns>bool</returns>
        public static bool VerifyClassRosterStudentNameAndAvatar(AutomationAgent teachermodeAutomationAgent)
        {
            return teachermodeAutomationAgent.IsElementFound("TeacherModeView", "ClassRosterStudentAvatar");
        }
        /// <summary>
        /// Class Roster Scroll Vertically
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent Object</param>
        public static void ScrollClassRosterVertically(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Swipe(Direction.Up);
        }
        /// <summary>
        /// Clicks Student Tile In Class Roster
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent Object</param>
        public static void ClickStudentTileInClassRoster(AutomationAgent teachermodeAutomationAgent)
        {
            teachermodeAutomationAgent.Click("TeacherModeView", "ClassRosterCollectionCell");

        }

        /// <summary>
        /// Verifies continue lesson button is present
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent Object</param>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyContinueMathLessonInStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "StudentContinueLessonButtonMath");
        }

        public static bool VerifyDashboardPlaceHolderStudent(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "DashboardPlaceHolderStudent");
        }

        public static bool VerifyDashboardPlaceHolderTeacher(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("DashboardView", "DashboardPlaceHolderTeacher");
        }

        public static bool VerifyMoreToExploreStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "MoreToExploreButtonStudentDashboard", "", WaitTime.LargeWaitTime))
            {
                return dashboardAutomationAgent.IsElementFound("DashboardView", "MoreToExploreButtonStudentDashboard");
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyConceptCornerStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.WaitforElement("DashboardView", "ConceptCornerButtonStudentDashboard", "", WaitTime.LargeWaitTime))
            {
                return dashboardAutomationAgent.IsElementFound("DashboardView", "ConceptCornerButtonStudentDashboard");
            }
            else
            {
                return false;
            }

        }

        public static void ClickConceptCornerButtonStudentDashboard(AutomationAgent dashboardAutomationAgent)
        {
            dashboardAutomationAgent.Click("DashboardView", "ConceptCornerButtonStudentDashboard");
        }

        public static void AddNotebookInDashboard(AutomationAgent dashboardAutomationAgent, TaskInfo taskInfo, int noOfNotebooks)
        {
            NavigationCommonMethods.NavigateToELAGrade(dashboardAutomationAgent, taskInfo.Grade);
            NavigationCommonMethods.StartELAUnitFromUnitLibrary(dashboardAutomationAgent, taskInfo.Unit);
            NavigationCommonMethods.OpenELALessonFromLessonBrowser(dashboardAutomationAgent, taskInfo.Lesson);

            for (int i = 0; i < noOfNotebooks; i++)
            {
                NavigationCommonMethods.NavigateToTaskPageInLesson(dashboardAutomationAgent, i + 1);
                NotebookCommonMethods.ClickOnNotebookIcon(dashboardAutomationAgent);
                NotebookCommonMethods.ClickEraseIconInNotebook(dashboardAutomationAgent);
                NotebookCommonMethods.ClickClearPage(dashboardAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(dashboardAutomationAgent);
                NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1200, 700, 1);
                NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1230, 700, 1);
                NotebookCommonMethods.SendText(dashboardAutomationAgent, "Page " + i);
                NotebookCommonMethods.TapOnScreen(dashboardAutomationAgent, 1200, 300, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(dashboardAutomationAgent);
            }
        }

        public static string GetUnitNumberInUnitPreview(AutomationAgent dashboardAutomationAgent)
        {
            int index = 1;
            int xOfUnitPane = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "UnitNumber", index + "", "x")[0]);
            int widthOfUnitPane = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "UnitNumber", index + "", "width")[0]);
            while (xOfUnitPane < 0 || (xOfUnitPane + widthOfUnitPane) > 1900)
            {
                index++;
                xOfUnitPane = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "UnitNumber", index + "", "x")[0]);
                widthOfUnitPane = Int32.Parse(dashboardAutomationAgent.GetAllValues("DashboardView", "UnitNumber", index + "", "width")[0]);
            }
            return dashboardAutomationAgent.GetTextIn("DashboardView", "UnitNumber", "Inside", index + "");
        }
        /// <summary>
        /// click Start Unit ELA In Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickStartUnitStudentELAButton(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.IsElementFound("DashboardView", "StartLessonButtonStudent"))
            {
                dashboardAutomationAgent.Click("DashboardView", "StartLessonButtonStudent");
            }
            else if (dashboardAutomationAgent.IsElementFound("DashboardView", "StudentContinueLessonButtonELA"))
            {
                dashboardAutomationAgent.Click("DashboardView", "StudentContinueLessonButtonELA");
                dashboardAutomationAgent.Sleep(3000);
                if (dashboardAutomationAgent.WaitforElement("TeacherModeView", "BackButton", "", WaitTime.LargeWaitTime))
                {
                    dashboardAutomationAgent.Click("TeacherModeView", "BackButton");
                }
            }
            dashboardAutomationAgent.Sleep(4000);
        }
        /// <summary>
        /// click Start Unit Math In Dashboard
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void ClickStartUnitStudentMathButton(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.IsElementFound("DashboardView", "StartMathLessonButtonStudent"))
            {
                dashboardAutomationAgent.Click("DashboardView", "StartMathLessonButtonStudent");
            }
            else if (dashboardAutomationAgent.IsElementFound("DashboardView", "StudentContinueLessonButtonMath"))
            {
                dashboardAutomationAgent.Click("DashboardView", "StudentContinueLessonButtonMath");
                dashboardAutomationAgent.Sleep(3000);
                if (dashboardAutomationAgent.WaitforElement("TeacherModeView", "BackButton", "", WaitTime.LargeWaitTime))
                {
                    dashboardAutomationAgent.Click("TeacherModeView", "BackButton");
                }
            }
            dashboardAutomationAgent.Sleep(4000);
        }

        public static bool VerifyNotebookOpenedInWorkBrowser(AutomationAgent dashboardAutomationAgent)
        {
            return dashboardAutomationAgent.IsElementFound("WorkBrowserView", "ViewInLesson");
        }
    }
}
