using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pearson.PSCAutomation.K1App
{
    public static class EreaderCommonMethod
    {
        /// <summary>
        /// Click to open next page in eReader
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <param name="nextCount">nextCount: describe number you want to go on next page</param>
        public static void ClickOnNextPageIcon(AutomationAgent eReaderAutomationAgent, int nextCount)
        {
            for (int i = 1; i <= nextCount; i++)
            {
                eReaderAutomationAgent.Click("eReaderView", "NextPage");
            }

        }

        /// <summary>
        /// Click to open previous page in eReader
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <param name="nextCount">nextCount: describe number you want to go to previous page</param>
        public static void ClickOnPreviousPageIcon(AutomationAgent eReaderAutomationAgent, int prevCount)
        {
            for (int i = 1; i <= prevCount; i++)
            {
                eReaderAutomationAgent.Click("eReaderView", "PreviousPage");
            }

        }

        /// <summary>
        /// Get current page count
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>current opened page count</returns>
        public static int GetCurrentPageCount(AutomationAgent eReaderAutomationAgent)
        {
            if (eReaderAutomationAgent.IsElementFound("eReaderView", "NextPage"))
            {
                eReaderAutomationAgent.Sleep(2000);
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);

                return Int32.Parse(eReaderAutomationAgent.GetElementText("eReaderView", "PageNumLabel"));

            }
            else
            {
                eReaderAutomationAgent.Sleep(2000);
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                return Int32.Parse(eReaderAutomationAgent.GetTextIn("eReaderView", "PreviousPage", "Right", ""));
            }
        }

        /// <summary>
        /// Verify Navbar activated
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyNavigationBarActivated(AutomationAgent eReaderAutomationAgent)
        {
            if (!eReaderAutomationAgent.IsElementFound("eReaderView", "HeaderView"))
            {
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
            }
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "HeaderView");
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "FooterView");
        }

        /// <summary>
        /// Verify Top Navigar bar items
        /// 1. back hand in left, 
        /// 2. notebook icon in center, 
        /// 3. send to notebook icon in right
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyTopNavBarItemsAtEreader(AutomationAgent eReaderAutomationAgent)
        {            
            if (!eReaderAutomationAgent.IsElementFound("MediaLibrary", "BackButtonAtImageViewer"))
            {
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
            }
            eReaderAutomationAgent.VerifyElementFound("MediaLibrary", "BackButtonAtImageViewer");
            eReaderAutomationAgent.Sleep(2000);
            if (!eReaderAutomationAgent.IsElementFound("MediaLibrary", "BackButtonAtImageViewer"))
            {
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
            }
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "EditNotebookIcon");
            eReaderAutomationAgent.Sleep(2000);
            if (!eReaderAutomationAgent.IsElementFound("MediaLibrary", "BackButtonAtImageViewer"))
            {
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
            }
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "SendNotebookIcon");
        }

        /// <summary>
        /// Bottom gray nav should appear with paging information centered at bottom
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyBottomNavBarItemsAtEreader(AutomationAgent eReaderAutomationAgent)
        {
            if (!eReaderAutomationAgent.IsElementFound("eReaderView", "PreviousPage"))
            {
                if (!eReaderAutomationAgent.IsElementFound("eReaderView", "NextPage"))
                {
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                }
                eReaderAutomationAgent.Click("eReaderView", "NextPage");
                eReaderAutomationAgent.VerifyElementFound("eReaderView", "PreviousPage");
            }
            if (!eReaderAutomationAgent.IsElementFound("eReaderView", "NextPage"))
            {
                if (!eReaderAutomationAgent.IsElementFound("eReaderView", "PreviousPage"))
                {
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                }
                eReaderAutomationAgent.Click("eReaderView", "PreviousPage");
                eReaderAutomationAgent.VerifyElementFound("eReaderView", "NextPage");
            }
        }


        /// <summary>
        /// clicks to open book from today shelf
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenBookFromTodayShelf(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "MediaLibrary", "MediaLibraryBook", "", "Right");
        }

        /// <summary>
        /// Verify if page count is not equal to 1 than Previous page should display, click on previous icon till its not get disabled
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <param name="getPagecount">page count</param>
        /// <returns>true: when previous page icon get disabled</returns>
        public static bool VerifyPreviousPageIconTillDisabled(AutomationAgent eReaderAutomationAgent, int getPagecount)
        {
            while (getPagecount != 1)
            {
                eReaderAutomationAgent.Click("eReaderView", "PreviousPage");
                eReaderAutomationAgent.Sleep();
                getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
            }

            return !(eReaderAutomationAgent.IsElementFound("eReaderView", "PreviousPage"));

        }

        /// <summary>
        /// if next page icon is enabled then click on it till it get disabled
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>true: when next page icon get disabled</returns>
        public static bool VerifyNextPageIconTillDisabled(AutomationAgent eReaderAutomationAgent)
        {
            while (eReaderAutomationAgent.IsElementFound("eReaderView", "NextPage"))
            {
                eReaderAutomationAgent.Click("eReaderView", "NextPage");
                eReaderAutomationAgent.Sleep();
            }

            return !(eReaderAutomationAgent.IsElementFound("eReaderView", "NextPage"));
        }


        /// <summary>
        /// Verify Page number is in middle of next and previous icons
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if next icon left side number and prev icon right side number is same</returns>
        public static bool VerifyPageNumberInMiddle(AutomationAgent eReaderAutomationAgent)
        {
            //eReaderAutomationAgent.Click("eReaderView", "PreviousPage");
            int widthofbottomnavbar = Int32.Parse(eReaderAutomationAgent.GetAllValues("eReaderView", "Footer", "width")[0]);
            int widthofPageNumLabel = Int32.Parse(eReaderAutomationAgent.GetAllValues("eReaderView", "PageNumLabel", "width")[0]);

            int XcoordinateOfPageNumLabel = Int32.Parse(eReaderAutomationAgent.GetAllValues("eReaderView", "PageNumLabel", "x")[0]);

            return ((widthofbottomnavbar / 2) == (XcoordinateOfPageNumLabel) + (widthofPageNumLabel / 2) - 8) ? true : false;




        }

        /// <summary>
        /// Verify eRaeder page is swipeable
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void SwipeToGetNextPage(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.Swipe(Direction.Right);
        }

        /// <summary>
        /// Return current page position 
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>return x axis</returns>
        public static int GetCurrentPagePosition(AutomationAgent eReaderAutomationAgent)
        {
            string[] position = eReaderAutomationAgent.GetPosition("eReaderView", "EreaderContent").Split(',');
            return Int32.Parse(position[0]);
        }

        /// <summary>
        /// Zoom Out the Ereader
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ZoomOutTheEreader(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.PinchOut();
        }
        /// <summary>
        /// Verify Ereader Header
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyEreaderHeaderView(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.IsElementFound("eReaderView", "HeaderView");
        }
        /// <summary>
        /// Verify Ereader Footer
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyEreaderFooterView(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.IsElementFound("eReaderView", "FooterView");
        }
        /// <summary>
        /// Click on the send to notebook button in Ereader
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSendToNotebookButtonInEreader(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Click("eReaderView", "SendNotebookIcon");
        }

        /// <summary>
        /// Click on edit icon for eReader
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickToEditEreader(AutomationAgent eReaderAutomationAgent)
        {
            if (!eReaderAutomationAgent.IsElementFound("eReaderView", "EditNotebookIcon"))
            {
                NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
            }
            eReaderAutomationAgent.Click("eReaderView", "EditNotebookIcon");
        }

        /// <summary>
        /// Click on top book icon for ereader in edit mode
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTopBookForEreader(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.Click("eReaderView", "TopBookAtEreader");
        }

        /// <summary>
        /// Verify google eye button for ereader
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifyGoogleEyeButtonForEreader(AutomationAgent eReaderAutomationAgent)
        {
            return eReaderAutomationAgent.IsElementFound("eReaderView", "GoogleEyeButton");
        }

        /// <summary>
        /// Verify Page arrow activated
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyPageArrowActivated(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "NextPage");
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "PreviousPage");
        }

        /// <summary>
        /// Verify eReader content display
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyEreaderContent(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "eReaderContent");
        }
        /// <summary>
        /// Verify cropping area 
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyCroppingArea(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.VerifyElementFound("UnitSelection", "CrossIconInBookogCamMode");
        }
        /// <summary>
        /// Verify user on annotation screen mode
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserOnAnnotationScreen(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "TopBookAtEreader");
        }
        /// <summary>
        /// Click on send to notebook button in annotation mode 
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSendToNotebookButtonInAnnotationMode(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.Click("eReaderView", "SendToNotebookButtonInAnnotationMode");
        }
        /// <summary>
        /// Verify SnapShot send to Notebook
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifySnapShotSendToNotebook(AutomationAgent eReaderAutomationAgent)
        {
            return eReaderAutomationAgent.IsElementFound("NotebookView", "NotebookImage");
        }
        /// <summary>
        /// Verify Snapshot added to new page
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <param name="count">int object: count of the page in which snapshot added</param>
        public static bool VerifySnapshotAddedToNewPage(AutomationAgent eReaderAutomationAgent, int count)
        {
            int countincanvas = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(eReaderAutomationAgent, (count + 1));
            if (countincanvas.Equals(count + 1))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify snapshot in the centre of the screen
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifySnapshotInTheCentreOfPage(AutomationAgent eReaderAutomationAgent)
        {
            int width = Int32.Parse(eReaderAutomationAgent.GetAllValues("NotebookView", "NotebookImage", "width")[0]);
            int xcoordinate = Int32.Parse(eReaderAutomationAgent.GetAllValues("NotebookView", "NotebookImage", "x")[0]);
            int WidthOfNavigationBar = Int32.Parse(eReaderAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);

            return ((WidthOfNavigationBar / 2) == (xcoordinate) + (width / 2)) ? true : false;
        }
        /// <summary>
        /// Verify google eyes close 
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyGoogleEyeClose(AutomationAgent eReaderAutomationAgent)
        {
            if (eReaderAutomationAgent.IsElementFound("eReaderView", "GooglyEyesClose"))
            {
                return eReaderAutomationAgent.IsElementFound("eReaderView", "GooglyEyesClose");
            }

            else
            {
                eReaderAutomationAgent.ClickOnScreen(1600, 100);
                return eReaderAutomationAgent.IsElementFound("eReaderView", "GooglyEyesClose");

            }
        }
        /// <summary>
        /// Click on the google eye button
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickonGoogleEyeButton(AutomationAgent eReaderAutomationAgent)
        {
            if (eReaderAutomationAgent.IsElementFound("eReaderView", "GoogleEyeButton"))
            {
                eReaderAutomationAgent.Click("eReaderView", "GoogleEyeButton");
            }
            else
            {
                eReaderAutomationAgent.ClickOnScreen(1600, 100);
                eReaderAutomationAgent.Click("eReaderView", "GoogleEyeButton");
            }

        }

        /// <summary>
        /// Verify that apart from selected area with scaling options, none of the elements under masked area should be functional
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAreaOtherThanCroppingAreaIsDisabled(AutomationAgent eReaderAutomationAgent)
        {
            string enableProperty = eReaderAutomationAgent.GetAllValues("NotebookView", "CroppingArea", "enabled")[0];
            if (enableProperty.Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Get position of ereader snapshot
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: position of snapshot</returns>
        public static string[] GetPositionOfEreaderSnapshot(AutomationAgent eReaderAutomationAgent)
        {
            string[] pos = eReaderAutomationAgent.GetPosition("NotebookView", "NotebookImage").Split(',');
            return pos;
        }
        /// <summary>
        /// Verify snapshot bot in the notebook tools
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static bool VerifySnapShotNotInNotebookTools(AutomationAgent eReaderAutomationAgent)
        {
            return (!eReaderAutomationAgent.IsElementFound("NotebookView", "SnapshotTool"));
        }

        /// <summary>
        /// verify send to notebook button 
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if button display</returns>
        public static bool VerifySendToNotebookButton(AutomationAgent eReaderAutomationAgent)
        {
            return eReaderAutomationAgent.IsElementFound("eReaderView", "SendNotebookIcon");
        }

        /// <summary>
        /// Verify send to notebook in annotation mode
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void VerifySendToNotebookButtonInAnnotationMode(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.VerifyElementFound("eReaderView", "SendToNotebookButtonInAnnotationMode");
        }


        /// <summary>
        /// Verify available canvas tools for ereader
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyEreaderCanvasTools(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("NotebookView", "CanvasTools", "1");
            MediaLibraryAutomationAgent.VerifyElementFound("NotebookView", "CanvasTools", "2");
            MediaLibraryAutomationAgent.VerifyElementFound("NotebookView", "CanvasTools", "3");
            MediaLibraryAutomationAgent.VerifyElementFound("NotebookView", "CanvasTools", "4");
            MediaLibraryAutomationAgent.VerifyElementFound("NotebookView", "CanvasTools", "5");
            MediaLibraryAutomationAgent.VerifyElementFound("NotebookView", "CanvasTools", "6");

        }

        /// <summary>
        /// Click on marker from notebook browser
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMarker(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("BookBuilderView", "Marker");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent"></param>
        /// <param name="currentPageCount"></param>
        public static void VerifyGivenPageNumber(AutomationAgent MediaLibraryAutomationAgent, int currentPageCount)
        {
            if (MediaLibraryAutomationAgent.IsElementFound("eReaderView", "GoBackButton"))
                NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
            int pageNumber = Int32.Parse(MediaLibraryAutomationAgent.GetElementText("eReaderView", "PageNumLabel"));
            Assert.IsTrue(pageNumber.Equals(currentPageCount), "Fail if page numbers does not match");
        }
        public static bool VerifyGlobalNavIconsDisabled(AutomationAgent eReaderAutomationAgent)
        {
            string topproperty = eReaderAutomationAgent.GetAllValues("UnitSelection", "MediaLibraryNavIcon", "top")[0];
            if (topproperty.Equals("false"))
                return true;
            else
                return false;
        }
        public static void ClickOnBackIconInNoteBookReview(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.WaitForElement("TeacherSupport", "BackIcon", WaitTime.DefaultWaitTime);
            eReaderAutomationAgent.Click("TeacherSupport", "BackIcon");
        }
        
    }
}
