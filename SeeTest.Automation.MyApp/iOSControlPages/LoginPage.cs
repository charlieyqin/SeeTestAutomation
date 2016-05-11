using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;

namespace SeeTest.Automation.EriBankTests.iOSControlPages
{
    public static class LoginPage
    {
        private static Control userNameTextbox;
        public static Control UserNameTextbox
        {
            get
            {
                if (userNameTextbox == null)
                {
                    userNameTextbox = new Control("Native", "xpath=//*[@accessibilityIdentifier='usernameTextField']", "UserName", "UserName", "Textbox");
                }
                return userNameTextbox;
            }
        }

        private static Control passwordTextbox;
        public static Control PasswordTextbox
        {
            get
            {
                if (passwordTextbox == null)
                {
                    passwordTextbox = new Control("Native", "xpath=//*[@accessibilityIdentifier='passwordTextField']", "Password", "Password", "Textbox");
                }
                return passwordTextbox;
            }
        }

        private static Control loginButton;
        public static Control LoginButton
        {
            get
            {
                if (loginButton == null)
                {
                    loginButton = new Control("Native", "xpath=//*[@accessibilityLabel='loginButton']", "Login", "Login", "Button");
                }
                return loginButton;
            }
        }

        private static Control loginLabel;
        public static Control LoginLabel
        {
            get
            {
                if (loginLabel == null)
                {
                    loginLabel = new Control("Native", "xpath=//*[@accessibilityLabel='Login']", "Login", "Login", "Label");
                }
                return loginLabel;
            }
        }
    }
}
