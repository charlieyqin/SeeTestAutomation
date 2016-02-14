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
    public class TeacherModeTest
    {
        public AutomationAgent TeacherModeAutomationAgent;

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(22)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherModeCriticalFunctionalities1()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("MTC22: Verify whether the TEACHER MODE frame is CLOSED when the SYSTEM TRAY icon is tapped from Navigation bar"))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode should open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDefaultTabOpened(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24227", true);

                    //TC24230 & TC20324 & TC20330
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterGetSelected(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnShowPasswordForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentSec01"));
                    TeacherModeCommonMethods.VerifyShowPasswordPopupForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentSec01"));
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20330", true);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterOpen(TeacherModeAutomationAgent), "My class roster not open.");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20324", true);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesGetSelected(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24230", true);


                    //TC19819
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(TeacherModeAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, getTeacherModeWidthAfterExpand > getTeacherModeWidthBeforeExpand);
                    NavigationCommonMethods.ClickToExpandTeacherMode(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(TeacherModeAutomationAgent);
                    int getTeacherModeWidthWhenNotebookBrowserOpen = TeacherModeCommonMethods.GetTeacherModeBarWidth(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, getTeacherModeWidthAfterExpand > getTeacherModeWidthWhenNotebookBrowserOpen);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC19819", true);

                    //TC19816 & TC19563
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyUserOnUnitHomeWithTeacherMode(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC19816", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC19563", true);
                    
                    //TC24369
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Doctor");
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24369", true);

                    //TC19817
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMediaLibraryOpenWithTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC19817", true);
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(false, TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode should close");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC19810", true);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyLessonNotesButton(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24434", true);
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(19816)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyToOpenTodaysShelfWhenTeacherModeEnabled()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC19816:Verify whether the teacher is able to OPEN TODAYS SHELF from UNIT HOME SCREEN when the Teacher mode is ENABLED"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(19817)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyToOpenMediaLibraryWhenTeacherModeOn()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC19817:Verify whether the teacher is able to OPEN MEDIA LIBRARY when the Teacher mode is ENABLED"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMediaLibraryOpenWithTeacherMode(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(19819)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherExpandedViewClosedAfterNotebookOpen()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC19819:Verify whether Teacher mode EXPANDED VIEW is closed if the user taps on  NOTEBOOK ICON"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(TeacherModeAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, getTeacherModeWidthAfterExpand > getTeacherModeWidthBeforeExpand);
                    NavigationCommonMethods.ClickOnNotebookBrowser(TeacherModeAutomationAgent);
                    int getTeacherModeWidthWhenNotebookBrowserOpen = TeacherModeCommonMethods.GetTeacherModeBarWidth(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, getTeacherModeWidthAfterExpand > getTeacherModeWidthWhenNotebookBrowserOpen);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(19563)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyToOpenUnitHomeFromTeacherMode()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC19563: Verify whether the teacher is able to OPEN UNIT HOME SCREEN when the Teacher mode is ENABLED"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyUserOnUnitHomeWithTeacherMode(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(26)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherModeImportantFunctionalities1()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("MTC26: Verify student roster in Teacher Mode and for current teacher it should be scrollable list"))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenu(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, "1"));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20458", true);
                    TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDefaultTabOpened(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyClassRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, "1");

                    TeacherModeCommonMethods.VerifyMyLessonNotesButton(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24234", true);
                    TeacherModeCommonMethods.VerifyMyClassRosterButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaOpenInWhiteRectangularArea(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaBelowShrinkApp(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24223", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24224", true);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDisabled(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDisabled(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDisabled(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24433", true);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent), "Verify if todayshelf is open");
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson), "Verify if Lesson Overview display");
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyLessonNumberInTeacherMode(TeacherModeAutomationAgent, randLesson));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20461", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20462", true);
                    TeacherModeCommonMethods.VerifyNotesAvailableInMyLessonNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20302", true);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyClassRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyScrollableStudentRoster(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC22051", true);
                    TeacherModeCommonMethods.VerifyStudentNameAndAvatar(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20323", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24235", true);
                    TeacherModeCommonMethods.VerifyStudentNameSorting(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC29966", true);
                    TeacherModeCommonMethods.ClickOnStudent(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyShowPasswordButton(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20326", true);
                    NavigationCommonMethods.ClickOnShowPasswordForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentSec01"));
                    TeacherModeCommonMethods.VerifyShowPasswordPopupForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentSec02"));
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 1000, 500);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC27049", true);
                    TeacherModeCommonMethods.ClickOnNonSetUpStudent(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyShowPasswordButton(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnShowPasswordForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentSec01"));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyShowPasswordPopupForNonSetupStudent(TeacherModeAutomationAgent), "Show Password popup should open");
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyShowPasswordPopupForNonSetupStudent(TeacherModeAutomationAgent), "Show Password popup closed");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC27050", true);
                    TeacherModeCommonMethods.VerifyUserOnUnitHomeWithTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20331", true);
                    TeacherModeCommonMethods.CLickOnMyLessonNotesButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyCreateNotesUI(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Doctor");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent), "Keyboard not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnformattedTextInTheBoxAndIsScrollable(TeacherModeAutomationAgent), "Not scrollbale");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24357", true);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24354", true);
                    TeacherModeCommonMethods.VerifyNotesAvailableInMyLessonNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, 7);
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyEditNotesUI(TeacherModeAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent), "Keyboard not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnformattedTextInTheBoxAndIsScrollable(TeacherModeAutomationAgent), "Not scrollbale");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24349", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24364", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24363", true);                
                    
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(27)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherModeImportantFunctionalities2()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("MTC27: Verify student roster in Teacher Mode and for current teacher it should be scrollable list"))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Teacher guide flyout panel not found");
                    TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenu(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent)));
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToCloseTeacherGuidePanel(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyClassRosterButton(TeacherModeAutomationAgent), "My class roster button found");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open");
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson), "Lesson overview not found");
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonGuide(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonGuideOpen(TeacherModeAutomationAgent), "Lesson overview not found");
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open after tapping on system tray");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Flyout found after tapping on system tray");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24397", true);
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 1000, 1000);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAppFullscreenView(TeacherModeAutomationAgent), "App not open in full screen");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open after tapping on app expand button");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Flyout found after tapping on app expand button");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyClassRosterButton(TeacherModeAutomationAgent), "My class roster button found");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24398", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20775", true);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);                    
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(29966)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySortingOfStudentInRoster()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC29966: Verify that in Teacher mode, student roster is sorted by the students first name"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyStudentNameSorting(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(27049)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyShowPasswordPopupForSetUpStudent()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC27049: For Picture password setup student, Verify that Show Password pop-up "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyShowPasswordButton(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnShowPasswordForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    TeacherModeCommonMethods.VerifyShowPasswordPopupForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 1000, 500);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(27050)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyShowPasswordPopupForNonSetUpStudent()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC27050: Verify that if student does not have a Picture Password, pop-up displays message indicating that password is not set up "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnShowPasswordForNonSetupStudent(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyShowPasswordPopupForNonSetupStudent(TeacherModeAutomationAgent), "Show Password popup should open");
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyShowPasswordPopupForNonSetupStudent(TeacherModeAutomationAgent), "Show Password popup closed");
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
        //Duplicate of 

       /* [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(27001)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentRosterOfflineMessage()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC27001: Verify Student roster offline message You must be connected to the internet to retrieve the class roster"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                    TeacherModeAutomationAgent.LaunchApp();
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyOfflineErrorMessage(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

    /*    [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20458)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitOverviewWhenTeacherModeOpened()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20458: Verify that  unit overview is displayed in teacher pane when  teacher mode is enabled from home screen "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent)));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTest"), TestCategory("K1SmokeTests")]
        [WorkItem(20461)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLessonOverviewWhenTodayShelfOpened()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20461: Verify that when today activity shelf is visible, relevant lesson overview is displayed in right pane. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    Assert.AreEqual<bool>(false, UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent), "Verify if todayshelf is not open");
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(8);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    Assert.AreEqual<bool>(true, UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent), "Verify if todayshelf is open");
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson), "Verify if Lesson Overview display");
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20462)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAppropriateLessonGetRefreshedInTeacherMode()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20462: Verify that on tapping Next/Previous arrow of lesson, the appropriate contnet of lesson should get refreshed in right pane"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int selectAnyLesson = NavigationCommonMethods.randomInteger(10);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, selectAnyLesson);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyLessonNumberInTeacherMode(TeacherModeAutomationAgent, selectAnyLesson));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24223)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNotesAreaDisplayedInWhiteRectangularArea()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24223: Verify that when the Teacher Guide Panel is opened, the Notes area is displayed in the white rectangular area below the shrunken app screen."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaOpenInWhiteRectangularArea(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyNotesAreaBelowShrinkApp(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
       /* [TestMethod()]
        [TestCategory("TeacherModeTest"), TestCategory("K1SmokeTests")]
        [WorkItem(24224)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNotesSectionContainsTwoHeader()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24224: Verify that the notes section contains two headers"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyLessonNotesButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyClassRosterButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
    /*    [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24227)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMyLessonNotesIsDefaultTabOpened()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24227: Verify that in the notes section, My Lesson Notes will be the default tab opened"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDefaultTabOpened(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24230)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyToggleBetweenButtonInSectionHeader()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24230: Verify that the Teachers can toggle between the Class Roster and the Notes view by tapping on either section name in the section header."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterGetSelected(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesGetSelected(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24234)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMessageWhenThereIsNoNotesAvailable()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24234: Verify that when no notes for the Lesson exist, an instructional message should be displayed. Tap here to add notes for this lesson."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24433)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMyLessonNotesIsDisableOnGivenScreens()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24433: verify that My Lesson Notes is disabled when unit-level content is being shown (Today Home, Media Library, Notebook)"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDisabled(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDisabled(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDisabled(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24434)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMyLessonNotesHidesAfterSystemTrayOpen()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24434: verify that My Lesson Notes is hidden when user taps on System Tray"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyLessonNotesButton(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherModeOfflineCriticalFunctionalities3()
            {
            using (TeacherModeAutomationAgent = new AutomationAgent("MTC24:verify that My Lesson Notes is displayed when user opens it in Offline mode and switches between Class Roaster and My Lesson Notes"))
            {
                try
                {                 
                    
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent,"TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
					
					TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterOpen(TeacherModeAutomationAgent), "My class roster not open.");
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(TeacherModeAutomationAgent);
					
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                    TeacherModeAutomationAgent.LaunchApp();
					
					NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    
					
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterGetSelected(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesGetSelected(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyOfflineErrorMessage(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24435", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC20332", true);

                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
         }
      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24435)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserSwitchBetweenMyLessonNotesAndMyClassRoster()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24435:verify that My Lesson Notes is displayed when user opens it in Offline mode and switches between Class Roaster and My Lesson Notes"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                    TeacherModeAutomationAgent.LaunchApp();
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterGetSelected(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesGetSelected(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyOfflineErrorMessage(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
       /* [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24369)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyKeyBoardAndAddNoteOverlayDismissAfterHittingCrossIcon()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24369: verify that On tap, the close button will dismiss the keyboard and Edit Note Overlay without saving any changes or newly inputted text."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Doctor");
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24370)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyChangesSavedAFterHittingDoneButton()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24370: verify On tap, the Done Button will save the changes or newly inputted text and dismiss the overlay and keyboard. The saved text will be displayed in the My Lesson Notes section's canvas."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    string texttosave = "Doctor";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttosave);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttosave));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(23)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherModeCriticalFunctionalities2()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("MTC23: Verify that on tap, the cancel button will dismiss the keyboard and Create Note Overlay without saving any inputted text."))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Doctor");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24358", true);

                    //TC24370 & TC24359
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifySaveButtonActive(TeacherModeAutomationAgent));
                    string texttosave = "Doctor";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttosave);
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(TeacherModeAutomationAgent), "Auto-Correct is not enabled");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySaveButtonActive(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttosave));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyAddNotePopUpClose(TeacherModeAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent));
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24370", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24359", true);

                    //TC24371
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyDisplayOfEditButton(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Tets");
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(TeacherModeAutomationAgent), "Auto-Correct is not enabled");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, "Notes"));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));

                    bool TurnAutoCorrectionON = false;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(TeacherModeAutomationAgent, TurnAutoCorrectionON);
                    TeacherModeAutomationAgent.LaunchApp();

                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCreateNoteOverlay(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Tets");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(TeacherModeAutomationAgent), "Auto-Correct is enabled");
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24371", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24373", true);

                    //TC24399
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonGuide(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonGuideOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 250, 250);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Fail if teacher mode flyout menu is still open");
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnMTE_CCIcon(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent), "Fail if today shelf is open");
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson), "Fail if lesson overvier is not active");
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Fail if teacher mode flyout menu is still open");
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24399", true);                    

                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24352)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMyLessonNotesActiveWhenLessonOverViewExpanded()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24352: To verify that My Lesson Notes becomes active when user has opened Teacher Guide and 'Lesson Overview' is expanded."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }
                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24359)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyFunctinalityOfSaveButtonInNotesOverlay()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24359: Verify The Create Note overlay_SAVE Button functionality"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifySaveButtonActive(TeacherModeAutomationAgent));
                    string texttosave = "Doctor";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttosave);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySaveButtonActive(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttosave));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24354)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCreateNoteOverlayItems()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24354: Verify that On tap of the canvas, The Create Note overlay is displayed. When no text has been entered into the overlay, overlay contains a instructional header, close button, text box, and save button."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyCreateNotesUI(TeacherModeAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24364)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEditNoteOverlayItems()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24364: Verify that The overlay contains a instructional header, close button, text box, delete note button, and save button."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyEditNotesUI(TeacherModeAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24363)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEditNoteButtonAndOverlayDisplay()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24363: Verify that Edit button is not displayed when notes do not exist for a Lesson and Edit note overlay get display after tapping on the edit note button."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyDisplayOfEditButton(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyEditNoteOverlay(TeacherModeAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24371)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDeleteNoteButtonFunctionality()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24371: Verify that On tap, the Delete Note Button will delete the note from the system as well as dismiss the overlay and keyboard. This note is removed from the My Lesson Notes section's canvas."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyDisplayOfEditButton(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, "Notes"));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(TeacherModeAutomationAgent));
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCreateNoteOverlay(TeacherModeAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/



      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24373)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutocorrectFunctionalityWhileEditingLessonNotes()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24373: Verify Autocorrect enabled if enabled on device, disabled if disabled on device while editing a lesson notes."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    bool TurnAutoCorrectionON = true;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(TeacherModeAutomationAgent, TurnAutoCorrectionON);
                    TeacherModeAutomationAgent.LaunchApp();
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Tets");
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(TeacherModeAutomationAgent), "Auto-Correct is not enabled");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(TeacherModeAutomationAgent);
                    TurnAutoCorrectionON = false;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(TeacherModeAutomationAgent, TurnAutoCorrectionON);
                    TeacherModeAutomationAgent.LaunchApp();
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, "Tets");
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(TeacherModeAutomationAgent), "Auto-Correct is enabled");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/




     /*   [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20302)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeUI()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20302: Verify Teacher Mode UI"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenu(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyLessonNotesButtonIsDefaultTabOpened(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyClassRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    
                    TeacherModeCommonMethods.VerifyNotesAvailableInMyLessonNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24349)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnformattedTextInEditNoteOverlay()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24349: Verify that the text box is ready for input when displayed. Unformatted text can be added into the box without a character limit."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent), "Keyboard not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnformattedTextInTheBoxAndIsScrollable(TeacherModeAutomationAgent), "Not scrollbale");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24357)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnformattedTextInCreateNoteOverlay()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24357: Verify that the text box is ready for input when displayed. Unformatted text can be added into the box without a character limit."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(TeacherModeAutomationAgent), "Keyboard not open");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnformattedTextInTheBoxAndIsScrollable(TeacherModeAutomationAgent), "Not scrollbale");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24399)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeCriticalFunctionality3()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24399: Verification of scenarios when Teacher Guide is OPEN, Today Activity Shelf is open and Flyout Menu is active"))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent)));
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonGuide(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyLessonGuideOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 250, 250);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Fail if teacher mode flyout menu is still open");
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnMTE_CCIcon(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(TeacherModeAutomationAgent);
                    Assert.IsFalse(UnitSelectionCommonMethods.VerifyTodayShelfOpen(TeacherModeAutomationAgent), "Fail if today shelf is open");
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson), "Fail if lesson overvier is not active");
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Fail if teacher mode flyout menu is still open");
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

   /*     [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24398)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherGuideFlyOutMenuUIAndNavigation()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24398: verify that upon tapping the existing Teacher Guide Icon, a fly out menu shall be displayed with the menu header labeled \"Teacher Guide\""))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Teacher guide flyout panel not found");
                    TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenu(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenu(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open after tapping on system tray");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Flyout found after tapping on system tray");
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 1000, 1000);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAppFullscreenView(TeacherModeAutomationAgent), "App not open in full screen");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open after tapping on app expand button");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Flyout found after tapping on app expand button");
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24397)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherGuideFlyOut()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24397: Verify that upon tapping the existing Teacher Guide Icon, a fly out menu shall be displayed with the menu header labeled \"Teacher Guide\" in Teacher Mode Full Screen view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Teacher guide flyout panel not found");
                    TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenu(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent)));
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(TeacherModeAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonOverview(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(TeacherModeAutomationAgent, randLesson), "Lesson overview not found");
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonGuide(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonGuideOpen(TeacherModeAutomationAgent), "Lesson overview not found");
                    NavigationCommonMethods.ClickOnSystemTray(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open after tapping on system tray");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(TeacherModeAutomationAgent), "Flyout found after tapping on system tray");
                    NavigationCommonMethods.TapOnScreen(TeacherModeAutomationAgent, 1000, 1000);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20331)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyShowPasswordMessagePopupForNonSetUpStudent()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20331: Ensure that tapping on show password button displays following message indicating that password is not set up."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnStudent(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnShowPasswordForNonSetupStudent(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyShowPasswordPopupForNonSetupStudent(TeacherModeAutomationAgent), "Show Password popup should open");
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyUserOnUnitHomeWithTeacherMode(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20775)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMyClassRosterButton()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20775: Ensure that tapping on show password button displays following message indicating that password is not set up."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToCloseTeacherGuidePanel(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyClassRosterButton(TeacherModeAutomationAgent), "My class roster button found");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open");
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(TeacherModeAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyClassRosterButton(TeacherModeAutomationAgent), "My class roster button found");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(TeacherModeAutomationAgent), "Teacher mode found open");
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20332)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMyClassRosterMessage()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20332: Ensure that tapping on show password button displays following message indicating that password is not set up."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterOpen(TeacherModeAutomationAgent), "My class roster not open.");
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(TeacherModeAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                    TeacherModeAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyNoRosterMessage(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);

                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20326)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyShowPasswordButtonForStudent()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20326: Ensure that Show password button is displayed when teacher taps student avatar image."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnStudent(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyShowPasswordButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20324)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStudentDataInMyClassRoster()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20324: Ensure that when teacher mode is enabled, class roster is displayed with student data at bottom of screen."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyClassRosterOpen(TeacherModeAutomationAgent), "My class roster not open.");
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20323)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAvatarAndStudentNameInMyClassRoster()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20323: Ensure that student data  having student  name & Student avatar image is displayed in class roster ,when teacher mode is enabled."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyStudentNameAndAvatar(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24360)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySavingFunctionalityOfLessonNotes()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24360: Verify that My Lesson Notes will be saved when user logs out and login after adding a lesson note"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    string texttoSaveForUser1 = "Testing1";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttoSaveForUser1);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherKatherin"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    string texttoSaveForUser2 = "Testing2";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttoSaveForUser2);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser1));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherKatherin"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser2));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(24235)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeUIAsPerCurrentArt()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC24235: Verify that the sizing, layout, and screen elements conform to below cut art"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyStudentNameAndAvatar(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(20330)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnShowPasswordCrossButton()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("TC20330: Verify that tapping on show password button , it displays student password with  red (X) in corner."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherModeAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.WaitForNameDisplayedInRoster(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnShowPasswordForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    TeacherModeCommonMethods.VerifyShowPasswordPopupForSetupStudent(TeacherModeAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.CloseErrorPopUp(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyClassRosterOpen(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("TeacherModeTest")]
        [WorkItem(25)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherModeCriticalFunctionalities4()
        {
            using (TeacherModeAutomationAgent = new AutomationAgent("MTC25: Verify that My Lesson Notes will be saved when user logs out and login after adding a lesson note"))
            {
                try
                {
                    string unitNumber = BackUpAndRestoreCommonMethods.InitialStepsToReachUnitSelectionScreen(TeacherModeAutomationAgent, "TeacherAdbul");
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    string texttoSaveForUser1 = "Testing1";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttoSaveForUser1);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherKatherin"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    string texttoSaveForUser2 = "Testing2";
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttoSaveForUser2);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser1));
                    TeacherModeAutomationAgent.CloseApplication();
                    TeacherModeAutomationAgent.Sleep();
                    TeacherModeAutomationAgent.LaunchApp();
                    TeacherModeAutomationAgent.Sleep();
                    
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser1));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherKatherin"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser1));                    
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser1));

                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, TurnWifiOff);
                    TeacherModeAutomationAgent.LaunchApp();
                    TeacherModeAutomationAgent.Sleep();

                    
                    TeacherModeCommonMethods.ClickOnEditButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, texttoSaveForUser1);
                    TeacherModeCommonMethods.ClickOnSaveButton(TeacherModeAutomationAgent);
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    LoginCommonMethods.TeacherAdminLogin(TeacherModeAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherModeAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherModeAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(TeacherModeAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(TeacherModeAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(TeacherModeAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, texttoSaveForUser1));
                    LoginCommonMethods.Logout(TeacherModeAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherModeAutomationAgent, false);
                    
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC51662", true);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport("TC24360", true);


                }

                catch (Exception ex)
                {
                    TeacherModeAutomationAgent.Sleep(2000);
                    TeacherModeAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherModeAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }



    }
}
