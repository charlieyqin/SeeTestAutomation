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
    public static class DashboardActions
    {
        public static string GetBalance(AutomationAgent agent)
        {
            string fullLabel = agent.GetElementText(DashboardPage.BalanceLabel);
            string balance = fullLabel.Substring(fullLabel.IndexOf(':') + 1);
            return balance.Trim();
        }

        public static bool VerifyLogo(AutomationAgent agent)
        {
            return agent.IsElementFound(DashboardPage.EriBankLogo);
        }

        public static bool VerifyAllButtons(AutomationAgent agent, out string message)
        {
            message = string.Empty;
            bool status = true;
            if (!agent.IsElementFound(DashboardPage.MakePaymentBtnLabel))
            {
                message = DashboardPage.MakePaymentBtnLabel.ControlName + " Does not exist \n";
                status = false;
            }
            if (!agent.IsElementFound(DashboardPage.MortgageRequestBtnLabel))
            {
                message = DashboardPage.MortgageRequestBtnLabel.ControlName + " Does not exist \n";
                status = false;
            }
            if (!agent.IsElementFound(DashboardPage.ExpenseReportBtnLabel))
            {
                message = DashboardPage.ExpenseReportBtnLabel.ControlName + " Does not exist \n";
                status = false;
            }
            if (!agent.IsElementFound(DashboardPage.LogoutBtnLabel))
            {
                message = DashboardPage.LogoutBtnLabel.ControlName + " Does not exist \n";
                status = false;
            }
            return status;
        }
        public static bool VerifyAllDefaultControls(AutomationAgent agent, out string message)
        {
            message = string.Empty;
            bool status = true;
            foreach(Control control in DashboardPage.DefaultControls)
            {
                if (!agent.IsElementFound(control))
                {
                    message = control.ControlName + " Does not exist \n";
                    status = false;
                }
            }
            return status;
        }

        public static void ClickMakePayment(AutomationAgent agent)
        {
            agent.Click(DashboardPage.MakePaymentBtnLabel);
        }

        public static void ClickMortgageRequest(AutomationAgent agent)
        {
            agent.Click(DashboardPage.MortgageRequestBtnLabel);
        }

        public static void ClickExpenseReport(AutomationAgent agent)
        {
            agent.Click(DashboardPage.ExpenseReportBtnLabel);
        }

        public static void ClickLogout(AutomationAgent agent)
        {
            agent.Click(DashboardPage.LogoutBtnLabel);
        }
    }
}
