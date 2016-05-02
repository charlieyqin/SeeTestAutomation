using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;

namespace SeeTest.Automation.EriBankTests.ControlPages
{
    public static class LoginPage
    {
        public static Control UserNameTextbox()
        {
            return new Control("Native", "xpath=//*[@accessibilityIdentifier='usernameTextField']", "UserName", "UserName", "Textbox");
        }

        public static Control PasswordTextbox()
        {
            return new Control("Native", "xpath=//*[@accessibilityIdentifier='passwordTextField']", "Password", "Password", "Textbox");
        }

        public static Control LoginButton()
        {
            return new Control("Native", "xpath=//*[@accessibilityLabel='loginButton']", "Login", "Login", "Button");
        }

        public static Control LoginLabel()
        {
            return new Control("Native", "xpath=//*[@accessibilityLabel='Login']", "Login", "Login", "Label");
        }
    }
}
