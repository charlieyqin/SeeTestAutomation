using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class Assessment
    {
        public AutomationAgent AssessmentAutomationAgent;


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8200"), TestCategory("US10090"), TestCategory("US9725")]
        [Priority(1)]
        [WorkItem(45932), WorkItem(45933), WorkItem(45934), WorkItem(45968), WorkItem(45969), WorkItem(45970), WorkItem(52833), WorkItem(52478)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyTeacherPreviewAssessmentForFixedAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45932, TC45933, TC45934, TC45968, TC45969, TC45970,TC52833,TC52478:Verify the Teacher Preview Assessment Screen for Fixed Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedFixedAssessmentName = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent,UnitStatus[21]);                    
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
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
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsLabelPresent(AssessmentAutomationAgent), "Common Core Standards Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52833", true);
                    while (!AssessmentCommonMethods.AnswerTabDisplayedInPreviewScreen(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickNextQuestionButtonInItemScoring(AssessmentAutomationAgent, 1);
                    }
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCorrectAnswerDisplayedInPreviewScreen(AssessmentAutomationAgent), "Correct Answer Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52478", true);
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
        [TestCategory("Assessment"), TestCategory("US8200"), TestCategory("US9715")]
        [Priority(2)]
        [WorkItem(45971), WorkItem(45972), WorkItem(45974), WorkItem(45975), WorkItem(45988), WorkItem(45989), WorkItem(45976), WorkItem(45982), WorkItem(46669)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyNavigationInTeacherPreviewAssessmentForFixedAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45971,TC45972,TC45974,TC45975,TC45988,TC45989,TC45976,TC45982,TC46669:Verify the Navigation in Teacher Preview Assessment Screen for Fixed Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
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
                        Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoreButtonInTeacherPreview(AssessmentAutomationAgent), "Rubric Panel is not present in Teacher Preview");
                        Assert.IsTrue(AssessmentCommonMethods.VerifyHideRubricTabIsPresentInTeacherPreview(AssessmentAutomationAgent), "Hide Tab is not present in Teacher Preview");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46669", true);
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
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);

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
        [TestCategory("Assessment"), TestCategory("US8195"), TestCategory("US9512"), TestCategory("US9260"), TestCategory("US9264"), TestCategory("US9263"), TestCategory("US8186")]
        [Priority(1)]
        [WorkItem(43690), WorkItem(43691), WorkItem(43834), WorkItem(43835), WorkItem(44751), WorkItem(45208), WorkItem(45209), WorkItem(45206), WorkItem(46238), WorkItem(46236), WorkItem(45160), WorkItem(45159), WorkItem(45111), WorkItem(45113), WorkItem(45254), WorkItem(45215), WorkItem(45250), WorkItem(45246)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyTheProgressBarAndButtonStatusForEachStateInAssessmentOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43690,TC43691,TC43834,TC43835,TC45208,TC45209,TC45206,TC44751,TC46238,TC46236,TC45160,TC45159,TC45111,TC45113,TC45254,TC45215,TC45250,TC45246: Verify The Progress Bar And Button Status For Each State In Assessment Overview"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    String PercentageValue = AssessmentCommonMethods.GetTextOfDynamicProgressBarValue(AssessmentAutomationAgent);
                    Assert.AreNotEqual("0%", PercentageValue, "Percentage Value Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43690", true);

                    Assert.IsTrue(AssessmentCommonMethods.StatusBarTabViewPresent(AssessmentAutomationAgent), "Progress Bar Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43691", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoresButtonEnabledinAssessmnetOverview(AssessmentAutomationAgent), "Score button is not enabled");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyViewReportButtonEnabledinAssessmnetOverview(AssessmentAutomationAgent), "View Report button is not enabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43834", true);

                    Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoresButtonDisabledinAssessmnetOverview(AssessmentAutomationAgent), "Release score button is not enabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43835", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45209", true);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);                    
                    String ScoringOverviewTitle = AssessmentCommonMethods.GetTextFromScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Overview", ScoringOverviewTitle, "Scoring Overview Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46238", true);
                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45159", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45111", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45206", true);
                    String TextBesideButton = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score  4  more to release scores", TextBesideButton, "Status Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44751", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45208", true);
                    Assert.IsTrue(AssessmentCommonMethods.SubmittedCountLabelInScoringOverview(AssessmentAutomationAgent, UnitStatus[17]), "Submitted Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45215", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45250", true);
                    Assert.IsTrue(AssessmentCommonMethods.ScoredCountLabelInScoringOverview(AssessmentAutomationAgent, UnitStatus[18]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45246", true);
                    //Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAlphabeticallyArrangedInScoring(AssessmentAutomationAgent), "Student Name Not Arranged In Alphabetically Order");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45254", true);

                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45160", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45113", true);
                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(AssessmentAutomationAgent);
                    String ReportTitle = AssessmentCommonMethods.GetTextFromAssessmentResultSummary(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Result Summary", ReportTitle, "Report Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46236", true);
                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US8195"), TestCategory("US9998"), TestCategory("US9601"), TestCategory("US9096"), TestCategory("US9259")]
        [Priority(2)]
        [WorkItem(43836), WorkItem(43692), WorkItem(43827), WorkItem(43828), WorkItem(52809),WorkItem(45151), WorkItem(52808), WorkItem(46393), WorkItem(44069)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyTabsgettingHighlightedWithStudentListInAssessmentOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52809,TC52808,TC46393,TC45151,TC44069,TC43836,TC43692,TC43827,TC43828: Verify the tabs getting highlighted when tapped on progress bar in the Assessment Overview page"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedFixedAssessmentName = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.VerifyAssessmentName(AssessmentAutomationAgent, ExpectedFixedAssessmentName);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52808", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52809", true);
                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46393", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44069", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoresButtonDisabledinAssessmnetOverview(AssessmentAutomationAgent), "Release score button is not disabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43836", true);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnLockAllButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAlphabeticallyArrangedInOverview(AssessmentAutomationAgent), "Student Name Not Arranged In Alphabetically Order");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45151", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyProgressBarHeaderColorBlue(AssessmentAutomationAgent), "Progress Tab Not Highlighted");
                    int notStartedCount = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList notStartedStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, notStartedCount);
                    Assert.IsFalse(notStartedStudentList[0].Equals(""), "Not Started Student List Is Empty");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43692", true);

                    ArrayList first_name = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent, int.Parse(UnitStatus[9]));
                    AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Right, 500, 500);
                    ArrayList name_after_swipe = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent, int.Parse(UnitStatus[9]));
                    if (first_name.Count > 24)
                    {
                        Assert.AreNotEqual(first_name[0], name_after_swipe[0], "Not able to do the Horizontal swipe.");
                    }
                    else
                    {
                        Assert.AreEqual(first_name[0], name_after_swipe[0], "Not able to do the Horizontal swipe.");
                    }                   
                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43827", true);

                    AssessmentCommonMethods.ClickOnTheStartedTab(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43828", true);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
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

        //US9117

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9117"), TestCategory("US9601")]
        [Priority(1)]
        [WorkItem(44020),WorkItem(43865), WorkItem(43866), WorkItem(44028), WorkItem(43867), WorkItem(43868), WorkItem(44012), WorkItem(44013), WorkItem(44014), WorkItem(44015), WorkItem(44032), WorkItem(44016), WorkItem(44022), WorkItem(44019), WorkItem(44018)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyTheLockAndUnlockScreenFunctionality()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC44020,TC43865,TC46394,TC43866,TC44028,TC43867,TC43868,TC44012,TC44013,TC44014,TC44015,TC44032,TC44016,TC44022,TC44019,TC44018 :Verify The Lock And Unlock Screen Functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedAssessmentUnitTitle = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent,UnitStatus[21]);                    
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                                       

                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43865", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46394", true);

                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.UnlockModalScreenFound(AssessmentAutomationAgent), "Assessment Overlay Screen Is Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43866", true);
                    AssessmentCommonMethods.VerifyStudentsWithLockUnlockIcons(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToCloseLockUnlockPopup(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44020", true);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);

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
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);

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
        [TestCategory("Assessment"), TestCategory("US8196"), TestCategory("US9563"), TestCategory("US9555"), TestCategory("US9740"), TestCategory("US8197")]
        [Priority(1)]
        [WorkItem(43844), WorkItem(45751), WorkItem(43845), WorkItem(43846), WorkItem(43847), WorkItem(43848), WorkItem(43849), WorkItem(46653), WorkItem(46564), WorkItem(46668), WorkItem(52031), WorkItem(53189), WorkItem(53190), WorkItem(53191)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void StudentAssessmentTestPlayerFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43844,TC45751,TC43845, TC43846, TC43847, TC43848, TC43849,TC46653,TC46564,TC46668,TC52031,TC53189,TC53190,TC53191:Verify that the student can open the Test Player"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentAutomationAgent.Sleep(5000);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentAutomationAgent.Sleep(5000);

                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent))
                      AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.Sleep(5000);
                    Assert.IsTrue(AssessmentCommonMethods.SummaryButtonInTestPlayer(AssessmentAutomationAgent), "Summary Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43844", true);
                    Assert.IsFalse(NavigationCommonMethods.IsSystemTrayAvailable(AssessmentAutomationAgent),"System tray Not available");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45751", true);
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43845", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlagForLaterButtonIsPresent(AssessmentAutomationAgent), "Flag for later button not present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46668", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52031", true);
                    Assert.IsTrue(AssessmentCommonMethods.GetTextofTitleFromTestPlayer(AssessmentAutomationAgent,UnitStatus[21]),"Title Not Present");
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
                    Assert.IsTrue(AssessmentCommonMethods.PreviousButtonFoundInTestPlayer(AssessmentAutomationAgent));
                    Assert.IsTrue(AssessmentCommonMethods.ReviewAndSubmitButtonFound(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43849", true);

                    AssessmentCommonMethods.ClickFlagForLaterInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    //string answeredText = AssessmentCommonMethods.GetAnsweredTestInELAAssessmentSummary(AssessmentAutomationAgent, currentQuestionNumber);
                    //Assert.IsTrue(answeredText.Contains("Answered"), "Answered Label Not found");                    
                    //Assert.IsFalse(AssessmentCommonMethods.VerifyAnsweredQuestiontile(AssessmentAutomationAgent, currentQuestionNumber.ToString()));                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53189", true);

                    String PageTitle = AssessmentCommonMethods.GetTextFromStudentAssessmentSummaryPage(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Summary", PageTitle, "Student Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53190", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlagLabelPresentInAssessmentSummary(AssessmentAutomationAgent, TotalQuestions.ToString()));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53191", true);

                    Assert.IsTrue(AssessmentCommonMethods.TimerFoundInAssessmentSummaryPage(AssessmentAutomationAgent), "Timer Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.QuestionTileInStudentAssessmentSummary(AssessmentAutomationAgent, currentQuestionNumber.ToString()), "Question Tile is not found");
                    String QuestionTileText = AssessmentCommonMethods.GetTextFromQuestionTileInStudentAssessmentResultSummary(AssessmentAutomationAgent);
                    Assert.AreEqual("Question 1", QuestionTileText, "Expected Text in Question tile not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46653", true);
                    AssessmentCommonMethods.ClickQuestion1Tile(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.TimerFoundInAssessmentSummaryPage(AssessmentAutomationAgent), "Timer Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46564", true);

                    for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.ClickRemoveFlagInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitButtonInLastQuestionOfAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[2]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent,UnitStatus[21]);
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
        [TestCategory("Assessment"), TestCategory("US8194"), TestCategory("US9600")]
        [Priority(1)]
        [WorkItem(43530), WorkItem(45749), WorkItem(43527), WorkItem(43536), WorkItem(43531)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void StatusInAssessmentManagerStudentSubmitsAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43530,TC43531,TC45749,TC43527,TC43536 :  Verify whether the ‘Scoring required’ text is displayed if students have submitted the assessment when the main status in ‘In Progress’ state."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45749", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentSubmitted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatusAfterAssessmentSubmitted[4], UnitStatusAfterAssessmentSubmitted[2]);

                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent,UnitStatus[21]), "Unlock Icon Not Present");
                    String SubmittedSubStatus = AssessmentCommonMethods.GetSubmittedSubStatusFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("Submitted: " + UnitStatusAfterAssessmentSubmitted[11], SubmittedSubStatus, "Sub Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43531", true);
                    Assert.AreEqual("In Progress", AssessmentCommonMethods.GetInProgressStatusFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]), "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43527", true);                    
                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent,UnitStatus[21]), "Unlock Icon Not Present");
                    String ScoringRequiredStatus = AssessmentCommonMethods.GetScoringRequiredStatusFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("Scoring Required", ScoringRequiredStatus, "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43530", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43536", true);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent,UnitStatus[21]);
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



         //US8193 : iOS: ASSESSMENT MANAGER: Unit Display & Selection
        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8193"), TestCategory("US9874")]
        [Priority(1)]
        [WorkItem(52392),WorkItem(52393),WorkItem(43512), WorkItem(43513), WorkItem(43514), WorkItem(43515), WorkItem(43516), WorkItem(43517), WorkItem(43521)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyUnitDisplayAndSelectionInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52392,TC52393,TC43512,TC43513,TC43514,TC43515,TC43516,TC43517,TC43521: Verify Unit Display And Selection In Assessment Manager"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52392", true);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickOnRefreshIcon(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.LoaderIconPresent(AssessmentAutomationAgent), "Loader Icon Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52393", true);
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
          [TestCategory("Assessment"), TestCategory("US9156"), TestCategory("US9117"), TestCategory("US8193")]
          [Priority(1)]
          [WorkItem(43856), WorkItem(43857), WorkItem(43850), WorkItem(43851), WorkItem(43855), WorkItem(43853), WorkItem(43852), WorkItem(43854), WorkItem(44023), WorkItem(44031), WorkItem(53578), WorkItem(43862), WorkItem(43861), WorkItem(43860), WorkItem(43518)]
          [Owner("Lakshmi Brunda(lakshmi.brunda")]
          public void LockAndResetPopUpScreenFunctionalities()
          {
              using (AssessmentAutomationAgent = new AutomationAgent("TC43856, TC43857, TC43850, TC43851, TC43855, TC43853, TC43852, TC43854,TC44023,TC44031,TC53578,TC43862,TC43861,TC43860,TC43518 :Verify whether the teacher is displayed with different options in the ‘Lock and reset data’ pop up."))
              {
                  try
                  {
                      Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                      NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                      TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                      String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                      AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                      NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                      Login studentLogin = Login.GetLogin("AssessmentStudent1");
                      NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                      TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                      AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                      AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted", UnitStatus[21]);
                      AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                      NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                      Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                      NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                      String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                      AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                      AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[2]);
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43518", true);
                      AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                      AssessmentCommonMethods.ClickLockAssessments(AssessmentAutomationAgent);
                      Assert.AreEqual("Locks only students that have not yet started", AssessmentCommonMethods.GetLockOnlyStudentsNotStartedAssessmentOverlayScreen(AssessmentAutomationAgent), "Message Not Found");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44031", true);
                      Assert.AreEqual("Started", AssessmentCommonMethods.VerifyStudentAssessmentStatusInUnlockScreen(AssessmentAutomationAgent), "Assessment Status Not Found");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53578", true);
                      AssessmentCommonMethods.TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
                      Assert.IsTrue(AssessmentCommonMethods.VerifyCancelButtonInLockAndResetScreen(AssessmentAutomationAgent), "Cancel Button Not Found");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43856", true);
                      Assert.IsTrue(AssessmentCommonMethods.LockAndResetButton(AssessmentAutomationAgent), "Lock And Reset Button Not Found");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43857", true);

                      String LockAndResetDataHeader = AssessmentCommonMethods.GetHeaderFromLockAndResetDataScreen(AssessmentAutomationAgent);
                      Assert.AreEqual("Lock Assessment and Clear All Data?", LockAndResetDataHeader, "Lock Assessment And Clear All Data Not Found ");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43850", true);
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44023", true);

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
                      Assert.AreEqual("Assessment Status", "Assessment Status", "Assessment Status Not Found");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43852", true);

                      String SubmittedCount = AssessmentCommonMethods.GetSubmittedStatusAndCount(AssessmentAutomationAgent);
                      Assert.AreEqual("Students Submitted", SubmittedCount, "Status Not Found");
                      AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43854", true);

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
                      //AssessmentCommonMethods.ResetAssessmentAfterAppCrashAndAssertionFailure(AssessmentAutomationAgent, "AssessmentTeacher", "ELA", "Assessment");
                      AssessmentAutomationAgent.GenerateReportAndReleaseClient();
                      throw;
                  }
              }
          }
                                           

        //US8186 - IOS: SCORING OVERVIEW: Main Screen

                 

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9218"), TestCategory("US9096"), TestCategory("US9312")]
        [Priority(1)]
        [WorkItem(46246), WorkItem(46251), WorkItem(46247), WorkItem(46245), WorkItem(46248), WorkItem(46249), WorkItem(46250), WorkItem(44068), WorkItem(46392)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyUnitTitleDropDownAndAssessmentStatusInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46246,TC46251,TC46247,TC46245,TC46248,TC46249,TC46250,TC44068,TC46392: Verify Unit Title Drop Down And Assessment Status In Assessment Manager"))
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

                    if (AssessmentCommonMethods.VerifyInProgressFixedAssessmentPresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickOnInProgressFixedAssessment(AssessmentAutomationAgent);
                        AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44068", true);
                    }

                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    string PreviewAssessmentTitle = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", PreviewAssessmentTitle, "Start Assessment dialog box present");
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46392", true);
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
   
         //US9263: iOS: SCORING OVERVIEW: Populate the list of the students
                
        
        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9263"), TestCategory("US9262"), TestCategory("US8194")]
        [Priority(1)]
        [WorkItem(45121), WorkItem(45119), WorkItem(45117), WorkItem(45115), WorkItem(45120), WorkItem(45118), WorkItem(45116), WorkItem(45114), WorkItem(45122), WorkItem(45112), WorkItem(45194), WorkItem(45239)]
        [Owner("Aalmeen Khan(aalmeen.khan)")]
        public void VerifyTheStudentsListInScoringOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45121,TC45119,TC45117,TC45115,TC45120,TC45118,TC45116,TC45114,TC45122,TC45112,TC45194,TC43529 : Verify for the not started student list in the scoring overview screen."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0], UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted", UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifySubmittedStatusInAssessmentManger(AssessmentAutomationAgent, UnitStatus[11]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43529", true);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    
                    int notStartedCount = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int startedCount = AssessmentCommonMethods.GetStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int submittedCount = AssessmentCommonMethods.GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverview(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickOnNotStartedTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList notStartedStudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent,0);
                    
                    AssessmentCommonMethods.ClickOnStartedTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList startedStudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent,0);
                    
                    AssessmentCommonMethods.ClickOnScoredTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList scoredtudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent,0);
                    
                    AssessmentCommonMethods.ClickOnSubmittedTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList submittedStudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent,1);
                    
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);                    
                    Assert.IsTrue(notStartedCount.Equals(AssessmentCommonMethods.GetNotStartedCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if submitted count does not match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45120", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45121", true);
                    Assert.IsTrue(startedCount.Equals(AssessmentCommonMethods.GetStartedCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if count is not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45118", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45119", true);
                    Assert.IsTrue(scoredCount.Equals(AssessmentCommonMethods.GetScoredCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if count is not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45116", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45117", true);
                    Assert.IsTrue(submittedCount.Equals(AssessmentCommonMethods.GetSubmittedCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if count is not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45114", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45115", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentCountFormatInScoringOverview(AssessmentAutomationAgent, UnitStatus[9]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45122", true);
                    Assert.AreEqual(UnitStatus[12], AssessmentCommonMethods.VerifyStudentNameInScoringOverviewScreen(AssessmentAutomationAgent), "Student Name Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45112", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoresDisabled(AssessmentAutomationAgent), "Release Scores tab is not disabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45194", true);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
                                      
               
        // US9258: iOS: SCORING: Navigate to Next/ Previous question for the same student

        
        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9258"), TestCategory("US8186")]
        [Priority(1)]
        [WorkItem(45135), WorkItem(45123), WorkItem(45125), WorkItem(45126), WorkItem(45124), WorkItem(45129), WorkItem(45130), WorkItem(45263), WorkItem(45127), WorkItem(45131), WorkItem(45128), WorkItem(45134), WorkItem(45132)]
        [Owner("Aalmeen Khan(aalmeen.khan)")]
        public void VerifyNavigationToNextAndPreviousQuestionInItemScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45135,TC45123,TC45125,TC45126,TC45124,TC45129,TC45130,TC45263,TC45127,TC45131,TC45128,TC45134,TC45132: Verify The teacher should not be displayed with the ‘Next’ button if that is the last question of the assessment."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0], UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted", UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent, UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    string defaultQuestion = AssessmentCommonMethods.VerifyRubricQuestionNumberLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.VerifyStudentStatusInTaskLevelAssessment(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45135", true);
                    AssessmentCommonMethods.VerifyItemScoringScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDefaultQuestion(AssessmentAutomationAgent,defaultQuestion);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45123", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45263", true);
                    string studentName = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    int totalQuestions = AssessmentCommonMethods.GetTotalQuestionNumberAtItemScoring(AssessmentAutomationAgent);
                    int quesNo = Int32.Parse(AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent));
                    if(totalQuestions.Equals(1))
                    {
                        Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent), "Fail if Previous button will display");
                        Assert.IsFalse(AssessmentCommonMethods.VerifyNextQuestionButtonInItemScorring(AssessmentAutomationAgent), "Fail if Previous button will display");
                    }else
                    {
                        for (int i = 1; i < totalQuestions;i++ )
                        {
                            AssessmentCommonMethods.ClickNextQuestionButtonInItemScoring(AssessmentAutomationAgent, 1);
                            string quesNoAfterTappingNext = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                            Assert.IsTrue(!quesNoAfterTappingNext.Equals(quesNo), "Fail if tapping on next does not navigate to next question");                            
                            string studentNameAfterTapingNext = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                            Assert.IsTrue(studentName.Equals(studentNameAfterTapingNext), "Fail if taping next does not redirect to same student");                            
                            Assert.IsTrue(AssessmentCommonMethods.VerifyPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent), "Fail if Previous button does not displayed");                            
                        }
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45127", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45131", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45125", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45126", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45124", true);
                        Assert.IsFalse(AssessmentCommonMethods.VerifyNextQuestionButtonInItemScorring(AssessmentAutomationAgent), "Fail if Next button displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45129", true);
                        Assert.IsTrue(AssessmentCommonMethods.VerifyPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent), "Fail if Previous button does not displayed");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45130", true);
                        AssessmentCommonMethods.ClickPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent);
                        string quesNoAfterTappingPrevious = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                        Assert.IsTrue(!quesNo.Equals(quesNoAfterTappingPrevious), "Fail if tapping on previous button does not navigate to previous question");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45128", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45134", true);
                        string studentNameAfterTapingPrevious = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                        Assert.IsTrue(studentName.Equals(studentNameAfterTapingPrevious), "Fail if taping previous does not redirect to same student");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45132", true);
                    }                                                                                                                                              
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US8199"), TestCategory("US8193")]
        [Priority(1)]
        [WorkItem(45517), WorkItem(45518), WorkItem(45519), WorkItem(45520), WorkItem(45521), WorkItem(45522), WorkItem(45523), WorkItem(45524), WorkItem(45525), WorkItem(45526), WorkItem(45527), WorkItem(43519)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void StudentAssessmentNavigationButtonFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45517, TC45518, TC45519, TC45520, TC45521, TC45522, TC45523, TC45524, TC45525, TC45526, TC45527,TC43519 : Verify the functionality of Student taking assessment."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "ReviewAndSubmit",UnitStatus[21]);
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
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45526", true);

                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    //String[] StudentUnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    //Assert.AreEqual(StudentUnitStatus[3], AssessmentCommonMethods.GetUnitNameAfterSubmittingAssessment(AssessmentAutomationAgent, StudentUnitStatus[0]), "Assessment title name mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45522", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45523", true);

                    //AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    //Assert.IsFalse(AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent), "Start Assessment Confirmation Pop Up is shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45524", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin2 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin2);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43519", true);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent,UnitStatus[21]);
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
        [TestCategory("Assessment"), TestCategory("US8186"), TestCategory("US9944"), TestCategory("US8187"), TestCategory("US9715")]
        [Priority(2)]
        [WorkItem(45210), WorkItem(45214), WorkItem(53579), WorkItem(45213), WorkItem(45207), WorkItem(52230), WorkItem(52229), WorkItem(53184), WorkItem(45133), WorkItem(45277), WorkItem(45269), WorkItem(46681)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyQuestionNumberHeaderScreenAssessmentNameInScoringOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45210,TC45214,TC53579,TC45213,TC45207,TC52230,TC52229,TC53184,TC45133,TC45277,TC45269,TC46681:Verify question number header in Scoring Overview screen"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoresButtonDisabledinAssessmnetOverview(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45210", true);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySubmittedCategory(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoredCategory(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStartedCategory(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNotStartedCategory(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45214", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53579", true);
                    AssessmentCommonMethods.VerifyQuestionsHeader(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45213", true);
                    String ScoringOverviewTitle = AssessmentCommonMethods.GetTextFromScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Overview", ScoringOverviewTitle, "Scoring Overview Title Not Found");
                    String AssessmentTitle = AssessmentCommonMethods.GetAssessmentNameFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual(UnitStatus[21],AssessmentTitle.Trim(), "Expected Assessment title not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45207", true);

                    String questionInScoringOverview = AssessmentCommonMethods.VerifyRubricQuestionNumberLabel(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);

                    String questionNumber = AssessmentCommonMethods.GetQuestionNumberFromItemScoringScreen(AssessmentAutomationAgent);
                    Assert.AreEqual(questionInScoringOverview,questionNumber,"Wrong Question Number Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53184", true);

                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52230", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyStudentResponseTabHighlighted(AssessmentAutomationAgent), "Student Response Tab Not Highlighted");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45133", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentResponseTabSelectedByDefaultInScoringScreen(AssessmentAutomationAgent), "Student Tab Not selected by default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45277", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDoneButtonInExerciseSummaryPresent(AssessmentAutomationAgent), "Done Button is not present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45269", true);
                    AssessmentCommonMethods.VerifyItemScoringScreen(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46681", true);
                    AssessmentCommonMethods.ClickQuestionTabInItemScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52229", true);
                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9258"), TestCategory("US9260"), TestCategory("US9259"), TestCategory("US9266")]
        [Priority(1)]
        [WorkItem(45136), WorkItem(45138), WorkItem(45137), WorkItem(53194), WorkItem(53193), WorkItem(45139), WorkItem(53170), WorkItem(45205)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifNextAndpreviousStudentButtonAtItemScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45136,TC45138,TC45137,TC53194,TC53193,TC45139,TC53170,TC45205: Verify The total number of students submitted should be displayed at the top of the ‘Assessment scoring screen’ "))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0], UnitStatus[21]);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[13]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted", UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin1 = Login.GetLogin("AssessmentStudent2");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);
                    TaskInfo taskInfo2 = studentLogin1.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo2.Grade, taskInfo2.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted", UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                                        
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    int submittedStudentCountAtAssessmentOverview = AssessmentCommonMethods.GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    int submittedStudentCountAtItemScoring = AssessmentCommonMethods.GetSubmittedStudentsCountAtItemScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(submittedStudentCountAtAssessmentOverview.Equals(submittedStudentCountAtItemScoring), "Fail as if submitted student count does not display at item scoring overview");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45136", true);                                      
                    if (AssessmentCommonMethods.VerifyNextStudentButton(AssessmentAutomationAgent))
                    {
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45138", true);
                        AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                        AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "1");
                        Assert.AreEqual("1", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                        AssessmentCommonMethods.ClickNextStudentButtonAtItemScoring(AssessmentAutomationAgent);
                        string quesNoAfterTappingNextStudent = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                        Assert.IsTrue(AssessmentCommonMethods.VerifyPreviousStudentButton(AssessmentAutomationAgent), "Fail if previous student button will not display");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45137", true);
                        AssessmentCommonMethods.ClickOnPreviousStudentButton(AssessmentAutomationAgent);
                        string quesNoAfterTappingPreviousStudent = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                        Assert.AreEqual(quesNoAfterTappingNextStudent, quesNoAfterTappingPreviousStudent, "Question are not Same");
                        Assert.AreEqual("1", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45205", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53194", true);
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53194", true);
                    }
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "--");
                    AssessmentCommonMethods.ClickAllgroupMemeberDropDownInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStudentNameAndStatusInChecklistScoring(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45139", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53170", true);                    
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9266"), TestCategory("US8187"), TestCategory("US9265"), TestCategory("US9408"), TestCategory("US8188"), TestCategory("US9368"), TestCategory("US9611")]
        [Priority(2)]
        [WorkItem(45201), WorkItem(53183), WorkItem(45199),WorkItem(45198), WorkItem(53181), WorkItem(45202), WorkItem(45200), WorkItem(53195), WorkItem(53196), WorkItem(53197), WorkItem(53198), WorkItem(45191), WorkItem(45189), WorkItem(45157), WorkItem(45158), WorkItem(45772)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherCanScoreAndUnScore()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45201,TC45199,TC45200,TC45198,TC45202,TC53181,TC53183,TC53195,TC53196,TC53197,TC53198,TC45191,TC45189,TC45157,TC45158,TC45772: Verify that teacher can un-score the student by tapping on “-“in fly out"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45157", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    int notStartedCountOne = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int submittedCount = AssessmentCommonMethods.GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);

                    while (AssessmentCommonMethods.VerifyMultiDimensionalRubricGroupTitleLabel(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }

                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentResponseTabSelectedByDefaultInScoringScreen(AssessmentAutomationAgent), "Student Tab Not selected by default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45158", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyValueInRubricFlyout(AssessmentAutomationAgent, "-"), "\"--\"value not found in the rubric box");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45199", true);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "1");
                    Assert.AreEqual("1", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53181", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45202", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45203", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53195", true);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyValueInRubricFlyout(AssessmentAutomationAgent, "--"), "\"--\"value not found in the rubric box");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45200", true);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "--");
                    Assert.AreEqual("--", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53183", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45201", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53196", true);

                    AssessmentCommonMethods.CheckCriterionLevel(AssessmentAutomationAgent, "4");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53197", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45198", true);

                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    Assert.AreEqual("--", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53198", true);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    int notScoredCountTwo = AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogueInAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual(notStartedCountOne+5, notScoredCountTwo, "Both the values are Unequal");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45191", true);
                    int partiallyScoredCount = AssessmentCommonMethods.GetPartiallyScoredCountInStopScoringDialogue(AssessmentAutomationAgent);
                    Assert.AreEqual(scoredCount+1, partiallyScoredCount, "Both the values are Unequal");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45189", true);
                    if (submittedCount < partiallyScoredCount)
                        Assert.Fail("Test case didn't meet expected result");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45772", true);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentManagerButtonFound(AssessmentAutomationAgent), "Student dashboard page is not displayed");                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52080", true);

                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual(UnitStatus[3], AssessmentCommonMethods.GetUnitAfterSelectingFromDropdownStudent(AssessmentAutomationAgent), "Selected Unit Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52083", true);

                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, UnitStatus[4]);
                    Assert.IsFalse(AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52089", true);

                    Assert.IsTrue(AssessmentCommonMethods.FixedAssessmentLabelPresent(AssessmentAutomationAgent));
                    Assert.IsTrue(AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52091", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentPresentInStudentDashboard(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52081", true);

                    AssessmentCommonMethods.VerifyAssessmentStatusLabelockIconTitlePresent(AssessmentAutomationAgent,UnitStatus[4]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52092", true);
                    
                    Assert.AreEqual("Not Started", AssessmentCommonMethods.VerifyAssessmentStatusAndLockIconInsync(AssessmentAutomationAgent,UnitStatus[4]), "Status is not sync with lock icon status");
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
                    Login login = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("MATH", "MathAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentLinkInMathDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    string ExpectedOngoingAssessmentTitle = AssessmentCommonMethods.GetTextFromMathOngoingAssessment(AssessmentAutomationAgent, UnitStatus[9]);
                    AssessmentCommonMethods.ClickMathExerciseInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[9]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLinkIspresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51890", true);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    string mathPreviewAssessmentTitle = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
                    string QuestionLabelAtFooter = AssessmentCommonMethods.GetQuestionNumberLabelFromMathOngoingPreviewAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", mathPreviewAssessmentTitle, "Preview Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51891", true);
                    Assert.IsTrue(QuestionLabelAtFooter.Contains("Question"), "Question number is displayed incorrectly");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51905", true);
                    string PreviewAssessmentName = AssessmentCommonMethods.GetTextFromMathOngoingAssessment(AssessmentAutomationAgent, ExpectedOngoingAssessmentTitle);
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
        [TestCategory("Assessment"), TestCategory("US9631"), TestCategory("US9628"), TestCategory("US9944")]
        [Priority(2)]
        [WorkItem(51907), WorkItem(50751), WorkItem(52233)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDoneButtonInMathExerciseThroughLessonBrowser()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51907,TC50751,TC52233 :Verify done button in Exercise Preview Assessment page through lesson browser"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "MathAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.NavigateToMathGrade(AssessmentAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(AssessmentAutomationAgent, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyExercisesStatusInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50751", true);
                    AssessmentCommonMethods.ClickExercisesInLessonTab(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52233", true);                    
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLessonTabInLessonBrowser(AssessmentAutomationAgent), "Lesson Browser screen is not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51907", true);
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
        [TestCategory("Assessment"), TestCategory("US9517"), TestCategory("US9759"), TestCategory("US9932"), TestCategory("US9941"), TestCategory("US10090")]
        [Priority(1)]
        [WorkItem(51767), WorkItem(51768), WorkItem(51769), WorkItem(51774), WorkItem(51773), WorkItem(51816), WorkItem(51814), WorkItem(52871), WorkItem(52872), WorkItem(45985), WorkItem(45983), WorkItem(46024), WorkItem(46030), WorkItem(46008), WorkItem(46011), WorkItem(51771), WorkItem(52836)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTextAndObservationInChecklistScoringScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51767,TC51768,TC51769,TC51774,TC51773,TC51816,TC51814,TC52871,TC52872,TC45985,TC45983,TC46024,TC46030,TC46008,TC51771,TC46011,TC52836: Verify the teacher should be able to navigate back to the scoring overview screen when the teacher taps on the done button."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "ChecklistAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickOnOngoingChecklistAssessment(AssessmentAutomationAgent,UnitStatus[21]);

                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyObservationChecklistTabIsPresent(AssessmentAutomationAgent), "Preview of Observation Checklist tab is not available");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStandardTabInChecklistAssessmentIsPresent(AssessmentAutomationAgent), "Preview of Standard Tab is not available");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52871", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewOfChecklistOngoingAssessment(AssessmentAutomationAgent), "Preview is not available");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52872", true);
                    AssessmentCommonMethods.ClickStandardTabInChecklistAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsLabelPresent(AssessmentAutomationAgent), "Common Core Standards Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52836", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);

                    int notScoredCount = AssessmentCommonMethods.GetNotScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);
                    ArrayList notScoredStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, notScoredCount);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);
                    ArrayList scoredStudentList = AssessmentCommonMethods.GetScoredStudentListFromAssessmentOverview(AssessmentAutomationAgent, scoredCount);
                    if (notScoredCount > 0)
                    {
                        Assert.IsFalse(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Empty");
                    }
                    else
                    {
                        Assert.IsTrue(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Not Empty");
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45985", true);
                    

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45983", true);
                    AssessmentCommonMethods.ClickActiveTileInChecklistScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.VerifyObservationNumber(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46024", true);
                    AssessmentCommonMethods.VerifyTextInCheckListScoringScreen(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46030", true);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    
                    AssessmentCommonMethods.ScoredTabDefaultSelectedInStopScoringDialogue(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51771", true);

                    AssessmentCommonMethods.VerifyTabsInStopScoringScreenForChecklist(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51767", true);

                    int scoredCountFromStopScoring = AssessmentCommonMethods.GetScoredCountFromStopScoringDialogue(AssessmentAutomationAgent);
                    ArrayList scoredStudentListInStopScoring = AssessmentCommonMethods.GetScoredStudentListFromStopScoringDialogue(AssessmentAutomationAgent, scoredCountFromStopScoring);
                    if (scoredCountFromStopScoring == 0)
                        AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51774", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51816", true);                    
                    if (scoredCountFromStopScoring > 0)
                    {
                        for (int i = 0; i < scoredStudentList.Count; i++)
                        Assert.IsTrue(scoredStudentList[i].Equals(scoredStudentListInStopScoring[i]), "Fail if scored list does not match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51769", true);
                    }                   

                    AssessmentCommonMethods.ClickNotScoredTabInStopScoringDialogue(AssessmentAutomationAgent);

                    int notscoredCountFromStopScoring = Int32.Parse(AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogue(AssessmentAutomationAgent));
                    ArrayList notScoredStudentListInStopScoring = AssessmentCommonMethods.GetNotScoredStudentListFromStopScoringDialogue(AssessmentAutomationAgent, notscoredCountFromStopScoring);
                    if (notscoredCountFromStopScoring == 0)
                    {
                    AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51773", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51814", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51773", true);
                    }

                    for (int i = 0; i < notScoredStudentList.Count; i++)
                        Assert.IsTrue(notScoredStudentList[i].Equals(notScoredStudentListInStopScoring[i]), "Fail if not scored list does not match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51768", true);

                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46008", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46011", true);                    
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
                    string ExpectedFixedAssessmentName = AssessmentCommonMethods.GetTextFromFixedAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
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
    
        
        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9268"), TestCategory("US9714")]
        [Priority(1)]
        [WorkItem(52514), WorkItem(52515), WorkItem(52513), WorkItem(52512), WorkItem(52511), WorkItem(52943), WorkItem(52946), WorkItem(52945)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyInternetOfflineMessageOnStartingAndResettingAnAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52514,TC52515,TC52513,TC52512,TC52511,TC52943,TC52946,TC52945:Verify Internet Offline Message On Starting And Resetting An Assessment"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent, UnitStatus[21]);
                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(AssessmentAutomationAgent))
                    {
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    }                    
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "start assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52514", true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52943", true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                    Assert.IsTrue(AssessmentCommonMethods.SubmitInConfirmationPopUpFound(AssessmentAutomationAgent), "Submit Button Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.CancelInConfirmationPopUpFound(AssessmentAutomationAgent), "Yes Button Not Found");

                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52946", true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52945", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "view report");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52515", true);

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
        [TestCategory("Assessment"), TestCategory("US8192"), TestCategory("US8194")]
        [Priority(1)]
        [WorkItem(43473), WorkItem(43826), WorkItem(43841),WorkItem(43524),WorkItem(43522), WorkItem(43507), WorkItem(43510), WorkItem(43511), WorkItem(43508), WorkItem(43509)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyAssessmentTypeDetailsAndScrollingInAssessmentManagerPage()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43473,TC43841,TC43524,TC43522,TC43826,TC43507,TC43510,TC43511,TC43508,TC43509: Verify the Assessment Type,details,scrolling and navigation to Assessment Manager Page"))
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
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43841", true);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.IsTrue(AssessmentCommonMethods.FixedAssessmentLabelPresent(AssessmentAutomationAgent), "Fixed Assessment Type Not Present");
                    if (!AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Down, 500, 2000);
                        Assert.IsTrue(AssessmentCommonMethods.OngoingAssessmentLabelPresent(AssessmentAutomationAgent));
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43508", true);
                    Assert.IsTrue(AssessmentCommonMethods.LockIconInAssessmentManager(AssessmentAutomationAgent), "Lock Icon Is Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.GetTextOfFixedAssessmentStatus(AssessmentAutomationAgent, UnitStatus[21]), "Pending Status Not Found");
                    Assert.AreEqual("Started: " + UnitStatus[7], AssessmentCommonMethods.GetStartedSubStatusFromAssessmentManager(AssessmentAutomationAgent), "Sub Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43524", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43522", true);

                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
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

        
        

        //[TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9501"), TestCategory("US9714")]
        [Priority(1)]
        [WorkItem(46055), WorkItem(52944)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyAssessmentErrorMessageWhenStudentStartsAnSecondAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46055,TC52944: Verify if the appropriate error message is displayed to the student when the student tries to start an assessment when already one assessment is in progress state."))
            {
                try
                {                    
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    //AssessmentCommonMethods.TeacherUnlocksAStudentForOtherAssessment(AssessmentAutomationAgent, "deni test", UnitStatus[12]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Started",UnitStatus[21]);
                                        
                    Login studentLogin1 = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);
                    TaskInfo taskInfo2 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    Assert.IsTrue(AssessmentCommonMethods.SummaryButtonInTestPlayer(AssessmentAutomationAgent),"Test Player For First Assessment Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46055", true);                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52944", true);
                    NavigationCommonMethods.CloseApplication(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.LaunchApp();                    

                    Login teacherLogin2 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin2);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent,UnitStatus[21]);
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

          
      
        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9634"), TestCategory("US9628"), TestCategory("US9944"), TestCategory("US9636")]
        [Priority(2)]
        [WorkItem(51788), WorkItem(51801), WorkItem(51787), WorkItem(51791), WorkItem(51793), WorkItem(51799), WorkItem(51800), WorkItem(51802), WorkItem(51803), WorkItem(51808), WorkItem(51790), WorkItem(53246), WorkItem(53254), WorkItem(46593), WorkItem(46731), WorkItem(52232), WorkItem(52079), WorkItem(52084), WorkItem(52086), WorkItem(52088)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyTestPlayerFunctionalitiesForStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51788,TC51801,TC51787,TC51791,TC51793,TC51799,TC51800,TC51802,TC51803,TC51808,TC51790,TC53246,TC53254,TC46593,TC46731,TC52232,TC52079,TC52084,TC52086,TC52088:Verify Exercise Assessment summary page functionalities for Student"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.NavigateToMathGrade(AssessmentAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(AssessmentAutomationAgent, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46731", true);
                    AssessmentCommonMethods.ClickMathExerciseInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[9]);
                    String PageTitle = AssessmentCommonMethods.GetTextFromStudentAssessmentSummaryPage(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Summary", PageTitle, "Student Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51788", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51802", true);

                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual(UnitStatus[0], AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInExercisePlayerScreen"), "Student Not Navigated To Previous Question");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51801", true);

                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52232", true);

                    AssessmentCommonMethods.ClickFlagForLaterInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Summary", PageTitle, "Student Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51787", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53246", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52079", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52084", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlaggedQuestionTileIsPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51790", true);

                    string challengeProblem = AssessmentCommonMethods.GetTextFromChallengeProblemTile(AssessmentAutomationAgent);
                    Assert.AreEqual("  Challenge Problem", challengeProblem, "Challenge Problem title not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51791", true);

                    String unAnsweredText = AssessmentCommonMethods.GetUnansweredTextFromQuestionTile(AssessmentAutomationAgent, UnitStatus[0]);
                    Assert.AreEqual("Unanswered", unAnsweredText, "UnAnswered Text not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51793", true);

                    String openEndedLabel = AssessmentCommonMethods.GetOpenEndedLabelFromQuestionTile(AssessmentAutomationAgent);
                    Assert.IsTrue(openEndedLabel.Contains("Open - Ended"), "Open Ended Response Text not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51799", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53254", true);

                    String infoText = AssessmentCommonMethods.GetTextBesideAssessmentSummaryHeader(AssessmentAutomationAgent);
                    Assert.AreEqual("Please select a question tile to begin ", infoText, "info Text mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51803", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnansweredLabelIsPresent(AssessmentAutomationAgent));
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlaggedLabelIsPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51808", true);                    
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickRemoveFlagInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDoneButtonInExerciseSummaryPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52086", true);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyExercisesInLessonBrowser(AssessmentAutomationAgent), "Exercise tab is not selected by default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51800", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46593", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLessonTabInLessonBrowser(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52088", true);
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
        [WorkItem(46437), WorkItem(46439)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyInProgressStatusForExerciseAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46437 and TC46439: Verify Teacher should see the status of the assessment as In Progress when one student have started the assessment"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "MathAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, UnitStatus[6]);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[5]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("Math", "MathAssessment");
                    String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "Math");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent,UnitStatus1[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent,UnitStatus1[4]);
                    AssessmentCommonMethods.StudentAnswersAssessmentFromAssessmentManager(AssessmentAutomationAgent, "Submitted", UnitStatus1[4]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);                 
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[2]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyInProgressStatusForExerciseAssessment(AssessmentAutomationAgent,UnitStatus[6]),"In Progress Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46437", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStartedStatusForExerciseAssessment(AssessmentAutomationAgent, UnitStatus[6]), "Started Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46439", true);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, UnitStatus[6]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US10012"), TestCategory("US8191"), TestCategory("US9915")]
        [Priority(1)]
        [WorkItem(52810), WorkItem(52812), WorkItem(52811), WorkItem(52936), WorkItem(52934), WorkItem(52935), WorkItem(45323), WorkItem(45324), WorkItem(45325), WorkItem(45326), WorkItem(52076), WorkItem(52078), WorkItem(52072), WorkItem(52077), WorkItem(52074)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySampleAnswerFunctionalitiesInPreviewAssessmentAndScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52810,TC52812,TC52811,TC52936,TC52934,TC52935,TC45323,TC45324,TC45325,TC45326,TC52076,TC52078,TC52072,TC52077,TC52074: Verify the teacher should be able to view the images in the sample answer modal if the sample answer contains images."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "SampleAnswerAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickOnSampleAnswerAssessment(AssessmentAutomationAgent, UnitStatus[6]);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[5]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo studentInfo = studentLogin.GetTaskInfo("ELA", "SampleAnswerAssessment");
                    String[] studentUnit = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(studentInfo);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "Math");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, studentUnit[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, studentUnit[1]);
                    AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);                    
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                                        
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.ClickOnSampleAnswerAssessment(AssessmentAutomationAgent, UnitStatus[6]);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    while (!AssessmentCommonMethods.VerifySampleAnswerPresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.ClickOnSampleAnswerInRubric(AssessmentAutomationAgent);
                    if (AssessmentCommonMethods.VerifySampleAnswerImage(AssessmentAutomationAgent))
                    {
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52810", true);
                    }                    
                    AssessmentCommonMethods.VerifySampleAnswerTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52812", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerCloseIcon(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent), "Fail if sample answer modal still displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52811", true);
                    Assert.IsTrue(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Fail if rubric panel not present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52076", true);
                    AssessmentCommonMethods.ClickOnHideIconOfRubric(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoreButtonInTeacherPreview(AssessmentAutomationAgent), "Fail if rubric panel present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52078", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    while (!AssessmentCommonMethods.VerifySampleAnswerPresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.VerifySampleAnswerButtonInRubric(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45323", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerInRubric(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45324", true);
                    AssessmentCommonMethods.VerifySampleAnswerTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52936", true);
                    if (AssessmentCommonMethods.VerifySampleAnswerImage(AssessmentAutomationAgent))
                    {
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52934", true);
                    }                    
                    //AssessmentCommonMethods.VerifySampleAnswerScrollView(AssessmentAutomationAgent);
                    //AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45325", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerCloseIcon(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent), "Fail if sample answer modal window still displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52935", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45326", true);
                    AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52072", true);
                    AssessmentCommonMethods.VerifyHideButtonInRubricSection(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52077", true);
                    AssessmentCommonMethods.ClickOnHideIconOfRubric(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoreButtonInTeacherPreview(AssessmentAutomationAgent), "Fail if rubric panel present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52074", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9791"), TestCategory("US9601"), TestCategory("US8194")]
        [Priority(1)]
        [WorkItem(51946), WorkItem(51945), WorkItem(51947), WorkItem(51948), WorkItem(46395), WorkItem(43523), WorkItem(43525), WorkItem(43526), WorkItem(43528)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyTeacherCanViewTheAssessmentsInPreviewModeOnLockUnlockAndSubmitState()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51946,TC51945,TC43523,TC46395,TC51947,TC51948,TC43525,TC43526,TC43528: Verify whether the teacher is able to tap on the assessment tile and view the assessments in ‘Preview’ mode when the assessment is in Locked ,Unlocked and Submit response state."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Locked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51945", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51946", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent,UnitStatus[21]), "Unlock Icon Is Not Present");
                    String AssessmentPendingStatus = AssessmentCommonMethods.GetPendingStatusFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.IsTrue(AssessmentPendingStatus.Contains("Pending"), "Assessment Pending Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43523", true);

                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Unlocked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51947", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Submitted Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51948", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46395", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    String InProgressStatus = AssessmentCommonMethods.GetInProgressStatusFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("In Progress", InProgressStatus, "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43525", true);

                    Assert.IsTrue(AssessmentCommonMethods.UnLockIconInAssessmentManagerIsPresent(AssessmentAutomationAgent,UnitStatus[21]), "Unlock Icon Not Found");
                    String StartedSubStatus = AssessmentCommonMethods.GetStartedSubStatusFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual("Started: " + UnitStatus[11], StartedSubStatus, "Sub Status Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43528", true);
                    Assert.AreEqual("In Progress", AssessmentCommonMethods.GetInProgressStatusFromAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]), "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43526", true);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRun(AssessmentAutomationAgent,UnitStatus[21]);
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
        [TestCategory("Assessment"), TestCategory("US9630"), TestCategory("US9629"), TestCategory("US9512"), TestCategory("US9631"), TestCategory("US9628"), TestCategory("US10090")]
        [Priority(1)]
        [WorkItem(46241), WorkItem(46107), WorkItem(46242), WorkItem(46438), WorkItem(46436), WorkItem(46435), WorkItem(46646), WorkItem(46648), WorkItem(46649), WorkItem(46651), WorkItem(46652), WorkItem(46654), WorkItem(46655), WorkItem(51895), WorkItem(51898), WorkItem(53240), WorkItem(46590), WorkItem(46591), WorkItem(52834)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyProgressTabsPreviewAndLockLinkScoreViewReportButtonPresentInExerciseAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46241,TC46107,TC46242,TC46438,TC46436,TC46435,TC46646,TC46648,TC46649,TC46651,TC46652,TC46654,TC46655,TC51895,TC51898,TC53240,TC46590,TC46591,TC52834:Verify the progress tabs,lock unlock ,preview Assessment,Score Button,Report Button  availability for Exercise Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("MATH", "MathAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyPendingStatusForExerciseAssessment(AssessmentAutomationAgent,UnitStatus[9]), "Exercise Pending State Not Found");                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46438", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46436", true);

                    AssessmentCommonMethods.VerifyExerciseAssessmentUnderOngoing(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46435", true);

                    AssessmentCommonMethods.ClickMathExerciseInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[9]);

                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Progress Overview Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46591", true);

                    Assert.IsTrue(AssessmentCommonMethods.NotScoredTabInAccomplishmentOverviewPresent(AssessmentAutomationAgent), "Not Started Tab Is Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.StartedTabInAccomplishmentOverviewPresent(AssessmentAutomationAgent), "Started Tab Is Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46646", true);

                    int notScoredCount = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList notScoredStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, notScoredCount);
                    if (notScoredCount > 0)
                    {
                        Assert.IsFalse(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Empty");
                    }
                    else
                    {
                        Assert.IsTrue(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Not Empty");
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46241", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46647", true);

                    AssessmentCommonMethods.Swipe(AssessmentAutomationAgent, Direction.Right, 500, 500);
                    AssessmentAutomationAgent.Sleep(3000);
                    ArrayList afterSwipe = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, notScoredCount);
                    if (notScoredCount > 24)
                    {
                        Assert.AreNotEqual(notScoredStudentList[0], afterSwipe[0], "Not able to do the Horizontal swipe.");
                    }
                    else
                    {
                        Assert.AreEqual(notScoredStudentList[0], afterSwipe[0], "Able to swipe when student count is less than 24.");
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46107", true);

                    int scoredCount = AssessmentCommonMethods.GetStartedCountFromAssessmentOverviewExercise(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnTheStartedTab(AssessmentAutomationAgent);
                    ArrayList scoredStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, scoredCount);
                    if (scoredCount > 0)
                    {
                        Assert.IsFalse(scoredStudentList[0].Equals(""), "Scored Student List Is Empty");
                    }
                    else
                    {
                        Assert.IsTrue(scoredStudentList.Count.Equals(0), "Scored Student List Is Not Empty");
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46242", true);


                    Assert.IsFalse(AssessmentCommonMethods.UnlockAssessmentsLinkPresent(AssessmentAutomationAgent), "Lock And Unlock Link Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46648", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46649", true);                                      

					Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLinkIspresent(AssessmentAutomationAgent));
					AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46651", true);
				
					Assert.IsFalse(AssessmentCommonMethods.AssessmentOverviewScoreButtonFound(AssessmentAutomationAgent), "Assessment Overview Score Button  Is Present");
					AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46654", true);
		
					Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewViewReportButtonFound(AssessmentAutomationAgent), "Overview Report Button Not Present");
					AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46655", true);
		
					AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
					string mathPreviewAssessmentTitle = AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent);
					Assert.AreEqual("Item Preview", mathPreviewAssessmentTitle, "Preview Assessment Screen Name Mismatch");
					AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46652", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46590", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyMultipleChoiceQuestionView(AssessmentAutomationAgent), "Question View is not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51895", true);

                    AssessmentCommonMethods.VerifyQuestionContentDisplay(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51898", true);
                    Assert.IsTrue(AssessmentCommonMethods.StandardTabViewPresent(AssessmentAutomationAgent), "Standard View Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53240", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsLabelPresent(AssessmentAutomationAgent), "Common Core Standards Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52834", true);

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
        [TestCategory("Assessment"), TestCategory("US9512"), TestCategory("US9513"), TestCategory("US9759"), TestCategory("US9932"), TestCategory("US10090")]
        [Priority(1)]
        [WorkItem(52863), WorkItem(52865), WorkItem(52867), WorkItem(50717), WorkItem(50716), WorkItem(51919), WorkItem(51911), WorkItem(51913), WorkItem(51927), WorkItem(51918), WorkItem(51924), WorkItem(51923), WorkItem(51778), WorkItem(51775), WorkItem(51779), WorkItem(52835)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyRubricScoringFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52863,TC52865,TC52867,TC50717,TC50716,TC51919,TC51911,TC51913,TC51927,TC51918,TC51924,TC51923,TC51778,TC51775,TC51779,TC52835:Verify the functionality of the ‘Score’ button at the bottom right corner of the assessment progress overview screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "DiscussionRubricAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[0]);
                    AssessmentCommonMethods.ClickRubricDiscussionOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);

                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickRubricQuestionOneArrow(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Rubric Panel Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52863", true);
                    Assert.IsTrue(AssessmentCommonMethods.RubricQuestionDataFound(AssessmentAutomationAgent), "Rubric Question Data not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52865", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStandardTabInChecklistAssessmentIsPresent(AssessmentAutomationAgent), "Standard View Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52867", true);
                    AssessmentCommonMethods.ClickStandardTabInChecklistAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsLabelPresent(AssessmentAutomationAgent), "Common Core Standards Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52835", true);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);

                    AssessmentCommonMethods.AssessmentOverviewScoreButtonFound(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50716", true);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50717", true);
                    AssessmentCommonMethods.ClickRubricTileInObservationOverviewScreen(AssessmentAutomationAgent,UnitStatus[12]);
                    String ScreenTitle = AssessmentCommonMethods.GetRubricScoringTitle(AssessmentAutomationAgent);
                    Assert.AreEqual("Rubric Scoring", ScreenTitle, "Screen Title did not Match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51911", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51927", true);

                    AssessmentCommonMethods.ClickNotScoredCriterions(AssessmentAutomationAgent,"--");
                    Assert.IsTrue(AssessmentCommonMethods.RubricScorePanelFlyoutArrowFound(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51913", true);

                    AssessmentCommonMethods.ClickNextStudentButtonInRubricScoring(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.NextStudentButtonNotFound(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51918", true);

                    AssessmentCommonMethods.ClickPreviousStudentInRubricScoring(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.PreviousStudentButtonNotFound(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51919", true);

                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYesButtonInStopScoringDialogue(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51924", true);

                    AssessmentCommonMethods.ScoredTabDefaultSelectedInStopScoringDialogue(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51778", true);

                    Assert.IsTrue(AssessmentCommonMethods.NotScoredTabFoundInStopScoringDialogue(AssessmentAutomationAgent), "NotScored Tab is not Present in Stop scoring Dialogue");
                    Assert.IsTrue(AssessmentCommonMethods.ScoredTabFoundInStopScoringDialogue(AssessmentAutomationAgent), "Scored Tab is not displayed in Stop scoring Dialogue");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51775", true);

                    AssessmentCommonMethods.ClickNotScoredTabInStopScoringDialogue(AssessmentAutomationAgent);
                    int notscoredCountFromStopScoring = Int32.Parse(AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogue(AssessmentAutomationAgent));
                    if (notscoredCountFromStopScoring == 0)
                        AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51779", true);
                                        
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51923", true);

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
        [TestCategory("Assessment"), TestCategory("US9758"), TestCategory("US9512"), TestCategory("US9637"), TestCategory("US10090")]
        [Priority(1)]
        [WorkItem(46715),WorkItem(46726),WorkItem(46729), WorkItem(46700), WorkItem(52176), WorkItem(46701), WorkItem(46703), WorkItem(46704), WorkItem(46707), WorkItem(46710), WorkItem(46714), WorkItem(46717), WorkItem(46720), WorkItem(46721), WorkItem(46702), WorkItem(46080), WorkItem(46083), WorkItem(46234), WorkItem(46239), WorkItem(46240), WorkItem(46106), WorkItem(46154), WorkItem(52837)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyProgressTabsPreviewAndLockLinkScoreViewReportButtonPresentInProjectAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46715,TC46726,TC46729,TC46700,TC52176,TC46701,TC46703,TC46704,TC46707,TC46710,TC46714,TC46717,TC46720,TC46721,TC46702,TC46080, TC46083, TC46234, TC46239, TC46240, TC46106, TC46154,TC52837: Verify the progress tabs,lock unlock ,preview Assessment,Score Button,Report Button  availability for Project Assessment."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "ProjectAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyProjectInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]), "Project Assessment not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46715", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyPendingStatusInNotebookAssessment(AssessmentAutomationAgent, UnitStatus[21]), "Pending status is not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46726", true);

                    Assert.IsFalse(AssessmentCommonMethods.VerifyScoredStatusInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]), "Scored status is displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46729", true);


                    AssessmentCommonMethods.ClickProjectInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);

                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Progress Overview Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46700", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52176", true);
                                                        
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent), "Assessment Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46701", true);

                    Assert.AreEqual(UnitStatus[4], AssessmentCommonMethods.GetSectionTitleFromAssessmentOverview(AssessmentAutomationAgent), "Section Name Mismatch");
                    String TotalStudentsAvailable = AssessmentCommonMethods.GetTextOfTotalStudentsinOverview(AssessmentAutomationAgent);
                    Assert.AreEqual(UnitStatus[9] + " Students", TotalStudentsAvailable, "Total Student Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46703", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46080", true);

                    Assert.IsTrue(AssessmentCommonMethods.ProgressBarViewPresent(AssessmentAutomationAgent), "Dynamic Progress Status Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46704", true);

                    String PercentageValue = AssessmentCommonMethods.GetTextOfDynamicProgressBarValue(AssessmentAutomationAgent);
                    Assert.AreEqual("0%", PercentageValue, "Percentage Value Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46083", true);

                    String TotalStudents = AssessmentCommonMethods.GetTextOfTotalStudentsToReleaseScoresinOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score 4 students to release scores", TotalStudents, "Student Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46234", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyProgressBarHeaderColorBlue(AssessmentAutomationAgent), "Progress Tab Not Highlighted");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46707", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46106", true);

                    Assert.IsTrue(AssessmentCommonMethods.NotScoredTabInAccomplishmentOverviewPresent(AssessmentAutomationAgent), "Not Scored Tab Is Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.ScoredTabInAccomplishmentOverviewPresent(AssessmentAutomationAgent), "Scored Tab Is Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46710", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46154", true);

                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewViewReportButtonFound(AssessmentAutomationAgent), "Overview Report Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46714", true);

                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewScoreButtonFound(AssessmentAutomationAgent), "Assessment Overview Score Button  Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46717", true);

                    Assert.IsFalse(AssessmentCommonMethods.UnlockAssessmentsLinkPresent(AssessmentAutomationAgent), "Lock And Unlock Link Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46720", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46239", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLinkIspresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46721", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46240", true);

                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.StandardTabViewPresent(AssessmentAutomationAgent), "Standard View Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsLabelPresent(AssessmentAutomationAgent), "Common Core Standards Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52837", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);                    
                    Assert.IsTrue(AssessmentCommonMethods.AssessmentManagerButtonFound(AssessmentAutomationAgent), "Assessment Manager Page Is Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46702", true);
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
        [TestCategory("Assessment"), TestCategory("US9758"), TestCategory("US9512"), TestCategory("US9514"), TestCategory("US9637"), TestCategory("US10090")]
        [Priority(1)]
        [WorkItem(52177), WorkItem(52180), WorkItem(52188), WorkItem(46068), WorkItem(46053), WorkItem(52178), WorkItem(52181), WorkItem(52186), WorkItem(52190), WorkItem(52194), WorkItem(52197), WorkItem(52199), WorkItem(46081), WorkItem(46077), WorkItem(46078), WorkItem(46237), WorkItem(46235), WorkItem(46240), WorkItem(46108), WorkItem(46079), WorkItem(52838)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyProgressTabsPreviewAndLockLinkScoreViewReportButtonPresentInNotebookAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52177,TC52180,TC52188,TC46068,TC46729,TC52178,TC52181,TC52186,TC52190,TC52194,TC52197,TC52199,TC46081,TC46077,TC46078, TC46237, TC46235, TC46240,TC46108,TC46079,TC52838: Verify the progress tabs,lock unlock ,preview Assessment,Score Button,Report Button  availability for Notebook Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52177", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyPendingStatusInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]), "Pending status is not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46053", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52180", true);

                    Assert.IsFalse(AssessmentCommonMethods.VerifyScoredStatusInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]), "Scored status is displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52188", true);

                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46068", true);

                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);

                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52178", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46077", true);

                    Assert.IsTrue(AssessmentCommonMethods.AssessmentProgressOverviewTitleFound(AssessmentAutomationAgent), "Assessment Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46078", true);    

                    Assert.AreEqual(UnitStatus[4], AssessmentCommonMethods.GetSectionTitleFromAssessmentOverview(AssessmentAutomationAgent), "Section Name Mismatch");
                    String TotalStudentsAvailable = AssessmentCommonMethods.GetTextOfTotalStudentsinOverview(AssessmentAutomationAgent);
                    Assert.AreEqual(UnitStatus[9] + " Students", TotalStudentsAvailable, "Total Student Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52181", true);


                    Assert.IsTrue(AssessmentCommonMethods.VerifyProgressBarHeaderColorBlue(AssessmentAutomationAgent), "Progress Tab Not Highlighted");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52186", true);

                    Assert.IsTrue(AssessmentCommonMethods.ProgressBarViewPresent(AssessmentAutomationAgent), "Dynamic Progress Status Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46081", true);

                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewScoreButtonFound(AssessmentAutomationAgent), "Assessment Overview Score Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46237", true);

                    Assert.IsTrue(AssessmentCommonMethods.NotScoredTabInAccomplishmentOverviewPresent(AssessmentAutomationAgent), "Not Scored Tab Is Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.ScoredTabInAccomplishmentOverviewPresent(AssessmentAutomationAgent), "Scored Tab Is Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52190", true);

                    AssessmentCommonMethods.ClickScoredTabInAccomplishmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46108", true);
                    

                    Assert.IsTrue(AssessmentCommonMethods.AssessmentOverviewViewReportButtonFound(AssessmentAutomationAgent), "Overview Report Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52194", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46235", true);

                    Assert.IsFalse(AssessmentCommonMethods.UnlockAssessmentsLinkPresent(AssessmentAutomationAgent), "Lock And Unlock Link Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52197", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLinkIspresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52199", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46240", true);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.StandardTabViewPresent(AssessmentAutomationAgent), "Standard View Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsLabelPresent(AssessmentAutomationAgent), "Common Core Standards Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52838", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.MyDashBoardButtonFound(AssessmentAutomationAgent), "Back Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46079", true);

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
        [TestCategory("Assessment"), TestCategory("US9515"), TestCategory("US10086")]
        [Priority(1)]
        [WorkItem(51922), WorkItem(51920), WorkItem(51921), WorkItem(51915), WorkItem(50725), WorkItem(51777), WorkItem(52820)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNameAndScoringStatusSyncsForRubric()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51922,TC51920,TC51921,TC51915,TC50725,TC51777,TC52820: Verify whether the name and scoring status syncs with the list in the observation overview screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "DiscussionRubricAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickRubricDiscussionOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]);

                    AssessmentCommonMethods.ClickScoredTabInAccomplishmentOverview(AssessmentAutomationAgent);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);
                    ArrayList scoredStudentList = AssessmentCommonMethods.GetScoredStudentListFromAssessmentOverview(AssessmentAutomationAgent, scoredCount);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    
                    int releaseCount=AssessmentCommonMethods.GetScoreMoreCountInScoringOverview(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickRubricTileInObservationOverviewScreen(AssessmentAutomationAgent,UnitStatus[12]);
                    
                    AssessmentCommonMethods.ClickStudentSelectionDropdown(AssessmentAutomationAgent);
                    String studentName = AssessmentCommonMethods.GetStudentNameFromDropDown(AssessmentAutomationAgent);
                    String studentStatus = AssessmentCommonMethods.GetStudentStatusFromDropDown(AssessmentAutomationAgent);
                    AssessmentCommonMethods.StudentSelectionAndStatus(AssessmentAutomationAgent, UnitStatus[12]);
                    
                    String totalScoreValue = AssessmentCommonMethods.GetTotalScoreValueInRubricScoring(AssessmentAutomationAgent,"--");
                    Assert.AreEqual("--", totalScoreValue, "Student is Scored");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51922", true);
                    Assert.AreEqual(UnitStatus[12], studentName, "Right Student is not selected");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51920", true);
                    Assert.IsTrue(studentStatus.Contains(UnitStatus[16]), "Right Status is not shown");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51921", true);

                    for (int i = releaseCount - 1; i >=0; i--)
                    {
                        AssessmentCommonMethods.TeacherScoresRubricAssessment(AssessmentAutomationAgent, "--", "2");
                        AssessmentCommonMethods.ClickNextStudentButtonAtItemScoring(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.ClickPreviousStudentButtonInChecklistScoring(AssessmentAutomationAgent);
                    String totalScoreValueAfterScoring = AssessmentCommonMethods.GetTotalScoreValueInRubricScoring(AssessmentAutomationAgent,"2");
                    Assert.AreEqual("2", totalScoreValueAfterScoring, "Student is Scored");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51915", true);                
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    int scoredCountFromStopScoring = AssessmentCommonMethods.GetScoredCountFromStopScoringDialogue(AssessmentAutomationAgent);
                    ArrayList scoredStudentListInStopScoring = AssessmentCommonMethods.GetScoredStudentListFromStopScoringDialogue(AssessmentAutomationAgent, scoredCountFromStopScoring);                    
                    Assert.IsFalse(scoredStudentListInStopScoring[0].Equals(""), "Not Started Student List Is Empty");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50725", true);                
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51777", true);                
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ReleaseScoresForRubric(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "DiscussionRubricAssessment");
                    String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, UnitStatus1[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, UnitStatus[21]);
                    AssessmentCommonMethods.ClickOnRubricScoreButtonInRubric(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Read Only Mode Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52820", true);
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
        [TestCategory("Assessment"), TestCategory("US9634"), TestCategory("US9637")]
        [Priority(2)]
        [WorkItem(51798), WorkItem(46730)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyStatusofOpenEndedItems()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51798,TC46730 :Verify Exercise Assessment summary page functionalities for Student"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.NavigateToMathGrade(AssessmentAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(AssessmentAutomationAgent, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickExercisesAssessmentInLessonBrowser(AssessmentAutomationAgent);

                    String openEndedLabel = AssessmentCommonMethods.GetOpenEndedLabelFromQuestionTile(AssessmentAutomationAgent);
                    Assert.IsFalse(openEndedLabel.Contains("Unanswered"), "Unanswered Text found");
                    Assert.IsFalse(openEndedLabel.Contains("Answered"), "Answered Text found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51798", true);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login login = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo1 = login.GetTaskInfo("MATH", "MathAssessment");
                    String[] UnitStatusAtTeacher = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatusAtTeacher[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAtTeacher[0]);
                    Assert.IsTrue(AssessmentCommonMethods.ExerciseWithInProgressAndStartedStatus(AssessmentAutomationAgent, UnitStatusAtTeacher[8]), "Status Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46730", true);
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
        [TestCategory("Assessment"), TestCategory("US9758"), TestCategory("US9637"), TestCategory("US9512"), TestCategory("US9518"), TestCategory("US9514")]
        [Priority(1)]
        [WorkItem(46798), WorkItem(46795), WorkItem(46791), WorkItem(45800), WorkItem(45802), WorkItem(45806),WorkItem(46712), WorkItem(46713), WorkItem(46711), WorkItem(46716), WorkItem(46728), WorkItem(46052), WorkItem(46054), WorkItem(46056), WorkItem(46065), WorkItem(46063), WorkItem(46070)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyProgressBarDateStampAndReleaseScoreButtonEnabledInProjectAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45798,TC45795,TC45791,TC45800,TC45802,TC45806,TC46712,TC46713,TC46711,TC46716,TC46728,TC46052,TC46054,TC46056,TC46065,TC46063,TC46070: Verify the progress bar,date stamp and release score button enabled for Project Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "ProjectAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);

                    AssessmentCommonMethods.ClickProjectInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46052", true);

                    int NotScoredCount1 = AssessmentCommonMethods.GetNotScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);

                    int ScoredCount1 = AssessmentCommonMethods.GetScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);

                    String TotalStudents = AssessmentCommonMethods.GetTextOfTotalStudentsToReleaseScoresinOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score 4 students to release scores", TotalStudents, "Student Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46713", true);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    int releaseCount = AssessmentCommonMethods.GetScoreMoreCountInScoringOverview(AssessmentAutomationAgent);

                    AssessmentCommonMethods.TeacherScoresANoteBookAndProjectAssessment(AssessmentAutomationAgent,releaseCount,"--","2");

                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.NotScoredTabFoundInStopScoringDialogue(AssessmentAutomationAgent), "NotScored Tab is not Present in Stop scoring Dialogue");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45798", true);
                    Assert.IsTrue(AssessmentCommonMethods.ScoredTabFoundInStopScoringDialogue(AssessmentAutomationAgent), "Scored Tab is not displayed in Stop scoring Dialogue");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45795", true);
                    Assert.IsTrue(AssessmentCommonMethods.ScoredTabDefaultSelectedInStopScoringDialogue(AssessmentAutomationAgent), "ScoreTab is not selected by default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45791", true);

                    int NotScoredCount2 = Int32.Parse(AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogue(AssessmentAutomationAgent));

                    Assert.AreNotEqual(NotScoredCount1, NotScoredCount2, "Both the NotScored Count are Equal");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45800", true);

                    int ScoredCount2 = AssessmentCommonMethods.GetScoredCountFromStopScoringDialogue(AssessmentAutomationAgent);
                    Assert.AreNotEqual(ScoredCount1, ScoredCount2, "Both the Scored Count are  Equal");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45802", true);

                    AssessmentCommonMethods.ClickNotScoredTabInStopScoringDialogue(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.ScoredTabDefaultSelectedInStopScoringDialogue(AssessmentAutomationAgent), "ScoredTab Is Highlighted");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45806", true);

                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(AssessmentAutomationAgent);
                    String ReportTitle = AssessmentCommonMethods.GetTextFromAssessmentResultSummary(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Result Summary", ReportTitle, "Report Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46716", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46712", true);
                    
                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyInProgressStatusInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]), "InProgress Status is Not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46728", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46054", true);

                    AssessmentCommonMethods.ClickProjectInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]);

                    AssessmentCommonMethods.ReleaseScoreForNotebook(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46711", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDeliveredStatusInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]), "Delivered status is not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46056", true);

                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46065", true);

                    string ScoredStatus = AssessmentCommonMethods.GetScoredStatusFromOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]);
                    Assert.IsTrue(ScoredStatus.Contains(UnitStatus[8]), "Scored Sub Status is Displayed");
                    Assert.IsTrue(ScoredStatus.Contains("4/5"), "Scored Sub Status is Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46063", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46070", true);
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
        [TestCategory("Assessment"), TestCategory("US9757")]
        [Priority(1)]
        [WorkItem(51754), WorkItem(51753), WorkItem(51751), WorkItem(51743), WorkItem(51740), WorkItem(51747), WorkItem(51749), WorkItem(51748)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyOpenEndedResponseLabelFunctionalitiesForExercises()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51754,TC51753,TC51751,TC51743,TC51740,TC51747,TC51749,TC51748: Verify the Open-Ended Response label is present with summary flag"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickExercisesAssessmentInLessonBrowser(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyOpenEndedResponseLabelIsPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51754", true);

                    Assert.AreNotEqual("Unanswered", AssessmentCommonMethods.GetOpenEndedResponseLabelFromExerciseSummary(AssessmentAutomationAgent), "Unanswered Text is Found in Open Ended Response Tile");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51751", true);

                    Assert.AreNotEqual("Self Evaluation Response", AssessmentCommonMethods.GetOpenEndedResponseLabelFromExerciseSummary(AssessmentAutomationAgent), "Self Evaluation Response Text is Found in Open Ended Response Tile");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51753", true);

                    AssessmentCommonMethods.ClickOnOpenEndedResponseLabelInExerciseSummary(AssessmentAutomationAgent);

                    Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerButtonIsPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51740", true);

                    AssessmentCommonMethods.ClickFlagForLaterInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFlaggedLabelIsPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51743", true);

                    String PageTitle = AssessmentCommonMethods.GetTextFromStudentAssessmentSummaryPage(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Summary", PageTitle, "Student Assessment Screen Name Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51747", true);

                    AssessmentCommonMethods.ClickOnOpenEndedResponseLabelInExerciseSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickRemoveFlagInStudentAssessmentSummary(AssessmentAutomationAgent);

                    if (AssessmentCommonMethods.NextButtonFoundInTestPlayer(AssessmentAutomationAgent))
                    {
                    int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInExercisePlayerScreen"));
                    AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    Assert.AreNotEqual(currentQuestionNumber + 1, currentQuestionNumber, "Student Not Navigated To Next Question");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51749", true);
                    AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                    Assert.AreEqual(currentQuestionNumber, int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInExercisePlayerScreen")), "Student Not Navigated To Previous Question");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51748", true);
                    }                    
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
        [TestCategory("Assessment"), TestCategory("US9726")]
        [Priority(1)]
        [WorkItem(52216), WorkItem(52217), WorkItem(52218)]
        [Owner("Godwin Terence(godwin.terence")]
        public void VerifyStudentResponseCapturedForOpenResponseQuestion()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52216,TC52217,TC52218 :Verify the student response saved for open response questions. "))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    String[] studentAddtionalInfo = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentTapsOnUnlockedAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                    int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                    while (!AssessmentCommonMethods.OpenEndedResponsePresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }

                    if (AssessmentCommonMethods.OpenEndedResponsePresent(AssessmentAutomationAgent)) {
                        AssessmentCommonMethods.StudentAnswerOpenEndedResponse(AssessmentAutomationAgent, "ABC");                        
                        Assert.AreEqual("ABC", AssessmentCommonMethods.VerifyOpenEndedQuestionResponse(AssessmentAutomationAgent), "Student Response Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52216", true);
                        int openEndedResponseQuestion = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                        AssessmentCommonMethods.ClickQuestionTileInStudentAssessmentSummary(AssessmentAutomationAgent, openEndedResponseQuestion.ToString());
                        Assert.AreEqual("ABC", AssessmentCommonMethods.VerifyOpenEndedQuestionResponse(AssessmentAutomationAgent), "Student Response Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52217", true);
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.SubmitInConfirmationPopUpFound(AssessmentAutomationAgent);
                        AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                    }                   

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    string quesNo = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                    while (!AssessmentCommonMethods.OpenEndedResponsePresent(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    Assert.AreEqual("ABC", AssessmentCommonMethods.VerifyOpenEndedQuestionResponse(AssessmentAutomationAgent), "Student Response Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52218", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9755")]
        [Priority(1)]
        [WorkItem(51857)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyStudentExperienceOnMachineScoredQuestionForCorrectResponse()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51857: Verify the Student experience on machine scored question For Correct Response"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMachineScoredExercisesInLessonTab(AssessmentAutomationAgent,UnitStatus[9]);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.SuccessHumanScoredQuestionMessageDisplayed(AssessmentAutomationAgent), "Success Message Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51857", true);
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
        [TestCategory("Assessment"), TestCategory("US9755"), TestCategory("US9634"), TestCategory("US9632")]
        [Priority(1)]
        [WorkItem(51883), WorkItem(51859), WorkItem(52094), WorkItem(52404), WorkItem(51858), WorkItem(51792), WorkItem(51860), WorkItem(51863), WorkItem(51856), WorkItem(51864), WorkItem(53270), WorkItem(51871), WorkItem(51873), WorkItem(51797), WorkItem(52408)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyStudentExperienceOnMachineScoredQuestion()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51883,TC51859,TC52404,TC52094,TC51858,TC51792,TC51860,TC51863,TC51856,TC51864,TC53270,TC51871,TC51873,TC51797,TC52408: Verify the Student experience on machine scored question"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMachineScoredExercisesInLessonTab(AssessmentAutomationAgent,UnitStatus[9]);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[1]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.SelectAnAnswerFirstDisplayed(AssessmentAutomationAgent), "Message Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51883", true);
                    AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[3]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51859", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52404", true);
                    Assert.IsTrue(AssessmentCommonMethods.TryAgainMessageDisplayed(AssessmentAutomationAgent), "Try Again Message Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51858", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52094", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Enabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51860", true);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionStatusInAssessmentSummary(AssessmentAutomationAgent, UnitStatus[1]), "Question Incorrect Status Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51863", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51792", true);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[1]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51856", true);                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Not Enabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51864", true);                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53270", true);
                    AssessmentCommonMethods.ClickReviseAnswerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[3]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Is Present After Second Attempt.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51871", true);
                    Assert.IsTrue(AssessmentCommonMethods.TryAnotherQuestionMessageDisplayed(AssessmentAutomationAgent), "Try Another Question Message Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51873", true);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRevisedStatusInAssessmentSummary(AssessmentAutomationAgent, UnitStatus[1]), "Revised Status Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51797", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52408", true);
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
        [TestCategory("Assessment"), TestCategory("US9756"), TestCategory("US9632")]
        [Priority(1)]
        [WorkItem(51935), WorkItem(51961), WorkItem(51960), WorkItem(51937), WorkItem(51941), WorkItem(51939), WorkItem(51952), WorkItem(51940), WorkItem(52405), WorkItem(52411)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyStudentExperienceOnHumanScoredQuestion()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51935,TC51961,TC51960,TC51937,TC51941,TC51939,TC51952,TC51940,TC52405,TC52411: Verify the Student experience on human scored question"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMachineScoredExercisesInLessonTab(AssessmentAutomationAgent,UnitStatus[10]);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[7]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySelfEvaluationOptionsPresent(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51935", true);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionStatusInAssessmentSummary(AssessmentAutomationAgent, UnitStatus[6]), "Unanswered Status Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51961", true);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[7]);
                    //AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[3]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    if (AssessmentCommonMethods.NextButtonFoundInTestPlayer(AssessmentAutomationAgent))
                    {
                    AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                    }                    
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnderstandNowButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Enabled");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYouCanTryAgainLabelInSelfEvaluation(AssessmentAutomationAgent), "Student Is Unable To Select The Options");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51960", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51937", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52405", true);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifySelfEvaluationLabelInAssessmentSummary(AssessmentAutomationAgent, UnitStatus[7]), "Self Evaluation Status Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51941", true);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[7]);
                    AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Enabled");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYouCanTryAgainLabelInSelfEvaluation(AssessmentAutomationAgent), "Student Is Unable To Select The Options");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51939", true);
                    AssessmentCommonMethods.ClickReviseAnswerButton(AssessmentAutomationAgent);
                    //AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[3]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickNeedHelpButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Is Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51952", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52411", true);
                    if (AssessmentCommonMethods.NextButtonFoundInTestPlayer(AssessmentAutomationAgent))
                    {
                    AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                    }                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Enabled");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Is Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51940", true);
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
        [TestCategory("Assessment"), TestCategory("US9756"), TestCategory("US9927"), TestCategory("US9634"), TestCategory("US9635"), TestCategory("US10013")]
        [Priority(1)]
        [WorkItem(51936), WorkItem(51942), WorkItem(52214), WorkItem(51794), WorkItem(51805), WorkItem(51938), WorkItem(52095), WorkItem(51957), WorkItem(52813), WorkItem(51951)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyStudentExperienceOnHumanScoredQuestionForCorrectResponse()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51936,TC52214,TC51942,TC51805,TC51794,TC51938,TC52095,TC52813,TC51957,TC51951: Verify the Student experience on human scored question For Correct Response"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Exercise");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickExercisesInLessonBrowser(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickMachineScoredExercisesInLessonTab(AssessmentAutomationAgent,UnitStatus[10]);
                    AssessmentCommonMethods.ClickQuestionOneInStudentAssessmentSummary(AssessmentAutomationAgent, UnitStatus[6]);
                    //AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[3]);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickNeedHelpButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51938", true);
                    Assert.IsTrue(AssessmentCommonMethods.CorrectAnswerDisplayedInHumanScoredQuestion(AssessmentAutomationAgent), "Correct Answer Not Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52095", true);
                    if (AssessmentCommonMethods.VerifySampleAnswerImagePresentInExercise(AssessmentAutomationAgent))
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52813", true);
                    AssessmentCommonMethods.ClickReviseAnswerButton(AssessmentAutomationAgent);
                    //AssessmentCommonMethods.StudentAnswersMachineScoredQuestion(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51957", true);
                    AssessmentCommonMethods.ClickCheckAnswerButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Enabled");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent), "Revise Button Is Present.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51951", true);
                    AssessmentCommonMethods.ClickYesIgotItButton(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52214", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerButtonIsDisabled(AssessmentAutomationAgent), "Check Answer Button Is Enabled");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51936", true);
                    AssessmentCommonMethods.ClickSummaryButtonInExercise(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionStatusInAssessmentSummary(AssessmentAutomationAgent, UnitStatus[6]), "Self Evaluation Status Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51942", true);                    
                    Assert.IsTrue(AssessmentCommonMethods.GetYesIgotItLabelInAssessmentSummary(AssessmentAutomationAgent,UnitStatus[6]), "Self Evaluation Label is not present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51794", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51805", true);
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
        [TestCategory("Assessment"), TestCategory("US9474")]
        [Priority(1)]
        [WorkItem(52862), WorkItem(52860), WorkItem(52864)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyEquationEditorSupportQuestionInAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52862,TC52860,TC52864: Verify the Equation editor support is available in Assessment"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "EquationEditorAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickOnEquationEditorAssessment(AssessmentAutomationAgent,UnitStatus[6]);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyEquationEditorInAssessments(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52862", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[5]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo studentInfo = studentLogin.GetTaskInfo("ELA", "EquationEditorAssessment");
                    String[] studentUnit = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(studentInfo);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "Math");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, studentUnit[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, studentUnit[1]);
                    AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyEquationEditorInAssessments(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52860", true);
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentMathTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.ClickOnEquationEditorAssessment(AssessmentAutomationAgent,UnitStatus[6]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyEquationEditorInAssessments(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52864", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9759"), TestCategory("US9513"), TestCategory("US9515")]
        [Priority(1)]
        [ WorkItem(50720), WorkItem(51776), WorkItem(50727), WorkItem(50718), WorkItem(51916), WorkItem(51917)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyListOfScoredAndNotScoredStudentsForRubric()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC50720,TC50718,TC50727,TC51776,TC51916,TC51917: Verify scored tab & not scored in rubric assessment for stop scoring screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "DiscussionRubricAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[0]);
                    AssessmentCommonMethods.ClickRubricDiscussionOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]);

                    
                    int notScoredCount = AssessmentCommonMethods.GetNotScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);
                    ArrayList notScoredStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(AssessmentAutomationAgent, notScoredCount);

                    AssessmentCommonMethods.ClickScoredTabInAccomplishmentOverview(AssessmentAutomationAgent);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent);
                    ArrayList scoredStudentList = AssessmentCommonMethods.GetScoredStudentListFromAssessmentOverview(AssessmentAutomationAgent, scoredCount);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStudentListAtScoringOverview(AssessmentAutomationAgent, notScoredStudentList);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50720", true);
                    Assert.AreEqual("Rubric", AssessmentCommonMethods.VerifyRubricQuestionNumberLabel(AssessmentAutomationAgent), "Question Label Missing");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50718", true);
                    AssessmentCommonMethods.ClickRubricTileInObservationOverviewScreen(AssessmentAutomationAgent, UnitStatus[12]);
                    String ScreenTitle = AssessmentCommonMethods.GetRubricScoringTitle(AssessmentAutomationAgent);
                    Assert.AreEqual("Rubric Scoring", ScreenTitle, "Screen Title did not Match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC50727", true);
                    string currentStudentName = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickNextStudentButtonAtItemScoring(AssessmentAutomationAgent);
                    string StudentNameAfterNext = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    Assert.IsFalse(currentStudentName.Equals(StudentNameAfterNext), "Fail if same student name display again");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51916", true);
                    AssessmentCommonMethods.ClickOnPreviousStudentButton(AssessmentAutomationAgent);
                    string StudentNameAfterPrev = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(currentStudentName.Equals(StudentNameAfterPrev), "Fail if it does not navigate to previous student");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51917", true);

                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickNotScoredTabInStopScoringDialogue(AssessmentAutomationAgent);
                    int notscoredCountFromStopScoring = Int32.Parse(AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogue(AssessmentAutomationAgent));
                    ArrayList notScoredStudentListInStopScoring = AssessmentCommonMethods.GetNotScoredStudentListFromStopScoringDialogue(AssessmentAutomationAgent, notscoredCountFromStopScoring);
                    for (int i = 0; i <notScoredStudentList.Count; i++)
                        Assert.IsTrue(notScoredStudentList[i].Equals(notScoredStudentListInStopScoring[i]), "Fail if not scored list does not match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51776", true);

                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9758"), TestCategory("US9637"), TestCategory("US9639"), TestCategory("US9514"), TestCategory("US9512"), TestCategory("US10088")]
        [Priority(1)]
        [WorkItem(52192), WorkItem(52193), WorkItem(52050), WorkItem(52191), WorkItem(52185), WorkItem(52184), WorkItem(52198), WorkItem(52201), WorkItem(46066), WorkItem(46155), WorkItem(52826), WorkItem(52828), WorkItem(52830), WorkItem(52831)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyProgressBarDateStampAndReleaseScoreButtonEnabledInNotebookAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52192,TC52050,TC52193,TC52191,TC52185,TC52184,TC52198,TC52201,TC46155,TC46066,TC52826,TC52828,TC52830,TC52831: Verify the progress bar,date stamp and release score button enabled for Project Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[1]);
                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);                                        

                    String TotalStudents = AssessmentCommonMethods.GetTextOfTotalStudentsToReleaseScoresinOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score 4 students to release scores", TotalStudents, "Student Count Mismatch");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52193", true);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    int releaseCount = AssessmentCommonMethods.GetScoreMoreCountInScoringOverview(AssessmentAutomationAgent);                    

                    AssessmentCommonMethods.TeacherScoresANoteBookAndProjectAssessment(AssessmentAutomationAgent,releaseCount,"--","2");

                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyActiveReleaseScoreButtonAtScoringOverview(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52050", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(AssessmentAutomationAgent);
                    String ReportTitle = AssessmentCommonMethods.GetTextFromAssessmentResultSummary(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Result Summary", ReportTitle, "Report Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52185", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52192", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyInProgressStatusInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]), "InProgress Status is Not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52184", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredStatusInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]), "Scored status is displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52198", true);

                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent, UnitStatus[21]);
                    
                    AssessmentCommonMethods.ReleaseScoreForNotebook(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52191", true);


                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyTimeStampBelowScoreReleasedAtAssessmentManager(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52201", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46155", true);

                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDeliveredStatusInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]), "Delivered Status Not Found");
                    AssessmentCommonMethods.VerifyDateAndTimeInAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46066", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, UnitStatus1[0]);
                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent, UnitStatus1[16]);                                        
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredAnswerProjectReportTitlePresent(AssessmentAutomationAgent), "Student Not Navigated To Project Report");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52826", true);
                    Assert.AreNotEqual("--", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52828", true);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Read Only Mode Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52830", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52831", true);
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
        [TestCategory("Assessment"), TestCategory("US9641"), TestCategory("US9642"), TestCategory("US10016"), TestCategory("US10086"), TestCategory("US8190"), TestCategory("US9262"), TestCategory("US8186"), TestCategory("US9601"), TestCategory("US8194"), TestCategory("US9714")]
        [Priority(1)]
        [WorkItem(52087), WorkItem(51949), WorkItem(52085), WorkItem(52949), WorkItem(45258), WorkItem(52819), WorkItem(52955), WorkItem(52952), WorkItem(45185), WorkItem(45188), WorkItem(45190), WorkItem(45192), WorkItem(53171), WorkItem(52957), WorkItem(45212), WorkItem(46396), WorkItem(45211), WorkItem(43532), WorkItem(43534), WorkItem(43535), WorkItem(46732), WorkItem(46533), WorkItem(52940), WorkItem(52941), WorkItem(52948), WorkItem(52513), WorkItem(52512)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyProficiencyLevelInStudentAssessmentManagerScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52087,TC51949,TC52085,TC52949,TC45258,TC52819,TC52955,TC52952,TC45185,TC45188,TC45190,TC45192,TC53171,TC52957,TC45212,TC46396,TC45211,TC43532,TC43534,TC43535,TC46732,TC43533,TC52940,TC52941,TC52948,TC52513,TC52512: Verify the Proficiency Level of a student in assessment manager screen after score released"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    int n = AssessmentCommonMethods.StudentCountToReleaseInOverview(AssessmentAutomationAgent);
                    if (n > 1)
                    {
                        AssessmentCommonMethods.TeacherUnlocksAllStudent(AssessmentAutomationAgent);
                    }                    
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    for(int i =n;i>=1;i--)
                    {
                        Login studentLogin = Login.GetLogin("AssessmentStudent"+i.ToString());
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                        AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                        AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, UnitStatus1[0]);
                        AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, UnitStatus1[4]);
                        AssessmentCommonMethods.StudentAnswersAssessmentFromAssessmentManager(AssessmentAutomationAgent, "Submitted", UnitStatus1[4]);
                        AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);                        
                        NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52087", true);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent, UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);                    
                    for (int i = n; i >= 1; i--)
                    {
                    String TextAfterScoreing = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                        Assert.AreEqual("Score" +"  "+i.ToString()+"  "+"more to release scores", TextAfterScoreing, "Status Message Not Found");
                        Login studentLogin = Login.GetLogin("AssessmentStudent" + i.ToString());
                        string studentName = studentLogin.PersonName.Replace(",", "");
                        AssessmentCommonMethods.TeacherScoresAStudentForAllQuestions(AssessmentAutomationAgent, studentName,"3");                        
                  }                  
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45185", true);
                                        
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "release scores");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52513", true);

                    AssessmentCommonMethods.ClickMyDashboardButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNoInternetAccessMessageInLockUnlockScreen(AssessmentAutomationAgent, "release scores");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52512", true);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();

                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickCancelInAssessmentCompletionPopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45188", true);

                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYesButtonInStopScoringDialogue(AssessmentAutomationAgent), "Yes Button Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoButtonInStopScoringDialogue(AssessmentAutomationAgent), "No Button Not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52940", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52941", true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, true);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52948", true);
                    NavigationCommonMethods.ChangeWiFiConnectivity(AssessmentAutomationAgent, false);
                    AssessmentAutomationAgent.LaunchApp();
                    AssessmentCommonMethods.ClickOnStartButtonReleaseSscorePopUp(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45190", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45212", true);

                    AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45192", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53171", true);

                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45211", true);

                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentManagerButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDeliveredStatusInAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43532", true);
                    AssessmentCommonMethods.VerifyTimeStampBelowScoreReleasedAtAssessmentManager(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43534", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43535", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46732", true);
                    AssessmentCommonMethods.VerifyScoredStatusInAssessmentmanager(AssessmentAutomationAgent, UnitStatus[11]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43533", true);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentTile(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Unlocked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51949", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46396", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin1 = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);                    
                    TaskInfo taskInfo2 = studentLogin1.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus2 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo2);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, UnitStatus2[0]);
                    AssessmentCommonMethods.VerifyStudentProficiencyLabelStatusPresent(AssessmentAutomationAgent, UnitStatus2[4]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52085", true);
                    AssessmentCommonMethods.ClickScoreReleasedInStudentAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredAnswerReportTitlePresent(AssessmentAutomationAgent), "Student Not Navigated To Unit Report");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52949", true);
                    while (!AssessmentCommonMethods.VerifyRubricScoreButtonInTeacherPreview(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    Assert.AreNotEqual("--", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45258", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52819", true);
                    Assert.IsTrue(AssessmentCommonMethods.ViewCommentButtonPresentFixedAssessment(AssessmentAutomationAgent),"View Comment Button Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52955", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52957", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52952", true);
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
        [TestCategory("Assessment"), TestCategory("US9941"), TestCategory("US9639"), TestCategory("US8187")]
        [Priority(2)]
        [WorkItem(51812), WorkItem(52054), WorkItem(52039), WorkItem(52043), WorkItem(53182), WorkItem(52053), WorkItem(52222), WorkItem(52055), WorkItem(52044), WorkItem(52045), WorkItem(52040), WorkItem(51810)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyScoredTabSelectedtByDefaultInNotebookStopScoringScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC51812,TC52054,TC52039,TC52043,TC53182,TC52053,TC52222,TC52055,TC52044,TC52045,TC52040,TC51810: Verify Scored Tab is selected by default in notebook stop scoring screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentNameInProjectAssessmentScoring(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickOnStudentNameInProjectAssessmentScoring(AssessmentAutomationAgent, UnitStatus[13]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52040", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifySecondTilePresentInNotebookScoring(AssessmentAutomationAgent, "10"), "Two Question Card Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52039", true);
                    AssessmentCommonMethods.ClickOnProjectActiveTile(AssessmentAutomationAgent, "5");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssignmentScoringTitlePresent(AssessmentAutomationAgent), "Assignment Scoring Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52043", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAllGroupMembersTitlePresent(AssessmentAutomationAgent), "Assignment Scoring Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52044", true);
                    AssessmentCommonMethods.ClickStudentResponseTab(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52054", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyStudentResponsePresentInResponseScreen(AssessmentAutomationAgent), "Student Response Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53182", true);
                    AssessmentCommonMethods.ClickAllGroupMembersInScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameListInAllGroupMemberDropdown(AssessmentAutomationAgent) > 1, "Student List Not Displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52045", true);
                    AssessmentCommonMethods.ClickAllGroupMembersInScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssignmentTabPresentInScoringScreen(AssessmentAutomationAgent), "Assignement Tab Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52053", true);
                    AssessmentCommonMethods.VerifyQuestionContentDisplay(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52222", true);
                    if (!AssessmentCommonMethods.VerifyMultiDimensionalRubricGroupTitleLabel(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                        Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Flyout Not Present");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52055", true);
                    }
                    else
                    {
                        AssessmentCommonMethods.ClickNotScoredCriterions(AssessmentAutomationAgent,"--");
                        Assert.IsTrue(AssessmentCommonMethods.RubricScorePanelFlyoutArrowFound(AssessmentAutomationAgent), "Flyout Not Present");
                        AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52055", true);
                    }                    

                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);                    
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredTabSelectedByDefaultInStopScoringScreen(AssessmentAutomationAgent), "Scored Tab Not Selected By Default");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51812", true);
                    int ScoredCount = AssessmentCommonMethods.GetScoredCountFromStopScoringDialogue(AssessmentAutomationAgent);
                    if (ScoredCount == 0)
		            AssessmentCommonMethods.VerifyNoStudentMessage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51810", true);
                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9313")]
        [Priority(1)]
        [WorkItem(52387), WorkItem(52375), WorkItem(52388), WorkItem(52372), WorkItem(52366), WorkItem(52380), WorkItem(52377)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyTaskLevelAssessmentFunctionality()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52387,TC52375,TC52388,TC52372,TC52366,TC52380,TC52377: Verify whether the appropriate text is displayed to the teacher for the assessment task."))
            {
                try
                {
                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "TaskLevelAssessment");
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentPreviewAssessmentTextInTaskLevelAssessment(AssessmentAutomationAgent), "Tap 'Start assessment' to begin taking the assessment.");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52387", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentStatusInTaskLevelAssessment(AssessmentAutomationAgent, "Start"), "Start Label Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52375", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo1 = teacherLogin.GetTaskInfo("ELA", "TaskLevelAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit, taskInfo1.Lesson, taskInfo1.TaskNumber);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyTeacherPreviewAssessmentTextInTaskLevelAssessment(AssessmentAutomationAgent), "Preview the assessment to make sure its correct is missing");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52388", true);
                    AssessmentCommonMethods.ClickPreviewButtonInTaskLevelAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Locked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52372", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherUnlocksStudentForTaskLevelAssessment(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    AssessmentCommonMethods.ClickPreviewButtonInTaskLevelAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For UnLocked Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52366", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    AssessmentCommonMethods.StudentAnswerTaskLevelAssessment(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentStatusInTaskLevelAssessment(AssessmentAutomationAgent, "Submitted"), "Submitted Label Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52380", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit, taskInfo1.Lesson, taskInfo1.TaskNumber);
                    AssessmentCommonMethods.ClickPreviewButtonInTaskLevelAssessment(AssessmentAutomationAgent);
                    Assert.AreEqual("Item Preview", AssessmentCommonMethods.GetTitleFromPreviewAssessment(AssessmentAutomationAgent), "Preview Mode Not Available For Submitted Assessment");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52377", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateToMyDashboard(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickTaskLevelAssessmentInManagerScreen(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9643"), TestCategory("US9640")]
        [Priority(1)]
        [WorkItem(52246), WorkItem(52245), WorkItem(52534), WorkItem(52538), WorkItem(52539), WorkItem(52543), WorkItem(52550), WorkItem(52548), WorkItem(52544), WorkItem(52545)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyTeacherCanAddEditViewCommentForAStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52246,TC52245,TC52534,TC52538,TC52539,TC52543,TC52550,TC52548,TC52544,TC52545: Verify Teacher Can Add Edit View Comment For A Student"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);                    
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[1]);
                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentNameInProjectAssessmentScoring(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickOnProjectActiveTile(AssessmentAutomationAgent, "5");
                    AssessmentCommonMethods.ClickAllgroupMemeberDropDownInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStudentNameAndStatusInNotebookScoring(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52246", true);
                    AssessmentCommonMethods.SelectStudentFromDropDownInScoringOverviewScreen(AssessmentAutomationAgent, UnitStatus[12]);                    
                    Assert.IsFalse(AssessmentCommonMethods.VerifyAllGroupMembersTitlePresent(AssessmentAutomationAgent), "");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52245", true);
                    AssessmentCommonMethods.ClickAddCommentButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.AddCommentOverlayPresentInScoringScreen(AssessmentAutomationAgent), "Add Comment Overlay Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52534", true);
                    Assert.IsTrue(AssessmentCommonMethods.CreateButtonPresentInScoringScreen(AssessmentAutomationAgent), "Create Button Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52538", true);
                    AssessmentCommonMethods.TeacherEnterComments(AssessmentAutomationAgent, "abc");
                    AssessmentCommonMethods.ClickCreateCommentButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.AddCommentOverlayPresentInScoringScreen(AssessmentAutomationAgent), "Add Comment Overlay Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52539", true);
                    AssessmentCommonMethods.ClickEditCommentButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.AddCommentOverlayPresentInScoringScreen(AssessmentAutomationAgent), "Edit Comment Overlay Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52543", true);
                    Assert.AreNotEqual("11 / 1000 characters max", AssessmentCommonMethods.VerifyCharacterLimitInCommentBox(AssessmentAutomationAgent), "Comments Are Not Saved");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52550", true);
                    AssessmentCommonMethods.ClickDoneInCommentButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.AddCommentOverlayPresentInScoringScreen(AssessmentAutomationAgent), "Add Comment Overlay Is Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52548", true);
                    AssessmentCommonMethods.ClickEditCommentButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDeleteCommentButton(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52544", true);
                    AssessmentCommonMethods.ClickAddCommentButton(AssessmentAutomationAgent);
                    Assert.AreEqual("0 / 1000 characters max", AssessmentCommonMethods.VerifyCharacterLimitInCommentBox(AssessmentAutomationAgent), "Comments Are Not Deleted");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52545", true);
                    AssessmentCommonMethods.ClickCreateButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US8189"), TestCategory("US9262"), TestCategory("US8190")]
        [Priority(1)]
        [WorkItem(45186),WorkItem(45195),WorkItem(45196),WorkItem(53580), WorkItem(53187), WorkItem(53186), WorkItem(53188), WorkItem(53185)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyAssignedScoreUsingMultiDimensionalRubric()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45186,TC45195,TC45196,TC53580,TC53187,TC53186,TC53188,TC53185: Verify Assigned Score Using Multi-Dimensional Rubric"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "MultiRubricAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "MultiRubricAssessment");
                    String[] studentData = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, studentData[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(AssessmentAutomationAgent, studentData[1]);
                    AssessmentCommonMethods.StudentAnswersAssessmentFromAssessmentManager(AssessmentAutomationAgent, "Submitted", studentData[1]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    string PercentageValue = AssessmentCommonMethods.GetTextOfDynamicProgressBarValue(AssessmentAutomationAgent);
                    Assert.AreNotEqual("0%", PercentageValue, "Percentage Value Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45195", true);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    String TextBesideButton = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score  4  more to release scores", TextBesideButton, "Status Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45186", true);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45196", true);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    while (!AssessmentCommonMethods.VerifyMultiDimensionalRubricGroupTitleLabel(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53580", true);

                    AssessmentCommonMethods.TeacherScoresMultirubricQuestion(AssessmentAutomationAgent,"--","2");
                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53187", true);

                    Assert.AreNotEqual("--", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53188", true);

                    string rubricScore = AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickCriterionLevelInScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyMultiDimensionalLevelLabelPresent(AssessmentAutomationAgent, "1"), "Level Is Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53185", true);
                    AssessmentCommonMethods.ClickCriterionLevelInScoringScreen(AssessmentAutomationAgent);

                    AssessmentCommonMethods.TeacherScoresMultirubricQuestion(AssessmentAutomationAgent, "2", "--");

                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);                   

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
        [TestCategory("Assessment"), TestCategory("US9517"), TestCategory("US9516"), TestCategory("US9770"), TestCategory("US10087"), TestCategory("US9714")]
        [Priority(1)]
        [WorkItem(46025), WorkItem(46026), WorkItem(46173), WorkItem(46169), WorkItem(51930), WorkItem(51928), WorkItem(51929), WorkItem(46007), WorkItem(46028), WorkItem(46167), WorkItem(46233), WorkItem(52821), WorkItem(46187), WorkItem(46192), WorkItem(46191), WorkItem(46171), WorkItem(46196), WorkItem(46198), WorkItem(52942), WorkItem(46168), WorkItem(52822), WorkItem(52823)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyTheOverallFunctionalityOfChecklistScoringScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46025,TC46026,TC46173,TC46169,TC51930,TC51928,TC51929,TC46007,TC46028,TC46167,TC46233,TC52821,TC46187,TC46192,TC46191,TC46171,TC46196,TC46198,TC52942,TC46168,TC52822,TC52823: Verify the overall functionality of Checklist scoring screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "ChecklistAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickOnOngoingChecklistAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionActiveInChecklistScoringOverview(AssessmentAutomationAgent,UnitStatus[12]), "First Columm Is Not Active");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46173", true);
                    AssessmentCommonMethods.VerifyNotScoredCategoryInChecklistScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoredCategoryInChecklistScoringOverview(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46169", true);
                    string NotScoredCountBeforeScoring = AssessmentCommonMethods.GetNotScoredOngoingCountFromScoringOverview(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    
                    String pageTitle = AssessmentCommonMethods.GetTitleFromChecklistScoringPage(AssessmentAutomationAgent);
                    Assert.IsFalse(pageTitle.Equals("Checklist Scoring"), "Page title didn't match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46191", true);

                    if (AssessmentCommonMethods.VerifyNextStudentButton(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickNextStudentButtonAtItemScoring(AssessmentAutomationAgent);
                        AssessmentCommonMethods.VerifyPreviousStudentButtonInChecklistScoring(AssessmentAutomationAgent);
                        AssessmentCommonMethods.ClickPreviousStudentButtonInChecklistScoring(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46025", true);
                    }                    
                    AssessmentCommonMethods.ClickStudentDropdownInChecklistScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent), "Student Dropdown Not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51930", true);
                    AssessmentCommonMethods.VerifyStudentNameAndStatusInChecklistScoring(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51928", true);                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC51929", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46028", true);
                    AssessmentCommonMethods.ClickStudentDropdownInChecklistScoring(AssessmentAutomationAgent);
                    AssessmentCommonMethods.TeacherScoresACheclistAsNotObserved(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46007", true);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);                                        
                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCheckMarkInChecklistQuestionTile(AssessmentAutomationAgent), "Checkmark image not found on question tile");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46026", true);
                    AssessmentCommonMethods.ClickQuestionTwoInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.TeacherScoresACheclistAsNotObserved(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);                    
                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyOmitButtonInChecklistScreenPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46187", true);
                    
                    AssessmentCommonMethods.ClickOmitButtonInChecklistScoringScreen(AssessmentAutomationAgent);
                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAddButtonInChecklistScreenPresent(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46192", true);
                    string NotScoredCountAfterScoring = AssessmentCommonMethods.GetNotScoredOngoingCountFromScoringOverview(AssessmentAutomationAgent);
                    Assert.AreNotEqual(NotScoredCountBeforeScoring, NotScoredCountAfterScoring, "Student Is Not Moved to Scored");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46171", true);
                    
                    AssessmentCommonMethods.ClickAddButtonInChecklistScoringScreen(AssessmentAutomationAgent);
                    string NotScoredCountAfterAddObservation = AssessmentCommonMethods.GetNotScoredOngoingCountFromScoringOverview(AssessmentAutomationAgent);
                    Assert.AreEqual(NotScoredCountBeforeScoring, NotScoredCountAfterAddObservation, "Student Is Not Moved to Not Scored");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46196", true);
                    AssessmentCommonMethods.ClickQuestionThreeInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.TeacherScoresACheclistAsNotObserved(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonYesButton(AssessmentAutomationAgent);

                    string ScoredCountAfterScoringAllCheck = AssessmentCommonMethods.GetNotScoredOngoingCountFromScoringOverview(AssessmentAutomationAgent);
                    Assert.AreNotEqual(NotScoredCountBeforeScoring, ScoredCountAfterScoringAllCheck, "Student Is Not Moved to Scored");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46168", true);

                    AssessmentCommonMethods.ClickOmitButtonInChecklistScoringScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyOmitLayoutInChecklistScoringScreen(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46198", true);                    
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52942", true);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46167", true);

                    AssessmentCommonMethods.ReleaseScoreForNotebook(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46233", true);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "ChecklistAssessment");
                    String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(AssessmentAutomationAgent, UnitStatus1[0]);
                    AssessmentCommonMethods.ClickScoreReleasedInStudentAssessmentManager(AssessmentAutomationAgent,UnitStatus[21]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredAnswerProjectReportTitlePresent(AssessmentAutomationAgent), "Student Not Navigated To Project Report");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52821", true);
                    AssessmentCommonMethods.ConfirmChecklistAssessmentScored(AssessmentAutomationAgent);
                    while (AssessmentCommonMethods.verifyNextObservation(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickOnNextObservationButton(AssessmentAutomationAgent);
                        AssessmentCommonMethods.ConfirmChecklistAssessmentScored(AssessmentAutomationAgent);
                    }
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52822", true);
                    AssessmentCommonMethods.ClickOnConsistentOption(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.verifyConsistentButtonIsSelected(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52823", true);
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

       
        
        //[TestMethod()]
        [TestCategory("Assessment"), TestCategory("US9259")]
        [Priority(1)]
        [WorkItem(53167), WorkItem(53168), WorkItem(53169)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDifferentStatusLabelInDropDownForFixedAssessments()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC53167,TC53168,TC53169: Verify for each student in the section the student name and the ‘Scored’ label is displayed in the drop down box of the ‘assessment overview screen’."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted",UnitStatus[21]);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.VerifyStudentNameAndSubmittedStatusInItemScoring(AssessmentAutomationAgent, UnitStatus[11]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52169", true);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");

                    while (AssessmentCommonMethods.VerifyNextQuestionButtonInItemScorring(AssessmentAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickNextQuestionButtonInItemScoring(AssessmentAutomationAgent, 1);
                        AssessmentCommonMethods.TeacherScoresMultirubricQuestion(AssessmentAutomationAgent,"--","2");
                    }
                    AssessmentCommonMethods.VerifyStudentNameAndScoredStatusInItemScoring(AssessmentAutomationAgent, UnitStatus[11]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52168", true);

                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);

                    AssessmentCommonMethods.VerifyClickingOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent,UnitStatus[12]);
                    AssessmentCommonMethods.VerifyStudentNameAndReleasedStatusInItemScoring(AssessmentAutomationAgent, UnitStatus[11]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52167", true);

                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9640")]
        [Priority(1)]
        [WorkItem(52247), WorkItem(52241), WorkItem(52248)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyBlankScoreForSecondStudentAftreScoringFirstStudentInNotebook()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52241,TC52248,TC52247: Verify for the score in the rubric scoring box for second student."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[0]);
                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentNameInProjectAssessmentScoring(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickOnStudentNameInProjectAssessmentScoring(AssessmentAutomationAgent, UnitStatus[13]);
                    AssessmentCommonMethods.ClickOnProjectActiveTile(AssessmentAutomationAgent, "5");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAllGroupMembersTitlePresent(AssessmentAutomationAgent), "All Group Memebers Not Present");
                    AssessmentCommonMethods.TeacherScoresNotebookAssessment(AssessmentAutomationAgent,"--", "2");
                    AssessmentCommonMethods.ClickAllgroupMemeberDropDownInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.SelectStudentFromDropDownInScoringOverviewScreen(AssessmentAutomationAgent,UnitStatus[12]);
                    Assert.AreEqual("2", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentCommonMethods.TeacherScoresNotebookAssessment(AssessmentAutomationAgent,"2", "4");
                    Assert.AreEqual("4", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52241", true);
                    AssessmentCommonMethods.ClickAllgroupMemeberDropDownInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.SelectStudentFromDropDownInScoringOverviewScreen(AssessmentAutomationAgent, UnitStatus[13]);
                    Assert.AreEqual("2", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52247", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52248", true);
                    AssessmentCommonMethods.TeacherScoresNotebookAssessment(AssessmentAutomationAgent, "2", "--");
                    AssessmentCommonMethods.ClickAllgroupMemeberDropDownInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.SelectStudentFromDropDownInScoringOverviewScreen(AssessmentAutomationAgent,UnitStatus[12]);                    
                    AssessmentCommonMethods.TeacherScoresNotebookAssessment(AssessmentAutomationAgent,"4", "--");
                    Assert.AreEqual("--", AssessmentCommonMethods.VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9313")]
        [Priority(1)]
        [WorkItem(52382), WorkItem(52385)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyTaskLevelAssessmentFunctionalityAfterScoresReleased()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52382,TC52385: Verify whether the teacher and studen tbale to view the assessment task after scores released."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo1 = teacherLogin.GetTaskInfo("ELA", "TaskLevelAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.TeacherUnlocksStudentForTaskLevelAssessment(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0],UnitStatus[21]);
                    int n = AssessmentCommonMethods.StudentCountToReleaseInOverview(AssessmentAutomationAgent);
                    if (n > 1)
                    {
                        AssessmentCommonMethods.TeacherUnlocksAllStudent(AssessmentAutomationAgent);
                    }                    
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);


                    for (int i = n; i >= 1; i--)
                    {
                        Login studentLogin = Login.GetLogin("AssessmentStudent" + i.ToString());
                    TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "TaskLevelAssessment");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    AssessmentCommonMethods.StudentAnswerTaskLevelAssessment(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentStatusInTaskLevelAssessment(AssessmentAutomationAgent, "Submitted"), "Submitted Label Not Present");
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                    }

                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickTaskLevelAssessmentInManagerScreen(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    for (int i = n; i >= 1; i--)
                    {
                        String TextAfterScoreing = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                        Assert.AreEqual("Score" + "  " + i.ToString() + "  " + "more to release scores", TextAfterScoreing, "Status Message Not Found");
                        Login studentLogin = Login.GetLogin("AssessmentStudent" + i.ToString());
                        string studentName = studentLogin.PersonName.Replace(",", "");
                        AssessmentCommonMethods.TeacherScoresAStudentForAllQuestions(AssessmentAutomationAgent, studentName, "2");
                    }
                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStartButtonReleaseSscorePopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit, taskInfo1.Lesson, taskInfo1.TaskNumber);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyTeacherPreviewAssessmentTextInTaskLevelAssessment(AssessmentAutomationAgent), "Preview the assessment to make sure its correct is missing");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52382", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin1 = Login.GetLogin("AssessmentStudent1");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);
                    TaskInfo taskInfo2 = studentLogin1.GetTaskInfo("ELA", "TaskLevelAssessment");
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo2.Grade, taskInfo2.Unit, taskInfo2.Lesson, taskInfo2.TaskNumber);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentStatusInTaskLevelAssessment(AssessmentAutomationAgent, "View Scores"), "Released Label Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52385", true);
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
        [TestCategory("Assessment"), TestCategory("US9640")]
        [Priority(1)]
        [WorkItem(52223), WorkItem(52227)]
        [Owner("Godwin Terence(godwin.terence)")]
        public void VerifyRelevantNotebookSharedIsDisplyedInNotebookAssessmentScoringScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52223,TC52227: Verify whether the teacher is displayed with the relevant assessment notebooks for the selected students in the scoring overview screen."))
            {
                try
                {
                    Login studentLogin = Login.GetLogin("AssessmentStudent1");
                    TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "NotebookAssessment");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    String[] teacherName = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    AssessmentCommonMethods.StudentSharesNotebookToTeacher(AssessmentAutomationAgent,teacherName[17]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo1 = teacherLogin.GetTaskInfo("ELA", "NotebookAssessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickNotebookInOngoingAssessment(AssessmentAutomationAgent,UnitStatus[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentNameInProjectAssessmentScoring(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickOnProjectActiveTile(AssessmentAutomationAgent, "5");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAllGroupMembersTitlePresent(AssessmentAutomationAgent), "All Group Memebers Not Present");
                    AssessmentCommonMethods.ClickAllgroupMemeberDropDownInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.SelectStudentFromDropDownInScoringOverviewScreen(AssessmentAutomationAgent, UnitStatus[12]);                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifySharedNotebookPresentInScoringScreen(AssessmentAutomationAgent), "Shared Notebook Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52223", true);
                    AssessmentCommonMethods.TeacherTapsOnSharedNoteBook(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyTeaherAbleToTapOnSharedNotebook(AssessmentAutomationAgent), "Notebook tile is not tappable");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52227", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
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