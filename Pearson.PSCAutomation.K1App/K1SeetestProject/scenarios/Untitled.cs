using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class Untitled
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "D:\\Branch-Code\\SeeTestAutomation\\Pearson.PSCAutomation.K1App\\K1SeetestProject";
        protected Client client = null;
        
        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "Untitled");
        }

        [TestMethod]
        public void TestUntitled()
        {
            // it is recommended to start your script with SetDevice command:
            // client.SetDevice( <Device Name>);
        }

        [TestCleanup()]
        public void TearDown()
        {
        // Generates a report of the test case.
        // For more information - http://experitest.com/studio/help2/WebHelp/help.htm#Report_Of_Executed_Script.htm .
        client.GenerateReport(false);
        // Releases the client so that other clients can approach the agent in the near future. 
        client.ReleaseClient();
        }
    }
}