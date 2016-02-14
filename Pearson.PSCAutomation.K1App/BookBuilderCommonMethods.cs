using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    public class BookBuilderCommonMethods
    {
        /// <summary>
        /// Verify the Book Builder landing page when user first login
        /// 1. Verify Back button
        /// 2. Verify Book Builder title
        /// 3. Verify Help Text
        /// 4. Verify New Book Icon
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void VerifyBookBuilderLandingPage(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("StudentSetup", "BackButton");
            bookBuilderAutomatinAgent.GetTextIn("BookBuilderView", "BookBuilderTitle", "Inside", " ").Equals("BOOK BUILDER");
            bookBuilderAutomatinAgent.GetTextIn("BookBuilderView", "HelpText", "Inside", " ").Equals("Let's make a book!");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "NewBookIcon");
        }

        /// <summary>
        /// Create Portrait book from book builder screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookName">string object: passing the name of book</param>
        /// <param name="authorName">string object: passing the name of author name</param>
        public static void CreateBook(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName)
        {
            bookBuilderAutomatinAgent.SetText("BookBuilderView", "BookNameField", bookName);
            //bookBuilderAutomatinAgent.SendText("{BKSP}");
            //bookBuilderAutomatinAgent.SendText(bookName);
            bookBuilderAutomatinAgent.SetText("BookBuilderView", "AuthorNameField", authorName);
            //bookBuilderAutomatinAgent.SendText("{BKSP}");
            //bookBuilderAutomatinAgent.SendText(authorName);
            //bookBuilderAutomatinAgent.Click("BookBuilderView", "AddPage");
        }

        /// <summary>
        /// Verify new Book has been created when we copme back
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookName">string object: passing the name of book</param>
        /// <param name="authorName">string object: passing the name of author name</param>
        public static void VerifyCreatedBook(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("UnitSelectionView", "SystemTray"))
            {
                NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
            }
            bookBuilderAutomatinAgent.WaitforElement("StudentSetup", "BackButton", "", WaitTime.DefaultWaitTime);
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookName", bookName);
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "AuthorName", authorName);
        }

        /// <summary>
        /// Click on New Book Icon
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnNewBookIcon(AutomationAgent bookBuilderAutomatinAgent)
        {
           ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
        }

        /// <summary>
        /// Click on New Portrait Book Icon
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnNewPortraitBookIcon(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "NewPortraitBookIcon");
        }

        /// <summary>
        /// Click on New Landscape Book Icon
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnNewLandscapeBookIcon(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "NewLandscapeBookIcon");
        }

        /// <summary>
        /// Click on New Square Book Icon
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent"></param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnNewSquareBookIcon(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "SquareBook");
        }


        /// <summary>
        /// Clicks on the new book button to add new book in book builder page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickOnNewBookIconOnLeftCorner(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "NewBookButton"))
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "NewBookButton");

            }
            else
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "NewBookIcon");
            }
        }

        /// <summary>
        /// Clicks on the lansdcape type of book when new book is added 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ChooseLandscapeBookShape(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "LandscapeBook");
        }
        /// <summary>
        /// Click On the portrait book from the pop up which comes after clicking on the new book button on the bottom left corner in book builder page.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ChoosePortraitBookShape(AutomationAgent bookBuilderAutomatinAgent)
        {
            if(bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "NewPortraitBookIcon")) {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "NewPortraitBookIcon");
            }
            else
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "PortraitBook");
            }
        }

        /// <summary>
        /// Click On the Square book from the pop up which comes after clicking on the new book button on the bottom left corner in book builder page.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ChooseSquareBookShape(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "SquareBook");
        }

        /// <summary>
        /// gets the position of the book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookName">string: passing unique name in book name</param>
        /// <returns>string: current book x axis</returns>
        public static string GetCurrentBookPosition(AutomationAgent bookBuilderAutomatinAgent, string bookName)
        {

            string[] currentBookCoordinate = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "BookName", bookName).Split(',');
            string currentBookxaxis = currentBookCoordinate[0];
            return currentBookxaxis;
        }
        /// <summary>
        /// Clicks on the edit button to edit book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnBookEditButton(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "EditBookButton"))
            {
                BookBuilderCommonMethods.ClickOnNewBookIcon(bookBuilderAutomatinAgent);
                BookBuilderCommonMethods.ClickOnNewPortraitBookIcon(bookBuilderAutomatinAgent);
                BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, "TestBookName", "TestAuthorName");
                NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
            }
            bookBuilderAutomatinAgent.Click("BookBuilderView", "EditBookButton");
            bookBuilderAutomatinAgent.WaitforElement("BookBuilderView", "AddPage", "", WaitTime.DefaultWaitTime);
        }
        /// <summary>
        /// Verifies that user is on the book browser screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyBookBrowserScreen(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "EditBookButton");
        }
        /// <summary>
        /// clicks on the cover page of the book in page carousel view.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnCoverPage(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "CoverPageBeforeEdit"))
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "CoverPageBeforeEdit");
            }
            else
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "CoverPageAfterEdit");
            }

        }
        /// <summary>
        /// verify the default title name and author name when cover page is open in edit mode
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookName">string object: passing the name of book</param>
        /// <param name="authorName">string object: passing the name of author</param>
        public static void VerifyCoverPageTitlesInEditMode(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookName", bookName);
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "AuthorName", authorName);
        }
        /// <summary>
        /// verify the default title name and author name on the  cover page in book browser view
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookName">string object: passing the name of book</param>
        /// <param name="authorName">string object: passing the name of author</param>
        public static void VerifyCoverPageTitlesAtBookBrowser(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookName", bookName);
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "AuthorName", authorName);
        }
        /// <summary>
        /// Verify the default title name and author name on the  cover page in page carousel view
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="p1">string object: passing the name of book</param>
        /// <param name="p2">string object: passing the name of author</param>
        public static void VerifyCoverPageTitlesAtPageBrowser(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookNameAtCoverPage", bookName);
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "AuthorName", authorName);
        }

        /// <summary>
        /// Verify that the auto correct property is disable when you type in author name and title field
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookName">string object: passing the name of book</param>
        /// <param name="authorName">string object: passing the name of author</param>
        /// <returns></returns>
        public static bool VerifyAutoCorrectDisable(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BookName", bookName) && bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "AuthorName", authorName))
            {
                return true;
            }
            else
                return false;

        }
        /// <summary>
        /// verify the blank titles on the cover page at page browser screen when new book is added 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyBlankCoverPagetitlesAtPageBrowser(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BlankCoverTitle");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BlankAuthorTitle");
        }

        /// <summary>
        /// Get the Book Name of already created book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>return: book name of previous book</returns>
        public static string GetNameOfBook(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.GetTextIn("BookBuilderView", "BookNameField", "Inside", "").Replace("\t\n", "");
        }

        /// <summary>
        /// Get the Author name of already created book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>return: author name of previous book</returns>
        public static string GetNameOfAuthor(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.GetTextIn("BookBuilderView", "AuthorNameField", "Inside", "").Replace("\t\n", "");
        }

        /// <summary>
        /// Verify that when user long click on the page then the +button disappears
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyHighlightedPage(AutomationAgent bookBuilderAutomatinAgent)
        {

            //bookBuilderAutomatinAgent.Click("BookBuilderView", "AddPage");
            //bookBuilderAutomatinAgent.LongClick("BookBuilderView", "BookPage", "2");
            //return (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "AddPage"));

            bookBuilderAutomatinAgent.Click("BookBuilderView", "AddPage");
            bookBuilderAutomatinAgent.LongClick("BookBuilderView", "BookPage", "2");            
            string parentHidden = bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "AddPage", "parentHidden")[0];
            return parentHidden.Equals("true");
        }
        /// <summary>
        /// Verify that Cover Page didnt get highlighted after long clicking on it
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyHighlightedCoverPage(AutomationAgent bookBuilderAutomatinAgent)
        {

            bookBuilderAutomatinAgent.LongClick("BookBuilderView", "CoverPageAfterEdit");
            return (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "AddPage"));
        }
        /// <summary>
        /// Verify white line between the author name and the title name.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyWhiteLine(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "");
        }
        /// <summary>
        /// Verify Tile blue color when cover page opens in edit mode
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyTileBlueColor(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BlueTile");
        }
        /// <summary>
        /// click on the add page button in the page browser view
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="pagetoadd">int object: passing the no. of pages to add</param>
        public static void ClickToAddPages(AutomationAgent bookBuilderAutomatinAgent, int pagetoadd)
        {
            for (int i = 1; i < pagetoadd; i++)
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "AddPage");
                bookBuilderAutomatinAgent.Sleep();
            }

        }

        /// <summary>
        /// verify the visibility of add page button in the page browser screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>true: if "+" button found</returns>
        public static bool VerifyAddPageButtonExist(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "AddPage");
        }

        /// <summary>
        /// swipe the page browser view to get the add button
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void SwipeToGetAddButton(AutomationAgent bookBuilderAutomatinAgent)
        {
            while (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "AddPage"))
            {
                bookBuilderAutomatinAgent.Swipe(Direction.Right);
            }

            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "AddPage");
        }
        /// <summary>
        ///  Verify Newly added pages positions with respect to "+" button
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>true: if all added pages are on left side of "+" button</returns>
        public static bool VerifyNewlyAddedPagesPositions(AutomationAgent bookBuilderAutomatinAgent)
        {
            string[] page2Coordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "BookPageCount", "2").Split(',');
            int page2XCoordinates = Int32.Parse(page2Coordinates[0]);
            string[] page3Coordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "BookPageCount", "3").Split(',');
            int page3XCoordinates = Int32.Parse(page3Coordinates[0]);
            string[] page4Coordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "BookPageCount", "4").Split(',');
            int page4XCoordinates = Int32.Parse(page4Coordinates[0]);
            string[] addButtonCoordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "AddPage").Split(',');
            int addButtonXCoordinates = Int32.Parse(addButtonCoordinates[0]);
            if (page2XCoordinates < page3XCoordinates && page3XCoordinates < page4XCoordinates && page4XCoordinates < addButtonXCoordinates)
                return true;
            else
                return false;
        }

        /// <summary>
        /// use to write text
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="value">string object:name to be written</param>
        public static void SendText(AutomationAgent bookBuilderAutomatinAgent, string value)
        {
            bookBuilderAutomatinAgent.SendText(value);
        }
        /// <summary>
        /// verify the cover page after editing in the edit mode in the page browser screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyEditedCoverPageInPageBrowser(AutomationAgent bookBuilderAutomatinAgent, string bookName, string authorName, string text)
        {
            BookBuilderCommonMethods.VerifyCoverPageTitlesInEditMode(bookBuilderAutomatinAgent, bookName, authorName);
            string CoverpageText = bookBuilderAutomatinAgent.GetText("TEXT");
            return CoverpageText.Contains(text);

        }
        /// <summary>
        /// Verify the saved page in the page browser screen after clicking on the back button in page edit screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifySavedPage(AutomationAgent bookBuilderAutomatinAgent, string text)
        {
            string CoverpageText = bookBuilderAutomatinAgent.GetText("TEXT");
            return CoverpageText.Contains(text);
        }

        /// <summary>
        /// Get the any page postion
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="pageCount">passed the page count</param>
        /// <returns>int: added page position</returns>
        public static int GetAddedPagePosition(AutomationAgent bookBuilderAutomatinAgent, int pageCount)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BookPageCount", pageCount.ToString()))
            {
                string[] pageCoordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "BookPageCount", pageCount.ToString()).Split(',');
                int pageXCoordinates = Int32.Parse(pageCoordinates[0]);
                return pageXCoordinates;
            }
            else
            {
                return -1;
            }
            
        }
        /// <summary>
        /// verify the following
        /// a) The page browser scroll position should be reset. 
        /// b) In the page browser, Cover page and first page should be left aligned
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyPageBrowserScrollPositionReset(AutomationAgent bookBuilderAutomatinAgent, int pagePosition)
        {
            bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BookPageCount", pagePosition.ToString());
            string[] page1Coordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "BookPageCount", "1").Split(',');
            int page1XCoordinates = Int32.Parse(page1Coordinates[0]);
            string[] coverPageCoordinates = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "CoverPageAfterEdit").Split(',');
            int coverPageXCoordinates = Int32.Parse(coverPageCoordinates[0]);
            if (coverPageXCoordinates < page1XCoordinates)
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify that the blue tile is not editable
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyBlueTileIsNotEditable(AutomationAgent bookBuilderAutomatinAgent)
        {
            NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
            bookBuilderAutomatinAgent.ClickOnScreen(524, 188);
            return NotebookCommonMethods.VerifyTextBoxRegionFound(bookBuilderAutomatinAgent);

        }


        /// <summary>
        /// opens the page of the newly added book
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen (aalmeen.khan)</author>
        public static void ClickToEditBookPage(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "BookPage", "1");
        }

        /// <summary>
        /// Verify the below items:
        /// 1.Camera
        /// 2.Backgrounds 
        /// 3.Table of Contents
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyLeftSideToolsOfCanvas(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "CameraIcon");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BackgroundPaper");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "TableTool");
        }

        /// <summary>
        /// Verify the below items:
        /// 1.Crayon, 
        /// 2.marker, 
        /// 3.brush, 
        /// 4.text area, 
        /// 5.stamp,
        /// 6.color picker,
        /// 7.eraser, 
        /// 8. hand tool
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyRightSideToolsOfCanvas(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "Crayon");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "Marker");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "Brush");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "TextArea");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "Stamp");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "ColorPicker");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "Eraser");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "HandTool");
        }


        /// <summary>
        /// verify the visibility of add page button in the page browser screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void SwipeToGetFirstPage(AutomationAgent bookBuilderAutomatinAgent)
        {
            while (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BookPage", "1"))
            {
                bookBuilderAutomatinAgent.Swipe(Direction.Left);
            }

            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookPage", "1");
        }
        /// <summary>
        /// Verify the chosse shape pop up open
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyChooseShapePopUpOpen(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Sleep();
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "ChooseShapePopup");
        }
        /// <summary>
        /// Drag element to trash in book builder
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void DragElementToTrashInBookBuilder(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "PageToDelete"))
            {
                int xCoordinateOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "x"))[0]);
                int yCoordinateOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "y"))[0]);
                int widthOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "width"))[0]);
                int heightOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "height"))[0]);

                int xCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanPageBookBuilder", "x"))[0]);
                int yCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanPageBookBuilder", "y"))[0]);
                int widthOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanPageBookBuilder", "width"))[0]);
                int heightOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanPageBookBuilder", "height"))[0]);

                bookBuilderAutomatinAgent.SetDragStartDelay(7000);
                bookBuilderAutomatinAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfTrash + (widthOfTrash / 2), yCoordinateOfTrash + (heightOfTrash / 2), 2000);
            }
            else
            {
                BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 2);
                BookBuilderCommonMethods.DragElementToTrashInBookBuilder(bookBuilderAutomatinAgent);
            }

        }
        /// <summary>
        /// Verify page deleted
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyPageDeleted(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "PageToDelete"))
                return true;
            else
                return false;
        }
        /// <summary>
        ///  Delete the added pages in the book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void DeleteAddedPages(AutomationAgent bookBuilderAutomatinAgent)
        {
            while (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "PageToDelete"))
            {
                int xCoordinateOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "x"))[0]);
                int yCoordinateOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "y"))[0]);
                int widthOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "width"))[0]);
                int heightOfLib = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PageToDelete", "height"))[0]);

                int xCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "x"))[0]);
                int yCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "y"))[0]);
                int widthOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "width"))[0]);
                int heightOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "height"))[0]);

                bookBuilderAutomatinAgent.SetDragStartDelay(7000);
                bookBuilderAutomatinAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfTrash + (widthOfTrash / 2), yCoordinateOfTrash + (heightOfTrash / 2), 2000);
                bookBuilderAutomatinAgent.Sleep();
                if (bookBuilderAutomatinAgent.IsElementFound("UnitSelection", "AcceptLogOut"))
                {
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                }
                else
                    continue;

            }
        }
        /// <summary>
        /// Click on the Table tool
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnTableTool(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "TableButtonInBookBuilder");
        }
        /// <summary>
        /// Verify the table tool overlay 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTableToolOverlay(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "TableToolOverlayInBookBuilder");
        }
        /// <summary>
        /// Click on the table of contents table in the overlay open.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnTableOfContentsTable(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "TableOfContentsTable");
        }
        /// <summary>
        /// Verify table tool overlay contents
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyTableToolOverlayContents(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "TableOfContentsTable");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "GlossaryTable");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "IndexTable");

        }
        /// <summary>
        /// Verify user able to add another table in the notebook canvas
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUserAbleToAddTable(AutomationAgent bookBuilderAutomatinAgent)
        {
            int count = bookBuilderAutomatinAgent.GetElementCount("BookBuilderView", "TableOfContentHeading");
            if (count.Equals(2))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify share button Enable in the book builder book browser view
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyShareButtonEnable(AutomationAgent bookBuilderAutomatinAgent)
        {
            string enable = bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "ShareBookIcon", "hidden")[0];
            if (enable.Equals("true"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Long click on book in book browser view
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void LongClickOnBookInBookBuilder(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.LongClick("BookBuilderView", "BookImage");
        }
        /// <summary>
        ///  Verify trash can is visisble
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if visible</returns>
        public static bool VerifyTrashCanAppeared(AutomationAgent bookBuilderAutomatinAgent)
        {
            string[] hiddenProperty = bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "hidden");
            return hiddenProperty[0].Equals("true");
        }
        /// <summary>
        /// Click to open the book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickToOpenBook(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.WaitforElement("BookBuilderView", "Book", "", WaitTime.DefaultWaitTime);
            bookBuilderAutomatinAgent.Click("BookBuilderView", "Book");
        }
        /// <summary>
        /// Verify one page at time when the book is open.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyOnePageAtATime(AutomationAgent bookBuilderAutomatinAgent)
        {
            int count = bookBuilderAutomatinAgent.GetElementCount("BookBuilderView", "SquarePage");
            return count.Equals(1);
        }
        /// <summary>
        /// Click on the back icon when book open
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickOnBackIconWhenBookOpen(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BackHandButtonWhenBookOpen"))
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "BackHandButtonWhenBookOpen");
            }
            else
            {
                bookBuilderAutomatinAgent.ClickOnScreen(500, 550);
                bookBuilderAutomatinAgent.Click("BookBuilderView", "BackHandButtonWhenBookOpen");
            }



        }
        /// <summary>
        /// Verify header footer in book
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyHeaderFooterInBook(AutomationAgent bookBuilderAutomatinAgent)
        {
            return (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "TitleInHeader") && bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "CoverInFooter"));

        }
        /// <summary>
        /// Verify Portrait page display when portrait book open.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySquarePage(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "SquarePage");
        }
        /// <summary>
        /// Verify text cover and right arrow in the footer
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTextCoverAndRightArrow(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.WaitforElement("BookBuilderView", "CoverInFooter", "", WaitTime.DefaultWaitTime);
            return (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "CoverInFooter") && bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "PageArrowRightAtBook"));
        }
        /// <summary>
        /// Verify Items In header
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyItemsInHeader(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "TitleInHeader");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BackHandButtonWhenBookOpen");
        }

        /// <summary>
        /// Verify book builder canvas placeholder
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyBookBuilderCanvasPlaceholder(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "CanvasPlaceholder", "1");
        }

        /// <summary>
        /// Verify that Book builder has textured off-white background
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyTexturedOffBackground(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("NotebookView", "NotebookBackground");
        }

        /// <summary>
        /// Verify that user is not able to draw and add items on the blue tile
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyItemsCannnotAddOnBlueTile(AutomationAgent bookBuilderAutomatinAgent)
        {
            NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
            string[] position = NotebookCommonMethods.GetPositionOfTextBox(bookBuilderAutomatinAgent);
            NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 484, 260);
            string[] afterPosition = NotebookCommonMethods.GetPositionOfTextBox(bookBuilderAutomatinAgent);
            Assert.IsTrue(position[0].Equals(afterPosition[0]) && position[1].Equals(afterPosition[1]), "fail if text box position moved to blue tile");
            NotebookCommonMethods.ClickOnRemoveButton(bookBuilderAutomatinAgent);

        }

        /// <summary>
        /// Click inside book title box
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickInsideBookTitle(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "BookNameField");
        }

        /// <summary>
        /// Click inside book author box
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickInsideBookAuthorName(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "AuthorNameField");
        }
        /// <summary>
        /// Verified saved snapshot of cover in page browser
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="p">string object: text to verify</param>
        public static bool VerifySavedSnapshotOfCoverInPageBrowser(AutomationAgent bookBuilderAutomatinAgent, string textinpagebrowser)
        {
            string text = bookBuilderAutomatinAgent.GetText("TEXT");
            return (text.Contains(textinpagebrowser));
        }
        /// <summary>
        /// Verified saved snapshot of cover in book browser
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="p">string object: text to verify</param>
        public static bool VerifySavedSnapshotOfCoverInBookBrowser(AutomationAgent bookBuilderAutomatinAgent, string textinbookbrowser)
        {
            string text = bookBuilderAutomatinAgent.GetText("TEXT");
            return (text.Contains(textinbookbrowser));
        }
        /// <summary>
        /// Verify Title and author does not overlap
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyTitleAndAuthorDoesNotOverlap(AutomationAgent bookBuilderAutomatinAgent)
        {
            int y_title_header = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TitleInHeader", "y")[0]);
            int height_title_header = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TitleInHeader", "height")[0]);


            int y_author = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("NotebookView", "AuthorTiTle", "y")[0]);
            int height_author_header = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("NotebookView", "AuthorTiTle", "height")[0]);

            if ((y_title_header + height_title_header) < y_author)
            {
                return true;
            }
            else
                return false;
        }

        public static void VerifyAddedPageAppendInCollection(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookPage", "1");
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "BookPage", "2");
        }
        /// <summary>
        /// Delete book from book builder 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void DeleteBook(AutomationAgent bookBuilderAutomatinAgent, string bookname, string authorname)
        {
            int xCoordinateBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookName", bookname, "x"))[0]);
            int yCoordinateOfBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookName", bookname, "y"))[0]);
            int widthOfBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookName", bookname, "width"))[0]);
            int heightOfBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookName", bookname, "height"))[0]);
            
            bookBuilderAutomatinAgent.LongClick("BookBuilderView", "BookImage");

            int xCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "x"))[0]);
            int yCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "y"))[0]);
            int widthOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "width"))[0]);
            int heightOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "height"))[0]);

            bookBuilderAutomatinAgent.SetDragStartDelay(7000);
            bookBuilderAutomatinAgent.Drag(xCoordinateBook + (widthOfBook / 2), yCoordinateOfBook + (heightOfBook / 2), xCoordinateOfTrash + (widthOfTrash / 2), yCoordinateOfTrash + (heightOfTrash / 2), 2000);
        }
        /// <summary>
        /// Verify delete pop up 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyDeletePopUp(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BackPackView", "RemovePaper");
        }
        /// <summary>
        /// Verify book is deleted
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="bookname">strin object: book name</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyDeletedBook(AutomationAgent bookBuilderAutomatinAgent, string bookname)
        {
            return !bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BookName", bookname);
        }
        /// <summary>
        /// Get the page count when book is open
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>int object: count of pages</returns>
        public static int GetPageCount(AutomationAgent bookBuilderAutomatinAgent)
        {
            string[] pagecount = bookBuilderAutomatinAgent.GetTextIn("NotebookView", "PageArrowLeftAtBook", "Right", "").Split(' ');
            return Int32.Parse(pagecount[2].Replace("\t\n", ""));
        }
        /// <summary>
        /// Verify odd page number on left side of screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="page_count">ibnt object: count of pages</param>
        public static bool VerifyOddPageNumber(AutomationAgent bookBuilderAutomatinAgent, int page_count)
        {
            return (page_count % 2 == 1);

        }
        /// <summary>
        /// Verify odd page number on left side.
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyOddPageNumberOnLeftSide(AutomationAgent bookBuilderAutomatinAgent)
        {
            NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 1000);
            string[] pagecount = bookBuilderAutomatinAgent.GetTextIn("BookBuilderView", "PageArrowLeftAtBook", "Right", "").Split(' ');
            int page_pos = Int32.Parse(pagecount[0].Replace("\n", ""));
            if (page_pos % 2 == 1)
            {
                int xcoordinate = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PortraitPage", "x")[0]);
                int width = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "PortraitPage", "width")[0]);
                return ((xcoordinate + width) <= 1024);
            }
            else
                return false;
        }
        /// <summary>
        /// Verify cover page in centre
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCoverPageInCentre(AutomationAgent bookBuilderAutomatinAgent)
        {
            while (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "BackHandButtonWhenBookOpen"))
            {
                NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 1000);
            }
            int width = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "SquarePage", "width")[0]);
            int Xcoordinate = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "SquarePage", "x")[0]);

            int WidthOfNavigationBar = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);

            return ((WidthOfNavigationBar / 2) == (Xcoordinate) + (width / 2)) ? true : false;
        }
        /// <summary>
        /// Verify two pages on one screen when 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyTwoPagesOnOneScreen(AutomationAgent bookBuilderAutomatinAgent)
        {
            int count = bookBuilderAutomatinAgent.GetElementCount("BookBuilderView", "PortraitPage");
            return count.Equals(2);
        }
        /// <summary>
        /// Get the count of tables added to the book builder notebook canvas
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>int object: count of tables</returns>
        public static int GetCountOfNumberLineTableInBookBuilderCanvas(AutomationAgent bookBuilderAutomatinAgent)
        {
            int count = bookBuilderAutomatinAgent.GetElementCount("BookBuilderView", "TableOfContentHeading");
            return count;
        }
        /// <summary>
        /// Drag table of contents table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void DragTableOfCOntentsTable(AutomationAgent bookBuilderAutomatinAgent, int x, int y)
        {
            bookBuilderAutomatinAgent.DragElement("BookBuilderView", "TableOfContentHeading", 0, 1000);
        }
        /// <summary>
        /// Delete all book available
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void DeleteAllBookAvailable(AutomationAgent bookBuilderAutomatinAgent)
        {

            while (!bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "NewBookIcon"))
            {
                int xCoordinateBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookImage", "x"))[0]);
                int yCoordinateOfBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookImage", "y"))[0]);
                int widthOfBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookImage", "width"))[0]);
                int heightOfBook = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "BookImage", "height"))[0]);

                bookBuilderAutomatinAgent.LongClick("BookBuilderView", "BookImage");

                int xCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "x"))[0]);
                int yCoordinateOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "y"))[0]);
                int widthOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "width"))[0]);
                int heightOfTrash = Int32.Parse((bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TrashCanBookBuilder", "height"))[0]);

                bookBuilderAutomatinAgent.SetDragStartDelay(7000);
                bookBuilderAutomatinAgent.Drag(xCoordinateBook + (widthOfBook / 2), yCoordinateOfBook + (heightOfBook / 2), xCoordinateOfTrash + (widthOfTrash / 2), yCoordinateOfTrash + (heightOfTrash / 2), 2000);
                NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
            }


        }
        /// <summary>
        /// Verify book builder main screen
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyBookBuilderMainScreen(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "NewBookIcon");
        }
        /// <summary>
        /// Get position of table of contents table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>string object : position of table</returns>
        public static string[] GetPositionofTableOfContentsTable(AutomationAgent bookBuilderAutomatinAgent)
        {
            string[] pos = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "TableOfContentHeading").Split(',');
            return pos;
        }

        /// <summary>
        /// Click on the glossary table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void clickonGlossarytabel(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "GlossaryTable");
        }
        /// <summary>
        /// Get position of glossary table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>string object: pos of glossary table</returns>
        public static string GetPositionofGlossaryTable(AutomationAgent bookBuilderAutomatinAgent)
        {
            string pos = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "GlossaryTitle");
            return pos;
        }
        /// <summary>
        /// drag glossary table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x </param>
        /// <param name="p2">int object: y</param>
        public static void DragGlossaryTable(AutomationAgent bookBuilderAutomatinAgent, int p1, int p2)
        {
            bookBuilderAutomatinAgent.DragElement("BookBuilderView", "GlossaryTitle", p1, p2);
        }
        /// <summary>
        /// Click on index table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickonIndextable(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "IndexTable");
        }
        /// <summary>
        /// Get position of index table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>string object</returns>
        public static string GetPositionofIndexTable(AutomationAgent bookBuilderAutomatinAgent)
        {
            string pos = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "IndexTitle");
            return pos;
        }
        /// <summary>
        /// drag index table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x </param>
        /// <param name="p2">int object: y</param>
        public static void DragIndexTable(AutomationAgent bookBuilderAutomatinAgent, int p1, int p2)
        {
            bookBuilderAutomatinAgent.DragElement("BookBuilderView", "IndexTitle", p1, p2);
        }
        /// <summary>
        /// Table selected
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyTableSelected(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("NotebookView", "RemoveButton");
        }
        /// <summary>
        /// Verify table added is saved
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyTableAddedIsSaved(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "TableOfContentHeading");
        }
        /// <summary>
        /// Verify share button disabled for teacher
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyShareButtonDisabledForTeacher(AutomationAgent bookBuilderAutomatinAgent)
        {
            string enabled = bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "ShareBookIcon", "enabled")[0];
            return (enabled.Equals(true));
        }
        /// <summary>
        /// Get the hegiht of table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static int GetHeightOfTable(AutomationAgent bookBuilderAutomatinAgent)
        {
            int height = Int32.Parse(bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "TableOfContentTableView", "height")[0]);
            return height;
        }
        /// <summary>
        /// Click to get new line
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void ClickToGetNewLine(AutomationAgent bookBuilderAutomatinAgent, int p)
        {
            bookBuilderAutomatinAgent.Click("BookBuilderView", "KeyBoardNewLineKey", p);
        }
        /// <summary>
        /// Verify four rows nad two columns
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static bool VerifyFourRowsTwoCOlumns(AutomationAgent bookBuilderAutomatinAgent)
        {
            return (bookBuilderAutomatinAgent.GetElementCount("BookBuilderView", "RowsColumns") - 2).Equals(8);
        }
        /// <summary>
        /// Drag table of contents drag handle
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="p1">int object: x</param>
        /// <param name="p2">int object: y</param>
        public static void DragTableOfContentHandle(AutomationAgent bookBuilderAutomatinAgent, int p1, int p2)
        {
            bookBuilderAutomatinAgent.DragElement("BookBuilderView", "TableOfContentDragHandle", p1, p2);
        }
        /// <summary>
        /// Verify check button on top right of the table
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCheckButton(AutomationAgent bookBuilderAutomatinAgent)
        {
            return bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "CheckButton");
        }

        /// <summary>
        /// Click on the previous arrow
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPrevArrowAtBook(AutomationAgent bookBuilderAutomatinAgent)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "PageArrowLeftAtBook"))
            {
                bookBuilderAutomatinAgent.Click("BookBuilderView", "PageArrowLeftAtBook");
            }
            else
            {
                bookBuilderAutomatinAgent.Swipe(Direction.Right, 500);
                bookBuilderAutomatinAgent.Click("BookBuilderView", "PageArrowLeftAtBook");
            }
        }

        /// <summary>
        /// Get share button position 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>share button position</returns>
        public static int GetShareButtonPosition(AutomationAgent bookBuilderAutomatinAgent)
        {
            string[] currentBookCoordinate = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "ShareBookIcon").Split(',');
            int currentBookxaxis = Int32.Parse(currentBookCoordinate[0]);
            return currentBookxaxis;
        }

        /// <summary>
        /// Get edit button position
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <returns>Edit button position</returns>
        public static int GetEditButtonPosition(AutomationAgent bookBuilderAutomatinAgent)
        {
            string[] currentBookCoordinate = bookBuilderAutomatinAgent.GetPosition("BookBuilderView", "EditBookButton").Split(',');
            int currentBookxaxis = Int32.Parse(currentBookCoordinate[0]);
            return currentBookxaxis;
        }

        /// <summary>
        /// verify share popup open when clicking on share button
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifySharePopupOpen(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "ShareSendConfirmationIcon");
        }

        /// <summary>
        /// verify sharing is sent 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifySentText(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "SentText");
        }

        /// <summary>
        /// verify scrollable teacher view at share popup
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyScrollableTeacherListAtSharePopup(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.VerifyElementFound("BookBuilderView", "ScrollableTeacherCell");
        }

        /// <summary>
        /// verify only one teacher is selected 
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        public static void VerifyUserCanSelectOnlyOneTeacher(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "SelectedTeacher", "Ms. LEISHA A Anekwe", "backgroundColor").Equals("0x74BADE");
            bookBuilderAutomatinAgent.GetAllValues("BookBuilderView", "SelectedTeacher", "Mr. Cye Babamovski", "backgroundColor").Equals("0xD3ECEA");
        }
        public static void VerifyAcceptAndCancelOptionsInShareDialogue(AutomationAgent bookBuilderAutomatinAgent)
        {
            bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "CancleShare");
            bookBuilderAutomatinAgent.IsElementFound("BookBuilderView", "AcceptShare");
            
        }
        public static void sendBooksToTeacher(AutomationAgent bookBuilderAutomatinAgent)
        {
            BackUpAndRestoreCommonMethods.InitialStepsToReachBookBuilder(bookBuilderAutomatinAgent, "StudentSec01");

            BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
            ShareBooksToTeacher(bookBuilderAutomatinAgent,2);
            BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "B");
            ShareBooksToTeacher(bookBuilderAutomatinAgent,1);
            BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "C");
            ShareBooksToTeacher(bookBuilderAutomatinAgent,1);
            NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
        }

        public static void ShareBooksToTeacher(AutomationAgent bookBuilderAutomatinAgent, int clickCount)
        {
            bookBuilderAutomatinAgent.WaitforElement("StudentSetup", "BackButton","",WaitTime.DefaultWaitTime);
            NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
            while (bookBuilderAutomatinAgent.IsElementFound("UnitSelection", "CurrentUnit"))
            {
                NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
            }
            for (int i = 0; i < clickCount; i++)
            {
                NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                NavigationCommonMethods.ClickOnAcceptButtonOfShare(bookBuilderAutomatinAgent);
                while (bookBuilderAutomatinAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                {
                    bookBuilderAutomatinAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
                }
                LoginCommonMethods.CloseErrorPopUp(bookBuilderAutomatinAgent);
            }

        }
    }

}


