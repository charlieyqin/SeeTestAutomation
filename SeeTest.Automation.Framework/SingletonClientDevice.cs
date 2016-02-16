using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Configuration;
using experitestClient;

namespace SeeTest.Automation.Framework
{
    public class SingletonClientDevice
    {
        private static string host = ConfigurationManager.AppSettings["Host"].ToString();
        private static int port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
        private static string seeTestDeviceName = ConfigurationManager.AppSettings["SeeTestDeviceName"].ToString();
        private static ClientDevice clientDeviceInstance;
        private static Device device = new Device(ConfigurationManager.AppSettings["DeviceName"].ToString(), seeTestDeviceName, ConfigurationManager.AppSettings["ConnectedOver"].ToString(), ConfigurationManager.AppSettings["Version"].ToString());
        private SingletonClientDevice()
        { }

        public static ClientDevice clientDevice
        {
            get
            {
                if (clientDeviceInstance == null)
                {
                    clientDeviceInstance = new ClientDevice(new Client(host, port, true), device, true);                 
                }
                return clientDeviceInstance;
            }
        }

        public static void InitializeClient(AutomationAgent automationAgent)
        {
            Client client = automationAgent.ClientDevice.Client;
            client.SetProjectBaseDirectory(automationAgent.ProjectBaseDirectory);
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var projectbasedirectorypath = Path.Combine(outPutDirectory, ConfigurationManager.AppSettings["ProjectBaseDirectory"].ToString());
            string projectbasedirectory = new Uri(projectbasedirectorypath).LocalPath;
            string reportsdirectory = projectbasedirectory + "\\" + ConfigurationManager.AppSettings["ReporterFolder"].ToString();
            client.SetReporter("xml", reportsdirectory, "loginnlogout");
            client.SetDevice(automationAgent.ClientDevice.Device.SeeTestDeviceName);
            client.Launch(automationAgent.LaunchingAppName, true, false); 
        }

    }
    public static class WaitTime
    {
        public const int DefaultWaitTime = 4000;
        public static readonly float WaitTimeMultiplier = float.Parse(ConfigurationManager.AppSettings["WaitTimeMultiplier"].ToString());
        public static readonly int SmallWaitTime = (int)(int.Parse(ConfigurationManager.AppSettings["SmallWaitTime"].ToString()) * WaitTimeMultiplier);
        public static readonly int MediumWaitTime = (int)(int.Parse(ConfigurationManager.AppSettings["MediumWaitTime"].ToString()) * WaitTimeMultiplier);
        public static readonly int LargeWaitTime = (int)(int.Parse(ConfigurationManager.AppSettings["LargeWaitTime"].ToString()) * WaitTimeMultiplier);
    }

    public enum Direction
    {
        Right,
        Left,
        Down,
        Up
    };
}
