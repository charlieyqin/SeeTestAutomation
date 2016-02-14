using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class LessonBrowserTests
    {
        public AutomationAgent LessonBrowserAutomationAgent;

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(17672)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ViewIntroVideoInLessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC17672: View intro video in Lesson browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnPauseButtonInVideo(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19362)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StartContinueButtonIsInAvailableStateWhenLessonActive()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19362: [2.2.1] the 'start/continue' button is in the available state when lesson is active"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<string>("true", LessonBrowserCommonMethods.VerifyELAStartButtonActive(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyELATaskOpen(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20030)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentVisibleForSectionedTeachers()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20030: Teacher Content - is visible for SECTIONED teachers"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeOpen(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(25148)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentVisibleForNonSectionedTeachers()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC25148: Teacher Content - is visible for NON SECTIONED teachers"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeOpen(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20073)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherModeContentDisplaysForLessonsTasks()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20073: Teacher Mode CONTENT displays for Lessons' tasks"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(LessonBrowserAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAccordionTeacherModeOpen(LessonBrowserAutomationAgent));
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherGuideExpands(LessonBrowserAutomationAgent));
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyUnitOverviewExpands(LessonBrowserAutomationAgent),"Unit overview not expanded");
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(LessonBrowserAutomationAgent),"Teacher guide not collapsed");
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(LessonBrowserAutomationAgent),"About this lesson does not expands");
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(LessonBrowserAutomationAgent),"Unit overview does not collapse");
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherGuideExpands(LessonBrowserAutomationAgent),"Teacher guide does not expands");
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(LessonBrowserAutomationAgent), "About this lesson does not collapse");
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20029)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsNotVisibleForSectionedStudents()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20029: Teacher Content is not visible for Sectioned Students"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(25491)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsNotVisibleForNonSectionedStudents()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC25491: Teacher Content is not visible for Non Sectioned Students"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19370)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DownloadCompletedLessonPreviewCardBrightActiveStartBlueAndWorking()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19370: Download completed - lesson preview card bright, active, START blue and working"))
            {
                try
                {
                    Login login = Login.GetLogin("TeacherCyeRobledo");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<string>("true", LessonBrowserCommonMethods.VerifyELAStartButtonActive(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathLessonPreview(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyMathTaskOpen(LessonBrowserAutomationAgent, taskInfo.Title));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20074)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeContentDisplaysForLessonPreview()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20074: Teacher Mode CONTENT displays for Lesson Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAccordionTeacherModeOpen(LessonBrowserAutomationAgent), "Teacher mode not open");
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(LessonBrowserAutomationAgent), "About this lesson not expanded");
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(LessonBrowserAutomationAgent), "Teacher Guide not collapse");
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyUnitOverviewExpands(LessonBrowserAutomationAgent), "Unit overview not expanded");
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(LessonBrowserAutomationAgent), "About this lesson does not collapse");
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(LessonBrowserAutomationAgent),"Unit overview does not collapse");
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAboutThisLessonExpands(LessonBrowserAutomationAgent), "About this lesson not expanded");
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20075)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeContentDisplaysForLessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20075: Teacher Mode CONTENT displays for Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyUnitOverviewExpands(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20077)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonCarouselShouldNotCoverTheNavigationBar()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20077: Lesson Carousel should NOT cover the navigation bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeOpen(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(17674)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenVideoIsCompletedDismissedInLessonBrowserUserIsReturnedToLessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC17674: When video is completed/dismissed in Lesson browser, user is returned to the lesson browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnPauseButtonInVideo(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserEpisodeCell(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.VerifyLessonBrowserPanelPresent(LessonBrowserAutomationAgent, taskInfo.Lesson.ToString());
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyVideoComplete(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19953), WorkItem(45570)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonBrowserChromeItemsForSectionedTeacher()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19953: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide For Sectioned Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForSectionedTeachers(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(26215)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonBrowserChromeItemsForNonSectionedStudent()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC26215: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide For Non Sectioned Student"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForNonSectionedStudents(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(26216)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonBrowserChromeItemsForSectionedStudent()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC26216: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide For Sectioned Student"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForSectionedStudents(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(26217)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonBrowserChromeItemsForNonSectionedTeacher()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC26217: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide For Non Sectioned Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForNonSectionedTeachers(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20477)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ImageGetsOpenedFullscreen()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20477:when you tap the image, it gets opened fullscreen properly"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Image");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(LessonBrowserAutomationAgent, taskInfo);
                    LessonBrowserCommonMethods.VerifyImageinLesson(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnImageInLesson(LessonBrowserAutomationAgent);
                    Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageFullScreen(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickDoneButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyImageinLesson(LessonBrowserAutomationAgent);
                    TaskInfo taskInfo1 = login.GetTaskInfo("Math", "SecondImage");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(LessonBrowserAutomationAgent, taskInfo1);
                    LessonBrowserCommonMethods.VerifyImageinLesson(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnImageInLessonSecond(LessonBrowserAutomationAgent);
                    Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageFullScreen(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickDoneButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyImageinLesson(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15892)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonDownloadCompletedThumbnailBrightPreviewOpensAfterTap()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15892: lesson download completed - thumbnail bright, preview opens after tap"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyWifiIcon(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.VerifyLessonOpened(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickOnStartLessonButton(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.VerifyLessonOpenedToRead(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15888)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonsAreOrderedByLessonNumberAscending()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15888: Lessons are ordered by lesson number, ascending"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.VerifyLessonsAreInOrder(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15887)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void ConfirmAppChromeTitleCorrectLessonBrowserUnitxUnitName()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15887: Confirm App Chrome title correct (Lesson Browser) = Unit [x]: [UnitName]"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserAppChromeTitle(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15886)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void BackButtonWhenInLessonBrowserIsLabelledGradeXSubjectSubjectInCaps()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15886: Back button when in Lesson Browser is labelled Grade X SUBJECT (SUBJECT in CAPS)"))
            {
                try
                {
                    string subject = "ELA";
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo(subject, "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    LessonBrowserAutomationAgent.Sleep(2000);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    string text = LessonBrowserCommonMethods.GetLessonBrowserBackButtonText(LessonBrowserAutomationAgent);
                    Assert.AreEqual(text.Trim(), "Grade "+taskInfo.Grade+" " + subject);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15882)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyPaginationIndicatorDisplayedOnScreenIfThereAreMoreThanOneEpisodes()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15882: View lessons on the lesson browser screen"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    string episodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 1);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    string episodeSubTitle = LessonBrowserCommonMethods.GetEpisodeSubTitle(LessonBrowserAutomationAgent);
                    Assert.AreEqual(episodeTitle.ToUpper(), episodeSubTitle.TrimStart());
                    LessonBrowserCommonMethods.ClickOnLessonPreviewCloseButton(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    int width = LessonBrowserCommonMethods.GetWidthOfPageIndicator(LessonBrowserAutomationAgent);
                    if (width > 14)
                    {
                        LessonBrowserCommonMethods.NavigateEpisode(LessonBrowserAutomationAgent);
                    }
                    else
                    {
                        NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    }
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15899)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void DownloadedLessonShouldNotHaveSpinnerProgressBar()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15899: Downloaded lesson should not have a spinner/progress bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnBackButton(LessonBrowserAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserEpisodeCell(LessonBrowserAutomationAgent));
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, taskInfo.Lesson));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15900)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void OnlyLessonsThatAreDownloadedShouldOpenLessonPreview()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15900: Only lessons that are downloaded should open Lesson Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NotDownloadedLesson");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserAutomationAgent.Sleep(3000);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickLessonNotDownloaded(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<string>("false", LessonBrowserCommonMethods.VerifyELAStartButtonActive(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15881)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SwipeThroughLessonEpisodesOneEpisodeAvailable()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15881: Swipe through lesson episodes (one episode available)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    string episodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.NavigateEpisode(LessonBrowserAutomationAgent);
                    string newEpisodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 1);
                    Assert.AreEqual(episodeTitle, newEpisodeTitle, "More than 1 episode available");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15880)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SwipeLeftRightThroughELALessonEpisodes()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15880: Swipe left/right through ELA lesson episodes"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    string episodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.NavigateEpisode(LessonBrowserAutomationAgent);
                    string newEpisodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 2);
                    Assert.AreNotEqual(episodeTitle, newEpisodeTitle);
                    LessonBrowserCommonMethods.NavigatePreviousEpisode(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyPaginationIndicatorInLessonPreview(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(LessonBrowserAutomationAgent));
                    for (int i = 0; i < 3; i++)
                    {
                        LessonBrowserCommonMethods.NavigateLesson(LessonBrowserAutomationAgent);
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyPaginationIndicatorInLessonPreview(LessonBrowserAutomationAgent));
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(LessonBrowserAutomationAgent));
                    }
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15889)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonNotYetStartedDownloadingDarkerThumbnailPreviewDoesntOpenNotDownloadedIcon()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15889: lesson not yet started downloading - darker thumbnail, preview doesn't open, AI implemented: not-downloaded icon"))
            {
                try
                {
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, true);
                    LessonBrowserAutomationAgent.LaunchApp();

                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(LessonBrowserAutomationAgent));
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(16114)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UnitPreviewStartMovesYouToTheLessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC16114: Unit Preview - 'START' moves you to the Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(18573)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherContentIsVisibleForBothSectionedAndNonSectionedTeachers()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC18573: Teacher Content - is visible for both: SECTIONED and NON-SECTIONED teachers"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent));
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickTeacherContentIcon(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeOpen(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickTeacherContentIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19059)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherContentIsNotVisibleForStudents()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19059: Teacher Content is not visible for Students"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent));
                    Assert.AreEqual<bool>(false, LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(16193)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeIconDisplaysForTheFollowingLocationsUnitPreviewLessonBrowserLessonPreviewLesson()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC16193: Teacher Mode: Icon displays for the following locations: Unit Preview, Lesson Browser, Lesson Preview, Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(LessonBrowserAutomationAgent, taskInfo.Unit));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickStartUnitButtonInUnitPreview(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnLessonInLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnStartLessonButton(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19367)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonPreviewCardIsGrayWhenItHasNotBeenFullyDownloaded()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19367: [2.1.1] lesson preview card is gray when it has not been fully downloaded"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");

                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickStartUnitButtonInUnitPreview(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnLessonInLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Right);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(31230)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonDownloadInProgressProgressBarOverThumbnailPreviewDoesntOpen()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC31230: 3. lesson download in-progress - progress bar over thumbnail, preview doesn't open"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickStartUnitButtonInUnitPreview(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.TapOnLessonForDownloading(LessonBrowserAutomationAgent, 9);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, 8));
                    LessonBrowserCommonMethods.TapOnLessonForDownloading(LessonBrowserAutomationAgent, 9);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(31602)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonPreviewDownloadNotStartedSTARTGreyedOutInactive()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC31602: [2.1.1/2.1.2] [ch] 1. Lesson Preview - download not started - START greyed out, inactive."))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickStartUnitButtonInUnitPreview(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserAutomationAgent.Sleep(3000);
                    LessonBrowserCommonMethods.ClickOnLessonInLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Right);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(LessonBrowserAutomationAgent));
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonPreviewCardContentIsGrayed(LessonBrowserAutomationAgent, 3));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(31603)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonPreviewDownloadInProgressProgressBarVisibleForLessonNotYetDownloaded()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC31603: [2.1.1/2.1.2] [ch] 1. Lesson Preview - download in-progress - Progress bar visible for lesson not yet downloaded"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickStartUnitButtonInUnitPreview(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickOnLessonInLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Right);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(LessonBrowserAutomationAgent));
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyLessonPreviewCardContentIsGrayed(LessonBrowserAutomationAgent, 5));
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Left);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }





        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20078)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonCarouselScalesAlongWithTheMainAppScreenWhenOpeningTeacherMode()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC20078: 13. Lesson Carousel scales along with the main app screen when opening teacher mode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnUnitOverviewInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeScaledProperly(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyBottomBlackBar(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(16194)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TeacherMode3SectionsAreUnitOverviewAboutThisLessonTeacherGuide()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC16194: Teacher Mode 3 sections are: Unit Overview / About This Lesson / Teacher Guide"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(LessonBrowserAutomationAgent, login.GetTaskInfo("Math", "Notebook"));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAccordionTeacherModeOpen(LessonBrowserAutomationAgent),"teacher mode accordion not found");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideExpands(LessonBrowserAutomationAgent),"teacher guide not expanded");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewCollapse(LessonBrowserAutomationAgent),"unit overview not collapsed");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(LessonBrowserAutomationAgent),"about this lesson not collapsed");
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(16195)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherModeContentDisplaysForUnitPreview()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC16195: Teacher Mode: Content displays for Unit Preview"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitOverviewExpands(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnAboutThisLessonInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyAboutThisLessonCollapse(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherGuideInTeacherMode(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherGuideCollapse(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }





        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(14961)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ViewIntroVideoFunctionsInLessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC14961: View intro video in Lesson browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnPauseButtonInVideo(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19372)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonCarouselOpensItShouldDefaultToThePositionOfSelectedLesson()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19372: [4]. the lesson carousel opens, it should default to the position of the selected lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19373)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonCarouselShouldNotCoverNavigationBar()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19373: [5]. Lesson Carousel should NOT cover the navigation bar"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(LessonBrowserAutomationAgent), "Teacher Mode Icon not present");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyBackButtonPresent(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyResourceLibraryIconPresent(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.ClickTeacherContentIcon(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeOpen(LessonBrowserAutomationAgent), "Teacher Mode is not open");
                    LessonBrowserCommonMethods.ClickTeacherContentIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ClickOnToolsIcon(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.VerifyResourceLibraryFlyOutMenu(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ClickOnToolsIcon(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickUnitBackButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.VerifyELAPage(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(17673)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SmoothTransitionFromIntroVideoToLessonBrowserPage()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC17673: Smooth transition from the Intro Video to the Lesson Browser page when intro video ends"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15877)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SwipeThroughELALessonEpisodesWhenOnlyOneEpisodeExists()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15877: Swipe through ELA lesson episodes when only one episode exists"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "SingleEpisodeUnit");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    String episodeBeforeSwipe = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.SwipeEpisode(LessonBrowserAutomationAgent, Direction.Right);
                    String episodeAfterSwipe = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 1);
                    Assert.AreEqual<string>(episodeAfterSwipe, episodeAfterSwipe);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15875)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void NavigationReturningToViewedEpisodeWhileTappingReturnNavigationButton()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15875: NAVIGATION: Returning to the viewed episode while user exiting lesson by tapping return navigation button"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.SwipeEpisode(LessonBrowserAutomationAgent, Direction.Right);
                    String episodeAfterSwipe = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 2);
                    LessonBrowserCommonMethods.ClickOnLessonInLessonBrowser(LessonBrowserAutomationAgent, 5);
                    LessonBrowserCommonMethods.ClickELALessonContinueButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnBackButton(LessonBrowserAutomationAgent);
                    String episodeAfterBack = LessonBrowserCommonMethods.GetEpisodeTitle(LessonBrowserAutomationAgent, 2);
                    Assert.AreEqual<string>(episodeAfterSwipe, episodeAfterBack);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests"), TestCategory("212SmokeTests")]
        [WorkItem(15876)]
        [Priority(2)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void SwipeLeftToSeeNextEpisodeOnLessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15876: Swipe left to see next episode on the Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.VerifyLessonBrowserPage(LessonBrowserAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySingleEpisodesPresence(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.SwipeEpisode(LessonBrowserAutomationAgent, Direction.Right);
                    LessonBrowserCommonMethods.VerifyLessonBrowserEpisodeCell(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.SwipeEpisode(LessonBrowserAutomationAgent, Direction.Right);
                    LessonBrowserCommonMethods.VerifyLessonBrowserEpisodeCell(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15878)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LessonBrowserCanScrollVerticallyIfMoreThanThumnailsITFits()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15878: lesson browser can scroll vertically (if more thumbnails than it fits)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ScrollLessonsInLessonBrowser(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15883)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void UserShouldNotAbleToScrollLessonsInEpisode()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15883: User should not be able to scroll when there are less than 6 lessons to an episode"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPaginationIndicator(LessonBrowserAutomationAgent));
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotScrollable(LessonBrowserAutomationAgent), "Lessons are scrollable");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(45485)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ViewELALessonBrowser()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC45485: View ELA Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ScrollLessonsInLessonBrowser(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyLessonsAreInOrder(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [Priority(1)]
        [WorkItem(18984)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ClassRosterIsVisibleTeacherWithOneSection()
        {

            using (LessonBrowserAutomationAgent = new AutomationAgent("TC18984: Class Roster - is visible for teacher with one section"))
            {
                try
                {
                    Login login = Login.GetLogin("TeacherAeddings");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, taskInfo.Unit);
                    TeacherModeCommonMethods.ClickOnTeacherModeIcon(LessonBrowserAutomationAgent);
                    TeacherModeCommonMethods.ClickUnitOverviewFromTeacherGuideOverlay(LessonBrowserAutomationAgent);
                    TeacherModeCommonMethods.ClickMyClassButton(LessonBrowserAutomationAgent);
                    Assert.IsTrue(TeacherModeCommonMethods.VerifyClassRosterOpened(LessonBrowserAutomationAgent), "Class Roster is not visible");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(45567)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonBrowserChromeItemsTrayBackUnitTitleToolsGamesNotificationBadgeTeacherGuideNonSectionedStudent()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC45567: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide for Non-Sectioned Student"))
            {
                try
                {
                    Login login = Login.GetLogin("KiranAnantapalli");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForNonSectionedStudents(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(45568)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonBrowserChromeItemsTrayBackUnitTitleToolsGamesNotificationBadgeTeacherGuideSectionedStudent()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC45568: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide for Sectioned Student"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForSectionedStudents(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(45569)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void LessonBrowserChromeItemsTrayBackUnitTitleToolsGamesNotificationBadgeTeacherGuideNonSectionedTeacher()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC45569: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide for Non Sectioned Teacher"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForNonSectionedTeachers(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        //[TestMethod()]
        //[TestCategory("LessonBrowserTests")]
        //[WorkItem(45570)]
        //[Priority(3)]
        //[Owner("Silky Manocha(silky.manocha)")]
        //public void LessonBrowserChromeItemsTrayBackUnitTitleToolsGamesNotificationBadgeTeacherGuideSectionedTeacher()
        //{
        //    using (LessonBrowserAutomationAgent = new AutomationAgent("TC45570: Lesson Browser chrome items are: Tray, 'back', Unit title, Tools&Games, Notification Badge, Teacher Guide for Sectioned Teacher"))
        //    {
        //        try
        //        {
        //            Login login = Login.GetLogin("Sec9Apatton");
        //            NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
        //            TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        //            NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
        //            NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
        //            Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForSectionedTeachers(LessonBrowserAutomationAgent));
        //            NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

        //        }
        //        catch (Exception ex)
        //        {
        //            LessonBrowserAutomationAgent.Sleep(2000);
        //            LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
        //            LessonBrowserAutomationAgent.ApplicationClose();
        //            LessonBrowserAutomationAgent.GenerateReportAndReleaseClient();
        //            throw;
        //        }
        //    }
        //}
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15895)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NoWifiIconsAreShownForLessonsNotYetDownloaded()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15895: no-wifi icons are shown ONLY for lessons NOT yet downloaded"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonPreviewProgress");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    //NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, true);
                   // LessonBrowserAutomationAgent.LaunchApp();
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, 1), "Lesson Progress Bar not found");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(LessonBrowserAutomationAgent), "Lessons Not Downloaded");
                    LessonBrowserCommonMethods.LessonProgressBarExistUntilDownloadComplete(LessonBrowserAutomationAgent, 1);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, true);
                    LessonBrowserAutomationAgent.LaunchApp();
                    LessonBrowserCommonMethods.ClickOnBackButton(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, 2);
                    Assert.IsTrue(LessonBrowserCommonMethods.NoWifiIconInLesson(LessonBrowserAutomationAgent), "Wifi Icon is not found");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, false);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(22151)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void StartButtonNonDownloadedLessonsPreviewDisabled()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC22151: start button of non-downloaded lessons in Lesson Preview disabled"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.NavigateToMathGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInMathUnitPreview(LessonBrowserAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnLessonTile(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.SwipeLessonPreviewTillContinueDisabled(LessonBrowserAutomationAgent, Direction.Right);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyStartButtonInLessonPreview(LessonBrowserAutomationAgent), "Start Button In LessonPreview is found");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15904)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NoWifiIconsVisibleOnThumbnailsPopupMessageVisible()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15904:no-wifi icons visible on thumbnails & pop-up message visible"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, 2);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, 1);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, 1), "Lesson Progress Bar not found");
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, true);
                    LessonBrowserAutomationAgent.LaunchApp();
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiMessageHeader(LessonBrowserAutomationAgent), "No Wifi Message Header is found");
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiMessageBody(LessonBrowserAutomationAgent), "No Wifi Message Body is found");
                    LoginLogoutCommonMethods.ClickOnOkButton(LessonBrowserAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.NoWifiIconInLesson(LessonBrowserAutomationAgent), "Wifi Icon is not found");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15897), WorkItem(16124), WorkItem(17701), WorkItem(20046), WorkItem(22155), WorkItem(22156), WorkItem(16303)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void LessonsDownloadingInBackgroundQueue()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15897, TC17701, TC20046, TC22155, TC22156, TC16303 & TC16124:Lessons downloading in background when user opens a unit for the first time"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NewUnitToDownload");
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    int newAddedGrade = NavigationCommonMethods.ClickAddGrade(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(LessonBrowserAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(LessonBrowserAutomationAgent, "ELA", newAddedGrade), "Recently added grade is not downloading");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, 1), "Lesson Progress Bar not found");
                    LessonBrowserCommonMethods.ScrollToLastEpisode(LessonBrowserAutomationAgent);
                    int lessonNumber = LessonBrowserCommonMethods.GetLastLessonNumberInEpisode(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(LessonBrowserAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingUnit(LessonBrowserAutomationAgent, taskInfo.SubjectName, taskInfo.Grade, taskInfo.Unit), "Downloading unit is not found in the content manager");
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingQueueForLessonSequence(LessonBrowserAutomationAgent, taskInfo.SubjectName, taskInfo.Grade, taskInfo.Unit, lessonNumber), "Lesson Nummber is not found in the downloading queue");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, newAddedGrade);
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.VerifyDownloadingGrade(LessonBrowserAutomationAgent, "ELA", newAddedGrade);
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ScrollToLastEpisode(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, lessonNumber);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, lessonNumber-1);
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(LessonBrowserAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyLessonDownloadingCurrently(LessonBrowserAutomationAgent, taskInfo.SubjectName, taskInfo.Grade, taskInfo.Unit, lessonNumber), "Currently tapped lesson is not downloading");
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingQueueForLessonWithoutScrolling(LessonBrowserAutomationAgent, taskInfo.SubjectName, taskInfo.Grade, taskInfo.Unit, lessonNumber-1), "Lesson Nummber is not found in the downloading queue");
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyQueuedLessonStartsDownloading(LessonBrowserAutomationAgent, taskInfo.SubjectName, taskInfo.Grade, taskInfo.Unit, lessonNumber, lessonNumber - 1), "Queued lesson didn't start downloading");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15901), WorkItem(22145)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyLessonsPreviewProgressBar()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15901 & TC22145:Lessons preview should show progress bar for the downloading lessons"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonPreviewProgress");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.WaitForLessonToDownloaded(LessonBrowserAutomationAgent, 1);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, 1);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPreviewCardContentIsGrayed(LessonBrowserAutomationAgent, 1), "Lesson preview is disabled");
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Left);
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Left);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCardContentIsGrayed(LessonBrowserAutomationAgent, 3), "Lesson preview is not disabled");
                    LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnLessonPreviewCloseButton(LessonBrowserAutomationAgent, 3);
                    LessonBrowserCommonMethods.ScrollToLastEpisode(LessonBrowserAutomationAgent);
                    int lessonNumber = LessonBrowserCommonMethods.GetLastLessonNumberInEpisode(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(LessonBrowserAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingQueueForLessonSequence(LessonBrowserAutomationAgent, taskInfo.SubjectName, taskInfo.Grade, taskInfo.Unit, lessonNumber), "Lesson downloading sequence is altered");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15975), WorkItem(15978), WorkItem(17697)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyUnitDownloadProgress()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15975, TC15978 & TC17697:Verify Unit download progress"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    int gradeAdded1 = NavigationCommonMethods.ClickAddGrade(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, gradeAdded1);
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(LessonBrowserAutomationAgent), "Preparing Units Spinner is not found");
                    NavigationCommonMethods.WaitForUnitsToDownload(LessonBrowserAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.GetNumberOfUnitsInGrade(LessonBrowserAutomationAgent) > 1, "Number of units in grade is not > 1");
                    NavigationCommonMethods.ClickELAUnit(LessonBrowserAutomationAgent, "1");
                    Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(LessonBrowserAutomationAgent, "1"), "Unit Preview is not accessible");
                    NavigationCommonMethods.ClickUnitPreviewCardStartButton(LessonBrowserAutomationAgent, "1");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(16095)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyUnitsDownloadPauseOnWifiDisable()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC16095:Verify Unit download is paused after Disabling Wifi and restarts after enabling"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    int gradeAdded = NavigationCommonMethods.ClickAddGrade(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, gradeAdded);
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(LessonBrowserAutomationAgent), "Preparing Units Spinner is not found");
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, true);
                    LessonBrowserAutomationAgent.LaunchApp();
                    LessonBrowserAutomationAgent.Sleep();
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoWiFiIconFound(LessonBrowserAutomationAgent), "No wifi icon is not found");
                    Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiLabelFound(LessonBrowserAutomationAgent), "No Wifi Label is not found");
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyNoWifiStatus(LessonBrowserAutomationAgent), "No Wifi status is not found");
                    NavigationCommonMethods.ChangeWiFiConnectivity(LessonBrowserAutomationAgent, false);
                    LessonBrowserAutomationAgent.LaunchApp();
                    LessonBrowserAutomationAgent.Sleep();
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(LessonBrowserAutomationAgent), "Preparing Units Spinner is not found");
                    Assert.IsFalse(NavigationCommonMethods.VerifyNoWiFiIconFound(LessonBrowserAutomationAgent), "No wifi icon is found");
                    Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiLabelFound(LessonBrowserAutomationAgent), "No Wifi Label is found");
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    Assert.IsFalse(ContentManagerCommonMethods.VerifyNoWifiStatus(LessonBrowserAutomationAgent), "No Wifi status is found");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15898)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NodelayInViewingLessonWhenUsersSwipeThroughLessons()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC15898:No delay in viewing lesson when users swipe through lessons."))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserAutomationAgent.Sleep();
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    DateTime FirstLessonPreview = DateTime.Now;
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Right);
                    DateTime SecondLessonPreview = DateTime.Now;
                    TimeSpan diffDatetime = SecondLessonPreview.Subtract(FirstLessonPreview);
                    LessonBrowserCommonMethods.VerifyLessonPreviewCard(LessonBrowserAutomationAgent, (taskInfo.Lesson + 1));
                    Assert.IsTrue(diffDatetime.Seconds < 50, "Time taken to open lesson preview is having delays");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }


                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(22153)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenLessonIsTappedItStartDownload()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC22153: When a lesson is tapped it starts to download, no preview opened"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NewUnitToDownload");
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    int newAddedGrade = NavigationCommonMethods.ClickAddGrade(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateContentManager(LessonBrowserAutomationAgent);
                    ContentManagerCommonMethods.ClickShowDetails(LessonBrowserAutomationAgent);
                    Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingGrade(LessonBrowserAutomationAgent, "ELA", newAddedGrade), "Recently added grade is not downloading");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, 1), "Lesson Progress Bar not found");
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(22150)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SelectingLessonWillBeginDownload()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC22150: IDL: Selecting lesson will begin its download - download starts"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(LessonBrowserAutomationAgent),"Lessons Downloaded Are found");
                    NavigationCommonMethods.ClickLessonNotDownloaded(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.AreEqual<string>("true", LessonBrowserCommonMethods.VerifyELAStartButtonActive(LessonBrowserAutomationAgent));
                    LessonBrowserCommonMethods.NavigateLesson(LessonBrowserAutomationAgent);
                    Assert.AreEqual<string>("false", LessonBrowserCommonMethods.VerifyELAStartButtonActive(LessonBrowserAutomationAgent));
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(22152)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void DownloadCanAccessLessonCarrousel()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC22152: IDL: during the download you can access the lesson carrousel and view already downloaded lessons"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInELAUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickLessonNotDownloadedInLessonPreview(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(LessonBrowserAutomationAgent), "Lesson Download is not found");
                    LessonBrowserCommonMethods.SwipeEpisode(LessonBrowserAutomationAgent, Direction.Right);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);

                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19363), WorkItem(19365), WorkItem(19366), WorkItem(19369), WorkItem(19371)]
        [Priority(2)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyNotDownloadedLessonsDoNotOpen()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC19363, TC19365, TC19369, TC19371 & TC19366: Verify lesson that are not downloaded can not be opened"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "NewUnitToDownload");
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, taskInfo.Unit);
                    LessonBrowserCommonMethods.ClickOnDownloadIconOfLesson(LessonBrowserAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(LessonBrowserAutomationAgent, 1), "Lesson Progress Bar not found");
                    NavigationCommonMethods.WaitForLessonToDownload(LessonBrowserAutomationAgent, 1);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.SwipeLessonPreviewCard(LessonBrowserAutomationAgent, Direction.Left);
                    LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(LessonBrowserAutomationAgent, 2);
                    LessonBrowserCommonMethods.ClickOnLessonPreviewCloseButton(LessonBrowserAutomationAgent, 2);
                    NavigationCommonMethods.WaitForLessonToDownload(LessonBrowserAutomationAgent, 2);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, 2);
                    LessonBrowserCommonMethods.VerifyELAStartButtonActive(LessonBrowserAutomationAgent, 2);
                    LessonBrowserCommonMethods.ClickOnLessonPreviewCloseButton(LessonBrowserAutomationAgent, 2);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.Sleep(2000);
                    LessonBrowserAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    LessonBrowserAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

    }
}

