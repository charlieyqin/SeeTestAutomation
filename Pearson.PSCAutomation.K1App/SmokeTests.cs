using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using System.Net;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class SmokeTests
    {
        public AutomationAgent smokeTestAutomationAgent;

        [TestMethod()]
        [TestCategory("K1SmokeTests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void UninstallAppAndInstallLatestK1Dev()
        {
            using (smokeTestAutomationAgent = new AutomationAgent("Uninstalls the K1 App and installs the latest dev app", false))
            {
                try
                {
                    string ipaLocalPath, ipaWebPath;
                    ipaWebPath = ConfigurationManager.AppSettings["DevelopWebIpaFilePath"].ToString();
                    ipaLocalPath = ConfigurationManager.AppSettings["DevelopLocalIpaFilePath"].ToString();
                    WebClient wc = new WebClient();
                    wc.DownloadFile(ipaWebPath, ipaLocalPath);
                    if (smokeTestAutomationAgent.IsAppInstalled(ConfigurationManager.AppSettings["DevLaunchingAppName"].ToString()))
                    smokeTestAutomationAgent.UninstallApp(ConfigurationManager.AppSettings["DevLaunchingAppName"].ToString());
                    smokeTestAutomationAgent.Install(ipaLocalPath, true);
                    smokeTestAutomationAgent.Sleep(WaitTime.LargeWaitTime);
                }
                catch (Exception ex)
                {
                    smokeTestAutomationAgent.Sleep(2000);
                    smokeTestAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    smokeTestAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("K1SmokeTests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void UpgradeAppByInstallingLatestK1Dev()
        {
            using (smokeTestAutomationAgent = new AutomationAgent("Upgrades the K1 App by installing the latest dev app", false))
            {
                try
                {
                    string ipaLocalPath, ipaWebPath;
                    ipaWebPath = ConfigurationManager.AppSettings["DevelopWebIpaFilePath"].ToString();
                    ipaLocalPath = ConfigurationManager.AppSettings["DevelopLocalIpaFilePath"].ToString();
                    WebClient wc = new WebClient();
                    wc.DownloadFile(ipaWebPath, ipaLocalPath);
                    smokeTestAutomationAgent.Install(ipaLocalPath, true);
                    smokeTestAutomationAgent.Sleep(WaitTime.LargeWaitTime);
                }

                catch (Exception ex)
                {
                    smokeTestAutomationAgent.Sleep(2000);
                    smokeTestAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    smokeTestAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }
    }
}
