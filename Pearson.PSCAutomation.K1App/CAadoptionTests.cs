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
    public class CAadoptionTests
    {
        public AutomationAgent CAadoptionAutomationAgent;

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24296)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherExpandedViewCloseAfterContraction()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24296: Verify that tapping on the contraction button on teacher guide full screen view will return the Teacher's guide panel to minimized size."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string currentUnit = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, currentUnit);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    Assert.IsTrue(getTeacherModeWidthBeforeExpand < getTeacherModeWidthAfterExpand);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24305)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeExpansionContractionWhenNotebookOpen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24305: Verify that tapping on the contraction button on teacher guide full screen view will return the Teacher's guide panel to minimized size when notebook browser open."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    Assert.IsTrue(getTeacherModeWidthBeforeExpand < getTeacherModeWidthAfterExpand);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24301)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeExpansionContractionWhenMediaLibOpen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24301: Verify that tapping on the contraction button on teacher guide full screen view will return the Teacher's guide panel to minimized size when notebook browser open."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    Assert.IsTrue(getTeacherModeWidthBeforeExpand < getTeacherModeWidthAfterExpand);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24302)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitOverViewOnHalfViewWhenNotebookBrowseropen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24302: Verify unit overview on half view when notebook browser open."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    String unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnNotebookBrowser(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);

                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewOpenInHalfView(CAadoptionAutomationAgent));
                    TeacherModeCommonMethods.VerifyElementsInTeacherModeOpen(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent, unitNumber));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContentOpenInShrunk(CAadoptionAutomationAgent));
                   //Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeCLoseButtonAtlowerleft(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24293)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitOverViewOnHalfViewOnUnitTodayView()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24293: Verify unit overview on half view on when usr is on unit today view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    String unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewOpenInHalfView(CAadoptionAutomationAgent));
                    TeacherModeCommonMethods.VerifyElementsInTeacherModeOpen(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent,unitNumber));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContentOpenInShrunk(CAadoptionAutomationAgent));
                    //Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeCLoseButtonAtlowerleft(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24298)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUnitOverViewOnHalfViewOnMediaLibView()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24298: Verify unit overview on half view on when user is on medial library view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string unitNum = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, unitNum);
                    NavigationCommonMethods.ClickOnMediaLibrary(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverViewOpenInHalfView(CAadoptionAutomationAgent));
                    TeacherModeCommonMethods.VerifyElementsInTeacherModeOpen(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent, unitNum));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContentOpenInShrunk(CAadoptionAutomationAgent));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeCLoseButtonAtlowerleft(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest"), TestCategory("K1SmokeTests")]
        [WorkItem(24231)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyThatTeachersCanMaintainNotesonlyatLessonlevel()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24231: Verify that the Teachers can maintain Notes only at the the Lesson level, and, as such, can only see Notes when the Teacher Guide is displaying lesson level content."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(CAadoptionAutomationAgent, randLesson);

                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(CAadoptionAutomationAgent, randLesson));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenNoNotesAvailable(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24294)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeOpenInFullViewMode()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24294: Verify that Teacher mode could be opened on full view mode."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    Assert.IsTrue(getTeacherModeWidthBeforeExpand < getTeacherModeWidthAfterExpand);
                    TeacherModeCommonMethods.VerifyExpandButtonDirectionChanges(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.VerifyElementsInTeacherModeOpenInFullView(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent, unitNumber));
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24299)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeOpenInFullViewModeWhenMediaLibOpen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24299: Verify that Teacher mode could be opened on full view mode."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent,unitNumber );
                    NavigationCommonMethods.ClickOnMediaLibrary(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    Assert.IsTrue(getTeacherModeWidthBeforeExpand < getTeacherModeWidthAfterExpand);
                    TeacherModeCommonMethods.VerifyExpandButtonDirectionChanges(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.VerifyElementsInTeacherModeOpenInFullView(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent, unitNumber));
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24303)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherModeInFullViewModeWhenNotebookBrowserOpen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24303: Verify that Teacher mode could be opened on full view mode."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    String unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnNotebookBrowser(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    int getTeacherModeWidthBeforeExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    int getTeacherModeWidthAfterExpand = TeacherModeCommonMethods.GetTeacherModeBarWidth(CAadoptionAutomationAgent);
                    Assert.IsTrue(getTeacherModeWidthBeforeExpand < getTeacherModeWidthAfterExpand);
                    TeacherModeCommonMethods.VerifyExpandButtonDirectionChanges(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.VerifyElementsInTeacherModeOpenInFullView(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent, unitNumber));
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24233)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMessageToCreateNotes()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24233: Verify that when the Teacher Guide is opened and a Lesson is not being viewed in the student facing window, the area below the app window displays a message about where user can go to enter or edit Notes."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMessageWhenLessonNotViewed(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24297)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBehaviourofClosebuttonOnlowerLeft()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24297: Verify behavior while tapping on Close button displaying on the lower left of teacher mode half view"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTodayShelfOpen(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyAppFullscreenView(CAadoptionAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTodayShelfOpen(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24400)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLessonGuideAndLessonOverview()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24400: Verify functionality of lesson guide and lesson overview."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);

                    Assert.IsFalse(TeacherModeCommonMethods.VerifyLessonOverView(CAadoptionAutomationAgent,3));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyLessonGuide(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(CAadoptionAutomationAgent, randLesson);

                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(CAadoptionAutomationAgent, randLesson));
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonGuide(CAadoptionAutomationAgent));
                    int selectAnyLesson = NavigationCommonMethods.randomInteger(10);
                    UnitSelectionCommonMethods.NavigateToLesson(CAadoptionAutomationAgent, selectAnyLesson);
                    Assert.AreEqual<bool>(true, TeacherModeCommonMethods.VerifyLessonNumberInTeacherMode(CAadoptionAutomationAgent, selectAnyLesson));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }







        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(22040)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyToDragItemToBackPack()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC22040: Verify that when the user tries to add same item multiple time or If item is already in backpack, a message dialog is displayed."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(CAadoptionAutomationAgent);
                    MediaLibraryCommonMethods.DragItemToBackPack(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(29989)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRemoveButtonATImage()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC29989: Verify that tapping red X visible in top left corner removes snapshot from the notebook"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(CAadoptionAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(CAadoptionAutomationAgent, 1600, 1000);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(CAadoptionAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(CAadoptionAutomationAgent);
                    NotebookCommonMethods.VerifyRemoveButtonAtTopLeftCornerOfImage(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24402)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherGuideFlyOutPanel()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24402: Verify Teacher Guide fly out menu is available on different screen."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu not found");
                    NavigationCommonMethods.TapOnScreen(CAadoptionAutomationAgent, 100, 100);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu not found");
                    NavigationCommonMethods.TapOnScreen(CAadoptionAutomationAgent, 100, 100);
                    NavigationCommonMethods.ClickOnMediaLibrary(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu not found");
                    NavigationCommonMethods.TapOnScreen(CAadoptionAutomationAgent, 100, 100);
                    NavigationCommonMethods.ClickOnNotebookBrowser(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu not found");
                    NavigationCommonMethods.TapOnScreen(CAadoptionAutomationAgent, 100, 100);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24403)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherGuidePanelDisappears()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24403: Verify the teacher guide panel is dismissed and flyout menu disappears."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyCollapseButtonOnRight(CAadoptionAutomationAgent), "Collapse button not on right");
                    TeacherModeCommonMethods.ClickToCloseTeacherGuidePanel(CAadoptionAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(CAadoptionAutomationAgent), "Teacher mode open");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu  found");
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickToCloseTeacherGuidePanel(CAadoptionAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeOpen(CAadoptionAutomationAgent), "Teacher mode open");
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu found");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24304)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIOfUnitOverviewOpenInFullScreen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24304: Verify the UI of content of Unit Overview content when the teacher mode is opened on full screen view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContent(CAadoptionAutomationAgent), "Content not available");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContentScrollable(CAadoptionAutomationAgent), "Not scrollable");
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24295)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIOfUnitOverviewOpenInFullScreenWhenTodayButtonOpen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24295: Verify the UI of content of Unit Overview content when the teacher mode is opened on full screen view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContent(CAadoptionAutomationAgent), "Content not available");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContentScrollable(CAadoptionAutomationAgent), "Not scrollable");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24300)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIOfUnitOverviewOpenInFullScreenWhenMedialibraryOpen()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24300: Verify the UI of content of Unit Overview content when the teacher mode is opened on full screen view."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContent(CAadoptionAutomationAgent), "Content not available");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverviewContentScrollable(CAadoptionAutomationAgent), "Not scrollable");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24437)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMyLessonNotesHides()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24437: Verify My lesson notes button get hide on the on the given view."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyMyLessonNotesHidden(CAadoptionAutomationAgent), "My Lesson Notes not hidden");
                    NavigationCommonMethods.ClickToExpandTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnTeacherModeExpandButtonToExpandApp(CAadoptionAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyMyLessonNotesButton(CAadoptionAutomationAgent), "My Lesson Notes not hidden");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(27061)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLessonContentChanges()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC27061: Verify  that new player content does vary by unit or lesson when the user navigates between them"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    string lessoncontentOfUnit4 = TeacherModeCommonMethods.GetTheLessonContent(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, "9");
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    string lessoncontentOfUnit9 = TeacherModeCommonMethods.GetTheLessonContent(CAadoptionAutomationAgent);
                    Assert.IsFalse(lessoncontentOfUnit4.Equals(lessoncontentOfUnit9));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24401)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherGuideContentsOPenFromFlyoutMenu()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24401: Verify the unit overview,lesson overview and lesson guide open from the flyout menu "))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    String unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    int randLesson = NavigationCommonMethods.randomInteger(3);
                    UnitSelectionCommonMethods.NavigateToLesson(CAadoptionAutomationAgent, randLesson);
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(CAadoptionAutomationAgent), "Teacher mode close");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyUnitOverView(CAadoptionAutomationAgent, unitNumber), "Unit Overview not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeWhenTeacherGuideOpen(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonOverview(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(CAadoptionAutomationAgent), "Teacher mode close");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonOverView(CAadoptionAutomationAgent, randLesson), "Lesson Overview not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeWhenTeacherGuideOpen(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnLessonGuide(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeOpen(CAadoptionAutomationAgent), "Teacher mode close");
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyLessonGuideOpen(CAadoptionAutomationAgent), "Lesson guide not open");
                    TeacherModeCommonMethods.ClickOnTeacherModeWhenTeacherGuideOpen(CAadoptionAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(CAadoptionAutomationAgent, 100, 100);
                    CAadoptionAutomationAgent.Sleep(5000);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideFlyOutPanel(CAadoptionAutomationAgent), "Fly out menu found");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(26258)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCategoriesInTodayShelf()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC26258: Verify that new category types (Introduced for California Adoption) should not be displayed on Today's Shelf for Teacher and Student."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyGraphicOrganizerInTodayShelf(CAadoptionAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyGlossaryInTodayShelf(CAadoptionAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyTableOfContentsInTodayShelf(CAadoptionAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyStandardChartsInTodayShelf(CAadoptionAutomationAgent));
                    Assert.IsFalse(TeacherModeCommonMethods.VerifyReviewerVideoInTodayShelf(CAadoptionAutomationAgent));
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);

                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24229)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMyClassRosterUI()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24229: Verify that the My class roster Background colors, fonts and sizes are implemented as per the cut art"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.VerifyMyClassRosterUI(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }
                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24771)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutocorrectFunctionalityWhileCreatingLessonNotes()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24771: Verify Autocorrect enabled if enabled on device, disabled if disabled on device while creating a lesson notes."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    bool TurnAutoCorrectionON = true;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(CAadoptionAutomationAgent, TurnAutoCorrectionON);
                    CAadoptionAutomationAgent.LaunchApp();
                    TeacherModeCommonMethods.ClickToAddNotes(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(CAadoptionAutomationAgent, "Tets");
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(CAadoptionAutomationAgent), "Auto-Correct is not enabled");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(CAadoptionAutomationAgent);
                    TurnAutoCorrectionON = false;
                    NavigationCommonMethods.EnableDeviceAutoCorrectionFeature(CAadoptionAutomationAgent, TurnAutoCorrectionON);
                    CAadoptionAutomationAgent.LaunchApp();
                    TeacherModeCommonMethods.ClickToAddNotes(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.SendTextToAddNotes(CAadoptionAutomationAgent, "Tets");
                    Assert.IsTrue(LoginCommonMethods.VerifyAutoCorrectEnable(CAadoptionAutomationAgent), "Auto-Correct is enabled");
                    TeacherModeCommonMethods.ClickOnCancelButtonInNotesOverlay(CAadoptionAutomationAgent);
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24275)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySunnyProgressWhileExtractingBundleContent()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24275: Verify a sunny progress indicator will be displayed while extracting and importing files on launching the app"))
            {
                try
                {
                    LoginCommonMethods.VerifyExtractContentMessage(CAadoptionAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInCentre(CAadoptionAutomationAgent);
                    LoginCommonMethods.WaitForContentToBeExtracted(CAadoptionAutomationAgent);
                    Assert.IsTrue(LoginCommonMethods.VerifySunnySpinnerDisappeared(CAadoptionAutomationAgent), "Sun spinner still displayed");
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(26223)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHandwritingActivityDoesNotDisplayInTodayShelf()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC26223: Verify handwriting activity does not display under Today Shelf."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    Assert.IsFalse(LoginCommonMethods.VerifyHandwritingActivityNotDisplayedInTodayShelf(CAadoptionAutomationAgent), "Handriting activity is displayed in today shelf");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(24361)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySavingScrollableNotesForEachLessons()
        {
            using (CAadoptionAutomationAgent = new AutomationAgent("TC24361: Verify user can create/save notes for each leasson and notes is scrollable when exceeds the viewable area."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(CAadoptionAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(CAadoptionAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(CAadoptionAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(CAadoptionAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(CAadoptionAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(CAadoptionAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(CAadoptionAutomationAgent);
                    int lessonNumber = NavigationCommonMethods.randomInteger(20);
                    UnitSelectionCommonMethods.NavigateToLesson(CAadoptionAutomationAgent, lessonNumber);
                    TeacherModeCommonMethods.ClickToAddNotes(CAadoptionAutomationAgent);
                    string[] text = new string[12] { "Test1", "Test2", "Test3", "Test4", "Test5", "Test6", "Test7", "Test8", "Test9", "Test10", "Test11", "Test12" };
                    for (int i = 0; i <= text.Length; i++)
                    {
                        TeacherModeCommonMethods.SendTextToAddNotes(CAadoptionAutomationAgent, text[i]);
                        TeacherModeCommonMethods.SendTextToAddNotes(CAadoptionAutomationAgent, "\n");
                    }
                    TeacherModeCommonMethods.ClickOnSaveButton(CAadoptionAutomationAgent);
                    for (int i = 0; i <= text.Length - 1; i++)
                    {
                        TeacherModeCommonMethods.VerifySavedNotes(CAadoptionAutomationAgent, text[i]);
                    }
                    TeacherModeCommonMethods.VerifyEditNoteButton(CAadoptionAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifySavedNotesIsScrollable(CAadoptionAutomationAgent, text[11]), "Saved Notes is not scrollable");
                    LoginCommonMethods.Logout(CAadoptionAutomationAgent);
                }

                catch (Exception ex)
                {
                    CAadoptionAutomationAgent.Sleep(2000);
                    CAadoptionAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    CAadoptionAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
    }
}




