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
    public class InteractiveTest
    {
        public AutomationAgent InteractiveAutomationAgent;

        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(19571)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIelementsofInteractive()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC19571: Verify the UI elements of Interactive Player"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyUIelementsOfInteractive(InteractiveAutomationAgent));
                    Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveHeader(InteractiveAutomationAgent), "Interactive header not found");
                    Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookButton(InteractiveAutomationAgent));
                    InteractiveCommonMethods.VerifyBodyOfInteractive(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(19573)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInteractiveSavedState()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC19573: Verify whether the interactive saved when the Back hand icon is tapped, validate this by opening the same interactive again from the same lesson"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    int dragableElementCount = InteractiveCommonMethods.GetDragableElementCount(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    InteractiveAutomationAgent.Sleep();
                    Assert.IsTrue(InteractiveCommonMethods.VerifyDraggableElement(InteractiveAutomationAgent, dragableElementCount), "Fail when element is not in saved state");
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(20419)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInteractiveSavedStateOfDifferentLessonAndUnitForTeacher()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC20419: Verify that user's work is saved and retained when interactive is opened from Today shelf for Teacher"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(InteractiveAutomationAgent, 5);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    int dragableElementCount = InteractiveCommonMethods.GetDragableElementCount(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(InteractiveAutomationAgent, 5);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    InteractiveAutomationAgent.Sleep();
                    Assert.IsTrue(InteractiveCommonMethods.VerifyDraggableElement(InteractiveAutomationAgent, dragableElementCount), "Fail when element is not in saved state");
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, "G-I");
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(InteractiveAutomationAgent, 3);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyDraggableElement(InteractiveAutomationAgent, dragableElementCount), "Fail when element is not in saved state");
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(31645)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInteractiveThumbnailIsInSelectedState()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC31645: Verify that Thumbnail is in selected state when Interactive is send to notebook when opened from Today's Shelf and user is taken to Notebook Canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(InteractiveAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(InteractiveAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyThumbnailSelectedState(InteractiveAutomationAgent), "Fail if thumbnail is not in slected state");
                    NavigationCommonMethods.ClickOnBackIcon(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(29961)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifTimeStampRemovedFromInteractive()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC29961: Verify that when the interactive is added to notebook, the file name and timestamp information below the interactive thumbnail DOES NOT exist"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(InteractiveAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(InteractiveAutomationAgent);
                    InteractiveCommonMethods.VerifyTimeStampDoenNotExistBelowSnapshot(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(23897)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifConfirmationPopupWhileAddingInteractiveToNotebook()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC23897: Verify that confirmation pop-up while adding interactive to notebook. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(InteractiveAutomationAgent);
                    InteractiveCommonMethods.VerifySendtoNotebookConfirmationPopup(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("InteractiveTest")]
        [WorkItem(45763)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifIntercativeSuspendAllItsActivity()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC45763: Verify that interactives will suspend all its activity when the app goes into the background and resume activity in paused state when the app returns into the foreground. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(InteractiveAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(InteractiveAutomationAgent);
                    InteractiveAutomationAgent.Sleep(3000);
                    InteractiveAutomationAgent.SendText("{HOME}");
                    InteractiveAutomationAgent.LaunchApp();
                    InteractiveAutomationAgent.Sleep();
                    Assert.IsTrue(InteractiveCommonMethods.VerifyGamePausedCanvas(InteractiveAutomationAgent), "Game paused popup doesn't appear");
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NotebookTest")]
        [WorkItem(23341)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySendingIntercativeToNotebookFromMediaLibrary()
        {
            using (InteractiveAutomationAgent = new AutomationAgent("TC23341: Verify whether the user is able to open an interactive from Media Library and save that to notebook. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(InteractiveAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(InteractiveAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(InteractiveAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(InteractiveAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenInteractive(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    InteractiveCommonMethods.VerifyUIelementsOfInteractive(InteractiveAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(InteractiveAutomationAgent);
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveCommonMethods.VerifyUIElementsOfSendToNotebookPopUp(InteractiveAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(InteractiveAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(InteractiveAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(InteractiveAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(InteractiveAutomationAgent);
                    InteractiveAutomationAgent.Sleep(5000);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(InteractiveAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(InteractiveAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnGoBackIcon(InteractiveAutomationAgent);
                    LoginCommonMethods.Logout(InteractiveAutomationAgent);
                }

                catch (Exception ex)
                {
                    InteractiveAutomationAgent.Sleep(2000);
                    InteractiveAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    InteractiveAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

    }
}
