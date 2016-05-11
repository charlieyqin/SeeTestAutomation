using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;

namespace SeeTest.Automation.EriBankTests.iOSControlPages
{
    public static class DashboardPage
    {
        private static Control eriBankLogo;
        public static Control EriBankLogo
        {
            get
            {
                if (eriBankLogo == null)
                {
                    eriBankLogo = new Control("Default", "EriBankLogo", "EriBankLogo", "eribank", "Image");
                }
                return eriBankLogo;
            }
        }

        private static Control balanceLabel;
        public static Control BalanceLabel
        {
            get
            {
                if (balanceLabel == null)
                {
                    balanceLabel = new Control("Web", "xpath=//*[@nodeName='H1']", "BalanceLabel", "Your balance is: {0}$", "Label");
                }
                return balanceLabel;
            }
        }

        private static Control makePaymentBtnLabel;
        public static Control MakePaymentBtnLabel
        {
            get
            {
                if (makePaymentBtnLabel == null)
                {
                    makePaymentBtnLabel = new Control("Native", "xpath=//*[@text='Make Payment']", "MakePaymentBtnLabel", "Make Payment", "ButtonLabel");
                }
                return makePaymentBtnLabel;
            }
        }

        private static Control mortgageRequestBtnLabel;
        public static Control MortgageRequestBtnLabel
        {
            get
            {
                if (mortgageRequestBtnLabel == null)
                {
                    mortgageRequestBtnLabel = new Control("Native", "xpath=//*[@text='Mortgage Request']", "MortgageRequestBtnLabel", "Mortgage Request", "ButtonLabel");
                }
                return mortgageRequestBtnLabel;
            }
        }

        private static Control expenseReportBtnLabel;
        public static Control ExpenseReportBtnLabel
        {
            get
            {
                if (expenseReportBtnLabel == null)
                {
                    expenseReportBtnLabel = new Control("Native", "xpath=//*[@text='Expense Report']", "ExpenseReportBtnLabel", "Expense Report", "ButtonLabel");
                }
                return expenseReportBtnLabel;
            }
        }

        private static Control logoutBtnLabel;
        public static Control LogoutBtnLabel
        {
            get
            {
                if (logoutBtnLabel == null)
                {
                    logoutBtnLabel = new Control("Native", "xpath=//*[@text='Logout']", "LogoutBtnLabel", "Logout", "ButtonLabel");
                }
                return logoutBtnLabel;
            }
        }
    }
}
