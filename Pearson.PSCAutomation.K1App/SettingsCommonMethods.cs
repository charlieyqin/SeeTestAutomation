using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace Pearson.PSCAutomation.K1App
{
    public static class SettingsCommonMethods
    {

        /// <summary>
        /// Verify if config code is editable
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        public static void VerifyConfigCodeIsNotEditable(AutomationAgent LoginAutomationAgent)
        {
            LoginAutomationAgent.Click("Settings", "ConfigCodeLabel");
            LoginAutomationAgent.VerifyElementFound("Settings", "ConfigCodeLabel");
        }

        /// <summary>
        /// Verify Unit label display at settings screen 
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber">unit number</param>
        /// <returns></returns>
        public static bool VerifyUnitLableDisplayAtSetting(AutomationAgent SettingAutomationAgent, string unitNumber)
        {
            return SettingAutomationAgent.GetElementText("Settings", "UnitLabel").Contains("Unit " + unitNumber);
        }

        /// <summary>
        /// Verify update content button display for unit which is not downloaded
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        /// <returns>true: when update content display</returns>
        public static bool VerifyUpdateContentLabelPerUnit(AutomationAgent SettingAutomationAgent, string unitNumber)
        {
            return SettingAutomationAgent.IsElementFound("Settings", "UpdateContentUnit", unitNumber.ToString());
        }

        /// <summary>
        /// Verify In Progress button display 
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        public static void VerifyInProgressContentButton(AutomationAgent SettingAutomationAgent)
        {
            SettingAutomationAgent.VerifyElementFound("Settings", "InProgressContentButton");
        }

        /// <summary>
        /// Get the text from app settings screen
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        /// <returns>string: config code</returns>
        public static string GetConfigCodefromAppSettingsScreen(AutomationAgent SettingAutomationAgent)
        {
            string configcode = SettingAutomationAgent.GetAllValues("Settings", "ConfigCodeLabel", "text")[0];
            return configcode;
        }

        /// <summary>
        /// Get the text from device settings screen
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        /// <returns>string: config code</returns>
        public static string GetConfigCodefromDeviceSettingsScreen(AutomationAgent SettingAutomationAgent)
        {
            SettingAutomationAgent.SendText("{HOME}");
            SettingAutomationAgent.Swipe(Direction.Up, 1000, 500);
            if (SettingAutomationAgent.IsElementFound("iPadCommonView", "SearchWindowClearText"))
            {
                SettingAutomationAgent.Click("iPadCommonView", "SearchWindowClearText");
            }
            SettingAutomationAgent.SendText("Settings");
            SettingAutomationAgent.ClickCoordinate(196, 242, 1);
            SettingAutomationAgent.Swipe(Direction.Down, 0, 2000);
            SettingAutomationAgent.Click("iPadCommonView", "AppAtDeviceSettings");
            return SettingAutomationAgent.GetTextIn("iPadCommonView", "ConfigCodeAtDeviceSettings", "TEXT", "Inside", "");
        }

        /// <summary>
        /// Verify update content button 
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        /// <param name="unitNumber"></param>
        public static void VerifyUpdateContentButton(AutomationAgent SettingAutomationAgent)
        {
            SettingAutomationAgent.VerifyElementFound("Settings", "UpdateContentButton");
        }

        /// <summary>
        /// Verify Settings Title 
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        public static void VerifySettingsTitle(AutomationAgent SettingAutomationAgent)
        {
            SettingAutomationAgent.VerifyElementFound("UnitSelection", "SettingsScreen");
        }

        /// <summary>
        /// Verify Status labels for App version number,Configuration Code and Caching Server
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        public static void VerifyStatusLabelOfSettingsScreen(AutomationAgent SettingAutomationAgent)
        {
            SettingAutomationAgent.VerifyElementFound("UnitSelection", "SettingsScreen");
            SettingAutomationAgent.VerifyElementFound("UnitSelection", "SettingsScreen");
            SettingAutomationAgent.VerifyElementFound("UnitSelection", "SettingsScreen");
        }

        /// <summary>
        /// Verify Diplay of Content installation logs title with data(date)
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        public static void VerifyContentInstallationLogsAtSettings(AutomationAgent SettingAutomationAgent)
        {
            string text = SettingAutomationAgent.GetTextIn("Settings", "ContentInstallationDate", "Inside", "");
            Assert.IsTrue((text.Substring(0, 20)).Contains("Content Changes from"));
            DateTime.Parse(text.Substring(20));

        }

        /// <summary>
        /// Verify Collection/place holder for installation and download logs With Subject name on the left side
        /// </summary>
        /// <param name="SettingAutomationAgent">AutomationAgent object</param>
        public static void VerifyDownloadLogsWithSubjectNameAtSettings(AutomationAgent SettingAutomationAgent)
        {
            SettingAutomationAgent.VerifyElementFound("Settings", "GradeLabel");
            SettingAutomationAgent.VerifyElementFound("Settings", "LogsLabel");
        }
    }
}
