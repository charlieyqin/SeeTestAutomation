using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using System.Reflection;
using System.Configuration;
using System.Collections;



namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class InboxTests
    {
        public AutomationAgent inboxAutomationAgent;

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("K1SmokeTests")]
        [WorkItem(10)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyInboxCriticalFunctionalitiesForStudent()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC10: Verify the display and functionality of ELA and Math Icons"))
            {
                try
                {
                    
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
            

                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyELAText(inboxAutomationAgent));
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyMATHText(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnMathButtonInStudentView(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyMATHbuttonHighlightedInStudentInbox(inboxAutomationAgent));
                    
                    InboxCommonMethods.ClickOnELAButtonInStudentView(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyELAbuttonHighlightedInStudentInbox(inboxAutomationAgent));
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(8)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCriticalFunctionalitiesOfTeacherInboxItem1()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC8: Verify the ability of User to switch between ELA and Math views"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 2);
                    InboxCommonMethods.sendMATHNoteBooKForReview(inboxAutomationAgent, "StudentSec01", 2);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    InboxCommonMethods.VerifyInboxFunctionalities(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCalenderHighlighted(inboxAutomationAgent));


                    InboxCommonMethods.NavigateToSelectELAOrMathUnit(inboxAutomationAgent, "ELA");
                    inboxAutomationAgent.WaitforElement("InboxView", "MathButton", "", WaitTime.DefaultWaitTime);
                    InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyMATHbuttonHighlighted(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyCalenderHighlighted(inboxAutomationAgent));

                    InboxCommonMethods.ClickOnELAButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyELAbuttonHighlighted(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyCalenderHighlighted(inboxAutomationAgent));


                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22178", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45043", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22088", true);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnStackIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnShowAllStudentIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.VerifyInboxFunctionalities(inboxAutomationAgent);

                    int sharedELAItemsCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsTrue(sharedELAItemsCount > 1, "Fail if more than one item is not shared");
                    InboxCommonMethods.VerifyEachStudentStackThumbnails(inboxAutomationAgent, sharedELAItemsCount);

                    InboxCommonMethods.ClickOnUnstackedItem(inboxAutomationAgent);
                    InboxCommonMethods.VerifyOrderOfUnstackedItems(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45490", true);

                    InboxCommonMethods.VerifyStudentDetailsInNotebookPage(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44549", true);

                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22494", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22496", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45458", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22087", true);
                    
                    InboxCommonMethods.NavigateToSelectELAOrMathUnit(inboxAutomationAgent, "MATH");
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyMATHbuttonHighlighted(inboxAutomationAgent));
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnStackIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnShowAllStudentIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.VerifyInboxFunctionalities(inboxAutomationAgent);

                    int sharedMathItemsCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsTrue(sharedMathItemsCount.Equals(1), "Fail if more than one item is not shared");
                    InboxCommonMethods.VerifyEachStudentStackThumbnails(inboxAutomationAgent, sharedMathItemsCount);                   

                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44627", true);
                                       

                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22495", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45459", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44628", true);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        //below test case is merged
      /*  [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22494), WorkItem(45458)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfItemsInTeacherInboxViewOfELAUnitHomescreen()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22494,TC45458: Verify the display of items in the Teacher inbox stacked view"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",2);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(inboxAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(inboxAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyELAandMathTabs(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    InboxCommonMethods.VerifyGroupCalendarAndSelectButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyBeigeAreaDisplay(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStackIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnShowAllStudentIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
     /*   [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22495), WorkItem(45459)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfItemsInTeacherInboxViewOfMath()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22495,TC45459: Verify the display of items in the Teacher inbox stacked view"))
            {
                try
                {
                    InboxCommonMethods.sendMATHNoteBooKForReview(inboxAutomationAgent, "StudentSec01",2);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(inboxAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyELAandMathTabs(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    InboxCommonMethods.VerifyGroupCalendarAndSelectButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyBeigeAreaDisplay(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStackIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnShowAllStudentIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
        /*  [TestMethod()]
          [TestCategory("InboxTest")]
          [WorkItem(22497)]
          [Priority(2)]
          [Owner("Namrita (namrita.agarwal)")]
          public void VerifyPreviousScreenDisplayedWhenBackButtonTappedFromInboxScreen()
          {
              using (inboxAutomationAgent = new AutomationAgent("TC22497:verify whether the previous screen is displayed when the back button is tapped from the inbox screen."))
              {
                  try
                  {
                      NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                      LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherAdbul"));
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      UnitSelectionCommonMethods.VerifyUnitSlectionScreen(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnELAUnit(inboxAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(inboxAutomationAgent));
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      UnitSelectionCommonMethods.VerifyUserOnUnitHome(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnMediaLibrary(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyUserOnMedialLibrary(inboxAutomationAgent));
                      NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyUserOnNotebookbrowser(inboxAutomationAgent));
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnMathUnit(inboxAutomationAgent, "0");
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      UnitSelectionCommonMethods.VerifyUserOnUnitHome(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnMediaLibrary(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyUserOnMedialLibrary(inboxAutomationAgent));
                      NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                      NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                      Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyUserOnNotebookbrowser(inboxAutomationAgent));
                      LoginCommonMethods.Logout(inboxAutomationAgent);

                  }

                  catch (Exception ex)
                  {
                      inboxAutomationAgent.Sleep(2000);
                      inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                      inboxAutomationAgent.CloseApplication();
                      throw;
                  }
              }
          }*/
        /*[TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22089)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTheFunctionalityOfSelectButtonInTeacherInboxView()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22089: Verify the functionality of Select Button in Teacher Inbox View"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnSelectButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyAddToClassNotebook(inboxAutomationAgent));
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyAddButton(inboxAutomationAgent));
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyCancelButton(inboxAutomationAgent));
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyHelpTextWhenSelectButtonTapp(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifySelectButton(inboxAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
       /* [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22496)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfItemsInTeacherInboxViewOfanyELAUnit()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22496: Verify the display of items in the Teacher inbox stacked view"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(inboxAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(inboxAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyELAandMathTabs(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    InboxCommonMethods.VerifyGroupCalendarAndSelectButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyBeigeAreaDisplay(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStackIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnShowAllStudentIcon(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, InboxCommonMethods.VerifyShowAllStudentIcon(inboxAutomationAgent));

                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /* Retired Test Case  [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22531)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIoFOverlayOfAddToNewClassNotebook()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22531: verify the UI of Add to New Class notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnSelectButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyAddButton(inboxAutomationAgent));
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyCancelButton(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnAddButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, InboxCommonMethods.VerifyAddClassNotebookOverlay(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnAddButton(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyAddClassNotebookOverlay(inboxAutomationAgent));
                    InboxCommonMethods.VerifyUIOfAddClassNotebookOverlay(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 100, 100);

                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22532)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUofINewClassNotebookOverlay()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22532: verify the NEW CLASS NOTEBOOK overlay's UI"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    //InboxCommonMethods.ClickOnSelectButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnAddButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnNewClassNotebook(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyNewClassNoteBookText(inboxAutomationAgent));
                    InboxCommonMethods.VerifyUIOfNewClassNotebookOverlay(inboxAutomationAgent);
                    InboxCommonMethods.ClickOntheScrollBar(inboxAutomationAgent);
                    InboxCommonMethods.VerifyScrollBarOpen(inboxAutomationAgent);
                    InboxCommonMethods.ClickInTextBoxToOpenKeyBoard(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }Retired Test Case*/
        //Student Important Test Case
        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(12)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyStudentInboxImportantFunctionalities()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC12: Verify the elements of student inbox"))
            {
                try
                {

                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.SendCommentAndAudioToStudent(inboxAutomationAgent);
                    InboxCommonMethods.SendCommentToStudent(inboxAutomationAgent);
                    InboxCommonMethods.SendWithoutCommentAndAudioToStudent(inboxAutomationAgent);
                    InboxCommonMethods.SendOnlyAudioToStudent(inboxAutomationAgent);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
                    {
                        inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                        inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
                    }
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                    {
                        inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
                    }
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "StudentSec01");
                    inboxAutomationAgent.WaitforElement("InboxView", "NewBannerInboxItem", "", WaitTime.DefaultWaitTime);
                    InboxCommonMethods.VerifyELAandMathIconInStudentInbox(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyWhiteBackGround(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22176", true);

                    InboxCommonMethods.ClickOnMathButtonInStudentView(inboxAutomationAgent);
                    
                    InboxCommonMethods.VerifyOrderOfUnstackedItems(inboxAutomationAgent);

                    inboxAutomationAgent.WaitforElement("InboxView", "NewBannerInboxItem", "", WaitTime.LargeWaitTime);                    

                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNewBoxDisplayOnTopLeftCornerOfStudent(inboxAutomationAgent);


                    InboxCommonMethods.ClickOnELAButtonInStudentView(inboxAutomationAgent);

                    InboxCommonMethods.VerifyOrderOfUnstackedItems(inboxAutomationAgent);


                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNewBoxDisplayOnTopLeftCornerOfStudent(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC22191", true);

                    InboxCommonMethods.ClickOnStudentThumbNail(inboxAutomationAgent, "1");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent),"Comment is Present");
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent));
                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    inboxAutomationAgent.WaitforElement("NotebookView", "HandToolOn", "", WaitTime.DefaultWaitTime);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54661", true);

                    InboxCommonMethods.ClickOnStudentThumbNail(inboxAutomationAgent, "2");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent));
                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    inboxAutomationAgent.WaitforElement("NotebookView", "HandToolOn", "", WaitTime.DefaultWaitTime);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54660", true);

                    InboxCommonMethods.ClickOnStudentThumbNail(inboxAutomationAgent, "3");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent));
                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    inboxAutomationAgent.WaitforElement("NotebookView", "HandToolOn", "", WaitTime.DefaultWaitTime);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54662", true);

                    InboxCommonMethods.ClickOnMathButtonInStudentView(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnStudentThumbNail(inboxAutomationAgent, "1");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent));
                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    inboxAutomationAgent.WaitforElement("NotebookView", "HandToolOn", "", WaitTime.DefaultWaitTime);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54659", true);                                      

                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
     /* Clubbed   [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22087)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDisplayOfItemsInInboxViewOfTeacher()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22087: Verify the display of below in Teacher inbox view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyELAandMathTabs(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyTextNextToBackIcon(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyGroupCalendarAndSelectButton(inboxAutomationAgent));
                    InboxCommonMethods.VerifyBeigeAreaDisplay(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/
      /*Retired  [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(22534)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUIofAddToExistingClassNotebookOverlay()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC22534: verify the Add to CLASS NOTEBOOK overlay's UI"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnSelectButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnAddButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnClassNotebook(inboxAutomationAgent);
                    Assert.AreEqual<bool>(true, InboxCommonMethods.VerifyAddToClassNoteBookText(inboxAutomationAgent));
                    InboxCommonMethods.VerifyUIOfAddToExtingClassNotebookOverlay(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(11)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyImportantFunctionalitiesOfInboxForTeacher1()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC11: Verify the state of ELA,Math and Calender button when tapped on"))
            {
                try
                {
                    BookBuilderCommonMethods.sendBooksToTeacher(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 1);
                    InboxCommonMethods.sendMATHNoteBooKForReview(inboxAutomationAgent, "StudentSec01", 1);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    inboxAutomationAgent.WaitForElement("InboxView", "PortraitBookImage", WaitTime.LargeWaitTime);
                    inboxAutomationAgent.WaitForElement("InboxView", "SquareBookImage", WaitTime.LargeWaitTime);
                    Assert.IsTrue(InboxCommonMethods.VerifyELAbuttonHighlighted(inboxAutomationAgent), "ELA Button Not Highlighted");
                    Assert.IsTrue(InboxCommonMethods.VerifyPotraitBookIsPresent(inboxAutomationAgent), "Potrait Book Not Found");
                    Assert.IsTrue(InboxCommonMethods.VerifyLanscapeBookIsPresent(inboxAutomationAgent), "Landscape Book Not Found");
                    Assert.IsTrue(InboxCommonMethods.VerifySquareBookIsPresent(inboxAutomationAgent), "Square Book Not Found");
                    Assert.IsTrue(InboxCommonMethods.VerifyUnitLabelIsPresentInInboxForNB(inboxAutomationAgent), "Unit Label Not Found");
                    int elaCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsNotNull(elaCount, "no notebookpages to review");

                    InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyPotraitBookIsPresent(inboxAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyLanscapeBookIsPresent(inboxAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifySquareBookIsPresent(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44624", true);

                    int mathCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsNotNull(mathCount, "no notebookpages to review");

                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54270", true);

                    InboxCommonMethods.ClickOnUnstackedItem(inboxAutomationAgent);
                    InboxCommonMethods.VerifyOrderOfUnstackedItems(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45047", true);

                    InboxCommonMethods.ClickOnELAButton(inboxAutomationAgent);


                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNewBoxDisplayOnTopLeftCorner(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45489", true);

                    int countBefore = InboxCommonMethods.GetSharedItemsNewBannerCount(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    int countAfter = InboxCommonMethods.GetSharedItemsNewBannerCount(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, countBefore.Equals(countAfter));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54274", true);


                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    inboxAutomationAgent.WaitforElement("NotebookView", "CommentBox", "", WaitTime.SmallWaitTime);
                    NotebookCommonMethods.VerifyAnnotationLayerOnNotebook(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44546", true);
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyPlainTextIntextBox(inboxAutomationAgent), "Plain text not avilable in box");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    string text1 = "TEST";
                    inboxAutomationAgent.SendText(text1);
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    

                    string text2 = "Automation";
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    inboxAutomationAgent.SendText(text2);
                    TeacherModeCommonMethods.VerifyEditNotesUI(inboxAutomationAgent);
                    InboxCommonMethods.ClickONDOneButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent), "Edit Comment Overlay Not Found");

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentSaved(inboxAutomationAgent, text1 + text2), "Verify saved comment");
                    string text3 = "Team";
                    inboxAutomationAgent.SendText(text3);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentSaved(inboxAutomationAgent, text1 + text2 + text3), "Verify saved comment");


                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44750", true);

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Save Button is Active"); 
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent), "Add Comment overlay found close");
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);                    
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44754", true);

                    
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44756", true);

                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCalenderHighlighted(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC46658", true);                             
                                 
                    
                    
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

      /*Clubbed  [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44627)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyThumbnailDetailsInTeacherInbox()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44627: Verify the details for each thumnail displayed in teacher inbox."))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyStudentNameLabel(inboxAutomationAgent);
                    InboxCommonMethods.VerifyDateTimeStampLabelInInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyUnitLabelInInbox(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(9)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCriticalFunctionalitiesOfTeacherInboxItem2()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC9: Verify working of Notebook Review Page In Inbox"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 2);
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec02", 2);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");

                    //InboxCommonMethods.ClickOnStudentSort(inboxAutomationAgent);
                    //Assert.IsTrue(InboxCommonMethods.VerifyStackedItemIsPresent(inboxAutomationAgent));
                    //int stackCount = InboxCommonMethods.GetStudentViewCount(inboxAutomationAgent);
                    //Assert.IsTrue(stackCount.Equals(2), "Student view is not sorted");
                    //inboxAutomationAgent.AddSteptoSeeTestReport("TC54271", true);

                    InboxCommonMethods.VerifyItemInTeacherInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44623", true);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
                    {
                        inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                        inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
                    }


                    //Verifying Audio Functionality

                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    if (InboxCommonMethods.VerifyRemoveRecordingButton(inboxAutomationAgent))
                    {
                        InboxCommonMethods.ClickToRemoveRecording(inboxAutomationAgent);
                        LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                        InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    }
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnPlayButtonInReviewAudio(inboxAutomationAgent);
                    InboxCommonMethods.VerifyProgressBarView(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnRerecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnCancelButtonInReviewAudio(inboxAutomationAgent);


                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);

                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1398, 1150);
                    Assert.IsTrue(InboxCommonMethods.VerifyRerecordButtonwithApply(inboxAutomationAgent), "Tap On Screen closed overlay");
                    InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);                    
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53688", true);

                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.VerifyRerecordingOptions(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnPlayButtonInReviewAudio(inboxAutomationAgent);
                    InboxCommonMethods.VerifyProgressBarView(inboxAutomationAgent);
                    InboxCommonMethods.ClickToRemoveRecording(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45631", true);

                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);                    
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);


                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.VerifyRerecordingOptions(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRerecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyRerecordApplyOptions(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1398, 1150);
                    Assert.IsTrue(InboxCommonMethods.VerifyRerecordButtonwithApply(inboxAutomationAgent), "Tap On Screen closed overlay");
                    InboxCommonMethods.ClickOnCancelButtonInReviewAudio(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyRerecordButtonwithApply(inboxAutomationAgent), "Cancel didn't work");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53689", true);                
                                       
                    
                    //Verifying Stamp Functionality

                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyItemsInStickerOverlay(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44757", true);
                    //InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    //InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    //Assert.IsFalse(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    //inboxAutomationAgent.AddSteptoSeeTestReport("TC45630", true);
                    //InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    //InboxCommonMethods.VerifyOpenedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    string[] pos = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerHighlighted(inboxAutomationAgent), "Dotted lines not present hence not highlighted");
                    NotebookCommonMethods.DragImage(inboxAutomationAgent, 500, 500);
                    string[] after_drag = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(!pos[0].Equals(after_drag[0]) && !pos[1].Equals(after_drag[1]), "Sticker didn't moved");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC45613", true);
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker  found on notebook after deleting");

                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44759", true);

                    //Verify Comment Functionality
                    bool TurnAutoCorrectionON = false;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(inboxAutomationAgent, TurnAutoCorrectionON);
                    inboxAutomationAgent.LaunchApp();
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    if (inboxAutomationAgent.IsElementFound("InboxView", "EditCommentOverlay"))
                    {
                        TeacherModeCommonMethods.ClickOnDeleteNoteButton(inboxAutomationAgent);
                        LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                        NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    }
                    
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    inboxAutomationAgent.SendText("U");
                    inboxAutomationAgent.SendText("o");

                    Assert.IsFalse(InboxCommonMethods.VerifyAutoCorrectForCommentEnable(inboxAutomationAgent), "Auto-Correct found enabled");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44753", true);

                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(inboxAutomationAgent, true);
                    inboxAutomationAgent.LaunchApp();
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    
                    int count=0;
                    for (int i = 0; i < 5;i++)
                    { 
                        
                        InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);
                        NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                        inboxAutomationAgent.SendText("U");
                        inboxAutomationAgent.SendText("o");
                        if(inboxAutomationAgent.IsElementFound("StudentSetup", "AutoCorrectionCell"))
                        {
                            count++;
                            break;
                        }
                    }
                    if(!count.Equals(0))
                    {
                        inboxAutomationAgent.AddSteptoSeeTestReport("TC44752", true);
                    }
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);                    
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44749", true);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);                
                   
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

     /*Clubbed   [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(45631)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyWorkingOfAudioFeature()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC45631: Verify the working of audio feature"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);
                    InboxCommonMethods.VerifyAudioSavedPopup(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    InboxCommonMethods.VerifyReviewRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnReviewRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickToRemoveRecording(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

    /*Clubbed    [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44759)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToDeleteSticker()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44759: Verify that user is able to Delete the added stickers "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    NotebookCommonMethods.ClickOnHandButton(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerHighlighted(inboxAutomationAgent), "Dotted lines not present hence not highlighted");
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker  found on notebook after deleting");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /*Clubbed [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(45613)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStickerTools()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC45613: Verify teacher review sticker tools"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyItemsInStickerOverlay(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay found");
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    NotebookCommonMethods.ClickOnHandButton(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    string[] pos = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    NotebookCommonMethods.DragImage(inboxAutomationAgent, 500, 500);
                    string[] after_drag = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(!pos[0].Equals(after_drag[0]) && !pos[1].Equals(after_drag[1]), "Sticker didn't moved");
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


       /* [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44750)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCancellingOfComment()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44750: Verify the functionality of cancelling the newly unsaved comment"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyPlainTextIntextBox(inboxAutomationAgent), "Plain text not avilable in box");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44749)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAddingAndSavingComment()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44749: Verify the functionality of adding and saving a comment newly to the canvas "))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyPlainTextIntextBox(inboxAutomationAgent), "Plain text not avilable in box");
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyGreenCheckOnCommentButton(inboxAutomationAgent), "Green check mark not found");
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44546)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifytransparentAnnotationLayerOn()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44546: Verify that Transparent annotation layer on top of student notebook page"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOnNotebook(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44757)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToAddSticker()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44757: verify that on selection of sticker from overlay, the overlay closes, and on tappign on canvas adds teh selected sticker  to it."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker  found on notebook after deleting");
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44756)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStampOverlay()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44756: Verify that tapping outside of the sticker overlay closes the stamp overlay automatically"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");

                    
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44623)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNewBanner()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44623: Verify that as a teacher user , items shared by student should be displayed in INBOX with NEW banner on top left thumbnail corner "))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.VerifyItemInTeacherInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44758)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRepostionOfAddedSticker()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44758: Verify that user is able to reposition the added stickers "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    NotebookCommonMethods.ClickOnHandButton(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerHighlighted(inboxAutomationAgent), "Dotted lines not present hence not highlighted");
                    string[] pos = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    NotebookCommonMethods.DragImage(inboxAutomationAgent, 500, 500);
                    string[] after_drag = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(!pos[0].Equals(after_drag[0]) && !pos[1].Equals(after_drag[1]), "Sticker didn't moved");
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44753)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAutoCorrectOptionOFFInCommentOverlay()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44753: verify that while adding comments to comment box, words do not get auto corrected if autocorrect option is OFF for device"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    bool TurnAutoCorrectionON = false;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(inboxAutomationAgent, TurnAutoCorrectionON);
                    inboxAutomationAgent.LaunchApp();
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    inboxAutomationAgent.SendText("Testngi");
                    Assert.IsFalse(LoginCommonMethods.VerifyAutoCorrectEnable(inboxAutomationAgent), "Auto-Correct found enabled");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44752)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAutoCorrectOptionONInCommentOverlay()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44752: verify that while adding comments to comment box, words get auto corrected if autocorrect option is ON for device"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    bool TurnAutoCorrectionON = true;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(inboxAutomationAgent, TurnAutoCorrectionON);
                    inboxAutomationAgent.LaunchApp();
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent), "Comment overlay found close");
                    Assert.IsTrue(InboxCommonMethods.VerifyKeyboardOpen(inboxAutomationAgent), "keyboard found close");
                    inboxAutomationAgent.SendText("Testngi");
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(inboxAutomationAgent), "Auto-Correct found enabled");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44754), WorkItem(45612)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEditingOfComment()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44754,TC45612: Verify that user is able to edit the comment successfully"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyCommentOverlayOpen(inboxAutomationAgent);
                    string text1 = "TEST";
                    inboxAutomationAgent.SendText(text1);
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyGreenCheckOnCommentButton(inboxAutomationAgent), "Green check mark not found");

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent), "Edit Comment Overlay Not Found");
                    String characterText = BackUpAndRestoreCommonMethods.GetEnteredTextInTextArea(inboxAutomationAgent);
                   
                    string text2 = "Automation";
                    inboxAutomationAgent.SendText(text2);
                    TeacherModeCommonMethods.VerifyEditNotesUI(inboxAutomationAgent);
                    InboxCommonMethods.ClickONDOneButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent), "Edit Comment Overlay Not Found");

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentSaved(inboxAutomationAgent, text1 + text2), "Verify saved comment");
                    string text3 = "Team";
                    inboxAutomationAgent.SendText(text3);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                   

                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentSaved(inboxAutomationAgent, text1 + text2 + text3), "Verify saved comment");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyGreenCheckOnCommentButton(inboxAutomationAgent), "Green check mark not found");
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySaveButtonActive(inboxAutomationAgent),"Save Button is Active");
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44628)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInboxViewForMoreThanOneStudent()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44628: Verify that inbox with BY STUDENT sort selection shows stack of each student when more than 1 student has submitted items to same teacher ."))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec02",1);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    int sharedItemsCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsTrue(sharedItemsCount > 1, "Fail if more than one item is not shared");
                    InboxCommonMethods.VerifyEachStudentStackThumbnails(inboxAutomationAgent, sharedItemsCount);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(45489)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNewBannerOnTopOfLeftCornerOfStackItem()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC45489: Verify that all Unread items (stacked or unstacked) have 'NEW' banner on top left corner"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNewBoxDisplayOnTopLeftCorner(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(45490)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOrderOfUnstackedItems()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC45490: Verify that tapping on any stacked items in inbox takes user to new view with unstacked items wherein order of display should be reverse chronological order"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnUnstackedItem(inboxAutomationAgent);
                    InboxCommonMethods.VerifyOrderOfUnstackedItems(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44549)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStudentAndDateTimeWhenStackItemOpened()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44549:Verify that the Student name and date timestamp is present on the top right of the notebook page and by the left side of the paper plane"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.VerifyStudentDetailsOnStackItem(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(44626)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStackItemsSorting()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC44626:Verify the stack view in teacher inbox for single item having multiple versions by single student and multiple items by single student."))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec02",1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    int sharedItems = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    if (sharedItems > 1)
                        InboxCommonMethods.VerifyOrderOfStackedItems(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(45047), WorkItem(22191), WorkItem(54282)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyELAAndMathIconsStudentInboxItemsOrder()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC45047,TC22191,TC54282 : Verify ELA and Math icons student inbox items order"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnELAButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyOrderOfStackedItems(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyOrderOfStackedItems(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(46658)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyFunctionalityOfBackButtonInReviewMode()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC46658: Verify the functionality of back button in review view"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53689)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyPlaybackOfAudioandAlertStyling()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53689: Playback of Teacher Audio Feedback and Alert Dialog Styling"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);
                    InboxCommonMethods.VerifyAudioSavedPopup(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    InboxCommonMethods.VerifyReviewRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyGreenCheckOnAudioIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnReviewRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyRerecordingOptions(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnPlayButtonInReviewAudio(inboxAutomationAgent);
                    InboxCommonMethods.VerifyProgressBarView(inboxAutomationAgent);
                    InboxCommonMethods.ClickToRemoveRecording(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnReviewRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyRerecordApplyOptions(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1398, 1150);
                    Assert.IsTrue(InboxCommonMethods.VerifyRerecordButtonwithApply(inboxAutomationAgent), "Tap On Screen closed overlay");
                    InboxCommonMethods.ClickOnCancelButtonInReviewAudio(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyRerecordButtonwithApply(inboxAutomationAgent), "Cancel didn't work");

                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53688)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyPlaybackOfAudioandAlertStylingChanges()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53688: Playback of Teacher Audio Feedback and Alert Dialog Styling"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnPlayButtonInReviewAudio(inboxAutomationAgent);
                    InboxCommonMethods.VerifyProgressBarView(inboxAutomationAgent);


                    InboxCommonMethods.ClickOnRerecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);


                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnRerecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickToApplyRecording(inboxAutomationAgent);
                    InboxCommonMethods.VerifyAudioSavedPopup(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnRecordIcon(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1398, 1150);
                    Assert.IsTrue(InboxCommonMethods.VerifyRerecordButtonwithApply(inboxAutomationAgent), "Tap On Screen closed overlay");

                    InboxCommonMethods.ClickOnRerecordButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    InboxCommonMethods.ClickOnRecordButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyRerecordApplyOptions(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnCancelButtonInReviewAudio(inboxAutomationAgent);


                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53693)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNotAbletoEditOrMoveStudentSharedAssets()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53693: Teacher Access to Student Notebook Page-Googly Eyes are OFF"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOFFNotebook(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 778, 578);
                    InteractiveCommonMethods.VerifyInteractiveHeader(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(inboxAutomationAgent);

                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 330, 290);
                    inboxAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 330, 290);
                    Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxRegionFound(inboxAutomationAgent), "Remove Button is shown");

                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");

                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

    /*    [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53695)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyAbletoEditOrMoveStudentSharedAssets()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53695: Teacher Access to Student Notebook Page-Googly Eyes are ON"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    InboxCommonMethods.VerifyOpenedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOnNotebook(inboxAutomationAgent);
                    EreaderCommonMethod.ClickOnMarker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1300, 500);
                    NotebookCommonMethods.ClickonCrayonButton(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1350, 550);
                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    NotebookCommonMethods.ClickOnHandButton(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerHighlighted(inboxAutomationAgent), "Dotted lines not present hence not highlighted");
                    NotebookCommonMethods.ClickOnRemoveButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker found on notebook");
                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

       /* [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53726)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNotAbletoEditOrMoveMathTools()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53726: Teacher Access to Student Notebook Page-Googly Eyes are OFF"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOFFNotebook(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyGrabHandle(inboxAutomationAgent);
                    int count_before = NotebookCommonMethods.GetCountOfNumberLines(inboxAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(inboxAutomationAgent, 0, 1000);
                    int count_after = NotebookCommonMethods.GetCountOfNumberLines(inboxAutomationAgent);
                    Assert.AreNotEqual(count_before, count_after, "Number Line Tool is dragged by Teacher");

                    string[] pos_before_drag = NotebookCommonMethods.GetPositionOfNumberLineTool(inboxAutomationAgent);
                    NotebookCommonMethods.DragNumberLineTool(inboxAutomationAgent, 0, 100);
                    string[] pos_after_drag = NotebookCommonMethods.GetPositionOfNumberLineTool(inboxAutomationAgent);
                    Assert.AreEqual(Int32.Parse(pos_before_drag[0]), Int32.Parse(pos_after_drag[0]), "position didn't match");

                    NotebookCommonMethods.ClickOnTableTool(inboxAutomationAgent);
                    int rowscountnormal = NotebookCommonMethods.GetCountOfRows(inboxAutomationAgent);
                    NotebookCommonMethods.DragDownToIncreaseRows(inboxAutomationAgent);
                    int countafterdown = NotebookCommonMethods.GetCountOfRows(inboxAutomationAgent);
                    Assert.IsTrue((countafterdown == rowscountnormal), "Fail due to handle is dragged down");

                    NotebookCommonMethods.ClickOnTableTool(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableActive(inboxAutomationAgent), "Table not active after adding it to the canvas");
                    string[] pos_before_swipe = NotebookCommonMethods.GetPositionOfTable(inboxAutomationAgent);
                    NotebookCommonMethods.DragTable(inboxAutomationAgent);
                    string[] pos_after_swipe = NotebookCommonMethods.GetPositionOfTable(inboxAutomationAgent);
                    Assert.AreEqual(pos_before_swipe, pos_after_swipe, "Fail because table is swiped/dragged");

                    string[] pos = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    NotebookCommonMethods.DragImage(inboxAutomationAgent, 1300, 500);
                    string[] after_drag = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(pos[0].Equals(after_drag[0]) && after_drag[1].Equals(after_drag[1]), "Fail because asset was movable");

                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

     /*   [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53701)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyAlertMessage()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53701: Student Notebook Page_Launch a saved interactive-Googly Eyes are Off"))
            {
                try
                {
                    
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOFFNotebook(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnInteractiveholder(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCancelButtonForAlertMessage(inboxAutomationAgent), "Alert message is not displayed");

                    InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/


    /*    [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(53694)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherRestrictedOnStudentNotebook()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53694: Teacher Restricted on Student Notebook Page-Googly Eyes are Off"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnKindergartenInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);

                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOFFNotebook(inboxAutomationAgent);

                    NotebookCommonMethods.ClickonCrayonButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCrayonButtonIsON(inboxAutomationAgent));

                    InboxCommonMethods.ClickOnEraserButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyEraserButtonIsON(inboxAutomationAgent));

                    InboxCommonMethods.ClickOnInteractiveholder(inboxAutomationAgent);
                    Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveHeader(inboxAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyCancelButtonForAlertMessage(inboxAutomationAgent));

                    NotebookCommonMethods.ClickOnStampButton(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStampOverlay(inboxAutomationAgent), "Stamp menu found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");

                    NavigationCommonMethods.NavigateToHome(inboxAutomationAgent, 1);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

      /* Useful & Notebook cases  [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10197")]
        [WorkItem(53945),WorkItem(44553),WorkItem(44551)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyFunctionalityInAdverseConditions()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC53945,TC44553,TC44551: Verify Update Single Page Notebook roundtrip workflow"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(inboxAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(inboxAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(inboxAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(inboxAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyAeroplaneIconIsPresent(inboxAutomationAgent), "Not able to send notebook page");
                    
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnCancelShare(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyInactiveHandIcon(inboxAutomationAgent), "Notebook review page displayed");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44553", true);
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    BookBuilderCommonMethods.VerifyAcceptAndCancelOptionsInShareDialogue(inboxAutomationAgent);
                    ColdWriteCommonMethods.SelectTeacherName(inboxAutomationAgent, "Mr. TEsec15grdKGFN TEsec15grdKG");
                    Assert.IsTrue(ColdWriteCommonMethods.VerifySentMessageIsPresent(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC44551", true);

                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    int countOfItems = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    //Teacher Inbox
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    InboxCommonMethods.VerifyStudentNameAtInbox(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);

                    inboxAutomationAgent.ApplicationClose();
                    inboxAutomationAgent.Sleep(3000);
                    inboxAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("StudentSec01"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);

                    int countAfter = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.AreEqual(countOfItems, countAfter, "Notebook review page received");
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/



        //US10485

     /*   [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10485")]
        [WorkItem(54270)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyFunctionalityOfInboxforMathAndELA()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54270: Verify that ELA and MATH toggle button display the respective subject  shared notebook in Teachers Inbox depending on the selected Subject."))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.sendMATHNoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnELAButton(inboxAutomationAgent);
                    int elaCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsNotNull(elaCount, "no notebookpages to review");

                    //Verify notebook pages under MATH tab
                    InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                    int mathCount = InboxCommonMethods.GetSharedItemsCount(inboxAutomationAgent);
                    Assert.IsNotNull(mathCount, "no notebookpages to review");
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10485")]
        [WorkItem(54271)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyFunctionalityOfByStudentSortOption()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54271: Verify that ELA and MATH toggle button display the respective subject  shared notebook in Teachers Inbox depending on the selected Subject."))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStudentSort(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyStackedItemIsPresent(inboxAutomationAgent));
                    int stackCount = InboxCommonMethods.GetStudentViewCount(inboxAutomationAgent);
                    Assert.IsTrue(stackCount.Equals(1), "Student view is not sorted");

                    LoginCommonMethods.Logout(inboxAutomationAgent);


                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10485")]
        [WorkItem(54274)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyDisplayOfNewBannerBeforeAndAfter()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54274: Verify the display of  Student shared Notebook page and New banner on Student shared Notebook Pages in Teacher inbox."))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(inboxAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(inboxAutomationAgent, Login.GetLogin("TeacherELA"));
                    NavigationCommonMethods.ClickOnSystemTray(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnInboxButton(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnELAButton(inboxAutomationAgent);
                    InboxCommonMethods.VerifyItemInTeacherInbox(inboxAutomationAgent);//clarification
                    InboxCommonMethods.VerifyNEWbannerOnTheItemInTheInbox(inboxAutomationAgent);
                    int countBefore = InboxCommonMethods.GetSharedItemsNewBannerCount(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    int countAfter = InboxCommonMethods.GetSharedItemsNewBannerCount(inboxAutomationAgent);
                    Assert.AreEqual<bool>(false, countBefore.Equals(countAfter));
                    LoginCommonMethods.Logout(inboxAutomationAgent);


                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10485")]
        [WorkItem(13)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherInboxNotebookReviewCriticalFunctionalities1()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC13: Verify the stack view in teacher inbox for single item having multiple versions by single student and multiple items by single student."))
            {
                try
                {
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    string tcountBefore = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(inboxAutomationAgent, "StudentSec02");
                    InboxCommonMethods.sendMultipleELANoteBooKForReview(inboxAutomationAgent, "A");//Image               
                    InboxCommonMethods.sendMultipleELANoteBooKForReview(inboxAutomationAgent, "B");//Audio
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherELA");
                    string tcountAfter = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(30000);
                    while (!tcountAfter.Equals(tcountBefore))
                    {
                        InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "2");
                        InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                        InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                        if (NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(inboxAutomationAgent))
                            break;
                        else
                            EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);

                    }
                    
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "2");
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(inboxAutomationAgent), "Image not Found");

                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioCapturedOnNotebook(inboxAutomationAgent), "Audio not Found");                

                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "2");
                    
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    string[] pos1 = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    NotebookCommonMethods.DragImage(inboxAutomationAgent, 1300, 500);
                    string[] after_drag1 = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(pos1[0].Equals(after_drag1[0]) && pos1[1].Equals(after_drag1[1]), "Fail because asset was movable");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53726", true);

                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);     
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioCapturedOnNotebook(inboxAutomationAgent));                    
                    InboxCommonMethods.ClickOnAudioInNotebook(inboxAutomationAgent, 2);
                    Assert.IsTrue(InboxCommonMethods.VerifyDashedLineInTeacherInbox(inboxAutomationAgent), "Dashed line not found");
                    Assert.IsFalse(InboxCommonMethods.VerifyRemoveButtonIsPresent(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53693", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54278", true);

                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);                                     
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("InboxTest")]
        [WorkItem(21)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherInboxNotebookReviewCriticalFunctionalities2()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC21: Verify the stack view in teacher inbox for single item having multiple versions by single student and multiple items by single student."))
            {
                try
                {
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    string tcountBefore = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(inboxAutomationAgent, "StudentSec02");
                    
                    InboxCommonMethods.sendMultipleELANoteBooKForReview(inboxAutomationAgent, "D");//Graphic Tool
                    InboxCommonMethods.sendMultipleELANoteBooKForReview(inboxAutomationAgent, "C");//Interactive
                    
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherELA");
                    string tcountAfter = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                    inboxAutomationAgent.Sleep(30000);
                    while (!tcountAfter.Equals(tcountBefore))
                    {
                        InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                        InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                        InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                        if (InboxCommonMethods.VerifyInteractiveInTeacherInboxNotebookReview(inboxAutomationAgent))
                            break;
                        else
                            EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);

                    }

                    inboxAutomationAgent.WaitforElement("InboxView", "NewBannerInboxtile", "1", WaitTime.MediumWaitTime);
                    if (inboxAutomationAgent.IsElementFound("InboxView", "NewBannerInboxtile", "1"))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "4");
                            if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
                            {
                                inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                                inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
                            }
                            String data = InboxCommonMethods.VerifyNewMouseAssetInNotebookReview(inboxAutomationAgent);
                            EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                            String unitName = InboxCommonMethods.GetCurrentUnitInCalendarView(inboxAutomationAgent);
                            String data1 = InboxCommonMethods.VerifyDataLabelInCalendarView(inboxAutomationAgent);
                            Assert.IsTrue(data1.Contains("2016"), "date and time is not displayed in the String");
                            Assert.IsTrue(data.Contains(unitName), "Unit name is matched");

                        }
                    }
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC55794", true);

                    //Verify Functionalities in Student Notebook review Page 
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "2");
                    NotebookCommonMethods.ClickonCrayonButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCrayonButtonIsON(inboxAutomationAgent));
                    InboxCommonMethods.ClickOnEraserButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyEraserButtonIsON(inboxAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    NotebookCommonMethods.ClickToChooseSticker(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Sticker not found on notebook");
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool is active");
                    NotebookCommonMethods.ClickOnHandButton(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 800, 800);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerHighlighted(inboxAutomationAgent), "Dotted lines not present hence not highlighted");
                    string[] pos = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    NotebookCommonMethods.DragImage(inboxAutomationAgent, 500, 500);
                    string[] after_drag = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(!pos[0].Equals(after_drag[0]) && !pos[1].Equals(after_drag[1]), "Sticker didn't moved");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53695", true);



                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    inboxAutomationAgent.SendText("Very Good");
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    NotebookCommonMethods.ClickOnCommentButton(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent), "Edit Comment Overlay Not Found");
                    InboxCommonMethods.ClickOnCancelButton(inboxAutomationAgent);

                    BackUpAndRestoreCommonMethods.CheckingCharacterCountVariation(inboxAutomationAgent);
                    InboxCommonMethods.ClickONDOneButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54642", true);

                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54281", true);


                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "2");
                    string[] after_back = NotebookCommonMethods.GetPositionOfImage(inboxAutomationAgent);
                    Assert.IsTrue(after_drag[0].Equals(after_back[0]) && after_drag[1].Equals(after_back[1]), "Sticker moved");                 
                    

                   

                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyInteractiveInTeacherInboxNotebookReview(inboxAutomationAgent), "Interactive is not available");

                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 778, 578);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 778, 578);
                    inboxAutomationAgent.WaitForElement("MediaLibrary", "BackButtonAtImageViewer", WaitTime.DefaultWaitTime);
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(inboxAutomationAgent);

                    //Verify the tools in notebook review page when googly eyes are OFF
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "2");
                    InboxCommonMethods.ClickOnGoogleEyes(inboxAutomationAgent);
                    InboxCommonMethods.VerifyClosedGoogleEyes(inboxAutomationAgent);
                    NotebookCommonMethods.VerifyAnnotationLayerOFFNotebook(inboxAutomationAgent);

                    Assert.IsTrue(InboxCommonMethods.VerifyDataSaved(inboxAutomationAgent, "Doctor"), "Data Saved not Found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyNumberLineInNotebook(inboxAutomationAgent), "Number line not found on notebook");
                    Assert.IsTrue(InboxCommonMethods.VerifyRowsAndCOlumns(inboxAutomationAgent), "Table not found");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54280", true);

                    NotebookCommonMethods.ClickonCrayonButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCrayonButtonIsON(inboxAutomationAgent));

                    InboxCommonMethods.ClickOnEraserButton(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyEraserButtonIsON(inboxAutomationAgent));

                    NotebookCommonMethods.ClickOnStampButton(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyStampOverlay(inboxAutomationAgent), "Stamp menu found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool not active");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53694", true);

                    NotebookCommonMethods.VerifyGrabHandle(inboxAutomationAgent);
                    int count_before = NotebookCommonMethods.GetCountOfNumberLines(inboxAutomationAgent);
                    NotebookCommonMethods.DragGrabHandleRight(inboxAutomationAgent);
                    int count_after = NotebookCommonMethods.GetCountOfNumberLines(inboxAutomationAgent);
                    Assert.AreEqual(count_before, count_after, "Number Line tool is editable");

                    InboxCommonMethods.TapInsideRowFieldInTeacherInbox(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyUserAbleToTypeInTeacherInboxRowField(inboxAutomationAgent), "Not able to type inside column area");
                    
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        //US10338

       /* [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10485")]
        [WorkItem(54380), WorkItem(54383), WorkItem(54382), WorkItem(54384), WorkItem(54385)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyStudentSharedBooksDisplayInCorrectShape()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54380,TC54382,TC54383,TC54384,TC54385: Verify the student shared Books will display in correct shape (portrait, landscape, square) in ELA tab"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    
                    BookBuilderCommonMethods.sendBooksToTeacher(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    //Teacher Inbox Verification
                    BackUpAndRestoreCommonMethods.InitialStepsToReachBookBuilder(inboxAutomationAgent, "TeacherELA");
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherELA");               

                   

                    Assert.IsTrue(InboxCommonMethods.VerifyPotraitBookIsPresent(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyLanscapeBookIsPresent(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifySquareBookIsPresent(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54380", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54383", true);
                    Assert.IsTrue(InboxCommonMethods.VerifyHeaderFooterAfterTappingBookInInbox(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54384", true);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 100, 100);
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    
                    int countBefore = InboxCommonMethods.countOfBooks(inboxAutomationAgent);
                    InboxCommonMethods.SelectInboxCheckBoxtoDelete(inboxAutomationAgent, "1");
                    InboxCommonMethods.SelectInboxCheckBoxtoDelete(inboxAutomationAgent, "2");
                    int checkBoxCount = InboxCommonMethods.countOfCheckedItems(inboxAutomationAgent);
                    Assert.IsTrue(checkBoxCount.Equals("1"), "checked Box Count didn't match");
                    InboxCommonMethods.selectDeleteButtonInInbox(inboxAutomationAgent);
                    int countAfter = InboxCommonMethods.countOfBooks(inboxAutomationAgent);
                    Assert.IsTrue(countAfter.Equals(countBefore - 1), "Count didn't match");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54385", true);
                    InboxCommonMethods.VerifyStudentNameLabelForBooks(inboxAutomationAgent, "lakshmi");
                    InboxCommonMethods.VerifyDateTimeStampLabelForBooks(inboxAutomationAgent, "lakshmi");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54382", true);

                    
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }

                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        //US10513: X - K1-iOS - Inbox: Student Inbox - Open Items

      /*  [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10513")]
        [WorkItem(54659)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherFeedbackOverlayWithAudioAndTextComment()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54659: verify the Teacher Feedback Overlay when Teacher has added both Audio and Text Comments as Feedback"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.addAudioNoteToStudent(inboxAutomationAgent);
                    InboxCommonMethods.addCommentToStudent(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickOnSendButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "StudentSec01");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent));
                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }*/

      /*  [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10513")]
        [WorkItem(54660)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherFeedbackOverlayWithTextCommentAlone()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54660: verify the Teacher Feedback Overlay when Teacher has added both Audio and Text Comments as Feedback"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");

                    InboxCommonMethods.addCommentToStudent(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickOnSendButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "StudentSec01");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent));
                    Assert.IsFalse(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent));
                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10513")]
        [WorkItem(54661)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherFeedbackOverlayWithAudioAlone()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54661: verify the Teacher Feedback Overlay when Teacher has added both Audio and Text Comments as Feedback"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.addAudioNoteToStudent(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickOnSendButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "StudentSec01");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent), "Comment note is Present");
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent), "Audio Note not present");

                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10513")]
        [WorkItem(54662)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTeacherFeedbackOverlayWithOutAudioOrComment()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC54662: verify the Teacher Feedback Overlay when Teacher has added both Audio and Text Comments as Feedback"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");

                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    ColdWriteCommonMethods.ClickOnSendButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "StudentSec01");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    InboxCommonMethods.VerifyStudentOvervlayItems(inboxAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyCommentNote(inboxAutomationAgent), "Comment note is Present");
                    Assert.IsFalse(InboxCommonMethods.VerifyAudioNote(inboxAutomationAgent), "Audio Note is present");

                    InboxCommonMethods.ClickNotebookIcon(inboxAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(inboxAutomationAgent), "Tool active");
                    NavigationCommonMethods.ClickOnBackIcon(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }*/

        //US13356
      /*  [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US13356")]
        [WorkItem(55792), WorkItem(55794)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNewMouseAssetWithStudentInfo()
        {
            using (inboxAutomationAgent = new AutomationAgent("TC55792,TC55794: Verify Teacher Review- Update Student info in Teacher Review view with new mouse asset"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    inboxAutomationAgent.WaitForElement("InboxView", "NewBannerInboxItem", WaitTime.MediumWaitTime);
                    if (inboxAutomationAgent.IsElementFound("InboxView", "NewBannerInboxItem"))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                            InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                            String data = InboxCommonMethods.VerifyNewMouseAssetInNotebookReview(inboxAutomationAgent);
                            EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                            String unitName = InboxCommonMethods.GetCurrentUnitInCalendarView(inboxAutomationAgent);
                            String data1 = InboxCommonMethods.VerifyDataLabelInCalendarView(inboxAutomationAgent);
                            Assert.IsTrue(data.Contains(data1), "date and time is not displayed in the String");
                            Assert.IsTrue(data.Contains(unitName), "Unit name is matched");

                        }
                    }


                    LoginCommonMethods.Logout(inboxAutomationAgent);

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }*/

        //US9804

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US13356")]
        [WorkItem(14)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyImportantFunctionalitiesOfInboxForTeacher2()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC14: Verify Teacher Review- Inbox Annotation verification in Different Scenarios"))
            {
                try
                {
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    string tcountBefore = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);



                    BookBuilderCommonMethods.sendBooksToTeacher(inboxAutomationAgent);
                    LoginCommonMethods.Logout(inboxAutomationAgent);
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec01", 1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    string tcountAfter = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                    while (tcountAfter.Equals(tcountBefore))
                    {
                        inboxAutomationAgent.Sleep(10000);
                        InboxCommonMethods.ClickOnMathButton(inboxAutomationAgent);
                        InboxCommonMethods.ClickOnELAButton(inboxAutomationAgent);
                        string tcountAfter1 = InboxCommonMethods.GetCountOfNewInboxItems(inboxAutomationAgent);
                        if (!tcountAfter1.Equals(tcountBefore))
                            break;
                    }

                    Assert.IsTrue(InboxCommonMethods.VerifyPotraitBookIsPresent(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifyLanscapeBookIsPresent(inboxAutomationAgent));
                    Assert.IsTrue(InboxCommonMethods.VerifySquareBookIsPresent(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54380", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54383", true);
                    InboxCommonMethods.ClickOnSquareBook(inboxAutomationAgent);
                    inboxAutomationAgent.WaitforElement("BookBuilderView", "CoverInFooter", "", WaitTime.DefaultWaitTime);
                    Assert.IsTrue(InboxCommonMethods.VerifyHeaderFooterAfterTappingBookInInbox(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54384", true);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 100, 100);
                    NavigationCommonMethods.ClickOnBackIconFromLessonStandard(inboxAutomationAgent);

                    string label = inboxAutomationAgent.GetElementText("InboxView", "DateLabelInCalendarView");
                    InboxCommonMethods.SelectInboxCheckBoxtoDelete(inboxAutomationAgent, 1074, 544);
                    InboxCommonMethods.SelectInboxCheckBoxtoDelete(inboxAutomationAgent, 634, 544);
                    int checkBoxCount = InboxCommonMethods.countOfCheckedItems(inboxAutomationAgent);
                    Assert.IsTrue(checkBoxCount.Equals(1), "checked Box Count didn't match");
                    InboxCommonMethods.selectDeleteButtonInInbox(inboxAutomationAgent);

                    string label1 = inboxAutomationAgent.GetElementText("InboxView", "DateLabelInCalendarView");
                    while (label1.Equals(label))
                    {
                        InboxCommonMethods.SelectInboxCheckBoxtoDelete(inboxAutomationAgent, 1074, 544);
                        InboxCommonMethods.selectDeleteButtonInInbox(inboxAutomationAgent);
                        string label2 = inboxAutomationAgent.GetElementText("InboxView", "DateLabelInCalendarView");
                        if (!label2.Equals(label1))
                            break;
                    }
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54385", true);

                    Assert.IsTrue(InboxCommonMethods.VerifyStudentDetailsForBook(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54382", true);


                    Assert.IsTrue(InboxCommonMethods.VerifyNEWbannerOnTheItemOneInTheInbox(inboxAutomationAgent, "1"));
                    int newBannerImageCount = InboxCommonMethods.GetSharedItemsNewBannerCount(inboxAutomationAgent);
                    InboxCommonMethods.ClickOnInboxItem(inboxAutomationAgent);
                    if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
                    {
                        inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                        inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
                    }

                    NotebookCommonMethods.ClickOnReviewSticker(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOverlay(inboxAutomationAgent), "Sticker overlay not found");
                    InboxCommonMethods.ClickOnYouDidIt(inboxAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(inboxAutomationAgent, 1432, 1030);

                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Added Annotation is not present");
                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                    {
                        inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
                    }

                    BookBuilderCommonMethods.VerifySentText(inboxAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyStandardSendBoxIsPresent(inboxAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Added Annotation is not present");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC46693", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC46675", true);
                    inboxAutomationAgent.SendText("{HOME}");
                    inboxAutomationAgent.LaunchApp();
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Added Annotation is not present");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC46688", true);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(inboxAutomationAgent, TurnWifiOff);
                    inboxAutomationAgent.LaunchApp();
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(inboxAutomationAgent), "Added Annotation is not present");
                    NavigationCommonMethods.ChangeWiFiConnectivity(inboxAutomationAgent, false);
                    inboxAutomationAgent.SendText("{HOME}");
                    inboxAutomationAgent.LaunchApp();
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC46692", true);
                    inboxAutomationAgent.WaitforElement("TeacherSupport", "BackIcon", "", WaitTime.DefaultWaitTime);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(inboxAutomationAgent);
                    int newBannerImageCount2 = InboxCommonMethods.GetSharedItemsNewBannerCount(inboxAutomationAgent);
                    Assert.IsTrue(newBannerImageCount2 < newBannerImageCount, "New Banner Image is still shown");
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC46673", true);
                    LoginCommonMethods.Logout(inboxAutomationAgent);                  

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }
        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10439")]
        [WorkItem(15)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyUsefulFunctionalityInInboxForTeacher()
        {
            using (inboxAutomationAgent = new AutomationAgent("MTC15: Functionalities of Comment Overlay"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(inboxAutomationAgent, "StudentSec02", 1);
                    InboxCommonMethods.NavigateTillInbox(inboxAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(inboxAutomationAgent, "1");
                    if (inboxAutomationAgent.IsElementFound("InboxView", "ShowAllStudentTag"))
                    {
                        inboxAutomationAgent.WaitforElement("InboxView", "InboxItemOfTeacher", "", WaitTime.DefaultWaitTime);
                        inboxAutomationAgent.Click("InboxView", "InboxItemOfTeacher");
                    }
                    BackUpAndRestoreCommonMethods.CheckingCharacterCountVariation(inboxAutomationAgent);
                    TeacherModeCommonMethods.ClickOnSaveButton(inboxAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(inboxAutomationAgent);
                    BackUpAndRestoreCommonMethods.CheckingCharacterCountVariation(inboxAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyEditCommentOverlay(inboxAutomationAgent), "Edit Comment Overlay Not Found");
                    InboxCommonMethods.ClickONDOneButton(inboxAutomationAgent);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54645", true);
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC54646", true);
                    //******CloseApplication is Not Working,So below Lines of Code is Commented***********//
                    //ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);                   
                    //while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                    //    {
                    //        inboxAutomationAgent.CloseApplication();
                    //        inboxAutomationAgent.LaunchApp();
                    //        inboxAutomationAgent.WaitForElementToVanish("StudentSetUp", "InprogressIcon", "", WaitTime.MediumWaitTime);
                    //    }
                    
                    //Assert.IsFalse(ColdWriteCommonMethods.VerifyStandardSendBoxIsPresent(inboxAutomationAgent));

                    ColdWriteCommonMethods.ClickAeroplaneToSend(inboxAutomationAgent);
                    if (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                        {
                              inboxAutomationAgent.SendText("{HOME}");
                              inboxAutomationAgent.Sleep(300000);
                              inboxAutomationAgent.LaunchApp();
                        }
                    while (inboxAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                    {
                        inboxAutomationAgent.WaitForElementToVanish("StudentSetup", "InprogressIcon");
                    }
                    
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyStandardSendBoxIsPresent(inboxAutomationAgent));
                    inboxAutomationAgent.AddSteptoSeeTestReport("TC53945", true);
                    LoginCommonMethods.Logout(inboxAutomationAgent);                 
                  

                }
                catch (Exception ex)
                {
                    inboxAutomationAgent.Sleep(2000);
                    inboxAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    inboxAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }

    }
}                  

                    
                   




    

