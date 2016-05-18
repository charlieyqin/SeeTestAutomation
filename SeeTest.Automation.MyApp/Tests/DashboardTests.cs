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

        #region Additional test attributes

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            
        }


        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
            
        }

        #endregion

        [TestMethod]
        [TestCategory("Dashboard")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyInitialBalance()
        {
            using (loginAutomationAgent = new AutomationAgent("Verify balance"))
            {
                try
                {
                    LoginActions.Login(loginAutomationAgent, Login.GetLogin("DefaultUser"));
                    Assert.AreEqual<string>("93.00$", DashboardActions.GetBalance(loginAutomationAgent));
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

        [TestMethod]
        [TestCategory("Dashboard")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void VerifyDefaultControls()
        {
            using (loginAutomationAgent = new AutomationAgent("Verify default controls"))
            {
                try
                {
                    LoginActions.Login(loginAutomationAgent, Login.GetLogin("DefaultUser"));
                    string message;
                    Assert.IsTrue(DashboardActions.VerifyAllDefaultControls(loginAutomationAgent, out message), message);
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
