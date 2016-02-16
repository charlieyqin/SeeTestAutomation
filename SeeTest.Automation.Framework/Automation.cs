using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Pearson.PSCAutomation.Framework
{
    [TestClass]
    public static class Automation
    {
        public static void Click(AutomationAgent automationAgent, string viewName, string controlName, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {
            Client client = automationAgent.ClientDevice.Client;
            if (client.WaitForElement("NATIVE", "accessibilityLabel=LOG IN", 0, waitTime))
            {
                // If statement
            }
            client.Click("NATIVE", "accessibilityLabel=LOG IN", 0, 1);
        }
        public static void SetText(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {

        }
        public static void WaitforElement(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {
            
        }

    }
}

