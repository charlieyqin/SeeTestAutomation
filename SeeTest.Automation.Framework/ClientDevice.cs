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
        Client client;
        Device device; 
        bool isClientReady;
        string hostName;
        int port;
        string seeTestDeviceName;
        string version;
        string connectedOver;
        Boolean useSessionId = true;
        public ClientDevice (Client client, Device device,  bool isclientReady)
        {
            this.client = client;
            this.device = device;            
            this.isClientReady = isclientReady;
        }
        public ClientDevice(XElement deviceXElement)
        {
            this.hostName = deviceXElement.Element("Host").Value;
            this.seeTestDeviceName = deviceXElement.Element("SeeTestDeviceName").Value;
            this.version = deviceXElement.Element("Version").Value;
            this.connectedOver = deviceXElement.Element("ConnectedOver").Value;
            this.port = int.Parse(deviceXElement.Element("Port").Value);
            this.client = new Client(hostName, port, useSessionId);
            this.device = new Device(deviceXElement);
            this.isClientReady = true;

        }
        public Device Device
        {
            get
            {
                return device;
            }
        }
        public Client Client
        {
            get
            {
                return client;                
            }            
        }
        public bool IsClientReady
        {
            get
            {
                return isClientReady;
            }
            set
            {
                isClientReady = value;
            }
        }        
    }
}
