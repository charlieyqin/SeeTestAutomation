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
    public class NotebookTest
    {
        public AutomationAgent notebookAutomationAgent;

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(19776)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNotebookNavIconPressedState()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19776: Verify whether the PRESSED STATE is displayed on NOTEBOOK icon when tapped on it."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(19757)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOtherNavIconsDeselectedOnNotebookBrowser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC19757: Verify only the NOTEBOOK icon is in selected state on the navigation bar rest all icons has to be deselected."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(notebookAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(notebookAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(23869)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingOutsideOfNotebookDeletionConfirmationPopupForELA()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23869: Verify that tapping anywhere outside the confirmation dialog box for ELA Unit, Confirmation dialog should not close. User forced to make a decision. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 100, 100);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 100, 100);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(25876)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingOutsideOfNotebookDeletionConfirmationPopupForMath()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC25876: Verify that tapping anywhere outside the confirmation dialog box for Math Unit, Confirmation dialog should not close. User forced to make a decision. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(notebookAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFullScreenIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToAddPageInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDeleteIcon(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 100, 100);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(notebookAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnFullScreenIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToAddPageInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDeleteIcon(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 100, 100);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(20502)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIOfNotebookBrowserScreen()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20502: Verify UI elements of Notebook browser screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNavigationBar(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNoteBookPageNumber(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNoteBookOnFocus(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUnitNumberAndTitle(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(29983)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDefaultItemInStampOverlay()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC29983:When the Stamp overlay pops up, verify that by square box stamp type is selected by default when the stamp overlay opens."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyDefaultItemSelectedInStampOverlay(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(27051)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStampTypeImageHighlighted()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC27051:On Stamp overlay verify that tapping on stamp type images in right column, stamp type image turns to active state."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolLettersInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolLetterInStampOverlayhighlighted(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolObjectsInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolObjectInStampOverlayHighlighted(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolAnimalInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolAnimalInStampOverlayHighlighted(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolWeatherInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyToolWeatherInStampOverlayHighlighted(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(27052)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySelectedImageTypeOptionsofStamps()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC27052:Verify that upon selecting the stamp type on right side column on the stamp overlay (3-d box, Aa, apple, cat, sun), left side column is updated with similar stamp image selection options."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolsshapeSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolLettersInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolLettersSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolObjectsInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolObjectSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolAnimalInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolAnimalSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolWeatherInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampsWhenToolWeatherSelected(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23364)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingCancelButtonDuringAdditonOfPages()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23364:Verify the following when tapping cancel button during addition of pages"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int pagecount = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPlusButtonInNotebookEditor(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int pagecountaftercancel = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.AreEqual<bool>(true, pagecount.Equals(pagecountaftercancel));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23309)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDeletionOfTable()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23309:Verify tapping on red cancel button displaying on top-left of table, deletes the table."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableDeleted(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23365)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingCancelButtonDuringAdditonOfPagesInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23365:Verify the following when tapping cancel button during addition of pages"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent), "Pop Up Still there after clicking on cancel button");
                    int pagecountaftercancel = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(pagecountaftercancel.Equals(pagecountbeforeaddition), "Page count didnt match");
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23374)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageCountUpdatedAccordingToAdditionAndDeletion()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23374: Verify that additon/deletion of pages to any notebook ,the page count gets updated respectively."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPlusButtonInNotebookEditor(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    int pagecountbeforedeletion = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnDeleteIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnContinueButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int pagecountafterdeletion = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(pagecountbeforedeletion.Equals(pagecountafterdeletion + 1));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23362)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageAddedFromNotebookbrowseralsoUpdatedWhenCheckedWithinNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23362: Verify that page added from notebook browser is also updated when checked from within notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    int countwithinNotebook = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, Count + 1);
                    Assert.IsTrue(countwithinNotebook.Equals(Count + 1));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(21985)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyActiveStateDisplayAndFunctionalityOfTextArea()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC21985: Verify the text area active state,display and functionality"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextButtonActive(notebookAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxRegionFound(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxRegionFound(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23363)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageAddedFromNotebookEditorIsalsoUpdatedWhenCheckedFromNotebookBrowser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23363: Verify that page added from notebook editor is also updated when checked from notebook browser."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPlusButtonInNotebookEditor(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserOnNotebookbrowser(notebookAutomationAgent), "User is not on notebook browser");
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23339)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUseAbleToAddInteractiveToNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23339: Verify whether the user is able to open an interactive from Today's Shelf and save that to notebook."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(notebookAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(notebookAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyUIelementsOfInteractive(notebookAutomationAgent), "The UI elements are not there. ");
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    InteractiveCommonMethods.VerifyUIElementsOfSendToNotebookPopUp(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(29957)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddPagePopUpAndCountAfterhittingCancel()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC29957: Verify that when the user tries to add the page to unit Notebook, styled prompt message displays giving an option to user whether to add or cancel adding page."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUIofAddPagePopup(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserOnNotebookbrowser(notebookAutomationAgent), "User not on notebook browser");
                    int countaftercancel = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(countaftercancel.Equals(Count), "The page count didnt match");
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int countwithinNotebook = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, Count);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    Assert.IsTrue(countwithinNotebook.Equals(countaftercancel), "The page count didnt match");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(29952)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddPagePopUpAndCount()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC29952: Verify that when the user tries to add the page to unit Notebook, styled prompt message displays giving an option to user whether to add or cancel adding page."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 1600, 1000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPopUpMessage(notebookAutomationAgent), "Pop up not found");
                    NotebookCommonMethods.VerifyUIofAddPagePopup(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int countafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(countafteraddition.Equals(Count + 1), "The page count didnt match");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(29956)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCountAfterhittingCancel()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC29956: Verify that when the user tries to add the page to unit Notebook, styled prompt message displays giving an option to user whether to add or cancel adding page."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUIofAddPagePopup(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserOnNotebookbrowser(notebookAutomationAgent), "User not on notebook browser");
                    int countaftercancel = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(countaftercancel.Equals(Count), "The page count didnt match");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23203)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStampOverlayCLose()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23203: Verify that Stamp tool overlay closes as soon as the stamp type is selected."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.ChooseTheShapeFromStampOverlay(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStampOverlay(notebookAutomationAgent), "Stamp menu found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23200)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStampOverlayWhileTappingOutSide()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23200: Verify the Display of Stamp overlay while tapping outside of overlay."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStampOverlay(notebookAutomationAgent), "Stamp menu not found");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 940, 1480);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStampOverlay(notebookAutomationAgent), "Stamp menu not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22526)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedDataOnNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22526: verify whether the notebook data is SAVED and does not duplicate, when user saves data in Unit X notebook and then opens Unit Y notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Doctor");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, "9");
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Doctor"), "Data Saved Found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22504)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedDataOnNotebookForELA()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22504: erify whether the notebook data is SAVED between seesions"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Doctor");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Doctor"), "Data Saved not Found");
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, "2");
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Teacher");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Teacher"), "Data Saved not Found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22505)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedDataOnNotebookFromTeacherAndStudent()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22505:Verify data is saved on notebook from teacher and student login"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Doctor");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Doctor"), "Data Saved Found");
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Teacher");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Teacher"), "Data Saved Found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23366)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNAvigationArrowInNotebookBrowser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23366: Ensure that a teacher/student should be able to navigate across notebook pages."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNavigationArrowPresent(notebookAutomationAgent), "Navigation Arrow Not Present");
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPrevArrow(notebookAutomationAgent);
                    int CountAfter = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(CountAfter.Equals(CountBefore - 1), "Page Count didn't match");
                    int CountBeforeNext = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNextArrow(notebookAutomationAgent);
                    int CountAfterNext = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(CountBeforeNext.Equals(CountAfterNext - 1), "Page Count didn't match");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23311)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTableToolKeyBoardPopUp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23311:Verify that tapping on any of the text fields (heading, rows, columns) will invoke the device keyboard. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 630, 400);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(notebookAutomationAgent), "Keyboard not poped up");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23357)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageNumberInNotebookEditor()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23357: verify that Correct page number visible at bottom of page in notebook editor screen for EL A units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int CountAfter = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, CountBefore);
                    Assert.IsTrue(CountAfter.Equals(CountBefore), "Page Count didn't match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22693)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyToolPopUpMenu()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22693:  verify the pop up menu displayed when user taps on Tool Menu in Notebook Edit Screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifYToolMenuPopUp(notebookAutomationAgent), "Tool menu not found");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 500, 500);
                    Assert.IsFalse(NotebookCommonMethods.VerifYToolMenuPopUp(notebookAutomationAgent), "Tool menu found");
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNumberLineInNotebook(notebookAutomationAgent), "Number line not found on notebook");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22695)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyFunctionalityOfColorSelctionMenu()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22695:  verify the functionality and UI of COLOR SELECTION MENU"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToGetColorSelectionMenu(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyColorSelectionMenu(notebookAutomationAgent), "Color Selection Menu Not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyElevenCircleInColorSelectionMenu(notebookAutomationAgent), "Circles not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyCloseButtonInColorSelectionMenu(notebookAutomationAgent), "Close Button in color slection menu not found");
                    
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 500, 500);
                    notebookAutomationAgent.Sleep(5000);
                    Assert.IsFalse(NotebookCommonMethods.VerifyColorSelectionMenu(notebookAutomationAgent), "Color Selection Menu found");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23240)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedStateOfNumberLineTool()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23240: Verify the saved number line tool after logging in back."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    string[] positionbefore = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    string[] positionafter = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    Assert.IsTrue(positionbefore.Equals(positionafter), "Position is not same");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(21890)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBackGroundToolPopUpMenu()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC21890: Verify the  ability of the user to set a notebook background image."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyBackGroundImageButton(notebookAutomationAgent), "Button not found");
                    NotebookCommonMethods.ClickOnBackGroundButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyBackGroundImagePopup(notebookAutomationAgent), "Pop up not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyTheCountOfBackgrounds(notebookAutomationAgent), "count didnt match");
                    NotebookCommonMethods.ClickToChooseBackground(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyBackGroundImagePopup(notebookAutomationAgent), "Pop up found");
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedBackGroundOnNoteBook(notebookAutomationAgent), "Slected background not found");
                    NotebookCommonMethods.ClickOnBackGroundButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 500, 500);
                    Assert.IsFalse(NotebookCommonMethods.VerifyBackGroundImagePopup(notebookAutomationAgent), "Pop up found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23304)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToAddTable()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23304: Verify that user is able to view, select and add the table on the canvas."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifYToolMenuPopUp(notebookAutomationAgent), "Tool menu found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHeadingArea(notebookAutomationAgent), "Heading Area not found");
                    NotebookCommonMethods.VerifyRowsAndColumns(notebookAutomationAgent);
                    NotebookCommonMethods.VerfiyExpansionContractionButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23306)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToAddDeleteColumnsRows()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23306: Verify that User is able to re-size table to add/ remove rows/ columns."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    int rowscountnormal = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    NotebookCommonMethods.DragDownToIncreaseRows(notebookAutomationAgent);
                    int countafterdown = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue((countafterdown > rowscountnormal), "Fail due to handle is not dragged down");
                    int rowscount = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    NotebookCommonMethods.DragUpToDecreaseRows(notebookAutomationAgent);
                    int rowscountafterup = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue((rowscountafterup < rowscount), "Fail due to handle is not dragged up");
                    int columncountnormal = NotebookCommonMethods.GetCountOfColumns(notebookAutomationAgent);
                    NotebookCommonMethods.DragRightToIncreaseColumns(notebookAutomationAgent);
                    int columncountafterright = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue((columncountnormal < columncountafterright), "Fail due to handle is not dragged right");
                    int columncount = NotebookCommonMethods.GetCountOfColumns(notebookAutomationAgent);
                    NotebookCommonMethods.DragLeftToDecreaseColumns(notebookAutomationAgent);
                    int columncountafterleft = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue((columncountafterleft < columncount), "Fail due to handle is not dragged left");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23198)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStampOverlayFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23198: Verify Notebook Behavior while tapping on stamp tool"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStampButtonActive(notebookAutomationAgent), "Stamp BUtoon not active");
                    Assert.IsTrue(NotebookCommonMethods.VerifyStampOverlay(notebookAutomationAgent), "Stamp menu not found");
                    NotebookCommonMethods.VerifyDefaultItemSelectedInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolsshapeSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolLettersInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolLettersSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolObjectsInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolObjectSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolAnimalInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampWhenToolAnimalSelected(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnToolWeatherInStampOverlay(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampsWhenToolWeatherSelected(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyGradientInPopUp(notebookAutomationAgent), "Gradient not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24176)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDeletionOfStamp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24176: Verify deletion of stamp on notebook using hand tool."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToChooseStampCone(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found");
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23973)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTableToolAndSavedData()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23973: Verify Table Tool Save and Restore when multiple user logs into the app on the device."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 630, 400);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "TEST");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(notebookAutomationAgent, "TEST"), "Data is not saved");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 630, 400);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "DOCTOR");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(notebookAutomationAgent, "TEST"), "Data is not saved");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23972)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTableToolAndSavedDataForSingleUser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23972: Verify that when the user logs out and loges in back to app, previously entered table, data on same unit 's notebook same canvas page still persists."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 630, 400);
                    DateTime todaysdate = DateTime.Now;
                    string[] date = todaysdate.ToString().Split(' ');
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, date[0]);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(notebookAutomationAgent, date[0]), "Data is not saved");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(notebookAutomationAgent, date[0]), "Data is not saved");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24198)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserAbleToDeleteInteractiveFromNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24198: Verify that when the user comes back and relaunch the same notebook page again, the deleted interactive doesn't exists."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(notebookAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveInNotebook(notebookAutomationAgent), "Interactive not found");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyInteractiveInNotebook(notebookAutomationAgent), "Interactive found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyInteractiveInNotebook(notebookAutomationAgent), "Interactive found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23971)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySavedDataInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23971: Verify that when the user surfs around different browser in the app and comes to view the same unit's same notebook page, the table and the data entered on it are saved and restored."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 630, 400);
                    DateTime todaysdate = DateTime.Now;
                    string[] date = todaysdate.ToString().Split(' ');
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, date[0]);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(notebookAutomationAgent, date[0]), "Data is not saved");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(notebookAutomationAgent, date[0]), "Data is not saved");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(21987)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNotebookHandFLowFunctinality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC21987: Verify Notebook Hand FLow Functinality."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "TEST");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 770, 528);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Hand tool not active");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 330, 690);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxRegionFound(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyResizableDotsOfTextBox(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 330, 700);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(notebookAutomationAgent), "Keyboard not open.");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(21986)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAbilityOfUserToEditTextArea()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC21986: Verify the ability of the user to edit text area"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxRegionFound(notebookAutomationAgent), "Text box region not found");
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    string[] pos_before_swipe = NotebookCommonMethods.GetPositionOfTextBox(notebookAutomationAgent);
                    NotebookCommonMethods.DragTextBoxRightDot(notebookAutomationAgent, 100, 0);
                    string[] pos_after_swipe = NotebookCommonMethods.GetPositionOfTextBox(notebookAutomationAgent);
                    Assert.AreNotEqual(pos_before_swipe, pos_after_swipe, "Postion got match");
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(notebookAutomationAgent), "Keyboard not open.");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxRegionFound(notebookAutomationAgent), "Text box region found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23307)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTableCanMove()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23307:Verify tapping on red cancel button displaying on top-left of table, deletes the table."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableActive(notebookAutomationAgent), "Table not active after adding it to the canvas");
                    string[] pos_before_swipe = NotebookCommonMethods.GetPositionOfTable(notebookAutomationAgent);
                    NotebookCommonMethods.DragTable(notebookAutomationAgent);
                    string[] pos_after_swipe = NotebookCommonMethods.GetPositionOfTable(notebookAutomationAgent);
                    Assert.AreNotEqual(pos_before_swipe, pos_after_swipe, "Fail because table is not swipeed/dragged");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableActive(notebookAutomationAgent), "Fail because table found active after reopening notebook");
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos_after_swipe[0]), Int32.Parse(pos_after_swipe[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableActive(notebookAutomationAgent), "Fail because tapping on table is not done  ");
                    string[] pos_beforeswipe = NotebookCommonMethods.GetPositionOfTable(notebookAutomationAgent);
                    NotebookCommonMethods.DragTable(notebookAutomationAgent);
                    string[] pos_afterswipe = NotebookCommonMethods.GetPositionOfTable(notebookAutomationAgent);
                    Assert.AreNotEqual(pos_beforeswipe, pos_afterswipe, "Fail because table is not swipeed/dragged");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableDeleted(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22694)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyFunctionalityAndUINumberLineTool()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22694:  verify the functionality and UI of NUMBER LINE tool"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.VerifyGrabHandle(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    int count_before = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    NotebookCommonMethods.DragGrabHandleLeft(notebookAutomationAgent);
                    int count_after = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    Assert.AreEqual(count_before, count_after, "Count dont match");
                    int count = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    NotebookCommonMethods.DragGrabHandleRight(notebookAutomationAgent);
                    int count_after_right = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    Assert.AreNotEqual(count, count_after_right, "Count got match");
                    Assert.IsTrue(NotebookCommonMethods.VerifyMaximumSizeOfNumberLines(notebookAutomationAgent), "Number line tool not found");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23312)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToAddMultipleTables()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23312:Verify Table Tool State of table while adding multiple table at same time"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.DragTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    string[] pos = NotebookCommonMethods.GetPositionOfTable(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifyNoCancelButtonOnUnselectedTable(notebookAutomationAgent), "Cancel button On Unselected table");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23308)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToEnterText()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23308:Verify Table Tool Type or enter text on table"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.TapInsideHeadingArea(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserAbleToTypeInHeadingArea(notebookAutomationAgent), "Not able to type inside heading area");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.TapInsideColumnArea(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserAbleToTypeInColumnArea(notebookAutomationAgent), "Not able to type inside column area");
                    NotebookCommonMethods.TapInsideRowField(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserAbleToTypeInRowField(notebookAutomationAgent), "Not able to type inside column area");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24429)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToEnterTextAndAutoSuggestIsDisable()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24429: Verify User can enter text in table and auto suugest is disable"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    NotebookCommonMethods.TapInsideHeadingArea(notebookAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(notebookAutomationAgent), "Keyborad not open");
                    Assert.IsTrue(NotebookCommonMethods.VerifyUserAbleToTypeInHeadingArea(notebookAutomationAgent), "Not able to type inside heading area");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(notebookAutomationAgent), "Auto correct not enable");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(30104)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageNumberDisplayFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC30104: Verify the Page Number display functionality on Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int pagecount = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookPageNumberAtBottom(notebookAutomationAgent, pagecount), "Number not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyArrowsNotPresentInNotebookCanvas(notebookAutomationAgent), "Arrows found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBookLog(notebookAutomationAgent);
                    UnitSelectionCommonMethods.ClickOnAddBooklogButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookIconInBooklogPopup(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookPageNumberAtBottom(notebookAutomationAgent, pagecount));
                    NavigationCommonMethods.NavigateToHome(notebookAutomationAgent, 2);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }


                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(30102)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUndoFunctionalityOnNotebookCanvas()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC30102: Verify Undo functionality on Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    notebookAutomationAgent.SendText("DEVELOPER");
                    notebookAutomationAgent.ClickOnScreen(300, 300);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToGetTextBoxOverText(notebookAutomationAgent);
                    string[] pos_before_swipe = NotebookCommonMethods.GetPositionOfNoteBookTextRegion(notebookAutomationAgent);
                    NotebookCommonMethods.SwipeTextBox(notebookAutomationAgent, 500, 500);
                    string[] pos_after_swipe = NotebookCommonMethods.GetPositionOfNoteBookTextRegion(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    string[] pos_after_undo = NotebookCommonMethods.GetPositionOfNoteBookTextRegion(notebookAutomationAgent);
                    Assert.IsTrue(pos_before_swipe[0].Equals(pos_after_undo[0]) && pos_before_swipe[1].Equals(pos_after_undo[1]), "Postion didn't  match after doing undo");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    string[] pos_after_redo = NotebookCommonMethods.GetPositionOfNoteBookTextRegion(notebookAutomationAgent);
                    Assert.IsTrue(pos_after_redo[0].Equals(pos_after_swipe[0]) && pos_after_redo[1].Equals(pos_after_swipe[1]), "Postion didn't  match after doing redo");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "DEVELOPER"), "Data Saved Not Found");
                    NotebookCommonMethods.ClickOnBackGroundButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToChooseBackground(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedBackGroundOnNoteBook(notebookAutomationAgent), "Selected background not found");
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySelectedBackGroundOnNoteBook(notebookAutomationAgent), "Selected background found after undo");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedBackGroundOnNoteBook(notebookAutomationAgent), "Selected background not found after redo");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(44217)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUndoRedoActionsOnTableInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC44217: verify that Undo and Redo actions can be performed on the Table added on Notebook Canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    string[] pos = NotebookCommonMethods.GetPositionOfTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTableAdded(notebookAutomationAgent), "Table not found");
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(notebookAutomationAgent);
                    int rowscountnormal = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    NotebookCommonMethods.DragDownToIncreaseRows(notebookAutomationAgent);
                    int countafterdown = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    int countafterundo = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue(countafterundo.Equals(rowscountnormal), "Count got match");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    int countafterredo = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue(countafterredo.Equals(countafterdown), "Count got match");
                    NotebookCommonMethods.DragUpToDecreaseRows(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    int countafterundowhencontract = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue(countafterundowhencontract.Equals(countafterredo), "Count got match");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    int countafterredowhencontract = NotebookCommonMethods.GetCountOfRows(notebookAutomationAgent);
                    Assert.IsTrue(countafterredowhencontract.Equals(rowscountnormal), "Count got match");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24175)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEditingOfStamp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24175: Verify editing of stamp on notebook using hand tool."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToChooseStampCone(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found");
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    string[] pos_before_swipe = NotebookCommonMethods.GetPositionOfStamp(notebookAutomationAgent);
                    NotebookCommonMethods.DragStamp(notebookAutomationAgent);
                    string[] pos_after_swipe = NotebookCommonMethods.GetPositionOfStamp(notebookAutomationAgent);
                    Assert.IsFalse(pos_before_swipe[0].Equals(pos_after_swipe[0]) && pos_before_swipe[1].Equals(pos_after_swipe[1]), "Fail beacuse stamp didnt get swipped");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    notebookAutomationAgent.ClickOnScreen(Int32.Parse(pos_after_swipe[0]), Int32.Parse(pos_after_swipe[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found after returning back from different browsers");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    notebookAutomationAgent.ClickOnScreen(Int32.Parse(pos_after_swipe[0]), Int32.Parse(pos_after_swipe[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found after logging in back");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    notebookAutomationAgent.ClickOnScreen(Int32.Parse(pos_after_swipe[0]), Int32.Parse(pos_after_swipe[1]));
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found after logging in back when multiple users already logged in");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24413)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageSnapshotSwipethroughNotebookPages()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24413: Verify Page snapshot Swipe Through Notebook Pages"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNavigationArrowPresent(notebookAutomationAgent), "Navigation Arrow Not Present");
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.SwippingOfPages(notebookAutomationAgent);
                    int CountAfter = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(CountAfter.Equals(CountBefore - 1), "Page Count got match after swipping through the pages");
                    int CountBeforeNext = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.SwippingOfPages(notebookAutomationAgent);
                    int CountAfterNext = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(CountBeforeNext.Equals(CountAfterNext - 1), "Page Count got match after swipping through the pages");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(21886)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDisplayOfNotebookWRTNeighborNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC21886: Verify the display of notebooks and the neighboring notebooks"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    List<string> downloadedUnitsList = NavigationCommonMethods.GetDownloadedUnitList(notebookAutomationAgent);
                    Assert.IsTrue(downloadedUnitsList.Count.Equals(1), "Invalid because more than one units is downloaded");
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyOnlyOneNotebookDisplay(notebookAutomationAgent), "Fail if next and prev Notebook will display");
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookSharingIcon(notebookAutomationAgent), "Fail if notebook sharing icon will display");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookAddPageButton(notebookAutomationAgent), "Fail if notebook add page button does not display");
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24190)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLaunchingInteractiveFromNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24190: Verify Launching interactive from notebook."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(notebookAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(notebookAutomationAgent, 4);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(notebookAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(notebookAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickOnGoBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnIntercativeImageFromNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    InteractiveCommonMethods.VerifyBackButton(notebookAutomationAgent);
                    //InteractiveCommonMethods.VerifyInteractiveHeader(notebookAutomationAgent);
                    Assert.IsFalse(InteractiveCommonMethods.VerifySendToNotebookButton(notebookAutomationAgent), "Faile if Send to notebook button will display");

                    NavigationCommonMethods.ClickOnGoBackIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23880)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNotebookDataCreatedInOfflineMode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23880: Verify that notebook data created in offline mode in device 1 is saved and backed up by tapping on back button in notebook "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ChangeWiFiConnectivity(notebookAutomationAgent, true);
                    notebookAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Test");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Test"), "Fail if test is not saved in notebook");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(notebookAutomationAgent, false);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24197)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDeletingIntercativeSnapshotFromNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24197: Verify that User can delete interactive snapshot from Notebook canvas  "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(notebookAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(notebookAutomationAgent, 4);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(notebookAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(notebookAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToSelectIntercativeImageFromNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifySnapShotSendToNotebook(notebookAutomationAgent), "Fail if snapshot will still display");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31833)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCameraMicrophoneGalleryInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31833: Verify Page snapshot Swipe Through Notebook Pages"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyItemsInCameragalleryOverlay(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyItemsEnabledInMediaOverlay(notebookAutomationAgent), "Items are enabled in the overlay");
                    notebookAutomationAgent.ClickOnScreen(1000, 1000);
                    Assert.IsFalse(NotebookCommonMethods.VerifyMediaOverlay(notebookAutomationAgent), "Overlay found after click on the screen");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31812)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMiniPopUpInitialization()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31812: Verify Mini pop up intialization"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyItemsInCameragalleryOverlay(notebookAutomationAgent);
                    notebookAutomationAgent.ClickOnScreen(1000, 500);
                    NotebookCommonMethods.ClickOnBackGroundButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyBackgroundButtonActive(notebookAutomationAgent), "Button found active");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24410)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUpdatedSnapShot()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24410: Verify Updated snapshot of the notebook in notebook browser"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    notebookAutomationAgent.SendText("Pearson Systems");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUpdatedSnapShotOnNotebookBrwoser(notebookAutomationAgent, "Pearson Systems"), "Updated text not found on notebook browser");
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnBackGroundButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToChooseBackground(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyUpdatedBackgroundOnNotebookBrowser(notebookAutomationAgent), "Updated background not found");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23129)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBehaviourOfNumberLineTool()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23129: Verify the behaviour of Number Line tool when the handtool is selected"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 1000);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 500);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    string[] pos = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCrayonButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    NotebookCommonMethods.VerifyRemoveBUtton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToGetColorSelectionMenu(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyColorSelectionMenu(notebookAutomationAgent), "Color Selection Menu Not found");
                    int colornumber = NavigationCommonMethods.randomInteger(10);
                    string color_selected = NotebookCommonMethods.GetColorToBeselected(notebookAutomationAgent, colornumber);
                    NotebookCommonMethods.ClickOntheColor(notebookAutomationAgent, colornumber);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedColorInNumberLineTool(notebookAutomationAgent, color_selected), "Selected color is not correct");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31611)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRedoFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31611: Verify Redo  functionality on Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 1000);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 500);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    int count = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    int countafterundo = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    int countafterredo = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int countaftercomingback = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsTrue(countafterredo.Equals(countaftercomingback), "Count didnt match after coming back to notebook after doing redo");
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    int countaferaddingchanges = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int countafer = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsTrue(countafer.Equals(countaferaddingchanges), "Count didnt match after coming back to notebook after adding changes");
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    Assert.IsTrue(countafer.Equals(countaferaddingchanges), "Chnages are done after doing undo");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23199)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnLeftColumnOfStamp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23199: Verify that Tapping any stamp on left column has no effect."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Testing");
                    NavigationCommonMethods.CloseDeviceKeyboard(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnLeftColumnOfStamp(notebookAutomationAgent);
                    NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Testing");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23201)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyColorSelectorReflectSameColorOnStamp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23201: Verify that Stamp tool selected state will reflect same color as indicated in color selector."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnColorSelector(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRedColorSelector(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRedColorOnStamp(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnLeftColumnOfStamp(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31823)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCameraFeatures()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31823: Verify Camera Feature"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyCameraIconWhenCameraOpen(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyCrossMarkIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUserOnNOtebookCanvas(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyCroppingArea(notebookAutomationAgent);
                    UnitSelectionCommonMethods.VerifyOptionsWhenPhotoCaptured(notebookAutomationAgent);
                    string pos = NotebookCommonMethods.GetpositionOfResizableBorder(notebookAutomationAgent);
                    NotebookCommonMethods.DragToCropThePhoto(notebookAutomationAgent, 500, 1000);
                    string pos_after_drag = NotebookCommonMethods.GetpositionOfResizableBorder(notebookAutomationAgent);
                    Assert.IsTrue(!pos.Equals(pos_after_drag), "Positon got match after resizing the cropping area");
                    NavigationCommonMethods.ClickOnCrossButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUserOnNOtebookCanvas(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31826)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyResizeAndDraggingOfSnapshot()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31826: verify that user is able to resize and drag the snapshot added to canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(notebookAutomationAgent);
                    string[] pos_before_resize = NotebookCommonMethods.GetPositionOfImage(notebookAutomationAgent);
                    string pos = NotebookCommonMethods.GetPositonOfResizableDotOfImageInNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.DragTextBoxRightDot(notebookAutomationAgent, 500, 500);
                    string pos_after = NotebookCommonMethods.GetPositonOfResizableDotOfImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(!pos.Equals(pos_after));
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos_before_resize[0]), Int32.Parse(pos_before_resize[1]));
                    string pos_after_saving = NotebookCommonMethods.GetPositonOfResizableDotOfImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(pos_after_saving.Equals(pos_after));
                    NotebookCommonMethods.DragImage(notebookAutomationAgent, 100, 100);
                    string pos_after_drag = NotebookCommonMethods.GetPositonOfResizableDotOfImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(!pos_after_drag.Equals(pos_after));
                    string[] pos_before_saving = NotebookCommonMethods.GetPositionOfImage(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos_before_saving[0]), Int32.Parse(pos_before_saving[1]));
                    string pos_after_saving_again = NotebookCommonMethods.GetPositonOfResizableDotOfImageInNotebook(notebookAutomationAgent);
                    Assert.IsTrue(pos_after_drag.Equals(pos_after_saving_again));
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31827)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyChangesSavedOnNotebookCanvas()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31827: Verify that tapping back hand saves the changes made on canvas"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    int count_before = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    NotebookCommonMethods.DragGrabHandleRight(notebookAutomationAgent);
                    int count_after = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    Assert.AreNotEqual(count_before, count_after, "Count dont match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    string[] pos = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    int count_after_saving = NotebookCommonMethods.GetCountOfNumberLines(notebookAutomationAgent);
                    Assert.AreEqual(count_after, count_after_saving, "Count dont match");
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 100);
                    string[] pos_after_drag = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, Int32.Parse(pos_after_drag[0]), Int32.Parse(pos_after_drag[1]));
                    string[] pos_aftersaving = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    Assert.AreEqual(Int32.Parse(pos_after_drag[0]), Int32.Parse(pos_aftersaving[0]), "Count dont match");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(44548)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAnnotationLayerOnTopOfStudentNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC44548: Verify that Transparent annotation layer on top of student notebook page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(notebookAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOnNotebook(notebookAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(notebookAutomationAgent, 2);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31825)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySnapShotViewOnCanvas()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31825: Verify Snapshot view on canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    Assert.IsFalse(NotebookCommonMethods.VerifyDottedLinePresent(notebookAutomationAgent), "Dotted lines are present around snapshot");
                    NotebookCommonMethods.VerifyResizableDotsOfTextBox(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(notebookAutomationAgent), "Photo found after deleting");
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(notebookAutomationAgent);
                    NotebookCommonMethods.DragImage(notebookAutomationAgent, 500, 500);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(notebookAutomationAgent);
                    NotebookCommonMethods.DragImage(notebookAutomationAgent, 200, 0);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickonCamerabutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCameraIconInBookLogCameraMode(notebookAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyMultipleImagesInNotebook(notebookAutomationAgent), "Multiple images not found in notebook");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(30103)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClearAllFunctionalityOnNotebookCanvasPage()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC30103: Verify ClearAll functionality on Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 1000);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    int count = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyClearAllPopUpElements(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCancelButton(notebookAutomationAgent);
                    int countaftercancel = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsTrue(count.Equals(countaftercancel), "Count didnt match after tapping on the cancel button");
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    int countafterclearing = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsFalse(count.Equals(countafterclearing), "Count  match after clearing all on the notebook canvas");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int countaftercomingtonotebookcanvas = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 1000);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    int countafteraddingtables = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    int countafterclearingall = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsTrue(countaftercomingtonotebookcanvas.Equals(countafterclearingall), "Count  match after clearing all on the notebook canvas");
                    NotebookCommonMethods.ClickToRedo(notebookAutomationAgent);
                    int countafterredo = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsTrue(countafterclearingall.Equals(countafterredo), "Count  match after clearing all on the notebook canvas");
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(notebookAutomationAgent, 0, 1000);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToUndo(notebookAutomationAgent);
                    int countafterundo = NotebookCommonMethods.GetCountOfNumberLineTable(notebookAutomationAgent);
                    Assert.IsTrue(count.Equals(countafterundo), "Count  match after clearing all on the notebook canvas");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(notebookAutomationAgent, 1);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(31824)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPhotoAdded()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC31824: Verify Photo has been added to canvas from gallery"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPhotoGalleryButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCameraRoll(notebookAutomationAgent);
                    NotebookCommonMethods.ChoosePictureFromGallery(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyCroppingArea(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(notebookAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPhotoGalleryButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnCameraRoll(notebookAutomationAgent);
                    NotebookCommonMethods.ChoosePictureFromGallery(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUserOnNOtebookCanvas(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24172)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStampToolBehaviourWhenSelectingTheColor()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24172: Verify the stamp tool behavior while selecting the color and using the stamp tool. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnColorSelector(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnRedColorSelector(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRedColorOnStamp(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyStampOverlayPopUp(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23893)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySendingIntercativeToNotebookFromBackpack()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23893: Verify whether the user is able to open an interactive from Back pack and save that to notebook. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillIntercative(notebookAutomationAgent);
                    BackPackCommonMethods.DragInteractiveToBackPack(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(notebookAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackInteractive(notebookAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(notebookAutomationAgent);
                    InteractiveCommonMethods.VerifyUIelementsOfInteractive(notebookAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    InteractiveCommonMethods.VerifyUIElementsOfSendToNotebookPopUp(notebookAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(notebookAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(notebookAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(notebookAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(notebookAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnGoBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23239)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySaveStateOfNumberLineTool()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23239: verify that tapping on back button will  save and restore coordinates and colors of number line tools."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    string[] pos = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToGetColorSelectionMenu(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    //int colornumber = NavigationCommonMethods.randomInteger(10);
                    string color_selected = NotebookCommonMethods.GetColorToBeselected(notebookAutomationAgent, 3);
                    NotebookCommonMethods.ClickOntheColor(notebookAutomationAgent, 3);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedColorInNumberLineTool(notebookAutomationAgent, color_selected), "Color selected not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    string[] pos_after_back = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    Assert.IsTrue(pos[0].Equals(pos_after_back[0]) && pos[1].Equals(pos_after_back[1]), "Coordinates not match after coming back");
                    notebookAutomationAgent.Sleep(5000);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedColorInNumberLineTool(notebookAutomationAgent, color_selected), "Color selected not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    string[] pos_after_back_from_browser = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    Assert.IsTrue(pos[0].Equals(pos_after_back_from_browser[0]) && pos[1].Equals(pos_after_back_from_browser[1]), "Coordinates not match after coming back");
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedColorInNumberLineTool(notebookAutomationAgent, color_selected), "Color selected not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    string[] pos_after_logout = NotebookCommonMethods.GetPositionOfNumberLineTool(notebookAutomationAgent);
                    Assert.IsTrue(pos[0].Equals(pos_after_logout[0]) && pos[1].Equals(pos_after_logout[1]), "Coordinates not match after coming back");
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedColorInNumberLineTool(notebookAutomationAgent, color_selected), "Color selected not found");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22506)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedDataOnNotebookFromTeacherAndStudentAfterKillingApp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22506:Verify data is saved on notebook from teacher and student login"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Doctor");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    notebookAutomationAgent.ApplicationClose();
                    notebookAutomationAgent.Sleep();
                    notebookAutomationAgent.LaunchApp();
                    notebookAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Doctor"), "Data Saved Found");
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    BookBuilderCommonMethods.SendText(notebookAutomationAgent, "Teacher");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    notebookAutomationAgent.CloseApplication();
                    notebookAutomationAgent.Sleep();
                    notebookAutomationAgent.LaunchApp();
                    notebookAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "Teacher"), "Data Saved Found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(26297)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNotebookAudioToolOptionsAndOrder()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC26297: Verify notebook audio tools options and its order. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyMediaIconsOrder(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23895)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInteractiveAddedAsANotebookNewPage()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC23895: Verify that Each interactive added to fresh new page on notebook "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickUntillCurrentPageNotDisplay(notebookAutomationAgent);
                    int PageLabel = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(notebookAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int PageLabelAfterSendingInteractive = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(PageLabel < PageLabelAfterSendingInteractive, "Fail as new added interactive does not added in new notebook");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22188)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyFlowWrappingAroundTwoNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22188: Verify the display of notebooks and the neighboring notebooks when multiple books are downloaded "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRightNotebookBleeding(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyLeftNotebookBleeding(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(22523)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnNeighboreNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC22523: Verify tapping of neighboring notebooks when multiple books are downloaded "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int currentUnitNumber = MediaLibraryCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRightNotebookBleeding(notebookAutomationAgent);
                    int currentUnitNumberAfterTappingOnNext = MediaLibraryCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent);
                    Assert.IsTrue(currentUnitNumber < currentUnitNumberAfterTappingOnNext, "Fail if next unit is not clikable");
                    NotebookCommonMethods.VerifyLeftNotebookBleeding(notebookAutomationAgent);
                    int currentUnitNumberAfterTappingOnPrev = MediaLibraryCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent);
                    Assert.IsTrue(currentUnitNumberAfterTappingOnPrev < currentUnitNumberAfterTappingOnNext, "Fail if previous unit is not clickable");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(27008)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLastPageViewedPosition()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC27008:  verify that Last page viewed on Unit's Notebook in the Notebook Browser will be retained; when user returns to Notebook Browser."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int count = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, CountBefore);
                    Assert.IsTrue(CountBefore.Equals(count), "Page Count didn't match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);

                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, "2");
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int count1 = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int count2 = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, count1);
                    Assert.IsTrue(count1.Equals(count2), "Page Count didn't match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count3 = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int count4 = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, Count3);
                    Assert.IsTrue(Count3.Equals(count4), "Page Count didn't match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnGraphicTool(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count5 = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int count6 = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, Count5);
                    Assert.IsTrue(Count5.Equals(count6), "Page Count didn't match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);

                    notebookAutomationAgent.CloseApplication();
                    notebookAutomationAgent.Sleep();
                    notebookAutomationAgent.LaunchApp();
                    notebookAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count7 = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    int count8 = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, Count5);
                    Assert.IsTrue(Count7.Equals(count8), "Page Count didn't match");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(45785)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNotebookBrowserUI()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC45785: Verify that Wood Background, Notebook Background, Page Number and Buttons, Add Page Button and Bleeding Edge Width are as per Specs and Assets provided"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookWoodBackground(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNoteBookPageNumber(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookAddPageButton(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyLeftNotebookBleeding(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRightNotebookBleeding(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(20829)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBleedingNotebooksWhileSwiping()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20829: Verify that while swiping towards Right on the notebook browser will display Previous numerical notebook in focus, where as while swiping towards left on the notebook browser will display Next numerical notebook in focus."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyNextNumericalNotebook(notebookAutomationAgent), "Next numerical unit got found");
                    NotebookCommonMethods.ClickRightNotebookBleeding(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNextNumericalNotebook(notebookAutomationAgent), "Next numerical unit not found");
                    NotebookCommonMethods.ClickLeftNotebookBleeding(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPreviousNumericalNotebook(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(notebookAutomationAgent, "0");//NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyNextNumericalNotebookInMAthUnit(notebookAutomationAgent), "Next numerical unit got found");
                    NotebookCommonMethods.ClickRightNotebookBleeding(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNextNumericalNotebookInMAthUnit(notebookAutomationAgent), "Next numerical unit not found");
                    NotebookCommonMethods.ClickLeftNotebookBleeding(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPreviousNumericalNotebookInMathUnit(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(20503)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitMedallionChangeAccordingToNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20503: Verify that tapping on the left/right side bleeding notebooks should get those notebook into focus - Tapping on the notebook on the right/left scrolls the corresponding notebook to focus."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyNextNumericalNotebook(notebookAutomationAgent), "Next numerical unit got found");
                    NotebookCommonMethods.ClickLeftNotebookBleeding(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNextNumericalNotebook(notebookAutomationAgent), "Next numerical unit not found");
                    NotebookCommonMethods.ClickRightNotebookBleeding(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPreviousNumericalNotebook(notebookAutomationAgent));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24411)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageSnapshotInNOtebookBrowserAndNotebookCanvas()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24411: Verify Page snapshot and the number in the notebook canvas and the browser also."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    notebookAutomationAgent.SendText("TESTING");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 770, 528);
                    int countinnotebook = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(notebookAutomationAgent, CountBefore);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "TESTING"), "Saved data not found");
                    Assert.IsTrue(countinnotebook.Equals(CountBefore), "Page Count didn't match");
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnPlusButtonInNotebookEditor(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int Countafteraddingpage = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(CountBefore.Equals(Countafteraddingpage - 1), "Page Count didnt match after adding page in notebook editor");
                    int Countbeforaddingpageinnotebookbrowser = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int Countafteraddingpageinnotebookbrowser = NotebookCommonMethods.GetPositionOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(Countafteraddingpageinnotebookbrowser.Equals(Countbeforaddingpageinnotebookbrowser + 1), "Page Count didnt match after adding page from notebook browser");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(20831)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayofBleedingNotebooksForMathANdELA()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC20831: Verify the display of notebooks and the neighboring notebooks when multiple books are downloaded "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyRightNotebookBleeding(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyLeftNotebookBleeding(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(notebookAutomationAgent, "0");//NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NotebookCommonMethods.VerifyRightNotebookBleeding(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyLeftNotebookBleeding(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24174)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBehaviourOfSTamp()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24174: Verify behavior while tapping anywhere on the canvas after selecting the stamp from stamp overlay. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickToChooseStampCone(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found");
                    NotebookCommonMethods.ClickOnStampButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStampButtonActive(notebookAutomationAgent), "Stamp button not active");
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStampButtonActive(notebookAutomationAgent), "Stamp button  active");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found after returning back from different browsers");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found after logging in back");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(notebookAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(notebookAutomationAgent), "Dashed line not found after logging in back when multiple users already logged in");
                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(24412)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageSnapshotInNOtebookBrowser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC24412: Snapshots for notebook pages will be saved locally and visible when user logs out, back in and returns to notebook browser."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.WaitforElement("NotebookView", "AddIconInNotebookBrowser", "", WaitTime.SmallWaitTime);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    notebookAutomationAgent.SendText("TESTING");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 770, 528);

                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "TESTING"), "Saved data not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.WaitforElement("NotebookView", "AddIconInNotebookBrowser", "", WaitTime.SmallWaitTime);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "TESTING"), "Saved data not found");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(notebookAutomationAgent, "0"); //NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.WaitforElement("NotebookView", "AddIconInNotebookBrowser", "", WaitTime.SmallWaitTime);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    notebookAutomationAgent.SendText("Another Unit");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 770, 528);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.WaitforElement("NotebookView", "AddIconInNotebookBrowser", "", WaitTime.SmallWaitTime);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "TESTING"), "Saved data not found");
                    LoginCommonMethods.Logout(notebookAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.WaitforElement("NotebookView", "AddIconInNotebookBrowser", "", WaitTime.SmallWaitTime);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "TESTING"), "Saved data not found");


                    NotebookCommonMethods.ClickOnClearAllButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(notebookAutomationAgent);
                    notebookAutomationAgent.SendText("KillTheApp");
                    NavigationCommonMethods.TapOnScreen(notebookAutomationAgent, 770, 528);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    notebookAutomationAgent.Sleep();
                    notebookAutomationAgent.ApplicationClose();
                    notebookAutomationAgent.Sleep();
                    notebookAutomationAgent.LaunchApp();
                    notebookAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    notebookAutomationAgent.WaitforElement("NotebookView", "AddIconInNotebookBrowser", "", WaitTime.SmallWaitTime);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(notebookAutomationAgent, "KillTheApp"), "Saved data not found");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(44918)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnXButtonForNotebookAudioButton()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC44918: Verify that notebook audio icon can be removed from the canvas by tapping the top left X button."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnAudionIcon(notebookAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyReviewRecordButton(notebookAutomationAgent), "Fail if Recording tool does not display");
                    LoginCommonMethods.CloseErrorPopUp(notebookAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyReviewRecordButton(notebookAutomationAgent), "Fail if Recording tool display");
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(44916)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyProgressBarWhileAudioPlaying()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC44916: Verify that tapping on the audio player icon,audio plays and tapping again audio icon stops the audio. Also, no progress bar is displayed when audio is getting played."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnMediaButton(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnAudionIcon(notebookAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(notebookAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyProgressLabelWhileRecording(notebookAutomationAgent), "Fail if progress label will not display");
                    InboxCommonMethods.ClickOnRecordButton(notebookAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyProgressLabelWhileRecording(notebookAutomationAgent), "Fail if progress label will display");
                    LoginCommonMethods.CloseErrorPopUp(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(29953)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddOrCancelAddingPage()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC29953: Verify that when the user tries to add the page to unit Notebook, styled prompt message displays giving an option to user whether to add or cancel adding page."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(notebookAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(notebookAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(notebookAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(notebookAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(notebookAutomationAgent);
                    int Count = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyUIofAddPagePopup(notebookAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(notebookAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(notebookAutomationAgent);
                    int countafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(notebookAutomationAgent);
                    Assert.IsTrue(countafteraddition.Equals(Count + 1), "The page count didnt match");
                    LoginCommonMethods.Logout(notebookAutomationAgent);
                }

                catch (Exception ex)
                {
                    notebookAutomationAgent.Sleep(2000);
                    notebookAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    notebookAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

    }
}
