using System;
using SeeTest.Automation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.EriBankTests.CommonMethods;

namespace SeeTest.Automation.EriBankTests
{
    [TestClass]
    public class LoginTests
    {
        public AutomationAgent loginAutomationAgent;
        [TestMethod]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifySuccessfulLogin()
        {
            using (loginAutomationAgent = new AutomationAgent("Verifying successful Login"))
            {
                try
                {
                    LoginActions.Login(loginAutomationAgent, "company", "company");
                    DashboardActions.ClickLogout(loginAutomationAgent);
                }
                catch (Exception ex)
                {
                    loginAutomationAgent.Sleep(2000);
                    loginAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    loginAutomationAgent.ApplicationClose();
                    loginAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }
    }
}
