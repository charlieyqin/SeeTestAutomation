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
    public class ReportsTests
    {
        public AutomationAgent reportsAutomationAgent;

        [TestMethod()]
        [TestCategory("AssessmentReports")]
        [Priority(1)]
        [WorkItem(10001)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyReportsE2ESample()
        {
            using (reportsAutomationAgent = new AutomationAgent("Reports E2E Sample."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacherGrd5");
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "AssessmentReports");
                    NavigationCommonMethods.Login(reportsAutomationAgent, teacherLogin);
                    String[] taskDetails = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(reportsAutomationAgent, taskDetails[4], taskDetails[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(reportsAutomationAgent, taskDetails[21]);
                    AssessmentCommonMethods.ClickUnlockAssessments(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickUnLockAllButton(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverlayDone(reportsAutomationAgent);
                    NavigationCommonMethods.Logout(reportsAutomationAgent, true);

                    Login studentLogin1 = Login.GetLogin(teacherLogin.StudentList[0]);
                    TaskInfo studentTaskInfo1 = studentLogin1.GetTaskInfo("ELA", "AssessmentReports");
                    String[] studentTaskDetails = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(studentTaskInfo1);
                    NavigationCommonMethods.Login(reportsAutomationAgent, studentLogin1);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(reportsAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(reportsAutomationAgent, studentTaskDetails[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(reportsAutomationAgent, studentTaskDetails[21]);
                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(reportsAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(reportsAutomationAgent);
                    }

                    AssessmentCommonMethods.StudentAnswerAndSubmitAssessment(reportsAutomationAgent, studentLogin1.PersonName);
                    NavigationCommonMethods.Logout(reportsAutomationAgent, true);

                    Login studentLogin2 = Login.GetLogin(teacherLogin.StudentList[1]);
                    TaskInfo studentTaskInfo2 = studentLogin2.GetTaskInfo("ELA", "AssessmentReports");
                    String[] studentTaskDetails2 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(studentTaskInfo2);
                    NavigationCommonMethods.Login(reportsAutomationAgent, studentLogin2);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(reportsAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(reportsAutomationAgent, studentTaskDetails2[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(reportsAutomationAgent, studentTaskDetails2[21]);
                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(reportsAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(reportsAutomationAgent);
                    }

                    AssessmentCommonMethods.StudentAnswerAndSubmitAssessment(reportsAutomationAgent, studentLogin2.PersonName);
                    NavigationCommonMethods.Logout(reportsAutomationAgent, true);

                    Login studentLogin3 = Login.GetLogin(teacherLogin.StudentList[2]);
                    TaskInfo studentTaskInfo3 = studentLogin3.GetTaskInfo("ELA", "AssessmentReports");
                    String[] studentTaskDetails3 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(studentTaskInfo3);
                    NavigationCommonMethods.Login(reportsAutomationAgent, studentLogin3);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(reportsAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentStudentUnitSelection(reportsAutomationAgent, studentTaskDetails3[0]);
                    AssessmentCommonMethods.ClickFixedAssessmentAsStudent(reportsAutomationAgent, studentTaskDetails3[21]);
                    if (AssessmentCommonMethods.AssessmentTilePopUpFound(reportsAutomationAgent))
                    {
                        AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp(reportsAutomationAgent);
                    }

                    AssessmentCommonMethods.StudentAnswerAndSubmitAssessment(reportsAutomationAgent, studentLogin3.PersonName);
                    NavigationCommonMethods.Logout(reportsAutomationAgent, true);

                    NavigationCommonMethods.Login(reportsAutomationAgent, teacherLogin);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(reportsAutomationAgent, taskDetails[4], taskDetails[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(reportsAutomationAgent, taskDetails[21]);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(reportsAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(reportsAutomationAgent, studentLogin1.PersonName);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(reportsAutomationAgent, studentTaskDetails[23]);
                    AssessmentCommonMethods.BackToScoringOverviewScreen(reportsAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(reportsAutomationAgent, studentLogin2.PersonName);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(reportsAutomationAgent, studentTaskDetails2[23]);
                    AssessmentCommonMethods.BackToScoringOverviewScreen(reportsAutomationAgent);
                    
                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(reportsAutomationAgent, studentLogin3.PersonName);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(reportsAutomationAgent, studentTaskDetails3[23]);
                    AssessmentCommonMethods.BackToScoringOverviewScreen(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInScoringOverview(reportsAutomationAgent);
                    reportsAutomationAgent.Sleep(66000);

                    AssessmentCommonMethods.ClickAssessmentOverviewReportButton(reportsAutomationAgent);
                    AssessmentCommonMethods.ClickViewItemAnalysis(reportsAutomationAgent);
                    ReportsCommonMethods.VerifyItemAnalysisReport(reportsAutomationAgent, 3);
                    NavigationCommonMethods.Logout(reportsAutomationAgent);
                }
                catch (Exception ex)
                {
                    reportsAutomationAgent.Sleep(2000);
                    reportsAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    reportsAutomationAgent.ApplicationClose();
                    reportsAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }
    }
}
