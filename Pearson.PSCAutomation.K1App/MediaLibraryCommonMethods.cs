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

    public class MediaLibraryCommonMethods
    {
        /// <summary>
        /// Click to open song 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenSong(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibrarySong") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibrarySong");
        }
        /// <summary>
        /// Verify that song is open in the IOS player
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyOpenSong(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaPlayerSlider");
        }
        /// <summary>
        /// Click to open video
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent"></param>
        public static void ClickToOpenVideos(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryVideo") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryVideo");
            MediaLibraryAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verify that video is open in native Ios player
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static bool VerifyOpenVideoSong(AutomationAgent MediaLibraryAutomationAgent)
        {
            return MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaPlayerSlider");
        }
        /// <summary>
        /// Click to Open Inetractive
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenInteractive(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryInteractive") && tCount <= 50)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down,850);
                tCount++;
            }
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryInteractive",1);
        }

        /// <summary>
        /// verify that interactive is open
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyInteractiveOpen(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Sleep();
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "InteractiveTitle");
        }

        /// <summary>
        /// Get Coordinate of interactive which need to open
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>coordinates of selected interactive </returns>
        public static string GetCoordinateOfInteractive(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryInteractive") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            string Coordinates = MediaLibraryAutomationAgent.GetPosition("MediaLibrary", "MediaLibraryInteractive");
            return Coordinates;
        }
        /// <summary>
        /// Get Coordinate of video which need to open
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>coordinates of selected video </returns>
        public static string GetCoordinateOfVideo(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryVideo") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            string Coordinates = MediaLibraryAutomationAgent.GetPosition("MediaLibrary", "MediaLibraryVideo");
            return Coordinates;
        }
        /// <summary>
        /// Click to open Image in Image Viewer
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenBookFromMediaLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryBook") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryBook");
        }

        public static bool VerifyImageOpenInFullScreen(AutomationAgent MediaLibraryAutomationAgent)
        {
            return (!EreaderCommonMethod.VerifyEreaderFooterView(MediaLibraryAutomationAgent) && !EreaderCommonMethod.VerifyEreaderHeaderView(MediaLibraryAutomationAgent));
        }
        /// <summary>
        /// Verify that back button exists in Image Viewer
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyBackButtonInImageViewer(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.ClickOnScreen(400, 400, 1);
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "BackButtonAtImageViewer");
        }
        /// <summary>
        /// verify that user is on media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUserOnMedialLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            string[] hiddenProperty = MediaLibraryAutomationAgent.GetAllValues("NotebookView", "MediaLibraryNavIconPressedState", "hidden");
            if (hiddenProperty[0].Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Get Coordinate of image which need to open
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>coordinates of selected image</returns>
        public static string GetCoordinateOfImage(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryBook") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            string Coordinates = MediaLibraryAutomationAgent.GetPosition("MediaLibrary", "MediaLibraryBook");
            MediaLibraryAutomationAgent.Sleep();
            return Coordinates;

        }
        /// <summary>
        /// Clicks on back Icon At Image Viewer 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBackIconAtImageViewer(AutomationAgent MediaLibraryAutomationAgent)
        {
            if (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "BackButtonAtImageViewer"))
            {
                NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 100);
            }
            MediaLibraryAutomationAgent.Click("MediaLibrary", "BackButtonAtImageViewer");
        }

        /// <summary>
        /// Verify Media Library Assets Categorization
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyLibraryAssetsCategorization(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryBook");
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryPoem");
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibrarySong");
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryInteractive");
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryFlashCard");
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryVideo");

        }

        /// <summary>
        /// Verify category icon should also appear in the first row of the category.
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyLibraryAssestsDisplayInFirstRow(AutomationAgent MediaLibraryAutomationAgent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verify There should be no duplicate books displayed in the media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no duplicate book displayed</returns>
        public static bool VerifyNoDuplicateBookDisplayed(AutomationAgent MediaLibraryAutomationAgent)
        {
            int bookCount = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "MediaLibraryBook");
            List<string> getBooksName = new List<string>();
            for (int i = 0; i <= bookCount; i += 2)
            {
                getBooksName.Add(MediaLibraryAutomationAgent.GetTextIn("MediaLibrary", "MediaLibraryBook", "Inside", "", "TEXT", i, 0, 0));
            }
            SortedSet<string> noDuplicateBooks = new SortedSet<string>(getBooksName);

            return getBooksName.Equals(noDuplicateBooks);

        }

        /// <summary>
        /// Verify There should be no duplicate books displayed in the media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no duplicate poem displayed</returns>
        public static bool VerifyNoDuplicatePoemDisplayed(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryPoem") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            int poemCount = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "MediaLibraryPoem");

            List<string> getPoemsName = new List<string>();
            for (int i = 0; i <= poemCount; i += 2)
            {
                getPoemsName.Add(MediaLibraryAutomationAgent.GetTextIn("MediaLibrary", "MediaLibraryPoem", "Inside", "", "TEXT", i, 0, 0));
            }
            SortedSet<string> noDuplicatePoem = new SortedSet<string>(getPoemsName);

            return getPoemsName.Equals(noDuplicatePoem);

        }

        /// <summary>
        /// Verify There should be no duplicate books displayed in the media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no duplicate song displayed</returns>
        public static bool VerifyNoDuplicateSongDisplayed(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibrarySong") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            int songsCount = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "MediaLibrarySong");

            List<string> getSongsName = new List<string>();
            for (int i = 0; i <= songsCount; i += 2)
            {
                getSongsName.Add(MediaLibraryAutomationAgent.GetTextIn("MediaLibrary", "MediaLibrarySong", "Inside", "", "TEXT", i, 0, 0));
            }
            SortedSet<string> noDuplicateSong = new SortedSet<string>(getSongsName);

            return getSongsName.Equals(noDuplicateSong);
        }

        /// <summary>
        /// Verify There should be no duplicate books displayed in the media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no duplicate interactive displayed</returns>
        public static bool VerifyNoDuplicateInteractiveDisplayed(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryInteractive") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            int interactiveCount = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "MediaLibraryInteractive");

            List<string> getInteractivesName = new List<string>();
            for (int i = 0; i <= interactiveCount; i += 2)
            {
                getInteractivesName.Add(MediaLibraryAutomationAgent.GetTextIn("MediaLibrary", "MediaLibraryInteractive", "Inside", "", "TEXT", i, 0, 0));
            }
            SortedSet<string> noDuplicateInteractive = new SortedSet<string>(getInteractivesName);

            return getInteractivesName.Equals(noDuplicateInteractive);
        }

        /// <summary>
        /// Verify There should be no duplicate books displayed in the media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>\]
        /// <returns>true: if no duplicate flash card displayed</returns>
        public static bool VerifyNoDuplicateFlashcardDisplayed(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryFlashCard") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            int flashcardCount = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "MediaLibraryFlashCard");

            List<string> getFlashcardName = new List<string>();
            for (int i = 0; i <= flashcardCount; i += 2)
            {
                getFlashcardName.Add(MediaLibraryAutomationAgent.GetTextIn("MediaLibrary", "MediaLibraryFlashCard", "Inside", "", "TEXT", i, 0, 0));
            }
            SortedSet<string> noDuplicateFlashCard = new SortedSet<string>(getFlashcardName);

            return getFlashcardName.Equals(noDuplicateFlashCard);
        }

        /// <summary>
        /// Verify There should be no duplicate books displayed in the media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// /// <returns>true: if no duplicate video displayed</returns>
        public static bool VerifyNoDuplicateVideoDisplayed(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryVideo") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            int videoCount = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "MediaLibraryVideo");

            List<string> getVideosName = new List<string>();
            for (int i = 0; i <= videoCount; i += 2)
            {
                getVideosName.Add(MediaLibraryAutomationAgent.GetTextIn("MediaLibrary", "MediaLibraryVideo", "Inside", "", "TEXT", i, 0, 0));
            }
            SortedSet<string> noDuplicateVideo = new SortedSet<string>(getVideosName);

            return getVideosName.Equals(noDuplicateVideo);
        }

        /// <summary>
        ///  Get current displayed Unit Number 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>int: unit number</returns>
        public static int GetCurrentUnitNumber(AutomationAgent MediaLibraryAutomationAgent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Click on next icon to go to display libraries of next unit
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNextUnitIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "NextArrowIcon");
        }

        /// <summary>
        /// Click on prev icon to go to display libraries of prebious unit
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPreviousUnitIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "PreviousArrowIcon");
        }
        /// <summary>
        /// Drag media library items to backpack.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void DragItemToBackPack(AutomationAgent CAadoptionAutomationAgent)
        {

        }

        /// <summary>
        /// Drag mEdia library as per given offset
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        /// <param name="p1">xOffset</param>
        /// <param name="p2">yOffset</param>
        public static void DragMediaLibraryScreenToBottom(AutomationAgent eReaderAutomationAgent)
        {
            int tCount = 0;
            while (!eReaderAutomationAgent.IsElementFound("BookBuilderView", "GlossaryTitle") && tCount <= 20)
            {
                eReaderAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            eReaderAutomationAgent.VerifyElementFound("BookBuilderView", "GlossaryTitle");
        }

        /// <summary>
        /// Click to open glossary from media library screen
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenGlossaryFromLibrary(AutomationAgent eReaderAutomationAgent)
        {
            eReaderAutomationAgent.Click("BookBuilderView", "GlossaryTitle");
        }

        /// <summary>
        /// Verify lesson standards in media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static bool VerifyLessonStandardsNOTInMediaLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "LessonStandards") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            return (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "LessonStandards"));


        }

        /// <summary>
        /// Click to open rubric from media library screen
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenRubricFromLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryItem", "11");
        }

        /// <summary>
        /// Click to open standard chart from media library screen
        /// </summary>
        /// <param name="eReaderAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenStandardChartFromLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryItem", "19");
        }

        /// <summary>
        /// Verify standard chart title
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyStandardChartTitle(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "StandardChartHeader");
        }

        /// <summary>
        /// Verify standard chart scroll view
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyStandardChartScrollView(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "StandardScrollView", "", "WEB");
        }

        /// <summary>
        /// Click to open table of content from libarary
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenTOCFromLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryItem", "13");
        }

        /// <summary>
        /// Click to open handwriting activity from media library
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenHandwritingActivity(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryItem", "0");
        }

        /// <summary>
        /// Verify updated image for handwriting activity
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyUpdatedHandwritingImage(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "HandwritingActivityImage");
        }

        /// <summary>
        /// Verify Order of display on the bottom shelf should be as follows when Hand writing Tile is configured: 1.Hand writing Tile 2.Table of Contents Tiles 3.Standards Chart
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyOrderOfMediaLibraryBottomShelf(AutomationAgent MediaLibraryAutomationAgent)
        {
            int xOfHandwriring = Int32.Parse(MediaLibraryAutomationAgent.GetElementProperty("MediaLibrary", "MediaLibraryItem", "x", "0"));
            int xOfTOC = Int32.Parse(MediaLibraryAutomationAgent.GetElementProperty("MediaLibrary", "MediaLibraryItem", "x", "13"));
            int xOfStandardChart = Int32.Parse(MediaLibraryAutomationAgent.GetElementProperty("MediaLibrary", "MediaLibraryItem", "x", "19"));

            Assert.IsTrue(xOfHandwriring < xOfTOC && xOfTOC < xOfStandardChart, "Fail when bottom shelf items of media library is not in order");
        }

        /// <summary>
        /// Verify table of content title 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyTableOfContentTitle(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "TableOfContentTitle");
        }

        /// <summary>
        /// Verify Rubric Title
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyRubricTitle(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "RubricHeader");
        }

        /// <summary>
        /// verify No internet connection message when tap on hadnwriting activity in offline mode
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if message matched</returns>
        public static bool VerifyOfflineMessageForHandwriting(AutomationAgent UnitSelectionAutomationAgent)
        {
            string TextonScreen = UnitSelectionAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("No internet connection. You must be connected to the Internet to access Handwriting Resources.");
        }

        /// <summary>
        /// Verify camera icon should not display in media library 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyNoCameraIconsInMediaLibrary(AutomationAgent UnitSelectionAutomationAgent)
        {
            int tCount = 0;
            while (!UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CameraIconInTodayShelf") && tCount <= 10)
            {
                UnitSelectionAutomationAgent.Swipe(Direction.Down);
                if (UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CameraIconInTodayShelf"))
                    return false;
                tCount++;
            }

            return true;
        }

        /// <summary>
        /// verify audio icon should not display in media library 
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyNoAudioIconsInMediaLibrary(AutomationAgent UnitSelectionAutomationAgent)
        {
            int tCount = 0;
            while (!UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CameraIconInTodayShelf") && tCount <= 10)
            {
                UnitSelectionAutomationAgent.Swipe(Direction.Down);
                if (UnitSelectionAutomationAgent.IsElementFound("UnitSelection", "CameraIconInTodayShelf"))
                    return false;
                tCount++;
            }

            return true;
        }

        /// <summary>
        /// Drag the media screen down untill Graphic Organizer Icon not displayed
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void DragMediaLibraryScreenTillGraphicOrganizers(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "GraphiOrganizersIcon") && tCount <= 20)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
                MediaLibraryAutomationAgent.Sleep(250);
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "GraphiOrganizersIcon");

            //MediaLibraryAutomationAgent.SwipeWhileNotFound("MediaLibrary", "GraphiOrganizersIcon", "Down", 800, 750, 500, 20, false);
        }

        /// <summary>
        /// Get coordinates of Graphic Organizer category icon from left corner of shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>Coordinates</returns>
        public static string[] GetCoordinateOfGraphicOrganizers(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "GraphiOrganizersIcon") && tCount <= 20)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            string[] Coordinates = MediaLibraryAutomationAgent.GetPosition("MediaLibrary", "GraphiOrganizersIcon").Split(',');
            return Coordinates;
        }

        /// <summary>
        /// Get coordinates of Graphic Organizer category icon from left corner of shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>Coordinates</returns>
        public static string[] GetCoordinateOfRubrics(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "Rubric") && tCount <= 20)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            string[] Coordinates = MediaLibraryAutomationAgent.GetPosition("MediaLibrary", "Rubric").Split(',');
            return Coordinates;
        }

        /// <summary>
        /// Get coordinates of Graphic Organizer category icon from left corner of shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns>Coordinates</returns>
        public static string[] GetCoordinateOfGlossary(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "GlossaryIcon") && tCount <= 20)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            string[] Coordinates = MediaLibraryAutomationAgent.GetPosition("MediaLibrary", "GlossaryIcon").Split(',');
            return Coordinates;
        }

        /// <summary>
        /// Verify default state when glossay is opened (alphabetical drop down should be A-z)
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyGlossaryDefaultStatus(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "AlphabetsDropDownAtGlossary");
        }

        /// <summary>
        /// Click on alphabetical drop down of glossary
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object<</param>
        public static void ClickOnAlphabeticalDropDownOfGlossary(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "AlphabetsDropDownAtGlossary");
        }

        /// <summary>
        /// Click to open graphic organizer
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenGraphicOrganizerFromMediaLibrary(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("MediaLibrary", "MediaLibraryGraphicOrganizer", "14");
        }

        /// <summary>
        /// Verify Blending Practice Image at Graphic Organizer
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyBlendingPracticeImage(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "GraphicOrganizerImage");
        }

        /// <summary>
        /// Verify glossary title 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyGlossaryTitle(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "GlossaryTitle");
        }

        /// <summary>
        /// Verify graphic organizer title 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyGraphicOrganizerTitle(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "GraphicOrganizerTitle");
        }

        /// <summary>
        /// Verify Book categpry icon display in First shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyBookCategoryIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "BookCategoryIcon") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "BookCategoryIcon");
        }

        /// <summary>
        /// Verify Book categpry icon display in First shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyPoemCategoryIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "PoemCategoryIcon") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "PoemCategoryIcon");
        }

        /// <summary>
        /// Verify Book categpry icon display in First shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifySongCategoryIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "SongCategoryIcon") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "SongCategoryIcon");
        }

        /// <summary>
        /// Verify Book categpry icon display in First shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyIntercativeCategoryIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "InteractiveCategoryIcon") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "InteractiveCategoryIcon");
        }

        /// <summary>
        /// Verify Book categpry icon display in First shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyFlashcardCategoryIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "FlashcardCategoryIcon") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "FlashcardCategoryIcon");
        }

        /// <summary>
        /// Verify Book categpry icon display in First shelf
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyVideoCategoryIcon(AutomationAgent MediaLibraryAutomationAgent)
        {
            int tCount = 0;
            while (!MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "VideoCategoryIcon") && tCount <= 10)
            {
                MediaLibraryAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "VideoCategoryIcon");
        }

        /// <summary>
        /// Verify unit title image at media library screen
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitTitleImage(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "MedialibraryUnitTitle");
        }

        /// <summary>
        /// Verify next unit icon at media library screen 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyNextUniticon(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "NextArrowIcon");
        }

        /// <summary>
        /// Verify prev icon at media library screen
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyPreviousUniticon(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.VerifyElementFound("MediaLibrary", "PreviousArrowIcon");
        }

        /// <summary>
        /// Drag Media library screen till interactive shelf
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragMediaLibraryScreenTillIntercative(AutomationAgent notebookAutomationAgent)
        {
            int tCount = 0;
            while (!notebookAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryInteractive") && tCount <= 20)
            {
                notebookAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            notebookAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryInteractive");
        }

        /// <summary>
        /// Drag Media library screen till Video shelf
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragMediaLibraryScreenTillVideo(AutomationAgent notebookAutomationAgent)
        {
            int tCount = 0;
            while (!notebookAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryVideo") && tCount <= 20)
            {
                notebookAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }

            notebookAutomationAgent.VerifyElementFound("MediaLibrary", "MediaLibraryVideo");
        }

        /// <summary>
        /// Verify there is no duplucate category availables
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoDuplicateCategory(AutomationAgent MediaLibraryAutomationAgent)
        {
            int bookCategory = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "BookCategoryIcon");
            int poemCategory = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "PoemCategoryIcon");
            int songCategory = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "SongCategoryIcon");
            int interactiveCategory = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "InteractiveCategoryIcon");
            int flashcardCategory = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "FlashcardCategoryIcon");
            int videoCategory = MediaLibraryAutomationAgent.GetElementCount("MediaLibrary", "VideoCategoryIcon");

            Assert.IsTrue(bookCategory.Equals(1) && poemCategory.Equals(bookCategory) && songCategory.Equals(poemCategory) && interactiveCategory.Equals(songCategory) && songCategory.Equals(flashcardCategory) && flashcardCategory.Equals(videoCategory));
        }

        /// <summary>
        /// Verify arrow is hidden when one unit is downloaded
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <param name="downloadedUnit">int: downloaded unit count</param>
        public static bool VerifyHiddenArrowForOneDownloadedUnit(AutomationAgent MediaLibraryAutomationAgent, int downloadedUnit)
        {
            if (downloadedUnit.Equals(1))
                return (MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "NextArrowIcon") && MediaLibraryAutomationAgent.IsElementFound("MediaLibrary", "PreviousArrowIcon"));
            else
                return false;
        }

    }
}
