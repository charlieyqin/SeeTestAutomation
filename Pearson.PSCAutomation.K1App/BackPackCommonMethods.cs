using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    public static class BackPackCommonMethods
    {
        /// <summary>
        /// Drag element from media library to back pack
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <param name="noOfDraggedElement">Int: Element which need to be dragged </param>
        public static void DragElementToBackPack(AutomationAgent BackPackAutomationAgent, int noOfDraggedElement)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItem", noOfDraggedElement.ToString(), "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItem", noOfDraggedElement.ToString(), "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItem", noOfDraggedElement.ToString(), "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItem", noOfDraggedElement.ToString(), "height"))[0]);

            int xCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "x"))[0]);
            int yCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "y"))[0]);
            int widthOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "width"))[0]);
            int heightOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(7000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfBP + (widthOfBP / 2), yCoordinateOfBP + (heightOfBP / 2), 1000);
        }

        public static void VerifyItemCountBadgeonBackPack(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.VerifyElementFound("BackPackView", "BackPackItemCountBadge");
        }


        /// <summary>
        /// Verify dragged element present in backpack
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if present</returns>
        public static bool VerifyDraggedElementInBackPack(AutomationAgent BackPackAutomationAgent)
        {
            return BackPackAutomationAgent.IsElementFound("BackPackView", "BackPackItem");
        }

        /// <summary>
        /// Draged library to trash can
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void DragElementToTrash(AutomationAgent BackPackAutomationAgent)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "height"))[0]);

            int xCoordinateOfTrash = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "TrashCan", "x"))[0]);
            int yCoordinateOfTrash = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "TrashCan", "y"))[0]);
            int widthOfTrash = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "TrashCan", "width"))[0]);
            int heightOfTrash = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "TrashCan", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(5000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfTrash + (widthOfTrash / 2), yCoordinateOfTrash + (heightOfTrash / 2), 2000);

        }

        /// <summary>
        /// Verify if item is deleted then it should not display on backpack
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if not found</returns>
        public static bool VerifyDeletedItemNotFoundInBackPack(AutomationAgent BackPackAutomationAgent)
        {
            string hidden = BackPackAutomationAgent.GetElementProperty("BackPackView", "BackPackItem", "parentHidden");
            if (hidden.Equals("true"))
                return true;
            else
                return false;            
        }

        /// <summary>
        /// Verify trash can is visisble
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if visible</returns>
        public static bool VerifyTrashCanAppeared(AutomationAgent BackPackAutomationAgent)
        {
            string[] hiddenProperty = BackPackAutomationAgent.GetAllValues("BackPackView", "TrashCan", "hidden");
            return hiddenProperty[0].Equals("false");
        }

        public static void VerifyGoldenIconBackGround(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.VerifyElementFound("BackPackView", "BackPack");
        }

        public static void VerifyBagWithZip(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.VerifyElementFound("BackPackView", "BackPackZip");
        }

        /// <summary>
        /// Get the backpack items count
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>back pack count</returns>
        public static int GetTheBackPackCount(AutomationAgent BackPackAutomationAgent)
        {
            int count = Int32.Parse(BackPackAutomationAgent.GetTextIn("BackPackView", "BackPackItemCount", "Inside", "", 0, 0));
            return count;
        }

        public static void ClickToOpenBackPackImage(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.Click("", "");
        }

        public static void VerifyDisplayOfImage(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.Click("", "");
        }

        public static void VerifyBackButtonIcon(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.Click("", "");
        }

        /// <summary>
        /// Long click on back pack item
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void LongClickOnBackPackItem(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.LongClick("BackPackView", "BackPackItem");
        }

        /// <summary>
        /// Drag element to any where in screen like back pack
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void DragBackpackElementToBackPack(AutomationAgent BackPackAutomationAgent)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackItem", "height"))[0]);

            int xCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "x"))[0]);
            int yCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "y"))[0]);
            int widthOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "width"))[0]);
            int heightOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(5000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfBP + (widthOfBP / 2), yCoordinateOfBP + (heightOfBP / 2), 2000);
        }

        /// <summary>
        /// Verify Delete Assert Popup From BackPack
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void VerifyDeleteAssertPopupFromBackPack(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.VerifyElementFound("UnitSelection", "AcceptLogOut");
            BackPackAutomationAgent.VerifyElementFound("UnitSelection", "CancelLogOut");
            BackPackAutomationAgent.VerifyElementFound("BackPackView", "RemovePaper");
        }

        /// <summary>
        /// Close the popup if media already exist message displayed
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAndCloseIfMediaAlreadyExist(AutomationAgent BackPackAutomationAgent)
        {
            if (VerifyMediaAlreadyExist(BackPackAutomationAgent))
            {
                LoginCommonMethods.CloseErrorPopUp(BackPackAutomationAgent);
                return true;
            }
            return false;
        }

        /// <summary>
        /// verify dragging library which is already exist in backapck should display message
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if already exist message displayed</returns>
        public static bool VerifyMediaAlreadyExist(AutomationAgent BackPackAutomationAgent)
        {
            string TextonScreen = BackPackAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("Media already exists in backpack.");
        }

        /// <summary>
        /// Tap to open eReader from back pack screen
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenBackPackEreader(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.Click("BackPackView", "BackPackEreader");
        }

        /// <summary>
        /// Drag the back pack zip to up
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void DragBackPackZipToUp(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.DragElement("BackPackView", "BackPackZip", 0, -400);
        }

        /// <summary>
        /// Verify backapck screen is not open 
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if not displayed</returns>
        public static bool VerifyBackPackIsClosed(AutomationAgent BackPackAutomationAgent)
        {
            return (!BackPackAutomationAgent.IsElementFound("BackPackView", "BackPackUnzipped"));
        }

        /// <summary>
        /// Drag the backpack zip to down
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void DragBackPackZipToDown(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.DragElement("BackPackView", "BackPack", 0, 900);
        }


        /// <summary>
        /// Drag the backpack zip to left
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void DragBackPackZipToLeft(AutomationAgent BackPackAutomationAgent)
        {
            BackPackAutomationAgent.DragElement("BackPackView", "BackPack", -900, 900);
        }

        /// <summary>
        /// Verify Backpack is in openned state
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static bool VerifyBackPackOpened(AutomationAgent BackPackAutomationAgent)
        {
            string hidden = BackPackAutomationAgent.GetElementProperty("BackPackView", "BackPackItem", "enabled");
            if (hidden.Equals("true"))
                return true;
            else
                return false;  
        }

        /// <summary>
        /// Get the available items count in backapack count 
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static int GetTheAvailablesItemCountInBackPack(AutomationAgent MediaLibraryAutomationAgent)
        {
            return MediaLibraryAutomationAgent.GetElementCount("BackPackView", "BackPackItems");
        }

        /// <summary>
        /// Click to open back pack item
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenBackPackItem(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("BackPackView", "BackPackItem");
        }

        /// <summary>
        /// Drag Interactive element to back pack
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DragInteractiveToBackPack(AutomationAgent BackPackAutomationAgent)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryInteractive", "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryInteractive", "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryInteractive", "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryInteractive", "height"))[0]);

            int xCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "x"))[0]);
            int yCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "y"))[0]);
            int widthOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "width"))[0]);
            int heightOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(5000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfBP + (widthOfBP / 2), yCoordinateOfBP + (heightOfBP / 2), 2000);
        }

        /// <summary>
        /// Click to open interactive from back pack screen
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenBackPackInteractive(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("MediaLibrary", "MediaLibraryInteractive");
        }

        /// <summary>
        /// Delete all available items from backpack
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void DeleteAllAvailableItemsFromBackpack(AutomationAgent MediaLibraryAutomationAgent)
        {
            NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
            int countsOfBackPackItems = BackPackCommonMethods.GetTheAvailablesItemCountInBackPack(MediaLibraryAutomationAgent);
            if (!countsOfBackPackItems.Equals(0))
                for (int i = 1; i <= countsOfBackPackItems; i++)
                {
                    BackPackCommonMethods.DragElementToTrash(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(MediaLibraryAutomationAgent);
                }
            NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
        }

        /// <summary>
        /// Get library item accessibilityIdentifier value
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <param name="itemXpathCount">xpath count</param>
        /// <returns>accessibilityIdentifier value</returns>
        public static string GetLibraryItemDetails(AutomationAgent BackPackAutomationAgent, int itemXpathCount)
        {
            return (BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItem", itemXpathCount.ToString(), "accessibilityIdentifier")[0]).Substring(8, 3);
        }

        /// <summary>
        /// Get back pack items position
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <param name="itemXpathCount">xpath count</param>
        /// <returns></returns>
        public static int GetBackpackItemPosition(AutomationAgent BackPackAutomationAgent, string value)
        {
            return Int32.Parse(BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackImage", value, "x")[0]);
        }

        /// <summary>
        /// Drag graphic organizer to back pack 
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        public static void DragGraphicOrganizerToBackPack(AutomationAgent BackPackAutomationAgent, int noOfDraggedElement)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryGraphicOrganizer", noOfDraggedElement.ToString(), "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryGraphicOrganizer", noOfDraggedElement.ToString(), "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryGraphicOrganizer", noOfDraggedElement.ToString(), "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryGraphicOrganizer", noOfDraggedElement.ToString(), "height"))[0]);

            int xCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "x"))[0]);
            int yCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "y"))[0]);
            int widthOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "width"))[0]);
            int heightOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(5000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfBP + (widthOfBP / 2), yCoordinateOfBP + (heightOfBP / 2), 2000);
        }

        /// <summary>
        /// click to open graphic organizer from backpack
        /// </summary>
        /// <param name="MediaLibraryAutomationAgent">AutomationAgent object</param>
        public static void ClickToOpenGraphicOrganizerFromBackPack(AutomationAgent MediaLibraryAutomationAgent)
        {
            MediaLibraryAutomationAgent.Click("BackPackView", "BackPackItem");
        }

        /// <summary>
        /// Get height od back pack items 
        /// </summary>
        /// <param name="BackPackAutomationAgent">AutomationAgent object</param>
        /// <param name="libraryItem2Details">accessibilityIdentifier value</param>
        /// <returns>Height</returns>
        public static int GetBackpackItemHeight(AutomationAgent BackPackAutomationAgent, string value)
        {
            return Int32.Parse(BackPackAutomationAgent.GetAllValues("BackPackView", "BackPackImage", value, "height")[0]);
        }
        public static void DragElementToBackPackFromMath(AutomationAgent BackPackAutomationAgent, int noOfDraggedElement)
        {
            int xCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItemInMathUnit", noOfDraggedElement.ToString(), "x"))[0]);
            int yCoordinateOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItemInMathUnit", noOfDraggedElement.ToString(), "y"))[0]);
            int widthOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItemInMathUnit", noOfDraggedElement.ToString(), "width"))[0]);
            int heightOfLib = Int32.Parse((BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItemInMathUnit", noOfDraggedElement.ToString(), "height"))[0]);

            int xCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "x"))[0]);
            int yCoordinateOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "y"))[0]);
            int widthOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "width"))[0]);
            int heightOfBP = Int32.Parse((BackPackAutomationAgent.GetAllValues("BackPackView", "BackPack", "height"))[0]);

            BackPackAutomationAgent.SetDragStartDelay(7000);
            BackPackAutomationAgent.Drag(xCoordinateOfLib + (widthOfLib / 2), yCoordinateOfLib + (heightOfLib / 2), xCoordinateOfBP + (widthOfBP / 2), yCoordinateOfBP + (heightOfBP / 2), 1000);
        }
        public static string GetLibraryItemDetailsForMath(AutomationAgent BackPackAutomationAgent, int itemXpathCount)
        {
            return (BackPackAutomationAgent.GetAllValues("MediaLibrary", "MediaLibraryItemInMathUnit", itemXpathCount.ToString(), "accessibilityIdentifier")[0]).Substring(8, 3);
        }
        
        public static void DragImageToBackPack(AutomationAgent BackPackAutomationAgent)
        {
            int tCount = 0;
            while (!BackPackAutomationAgent.IsElementFound("MediaLibrary", "MediaLibraryFlashCard") && tCount <= 10)
            {
                BackPackAutomationAgent.Swipe(Direction.Down);
                tCount++;
            }
            DragElementToBackPack(BackPackAutomationAgent, 1);

        }
        public static void ClickToOpenFlashCard(AutomationAgent BackPackAutomationAgent, string value)
        {
            BackPackAutomationAgent.Click("BackPackView", "BackPackImage", value);
        }
    }
}
