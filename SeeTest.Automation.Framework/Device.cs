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
        private string name;
        private string seeTestDeviceName;
        private string connectedOver;
        private string version;
        private int port;

        public Device(string name, string seeTestDeviceName, string connectedOver, string version, int port = 8889)
        {
            this.name = name;
            this.seeTestDeviceName = seeTestDeviceName;
            this.connectedOver = connectedOver;
            this.version = version;
            this.port = port;
        }

        public Device(XElement deviceXElement)
        {
            name = deviceXElement.Attribute("DeviceName").Value;
            seeTestDeviceName = deviceXElement.Element("SeeTestDeviceName").Value;
            version = deviceXElement.Element("Version").Value;
            connectedOver = deviceXElement.Element("ConnectedOver").Value;
            port = int.Parse(deviceXElement.Element("Port").Value);
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string SeeTestDeviceName
        {
            get
            {
                return seeTestDeviceName;
            }
        }
        public string Version
        {
            get
            {
                return version;
            }
        }
        public string ConnectedOver
        {
            get
            {
                return connectedOver;
            }
        }
        public int Port
        {
            get
            {
                return port;
            }
        }
    }
}
