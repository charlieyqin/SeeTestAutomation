using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;
using System.Collections;


namespace Pearson.PSCAutomation.K1App
{
    public class SystemTrayCommonMethods
    {
        public static bool VerifyAssessmentManager(AutomationAgent systemTrayAutomationAgent)
        {
            if (systemTrayAutomationAgent.IsElementFound("SystemTray", "AssessmentManager"))
                return true;
            else
                return false;
        }

        public static bool VerifyAssessmentReports(AutomationAgent systemTrayAutomationAgent)
        {
            if (systemTrayAutomationAgent.IsElementFound("SystemTray", "AssessmentReport"))
                return true;
            else
                return false;
        }
        public static void ClickAssessmentManager(AutomationAgent systemTrayAutomationAgent)
        {
            systemTrayAutomationAgent.Click("SystemTray", "AssessmentManager");
        }

        public static bool VerifyAssessmentManagerMenu(AutomationAgent systemTrayAutomationAgent)
        {
            string menu = systemTrayAutomationAgent.GetTextIn("SystemTray", "AssessmentManagerMenu", "Inside", "");
            return (menu.Contains("MATH") && menu.Contains("Sec") || menu.Contains("Per"));
        }
        public static void ClickAssessmentReports(AutomationAgent systemTrayAutomationAgent)
        {
            systemTrayAutomationAgent.Click("SystemTray", "AssessmentReport");
        }
        public static string GetTextOfAssessmentMenu(AutomationAgent systemTrayAutomationAgent)
        {
            string menu = systemTrayAutomationAgent.GetTextIn("SystemTray", "AssessmentManagerMenu", "Inside", "");
            string submenu = menu.Replace("\t\n", "");
            return submenu;
        }
        public static void ClickSubMenuInAssessmentReports(AutomationAgent systemTrayAutomationAgent)
        {
            systemTrayAutomationAgent.Click("SystemTray", "AssessmentManagerMenu");
        }
        public static bool VerifyGoBackButton(AutomationAgent systemTrayAutomationAgent)
        {
            return systemTrayAutomationAgent.IsElementFound("TeacherSupport", "BackIcon");
        }
        public static bool VerifySettingsButton(AutomationAgent systemTrayAutomationAgent)
        {
            return systemTrayAutomationAgent.IsElementFound("UnitSelection", "SettingsButton");
        }
        public static bool VerifyRefreshButton(AutomationAgent systemTrayAutomationAgent)
        {
            return systemTrayAutomationAgent.IsElementFound("SystemTray", "RefreshButton");
        }
        public static void ClickLoginButtonInStudentScreen(AutomationAgent systemTrayAutomationAgent)
        {
            systemTrayAutomationAgent.Click("StudentSetup", "Login");
        }
        public static int GetInboxCountInSystemTray(AutomationAgent systemTrayAutomationAgent)
        {
            string badgeCount=systemTrayAutomationAgent.GetElementProperty("SystemTray", "InboxBadgeInSystemTray", "text");
            int n = int.Parse(badgeCount);
            return n;
        }
        public static bool VerifyInboxCountBadge(AutomationAgent systemTrayAutomationAgent)
        {
            return systemTrayAutomationAgent.IsElementFound("StudentSetup", "InboxBadgeInSystemTray");
        }
        



    }
}
