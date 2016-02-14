using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class BackPackTests
    {
        public AutomationAgent BackPackAutomationAgent;

    /*    [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20185)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void AddingItemsToBackPack()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20185: Verify that user is allowed to add different categories of items available in Media library to backpack"))
            {
                try
                {
                   
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.AreEqual<bool>(true, BackPackCommonMethods.VerifyDraggedElementInBackPack(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20135)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void DeletingItemsByHoveringOverTrashCan()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20135: Verifying of deleted items when hovered over trash can "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 3);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToTrash(BackPackAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToTrash(BackPackAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackPackAutomationAgent);
                    Assert.AreEqual<bool>(true, BackPackCommonMethods.VerifyDeletedItemNotFoundInBackPack(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20136)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAppearenceofTrashCan()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20136: Verify that the trash can disappears once the user releases the long pressed and dragged item in backpack anywhere apart from trash can "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.LongClickOnBackPackItem(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyTrashCanAppeared(BackPackAutomationAgent), "Trash is no appeared");
                    BackPackCommonMethods.DragBackpackElementToBackPack(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyTrashCanAppeared(BackPackAutomationAgent), "Trash is not disappeared");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20138)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUIElementsOfBackPackIcon()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20138: Verify UI of  Backpack Icon "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyBagWithZip(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyItemCountBadgeonBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyGoldenIconBackGround(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20142)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCountAfterAddingORDeletingItems()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20142: Verify the Updating of count if the user deletes items from backpack "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    int backPackCountBeforeAdding = BackPackCommonMethods.GetTheBackPackCount(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    int backPackCountAfterAdding = BackPackCommonMethods.GetTheBackPackCount(BackPackAutomationAgent);
                    Assert.IsTrue(backPackCountAfterAdding.Equals(backPackCountBeforeAdding + 1), "backpack count increased");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToTrash(BackPackAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackPackAutomationAgent);
                    int backPackCountAfterDeleting = BackPackCommonMethods.GetTheBackPackCount(BackPackAutomationAgent);
                    Assert.IsTrue(backPackCountAfterDeleting.Equals(backPackCountAfterAdding - 1), "backpack count decreased");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(23641)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDeleteAssertPopupFromBackPack()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC23641: Verify the styled pop-up message displays when the user tries to delete any assets from back pack. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToTrash(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyDeleteAssertPopupFromBackPack(BackPackAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20148)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMediaAlreadyExistPopup()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20148: Verify message when the item which is already added is dragged and dropped on the backpack icon."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    Assert.IsTrue(BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent), "Media already exist popup does not open");
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20144)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMediaLibraryIsDragable()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20144: Verify that student is able to long press/hold Media library item and drag it."))
            {
                try
                {
                    
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests"), TestCategory("K1SmokeTests")]
        [WorkItem(23225)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEpubViewerFromBackPack()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC23225: Verify ePub viewer"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(BackPackAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackPackAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(BackPackAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(BackPackAutomationAgent);
                    EreaderCommonMethod.VerifyBottomNavBarItemsAtEreader(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20820)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClosingOfBackPackByDraggingTheBackPackIcon()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20820: Verify dragging the backpack icon less than 3/4th distance towards the bottom of the screen, backpack overlay is closed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragBackPackZipToUp(BackPackAutomationAgent);
                    Assert.IsTrue(BackPackCommonMethods.VerifyBackPackIsClosed(BackPackAutomationAgent), "Backpack is still not closed");
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20819)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOpeningOfBackPackByDraggingTheBackPackIcon()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20819: Verify dragging the backpack icon more than 3/4th distance towards the bottom of the screen, backpack overlay is opened."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    BackPackCommonMethods.DragBackPackZipToDown(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyBackPackIsClosed(BackPackAutomationAgent), "Backpack is still closed");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20783)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddingItemsToBackPackFromMultipleUnits()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20783: Verify User adds items to backpack from multiple ELA Units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    BackPackCommonMethods.DragBackPackZipToLeft(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyBackPackIsClosed(BackPackAutomationAgent), "Backpack is still closed");
                    Assert.IsTrue(BackPackCommonMethods.VerifyDraggedElementInBackPack(BackPackAutomationAgent), "Element is not present");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests"), TestCategory("K1SmokeTests")]
        [WorkItem(20184)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOpeningOfBackPackByDraggingAnywhereAndDisplayAllAddedItems()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20184: Verify dragging anywhere on the backpack icon should open the backpack overlay with all added items  displayed in it."))
            {
                try
                {
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentKevin"));
                    string randUnitNo = NavigationCommonMethods.GetRandomUnitNumber(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, randUnitNo);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyDraggedElementInBackPack(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20146)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOpenedBackPackIconWhenItemDraggedTowardsIt()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20146: Verify display of backpack icon when the Media library item is dragged over backpack icon"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.VerifyBackPackOpened(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(22209)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOpeningImageFromBackpack()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC22209: Verify that Backpack scroll position is intact when the user opens the image from backpack and comes back to backpack "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(BackPackAutomationAgent);
                    MediaLibraryCommonMethods.VerifyImageOpenInFullScreen(BackPackAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackPackAutomationAgent, 1200, 300);
                    NavigationCommonMethods.ClickOnGoBackIcon(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyBackPackOpened(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20103)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMostRecentAddedItemDisplayFirstInBackpack()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20103: Verify that items in the Student's backpack are displayed with most recently added items first (reverse chronological order of add date)"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    string libraryItem1Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    string libraryItem2Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 2);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 2);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    int backpackItem1Position = BackPackCommonMethods.GetBackpackItemPosition(BackPackAutomationAgent, libraryItem1Details);
                    int backpackItem2Position = BackPackCommonMethods.GetBackpackItemPosition(BackPackAutomationAgent, libraryItem2Details);
                    Assert.IsTrue(backpackItem2Position < backpackItem1Position, "Fail if recent added  item does not display at fisrt position");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(22160)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBackPackItemSequence()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC22160: Verify that items in the Student's backpack are displayed with most recently added items first and third row will be partially visible"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    string libraryItem1Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    string libraryItem2Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 2);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 2);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    int backpackItem1Position = BackPackCommonMethods.GetBackpackItemPosition(BackPackAutomationAgent, libraryItem1Details);
                    int backpackItem2Position = BackPackCommonMethods.GetBackpackItemPosition(BackPackAutomationAgent, libraryItem2Details);
                    Assert.IsTrue(backpackItem2Position < backpackItem1Position, "Fail if recent added  item does not display at fisrt position");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    string libraryItem3Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 3);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 3);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 4);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 5);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 6);
                    string libraryItem6Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 6);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 7);
                    string libraryItem7Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 7);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    int backpackItem3Position = BackPackCommonMethods.GetBackpackItemHeight(BackPackAutomationAgent, libraryItem3Details);
                    int backpackItem6Position = BackPackCommonMethods.GetBackpackItemHeight(BackPackAutomationAgent, libraryItem6Details);
                    int backpackItem7Position = BackPackCommonMethods.GetBackpackItemHeight(BackPackAutomationAgent, libraryItem7Details);
                    Assert.IsTrue(backpackItem3Position.Equals(backpackItem6Position) && backpackItem6Position > backpackItem7Position);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(22158)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBackPackOpenAndClose()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC22158: Verify that Tapping on backpack icon in navigation bar"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackPackAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.verifyBackPackOpen(BackPackAutomationAgent), "BackPackIsNotOpen");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.verifyBackPackOpen(BackPackAutomationAgent), "BackPackIsNotOpen");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUserOnMedialLibrary(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.verifyBackPackOpen(BackPackAutomationAgent), "BackPackIsNotOpen");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    NavigationCommonMethods.VerifyUserOnNoteBookBrowser(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        //Clubbed 10 Critical,5 Important & 3 Useful Cases of BackPack
        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20185), WorkItem(20148), WorkItem(20144), WorkItem(20103), WorkItem(22160), WorkItem(23225), WorkItem(20135), WorkItem(22158), WorkItem(23641),WorkItem(20142)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyBackPackCriticalFlow()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC22158,TC20148,TC20144,TC20103,TC22160,TC23225,TC23641,TC20185,TC20135,TC20142: Verify flow of backpack from dragging asset to deleting it"))
            {
                try
                {
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnMathUnit(BackPackAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.verifyBackPackOpen(BackPackAutomationAgent), "BackPackIsNotOpen");
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    int backPackCountBeforeAdding = BackPackCommonMethods.GetTheBackPackCount(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPackFromMath(BackPackAutomationAgent, 1);
                    int backPackCountAfterAdding = BackPackCommonMethods.GetTheBackPackCount(BackPackAutomationAgent);
                    Assert.IsTrue(backPackCountAfterAdding.Equals(backPackCountBeforeAdding + 1), "backpack count increased");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20142", true);
                    BackPackCommonMethods.DragElementToBackPackFromMath(BackPackAutomationAgent, 1);
                    Assert.IsTrue(BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(BackPackAutomationAgent), "Media already exist popup does not open");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20148", true);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.AreEqual<bool>(true, BackPackCommonMethods.VerifyDraggedElementInBackPack(BackPackAutomationAgent));
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20144", true);
                    string libraryItem1Details = BackPackCommonMethods.GetLibraryItemDetailsForMath(BackPackAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.verifyBackPackOpen(BackPackAutomationAgent), "BackPackIsNotOpen");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 2);
                    string libraryItem2Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 2);
                    int backpackItem1Position = BackPackCommonMethods.GetBackpackItemPosition(BackPackAutomationAgent, libraryItem1Details);
                    int backpackItem2Position = BackPackCommonMethods.GetBackpackItemPosition(BackPackAutomationAgent, libraryItem2Details);
                    Assert.IsTrue(backpackItem2Position < backpackItem1Position, "Fail if recent added  item does not display at first position");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20103", true);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 3);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 4);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 5);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 6);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 7);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 8);
                    string libraryItem3Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 3);
                    string libraryItem6Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 6);
                    string libraryItem7Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 7);
                    int backpackItem3Position = BackPackCommonMethods.GetBackpackItemHeight(BackPackAutomationAgent, libraryItem3Details);
                    int backpackItem6Position = BackPackCommonMethods.GetBackpackItemHeight(BackPackAutomationAgent, libraryItem6Details);
                    int backpackItem7Position = BackPackCommonMethods.GetBackpackItemHeight(BackPackAutomationAgent, libraryItem7Details);
                    Assert.IsTrue(backpackItem3Position.Equals(backpackItem6Position) && backpackItem6Position > backpackItem7Position);
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC22160", true);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(BackPackAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackPackAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(BackPackAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(BackPackAutomationAgent);
                    EreaderCommonMethod.VerifyBottomNavBarItemsAtEreader(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(BackPackAutomationAgent);
                    Assert.IsTrue(BackPackCommonMethods.VerifyDraggedElementInBackPack(BackPackAutomationAgent), "Ereader didn't navigate back to BackPack");

                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC23225", true);
                    BackPackCommonMethods.VerifyDeleteAssertPopupFromBackPack(BackPackAutomationAgent); NotebookCommonMethods.ClickOnCancelButton(BackPackAutomationAgent);
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC23641", true);
                    int countOfItems = BackPackCommonMethods.GetTheAvailablesItemCountInBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(countOfItems.Equals(9), "Asset was not dragged");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20185", true);
                    for (int i = 0; i < countOfItems; i++)
                    {
                        BackPackCommonMethods.DragElementToTrash(BackPackAutomationAgent);
                        NotebookCommonMethods.ClickOnYesbutton(BackPackAutomationAgent);
                    }

                    Assert.AreEqual<bool>(true, BackPackCommonMethods.VerifyDeletedItemNotFoundInBackPack(BackPackAutomationAgent));
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20135", true);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUserOnMedialLibrary(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.verifyBackPackOpen(BackPackAutomationAgent), "BackPackIsNotOpen");
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    NavigationCommonMethods.VerifyUserOnNoteBookBrowser(BackPackAutomationAgent);
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC22158", true);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20138), WorkItem(20184), WorkItem(20783), WorkItem(22209), WorkItem(20136)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyBackPackImportantFlow()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20138,TC20184,TC20783,TC22209,TC20136: Verify flow of backpack from dragging asset to deleting it by clicking on random Unit"))
            {
                try
                {
                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSec01"));
                    string randUnitNo = NavigationCommonMethods.GetRandomUnitNumber(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, randUnitNo);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(BackPackAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyBagWithZip(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyItemCountBadgeonBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyGoldenIconBackGround(BackPackAutomationAgent);
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20138", true);
                    BackPackCommonMethods.DragImageToBackPack(BackPackAutomationAgent);
                    BackPackCommonMethods.DragBackPackZipToLeft(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyBackPackIsClosed(BackPackAutomationAgent), "Backpack is still closed");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20783", true);
                    Assert.IsTrue(BackPackCommonMethods.VerifyDraggedElementInBackPack(BackPackAutomationAgent));
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20184", true);
                    string libraryItem1Details = BackPackCommonMethods.GetLibraryItemDetails(BackPackAutomationAgent, 1);
                    BackPackCommonMethods.ClickToOpenFlashCard(BackPackAutomationAgent, libraryItem1Details);
                    MediaLibraryCommonMethods.VerifyImageOpenInFullScreen(BackPackAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackPackAutomationAgent, 1200, 300);
                    NavigationCommonMethods.ClickOnGoBackIcon(BackPackAutomationAgent);
                    BackPackCommonMethods.VerifyBackPackOpened(BackPackAutomationAgent);
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC22209", true);
                    BackPackCommonMethods.LongClickOnBackPackItem(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyTrashCanAppeared(BackPackAutomationAgent), "Trash is no appeared");
                    BackPackCommonMethods.DragBackpackElementToBackPack(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyTrashCanAppeared(BackPackAutomationAgent), "Trash is not disappeared");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20136", true);
                    NavigationCommonMethods.ClickOnBackPack(BackPackAutomationAgent);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackPackTests")]
        [WorkItem(20820), WorkItem(20819), WorkItem(20146)]
        [Priority(3)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyBackPackUsefulFlow()
        {
            using (BackPackAutomationAgent = new AutomationAgent("TC20820,TC20819,TC20146: Verify UI flow of BackPack"))
            {
                try
                {

                    LoginCommonMethods.TeacherAdminLogin(BackPackAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnELAUnit(BackPackAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackPackAutomationAgent));
                    BackPackCommonMethods.DragBackPackZipToDown(BackPackAutomationAgent);
                    Assert.IsFalse(BackPackCommonMethods.VerifyBackPackIsClosed(BackPackAutomationAgent), "Backpack is still closed");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20819", true);
                    BackPackCommonMethods.DragBackPackZipToUp(BackPackAutomationAgent);
                    Assert.IsTrue(BackPackCommonMethods.VerifyBackPackIsClosed(BackPackAutomationAgent), "Backpack is still not closed");
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20820", true);
                    NavigationCommonMethods.ClickOnMediaLibrary(BackPackAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(BackPackAutomationAgent, 1);
                    Assert.IsTrue(BackPackCommonMethods.VerifyBackPackOpened(BackPackAutomationAgent));
                    BackPackAutomationAgent.AddSteptoSeeTestReport("TC20146", true);
                    LoginCommonMethods.Logout(BackPackAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackPackAutomationAgent.Sleep(2000);
                    BackPackAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackPackAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


    }
}
