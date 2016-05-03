using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;
#if iOS
using SeeTest.Automation.EriBankTests.iOSControlPages;
#elif Android
using SeeTest.Automation.EriBankTests.AndroidControlPages;
#endif

namespace SeeTest.Automation.EriBankTests.CommonMethods
{
    /// <summary>
    /// Summary description for Navigation
    /// </summary>
    public static class LoginActions
    {
        public static void SetUsername(AutomationAgent agent, string username)
        {
            agent.SetText(LoginPage.UserNameTextbox(), username);
        }

        public static void SetPassword(AutomationAgent agent, string password)
        {
            agent.SetText(LoginPage.PasswordTextbox(), password);
        }

        public static void ClickLogin(AutomationAgent agent)
        {
            agent.Click(LoginPage.LoginButton());
        }

        public static void Login(AutomationAgent agent, string username, string password)
        {
            SetUsername(agent, username);
            SetPassword(agent, password);
            ClickLogin(agent);
        }
    }
}
