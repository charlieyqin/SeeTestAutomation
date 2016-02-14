using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;

using System.Configuration;

namespace Pearson.PSCAutomation._212App
{
    public static class NavigationCommonMethods
    {
        /// <summary>
        /// Logins into K212 application with valid username and password
        /// 1. Sends username to Username field
        /// 2. Sends password to Password field
        /// 3. Clicks on Login button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        public static void Login(AutomationAgent navigationAutomationAgent, string userName, string password)
        {
            navigationAutomationAgent.SetText("LoginView", "UserName", "u");
            navigationAutomationAgent.SendText("{BKSP}");
            navigationAutomationAgent.SetText("LoginView", "UserName", userName);
            navigationAutomationAgent.SetText("LoginView", "Password", "p");
            navigationAutomationAgent.SendText("{BKSP}");
            navigationAutomationAgent.SetText("LoginView", "Password", password);
            navigationAutomationAgent.Click("LoginView", "Login");
        }

        /// <summary>
        /// Logins into K212 application with Login object
        /// 1. Sends username to Username field
        /// 2. Sends password to Password field
        /// 3. Clicks on Login button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="login">Login object</param>
        public static void Login(AutomationAgent navigationAutomationAgent, Login login, bool logoutAndLogin = false)
        {
            if (logoutAndLogin)
            {
                if (IsSystemTrayAvailable(navigationAutomationAgent))
                    Logout(navigationAutomationAgent, true);
            }
            else
            {
                if (bool.Parse(ConfigurationManager.AppSettings["UnitTestExecution"].ToString()))
                {

                    if (!(IsSystemTrayAvailable(navigationAutomationAgent)) && navigationAutomationAgent.IsElementFound("LoginView", "UserName"))
                    {
                        SubLogin(navigationAutomationAgent, login);
                    }
                    else
                    {
                        String NameInSystemTray = navigationAutomationAgent.GetTextIn("SystemTrayMenuView", "NameInSystemTray", "NATIVE", "Inside", "", 0, 0);
                        NameInSystemTray = NameInSystemTray.Replace("\t\n", "");
                        if (NameInSystemTray != login.PersonName)
                        {
                            Logout(navigationAutomationAgent, true);
                            SubLogin(navigationAutomationAgent, login);
                        }
                    }
                }
                else
                {
                    SubLogin(navigationAutomationAgent, login);
                }
            }
        }
        /// <summary>
        /// Verify Teacher Mode Icon is present or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:if teacher mode icon present,false:if teacher mode icon not present</returns>
        public static bool VerifyTeacherModeIcon(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("TasksTopMenuView", "TeacherModeIcon");

        }
        /// <summary>
        /// Login into the application
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="login">login object</param>
        public static void SubLogin(AutomationAgent navigationAutomationAgent, Login login)
        {
            navigationAutomationAgent.SetText("LoginView", "UserName", login.UserName);
            navigationAutomationAgent.CloseKeyboard();
            navigationAutomationAgent.SetText("LoginView", "Password", login.Password);
            navigationAutomationAgent.Click("LoginView", "Login");
            WaitForSystemTrayToAppear(navigationAutomationAgent);
        }

        private static void SetUserName(AutomationAgent navigationAutomationAgent, Login login)
        {
            if (navigationAutomationAgent.GetElementText("LoginView", "UserName") != string.Empty)
                navigationAutomationAgent.Click("LoginView", "ClearUserName");
            else
                navigationAutomationAgent.Click("LoginView", "UserName");
            navigationAutomationAgent.SendText(login.UserName);
            if (navigationAutomationAgent.GetElementText("LoginView", "UserName") != login.UserName)
                SetUserName(navigationAutomationAgent, login);
        }

        private static void SetPassword(AutomationAgent navigationAutomationAgent, Login login)
        {
            if (navigationAutomationAgent.GetElementText("LoginView", "Password") != string.Empty)
                navigationAutomationAgent.Click("LoginView", "ClearPassword");
            else
                navigationAutomationAgent.Click("LoginView", "Password");
            navigationAutomationAgent.SendText(login.Password);
            if (navigationAutomationAgent.GetElementText("LoginView", "Password") != login.Password)
                SetPassword(navigationAutomationAgent, login);
        }

        /// <summary>
        /// Verify if system tray is avialble or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:if system tray available false: if system tray not available</returns>
        public static bool IsSystemTrayAvailable(AutomationAgent navigationAutomationAgent)
        {
            string[] parentHidden;
            if (navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton"))
            {
                parentHidden = navigationAutomationAgent.GetAllValues("SystemTrayMenuView", "SystemTrayButton", "parentHidden");
                return (parentHidden == null || parentHidden[0] == "NULL")
                  && !bool.Parse(navigationAutomationAgent.GetElementProperty("SystemTrayMenuView", "SystemTrayButton", "hidden"));
            }
            else
                return false;
        }

        public static void LoginWithoutWaitingForSystemTray(AutomationAgent navigationAutomationAgent, Login login)
        {
            if (NavigationCommonMethods.IsSystemTrayAvailable(navigationAutomationAgent))
            {
                NavigationCommonMethods.Logout(navigationAutomationAgent, true);
            }
            navigationAutomationAgent.SetText("LoginView", "UserName", login.UserName);
            navigationAutomationAgent.SetText("LoginView", "Password", login.Password);
            navigationAutomationAgent.Click("LoginView", "Login");
        }

        public static void WaitForSystemTrayToAppear(AutomationAgent navigationAutomationAgent)
        {
            for (int i = 0; i < 10; i++)
            {
                if (navigationAutomationAgent.IsElementFound("LoginView", "UserName") || navigationAutomationAgent.IsElementFound("LoginView", "InProgressIcon"))
                {
                    navigationAutomationAgent.Sleep();
                }
                else if ((navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "SystemTrayButton", WaitTime.SmallWaitTime)))
                {
                    string[] parentHidden = navigationAutomationAgent.GetAllValues("SystemTrayMenuView", "SystemTrayButton", "parentHidden");
                    if (parentHidden == null || parentHidden[0] == "NULL")
                    {
                        break;
                    }
                    else
                    {
                        Assert.Fail("Automation not able to find either of these controls, system tray, in progress icon or username textbox. Application might have crashed");
                    }
                }
            }
        }

