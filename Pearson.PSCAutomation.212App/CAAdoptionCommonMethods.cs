using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;



namespace Pearson.PSCAutomation._212App
{

    public class CAAdoptionCommonMethods
    {
        /// <summary>
        /// Verifies If User is on Dashboard or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if user is no dashboard), false(if user not on dashboard)</returns>
        public static bool VerifyUserIsOnDashboard(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("DashboardView", "MyDashboardTitle");
        }
        /// <summary>
        /// Clicks on Resource Library Icon present at the Top in App chrome Bar
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickResourceLibrary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "ToolsIcon");
        }
        /// <summary>
        /// Verifies Resource Library icon present or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Icon is present), false(if Icon is not present)</returns>
        public static bool VerifyResourceLibraryIcon(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon");
        }
        /// <summary>
        /// Verifies the Resource Library Fly Out Menu available or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if avaialble), false(if not avaialble)</returns>
        public static bool VerifyResourceLibraryFlyOutMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("DashboardView", "ResourceLibraryFlyOutMenu");
        }
        /// <summary>
        /// Gets the Heading of the Tools Icon Sub menus
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static string GetResourceLibraryIconHeading(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.GetTextIn("TasksTopMenuView", "ToolsIconHeading", "Inside", "").Replace("\t\n", "");
        }
        /// <summary>
        /// Clicks on Vocabulary Button in Resource Library Fly Out MEnu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickVocabularyInResourceLibrary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "VocabularyInResourceLibrary");
        }
        /// <summary>
        /// Clicks on Unit 1 present in Yocabulary Fly out menu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitInVocabulary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.WaitforElement("TasksTopMenuView", "Unit1inVocabulary", "", WaitTime.LargeWaitTime);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "Unit1inVocabulary");
            CAAdoptionAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Episode 1 present in Vocabulary Fly out menu 
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnEpisodeInVocabulary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "Episode1inVocabulary");
        }
        /// <summary>
        /// Verifies Episodes Full present or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyEpisodeFullPage(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "VocabularyListPage");
        }
        /// <summary>
        /// Clicks on Done Button Present in the Wpisode Full Page
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDoneButton(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "EpisdoeDoneButton");
        }
        /// <summary>
        /// Verifies ELA Unit Library Page
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if all the elements are found), false(if any one of the element is not found)</returns>
        public static bool VerifyELAUnitLibraryPage(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("GradeSelectionMenuView", "ELAUnitsTitle") &&
               CAAdoptionAutomationAgent.IsElementFound("GradeSelectionMenuView", "GradesMenuView")
              )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Done Button Present at the Top Left Corner
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyDoneButton(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.VerifyElementFound("TasksTopMenuView", "EpisdoeDoneButton");
            int xPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "EpisdoeDoneButton", "x")[0]);
            int yPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "EpisdoeDoneButton", "y")[0]);
            if (xPos < 20 && yPos < 60)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Title Populated on clicking Episode in Vocabulary is at Center
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyTitlePopulated(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.VerifyElementFound("TasksTopMenuView", "VocabularyListPage");
            int xPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "VocabularyListPage", "x")[0]);
            int yPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "VocabularyListPage", "y")[0]);
            if (xPos < 950 && yPos < 70)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Send To Notebook Icon present at the Top Right Corner
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifySendToNotebookIcon(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.VerifyElementFound("InteractiveView", "SaveToNotebookButton");
            int xPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("InteractiveView", "SaveToNotebookButton", "x")[0]);
            int yPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("InteractiveView", "SaveToNotebookButton", "y")[0]);
            if (xPos < 1950 && yPos < 60)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Resource Library Sub menu 
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if submenu label is Tools), false(if not)</returns>
        public static bool VerifyResourceLibrarySubmenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "ResourceLibraryToolsMenu");
        }
        /// <summary>
        /// Verifies Snapshoot Tool Submenu Present or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySnapshotToolMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SnapshotToolsIcon");
        }
        /// <summary>
        /// Clicks on Resource Library Sub menu Tools
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClicksOnResourceLibrarySubmenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "ResourceLibraryToolsMenu");
        }
        /// <summary>
        /// Verifies Vocabulary Page Present or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyVolabularyPage(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "VocabularyListPage");
        }
        /// <summary>
        /// Clicks On Language Studies In ResourceLibrary
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickLanguageStudiesInResourceLibrary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.WaitforElement("TasksTopMenuView", "LanguageMenu", "", WaitTime.LargeWaitTime);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "LanguageMenu");
            CAAdoptionAutomationAgent.Sleep(1000);
        }
        /// <summary>
        /// Verifies Language SubMenu Opened or not 
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if opened), false(if not opened)</returns>
        public static bool VerifyLanguageSubMenuOpened(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "LanguageSubmenuOpened");
        }
        /// <summary>
        /// Verifies Language SubMenu Options present or not 
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyLanguageSubMenuOptions(AutomationAgent CAAdoptionAutomationAgent)
        {
            if ((CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SentenceCombiners")) && (CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "GrammerGrabs")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies Right Arrow For Language Menu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyRightArrowForLanguageMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "RightArrowOfLanguageMenu");
        }
        /// <summary>
        /// Clicks On Sentence Combiners In Language Studies
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickSentenceCombinersInLanguageStudies(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "SentenceCombiners");
        }
        /// <summary>
        /// Click On Bugle Horn In Sentence Combiners
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickBugleHornInSentenceCombiners(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "BugleHornInSenetnceCombiners");
        }
        /// <summary>
        /// Click Week1 Menu Of Spelling
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickWeek1MenuOfSpelling(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "SpellingWeek1");
            CAAdoptionAutomationAgent.Sleep(WaitTime.LargeWaitTime);
        }
        /// <summary>
        /// Get Spelling Of Notebook Title
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>string:Spelling Notebook Title</returns>
        public static string GetSpellingNotebookTitle(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.GetTextIn("NotebookView", "SpellingNotebook", "NATIVE", "Inside", "", 0, 0);
        }
        /// <summary>
        /// Verify Spelling Header Of Chrome Title and location should be at center
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present and at the center), false(if not present and not at the center)</returns>
        public static bool VerifySpellingHeaderChromeTitle(AutomationAgent CAAdoptionAutomationAgent)
        {
            int xPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "SpellingHeaderTitle", "x")[0]);
            int yPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "SpellingHeaderTitle", "y")[0]);
            if (xPos < 1000 && yPos < 70 && CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingHeaderTitle"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// clicks Games In ResourceLibrary
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickGamesinResourceLibrary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "GamesInResourceLibrary");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// clicks BobBusters In Games
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent"></param>
        public static void ClickBobBustersInGames(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.WaitforElement("TasksTopMenuView", "BlobBlusterInGamesMenu", "", WaitTime.MediumWaitTime);
            if (CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "BlobBlusterInGamesMenu"))
            {
                CAAdoptionAutomationAgent.Click("TasksTopMenuView", "BlobBlusterInGamesMenu");
            }
            else
            {
                if (CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "GamesInResourceLibrary"))
                {
                    CAAdoptionAutomationAgent.Click("TasksTopMenuView", "GamesInResourceLibrary");
                    CAAdoptionAutomationAgent.Sleep(2000);
                    CAAdoptionAutomationAgent.Click("TasksTopMenuView", "BlobBlusterInGamesMenu");
                }
            }
        }
        /// <summary>
        /// verfies BlobBuster Page In Games Menu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns></returns>
        public static bool VerifyBlobBusterPage(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.WaitforElement("TasksTopMenuView", "BlobBlusterInGamesMenu", "", WaitTime.MediumWaitTime);
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "BlobBlusterInGamesMenu");
        }
        /// <summary>
        /// Verify Spelling Notebook Header Color
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>string:background color</returns>
        public static string VerifySpellingNotebookHeaderColor(AutomationAgent CAAdoptionAutomationAgent)
        {
            string[] str;
            str = CAAdoptionAutomationAgent.GetAllValues("NotebookTopMenuView", "NotebookTitleBar", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Verify Folder Icon 
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>string:folder icon enabled or not</returns>
        public static string VerifyFolderIcon(AutomationAgent CAAdoptionAutomationAgent)
        {
            string[] str;
            str = CAAdoptionAutomationAgent.GetAllValues("NotebookTopMenuView", "PersonalNotesFoldericonCheck", "", "enabled");
            return str[0];
        }
        /// <summary>
        /// Verify Share Icon 
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>string:Spelling Notebook Share Icon enaled or not</returns>
        public static string VerifyShareIcon(AutomationAgent CAAdoptionAutomationAgent)
        {
            string[] str;
            str = CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "SpellingNotebookShareIcon", "", "enabled");
            return str[0];
        }
        /// <summary>
        /// Verify Alert Message On Send To Notebook Icon Click
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if alert Message is present),false:(if alert message is not present)</returns>
        public static bool VerifyAlertOnSendToNotebookIconClick(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("InteractiveView", "SaveInteractivePopUpLabel") && CAAdoptionAutomationAgent.IsElementFound("InteractiveView", "InteractiveAlertCancelButton") && CAAdoptionAutomationAgent.IsElementFound("InteractiveView", "InteractiveAlertContinueButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Alert Message Present or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if alert sent to notebook icon is present),false:(if alert is not present)</returns>
        public static bool VerifyAlertMessagePresent(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("InteractiveView", "InteractiveAlert");
        }
        /// <summary>
        /// Click Alert Cancel Button in Notebook
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickAlertCancelButton(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("InteractiveView", "InteractiveAlertCancelButton");
        }
        /// <summary>
        /// Verify Notebook Icon Selected State
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if selected) false:(if not selected)</returns>
        public static bool VerifyNotebookIconSelectedState(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("NotebookView", "SpellingNotebookIconSelectedState");
        }
        /// <summary>
        /// Verify Wrench Icon is Active or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if active) false:(if not active)</returns>
        public static bool VerifyWrenchIconActive(AutomationAgent CAAdoptionAutomationAgent)
        {
            return bool.Parse(CAAdoptionAutomationAgent.GetAllValues("NotebookBottomMenuView", "WrenchIcon", "enabled")[0]);
        }
        /// <summary>
        /// Verify Spelling Page Open or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if open) false:(if not open)</returns>
        public static bool VerifySpellingPageOpen(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingHeaderTitle");
        }
        /// <summary>
        /// Click Graphic Organizers In Tools
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickGraphicOrganizersInTools(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "GraphicOrganizers");
        }
        /// <summary>
        /// Click Story Map In Graphic Organizers Menu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickStoryMapInGraphicOrganizersMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "StoryMapInGraphicOrganizers");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verify Notebook Picker Work Browser Modal Exists or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not present)</returns>
        public static bool VerifyNotebookPickerWorkBrowserModalExists(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("NotebookWorkBrowserView", "NotebookPickerWorkBrowserModal");
        }
        /// <summary>
        /// Click X Icon In Work Browser Modal in graphic Organizers
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickXIconInWorkBrowserModal(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("WorkBrowserView", "WorkBrowserXIconInGraphicOrganizers");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verify Work Browser Header Title
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if work browser title present),false:(if not present)</returns>
        public static bool VerifyWorkBrowserHeaderTitle(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("WorkBrowserView", "WorkBrowserHeaderTitleInGraphicOrganizers");
        }
        /// <summary>
        /// Verify Vocabulary Notebook Header Color
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>string:(color)</returns>
        public static string VerifyVocabularyNotebookHeaderColor(AutomationAgent CAAdoptionAutomationAgent)
        {
            string[] str;
            str = CAAdoptionAutomationAgent.GetAllValues("NotebookTopMenuView", "NotebookTitleBar", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Click Glossary In Resource Libarary
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickGlossaryInResourceLibarary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "Glossary");
        }
        /// <summary>
        /// Verify Chrome Header For Glossary
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not present)</returns>
        public static bool VerifyChromeHeaderForGlossary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.WaitforElement("TasksTopMenuView", "Glossary", "", WaitTime.LargeWaitTime);
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "Glossary");
        }
        /// <summary>
        /// Click Reading Log In Resource Libarary
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickReadingLogInResourceLibarary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "ReadingLog");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verify Story Map Header In Graphic Organizers
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyStoryMapHeaderInGraphicOrganizers(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "StoryMapInGraphicOrganizers");
        }
        /// <summary>
        /// Verify Reading Log Header In Chrome
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyReadingLogHeaderInChrome(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "ReadingLog");
        }
        /// <summary>
        /// Verify Notebook Is On Right Of Screen
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyNotebookIsOnRightOfScreen(AutomationAgent CAAdoptionAutomationAgent)
        {
            int xPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("NotebookDrawView", "DrawViewPanel", "x")[0]);
            int yPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("NotebookDrawView", "DrawViewPanel", "y")[0]);
            if (xPos < 1070 && yPos < 229)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Verify Lesson Content On Left Of Screen
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyLessonContentOnLeftOfScreen(AutomationAgent CAAdoptionAutomationAgent)
        {
            int xPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "SpellingContent", "x")[0]);
            int yPos = Int32.Parse(CAAdoptionAutomationAgent.GetAllValues("TasksTopMenuView", "SpellingContent", "y")[0]);
            if (xPos < 78 && yPos < 360)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Full Screen Overlay
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyFullScreenOverlay(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (bool.Parse(CAAdoptionAutomationAgent.GetAllValues("GradeSelectionMenuView", "ELAUnitsTitle", "", "top")[0]))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// Verify Reading Log Is Present In Resource Library Menu or not
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyReadingLogIsPresentInResourceLibraryMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "ReadingLog");
        }
        /// <summary>
        /// Verify Glossary Is Present In Resource Library Menu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyGlossaryIsPresentInResourceLibraryMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "Glossary");
        }
        /// <summary>
        /// Click TChart In Graphic Organizers Menu
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickTChartInGraphicOrganizersMenu(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "TChart");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verify Spelling Interactive Full Screen
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifySpellingInteractiveFullScreen(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "ToolsIcon"))
            {
                return false;

            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// Verify Sentence Combiners Is Present In Resource Library
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifySentenceCombinersIsPresentInResourceLibrary(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SentenceCombiners");
        }
        /// <summary>
        /// Verify Bugle Horn Chrome Header is present
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyBugleHornChromeHeader(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "BugleHornInSenetnceCombiners");
        }
        /// <summary>
        /// Verify Spelling Lesson Lists
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifySpellingLessonLists(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingWeek1") &&
                CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingWeek2") &&
                CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingWeek3") &&
                CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingWeek4") &&
                CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingWeek5") &&
                CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SpellingWeek6"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click Week2 Menu Of Spelling
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickWeek2MenuOfSpelling(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "SpellingWeek2");
            CAAdoptionAutomationAgent.Sleep(WaitTime.LargeWaitTime);
        }
        /// <summary>
        /// Click Week3 Menu Of Spelling
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickWeek3MenuOfSpelling(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "SpellingWeek3");
            CAAdoptionAutomationAgent.Sleep(WaitTime.LargeWaitTime);
        }
        /// <summary>
        /// Verify Story Map Visible And Accessible In Graphic Organizers
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyStoryMapVisibleAndAccessibleInGraphicOrganizers(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "StoryMapInGraphicOrganizers") &&
              CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "EpisdoeDoneButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click Notebook Title To Edit
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickNotebookTitleToEdit(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("PersonalNotesTopView", "PersonalNotebookTitle");
        }
        /// <summary>
        /// Verify Blue Bounding Box Of Notebook
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false:(if not)</returns>
        public static bool VerifyBlueBoundingBoxOfNotebook(AutomationAgent CAAdoptionAutomationAgent)
        {
            string color = CAAdoptionAutomationAgent.GetAllValues("NotebookView", "EditNotebookBoundingBox", "backgroundColor")[0];
            if (color == "0x0054A5")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Move Intearctive In NoteBook
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void MoveIntearctiveInNoteBook(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.SwipeElement("NotebookView", "InteractiveThumbnail", Direction.Left, 10, WaitTime.DefaultWaitTime);
        }
        /// <summary>
        /// Get Image Coordinate
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string:image coordinate</returns>
        public static string GetImageCoordinate(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetPosition("NotebookView", "InteractiveThumbnail");
        }
        /// <summary>
        /// Verify Story Map Initial State In Graphic Organizers
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <param name="ToFind">String:To Find</param>
        /// <returns>true:(if found),false:(if not found)</returns>
        public static bool VerifyStoryMapInitialStateInGraphicOrganizers(AutomationAgent CAAdoptionAutomationAgent, string ToFind)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "TextToFindInStoryMap", ToFind);
        }
        /// <summary>
        /// Click Create Notebook In Notebook Picker
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickCreateNotebookInNotebookPicker(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("NotebookTopMenuView", "CreateNotebook");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Open EPub In Spelling
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void OpenEPubInSpelling(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "EPubInSpelling");
        }
        /// <summary>
        /// Click Saved Graphic Organizer
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickSavedGraphicOrganizer(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "SavedGraphicOrganizerNotebook");
        }
        /// <summary>
        /// Verify Multiple Instances Have TimeStamp
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMultipleInstancesHaveTimeStamp(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("NotebookView", "InteractiveThumbnail"))
            {
                CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SavedNotebookLastModified");
                CAAdoptionAutomationAgent.IsElementFound("NotebookTopMenuView", "RightArrow");
                bool timestamp = CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "SavedNotebookLastModified");
                return timestamp;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Multiple Instances Are Saved
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyMultipleInstancesAreSaved(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("NotebookView", "InteractiveThumbnail"))
            {
                CAAdoptionAutomationAgent.Click("NotebookTopMenuView", "LeftArrow");
                bool instance2 = CAAdoptionAutomationAgent.IsElementFound("NotebookView", "InteractiveThumbnail");
                return instance2;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Verify Epub Title Header
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyEpubTitleHeader(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "EpubHeader");
        }
        /// <summary>
        /// Verify First Url InWebView CA
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void VerifyFirstUrlInWebViewCA(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("iPadCommonView", "SafariBrowserUrl");
            teachersupportAutomationAgent.VerifyElementFound("TeacherSupportView", "FirstUrlInBrowserCA");
            teachersupportAutomationAgent.ClickOnScreen(40, 192, 1);
        }
        /// <summary>
        /// Verify Games in Resource Library
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyGamesinResourceLibrary(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.IsElementFound("TasksTopMenuView", "GamesInResourceLibrary");
        }
        /// <summary>
        /// Copy Vocabulary Word
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <param name="texttoselect">texttoselect</param>
        public static void SelectAndCopyVocabularyWord(AutomationAgent CAAdoptionAutomationAgent, string texttoselect)
        {
            CAAdoptionAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", texttoselect);
            CAAdoptionAutomationAgent.Sleep(4000);
            if (!CAAdoptionAutomationAgent.IsElementFound("NotebookView", "CopyMenu"))
            {
                NotebookCommonMethods.TapOnScreen(CAAdoptionAutomationAgent, 200, 200, 1);
                CAAdoptionAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", texttoselect);
                CAAdoptionAutomationAgent.Sleep(4000);
            }
            CAAdoptionAutomationAgent.Click("NotebookView", "CopyMenu");
            CAAdoptionAutomationAgent.Sleep(4000);
        }
        /// <summary>
        /// Click Vocabulary in My Work Filter
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickVocabulary(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("WorkBrowserView", "VocabularySelect");
        }

        /// <summary>
        /// Click ELA in My Work Filter
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickELA(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("WorkBrowserView", "ELASelect");
        }
        /// <summary>
        /// Click Vocabulary Tile in Work Browser
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickVocabularyTile(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Sleep(2000);
            CAAdoptionAutomationAgent.Click("WorkBrowserView", "VocabularyTile");
        }
        /// <summary>
        /// Verify Vocabulary Word Copied
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static string VerifyVocabularyWordCopied(AutomationAgent CAAdoptionAutomationAgent)
        {
            string[] str;
            str = CAAdoptionAutomationAgent.GetAllValues("NotebookTopMenuView", "SendToNotebookBtnDesmos", "enabled");
            return str[0];
        }
        /// <summary>
        /// Verify VocabularyScreenSplitted
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyVocabularyScreenSplitted(AutomationAgent CAAdoptionAutomationAgent)
        {
            string WindowSize = CAAdoptionAutomationAgent.GetAllValues("NoteBookTouchView", "ScreenSizeHTML", "width")[0];
            string notebookWindowSize = "0";

            notebookWindowSize = CAAdoptionAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookDrawRegion", "x")[0];
            return (Int32.Parse(notebookWindowSize) * 2 == Int32.Parse(WindowSize)) ? true : false;
        }
        /// <summary>
        /// Click Saved Vocabulary Page
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickSavedVocabularyPage(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "SavedGraphicOrganizerNotebook");
        }
        /// <summary>
        /// Tap On Vocabulary Page
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void TapOnVocabularyPage(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.ClickCoordinate(120, 470, 1);
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Copies the Title of notebook
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void CopyNotebookTitle(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("NotebookView", "SpellingNotebook");
            if (!CAAdoptionAutomationAgent.IsElementFound("NotebookView", "CopyMenu"))
            {
                CAAdoptionAutomationAgent.Click("NotebookView", "SpellingNotebook");
            }
            CAAdoptionAutomationAgent.Click("NotebookView", "CopyMenu");
        }
        /// <summary>
        /// Paste the copied content
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        public static void PasteTitleInNotebook(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("NotebookView", "PasteMenu");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Clicks Grammer Grab In Language studies
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent"></param>
        public static void ClickGrammerGrabInLanguageStudies(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.WaitforElement("TasksTopMenuView", "GrammerGrabs", "", WaitTime.LargeWaitTime); 
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "GrammerGrabs");
            CAAdoptionAutomationAgent.Sleep(1000);
        }
        /// <summary>
        /// Clicks Adverb in grammer grab
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent"></param>
        public static void ClickAdverbsGrammerGrab(AutomationAgent CAAdoptionAutomationAgent)
        {
            CAAdoptionAutomationAgent.Click("TasksTopMenuView", "Adverbs");
            CAAdoptionAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verifies Video is in Fullscreen overlay
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent"></param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyVideoFullScreenOverlay(AutomationAgent CAAdoptionAutomationAgent)
        {
            if (CAAdoptionAutomationAgent.IsElementFound("LessonBrowserView", "VideoPlayerPause") &&
               CAAdoptionAutomationAgent.IsElementFound("LessonBrowserView", "DoneButtonInVideo"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verifies VideoPlay Till  End
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent"></param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyVideoPlayTillEnd(AutomationAgent CAAdoptionAutomationAgent)
        {
            return CAAdoptionAutomationAgent.WaitForElementToVanish("LessonBrowserView", "VideoPlayerPlay");
        }
    }
}

