using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation._212App
{

    public class ChallengeProblemCommonMethods
    {
        /// <summary>
        /// Verifies Challenge Problem button
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyChallengeProblemButton(AutomationAgent ChallengeProblemAutomationAgent)
        {
            return ChallengeProblemAutomationAgent.IsElementFound("ChallengeProblemView", "ChallengeProblemButton");
        }

        /// <summary>
        /// Clicks on Challenge Problem button
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        public static void ClickChallengeProblemButton(AutomationAgent ChallengeProblemAutomationAgent)
        {
            ChallengeProblemAutomationAgent.Click("ChallengeProblemView", "ChallengeProblemButton");
            ChallengeProblemAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verifies Challenge Problem Page 
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyChallengeProblemPage(AutomationAgent ChallengeProblemAutomationAgent)
        {
            return ChallengeProblemAutomationAgent.IsElementFound("ChallengeProblemView", "ChallengeProblemLabel"); ;
        }

        /// <summary>
        /// Clicks On Done button in Challenge Problem 
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDoneButtonInChallengeProblem(AutomationAgent ChallengeProblemAutomationAgent)
        {
            ChallengeProblemAutomationAgent.Click("ChallengeProblemView", "DoneButtonInChallengeProblem");
        }
        /// <summary>
        /// Verifies the Done Button Present in the Challenge problem is present at the Top Left Corner
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyDoneButtonInChallengeProblem(AutomationAgent ChallengeProblemAutomationAgent)
        {
            ChallengeProblemAutomationAgent.VerifyElementFound("ChallengeProblemView", "DoneButtonInChallengeProblem");
            int xPos = Int32.Parse(ChallengeProblemAutomationAgent.GetAllValues("ChallengeProblemView", "DoneButtonInChallengeProblem", "x")[0]);
            int yPos = Int32.Parse(ChallengeProblemAutomationAgent.GetAllValues("ChallengeProblemView", "DoneButtonInChallengeProblem", "y")[0]);
            if (xPos < 20 && yPos < 60)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if result as expected), false(if result is not as expected)</returns>
        public static bool VerifyNotebookIcon(AutomationAgent ChallengeProblemAutomationAgent)
        {
            ChallengeProblemAutomationAgent.VerifyElementFound("TasksTopMenuView", "NotebookIcon");
            int xPos = Int32.Parse(ChallengeProblemAutomationAgent.GetAllValues("ChallengeProblemView", "DoneButtonInChallengeProblem", "x")[0]);
            int yPos = Int32.Parse(ChallengeProblemAutomationAgent.GetAllValues("ChallengeProblemView", "DoneButtonInChallengeProblem", "y")[0]);
            if (xPos == 16 && yPos == 58)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify Challenge Problem Title is In Center
        /// </summary>
        /// <param name="ChallengeProblemAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyChallengeProblemTitleInCenter(AutomationAgent ChallengeProblemAutomationAgent)
        {
            int xPos = Int32.Parse(ChallengeProblemAutomationAgent.GetAllValues("ChallengeProblemView", "ChallengeProblemLabel", "x")[0]);
            int yPos = Int32.Parse(ChallengeProblemAutomationAgent.GetAllValues("ChallengeProblemView", "ChallengeProblemLabel", "y")[0]);
            if (xPos < 889 && yPos < 70)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies if Teacher Mode is Open or not 
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if Teacher Mode is open), false(if teacher mode is not open)</returns>
        public static bool VerifyTeacherModeOpen(AutomationAgent LessonBrowserAutomationAgent)
        {
            return LessonBrowserAutomationAgent.IsElementFound("TeacherModeView", "TeacherModeOpenedMath");
        }
    }
}
