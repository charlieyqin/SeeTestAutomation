using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation.K1App
{

    public static class TeacherSupportCommonMethods
    {
        /// <summary>
        /// Verify Back Icon display at Teacher Support screen
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static void VerifyBackIcon(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.VerifyElementFound("TeacherSupport", "BackIcon");
        }


        /// <summary>
        /// Verify offline alert message when clicking on Grow your skill link under welcome from teacher support
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static bool VerifyGrowYourSkillOfflineAlertMessage(AutomationAgent TeacherSupportAutomationAgent)
        {
            string TextonScreen = TeacherSupportAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("No internet connection. You must be connected to the Internet to access Teacher Support.");

        }

        /// <summary>
        /// Verify offline alert message when clicking on Prepare your lesson link under welcome from teacher support
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static bool VerifyPrepareYourLessonOfflineAlertMessage(AutomationAgent TeacherSupportAutomationAgent)
        {
            string TextonScreen = TeacherSupportAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("No internet connection. You must be connected to the Internet to access Teacher Support.");
        }

        /// <summary>
        /// Verify offline alert message when clicking on get Help link under welcome from teacher support
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static bool VerifyGetHelpOfflineAlertMessage(AutomationAgent TeacherSupportAutomationAgent)
        {
            string TextonScreen = TeacherSupportAutomationAgent.GetText("TEXT").Replace("\n", " ");
            return TextonScreen.Contains("No internet connection. You must be connected to the Internet to access Teacher Support.");
        }

        /// <summary>
        /// Click on Grow your skill link
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGrowYourSkill(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.Click("TeacherSupport", "GrowYourSkillLink");
        }

        /// <summary>
        /// Click on Prepare your Lesson link
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnPrepareYourLessonLink(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.Click("TeacherSupport", "PrepareYourLessonLink");
        }

        /// <summary>
        /// Click on Prepare Get Help link
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGetHelpLink(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.Click("TeacherSupport", "GetHelpLink");
        }

        /// <summary>
        /// Verify User on Media Library screen
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserOnMediaLibrary(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.VerifyElementFound("MediaLibrary", "MedialibraryUnitTitle");
        }
        /// <summary>
        /// Verify Link open in mobile safrai.
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyLinkOpenInMobileSafari(AutomationAgent TeacherSupportAutomationAgent)
        {
            return TeacherSupportAutomationAgent.IsElementFound("iPadCommonView", "MobileSafariURL");
        }
        /// <summary>
        /// Click inside the URL
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static void ClickInsideURL(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.Click("iPadCommonView", "MobileSafariURL");
        }
        /// <summary>
        /// Verify Grow your skill URL 
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyGrowYourSkillURL(AutomationAgent TeacherSupportAutomationAgent)
        {
            return TeacherSupportAutomationAgent.IsElementFound("iPadCommonView", "GrowYourSkillURL");
        }
        /// <summary>
        /// Verify Prepare Your Lesson URL 
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyPrepareYourLessonURL(AutomationAgent TeacherSupportAutomationAgent)
        {
            return TeacherSupportAutomationAgent.IsElementFound("iPadCommonView", "PrepareYourLessonURL");
        }
        /// <summary>
        /// Verify Get Help URL 
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyGetHelpURL(AutomationAgent TeacherSupportAutomationAgent)
        {
            return TeacherSupportAutomationAgent.IsElementFound("iPadCommonView", "GetHelpURL");
        }
        /// <summary>
        /// Verify User on teacher support screen
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUserOnTeacherSupport(AutomationAgent TeacherSupportAutomationAgent)
        {
            return TeacherSupportAutomationAgent.IsElementFound("TeacherSupport", "PrepareYourLessonLink");
        }
        /// <summary>
        /// Verify Welcome Screen display 
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        public static bool VerifyWelcomeScreen(AutomationAgent TeacherSupportAutomationAgent)
        {
            return TeacherSupportAutomationAgent.IsElementFound("TeacherSupport", "WelcomeLabel");
        }
        /// <summary>
        /// Verify Single sign on authentication.
        /// </summary>
        /// <param name="TeacherSupportAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifySSOAuthentication(AutomationAgent TeacherSupportAutomationAgent)
        {
            TeacherSupportAutomationAgent.Sleep();
            return (TeacherSupportAutomationAgent.IsElementFound("TeacherSupport", "WelcomeTeacherAccount") && TeacherSupportAutomationAgent.IsElementFound("TeacherSupport", "SignOFF"));
        }
    }
}
