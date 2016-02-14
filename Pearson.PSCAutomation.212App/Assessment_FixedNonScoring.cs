using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class AssessmentFixedNonScoring
    {
        public AutomationAgent AssessmentAutomationAgent;


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8200")]
        [Priority(1)]
        [WorkItem(45932), WorkItem(45933), WorkItem(45934), WorkItem(45968), WorkItem(45969), WorkItem(45970)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyTeacherPreviewAssessmentForFixedAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45932, TC45933, TC45934, TC45968, TC45969, TC45970 :Verify the Teacher Preview Assessment Screen for Fixed Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedFixedAssessmentName = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    string ScoringOverviewScreenName = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", ScoringOverviewScreenName, "Preview Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45932", true);
                    string PreviewAssessmentName = AssessmentCommonMethods.GetTextFromPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual(ExpectedFixedAssessmentName, PreviewAssessmentName, "Assessment Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45933", true);
                    Assert.IsTrue(AssessmentCommonMethods.QuestionsTabAndStandardTabPresent(AssessmentAutomationAgent), "Question And Standard Tab Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45934", true);
                    Assert.IsTrue(AssessmentCommonMethods.QuestionsTabSelectedByDefaultPresent(AssessmentAutomationAgent), "Question Tab Is Not Selected By Default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45968", true);
                    Assert.IsTrue(AssessmentCommonMethods.QuestionTabViewPresent(AssessmentAutomationAgent), "Question View Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45969", true);
                    Assert.IsTrue(AssessmentCommonMethods.StandardTabViewPresent(AssessmentAutomationAgent), "Standard View Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45970", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8200")]
        [Priority(2)]
        [WorkItem(45971), WorkItem(45972), WorkItem(45974), WorkItem(45975), WorkItem(45988), WorkItem(45989), WorkItem(45976), WorkItem(45982)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyNavigationInTeacherPreviewAssessmentForFixedAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45971,TC45972,TC45974,TC45975,TC45988,TC45989,TC45976,TC45982:Verify the Navigation in Teacher Preview Assessment Screen for Fixed Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifiesPreviewScreenBodyPresent(AssessmentAutomationAgent), "Question Content Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45972", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifiesPreviewButtonPresent(AssessmentAutomationAgent), "Previous Button Is Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45974", true);
                    int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInPreviewScreen"));
                    int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInPreviewScreen"));
                    if (currentQuestionNumber < TotalQuestions)
                    {
                        AssessmentCommonMethods.NavigateToNextQuestioInPreviewScreen(AssessmentAutomationAgent);
                        Assert.IsTrue(AssessmentCommonMethods.VerifiesPreviousButtonPresentInPreview(AssessmentAutomationAgent), "Previous Button Not Present");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45975", true);
                        Assert.IsTrue(AssessmentCommonMethods.VerifiesNextButtonPresentInPreview(AssessmentAutomationAgent), "Next Button Not Displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45988", true);
                        Assert.AreEqual("2.", AssessmentCommonMethods.VerifiesQuestionNumberInPreviewScreen(AssessmentAutomationAgent), "Question Number Not Found");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45989", true);
                        AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                        Assert.AreEqual("1.", AssessmentCommonMethods.VerifiesQuestionNumberInPreviewScreen(AssessmentAutomationAgent), "Question Number Not Found");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45976", true);
                        AssessmentCommonMethods.NavigateToLastQuestioInPreviewScreen(AssessmentAutomationAgent);
                        Assert.IsFalse(AssessmentCommonMethods.VerifiesNextButtonPresentInPreview(AssessmentAutomationAgent), "Next Button Is Displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45982", true);
                        Assert.IsTrue(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Rubric Panel Not Present");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45971", true);
                    }                    
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8195")]
        [Priority(1)]
        [WorkItem(43673), WorkItem(43677), WorkItem(43686), WorkItem(43832), WorkItem(43829), WorkItem(43830), WorkItem(43831), WorkItem(43687), WorkItem(43688), WorkItem(43683)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyScreenAndFunctionalityForEachStateInAssessmentOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43673,TC43677,TC43686,TC43832,TC43829,TC43830,TC43831,TC43687,TC43688,TC43683: Verify Screen And Functionality For Each State In Assessment Overview"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);

                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43673", true);


                    Assert.IsTrue(AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent), "Assessment Progress Overview Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43677", true);

                    String TotalStudentsAvailable = AssessmentCommonMethods.GetTextOfTotalStudentsinOverview(AssessmentAutomationAgent);
                    Assert.AreEqual(UnitStatus[9] + " Students", TotalStudentsAvailable, "Total Student Count Mismatch");
                    string ActualSectionTitle = AssessmentCommonMethods.GetSectionTitleFromAssessmentOverview(AssessmentAutomationAgent);
                    Assert.IsTrue(ActualSectionTitle.Contains(UnitStatus[4]), "Section Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43686", true);

                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewScoreButtonFound(AssessmentAutomationAgent), "Score Button Is Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewViewReportButtonFound(AssessmentAutomationAgent), "Report Button Is Not Found");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoresButtonDisabledinAssessmnetOverview(AssessmentAutomationAgent), "Release score button is not disabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43832", true);


                    Assert.IsTrue(AssessmentCommonMethods.UnlockAssessmentsLinkPresent(AssessmentAutomationAgent), "Lock And Unlock Link Is Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43829", true);

                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.UnlockModalScreenFound(AssessmentAutomationAgent), "Unlock Modal Screen Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43830", true);

                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    string ActualLockedCount = AssessmentCommonMethods.GetTextFromUnlockAssessmentLink(AssessmentAutomationAgent);
                    String[] LockedCount = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    Assert.AreEqual("Locked for " + LockedCount[5], ActualLockedCount, "Locked Student Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43831", true);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    string ScoringOverviewScreenName = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", ScoringOverviewScreenName, "Preview Assessment Screen Name Mismatch");
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43687", true);

                    Assert.IsTrue(AssessmentCommonMethods.ProgressBarViewPresent(AssessmentAutomationAgent), "Dynamic Progress Status Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43688", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentManagerButtonFound(AssessmentAutomationAgent), "Assessment Manager Button Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43683", true);

                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9117"), TestCategory("US9601")]
        [Priority(1)]
        [WorkItem(43865), WorkItem(43866), WorkItem(44028), WorkItem(43867), WorkItem(43868), WorkItem(44012), WorkItem(44013), WorkItem(44014), WorkItem(44015), WorkItem(44032), WorkItem(44016), WorkItem(44022), WorkItem(44019), WorkItem(44018)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyTheLockAndUnlockScreenFunctionality()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43865,TC46394,TC43866,TC44028,TC43867,TC43868,TC44012,TC44013,TC44014,TC44015,TC44032,TC44016,TC44022,TC44019,TC44018 :Verify The Lock And Unlock Screen Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedAssessmentUnitTitle = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);

                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43865", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46394", true);

                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.UnlockModalScreenFound(AssessmentAutomationAgent), "Assessment Overlay Screen Is Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43866", true);

                    Assert.IsTrue(AssessmentCommonMethods.UnLockAllButtonPresent(AssessmentAutomationAgent), "Unlock Button Not Displayed By Default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44028", true);

                    string ActualAssessmentTitle1 = AssessmentCommonMethods.GetAssessmentTitleFromAssessmentOverlayScreen(AssessmentAutomationAgent);
                    Assert.AreEqual(ExpectedAssessmentUnitTitle, ActualAssessmentTitle1, "Assessment Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43867", true);


                    Assert.AreEqual("Lock or Unlock to manage student access to the assessment", AssessmentCommonMethods.GetLockOrUnlockToManageStudentFromAssessmentOverlayScreen(AssessmentAutomationAgent), "Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43868", true);


                    string ActualAssessmentProgressStatus = AssessmentCommonMethods.GetAssessmentProgressStatusFromAssessmentOverlayScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Pending", ActualAssessmentProgressStatus, "Assessment Progress Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44012", true);


                    string ActualSectionNumber = AssessmentCommonMethods.GetUnitTitleFromAssessmentOverlayScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(ActualSectionNumber.Contains(UnitStatus[4]), "Section Number Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44013", true);

                    string ActualLockedCount = "Locked For " + AssessmentCommonMethods.GetLockedForTextPresent(AssessmentAutomationAgent);
                    String[] LockedCount = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    Assert.AreEqual("Locked For " + LockedCount[6], ActualLockedCount, "Student Locked Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44014", true);


                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverlayStudenCellFound(AssessmentAutomationAgent), "Assessment Overlay Student Cell Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44015", true);


                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    String UnlockedStudentName = AssessmentCommonMethods.GetStudentNameFromAssessmentModalScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    Assert.AreEqual(UnlockedStudentName, AssessmentCommonMethods.GetTextFromAssessmentTable(AssessmentAutomationAgent), "Student Name Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44032", true);

                    AssessmentCommonMethods.ClickLockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    String AssessmentIsLockedMessage = AssessmentCommonMethods.ValidateAssessmentLockMessage(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment is Locked.", AssessmentIsLockedMessage, "Student Name Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44016", true);

                    Assert.IsTrue(AssessmentCommonMethods.UnlockAssessmentsLinkPresent(AssessmentAutomationAgent), "Lock And Unlock Screen Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44022", true);

                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverlayStudenCellFound(AssessmentAutomationAgent), "Able To Access Background Functionality");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44019", true);
                    AssessmentCommonMethods.ClickAssessmentOverlayClose(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.StatusBarTabViewPresent(AssessmentAutomationAgent), "Assessment Overlay Screen Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44018", true);

                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8193")]
        [Priority(1)]
        [WorkItem(43512), WorkItem(43513), WorkItem(43514), WorkItem(43515), WorkItem(43516), WorkItem(43517), WorkItem(43521)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyUnitDisplayAndSelectionInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43512,TC43513,TC43514,TC43515,TC43516,TC43517,TC43521: Verify Unit Display And Selection In Assessment Manager"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);

                    Assert.AreEqual(UnitStatus[19], AssessmentCommonMethods.GetUnitAfterSelectingFromDropdown(AssessmentAutomationAgent), "Unit1 Not Selected By Default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43514", true);

                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentUnitDropDownMenuPresent(AssessmentAutomationAgent), "Unit Selection Dropdown Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43512", true);
                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);

                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual(UnitStatus[20], AssessmentCommonMethods.GetUnitAfterSelectingFromDropdown(AssessmentAutomationAgent), "Selected Unit Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43513", true);


                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyAssessmentUnitDropDownMenuPresent(AssessmentAutomationAgent), "Unit Dropdown Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43515", true);


                    AssessmentCommonMethods.AssessmentScrollToUnit(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual("Unit " + UnitStatus[0], AssessmentCommonMethods.VerifiesUnitStatusInDropdown(AssessmentAutomationAgent, UnitStatus[0]), "Unit Number And Status Are Not Displayed");
                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43516", true);

                    AssessmentCommonMethods.AssessmentScrollToUnit(AssessmentAutomationAgent, UnitStatus[0]);
                    String ExpectedUnitStatus = "Unit " + UnitStatus[0];
                    Assert.AreEqual(ExpectedUnitStatus, AssessmentCommonMethods.VerifiesUnitStatusInDropdown(AssessmentAutomationAgent, UnitStatus[0]), "Unit Status Mismatch");
                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43517", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    NavigationCommonMethods.VerifyDashboard(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43521", true);

                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9218")]
        [Priority(1)]
        [WorkItem(46246), WorkItem(46251), WorkItem(46247), WorkItem(46245), WorkItem(46248), WorkItem(46249), WorkItem(46250)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyUnitTitleDropDownAndAssessmentStatusInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46246,TC46251,TC46247,TC46245,TC46248,TC46249,TC46250: Verify Unit Title Drop Down And Assessment Status In Assessment Manager"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySubStatusDisplayAtAssessmentManager(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46246", true);

                    AssessmentCommonMethods.VerifyNoGrayColorSeparatorsVertically(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46251", true);

                    AssessmentCommonMethods.VerifyUnitSelectionDropDownBoxAtAssessmentManager(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46247", true);

                    string ActualSubStatus1 = AssessmentCommonMethods.GetStartedSubStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.IsTrue(ActualSubStatus1.Contains("Started"), "Sub Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46245", true);

                    AssessmentCommonMethods.VerifyScrollableUnitSelectionDropDownBox(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46248", true);


                    AssessmentCommonMethods.AssessmentScrollToUnit(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual("Unit " + UnitStatus[0], AssessmentCommonMethods.VerifiesUnitStatusInDropdown(AssessmentAutomationAgent, UnitStatus[0]), "Unit Title And Status Mismatch");
                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46249", true);

                    AssessmentCommonMethods.VerifyNoGrayColorSeparatorsVertically(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46250", true);

                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(2)]
        [WorkItem(46393)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAssessmentScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46393 : Verify whether the teacher is able to tap on the assessment tile and view the assessments in ‘Preview’ mode when the assessment is in ‘Locked’ state."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }

            }
        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(44020)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLockUnlockSyncWithStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC44020: Verify the teacher should be displayed with the lock/unlock icon which syncs with the student’s assessment status in the assessment overlay screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    if (AssessmentCommonMethods.LockAssessmentsLinkPresent(AssessmentAutomationAgent))
                        AssessmentCommonMethods.ClickLockAssessments(AssessmentAutomationAgent);
                    else
                        AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStudentsWithLockUnlockIcons(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToCloseLockUnlockPopup(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(44068)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAssessmentInProgressStateisTabale()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC44068 : Verify teacher should be able to tap on the assessment "))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnInProgressFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(44069)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnAssessmentRedirectOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC44069: Verify teacher should be navigated to the Assessment Overview page  "))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9874")]
        [Priority(1)]
        [WorkItem(52392), WorkItem(52393)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyManualRefreshAndLoadedIconInAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52392,TC52393: Verify the data refresh for Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    Assert.IsTrue(AssessmentCommonMethods.LoaderIconPresent(AssessmentAutomationAgent), "Loader Icon Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52392", true);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnRefreshIcon(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.LoaderIconPresent(AssessmentAutomationAgent), "Loader Icon Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52393", true);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8192")]
        [Priority(1)]
        [WorkItem(43473), WorkItem(43826), WorkItem(43507), WorkItem(43510), WorkItem(43511), WorkItem(43508), WorkItem(43509)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyAssessmentTypeDetailsAndScrollingInAssessmentManagerPage()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43473,TC43826,TC43507,TC43510,TC43511,TC43508,TC43509: Verify the Assessment Type,details,scrolling and navigation to Assessment Manager Page"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    DashboardCommonMethods.VerifyUserIsOnDashBoard(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43473", true);

                    Assert.IsTrue(AssessmentCommonMethods.MyDashBoardButtonFound(AssessmentAutomationAgent), "Teacher Dashboard Not Present.Application Crashed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43826", true);

                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentManagerButtonFound(AssessmentAutomationAgent), "Assessment Manager Page Is Not Present");
                    Assert.AreEqual(UnitStatus[19], AssessmentCommonMethods.GetUnitAfterSelectingFromDropdown(AssessmentAutomationAgent), "Unit1 Not Selected By Default");
                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentUnitDropDownMenuPresent(AssessmentAutomationAgent), "Unit Selection Dropdown Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43507", true);
                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyProgressStatusDisplayAtAssessmentManager(AssessmentAutomationAgent), "Progress Status Not Found");
                    AssessmentCommonMethods.VerifySubStatusDisplayAtAssessmentManager(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43510", true);
                    if (!AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Down, 500, 2000);
                        Assert.IsTrue(AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent));                        
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43511", true);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.IsTrue(AssessmentCommonMethods.FixedAssessmentLabelPresent(AssessmentAutomationAgent), "Fixed Assessment Type Not Present");
                    if (!AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Down, 500, 2000);
                        Assert.IsTrue(AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent));
                    }                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43508", true);

                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43509", true);

                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

       

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(52809)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAssessmentNameInAllForthCominScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52809: Verify  The teacher should be displayed with same assessment name in all the forthcoming screen which is same as the name in the assessment manager screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    string assessmentName = AssessmentCommonMethods.GetAssessmentNameFromAssessmentManager(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyAssessmentName(AssessmentAutomationAgent, assessmentName);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8195")]
        [Priority(2)]
        [WorkItem(43836), WorkItem(43692), WorkItem(43827), WorkItem(43828)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyTabsgettingHighlightedWithStudentListInAssessmentOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43836,TC43692,TC43827,TC43828: Verify the tabs getting highlighted when tapped on progress bar in the Assessment Overview page"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    //NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    //AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    //AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedFixedAssessmentName = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnLockAllButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyProgressBarHeaderColorBlue(AssessmentAutomationAgent), "Progress Tab Not Highlighted");
                    int notStartedCount = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList notStartedStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, notStartedCount);
                    Assert.IsFalse(notStartedStudentList[0].Equals(""), "Not Started Student List Is Empty");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43692", true);

                    ArrayList first_name = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Right, 500, 500);
                    ArrayList name_after_swipe = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent);
                    Assert.AreNotEqual(first_name[0], name_after_swipe[0], "Not able to do the Horizontal swipe.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43827", true);
                    AssessmentCommonMethods.ClickOnTheStartedTab(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43828", true);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickLockAllButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoresButtonDisabledinAssessmnetOverview(AssessmentAutomationAgent), "Release score button is not disabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43836", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9631")]
        [Priority(1)]
        [WorkItem(51890), WorkItem(51891), WorkItem(51893), WorkItem(51894), WorkItem(51898), WorkItem(51903), WorkItem(51904), WorkItem(51892), WorkItem(51902), WorkItem(51899), WorkItem(51900), WorkItem(51905), WorkItem(51896), WorkItem(51901), WorkItem(51906)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyTeacherPreviewAssessmentFunctionalitiesForMathAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51890,TC51891,TC51892,TC51893,TC51894,TC51898,TC51903,TC51904,TC51902,TC51899,TC51900,TC51905,TC51896,TC51901,TC51906  :Verify preview assessment functionalities for MATH teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("AdeleAlamedaTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("MATH", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentLinkInMathDashBoard(AssessmentAutomationAgent, UnitStatus[2]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedOngoingAssessmentTitle = AssessmentCommonMethods.GetTextFromMathOngoingAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMathExerciseInOngoingAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLinkIspresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51890", true);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    string mathPreviewAssessmentTitle = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
                    string QuestionLabelAtFooter = AssessmentCommonMethods.GetQuestionNumberLabelFromMathOngoingPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", mathPreviewAssessmentTitle, "Preview Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51891", true);
                    Assert.IsTrue(QuestionLabelAtFooter.Contains("Question"), "Question Label is not displayed incorrectly");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51905", true);
                    string PreviewAssessmentName = AssessmentCommonMethods.GetTextFromMathOngoingAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual(ExpectedOngoingAssessmentTitle, PreviewAssessmentName, "Assessment Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51892", true);
                    Assert.IsTrue(AssessmentCommonMethods.QuestionsAnswerAndStandardTabPresent(AssessmentAutomationAgent), "Question, Answer and Standard Tab Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51893", true);
                    Assert.IsTrue(AssessmentCommonMethods.QuestionsTabSelectedByDefaultPresent(AssessmentAutomationAgent), "Question Tab Is Not Selected By Default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51894", true);
                    Assert.IsTrue(AssessmentCommonMethods.QuestionTabViewPresent(AssessmentAutomationAgent), "Question View Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51898", true);
                    Assert.IsTrue(AssessmentCommonMethods.StandardTabViewPresent(AssessmentAutomationAgent), "Standard View Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51896", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifiesPreviewButtonPresent(AssessmentAutomationAgent), "Previous Button Is Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51899", true);
                    int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInPreviewScreen"));
                    int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInPreviewScreen"));
                    if (currentQuestionNumber < TotalQuestions)
                    {
                        Assert.IsTrue(AssessmentCommonMethods.VerifiesNextButtonPresentInPreview(AssessmentAutomationAgent), "Next Button Not Displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51903", true);
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                        AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                        Assert.AreEqual("2.", AssessmentCommonMethods.VerifiesQuestionNumberInPreviewScreen(AssessmentAutomationAgent), "Question Number Not Found");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51904", true);
                        Assert.IsTrue(AssessmentCommonMethods.VerifiesPreviewButtonPresent(AssessmentAutomationAgent), "Previous Button Is not displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51900", true);
                        AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                        Assert.AreEqual("1.", AssessmentCommonMethods.VerifiesQuestionNumberInPreviewScreen(AssessmentAutomationAgent), "Question Number Not Found");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51901", true);
                        AssessmentCommonMethods.NavigateToLastQuestioInPreviewScreen(AssessmentAutomationAgent);
                        Assert.IsFalse(AssessmentCommonMethods.VerifiesNextButtonPresentInPreview(AssessmentAutomationAgent), "Next Button Is Displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51902", true);
                    }                
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51906", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9312")]
        [Priority(1)]
        [WorkItem(46392)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyStartAssessmentDialogNotShownForTeacher()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46392:Verify whether the teacher is able to tap on the assessment tile and view the assessments in ‘Preview’ mode and the teacher should not be displayed with any start assessment dialog box."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent);
                    string PreviewAssessmentTitle = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", PreviewAssessmentTitle, "Start Assessment dialog box present");
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9641")]
        [Priority(1)]
        [WorkItem(52080), WorkItem(52083), WorkItem(52089), WorkItem(52091), WorkItem(52081), WorkItem(52092), WorkItem(52093), WorkItem(52090)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyStudentAbleToNavigateAndViewTheAssessmentStatusInAssessmentManagerScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52080,TC52083,TC52089,TC52091,TC52081,TC52092,TC52093,TC52090: Verify whether the student is able to get to assessment manager through the dashboard and view the assessment and the status."))
            {
                try
                {
                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentManagerButtonFound(AssessmentAutomationAgent), "Student dashboard page is not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52080", true);

                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual(UnitStatus[3], AssessmentCommonMethods.GetUnitAfterSelectingFromDropdown(AssessmentAutomationAgent), "Selected Unit Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52083", true);

                    AssessmentCommonMethods.ClickOnLockedAndUnlockedAssessment(AssessmentAutomationAgent, true);
                    Assert.IsFalse(AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52089", true);

                    Assert.IsTrue(AssessmentCommonMethods.FixedAssessmentLabelPresent(AssessmentAutomationAgent));
                    Assert.IsTrue(AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52091", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentPresentInStudentDashboard(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52081", true);

                    AssessmentCommonMethods.VerifyAssessmentStatusLabelockIconTitlePresent(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52092", true);

                    Assert.AreEqual("Not Started", AssessmentCommonMethods.VerifyAssessmentStatusAndLockIconInsync(AssessmentAutomationAgent), "Status is not sync with lock icon status");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52093", true);

                    AssessmentCommonMethods.ClickMyDashboardButtonInStudentAssessmentManager(AssessmentAutomationAgent);
                    String myDashBoardTitle = AssessmentCommonMethods.GetTitleFromStudentDashBoard(AssessmentAutomationAgent);
                    Assert.AreEqual("My Dashboard", myDashBoardTitle, "Student dashboard page is not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52090", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9268")]
        [Priority(1)]
        [WorkItem(52507), WorkItem(52509), WorkItem(52508), WorkItem(52510)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyInternetOfflineMessageWhenUnlockingAndLockingAssessmentForAStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52507,TC52509,TC52508,TC52510: Verify internet offline message when unlocking the assessment for student"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedFixedAssessmentName = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);

                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "lock/unlock assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52507", true);

                    AssessmentCommonMethods.ClickUnLockAllButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "unlock assessments for all the students");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52509", true);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);

                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "lock/unlock assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52508", true);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickUnLockAllButton(AssessmentAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickLockAllButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "lock assessments for all the students");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52510", true);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickLockAllButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }



        //Test Cases Teacher + Student Experience (Started,Submitted)

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9117")]
        [Priority(1)]
        [WorkItem(44023), WorkItem(44031), WorkItem(53578)]
        [Owner("Godwin Terence(godwin.terence")]
        public void VerifyLockAndResetModalScreenLabel()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC44023,TC44031,TC53578 :Verify Lock And Reset Modal Screen Label"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started");

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    Assert.AreEqual("Locks only students that have not yet started", AssessmentCommonMethods.GetLockOnlyStudentsNotStartedAssessmentOverlayScreen(AssessmentAutomationAgent), "Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44031", true);
                    Assert.AreEqual("Started", AssessmentCommonMethods.VerifyStudentAssessmentStatusInUnlockScreen(AssessmentAutomationAgent), "Assessment Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53578", true);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                    Assert.AreEqual("Lock Assessment and Clear All Data?", AssessmentCommonMethods.VerifyLockAndResetModalScreenLabel(AssessmentAutomationAgent), "Lock Reset Modal Screen Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44023", true);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9117")]
        [Priority(1)]
        [WorkItem(44024), WorkItem(44025), WorkItem(44029), WorkItem(44030), WorkItem(44033)]
        [Owner("Godwin Terence(godwin.terence")]
        public void VerifyLockUnlockCountUpdatesInLockAndResetModalScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC44024,TC44025,TC44029,TC44030,TC44033 :Verify Lock Unlock Count In Lock And Reset Modal Screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    String[] LockedCount = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.VerifyLockedStudentCount(AssessmentAutomationAgent, LockedCount[5]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44025", true);

                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.VerifyLockedStudentCount(AssessmentAutomationAgent, LockedCount[6]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44024", true);


                    AssessmentCommonMethods.ClickUnLockAllButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.LockAllButtonPresent(AssessmentAutomationAgent), "Lock All Button Not Changes To Unlock On Tapping");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44030", true);

                    AssessmentCommonMethods.VerifyLockedStudentCount(AssessmentAutomationAgent, LockedCount[7]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44033", true);

                    AssessmentCommonMethods.VerifyLockedStudentCount(AssessmentAutomationAgent, LockedCount[7]);
                    Assert.IsTrue(AssessmentCommonMethods.LockAllButtonPresent(AssessmentAutomationAgent), "Unlock Button Not Changes To Lock All On Tapping");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44029", true);
                    AssessmentCommonMethods.ClickLockAllButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9156")]
        [Priority(1)]
        [WorkItem(43856), WorkItem(43857), WorkItem(43850), WorkItem(43851), WorkItem(43855), WorkItem(43853), WorkItem(43852), WorkItem(43854)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void LockAndResetPopUpScreenFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43856, TC43857, TC43850, TC43851, TC43855, TC43853, TC43852, TC43854   :Verify whether the teacher is displayed with different options in the ‘Lock and reset data’ pop up."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started");

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickLockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCancelButtonInLockAndResetScreen(AssessmentAutomationAgent), "Cancel Button Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43856", true);
                    Assert.IsTrue(AssessmentCommonMethods.LockAndResetButton(AssessmentAutomationAgent), "Lock And Reset Button Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43857", true);

                    String LockAndResetDataHeader = AssessmentCommonMethods.GetHeaderFromLockAndResetDataScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Lock Assessment and Clear All Data?", LockAndResetDataHeader, "Lock Assessment And Clear All Data Not Found ");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43850", true);

                    String UnitName = AssessmentCommonMethods.GetUnitNameFromLockAndResetDataScreen(AssessmentAutomationAgent);
                    Assert.AreEqual(UnitStatusAfterAssessmentStarted[4], UnitName, "Unit Name Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43851", true);

                    String AlertText = AssessmentCommonMethods.GetAlertTextFromLockAndResetDataScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Lock & Reset will clear all student answers and reset the assessments", AlertText, "Alert Text Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43855", true);

                    String StatusInProgress = AssessmentCommonMethods.GetInProgressCountFromLockAndResetDataScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Student In Progress", StatusInProgress, "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43853", true);

                    String ProgressStatus = AssessmentCommonMethods.GetProgressStatusFromLockAndResetDataScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Status", ProgressStatus, "Assessment Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43852", true);

                    String SubmittedCount = AssessmentCommonMethods.GetSubmittedStatusAndCount(AssessmentAutomationAgent);
                    Assert.AreEqual("Students Submitted", SubmittedCount, "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43854", true);

                    AssessmentCommonMethods.ResetDataBackToDefault(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9156")]
        [Priority(1)]
        [WorkItem(43862), WorkItem(43861), WorkItem(43860)]
        [Owner("Godwin Terence(godwin.terence")]
        public void VerifyLockResetAndCancelFunctionalityInLockAndResetScreenForFixedAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43862,TC43861,TC43860 :Verify the functionality of the ‘Cancel’ button And Lock & Reset button in the ‘Lock and reset data’ pop up."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started");

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsCancelInLocksAndResetScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Lock or Unlock to manage student access to the assessment", AssessmentCommonMethods.GetLockOrUnlockToManageStudentFromAssessmentOverlayScreen(AssessmentAutomationAgent), "Lock And Reset Data Pop Up Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43862", true);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    string ActualLockedCount = "Locked For " + AssessmentCommonMethods.GetLockedForTextPresent(AssessmentAutomationAgent);
                    Assert.AreEqual("Locked For " + UnitStatus[6], ActualLockedCount, "Locked Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43861", true);
                    string ActualAssessmentProgressStatus = AssessmentCommonMethods.GetAssessmentProgressStatusFromAssessmentOverlayScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Pending", ActualAssessmentProgressStatus, "Assessment Progress Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43860", true);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8193")]
        [Priority(1)]
        [WorkItem(43518), WorkItem(43519)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyUnitInProgressScoringRequiredStatusDisplayedInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43518,TC43519:Verify Unit InProgress Scoring Required Status Displayed In Assessment Manager"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started");

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.AssessmentScrollToUnit(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[1]);
                    String ExpectedUnitStatus = "Unit : " + UnitStatus[1];
                    Assert.AreEqual(ExpectedUnitStatus, AssessmentCommonMethods.VerifiesUnitStatusInDropdown(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[1]), "Unit Status Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43518", true);
                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin1 = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);
                    TaskInfo taskInfo2 = studentLogin1.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                    Login teacherLogin2 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin2);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    String[] UnitStatusAfterAssessmentSubmitted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.AssessmentScrollToUnit(AssessmentAutomationAgent, UnitStatus[2]);
                    String ExpectedUnitStatus1 = "Unit : " + UnitStatus[2];
                    Assert.AreEqual(ExpectedUnitStatus1, AssessmentCommonMethods.VerifiesUnitStatusInDropdown(AssessmentAutomationAgent, UnitStatusAfterAssessmentSubmitted[2]), "Unit Status Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43519", true);
                    AssessmentCommonMethods.ClickUnitTitleDropdown(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentSubmitted[2]);
                    AssessmentCommonMethods.ClickFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
         }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(2)]
        [WorkItem(43531)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySubmittedAndStartedStatusInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43531: Verify that “Started” and “Submitted” sub statuses in the assessment manager page."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.VerifySubmittedStatusInAssessmentManger(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStartedStatusInAssessmentmanager(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8194")]
        [Priority(2)]
        [WorkItem(43523), WorkItem(43841), WorkItem(43522), WorkItem(43524), WorkItem(43525), WorkItem(43528), WorkItem(43526)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void StatusInAssessmentManagerBeforeAndAfterStudentstartsAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43523,TC43841,TC43522, TC43524, TC43525,TC43528,TC43526 : Verify the pending status when the students have not started the assessment but the teacher has unlocked the assessment."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Down, 500, 2000);
                    Assert.IsTrue(AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43841", true);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.LockIconInAssessmentManager(AssessmentAutomationAgent), "Lock Icon Is Not Present");
                    String AssessmentStatus = AssessmentCommonMethods.GetTextOfFixedAssessmentStatus(AssessmentAutomationAgent);
                    Assert.AreEqual("Pending", AssessmentStatus, "Assessment Status Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43522", true);

                    Assert.IsTrue(AssessmentCommonMethods.LockIconInAssessmentManager(AssessmentAutomationAgent));
                    String AssessmentStatusOne = AssessmentCommonMethods.GetTextOfFixedAssessmentStatus(AssessmentAutomationAgent);
                    Assert.AreEqual("Pending", AssessmentStatusOne, "Assessment Pending Status Not Found");
                    Assert.AreEqual("Started: " + UnitStatus[7], AssessmentCommonMethods.GetStartedSubStatusFromAssessmentManager(AssessmentAutomationAgent), "Sub Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43524", true);


                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent), "Unlock Icon Is Not Present");
                    String AssessmentPendingStatus = AssessmentCommonMethods.GetPendingStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentPendingStatus.Contains("Pending"), "Assessment Pending Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43523", true);



                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started");

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[1]);
                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent), "Unlock Icon Not Present");
                    String InProgressStatus = AssessmentCommonMethods.GetInProgressStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual("In Progress", InProgressStatus, "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43525", true);

                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent), "Unlock Icon Not Found");
                    String StartedSubStatus = AssessmentCommonMethods.GetStartedSubStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual("Started: " + UnitStatus[11], StartedSubStatus, "Sub Status Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43528", true);
                    Assert.AreEqual("In Progress", AssessmentCommonMethods.GetInProgressStatusFromAssessmentManager(AssessmentAutomationAgent), "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43526", true);

                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8194")]
        [Priority(1)]
        [WorkItem(43530), WorkItem(43527), WorkItem(43536)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void StatusInAssessmentManagerStudentSubmitsAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43530, TC43527,TC43536 :  Verify whether the ‘Scoring required’ text is displayed if students have submitted the assessment when the main status in ‘In Progress’ state."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentSubmitted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatusAfterAssessmentSubmitted[4], UnitStatusAfterAssessmentSubmitted[2]);

                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent), "Unlock Icon Not Present");
                    String SubmittedSubStatus = AssessmentCommonMethods.GetSubmittedSubStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual("Submitted: " + UnitStatusAfterAssessmentSubmitted[11], SubmittedSubStatus, "Sub Status Not Found");
                    Assert.AreEqual("In Progress", AssessmentCommonMethods.GetInProgressStatusFromAssessmentManager(AssessmentAutomationAgent), "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43527", true);
                    if (AssessmentCommonMethods.GetDeliveredStatusFromAssessmentManager(AssessmentAutomationAgent).Equals("Delivered"))
                    {
                        Assert.AreEqual("Scoring Required", AssessmentCommonMethods.GetScoringRequiredStatusFromAssessmentManager(AssessmentAutomationAgent), "Status Not Found");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43536", true);
                    }
                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent), "Unlock Icon Not Present");
                    String ScoringRequiredStatus = AssessmentCommonMethods.GetScoringRequiredStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Required", ScoringRequiredStatus, "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43530", true);

                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8199")]
        [Priority(1)]
        [WorkItem(45517), WorkItem(45518), WorkItem(45519), WorkItem(45520), WorkItem(45521), WorkItem(45522), WorkItem(45523), WorkItem(45524), WorkItem(45525), WorkItem(45526), WorkItem(45527)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void StudentAssessmentNavigationButtonFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45517, TC45518, TC45519, TC45520, TC45521, TC45522, TC45523, TC45524, TC45525, TC45526, TC45527) : Verify the functionality of Student taking assessment."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "ReviewAndSubmit");
                    String PageTitle = AssessmentCommonMethods.GetTextFromStudentAssessmentSummaryPage(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Summary", PageTitle, "Student Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45518", true);

                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent), "Assessment Submission Confirmation Pop Up not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45519", true);

                    String SubmitAssessmentTitle = AssessmentAutomationAgent.GetElementText("AssessmentView", "SubmitAssessmentPopUpTitle");
                    Assert.AreEqual("Submit Assessment?", SubmitAssessmentTitle, "Submit Title is not displayed in Confirmation Pop-Up");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45527", true);

                    Assert.IsTrue(AssessmentCommonMethods.SubmitInConfirmationPopUpFound(AssessmentAutomationAgent), "Submit button in Pop Up not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45520", true);

                    Assert.IsTrue(AssessmentCommonMethods.CancelInConfirmationPopUpFound(AssessmentAutomationAgent), "Cancel button in Pop Up not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45521", true);

                    AssessmentCommonMethods.ClickCancelInAssessmentCompletionPopUp(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.SubmitInStudentAssessmentSummary(AssessmentAutomationAgent), "Assessment Summary Page with submit button is  not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45525", true);

                    AssessmentCommonMethods.ClickCancelInAssessmentCompletionPopUp(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.SubmitInStudentAssessmentSummary(AssessmentAutomationAgent), "Submit button is  not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45526", true);

                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    String[] StudentUnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    Assert.AreEqual("Unit 10: Assessment Unit1", AssessmentCommonMethods.GetUnitNameAfterSubmittingAssessment(AssessmentAutomationAgent, StudentUnitStatus[0]), "Assessment title name mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45522", true);

                    Assert.AreEqual("Unit 10: Assessment Unit1", AssessmentCommonMethods.GetUnitNameAfterSubmittingAssessment(AssessmentAutomationAgent, StudentUnitStatus[0]), "Start Assessment Screen is not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45523", true);

                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent), "Start Assessment Confirmation Pop Up is shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45524", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin2 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin2);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9791")]
        [Priority(1)]
        [WorkItem(51946), WorkItem(51945), WorkItem(51947), WorkItem(51948)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyTeacherCanViewTheAssessmentsInPreviewModeOnLockUnlockAndSubmitState()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51946,TC51945,TC51947,TC51948: Verify whether the teacher is able to tap on the assessment tile and view the assessments in ‘Preview’ mode when the assessment is in Locked ,Unlocked and Submit response state."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Locked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51945", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51946", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Unlocked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51947", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Submitted Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51948", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9715")]
        [Priority(1)]
        [WorkItem(46669), WorkItem(46668)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyTestPlayerForStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46669,TC46668:Verify the test player page for students"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Rubric Panel is not present in Teacher Preview");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoreButtonInTeacherPreview(AssessmentAutomationAgent), "Rubric Panel is not present in Teacher Preview");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyHideRubricTabIsPresentInTeacherPreview(AssessmentAutomationAgent), "Hide Tab is not present in Teacher Preview");
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46669", true);

                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent);
                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent))
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.Sleep(5000);
                    Assert.IsTrue(AssessmentCommonMethods.SummaryButtonInTestPlayer(AssessmentAutomationAgent), "Summary Button Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.NextButtonFoundInTestPlayer(AssessmentAutomationAgent), "Next Button Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlagForLaterButtonIsPresent(AssessmentAutomationAgent), "Flag for later button not present");
                    Assert.IsTrue(AssessmentCommonMethods.TimerFoundInAssessmentSummaryPage(AssessmentAutomationAgent), "Timer Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.CounterFound(AssessmentAutomationAgent), "Counter Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46668", true);

                    while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextButtonInTestPlayerFound"))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.ClickSubmitButtonInLastQuestionOfAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(46395)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAssessmentPreviewModeInSubmitResponse()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46395: Verify The teacher should be able to view the assessments in preview mode by tapping on the assessment tile when the assessment is in “Submit response’ state."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickOnSubmittedFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8196")]
        [Priority(1)]
        [WorkItem(43844), WorkItem(43845), WorkItem(43846), WorkItem(43847), WorkItem(43848), WorkItem(43849)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void StudentAssessmentTestPlayerFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43844, TC43845, TC43846, TC43847, TC43848, TC43849  :Verify that the student can open the Test Player"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentAutomationAgent.Sleep(5000);
                    // AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent, "1");
                    AssessmentAutomationAgent.Sleep(5000);

                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent))
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.Sleep(5000);
                    Assert.IsTrue(AssessmentCommonMethods.SummaryButtonInTestPlayer(AssessmentAutomationAgent), "Summary Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43844", true);
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43845", true);
                    String TestPlayerTitle = AssessmentCommonMethods.GetTextofTitleFromTestPlayer(AssessmentAutomationAgent);
                    Assert.IsTrue(TestPlayerTitle.Contains("Assess"), "Test Player Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43846", true);

                    int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                    int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                    if (currentQuestionNumber == 1)
                    {
                        Assert.IsTrue(AssessmentCommonMethods.NextButtonFoundInTestPlayer(AssessmentAutomationAgent));
                        Assert.IsFalse(AssessmentCommonMethods.PreviousButtonFoundInTestPlayer(AssessmentAutomationAgent));
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43848", true);
                    }
                    for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    if (currentQuestionNumber == 4)
                    {
                        Assert.IsTrue(AssessmentCommonMethods.PreviousButtonFoundInTestPlayer(AssessmentAutomationAgent));
                        Assert.IsFalse(AssessmentCommonMethods.NextButtonFoundInTestPlayer(AssessmentAutomationAgent));
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43849", true);
                    }
                    for (int i = TotalQuestions; i > currentQuestionNumber; i--)
                    {
                        AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                    }
                    NavigationCommonMethods.CloseApplication(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.LaunchApp();

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9555")]
        [Priority(1)]
        [WorkItem(46653), WorkItem(46564)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void StudentAssessmentSummaryPageFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46653,TC46564 :STUDENT EXPERIENCE: Assessment Summary of response status:Verify whether the 'question' text and number is displayed in the question tile."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.ClickSummaryButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.TimerFoundInAssessmentSummaryPage(AssessmentAutomationAgent), "Timer Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.QuestionTileInStudentAssessmentSummary(AssessmentAutomationAgent), "Question Tile is not found");
                    String QuestionTileText = AssessmentCommonMethods.GetTextFromQuestionTileInStudentAssessmentResultSummary(AssessmentAutomationAgent);
                    Assert.AreEqual("Question 1", QuestionTileText, "Expected Text in Question tile not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46653", true);
                    AssessmentCommonMethods.ClickQuestion1Tile(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.TimerFoundInAssessmentSummaryPage(AssessmentAutomationAgent), "Timer Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46564", true);
                    NavigationCommonMethods.CloseApplication(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.LaunchApp();

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[4], UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(45751)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNoOptionToExitAssessmentForStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45751: Verify Student should not have any option to exit an assessment"))
            {
                try
                {

                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.CheckSystemTrayButtonInTestPlayer(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton"));
                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[4], UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(53189), WorkItem(53190), WorkItem(53191)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyStudentAnsweredTileProperties()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC53189,TC53190,TC53191: Verify the answered response in Assessment Summary screen"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    //NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    //AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    //NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    //NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    //AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentTapsOnUnlockedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.ClickFlagForLaterInStudentAssessmentSummary(AssessmentAutomationAgent);
                    string currentQuestionNumber = AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound");
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    string answeredText = AssessmentCommonMethods.GetAnsweredTestInELAAssessmentSummary(AssessmentAutomationAgent);
                    Assert.IsTrue(answeredText.Contains("Answered"), "Answered Label Not found");                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAnsweredQuestiontile(AssessmentAutomationAgent, currentQuestionNumber));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53189", true);
                    AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[2]);
                    while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextButtonInTestPlayerFound"))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }

                    AssessmentCommonMethods.ClickReviewAndSubmitButton(AssessmentAutomationAgent);
                    String PageTitle = AssessmentCommonMethods.GetTextFromStudentAssessmentSummaryPage(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Summary", PageTitle, "Student Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53190", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlagLabelPresentInAssessmentSummary(AssessmentAutomationAgent, UnitStatus[0]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53191", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[4], UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9268")]
        [Priority(1)]
        [WorkItem(52514), WorkItem(52515), WorkItem(52513), WorkItem(52512), WorkItem(52511)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyInternetOfflineMessageOnStartingAndResettingAnAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52514,TC52515,TC52513,TC52512,TC52511:Verify Internet Offline Message On Starting And Resetting An Assessment"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "start assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52514", true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "view report");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52515", true);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "release scores");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52513", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "release scores");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52512", true);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "lock and reset data");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52511", true);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9501")]
        [Priority(1)]
        [WorkItem(46055)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyAssessmentErrorMessageWhenStudentStartsAnSecondAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46055: Verify if the appropriate error message is displayed to the student when the student tries to start an assessment when already one assessment is in progress state."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherUnlocksAStudentForOtherAssessment(AssessmentAutomationAgent, "deni test", UnitStatus[12]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started");

                    Login studentLogin1 = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);
                    TaskInfo taskInfo2 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo2.Grade, taskInfo2.Unit);
                    AssessmentAutomationAgent.Sleep(5000);
                    //AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent, "2");
                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent))
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyAssessmentErrorMessageDisplayed(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin2 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin2);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherUnlocksAStudentForOtherAssessment(AssessmentAutomationAgent, "deni test", UnitStatus[12]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                }
                catch (Exception ex)
                {
                    AssessmentAutomationAgent.Sleep(2000);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    AssessmentAutomationAgent.ApplicationClose();
                    AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


    }
}



                
                
                    
                    
                   
                 

              

    



    




        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        





































































































































































































































































































































































































































































































































        































































































        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
