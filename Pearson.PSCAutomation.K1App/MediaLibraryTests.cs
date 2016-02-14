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
    public class MediaLibraryTests
    {
        public AutomationAgent MediaLibraryAutomationAgent;

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(29959)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserIsAbleToLaunchSongs()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC29959: verify that user is able to launch songs in native player of iOS"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    string currentUnit = NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, currentUnit);
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenSong(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyOpenSong(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenSong(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyOpenSong(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26226)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserIsAbleToVideos()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26226: verify that user is able to launch videos in native player of iOS"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    string currentUnit = NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, currentUnit);
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenVideos(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyOpenVideoSong(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenVideos(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyOpenVideoSong(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26228)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserIsAbleToOpenInteractive()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26228: verify that user is able to launch interactive in native player of iOS"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenInteractive(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackButtonatMTE(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenInteractive(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackButtonatMTE(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(29962)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVerticalScrollPositionSavedInInteractive()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC29962:Verify that the media library is in the same state (i.e) currently displaying current unit and same vertical scroll position after tapping on the back button in the Interactive"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    string coordinatesBeforeOpeningInteractive = MediaLibraryCommonMethods.GetCoordinateOfInteractive(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenInteractive(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyInteractiveOpen(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackButtonatMTE(MediaLibraryAutomationAgent);
                    string coordinatesAfterOpeningInteractive = MediaLibraryCommonMethods.GetCoordinateOfInteractive(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, coordinatesBeforeOpeningInteractive.Equals(coordinatesAfterOpeningInteractive));
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26648)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVerticalScrollPositionSavedInVideoPlayer()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26648:Verify that the media library is in the same state (i.e) currently displaying current unit and same vertical scroll position after tapping on the back button video player"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    string coordinatesBeforeOpeningVideo = MediaLibraryCommonMethods.GetCoordinateOfVideo(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenVideos(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyOpenVideoSong(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackAtMediaPlayer(MediaLibraryAutomationAgent);
                    string coordinatesAfterOpeningVideo = MediaLibraryCommonMethods.GetCoordinateOfVideo(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, coordinatesBeforeOpeningVideo.Equals(coordinatesAfterOpeningVideo));
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(22201)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserIsAbleToOpenImageInImageViewer()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC22201:Ensure that user is able to open the image from Media library and the view of image in image viewer"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    string coordinatesBeforeOpeningImage = MediaLibraryCommonMethods.GetCoordinateOfImage(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBackButtonInImageViewer(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyUserOnMedialLibrary(MediaLibraryAutomationAgent));
                    string coordinatesAfterOpeningImage = MediaLibraryCommonMethods.GetCoordinateOfImage(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, coordinatesBeforeOpeningImage.Equals(coordinatesAfterOpeningImage));
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(27054)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNoDuplicateAssetsInMediaLibrary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC27054: Verify that there are no duplicate assets displayed in the media library"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyNoDuplicateBookDisplayed(MediaLibraryAutomationAgent));
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyNoDuplicatePoemDisplayed(MediaLibraryAutomationAgent));
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyNoDuplicateSongDisplayed(MediaLibraryAutomationAgent));
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyNoDuplicateInteractiveDisplayed(MediaLibraryAutomationAgent));
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyNoDuplicateFlashcardDisplayed(MediaLibraryAutomationAgent));
                    Assert.AreEqual<bool>(true, MediaLibraryCommonMethods.VerifyNoDuplicateVideoDisplayed(MediaLibraryAutomationAgent));
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("MediaLibraryTest"), TestCategory("K1SmokeTests")]
        [WorkItem(20452)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnNextPreviousUnitIconAtMediaLibrary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC20452: Verify that clicking on Right arrow moves to next unit present on the device and clicking on left arrow moves to previous unit present on the device"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    int unitNumber = MediaLibraryCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickOnNextUnitIcon(MediaLibraryAutomationAgent);
                    int unitNumberAfterClickingNext = MediaLibraryCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, unitNumberAfterClickingNext == (unitNumber + 1));
                    MediaLibraryCommonMethods.ClickOnPreviousUnitIcon(MediaLibraryAutomationAgent);
                    int unitNumberAfterClickingPrev = MediaLibraryCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    Assert.AreEqual<bool>(true, unitNumberAfterClickingPrev == (unitNumberAfterClickingNext - 1));
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(30028)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLessonStandardsInMediaLibrary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC30028: Verify that Lesson Standards will WILL NOT BE displayed in the Media Library."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyLessonStandardsNOTInMediaLibrary(MediaLibraryAutomationAgent), "Lesson standards found in media library");
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(43481)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRubricsEreaderTools()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC43481: Verify that the Rubrics opened in the E-Reader will have the same tools available in our standard E-Reader"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenRubricFromLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 100);
                    EreaderCommonMethod.VerifyEreaderHeaderView(MediaLibraryAutomationAgent);
                    MediaLibraryAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 100);
                    EreaderCommonMethod.VerifyEreaderFooterView(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.ClickToEditEreader(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.VerifyEreaderCanvasTools(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.VerifyUserOnAnnotationScreen(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.VerifySendToNotebookButtonInAnnotationMode(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(31751)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyStandardChartAsInteractiveNotEreader()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC31751: Verify that Standards chart shall be configured as an Interactive Animation and NOT EReader"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenStandardChartFromLibrary(MediaLibraryAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifyEreaderFooterView(MediaLibraryAutomationAgent), "Fail if ereader footer display for standard chart");
                    Assert.IsFalse(EreaderCommonMethod.VerifyEreaderHeaderView(MediaLibraryAutomationAgent), "Fail if ereader header display for standard chart");
                    MediaLibraryCommonMethods.VerifyStandardChartTitle(MediaLibraryAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifySendToNotebookButton(MediaLibraryAutomationAgent), "Fail if send to notebook button is display");
                    MediaLibraryCommonMethods.VerifyStandardChartScrollView(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 19);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(MediaLibraryAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifyEreaderFooterView(MediaLibraryAutomationAgent), "Fail if ereader footer display for standard chart");
                    Assert.IsFalse(EreaderCommonMethod.VerifyEreaderHeaderView(MediaLibraryAutomationAgent), "Fail if ereader header display for standard chart");
                    MediaLibraryCommonMethods.VerifyStandardChartTitle(MediaLibraryAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifySendToNotebookButton(MediaLibraryAutomationAgent), "Fail if send to notebook button is display");
                    MediaLibraryCommonMethods.VerifyStandardChartScrollView(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest"), TestCategory("K1SmokeTests")]
        [WorkItem(27457)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTeacherAbleToDragGlossary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC27457: Verify that as a teacher User is able to drag GO or Glossary on the media library screen."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 15);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26270)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTOCEpubView()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26270: Verify TOC epub view"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenTOCFromLibrary(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.ZoomOutTheEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 350, 350);
                    EreaderCommonMethod.VerifyEreaderHeaderView(MediaLibraryAutomationAgent);
                    MediaLibraryAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 350, 350);
                    EreaderCommonMethod.VerifyEreaderFooterView(MediaLibraryAutomationAgent);
                    MediaLibraryAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 350, 350);
                    EreaderCommonMethod.ClickToEditEreader(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.ClickOnTopBookForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 350, 350);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(MediaLibraryAutomationAgent);
                    MediaLibraryAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 350, 350);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(MediaLibraryAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.VerifySnapShotSendToNotebook(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 350, 350);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);

                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(43462)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHandwritingResourcesImageUpdatedForStudent()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC43462: Verify that Handwriting Resources image is updated for student."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenHandwritingActivity(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUpdatedHandwritingImage(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26267)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDisplayAndOrderOfMediaLibraryBottomShelf()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26267: Verify the display and order of Handwriting activity, TOC and Standards Chart"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyOrderOfMediaLibraryBottomShelf(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    int countsOfBackPackItems = BackPackCommonMethods.GetTheAvailablesItemCountInBackPack(MediaLibraryAutomationAgent);
                    if (!countsOfBackPackItems.Equals(0))
                        for (int i = 1; i <= countsOfBackPackItems; i++)
                            BackPackCommonMethods.DragElementToTrash(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 13);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackItem(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyTableOfContentTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 300, 300);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToTrash(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 19);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackItem(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyStandardChartTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(43480)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDraggingOfRubricToBackPack()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC43480: Verify that the Students will be able to drag Rubrics to the Backpack"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    int countsOfBackPackItems = BackPackCommonMethods.GetTheAvailablesItemCountInBackPack(MediaLibraryAutomationAgent);
                    if (!countsOfBackPackItems.Equals(0))
                        for (int i = 1; i <= countsOfBackPackItems; i++)
                            BackPackCommonMethods.DragElementToTrash(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 11);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackItem(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyRubricTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 250, 250);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26224)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHandwritingView()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26224: Verify that Handwriting Resources image is shows an image in the image viewer"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    int getBackPackCount = BackPackCommonMethods.GetTheBackPackCount(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 0);
                    int getBackPackCountAfterDraggingHandwriting = BackPackCommonMethods.GetTheBackPackCount(MediaLibraryAutomationAgent);
                    Assert.IsTrue(getBackPackCount.Equals(getBackPackCountAfterDraggingHandwriting), "Fail if handwriting is draggable");
                    MediaLibraryCommonMethods.ClickToOpenHandwritingActivity(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUpdatedHandwritingImage(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(MediaLibraryAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(27082)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHandwritingIsNotDraggable()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC27082: Verify that neither a teacher nor a student can add the handwriting resource to backpack."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    int getBackPackCount = BackPackCommonMethods.GetTheBackPackCount(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 0);
                    int getBackPackCountAfterDraggingHandwriting = BackPackCommonMethods.GetTheBackPackCount(MediaLibraryAutomationAgent);
                    Assert.IsTrue(getBackPackCount.Equals(getBackPackCountAfterDraggingHandwriting), "Fail if handwriting is draggable");
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(31840)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLoadingIndicatorWhenHandwritingOpen()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC31840: Verify that neither a teacher nor a student can add the handwriting resource to backpack."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenHandwritingActivity(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.VerifyLoadingIndicator(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26229)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOfllineMessageWhenTapsOnHandwriting()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26229: Verify the page behavior when Teacher taps on the Handwriting tile from Media Libraray when Network Data Loss is enabled"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(MediaLibraryAutomationAgent, true);
                    MediaLibraryAutomationAgent.LaunchApp();
                    MediaLibraryCommonMethods.ClickToOpenHandwritingActivity(MediaLibraryAutomationAgent);
                    MediaLibraryAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    MediaLibraryCommonMethods.VerifyOfflineMessageForHandwriting(MediaLibraryAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(MediaLibraryAutomationAgent, false);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(27088)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOfllineMessageWhenExternalDataLoadsWithinHandwriting()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC27088: Verify that When the Network data loss is enabled, the external website loads within the app "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenHandwritingActivity(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(MediaLibraryAutomationAgent, true);
                    MediaLibraryAutomationAgent.LaunchApp();
                    MediaLibraryAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                    LoginCommonMethods.VerifyNoInternetMessage(MediaLibraryAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(MediaLibraryAutomationAgent, false);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(43478)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRubricShelfPositionInMediaLibrary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC43478: Verify that the Rubric Shelf position in the Media Library is below Graphic Organizers and above Glossary"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillGraphicOrganizers(MediaLibraryAutomationAgent);
                    int positionOfGraphicOrganizers = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGraphicOrganizers(MediaLibraryAutomationAgent)[1]);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    int positionOfRubrics = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfRubrics(MediaLibraryAutomationAgent)[1]);
                    int positionOfGlossary = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGlossary(MediaLibraryAutomationAgent)[1]);
                    Assert.IsTrue(positionOfGraphicOrganizers < positionOfRubrics && positionOfRubrics < positionOfGlossary, "Fail if rubrics position is not matched with requirement");

                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(29981)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyGlossarySavingState()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC29981: Verify Glossary Saving state to Media Library"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGlossaryFromLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickOnAlphabeticalDropDownOfGlossary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGlossaryFromLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGlossaryDefaultStatus(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest"), TestCategory("K1SmokeTests")]
        [WorkItem(29974)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyGraphicOrganizerSavingState()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC29974: Verify Graphic Organizer Saving state to Media Library"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillGraphicOrganizers(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGraphicOrganizerFromMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBlendingPracticeImage(MediaLibraryAutomationAgent);
                    MediaLibraryAutomationAgent.Swipe(Direction.Down);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGraphicOrganizerFromMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBlendingPracticeImage(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26279)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVisibilityAndFunctionalityOfGlossary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26279: Verify visibility and functionality of glossary"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    int positionOfGraphicOrganizers = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGraphicOrganizers(MediaLibraryAutomationAgent)[1]);
                    int positionOfGlossary = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGlossary(MediaLibraryAutomationAgent)[1]);
                    Assert.IsTrue(positionOfGraphicOrganizers > positionOfGlossary, "Fail if glossary position is not below to graphic organizer");
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    int countsOfBackPackItems = BackPackCommonMethods.GetTheAvailablesItemCountInBackPack(MediaLibraryAutomationAgent);
                    if (!countsOfBackPackItems.Equals(0))
                        for (int i = 1; i <= countsOfBackPackItems; i++)
                            BackPackCommonMethods.DragElementToTrash(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 15);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackItem(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGlossaryTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGlossaryFromLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGlossaryDefaultStatus(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26278)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyVisibilityAndFunctionalityOfGraphicOrganizer()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26278: Verify visibility and functionality of Graphic Organizer"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    int positionOfGraphicOrganizers = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGraphicOrganizers(MediaLibraryAutomationAgent)[1]);
                    MediaLibraryCommonMethods.ClickToOpenGraphicOrganizerFromMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGraphicOrganizerTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    int positionOfGlossary = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGlossary(MediaLibraryAutomationAgent)[1]);
                    Assert.IsTrue(positionOfGraphicOrganizers > positionOfGlossary, "Fail if glossary position is not below to graphic organizer");
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26282)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNewCategoryGlossary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26282: Verify visibility and functionality of Glossary"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    int countsOfBackPackItems = BackPackCommonMethods.GetTheAvailablesItemCountInBackPack(MediaLibraryAutomationAgent);
                    if (!countsOfBackPackItems.Equals(0))
                        for (int i = 1; i <= countsOfBackPackItems; i++)
                            BackPackCommonMethods.DragElementToTrash(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 15);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackItem(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGlossaryTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.VerifyBackPackOpened(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGlossaryFromLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGlossaryTitle(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(20454)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMediaLibraryRefreshCurrentUnitNumber()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC20454: Verify that once unit download gets completed while user is viewing media library it refreshes to reflect currently available units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    int currentUnitNumber = MediaLibraryCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickOnNextUnitIcon(MediaLibraryAutomationAgent);
                    int currentUnitNumberAfterNav = MediaLibraryCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    Assert.IsTrue(currentUnitNumber < currentUnitNumberAfterNav, "Fail as cannot navigate to next unit");
                    MediaLibraryCommonMethods.ClickOnPreviousUnitIcon(MediaLibraryAutomationAgent);
                    int currentUnitNumberAfterNavToPrev = MediaLibraryCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent);
                    Assert.IsTrue(currentUnitNumberAfterNavToPrev < currentUnitNumberAfterNav, "Fail cannot navigate to prev unit");
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(19263)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCategoryIconDisplayInFirstShelf()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC19263: Verify that each category begins on a new shelf with icons displayed on a start shelf specific to category"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBookCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyPoemCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifySongCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyIntercativeCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyFlashcardCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyVideoCategoryIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(19262)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMedialibraryViewAndElements()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC19262: Verify the layout of view and elements in media library screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUnitTitleImage(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyNextUniticon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyPreviousUniticon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBookCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyPoemCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifySongCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyIntercativeCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyFlashcardCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyVideoCategoryIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(31224)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMedialibraryAssets()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC31224: Verify that the assets are categorized appropriately with no duplication of assets in the media library"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBookCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyPoemCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifySongCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyIntercativeCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyFlashcardCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyVideoCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyNoDuplicateCategory(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest"), TestCategory("K1SmokeTests")]
        [WorkItem(26222)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNoDuplicateCategoryAtMedialibrary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26222: Verify that the assets are categorized appropriately with no duplication of assets in the media library"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyBookCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyPoemCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifySongCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyIntercativeCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyFlashcardCategoryIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyVideoCategoryIcon(MediaLibraryAutomationAgent);
                    //MediaLibraryCommonMethods.VerifyNoDuplicateCategory(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(27029)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEreaderAnnotationInMediaLibraryAccessFromTodayShelf()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC27029: Verify that annotations made for E-reader accessed from todays shelf are retrieved when same E-reader is viewed from media libraray "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(MediaLibraryAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(MediaLibraryAutomationAgent, 1);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 500, 500);
                    EreaderCommonMethod.ClickToEditEreader(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.ClickOnMarker(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1300, 500);
                    EreaderCommonMethod.ClickOnTopBookForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(23857)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAnnotationOpenFromDifferentFromDifferentModule()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC23857: Verify that the annotation is persisting in the all the instances of the e reader in today's shelf, Media Library and Back pack"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(MediaLibraryAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(MediaLibraryAutomationAgent, 1);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 500, 500);
                    EreaderCommonMethod.ClickToEditEreader(MediaLibraryAutomationAgent);
                    EreaderCommonMethod.ClickOnMarker(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1300, 500);
                    EreaderCommonMethod.ClickOnTopBookForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1000, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(MediaLibraryAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(MediaLibraryAutomationAgent, 1);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1300, 500);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 1);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(20451)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUnitImageAndHIddenArrowForOneDownloadedUnit()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC20451: Verify that Media Library should display unit title, medallion and activities for current unit."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    List<string> downloadedUnit = NavigationCommonMethods.GetDownloadedUnitList(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUnitTitleImage(MediaLibraryAutomationAgent);
                    Assert.IsTrue(MediaLibraryCommonMethods.VerifyHiddenArrowForOneDownloadedUnit(MediaLibraryAutomationAgent, downloadedUnit.Count), "Fail if arrow will not hidden");
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26225)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHandwritingLoadsTheExternalWebsite()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26225: Verify that Tapping on the Handwriting tile loads the external website within the app (similar to MTE/CC)"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenHandwritingActivity(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyUpdatedHandwritingImage(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(MediaLibraryAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(23534)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLibraryOpenToLastReadPage()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC23534: Verify E-reader Save and Open To Last Read Page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(MediaLibraryAutomationAgent, 1);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    EreaderCommonMethod.ClickOnNextPageIcon(MediaLibraryAutomationAgent, 1);
                    int currentPageCount = EreaderCommonMethod.GetCurrentPageCount(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(MediaLibraryAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(MediaLibraryAutomationAgent, 1);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    EreaderCommonMethod.VerifyGivenPageNumber(MediaLibraryAutomationAgent, currentPageCount);
                    EreaderCommonMethod.ClickOnNextPageIcon(MediaLibraryAutomationAgent, 1);
                    currentPageCount = EreaderCommonMethod.GetCurrentPageCount(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    EreaderCommonMethod.VerifyGivenPageNumber(MediaLibraryAutomationAgent, currentPageCount);
                    EreaderCommonMethod.ClickOnNextPageIcon(MediaLibraryAutomationAgent, 1);
                    currentPageCount = EreaderCommonMethod.GetCurrentPageCount(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    EreaderCommonMethod.VerifyGivenPageNumber(MediaLibraryAutomationAgent, currentPageCount);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    EreaderCommonMethod.VerifyGivenPageNumber(MediaLibraryAutomationAgent, currentPageCount);
                    NavigationCommonMethods.TapOnScreen(MediaLibraryAutomationAgent, 1600, 350);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26277)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyGOIsAddedToMediaLibrary()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26277: Verify Graphic Organizer displayed on a new shelf, below the existing shelves on the Media Library and above the Glossary. The shelf shall be visible only if GO's are available as part of the Unit Content and Can be Added to Back pack."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillGraphicOrganizers(MediaLibraryAutomationAgent);
                    int positionOfGraphicOrganizers = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGraphicOrganizers(MediaLibraryAutomationAgent)[1]);
                    int positionOfGlossary = Int32.Parse(MediaLibraryCommonMethods.GetCoordinateOfGlossary(MediaLibraryAutomationAgent)[1]);
                    Assert.IsTrue(positionOfGraphicOrganizers > positionOfGlossary, "Fail if glossary position is not below to graphic organizer");
                    MediaLibraryCommonMethods.ClickToOpenGraphicOrganizerFromMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGraphicOrganizerTitle(MediaLibraryAutomationAgent);
                    InteractiveCommonMethods.VerifyInteractivePlayer(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DeleteAllAvailableItemsFromBackpack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.DragGraphicOrganizerToBackPack(MediaLibraryAutomationAgent, 14);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.ClickToOpenGraphicOrganizerFromBackPack(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGraphicOrganizerTitle(MediaLibraryAutomationAgent);
                    InteractiveCommonMethods.VerifyInteractivePlayer(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    BackPackCommonMethods.VerifyBackPackOpened(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(26281)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyFunctionalBehaviourOfGOIsSimiliarToInteractive()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC26281: Verify that the functional behavior of GO should be similar to the Interactives"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillGraphicOrganizers(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGraphicOrganizerFromMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGraphicOrganizerTitle(MediaLibraryAutomationAgent);
                    InteractiveCommonMethods.VerifyInteractivePlayer(MediaLibraryAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnIntercativeImageFromNotebook(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(MediaLibraryAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(MediaLibraryAutomationAgent);
                    LoginCommonMethods.Logout(MediaLibraryAutomationAgent);
                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        //[TestMethod()]
        [TestCategory("MediaLibraryTest")]
        [WorkItem(29976)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyFurtherUpdatesOfGOSendingToNotebook()
        {
            using (MediaLibraryAutomationAgent = new AutomationAgent("TC29976: Verify Further updates to the Graphic organizer shall save state back to Notebook "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(MediaLibraryAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(MediaLibraryAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(MediaLibraryAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(MediaLibraryAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillGraphicOrganizers(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGraphicOrganizerFromMediaLibrary(MediaLibraryAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.ClickOnStampButton(MediaLibraryAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnIntercativeImageFromNotebook(MediaLibraryAutomationAgent);
                    InteractiveCommonMethods.VerifyThumbnailSelectedState(MediaLibraryAutomationAgent);
                    NavigationCommonMethods.ClickOnIntercativeImageFromNotebook(MediaLibraryAutomationAgent);
                    MediaLibraryCommonMethods.VerifyGraphicOrganizerTitle(MediaLibraryAutomationAgent);

                }

                catch (Exception ex)
                {
                    MediaLibraryAutomationAgent.Sleep(2000);
                    MediaLibraryAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    MediaLibraryAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

    }
}
