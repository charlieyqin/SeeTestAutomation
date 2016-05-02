using System;
using SeeTest.Automation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeeTest.Automation.EriBankTests
{
    [TestClass]
    public class LoginTests
    {
        public AutomationAgent loginAutomationAgent;
        [TestMethod]
        public void VerifySuccessfulLogin()
        {
            using (loginAutomationAgent = new AutomationAgent("Verifying successful Login"))
            {
                try
                {

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
