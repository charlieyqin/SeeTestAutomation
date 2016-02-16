using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Data;
using Excel;
using experitestClient;

namespace SeeTest.Automation.Framework
{
    public class AutomationAgent : IDisposable
    {
        ClientDevice clientDevice;
        Client client;
        Device device;
        string testDetails;
        static string reporterFolder = ConfigurationManager.AppSettings["ReporterFolder"].ToString();
        string projectBaseDirectory;
        string appName;
        string launchingAppName;
        string osName;
        private Control control = null;
        XElement rootXElement;
        bool SetShowPassImageInReport;

        public AutomationAgent(string testDetails, bool launchApp = true)
        {
            if (ConfigurationManager.AppSettings["IsParallelTestExecution"].ToString() == "true")
            {
                this.clientDevice = ClientDeviceFactory.AvailableClientDevice;
            }
            else
            {
                this.clientDevice = SingletonClientDevice.clientDevice;
                clientDevice.IsClientReady = false;
            }
            this.client = this.clientDevice.Client;
            this.device = this.clientDevice.Device;
            this.testDetails = testDetails;
            this.appName = ConfigurationManager.AppSettings["AppName"].ToString();
            if (ConfigurationManager.AppSettings["DevCodeBranch"].ToString() == "CADevelop")
            {
                this.launchingAppName = ConfigurationManager.AppSettings["CADevLaunchingAppName"].ToString();
            }
            else
            {
                this.launchingAppName = ConfigurationManager.AppSettings["DevLaunchingAppName"].ToString();
            }
            this.osName = ConfigurationManager.AppSettings["OS"].ToString();
            //Load the rootXElement from controls.xml
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string xmlfilepath = Path.Combine(outPutDirectory, "Xml\\Controls.xml");
            string xmlfile_path = new Uri(xmlfilepath).LocalPath;
            this.projectBaseDirectory = new Uri(outPutDirectory + "\\" + ConfigurationManager.AppSettings["ProjectBaseDirectory"].ToString()).LocalPath;
            this.SetShowPassImageInReport = bool.Parse(ConfigurationManager.AppSettings["SetShowPassImageInReport"]);
            //this.reporterFolder = new Uri(outPutDirectory.Remove(outPutDirectory.Length - 10) + "\\" + ConfigurationManager.AppSettings["ProjectBaseDirectory"].ToString() + "\\" + ConfigurationManager.AppSettings["ReporterFolder"].ToString()).LocalPath;
            this.rootXElement = XElement.Load(xmlfile_path).Elements("OS").Where(os => os.Attribute("OSName").Value == this.osName).FirstOrDefault<XElement>();
            InitializeClientAndLaunchApp(launchApp);
        }

        #region Properites
        public ClientDevice ClientDevice
        {
            get
            {
                return this.clientDevice;
            }
        }
        public string ReporterFolder
        {
            get
            {
                return reporterFolder;
            }
        }

        public string ProjectBaseDirectory
        {
            get
            {
                return projectBaseDirectory;
            }
        }

        public string AppName
        {
            get
            {
                return appName;
            }
        }

        public string LaunchingAppName
        {
            get
            {
                return launchingAppName;
            }
        }
        public string OsName
        {
            get
            {
                return osName;
            }
        }
        #endregion

        #region AutomationAgentPrivateMethods

        /// <summary>
        /// Populates the control property of AutomationAgent for current client method execution
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        private void PopulateControl(string viewName, string controlName)
        {
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == viewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == controlName).FirstOrDefault<XElement>();
            this.control = new Control(controlXElement);
        }

