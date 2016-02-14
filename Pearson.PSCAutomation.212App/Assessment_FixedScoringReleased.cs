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
    public class AssessmentFixedScoringReleased
    {
        public AutomationAgent AssessmentAutomationAgent;


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US8190"), TestCategory("US9262")]
        [Priority(2)]
        [WorkItem(45185), WorkItem(45186), WorkItem(45196), WorkItem(45188), WorkItem(45190), WorkItem(45192), WorkItem(53171)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyReleaseScoreButtonFunctionalityInScoringOverviewScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45185,TC45186,TC45196,TC45188,TC45190,TC45192,TC53171 :  Verify the text displayed near “Release Score” button (enabled) in the Scoring Overview screen"))
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

                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    String TextBesideButton = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                    Assert.AreEqual("Score  1  more to release scores", TextBesideButton, "Status Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45186", true);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45196", true);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "2");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found");
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    String TextAfterScoreing = AssessmentCommonMethods.GetScoreCountTextInScoringOverview(AssessmentAutomationAgent);
                    Assert.AreNotEqual("Score  1  more to release scores", TextAfterScoreing, "Status Message Not Found");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45185", true);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickCancelInAssessmentCompletionPopUp(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45188", true);
                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45190", true);
                    AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC45192", true);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC53171", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
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
        [WorkItem(43534), WorkItem(43535)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyScoreReleasedTimeStampInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43535 and TC43534: ‘Scores Released’ sub status should be displayed with Date-Time stamp for the assessment in its corresponding row."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.VerifyTimeStampBelowScoreReleasedAtAssessmentManager(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43534", true);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC43535", true);
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
        [WorkItem(45211)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyScoresRealeseButtonWIthTimeStamp()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45211 : Verify that “Release Scores” button replaced by Scores release text with date time stamp"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickOnFixedAssessScoreReleasedArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
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
        [WorkItem(45212)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyReleaseScoreButtonReplacedByScoresReleaseText()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC45212: Verify Teacher should see the “Release Scores” button replaced by Scores release text with date time stamp"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickOnAssessmentStartedByStudent(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoresReleasedLabel(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
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
        [WorkItem(43533)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyScoreAndScoreReleasedStatusInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43533: Verify that “Scored” and “Scores Released” sub statuses in the assessment manager page."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyScoreReleasedStatusInAssessmentManager(AssessmentAutomationAgent);
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
        [TestCategory("Assessment")]
        [Priority(1)]
        [WorkItem(43532)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDeliveredStatusInAssessmentManager()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC43532: Verify The teacher should be displayed with the unlock icon along with “Delivered” status for the assessment in its corresponding row."))
            {
                try
                {
                    Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
                    TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDeliveredStatusInAssessmentManager(AssessmentAutomationAgent);
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
        [WorkItem(46396)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAssessmentPreviewModeInScoreReleasedWithSubmitResponse()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC46396: Verify The teacher should be able to view the assessments in preview mode by tapping on the assessment tile when the assessment is in ‘Release scores’ state."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    AssessmentCommonMethods.ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
                    AssessmentCommonMethods.ClickOnScoresReleasedFixedAssessment(AssessmentAutomationAgent);
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
        [TestCategory("Assessment"), TestCategory("US9641")]
        [Priority(1)]
        [WorkItem(52087), WorkItem(52085)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyProficiencyLevelInStudentAssessmentManagerScreen()
        {
            using (AssessmentAutomationAgent = new AutomationAgent("TC52087,TC52085 : Verify the Proficiency Level of a student in assessment manager screen after score released"))
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
                    String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo1);
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus1[0]);                    
                    AssessmentCommonMethods.StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted");
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52087", true);
                    AssessmentCommonMethods.ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login teacherLogin1 = Login.GetLogin("AssessmentTeacher");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin1);
                    AssessmentCommonMethods.TeacherAtAssessmentManager(AssessmentAutomationAgent, UnitStatus[4], UnitStatus[1]);
                    AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);

                    AssessmentCommonMethods.ClickQuestionOneInScoringOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "4");
                    AssessmentCommonMethods.ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(AssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyReleaseScoreButtonEnabledInAssessmentOverview(AssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnReleaseScoreButton(AssessmentAutomationAgent);
                    NavigationCommonMethods.Logout(AssessmentAutomationAgent);

                    Login studentLogin1 = Login.GetLogin("AssessmentStudent");
                    NavigationCommonMethods.Login(AssessmentAutomationAgent, studentLogin1);                    
                    AssessmentCommonMethods.ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
                    AssessmentCommonMethods.AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus1[0]);
                    AssessmentCommonMethods.VerifyStudentProficiencyLabelStatusPresent(AssessmentAutomationAgent, UnitStatus1[4]);
                    AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52085", true);
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



                
                
                    
                    
                   
                 

              

    



    




        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        





































































































































































































































































































































































































































































































































        































































































        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
