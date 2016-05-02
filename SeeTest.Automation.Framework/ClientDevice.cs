using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using experitestClient;

namespace SeeTest.Automation.Framework
{
    public class ClientDevice
    {
        public string HostName { get; private set; }
        public string SeeTestDeviceName { get; private set; }
        public string Version { get; private set; }
        public string ConnectedOver { get; private set; }
        public int Port { get; private set; }
        public Device Device { get; private set; }
        public Client Client { get; private set; }
        public bool IsClientReady { get; set; }

        public ClientDevice (Client client, Device device,  bool isclientReady)
        {
            this.Client = client;
            this.Device = device;            
            this.IsClientReady = isclientReady;
        }
        public ClientDevice(XElement deviceXElement)
        {
            this.HostName = deviceXElement.Element("Host").Value;
            this.SeeTestDeviceName = deviceXElement.Element("SeeTestDeviceName").Value;
            this.Version = deviceXElement.Element("Version").Value;
            this.ConnectedOver = deviceXElement.Element("ConnectedOver").Value;
            this.Port = int.Parse(deviceXElement.Element("Port").Value);
            this.Client = new Client(HostName, Port, true);
            this.Device = new Device(deviceXElement);
            this.IsClientReady = true;
        }
   
    }
}
