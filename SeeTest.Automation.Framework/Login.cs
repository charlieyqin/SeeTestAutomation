using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace SeeTest.Automation.Framework
{
    public class Login
    {
        public Login(XElement loginElement)
        {
            LoginName = loginElement.Attribute("LoginName").Value;
            UserName = loginElement.Element("UserName").Value;
            Password = loginElement.Element("Password").Value;
            PersonName = loginElement.Element("PersonName").Value;
        }

        public static Login GetLogin(string loginName)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string xmlfilepath = Path.Combine(outPutDirectory, "Xml\\Logins.xml");
            string xmlfile_path = new Uri(xmlfilepath).LocalPath;
            XElement loginXElement = XElement.Load(xmlfile_path).Elements("OS").Where(os => os.Attribute("OSName").Value == ConfigurationManager.AppSettings["OS"].ToString()).FirstOrDefault<XElement>().Elements("Login").Where(login => login.Attribute("LoginName").Value == loginName).FirstOrDefault<XElement>();
            return new Login(loginXElement);
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string PersonName { get; private set; }
        public string LoginName { get; private set; }
        
    }

}