        /// <summary>
        /// Logs out of the application
        /// 1. Navigates to System tray menu
        /// 2. Clicks on Logout button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void Logout(AutomationAgent navigationAutomationAgent, bool logoutMandatory = false)
        {
            if (!bool.Parse(ConfigurationManager.AppSettings["UnitTestExecution"].ToString()) || logoutMandatory)
            {
                if (OpenSystemTray(navigationAutomationAgent))
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "LogOutButton");
                }
                else
                {
                    CloseApplication(navigationAutomationAgent);
                }
            }
        }

        public static void LogoutIfAlreadyLogin(AutomationAgent navigationAutomationAgent)
        {
            if (!navigationAutomationAgent.IsElementFound("LoginView", "UserName"))
            {
                Logout(navigationAutomationAgent, true);
            }
        }

        public static bool OpenSystemTray(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            string[] parentHidden;
            bool result = false;
            for (int i = 0; i < 10; i++)
            {
                parentHidden = navigationAutomationAgent.GetAllValues("SystemTrayMenuView", "LogOutButton", "parentHidden");
                if (navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "LogOutButton") && (parentHidden == null || parentHidden[0] == "NULL")
                    && !bool.Parse(navigationAutomationAgent.GetElementProperty("SystemTrayMenuView", "LogOutButton", "hidden")))
                {
                    result = true;
                    break;
                }
                else
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
                }
                navigationAutomationAgent.Sleep();
            }
            return result;
        }

        /// <summary>
        /// Navigates to ELA units 
        /// 1. Navigates to System tray menu
        /// 2. Expands Unit Library menu if not already expanded
        /// 3. Clicks on ELA Units
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void NavigateToELA(AutomationAgent navigationAutomationAgent)
        {
            OpenSystemTray(navigationAutomationAgent);
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "ELAUnitsButton", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "ELAUnitsButton");
            }
            else
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                navigationAutomationAgent.Click("SystemTrayMenuView", "ELAUnitsButton");
            }
        }

        public static void NavigateToMyDashboard(AutomationAgent navigationAutomationAgent)
        {
            OpenSystemTray(navigationAutomationAgent);
            navigationAutomationAgent.Click("SystemTrayMenuView", "MyDashboardButton");
        }

        /// <summary>
        /// Navigates to Math units 
        /// 1. Navigates to System tray menu
        /// 2. Expands Unit Library menu if not already expanded
        /// 3. Clicks on Math Units
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void NavigateToMath(AutomationAgent navigationAutomationAgent)
        {
            OpenSystemTray(navigationAutomationAgent);
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "MathUnitsButton", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "MathUnitsButton");
            }
            else
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                navigationAutomationAgent.Click("SystemTrayMenuView", "MathUnitsButton");
            }
        }

        /// <summary>
        /// Navigates to ELA grade
        /// Clicks on Grade number tab
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be navigated</param>
        public static void NavigateToELAGrade(AutomationAgent navigationAutomationAgent, int gradeNumber)
        {
            NavigateToELA(navigationAutomationAgent);
            if (gradeNumber > 12 && gradeNumber < 2)
            {
                Assert.Fail("Grade entered (" + gradeNumber.ToString() + ") is invalid");
            }
            navigationAutomationAgent.WaitforElement("GradeSelectionMenuView", "ELAGradeButton", gradeNumber.ToString());
            navigationAutomationAgent.Click("GradeSelectionMenuView", "ELAGradeButton", gradeNumber.ToString());
        }

        /// <summary>
        /// Navigates to Math grade
        /// Clicks on Grade number tab
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be navigated</param>
        public static void NavigateToMathGrade(AutomationAgent navigationAutomationAgent, int gradeNumber)
        {
            NavigateToMath(navigationAutomationAgent);
            if (gradeNumber > 11 && gradeNumber < 2)
            {
                Assert.Fail("Grade entered (" + gradeNumber.ToString() + ") is invalid");
            }
            navigationAutomationAgent.Click("GradeSelectionMenuView", "MathGradeButton", gradeNumber.ToString());
        }

        /// <summary>
        /// Opens on Unit within lesson
        /// Clicks on Unit within lesson
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnUnitWithinLesson(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        /// <summary>
        /// Starts ELA units from Unit library
        /// 1. Clicks on ELA unit
        /// 2. Clicks on Start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        public static void StartELAUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
            navigationAutomationAgent.WaitforElement("UnitOverView", "ELAUnitStartButton", unitNumber.ToString(), WaitTime.LargeWaitTime);
            int count = 5;
            while (count > 0 && navigationAutomationAgent.IsElementFound("UnitOverView", "ELAUnitStartButton", unitNumber.ToString()))
            {
                navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
                navigationAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                count--;
            }
        }

        /// <summary>
        /// Starts ELA units from Unit library
        /// 1. Clicks on ELA unit
        /// 2. Clicks on Start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        public static void StartELAUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
            navigationAutomationAgent.WaitforElement("UnitOverView", "ELAUnitStartButton", unitNumber.ToString(), WaitTime.LargeWaitTime);
            int count = 5;
            while (count > 0 && navigationAutomationAgent.IsElementFound("UnitOverView", "ELAUnitStartButton", unitNumber.ToString()))
            {
                navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
                navigationAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                count--;
            }
        }

        /// <summary>
        /// Opens on Unit from Unit library
        /// Clicks on Unit in Unit library
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <author>Narasimhan (narsimhan.narayanan)</author>
        public static void ClickELAUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        public static void ClickStartInELAUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.WaitforElement("UnitOverView", "ELAUnitStartButton", unitNumber.ToString(), WaitTime.LargeWaitTime);
            int count = 5;
            while (count > 0 && navigationAutomationAgent.IsElementFound("UnitOverView", "ELAUnitStartButton", unitNumber.ToString()))
            {
                navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
                navigationAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                count--;
            }
        }

        public static void ClickELAUnit(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        /// <summary>
        /// Starts Math units from Unit library
        /// 1. Clicks on Math unit
        /// 2. Clicks on Start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        public static void StartMathUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "MathUnitTile", unitNumber.ToString());
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.Click("UnitOverView", "MathUnitStartButton", unitNumber.ToString());
            navigationAutomationAgent.Sleep();
        }

        /// <summary>
        /// Opens on Unit from Unit library
        /// Clicks on Unit in Unit library
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <author>Narasimhan (narsimhan.narayanan)</author>
        public static void ClickELAUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        public static void ClickStartInELAUnitLibrary(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            int count = 5;
            while (count > 0 && navigationAutomationAgent.IsElementFound("UnitOverView", "ELAUnitStartButton", unitNumber.ToString()))
            {
                navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
                navigationAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                count--;
            }
        }

        public static void ClickELAUnit(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        /// <summary>
        /// Starts Math units from Unit library
        /// 1. Clicks on Math unit
        /// 2. Clicks on Start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number to be opened</param>
        public static void StartMathUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "MathUnitTile", unitNumber.ToString());
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.Click("UnitOverView", "MathUnitStartButton", unitNumber.ToString());
            navigationAutomationAgent.Sleep();
        }

        /// <summary>
        /// Opens a lesson from Lesson Browser
        /// Clicks on ELA lesson
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        public static void ClickELALessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            if (navigationAutomationAgent.WaitforElement("LessonBrowserView", "ELALessonTile", lessonNumber.ToString(), WaitTime.LargeWaitTime))
            {
                navigationAutomationAgent.Click("LessonBrowserView", "ELALessonTile", lessonNumber.ToString());
            }
        }


        public static void ClickOnLessonTile(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonTile", lessonNumber.ToString());
        }

        public static void VerifyClickedLessonOpened(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonNumber", lessonNumber.ToString());
        }

        public static void CloseELALessonTitle(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonCloseIcon", lessonNumber.ToString());
        }

        /// <summary>
        /// Opens lesson from lesson browser and clicks continue
        /// 1. Clicks on Lesson tile in Lesson Browser
        /// 2. Clicks on Continue button or start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        public static void OpenELALessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber, bool retry = false)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonTile", lessonNumber.ToString());
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "ELALessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "ELALessonContinueButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString());
            }
            else
            {
                if (retry)
                {
                    navigationAutomationAgent.AddSteptoSeeTestReport("Neither Start nor Continue button are found on the screen", false);
                }
                else
                {
                    navigationAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Left, 10, 2000);
                    OpenELALessonFromLessonBrowser(navigationAutomationAgent, lessonNumber, true);
                }
            }
        }

        /// <summary>
        /// Opens lesson from lesson browser and clicks continue
        /// 1. Clicks on Lesson tile in Lesson Browser
        /// 2. Clicks on Continue button or start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        public static void OpenMathLessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber, bool retry = false)
        {
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.Click("LessonBrowserView", "MathLessonTile", (lessonNumber).ToString());
            navigationAutomationAgent.Sleep();
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString());
            }
            else
            {
                if (retry)
                {
                    navigationAutomationAgent.AddSteptoSeeTestReport("Neither Start nor Continue button are found on the screen", false);
                }
                else
                {
                    navigationAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Left, 10, 2000);
                    OpenMathLessonFromLessonBrowser(navigationAutomationAgent, lessonNumber, true);
                }
            }
        }

        /// <summary>
        /// Navigates to a task page within a lesson
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="taskNumber">task number to be navigated to</param>
        public static void NavigateToTaskPageInLesson(AutomationAgent navigationAutomationAgent, int taskNumber)
        {
            int currentTaskNumber = int.Parse(navigationAutomationAgent.GetElementText("LessonView", "CurrentPageLabel"));
            int numberOfPagesToTraverse = 0;
            if (currentTaskNumber > taskNumber)
            {
                numberOfPagesToTraverse = currentTaskNumber - taskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    navigationAutomationAgent.Click("LessonView", "PreviousButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
            else if (currentTaskNumber < taskNumber)
            {
                numberOfPagesToTraverse = taskNumber - currentTaskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    navigationAutomationAgent.Click("LessonView", "NextButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Navigates to a particular task number in ELA
        /// 1. Navigates to ELA
        /// 2. Navigates to given Grade
        /// 3. Navigates to given Unit
        /// 4. Navigates to given Lesson
        /// 5. Navigates to given task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be opened</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        /// <param name="taskNumber">task number to be opened</param>
        public static void NavigateELATaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {
            NavigateToELAGrade(navigationAutomationAgent, gradeNumber);
            StartELAUnitFromUnitLibrary(navigationAutomationAgent, unitNumber);
            OpenELALessonFromLessonBrowser(navigationAutomationAgent, lessonNumber);
            NavigateToTaskPageInLesson(navigationAutomationAgent, taskNumber);
        }
        /// <summary>
        /// Navigates to a particular task number in ELA
        /// 1. Navigates to ELA
        /// 2. Navigates to given Grade
        /// 3. Navigates to given Unit
        /// 4. Navigates to given Lesson
        /// 5. Navigates to given task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be opened</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        /// <param name="taskNumber">task number to be opened</param>
        public static void NavigateELATaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, int gradeNumber, string unitNumber, int lessonNumber, int taskNumber)
        {
            NavigateToELAGrade(navigationAutomationAgent, gradeNumber);
            StartELAUnitFromUnitLibrary(navigationAutomationAgent, unitNumber);
            OpenELALessonFromLessonBrowser(navigationAutomationAgent, lessonNumber);
            NavigateToTaskPageInLesson(navigationAutomationAgent, taskNumber);
        }

        /// <summary>
        /// Navigates to work browser menu
        /// 1. Navigates to System tray menu
        /// 2. Clicks on Work Browser button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void NavigateWorkBrowser(AutomationAgent navigationAutomationAgent)
        {
            if (!navigationAutomationAgent.IsElementFound("WorkBrowserView", "WorkBrowserHeader"))
            {
                OpenSystemTray(navigationAutomationAgent);
                if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "WorkBrowser", WaitTime.SmallWaitTime))
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "WorkBrowser");
                }
                navigationAutomationAgent.Sleep();
            }
        }

        /// <summary>
        /// Navigates to a particular task number in Math
        /// 1. Navigates to Math
        /// 2. Navigates to given Grade
        /// 3. Navigates to given Unit
        /// 4. Navigates to given Lesson
        /// 5. Navigates to given task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be opened</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        /// <param name="taskNumber">task number to be opened</param>
        public static void NavigateMathTaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {
            NavigateToMathGrade(navigationAutomationAgent, gradeNumber);
            StartMathUnitFromUnitLibrary(navigationAutomationAgent, unitNumber);
            OpenMathLessonFromLessonBrowser(navigationAutomationAgent, lessonNumber);
            NavigateToTaskPageInLesson(navigationAutomationAgent, taskNumber);
        }

        /// <summary>
        /// Navigates to a particular task number in Math
        /// 1. Navigates to Math
        /// 2. Navigates to given Grade
        /// 3. Navigates to given Unit
        /// 4. Navigates to given Lesson
        /// 5. Navigates to given task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be opened</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        /// <param name="taskNumber">task number to be opened</param>
        public static void NavigateMathTaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, int gradeNumber, string unitNumber, int lessonNumber, int taskNumber)
        {
            NavigateToMathGrade(navigationAutomationAgent, gradeNumber);
            StartMathUnitFromUnitLibrary(navigationAutomationAgent, unitNumber);
            OpenMathLessonFromLessonBrowser(navigationAutomationAgent, lessonNumber);
            NavigateToTaskPageInLesson(navigationAutomationAgent, taskNumber);
        }

        /// <summary>
        /// Cancels in Select grade
        /// 1. Selects grade 
        /// 2. Clicks on Cancel
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelInSelectGrade(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.WaitforElement("SelectGradeView", "GradeLabel", "5", 10000);
            navigationAutomationAgent.Click("SelectGradeView", "CancelButton");
        }

        /// <summary>
        /// Pinches out on screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if pinch out</returns>
        /// <author>Kiran Kumar Anantapalli(kiran.anantapalli)</author>
        public static bool PinchOutOnScreen(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.PinchOut();
        }

        /// <summary>
        /// Logs out of the application and release client
        /// 1. Navigates to System tray menu
        /// 2. Clicks on Logout button
        /// 3. Releases client and generate report
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void LogoutOnExceptionAndReleaseClient(AutomationAgent navigationAutomationAgent)
        {
            //if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "SystemTrayButton"))
            //{
            //    navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            //    navigationAutomationAgent.Click("SystemTrayMenuView", "LogOutButton");
            //}            
            navigationAutomationAgent.ApplicationClose();
            navigationAutomationAgent.GenerateReportAndReleaseClient();
        }

        /// <summary>
        /// Swipes unit in given direction
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="direction">Direction object</param>
        public static void SwipeUnit(AutomationAgent navigationAutomationAgent, Direction direction)
        {
            navigationAutomationAgent.Swipe(direction);
        }

        /// <summary>
        /// Clicks on Teacher mode button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickTeacherModeButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "TeacherMode");
        }

        /// <summary>
        /// Verifies class roster link
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyClassRosterLink(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementNotFound("DashboardView", "ClassRosterLink");
        }

        /// <summary>
        /// Navigates back in Grade
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickBackButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "GradeBackButton");
        }

        /// <summary>
        /// Clicks on lesson
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void ClickOnLesson(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("LessonView", "AnotherLesson");
        }

        /// <summary>
        /// Click add grade 
        /// 1. Clicks add grade
        /// 2. Selects grade from available / enabled list
        /// 3. Clicks continue
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static int ClickAddGrade(AutomationAgent navigationAutomationAgent, int toBeAdded = 0)
        {
            int i = 0;
            if (navigationAutomationAgent.IsElementFound("UnitLibraryView", "AddGrades"))
            {
                navigationAutomationAgent.Click("UnitLibraryView", "AddGrades");
                bool gradeAdded = false;
                for (i = 2; (i <= 12 && !gradeAdded); i++)
                {
                    if (toBeAdded > 1)
                    {
                        if (i == toBeAdded)
                        {
                            navigationAutomationAgent.WaitforElement("SelectGradeView", "GradeButton", i.ToString(), WaitTime.DefaultWaitTime);
                            navigationAutomationAgent.Click("SelectGradeView", "GradeButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                            if (navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", i.ToString()))
                            {
                                gradeAdded = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        navigationAutomationAgent.WaitforElement("SelectGradeView", "GradeButton", i.ToString(), WaitTime.DefaultWaitTime);
                        navigationAutomationAgent.Click("SelectGradeView", "GradeButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                        if (navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", i.ToString()))
                        {
                            gradeAdded = true;
                            break;
                        }
                    }

                }
                if (gradeAdded)
                {
                    navigationAutomationAgent.Click("SelectGradeView", "ContinueButton");
                }
                else
                {
                    navigationAutomationAgent.Click("SelectGradeView", "CancelButton");
                }
            }
            return i;
        }

        /// <summary>
        /// Changes Wifi connectivity
        /// 1. Navigates to device home and opens Settings
        /// 2. Checks if Wifi has to be ON and if not already ON then changes the ON
        /// 3. Checks if Wifi has to be OFF and if not already OFF then changes the OFF
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <param name="TurnWifiOff">turn off / on wifi</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void ChangeWiFiConnectivity(AutomationAgent navigationAutomationAgent, bool TurnWifiOff)
        {
            navigationAutomationAgent.SendText("{HOME}");
            navigationAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (navigationAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                navigationAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            navigationAutomationAgent.SendText("Settings");
            if (navigationAutomationAgent.IsElementFound("iPadCommonView", "SettingsMenu"))
            {
                navigationAutomationAgent.Click("iPadCommonView", "SettingsMenu");
            }
            else
            {
                navigationAutomationAgent.ClickCoordinate(196, 242, 1);
            }
            if (navigationAutomationAgent.IsElementFound("iPadCommonView", "Wi-FiSettingsButtoniOS9"))
            {
                navigationAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsButtoniOS9");
            }
            else
            {
                navigationAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsButton");
            }

            if (TurnWifiOff)
            {
                if (navigationAutomationAgent.IsElementFound("iPadCommonView", "Wi-FiSettingsOnStatus"))
                {
                    navigationAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsUIASwitch");
                }
            }

            else
            {
                if (!navigationAutomationAgent.IsElementFound("iPadCommonView", "Wi-FiSettingsOnStatus"))
                {
                    navigationAutomationAgent.Click("iPadCommonView", "Wi-FiSettingsUIASwitch");
                }
            }
        }

        /// <summary>
        /// Continues lesson from lesson browser
        /// Clicks on Continue lesson button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">lesson number to be continued</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickContinueLessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber, bool retry = false)
        {
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "ELALessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "ELALessonContinueButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString());
            }
            else
            {
                if (retry)
                {
                    navigationAutomationAgent.AddSteptoSeeTestReport("Neither Start nor Continue button are found on the screen", false);
                }
                else
                {
                    navigationAutomationAgent.SwipeElement("LessonBrowserView", "LessonBrowserCollection", Direction.Left, 10, 2000);
                    ClickContinueLessonFromLessonBrowser(navigationAutomationAgent, lessonNumber, true);
                }
            }
        }

        /// <summary>
        /// Closes lesson in ELA
        /// Clicks on clos lesson button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickLessonCloseButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "LessonCloseXButton");
        }

        /// <summary>
        /// Verifies the In progress spinner in the Grade selection view
        /// </summary>
        /// <param name="navigationAutomationAgent">Automation Agent object</param>
        /// <returns>in progress spinner exists status</returns>
        public static bool VerifyInprogressSpinnerExists(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "InProgressSpinner");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyNoWiFiIconFound(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "NoWiFiIcon");
        }

        public static bool VerifyMessageUnderNoWiFiIcon(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "BodyPopUpMessage");
        }
        /// <summary>
        /// Clicks on remove grade button
        /// It removes the grade 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void ClickRemoveGradeButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SelectGradeView", "RemoveGradeButton");
            navigationAutomationAgent.Click("LoginView", "OkButton");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean object: true if button enabled, false if button not enabled</returns>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static bool VerifyRemoveGradeButtonActive(AutomationAgent navigationAutomationAgent)
        {
            string[] alpha = navigationAutomationAgent.GetAllValues("UnitLibraryView", "RemoveGrade", "", "alpha");
            if (alpha[0] == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies the Header section of the No WiFi message
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNoWifiMessageHeader(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "NoInternetConnectionPopUp");
        }
        /// <summary>
        /// Verifies the Body section of the No WiFi message
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNoWifiMessageBody(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "BodyPopUpMessage");
        }
        /// <summary>
        /// Clicks on the OK Button visible in the Pop Up Message
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOkButtonInPopUpMessage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("GradeSelectionMenuView", "OkButtonInPopUpMessage");
        }
        /// <summary>
        /// 1. Clicks on the System Tray Button 
        /// 2. Verifies the Unit Library Button 
        ///     If active then verifies the sub menu (ELA Units and Math Units)
        ///     else click on Unit Library and then verifies the sub menu (ELA Units and Math Units)
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifySystemTraySubMenu(AutomationAgent navigationAutomationAgent)
        {
            OpenSystemTray(navigationAutomationAgent);
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "ELAUnitsButton", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ELAUnitsButton");
                navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "MathUnitsButton");
            }
            else
            {
                navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "UnitLibrary");
                navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ELAUnitsButton");
                navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "MathUnitsButton");
            }
        }
        /// <summary>
        /// Navigates to Content Manager menu
        /// 1. Navigates to System tray menu
        /// 2. Clicks on Content Manager button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void NavigateContentManager(AutomationAgent navigationAutomationAgent)
        {
            OpenSystemTray(navigationAutomationAgent);
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "ContentManager", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "ContentManager");
            }
        }
        /// <summary>
        /// Verifies that Downloading contents of the grades are in progress 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static bool VerifyPrepairingUnits(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "PrepairingUnits");
        }
        /// <summary>
        /// Verifies that Update content oh the grades are in progress in Content Manager
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static bool VerifyActivitySpinnerExists(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "ActivitySpinner");
        }
        /// <summary>
        /// Navigates to My Dashboard menu
        /// 1. Navigates to System tray menu
        /// 2. Clicks on My Dashboard button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void NavigateMyDashboard(AutomationAgent navigationAutomationAgent)
        {
            if (!navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "MyDashboard"))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
                OpenSystemTray(navigationAutomationAgent);
                if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "MyDashboard", WaitTime.SmallWaitTime))
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "MyDashboard");
                }
            }
        }
        /// <summary>
        /// Clicks on the System Tray Button 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickSystemTrayButton(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.WaitforElement("SystemTrayMenuView", "SystemTrayButton", "", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            }
        }

        /// <summary>
        /// Verifies the units thumbnails present in a particular grade
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyUnitThumbnails(AutomationAgent navigationAutomationAgent, string unit)
        {
            navigationAutomationAgent.VerifyElementFound("UnitLibraryView", "UnitNo", unit);
        }
        /// <summary>
        /// Verifies the images present in the Dashboard of a particular grade
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static bool VerifyImagesInDashboard(AutomationAgent navigationAutomationAgent, string grade, string subject)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!navigationAutomationAgent.IsElementFound("DashboardView", "ImageInDashboard", grade + " " + subject))
                {
                    navigationAutomationAgent.Swipe(Direction.Right);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifies the Unit Library Page in System Tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyUnitLibraryPage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "UnitLibrary");
        }
        /// <summary>
        /// Verifies User is on Dashboard
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyDashboard(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("DashboardView", "MyDashboardTitle");
        }
        /// <summary>
        /// Verifies Content manager button in system tray menu
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyContentManagerButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ContentManagerButton");
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ContentManager");
        }
        /// <summary>
        /// Verifies the position of the Unit Library Button
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitLibraryPosition(AutomationAgent navigationAutomationAgent)
        {
            string SystemBtnsOrder = navigationAutomationAgent.GetTextIn("SystemTrayMenuView", "CurrentUserName", "Down", "");
            bool UnitLibrarySecondPos = false;
            string[] SystemBtnsNameOrder = SystemBtnsOrder.Split('\t');
            for (int i = 0; i < SystemBtnsNameOrder.Count(); i++)
            {
                switch (i)
                {
                    case 0: break;
                    case 1: Assert.AreEqual<string>("Unit Library", SystemBtnsNameOrder[i].Replace("\n", ""));
                        UnitLibrarySecondPos = true;
                        break;
                }
                if (UnitLibrarySecondPos)
                    break;
            }
            Assert.AreEqual<bool>(true, UnitLibrarySecondPos);
        }
        /// <summary>
        /// Clicks On Unit Library Button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickUnitLibraryButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
        }
        /// <summary>
        /// Verifies Chrome icon set in Math consisting of tools/games, Notebook, concept corner, shared work
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyChromeIconSetInMathStudent(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "ToolsIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "NotebookIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "ConceptCornerIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "SharingNotificationIcon");
        }
        /// <summary>
        /// Verifies Chrome icon set in ELA consisting of tools/games, Notebook, More To Explore, shared work
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyChromeIconSetInELAStudent(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "ToolsIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "NotebookIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "MoreToExploreIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "SharingNotificationIcon");
        }
        /// <summary>
        /// Verifies Chrome icon set in ELA consisting of tools/games, Notebook, concept corner, shared work, Teacher Mode
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyChromeIconSetInMathTeacher(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "ToolsIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "NotebookIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "ConceptCornerIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "SharingNotificationIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "TeacherModeIcon");
        }
        /// <summary>
        /// Verifies Chrome icon set in ELA consisting of tools/games, Notebook, More To Explore, shared work, Teacher Mode
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyChromeIconSetInELATeacher(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "ToolsIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "NotebookIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "MoreToExploreIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "SharingNotificationIcon");
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "TeacherModeIcon");
        }
        /// <summary>
        /// Verifies the Log Out Button present in the system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyLogoutButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "LogOutButtonIcon");
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "LogOutButton");
        }
        /// <summary>
        /// Verifies if teacher is Sectioned or Not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="login">login</param>
        /// <returns>bool:- true(if result is as expectated) false(if note as expected)</returns>
        public static bool IsSectionedUser(AutomationAgent navigationAutomationAgent, Login login)
        {
            bool isNonSectionedUser = false;
            int[] grades = login.SectionedGrades;
            for (int i = 0; i < 12; i++)
            {
                if (!grades.Contains(i + 1) && navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "ELAGradeButton", (i + 1).ToString()))
                {
                    return true;
                }
            }
            return isNonSectionedUser;
        }
        /// <summary>
        /// Verifies System tray is Open
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifySystemTrayOpen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "SystemTrayHighLighted");
        }
        /// <summary>
        /// Verifies the ELA Page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyELAPage(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "ELAUnitsTitle");
        }
        /// <summary>
        /// Verifies the Math Page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyMathPage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("GradeSelectionMenuView", "MathUnitsTitle");
        }
        /// <summary>
        /// Verifies Work Browser Page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyWorkBrowserPage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "WorkBrowser");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void NavigateTeacherSupport(AutomationAgent navigationAutomationAgent)
        {
            if (!(navigationAutomationAgent.IsElementFound("TeacherSupportView", "TeacherSupportTitle")))
            {
                OpenSystemTray(navigationAutomationAgent);
                if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "TeacherSupport", WaitTime.SmallWaitTime))
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "TeacherSupport");
                }
            }
        }
        /// <summary>
        /// Verifies Teacher Support Page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherSupportPage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "TeacherSupport");
            navigationAutomationAgent.VerifyElementFound("TeacherSupportView", "FirstUrl");
            navigationAutomationAgent.VerifyElementFound("TeacherSupportView", "SecondUrl");
            navigationAutomationAgent.VerifyElementFound("TeacherSupportView", "ThirdUrl");
        }
        /// <summary>
        /// Verifies Content Manager Page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyContentManagerPage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "ContentManager");
        }

        /// <summary>
        /// Clicks on the Tools button present in the sub menu of tools and games 
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickOnToolbarSubMenuButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "ToolsMoreInfoIcon");
        }
        /// <summary>
        /// Verifies the Snapshot Tool button present in the sub menu of tools button
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void VerifySnapshotToolButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("TasksTopMenuView", "SnapshotIcon");
        }
        /// <summary>
        /// Verifies that "a" in word and is between tools and games
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if as expected), false(if not as expected)</returns>
        public static bool ToolsAndGames(AutomationAgent navigationAutomationAgent)
        {
            string s = navigationAutomationAgent.GetTextIn("TasksTopMenuView", "ToolsAndGames", "Inside", "").Replace("\t\n", "");
            string[] t = s.Split();
            if (t[1].Equals("and") && t[1].Contains("a"))
            {
                return true;
            }
            else
                return false;

        }
        /// <summary>
        /// Verifies the Login screen containing username, password field and Login Button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyLoginScreen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("LoginView", "UserName");
            navigationAutomationAgent.VerifyElementFound("LoginView", "Password");
            navigationAutomationAgent.VerifyElementFound("LoginView", "Login");
        }

        public static void KillApp(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.SendText("{HOME}{HOME}");
            navigationAutomationAgent.Swipe(Direction.Up);
            navigationAutomationAgent.Drag(100, 600, 100, 0);

        }

        /// <summary>
        /// Clicks on the Lesson which is not downloaded 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static void ClickLessonNotDownloaded(AutomationAgent LessonBrowserAutomationAgent, int lessonNumber)
        {
            if (LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonDownloadButton"))
            {
                LessonBrowserAutomationAgent.Click("LessonBrowserView", "LessonDownloadButton", lessonNumber.ToString());
                LessonBrowserAutomationAgent.Sleep();
                while (LessonBrowserAutomationAgent.IsElementFound("LessonBrowserView", "LessonProgressBar"))
                {

                }
                LessonBrowserAutomationAgent.Click("LessonBrowserView", "MathLessonTile", lessonNumber.ToString());
            }
        }
        /// <summary>
        /// Verifies Add Grade Continue Button is Disabled or Not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if button disabled), false(if not disabled)</returns>
        public static bool VerifyAddGradeContinueButtonDisabled(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "AddGrades");
            return bool.Parse(navigationAutomationAgent.GetElementProperty("SelectGradeView", "ContinueButton", "enabled"));
        }
        /// <summary>
        /// Closes the Add Grade Pop Up 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void CloseAddGradePopUp(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SelectGradeView", "CancelButton");
        }

        /// <summary>
        /// Gets the Task Page Number in Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>int: Task Page Number</returns>
        public static int GetTaskPageNumberInLesson(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("LessonView", "CurrentPageLabel"))
            {
                int currentTaskNumber = int.Parse(navigationAutomationAgent.GetElementText("LessonView", "CurrentPageLabel"));
                return currentTaskNumber;
            }

            else
                return -1;
        }

        /// <summary>
        /// Clicks on Tools Icon present in the Student Dashboard
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnToolsIcon(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "ToolsIcon");
        }
        /// <summary>
        /// Gets the Heading of the Tools Icon Sub menus
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static string GetToolsIconHeading(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.GetTextIn("TasksTopMenuView", "ToolsIconHeading", "NATIVE", "Inside", "", 0, 0).Replace("\t\n", "");
        }
        /// <summary>
        /// Clicks on Spelling Menu Item in Tools Icon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSpellingMenuItem(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "SpellingMenu");
        }
        /// <summary>
        /// Gets the Text color of the grade number selected
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">string</param>
        /// <returns>string: text color of grade number selected</returns>
        public static string GetTextColorOfGrades(AutomationAgent navigationAutomationAgent, int gradeNumber)
        {
            if (navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGradeNumber", gradeNumber.ToString()))
            {
                string[] s = navigationAutomationAgent.GetAllValues("SelectGradeView", "SelectedGradeNumber", gradeNumber.ToString(), "textColor");
                return s[0];
            }
            return null;
        }


        /// <summary>
        /// It Verifies the Unit Numbers of the Units present in a particular grade
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitsNumberInOrder(AutomationAgent navigationAutomationAgent, string unit)
        {
            return navigationAutomationAgent.IsElementFound("UnitLibraryView", "UnitNo", unit);
        }
        /// <summary>
        /// Verify the ELA Unit button is highlighted by verifying the text color
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>string: color of ELA Unit button</returns>
        public static string VerifyELAUnitHighlight(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("GradeSelectionMenuView", "ELAUnitsTitle");
            string[] s = navigationAutomationAgent.GetAllValues("SystemTrayMenuView", "ELAUnitsColorBlue", "", "textColor");
            return s[0];
        }
        /// <summary>
        /// Verify the Math Unit button is highlighted by verifying the text color
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>string: color of Math Unit button</returns>
        public static string VerifyMathUnitHighlight(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("GradeSelectionMenuView", "MathUnitsTitle");
            string[] s = navigationAutomationAgent.GetAllValues("SystemTrayMenuView", "MathUnitsColorGreen", "", "textColor");
            return s[0];
        }
        /// <summary>
        /// Verifies Unit Library Button is collapsed
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitLibraryCollapsed(AutomationAgent dashboardAutomationAgent)
        {
            if (dashboardAutomationAgent.IsElementFound("SystemTrayMenuView", "ELAUnitsButton"))
            {

            }
            return dashboardAutomationAgent.IsElementFound("SystemTrayMenuView", "UnitLibraryArrowDown");
        }
        /// <summary>
        /// Verifies the Unit Library Button status in System Tray wether it has Arrow Up or Down
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Arrow is Up), false(if Arrow is Down)</returns>
        public static bool VerifyUnitLibraryButton(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "ELAUnitsButton"))
            {
                navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "UnitLibraryArrowUp");
                return true;
            }
            else
            {
                navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "UnitLibraryArrowDown");
                return false;
            }
        }
        /// <summary>
        /// Verifies the Unit Library Expanded with the List of courses
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitLibraryExpanded(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "ELAUnitsButton") &&
            navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "MathUnitsButton") &&
            navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "UnitLibraryArrowDown"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifies the Resource Library Fly Out Menu available or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if avaialble), false(if not avaialble)</returns>
        public static bool VerifyResourceLibraryFlyOutMenu(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("DashboardView", "ResourceLibraryFlyOutMenu");
        }
        /// <summary>
        /// Clicks on Continue Button present in the Lesson Preview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnELALessonContinueButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("LessonsOverView", "ELALessonCommonContinueButton");
        }
        /// <summary>
        /// Verifies No Wifi Icon Present in the Unit Library
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if No WiFi Icon is present), false(if No wIfi Icon is not present)</returns>
        public static bool VerifyNoWifiIconInUnitLibrary(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("UnitLibraryView", "NoWifiIconInUnitLibrary");
        }
        /// <summary>
        /// Verifies id Add grade button is enabled
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>string: true(if enabled), false(if disabled)</returns>
        public static string VerifyAddGradeButtonActive(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.GetElementProperty("UnitLibraryView", "AddGrades", "enabled", "");
        }
        /// <summary>
        /// Clicks on More To Explore Butto Present in the Navigation Bar in ELA Task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickMoreToExploreButtonInNavBar(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "MoreToExploreIcon");
            navigationAutomationAgent.WaitForElementToVanish("GradeSelectionMenuView", "InProgressSpinner");
        }
        /// <summary>
        /// Verifies More To explore Page 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyMoreToExplorePage(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.WaitforElement("DashboardView", "MoreToExploreLabel", "", WaitTime.LargeWaitTime);
            return navigationAutomationAgent.IsElementFound("DashboardView", "MoreToExploreLabel");
        }
        /// <summary>
        /// Clicks on Concept Corner Button present in the navigation bar in Math Task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickConceptCornerButtonInNavBar(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "ConceptCornerIcon");
        }
        /// <summary>
        /// Verifies More To explore Page 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Page present), false(if not present)</returns>
        public static bool VerifyConceptCornerPage(AutomationAgent navigationAutomationAgent)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((navigationAutomationAgent.WaitForElement("TasksTopMenuView", "ConceptCornerPage", WaitTime.SmallWaitTime)))
                    break;
            }
            return navigationAutomationAgent.IsElementFound("TasksTopMenuView", "ConceptCornerPage");
        }
        /// <summary>
        /// Clicks on Unit Preview Card Start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        public static void ClickUnitPreviewCardStartButton(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
        }

        /// <summary>
        /// Clicks on Unit Preview Card Start button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        public static void ClickUnitPreviewCardStartButton(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber);
        }
        /// <summary>
        /// Clicks On Lesson Browser Back button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickLessonBrowserBackButton(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.WaitforElement("UnitOverView", "UnitPreviewBackButton", "", WaitTime.LargeWaitTime))
            {
                navigationAutomationAgent.Click("UnitOverView", "UnitPreviewBackButton");
            }

        }

        /// <summary>
        /// Verify Unit Preview Card
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        /// <returns>bool: true(if Preview Card present), false(if Preview Card not present)</returns>
        public static bool VerifyUnitPreviewCard(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            return navigationAutomationAgent.IsElementFound("UnitLibraryView", "UnitNumber", unitNumber.ToString());
        }

        /// <summary>
        /// Verify Unit Preview Card
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        /// <returns>bool: true(if Preview Card present), false(if Preview Card not present)</returns>
        public static bool VerifyUnitPreviewCard(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            return navigationAutomationAgent.IsElementFound("UnitLibraryView", "UnitNumber", unitNumber);
        }

        /// <summary>
        /// Clicks On Fly Out Menu of Back button
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickBackButtonOnResourceLibraryFlyOutMenu(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("DashboardView", "ResourceLibraryBackButton");
        }
        /// <summary>
        /// Verifies Concept Corner Page relevant to the Lesson Previewed
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyConceptCornerPageRelevantToLastViewedLesson(AutomationAgent navigationAutomationAgent, string grade = "9", string unit = "0" )
        {
            while (true)
            {
                if ((navigationAutomationAgent.WaitForElement("TasksTopMenuView", "ConceptCornerPage", WaitTime.SmallWaitTime)))
                    break;
            }
            string text = navigationAutomationAgent.GetAllValues("TasksTopMenuView", "ConceptCornerPageRelevantToLesson", "text")[0];
            return text.Contains(grade + "." + unit);
        }
        /// <summary>
        /// Clicks on Done Button Present in Web Page
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDone(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "DoneButton");
        }
        /// <summary>
        /// Verifies More To Explore Page relevant to the Lesson Previewed
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyMoreToExplorePageRelevantToLastViewedLesson(AutomationAgent navigationAutomationAgent, string grade, string unit)
        {
            while (true)
            {
                if ((navigationAutomationAgent.WaitForElement("TasksTopMenuView", "MoreToExplorePage", WaitTime.SmallWaitTime)))
                    break;
            }
            string text = navigationAutomationAgent.GetAllValues("TasksTopMenuView", "MoreToExplorePageRelevantToLesson", "text")[0];
            return text.Contains(grade + "." + unit);
        }
        /// <summary>
        /// Clicks on More To Explore Button Present in Dashboard
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickMoreToExploreButtonInDashboard(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("DashboardView", "MoreToExploreButton");
        }
        /// <summary>
        /// Clicks on Concept Corner Button Present in Dashboard
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickConceptCornerButtonInDashboard(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("DashboardView", "ConceptCornerMathButton");
        }

        /// <summary>
        /// Verify that More Unit Cards are displayed
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyMoreUnitsCardDisplayed(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("UnitOverView", "MoreUnitPreviewCards");
        }
        /// <summary>
        /// Verify Edge of Next Unit Card is displayed
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyEdgeOfNextUnitCardDisplayed(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("UnitOverView", "NextUnitPreviewCardEdge");
        }



        /// <summary>
        /// Verify App Chrome Title on Unit Preview Screen 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitnumber"></param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static string VerifyAppChromeTitleOnUnitPreviewScreen(AutomationAgent navigationAutomationAgent, int unitnumber)
        {
            String text = navigationAutomationAgent.GetTextIn("UnitOverView", "UnitPreviewCardTitle", "Inside", unitnumber.ToString());
            String Text1 = text.Replace("\t\n", "");
            return Text1;
        }

        /// <summary>
        /// Verify App Chrome Title on Unit Preview Screen 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitnumber"></param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static string VerifyAppChromeTitleOnUnitPreviewScreen(AutomationAgent navigationAutomationAgent, string unitnumber)
        {
            String text = navigationAutomationAgent.GetTextIn("UnitOverView", "UnitPreviewCardTitle", "Inside", unitnumber);
            String Text1 = text.Replace("\t\n", "");
            return Text1;
        }

        /// <summary>
        /// Verify Default Grade is in highlighted state or not.
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyDefaultGradeInHighlightedState(AutomationAgent navigationAutomationAgent, int Grade)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "ELAGradeButton", Grade.ToString());
        }

        /// <summary>
        /// Clicks on My Work Drop Down present in Work Browser
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMyWorkDropDown(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("WorkBrowser", "WorkBrowserMenu");
        }
        /// <summary>
        /// Clicks on My Class in My Work Drop Down Menu
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickMyClassInMyWorkDropDown(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("WorkBrowser", "MyClassInMyWork");
        }
        /// <summary>
        /// Clicks on Notebooks in My Class
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickNotebooksInMyClass(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("WorkBrowser", "NotebooksInMyClass");
        }
        /// <summary>
        /// Clicks on First ELA Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickFirstELACommonRead(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.ClickOnScreen(60, 502, 1);
            commonReadAutomationAgent.Sleep(15000);
        }
        /// <summary>
        /// Closes application
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void CloseApplication(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.ApplicationClose();
            commonReadAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Clicks on First ELA Notebook
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickFirstELANotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.ClickOnScreen(60, 502, 1);
            notebookAutomationAgent.Sleep(15000);
        }
        /// <summary>
        /// Clicks on Common Reads in My Class
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickCommonReadInMyClass(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "CommonReadsInMyClass");
        }
        /// <summary>
        /// Clicks on Sec-34 Per-5 in My Class
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static void ClickSec_34Per_5(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("WorkBrowser", "Sec34Per5InMyClass");
        }
        /// <summary>
        /// Clicks on Math Unit 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to be opened</param>
        public static void ClickMathUnit(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "MathUnitTile", (unitNumber).ToString());
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Math Unit 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">string: unit number to be opened</param>
        public static void ClickMathUnit(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "MathUnitTile", (unitNumber).ToString());
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// clicks on the start button present in the unit preview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to be opened</param>
        public static void ClickStartInMathUnitPreview(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitOverView", "MathUnitStartButton", (unitNumber - 1).ToString());
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// clicks on the start button present in the unit preview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to be opened</param>
        public static void ClickStartInMathUnitPreview(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitOverView", "MathUnitStartButton", unitNumber);
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Math Lesson Present in the Lesson Browser
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int: lesson number to be opened</param>
        public static void ClickMathLessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "MathLessonTile", (lessonNumber).ToString());
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on the Start button present in the Math Lesson preview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="lessonNumber">int: lesson number to be opened</param>
        public static void ClickStartInMathLessonPreview(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString());
            }
            else
            {
                navigationAutomationAgent.CaptureScreenshot("Neither Start nor Continue button are found on the screen");
                Assert.Fail("Neither Start nor Continue button are found on the screen");
            }
        }
        /// <summary>
        /// Clicks on Down Chevron Icon present in the work browser
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="index">int: index of the Down chevron icon</param>
        public static void ClickDownChevronIcon(AutomationAgent navigationAutomationAgent, int index)
        {
            navigationAutomationAgent.Click("WorkBrowser", "DownChevronIcon", index.ToString());
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies the position of the Unit Library Button
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitLibraryPositionForNonSectionedUser(AutomationAgent navigationAutomationAgent)
        {
            string SystemBtnsOrder = navigationAutomationAgent.GetTextIn("SystemTrayMenuView", "CurrentUserName", "Down", "");
            bool UnitLibraryFirstPos = false;
            string[] SystemBtnsNameOrder = SystemBtnsOrder.Split('\t');
            for (int i = 0; i < SystemBtnsNameOrder.Count(); i++)
            {
                switch (i)
                {
                    case 0: Assert.AreEqual<string>("Unit Library", SystemBtnsNameOrder[i].Replace("\n", ""));
                        UnitLibraryFirstPos = true;
                        break;
                    case 1:
                        break;
                }
                if (UnitLibraryFirstPos)
                    break;
            }
            Assert.AreEqual<bool>(true, UnitLibraryFirstPos);
        }
        /// <summary>
        /// Verifies Unit Library Button Present or not in the system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitLibraryButtonPresent(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("SystemTrayMenuView", "UnitLibrary");
        }

        public static bool VerifyNewAppIconOnHomeScreen(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("iPadCommonView", "AppIcon");
        }
        public static bool VerifyUnitBackButtonPresent(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("TasksTopMenuView", "UnitBackButton");
        }

        public static void NavigateToTaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, TaskInfo taskInfo)
        {
            if (NotebookCommonMethods.VerifyNotebookRegionPresent(navigationAutomationAgent))
            {
                NotebookCommonMethods.ClickOnNotebookIcon(navigationAutomationAgent);
            }
            if (taskInfo.SubjectName == "ELA")
            {
                if (navigationAutomationAgent.IsElementFound("LessonView", "LessonTitle", taskInfo.Title))
                {
                    if (taskInfo.TaskNumber != int.Parse(navigationAutomationAgent.GetElementText("LessonView", "CurrentPageLabel")))
                    {
                        NavigateToTaskPageInLesson(navigationAutomationAgent, taskInfo.TaskNumber);
                    }
                }
                else
                {
                    NavigateELATaskfromSytemTrayMenu(navigationAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                }
            }
            else if (taskInfo.SubjectName == "Math")
            {
                if (navigationAutomationAgent.IsElementFound("LessonView", "LessonTitle", taskInfo.Title))
                {
                    if (taskInfo.TaskNumber != int.Parse(navigationAutomationAgent.GetElementText("LessonView", "CurrentPageLabel")))
                    {
                        NavigateToTaskPageInLesson(navigationAutomationAgent, taskInfo.TaskNumber);
                    }
                }
                else
                {
                    NavigateMathTaskfromSytemTrayMenu(navigationAutomationAgent, taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                }
            }
        }
        /// <summary>
        /// Clicks on Tools button present in the Resource Library Fly out menu
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickToolsInResourceLibrary(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "ResourceLibraryToolsMenu");
            navigationAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verifies if Add Grades button is present in the unit library or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAddGradeButtonPresent(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("UnitLibraryView", "AddGrades");
        }
        /// <summary>
        /// Clicks on Add grade button present in the unit library
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void TapAddgrade(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "AddGrades");
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies Add grade pop up present or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAddGradePopUp(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("SelectGradeView", "AddGradePopUp");
        }
        /// <summary>
        /// Gets the Username present in the Select Grade Pop up 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>string: UserName In Pop Up</returns>
        public static string GetUserNameInAddGradePopUp(AutomationAgent navigationAutomationAgent)
        {
            string[] s = navigationAutomationAgent.GetTextIn("SelectGradeView", "UserNameInSelectGrade", "NATIVE", "Inside", "", 0, 0).Split('\t');
            return s[0];
        }
        /// <summary>
        /// Verifies if Back button present or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyBackButtonPresent(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Sleep(2000);
            return navigationAutomationAgent.IsElementFound("UnitOverView", "UnitPreviewBackButton");
        }
        /// <summary>
        /// Verifies if Remove Grade button is present or not in the Unit Library 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyRemoveGradeButtonPresent(AutomationAgent navigationAutomationAgent)
        {
            bool hidden = bool.Parse(navigationAutomationAgent.GetAllValues("UnitLibraryView", "RemoveGrade", "hidden")[0]);
            if (hidden)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Verifies if specific grade is present or not 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">int</param>
        public static bool VerifySpecificGradePresent(AutomationAgent navigationAutomationAgent, int gradeNumber)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "ELAGradeButton", gradeNumber.ToString());
        }
        /// <summary>
        /// Gets the Unit title from the Unit thumbnail present in the unit Library 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to verify</param>
        /// <returns>string: title of the unit</returns>
        public static string GetUnitTitleFromUnitThumbnail(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            string s = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitTitleInThumbnail", "Inside", unitNumber.ToString());
            return s.Replace("\t\n", "");
        }
        /// <summary>
        /// Gets the Unit Title from the Unit Preview card of Unit clicked
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to verify</param>
        /// <returns>string: title of the unit</returns>
        public static string GetUnitTitleFromUnitPreview(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            string s = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitTitleInUnitPreview", "Inside", unitNumber.ToString());
            return s.Replace("\t\n", "");
        }
        /// <summary>
        /// Gets the Unit title from the Unit thumbnail present in the unit Library 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to verify</param>
        /// <returns>string: title of the unit</returns>
        public static string GetUnitTitleFromUnitThumbnail(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            string s = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitTitleInThumbnail", "Inside", unitNumber);
            return s.Replace("\t\n", "");
        }
        /// <summary>
        /// Gets the Unit Title from the Unit Preview card of Unit clicked
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to verify</param>
        /// <returns>string: title of the unit</returns>
        public static string GetUnitTitleFromUnitPreview(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            string s = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitTitleInUnitPreview", "Inside", unitNumber);
            return s.Replace("\t\n", "");
        }
        /// <summary>
        /// Verifies Waiting To Download after adding any new grade
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyWaitingToDownload(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementFound("UnitLibraryView", "WaitingToDownload");
        }
        /// <summary>
        /// Verify default filter exists in work browser or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDefaultFilterInWorkBrowser(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("WorkBrowserView", "DefaultFilter");
        }
        /// <summary>
        /// De-Select the math filter in My Work 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void DeSelectMathFilterInMyWork(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("WorkBrowserView", "MathInMyWork"))
            {
                navigationAutomationAgent.Click("WorkBrowserView", "MathInMyWork");
            }
        }
        /// <summary>
        /// Verify ELA Header Colour in Work Browser
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>String:Colour</returns>
        public static string VerifyELAHeaderTitleColor(AutomationAgent navigationAutomationAgent, Login login)
        {
            if (!navigationAutomationAgent.IsElementFound("WorkBrowserView", "ELAHeader"))
            {
                NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickEraseIconInNotebook(navigationAutomationAgent);
                NotebookCommonMethods.ClickClearPage(navigationAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(navigationAutomationAgent);
                NotebookCommonMethods.TapOnScreen(navigationAutomationAgent, 1200, 700, 1);
                NotebookCommonMethods.TapOnScreen(navigationAutomationAgent, 1230, 700, 1);
                NotebookCommonMethods.SendText(navigationAutomationAgent, "First Page");
                NotebookCommonMethods.TapOnScreen(navigationAutomationAgent, 1200, 300, 1);
                NavigateWorkBrowser(navigationAutomationAgent);
                NavigationCommonMethods.ClickOnMyWorkDropDown(navigationAutomationAgent);
                NavigationCommonMethods.DeSelectMathFilterInMyWork(navigationAutomationAgent);
                NotebookCommonMethods.TapOnScreen(navigationAutomationAgent, 0, 132, 1);
            }
            string[] str;
            str = navigationAutomationAgent.GetAllValues("WorkBrowserView", "ELAHeader", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Select the Personal Notes filter in My Work 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void SelectPersonalNotesFilterInMyWork(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("WorkBrowserView", "PersonalNotesInMyWork");
        }
        /// <summary>
        /// Verify PersonalNotes HeaderTitle Color
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>String:Colour</returns>
        public static string VerifyPersonalNotesHeaderTitleColor(AutomationAgent navigationAutomationAgent, Login login)
        {
            if (!navigationAutomationAgent.IsElementFound("WorkBrowserView", "PersonalNotesHeaderWorkBrowser"))
            {
                NavigateToTaskfromSytemTrayMenu(navigationAutomationAgent, login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon(navigationAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(navigationAutomationAgent);
                NotebookCommonMethods.ClickPersonalNotesLink(navigationAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(navigationAutomationAgent);
                NotebookCommonMethods.ClickPersonalNoteCreateButton(navigationAutomationAgent);
                NavigateWorkBrowser(navigationAutomationAgent);
                ClickOnMyWorkDropDown(navigationAutomationAgent);
                SelectPersonalNotesFilterInMyWork(navigationAutomationAgent);
                NotebookCommonMethods.TapOnScreen(navigationAutomationAgent, 0, 132, 1);
            }
            string[] str;
            str = navigationAutomationAgent.GetAllValues("WorkBrowserView", "PersonalNotesHeaderWorkBrowser", "backgroundColor");
            return str[0];
        }
        /// <summary>
        /// Verify Single Episodes Presence in lesson Browser
        /// </summary>
        /// <param name="CAAdoptionAutomationAgent">AutomationAgent object</param>
        /// <param name="width">width</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySingleEpisodesPresence(AutomationAgent CAAdoptionAutomationAgent)
        {
            return !CAAdoptionAutomationAgent.IsElementFound("LessonBrowserView", "PaginationIndicator", "2");
        }
        /// <summary>
        /// Verifies New Grades On Ribbon
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="grade">grade to be verified</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNewGradeOnRibbon(AutomationAgent navigationAutomationAgent, int grade)
        {
            return navigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "ELAGradeButton", grade.ToString());
        }
        /// <summary>
        /// Click on the Cancel Button in Add grades screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SelectGradeView", "CancelButton");
        }
        /// <summary>
        /// Verifies if work in work browser is scrollable vertically or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <param name="workNumber">int: work number to identify</param>
        /// <returns>bool: true(if scrollable), false(if not scrollable)</returns>
        public static bool VerifyWorkIsScrollable(AutomationAgent notebookAutomationAgent, int workNumber)
        {
            int yPos = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowserView", "WorkBrowserItemViewCell", workNumber.ToString(), "x")[0]);
            notebookAutomationAgent.Swipe(Direction.Down);
            int newYPos = Int32.Parse(notebookAutomationAgent.GetAllValues("WorkBrowserView", "WorkBrowserItemViewCell", workNumber.ToString(), "y")[0]);
            notebookAutomationAgent.Swipe(Direction.Up);
            if (yPos == newYPos)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Verifies Grade selection screen
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGradeSelectionScreen(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.WaitForElement("LoginView", "GradeSelection", WaitTime.LargeWaitTime);
            return navigationAutomationAgent.IsElementFound("LoginView", "GradeSelection");

        }
        /// <summary>
        /// Verifies Only One grade can be selected
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifySelectOnlyOneGrade(AutomationAgent navigationAutomationAgent, int grade  = 3)
        {
            bool notAddedGrade = false;
            while (!notAddedGrade)
            {
                if (!navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", (grade).ToString()))
                {
                    navigationAutomationAgent.Click("SelectGradeView", "GradeButton", grade.ToString(), 1, WaitTime.DefaultWaitTime);
                    if (navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", (grade).ToString()))
                    {
                        notAddedGrade = true;
                    }
                }
                grade++;
            }
            bool selectedCGradeFound = navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", (grade - 1).ToString());
            if (!selectedCGradeFound)
            {
                navigationAutomationAgent.AddSteptoSeeTestReport("Selected grade is not available", false);
            }
            navigationAutomationAgent.Click("SelectGradeView", "GradeButton", (grade - 1).ToString(), 1, WaitTime.DefaultWaitTime);
            selectedCGradeFound = navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", (grade - 2).ToString());
            if (selectedCGradeFound)
            {
                navigationAutomationAgent.AddSteptoSeeTestReport("Already downloaded grade is selected", false);
            }
        }
        /// <summary>
        /// Click on New Added grade
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeadded">grade to be Clicked</param>
        public static void ClickNewAddedGrade(AutomationAgent navigationAutomationAgent, int gradeadded)
        {
            navigationAutomationAgent.Click("SelectGradeView", "GradeLabel", gradeadded.ToString(), 1, WaitTime.DefaultWaitTime);
        }
        /// <summary>
        /// Verifies No Grades are Selected on First Login 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if selected), false(if not selected)</returns>
        public static bool VerifyNoGradeSelectedOnFirstLogin(AutomationAgent navigationAutomationAgent)
        {
            for (int i = 2; i <= 12; i++)
            {
                if (navigationAutomationAgent.IsElementFound("SelectGradeView", "SelectedGrade", (i).ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Verifies Unit No, Unit Title, Unit Description and Start button in Unit Preview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to be verified</param>
        public static void VerifyELAUnitPreviewDetails(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.VerifyElementFound("UnitLibraryView", "UnitNumber", unitNumber.ToString());
            navigationAutomationAgent.VerifyElementFound("UnitLibraryView", "UnitTitleInUnitPreview", unitNumber.ToString());
            navigationAutomationAgent.VerifyElementFound("UnitOverView", "UnitDescription");
            navigationAutomationAgent.VerifyElementFound("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
        }

        /// <summary>
        /// Verifies Unit No, Unit Title, Unit Description and Start button in Unit Preview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">int: unit number to be verified</param>
        public static void VerifyELAUnitPreviewDetails(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.VerifyElementFound("UnitLibraryView", "UnitNumber", unitNumber);
            navigationAutomationAgent.VerifyElementFound("UnitLibraryView", "UnitTitleInUnitPreview", unitNumber);
            navigationAutomationAgent.VerifyElementFound("UnitOverView", "UnitDescription");
            navigationAutomationAgent.VerifyElementFound("UnitOverView", "ELAUnitStartButton", unitNumber);
        }

        /// <summary>
        /// Click add grade 
        /// 1. Selects grade from available / enabled list
        /// 2. Clicks continue
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static int AddGradeForNonSectionedUser(AutomationAgent navigationAutomationAgent)
        {
            int i = 0;
            navigationAutomationAgent.Click("UnitLibraryView", "AddGrades");
            for (i = 2; i < 12; i++)
            {
                if (navigationAutomationAgent.GetElementProperty("SelectGradeView", "GradeButton", "enabled", i.ToString(), WaitTime.DefaultWaitTime).Equals("true"))
                {
                    navigationAutomationAgent.Click("SelectGradeView", "GradeButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    break;
                }
            }
            navigationAutomationAgent.Click("SelectGradeView", "ContinueButton");
            return i;
        }
        /// <summary>
        /// Adds all the grades present in the grade selection view
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void AddAllGrades(AutomationAgent navigationAutomationAgent)
        {
            int i = 0;
            if (navigationAutomationAgent.IsElementFound("UnitLibraryView", "AddGrades"))
            {
                navigationAutomationAgent.Click("UnitLibraryView", "AddGrades");
                for (i = 2; i <= 12; i++)
                {
                    if (navigationAutomationAgent.GetElementProperty("SelectGradeView", "GradesButton", "textColor", i.ToString(), WaitTime.DefaultWaitTime).Equals("0x333333"))
                    {
                        navigationAutomationAgent.Click("SelectGradeView", "GradesButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    }
                }
                navigationAutomationAgent.Click("SelectGradeView", "ContinueButton");
            }
        }
        /// <summary>
        /// gets the task name from the task page
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>string: text</returns>
        public static string GetTaskName(AutomationAgent teachermodeAutomationAgent)
        {
            string s = teachermodeAutomationAgent.GetAllValues("TasksTopMenuView", "ELANotebookTaskName", "text")[0];
            return s;
        }
        /// <summary>
        /// Gets Unit Thumnail Text
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        /// <returns>string: text</returns>
        public static string GetUnitThumbnailText(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            string UnitText = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitNo", "Inside", unitNumber.ToString());
            return "Unit" + (UnitText.Replace("\n", "").Replace("\t", ""));
        }
        /// <summary>
        ///  Gets Unit Label From UnitPreview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        /// <returns>string: text</returns>
        public static string GetUnitLabelFromUnitPreview(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            string UnitText = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitNumber", "Inside", unitNumber.ToString());
            return "Unit" + UnitText.Replace("\n", "").Replace("\t", "");
        }
        /// <summary>
        /// Gets Unit Thumnail Text
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        /// <returns>string: text</returns>
        public static string GetUnitThumbnailText(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            string UnitText = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitNo", "Inside", unitNumber);
            return "Unit" + (UnitText.Replace("\n", "").Replace("\t", ""));
        }
        /// <summary>
        ///  Gets Unit Label From UnitPreview
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        /// <returns>string: text</returns>
        public static string GetUnitLabelFromUnitPreview(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            string UnitText = navigationAutomationAgent.GetTextIn("UnitLibraryView", "UnitNumber", "Inside", unitNumber);
            return "Unit" + UnitText.Replace("\n", "").Replace("\t", "");
        }
        /// <summary>
        /// Verify Units Are In Orderor not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyUnitsAreInOrder(AutomationAgent navigationAutomationAgent)
        {
            int count = navigationAutomationAgent.GetElementCountIn("UnitOverView", "MoreUnitPreviewCards", "Inside", "UnitOverView", "UnitNumbers", 0, 0);
            for (int i = 1; i <= 2; i++)
            {
                string UnitText = navigationAutomationAgent.GetTextIn("UnitOverView", "UnitNumber", "Inside", i.ToString());
                int UnitNo = Int32.Parse(UnitText.Replace("\n", "").Replace("\t", ""));
                Assert.AreEqual<int>(i, UnitNo);
                SwipeUnit(navigationAutomationAgent, Direction.Right);
            }

            for (int i = 1; i <= 2; i++)
            {
                SwipeUnit(navigationAutomationAgent, Direction.Left);
            }
        }

        /// <summary>
        /// Verifies recommend message to add 2 grades
        /// </summary>
        /// <param name="navigationAutomationAgent"></param>
        /// <returns></returns>
        public static bool VerifyRecommendationMessageAddGrade(AutomationAgent navigationAutomationAgent)
        {
            string message = navigationAutomationAgent.GetElementText("UnitLibraryView", "AddGradesAlertMessage");
            if (message == "Adding more than two grades is not recommended due to available space.")
                return true;

            else
                return false;
        }

        public static bool VerifyGradeAsPerSectionedforUser(Login login, string Gradetext)
        {
            bool isSectionedGradeofUser = false;
            int[] grades = login.SectionedGrades;
            for (int i = 0; i < grades.Count(); i++)
            {
                if (Gradetext.Contains(grades[i].ToString()))
                {
                    return true;
                }
            }
            return isSectionedGradeofUser;
        }

        public static void SwipeUnit(AutomationAgent teachermodeAutomationAgent, Direction direction, int Unit)
        {
            teachermodeAutomationAgent.SwipeElement("UnitLibraryView", "UnitTitleInUnitPreview", Unit.ToString(), direction, 0, 2000);
        }
        public static void SwipeUnit(AutomationAgent teachermodeAutomationAgent, Direction direction, string Unit)
        {
            teachermodeAutomationAgent.SwipeElement("UnitLibraryView", "UnitTitleInUnitPreview", Unit, direction, 0, 2000);
        }

        /// <summary>
        /// Waits for the units to download after grade is added
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutoamtionAgent object</param>
        public static void WaitForUnitsToDownload(AutomationAgent NavigationAutomationAgent)
        {
            NavigationAutomationAgent.Sleep(600000);
            int i = 15;
            while (NavigationAutomationAgent.IsElementFound("GradeSelectionMenuView", "PrepairingUnits") && i > 0)
            {
                NavigationAutomationAgent.WaitForElementToVanish("GradeSelectionMenuView", "PrepairingUnits", 30000);
                i--;
            }
        }
        /// <summary>
        /// Gets the number of units in a grade
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent objct</param>
        /// <returns>number of units</returns>
        public static int GetNumberOfUnitsInGrade(AutomationAgent LessonBrowserAutomationAgent)
        {
            int numberOfUnits = 0;
            int UnitPages = LessonBrowserAutomationAgent.GetElementCount("UnitLibraryView", "UnitLibraryPage");
            for (int i = 1; i <= UnitPages; i++)
            {
                numberOfUnits += LessonBrowserAutomationAgent.GetElementCount("UnitLibraryView", "GenericUnitTile");
                LessonBrowserAutomationAgent.Swipe(Direction.Right);
            }
            for (int i = 1; i <= UnitPages; i++)
            {
                LessonBrowserAutomationAgent.Swipe(Direction.Left);
            }
            return numberOfUnits;
        }

        /// <summary>
        /// Verifies No Wifi Label and returns status
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent Object</param>
        /// <returns>No wifi found status</returns>
        public static bool VerifyNoWifiLabelFound(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("UnitLibraryView", "NoWifiLabelInUnitLibrary");
        }
        /// <summary>
        ///  Verify Educational Standard Arrow Up    
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if arrow up),false:(if not)</returns>
        public static bool VerifyEducationalStandardArrowUp(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.IsElementFound("LessonBrowserView", "EducationalStandardArrowUp");
        }
        /// <summary>
        /// Click Educational Standard Arrow Up
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickEducationalStandardArrowUp(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "EducationalStandardArrowUp");
        }
        /// <summary>
        /// Verify Educational Standard Expands
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if expands),false:(if not)</returns>
        public static bool VerifyEducationalStandardExpands(AutomationAgent navigationAutomationAgent)
        {
            string ypos = navigationAutomationAgent.GetAllValues("LessonBrowserView", "EducationalStandardArrowDown", "y")[0];
            int yposvalue = Int32.Parse(ypos);
            if (yposvalue < 1190)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Verify Educational Standard Arrow Down
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:((if arrow up),false:(if not)</returns>
        public static bool VerifyEducationalStandardArrowDown(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("LessonBrowserView", "EducationalStandardArrowDown"))
            {
                ClickEducationalStandardArrowUp(navigationAutomationAgent);
            }
            return navigationAutomationAgent.IsElementFound("LessonBrowserView", "EducationalStandardArrowDown");
        }
        /// <summary>
        /// Click Educational Standard Arrow Down
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickEducationalStandardArrowDown(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "EducationalStandardArrowDown");
        }
        /// <summary>
        /// Verify Educational Standard Collapses
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if collapsed),false(if not)</returns>
        public static bool VerifyEducationalStandardCollapses(AutomationAgent navigationAutomationAgent)
        {
            string ypos = navigationAutomationAgent.GetAllValues("LessonBrowserView", "EducationalStandardArrowUp", "y")[0];
            int yposvalue = Int32.Parse(ypos);
            if (yposvalue == 1190)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies the Remove grade button status for sectioned grades
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="failureMessage">failure message out parameter</param>
        /// <returns>failure message and boolean status of remove grades button</returns>
        public static bool VerifyRemoveGradeButtonForSectionedGradesInELA(AutomationAgent navigationAutomationAgent, Login login, out string failureMessage)
        {
            bool buttonStatus = true;
            failureMessage = string.Empty;
            foreach (int grade in login.SectionedGrades)
            {
                navigationAutomationAgent.Click("GradeSelectionMenuView", "ELAGradeButton", grade.ToString());
                if (VerifyRemoveGradeButtonActive(navigationAutomationAgent))
                {
                    buttonStatus = false;
                    failureMessage += "Remove Grade button is Active for the Grade: " + grade;
                }
            }
            return buttonStatus;
        }
        /// <summary>
        /// Clicks on Grade in the ELA unit library
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent Object</param>
        /// <param name="Grade">Grade number</param>
        public static void ClickELAGradeInUnitLibrary(AutomationAgent navigationAutomationAgent, int grade)
        {
            navigationAutomationAgent.Click("GradeSelectionMenuView", "ELAGradeButton", grade.ToString());
        }
        /// <summary>
        /// Adds the grades if they are already not added
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent Object</param>
        /// <param name="grades">Grades params list</param>
        public static void AddGrades(AutomationAgent navigationAutomationAgent, params int[] grades)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "AddGrades");
            foreach (int grade in grades)
            {
                if (navigationAutomationAgent.IsElementEnabled("SelectGradeView", "GradeButton", grade.ToString()))
                {
                    navigationAutomationAgent.Click("SelectGradeView", "GradeButton", grade.ToString(), 1, WaitTime.DefaultWaitTime);
                    navigationAutomationAgent.Sleep(200);
                }
            }
            if (navigationAutomationAgent.IsElementEnabled("SelectGradeView", "ContinueButton"))
            {
                navigationAutomationAgent.Click("SelectGradeView", "ContinueButton");
            }
            else
            {
                ClickCancelButton(navigationAutomationAgent);
            }
        }
        /// <summary>
        /// Gets the available grades for ELA
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>int array of available grades</returns>
        public static int[] GetAvailableGradesInELA(AutomationAgent navigationAutomationAgent)
        {
            int gradesCount = navigationAutomationAgent.GetElementCount("GradeSelectionMenuView", "GenericGradeLabel");
            int[] availableGrades = new int[gradesCount];
            for (int i = 0; i < gradesCount; i++)
            {
                availableGrades[i] = int.Parse(navigationAutomationAgent.GetElementText("GradeSelectionMenuView", "GenericGradeLabel", i));
            }
            return availableGrades;
        }

        /// <summary>
        /// Removes the grades
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="grades">params list of grades to be removed</param>
        public static void RemoveGrades(AutomationAgent navigationAutomationAgent, params int[] grades)
        {
            foreach (int grade in grades)
            {
                ClickELAGradeInUnitLibrary(navigationAutomationAgent, grade);
                ClickRemoveGradeButton(navigationAutomationAgent);
                navigationAutomationAgent.Sleep();
                ClickContinueInRemoveGradeConfirmation(navigationAutomationAgent);
            }
        }
        /// <summary>
        /// Clicks on continue in remove grade confirmation pop up
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void ClickContinueInRemoveGradeConfirmation(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("UnitLibraryView", "ContinueRemoveGrade"))
            {
                navigationAutomationAgent.Click("UnitLibraryView", "ContinueRemoveGrade");
            }
        }

        /// <summary>
        /// Opens systemtray and verifies the existence of Math units in the system tray
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean status of math units found in system tray</returns>
        public static bool VerifyMathUnitsInSystemTray(AutomationAgent navigationAutomationAgent)
        {
            OpenSystemTray(navigationAutomationAgent);
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "ELAUnitsButton", WaitTime.SmallWaitTime))
            {
                return navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "MathUnitsButton");
            }
            else
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                return navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "MathUnitsButton");
            }
        }
        /// <summary>
        /// Verify Teacher Views CommonCore Stands
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyTeacherViewsCommonCoreStands(AutomationAgent navigationAutomationAgent, string word = "Reading")
        {
            navigationAutomationAgent.Sleep();
            string textcontains = navigationAutomationAgent.GetText("TEXT");
            navigationAutomationAgent.Sleep();
            if (textcontains.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Start Button Accessible or not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>true:(if present),false(if not)</returns>
        public static bool VerifyStartButtonAccessible(AutomationAgent navigationAutomationAgent)
        {
            string startbutton = navigationAutomationAgent.GetAllValues("LessonsOverView", "ELALessonCommonCoreContinueButton", "top")[0];
            return bool.Parse(startbutton);

        }

        public static void VerifyIfInformationIsMoreOnPanel(AutomationAgent navigationAutomationAgent, string word = "Reading")
        {
            navigationAutomationAgent.Sleep();
            string text = NotebookCommonMethods.GetTextInTextZone(navigationAutomationAgent);
            Assert.IsTrue(text.Contains(word), "");
            navigationAutomationAgent.Swipe(Direction.Down, 500);
            navigationAutomationAgent.Sleep();
            string newText = NotebookCommonMethods.GetTextInTextZone(navigationAutomationAgent);
            if (newText.Contains(word))
            {
                navigationAutomationAgent.AddSteptoSeeTestReport("Text is not scrollable", true);
            }
            else
            {
                navigationAutomationAgent.AddSteptoSeeTestReport("Text is scrollable", true);
            }
        }


        /// <summary>
        /// Waits for the lesson to download by verifying the progressbar
        /// </summary>
        /// <param name="navigationAutomationAgent">Automation Agent</param>
        /// <param name="lessonNumber">Lesson Number</param>
        public static void WaitForLessonToDownload(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            int i = 18;
            while (!bool.Parse(navigationAutomationAgent.GetElementProperty("LessonBrowserView", "ProgressBarByLesson", "hidden", lessonNumber.ToString())) && i > 0)
            {
                navigationAutomationAgent.Sleep(10000);
                i--;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationAutomationAgent"></param>
        public static string[] GetAllUnitLabels(AutomationAgent navigationAutomationAgent)
        {
            int noOfUnitTiles = navigationAutomationAgent.GetElementCount("UnitLibraryView", "GenericUnitTile");
            string[] unitLabels = new string[noOfUnitTiles];
            for (int i = 0; i < noOfUnitTiles; i++)
            {
                unitLabels[i] = navigationAutomationAgent.GetElementText("UnitLibraryView", "GenericUnitNoLabel", i);
            }
            return unitLabels;
        }




        /// <summary>
        /// Changes Wifi connectivity
        /// 1. Navigates to device home and opens Settings
        /// 2. Checks for config code control in App name
        /// </summary>
        /// <param name="LoginLogoutAutomationAgent">AutomationAgent object</param>
        /// <param name="TurnWifiOff">turn off / on wifi</param>
        /// <author>Madhav Purohit(madhav.purohit)</author> 
        public static bool VerifyContentControlCodefieldExistsDeviceSetting(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.SendText("{HOME}");
            navigationAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (navigationAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                navigationAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            navigationAutomationAgent.SendText("Settings");
            navigationAutomationAgent.ClickCoordinate(196, 242, 1);

            navigationAutomationAgent.Click("iPadCommonView", "DisplayBrightnessInSettings");
            navigationAutomationAgent.ElementSwipeWhileNotFound("iPadCommonView", "SettingsTableScroll", "iPadCommonView", "AppNameInSettings", "", "Up", 1000, 2000, 1000, 5, false);
            navigationAutomationAgent.Click("iPadCommonView", "AppNameInSettings");
            return navigationAutomationAgent.IsElementFound("iPadCommonView", "ConfigAppNameInSettings");
        }
        /// <summary>
        /// Clicks Math Unit 2
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent Object</param>
        /// <param name="unitNumber">Unit Number</param>
        public static void StartMathUnit2FromUnitLibrary(AutomationAgent navigationAutomationAgent, string unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "MathUnit2Tile", unitNumber.ToString());
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.Click("UnitOverView", "MathAllUnitStartButton", unitNumber.ToString());
            navigationAutomationAgent.Sleep();
        }
        /// <summary>
        /// Swipe Lesson and click on lesson Tile
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent Object</param>
        /// <param name="lessonNumber">Lesson Number</param>
        public static void SwipeAndOpenMathLessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {

            navigationAutomationAgent.SwipeElement("LessonBrowserView", "LessonCollection", (lessonNumber).ToString(), Direction.Up, 1000, 500);
            navigationAutomationAgent.Sleep();
            navigationAutomationAgent.Click("LessonBrowserView", "MathLessonTile", (lessonNumber).ToString());
            navigationAutomationAgent.Sleep();
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString());
            }

        }

        public static void VerifySystemTrayOpened(AutomationAgent navigationAutomationAgent)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "LogOutButton"))
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
                }
                else
                {
                    return;
                }
            }
        }

        public static void CloseSystemTray(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.WaitforElement("SystemTrayMenuView", "SystemTrayButton", "", WaitTime.SmallWaitTime))
            {
                int xOfSystemTray = int.Parse(navigationAutomationAgent.GetAllValues("SystemTrayMenuView", "SystemTrayButton", "x")[0]);
                if (xOfSystemTray > 0)
                {
                    navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
                }
            }
        }

    }
}
