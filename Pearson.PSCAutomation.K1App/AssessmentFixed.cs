using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class AssessmentFixed
    {
        public AutomationAgent FixedAssessmentAutomationAgent;

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10317"), TestCategory("US10283")]
        [Priority(2)]
        [WorkItem(54004), WorkItem(54005), WorkItem(54006), WorkItem(53924), WorkItem(53926)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyBackButtonFunctionalityAndNavigationOnTapping()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54004,TC54005,TC54006,TC53924,TC53926 :Verify the functionality of back button and navigation on tappping it"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent,login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent,taskInfo.Grade,taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent,testData[0]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerTitlePresent(FixedAssessmentAutomationAgent),"Assessment Manager Title Not Found");
                    NavigationCommonMethods.ClickOnSystemTray(FixedAssessmentAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(FixedAssessmentAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUnitSelectionBackground(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54004", true);
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent, testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitlePresent(FixedAssessmentAutomationAgent), "Assessment Progress Overview Title Not Found");
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerTitlePresent(FixedAssessmentAutomationAgent), "Assessment Manager Title Not Found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54005", true);
                    //Assert.IsTrue(AssessmentCommonMethods.VerifyUnitBackgroundColourInManagerScreen(FixedAssessmentAutomationAgent), "Unit name Is Not Displayed With Blue Background");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNavigationBarColourInManagerScreen(FixedAssessmentAutomationAgent), "Navigation Bar Is Not Displayed With Black Background");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIconPresentInManagerScreen(FixedAssessmentAutomationAgent), "Refresh Icon Is Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54006", true);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyScoresButtonEnabledinAssessmnetOverview(FixedAssessmentAutomationAgent),"Score Button Is Enabled");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53924", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyReportButtonEnabledinAssessmnetOverview(FixedAssessmentAutomationAgent), "Report Button Is Enabled");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53926", true);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10216"), TestCategory("US10220")]
        [Priority(1)]
        [WorkItem(53899), WorkItem(53917)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyAssessmentStatusAndSubStatusInManagerScreen()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC53899,TC53917:Verify Assessment Status And SubStatus In Manager Screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent,login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent,testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentPendingStatusInManagerPresent(FixedAssessmentAutomationAgent,testData[1]), "Pending Status Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentStartedSubStatusInManagerPresent(FixedAssessmentAutomationAgent,testData[1]), "Started Sub Status Not Found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53899", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentCountInManagerScreen(FixedAssessmentAutomationAgent,testData[6]), "Student Count Mismatch");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53917", true); 
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10214"), TestCategory("US10218"), TestCategory("US10343")]
        [Priority(2)]
        [WorkItem(53912),WorkItem(53980), WorkItem(53913), WorkItem(53914), WorkItem(53915), WorkItem(53916), WorkItem(54007), WorkItem(54008), WorkItem(54009), WorkItem(540011), WorkItem(54015)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyFixedAssessmentInAssessmentManager()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC53912,TC53980,TC53913,TC53914,TC53915,TC53916,TC54007,TC54008,TC54009,TC54011,TC54015:Verify Fixed Assessment In Assessment Manager"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent,testData[0]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIconPresentInManagerScreen(FixedAssessmentAutomationAgent),"Refresh Icon Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDateTimeStampInManagerScreen(FixedAssessmentAutomationAgent), "Date And Time Stamp Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLastUpdatedLabelPresentInManagerScreen(FixedAssessmentAutomationAgent),"Last Updated Label Not present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53915", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53980", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnitLabelPresentInManagerScreen(FixedAssessmentAutomationAgent, testData[11]), "Unit Label Not Present Before selecting");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54009", true);
                    AssessmentCommonMethods.ClickUnitTitleDropdown(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnitTitleDropDownValue(FixedAssessmentAutomationAgent)>0,"Unit Drop Down is empty");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54008", true);
                    AssessmentCommonMethods.ClickUnitTitleDropdown(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent,testData[2]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnitLabelPresentInManagerScreen(FixedAssessmentAutomationAgent, testData[12]), "Unit Label Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53912", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54011", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyOverallAssessmentStatusInManagerScreen(FixedAssessmentAutomationAgent, testData[2].Split(':')[1].Replace("\t\n","").Trim()), "Overall Status Mismatch");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54007", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFixedAndOngoingLabelPresentInManagerScreen(FixedAssessmentAutomationAgent),"Fixed And Ongoing Assessment Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53913", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFixedAssessmentPresentInManagerScreen(FixedAssessmentAutomationAgent, testData[1]), "Fixed Assessment Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53916", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreenVerticallyScrollable(FixedAssessmentAutomationAgent), "Assessment Manager Not Vertically Scrollable");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53914", true);                    
                    //Assert.IsTrue(AssessmentCommonMethods.VerifyBackButtonPresentInAssessmentManager(FixedAssessmentAutomationAgent),"Back Button Not Prersent");
                    //FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54015", true);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10235"), TestCategory("US10220")]
        [Priority(2)]
        [WorkItem(53901), WorkItem(53902), WorkItem(53906), WorkItem(53907), WorkItem(53905), WorkItem(53903), WorkItem(53918)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyLockUnlockOverlayScreenFunctionality()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC53901,TC53902,TC53906,TC53905,TC53903,TC53918:Verify the Lock Unlock overlay screen functionality"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent, testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitlePresent(FixedAssessmentAutomationAgent), "Assessment Progress Overview Title Not Found");
                    AssessmentCommonMethods.ClickUnlockAssessmentsInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockModalScreenFound(FixedAssessmentAutomationAgent),"Lock Unlock Overlay Screen Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.VerifySectionTitleInUnlockOverlayScreen(FixedAssessmentAutomationAgent, testData[1]), "Section Title Mismatch");
                    Assert.AreEqual(testData[2].Split(':')[1].Replace("\t\n","").Trim(), AssessmentCommonMethods.VerifyStatusInUnlockOverlayScreen(FixedAssessmentAutomationAgent), "Status Mismatch");
                    Assert.AreEqual(testData[7],AssessmentCommonMethods.VerifyLockedForStudentCountInUnlockOverlayScreen(FixedAssessmentAutomationAgent),"Locked For Count Mismatch");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53901", true);
                    AssessmentCommonMethods.VerifyUnLockAllButtonPresent(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickUnLockAllButton(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLockIconPresentForStudentInOverlay(FixedAssessmentAutomationAgent),"Lock Icon NOt Preent");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53902", true);
                    AssessmentCommonMethods.VerifyLockAllButtonPresent(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickLockAllButton(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53906", true);                    
                    AssessmentCommonMethods.ClickOnStudentName(FixedAssessmentAutomationAgent,testData[10]);                  
                    Assert.IsFalse(AssessmentCommonMethods.VerifyStartedStatusPresentForStudentInOverlay(FixedAssessmentAutomationAgent),"Started Status Is Present For Not Started Student");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53905", true);
                    AssessmentCommonMethods.ClickDoneInLockUnlockOverlay(FixedAssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyUnlockModalScreenFound(FixedAssessmentAutomationAgent), "Lock Unlock Overlay Screen Is Found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53903", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerTitlePresent(FixedAssessmentAutomationAgent), "Assessment Manager Title Not Found");                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnLockIconPresentInAssessmentManagerScreen(FixedAssessmentAutomationAgent,testData[1]),"Unlock icon Not Present For the Assessment");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53918", true);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickUnlockAssessmentsInAssessmentOverview(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickOnStudentName(FixedAssessmentAutomationAgent, testData[10]);
                    AssessmentCommonMethods.ClickDoneInLockUnlockOverlay(FixedAssessmentAutomationAgent);                    
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10497")]
        [Priority(1)]
        [WorkItem(54141), WorkItem(54142), WorkItem(54143), WorkItem(54144), WorkItem(54145), WorkItem(54146)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyLoadingIndicatorFunctionlaityInAssessmentScreen()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54141,TC54142,TC54143,TC54144,TC54145,TC54146:Verify functionality of Loading indicator on assessments screens"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent, testData[0]);                    
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54141", true);
                    AssessmentCommonMethods.ClickRefreshIconInAssessmentManager(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLoaderImagePresent(FixedAssessmentAutomationAgent), "Loader Image Not Present");
                    NavigationCommonMethods.ClickOnSystemTray(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerInSystemTray(FixedAssessmentAutomationAgent),"Menu Not Available");
                    NavigationCommonMethods.ClickOnSystemTray(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54142", true);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent,testData[2]);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54143", true);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent,testData[1]);                    
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54144", true);
                    AssessmentCommonMethods.ClickRefreshIconInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLoaderImagePresent(FixedAssessmentAutomationAgent), "Loader Image Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54145", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerTitlePresent(FixedAssessmentAutomationAgent), "Assessment Manager Title Not Found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54146", true);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10405"), TestCategory("US10440")]
        [Priority(1)]
        [WorkItem(54147), WorkItem(54167), WorkItem(54168), WorkItem(54170), WorkItem(54171), WorkItem(54210), WorkItem(54213), WorkItem(54217), WorkItem(54218), WorkItem(54219), WorkItem(54220)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyScreenRefreshFunctionlaityInAssessmentScreen()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54147,TC54167,TC54168,TC54170,TC54171,TC54210,TC54213,TC54217,TC54218,TC54219,TC54220:Verify functionality of Loading indicator on assessments screens"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent, testData[0]);                    
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54171", true);
                    AssessmentCommonMethods.ClickRefreshIconInAssessmentManager(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLoaderImagePresent(FixedAssessmentAutomationAgent), "Loader Image Not Present");
                    AssessmentCommonMethods.WaitForPageToload(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54147", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDateTimeStampInManagerScreen(FixedAssessmentAutomationAgent), "Date And Time Stamp Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54170", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54167", true);  
                    NavigationCommonMethods.ClickOnSystemTray(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerInSystemTray(FixedAssessmentAutomationAgent), "Menu Not Available");
                    NavigationCommonMethods.ClickOnSystemTray(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.WaitForPageToload(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54168", true);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);                    
                    AssessmentCommonMethods.ClickRefreshIconInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLoaderImagePresent(FixedAssessmentAutomationAgent), "Loader Image Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54210", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54219", true);                    
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDateTimeStampInOverviewScreen(FixedAssessmentAutomationAgent), "Date And Time Stamp Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54213", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54220", true);
                    AssessmentCommonMethods.ClickRefreshIconInAssessmentOverview(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerTitlePresent(FixedAssessmentAutomationAgent), "Assessment Manager Title Not Found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54217", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54218", true);  
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10464"), TestCategory("US10462"), TestCategory("US10470")]
        [Priority(2)]
        [WorkItem(54012), WorkItem(54716), WorkItem(54801), WorkItem(53904),WorkItem(54644), WorkItem(54658), WorkItem(54640), WorkItem(54657)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyAssessmentStatusAndStudentStatusAfterStudentStartsAnAssessment()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54012,TC54716,TC54801,TC53904,TC54644,TC54658,TC54640,TC54657:Verify Assessment Status And SubStatus In Manager Screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent,testData[0],testData[2]);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(FixedAssessmentAutomationAgent,testData[1],testData[10]);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, studentLogin);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.StudentAnswersTheAssessment(FixedAssessmentAutomationAgent,"Start");
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent, testData[0], testData[3]);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54012", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentInProgressStatusInManagerPresent(FixedAssessmentAutomationAgent,testData[1]),"In Progress Status Not Found");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentCountInManagerScreen(FixedAssessmentAutomationAgent,testData[9]));
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54716", true);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54801", true); 
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickUnlockAssessmentsInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStartedInlineStatusPresent(FixedAssessmentAutomationAgent,testData[10]),"Started Inline Status Not Found");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyStudentBackgroundColourInOverlay(FixedAssessmentAutomationAgent,testData[10]),"Student Cell Not Grayed Out");                    
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53904", true);
                    AssessmentCommonMethods.ClickOnStudentName(FixedAssessmentAutomationAgent, testData[10]);
                    
                    AssessmentCommonMethods.ClickUnLockAllButton(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyLockAllButtonPresent(FixedAssessmentAutomationAgent),"Lock All Button Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54644", true);
                    Assert.AreEqual(testData[6], AssessmentCommonMethods.VerifyLockedForStudentCountInUnlockOverlayScreen(FixedAssessmentAutomationAgent), "Locked For Count Mismatch");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54658", true);
                    AssessmentCommonMethods.ClickLockAllButton(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyUnLockAllButtonPresent(FixedAssessmentAutomationAgent),"Unlock All Button Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54640", true);
                    Assert.AreEqual(testData[8], AssessmentCommonMethods.VerifyLockedForStudentCountInUnlockOverlayScreen(FixedAssessmentAutomationAgent), "Locked For Count Mismatch");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54657", true);
                    AssessmentCommonMethods.ClickDoneInLockUnlockOverlay(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetFromOverviewScreen(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10470"), TestCategory("US10283"), TestCategory("US10292")]
        [Priority(2)]
        [WorkItem(54013), WorkItem(54802), WorkItem(55258), WorkItem(55259), WorkItem(55260), WorkItem(55261), WorkItem(55262), WorkItem(55263)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyAssessmentStatusAndStudentStatusAfterStudentSubmitAnAssessment()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54013,TC54802,TC55258,TC55259,TC55260,TC55261,TC55262,TC55263:Verify Assessment Status And SubStatus In Manager Screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent, testData[0], testData[2]);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(FixedAssessmentAutomationAgent, testData[1], testData[10]);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, studentLogin);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.StudentAnswersTheAssessment(FixedAssessmentAutomationAgent, "Submit");
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent, testData[0], testData[4]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentScoringRequiredStatusInManagerPresent(FixedAssessmentAutomationAgent,testData[1]),"Scoring Required Status Not Found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54013", true); 
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoresButtonEnabledinAssessmnetOverview(FixedAssessmentAutomationAgent));
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54802", true);
                    AssessmentCommonMethods.ClickScoreButtonInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewTitlePresent(FixedAssessmentAutomationAgent),"Scoring overview title not present");
                    AssessmentCommonMethods.ClickRefreshIconInScoringOverview(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55259", true);
                    AssessmentCommonMethods.WaitForPageToload(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyDateAndTimeStampInScoringOverviewScreen(FixedAssessmentAutomationAgent);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55258", true);                    
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55261", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewTitlePresent(FixedAssessmentAutomationAgent), "Scoring overview title not present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55262", true);
                    AssessmentCommonMethods.ClickRefreshIconInScoringOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyBackButtonEnabledinScoringOverview(FixedAssessmentAutomationAgent),"Back Button Disabled");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55263", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitlePresent(FixedAssessmentAutomationAgent));
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55260", true);                    
                    AssessmentCommonMethods.LockAndResetFromOverviewScreen(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10222"), TestCategory("US10586")]
        [Priority(1)]
        [WorkItem(54173), WorkItem(54179), WorkItem(54180), WorkItem(54181), WorkItem(54182), WorkItem(54183), WorkItem(54184), WorkItem(54185), WorkItem(54634), WorkItem(54635)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyPreviewAssessmentInColdWrite()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54173,TC54179,TC54180,TC54181,TC54182,TC54183,TC54184,TC54185,TC54634,TC54635:Verify Preview Assessment page in Cold writes "))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent, testData[0], testData[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickPreviewAssessmentInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyItemPreviewTitlePresent(FixedAssessmentAutomationAgent),"Item Preview Title Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54173", true);
                    Assert.AreEqual(testData[1], AssessmentCommonMethods.VerifyPreviewAssessmentTitleLabel(FixedAssessmentAutomationAgent), "Assessment Label Missing");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyBackButtonPresentInAssessmentManager(FixedAssessmentAutomationAgent),"Back Button Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54179", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionTabInPreviewAssessment(FixedAssessmentAutomationAgent),"Question Tab Missing");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStandardTabInPreviewAssessment(FixedAssessmentAutomationAgent), "Standard Tab Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54180", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyDefaultTabInPreviewAssessment(FixedAssessmentAutomationAgent),"Default Tab Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54181", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionViewInPreviewAssessment(FixedAssessmentAutomationAgent),"Question View Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54182", true);                    
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54185", true);
                    AssessmentCommonMethods.ClickStandardsTabInPreviewScreen(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsViewInPreviewAssessment(FixedAssessmentAutomationAgent),"Standard View Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54183", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsInPreviewAssessment(FixedAssessmentAutomationAgent), "Standrds Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54634", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyCommonCoreStandardsIDInPreviewAssessment(FixedAssessmentAutomationAgent),"Standard ID Missing");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54635", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricPanelInPreviewAssessment(FixedAssessmentAutomationAgent),"Rubric Panel Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54184", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);                    
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10231")]
        [Priority(1)]
        [WorkItem(54205), WorkItem(54206), WorkItem(54207), WorkItem(54208), WorkItem(54209), WorkItem(54211), WorkItem(54212)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyRubricInColdWritePreviewStandards()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC54205,TC54206,TC54207,TC54208,TC54209,TC54211,TC54212:Verify the preview standards availability of checklist assessment."))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(FixedAssessmentAutomationAgent, testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(FixedAssessmentAutomationAgent, testData[2]);
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickPreviewAssessmentInAssessmentOverview(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionTabInPreviewAssessment(FixedAssessmentAutomationAgent), "Question Tab Missing");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricPanelInPreviewAssessment(FixedAssessmentAutomationAgent), "Rubric Panel Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54205", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricContentInPreviewAssessment(FixedAssessmentAutomationAgent),"Rubric Content Not Displayed");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54206", true);
                    AssessmentCommonMethods.ClickStandardsTabInPreviewScreen(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricContentInPreviewAssessment(FixedAssessmentAutomationAgent), "Rubric Content Not Displayed");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54207", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyHideRubricInPreviewAssessment(FixedAssessmentAutomationAgent),"Hide Rubric Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54208", true);
                    AssessmentCommonMethods.TapOnHideRubricInPreviewAssessment(FixedAssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricContentInPreviewAssessment(FixedAssessmentAutomationAgent), "Rubric Content Not Displayed");
                    AssessmentCommonMethods.TapOnHideRubricInPreviewAssessment(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricContentInPreviewAssessment(FixedAssessmentAutomationAgent), "Rubric Content Not Displayed");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54298", true);
                    AssessmentCommonMethods.ClickOnRubricScoreButton(FixedAssessmentAutomationAgent);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyRubricScoringFlyout(FixedAssessmentAutomationAgent), "Rubric scoring flyout not found");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54211", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyRubricTableScrollableInPreview(FixedAssessmentAutomationAgent),"Rubric Table Not Scrollable");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54212", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10674")]
        [Priority(2)]
        [WorkItem(55171), WorkItem(55172), WorkItem(55173), WorkItem(55174), WorkItem(55176), WorkItem(55186), WorkItem(55187), WorkItem(55188)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyStopScoringDialogueInColdWriteAssessment()
        {
            using (FixedAssessmentAutomationAgent = new AutomationAgent("TC55171,TC55172,TC55173,TC55174,TC55176,TC55186,TC55187,TC55188:Verify Stop Scoring Dialogue In Cold Write Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent, testData[0], testData[2]);
                    AssessmentCommonMethods.TeacherUnlocksAStudent(FixedAssessmentAutomationAgent, testData[1], testData[10]);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);

                    Login studentLogin = Login.GetLogin("AssessmentStudent");
                    TaskInfo taskInfo1 = studentLogin.GetTaskInfo("ELA", "Assessment");
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, studentLogin);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.StudentAnswersTheAssessment(FixedAssessmentAutomationAgent, "Submit");
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(FixedAssessmentAutomationAgent, login);
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(FixedAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.TeacherInAssessmentManagerScreen(FixedAssessmentAutomationAgent, testData[0], testData[4]);                    
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(FixedAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickScoreButtonInAssessmentOverview(FixedAssessmentAutomationAgent);
                    //Tap on question tile
                    AssessmentCommonMethods.ClickChecklistDoneButton(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredTabSelectedByDefaultInStopScoring(FixedAssessmentAutomationAgent),"Scored tab Not Selected By Default");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55171", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoStudentsMessageInAssessmentOverview(FixedAssessmentAutomationAgent), "No Student Message Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55173", true);
                    //Verify all four tabs displyed
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55174", true);
                    //Tap on Not started
                    //Verify not started is elected with stuent list
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55172", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringTextPresent(FixedAssessmentAutomationAgent),"Stop Scoring Text Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYesAndNoButtonPresentInStopScoring(FixedAssessmentAutomationAgent),"Yes or No button not present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55176", true);
                    //Verify progress % with progress text below
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55186", true);
                    AssessmentCommonMethods.ClickNoButtonInStopScoringDialog(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyItemScoringTitlePresent(FixedAssessmentAutomationAgent),"Item Scoring Title Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55188", true);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialog(FixedAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewTitlePresent(FixedAssessmentAutomationAgent),"Scoring Overview Title Not Present");
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55187", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.LockAndResetFromOverviewScreen(FixedAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(FixedAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(FixedAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    FixedAssessmentAutomationAgent.Sleep(2000);
                    FixedAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    FixedAssessmentAutomationAgent.ApplicationClose();
                    FixedAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }

        }

    }    

}
