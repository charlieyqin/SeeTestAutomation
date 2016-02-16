using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;
using System.Reflection;
using System.Configuration;
using System.Net;


using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class BackUpAndRestore
    {
        public AutomationAgent BackUpAndRestoreAutomationAgent;
        
        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(53558), WorkItem(53559), WorkItem(53560), WorkItem(53561), WorkItem(53562), WorkItem(53563), WorkItem(53564), WorkItem(53565)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyCriticalBackUpAndRestoredAssetsForNoteBookAndBookBuiler()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53558,TC53559,TC53560,TC53561,TC53562,TC53563,TC53564,TC53565: Verify book builder & Notebook with inserted assets - backed up and restored correctly"))
            {
                try
                {

                    BackUpAndRestoreCommonMethods.InitialStepsToReachBookBuilder(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    string bookName = "Portrait Book1";
                    string authorName = "Portrait Author1";
                    BackUpAndRestoreCommonMethods.CreatingBookInBookBuilder(BackUpAndRestoreAutomationAgent, bookName, authorName,"A");
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 2);
                    string bookName2 = "Landscape Book2";
                    string authorName2 = "Landscape Author2";
                    BackUpAndRestoreCommonMethods.CreatingBookInBookBuilder(BackUpAndRestoreAutomationAgent, bookName2, authorName2, "B");
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 1);
                    BackUpAndRestoreCommonMethods.DeleteAssetsinBookBuilder(BackUpAndRestoreAutomationAgent, bookName2, authorName2);
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 3);

                    //Creating,Editing & Deleting Notebook
                    TaskInfo taskInfo = Login.GetLogin("TeacherAdbul").GetTaskInfo("ELA", "Notebook");
                    String[] UnitStatus = BackUpAndRestoreCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, UnitStatus[0]);
                    BackUpAndRestoreCommonMethods.addInteractiveImageAndAudioInNoteBook(BackUpAndRestoreAutomationAgent,2);
                    int deletedAssetsPage = BackUpAndRestoreCommonMethods.DeleteAssetsInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);



                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachBookBuilder(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    String bookTile = BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent);
                    while (!BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent).Contains(bookName2))
                    {
                        BackUpAndRestoreAutomationAgent.Swipe(Direction.Left, 500);
                    }
                    BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
                    Assert.IsFalse(InboxCommonMethods.VerifyAudioCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 3);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53560", true);
                 
                    while (!BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent).Contains(bookName))
                    {
                        BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
                    }
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 3);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53558", true);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53559", true);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53561", true);

                    //Notebook verification in Device2
                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    int pageNumber = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    while((pageNumber<deletedAssetsPage)&&(BackUpAndRestoreAutomationAgent.IsElementFound("NotebookView", "PageArrowRight")))
                    {

                        BackUpAndRestoreAutomationAgent.Click("NotebookView", "PageArrowRight");

                    }
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyAudioCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    Assert.IsFalse(BackUpAndRestoreCommonMethods.VerifyInteractiveInNotebook(BackUpAndRestoreAutomationAgent));
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53564", true);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(BackUpAndRestoreAutomationAgent);

                    NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);

                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyAudioCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    Assert.IsTrue(BackUpAndRestoreCommonMethods.VerifyInteractiveInNotebook(BackUpAndRestoreAutomationAgent));
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53562", true);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53563", true);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53565", true);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(BackUpAndRestoreAutomationAgent);                    
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);                    
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


      /*  [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(53559)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyInsertedAssetsBackedUpInExistingBook()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53559: Verify A new book builder with inserted assets - backed up and restored correctly"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("BackUpAndRestoreCredentials"));
                    NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);
                    string bookName = "Portrait Book2";
                    string authorName = "Portrait Author2";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookIconInPageMiddle(BackUpAndRestoreAutomationAgent, "A");

                    BookBuilderCommonMethods.CreateBook(BackUpAndRestoreAutomationAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);                                       
                    BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
                    
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
                    BackUpAndRestoreCommonMethods.AddingImageAndAudioAssets(BackUpAndRestoreAutomationAgent);                  

                    ArrayList assetWorkIdInDevice1 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("BackUpAndRestoreCredentials"));
                    NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);
                    
                    string bookNameInDevice2 = BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent);
                    if (!bookNameInDevice2.Equals(bookName))
                        BackUpAndRestoreCommonMethods.VerifyBookName(BackUpAndRestoreAutomationAgent, bookName);
                    BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
                    ArrayList assetWorkIdInDevice2 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    Assert.AreEqual(assetWorkIdInDevice2[0], assetWorkIdInDevice1[0], "Audio Asset Not displayed");
                    Assert.AreEqual(assetWorkIdInDevice2[1], assetWorkIdInDevice1[1], "Image Asset Not displayed");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);                    

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(53560)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDeletedAssetsAreNotBackedUpInExistingBook()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53560: Verify An existing book builder without inserted assets - still backed up and restored correctly"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("BackUpAndRestoreCredentials"));
                    NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);

                    string bookName = "Portrait Book3";
                    string authorName = "Portrait Author3";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookButtonInLeftCorner(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.CreateBook(BackUpAndRestoreAutomationAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    
                    
                    BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
                    
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");

                    BackUpAndRestoreCommonMethods.AddingImageAndAudioAssets(BackUpAndRestoreAutomationAgent);                  
                    NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);                               
                    
                                   
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.CloseApplication();

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("BackUpAndRestoreCredentials"));
                    NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);
                    
                    string bookNameInDevice3 = BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent);
                    if (!bookNameInDevice3.Equals(bookName))
                        BackUpAndRestoreCommonMethods.VerifyBookName(BackUpAndRestoreAutomationAgent,bookName);

                    string AuthorNameInDevice3 = BackUpAndRestoreCommonMethods.GetAuthorNameFromBook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(bookName.Equals(bookNameInDevice3), "Book is Restored");
                    Assert.IsTrue(authorName.Equals(AuthorNameInDevice3), "AuthorName is Restored");                    
                    
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(53561)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyNewlyCreatedBookBackedUp()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53561: Verify A new book builder without inserted assets - still backed up and restored correctly"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("BackUpAndRestoreCredentials"));
                    NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);

                    string bookName = "Portrait Book4";
                    string authorName = "Portrait Author4";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookButtonInLeftCorner(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.CreateBook(BackUpAndRestoreAutomationAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                                                                                                            
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.CloseApplication();

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("BackUpAndRestoreCredentials"));
                    NavigationCommonMethods.ClickOnSystemTray(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(BackUpAndRestoreAutomationAgent);

                    string bookNameInDevice4 = BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent);
                    if (!bookNameInDevice4.Equals(bookName))
                        BackUpAndRestoreCommonMethods.VerifyBookName(BackUpAndRestoreAutomationAgent, bookName);

                    string AuthorNameInDevice4 = BackUpAndRestoreCommonMethods.GetAuthorNameFromBook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(bookName.Equals(bookNameInDevice4), "Book is Restored");
                    Assert.IsTrue(authorName.Equals(AuthorNameInDevice4), "AuthorName is Restored");                                    
                                                           
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }*/

        //Notebook Flow

    /*    [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51701)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyInsertedAssetsInNotebookBackedUpForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51701: Create Notebook_Save Locally_Teacher"))
            {
                try
                {


                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.SendText(BackUpAndRestoreAutomationAgent, "Doctor");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent,"BackUpAndRestoreCredentials");
                    int pagecountafterRelogin = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountafteraddition));

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.Sleep();
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                                 
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51712)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyInsertedAssetsInNotebookBackedUpForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51712: Create Notebook_Save Locally_Student"))
            {
                try
                {


                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnTextButton(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickInsideTextBox(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.SendText(BackUpAndRestoreAutomationAgent, "Doctor");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountafterRelogin = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountafteraddition));

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.Sleep();
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentUmontee");
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51707)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyNotebookRestoreForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51707: reate Notebook_Restore Locally_Teacher"))
            {
                try
                {


                    //Verification1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    SmokeTests st = new SmokeTests();
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

                    //Verification2
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

                    //Verification3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51713)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyNotebookRestoreForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51713: reate Notebook_Restore Locally_Teacher"))
            {
                try
                {

                    //Verification1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    SmokeTests st = new SmokeTests();
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

                    //Verification2
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent,"Doctor");
                    

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

                    //Verification3

                    
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);               
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51710)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyNotebookRestoreRemotelyForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51710: Create Notebook_Restore Remotely_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                                    
                          
                                 
                    //Step2
                    
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");

                    

                    //Step3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Lawyer");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Engineer"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);                    
                                        
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51715)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyNotebookRestoreRemotelyForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51715: Create Notebook_Restore Remotely_Student"))
            {
                try
                {

                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));



                    //Step2

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();


                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");



                    //Step3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Lawyer");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Engineer"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Doctor"), "Data Saved Not Found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51821)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDeletedNotebookForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51821: Delete Notebook_Save Locally_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountaftersubtraction = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountaftersubtraction.Equals(pagecountbeforeaddition));

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.Sleep();
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    int pagecountafterAppRelaunch = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountaftersubtraction.Equals(pagecountbeforeaddition));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterTeacher2Login = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterTeacher2Login.Equals(pagecountbeforeaddition));

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                                                               
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterdeleteInOfflineMode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterdeleteInOfflineMode.Equals(pagecountbeforeaddition));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);                    
                    
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51837)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDeletedNotebookForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51837: Delete Notebook_Save Locally_Student"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountaftersubtraction = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountaftersubtraction.Equals(pagecountbeforeaddition));

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.Sleep();
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    int pagecountafterAppRelaunch = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountaftersubtraction.Equals(pagecountbeforeaddition));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentUmontee");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterTeacher2Login = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterTeacher2Login.Equals(pagecountbeforeaddition));

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterdeleteInOfflineMode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterdeleteInOfflineMode.Equals(pagecountbeforeaddition));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51822)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDeletedNotebookRestoreForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51822: Delete Notebook_Restore Locally_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition ));                   
                                                       

                    //Verification2
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");

                    int pagecountafterdeletinginOfflinemode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterdeletinginOfflinemode.Equals(pagecountbeforeaddition));
                                               

                    //Verification3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecount = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(pagecount.Equals(pagecountafterdeletinginOfflinemode + 1));
                   
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51838)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyDeletedNotebookRestoreForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51838: Delete Notebook_Restore Locally_Student"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);

                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition));


                    //Verification2
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");

                    int pagecountafterdeletinginOfflinemode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterdeletinginOfflinemode.Equals(pagecountbeforeaddition));


                    //Verification3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecount = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(pagecount.Equals(pagecountafterdeletinginOfflinemode + 1));

                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51823)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void DeleteNotebookRestoreRemotelyForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51823: Delete Notebook_Restore Remotely_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition));



                    //Step2

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();


                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");



                    //Step3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Lawyer");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Lawyer"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);                    
                    Assert.IsTrue(NotebookCommonMethods.VerifyArrowsNotPresentInNotebookCanvas(BackUpAndRestoreAutomationAgent), "Previous and next arrow found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51839)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void DeleteNotebookRestoreRemotelyForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51839: Delete Notebook_Restore Remotely_Student"))
            {
                try
                {

                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition));



                    //Step2

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();


                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");



                    //Step3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Lawyer");
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Lawyer"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyArrowsNotPresentInNotebookCanvas(BackUpAndRestoreAutomationAgent), "Previous and next arrow found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51825)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void EditNotebookForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51825: Edit Notebook_Restore Remotely_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));



                    //Step2

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.Sleep();
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    int pagecountafterAppRelaunch = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterAppRelaunch.Equals(pagecountbeforeaddition));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterTeacher2Login = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterTeacher2Login.Equals(pagecountbeforeaddition + 1));

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterEditInOfflineMode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterEditInOfflineMode.Equals(pagecountafterTeacher2Login + 2));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);                    
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51841)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void EditNotebookForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51841: Edit Notebook_Restore Remotely_Student"))
            {
                try
                {

                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));



                    //Step2

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.Sleep();
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreAutomationAgent.Sleep();

                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    int pagecountafterAppRelaunch = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterAppRelaunch.Equals(pagecountbeforeaddition));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentUmontee");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountafterTeacher2Login = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterTeacher2Login.Equals(pagecountbeforeaddition + 1));

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafterEditInOfflineMode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterEditInOfflineMode.Equals(pagecountafterTeacher2Login + 2));
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);                    
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51826)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void EditNotebookRestoreForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51826: Edit Notebook_Restore Remotely_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    

                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));


                    //Verification2
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");

                    int pagecountafterEditinOfflinemode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterEditinOfflinemode.Equals(pagecountafteraddition + 1));


                    //Verification3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecount = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(pagecount.Equals(pagecountafterEditinOfflinemode));

                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51842)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void EditNotebookRestoreForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51842: Edit Notebook_Restore Remotely_Student"))
            {
                try
                {

                    SmokeTests st = new SmokeTests();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");


                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));


                    //Verification2
                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");

                    int pagecountafterEditinOfflinemode = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafterEditinOfflinemode.Equals(pagecountafteraddition + 1));


                    //Verification3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecount = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(pagecount.Equals(pagecountafterEditinOfflinemode));

                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51827)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void EditNotebookRestoreRemotelyForTeacher()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51827: Edit Notebook_Restore Remotely_Teacher"))
            {
                try
                {
                    SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));



                    //Step2

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();


                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");



                    //Step3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Lawyer");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Engineernote"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent,"Doctornote"), "Previous and next arrow found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51843)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void EditNotebookRestoreRemotelyForStudent()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51843: Edit Notebook_Restore Remotely_Student"))
            {
                try
                {

                     SmokeTests st = new SmokeTests();


                    //Step1
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Doctor");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    int pagecountafteraddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pagecountafteraddition.Equals(pagecountbeforeaddition + 1));



                    //Step2

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();


                    NavigationCommonMethods.ClickOnNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Engineer");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "prsnk101");



                    //Step3


                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Lawyer");
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "note");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSophia");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent, "Engineernote"), "Data Saved Not Found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifySavedData(BackUpAndRestoreAutomationAgent,"Doctornote"), "Previous and next arrow found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);

                }

                
                     

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53563)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNotebookWithInsertedAssets ()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53563: Verify that the functional behavior of GO should be similar to the Interactives"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(BackUpAndRestoreAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(BackUpAndRestoreAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(BackUpAndRestoreAutomationAgent);
                    MediaLibraryCommonMethods.DragMediaLibraryScreenTillIntercative(BackUpAndRestoreAutomationAgent);
                    MediaLibraryCommonMethods.ClickToOpenInteractive(BackUpAndRestoreAutomationAgent);

                    InteractiveCommonMethods.VerifyInteractivePlayer(BackUpAndRestoreAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnGreenIconInBookLogCameraMode(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyInteractiveInNotebook(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 2);

                    //Adding Image
                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent);

                    //Adding Audio
                    BackUpAndRestoreCommonMethods.AddAudioInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    ArrayList assetWorkIdInDevice1 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(BackUpAndRestoreAutomationAgent, 1);

                    //Launch Device2
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    ArrayList assetWorkIdInDevice2 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    Assert.AreEqual(assetWorkIdInDevice2[0], assetWorkIdInDevice1[0], "Audio Asset Not displayed");
                    Assert.AreEqual(assetWorkIdInDevice2[1], assetWorkIdInDevice1[1], "Image Asset Not displayed");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent); 
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53564)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNotebookWithDeletedInsertedAssets()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53564: An existing notebook without inserted assets - still backed up and restored correctly"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.RemoveAudio(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.RemoveImage(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickToSelectIntercativeImageFromNotebook(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnRemoveButton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    int pageCount = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                    

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    if (pageCountAtDevice2 == pageCount)
                    {
                        NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                        BackUpAndRestoreCommonMethods.verifyAssets(BackUpAndRestoreAutomationAgent);
                    }
                    else
                        Assert.Fail("Sync functionality is not working");
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53565)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNewNotebookWithoutInsertedAssets()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53565: A new notebook without inserted assets - still backed up and restored correctly"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    NotebookCommonMethods.ClicktoAddPageFromNotebookBrowser(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    int pageCount = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);


                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pageCount.Equals(pageCountAtDevice2),"Count didn't match");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                        
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53562)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNewNotebookWithInsertedAssets()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53562: A new notebook with inserted assets - backed up and restored correctly"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachBookBuilder(BackUpAndRestoreAutomationAgent,"TeacherELA");
                    string bookName = "Portrait Book562";
                    string authorName = "Portrait Author562";
                    BackUpAndRestoreCommonMethods.ClickOnNewBookButtonInLeftCorner(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.ChoosePortraitBookShape(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.CreateBook(BackUpAndRestoreAutomationAgent, bookName, authorName);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnSpecificPageNumber(BackUpAndRestoreAutomationAgent, "1");
                    BackUpAndRestoreCommonMethods.AddingImageAndAudioAssets(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.ClickOnLogoutButton(BackUpAndRestoreAutomationAgent);
                   
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachBookBuilder(BackUpAndRestoreAutomationAgent,"TeacherELA");
                    string bookNameInDevice562 = BackUpAndRestoreCommonMethods.GetTitleFromBook(BackUpAndRestoreAutomationAgent);
                    if (!bookNameInDevice562.Equals(bookName))
                        BackUpAndRestoreCommonMethods.VerifyBookName(BackUpAndRestoreAutomationAgent, bookName);

                    string AuthorNameInDevice562 = BackUpAndRestoreCommonMethods.GetAuthorNameFromBook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(bookName.Equals(bookNameInDevice562), "Book is Restored");
                    Assert.IsTrue(authorName.Equals(AuthorNameInDevice562), "AuthorName is Restored");                                                                                        
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }*/

        //Clubbing of US9672

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(1)]
        [WorkItem(51701), WorkItem(51712), WorkItem(51821), WorkItem(51825), WorkItem(51837), WorkItem(51842)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyCriticalNotebookBehaviorOfTeacherAndStudentwithinDevice1()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51701,TC51712,TC51821,TC51825,TC51837,TC51842: Create,Edit & Delete Notebook functionality for Teacher & Student"))
            {
                try
                {


                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "Edited Page");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Created Page");
                    int deletedPage = BackUpAndRestoreCommonMethods.DeleteNotebookPage(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition, deletedPage, "Edited Page", "Created Page");

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.LaunchApp();


                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition, deletedPage, "Edited Page", "Created Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Student Login
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    int spagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                   
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "Edited Page");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Created Page");
                    int sdeletedPage = BackUpAndRestoreCommonMethods.DeleteNotebookPage(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition, sdeletedPage, "Edited Page", "Created Page");

                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition, deletedPage, "Edited Page", "Created Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Teacher Login

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition, deletedPage, "Edited Page", "Created Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Student Login
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition, sdeletedPage, "Edited Page", "Created Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Teacher Login to Create Offline Page for Verification
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent,"TeacherAbdul");
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    BackUpAndRestoreCommonMethods.VerifyOfflineBehaviorforNotebook(BackUpAndRestoreAutomationAgent,"TeacherAbdul");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                    

                    //Student Login to Create Offline Page for Verification
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyOfflineBehaviorforNotebook(BackUpAndRestoreAutomationAgent,"StudentSec01");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(2)]
        [WorkItem(51707), WorkItem(51713), WorkItem(51822), WorkItem(51826), WorkItem(51838), WorkItem(51841), WorkItem(51843)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyImportantOfflineOnlineDeleteAppFunctionalityOfTeacherAndStudentInDevice1And2()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51707,TC51713,TC51822,TC51826,TC51838,TC51841,TC51843: Create,Edit & Delete Notebook functionality in Offline,Delete App & go Online for Teacher & Student "))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    int pagecountbeforeaddition1 = pagecountbeforeaddition + 1;
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    int tdeletedPageinOffline = BackUpAndRestoreCommonMethods.VerifyOfflineBehaviorforNotebook(BackUpAndRestoreAutomationAgent, "TeacherAdbul");                                   
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    int spagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    int spagecountbeforeaddition1 = spagecountbeforeaddition + 1;
                    int sdeletedPageinOffline = BackUpAndRestoreCommonMethods.VerifyOfflineBehaviorforNotebook(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);                
                    
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);

                    SmokeTests st = new SmokeTests();
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "ccsocdct");
                   
                    

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition1,tdeletedPageinOffline,"Edited Offline Page", "Created Offline Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition1, sdeletedPageinOffline, "Edited Offline Page", "Created Offline Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition1, tdeletedPageinOffline, "Edited Offline Page", "Created Offline Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyCreateEditAndDeletedPages(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition1, sdeletedPageinOffline, "Edited Offline Page", "Created Offline Page");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }        
                  
    

               
            
        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [Priority(2)]
        [WorkItem(51710), WorkItem(51715), WorkItem(51823), WorkItem(51827), WorkItem(51839)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyImportantOfflineDeleteOnlineAppFunctionalityOfTeacherAndStudentInDevice1()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC51710,TC51715,TC51823,TC51827,TC51839: Create,Edit & Delete Notebook functionality in Offline,go Online & Delete App for Teacher & Student "))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    int pagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "Edited Page");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Created Page");
                    int deletedPage = BackUpAndRestoreCommonMethods.DeleteNotebookPage(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition);
                    BackUpAndRestoreCommonMethods.DeleteStampInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    int spagecountbeforeaddition = NotebookCommonMethods.GetCountOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.EditNotebook(BackUpAndRestoreAutomationAgent, "Edited Page");
                    BackUpAndRestoreCommonMethods.CreateDataInNoteBookCanvas(BackUpAndRestoreAutomationAgent, "Created Page");
                    int sdeletedPage = BackUpAndRestoreCommonMethods.DeleteNotebookPage(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition);
                    BackUpAndRestoreCommonMethods.DeleteStampInNotebookCanvas(BackUpAndRestoreAutomationAgent);


                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();
                    int sdeletedPageInOffline = BackUpAndRestoreCommonMethods.VerifyOfflineBehaviorforNotebook(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    int deletedPageInOffline = BackUpAndRestoreCommonMethods.VerifyOfflineBehaviorforNotebook(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    SmokeTests st = new SmokeTests();
                    st.UninstallAppAndInstallLatestK1Dev();
                    NavigationCommonMethods.EnterConfigCodeInDeviceAppsettings(BackUpAndRestoreAutomationAgent, "ccsocdct");
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, false);
                    

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    BackUpAndRestoreCommonMethods.VerifyOfflineCreateEditAndDeletedPagesInDevices(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition, deletedPageInOffline);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyOfflineCreateEditAndDeletedPagesInDevices(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition, sdeletedPageInOffline);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "TeacherAbdul");
                    BackUpAndRestoreCommonMethods.VerifyOfflineCreateEditAndDeletedPagesInDevices(BackUpAndRestoreAutomationAgent, pagecountbeforeaddition, deletedPageInOffline);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "StudentSec01");
                    BackUpAndRestoreCommonMethods.VerifyOfflineCreateEditAndDeletedPagesInDevices(BackUpAndRestoreAutomationAgent, spagecountbeforeaddition, sdeletedPageInOffline);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);                    

                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }        
       

        //Conflict Resolution-US10291

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53931), WorkItem(53933), WorkItem(53934), WorkItem(53935)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyCriticalFunctionalityOfNotebookConflictInDevice1And2()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53931,TC53933,TC53934,TC53935:  verify the Sync functionality for a newly created Page 1 from Device 1 to Device 2 and also Sync for same edited page from Device 2 to Device 1"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);

                    NotebookCommonMethods.ClickOnGraphicTool(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnNumberLineButton(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandToolActive(BackUpAndRestoreAutomationAgent), "Tool not active");
                    string[] pos = NotebookCommonMethods.GetPositionOfNumberLineTool(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickonCrayonButton(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(BackUpAndRestoreAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.DrawLineImage(1, 3);
                    int pageCountAtDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    if(pageCountAtDevice2.Equals(pageCountAtDevice1))
                    {
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNumberLineInNotebook(BackUpAndRestoreAutomationAgent), "Number line not found on notebook");
                    Assert.IsTrue(NotebookCommonMethods.VerifyPhotoCapturedOnNotebook(BackUpAndRestoreAutomationAgent));
                    BookBuilderCommonMethods.SendText(BackUpAndRestoreAutomationAgent, "TEST");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    }

                    NotebookCommonMethods.ClickOnPrevArrow(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);                                                  
                    
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice1();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice3 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pageCountAtDevice3.Equals(pageCountAtDevice2 - 1), "Count didn't match");
                    Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowInNotebookBrowser(BackUpAndRestoreAutomationAgent));
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53933", true);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53934", true);                    
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTableAndDataSaved(BackUpAndRestoreAutomationAgent, "TEST"), "Data is not saved");
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53931", true);
                    BackUpAndRestoreAutomationAgent.WaitForElement("StudentSetup", "ErrorPopUpCloseIcon");
                    Assert.IsTrue(BackUpAndRestoreCommonMethods.VerifyNotebookUpdatedPopup(BackUpAndRestoreAutomationAgent), "Pop-Up Not Displayed");
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                    int pageRefreshed = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53935", true);
                    Assert.IsTrue(pageRefreshed.Equals(1), "Page1 is not refreshed");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                    
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


      /*  [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53935)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyInfoMessageShownafterNotebookUpdated()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53935:  verify User within the Notebook being replaced on Device 1"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    int CountAfter = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(BackUpAndRestoreAutomationAgent, CountBefore);
                    Assert.IsTrue(CountAfter.Equals(CountBefore), "Page Count didn't match");
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(BackUpAndRestoreAutomationAgent);

                    //Adding Image as Media Asset
                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);

                    //Drawing Layer
                    string[] pos = NotebookCommonMethods.GetPositionOfNumberLineTool(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickonCrayonButton(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(NotebookCommonMethods.VerifyHandToolActive(BackUpAndRestoreAutomationAgent), "Tool not active");
                    NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.DrawLineImage(Int32.Parse(pos[0]), Int32.Parse(pos[1]));
                    NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, Int32.Parse(pos[0]), Int32.Parse(pos[1]));

                    //Adding Table Tool

                    NotebookCommonMethods.ClickOnGraphicTool(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(CountBefore.Equals(pageCountAtDevice2), "Count didn't match");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    ArrayList assetWorkIdInDevice2 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);                    
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(BackUpAndRestoreCommonMethods.VerifyNotebookUpdatedPopup(BackUpAndRestoreAutomationAgent), "Pop-Up Not Displayed");
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    ArrayList assetWorkIdInDevice1 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    Assert.AreEqual(assetWorkIdInDevice2[0], assetWorkIdInDevice1[0], "Image Asset Not displayed");
                    Assert.AreEqual(assetWorkIdInDevice2[1], assetWorkIdInDevice1[1], "Image Asset Not displayed");
                    Assert.IsTrue(BackUpAndRestoreCommonMethods.VerifyTableTool(BackUpAndRestoreAutomationAgent));
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }*/

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53938), WorkItem(53106)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyImportantFunctionalityofOnlineOfflineNotebook()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53938,TC53106:  verify Device 1(online) and Device 2 (Offline)_Scenario 1_US10291"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int CountBefore = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.addMultiplePageNumbers(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    int CountAfter = NotebookCommonMethods.GetCountOfNotebookPagesInNotebookEditor(BackUpAndRestoreAutomationAgent, CountBefore);
                    Assert.IsTrue(CountAfter.Equals(CountBefore + 3), "Page Count didn't match");
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(BackUpAndRestoreAutomationAgent);

                    //Adding Image as Media Asset
                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Set Device2
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();                                                    

                    //Get Notebook Pages Count
                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(CountAfter.Equals(pageCountAtDevice2), "Count didn't match");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);

                    //Adding Table Tool

                    NotebookCommonMethods.ClickOnGraphicTool(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnTableTool(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);

                    //Adding multiple pages in device2
                    BackUpAndRestoreCommonMethods.addMultiplePageNumbers(BackUpAndRestoreAutomationAgent);
                    int pageCountAtDevice3 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Setting Device1
                    BackUpAndRestoreAutomationAgent.LaunchDevice1();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    BackUpAndRestoreAutomationAgent.Sleep(15000);
                    if (BackUpAndRestoreCommonMethods.VerifyNotebookUpdatedPopup(BackUpAndRestoreAutomationAgent))
                    {
                        LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                        int pageRefreshed = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                        Assert.IsTrue(pageRefreshed.Equals(1), "Page1 is not refreshed");
                    }
                    int pageCountAtDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    
                    Assert.IsTrue(pageCountAtDevice1.Equals(pageCountAtDevice2 + 3), "Page Count didn't match");
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54106", true);
                    Assert.IsFalse(BackUpAndRestoreCommonMethods.VerifyNotebookUpdatedPopup(BackUpAndRestoreAutomationAgent), "Pop-Up Not Displayed");                    

                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(BackUpAndRestoreCommonMethods.VerifyTableTool(BackUpAndRestoreAutomationAgent));
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC53938", true);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

       /* [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(54106)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyNumberOfPagesInNotebook()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC54106:  Conflict on same unit notebooks with different notebook IDs-Notebook Created in Online Device First"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    
                    BackUpAndRestoreCommonMethods.addMultiplePageNumbers(BackUpAndRestoreAutomationAgent);
                    int CountAfterAddingPages = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Set Device2
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    //Get Notebook Pages Count
                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(CountAfterAddingPages.Equals(pageCountAtDevice2), "Count didn't match");
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.addMultiplePageNumbers(BackUpAndRestoreAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);


                    //Setting Device1
                    BackUpAndRestoreAutomationAgent.LaunchDevice1();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pageCountAtDevice1.Equals(pageCountAtDevice2 + 3), "Page Count didn't match");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }*/

      /*  [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53933)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyDeletedPageSyncWithDevice1And2()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53933:  verify the Sync functionality for a newly created Page 1 from Device 1 to Device 2 and also Sync for same edited page from Device 2 to Device 1"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");                    
                    NavigationCommonMethods.ClickToOpenNotebook(BackUpAndRestoreAutomationAgent);                    
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(BackUpAndRestoreAutomationAgent);

                    //Adding Image as Media Asset
                    BackUpAndRestoreCommonMethods.AddImageInNotebookCanvas(BackUpAndRestoreAutomationAgent);
                    ArrayList assetWorkIdInDevice1 = BackUpAndRestoreCommonMethods.GetNotebookWorkId(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);
                                                         
                    //Setting Device2
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountAtDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    if (pageCountAtDevice1<3)
                    {
                        BackUpAndRestoreAutomationAgent.Click("NotebookView", "PageArrowRight");
                    }
                    else if (pageCountAtDevice1 > 3)
                    {
                        BackUpAndRestoreAutomationAgent.Click("NotebookView", "PageArrowLeft");
                    }

                    int pageCountAtDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pageCountAtDevice2.Equals(3), "Page Number is not 3");
                                      
                    BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);
                    int pageCountAfterDeletion = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice1();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountInDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pageCountInDevice1.Equals(pageCountAfterDeletion), "Count didn't match");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(53934)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyDeletingSpecificPageSyncWithDevice1And2()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC53934:  Sync with Device 1 and 2 for Deleted Page 3"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    BackUpAndRestoreCommonMethods.addMultiplePageNumbers(BackUpAndRestoreAutomationAgent);
                    int currentPageCount = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Console.WriteLine(currentPageCount);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Setting Device2
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int currentPageCountInDevice2 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Console.WriteLine(currentPageCountInDevice2);
                    if (currentPageCountInDevice2 == 3)
                    {
                        BackUpAndRestoreCommonMethods.DragElementToTrash(BackUpAndRestoreAutomationAgent);
                        NotebookCommonMethods.ClickOnYesbutton(BackUpAndRestoreAutomationAgent);        
                    }
                        LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachNotebookBrowser(BackUpAndRestoreAutomationAgent, "BackUpAndRestoreCredentials");
                    int pageCountInDevice1 = NotebookCommonMethods.GetPositionOfNotebookPages(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(pageCountInDevice1.Equals(currentPageCountInDevice2 - 1), "Count didn't match");
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }*/

        //US10519

        [TestMethod()]
        [TestCategory("BackUpAndRestore")]
        [WorkItem(54729), WorkItem(54734)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyCriticalBackUpAndRestoreFunctionalityOfeReaderAnnotation()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC54729,TC54734:  Sync with Device 1 and 2 for newly created annotation in Online Mode"))
            {
                try
                {
                    BackUpAndRestoreCommonMethods.InitialStepsToReachEreader(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    EreaderCommonMethod.ClickToEditEreader(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 1024, 500);                                     
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    //Setting Device2
                    BackUpAndRestoreAutomationAgent.LaunchDevice2();

                    BackUpAndRestoreCommonMethods.InitialStepsToReachEreader(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    Assert.IsTrue(EreaderCommonMethod.VerifyGoogleEyeClose(BackUpAndRestoreAutomationAgent), "Googly eyes found");
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54729", true);
                    //TC54734

                    bool TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, TurnWifiOff);
                    BackUpAndRestoreAutomationAgent.LaunchApp();

                    NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 1024, 500);
                    EreaderCommonMethod.ClickToEditEreader(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreCommonMethods.ClickOnStampOption(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickToChooseStampCone(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 600, 400);
                    NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(BackUpAndRestoreAutomationAgent), "Dashed line not found");
                    NavigationCommonMethods.ClickOnBackIcon(BackUpAndRestoreAutomationAgent);                    
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    NavigationCommonMethods.ChangeWiFiConnectivity(BackUpAndRestoreAutomationAgent, true);

                    BackUpAndRestoreAutomationAgent.LaunchDevice1();
                    BackUpAndRestoreCommonMethods.InitialStepsToReachEreader(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    EreaderCommonMethod.ClickToEditEreader(BackUpAndRestoreAutomationAgent);
                    NotebookCommonMethods.ClickOnHandButton(BackUpAndRestoreAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(BackUpAndRestoreAutomationAgent, 600, 400);
                    Assert.IsTrue(NotebookCommonMethods.VerifySelectedStampWithDashedLine(BackUpAndRestoreAutomationAgent), "Dashed line not found");
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54734", true);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);                   
                }

                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    BackUpAndRestoreAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }
        //US10439

        

        [TestMethod()]
        [TestCategory("InboxTest"), TestCategory("US10439")]
        [WorkItem(54630), WorkItem(54631)]        
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyCriticalTeacherReviewedItemRestoredForNewAndExisting()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC54630,TC54631: Reviewed Items Restore - Create New Review in Online Mode"))
            
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(BackUpAndRestoreAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(BackUpAndRestoreAutomationAgent,"1");
                    InboxCommonMethods.addCommentToStudent(BackUpAndRestoreAutomationAgent);
                    InboxCommonMethods.addAudioNoteToStudent(BackUpAndRestoreAutomationAgent);
                    InboxCommonMethods.addStickerSmiley(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                    BackUpAndRestoreAutomationAgent.LaunchDevice2();
                    
                    InboxCommonMethods.NavigateTillInbox(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(BackUpAndRestoreAutomationAgent, "1");
                    Assert.IsTrue(NotebookCommonMethods.VerifyStickerOnNotebook(BackUpAndRestoreAutomationAgent), "Sticker not found on notebook");
                    NotebookCommonMethods.ClickOnCommentButton(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(InboxCommonMethods.VerifyEditCommentOverlay(BackUpAndRestoreAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                    InboxCommonMethods.ClickOnRecordIcon(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(BackUpAndRestoreCommonMethods.VerifyReviewAudioWindow(BackUpAndRestoreAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54630", true);

                    //TestCase-2                    
                    InboxCommonMethods.addCommentToStudent(BackUpAndRestoreAutomationAgent);
                    InboxCommonMethods.addAudioNoteToStudent(BackUpAndRestoreAutomationAgent);
                    InboxCommonMethods.addStickerSmiley(BackUpAndRestoreAutomationAgent);
                    int countOfAssetIdsInDevice2 = BackUpAndRestoreCommonMethods.GetCountOfWorkIds(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.LaunchDevice1();
                    InboxCommonMethods.NavigateTillInbox(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(BackUpAndRestoreAutomationAgent,"1");
                    int countOfAssetIdsInDevice1 = BackUpAndRestoreCommonMethods.GetCountOfWorkIds(BackUpAndRestoreAutomationAgent);
                    Assert.IsTrue(countOfAssetIdsInDevice2.Equals(countOfAssetIdsInDevice1));

                    NotebookCommonMethods.ClickOnCommentButton(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(InboxCommonMethods.VerifyEditCommentOverlay(BackUpAndRestoreAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);

                    InboxCommonMethods.ClickOnRecordIcon(BackUpAndRestoreAutomationAgent);
                    Assert.IsFalse(BackUpAndRestoreCommonMethods.VerifyReviewAudioWindow(BackUpAndRestoreAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54631", true);
                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                }
                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }

       /* [TestMethod()] Clubbed in InboxTest
        [TestCategory("InboxTest"), TestCategory("US10439")]
        [WorkItem(54642), WorkItem(54645), WorkItem(54646)]
        [Priority(1)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyCharacterCounterInCommentOverlay()
        {
            using (BackUpAndRestoreAutomationAgent = new AutomationAgent("TC54642,TC54645,TC54646: Functionalities of Comment Overlay"))
            {
                try
                {
                    InboxCommonMethods.sendELANoteBooKForReview(BackUpAndRestoreAutomationAgent, "StudentSec01",1);
                    InboxCommonMethods.NavigateTillInbox(BackUpAndRestoreAutomationAgent, "TeacherAdbul");
                    InboxCommonMethods.ClickOnStackedItemNumber(BackUpAndRestoreAutomationAgent, "1");


                    BackUpAndRestoreCommonMethods.CheckingCharacterCountVariation(BackUpAndRestoreAutomationAgent);
                    TeacherModeCommonMethods.ClickOnSaveButton(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54642", true);

                    BackUpAndRestoreCommonMethods.CheckingCharacterCountVariation(BackUpAndRestoreAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(BackUpAndRestoreAutomationAgent);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport("TC54645", true);

                    LoginCommonMethods.Logout(BackUpAndRestoreAutomationAgent);

                }
                catch (Exception ex)
                {
                    BackUpAndRestoreAutomationAgent.Sleep(2000);
                    BackUpAndRestoreAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    BackUpAndRestoreAutomationAgent.CloseApplication();
                    throw;
                }

            }
        }*/

       

        





        




        


        
       
    }

}

