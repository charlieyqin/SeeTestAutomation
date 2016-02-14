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
        private string projectBaseDirectory = "D:\\Def File\\akanksha\\SeeTestAutomation\\Pearson.PSCAutomation.212App\\212SeeTestProject\\default";
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
            client.GenerateReport(true);
        }
    }
}