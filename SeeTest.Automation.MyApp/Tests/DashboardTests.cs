using System;
using SeeTest.Automation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.EriBankTests.CommonMethods;

namespace SeeTest.Automation.EriBankTests.Tests
{
    [TestClass]
    public class DashboardTests
    {
        public AutomationAgent loginAutomationAgent;
        [TestMethod]
        public void VerifyBalance()
        {
            using (loginAutomationAgent = new AutomationAgent("Verify balance"))
            {
                try
                {
                    LoginActions.Login(loginAutomationAgent, "company", "company");
                    Assert.AreEqual<string>("100.00$", DashboardActions.GetBalance(loginAutomationAgent));
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
