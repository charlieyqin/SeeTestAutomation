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
    public class EreaderTest
    {
        public AutomationAgent eReaderAutomationAgent;

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(23859)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyNavigatingToPreviousAndNextPagesOfEReader()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC23859: Verify that the user is able to navigate to previous and next pages using the left and right arrows in the annotation mode of the ereader"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnNextPageIcon(eReaderAutomationAgent, 1);
                    int getPagecountAfterClickingOnNext = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterClickingOnNext.Equals(getPagecount + 1));
                    EreaderCommonMethod.ClickOnPreviousPageIcon(eReaderAutomationAgent, 1);
                    int getPagecountAfterClickingOnPrev = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterClickingOnPrev.Equals(getPagecountAfterClickingOnNext - 1));
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(21897)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEreaderFunctionalityAndFlowFromMediaLibrary()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC21897: Verify the functionality and flow when user opens poem,book and hand writing flash cards from the media library."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyBottomNavBarItemsAtEreader(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(21898)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEreaderFunctionalityAndFlowFromTodayShelf()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC21898: Verify the functionality and flow when user opens book from the Today's Shelf."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyBottomNavBarItemsAtEreader(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(22189)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEreaderBottomNavBarItemsFlowFromMediaLibrary()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC22189: Verify the functionality and flow when user opens book from the media library."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyBottomNavBarItemsAtEreader(eReaderAutomationAgent);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, EreaderCommonMethod.VerifyPreviousPageIconTillDisabled(eReaderAutomationAgent, getPagecount));
                    Assert.AreEqual<bool>(true, EreaderCommonMethod.VerifyNextPageIconTillDisabled(eReaderAutomationAgent));
                    Assert.AreEqual<bool>(true, EreaderCommonMethod.VerifyPageNumberInMiddle(eReaderAutomationAgent));
                    EreaderCommonMethod.SwipeToGetNextPage(eReaderAutomationAgent);
                    int getPagecountAfterSwiping = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterSwiping > getPagecount);
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(22190)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEreaderBottomNavBarItemsFlowFromTodayShelf()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC22190: Verify the functionality and flow when user opens book from the Today's Shelf."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, EreaderCommonMethod.VerifyPreviousPageIconTillDisabled(eReaderAutomationAgent, getPagecount));
                    Assert.AreEqual<bool>(true, EreaderCommonMethod.VerifyNextPageIconTillDisabled(eReaderAutomationAgent));
                    Assert.AreEqual<bool>(true, EreaderCommonMethod.VerifyPageNumberInMiddle(eReaderAutomationAgent));
                    EreaderCommonMethod.SwipeToGetNextPage(eReaderAutomationAgent);
                    int getPagecountAfterSwiping = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterSwiping > getPagecount);
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(22452)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyZoomInAndOutEreaderFromTodayShelf()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC22452: Verify whether the user is able to zoom in and out the E-reader when opened from Today Shelf."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    int pagePosition = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    EreaderCommonMethod.ZoomOutTheEreader(eReaderAutomationAgent);
                    int pagePositionAfterZoomedOut = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut > pagePosition);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(eReaderAutomationAgent);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnNextPageIcon(eReaderAutomationAgent, 1);
                    int pagePositionAfterClickingNext = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut > pagePositionAfterClickingNext);
                    int getPagecountAfterClickingOnNext = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterClickingOnNext.Equals(getPagecount + 1));
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(22453)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyZoomInAndOutEreaderFromMediaLibrary()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC22453: Verify whether the user is able to zoom in and out the E-reader when opened from Media Library"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenBookFromMediaLibrary(eReaderAutomationAgent);
                    int pagePosition = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    EreaderCommonMethod.ZoomOutTheEreader(eReaderAutomationAgent);
                    int pagePositionAfterZoomedOut = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut > pagePosition);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(eReaderAutomationAgent);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnNextPageIcon(eReaderAutomationAgent, 1);
                    int pagePositionAfterClickingNext = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut > pagePositionAfterClickingNext);
                    int getPagecountAfterClickingOnNext = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterClickingOnNext.Equals(getPagecount + 1));
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(27030)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAnnotationMadeInOfflineRetrivedInOnline()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC27030: Verify that annotations made in offline session are still retrieved in next online session."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(eReaderAutomationAgent, TurnWifiOff);
                    eReaderAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnTopBookForEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(eReaderAutomationAgent, TurnWifiOff);
                    eReaderAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentKevin"));
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(22635)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEreaderHeaderAndFooterFunctionality()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC22635: Verify the Header and Footer functionality of eReader."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyPageArrowActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.ZoomOutTheEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyPageArrowActivated(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyEreaderContent(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyPageNumberInMiddle(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(22451)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyZoomInAndOutOfErederFromBackPack()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC22451: Verify whether the user is able to zoom in and out the E-reader from Backpack"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(eReaderAutomationAgent);
                    BackPackCommonMethods.DragElementToBackPack(eReaderAutomationAgent, 1);
                    BackPackCommonMethods.VerifyAndCloseIfMediaAlreadyExist(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnBackPack(eReaderAutomationAgent);
                    BackPackCommonMethods.ClickToOpenBackPackEreader(eReaderAutomationAgent);
                    int pagePosition = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    EreaderCommonMethod.ZoomOutTheEreader(eReaderAutomationAgent);
                    int pagePositionAfterZoomedOut = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut > pagePosition);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyTopNavBarItemsAtEreader(eReaderAutomationAgent);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnNextPageIcon(eReaderAutomationAgent, 1);
                    int pagePositionAfterClickingNext = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut > pagePositionAfterClickingNext);
                    int getPagecountAfterClickingOnNext = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, getPagecountAfterClickingOnNext.Equals(getPagecount + 1));
                    MediaLibraryCommonMethods.ClickOnBackIconAtImageViewer(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30009)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserOnAnnotationScreen()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30009: Ensure that on tapping Red(X) button on cropping snapshot interface screen , should CANCEL and return user to E-Reader screen in annotation mode."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInAnnotationMode(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyCroppingArea(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyUserOnAnnotationScreen(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30046)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGooglyEyesPresent()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30046:  verify that Googly eyes are hidden when No annotation is present on eReader page."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    Assert.IsFalse(EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(eReaderAutomationAgent), "Googly eyes found");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30007)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserAbleToSendSnapshotToNotebook()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30007:Ensure that on clicking Green check on snapshot cropping interface screen, sends snapshot to notebook."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInAnnotationMode(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyCroppingArea(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifySnapShotSendToNotebook(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(eReaderAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(eReaderAutomationAgent, 2);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(27025)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySendSnapshotIsInTheCentreOfNotebook()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC27025:Ensure that on tapping Green check mark on cropping interface screen , snapshot should be inserted in the center of new page"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(eReaderAutomationAgent);
                    int count = NotebookCommonMethods.GetCountOfNotebookPages(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInAnnotationMode(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifySnapShotSendToNotebook(eReaderAutomationAgent);
                    Assert.IsTrue(EreaderCommonMethod.VerifySnapshotAddedToNewPage(eReaderAutomationAgent, count), "The snapshot is not added to new page");
                    Assert.IsTrue(EreaderCommonMethod.VerifySnapshotInTheCentreOfPage(eReaderAutomationAgent), "Snapshot is not in the centre of the screen");
                    NotebookCommonMethods.ClickOnClearAllButton(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(eReaderAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(eReaderAutomationAgent, 2);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest"), TestCategory("K1SmokeTests")]
        [WorkItem(30048)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGooglyEyesCloseAndOpen()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30048: verify that open Googly eyes are visible when Annotations is present with Googly eyes  toggled on in eReader page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep(6000);
                    Assert.IsFalse(EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(eReaderAutomationAgent), "Googly eyes found");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickonGoogleEyeButton(eReaderAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickonGoogleEyeButton(eReaderAutomationAgent);
                    Assert.IsTrue(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(29985)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRedirectionToSameEreader()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC29985: Verify that the user is able to navigate to previous and next pages using the left and right arrows in the annotation mode of the ereader"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    int getPagecount = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    int Pagecountafterredirection = EreaderCommonMethod.GetCurrentPageCount(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, Pagecountafterredirection.Equals(getPagecount), "Page count of ereader didnt match after redirection from notebook canvas");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(29989)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRemoveButtonFunctionalityInSnapshot()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC29989: Verify that tapping red X visible in top left corner removes snapshot from the notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    NotebookCommonMethods.VerifyRemoveBUtton(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(eReaderAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifySnapShotSendToNotebook(eReaderAutomationAgent), "Snapshot didnt get deleted after pressing remove button");
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(29992)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDottedLinesAndHandtoolActive()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC29992: Verify Send snapshot to notebook (Read Mode)_absence of dotted lines and hand tool active"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(eReaderAutomationAgent), "Hand tool not active after adding sanpshot to notebook");
                    Assert.IsFalse(NotebookCommonMethods.VerifyDottedLinePresent(eReaderAutomationAgent), "Dotted lines are present around snapshot");
                    NotebookCommonMethods.ClickOnRemoveButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30052)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyZoomFeatureWhenAnnotationLayerOn()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30052: verify Zoom feature in eReader page with annotation layer on"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickonGoogleEyeButton(eReaderAutomationAgent);
                    int pagePosition = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    EreaderCommonMethod.ZoomOutTheEreader(eReaderAutomationAgent);
                    int pagePositionAfterZoomedOut = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePositionAfterZoomedOut.Equals(pagePosition), "The zoom in took place therefore position didnt match");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickonGoogleEyeButton(eReaderAutomationAgent);
                    int pagePosition1 = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    EreaderCommonMethod.ZoomOutTheEreader(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickonGoogleEyeButton(eReaderAutomationAgent);
                    int pagePosition2 = EreaderCommonMethod.GetCurrentPagePosition(eReaderAutomationAgent);
                    Assert.AreEqual<bool>(true, pagePosition1.Equals(pagePosition2));
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }
                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }


            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30049)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGooglyEyesRules()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30049: Verify Googly rules in eReader page"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    UnitSelectionCommonMethods.NavigateToLesson(eReaderAutomationAgent, 5);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    Assert.IsTrue(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found open");
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickOnNextPageIcon(eReaderAutomationAgent, 1);
                    eReaderAutomationAgent.Sleep(6000);
                    Assert.IsFalse(EreaderCommonMethod.VerifyGoogleEyeButtonForEreader(eReaderAutomationAgent), "Google eye found after navigating to other page");
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickOnTopBookForEreader(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    Assert.IsFalse(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found closed after returning back from annotation edit mode");
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickOnPreviousPageIcon(eReaderAutomationAgent, 1);
                    Assert.IsTrue(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found closed after returning back from annotation edit mode");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(25165)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyErederUnderMaskedAreaShouldNotBeFunctional()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC25165: Verify that on cropped snapshot interface screen, elements under masked area should not be functional"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyCroppingArea(eReaderAutomationAgent);
                    Assert.IsTrue(EreaderCommonMethod.VerifyAreaOtherThanCroppingAreaIsDisabled(eReaderAutomationAgent), "Fail when enabled property will be true");
                    Assert.IsTrue(EreaderCommonMethod.VerifyGlobalNavIconsDisabled(eReaderAutomationAgent), "Fail when property will be True");
                    NavigationCommonMethods.ClickOnCrossButton(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest"), TestCategory("K1SmokeTests")]
        [WorkItem(28365)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedDataInNotebOokCanvas()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC28365: Ensure that user is able to save the notebook canvas after editing with all functional tools of canvas post insertion of snapshot of e-reader"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 100);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInAnnotationMode(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep(5000);
                    EreaderCommonMethod.VerifySnapShotSendToNotebook(eReaderAutomationAgent);
                    string[] pos = EreaderCommonMethod.GetPositionOfEreaderSnapshot(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1500, 500);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 800);
                    NotebookCommonMethods.ClickInsideTextBox(eReaderAutomationAgent);
                    eReaderAutomationAgent.SendText("Tester");
                    NavigationCommonMethods.NavigateToHome(eReaderAutomationAgent, 3);
                    NavigationCommonMethods.ClickOnNotebookBrowser(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep(5000);
                    NavigationCommonMethods.ClickToOpenNotebook(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(eReaderAutomationAgent);
                    eReaderAutomationAgent.ClickOnScreen(Int32.Parse(pos[0]) + 50, Int32.Parse(pos[1]) + 50);
                    EreaderCommonMethod.VerifySnapShotSendToNotebook(eReaderAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(eReaderAutomationAgent, "Tester"), "Data not found after opening the notebook");
                    NotebookCommonMethods.ClickOnClearAllButton(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30047)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGooglyEyesOpeAndClose()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30047: verify that closed Googly eyes are visible when Annotations is present with Googly eyes  toggled off on eReader page."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickToEditEreader(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    Assert.IsTrue(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found open");
                    EreaderCommonMethod.ClickonGoogleEyeButton(eReaderAutomationAgent);
                    Assert.IsFalse(EreaderCommonMethod.VerifyGoogleEyeClose(eReaderAutomationAgent), "Googly eyes found close");
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1024, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest"), TestCategory("K1SmokeTests")]
        [WorkItem(28363)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyEreaderUnderMaskedAreaNotBeFunctional()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC28363: Verify that on cropped snapshot interface screen, elements under masked area should not be functional"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    EreaderCommonMethod.VerifyCroppingArea(eReaderAutomationAgent);
                    Assert.IsTrue(EreaderCommonMethod.VerifyAreaOtherThanCroppingAreaIsDisabled(eReaderAutomationAgent), "Fail when enabled property will be true");
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    Assert.IsTrue(EreaderCommonMethod.VerifySnapShotNotInNotebookTools(eReaderAutomationAgent), "Snapshot found");
                    NotebookCommonMethods.ClickOnClearAllButton(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(29979)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHiddenSendToNotebookButtonForGlossary()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC29979: Verify that Send to notebook button is hidden for Glossary."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenToBottom(eReaderAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenGlossaryFromLibrary(eReaderAutomationAgent);
                    eReaderAutomationAgent.WaitforElement("BookBuilderView", "GlossaryTitle", "", WaitTime.MediumWaitTime);
                    Assert.IsFalse(EreaderCommonMethod.VerifySendToNotebookButton(eReaderAutomationAgent), "Fail if send to notebook button display");
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(25167)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCanvasPostInsertionInToEreaderSnapshot()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC25167: Verify that user is able to save the notebook canvas after editing with all functional tools of canvas post insertion of snapshot of e-reader."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    eReaderAutomationAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    LoginCommonMethods.ClickGreenMark(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(eReaderAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(eReaderAutomationAgent);
                    BookBuilderCommonMethods.SendText(eReaderAutomationAgent, "Testing");
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1000, 500);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(eReaderAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(eReaderAutomationAgent, "Testing"), "Fail if canvas changes is not saved on notebook");
                    NavigationCommonMethods.ClickOnBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }

                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("EreaderTest")]
        [WorkItem(30050)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyHeaderFooterOnEreader()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC30050: Verify when back button is tapped in the interactive player the user redirected to the previous screen in this case todays shelf open."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 1000);
                    Assert.IsTrue(EreaderCommonMethod.VerifyEreaderHeaderView(eReaderAutomationAgent), "Header not found");
                    Assert.IsTrue(EreaderCommonMethod.VerifyEreaderFooterView(eReaderAutomationAgent), "Footer not found");
                    eReaderAutomationAgent.Sleep(5000);
                    
                    Assert.IsFalse(EreaderCommonMethod.VerifyEreaderHeaderView(eReaderAutomationAgent), "Header  found");
                    Assert.IsFalse(EreaderCommonMethod.VerifyEreaderFooterView(eReaderAutomationAgent), "Footer  found");
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 1000);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);

                }
                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("CAadoptionTest")]
        [WorkItem(29984)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCancelingTheSnapshotInEreader()
        {
            using (eReaderAutomationAgent = new AutomationAgent("TC29984: Ensure that on tapping Red(X) button on cropping snapshot interface screen , should CANCEL and return user to E-Reader screen in read mode"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(eReaderAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(eReaderAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(eReaderAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(eReaderAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickToOpenEreaderFromTodaysShelf(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 1000);
                    EreaderCommonMethod.ClickOnSendToNotebookButtonInEreader(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(eReaderAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(eReaderAutomationAgent, 1600, 1000);
                    EreaderCommonMethod.VerifyNavigationBarActivated(eReaderAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(eReaderAutomationAgent);
                    LoginCommonMethods.Logout(eReaderAutomationAgent);
                }
                catch (Exception ex)
                {
                    eReaderAutomationAgent.Sleep(2000);
                    eReaderAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    eReaderAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
    }
}
