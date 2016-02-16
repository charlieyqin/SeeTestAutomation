using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class CommonReadTests
    {
        public AutomationAgent commonReadAutomationAgent;

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(15955)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ChangingPagesOnCommonReadAscendingPagesByUsingPaginationArrows()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15955: Changing pages on common read (ascending pages) by using pagination (arrows)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    int pageNumberBefore = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "1"));
                    CommonReadCommonMethods.ClickOnRightArrow(commonReadAutomationAgent);
                    int pageNumberAfter = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "2"));
                    Assert.AreEqual<int>(pageNumberBefore + 1, pageNumberAfter);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(15954)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChangingPagesOnCommonReadDescendingPagesByTappingPaginationArrows()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15954: Changing pages on a common read (descending pages) by tapping pagination (arrows)"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnRightArrow(commonReadAutomationAgent);
                    int pageNumberBefore = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "2"));
                    CommonReadCommonMethods.ClickOnLeftArrow(commonReadAutomationAgent);
                    int pageNumberAfter = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "1"));
                    Assert.AreEqual<int>(pageNumberBefore, pageNumberAfter + 1);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(21759)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void TappingDoneButtonClosesCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC21759: Tapping done button closes common read"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    Assert.AreEqual<bool>(false, CommonReadCommonMethods.VerifyCommonReadButton(commonReadAutomationAgent));
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests"), TestCategory("212SmokeTests")]
        [WorkItem(15944)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AnnotationHighlightsDisappearsWhenAnnotationOffAndItAppearsWhenAnnotationOn()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15944: Verify that annotation highlights disappear when Annotation button is off"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[1], "Test2");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[2], "Test3");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[3], "Test4");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[4], "Test5");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyNotExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[3]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[4]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(23138)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void MessageForOverlappingPreviouslyCreatedItemAnnotation()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC23138: Verify message for overlapping previously created item annotation/ highlighted"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(2000);
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(16059)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDeleteHighlightAppearanceAndExistingHighlightMessage()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC16059: Verify Delete highlight option in the contextual menu and message for overlapping existing item annotation/highlight"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    Assert.AreEqual<bool>(false, CommonReadCommonMethods.VerifyDeleteHighlightButtonExist(commonReadAutomationAgent));
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(16062)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyExistingHighlightMessage()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC16062: Verify Tapping on previously created highlight should cause that appropriate message for overlapping is showed up"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    if (!CommonReadCommonMethods.VerifyHighlightExistsOrAnnotation(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    }
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(2000);
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(16063)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDeleteHighlightinEreader()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC16063: Verify 'Delete Highlight' deletes existing highlight in Common Read eReader"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    if (!CommonReadCommonMethods.VerifyHighlightExistsOrAnnotation(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    }
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    if (CommonReadCommonMethods.VerifyEditAndDeleteButton(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                        CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                        commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                        commonReadAutomationAgent.Sleep(2000);
                        CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    }
                    if (!CommonReadCommonMethods.VerifyHighlightExistsOrAnnotation(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    }
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(15999)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyCommonReadDisplaysEPub()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15999: Verify common read displays ePub"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyCommonReadScreen(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18604)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyScreenDisplayDividesInHalfWhenTappingAnnotateWhileInCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC18604: Verify screen display divides in half when tapping ‘annotate’, while in common read"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test10");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();

                    Assert.AreEqual(true, CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(commonReadAutomationAgent));

                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(19299)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyToolOnTheRightSideOfCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC19299: Verify tool on the right side of Common Read"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(3000);
                    CommonReadCommonMethods.VerifyVellumModeButtonExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18607)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDefaultAnnotateModeInPressedStateCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC18607: Verify Default 'annotate mode' button should be in pressed state"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(2000);

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationLayerOn(commonReadAutomationAgent));
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationLayerOff(commonReadAutomationAgent));
                    CommonReadCommonMethods.VerifyGistAnnotationStickyNotExists(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18673)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyKeyboardAppearDisappearOnCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC18673: Verify keyboard should automatically raised on annotation and disappear when press on cancel"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    if (CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                        CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                        CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                        NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                        CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                        CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    }
                    Assert.IsTrue(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent));
                    CommonReadCommonMethods.ClickCancelOnEditAnnotation(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    Assert.IsFalse(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent));

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(15958)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyScreenDisplayDividesInHalfBlueInCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15958: Verify that annotation right panel appears in half screen and blue in background"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[2], "Test10");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();

                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(commonReadAutomationAgent), "Annotation doesn't split CR window");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyBlueBackGroundOfAnnotationScreen(commonReadAutomationAgent), "background of annotation screen is not blue");
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18603)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyKeyboardSlidesUpOnCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC18603: Verify keyboard slides up from the bottom when tapping annotate, in common read"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    if (CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                        CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                        CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                        NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                        CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                        CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    }
                    Assert.IsTrue(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent));

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(15948)]
        [Priority(3)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyChangeAnnotationAndFilter()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15948: Verify Change annotation category and filter"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[2], "Test11");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    CommonReadCommonMethods.ChangeAndFilterAnnotationType(commonReadAutomationAgent, AnnotationType.Gist);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("CommonReadTests"), TestCategory("212SmokeTests")]
        [WorkItem(15943)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void PaginationWithSwipingOrTappingOnLeftAndRightArrow()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC15943: Pagination with swiping or tapping on >/<"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    int pageNumberBefore = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "1"));
                    CommonReadCommonMethods.ClickOnRightArrow(commonReadAutomationAgent);
                    int pageNumberAfter = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "2"));
                    Assert.AreEqual<int>(pageNumberBefore + 1, pageNumberAfter, "page number not in ascending order");
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnRightArrow(commonReadAutomationAgent);
                    int pageNumberBefore1 = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "2"));
                    CommonReadCommonMethods.ClickOnLeftArrow(commonReadAutomationAgent);
                    int pageNumberAfter1 = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "1"));
                    Assert.AreEqual<int>(pageNumberBefore1, pageNumberAfter1 + 1, "page number not in descending order");
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(16066)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyHighlightSupportsHighlightSelectedText()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC16066: Highlights support Highlight selected text in Common read"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    if (!CommonReadCommonMethods.VerifyHighlightExistsOrAnnotation(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    }
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(3000);
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18606)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAnnotatonLayerBehavior()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC18606: annotations/ highlights turn on when turning on annotation mode in Common read"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    if (!CommonReadCommonMethods.VerifyHighlightExistsOrAnnotation(commonReadAutomationAgent))
                    {
                        CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    }

                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[1], "Test5");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.VerifyHighlightedWord(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();

                    CommonReadCommonMethods.VerifyHighlightedWordNotFound(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyNotExists(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();

                    CommonReadCommonMethods.VerifyHighlightedWord(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);

                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(19139)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyCopyPasteInCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC19139: annotations/ highlights turn on when turning on annotation mode in Common read"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.CopyTextFromCommonRead(commonReadAutomationAgent);

                    NotebookCommonMethods.ClickOnNotebookIcon(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(commonReadAutomationAgent);

                    NotebookCommonMethods.ClickTextIconInNotebook(commonReadAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(commonReadAutomationAgent, "First Page");
                    NotebookCommonMethods.LongClickOnText(commonReadAutomationAgent, "First Page");
                    NotebookCommonMethods.ClickOnNotebookPasteIcon(commonReadAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.VerifyTextRegionTextFound(commonReadAutomationAgent, words[2]);

                    NotebookCommonMethods.ClickEraseIconInNotebook(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(commonReadAutomationAgent);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(20776)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTappingOnExistingAnnotationInCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC20776: Verify Tapping on annotation should open panel in common read"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test10");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(3000);
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    Assert.AreEqual(true, CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(commonReadAutomationAgent));

                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(34191)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDisabledFunctionalitiesInCommonReadInZoomedState()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC34191: Disabled functionality/elements in eReader when zoomed in state"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    string annotationButtonWidth = CommonReadCommonMethods.GetCopyButtonWidth(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                    commonReadAutomationAgent.Sleep();
                    Assert.IsFalse(CommonReadCommonMethods.VerifyLeftRightNavigationNotExist(commonReadAutomationAgent), "Left / Right navigation icons exist");
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    Assert.AreEqual<string>(annotationButtonWidth, CommonReadCommonMethods.GetCopyButtonWidth(commonReadAutomationAgent), "Copy button width is not same");

                    NotebookCommonMethods.Swipe(commonReadAutomationAgent, Direction.Left, 100, 100);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                    CommonReadCommonMethods.ClickOnLeftArrow(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(3000);
                    Assert.IsFalse(CommonReadCommonMethods.VerifyFirstPageOfCommonRead(commonReadAutomationAgent), "Left navigation icon exists");

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18601)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAnnotatingInEditModeInCommonRead()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC18601: Verify Annotating while in edit mode in common read"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test10");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();

                    Assert.IsTrue(CommonReadCommonMethods.VerifyEditAndDeleteButton(commonReadAutomationAgent), "Edit and Delete are not present");
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, "the");
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    Assert.IsFalse(CommonReadCommonMethods.VerifyEditAndDeleteButton(commonReadAutomationAgent), "Edit and Delete are present");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(16067)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyHighlightDragDotStretchFunction()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC16067: Verify that highlights can be stretched by using drag dot"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));

                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    Assert.IsTrue(CommonReadCommonMethods.DragDotIconAndVerify(commonReadAutomationAgent));
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(15955), WorkItem(15954), WorkItem(15944), WorkItem(23138), WorkItem(16059), WorkItem(16062), WorkItem(16063), WorkItem(15999), WorkItem(19299), WorkItem(15943), WorkItem(16066), WorkItem(18606), WorkItem(19139), WorkItem(34191)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyCommonReadCriticalTestCases()
        {
            using (commonReadAutomationAgent = new AutomationAgent("MTC21: CommonRead - Verify all common read functionalities"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');
                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyCommonReadScreen(commonReadAutomationAgent);
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(3000);
                    CommonReadCommonMethods.VerifyVellumModeButtonExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                    int pageNumberBeforeRight = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "1"));
                    CommonReadCommonMethods.ClickOnRightArrow(commonReadAutomationAgent);
                    int pageNumberAfterRight = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "2"));
                    Assert.IsTrue((pageNumberBeforeRight + 1) == pageNumberAfterRight, "Right navigation is not working on Common Read");
                    CommonReadCommonMethods.ClickOnLeftArrow(commonReadAutomationAgent);
                    int pageNumberAfterLeft = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber(commonReadAutomationAgent, "1"));
                    Assert.IsTrue(pageNumberAfterRight == (pageNumberAfterLeft + 1), "Left navigation is not working on Common Read");
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test1");
                    CommonReadCommonMethods.ClickAnnotateDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[1], "Test2");
                    CommonReadCommonMethods.ClickAnnotateDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyNotExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    Assert.IsFalse(CommonReadCommonMethods.VerifyDeleteHighlightButtonExist(commonReadAutomationAgent), "Delete Highligh button exists");
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyHighlightedWord(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    CommonReadCommonMethods.VerifyHighlightedWordNotFound(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    CommonReadCommonMethods.VerifyHighlightedWord(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(2000);
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[5]);
                    CommonReadCommonMethods.DeleteHighlightFromCommonRead(commonReadAutomationAgent);

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    CommonReadCommonMethods.CopyTextFromCommonRead(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    NotebookCommonMethods.ClickOnNotebookIcon(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(commonReadAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(commonReadAutomationAgent, "First Page");
                    NotebookCommonMethods.LongClickOnText(commonReadAutomationAgent, "First Page");
                    NotebookCommonMethods.ClickOnNotebookPasteIcon(commonReadAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 1200, 400, 1);
                    NotebookCommonMethods.VerifyTextRegionTextFound(commonReadAutomationAgent, words[2]);
                    NotebookCommonMethods.ClickEraseIconInNotebook(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[8]);
                    string annotationButtonWidth = CommonReadCommonMethods.GetCopyButtonWidth(commonReadAutomationAgent);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    CommonReadCommonMethods.ZoomCommonRead(commonReadAutomationAgent, words[8]);
                    Assert.IsFalse(CommonReadCommonMethods.VerifyLeftRightNavigationNotExist(commonReadAutomationAgent), "Left / Right navigation icons exist");
                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[8]);
                    Assert.IsTrue(annotationButtonWidth.Equals(CommonReadCommonMethods.GetCopyButtonWidth(commonReadAutomationAgent)), "Copy button width is not same");
                    NotebookCommonMethods.Swipe(commonReadAutomationAgent, Direction.Left, 100, 100);
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                    Assert.IsFalse(CommonReadCommonMethods.VerifyFirstPageOfCommonRead(commonReadAutomationAgent), "Left navigation icon exists");
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(21759), WorkItem(18604), WorkItem(18607), WorkItem(18673), WorkItem(15958), WorkItem(18603), WorkItem(15948), WorkItem(20776), WorkItem(18601), WorkItem(16067)]
        [Priority(2)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CommonReadImportantCases()
        {
            using (commonReadAutomationAgent = new AutomationAgent("MTC22: CommonRead - Other important cases"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    String additionalInfo = taskInfo.AdditionalInfo;
                    String[] objects = additionalInfo.Split(':');
                    String[] words = objects[1].Split(',');

                    NavigationCommonMethods.Login(commonReadAutomationAgent, login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(commonReadAutomationAgent, login.GetTaskInfo("ELA", "CommonRead"));
                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);

                    CommonReadCommonMethods.MoveToFirstPageInCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0], "Test10");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep(WaitTime.MediumWaitTime);

                    Assert.IsTrue(CommonReadCommonMethods.VerifyEditAndDeleteButton(commonReadAutomationAgent), "1. Edit and Delete are not present");
                    
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(commonReadAutomationAgent), "1. Annotation doesn't split CR window");
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep(WaitTime.SmallWaitTime);

                    CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationLayerOn(commonReadAutomationAgent));
                    CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationLayerOff(commonReadAutomationAgent));
                    CommonReadCommonMethods.VerifyGistAnnotationStickyNotExists(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                    
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyBlueBackGroundOfAnnotationScreen(commonReadAutomationAgent), "background of annotation screen is not blue");
                    CommonReadCommonMethods.ClickEditButton(commonReadAutomationAgent);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent), "1. Keyboard is not present");
                    CommonReadCommonMethods.ClickCancelOnEditAnnotation(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    Assert.IsFalse(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent), "1. Keyboard is present");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[1]);
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    Assert.IsFalse(CommonReadCommonMethods.VerifyEditAndDeleteButton(commonReadAutomationAgent), "2. Edit and Delete are present");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent), "2. Keyboard is not present");
                    CommonReadCommonMethods.ClickCancelOnEditAnnotation(commonReadAutomationAgent);
                    commonReadAutomationAgent.Sleep();
                    Assert.IsFalse(CommonReadCommonMethods.VerifyKeyboardPresence(commonReadAutomationAgent), "2. Keyboard is present");
                    commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                    commonReadAutomationAgent.Sleep();

                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(commonReadAutomationAgent), "2. Annotation doesn't split CR window");

                    CommonReadCommonMethods.ChangeAndFilterAnnotationType(commonReadAutomationAgent, AnnotationType.Gist);
                    CommonReadCommonMethods.SelectAnnotation(commonReadAutomationAgent, AnnotationType.Gist, words[0]);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);

                    CommonReadCommonMethods.GetAnnotationMenu(commonReadAutomationAgent, AnnotationType.Gist, words[2]);
                    Assert.IsTrue(CommonReadCommonMethods.DragDotIconAndVerify(commonReadAutomationAgent), "DragDot is not working properly");

                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    
                    Assert.IsFalse(CommonReadCommonMethods.VerifyCommonReadButton(commonReadAutomationAgent), "Common Read is not closed");
                    
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);
                }
                catch (Exception ex)
                {
                    commonReadAutomationAgent.Sleep(2000);
                    commonReadAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    commonReadAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}

