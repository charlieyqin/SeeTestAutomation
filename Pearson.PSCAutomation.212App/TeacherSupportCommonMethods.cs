using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public class TeacherSupportCommonMethods
    {
        /// <summary>
        /// Verifies Teacher Support Button Present in the System Tray 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherSupportButtonInSystemTray(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.VerifyElementFound("SystemTrayMenuView", "TeacherSupport");
        }
        /// <summary>
        /// Verifies Teacher Support Button Present in the Dashboard
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTeacherSupportButtonDashboard(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("DashboardView", "TeacherSupportButton");
        }
        /// <summary>
        /// Clicks on the Teacher Support Button present in the Dashboard
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickTeacherSupportButtonDashboard(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("DashboardView", "TeacherSupportButton");
        }
        /// <summary>
        /// Clicks on the Teacher mode icon present 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeIcon(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Sleep(1000);
            teachersupportAutomationAgent.Click("TasksTopMenuView", "TeacherModeIcon");
            teachersupportAutomationAgent.Sleep(2000);
        }
        /// <summary>
        /// Verifies if Teacher Mode is Open or not 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if Teacher Mode is open), false(if teacher mode is not open)</returns>
        public static bool VerifyTeacherModeOpen(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeOpened");
        }
        /// <summary>
        /// Clicks on the Teacher Mode Arrow Icon 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeArrowIcon(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherModeView", "TeacherModeArrowButton");
        }
        /// <summary>
        /// Gets the Width of the Panel in Teacher Mode
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>int: width</returns>
        public static int GetWidthOfTeacherModePanel(AutomationAgent teachersupportAutomationAgent)
        {
            string[] width = teachersupportAutomationAgent.GetAllValues("TeacherModeView", "ExpandArrowBarViewInTeacherMode", "width");
            return Int32.Parse(width[0]);
        }
        /// <summary>
        /// Clicks on Unit Overview in Teacher Mode
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitOverviewInTeacherMode(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherModeView", "UnitOverviewButton");
        }
        /// <summary>
        /// Clicks on About this Lesson in Teacher Mode
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnAboutThisLessonInTeacherMode(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherModeView", "AboutThisLessonButton");
        }
        /// <summary>
        /// Clicks on Teacher Guide in Teacher Mode
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherGuideInTeacherMode(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherModeView", "TeacherGuideButton");
        }
        /// <summary>
        /// Verifies if Teacher Guide is open 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher guide is open), false(if teacher guide is not open)</returns>
        public static bool VerifyTeacherGuideExpands(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if Unit Overview is open
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyUnitOverviewExpands(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if About This Lesson is open 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if open), false(if not)</returns>
        public static bool VerifyAboutThisLessonExpands(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "ButtonsActive");
        }
        /// <summary>
        /// Verifies if Teacher Guide is Collapsed
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if teacher guide is collaped), false(if not)</returns>
        public static bool VerifyTeacherGuideCollapse(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies if Unit Overview is Collapsed
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if collapsed), false(if not)</returns>
        public static bool VerifyUnitOverviewCollapse(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies if About This Lesson is collapsed
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if collapsed), false(if not)</returns>
        public static bool VerifyAboutThisLessonCollapse(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "ButtonsInactive");
        }
        /// <summary>
        /// Verifies the Teacher Support Page 
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result not as expected)</returns>
        public static bool VerifyTeacherSupportPage(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.IsElementFound("SystemTrayMenuView", "TeacherSupport") &&
            navigationAutomationAgent.IsElementFound("TeacherSupportView", "FirstUrl") &&
            navigationAutomationAgent.IsElementFound("TeacherSupportView", "SecondUrl") &&
            navigationAutomationAgent.IsElementFound("TeacherSupportView", "ThirdUrl"))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Clicks on First Url present in the Teacher Support Page
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnFirstUrl(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherSupportView", "FirstUrl");
            teachersupportAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Second Url present in the Teacher Support Page
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSecondUrl(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherSupportView", "SecondUrl");
            teachersupportAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Third Url present in the Teacher Support Page
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnThirdUrl(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("TeacherSupportView", "ThirdUrl");
            teachersupportAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies External Browser is Open 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if open), false(if not)</returns>
        public static bool VerifyExternalBrowserOpen(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("iPadCommonView", "SafariBrowser");
        }
        /// <summary>
        /// Verifies Teacher Support Page Title
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Title present), false(if title not present)</returns>
        public static bool VerifyTeacherSupportPageTitle(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherSupportView", "TeacherSupportTitle");

        }
        /// <summary>
        /// Verifies that Unit overview button is active or not
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>string: enabled property of Button</returns>
        public static string VerifyUnitOverViewButtonActive(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.GetElementProperty("TeacherModeView", "UnitOverview", "enabled", "");
        }
        /// <summary>
        /// Verifies that Lesson overview button is active or not
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>string: enabled property of Button</returns>
        public static string VerifyLessonOverViewButtonActive(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.GetElementProperty("TeacherModeView", "LessonOverview", "enabled", "");
        }
        /// <summary>
        /// Verifies that Task Guide button is active or not
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>string: enabled property of Button</returns>
        public static string VerifyTaskGuideButtonActive(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.GetElementProperty("TeacherModeView", "TaskGuide", "enabled", "");
        }
        /// <summary>
        /// Verifies If teacher mode icon present is enabled or not 
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyTeacherModeEnabled(AutomationAgent teachersupportAutomationAgent)
        {
            return bool.Parse(teachersupportAutomationAgent.GetElementProperty("TasksTopMenuView", "TeacherModeIcon", "enabled"));
        }

        public static bool VerifyTeacherModePulledOut(AutomationAgent teachersupportAutomationAgent)
        {
            int widthBefore = GetWidthOfTeacherModePanel(teachersupportAutomationAgent);
            ClickOnTeacherModeArrowIcon(teachersupportAutomationAgent);
            int widthAfter = GetWidthOfTeacherModePanel(teachersupportAutomationAgent);
            if (widthAfter >= (widthBefore * 2))
                return true;
            else
                return false;
        }

        public static bool VerifyTeacherModeNormalState(AutomationAgent teachersupportAutomationAgent)
        {
            int width = GetWidthOfTeacherModePanel(teachersupportAutomationAgent);
            if (width == 916)
                return true;
            else
                return false;
        }

        public static bool VerifyTeacherModeButtonExpands(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeArrowButton");
        }
        /// <summary>
        /// Verifies the URl of Grow Your skills of Teacher Support in Web View
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void VerifyFirstUrlInWebView(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("iPadCommonView", "SafariBrowserUrl");
            teachersupportAutomationAgent.VerifyElementFound("TeacherSupportView", "FirstUrlInBrowser");
            teachersupportAutomationAgent.ClickOnScreen(40, 192, 1);
        }
        /// <summary>
        /// Verifies the URl of Prepare Your Lesson of Teacher Support in Web View
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void VerifySecondUrlInWebView(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("iPadCommonView", "SafariBrowserUrl");
            teachersupportAutomationAgent.VerifyElementFound("TeacherSupportView", "SecondUrlInBrowser");
            teachersupportAutomationAgent.ClickOnScreen(40, 192, 1);
        }
        /// <summary>
        /// Verifies the URl of Get Help of Teacher Support in Web View
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void VerifyThirdUrlInWebView(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("iPadCommonView", "SafariBrowserUrl");
            teachersupportAutomationAgent.VerifyElementFound("TeacherSupportView", "ThirdUrlInBrowser");
            teachersupportAutomationAgent.ClickOnScreen(40, 192, 1);
        }
        /// <summary>
        /// Verifies if no internet connection pop up is present or not
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNoInternetConnectionPopUp(AutomationAgent teachersupportAutomationAgent)
        {
            if (teachersupportAutomationAgent.IsElementFound("GradeSelectionMenuView", "NoInternetConnectionPopUp") &&
               teachersupportAutomationAgent.IsElementFound("TeacherSupportView", "NoInterentConnectionPopUpBody")
                )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on OK button
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOK(AutomationAgent teachersupportAutomationAgent)
        {
            teachersupportAutomationAgent.Click("AnnotationMenuView", "OKButton");
        }

        public static void ClickLogOut(AutomationAgent teachersupportAutomationAgent)
        {
            for (int i = 0; i < 7; i++)
            //while (true)
            {
                if ((teachersupportAutomationAgent.WaitForElement("SystemTrayMenuView", "SystemTrayButton", WaitTime.SmallWaitTime)))
                    break;
                else
                {
                    teachersupportAutomationAgent.Sleep();
                }
            }
            teachersupportAutomationAgent.Click("TeacherSupportView", "LogOutInFirstUrl");
        }

        public static void VerifyMinimizeIcon(AutomationAgent teachermodeAutomationAgent)
        {

        }

        public static void VerifyExtendIcon(AutomationAgent teachermodeAutomationAgent)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Verfies Logout InUrl Teacher Already LoggedIn
        /// </summary>
        /// <param name="teachersupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool</returns>
        public static bool VerifyLogoutInUrlTeacherAlreadyLoggedIn(AutomationAgent teachersupportAutomationAgent)
        {
            return teachersupportAutomationAgent.IsElementFound("TeacherSupportView", "LogOutInFirstUrl");
        }
    }
}
