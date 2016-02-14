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
    public class AssessmentFixedScoring
    {
        public AutomationAgent AssessmentAutomationAgent;


        [TestMethod()]
        [TestCategory("Assessment")]
        [Priority(2)]
        [WorkItem(45202)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherCanScore()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45202 :Verify that teacher can score any of the student by tapping on number in fly out"))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
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
        [WorkItem(45201)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherCanUnScore()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45201 : Verify that teacher can un-score the student by tapping on “-“in fly out"))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "2"), "Scored value not found in the rubric box");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "--");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "--"), "Scored value not found in the rubric box");

                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
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
        [WorkItem(45200)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTheDisplayOfSymbol()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45200 : Verify the “-“displayed in criterion level strip on tapping of “Score box”"))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "2"), "Scored value not found in the rubric box");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyValueInRubricFlyout(AssessmentAutomationAgent, "--"), "\"--\"value not found in the rubric box");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
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
        [WorkItem(45199)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTheDisplayOfSymbolsInCriterionLevel()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45199 : Verify the “-“displayed in criterion level strip on tapping of “Score box”"))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyValueInRubricFlyout(AssessmentAutomationAgent, "-"), "\"--\"value not found in the rubric box");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
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
        [WorkItem(43690), WorkItem(43691), WorkItem(43834), WorkItem(43835), WorkItem(44751)]
        [Owner("Godwin Terence (godwin.terence)")]
        public void VerifyTheProgressBarAndButtonStatusForEachStateInAssessmentOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43690,TC43691,TC43834,TC43835,TC44751: Verify The Progress Bar And Button Status For Each State In Assessment Overview"))
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
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
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

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    String TextBesideButton = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score  1  more to release scores", TextBesideButton, "Status Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC44751", true);

                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9512")]
        [Priority(1)]
        [WorkItem(46236), WorkItem(46238)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void FunctionalityOfViewReportnAndScoreButtonInAssessmentProgressOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46236,TC46238:Verify the functionality of the ‘View Report’ button at the bottom right corner of the assessment progress overview screen."))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    String ScoringOverviewTitle = AssessmentCommonMethods.GetTextFromScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Overview", ScoringOverviewTitle, "Scoring Overview Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46238", true);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(AssessmentAutomationAgent);
                    String ReportTitle = AssessmentCommonMethods.GetTextFromAssessmentResultSummary(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Result Summary", ReportTitle, "Report Title Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC46236", true);
                    NavigationCommonMethods.CloseApplication(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.LaunchApp();

                    Login teacherLogin2 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
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
        [TestCategory("Assessment"), TestCategory("US8186")]
        [Priority(1)]
        [WorkItem(45206), WorkItem(45209), WorkItem(45208), WorkItem(45215), WorkItem(45246), WorkItem(45263)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void FunctionalitiesInScoringOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45206,TC45209, TC45208,TC45215, TC45246,TC45263 :Verify disabled “Release Scores” button when student submitted assessment less than 80%."))
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
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    String ScoringOverviewTitle = AssessmentCommonMethods.GetTextFromScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Overview", ScoringOverviewTitle);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45206", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoresButtonDisabled(AssessmentAutomationAgent));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45209", true);

                    String QuestionNumberInScoringOverview = AssessmentCommonMethods.GetQuestionNumberInScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    String QuestionNumberInItemScoring = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                    Assert.AreEqual(QuestionNumberInScoringOverview, QuestionNumberInItemScoring, "Question Number In Item Scoring Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45263", true);

                    String TextBesideButton = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score  1  more to release scores", TextBesideButton, "Status Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45208", true);

                    Assert.IsTrue(AssessmentCommonMethods.SubmittedCountLabelInScoringOverview(AssessmentAutomationAgent, UnitStatus[17]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45215", true);

                    Assert.IsTrue(AssessmentCommonMethods.ScoredCountLabelInScoringOverview(AssessmentAutomationAgent, UnitStatus[18]));
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45246", true);

                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
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
        [TestCategory("Assessment")]
        [Priority(2)]
        [WorkItem(45159)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTapingOnScoreRedirectToScoringOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45159: Verify Teacher should be in Assessment Scoring overview screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoringOverviewTitle(AssessmentAutomationAgent);
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
        [WorkItem(45160)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnBackFromScoringOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45160: Verify Teacher should be in the Assessment Progress Overview screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9262")]
        [Priority(1)]
        [WorkItem(45194)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyReleaseScoresButtonIsDisabled()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45194: Verify disabled “Release Scores” button when student submitted assessment less than 80%"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    int ScoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverview(AssessmentAutomationAgent);
                    if (ScoredCount >= 1)
                        Assert.Fail("Release Score button is Activated");
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoresDisabled(AssessmentAutomationAgent), "Release Scores tab is not disabled");
                    NavigationCommonMethods.ClickLessonBrowserBackButton(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9714")]
        [Priority(1)]
        [WorkItem(52940)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyReleasingScorePopUpButtons()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52940: Verify whether the teacher is able to view the redesigned dialog box while releasing scores from assessment progress overview screen."))
            {
                try
                {

                    Login teacherLogin = Login.GetLogin("AdeleAlamedaTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("MATH", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[2], UnitStatus[3], UnitStatus[4]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudentExercise");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("MATH", "Assessment");
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);

                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[2]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "3");
                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);


                    AssessmentCommonMethods.ClickQuestionTwoInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFlyoutForEachCriteria(AssessmentAutomationAgent, "1");
                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionThreeInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickFlyoutForEachCriteria(AssessmentAutomationAgent, "1");
                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);


                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYesButtonInStopScoringDialogue(AssessmentAutomationAgent));
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoButtonInStopScoringDialogue(AssessmentAutomationAgent));
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
        [TestCategory("Assessment"), TestCategory("US9263")]
        [Priority(2)]
        [WorkItem(45111), WorkItem(45113), WorkItem(45120), WorkItem(45118), WorkItem(45116), WorkItem(45114)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyStudentCountInScoringOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45111,TC45113,TC45120,TC45118,TC45116,TC45114 : Verify whether the teacher is able to navigate back to the assessment overview screen by clicking the back navigational arrow the Scoring overview screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    String ScoringOverviewTitle = AssessmentCommonMethods.GetTextFromScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Overview", ScoringOverviewTitle);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45111", true);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45113", true);
                    int notStartedCount = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int startedCount = AssessmentCommonMethods.GetStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int submittedCount = AssessmentCommonMethods.GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(notStartedCount.Equals(AssessmentCommonMethods.GetNotStartedCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if submitted count does not match");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45120", true);
                    Assert.IsTrue(startedCount.Equals(AssessmentCommonMethods.GetStartedCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if count is not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45118", true);
                    Assert.IsTrue(scoredCount.Equals(AssessmentCommonMethods.GetScoredCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if count is not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45116", true);
                    Assert.IsTrue(submittedCount.Equals(AssessmentCommonMethods.GetSubmittedCountFromScoringOverview(AssessmentAutomationAgent)), "Fail if count is not matched");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45114", true);
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
        [TestCategory("Assessment"), TestCategory("US8186")]
        [Priority(2)]
        [WorkItem(45210), WorkItem(45214), WorkItem(45213), WorkItem(45207)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyQuestionNumberHeaderScreenAssessmentNameInScoringOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45210,TC45214,TC45213,TC45207 :Verify question number header in Scoring Overview screen"))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45210", true);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySubmittedCategory(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoredCategory(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStartedCategory(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyNotStartedCategory(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45214", true);
                    AssessmentCommonMethods.VerifyQuestionsHeader(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45213", true);
                    String ScoringOverviewTitle = AssessmentCommonMethods.GetTextFromScoringOverviewScreen(AssessmentAutomationAgent);
                    Assert.AreEqual("Scoring Overview", ScoringOverviewTitle, "Scoring Overview Title Not Found");
                    String AssessmentTitle = AssessmentCommonMethods.GetAssessmentNameFromAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual(AssessmentTitle.Contains("Assessment with a long name"), "Expected Assessment title not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45207", true);

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
        [TestCategory("Assessment"), TestCategory("US9263")]
        [Priority(1)]
        [WorkItem(45121), WorkItem(45119), WorkItem(45117), WorkItem(45115)]
        [Owner("Aalmeen Khan(aalmeen.khan)")]
        public void VerifyTheStudentsListInScoringOverview()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45121,TC45119,TC45117,TC45115 : Verify for the not started student list in the scoring overview screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnNotStartedTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList notStartedStudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(notStartedStudentList[0].Equals(""), "Fail as not started student list is blank for selected assessment");
                    AssessmentCommonMethods.ClickOnStartedTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList startedStudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(startedStudentList[0].Equals(""), "Fail as started student list is blank for selected assessment");
                    AssessmentCommonMethods.ClickOnScoredTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList scoredtudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(scoredtudentList[0].Equals(""), "Fail as scrored student list is blank for selected assessment");
                    AssessmentCommonMethods.ClickOnSubmittedTabFromAssessmentOverview(AssessmentAutomationAgent);
                    ArrayList submittedStudentList = AssessmentCommonMethods.GetStudentListFromAssessmentOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(submittedStudentList[0].Equals(""), "Fail as submitted student list is blank for selected assessment");
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStudentListAtScoringOverview(AssessmentAutomationAgent, notStartedStudentList);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45121", true);
                    AssessmentCommonMethods.VerifyStudentListAtScoringOverview(AssessmentAutomationAgent, startedStudentList);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45119", true);
                    AssessmentCommonMethods.VerifyStudentListAtScoringOverview(AssessmentAutomationAgent, scoredtudentList);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45117", true);
                    AssessmentCommonMethods.VerifyStudentListAtScoringOverview(AssessmentAutomationAgent, submittedStudentList);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45115", true);
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
        [TestCategory("Assessment"), TestCategory("US9265"), TestCategory("US9408")]
        [Priority(1)]
        [WorkItem(53195), WorkItem(53196), WorkItem(53197), WorkItem(53198)]
        [Owner("Lakshmi Brunda(lakshmi.brunda")]
        public void VerifyScoreFlyoutFunctionalities()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC53195,TC53196,TC53197,TC53198 :   Verify that teacher can score any of the student by tapping on number in fly out"))
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
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "2"), "Scored value not found in the rubric box");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53195", true);

                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "--");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "--"), "Scored value not found in the rubric box");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53196", true);

                    AssessmentCommonMethods.CheckCriterionLevel(AssessmentAutomationAgent, "4");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53197", true);

                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "3");
                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "3"), "Scored value not found in the rubric box");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53198", true);

                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US10012")]
        [Priority(1)]
        [WorkItem(52810), WorkItem(52812), WorkItem(52811), WorkItem(52936), WorkItem(52934), WorkItem(52935)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySampleAnswerFunctionalitiesInPreviewAssessmentAndScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52810,TC52812,TC52811,TC52936,TC52934,TC52935: Verify the teacher should be able to view the images in the sample answer modal if the sample answer contains images."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickOnFixedAssessmentSampleAnswerAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnSampleAnswerInRubric(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySampleAnswerImage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52810", true);
                    AssessmentCommonMethods.VerifySampleAnswerTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52812", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerCloseIcon(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent), "Fail if sample answer modal still displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52811", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnSampleAnswerInRubric(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySampleAnswerTitle(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52936", true);
                    AssessmentCommonMethods.VerifySampleAnswerImage(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52934", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerCloseIcon(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent), "Fail if sample answer modal window still displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52935", true);
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
        [TestCategory("Assessment"), TestCategory("US9915")]
        [Priority(1)]
        [WorkItem(52076), WorkItem(52078), WorkItem(52072), WorkItem(52077), WorkItem(52074)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnHideButtonForFixedInPreviewAssessmentAndScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52076,TC52078,TC52072,TC52077,TC52074: Verify the functionality of “Hidden” button expanded in assessment preview screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Fail if rubric panel not present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52076", true);
                    AssessmentCommonMethods.ClickOnHideIconOfRubric(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Fail if rubric panel present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52078", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52072", true);
                    AssessmentCommonMethods.VerifyHideButtonInRubricSection(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52077", true);
                    AssessmentCommonMethods.ClickOnHideIconOfRubric(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.RubricPanelPresent(AssessmentAutomationAgent), "Fail if rubric panel present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52074", true);
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
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(45191)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTheDisplayOfNotScoredStudentCountInStopScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45191 : Verify whether the ‘Student not scored’ count is available in the ‘Scoring report completion screen’."))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    int notStartedCountOne = AssessmentCommonMethods.GetNotStartedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonTile(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    int notScoredCountTwo = AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogueInAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual(notStartedCountOne, notScoredCountTwo, "Both the values are Unequal");

                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
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
        [WorkItem(43529)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySubmittedAndScoredStatusInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43529: Verify the “Submitted” and “Scored” sub statuses in the assessment manager page."))
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
                    AssessmentCommonMethods.VerifyScoreStatusInAssessmentmanager(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9258")]
        [Priority(1)]
        [WorkItem(45123), WorkItem(45125), WorkItem(45126), WorkItem(45124), WorkItem(45129), WorkItem(45130)]
        [Owner("Aalmeen Khan(aalmeen.khan)")]
        public void VerifyNavigationToNextAndPreviousQuestionInItemScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45123,TC45125,TC45126,TC45124,TC45129,TC45130: Verify The teacher should not be displayed with the ‘Next’ button if that is the last question of the assessment."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyItemScoringScreen(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDefaultQuestion(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45123", true);
                    int totalQuestions = AssessmentCommonMethods.GetTotalQuestionNumberAtItemScoring(AssessmentAutomationAgent);
                    int quesNo = Int32.Parse(AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent));
                    while (!quesNo.Equals(1))
                    {
                        AssessmentCommonMethods.ClickPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent);
                    }
                    Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent), "Fail if Previous button will display");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45125", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45126", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNextQuestionButtonInItemScorring(AssessmentAutomationAgent), "Fail if Next button will not display");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45124", true);

                    while (quesNo.Equals(totalQuestions))
                    {
                        AssessmentCommonMethods.ClickNextQuestionButtonInItemScoring(AssessmentAutomationAgent, 1);
                    }
                    Assert.IsFalse(AssessmentCommonMethods.VerifyNextQuestionButtonInItemScorring(AssessmentAutomationAgent), "Fail if Next button displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45129", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent), "Fail if Previous button does not displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45130", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9258")]
        [Priority(1)]
        [WorkItem(45127), WorkItem(45131), WorkItem(45128), WorkItem(45134), WorkItem(45132)]
        [Owner("Aalmeen Khan(aalmeen.khan)")]
        public void VerifyTappingOnNextPreviousRedirectForSameStudentAndQuestion()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45127,TC45131,TC45128,TC45134,TC45132 : Verify The teacher should be navigated to the previous question of the assessment for the same student if the teacher taps on the ‘Previous’ button in the assessment scoring screen."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyItemScoringScreen(AssessmentAutomationAgent);
                    string studentName = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    int totalQuesNo = Int32.Parse(AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent));
                    int quesNo = Int32.Parse(AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent));
                    if (quesNo.Equals(1))
                        AssessmentCommonMethods.ClickNextQuestionButtonInItemScoring(AssessmentAutomationAgent, AssessmentCommonMethods.randomInteger(totalQuesNo));
                    string quesNoAfterTappingNext = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(quesNoAfterTappingNext.Equals(quesNo + 1), "Fail if tapping on next does not navigate to next question");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45127", true);
                    string studentNameAfterTapingNext = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(studentName.Equals(studentNameAfterTapingNext), "Fail if taping next does not redirect to same student");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45131", true);
                    AssessmentCommonMethods.ClickPreviousQuestionButtonInItemScoring(AssessmentAutomationAgent);
                    string quesNoAfterTappingPrevious = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(quesNo.Equals(quesNoAfterTappingPrevious + 1), "Fail if tapping on previous button does not navigate to previous question");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45128", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45134", true);
                    string studentNameAfterTapingPrevious = AssessmentCommonMethods.GetStudentNameFromItemScoringScreen(AssessmentAutomationAgent);
                    Assert.IsTrue(studentName.Equals(studentNameAfterTapingPrevious), "Fail if taping previous does not redirect to same student");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45132", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9258")]
        [Priority(1)]
        [WorkItem(45136), WorkItem(45138), WorkItem(45137)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifNextAndpreviousStudentButtonAtItemScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45136,TC45138,TC45137: Verify The total number of students submitted should be displayed at the top of the ‘Assessment scoring screen’ "))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    int submittedStudentCountAtAssessmentOverview = AssessmentCommonMethods.GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    int submittedStudentCountAtItemScoring = AssessmentCommonMethods.GetSubmittedStudentsCountAtItemScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(submittedStudentCountAtAssessmentOverview.Equals(submittedStudentCountAtItemScoring), "Fail as if submitted student count does not display at item scoring overview");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45136", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNextStudentButton(AssessmentAutomationAgent), "Next student button not found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45138", true);
                    if (AssessmentCommonMethods.VerifyNextStudentButton(AssessmentAutomationAgent))
                        AssessmentCommonMethods.ClickNextStudentButtonAtItemScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviousStudentButton(AssessmentAutomationAgent), "Fail if previous student button will not display");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45137", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US8191")]
        [Priority(1)]
        [WorkItem(45323), WorkItem(45324), WorkItem(45325), WorkItem(45326)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySampleAnswerModalWindow()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45323,TC45324,TC45325,TC45326: Verify Teacher should see sample answer in modal window"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickOnFixedAssessmentSampleAnswerAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySampleAnswerButtonInRubric(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45323", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerInRubric(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45324", true);
                    AssessmentCommonMethods.VerifySampleAnswerScrollView(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45325", true);
                    AssessmentCommonMethods.ClickOnSampleAnswerCloseIcon(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerModalWindow(AssessmentAutomationAgent), "Fail if sample answer modal window still displayed");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45326", true);
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
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(45203)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyFlyOutdisappearsOnScoringStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45203: Verify the color change on scoring the student"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    String scoreValue = AssessmentCommonMethods.GetRubricScoreLabelValue(AssessmentAutomationAgent);
                    Assert.AreEqual("2", scoreValue, "Score value is not equal");
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
        [TestCategory("Assessment"), TestCategory("US9944")]
        [Priority(1)]
        [WorkItem(52230), WorkItem(52229)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyQuestionTabAndStudentResponseWebViewInAssessment()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52230,TC52229: Verify the test player for Question Tab in Item Scoring Screen"))
            {
                try
                {

                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[2], UnitStatus[3], UnitStatus[4]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    AssessmentCommonMethods.NavigateToMathGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentScoringCheckbox(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52230", true);
                    AssessmentCommonMethods.ClickQuestionTabInItemScoring(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.WebViewOfTestPlayer(AssessmentAutomationAgent), "Test Player Not Present");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52229", true);
                    AssessmentCommonMethods.BackToScoringOverviewScreen(AssessmentAutomationAgent);
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
                    AssessmentCommonMethods.TeacherUnlocksAStudent(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[12], UnitStatus[0]);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    String[] studentAddtionalInfo = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.NavigateToGradeAndUnit(AssessmentAutomationAgent, taskInfo1.Grade, taskInfo1.Unit);
                    AssessmentCommonMethods.StudentTapsOnUnlockedAssessment(AssessmentAutomationAgent);
                    int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                    int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                    while (!currentQuestionNumber.Equals(studentAddtionalInfo[2]))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    AssessmentCommonMethods.StudentAnswerOpenEndedResponse(AssessmentAutomationAgent, "123");
                    AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                    Assert.AreEqual("123", AssessmentCommonMethods.VerifyOpenEndedQuestionResponse(AssessmentAutomationAgent), "Student Response Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52216", true);
                    AssessmentCommonMethods.StudentAnswerOpenEndedResponse(AssessmentAutomationAgent, "456");
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickQuestionTileInStudentAssessmentSummary(AssessmentAutomationAgent, studentAddtionalInfo[2]);
                    Assert.AreEqual("456", AssessmentCommonMethods.VerifyOpenEndedQuestionResponse(AssessmentAutomationAgent), "Student Response Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52217", true);
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.SubmitInConfirmationPopUpFound(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    String[] UnitStatusAfterAssessmentStarted = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatusAfterAssessmentStarted[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    string quesNo = AssessmentCommonMethods.GetQuestionNumberInItemScoringScreen(AssessmentAutomationAgent);
                    while (!quesNo.Equals(studentAddtionalInfo[2]))
                    {
                        AssessmentCommonMethods.ClickAssessmentNextButton(AssessmentAutomationAgent);
                    }
                    Assert.AreEqual("456", AssessmentCommonMethods.VerifyOpenEndedQuestionResponse(AssessmentAutomationAgent), "Student Response Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52218", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
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
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(45205)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyScoresPersistForThePreviouslyScoredStudent()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45205: Verify Teacher should see the Scores persist for the previously scored student"))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "1");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "1"), "Scored value not found in the rubric box");
                    AssessmentCommonMethods.ClickNextStudentButtonAtItemScoring(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnPreviousStudentButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, "1"), "Scored value not found in the rubric box");
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
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(45189)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyTheDisplayOfStudentPartiallyScoredCountInStopScoring()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45189 : Verify whether the ‘Student Partially scored’ count is available in the ‘Scoring report completion screen’."))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    int scoredCount = AssessmentCommonMethods.GetScoredCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonTile(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    int partiallyScoredCount = AssessmentCommonMethods.GetNotScoredCountFromStopScoringDialogueInAssessmentManager(AssessmentAutomationAgent);
                    Assert.AreEqual(scoredCount, partiallyScoredCount, "Both the values are Unequal");

                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9611")]
        [Priority(1)]
        [WorkItem(45772)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void ComparePartiallyScoredAndSubmittedCount()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45772: Verify if the number of students ‘Not scored’ and Partially scored’ displayed near the ‘Stop Scoring’ text are from the ‘Submitted’ category in the completion report screen."))
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
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    int submittedCount = AssessmentCommonMethods.GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickonTile(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                    int partiallyScoredCount = AssessmentCommonMethods.GetPartiallyScoredCountInStopScoringDialogue(AssessmentAutomationAgent);

                    if (submittedCount < partiallyScoredCount)
                        Assert.Fail("Test case didn't meet expected result");

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
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickOnEquationEditorAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickPreviewAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyEquationEditorInAssessments(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52862", true);
                    AssessmentCommonMethods.ClickPreviewAssessmentDone(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnlockAssessments(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin);
                    TaskInfo studentInfo = studentLogin.GetTaskInfo("ELA", "Assessment");
                    String[] studentUnit = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(studentInfo);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, studentUnit[0]);
                    AssessmentCommonMethods.ClickOnEquationEditorAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyEquationEditorInAssessments(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52860", true);
                    AssessmentCommonMethods.ClickSummaryButton2(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitButtonInStudentAssessmentSummary(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus[0]);
                    AssessmentCommonMethods.ClickOnEquationEditorAssessment(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickActiveTileFromScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyEquationEditorInAssessments(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52864", true);
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
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

    }
}



                
                
                    
                    
                   
                 

              

    



    




        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        





































































































































































































































































































































































































































































































































        































































































        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
