using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using System.Net;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{

    /// <summary>
    /// Summary description for SmokeTests
    /// </summary>
    [TestClass]
    public class SmokeTests
    {
        public AutomationAgent smokeTestAutomationAgent;
        public SmokeTests()
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


        [TestMethod()]
        [TestCategory("212SmokeTests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void UninstallAppAndInstallLatest212Dev()
        {
            using (smokeTestAutomationAgent = new AutomationAgent("Uninstall the existing App And install Latest Dev build", false))
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
                }
                catch (Exception ex)
                {
                    smokeTestAutomationAgent.Sleep(2000);
                    smokeTestAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("212SmokeTests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void UpgradeAppByInstallingLatest212Dev()
        {
            using (smokeTestAutomationAgent = new AutomationAgent("Uninstall the existing App And install Latest Dev build", false))
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
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("212SmokeTests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void NonSectionedUserLoginAndDownloadGrade()
        {
            using (smokeTestAutomationAgent = new AutomationAgent("Non Sectioned user logs in and downloads 4th grade"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    TaskInfo notebookTask = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.LoginWithoutWaitingForSystemTray(smokeTestAutomationAgent, login);
                    NavigationCommonMethods.VerifyGradeSelectionScreen(smokeTestAutomationAgent);
                    smokeTestAutomationAgent.Sleep();
                    LoginLogoutCommonMethods.AddSpecifiedGrade(smokeTestAutomationAgent, notebookTask.Grade);
                    NavigationCommonMethods.WaitForUnitsToDownload(smokeTestAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(smokeTestAutomationAgent, notebookTask.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(smokeTestAutomationAgent, notebookTask.Unit);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(smokeTestAutomationAgent, notebookTask.Lesson);
                    smokeTestAutomationAgent.Sleep();
                    NavigationCommonMethods.WaitForLessonToDownload(smokeTestAutomationAgent, notebookTask.Lesson);
                    NavigationCommonMethods.Logout(smokeTestAutomationAgent, true);
                }
                catch (Exception ex)
                {
                    smokeTestAutomationAgent.Sleep(2000);
                    smokeTestAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    throw;
                }
            }
        }
    }
}
