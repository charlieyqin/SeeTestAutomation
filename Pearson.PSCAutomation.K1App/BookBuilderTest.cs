using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class BookBuilderTest
    {
        public AutomationAgent bookBuilderAutomatinAgent;


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(20)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCriticalFunctionalityOfBookBuilderLandingPageForStudentUser()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("MTC20: Verify that Book Builder landing Page when the user first time access the book builder "))
            {
                try
                {
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSec02"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DeleteAllBookAvailable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBuilderLandingPage(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC20306", true);                    
                    string bookName = "Portrait Book";
                    string authorName = "Portrait Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 2);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTextCoverAndRightArrow(bookBuilderAutomatinAgent), "Text cover not found");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyCoverPageInCentre(bookBuilderAutomatinAgent), "Cover not found in centre");
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    bookBuilderAutomatinAgent.Sleep();                    
                    BookBuilderCommonMethods.VerifyOddPageNumberOnLeftSide(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTwoPagesOnOneScreen(bookBuilderAutomatinAgent), "Two pages on one screen not found");
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 1000);
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC44179", true);
                    if (bookBuilderAutomatinAgent.IsElementFound("UnitSelection", "SystemTray"))
                    {
                        NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                        NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    }
                    bookBuilderAutomatinAgent.WaitforElement("BookBuilderView", "NewBookButton", "", WaitTime.DefaultWaitTime);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragElementToTrashInBookBuilder(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyPageDeleted(bookBuilderAutomatinAgent), "Page not deleted");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);                    
                    bookName = "Landscape Book";
                    authorName = "Landcspae Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "B");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyPageDeleted(bookBuilderAutomatinAgent), "Page not deleted");
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC22180", true);
                    bookName = "Square Book";
                    authorName = "Square Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "C");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC30093", true);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC20439", true);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyItemsCannnotAddOnBlueTile(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SendText(bookBuilderAutomatinAgent, "Testing");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(bookBuilderAutomatinAgent, "Testing"), "Data Saved not Found");
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC22274", true);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    int currentBookPosition = Int32.Parse(BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, "BookTitle"));
                    int shareButtonPosition = BookBuilderCommonMethods.GetShareButtonPosition(bookBuilderAutomatinAgent);
                    int editButtonPosition = BookBuilderCommonMethods.GetEditButtonPosition(bookBuilderAutomatinAgent);
                    Assert.IsTrue((currentBookPosition - 38).Equals(shareButtonPosition - 96), "Fail if share would not display for centered book");
                    Assert.IsTrue(editButtonPosition < shareButtonPosition, "Fail if edit button would not be left of shre button");
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnCancelShare(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC45844", true);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.AreEqual<bool>(false, BookBuilderCommonMethods.VerifyHighlightedPage(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1600, 1200);
                    Assert.AreEqual<bool>(false, BookBuilderCommonMethods.VerifyHighlightedCoverPage(bookBuilderAutomatinAgent));
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC22267", true);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 10);
                    int pagePosition = BookBuilderCommonMethods.GetAddedPagePosition(bookBuilderAutomatinAgent, 8);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 8);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    int pagePositionAfterback = BookBuilderCommonMethods.GetAddedPagePosition(bookBuilderAutomatinAgent, 8);
                    Assert.IsFalse(pagePosition.Equals(pagePositionAfterback), "Previous saved scroll state isn't reset");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBrowserScreen(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyPageBrowserScrollPositionReset(bookBuilderAutomatinAgent, pagePosition), "Page browser state doesn't default to cover / first pages left-justified");
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC23190", true);
                    BookBuilderCommonMethods.DeleteAddedPages(bookBuilderAutomatinAgent);//Clarification in TC23179
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC23179", true);
                    string editBook = "EditBook";
                    string editName = "SaveBook";
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 100, 500);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, editBook, editName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtBookBrowser(bookBuilderAutomatinAgent, editBook, editName);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC21731", true);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyLeftSideToolsOfCanvas(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyRightSideToolsOfCanvas(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC22200", true);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "B");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 24);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SwipeToGetAddButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 2);
                    Assert.AreEqual<bool>(false, BookBuilderCommonMethods.VerifyAddPageButtonExist(bookBuilderAutomatinAgent));
                    BookBuilderCommonMethods.SwipeToGetFirstPage(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC21666", true);
                    BookBuilderCommonMethods.DragElementToTrashInBookBuilder(bookBuilderAutomatinAgent);
                    BackPackCommonMethods.VerifyDeleteAssertPopupFromBackPack(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport("TC23640", true);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

 /*       [TestMethod()]
        [TestCategory("BookBuilderTest"), TestCategory("K1SmokeTests")]
        [WorkItem(30093)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void CreateNewPortraitBookInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC30093: Verify that User is able to create a new Portrait book in Book Builder after accessing the Book Builder for first time"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Portrait Book";
                    string authorName = "Portrait Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");

                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24334)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void CreateNewLandscapeBookInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24334: Verify that User is able to create a new Landscape book in Book Builder after accessing the Book Builder for first time"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Landscape Book";
                    string authorName = "Landscape Author";
                    BookBuilderCommonMethods.ClickOnNewBookIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewLandscapeBookIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24337)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void CreateNewSquareBookInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24337: Verify that User is able to create a new Square book in Book Builder after accessing the Book Builder for first time"))
            {
                try
                {


                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Square Book";
                    string authorName = "Square Author";
                    BookBuilderCommonMethods.ClickOnNewBookIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewSquareBookIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(30003)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserCreateAndSavePortraitBookInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC30003:Verify that user is able to create and Save Portrait mode book even if Book builder has saved books"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Portrait Book";
                    string authorName = "Portrait Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24416)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserCreateAndSaveLandscapeBookInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24416:Verify that user is able to create and Save Landscape mode book even if Book builder has saved books"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Landscape Book";
                    string authorName = "Landscape Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "B");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24419)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUserCreateAndSaveSquareBookInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24419:Verify that user is able to create and Save Square mode book even if Book builder has saved books"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Square Book";
                    string authorName = "Square Author";
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


       /* [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(20439)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCreatingDifferentTypesBook()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC20439: Verifying creating different types of books and saves it"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Portrait Book";
                    string authorName = "Portrait Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    bookName = "Landscape Book";
                    authorName = "Landcspae Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "B");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    bookName = "Square Book";
                    authorName = "Square Author";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "C");
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(20470)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUserScrollThroughCreatedBooks()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC20470: Verify that the user is able to scroll through the newly created books"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Current Book " + NavigationCommonMethods.randomInteger(10).ToString();
                    string authorName = "Current Author " + NavigationCommonMethods.randomInteger(10).ToString();
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    string currentBookxaxis = BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, bookName);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 100, 500);
                    string swipedBookxaxis = BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, bookName);
                    bookBuilderAutomatinAgent.Sleep();
                    Assert.AreEqual<bool>(true, Int32.Parse(swipedBookxaxis) < Int32.Parse(currentBookxaxis));
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(20471)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRecentBookPositionWRTCurrentBook()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC20471: Verify Recent added book position with respect to Current added book"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName1 = "Recent added Book " + NavigationCommonMethods.randomInteger(10).ToString();
                    string authorName1 = "Recent Author " + NavigationCommonMethods.randomInteger(10).ToString();
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName1, authorName1);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    string bookName = "Current added Book " + NavigationCommonMethods.randomInteger(10).ToString();
                    string authorName = "Recent Author " + NavigationCommonMethods.randomInteger(10).ToString();
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    string recentBookxaxis = BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, bookName1);
                    string currentBookxaxis = BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, bookName);
                    Assert.AreEqual<bool>(true, Int32.Parse(currentBookxaxis) < Int32.Parse(recentBookxaxis));
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }





        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(21734)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAutoCorrectIsDisabledInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC21734:Verify that the auto correct is disabled in the title and author fields in the book builder"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "wrnog Naem";
                    string authorName = "wrnog Auhtor";
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    Assert.AreEqual<bool>(true, BookBuilderCommonMethods.VerifyAutoCorrectDisable(bookBuilderAutomatinAgent, bookName, authorName));
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22301)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTilteAndAuthorNameOnCoverPagesForPrevCreatedBook()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22301:Ensure that Author and title fields are displayed as per the latest design specifications in Book Cover under below Screens for previously created books"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    string bookName = BookBuilderCommonMethods.GetNameOfBook(bookBuilderAutomatinAgent);
                    string authorName = BookBuilderCommonMethods.GetNameOfAuthor(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtPageBrowser(bookBuilderAutomatinAgent, bookName, authorName);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesInEditMode(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtBookBrowser(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22273)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDisplayTextInTitleAndAuhtorField()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22273:Ensure that the default text is displayed in title and author fields when the user has not entered any text in previous screens"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesInEditMode(bookBuilderAutomatinAgent, "Untitled", "Author Name");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22302)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyDefaultTilteAndAuthorNameOnCoverPagesForNewlyCreatedBooks()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22302:Ensure that the Author and Title are displayed as per the latest specifications for newly created book under below screens"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBlankCoverPagetitlesAtPageBrowser(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtBookBrowser(bookBuilderAutomatinAgent, "Untitled", "Author Name");
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesInEditMode(bookBuilderAutomatinAgent, "Untitled", "Author Name");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22097)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.Khan)")]
        public void VerifyNotebookCanvasWhenBookPageIsOpen()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22097:Ensure that Tap on page in Book page browser opens book page in edit mode to invoke Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }
      /*  [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22267)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfPagesOnLongPressingPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22267:Verify the display of pages in page view on long pressing a page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    Assert.AreEqual<bool>(false, BookBuilderCommonMethods.VerifyHighlightedPage(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1600, 1200);
                    Assert.AreEqual<bool>(false, BookBuilderCommonMethods.VerifyHighlightedCoverPage(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/
        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22272)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCoverPageItemsWhenOpenInEditMode()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22272:Ensure that cover page is displayed with below item when opened in Edit mode"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyTileBlueColor(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesInEditMode(bookBuilderAutomatinAgent, "Untitled", "Author Name");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(21776)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAddedpageWithReferenceToAddButton()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC21776: Verify that plus button transition when at least three pages and plus button appear on screen ."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 4);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyAddPageButtonExist(bookBuilderAutomatinAgent), "Add page button exist");
                    BookBuilderCommonMethods.SwipeToGetAddButton(bookBuilderAutomatinAgent);
                    Assert.AreEqual<bool>(true, BookBuilderCommonMethods.VerifyNewlyAddedPagesPositions(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22275)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingOnBackSavedTheEditedCoverPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22275: Verify cover page thumbnail is displayed with updated/edited items when saved the cover page after Editing"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "Portrait Book";
                    string authorName = "Portrait Author";
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SendText(bookBuilderAutomatinAgent, "PEARSON TESTER");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyEditedCoverPageInPageBrowser(bookBuilderAutomatinAgent, bookName, authorName, "PEARSON TESTER"), "Faile due to editable cover page not found");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22682)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedPageInPageBrowserScreen()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22682:Verify that tapping on back button in edit page screen saves the page and page browser is displayed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SendText(bookBuilderAutomatinAgent, "Pearson Systems");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifySavedPage(bookBuilderAutomatinAgent, "Pearson Systems"), "Saved Page and its content not found");
                    BookBuilderCommonMethods.VerifyAddPageButtonExist(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }
       /* [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(23190)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageBrowserDefaultState()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC23190: Verify that if the user exits Book page browser and open the same book again, a. Previous saved scroll state is reset, b. Page browser state defaults to cover / first pages left-justified"))
            {

                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 10);
                    int pagePosition = BookBuilderCommonMethods.GetAddedPagePosition(bookBuilderAutomatinAgent, 8);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 8);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    int pagePositionAfterback = BookBuilderCommonMethods.GetAddedPagePosition(bookBuilderAutomatinAgent, 8);
                    Assert.IsFalse(pagePosition.Equals(pagePositionAfterback), "Previous saved scroll state isn't reset");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBrowserScreen(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyPageBrowserScrollPositionReset(bookBuilderAutomatinAgent, pagePosition), "Page browser state doesn't default to cover / first pages left-justified");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22758)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCoverPageCanvasUI()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22758:Ensure that the Cover page has fixed position blue Title / Author tile with Title and Author filled in and non editable blue tile area in book page browser ."))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBlankCoverPagetitlesAtPageBrowser(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtBookBrowser(bookBuilderAutomatinAgent, "Untitled", "Author Name");
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyTileBlueColor(bookBuilderAutomatinAgent);
                    Assert.AreEqual<bool>(true, BookBuilderCommonMethods.VerifyBlueTileIsNotEditable(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

     /*   [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(21731)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyLastModifiedBookInCentre()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC21731: Verify that user is able to see the last modified book is in centre and positioned as the first book in book browser."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    string bookName = "EditBook";
                    string authorName = "SaveBook";
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 100, 500);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtBookBrowser(bookBuilderAutomatinAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/


       /* [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22200)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEditNotebookCanvasTools()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22200: Verify Edit Page Using Notebook Canvas Tools."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyLeftSideToolsOfCanvas(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyRightSideToolsOfCanvas(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(21666)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddingMultiplePagesInBreakToSameBook()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC21666: Ensure that user is able to add maximum limit of pages (max limit is 25 plus cover page) by tapping [+] icon after adding 23 pages in previous attempt for same book."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 24);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SwipeToGetAddButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 2);
                    Assert.AreEqual<bool>(false, BookBuilderCommonMethods.VerifyAddPageButtonExist(bookBuilderAutomatinAgent));
                    BookBuilderCommonMethods.SwipeToGetFirstPage(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22225)]
        [Priority(3)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingOutSideChooseShapePopUpClosePopUp()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22225:Verify that Tapping outside the Choose shape pop up close the pop up"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyChooseShapePopUpOpen(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1600, 100);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyChooseShapePopUpOpen(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

      /*  [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(23640)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDeleteStylePopUp()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC23640: Verify the styled pop-up message displays when the user tries to delete the pages from book builder page browser screen. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragElementToTrashInBookBuilder(bookBuilderAutomatinAgent);
                    BackPackCommonMethods.VerifyDeleteAssertPopupFromBackPack(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }*/
        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(23179)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPageBrowserSavedState()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC23179: Verify that tapping on the book page to edit - the scroll position at this moment will be saved"))
            {

                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 10);
                    int pagePosition = BookBuilderCommonMethods.GetAddedPagePosition(bookBuilderAutomatinAgent, 8);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 8);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    int pagePositionAfterback = BookBuilderCommonMethods.GetAddedPagePosition(bookBuilderAutomatinAgent, 8);
                    Assert.IsFalse(pagePosition.Equals(pagePositionAfterback), "Previous scroll position is saved");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DeleteAddedPages(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22180)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDeletedPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22180: Ensure that page once deleted will not be shown back in page browser once user goes toanother book and visits same book's page browser again"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 2);
                    BookBuilderCommonMethods.DragElementToTrashInBookBuilder(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyPageDeleted(bookBuilderAutomatinAgent), "Page not deleted");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyPageDeleted(bookBuilderAutomatinAgent), "Page not deleted");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22268)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyReorderingOfPages()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22268: Verify the functionality of reordering the pages"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 1);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24425)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTableAddedToNoteBookCanvas()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24425:Ensure that Tap on page in Book page browser opens book page in edit mode to invoke Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableToolOverlay(bookBuilderAutomatinAgent), "Table tool overlay not found in the book builder notebook canvas");
                    BookBuilderCommonMethods.VerifyTableToolOverlayContents(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableToolOverlay(bookBuilderAutomatinAgent), "Table tool overlay found and you can add table");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyUserAbleToAddTable(bookBuilderAutomatinAgent), "Another table is not added");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(31834)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyShareBookIconANdTrashCan()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC31834: Verfiy Share book Icon And The trash can in the book brwoser view of book builder."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyShareButtonEnable(bookBuilderAutomatinAgent), "Share button is enable in the book builder");
                    BookBuilderCommonMethods.LongClickOnBookInBookBuilder(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTrashCanAppeared(bookBuilderAutomatinAgent), "Trash can not appeared");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 1);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44181)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyOnePagePerscreenAtATime()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44181: Verify that Square and landscape books continue to display only one page per screen at a time"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyOnePageAtATime(bookBuilderAutomatinAgent), "Fail as more than one page is available when square book open");
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyOnePageAtATime(bookBuilderAutomatinAgent), "Fail as more than one page is available when square book open");
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseLandscapeBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyOnePageAtATime(bookBuilderAutomatinAgent), "Fail as more than one page is available when landscape book open");
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyOnePageAtATime(bookBuilderAutomatinAgent), "Fail as more than one page is available when landscape book open");
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest"), TestCategory("K1SmokeTests")]
        [WorkItem(23287)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUIofBook()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC23287: Verify the UI of book read mode as follows"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "C");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep(2000);
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyHeaderFooterInBook(bookBuilderAutomatinAgent), "Header Footer not found in the book");
                    bookBuilderAutomatinAgent.Sleep(5000);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyHeaderFooterInBook(bookBuilderAutomatinAgent), "Header Footer found after 5 second of wait");
                    bookBuilderAutomatinAgent.ClickOnScreen(1000, 500);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTextCoverAndRightArrow(bookBuilderAutomatinAgent), "CoverNotFound");
                    BookBuilderCommonMethods.VerifyItemsInHeader(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    bookBuilderAutomatinAgent.Sleep();
                    bookBuilderAutomatinAgent.ClickOnScreen(1000, 500);
                    Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowPresent(bookBuilderAutomatinAgent), "Navigation arrow not present in ");
                    BookBuilderCommonMethods.ClickOnPrevArrowAtBook(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTextCoverAndRightArrow(bookBuilderAutomatinAgent), "CoverNotFound");
                    bookBuilderAutomatinAgent.ClickOnScreen(1000, 500);
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22099)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookBuilderCanvasPlaceholder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22099: Verify Book Builder canvas placeholder"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBuilderCanvasPlaceholder(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22202)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookBuilderCanvasDisplay()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22202: Verify the Book Canvas display"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyTexturedOffBackground(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBuilderCanvasPlaceholder(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22274)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookBuilderEditingCoverPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22274: Verify that user is able to Edit the cover page and verify the display of Edited items on Cover page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyItemsCannnotAddOnBlueTile(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SendText(bookBuilderAutomatinAgent, "Testing");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(bookBuilderAutomatinAgent, "Testing"), "Data Saved not Found");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(43808)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEmojiKeyIsDisabledForScreensWhenSettingsIsOn()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC43808: Verify that Emojis Key is disabled on Keyboard though the display of emoji is ON in device settings"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.EnableDeviceKeyboardEmojisKey(bookBuilderAutomatinAgent, true);
                    bookBuilderAutomatinAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickInsideBookTitle(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    BookBuilderCommonMethods.ClickInsideBookAuthorName(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    NavigationCommonMethods.ClickOnELAUnit(bookBuilderAutomatinAgent, NavigationCommonMethods.GetCurrentUnitNumber(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(bookBuilderAutomatinAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnTodayButton(bookBuilderAutomatinAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    TeacherModeCommonMethods.SendTextToAddNotes(bookBuilderAutomatinAgent, "Testing");
                    TeacherModeCommonMethods.ClickOnSaveButton(bookBuilderAutomatinAgent);
                    TeacherModeCommonMethods.ClickOnEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(43809)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyEmojiKeyIsDisabledForScreensWhenSettingsIsOff()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC43809: Verify that Emojis Key is disabled on Keyboard though the display of emoji is OFF in device settings"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.EnableDeviceKeyboardEmojisKey(bookBuilderAutomatinAgent, false);
                    bookBuilderAutomatinAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickInsideBookTitle(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    BookBuilderCommonMethods.ClickInsideBookAuthorName(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    NavigationCommonMethods.ClickOnELAUnit(bookBuilderAutomatinAgent, NavigationCommonMethods.GetCurrentUnitNumber(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnUnitHomeNavIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnTeacherMode(bookBuilderAutomatinAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnTodayButton(bookBuilderAutomatinAgent);
                    TeacherModeCommonMethods.ClickToAddNotes(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    TeacherModeCommonMethods.SendTextToAddNotes(bookBuilderAutomatinAgent, "Testing");
                    TeacherModeCommonMethods.ClickOnSaveButton(bookBuilderAutomatinAgent);
                    TeacherModeCommonMethods.ClickOnEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyEmojKeyDisabledOnKeyboard(bookBuilderAutomatinAgent), "Fail if Emoji key look enabled");
                    TeacherModeCommonMethods.ClickOnDeleteNoteButton(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(31613)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyBookBuilderNotebookCanvasRedoFunctionality()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC31613: Verify Redo  functionality on Bookbuilder Notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 1000);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 200);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int count = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    int countafterundo = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    int countafterredo = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    int countaftercomingback = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countafterredo.Equals(countaftercomingback), "Count didnt match after coming back to notebook after doing redo");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int countaferaddingchanges = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    int countafer = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countafer.Equals(countaferaddingchanges), "Count didnt match after coming back to notebook after adding changes");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22759)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySavedsnapshot()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22759: Ensure that Saved snapshot of cover will show the updated canvas with fixed-position blue tile in book page browser and book browser"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnCoverPage(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.SendText("PEARSON TESTER");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifySavedSnapshotOfCoverInPageBrowser(bookBuilderAutomatinAgent, "PEARSON TESTER"), "Savedsnapshot not found in page browser screen");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifySavedSnapshotOfCoverInBookBrowser(bookBuilderAutomatinAgent, "PEARSON TESTER"), "Savedsnapshot not found in page browser screen");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(22303)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDisplayOfBookCoverPageInBookBrowserView()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC22303: Display of Book Cover Page in Book Browser view."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    string bookName = BookBuilderCommonMethods.GetNameOfBook(bookBuilderAutomatinAgent);
                    string authorName = BookBuilderCommonMethods.GetNameOfAuthor(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCoverPageTitlesAtBookBrowser(bookBuilderAutomatinAgent, bookName, authorName);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTitleAndAuthorDoesNotOverlap(bookBuilderAutomatinAgent), "Titles overlap each other");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(26234)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAddingPageAppendToCollection()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC26234: Verify that adding a page will not cause a refresh of all pages and a snapshot for the new page will be generated with page appended to collection."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(bookBuilderAutomatinAgent, "A");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(bookBuilderAutomatinAgent, "1");
                    NotebookCommonMethods.ClickOnTextButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickInsideTextBox(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.SendText(bookBuilderAutomatinAgent, "Testing");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 2);
                    BookBuilderCommonMethods.VerifyAddedPageAppendInCollection(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.VerifySavedData(bookBuilderAutomatinAgent, "Testing");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44244)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDeletionOfBook()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44244: Verify Deletion of book"))
            {

                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    string bookname = "Tester1";
                    string authorname = "Test";
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookname, authorname);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DeleteBook(bookBuilderAutomatinAgent, bookname, authorname);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyDeletePopUp(bookBuilderAutomatinAgent), "Delete  pop up not found");
                    BackPackCommonMethods.VerifyDeleteAssertPopupFromBackPack(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 100, 100);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyDeletePopUp(bookBuilderAutomatinAgent), "Delete  pop up not found");
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyDeletePopUp(bookBuilderAutomatinAgent), "Delete  pop up  found");
                    BookBuilderCommonMethods.VerifyBookBrowserScreen(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DeleteBook(bookBuilderAutomatinAgent, bookname, authorname);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyDeletePopUp(bookBuilderAutomatinAgent), "Delete  pop up  found");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyDeletedBook(bookBuilderAutomatinAgent, bookname), "Book didnt get delete");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 1);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44180)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPagesInProtraitView()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44180: Verify that If the last page of the book is an odd number, or if there is only one page in the book, it will be presented by itself on the left side of the screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 3);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    int page_count = BookBuilderCommonMethods.GetPageCount(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyOddPageNumber(bookBuilderAutomatinAgent, page_count), "Odd page number not found");
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 400, 400);
                    BookBuilderCommonMethods.VerifyOddPageNumberOnLeftSide(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    int count = BookBuilderCommonMethods.GetPageCount(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyOddPageNumber(bookBuilderAutomatinAgent, page_count), "Odd page number not found");
                    BookBuilderCommonMethods.VerifyOddPageNumberOnLeftSide(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44179)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTwoPageProtraitView()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44179: Verify Two page portrait view in book builder"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToAddPages(bookBuilderAutomatinAgent, 3);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    BookBuilderCommonMethods.ClickToOpenBook(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTextCoverAndRightArrow(bookBuilderAutomatinAgent), "Text cover not found");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyCoverPageInCentre(bookBuilderAutomatinAgent), "Cover not found in centre");
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 300);
                    bookBuilderAutomatinAgent.Sleep();
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 1000);
                    BookBuilderCommonMethods.VerifyOddPageNumberOnLeftSide(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep();
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTwoPagesOnOneScreen(bookBuilderAutomatinAgent), "Two pages on one screen not found");
                    BookBuilderCommonMethods.ClickOnBackIconWhenBookOpen(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44244)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDeletionOfBook1()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44244: Verify Deletion of book"))
            {

                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    string bookname = "Tester1";
                    string authorname = "Test";
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookname, authorname);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DeleteBook(bookBuilderAutomatinAgent, bookname, authorname);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);




                    Assert.IsFalse(BookBuilderCommonMethods.VerifyDeletePopUp(bookBuilderAutomatinAgent), "Delete  pop up  found");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyDeletedBook(bookBuilderAutomatinAgent, bookname), "Book didnt get delete");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(31612)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBookBuilderNotebookCanvasUndoFunctionality()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC31612: Verify Undo functionality on Bookbuilder canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 1000);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 500);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int count = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    int countafterundo = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    int countaftercomingback = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countafterundo.Equals(countaftercomingback), "Count didnt match after coming back to notebook after doing undo");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int countaferaddingchanges = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    int countafer = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countafer.Equals(countaferaddingchanges), "Count didnt match after coming back to notebook after adding changes");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int countaferediting = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    int countaferundoing = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsFalse(countaferundoing.Equals(countaferediting), "Count  match after coming back to notebook canvas after adding changes");
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    int countaferundoingagain = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countaferundoing.Equals(countaferundoing), "Count didnt match after undoing again hence one of the elemente get undo.");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(31614)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClearAllFunctionalityOnBookBuilderPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC31614: Verify Undo functionality on Bookbuilder canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChooseSquareBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 1000);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int count = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.VerifyClearAllPopUpElements(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    int countaftercancel = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(count.Equals(countaftercancel), "Count didnt match after tapping on the cancel button");
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    int countafterclearing = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsFalse(count.Equals(countafterclearing), "Count  match after clearing all on the notebook canvas");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToEditBookPage(bookBuilderAutomatinAgent);
                    int countaftercomingtonotebookcanvas = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 1000);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int countafteraddingtables = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    int countafterclearingall = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countaftercomingtonotebookcanvas.Equals(countafterclearingall), "Count  match after clearing all on the notebook canvas");
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    int countafterredo = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(countafterclearingall.Equals(countafterredo), "Count  match after clearing all on the notebook canvas");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 1000);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    int countafterundo = BookBuilderCommonMethods.GetCountOfNumberLineTableInBookBuilderCanvas(bookBuilderAutomatinAgent);
                    Assert.IsTrue(count.Equals(countafterundo), "Count  match after clearing all on the notebook canvas");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44239)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyDeletionOfBookandItsShift()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44239: Verify Deletion of book and its shift"))
            {

                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DeleteAllBookAvailable(bookBuilderAutomatinAgent);
                    for (int i = 0; i <= 2; i++)
                    {
                        BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                        BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                        NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    }
                    string bookname1 = "Tester1";
                    string authorname1 = "Test";
                    string bookname2 = "Tester2";
                    string authorname2 = "Test2";
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookname1, authorname1);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookname2, authorname2);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 500);
                    bookBuilderAutomatinAgent.Sleep();
                    bookBuilderAutomatinAgent.Swipe(Direction.Right, 500);
                    string pos = BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, bookname1);
                    BookBuilderCommonMethods.DeleteBook(bookBuilderAutomatinAgent, "Untitled", "Author Name");
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    string posaftershift = BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, bookname1);
                    Assert.AreEqual(pos, posaftershift, "Positon got match i.e. no shift takes place.");
                    BookBuilderCommonMethods.DeleteAllBookAvailable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyBookBuilderMainScreen(bookBuilderAutomatinAgent), "Main screen not found");
                    BookBuilderCommonMethods.ClickOnNewBookIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewPortraitBookIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, bookname1, authorname1);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyCreatedBook(bookBuilderAutomatinAgent, bookname1, authorname1);
                    BookBuilderCommonMethods.DeleteBook(bookBuilderAutomatinAgent, bookname1, authorname1);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyDeletedBook(bookBuilderAutomatinAgent, bookname1), "Book didnt get delete");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 1);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(27112)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTablesCanBeRepositioned()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC27112: Verify that activating hand tool TOC, Index, Glossary added to canvas can be re-positioned on the canvas. "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    string[] tableofcontents_pos = BookBuilderCommonMethods.GetPositionofTableOfContentsTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfCOntentsTable(bookBuilderAutomatinAgent, 0, 500);
                    string[] tableofcontents_pos_after_drag = BookBuilderCommonMethods.GetPositionofTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.AreNotEqual(tableofcontents_pos, tableofcontents_pos_after_drag, "position got match");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.clickonGlossarytabel(bookBuilderAutomatinAgent);
                    string glossary_pos = BookBuilderCommonMethods.GetPositionofGlossaryTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragGlossaryTable(bookBuilderAutomatinAgent, 500, 500);
                    string glossary_pos_after_drag = BookBuilderCommonMethods.GetPositionofGlossaryTable(bookBuilderAutomatinAgent);
                    Assert.AreNotEqual(glossary_pos, glossary_pos_after_drag, "position got match");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickonIndextable(bookBuilderAutomatinAgent);
                    string index_pos = BookBuilderCommonMethods.GetPositionofIndexTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragIndexTable(bookBuilderAutomatinAgent, 500, 0);
                    string index_pos_after_drag = BookBuilderCommonMethods.GetPositionofIndexTable(bookBuilderAutomatinAgent);
                    Assert.AreNotEqual(glossary_pos, glossary_pos_after_drag, "position got match");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(27117)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySelectionOfTable()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC27117: Verify that table/ Glossary/ Index gets deselected "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 1000);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 594, 718);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    NotebookCommonMethods.ClickOnHandButton(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24431)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTheSaveDataInBookBuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24431: Verify user able to add table"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(bookBuilderAutomatinAgent, "1");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Another table is not added");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep(5000);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(bookBuilderAutomatinAgent, "1");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Another table is not added");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    bookBuilderAutomatinAgent.Sleep(5000);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(bookBuilderAutomatinAgent, "1");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Another table is not added");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    bookBuilderAutomatinAgent.Swipe(Direction.Right);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(bookBuilderAutomatinAgent, "1");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    bookBuilderAutomatinAgent.Swipe(Direction.Left);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(bookBuilderAutomatinAgent, "1");
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Another table is not added");
                    bookBuilderAutomatinAgent.Sleep(5000);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestCategory("BookBuilderTest")]
        [WorkItem(45847)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyShareButtonDisplayForteacher()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC45847: verify the Share button display for a Teacher in Book Builder"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyShareButtonDisabledForTeacher(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24430)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyFeautresOfTable()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24430: Verify Features of table added to book builder notebook canvas"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 1000);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 594, 718);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(bookBuilderAutomatinAgent), "Tool not active");
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 610, 470);
                    int height_before_text_entered = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickToGetNewLine(bookBuilderAutomatinAgent, 3);
                    int height_after_text_entered = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(height_before_text_entered <= height_after_text_entered);
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(24427)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyIntialStateOfTableAdded()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC24427: Verfying the intial state of table after adding table to book builder notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    BookBuilderCommonMethods.VerifyFourRowsTwoCOlumns(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableSelected(bookBuilderAutomatinAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(bookBuilderAutomatinAgent), "Tool not active");
                    int height_before_drag = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfContentHandle(bookBuilderAutomatinAgent, 0, 200);
                    int height_after_drag = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(height_before_drag < height_after_drag, "Height get matched");
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyCheckButton(bookBuilderAutomatinAgent), "Check button found");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 3);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(45049)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyHighlightedPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC45049: Verify the display of pages in page view on long pressing a page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyHighlightedPage(bookBuilderAutomatinAgent), "Page Is not highlighted");
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyAddPageButtonExist(bookBuilderAutomatinAgent), "Add page button exist");
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1600, 1200);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyHighlightedCoverPage(bookBuilderAutomatinAgent), "Cover Page is highlighted");
                    NavigationCommonMethods.NavigateToHome(bookBuilderAutomatinAgent, 2);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(44218)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyUndoRedoActionsOnTableInBookBuilderPage()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC44218: verify that Undo and Redo actions can be performed on the Table added in Book Builder Page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookPage(bookBuilderAutomatinAgent, 1);
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    string[] pos = BookBuilderCommonMethods.GetPositionofTableOfContentsTable(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    NotebookCommonMethods.ClickOnRemoveButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    Assert.IsTrue(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTableAddedIsSaved(bookBuilderAutomatinAgent), "Table not found");
                    BookBuilderCommonMethods.ClickOnTableTool(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnTableOfContentsTable(bookBuilderAutomatinAgent);
                    int height_before_drag = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.DragTableOfContentHandle(bookBuilderAutomatinAgent, 0, 200);
                    int height_after_drag = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    int height_after_undo = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(height_after_undo.Equals(height_before_drag), "Count got match");
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    int height_after_redo = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(height_after_redo.Equals(height_after_drag), "Count got match");
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    BookBuilderCommonMethods.DragTableOfContentHandle(bookBuilderAutomatinAgent, 0, -200);
                    NotebookCommonMethods.ClickToUndo(bookBuilderAutomatinAgent);
                    int heightafterundowhencontract = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(heightafterundowhencontract.Equals(height_after_redo), "Count got match");
                    NotebookCommonMethods.ClickToRedo(bookBuilderAutomatinAgent);
                    int heightafterredowhencontract = BookBuilderCommonMethods.GetHeightOfTable(bookBuilderAutomatinAgent);
                    Assert.IsTrue(heightafterredowhencontract.Equals(height_before_drag), "Count got match");
                    NotebookCommonMethods.ClickOnClearAllButton(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnYesbutton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);
                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(45844)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyShareButtonAtBookbuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC45844: Ensure that the Share button location and functionality for book builder"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, "BookTitle", "BookAuthor");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    int currentBookPosition = Int32.Parse(BookBuilderCommonMethods.GetCurrentBookPosition(bookBuilderAutomatinAgent, "BookTitle"));
                    int shareButtonPosition = BookBuilderCommonMethods.GetShareButtonPosition(bookBuilderAutomatinAgent);
                    int editButtonPosition = BookBuilderCommonMethods.GetEditButtonPosition(bookBuilderAutomatinAgent);
                    Assert.IsTrue((currentBookPosition - 38).Equals(shareButtonPosition - 96), "Fail if share would not display for centered book");
                    Assert.IsTrue(editButtonPosition < shareButtonPosition, "Fail if edit button would not be left of shre button");
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnCancelShare(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(45846)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyShareConfirmationAlertAtBookbuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC45846: verify the Share Confirmation Alert after user Taps on the Green Check icon from Share Dialog box"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, "BookTitle", "BookAuthor");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnAcceptButtonOfShare(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySentText(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnCancelShare(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBuilderMainScreen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.TapOnScreen(bookBuilderAutomatinAgent, 1000, 300);
                    BookBuilderCommonMethods.VerifyBookBuilderMainScreen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(bookBuilderAutomatinAgent, true);
                    bookBuilderAutomatinAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    LoginCommonMethods.VerifyNoInternetMessage(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTest")]
        [WorkItem(45845)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyShareDialogBoxAtBookbuilder()
        {
            using (bookBuilderAutomatinAgent = new AutomationAgent("TC45845: Verify the Share Dialog Box after user Taps on the 'Share' button below a Book"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(bookBuilderAutomatinAgent);
                    LoginCommonMethods.TeacherAdminLogin(bookBuilderAutomatinAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ClickOnNewBookIconOnLeftCorner(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.CreateBook(bookBuilderAutomatinAgent, "BookTitle", "BookAuthor");
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyScrollableTeacherListAtSharePopup(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyUserCanSelectOnlyOneTeacher(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnAcceptButtonOfShare(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySentText(bookBuilderAutomatinAgent);
                    NotebookCommonMethods.ClickOnCancelButton(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnShareButton(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifySharePopupOpen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnCancelShare(bookBuilderAutomatinAgent);
                    BookBuilderCommonMethods.VerifyBookBuilderMainScreen(bookBuilderAutomatinAgent);
                    NavigationCommonMethods.ClickOnBackIcon(bookBuilderAutomatinAgent);
                    LoginCommonMethods.Logout(bookBuilderAutomatinAgent);

                }

                catch (Exception ex)
                {
                    bookBuilderAutomatinAgent.Sleep(2000);
                    bookBuilderAutomatinAgent.AddSteptoSeeTestReport(ex.Message, false);
                    bookBuilderAutomatinAgent.CloseApplication();
                    throw;
                }
            }
        }
    }
}