        private Control PopulateDynamicControl(string viewName, string controlName, string dynamicVariable)
        {
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == viewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == controlName).FirstOrDefault<XElement>();
            this.control = new Control(controlXElement);
            string updatedElement = this.control.Element.Replace("()", dynamicVariable);
            string updatedControlText = this.control.ControlText.Replace("()", dynamicVariable);
            this.control.Element = updatedElement;
            this.control.ControlText = updatedControlText;
            return this.control;
        }
        /// <summary>
        /// Initializes the Client and Launches the App
        /// </summary>
        private void InitializeClientAndLaunchApp(bool launchApp)
        {
            client.SetProjectBaseDirectory(ProjectBaseDirectory);
            client.SetReporter("xml", reporterFolder, testDetails);
            client.SetShowPassImageInReport(this.SetShowPassImageInReport);
            client.SetDevice(device.SeeTestDeviceName);
            if (bool.Parse(ConfigurationManager.AppSettings["MonitorCPUAndMemory"].ToString()))
            {
                client.StartMonitor("cpu");
                client.StartMonitor("memory");
            }
            client.SendText("{LANDSCAPE}");
            client.SetProperty("ios.elementsendtext.action.fire", "true");
            if (launchApp)
            {
                this.LaunchApp();
        }
        }

        public void LaunchDevice2()
        {
            client.ReleaseDevice(ConfigurationManager.AppSettings["SeeTestDeviceName"].ToString(), false, false, true);
            client.SetDevice(ConfigurationManager.AppSettings["SeeTestDevice2"].ToString());
            client.SetProperty("ios.elementsendtext.action.fire", "true");
            this.LaunchApp();
        }

        public void LaunchDevice1()
        {
            client.ReleaseDevice(ConfigurationManager.AppSettings["SeeTestDevice2"].ToString(), false, false, true);
            client.SetDevice(ConfigurationManager.AppSettings["SeeTestDeviceName"].ToString());
            client.SetProperty("ios.elementsendtext.action.fire", "true");
            this.LaunchApp();
        }

        public static void CreateAndSetReportsFolder(string appName)
        {
            string fullFolderPath = ConfigurationManager.AppSettings["ReporterFolder"].ToString() + "\\" + appName + "_" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss");
            Directory.CreateDirectory(fullFolderPath);
            reporterFolder = fullFolderPath;
        }

        public void LaunchApp()
        {
            client.Launch(launchingAppName, true, false);
            client.SetProperty("ios.elementsendtext.action.fire", "true");
            client.SendText("{Landscape}");
        }

        public void ApplicationClose()
        {
            client.ApplicationClose(launchingAppName);            
        }

        public void AddSteptoSeeTestReport(string message, bool passOrFail)
        {
            client.Report(message, passOrFail);
            if (!passOrFail && ConfigurationManager.AppSettings["CaptureDeviceLog"].ToString()=="true")
            client.GetDeviceLog();
        }

        #endregion

        #region ClientMethods
        /// <summary>
        /// Performs Click on the control with the given viewname and controlname.
        /// Default clickcount is 1 and waittime is 10 sec
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml </param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="clickCount">Default click count is 1. Provide a valid integer value</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public void Click(string viewName, string controlName, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            client.Click(this.control.Zone, this.control.Element, this.control.Index, clickCount);
        }

        public bool WaitforElement(string viewName, string controlName, string dynamicVariable, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }

        public bool WaitforElement(string Zone, string viewName, string controlName, string dynamicVariable, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.WaitForElement(Zone, this.control.Element, this.control.Index, waitTime);
        }

        public void Click(string viewName, string controlName, string dynamicVariable, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.Click(this.control.Zone, this.control.Element, this.control.Index, clickCount);
        }

        public void Click(string viewName, string controlName, string dynamicVariable, int Index, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.Click(this.control.Zone, this.control.Element, Index, clickCount);
        }

        /// <summary>
        /// Sets the Text to textbox controls
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="textToSet">Text to Set to textbox control</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public void SetText(string viewName, string controlName, string textToSet, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            client.ElementSendText(this.control.Zone, this.control.Element, this.control.Index, textToSet);
        }

        public void SetText(string viewName, string controlName, string textToSet, int waitTime, string dynamicVariable)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.ElementSendText(this.control.Zone, this.control.Element, this.control.Index, textToSet);
        }

        public void SendText(string text)
        {
            client.SendText(text);
            this.Sleep(500);
        }

        public void ClickOnScreen(int x = 0, int y = 0, int clickCount = 1)
        {
            this.Sleep();
            client.ClickCoordinate(x, y, clickCount);
        }

        /// <summary>
        /// Waits for the Control to exist on the screen
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="waitTime">Max Time to wait for the control existence</param>
        public bool WaitForElement(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }

        /// <summary>
        /// Verifies for the Element not to be found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementNotFound(string viewName, string controlName)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateControl(viewName, controlName);
            client.VerifyElementNotFound(this.control.Zone, this.control.Element, this.control.Index);
        }

        /// <summary>
        /// Verifies for the Element not to be found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementNotFound(string viewName, string controlName, string dynamicVariable)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.VerifyElementNotFound(this.control.Zone, this.control.Element, this.control.Index);
        }

        /// <summary>
        /// Verifies if an Element is found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementFound(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            client.VerifyElementFound(this.control.Zone, this.control.Element, this.control.Index);
        }
               
        /// <summary>
        /// Verifies if an Element is found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementFound(string viewName, string controlName, string dynamicVariable)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.VerifyElementFound(this.control.Zone, this.control.Element, this.control.Index);
        }

        public void VerifyElementFound(string viewName, string controlName, string dynamicVariable, string Zone)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateControl(viewName, controlName);
            client.VerifyElementFound(Zone, this.control.Element, this.control.Index);
        }


        public void VerifyElementFoundInZone(string zone, string element, int index)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            client.VerifyElementFound(zone, element, index);
        }

        /// <summary>
        /// Waits of an Element to vanish from the screen
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public bool WaitForElementToVanish(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return client.WaitForElementToVanish(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }

        /// <summary>
        /// Waits of an Element to vanish from the screen
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public bool WaitForElementToVanish(string viewName, string controlName, string dynamicVariable, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.WaitForElementToVanish(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }
        /// <summary>
        /// Gets the property of the Element
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="property">Property name to get the value</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        /// <returns>returns the property string</returns>
        public string GetElementProperty(string viewName, string controlName, string property, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return client.ElementGetProperty(this.control.Zone, this.control.Element, this.control.Index, property);
        }

        /// <summary>
        /// Gets the property of the Element
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="property">Property name to get the value</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        /// <returns>returns the property string</returns>
        public string GetElementProperty(string viewName, string controlName, string property, int index, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return client.ElementGetProperty(this.control.Zone, this.control.Element, index, property);
        }
        public string GetElementProperty(string viewName, string controlName, string property, string dynamicvalue, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicvalue);
            return client.ElementGetProperty(this.control.Zone, this.control.Element, this.control.Index, property);
        }



        public bool IsElementEnabled(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return bool.Parse(client.ElementGetProperty(this.control.Zone, this.control.Element, this.control.Index, "enabled"));
        }

        public bool IsElementEnabled(string viewName, string controlName, string dynamicVariable, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return bool.Parse(client.ElementGetProperty(this.control.Zone, this.control.Element, this.control.Index, "enabled"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="waitTime"></param>
        public void SetElementProperty(string viewName, string controlName, string property, string value, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            client.ElementSetProperty(this.control.Zone, this.control.Element, this.control.Index, property, value);
        }

        public void LongClick(string viewName, string controlName, int clickCount = 1, int X = 0, int Y = 0)
        {
            this.PopulateControl(viewName, controlName);
            client.LongClick(this.control.Zone, this.control.Element, this.control.Index, clickCount, X, Y);
        }

        public void LongClick(string viewName, string controlName, string dynamicVariable, int clickCount = 1, int X = 0, int Y = 0)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.LongClick(this.control.Zone, this.control.Element, this.control.Index, clickCount, X, Y);
        }

        public void SwipeElement(string viewName, string controlName, Direction direction, int offSet, int swipeTime)
        {
            this.PopulateControl(viewName, controlName);
            client.ElementSwipe(this.control.Zone, this.control.Element, this.control.Index, direction.ToString(), offSet, swipeTime);
        }


        public void SwipeElement(string viewName, string controlName, string dynamicVaiable, Direction direction, int offSet, int swipeTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVaiable);
            client.ElementSwipe(this.control.Zone, this.control.Element, this.control.Index, direction.ToString(), offSet, swipeTime);
        }


        public void Swipe(Direction direction, int offSet = 500)
        {
            client.Swipe(direction.ToString(), offSet);
        }

        public void SwipeRight()
        {
            client.Swipe(Direction.Right.ToString(), 100);
        }

        public void SwipeLeft()
        {
            client.Swipe(Direction.Left.ToString(), 100);
        }

        public string[] GetAllValues(string viewName, string controlName, string property)
        {
            this.PopulateControl(viewName, controlName);
            return client.GetAllValues(this.control.Zone, this.control.Element, property);
        }

        public string[] GetAllValues(string viewName, string controlName, string dynamicVariable, string property)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetAllValues(this.control.Zone, this.control.Element, property);
        }

        public string[] GetAllValues(string viewName, string controlName, string zone, string dynamicVariable, string property)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetAllValues(zone, this.control.Element, property);
        }


        public void RunNativeApICall(string viewName, string controlName, string script)
        {
            this.PopulateControl(viewName, controlName);
            client.RunNativeAPICall(this.control.Zone, this.control.Element, this.control.Index, script);
        }

        public bool IsElementFound(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            return client.IsElementFound(this.control.Zone, this.control.Element, this.control.Index);

        }

        public bool IsElementFound(string viewName, string controlName, string dynamicVariable)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.IsElementFound(this.control.Zone, this.control.Element);
        }

        public bool IsElementFound(string viewName, string controlName, string dynamicVariable, string zone)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.IsElementFound(zone, this.control.Element, this.control.Index);
        }

        public void DragElement(string viewName, string controlName, int xOffset, int yOffset)
        {
            this.PopulateControl(viewName, controlName);
            client.Drag(this.control.Zone, this.control.Element, this.control.Index, xOffset, yOffset);
        }

        public void DragAndDrop(string dragElementviewName, string dragElementcontrolName, string dropElementViewName, string dropElementControlName)
        {
            this.PopulateControl(dragElementviewName, dragElementcontrolName);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == dropElementViewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == dropElementControlName).FirstOrDefault<XElement>();
            Control dropControl = new Control(controlXElement);
            client.DragDrop(this.control.Zone, this.control.Element, this.control.Index, dropControl.ControlName, dropControl.Index);
        }


        public void DragAndDrop(string dragElementviewName, string dragElementcontrolName, string dynamicVariable, string dropElementViewName, string dropElementControlName)
        {
            this.PopulateDynamicControl(dragElementviewName, dragElementcontrolName, dynamicVariable);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == dropElementViewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == dropElementControlName).FirstOrDefault<XElement>();
            Control dropControl = new Control(controlXElement);
            client.DragDrop(this.control.Zone, this.control.Element, this.control.Index, dropControl.Element, dropControl.Index);
        }

        public void DragAndDrop(string dragElementviewName, string dragElementcontrolName, string dragElementDynamicVariable, string dropElementViewName, string dropElementControlName, string dropElementDynamicVariable)
        {
            Control dropControl = this.PopulateDynamicControl(dropElementViewName, dropElementControlName, dropElementDynamicVariable);
            this.PopulateDynamicControl(dragElementviewName, dragElementcontrolName, dragElementDynamicVariable);            
            client.DragDrop(this.control.Zone, this.control.Element, this.control.Index, dropControl.Element, dropControl.Index);
        }

        public string GetPosition(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            return this.client.GetPosition(this.control.Zone, this.control.Element);

        }

        public string GetPosition(string viewName, string controlName, string dynamicVar)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVar);
            return this.client.GetPosition(this.control.Zone, this.control.Element);
        }


        public string GetElementText(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            return client.ElementGetText(this.control.Zone, this.control.Element, this.control.Index);
        }

        public string GetElementText(string viewName, string controlName, int index)
        {
            this.PopulateControl(viewName, controlName);
            return client.ElementGetText(this.control.Zone, this.control.Element, index);
        }
        public string GetElementText(string viewName, string controlName, string dynamicvar)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicvar);
            return client.ElementGetText(this.control.Zone, this.control.Element, this.control.Index);
        }

        public string GetElementText(string Zone, string viewName, string controlName, string dynamicvar)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicvar);
            return client.ElementGetText(Zone, this.control.Element, this.control.Index);
        }
        public string GetText(string zone)
        {
            return client.GetText(zone);
        }

        /// <summary>
        /// Performs pinch in/zoom in action on the screen at the given x & Y coordinates of the screen. Not supplying any parameters, performs pinch in at the center of the screen with a radius 100 pixels.
        /// </summary>
        /// <param name="xCoordinate">X Co ordinate where pinch in should be performed, default is 0</param>
        /// <param name="yCoordinate">Y Co ordinate where pinch in should be performed, default is 0</param>
        /// <param name="pinchRadius">Radius of pinch circle. default is 100</param>
        /// <returns>bool value indicating action success or failure</returns>
        public bool PinchIn(int xCoordinate = 0, int yCoordinate = 0, int pinchRadius = 100)
        {
            return client.Pinch(true, xCoordinate, yCoordinate, pinchRadius);
        }

        /// <summary>
        /// Performs pinch out or zoom out action on the screen at the given x and Y coordinates of the screen
        /// Not supplying any parameters, performs pinch out at the center of the screen with a radius 100 pixels.
        /// </summary>
        /// <param name="xCoordinate">X Co ordinate where pinch out should be performed default is 0</param>
        /// <param name="yCoordinate">Y Co ordinate where pinch out should be performed default is 0</param>
        /// <param name="pinchRadius">Radius of pinch out circle default is 100</param>
        /// <returns>bool value indicating action success or failure</returns>
        public bool PinchOut(int xCoordinate = 0, int yCoordinate = 0, int pinchRadius = 100)
        {
            return client.Pinch(false, xCoordinate, yCoordinate, pinchRadius);
        }

        public void Drag(int fromX1, int fromY1, int toX2, int toY2, int dragTime = 1000)
        {
            client.DragCoordinates(fromX1, fromY1, toX2, toY2, dragTime);
        }

        public void DrawDiamondImage(int x1, int y1, int length = 100)
        {
            int x2 = x1 + length;
            int y2 = y1 + length;
            int x3 = x1 + length / 2;
            int y3 = y1 - length;
            Drag(x1, y1, x2, y1);
            Drag(x3, y3, x3, y2);
            Drag(x2, y1, x3, y3);
            Drag(x3, y3, x1, y1);
            Drag(x1, y1, x3, y2);
            Drag(x3, y2, x2, y1);
        }
        public void InstallApp(string path)
        {
            client.Install(path, true, true);
        }

        public void UninstallApp(string appName)
        {
            client.Uninstall(appName);
        }

        public void AddDevice(string serialNumber, string deviceName)
        {
            client.AddDevice(serialNumber, deviceName);
        }

        public void CaptureScreenshot(string screenshotMessage)
        {
            client.Capture(screenshotMessage);

            try
            {
                VerifyElementFound("AssertExceptionHandle", "DummyException");
        }
            catch (Exception)
            {
                //Temp solution need to remove
        }

        }

        public void ClickCoordinate(int x, int y, int clickCount = 1)
        {
            this.Sleep();
            client.ClickCoordinate(x, y, clickCount);
        }

        public void Sleep(int milliSeconds = WaitTime.DefaultWaitTime)
        {
            System.Threading.Thread.Sleep(milliSeconds);
        }
        public string GetDeviceLog()
        {
            return "";
            //return client.GetDeviceLog();
        }

        #endregion

        public void GenerateReportAndReleaseClient()
        {
            this.client.GenerateReport(true);
            this.clientDevice.IsClientReady = true;
        }

        public void Dispose()
        {
            this.GenerateReportAndReleaseClient();
        }

        public void Swipe(Direction direction, int offset, int time)
        {
            client.Swipe(direction.ToString(), offset, time);
        }

        public string GetTextIn(string viewName, string controlName, string direction, string dynamicVariable, int width = 0, int height = 0)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetTextIn(this.control.Zone, this.control.Element, this.control.Index, direction, width, height);
        }

        public string GetTextIn(string viewName, string controlName, string direction, string dynamicVariable, int Index, int width = 0, int height = 0)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);            
            return client.GetTextIn(this.control.Zone, this.control.Element, Index, direction, width, height);
        }

        public string GetTextIn(string viewName, string controlName, string direction, string dynamicVariable, string textZone, int Index, int width = 0, int height = 0)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetTextIn(this.control.Zone, this.control.Element, Index, textZone, direction, width, height);
        }

        public string GetTextIn(string viewName, string controlName, string TextZone, string direction, string dynamicVariable, int width = 0, int height = 0)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetTextIn(this.control.Zone, this.control.Element, this.control.Index, TextZone, direction, width, height);
        }

        public void CloseApplication()
        {
            client.ApplicationClose(this.launchingAppName);
        }

        public void VerifyIn(string viewName, string controlName, string direction, string elementFindViewName, string elementFindControlName, int width = 0, int height = 0)
        {
            this.PopulateControl(viewName, controlName);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == elementFindViewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == elementFindControlName).FirstOrDefault<XElement>();
            Control elementToFindControl = new Control(controlXElement);
            client.VerifyIn(this.control.Zone, this.control.Element, this.control.Index, direction, elementToFindControl.Zone, elementToFindControl.Element, width, height);
        }

        public int GetElementCountIn(string viewName, string controlName, string direction, string elementFindViewName, string elementFindControlName, int width = 0, int height = 0)
        {
            this.PopulateControl(viewName, controlName);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == elementFindViewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == elementFindControlName).FirstOrDefault<XElement>();
            Control elementToFindControl = new Control(controlXElement);
            return client.GetElementCountIn(this.control.Zone, this.control.Element, this.control.Index, direction, elementToFindControl.Zone, elementToFindControl.Element, width, height);
        }
        public bool IsFoundIn(string viewName, string controlName, string direction, string zone, int width = 0, int height = 0)
        {
            this.PopulateControl(viewName, controlName);
            return client.IsFoundIn(this.control.Zone, this.control.Element, this.control.Index, direction, zone, this.control.Element, width, height);
        }

        public bool ElementSwipeWhileNotFound(string swipeElementViewName, string swipeElementControlName, string searchElementviewName, string searchElementcontrolName, string dynamicVariable, string direction, int offset = 100, int swipetime = 2000, int delay = 1000, int rounds = 5, bool click = true)
        {
            this.PopulateDynamicControl(searchElementviewName, searchElementcontrolName, dynamicVariable);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == swipeElementViewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == swipeElementControlName).FirstOrDefault<XElement>();
            Control swipeControl = new Control(controlXElement);
            return client.ElementSwipeWhileNotFound(swipeControl.Zone, swipeControl.Element, direction, offset, swipetime, this.control.Zone, this.control.Element, this.control.Index, delay, rounds, click);
        }

        public bool SwipeWhileNotFound(string searchElementviewName, string searchElementcontrolName, string dynamicVariable, string direction, int offset = 100, int swipetime = 2000, int delay = 1000, int rounds = 5)
        {
            this.PopulateDynamicControl(searchElementviewName, searchElementcontrolName, dynamicVariable);
            return client.SwipeWhileNotFound(direction, offset, swipetime, this.control.Zone, this.control.Element, 0, delay, rounds, true);
        }

        public void Install(string ipaFilePath, bool upgrade)
        {
            client.Install(ipaFilePath, upgrade);
        }

        public int GetElementCount(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            return client.GetElementCount(this.control.Zone, this.control.Element);
        }

        public int GetElementCount(string viewName, string controlName, string dynamicVariable)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetElementCount(this.control.Zone, this.control.Element);
        }

        public int GetElementCount(string Zone, string viewName, string controlName, string dynamicVariable)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.GetElementCount(Zone, this.control.Element);
        }

        public void SetDragStartDelay(int delay)
        {
            client.SetDragStartDelay(delay);
        }

        public void CloseKeyboard()
        {
            client.SendText("{CLOSEKEYBOARD}");
        }

        public void SetDefaultClickDownTime()
        {
            client.SetDefaultClickDownTime(100);
        }

        public void ElementListSelect(string viewName, string controlName, string dynamicVariable)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.ElementListSelect("", this.control.Element, this.control.Index, false);
            
        }
        public bool SwipeWhileNotFound(string searchElementviewName, string searchElementcontrolName, string direction, int offset = 791, int swipetime = 2000, int delay = 1000, int rounds = 10, bool click = true)
        {
            this.PopulateControl(searchElementviewName, searchElementcontrolName);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == searchElementviewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == searchElementcontrolName).FirstOrDefault<XElement>();
            Control swipeControl = new Control(controlXElement);           
            return client.SwipeWhileNotFound(direction, offset, swipetime, swipeControl.Zone, swipeControl.Element, 0, delay, rounds, click);
        }
        public void ElementListVisible(string viewName, string controlName, string dynamicVariable)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.ElementListVisible("", this.control.Element, this.control.Index);
        }

        public bool IsAppInstalled(string appName)
        {
           return client.GetInstalledApplications().Contains(appName);
        }
       
        public void DrawLineImage(int x1, int y1, int length = 100)
        {
            int x2 = x1 + length;   
            Drag(x1, y1, x2, y1);
        }

        #region ExcelMethods
        public static DataSet ReadExcelToFillData(string filePath, bool IsFirstRowAsColumnNames = true)
        {

            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            if (Path.GetExtension(filePath).Equals(".xls"))
            {
                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                //...
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //...
                //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                excelReader.IsFirstRowAsColumnNames = IsFirstRowAsColumnNames;

                DataSet result = excelReader.AsDataSet();
                //...
                ////4. DataSet - Create column names from first row
                //excelReader.IsFirstRowAsColumnNames = true;
                //DataSet result = excelReader.AsDataSet();

                //5. Data Reader methods
                while (excelReader.Read())
                {
                    //excelReader.GetInt32(0);
                }

                //6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close();

                if (!IsFirstRowAsColumnNames)
                {

                    foreach (DataColumn column in result.Tables[0].Columns)
                    {
                        string cName = result.Tables[0].Rows[2][column.ColumnName].ToString();
                        if (!result.Tables[0].Columns.Contains(cName) && cName != "")
                        {
                            column.ColumnName = cName;
                        }
                    }

                }

                return result;

            }

            else
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                excelReader.IsFirstRowAsColumnNames = IsFirstRowAsColumnNames;
                DataSet result = excelReader.AsDataSet();
                //...
                ////4. DataSet - Create column names from first row
                //excelReader.IsFirstRowAsColumnNames = true;
                //DataSet result = excelReader.AsDataSet();

                //5. Data Reader methods
                while (excelReader.Read())
                {
                    //excelReader.GetInt32(0);
                }

                //6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close();

                if (!IsFirstRowAsColumnNames)
                {

                    foreach (DataColumn column in result.Tables[0].Columns)
                    {
                        string cName = result.Tables[0].Rows[3][column.ColumnName].ToString();
                        if (!result.Tables[0].Columns.Contains(cName) && cName != "")
                        {
                            column.ColumnName = cName;
                        }
                    }

                }


                return result;
            }
        }

        #endregion

    }
}

