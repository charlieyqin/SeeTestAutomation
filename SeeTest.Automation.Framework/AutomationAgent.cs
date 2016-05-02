using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Data;
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
            this.projectBaseDirectory = new Uri(outPutDirectory + "\\" + ConfigurationManager.AppSettings["ProjectBaseDirectory"].ToString()).LocalPath;
            this.SetShowPassImageInReport = bool.Parse(ConfigurationManager.AppSettings["SetShowPassImageInReport"]);
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
            if (!passOrFail && ConfigurationManager.AppSettings["CaptureDeviceLog"].ToString() == "true")
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
        public void Click(Control control, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {            
            client.Click(control.Zone, control.Element, control.Index, clickCount);
        }

        public bool WaitforElement(Control control, int waitTime = WaitTime.DefaultWaitTime)
        {
            return client.WaitForElement(control.Zone, control.Element, control.Index, waitTime);
        }
        
        /// <summary>
        /// Sets the Text to textbox controls
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="textToSet">Text to Set to textbox control</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public void SetText(Control control, string textToSet, int waitTime = WaitTime.DefaultWaitTime)
        {            
            client.ElementSendText(control.Zone, control.Element, control.Index, textToSet);
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
        public bool WaitForElement(Control control, int waitTime = WaitTime.DefaultWaitTime)
        {            
            return client.WaitForElement(control.Zone, control.Element, control.Index, waitTime);
        }

        /// <summary>
        /// Verifies for the Element not to be found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementNotFound(Control control)
        {            
            client.VerifyElementNotFound(control.Zone, control.Element, control.Index);
        }

        /// <summary>
        /// Verifies if an Element is found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementFound(Control control)
        {            
            client.VerifyElementFound(control.Zone, control.Element, control.Index);
        }
                
        /// <summary>
        /// Waits of an Element to vanish from the screen
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public bool WaitForElementToVanish(Control control, int waitTime = WaitTime.DefaultWaitTime)
        {            
            return client.WaitForElementToVanish(control.Zone, control.Element, control.Index, waitTime);
        }

        
        /// <summary>
        /// Gets the property of the Element
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="property">Property name to get the value</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        /// <returns>returns the property string</returns>
        public string GetElementProperty(Control control, string property, int waitTime = WaitTime.DefaultWaitTime)
        {
            return client.ElementGetProperty(control.Zone, control.Element, control.Index, property);
        }

        public bool IsElementEnabled(Control control)
        {            
            return bool.Parse(client.ElementGetProperty(control.Zone, control.Element, control.Index, "enabled"));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="waitTime"></param>
        public void SetElementProperty(Control control, string property, string value)
        {            
            client.ElementSetProperty(control.Zone, control.Element, control.Index, property, value);
        }

        public void LongClick(Control control, int clickCount = 1, int X = 0, int Y = 0)
        {            
            client.LongClick(control.Zone, control.Element, control.Index, clickCount, X, Y);
        }

        public void SwipeElement(Control control, Direction direction, int offSet, int swipeTime)
        {            
            client.ElementSwipe(control.Zone, control.Element, control.Index, direction.ToString(), offSet, swipeTime);
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

        public string[] GetAllValues(Control control, string property)
        {            
            return client.GetAllValues(control.Zone, control.Element, property);
        }
        
        public void RunNativeApICall(Control control, string script)
        {            
            client.RunNativeAPICall(control.Zone, control.Element, control.Index, script);
        }

        public bool IsElementFound(Control control)
        {            
            return client.IsElementFound(control.Zone, control.Element, control.Index);
        }
        
        public void DragElement(Control control, int xOffset, int yOffset)
        {            
            client.Drag(control.Zone, control.Element, control.Index, xOffset, yOffset);
        }

        public void DragAndDrop(Control dragControl, Control dropControl)
        {
            client.DragDrop(dragControl.Zone, dragControl.Element, dragControl.Index, dropControl.Element, dropControl.Index);
        }

        public string GetPosition(Control control)
        {            
            return this.client.GetPosition(control.Zone, control.Element);
        }
        
        public string GetElementText(Control control)
        {            
            return client.ElementGetText(control.Zone, control.Element, control.Index);
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
        }

        public void ClickCoordinate(int x, int y, int clickCount = 1, int sleepTime = WaitTime.DefaultWaitTime)
        {
            this.Sleep(sleepTime);
            client.ClickCoordinate(x, y, clickCount);
        }

        public void Sleep(int milliSeconds = WaitTime.DefaultWaitTime)
        {
            System.Threading.Thread.Sleep(milliSeconds);
        }
        public string GetDeviceLog()
        {            
            return client.GetDeviceLog();
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

        public string GetTextIn(Control control, string direction,  int width = 0, int height = 0)
        {            
            return client.GetTextIn(control.Zone, control.Element, control.Index, direction, width, height);
        }
        
        public string GetTextIn(Control control, string direction,  string textZone, int Index, int width = 0, int height = 0)
        {            
            return client.GetTextIn(control.Zone, control.Element, Index, textZone, direction, width, height);
        }
        
        public void CloseApplication()
        {
            client.ApplicationClose(this.launchingAppName);
        }

        public void VerifyIn(Control control, Control controlToFind, string direction, int width = 0, int height = 0)
        {
            client.VerifyIn(control.Zone, control.Element, control.Index, direction, controlToFind.Zone, controlToFind.Element, width, height);
        }

        public int GetElementCountIn(Control control, Control controlToFind, string direction, int width = 0, int height = 0)
        {
            return client.GetElementCountIn(control.Zone, control.Element, control.Index, direction, controlToFind.Zone, controlToFind.Element, width, height);
        }

        public bool IsFoundIn(Control searchControl, Control controlToFind, string direction, int width = 0, int height = 0)
        {
            return client.IsFoundIn(searchControl.Zone, searchControl.Element, searchControl.Index, direction, controlToFind.Zone, controlToFind.Element, width, height);
        }

        public bool ElementSwipeWhileNotFound(Control swipeControl, Control controlToFind, string direction, int offset = 100, int swipetime = 2000, int delay = 1000, int rounds = 5, bool click = true)
        {
            return client.ElementSwipeWhileNotFound(swipeControl.Zone, swipeControl.Element, direction, offset, swipetime, controlToFind.Zone, controlToFind.Element, controlToFind.Index, delay, rounds, click);
        }

        public bool SwipeWhileNotFound(Control control, string direction, int offset = 100, int swipetime = 2000, int delay = 1000, int rounds = 5)
        {
            return client.SwipeWhileNotFound(direction, offset, swipetime, control.Zone, control.Element, 0, delay, rounds, true);
        }

        public void Install(string ipaFilePath, bool upgrade)
        {
            client.Install(ipaFilePath, upgrade);
        }

        public int GetElementCount(Control control)
        {            
            return client.GetElementCount(control.Zone, control.Element);
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

        public void ElementListSelect(Control control)
        {            
            client.ElementListSelect("", control.Element, control.Index, false);
        }

        public bool SwipeWhileNotFound(Control control, string direction, int offset = 791, int swipetime = 2000, int delay = 1000, int rounds = 10, bool click = true)
        {
            return client.SwipeWhileNotFound(direction, offset, swipetime, control.Zone, control.Element, 0, delay, rounds, click);
        }

        public void ElementListVisible(Control control, string dynamicVariable)
        {            
            client.ElementListVisible("", control.Element, control.Index);
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
    }
}
