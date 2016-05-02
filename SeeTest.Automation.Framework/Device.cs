using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeeTest.Automation.Framework
{
    public class Device
    {
        public Device(string name, string seeTestDeviceName, string connectedOver, string version, int port = 8889)
        {
            this.Name = name;
            this.SeeTestDeviceName = seeTestDeviceName;
            this.ConnectedOver = connectedOver;
            this.Version = version;
            this.Port = port;
        }

        public Device(XElement deviceXElement)
        {
            Name = deviceXElement.Attribute("DeviceName").Value;
            SeeTestDeviceName = deviceXElement.Element("SeeTestDeviceName").Value;
            Version = deviceXElement.Element("Version").Value;
            ConnectedOver = deviceXElement.Element("ConnectedOver").Value;
            Port = int.Parse(deviceXElement.Element("Port").Value);
        }

        public string Name { get; set; }
        public string SeeTestDeviceName { get; set; }
        public string Version { get; set; }
        public string ConnectedOver { get; set; }
        public int Port { get; set; }
    }
}
