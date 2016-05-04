using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;

namespace SeeTest.Automation.EriBankTests.AndroidControlPages
{
    public static class LoginPage
    {
        private static Control userNameTextbox = new Control("Native", "xpath=//*[@accessibilityIdentifier='usernameTextField']", "UserName", "UserName", "Textbox");
        private static Control passwordTextbox = new Control("Native", "xpath=//*[@accessibilityIdentifier='passwordTextField']", "Password", "Password", "Textbox");
        private static Control loginButton = new Control("Native", "xpath=//*[@accessibilityLabel='loginButton']", "Login", "Login", "Button");
        private static Control loginLabel = new Control("Native", "xpath=//*[@accessibilityLabel='Login']", "Login", "Login", "Label");
        public static Control UserNameTextbox
        {
            get { return userNameTextbox; }
        }

        public static Control PasswordTextbox
        {
            get { return passwordTextbox; }
        }

        public static Control LoginButton
        {
            get { return loginButton; }
        }

        public static Control LoginLabel
        {
            get { return loginLabel; }
        }
    }
}
