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
    public class GalleryProblemTests
    {
        public AutomationAgent GalleryProblemAutomationAgent;
        public GalleryProblemTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        ////[AssemblyInitialize]
        ////public static void _212AssemblyInitialize(TestContext testContext)
        ////{

        ////}

        //[ClassInitialize]
        //public static void TeacherSupportTestsClassInitialize(TestContext testContext)
        //{
        //}
        //[TestInitialize]
        //public void TeacherSupportTestsTestInitialize()
        //{

        //}


        //[AssemblyCleanup]
        //public static void _212AssemblyCleanup()
        //{

        //}

        //[ClassCleanup]
        //public static void TeacherSupportTestsClassCleanup()
        //{

        //}
        //[TestCleanup]
        //public void TeacherSupportTestsTestCleanup()
        //{

        //}
        #endregion

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20189)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GalleryProblemDoneButtonBringsUserBackToGalleryLesson()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20189: 14. Gallery Problem 'done' button brings user back to Gallery Lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    Assert.IsFalse(GalleryProblemCommonMethods.VerifyGalleryProblemLessonTaskPage(GalleryProblemAutomationAgent));
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent));
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyDoneButtonInGalleryProblemPage(GalleryProblemAutomationAgent));
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemLessonTaskPage(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20192)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GalleryLessonUnitXButtonInChromeSendsUserBackToLessonBrowser()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20192: 06. gallery lesson - Unit X button in chrome sends user back to Lesson Browser"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemLessonTaskPage(GalleryProblemAutomationAgent));
                    string backButtonText = GalleryProblemCommonMethods.GetUnitBackButtonText(GalleryProblemAutomationAgent);
                    Assert.AreEqual(backButtonText, "Unit "+taskInfo.Unit);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20195)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GalleryLessonsCanBeAccessedLikeAnyOtherLesson()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20195: 01. Gallery lessons can be accessed like any other lesson"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(GalleryProblemAutomationAgent, taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyMathUnitPreview(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathUnitPreview(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.ClickMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyMathLessonPreview(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.ClickStartInMathLessonPreview(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    string lessonTitle = LessonBrowserCommonMethods.GetLessonTitle(GalleryProblemAutomationAgent);
                    Assert.IsTrue(lessonTitle.Contains("Gallery"));
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(31810)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GalleryLessonContainsIconsOnTheChromeBarForStudents()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC31810: 06. gallery lesson - the icons on the chrome bar are: games & tools, notebook, concept corner, notification and teacher mode (for students)"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryLessonChromeIconsForStudents(GalleryProblemAutomationAgent));
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20202)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GalleryProblemChromeTitleSaysGalleryProblem()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20202: 08. Gallery Problem chrome title says Gallery Problem"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    string title = LessonBrowserCommonMethods.GetLessonTitle(GalleryProblemAutomationAgent);
                    Assert.AreEqual(title, "Gallery Problem");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20216)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GalleryProblemChromeIconsAreBackToolsAndGamesNotebookIcon()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20216: 08. Gallery Problem chrome icons are: back, tools & games, notebook icon"))
            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemChromeBarIcons(GalleryProblemAutomationAgent));
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20483)]
        [Priority(1)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GalleryLessonChromeTitleIsLessonXGallery()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20483: 15. Gallery Lesson chrome title is Lesson X: Gallery"))
            {
                try
                {
                    int i = 6;
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, i);
                    string title = LessonBrowserCommonMethods.GetLessonTitle(GalleryProblemAutomationAgent);
                    Assert.AreEqual(title, "Lesson " + i + ": Gallery");
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(31809)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void GalleryLessonContainsIconsOnTheChromeBarForTeachers()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC31809: 06. gallery lesson - the icons on the chrome bar are: games & tools, notebook, concept corner, notification and teacher mode (for teachers)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryLessonChromeIconsForTeacher(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(21740)]
        [Priority(3)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void GIVENTeacherModeOpenedWHENOpenGalleryProblemTHENTeacherModeStaysOpened()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC21740: GIVEN teacher mode is opened, WHEN I open a Gallery Problem THEN teacher mode stays opened"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    LessonBrowserCommonMethods.ClickOnTeacherModeIcon(GalleryProblemAutomationAgent);
                    Assert.AreEqual<bool>(true, LessonBrowserCommonMethods.VerifyTeacherModeOpened(GalleryProblemAutomationAgent));
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    GalleryProblemCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent);
                    LessonBrowserCommonMethods.VerifyTeacherModeOpened(GalleryProblemAutomationAgent);
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }



        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20200)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryLessonTheIconsOnTheChromeBar()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20200: 06. gallery lesson - the icons on the chrome bar are: games & tools, notebook, concept corner, notification and teacher mode (for students)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryLessonChromeIconsForTeacher(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);

                    Login loginstd = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, loginstd);
                    TaskInfo taskInfostd = loginstd.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfostd.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfostd.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfostd.Lesson);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryLessonChromeIconsForStudents(GalleryProblemAutomationAgent));
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(GalleryProblemAutomationAgent));
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20201)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemOpensWhenTappinAnywhereonImage()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20201: Gallery Problem opens when tapping anywhere on the image thumbnail"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);

                    string GalleryProbCoordinates = GalleryProblemCommonMethods.GetGalleryProblemPosition(GalleryProblemAutomationAgent);
                    string[] galleryprobpos = GalleryProbCoordinates.Split(',');
                    int galleryprobposx = Int32.Parse(galleryprobpos[0]);
                    int galleryprobposy = Int32.Parse(galleryprobpos[1]);


                    GalleryProblemAutomationAgent.ClickCoordinate(galleryprobposx + 10, galleryprobposy);
                    GalleryProblemAutomationAgent.Sleep();
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "Gallery problem page not opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);

                    GalleryProblemAutomationAgent.ClickCoordinate(galleryprobposx, galleryprobposy + 10);
                    GalleryProblemAutomationAgent.Sleep();
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "Gallery problem page not opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);

                    GalleryProblemAutomationAgent.ClickCoordinate(galleryprobposx + 10, galleryprobposy + 10);
                    GalleryProblemAutomationAgent.Sleep();
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "Gallery problem page not opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);

                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20197)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemLayoutConsistsof2Or3Columns()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20197: 04. Gallery problem layout consists of 2 or 3 columns"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    Assert.IsTrue(GalleryProblemCommonMethods.GetGalleryProblemThumbnails(GalleryProblemAutomationAgent) <= 3, "gallery problem thumbnails are more than 3");
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20204)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookTitleWillbeGalleryNameForGalleryLessonandGalleryProblemName()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20204: Notebook title will be [Gallery Name] for Gallery Lesson and [Gallery Problem Name] for gallery problem"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemAutomationAgent.Sleep(2000);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    string NoteBookTitle = NotebookCommonMethods.GetTextInsideElement(GalleryProblemAutomationAgent);
                    Assert.IsTrue(NoteBookTitle.Contains("Choose Prob"), "notebook title doesnot contains lesson name");
                    LessonBrowserCommonMethods.ClickOnBackButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    string NewNoteBookTitle = NotebookCommonMethods.GetTextInsideElement(GalleryProblemAutomationAgent);
                    Assert.IsTrue(NewNoteBookTitle.Contains("Research Linea"), "notebook title doesnot contains gallery problem name");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20205)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenNotebookOpenGalleryProblemContentNeedsToBeReformattedToFitHalfScreen()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20205:When the notebook is open, gallery problem content needs to be reformatted to fit half screen"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    GalleryProblemAutomationAgent.Sleep(2000);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryLessonFullScreen(GalleryProblemAutomationAgent), "Gallery lesson not full screen");
                    GalleryProblemAutomationAgent.Sleep(2000);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    GalleryProblemAutomationAgent.Sleep(2000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(GalleryProblemAutomationAgent), "NoteBook does not split screen to half");
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    GalleryProblemAutomationAgent.Sleep(2000);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryLessonFullScreen(GalleryProblemAutomationAgent), "Gallery lesson not full screen");
                    GalleryProblemAutomationAgent.Sleep(2000);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    GalleryProblemAutomationAgent.Sleep(2000);
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(GalleryProblemAutomationAgent), "NoteBook does not split screen to half");
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20191)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyOneNotebookForGalleryProblem()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20191: Verify that there is one Notebook for a gallery problem (even for multi-tasks)"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblemWithOneProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemAutomationAgent.Sleep(3000);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(GalleryProblemAutomationAgent, "Single");
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(GalleryProblemAutomationAgent, "Single"), "Text not found in the text region");
                    taskInfo = login.GetTaskInfo("Math", "GalleryProblemWithMultipleProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblemWithMultiplePages(GalleryProblemAutomationAgent);
                    GalleryProblemAutomationAgent.Sleep(3000);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickEraseIconInNotebook(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickClearPage(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickTextIconInNotebook(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(GalleryProblemAutomationAgent, "Multiple");
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1200, 300, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    NotebookCommonMethods.ClickOnNotebookIcon(GalleryProblemAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(GalleryProblemAutomationAgent, "Multiple"), "Text not found in the text region");
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1200, 700, 1);
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1230, 700, 1);
                    NotebookCommonMethods.SendText(GalleryProblemAutomationAgent, "Text ");
                    NotebookCommonMethods.TapOnScreen(GalleryProblemAutomationAgent, 1200, 300, 1);
                    Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionTextFound(GalleryProblemAutomationAgent, "Text Multiple"), "Text not found in the text region");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20211)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenVideoOpenedThenMediaOpenInFullscreen()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20211: WHEN the video is opened THEN media open in fullscreen"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblemWithImage");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemAutomationAgent.ClickOnScreen(140, 1200, 1);
                    GalleryProblemAutomationAgent.Sleep(3000);
                    GalleryProblemCommonMethods.OpenImageInGalleryTaskPage(GalleryProblemAutomationAgent, taskInfo.TaskNumber);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyImageFullScreen(GalleryProblemAutomationAgent), "Gallery Image not in full screen");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20190)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemsusercanswipethroughtasks()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20190:gallery problems - user can swipe through tasks"))
            {
                try
                {

                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "MultiTask Gallery Problem Is Not Opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemInLessonTaskPage(GalleryProblemAutomationAgent), "Gallery Page Is Not Opened");
                    GalleryProblemAutomationAgent.ClickCoordinate(1054, 571);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "MultiTask Gallery Problem Is Not Opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemInLessonTaskPage(GalleryProblemAutomationAgent), "Gallery Page Is Not Opened");
                    GalleryProblemAutomationAgent.ClickCoordinate(134, 1193);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "MultiTask Gallery Problem Is Not Opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemInLessonTaskPage(GalleryProblemAutomationAgent), "Gallery Page Is Not Opened");

                    Login login2 = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo2 = login2.GetTaskInfo("Math", "GalleryProblemWithImage");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo2.Grade);
                    NavigationCommonMethods.StartMathUnit2FromUnitLibrary(GalleryProblemAutomationAgent, taskInfo2.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo2.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemPage(GalleryProblemAutomationAgent), "Single Task Gallery Problem Is Not Opened");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemInLessonTaskPage(GalleryProblemAutomationAgent), "Gallery Page Is Not Opened");
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("GalleryProblemTests")]
        [WorkItem(20196)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemsdontSeePaginationIndicator()
        {
            using (GalleryProblemAutomationAgent = new AutomationAgent("TC20196:WHEN you open Gallery Problem containing one task THEN you don't see the pagination indicator"))
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.Login(GalleryProblemAutomationAgent, login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo.Grade);
                    NavigationCommonMethods.StartMathUnitFromUnitLibrary(GalleryProblemAutomationAgent, taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyPaginationIndicatorPresence(GalleryProblemAutomationAgent), "Pagination indictor not available for multi task gallery prob");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemInLessonTaskPage(GalleryProblemAutomationAgent), "Gallery Page Is Not Opened");


                    Login login2 = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo2 = login2.GetTaskInfo("Math", "GalleryProblemWithOneTask");
                    NavigationCommonMethods.NavigateToMathGrade(GalleryProblemAutomationAgent, taskInfo2.Grade);
                    NavigationCommonMethods.StartMathUnit2FromUnitLibrary(GalleryProblemAutomationAgent, taskInfo2.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(GalleryProblemAutomationAgent, taskInfo2.Lesson);
                    GalleryProblemCommonMethods.OpenGalleryProblem(GalleryProblemAutomationAgent);
                    Assert.IsFalse(GalleryProblemCommonMethods.VerifyPaginationIndicatorPresence(GalleryProblemAutomationAgent), "Pagonation indictor available for single task gallery prob");
                    GalleryProblemCommonMethods.ClickGalleryProblemDoneButton(GalleryProblemAutomationAgent);
                    Assert.IsTrue(GalleryProblemCommonMethods.VerifyGalleryProblemInLessonTaskPage(GalleryProblemAutomationAgent), "Gallery Page Is Not Opened");
                    NavigationCommonMethods.Logout(GalleryProblemAutomationAgent);
                }
                catch (Exception ex)
                {
                    GalleryProblemAutomationAgent.Sleep(2000);
                    GalleryProblemAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    GalleryProblemAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }
    }
}
