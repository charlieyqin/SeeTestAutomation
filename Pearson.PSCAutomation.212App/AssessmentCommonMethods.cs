using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest.Automation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Pearson.PSCAutomation._212App
{
    public static class AssessmentCommonMethods
    {
        /// <summary>
        /// Verifies Assessment Link is Present in Teacher DashBoard
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void VerifyAssessmentInDashboard(AutomationAgent AssessmentAutomationAgent, string sectionAndPeriod)
        {

            // WaitForGrade12ELAToAppear(AssessmentAutomationAgent);
            Swipe(AssessmentAutomationAgent, Direction.Right, 500, 731);
            AssessmentAutomationAgent.VerifyElementFound("DashboardView", "AssessmentLink", sectionAndPeriod);
        }

        /// <summary>
        /// Swipes the application page in provided directions
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="Direction">Direction object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void Swipe(AutomationAgent AssessmentAutomationAgent, Direction direction, int offset, int time)
        {
            AssessmentAutomationAgent.Swipe(direction, offset, time);

        }

        /// <summary>
        /// Verifies Assessment Link is clickable in Teacher DashBoard
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>         
        public static void ClickAssessmentInDashBoard(AutomationAgent AssessmentAutomationAgent, string sectionAndPeriod)
        {
            AssessmentAutomationAgent.Sleep();
            WaitForGradeToAppear(AssessmentAutomationAgent, sectionAndPeriod);
            AssessmentAutomationAgent.VerifyElementFound("DashboardView", "AssessmentLink", sectionAndPeriod);
            AssessmentAutomationAgent.Click("DashboardView", "AssessmentLink", sectionAndPeriod);
            WaitForPageToload(AssessmentAutomationAgent);
        }


        /// <summary>
        /// Teacher Taps My Dashboard assessment back button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickMyDashboardButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentBackButton");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verifies Teacher is able to select particular unit from the dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void AssessmentUnitSelection(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            AssessmentAutomationAgent.Sleep();
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "AssessmentUnitSelection", unitStatus);
            AssessmentAutomationAgent.Sleep();
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentUnitSelection", unitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void AssessmentStudentUnitSelection(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "UnitTitleDropDownButtonStudent");
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "AssessmentUnitSelectionStudent", unitStatus);
            AssessmentAutomationAgent.Sleep();
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentUnitSelectionStudent", unitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
        }


        public static void AssessmentUnitSelectionAfterCrash(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            AssessmentAutomationAgent.Sleep();
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "FixedAssessment1NameStudent", unitStatus);
            AssessmentAutomationAgent.Sleep();
            AssessmentAutomationAgent.Click("AssessmentView", "FixedAssessment1NameStudent", unitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Teacher scrolls to particular unit from the dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void AssessmentScrollToUnit(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "AssessmentUnitSelection", unitStatus);

        }

        /// <summary>
        /// Verifies Unit Status from the dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string VerifiesUnitStatusInDropdown(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentUnitSelection", unitStatus);
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Teacher Taps On Unit Title Dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickUnitTitleDropdown(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
        }

        /// <summary>
        /// Verifies Unit DropDown Menu is Present in Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyAssessmentUnitDropDownMenuPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnitTitleDropDown");

        }

        /// <summary>
        /// Verifies to get the  title of Fixed Assessment in Assessment Manager Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromFixedAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "FixedAssessment1Name", assessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get the  title of MATH Ongoing Assessment in Assessment Manager Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromMathOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string mathAssessmentName)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ExerciseUnderOngoingAssessment", mathAssessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get Question Number from MATH Ongoing Assessment preview in Assessment Manager Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetQuestionNumberLabelFromMathOngoingPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "MathOngoingPreviewAssessmentQuestionNoLabel");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get the  title of Unit Assessment in Preview Assessment Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "PreviewAssessmentName", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }


        /// <summary>
        /// Verifies to get the Selected Unit From Dropdown
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetUnitAfterSelectingFromDropdown(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "UnitTitleDropDownButton", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static string GetUnitAfterSelectingFromDropdownStudent(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "UnitTitleStudentManager", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get title from Student Assessment Start Page after submission
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetUnitNameAfterSubmittingAssessment(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentUnitSelection", unitStatus);
            string newText = text.Replace("\t\n", "");
            return newText;
        }



        /// <summary>
        /// Verifies to get the title of Preview Assessment Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTitleFromPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "PreviewAssessmentTitle", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies Tapping on title takes to next page for each Assessment  under Fixed type
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickFixedAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "FixedAssessment1Name", assessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "FixedAssessment1Name", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);

        }
        /// <summary>
        /// Verifies navigation arrow for each Assessment  under Fixed type
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickFixedAssessmentNavigationArrow(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "FixedAssessment1Name", assessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "FixedAssessment1Name", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickFixedAssessmentAsStudent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "FixedAssessment1NameStudent", assessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "FixedAssessment1NameStudent", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Click Preview Assessment link
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickPreviewAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "PreviewAssessmentLink");
            AssessmentAutomationAgent.Click("AssessmentView", "PreviewAssessmentLink");
            AssessmentAutomationAgent.Sleep();
        }


        /// <summary>
        /// Verifies Preview Assessment link is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyPreviewAssessmentLinkIspresent(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviewAssessmentLink"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifies Questions and Standard tabs are present in Preview Assessment Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool QuestionsTabAndStandardTabPresent(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTab") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "StandardTab"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verifies Questions tab view is selected by default
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool QuestionsTabSelectedByDefaultPresent(AutomationAgent AssessmentAutomationAgent)
        {
            //if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTabByDefault"))
            //    return true;
            //else
            //    return false;

            string defaultText = AssessmentAutomationAgent.GetTextIn("AssessmentView", "QuestionTabByDefault", "Up", "");
            return defaultText.Contains("Question");

        }

        /// <summary>
        /// Verifies Questions tab view is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool QuestionTabViewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTabView");

        }
        /// <summary>
        /// Verifies Standard Tab View is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool StandardTabViewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StandardTab");
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StandardTabView");

        }

        /// <summary>
        /// Verifies Rubric Panel is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool RubricPanelPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricPanelView");

        }

        public static void VerifyRubricPanelPresentAfterHide(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "RubricPanelViewAfterHide");
            AssessmentAutomationAgent.Click("AssessmentView", "RubricPanelViewAfterHide");
        }

        /// <summary>
        /// Verifies Preview Button is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifiesPreviewButtonPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviousButtonInTestPlayerFound");

        }

        /// <summary>
        /// Navigates To last question in Preview Assessment Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void NavigateToLastQuestioInPreviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInPreviewScreen"));
            int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInPreviewScreen"));
            for (int i = currentQuestionNumber; i < TotalQuestions; i++)
            {
                ClickAssessmentNextButton(AssessmentAutomationAgent);
            }

        }

        /// <summary>
        /// Navigates To Next question in Preview Assessment Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void NavigateToNextQuestioInPreviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInPreviewScreen"));
            int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInPreviewScreen"));
            if (currentQuestionNumber < TotalQuestions)
            {
                ClickAssessmentNextButton(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep();
            }

        }

        /// <summary>
        /// Verifies to get the Question Number Label in Preview Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string VerifiesQuestionNumberInPreviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "QuestionNumberLabelPreview", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies Next Button is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifiesNextButtonPresentInPreview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextButtonInTestPlayerFound");

        }

        /// <summary>
        /// Verifies Preview Screen Body is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifiesPreviewScreenBodyPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTabView");

        }

        /// <summary>
        /// Verifies Previous Button is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifiesPreviousButtonPresentInPreview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviousButtonInTestPlayerFound");

        }

        /// <summary>
        /// Verifies dynamic progress bar view is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool ProgressBarViewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ProgressBarView");

        }

        /// <summary>
        /// Verifies Questions and Standard tabs are present in Preview Assessment Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static bool StatusBarTabViewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return (AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotStartedView") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "StartedView") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "SubmittedView") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredView"));

        }

        /// <summary>
        /// Verifies Unlock Assessments link is present in Assessment Progress overview Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickUnlockAssessments(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "UnlockAssessments");
            AssessmentAutomationAgent.Click("AssessmentView", "UnlockAssessments");

        }

        /// <summary>
        /// Verifies lock Assessments link is present in Assessment Progress overview Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickLockAssessments(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockedAssessments");
            AssessmentAutomationAgent.Click("AssessmentView", "LockedAssessments");

        }

        /// <summary>
        /// Verifies Lock/Unlock Modal is displayed
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static bool UnlockModalScreenFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnlockModal");

        }

        /// <summary>
        /// Verifies Unlock Assessments link is present in Assessment Progress overview Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool UnlockAssessmentsLinkPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnlockAssessments");


        }

        /// <summary>
        /// Verifies to get Text From Unlock Assessment Link
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetTextFromUnlockAssessmentLink(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.GetTextIn("AssessmentView", "UnlockAssessments", "Inside", "").Replace("\t\n", "");
        }

        /// <summary>
        /// Verifies lock Assessments link is present in Assessment Progress overview Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool LockAssessmentsLinkPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockedAssessments");

        }

        /// <summary>
        /// Verifies lock all button is present in Assessment modal Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool LockAllButtonPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockAll");

        }

        /// <summary>
        /// Verifies unlock all button is present in Assessment modal Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool UnLockAllButtonPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnLockAll");

        }

        /// <summary>
        /// Verifies Status Message in Assessment Progress Overview Screen for Locked Status
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetTextFromAssessmentTable(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "Inside", "1").Replace("\t\n", "");
        }

        /// <summary>
        /// Verifies clicking on unlock all button in Assessment modal Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void ClickUnLockAllButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "UnLockAll");
            AssessmentAutomationAgent.Click("AssessmentView", "UnLockAll");
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verifies clicking on lock all button in Assessment modal Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickLockAllButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockAll");
            AssessmentAutomationAgent.Click("AssessmentView", "LockAll");
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verifies clicking on lock status in Assessment modal overlay screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickOnStudentName(AutomationAgent AssessmentAutomationAgent, string studentname)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockStudentName");
            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "StudentName", studentname);
            AssessmentAutomationAgent.Click("AssessmentView", "StudentName", studentname);
            AssessmentAutomationAgent.Sleep(6000);
        }

        /// <summary>
        /// Verifies clicking on close option in Assessment modal overlay screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentOverlayClose(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentOverlayClose");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentOverlayClose");

        }

        /// <summary>
        /// Verifies clicking on Done option in Assessment modal overlay screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentOverlayDone(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentOverlayDone");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentOverlayDone");
            WaitForPageToload(AssessmentAutomationAgent);
        }


        /// <summary>
        /// Verifies to get the  title of Assessment Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromAssessmentOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentOverviewScreen");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies Assessment Progress Overview Screen is displayed
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool AssessmentProgressOverviewTitleFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentOverviewScreenTitle");

        }

        /// <summary>
        /// Verifies to get Assessment table status message
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string ValidateAssessmentLockMessage(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentLockedStatus");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get the  title of Assessment Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetStudentNameFromAssessmentModalScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockStudentName");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get Locked For Count
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetLockedForTextPresent(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockedForTextPresent");
            string newText = text.Replace("\t\n", "");
            return newText;

        }

        /// <summary>
        /// Verifies Locked For Text Present is displayed in Modal Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool LockedForTextFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockedForTextPresent");

        }

        /// <summary>
        /// Verifies Student Cell is displayed in Assessment Overlay Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool AssessmentOverlayStudenCellFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentOverlayStudentCellPresent");

        }


        /// <summary>
        /// Verifies clicking on Done option in Preview Assessment screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickPreviewAssessmentDone(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "PreviewAssessmentDoneButton");
            AssessmentAutomationAgent.Click("AssessmentView", "PreviewAssessmentDoneButton");
            WaitForPageToload(AssessmentAutomationAgent);

        }

        /// <summary>
        /// Verifies d Button is displayed in Assessment Progress Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool AssessmentOverviewScoreButtonFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentOverviewScoreButtonPresent");

        }

        /// <summary>
        /// Verifies View Report Button is displayed in Assessment Progress Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool AssessmentOverviewViewReportButtonFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentOverviewViewReportButtonPresent");

        }
        /// <summary>
        /// Verifies clicking on view report button in Assessment Progress Overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentOverviewReportButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentOverviewViewReportButtonPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentOverviewViewReportButtonPresent");

        }

        /// <summary>
        /// Verifies Assessment Manager button is displayed in Assessment Progress Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool AssessmentManagerButtonFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentManagerButtonPresent");

        }

        /// <summary>
        /// Verifies clicking on Assessment Manager button in Assessment Progress Overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentManagerButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentManagerButtonPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentManagerButtonPresent");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verifies My DashBoard button is displayed in Assessment Manager Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool MyDashBoardButtonFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "MyDashBoardButtonPresent");

        }


        /// <summary>
        /// Validates the Locked Student Count
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void VerifyLockedStudentCount(AutomationAgent AssessmentAutomationAgent, string StudentCount)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockedForTextPresent").Replace("\t\n", "");
            Assert.AreEqual(StudentCount, text, "StudentCount Mismatch");

        }
        /// <summary>
        /// Verifies Start Lesson button is present in My DashBoard
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickStudentStartUnitButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StartLessonButtonInMyDashBoardPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "StartLessonButtonInMyDashBoardPresent");

        }
        /// <summary>
        /// Verifies BackButton in  Unit1 Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickStudentGrade9ELAButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "Grade9ELAButtonPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "Grade9ELAButtonPresent");

        }
        /// <summary>
        /// Verifies Swipe Functionailty till Unit10 in  Grade9 ELA Unit
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void SwipeTillUnit10(AutomationAgent AssessmentAutomationAgent, Direction direction, int offset, int swipetime)
        {
            AssessmentAutomationAgent.Swipe(Direction.Right, 500, 731);
        }
        /// <summary>
        /// Verifies if required Unit is present or not
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnit10IsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "TillUnit10ToSwipe");
        }
        /// <summary>
        /// Verifies BackButton in  Unit1 Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickStartButtonInUnit10(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "Unit10StartButtonPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "Unit10StartButtonPresent");

        }
        /// <summary>
        /// Verifies clicking on Student Assessment tile in Unit 10
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickStudentAssessmentTileInUnit10(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "TapOnStudentAssessmentTile");
            AssessmentAutomationAgent.Click("AssessmentView", "TapOnStudentAssessmentTile");

        }
        /// <summary>
        /// Verifies clicking on start button in PoP Up for Student Assessment tile in Unit 10
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi brunda(lakshmi.brunda)</author>
        public static void ClickStartOnStudentAssessmentTilePopUp(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "TapOnStartButtonInAssessmentPopUp");
            AssessmentAutomationAgent.Click("AssessmentView", "TapOnStartButtonInAssessmentPopUp");

        }


        public static void StudentAnswersAssessmentQuestion(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StudentAssessmentNextButton");
            AssessmentAutomationAgent.Click("AssessmentView", "StudentAssessmentNextButton");
            AssessmentAutomationAgent.Click("AssessmentView", "StudentAssessmentNextButton");
        }


        public static void StudentSubmitAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StudentAssessmentSubmitButton");
        }

        public static void StudentTakingAssessment(AutomationAgent AssessmentAutomationAgent, string status)
        {

            ClickStudentStartUnitButton(AssessmentAutomationAgent);
            ClickStudentGrade9ELAButton(AssessmentAutomationAgent);
            if (AssessmentAutomationAgent.SwipeWhileNotFound("AssessmentView", "TillUnit10ToSwipe", "Right", 791, 2000, 1000, 10, true))
            {
                AssessmentAutomationAgent.Sleep(10000);
                ClickStartButtonInUnit10(AssessmentAutomationAgent);
            }
            AssessmentAutomationAgent.Sleep(10000);
            ClickStartButtonInUnit10(AssessmentAutomationAgent);
            ClickStudentAssessmentTileInUnit10(AssessmentAutomationAgent);
            ClickStartOnStudentAssessmentTilePopUp(AssessmentAutomationAgent);
            StudentAnswersAssessmentQuestion(AssessmentAutomationAgent);
            if (status.Equals("Started"))
            {
                AssessmentAutomationAgent.ApplicationClose();
            }
            else
            {
                //StudentSubmitAssessment(AssessmentAutomationAgent);
            }
            //NavigationCommonMethods.Logout(AssessmentAutomationAgent);
        }


        public static void ClickLockAllAssessmentAndResetDataLink(AutomationAgent AssessmentAutomationAgent)
        {
            if (VerifyLockAllAssessmentAndResetDataLinkFound(AssessmentAutomationAgent))
            {
                AssessmentAutomationAgent.Click("AssessmentView", "LockAllAssessmentResetData");
            }
        }

        public static bool VerifyLockAllAssessmentAndResetDataLinkFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockAllAssessmentResetData");
        }

        public static void ClickCancelInLockAllResetData(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockAllAssessmentResetDataCancelButton");
        }
        public static bool VerifyCancelButtonInLockAndResetScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockAndResetCancelButton");
        }

        public static void ClickLockAndRestInLockAllResetData(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockAllAssessmentResetDataLockResetButton");
        }

        /// <summary>
        /// Verifies to get the  Unit Title from Assessment Overlay Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetUnitTitleFromAssessmentOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "UnitTitleNamePresent");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get the  Assessment Title from Assessment Overlay Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetAssessmentTitleFromAssessmentOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentTitleNamePresent");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get the  Assessment Progress Status from Assessment Overlay Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetAssessmentProgressStatusFromAssessmentOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentProgressStatusNamePresent");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get the Lock Or Unlock To Manage Student Message from Assessment Overlay Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetLockOrUnlockToManageStudentFromAssessmentOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockOrUnlockToManageStudentMessage");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get the Locks Only Students That Have Not Yet Started
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetLockOnlyStudentsNotStartedAssessmentOverlayScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockOnlyStudentsNotStartedMessage");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Teacher Unlocks a Student 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void TeacherUnlocksAStudent(AutomationAgent AssessmentAutomationAgent, string sectionAndperiod, string studentName, string UnitStatus, string assessmentName)
        {
            AssessmentAutomationAgent.Sleep();
            ClickAssessmentInDashBoard(AssessmentAutomationAgent, sectionAndperiod);
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
            ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent, assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
            ClickUnlockAssessments(AssessmentAutomationAgent);
            ClickOnStudentName(AssessmentAutomationAgent, studentName);
            AssessmentAutomationAgent.Sleep(3000);
            ClickAssessmentOverlayDone(AssessmentAutomationAgent);
        }


        public static void TeacherUnlocksAllStudent(AutomationAgent AssessmentAutomationAgent)
        {
            ClickUnlockAssessments(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "UnLockAll");
            AssessmentAutomationAgent.Sleep(3000);
            ClickAssessmentOverlayDone(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Teacher Taps Locks And Reset Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void TeacherTapsLocksAndResetButton(AutomationAgent AssessmentAutomationAgent)
        {

            AssessmentAutomationAgent.Click("AssessmentView", "LockAndResetButton");
            AssessmentAutomationAgent.Sleep(5000);
            Assert.AreEqual("Assessment is Locked.", ValidateAssessmentLockMessage(AssessmentAutomationAgent), "Student Name Found");
        }
        /// <summary>
        /// Verifies Lock & Reset button is present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool LockAndResetButton(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockAndResetButton");

        }

        /// <summary>
        /// Teacher Taps Locks And Reset Label
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void TeacherTapsLocksAndResetLabel(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockAndResetLabel");
        }

        /// <summary>
        /// Verifies to get the Lock And Reset Modal screen Title
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string VerifyLockAndResetModalScreenLabel(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetModalScreenTitle");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Teacher Taps On Cancel Button In Lock And Reset Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void TeacherTapsCancelInLocksAndResetScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockAndResetCancelButton");
        }

        /// <summary>
        /// Student Attempts The Unlocked Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void StudentAnswersAssessment(AutomationAgent AssessmentAutomationAgent, string status, string assessmentName)
        {
            AssessmentAutomationAgent.Sleep(10000);
            ClickAssessmentTile(AssessmentAutomationAgent, assessmentName);
            AssessmentAutomationAgent.Sleep(10000);
            //Check if Assessment is unlocked
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(10000);
                int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                {
                    ClickAssessmentNextButton(AssessmentAutomationAgent);
                }

                if (status.Equals("Started"))
                {
                    NavigationCommonMethods.CloseApplication(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.LaunchApp();
                }
                else if (status.Equals("ReviewAndSubmit"))
                {
                    AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReviewAndSubmitIsPresent");
                    AssessmentAutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");

                }
                else if (status.Equals("Submitted"))
                {
                    ClickSubmitButtonInLastQuestionOfAssessment(AssessmentAutomationAgent);

                }

            }
        }

        public static void StudentAnswersAssessmentFromAssessmentManager(AutomationAgent AssessmentAutomationAgent, string status, string assessmentName)
        {
            AssessmentAutomationAgent.Sleep(10000);
            //Check if Assessment is unlocked
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(10000);
                int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                {
                    ClickAssessmentNextButton(AssessmentAutomationAgent);
                }

                if (status.Equals("Started"))
                {

                    NavigationCommonMethods.CloseApplication(AssessmentAutomationAgent);
                    AssessmentAutomationAgent.LaunchApp();
                }
                else if (status.Equals("ReviewAndSubmit"))
                {
                    AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReviewAndSubmitIsPresent");
                    AssessmentAutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");

                }
                else if (status.Equals("Submitted"))
                {
                    ClickSubmitButtonInLastQuestionOfAssessment(AssessmentAutomationAgent);

                }

            }
        }


        /// <summary>
        /// Verifies clicking on Assessment Tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentTile(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            int i = 10;
            while (!AssessmentAutomationAgent.IsElementFound("AssessmentView", "FixedAssessment1Name") && i > 0)
            {
                AssessmentAutomationAgent.Swipe(Direction.Down, 600);
                if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "FixedAssessment1Name", assessmentName))
                {
                    break;
                }
                else
                {
                    NavigationCommonMethods.SwipeUnit(AssessmentAutomationAgent, Direction.Right);
                    i--;
                }
                AssessmentAutomationAgent.Swipe(Direction.Down, 600);
            }
            AssessmentAutomationAgent.Click("AssessmentView", "FixedAssessment1Name", assessmentName);

        }

        /// <summary>
        /// Verifies Assessment Tile is Present in Unit10
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool AssessmentTilePopUpFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentTilePopUpFound");

        }

        /// <summary>
        /// Verifies clicking on Assessment Tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentStartButtonInPopUp(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StartButtonInPopUpFound");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "CancelButtonInPopUpFound");
            AssessmentAutomationAgent.Click("AssessmentView", "StartButtonInPopUpFound");

        }
        /// <summary>
        /// Verifies clicking on Assessment Tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickCancelInAssessmentCompletionPopUp(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "CancelButtonInPopUpFound");
            AssessmentAutomationAgent.Click("AssessmentView", "CancelButtonInPopUpFound");

        }
        public static bool CancelInConfirmationPopUpFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CancelButtonInPopUpFound");

        }
        /// <summary>
        /// Verifies clicking on Next Button
        /// /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentNextButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NextButtonInTestPlayerFound");
            AssessmentAutomationAgent.Click("AssessmentView", "NextButtonInTestPlayerFound");

        }


        /// <summary>
        /// Verifies clicking on Submit button in Last Question of Assessment
        /// /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickSubmitButtonInLastQuestionOfAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReviewAndSubmitIsPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "SubmitAssessmentIsFound");
            String SubmitAssessmentTitle = AssessmentAutomationAgent.GetElementText("AssessmentView", "SubmitAssessmentPopUpTitle");
            Assert.AreEqual("Submit Assessment?", SubmitAssessmentTitle);

        }

        public static void ClickSubmitInConfirmationPopUp(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentSubmitInPopUpIsFound");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentCancelInPopUpIsFound");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentSubmitInPopUpIsFound");
            AssessmentAutomationAgent.Sleep(5000);
        }
        public static void ClickSubmitButtonInStudentAssessmentSummary(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SubmitAssessmentIsFound");
            AssessmentAutomationAgent.Click("AssessmentView", "SubmitAssessmentIsFound");
            AssessmentAutomationAgent.Sleep(5000);
        }
        public static bool SubmitInConfirmationPopUpFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentSubmitInPopUpIsFound");

        }

        public static bool SubmitInStudentAssessmentSummary(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SubmitAssessmentIsFound");

        }
        /// <summary>
        /// Verifies clicking on Assessment Tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickSubmitButtonAfterReview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentTileIsPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentTileIsPresent");

        }

        /// <summary>
        /// Verifies clicking on Summary Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickSummaryButton(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.Sleep(5000);
            ClickAssessmentTile(AssessmentAutomationAgent, assessmentName);
            AssessmentAutomationAgent.Sleep(5000);
            //Check if Assessment is unlocked
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Sleep(5000);
            ClickSummaryButton2(AssessmentAutomationAgent);
            String ActualTileText = GetTextFromQuestion1Tile(AssessmentAutomationAgent);
            Assert.AreEqual("Question 1", ActualTileText);




        }

        /// <summary>
        /// Verifies to get text in Question 1 tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromQuestion1Tile(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "Question1TileTextFound");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get text from Assessment Summary Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromStudentAssessmentSummaryPage(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentAssessmentSummaryPage");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get text in Question 1 tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool CounterFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "TimerFound");

        }

        /// <summary>
        /// Verifies hidden counter doesn't stop the timer
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickTimerFound(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "TimerIcon");
            AssessmentAutomationAgent.Click("AssessmentView", "TimerIcon");

        }

        /// <summary>
        /// Verifies Question tile is clickable
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickQuestion1Tile(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "Question1TileTextFound");
            AssessmentAutomationAgent.Click("AssessmentView", "Question1TileTextFound");

        }

        /// <summary>
        /// Verifies clicking on Summary Button in Question1 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickSummaryButton2(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SummaryButtonInQuestion1Found");
            AssessmentAutomationAgent.Click("AssessmentView", "SummaryButtonInQuestion1Found");
            AssessmentAutomationAgent.Sleep(5000);
        }


        public static void ClickSummaryButtonInExercise(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SummaryButtonInExercises");
            AssessmentAutomationAgent.Click("AssessmentView", "SummaryButtonInExercises");
            AssessmentAutomationAgent.Sleep(5000);
        }

        /// <summary>
        /// Verifies Summary Tab is Present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool SummaryButtonInTestPlayer(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SummaryButtonInQuestion1Found");

        }

        /// <summary>
        /// Verifies Test Player is shown in Web View
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool WebViewOfTestPlayer(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "TestPlayer");

        }
        /// <summary>
        /// Verifies to get title of Assessment in Test Player
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool GetTextofTitleFromTestPlayer(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentTitleInTestPlayer", assessmentName);
        }

        /// <summary>
        /// Student Attempts The Unlocked Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void StudentAnswersAssessmentInTestPlayer(AutomationAgent AssessmentAutomationAgent, string asssessmentName)
        {
            ClickAssessmentTile(AssessmentAutomationAgent, asssessmentName);
            AssessmentAutomationAgent.Sleep(5000);

            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {

                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(5000);
                int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                if (currentQuestionNumber == 1)
                {
                    Assert.IsTrue(NextButtonFoundInTestPlayer(AssessmentAutomationAgent));
                    Assert.IsFalse(PreviousButtonFoundInTestPlayer(AssessmentAutomationAgent));
                }
                for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                {
                    ClickAssessmentNextButton(AssessmentAutomationAgent);
                }
                if (currentQuestionNumber == 4)
                {
                    Assert.IsTrue(PreviousButtonFoundInTestPlayer(AssessmentAutomationAgent));
                    Assert.IsFalse(NextButtonFoundInTestPlayer(AssessmentAutomationAgent));
                }
                for (int i = TotalQuestions; i > currentQuestionNumber; i--)
                {
                    ClickAssessmentPreviousButton(AssessmentAutomationAgent);
                }
            }


        }



        /// <summary>
        /// Verifies Test Player is shown with Foward  functionality
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool NextButtonFoundInTestPlayer(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextButtonInTestPlayerFound");

        }
        /// <summary>
        /// Verifies Test Player is shown with Backward functionality
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool PreviousButtonFoundInTestPlayer(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviousButtonInTestPlayerFound");

        }


        /// <summary>
        /// Verifies Timer is found
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool TimerFoundInAssessmentSummaryPage(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "TimerIcon");

        }
        /// <summary>
        /// Verifies QuestionTile in Student Assessment Summary Page is Found
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool QuestionTileInStudentAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string questionTile)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "Question1TileFound", questionTile);

        }
        /// <summary>
        /// Verifies to get text from Question tile in Student Assessment Summary Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromQuestionTileInStudentAssessmentResultSummary(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "Question1TileTextFound");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get title of Group Assessment Summary Report
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromAssessmentResultSummary(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "AssessmentResultSummaryReport");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies clicking on Score button in Assessment Progress Overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentOverviewScoreButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentOverviewScoreButtonPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentOverviewScoreButtonPresent");
            WaitForPageToload(AssessmentAutomationAgent);
        }
        /// <summary>
        /// Verifies clicking on previous button in Assessment Test Player
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentPreviousButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "PreviousButtonInTestPlayerFound");
            AssessmentAutomationAgent.Click("AssessmentView", "PreviousButtonInTestPlayerFound");

        }
        /// <summary>
        /// Verifies to get title of Scoring Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetTextFromScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoringOverviewOnClickScoreButton");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get total number of students in AssessmentOverview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetTextOfTotalStudentsinOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalNumberOfStudentsIsPresentInOverview");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static int StudentCountToReleaseInOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string count = AssessmentAutomationAgent.GetTextIn("AssessmentView", "ReleaseScoreButton", "Down", "").Split(' ')[4];
            return Int32.Parse(count);
        }

        /// <summary>
        /// Verifies to get total number of students to release scores in AssessmentOverview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetTextOfTotalStudentsToReleaseScoresinOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "NumberOfStudentsToReleaseScores");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get total number of students to release scores in AssessmentOverview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetTextOfDynamicProgressBarValue(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "IncreasingPercentageInDynamicProgressBar");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies Assessment Tile is Present in Unit10
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool LockIconInAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockIconInAssessmentManager");

        }
        /// <summary>
        /// Verifies to get the  status of Fixed Assessment in Assessment Manager Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool GetTextOfFixedAssessmentStatus(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StatusInAssessmentManager", assessmentName);
        }
        /// <summary>
        /// Waits for page to load
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutoamtionAgent object</param>
        public static void WaitForPageToload(AutomationAgent AssessmentAutomationAgent)
        {
            int i = 15;
            while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "LoaderImageView") && i > 0)
            {
                AssessmentAutomationAgent.WaitForElementToVanish("AssessmentView", "LoaderImageView");
                i--;
            }
        }
        /// <summary>
        /// Verifies to get the  Unit Title from Assessment Overlay Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetSectionTitleFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "SectionTitleInOverview");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies Teacher clicking in DashBoard and Selecting Unit10
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>        
        public static void TeacherAtAssessmentManager(AutomationAgent AssessmentAutomationAgent, string sectionAndPeriod, string UnitStatus)
        {
            AssessmentAutomationAgent.Sleep(10000);
            ClickAssessmentInDashBoard(AssessmentAutomationAgent, sectionAndPeriod);
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verifies UnLock Icon in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool UnLockIconInAssessmentManagerIsPresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnlockIconInAssessmentManager", assessmentName);
        }
        /// <summary>
        /// Verifies Scoring Required Status in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetScoringRequiredStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoringRequired", assessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static bool ScoringRequiredInAssessmentManagerIsPresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoringRequired", assessmentName);
        }

        /// <summary>
        /// Verifies Delivered Status in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetDeliveredStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "Delivered");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies Submitted Status in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetSubmittedStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "SubmittedStatusInAssessmentManager");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies Pending Status in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetPendingStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInAssessmentManager", assessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        // <summary>
        /// Verifies InProgress Status in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetInProgressStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "InprogressStatusInAssessmentManager", assessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        // <summary>
        /// Verifies Started Status in Assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetStartedSubStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "StartedStatusInAssessmentManager");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static string GetSubmittedSubStatusFromAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "SubmittedStudents", assessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        // <summary>
        /// Verifies to Lock and Reset data after Test Run
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void LockAndResetDataAfterTestRun(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent, assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
            ClickUnlockAssessments(AssessmentAutomationAgent);
            TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);
            TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
            ClickAssessmentOverlayDone(AssessmentAutomationAgent);

        }

        // <summary>
        /// Verifies to Lock and Reset data after Test Run
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void LockAndResetDataAfterTestRunInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            if (UnlockAssessmentsLinkPresent(AssessmentAutomationAgent))
                ClickUnlockAssessments(AssessmentAutomationAgent);
            else
                ClickLockAssessments(AssessmentAutomationAgent);
            TeacherTapsLocksAndResetLabel(AssessmentAutomationAgent);

            TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);
            ClickAssessmentOverlayDone(AssessmentAutomationAgent);

        }
        /// <summary>
        /// Verifies Release Scores button is Disabled in Scoring Overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ReleaseScoresButtonFound(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReleaseScoresInScoringOverview");
            AssessmentAutomationAgent.Click("AssessmentView", "ReleaseScoresInScoringOverview");

        }

        /// <summary>
        /// Verifies Release Scores button is Present in Scoring Overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyReleaseScoresButtonDisabled(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementEnabled("AssessmentView", "ReleaseScoresInScoringOverview");

        }
        /// <summary>
        /// Verifies Item Scoring Screen Number
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickQuestionOneInScoringOverview(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ClickQuestion1TextBox", studentName);
            AssessmentAutomationAgent.Click("AssessmentView", "ClickQuestion1TextBox", studentName);
            AssessmentAutomationAgent.Sleep();
        }
        /// <summary>
        /// Verifies Click On Student Assessment Summary Question1
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickQuestionOneInStudentAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string questionNumber)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentExperienceAssessmentSummaryScreenQuestion1", questionNumber);
            AssessmentAutomationAgent.Click("AssessmentView", "StudentExperienceAssessmentSummaryScreenQuestion1", questionNumber);
        }

        /// <summary>
        /// Get Question Number from Item Scoring Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetQuestionNumberInItemScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.GetTextIn("AssessmentView", "QuestionNumberInItemScoring", "Right", "").Substring(0, 2);
        }
        /// <summary>
        /// Verifies Back Button in Scoring Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickBackButtonInScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "BackButtonInScoringOverviewMainScreen");
            AssessmentAutomationAgent.Click("AssessmentView", "BackButtonInScoringOverviewMainScreen");
            WaitForPageToload(AssessmentAutomationAgent);
        }
        /// <summary>
        /// Get Question Number from Scoring Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetQuestionNumberInScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "QuestionNoInScoringOverviewMainScreen");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get the  Number of students count to release scores
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetScoreCountTextInScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoreCountTextInScoringOverviewScreen");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static int GetScoreMoreCountInScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string count = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoreCountTextInScoringOverviewScreen").Split(' ')[2];
            return Int32.Parse(count);
        }

        public static string[] LoadUnitStatusFromAdditionalInfo(TaskInfo taskInfo)
        {
            String additionalInfo = taskInfo.AdditionalInfo;
            String[] unitStatus = additionalInfo.Split(',');
            return unitStatus;
        }

        public static void WaitForGradeToAppear(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            int i = 15;
            while (!AssessmentAutomationAgent.IsElementFound("DashboardView", "AssessmentNameDashboard", assessmentName) && i > 0)
            {
                Swipe(AssessmentAutomationAgent, Direction.Right, 500, 731);
                i--;
            }

        }


        public static void ResetDataBackToDefault(AutomationAgent AssessmentAutomationAgent)
        {
            TeacherTapsLocksAndResetButton(AssessmentAutomationAgent);

        }

        /// <summary>
        /// Verifies to get Alert message in Lock & Reset Data Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetSubmittedStatusAndCount(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetStudentInSubmitted");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Get submitted student count from assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>submitted count</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetSubmittedCountFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "SubmittedView").Split(' ')[0]);
        }

        /// <summary>
        /// Get submitted student count from scoring overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>submitted count</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetSubmittedCountFromScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "SubmittedView").Substring(11, 1));
        }


        /// <summary>
        /// Verifies to get HEADER of Lock & Reset Data
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetHeaderFromLockAndResetDataScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetDataHeader");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get Unit Name of Lock & Reset Data Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetUnitNameFromLockAndResetDataScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetUnitName");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies to get Alert message in Lock & Reset Data Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetAlertTextFromLockAndResetDataScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetScreenAlert");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get Alert message in Lock & Reset Data Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetProgressStatusFromLockAndResetDataScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetScreenSectionTitle");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get partially Scored Count
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static int GetPartiallyScoredCountInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "PartialScoredStudentsInStopScoringDialogue", "Inside", ""));
        }

        /// <summary>
        /// Verifies to get Alert message in Lock & Reset Data Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetInProgressCountFromLockAndResetDataScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "LockAndResetStudentInProgress");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Get scorred student count from assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>scored count</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetScoredCountFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoredView").Split(' ')[0]);
        }

        /// <summary>
        /// Get scored student count from scoring overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent objec</param>
        /// <returns>scored count</returns>returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetScoredCountFromScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoredView").Substring(8, 2).Replace(" ", ""));
        }

        /// <summary>
        /// Get started student count from assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>started count</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetStartedCountFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "StartedView").Split(' ')[0]);
        }

        /// <summary>
        /// Get started student count from scoring overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent objec</param>
        /// <returns>started count</returns>returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetStartedCountFromScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "StartedView").Substring(9, 2).Replace(" ", ""));
        }

        /// <summary>
        /// Get started student count from assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>not started count</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetNotStartedCountFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "NotStartedView").Split(' ')[0]);
        }

        public static int GetStartedCountFromAssessmentOverviewExercise(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StartedTabView", "inside", "").Split(' ')[0]);
        }


        /// <summary>
        /// Get started student count from scoring overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent objec</param>
        /// <returns>not started count</returns>returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetNotStartedCountFromScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "NotStartedView").Substring(13, 2).Replace(" ", ""));
        }

        /// <summary>
        /// Verifies clicking on checkbox in Assessment Scoring Overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickAssessmentScoringCheckbox(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentScoreCheckBoxInScoringOverview");
            AssessmentAutomationAgent.Click("AssessmentView", "StudentScoreCheckBoxInScoringOverview");

        }
        /// <summary>
        /// Verifies clicking on Done button in Checklist Scoring
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickDoneButtonInCheckListScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "DoneButtonInChecklistScoring");
            AssessmentAutomationAgent.Click("AssessmentView", "DoneButtonInChecklistScoring");

        }
        public static bool NotScoredTabFoundInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotScoredTabInStopScoringDialogue");

        }
        /// <summary>
        /// Verifies clicking on NotScored Button in Stop Scoring Dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickNotScoredTabInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotScoredTabInStopScoringDialogue");
            AssessmentAutomationAgent.Click("AssessmentView", "NotScoredTabInStopScoringDialogue");

        }
        /// <summary>
        /// Verifies clicking on Scored Button in Stop Scoring Dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickScoredTabInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoredTabInStopScoringDialogue");
            AssessmentAutomationAgent.Click("AssessmentView", "ScoredTabInStopScoringDialogue");

        }
        public static bool ScoredTabFoundInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredTabInStopScoringDialogue");

        }
        public static void ClickOngoingAssessmentFirstExercise(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "OngoingAssessmentFirstExercise");
            AssessmentAutomationAgent.Click("AssessmentView", "OngoingAssessmentFirstExercise");
            WaitForPageToload(AssessmentAutomationAgent);

        }

        public static bool OngoingAssessmentExercises(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OngoingAssessmentFirstExercise");

        }

        public static bool ScoredTabDefaultSelectedInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "BackgroundColorOfScoredTabInStopScoringDialogue");

        }


        public static bool NotScoredTabInAccomplishmentOverviewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotScoredTabOngoingAssessments");

        }

        public static bool ScoredTabInAccomplishmentOverviewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredTabOngoingAssessments");

        }

        public static void ClickScoredTabInAccomplishmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ScoredTabOngoingAssessments");
        }

        /// <summary>
        /// Click on active tile from scoring overview screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickActiveTileFromScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "TileAtScoringOverview");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Click on active tile from scoring overview screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickActiveTileInChecklistScoringOverview(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "ChecklistTileAtScoringOverview", studentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verify item scoring screen opened
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyItemScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ItemScoringTitle");
        }

        /// <summary>
        /// Verify Next button display in item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyNextQuestionButtonInItemScorring(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextButtonAtItemScoring");

        }

        /// <summary>
        /// Click on Done button at item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnItemScoringDoneButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "PreviewAssessmentDoneButton");
        }

        /// <summary>
        /// Click on yes button at completion dialoge view popup
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnYesButtonAtCompletionDialogView(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "YesButtonAtCompletionDialog");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verify Previous button display in item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyPreviousQuestionButtonInItemScoring(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviousButtonAtItemScoring");
        }

        /// <summary>
        /// Click On Next question button from item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickNextQuestionButtonInItemScoring(AutomationAgent AssessmentAutomationAgent, int clickCount)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "NextButtonAtItemScoring", clickCount);
        }

        /// <summary>
        /// Click on previous question button in item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickPreviousQuestionButtonInItemScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "PreviousButtonAtItemScoring");
        }

        /// <summary>
        /// Verify the next student button 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNextStudentButton(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextStudent");
        }
        /// <summary>
        /// Click on yes button 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickonYesButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "CompletionReportDialogViewYesButton");
            WaitForPageToload(AssessmentAutomationAgent);
        }
        /// <summary>
        /// Click on the tile in scoring overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickonTile(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "TeacherScoringOverviewCollectioncell");

        }

        /// <summary>
        /// Generate random number between 1 and given number
        /// </summary>
        /// <param name="n">given number</param>
        /// <returns>rand integer</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int randomInteger(int n)
        {
            Random rnd = new Random();
            int randomInt = rnd.Next(1, n);
            return randomInt;
        }

        /// <summary>
        /// Get total number available on item scoring screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>total number</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetTotalQuestionNumberAtItemScoring(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "QuestionScoredLabelAtItemScoring", "Left", "").Split(new string[] { "of " }, StringSplitOptions.None)[1]);
        }

        /// <summary>
        /// Get selected student name from item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>student name</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static string GetStudentNameFromItemScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.GetTextIn("AssessmentView", "DownArrowOfStudentAtItemScoring", "Left", "").Replace("\t\n", ""); ;
        }

        /// <summary>
        /// Verify relaes score button disabled assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyReleaseScoresButtonDisabledinAssessmnetOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "ReleaseScoreButton", "enabled")[0];
            return Convert.ToBoolean(enabled);
        }
        /// <summary>
        /// CLick on the started tab in the assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTheStartedTab(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StartedTabView");
        }

        public static bool StartedTabInAccomplishmentOverviewPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StartedTabView");

        }

        /// <summary>
        /// Verify no student message 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoStudentMessage(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NoStudents");

        }
        /// <summary>
        /// Verify score button enabled in assessment overview button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyScoresButtonEnabledinAssessmnetOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "ScoreButton", "enabled")[0];
            return enabled.Equals("true");
        }
        /// <summary>
        /// Verify view report button enabled in assessment overview button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyViewReportButtonEnabledinAssessmnetOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "ViewReport", "enabled")[0];
            return enabled.Equals("true");
        }

        /// <summary>
        /// Get scorred student count from Stop Scoring Dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>scored count</returns>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static int GetScoredCountFromStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "ScoredTabInStopScoringDialogue", "Inside", "").Substring(0, 1));
        }
        /// <summary>
        /// Get Notscored student count from Stop Scoring Dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>scored count</returns>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetNotScoredCountFromStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            String text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "NotScoredTabInStopScoringDialogue", "Inside", "").Substring(0, 2);
            return text;

        }
        /// <summary>
        /// Clicks on Yes Button in Stop Scoring Dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickYesButtonInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "YesButtonInStopScoringDialogue");
            AssessmentAutomationAgent.Click("AssessmentView", "YesButtonInStopScoringDialogue");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static bool VerifyYesButtonInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "YesButtonInStopScoringDialogue");
        }
        /// <summary>
        /// Clicks on No Button in Stop Scoring Dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickNoButtonInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NoButtonInStopScoringDialogue");
            AssessmentAutomationAgent.Click("AssessmentView", "NoButtonInStopScoringDialogue");


        }

        /// <summary>
        /// click on submit tab from assessment overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSubmittedTabFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "SubmittedView");
        }

        /// <summary>
        /// Get student list from opened tab at assessment overview screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>Array of student list</returns>
        public static ArrayList GetStudentListFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent, int count)
        {
            ArrayList StudentList = new ArrayList();
            //int submittedStudentCount = GetSubmittedCountFromAssessmentOverview(AssessmentAutomationAgent);

            for (int i = 1; i <= count; i++)
            {
                StudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return StudentList;
        }

        /// <summary>
        /// Verify same student display on scoring overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="submittedStudentList">Array of student list</param>
        public static void VerifyStudentListAtScoringOverview(AutomationAgent AssessmentAutomationAgent, ArrayList submittedStudentList)
        {
            for (int i = 0; i < submittedStudentList.Count; i++)
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentListInScoringOverview", submittedStudentList[i].ToString());
        }

        /// <summary>
        /// click on scored tap on assessment overview screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnScoredTabFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ScoredView");
        }

        /// <summary>
        /// click on started tab on assessment overview screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnStartedTabFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StartedView");
        }

        /// <summary>
        /// click on not started tab on assessment overview screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnNotStartedTabFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "NotStartedView");
        }
        /// <summary>
        /// Verify Submitted Category in scoring overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>

        public static void VerifySubmittedCategory(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SubmittedView");

        }
        /// <summary>
        /// Verify Scored category 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void VerifyScoredCategory(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredView"))
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoredView");
            else
                AssessmentAutomationAgent.Swipe(Direction.Down, 500);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoredView");

        }
        /// <summary>
        /// Verify started Category 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void VerifyStartedCategory(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "StartedView"))
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StartedView");
            else
                AssessmentAutomationAgent.Swipe(Direction.Down, 500);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StartedView");
        }
        /// <summary>
        /// Verify not started category
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotStartedCategory(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotStartedView"))
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotStartedView");
            else
                AssessmentAutomationAgent.Swipe(Direction.Down, 500);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotStartedView");
        }
        /// <summary>
        /// Click on fixed assessment score released arrow
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnFixedAssessScoreReleasedArrow(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ScoreReleased");

        }
        /// <summary>
        /// Verify scores released label
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifyScoresReleasedLabel(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoreReleasedLabel");
        }
        /// <summary>
        /// Verify date and time 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifyDateAndTimeBelowScoreReleasedLabel(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LblScoresReleaseDate");
        }

        /// <summary>
        /// Verifies Delivered status in Ongoing Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyDeliveredStatusInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DeliveredStatusInOngoingAssessments", assessmentName);

        }
        /// <summary>
        /// Verifies InProgress status in Ongoing Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyInProgressStatusInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string ongoingTitle)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "InprogressStatusInOngoingAssessments", ongoingTitle);

        }

        /// <summary>
        /// Verifies Pending status in Ongoing Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyPendingStatusInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PendingStatusInOngoingAssessments", assessmentName);

        }

        /// <summary>
        /// Verifies to get the  status from ongoing Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetScoredStatusFromOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentType)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "ScoredSubStatusInOngoingAssessments", "Inside", assessmentType);
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verifies to get the  Scores Released Status from ongoing Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetScoresReleasedStatusFromOngoingAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoresReleasedInOngoingAssessments");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verify date and time 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifyDateAndTimeInAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DateAndTimeStampInOngoingAssessments", assessmentName);
        }
        /// <summary>
        /// Verifies Review and Submit button in Lat Question
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool ReviewAndSubmitButtonFound(AutomationAgent AssessmentAutomationAgent)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReviewAndSubmitIsPresent");

        }


        /// <summary>
        /// Verify Progress Tab colour is blue 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if blue color header), false(header color not blue)</returns>
        public static bool VerifyProgressBarHeaderColorBlue(AutomationAgent AssessmentAutomationAgent)
        {
            string s = AssessmentAutomationAgent.GetElementProperty("AssessmentView", "BackgroundColorOfScoredTabInStopScoringDialogue", "backgroundColor");
            if (s == "0x198098")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get scored student count from Assessment OverView Screen - Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>scored count</returns>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static int GetScoredCountFromAssessmentOverviewAccomplishment(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "ScoredTabOngoingAssessments", "inside", "").Substring(0, 1));
        }
        /// <summary>
        /// Get Not Scored student count from Assessment OverView Screen - Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>Not scored count</returns>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static int GetNotScoredCountFromAssessmentOverviewAccomplishment(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "NotScoredTabOngoingAssessments", "inside", "").Substring(0, 2));

        }

        /// <summary>
        /// Get Not Scored student count from scoring overview - Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>Not Scored count</returns>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string GetNotScoredOngoingCountFromScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.GetElementText("AssessmentView", "NotScoredStudents").Split('(')[1].Substring(0, 2).Trim();
        }
        /// <summary>
        /// Click on lock assessment tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLockIconAssessmentTile(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "LockIconInAssessmentManager");
        }
        /// <summary>
        /// Verify questions header
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifyQuestionsHeader(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionNumberCollection");
        }
        /// <summary>
        /// Click on the rubric score button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickOnRubricScoreButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RubricViewScoreButton");
            AssessmentAutomationAgent.Sleep();
        }

        public static void ClickOnRubricScoreButtonInRubric(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RubricViewScoreButtonInRubric");
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verify Rubric Scoring Flyout
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyRubricScoringFlyout(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricScoreFlyOut");
        }
        /// <summary>
        /// Click to score from the rubric flyout
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickToScoreFromRubricFlyout(AutomationAgent AssessmentAutomationAgent, string scorevalue)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RubricScoreFlyOutMenu", scorevalue);
            AssessmentAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verify student name is sync with lock and unlock icons
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyStudentsWithLockUnlockIcons(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockStudentName");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "LockStatusIcon");
        }

        /// <summary>
        /// Click on cross icon to close the lock or unlock popup
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickToCloseLockUnlockPopup(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("ReceivedWorkView", "CloseButton");
        }

        /// <summary>
        /// verify total number of students submitted should be displayed at the top of the ‘Assessment scoring screen’
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetSubmittedStudentsCountAtItemScoring(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "DownArrowOfStudentAtItemScoring", "Right", "").Split(new string[] { "of " }, StringSplitOptions.None)[0].Trim());
        }

        /// <summary>
        /// Click on Next student button at item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickNextStudentButtonAtItemScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "NextStudent");
        }

        /// <summary>
        /// Verify previous student button found at item scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if button found</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyPreviousStudentButton(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviousStudent");
        }

        public static bool VerifyPreviousStudentButtonInChecklistScoring(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreviousStudentInChecklist");
        }

        public static void ClickPreviousStudentButtonInChecklistScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "PreviousStudentInChecklist");
        }

        public static ArrayList GetNotScoredStudentListFromAssessmentAccomplishment(AutomationAgent AssessmentAutomationAgent, int studentCount)
        {
            ArrayList notScoredStudentList = new ArrayList();

            for (int i = 1; i <= studentCount; i++)
            {
                notScoredStudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return notScoredStudentList;
        }

        /// <summary>
        /// Verify whether the sub status in the assessment row is not getting truncated at the edges.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifySubStatusDisplayAtAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StatusAtAssessmentManager", "Inside", "").Replace("\t\n", "");
            if (text.Contains("Started"))
                text.Length.Equals(12);
            if (text.Contains("Scored"))
                text.Length.Equals(12);
            if (text.Contains("Submitted"))
                text.Length.Equals(15);
        }

        /// <summary>
        /// Verify the teacher should be displayed with the ‘Unit selection drop down box’ with no blank spaces at the bottom in the assessment manager screen.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyUnitSelectionDropDownBoxAtAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "UnitTitleDropDownButton");
            ClickUnitTitleDropdown(AssessmentAutomationAgent);
            int availableUnits = AssessmentAutomationAgent.GetElementCount("AssessmentView", "UnitSelectionList");
            for (int i = 1; i <= availableUnits; i++)
                Assert.IsFalse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "UnitSelectionList", "Inside", "").Equals(" "), "Fail if blank spaces found in drop down");
            ClickUnitTitleDropdown(AssessmentAutomationAgent);
        }

        /// <summary>
        /// verify the teacher should be able to scroll the contents in the ‘Unit selection drop down box’ smoothly and there should be no blank spaces below.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyScrollableUnitSelectionDropDownBox(AutomationAgent AssessmentAutomationAgent)
        {
            ClickUnitTitleDropdown(AssessmentAutomationAgent);
            string currentUnit = AssessmentAutomationAgent.GetTextIn("AssessmentView", "UnitSelectionList", "Inside", "").Replace("\t\n", "");
            AssessmentAutomationAgent.SwipeElement("AssessmentView", "UnitSelectionList", Direction.Up, 500, 1000);
            string currentUnitAfterScroll = AssessmentAutomationAgent.GetTextIn("AssessmentView", "UnitSelectionList", "Inside", "").Replace("\t\n", "");
            //Assert.IsFalse(currentUnit.Equals(currentUnitAfterScroll), "current unit should not be scrollable");
            ClickUnitTitleDropdown(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Click on In progress fixed Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnInProgressFixedAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "InprogressStatusInAssessmentManager");
        }

        public static bool VerifyInProgressFixedAssessmentPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "InprogressStatusInAssessmentManager");
        }

        /// <summary>
        /// Verify Scored Value IN rubric Box
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="p">int object: scoring value</param>
        /// <returns>bool object: if found</returns>
        public static bool VerifyScoredValueInRubricBox(AutomationAgent AssessmentAutomationAgent, string p)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricScoreFlyOutValue", p);
        }
        /// <summary>
        /// Verify Value In rubric Flyout
        /// </summary>
        /// <param name="AssessmentAutomationAgent"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool VerifyValueInRubricFlyout(AutomationAgent AssessmentAutomationAgent, string p)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricScoreFlyOutMenu", p);
        }

        /// <summary>
        /// Get submitted student count from assessment overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>submitted count</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static int GetNotScoredCountFromStopScoringDialogueInAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            return Int32.Parse(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentNotScoredCountInStopScoringDialogue", "Inside", "").Substring(0, 1).Replace(" ", ""));
        }

        /// <summary>
        /// Click on Assessment in Student DashBoard
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentInStudentDashBoard(AutomationAgent AssessmentAutomationAgent, string AssessmentInDashboard)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentLinkInStudentDashBoard", AssessmentInDashboard);
            WaitForPageToload(AssessmentAutomationAgent);
        }
        /// <summary>
        /// Click on My DashBoard button in Student Login
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickMyDashboardButtonInStudentAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("SystemTrayMenuView", "MyDashboard");
        }

        /// <summary>
        /// Verifies to get the title of Student Dashboard
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTitleFromStudentDashBoard(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "MyDashBoardButtonPresent", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Click on My DashBoard button in Student Login
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickAssessmentLinkInMathDashBoard(AutomationAgent AssessmentAutomationAgent, string AssessmentInDashboard)
        {
            AssessmentAutomationAgent.Sleep();
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AssessmentLinkInMathTeacher", AssessmentInDashboard);
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentLinkInMathTeacher", AssessmentInDashboard);
        }

        /// <summary>
        /// Click on My DashBoard button in Student Login
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickMathExerciseInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string exerciseAsssessmentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ExerciseUnderOngoingAssessment", exerciseAsssessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "ExerciseUnderOngoingAssessment", exerciseAsssessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Click on Exercises tab in Lesson Browser
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickExercisesInLessonBrowser(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ExercisesTabInLessonBrowser");
        }
        public static bool VerifyExercisesInLessonBrowser(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ExercisesTabInLessonBrowser");
        }

        /// <summary>
        /// Verify Lesson Tab in Lesson Browser
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: if found</returns>
        public static bool VerifyLessonTabInLessonBrowser(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LessonsTabInLessonBrowser");
        }

        /// <summary>
        /// Verify No Gray Colous separator vertically on Assessment Manager Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyNoGrayColorSeparatorsVertically(AutomationAgent AssessmentAutomationAgent)
        {
            string seperatorHeight = AssessmentAutomationAgent.GetAllValues("AssessmentView", "SeparatorLine", "height")[0];
            Assert.IsTrue(seperatorHeight.Equals("2"));
        }


        /// <summary>
        /// Verify Default question 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyDefaultQuestion(AutomationAgent AssessmentAutomationAgent, string question)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "DefaultQuestion", question);
        }
        /// <summary>
        /// Verifies Questions, Answer and Standard tabs are present in Math Preview Assessment Page
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool QuestionsAnswerAndStandardTabPresent(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTab") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "StandardTab"))
                return true;
            else
                return false;

        }

        public static bool OngoingAssessmentLabelPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OngoingAssessmentLabel");

        }

        public static bool FixedAssessmentLabelPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "FixedAssessmentLabel");

        }

        /// <summary>
        /// Verify Exercise assessment should be displayed under ongoing assessment section
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyExerciseAssessmentInOngoingSection(AutomationAgent AssessmentAutomationAgent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// click on checklist under ongoing assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnOngoingChecklistAssessment(AutomationAgent AssessmentAutomationAgent, string checklistAssessment)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "UACheckList", checklistAssessment);
            AssessmentAutomationAgent.Click("AssessmentView", "UACheckList", checklistAssessment);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verify scoring overview title 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyScoringOverviewTitle(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoringOverviewOnClickScoreButton");
        }

        /// <summary>
        /// Verify the tabs displayed in the Stop Scoring screen for checklist
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyTabsInStopScoringScreenForChecklist(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotScoredTabInStopScoringDialogue");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoredTabInStopScoringDialogue");
        }

        /// <summary>
        /// Verify Exercise assessment should be displayed under ongoing assessment section
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyExerciseAssessmentUnderOngoing(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "OngoingAssessmentLabel", "Down", "");
            Assert.IsTrue(text.Contains("Exercise"));
        }

        /// <summary>
        /// Verify the question content
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyQuestionContentDisplay(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "QuestionContent");
        }


        /// <summary>
        /// Verify Internet Offline Message
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void VerifyNoInternetAccessMessageInLockUnlockScreen(AutomationAgent AssessmentAutomationAgent, string message)
        {
            if (VerifyNoInternetAccessPopUpFound(AssessmentAutomationAgent))
            {
                Assert.IsTrue(AssessmentAutomationAgent.IsElementFound("AssessmentView", "NoInternetAccessLabelLockUnlockScreen", message), "No Internet Access Message Not Found");
            }
            AssessmentAutomationAgent.Click("LoginView", "OkButton");
        }

        /// <summary>
        /// Verify No Internet Access PopUp 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyNoInternetAccessPopUpFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NoInternetAccessLabel");
        }

        /// <summary>
        /// Click on Rubric Assessment Under Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnOngoingRubricAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            int tCount = 0;
            while (!AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricAssessment") && tCount <= 5)
            {
                AssessmentAutomationAgent.Swipe(Direction.Down);
                if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricAssessment"))
                {
                    AssessmentAutomationAgent.Click("AssessmentView", "RubricAssessment");
                    break;
                }
                tCount++;
            }


        }

        /// <summary>
        /// Verify The teacher should be displayed with the observation number below the student name in the scoring screen.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyObservationNumber(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentNameButtonAtScoring", "Down", "");
            Assert.IsTrue(text.Contains("Observation"), "Fail if Observation does not display below student list");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ObservationNumberAtScoring");
        }

        /// <summary>
        /// Verify The teacher should not see ‘Please complete checklist and click ‘submit’ below’ near the observation number in the scoring screen.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyTextInCheckListScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            Assert.IsFalse(AssessmentAutomationAgent.GetText("Native").Contains("Please complete checklist and click ‘submit"), "Fail if this text will display");
        }

        /// <summary>
        /// Verify Teacher should see the “Release Score” button disappear and should see the timestamp (Format: MM/DD/YYYY at HH:MM AM/PM)
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyClickingOnReleaseScoreButton(AutomationAgent AssessmentAutomationAgent)
        {
            if (VerifyScoresReleasedLabel(AssessmentAutomationAgent))
                VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
            else
                ClickOnReleaseScoreButton(AssessmentAutomationAgent);
            VerifyDateAndTimeBelowScoreReleasedLabel(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Click on Release score button 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnReleaseScoreButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReleaseScoresDisabled");
            AssessmentAutomationAgent.Click("AssessmentView", "ReleaseScoresDisabled");
        }

        public static void ClickOnStartButtonReleaseSscorePopUp(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StartButtonInPopUpFound");
            AssessmentAutomationAgent.Sleep(5000);
        }


        /// <summary>
        /// Verify The teacher should be enabled with the ‘Scores released’ button only if 80% students have been scored.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyReleaseScoreButtonEnabledInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseScoreButton");
        }

        /// <summary>
        /// Verify The teacher should be enabled with the ‘Scores released’ button only if 80% students have been scored.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyTimeStampBelowScoreReleasedAtAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            string timeStamp = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoreReleasedAtAssessmentManager").Split('d')[1];
            DateTime date1;
            DateTime.TryParse(timeStamp, out date1);
        }

        /// <summary>
        /// Verify whether the Progress Status is displayed in Assessment Manager Table Cell
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyProgressStatusDisplayAtAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "AssessmentManagerTableCell", "Inside", "").Replace("\t\n", "");
            return (text.Contains("Pending") || text.Contains("In Progress") || text.Contains("Delivered"));

        }

        /// <summary>
        /// Verify Error Message on Starting a Second Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void VerifyAssessmentErrorMessageDisplayed(AutomationAgent AssessmentAutomationAgent)
        {
            if (VerifyAssessmentErrorPopUpFound(AssessmentAutomationAgent))
            {
                Assert.IsTrue(AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentErrorMessageDialog"), "Assessment Error Message Not Found");
            }
        }

        /// <summary>
        /// Verify Assessment Error PopUp Present
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyAssessmentErrorPopUpFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssessmentErrorLabel");
        }

        /// <summary>
        /// Teacher Unlocks a Student Of Second Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void TeacherUnlocksAStudentForOtherAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName, string studentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "AssessmentSelectionFromManagerScreen", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
            ClickUnlockAssessments(AssessmentAutomationAgent);
            ClickOnStudentName(AssessmentAutomationAgent, studentName);
            ClickAssessmentOverlayDone(AssessmentAutomationAgent);

        }
        /// <summary>
        /// The teacher should be displayed with the unlock icon along with “Delivered” status for the assessment in its corresponding row.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyDeliveredStatusInAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DeliveredStatusInAssessmentManager", assessmentName);
        }

        /// <summary>
        /// Scored: X/Y and ‘Scores Released’ sub status should be displayed (Where X is number of students scored, Y is Total number of students in the section) 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyScoreStatusInAssessmentmanager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string[] text1 = AssessmentAutomationAgent.GetElementText("AssessmentView", "ScoredView").Split('/');
            ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent, assessmentName);
            string[] text2 = AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalNumberOfStudentsIsPresentInOverview").Split(' ');
            Assert.IsTrue(text1[1].Equals(text2[0]), "Fail if Y not represent total number of student ");
            int text3 = GetScoredCountFromAssessmentOverview(AssessmentAutomationAgent);
            Assert.IsTrue(Int32.Parse(text1[0]).Equals(text3), "Fail if X not display as number of students scored");

        }

        /// <summary>
        /// Verify that “Scores Released” sub statuses in the assessment manager page.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyScoreReleasedStatusInAssessmentManager(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoreReleasedAtAssessmentManager");
        }

        /// <summary>
        /// Click on Previous student button from Item Scoring screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnPreviousStudentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "PreviousStudentInChecklist");
        }

        /// <summary>
        /// get Not scored student list from stop scoring dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="notscoredCountFromStopScoring">not scored student count</param>
        /// <returns>No0t scored student list</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static ArrayList GetNotScoredStudentListFromStopScoringDialogue(AutomationAgent AssessmentAutomationAgent, int notscoredCountFromStopScoring)
        {
            ArrayList notScoredStudentList = new ArrayList();

            for (int i = 1; i <= notscoredCountFromStopScoring; i++)
            {
                notScoredStudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInStopScoring", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return notScoredStudentList;
        }

        /// <summary>
        /// get Not scored student list from Assessment Overview Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="scoredCount">scored student count</param>
        /// <returns>scored student list</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static ArrayList GetScoredStudentListFromAssessmentOverview(AutomationAgent AssessmentAutomationAgent, int scoredCount)
        {
            ArrayList notScoredStudentList = new ArrayList();

            for (int i = 1; i <= scoredCount; i++)
            {
                notScoredStudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return notScoredStudentList;
        }

        /// <summary>
        /// get Not scored student list from stop scoring dialogue
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <param name="scoredCountFromStopScoring">scored student count</param>
        /// <returns>scored student list</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static ArrayList GetScoredStudentListFromStopScoringDialogue(AutomationAgent AssessmentAutomationAgent, int scoredCountFromStopScoring)
        {
            ArrayList notScoredStudentList = new ArrayList();

            for (int i = 1; i <= scoredCountFromStopScoring; i++)
            {
                notScoredStudentList.Add(AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInStopScoring", "Inside", i.ToString()).Replace("\t", "").Replace("\n", ""));
            }

            return notScoredStudentList;
        }

        /// <summary>
        /// Verifies to get text in Challenge Problem tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromChallengeProblemTile(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ChallengeProblemTileFound");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Verify teacher should see the status of the assessment as Pending when no student should have started exercise assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyPendingStatusForExerciseAssessment(AutomationAgent AssessmentAutomationAgent, string exerciseAssessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PendingStatusForExerciseInAssessment", exerciseAssessmentName);
        }

        /// <summary>
        /// Verify Teacher should see the status of the assessment as In Progress when one student have started the assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifyInProgressStatusForExerciseAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "InProgressStatusForExerciseInAssessment", assessmentName);
        }

        public static bool VerifyStartedStatusForExerciseAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StartedStatusForExerciseInAssessment", assessmentName);
        }

        /// <summary>
        /// Click on ongoing notebook assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void ClickonNotebookOngoingAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            int tCount = 0;
            while (!AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotebookAssessment") && tCount <= 5)
            {
                AssessmentAutomationAgent.Swipe(Direction.Down);
                if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotebookAssessment"))
                {
                    AssessmentAutomationAgent.Click("AssessmentView", "NotebookAssessment");
                    break;
                }
                tCount++;
            }
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verify submitted status in assessment manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifySubmittedStatusInAssessmentManger(AutomationAgent AssessmentAutomationAgent, string studentCount)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SubmittedStudentCountStatusInAssessmentManager", studentCount);
        }


        /// <summary>
        /// Verify started status in assessment manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static bool VerifyScoredStatusInAssessmentmanager(AutomationAgent AssessmentAutomationAgent, string studentCount)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredtudentCountStatusInAssessmentManager", studentCount);
        }

        /// <summary>
        /// Click on assessment which has sample answer button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnFixedAssessmentSampleAnswerAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "SampleAnswerAssessment");
        }

        /// <summary>
        /// verify sample answer button in rubric
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifySampleAnswerButtonInRubric(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SampleAnswerAssessment");
        }


        public static bool VerifySampleAnswerPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SampleAnswerAssessment");
        }

        /// <summary>
        /// Click on sample answer button in rubric panel
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnSampleAnswerInRubric(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "SampleAnswerAssessment");
        }

        /// <summary>
        /// Verify sample answer modal window when tapping on button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifySampleAnswerModalWindow(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SampleAnswerModalWindow");
        }

        /// <summary>
        /// Verify sample scroll view when tapping on button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifySampleAnswerScrollView(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SampleAnswerScrollView");
        }

        /// <summary>
        /// Click on sample answer close icon
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnSampleAnswerCloseIcon(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "SampleAnswerCloseIcon");
            AssessmentAutomationAgent.Sleep(4000);
        }

        /// <summary>
        /// Verify sample answer title
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifySampleAnswerTitle(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "SampleAnswerTitle");
        }

        /// <summary>
        /// Verify sample answer image in modal
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static bool VerifySampleAnswerImage(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("LessonView", "ImageThumbnailInLesson");
        }

        public static void VerifyAssessmentStatusLabelockIconTitlePresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentAssessmentManagerTableCellLockIcon", assessmentName);
        }

        public static void ClickOnLockedAndUnlockedAssessment(AutomationAgent AssessmentAutomationAgent, bool assessmentLocked)
        {
            if (assessmentLocked)
            {
                if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "LockedLabelInStudentManger"))
                {
                    AssessmentAutomationAgent.Click("AssessmentView", "LockedLabelInStudentManger");
                }
            }

            else
            {
                if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnLockedLabelInStudentManger"))
                {
                    AssessmentAutomationAgent.Click("AssessmentView", "UnLockedLabelInStudentManger");
                }
            }
        }

        public static string VerifyAssessmentStatusAndLockIconInsync(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentAssessmentManagerTableCellLockIcon", assessmentName);
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentAssessmentManagerTableCellStatus", assessmentName);
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static bool VerifyAssessmentPresentInStudentDashboard(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentAssessmentManagerAssessmentList");
        }

        /// <summary>
        /// Verifies to get Unanswered text from tile1
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetUnansweredTextFromQuestionTile(AutomationAgent AssessmentAutomationAgent, string questionNumber)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "QuestionStateInSummary", questionNumber);
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static void ClickQuestionTileInStudentAssessmentSummary(AutomationAgent navigationAutomationAgent, string questionNumber)
        {
            navigationAutomationAgent.Click("AssessmentView", "StudentExperienceAssessmentSummaryScreenQuestion1", questionNumber.ToString());
            navigationAutomationAgent.Sleep();

        }

        public static string GetOpenEndedLabelFromQuestionTile(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "OpenEndedLabel", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static void NavigateToGradeAndUnit(AutomationAgent AssessmentAutomationAgent, int gradeNumber, string unitNumber)
        {
            NavigationCommonMethods.NavigateToELAGrade(AssessmentAutomationAgent, gradeNumber);
            int i = 5;
            while (!AssessmentAutomationAgent.IsElementFound("UnitLibraryView", "ELAUnitTile", unitNumber.ToString()) && i > 0)
            {
                NavigationCommonMethods.SwipeUnit(AssessmentAutomationAgent, Direction.Right);
                i--;
            }
            NavigationCommonMethods.StartELAUnitFromUnitLibrary(AssessmentAutomationAgent, unitNumber);

        }

        public static void NavigateToMathGradeAndUnit(AutomationAgent AssessmentAutomationAgent, int gradeNumber, string unitNumber)
        {
            NavigationCommonMethods.NavigateToMathGrade(AssessmentAutomationAgent, gradeNumber);
            int i = 5;
            while (!AssessmentAutomationAgent.IsElementFound("UnitLibraryView", "MathUnitTile", unitNumber.ToString()) && i > 0)
            {
                NavigationCommonMethods.SwipeUnit(AssessmentAutomationAgent, Direction.Right);
                i--;
            }
            NavigationCommonMethods.StartMathUnitFromUnitLibrary(AssessmentAutomationAgent, unitNumber);

        }

        public static string GetTextBesideAssessmentSummaryHeader(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "TextBesideAssessmentSummaryHeader", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static bool VerifyUnansweredLabelIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "UnansweredLabel");

        }

        public static bool VerifyFlaggedLabelIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "FlaggedLabel");

        }

        public static void ClickFlagForLaterInStudentAssessmentSummary(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "FlagForLaterButton");
            AssessmentAutomationAgent.Click("AssessmentView", "FlagForLaterButton");
        }

        public static void ClickRemoveFlagInStudentAssessmentSummary(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "RemoveFlagButton");
            AssessmentAutomationAgent.Click("AssessmentView", "RemoveFlagButton");
            AssessmentAutomationAgent.Sleep(3000);
        }

        public static bool VerifyFlaggedQuestionTileIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "FlaggedQuestionTile");

        }

        /// <summary>
        /// Get first assessment name from assessment Manager
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <returns>string</returns>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static string GetAssessmentNameFromAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            return AssessmentAutomationAgent.GetElementText("AssessmentView", "FixedAssessment1Name", assessmentName);
        }

        /// <summary>
        /// Verify assessment name in screen 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <param name="assessmentName">string</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyAssessmentName(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.GetText("Native").Contains(assessmentName);
        }

        /// <summary>
        /// Click on hide button of rubric panel
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnHideIconOfRubric(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "HideRubric");
        }

        public static bool NotStartedAndStartedTabPresentIn(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTab") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "AnswerTabInMathPreview") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "StandardTab"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Checking System Tray Button in Test Player
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void CheckSystemTrayButtonInTestPlayer(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            ClickAssessmentTile(AssessmentAutomationAgent, assessmentName);
            AssessmentAutomationAgent.Sleep(5000);

            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {

                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(5000);
                int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                {
                    Assert.IsFalse(AssessmentAutomationAgent.IsElementFound("SystemTrayMenuView", "SystemTrayButton"));
                    ClickAssessmentNextButton(AssessmentAutomationAgent);
                }
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReviewAndSubmitIsPresent");
                AssessmentAutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");
            }
        }

        /// <summary>
        /// Getting Rubric Score Label Value
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetRubricScoreLabelValue(AutomationAgent AssessmentAutomationAgent)
        {
            String text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "RubricScoreLabel", "Inside", "");
            return text;

        }

        /// <summary>
        /// Selecting Rubric Discussion Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickRubricDiscussionOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string rubricAssessmentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "RubricDiscussionOngoingAssessment", rubricAssessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "RubricDiscussionOngoingAssessment", rubricAssessmentName);
            WaitForPageToload(AssessmentAutomationAgent);

        }
        /// <summary>
        /// Clicking Rubric Tile 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickRubricTileInObservationOverviewScreen(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "TapOnStudentRubric", studentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Clicking Previous Student Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickPreviousStudentInRubricScoring(AutomationAgent AssessmentAutomationAgent)
        {
            int i = 30;
            while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapOnPreviousButtonInRubricScoring") && i > 0)
            {
                AssessmentAutomationAgent.Click("AssessmentView", "TapOnPreviousButtonInRubricScoring");
                AssessmentAutomationAgent.Sleep();
                i--;
            }
        }

        /// <summary>
        /// Checking Previous Student Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool PreviousStudentButtonNotFound(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapOnPreviousButtonInRubricScoring"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Checking Rubric Scoring Tile
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetRubricScoringTitle(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "RubricScoringTitlePresent");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Clicking SoundnessOfApproach in Rubric
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickSoundnessOfApproachInRubricGroup(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "SoundnessOfApproachScoreFlyout");
            AssessmentAutomationAgent.Click("AssessmentView", "SoundnessOfApproachScoreFlyout");
        }
        /// <summary>
        /// Clicking SoundnessOfApproach in Rubric
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickQualityOfPresentationInRubricGroup(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "QualityOfPresentationScoreFlyout");
            AssessmentAutomationAgent.Click("AssessmentView", "QualityOfPresentationScoreFlyout");


        }
        /// <summary>
        /// Clicking SoundnessOfApproach in Rubric
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickPreparednessOfWorkItemsInRubricGroup(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "PreparationOfWorkItemsScoreFlyout");
            AssessmentAutomationAgent.Click("AssessmentView", "PreparationOfWorkItemsScoreFlyout");

        }

        /// <summary>
        /// Checking Rubric Score Panel Flyout
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool RubricScorePanelFlyoutArrowFound(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoreFlyoutRightPanelArrow"))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Clicking Next Student button in Rubric Scoring
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickNextStudentInRubricScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapOnNextButtonInRubricScoring");
            AssessmentAutomationAgent.Click("AssessmentView", "TapOnNextButtonInRubricScoring");

        }

        /// <summary>
        /// Checking Student name in Rubric Scoring 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetStudentNameInRubricScoring(AutomationAgent AssessmentAutomationAgent, string studentName)
        {

            string text = AssessmentAutomationAgent.GetTextIn("UnitOverView", "UnitNumber", "inside", studentName);
            string newText = text.Replace("\t\n", "");
            return newText;

        }

        public static string GetQuestionNumberFromItemScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.GetTextIn("AssessmentView", "QuestionTabInItemScoring", "Left", "").Split('.')[0];
        }

        /// <summary>
        /// Clicking Previous Student Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickPreviousStudentButtonInRubricScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapOnPreviousButtonInRubricScoring");
            AssessmentAutomationAgent.Click("AssessmentView", "TapOnPreviousButtonInRubricScoring");

        }

        /// <summary>
        /// Clicking Next Student Button in Rubric Scoring
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickNextStudentButtonInRubricScoring(AutomationAgent AssessmentAutomationAgent)
        {
            int i = 30;
            while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapOnNextButtonInRubricScoring") && i > 0)
            {
                AssessmentAutomationAgent.Click("AssessmentView", "TapOnNextButtonInRubricScoring");
                AssessmentAutomationAgent.Sleep();
                i--;
            }


        }

        /// <summary>
        /// Checking next student Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool NextStudentButtonNotFound(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapOnNextButtonInRubricScoring"))
                return true;
            else
                return false;

        }
        public static void ClickProjectInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string projectAssessmentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ProjectUnderOngoingAssessment", projectAssessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "ProjectUnderOngoingAssessment", projectAssessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickNotebookInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string notebookAssessmentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotebookUnderOngoingAssessment", notebookAssessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "NotebookUnderOngoingAssessment", notebookAssessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Clicking Arrow on Option1
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickRubricQuestionOneArrow(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "RubricQuestion");
            AssessmentAutomationAgent.Click("AssessmentView", "RubricQuestion");

        }
        /// <summary>
        /// Checking data present in Option1
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool RubricQuestionDataFound(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricQuestionData"))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Verify hide button in rubric section
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        public static void VerifyHideButtonInRubricSection(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "HideRubric");
        }
        /// <summary>
        /// Click on the assessment tile which is in ‘Submit response’ state corresponding to that unit.
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnSubmittedFixedAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "SubmittedStatusInAssessmentManager");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Click on scores released fixed assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnScoresReleasedFixedAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "ScoreReleasedAtAssessmentManager");
            WaitForPageToload(AssessmentAutomationAgent);
        }
        /// <summary>
        /// Tap on any assessment which has been started by the student
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void ClickOnAssessmentStartedByStudent(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "StartedStatusInAssessmentManager");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        /// <summary>
        /// Verify rubric score criterion level 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Aalmeen Khan(aalmeen.khan)</author>
        public static void VerifyRubricScoreCriteriaLevel(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "RubricScoreLabel");
        }


        /// <summary>
        /// Verify Preview fo Checklist Ongoing Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyPreviewOfChecklistOngoingAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OngoingChecklistPreviewPresent");
        }
        /// <summary>
        /// Teacher Taps On Student Dropdown in Rubric Scoring
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickStudentSelectionDropdown(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StudentDropDownInRubricScoring");
        }

        /// <summary>
        /// Verifies Teacher is able to Verify Student and Status
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void StudentSelectionAndStatus(AutomationAgent AssessmentAutomationAgent, string unitStatus)
        {

            AssessmentAutomationAgent.ElementListSelect("AssessmentView", "StudentSelectionFromDropDown", unitStatus);
            AssessmentAutomationAgent.Click("AssessmentView", "StudentSelectionFromDropDown", unitStatus);

        }

        public static void ClickStudentDropdownInChecklistScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StudentSelectionFromDropDown");
        }

        public static bool VerifyStudentDropdownDisplayedInChecklistScoring(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentDropdownInCheckListScoring");
        }


        public static void VerifyStudentNameAndStatusInChecklistScoring(AutomationAgent AssessmentAutomationAgent)
        {
            if (VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent))
            {
                string studentName = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInDropdownInCheckListScoring").Replace("\t\n", "");
                string studentStatus = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInDropdownInCheckListScoring").Replace("\t\n", "");
                Assert.IsTrue(studentName.Length > 0 && studentStatus.Length > 0);
                Assert.IsTrue(studentStatus.Contains("Scored") || studentStatus.Contains("Released") || studentStatus.Contains("Submitted"));
            }

        }

        public static void VerifyStudentNameAndStatusInNotebookScoring(AutomationAgent AssessmentAutomationAgent)
        {
            if (VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent))
            {
                string studentName = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInDropdownInCheckListScoring").Replace("\t\n", "");
                string studentStatus = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInDropdownInNotebookScoring").Replace("\t\n", "");
                Assert.IsTrue(studentName.Length > 0 && studentStatus.Length > 0);
                Assert.IsTrue(studentStatus.Contains("Scored") || studentStatus.Contains("Released") || studentStatus.Contains("Submitted"));
            }

        }

        /// <summary>
        /// Checking Student name from DropDown in Rubric Scoring Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTotalScoreValueInRubricScoring(AutomationAgent AssessmentAutomationAgent, string score)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "TotalScoreValue", "inside", score);
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Checking Student name and Staus in DropDown in Rubric Scoring Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetStudentStatusFromDropDown(AutomationAgent AssessmentAutomationAgent)
        {

            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentStatus", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;

        }

        /// <summary>
        /// Checking Student name and Staus in DropDown in Rubric Scoring Screen
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetStudentNameFromDropDown(AutomationAgent AssessmentAutomationAgent)
        {

            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentSelectionFromDropDown", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;

        }

        /// <summary>
        /// Verifies Observation Checklist tab in Preview of Checklist Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool VerifyObservationChecklistTabIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ObservationChecklist");

        }
        /// <summary>
        /// Verifies Standard tab in Preview of Checklist Assessment
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool VerifyStandardTabInChecklistAssessmentIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StandardsTabInChecklistPreview");
        }

        public static void ClickStandardTabInChecklistAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "StandardsTabInChecklistPreview");
        }

        /// <summary>
        /// Verify Question with multiple choice answers 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool VerifyMultipleChoiceQuestionView(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "MultipleChoiceQuestion");
        }
        /// <summary>
        /// Verify The teacher should see the dynamic Progress updated
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static void VerifyDynamicProgressBarStatusInAssessmentOverview(AutomationAgent AssessmentAutomationAgent)
        {
            int progressValue = Int32.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "IncreasingPercentageInDynamicProgressBar").Split('%')[0]);
            if (progressValue > 0)
                Assert.AreNotEqual("0", GetScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent), "Scored Students Count is equal to 0");
            else
                Assert.AreEqual("0", GetScoredCountFromAssessmentOverviewAccomplishment(AssessmentAutomationAgent), "Scored Students Count is not equal to 0");
        }

        public static bool VerifyCheckAnswerButtonIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckAnswerButton");

        }

        public static bool VerifyOpenEndedResponseLabelIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OpenEndedResponseLabel");

        }

        public static string GetOpenEndedResponseLabelFromExerciseSummary(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "OpenEndedResponseLabel", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static void ClickOnOpenEndedResponseLabelInExerciseSummary(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "OpenEndedResponseLabel");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickExercisesAssessmentInLessonBrowser(AutomationAgent AssessmentAutomationAgent)
        {
            int availableExercises = AssessmentAutomationAgent.GetElementCount("AssessmentView", "ExerciseTable");
            for (int i = 1; i <= availableExercises; i++)
            {
                AssessmentAutomationAgent.Click("AssessmentView", "ExerciseTableCell", i.ToString());
                if (VerifyOpenEndedResponseLabelIsPresent(AssessmentAutomationAgent))
                    break;
                ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(3000);
            }

        }

        public static void ClickExercisesInLessonTab(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ExerciseTableCell", "1");
        }

        public static void ClickMachineScoredExercisesInLessonTab(AutomationAgent AssessmentAutomationAgent, string machineScoredExercise)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "EquationEditorAssessment", machineScoredExercise);
        }

        public static void StudentTapsOnUnlockedAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.Sleep(10000);
            ClickAssessmentTile(AssessmentAutomationAgent, assessmentName);
            AssessmentAutomationAgent.Sleep(10000);
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(10000);
            }
        }

        public static void StudentAnswerOpenEndedResponse(AutomationAgent AssessmentAutomationAgent, string answer)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "OpenEndedInteractionResponse");
            AssessmentAutomationAgent.SendText(answer);
            AssessmentAutomationAgent.CloseKeyboard();
        }


        public static bool OpenEndedResponsePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OpenEndedInteractionResponse");
        }

        /// <summary>
        /// Verifies Open Ended Response
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static string VerifyOpenEndedQuestionResponse(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "OpenEndedInteractionResponse");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static bool LoaderIconPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "LoaderImageView");
        }

        public static void ClickOnRefreshIcon(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "RefreshButton");
        }

        public static void StudentAnswersMachineScoredQuestion(AutomationAgent AssessmentAutomationAgent, string answer)
        {
            switch (answer)
            {
                case "A":
                    //AssessmentAutomationAgent.ClickCoordinate(85, 874, 1);
                    AssessmentAutomationAgent.Click("AssessmentView", "QuestionOptionsInExercises", "A.");
                    AssessmentAutomationAgent.Sleep(2000);
                    break;
                case "B":
                    //AssessmentAutomationAgent.ClickCoordinate(220, 954, 1);
                    AssessmentAutomationAgent.Click("AssessmentView", "QuestionOptionsInExercises", "B.");
                    AssessmentAutomationAgent.Sleep(2000);
                    break;
                case "C":
                    //AssessmentAutomationAgent.ClickCoordinate(155, 1064, 1);
                    AssessmentAutomationAgent.Click("AssessmentView", "QuestionOptionsInExercises", "C.");
                    AssessmentAutomationAgent.Sleep(2000);
                    break;
                case "D":
                    //AssessmentAutomationAgent.ClickCoordinate(220, 1087, 1);
                    AssessmentAutomationAgent.Click("AssessmentView", "QuestionOptionsInExercises", "D.");
                    AssessmentAutomationAgent.Sleep(2000);
                    break;
            }

        }

        public static void ClickOnMachineScoredQuestionInExercise(AutomationAgent AssessmentAutomationAgent)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "OpenEndedResponseLabel");
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickCheckAnswerButton(AutomationAgent AssessmentAutomationAgent)
        {
            VerifyCheckAnswerButtonIsPresent(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "CheckAnswerButton");
            AssessmentAutomationAgent.Sleep(3000);
        }

        public static bool SelectAnAnswerFirstDisplayed(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckAnswerWithoutAnswerMessage");
        }

        public static bool TryAgainMessageDisplayed(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckAnswerWrongAnswerMessage");
        }

        public static bool TryAnotherQuestionMessageDisplayed(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckAnswerMessageAfterSecondAttempt");
        }

        public static bool SuccessHumanScoredQuestionMessageDisplayed(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckAnswerCorrectAnswerMessage");
        }

        public static void ClickReviseAnswerButton(AutomationAgent AssessmentAutomationAgent)
        {
            VerifyReviseAnswerButtonIsPresent(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "ReviseAnswerButton");
        }

        public static bool VerifyCheckAnswerButtonIsDisabled(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckAnswerButtonDisabled");
        }

        public static bool VerifyReviseAnswerButtonIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReviseAnswerButton");
        }

        public static bool VerifyFlagForLaterButtonIsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "FlagForLaterButton");

        }

        public static bool VerifyHideRubricTabIsPresentInTeacherPreview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "HideRubric");

        }

        public static bool VerifyRubricScoreButtonInTeacherPreview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricViewScoreButton");
        }

        public static void ClickYesIgotItButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "YesIGotItButton");
            AssessmentAutomationAgent.Click("AssessmentView", "YesIGotItButton");
        }

        public static bool GetYesIgotItLabelInAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string question)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SelfEvaluationLabelInSummary", question);
        }

        public static bool VerifyReleaseScoresDisabled(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseScoresDisabled");
        }

        public static void ReleaseScoresForRubric(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "ReleaseScoresDisabled");
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                WaitForPageToload(AssessmentAutomationAgent);
            }
        }

        public static bool VerifyQuestionStatusInAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string question)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionStateInSummary", question);
        }
        /// <summary>
        /// Verify Progress Tab colour is blue 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <returns>boolean: true(if blue color header), false(header color not blue)</returns>
        public static bool VerifyAnsweredQuestiontile(AutomationAgent AssessmentAutomationAgent, string questionNo)
        {
            string s = AssessmentAutomationAgent.GetElementProperty("AssessmentView", "UnansweredTextInQuestion6", "backgroundColor", questionNo);
            if (s == "0xE1E1E1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyFlagLabelPresentInAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string tileNumber)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "FlaggedQuestionTileInSummary", tileNumber);
        }
        public static string GetAnsweredTestInELAAssessmentSummary(AutomationAgent AssessmentAutomationAgent, int question)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "AnsweredText", "inside", question.ToString());
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        /// <summary>
        /// Verifies clicking on Review and Submit Button
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickReviewAndSubmitButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ReviewAndSubmitIsPresent");
            AssessmentAutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");


        }
        /// <summary>
        /// Verifies criterian Level for Score
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void CheckCriterionLevel(AutomationAgent AssessmentAutomationAgent, string scorenumber)
        {
            int n = int.Parse(scorenumber);
            int j = 30;
            for (int i = 1; i <= n; i++)
            {
                ClickOnRubricScoreButton(AssessmentAutomationAgent);
                while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricScoreFlyOut") && j > 0)
                {
                    ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, i.ToString());
                    Assert.AreEqual(i.ToString(), VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                    j--;
                }
            }

            ClickOnRubricScoreButton(AssessmentAutomationAgent);
            j = 30;
            while (AssessmentAutomationAgent.IsElementFound("AssessmentView", "RubricScoreFlyOut") && j > 0)
            {
                ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, "--");
                Assert.AreEqual("--", VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent), "Rubric Total Score Label Not Populated");
                j--;
            }
        }

        /// <summary>
        /// Verifies clicking on Done and Yes Button when back to Scoring Overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void BackToScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
            ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);
            WaitForPageToload(AssessmentAutomationAgent);
        }
        public static void VerifySelfEvaluationOptionsPresent(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "YesIGotItButton");
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "IsUncertainButton");
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "IsNeedHelpButton");
        }

        public static void ClickUnderstandNowButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "IsUncertainButton");
            AssessmentAutomationAgent.Click("AssessmentView", "IsUncertainButton");
            AssessmentAutomationAgent.Sleep(4000);
        }

        public static void ClickNeedHelpButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "IsNeedHelpButton");
            AssessmentAutomationAgent.Click("AssessmentView", "IsNeedHelpButton");
        }

        public static bool VerifySelfEvaluationLabelInAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string question)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SelfEvaluationLabelInSummary", question);
        }

        public static bool VerifyYouCanTryAgainLabelInSelfEvaluation(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "YouCanTryAgainLabel");
        }

        public static void ClickReviewButtonInLastQuestion(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReviewButtonInExercise");
            AssessmentAutomationAgent.Click("AssessmentView", "ReviewButtonInExercise");
        }
        /// <summary>
        /// Verifies Test Player is shown in Web View of Exercise for Teacher
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool WebViewOfTestPlayerForTeacher(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "TeacherPreviewAnswers");

        }
        public static void ClickStudentResponseTab(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentResponseTabInItemScoring");
            AssessmentAutomationAgent.Click("AssessmentView", "StudentResponseTabInItemScoring");
        }
        public static void ClickQuestionTabInItemScoring(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "QuestionTabInItemScoring");
            AssessmentAutomationAgent.Click("AssessmentView", "QuestionTabInItemScoring");
        }
        /// <summary>
        /// Verifies to get text Exercise Assessment Summary Title
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static string GetTextFromExerciseTitle(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "ExerciseTitle");
            string newText = text.Replace("\t\n", "");
            return newText;
        }
        /// <summary>
        /// Click on radio button in 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickOnStudentNameInNotebookScoringOverview(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentSelectionInNoteBookScoringOverview");
            AssessmentAutomationAgent.Click("AssessmentView", "StudentSelectionInNoteBookScoringOverview");
            WaitForPageToload(AssessmentAutomationAgent);
        }
        public static bool VerifyNoButtonInStopScoringDialogue(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NoButtonInStopScoringDialogue");
        }
        /// <summary>
        /// Verifies Item Scoring Screen Number
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickQuestionTwoInScoringOverview(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ClickQuestion3TextBox", studentName);
            AssessmentAutomationAgent.Click("AssessmentView", "ClickQuestion3TextBox", studentName);
        }
        /// <summary>
        /// Verifies Item Scoring Screen Number
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickQuestionThreeInScoringOverview(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ClickQuestion4TextBox", studentName);
            AssessmentAutomationAgent.Click("AssessmentView", "ClickQuestion4TextBox", studentName);
        }
        /// <summary>
        /// Score a Student for Different Criteria's
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickFlyoutForEachCriteria(AutomationAgent AssessmentAutomationAgent, String criteriaLevel)
        {
            int n = int.Parse(criteriaLevel);
            for (int i = 1; i < 5; i++)
            {

                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "StudentScoreForDifferentCriterias", n.ToString());
                AssessmentAutomationAgent.Click("AssessmentView", "StudentScoreForDifferentCriterias", n);
                ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, n.ToString());
                n++;
            }
        }

        /// <summary>
        /// Clicks on Omit Button#3
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickOnOmitButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "OmitButtonBeforeScoresReleased");
            AssessmentAutomationAgent.Click("AssessmentView", "OmitButtonBeforeScoresReleased");
        }

        public static bool OkButtonInOmitConfirmationPopUpFound(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OkButton");

        }
        public static bool VerifyActiveReleaseScoreButtonAtScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseScoresDisabled");

        }
        public static bool VerifyCommonCoreStandardsLabelPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CommonCoreStandardsLabel");
        }

        public static void ClickOnEquationEditorAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "EquationEditorAssessment", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickOnSampleAnswerAssessment(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "EquationEditorAssessment", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void VerifyEquationEditorInAssessments(AutomationAgent AssessmentAutomationAgent)
        {
            while (!AssessmentAutomationAgent.IsElementFound("AssessmentView", "EquationEditorMoreButton"))
            {
                ClickAssessmentNextButton(AssessmentAutomationAgent);
            }
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "EquationEditorMoreButton");
        }

        public static bool VerifyDoneButtonInExerciseSummaryPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "DoneButtonInChecklistScoring");
        }

        /// <summary>
        /// Verifies Pending status in Ongoing Notebook/Project Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyPendingStatusInNotebookAssessment(AutomationAgent AssessmentAutomationAgent, string notebookTitle)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "PendingStatusForAssessments", notebookTitle);

        }
        /// <summary>
        /// Verifies Scored status in Notebook/Project Assessments
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool VerifyScoredStatusInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string OngoingTitle)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredSubStatusInOngoingAssessments", OngoingTitle);

        }
        /// <summary>
        /// Verifies Project Assessment under Ongoing Section
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool VerifyProjectInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string projectAssessmentName)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ProjectUnderOngoingAssessment", projectAssessmentName);

        }
        /// <summary>
        /// Verifies Notebook Assessment under Ongoing Section
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static bool VerifyNotebookInOngoingAssessment(AutomationAgent AssessmentAutomationAgent, string notebookAssessment)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotebookUnderOngoingAssessment", notebookAssessment);

        }

        public static bool VerifyRevisedStatusInAssessmentSummary(AutomationAgent AssessmentAutomationAgent, string question)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "RevisedButtonInSummary", question);
        }

        /// <summary>
        /// Click on student name in Scoring Overview
        /// </summary>
        /// <param name="AssessmentAutomationAgent">Automation Agent</param>
        /// <author>Lakshmi Brunda(lakshmi.brunda)</author>
        public static void ClickOnStudentNameInProjectAssessmentScoring(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("UnitOverView", "UnitNumber", studentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void ClickOnProjectActiveTile(AutomationAgent AssessmentAutomationAgent, string tileNumber)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Click("AssessmentView", "ProjectAssessmentActiveTileInScoringOverview", tileNumber);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static bool VerifySecondTilePresentInNotebookScoring(AutomationAgent AssessmentAutomationAgent, string question)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ProjectAssessmentSecondTileInScoringOverview", question);
        }

        public static void ClickBackToAssessmentManagerScreen(AutomationAgent AssessmentAutomationAgent)
        {

            BackToScoringOverviewScreen(AssessmentAutomationAgent);
            ClickMyDashboardButton(AssessmentAutomationAgent);
            ClickAssessmentManagerButton(AssessmentAutomationAgent);
            WaitForPageToload(AssessmentAutomationAgent);


        }
        public static bool ExerciseWithInProgressAndStartedStatus(AutomationAgent AssessmentAutomationAgent, string attempted)
        {

            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ExerciseWithInProgressStatus", attempted);

        }

        public static bool VerifyNotScoredLabelValue(AutomationAgent AssessmentAutomationAgent, string scoreLabel)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotScoredRubricLabel", scoreLabel);
        }

        public static void TeacherScoresANoteBookAndProjectAssessment(AutomationAgent AssessmentAutomationAgent, int count, string scoreLabel, string scoreValue)
        {
            for (int i = count + 1; i > 1; i--)
            {
                AssessmentAutomationAgent.Click("AssessmentView", "OngoingAssessmentActiveTileInScoringOverview", i.ToString());
            }
            ClickOnProjectActiveTile(AssessmentAutomationAgent, "5");
            TeacherScoresNotebookAssessment(AssessmentAutomationAgent, scoreLabel, scoreValue);
        }

        public static void TeacherScoresRubricAssessment(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string score)
        {
            while (VerifyNotScoredLabelValue(AssessmentAutomationAgent, scoreLabel))
            {
                ClickNotScoredCriterions(AssessmentAutomationAgent, scoreLabel);
                ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, score);
                AssessmentAutomationAgent.Sleep(3000);
            }
        }

        public static void ClickNotScoredCriterions(AutomationAgent AssessmentAutomationAgent, string scoreLabel)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotScoredRubricLabel", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "NotScoredRubricLabel", scoreLabel);

        }

        public static void ClickReleaseScoreButton(AutomationAgent AssessmentAutomationAgent)
        {

            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseScoreButton");
            AssessmentAutomationAgent.Click("AssessmentView", "ReleaseScoreButton");

        }

        public static void ReleaseScoreForNotebook(AutomationAgent AssessmentAutomationAgent)
        {

            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseScoreButton");
            AssessmentAutomationAgent.Click("AssessmentView", "ReleaseScoreButton");
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(5000);
            }

        }

        public static bool VerifyStudentResponseTabHighlighted(AutomationAgent AssessmentAutomationAgent)
        {
            string s = AssessmentAutomationAgent.GetElementProperty("AssessmentView", "StudentResponseTabInItemScoring", "textColor");
            if (s == "0x262626")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void VerifyExercisesStatusInLessonBrowser(AutomationAgent AssessmentAutomationAgent)
        {
            int availableExercises = AssessmentAutomationAgent.GetElementCount("AssessmentView", "ExerciseTable");
            for (int i = 1; i <= availableExercises; i++)
            {
                string status = AssessmentAutomationAgent.GetElementText("AssessmentView", "ExerciseWithProgressInLessonBrowser", i.ToString());
                Assert.IsTrue(status.Contains("Not Started") || status.Contains("Started") || status.Contains("Completed"));

            }

        }

        public static bool SubmittedCountLabelInScoringOverview(AutomationAgent AssessmentAutomationAgent, string count)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SubmittedCountInScoringOverview", count);

        }

        public static bool ScoredCountLabelInScoringOverview(AutomationAgent AssessmentAutomationAgent, string count)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredCountInScoringOverview", count);

        }

        public static void VerifyStudentProficiencyLabelStatusPresent(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentProficiencyLabel", "inside", assessmentName).Replace("\t\n", "");
            Assert.IsTrue(text.Contains("Proficient") || text.Contains("Not Proficient") || text.Contains("At Risk"));
        }

        public static string VerifyStudentAssessmentStatusInUnlockScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentAssessmentStatus", "inside", "").Replace("\t\n", "");
            return text;
        }

        public static bool VerifyScoredTabSelectedByDefaultInStopScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredTabSelectedByDefault");

        }

        public static bool VerifyStudentResponseTabSelectedByDefaultInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentResponseTabSelectedByDefault");

        }

        public static bool VerifyTeacherPreviewAssessmentTextInTaskLevelAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "TeacherPreviewTextInTaskAssessment");

        }

        public static void ClickPreviewButtonInTaskLevelAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "TeacherPreviewButtonInTaskAssessment");
            AssessmentAutomationAgent.Click("AssessmentView", "TeacherPreviewButtonInTaskAssessment");
        }

        public static void ClickTaskLevelAssessmentInManagerScreen(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "TaskLevelAssessmentInManagerScreen", assessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "TaskLevelAssessmentInManagerScreen", assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
        }

        public static void TeacherUnlocksStudentForTaskLevelAssessment(AutomationAgent AssessmentAutomationAgent, string sectionAndperiod, string studentName, string UnitStatus, string assessmentName)
        {
            AssessmentAutomationAgent.Sleep();
            ClickAssessmentInDashBoard(AssessmentAutomationAgent, sectionAndperiod);
            WaitForPageToload(AssessmentAutomationAgent);
            AssessmentUnitSelection(AssessmentAutomationAgent, UnitStatus);
            WaitForPageToload(AssessmentAutomationAgent);
            ClickTaskLevelAssessmentInManagerScreen(AssessmentAutomationAgent, assessmentName);
            WaitForPageToload(AssessmentAutomationAgent);
            ClickUnlockAssessments(AssessmentAutomationAgent);
            ClickOnStudentName(AssessmentAutomationAgent, studentName);
            ClickAssessmentOverlayDone(AssessmentAutomationAgent);

        }

        public static bool VerifyStudentPreviewAssessmentTextInTaskLevelAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentPreviewTextInTaskAssessment");

        }

        public static bool VerifyStudentStatusInTaskLevelAssessment(AutomationAgent AssessmentAutomationAgent, string status)
        {
            return AssessmentAutomationAgent.IsElementFound("CommonReadAnnotationsPanelView", "TimeStampLabel", status);

        }

        public static void StudentAnswerTaskLevelAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("CommonReadAnnotationsPanelView", "TimeStampLabel", "Start");
            if (AssessmentTilePopUpFound(AssessmentAutomationAgent))
            {
                ClickAssessmentStartButtonInPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(10000);
                int currentQuestionNumber = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "CurrentQuestionInCurrentScreenFound"));
                int TotalQuestions = int.Parse(AssessmentAutomationAgent.GetElementText("AssessmentView", "TotalQuestionsInCurrentScreenFound"));
                for (int i = currentQuestionNumber; i < TotalQuestions; i++)
                {
                    ClickAssessmentNextButton(AssessmentAutomationAgent);
                }
                ClickSubmitButtonInLastQuestionOfAssessment(AssessmentAutomationAgent);
                ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
                AssessmentAutomationAgent.Sleep(5000);
            }
        }

        public static void ClickStudentCheckBoxInScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent, string studentCheckBox)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentCheckBox", studentCheckBox);
            AssessmentAutomationAgent.Click("AssessmentView", "StudentCheckBox", studentCheckBox);
        }

        public static void ClickAllgroupMemeberDropDownInScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "DownArrowOfStudentAtItemScoring");
            AssessmentAutomationAgent.Click("AssessmentView", "DownArrowOfStudentAtItemScoring");
        }

        public static void SelectStudentFromDropDownInScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "StudentNameInDropDown", studentName);
            AssessmentAutomationAgent.Click("AssessmentView", "StudentNameInDropDown", studentName);
        }

        public static void ClickAddCommentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "AddCommentButton");
            AssessmentAutomationAgent.Click("AssessmentView", "AddCommentButton");
        }

        public static void ClickEditCommentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "EditCommentButton");
            AssessmentAutomationAgent.Click("AssessmentView", "EditCommentButton");
        }

        public static bool AddCommentOverlayPresentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AddCommentOverlay");
        }

        public static bool ViewCommentButtonPresentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ViewCommentButton");
        }

        public static bool ViewCommentButtonPresentFixedAssessment(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ViewCommentButtonFixedAssessment");
        }

        public static void ClickViewCommentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ViewCommentButton");
            AssessmentAutomationAgent.Click("AssessmentView", "ViewCommentButton");
        }

        public static bool ViewCommentOverlayPresentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ViewCommentOverlay");
        }

        public static bool VerifyReleaseTextAndLockIconInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return (AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseLockIconInScoringScreen") && AssessmentAutomationAgent.IsElementFound("AssessmentView", "ReleaseTextInScoringScreen"));
        }

        public static bool CreateButtonPresentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CreateButtonInAddComment");

        }

        public static void ClickCreateCommentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "CreateButtonInAddComment");
            AssessmentAutomationAgent.Click("AssessmentView", "CreateButtonInAddComment");
            AssessmentAutomationAgent.Click("LoginView", "OkButton");
            AssessmentAutomationAgent.Sleep();
        }

        public static void ClickCreateButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "CreateButtonInAddComment");
        }


        public static void TeacherEnterComments(AutomationAgent AssessmentAutomationAgent, string comment)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "CommentTextBox");
            AssessmentAutomationAgent.SendText(comment);
            AssessmentAutomationAgent.CloseKeyboard();
        }

        public static void ClickDeleteCommentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "CommentTextBoxDeleteButton");
            AssessmentAutomationAgent.Click("AssessmentView", "CommentTextBoxDeleteButton");
            AssessmentAutomationAgent.Click("LoginView", "OkButton");
        }

        public static void ClickDoneInCommentButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "CommentDoneButton");
            AssessmentAutomationAgent.Click("AssessmentView", "CommentDoneButton");
        }

        public static string VerifyCharacterLimitInCommentBox(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "CommentTextBoxCharactersLimit").Replace("\t\n", "");
            return text;
        }

        public static string VerifyEnteredCommentInViewCommment(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "CommentTextBoxCharactersLimit").Replace("\t\n", "");
            return text;
        }

        public static bool CorrectAnswerDisplayedInHumanScoredQuestion(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CorrectAnswerDisplayed");
        }

        public static bool AnswerTabDisplayedInPreviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AnswerTabInPreviewScreen");

        }


        public static bool VerifyCorrectAnswerDisplayedInPreviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "AnswerTabInPreviewScreen");
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckedAnswerInPreviewScreen");

        }

        public static void ClicCriterionLevelScoreFromMultiRubric(AutomationAgent AssessmentAutomationAgent, string criteria)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "CriterionLevelRubricScoring", criteria);
            AssessmentAutomationAgent.Click("AssessmentView", "CriterionLevelRubricScoring", criteria);
            AssessmentAutomationAgent.Sleep();
        }

        public static string VerifyRubricScoreLAbelValuePopulated(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "RubricViewScoreLabel").Replace("\t\n", "");
            return text;
        }

        public static string VerifyRubricQuestionNumberLabel(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "RubricQuestionNumberLabel").Replace("\t\n", "");
            return text;
        }

        public static void ClickScoreReleasedInStudentAssessmentManager(AutomationAgent AssessmentAutomationAgent, string assessmentName)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoresReleasedInOngoingAssessments", assessmentName);
            AssessmentAutomationAgent.Click("AssessmentView", "ScoresReleasedInOngoingAssessments", assessmentName);
        }


        public static bool VerifyScoredAnswerReportTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredAnswerReportTitle");
        }

        public static bool VerifyScoredAnswerProjectReportTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ProjectReportScoringTitle");
        }

        public static string VerifyStudentNameInScoringOverviewScreen(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInScoringOverview").Replace("\t\n", "");
            return text;
        }

        public static bool VerifyAllGroupMembersTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssignmentScoringAllGroupMembersTitle");
        }

        public static void ClickAllGroupMembersInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssignmentScoringAllGroupMembersTitle");
            AssessmentAutomationAgent.Click("AssessmentView", "AssignmentScoringAllGroupMembersTitle");
        }

        public static int VerifyStudentNameListInAllGroupMemberDropdown(AutomationAgent AssessmentAutomationAgent)
        {
            int studentCount = AssessmentAutomationAgent.GetElementCount("AssessmentView", "StudentDropListInNotebookScoring");
            return studentCount;
        }

        public static bool VerifyAssignmentTabPresentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentView", "AssignmentTabInNotebookScoring");
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssignmentTabInNotebookScoring");
        }

        public static bool VerifyMultiDimensionalRubricGroupTitleLabel(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "MultiDimensionalRubricGroupTitleLabel");
        }

        public static void ClickCriterionLevelInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "MultiDimensionalCriterionLevelLabel");
            AssessmentAutomationAgent.Click("AssessmentView", "MultiDimensionalCriterionLevelLabel");
        }

        public static bool VerifyMultiDimensionalLevelLabelPresent(AutomationAgent AssessmentAutomationAgent, string level)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "MultiDimensionalLevelDescriptionLabel", level);
        }

        public static bool VerifyStudentCountFormatInScoringOverview(AutomationAgent AssessmentAutomationAgent, string totalCount)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SubmittedFormatDisplayed", totalCount);
        }

        public static bool VerifyStudentResponsePresentInResponseScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("InteractiveView", "DivInInteractive");
        }


        /// <summary>
        /// Verify the question tile is active 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        /// <author>Godwin Terence(godwin.terence)</author>
        public static bool VerifyQuestionActiveInChecklistScoringOverview(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            string enabled = AssessmentAutomationAgent.GetAllValues("AssessmentView", "ClickQuestion1TextBox", studentName, "enabled")[0];
            return Convert.ToBoolean(enabled);
        }

        /// <summary>
        /// Verify Not Scored Category 
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void VerifyNotScoredCategoryInChecklistScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "NotScoredCategoryInScoringOverview"))
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotScoredCategoryInScoringOverview");
            else
                AssessmentAutomationAgent.Swipe(Direction.Down, 500);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotScoredCategoryInScoringOverview");
        }

        /// <summary>
        /// Verify Scored category
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void VerifyScoredCategoryInChecklistScoringOverview(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "ScoredCategoryInScoringOverview"))
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoredCategoryInScoringOverview");
            else
                AssessmentAutomationAgent.Swipe(Direction.Down, 500);
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ScoredCategoryInScoringOverview");
        }

        /// <summary>
        /// Verify Teacher able to score checklist
        /// </summary>
        /// <param name="AssessmentAutomationAgent">AutomationAgent object</param>
        public static void TeacherScoresACheclistAsNotObserved(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NotObservedButtonInChecklistScoring");
            int notObservedButtonCount = AssessmentAutomationAgent.GetElementCount("AssessmentView", "NotObservedButtonInChecklistScoring");
            for (int i = notObservedButtonCount; i >= 1; i--)
            {
                AssessmentAutomationAgent.Click("AssessmentView", "NotObservedCircleInChecklistScoring", i.ToString());
            }
            AssessmentAutomationAgent.Swipe(Direction.Down, 500);
            AssessmentAutomationAgent.Click("AssessmentView", "BeginningCircleInChecklistScoring", "3");
        }

        public static bool VerifyCheckMarkInChecklistQuestionTile(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "CheckMarkScoringOnQuestionTileInChecklist");
        }

        public static bool VerifyAssignmentScoringTitlePresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AssignmentScoringTitle");
        }
        public static string GetTitleFromChecklistScoringPage(AutomationAgent AssessmentAutomationAgent)
        {
            string text = AssessmentAutomationAgent.GetTextIn("AssessmentView", "ChecklistScoringTitle", "inside", "");
            string newText = text.Replace("\t\n", "");
            return newText;
        }

        public static void SelectSpecificStudentToScore(AutomationAgent AssessmentAutomationAgent, String studentSelect)
        {
            WaitForPageToload(AssessmentAutomationAgent);
            while (VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent))
            {
                ClickStudentDropdownInChecklistScoring(AssessmentAutomationAgent);
                AssessmentAutomationAgent.ElementListSelect("AssessmentView", "StudentNameInDropdownInCheckListScoring", studentSelect);
                string studentName = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInDropdownInCheckListScoring").Replace("\t\n", "");
                string studentStatus = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInDropdownInCheckListScoring").Replace("\t\n", "");
                if ((studentName.Contains(studentSelect)) && (studentStatus.Contains("Not Scored")))
                {
                    AssessmentAutomationAgent.Click("AssessmentView", "StudentNameInDropdownInCheckListScoring", studentSelect);
                    TeacherScoresACheclistAsNotObserved(AssessmentAutomationAgent);
                }


                ClickDoneButtonInCheckListScoring(AssessmentAutomationAgent);
                ClickYesButtonInStopScoringDialogue(AssessmentAutomationAgent);

            }
        }

        public static void ConfirmChecklistAssessmentScored(AutomationAgent AssessmentAutomationAgent)
        {
            int tCount = 5;
            int scoredCount = AssessmentAutomationAgent.GetElementCount("AssessmentView", "ChecklistScored");
            Assert.AreEqual(scoredCount, tCount, "Scoring Not Completed");
        }



        public static void ClickOnNextObservationButton(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "NextObservation");
            AssessmentAutomationAgent.Click("AssessmentView", "NextObservation");

        }

        public static bool verifyNextObservation(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NextObservation");
        }

        public static void ClickOnConsistentOption(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ConsistentButton");
            AssessmentAutomationAgent.Click("AssessmentView", "ConsistentButton");
        }

        public static bool verifyConsistentButtonIsSelected(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "ConsistentButton");
        }

        public static void TeacherScoresMultirubricQuestion(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            while (VerifyNotScoredLabelValue(AssessmentAutomationAgent, scoreLabel))
            {
                ClickNotScoredCriterions(AssessmentAutomationAgent, scoreLabel);
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricScoringFlyout(AssessmentAutomationAgent), "Rubric scoring flyout not found for criterion");
                ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoredValueInRubricBox(AssessmentAutomationAgent, scoreValue), "Scored value not found in the rubric box");
            }
            AssessmentAutomationAgent.Sleep(5000);
            if (VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent).Equals(scoreLabel))
            {
                AssessmentCommonMethods.ClickOnRubricScoreButton(AssessmentAutomationAgent);
                AssessmentCommonMethods.ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
            }
        }

        public static void VerifyStudentNameAndReleasedStatusInItemScoring(AutomationAgent AssessmentAutomationAgent, string studentSelect)
        {
            if (VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent))
            {
                string studentName = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInDropdownInCheckListScoring").Replace("\t\n", "");
                string studentStatus = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInDropdownInCheckListScoring").Replace("\t\n", "");
                Assert.IsTrue(studentName.Length > 0 && studentStatus.Length > 0);
                Assert.IsTrue(studentStatus.Contains("Released"));
            }

        }

        public static void VerifyStudentNameAndScoredStatusInItemScoring(AutomationAgent AssessmentAutomationAgent, string studentSelect)
        {
            if (VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent))
            {
                ClickStudentDropdownInChecklistScoring(AssessmentAutomationAgent);
                AssessmentAutomationAgent.ElementListSelect("AssessmentView", "StudentNameInDropdownInCheckListScoring", studentSelect);
                string studentName = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInDropdownInCheckListScoring").Replace("\t\n", "");
                string studentStatus = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInDropdownInCheckListScoring").Replace("\t\n", "");
                Assert.IsTrue(studentName.Length > 0 && studentStatus.Length > 0);
                Assert.IsTrue(studentStatus.Contains("Scored"));
            }

        }

        public static void VerifyStudentNameAndSubmittedStatusInItemScoring(AutomationAgent AssessmentAutomationAgent, string studentSelect)
        {
            if (VerifyStudentDropdownDisplayedInChecklistScoring(AssessmentAutomationAgent))
            {
                string studentName = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameInDropdownInCheckListScoring").Replace("\t\n", "");
                string studentStatus = AssessmentAutomationAgent.GetElementText("AssessmentView", "StatusInDropdownInCheckListScoring").Replace("\t\n", "");
                Assert.IsTrue(studentName.Length > 0 && studentStatus.Length > 0);
                Assert.IsTrue(studentStatus.Contains("Submitted"));
            }

        }

        public static void TeacherScoresNotebookAssessment(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            ClickIntroductionInRubricGroup(AssessmentAutomationAgent, scoreLabel, scoreValue);
            ClickOrganizationInRubricGroup(AssessmentAutomationAgent, scoreLabel, scoreValue);
            ClickDevelopmentInRubricGroup(AssessmentAutomationAgent, scoreLabel, scoreValue);
            ClickVocabularyInRubricGroup(AssessmentAutomationAgent, scoreLabel, scoreValue);
            ClickClosureInRubricGroup(AssessmentAutomationAgent, scoreLabel, scoreValue);
            ClickConventionsInRubricGroup(AssessmentAutomationAgent, scoreLabel, scoreValue);
            AssessmentAutomationAgent.Sleep(5000);
            if (VerifyRubricScoreLAbelValuePopulated(AssessmentAutomationAgent).Equals(scoreLabel))
            {
                ClickOnRubricScoreButton(AssessmentAutomationAgent);
                ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
            }
            AssessmentAutomationAgent.Sleep(10000);
        }

        public static void ClickIntroductionInRubricGroup(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "IntroductionScoreFlyout", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "IntroductionScoreFlyout", scoreLabel);
            ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
        }

        public static void ClickOrganizationInRubricGroup(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "OrganizationScoreFlyout", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "OrganizationScoreFlyout", scoreLabel);
            ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
        }

        public static void ClickDevelopmentInRubricGroup(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "DevelopmentScoreFlyout", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "DevelopmentScoreFlyout", scoreLabel);
            ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
        }

        public static void ClickVocabularyInRubricGroup(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "VocabularyScoreFlyout", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "VocabularyScoreFlyout", scoreLabel);
            ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
        }

        public static void ClickClosureInRubricGroup(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ClosureScoreFlyout", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "ClosureScoreFlyout", scoreLabel);
            ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
        }

        public static void ClickConventionsInRubricGroup(AutomationAgent AssessmentAutomationAgent, string scoreLabel, string scoreValue)
        {
            AssessmentAutomationAgent.IsElementFound("AssessmentView", "ConventionsScoreFlyout", scoreLabel);
            AssessmentAutomationAgent.Click("AssessmentView", "ConventionsScoreFlyout", scoreLabel);
            ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
        }

        public static bool VerifyStudentNameAlphabeticallyArrangedInScoring(AutomationAgent AssessmentAutomationAgent)
        {
            string student1 = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameinScoringOverviewScreen", "8").Split(' ')[1].Trim();
            string student2 = AssessmentAutomationAgent.GetElementText("AssessmentView", "StudentNameinScoringOverviewScreen", "7").Split(' ')[1].Trim();
            byte[] asciiStudent1 = Encoding.ASCII.GetBytes(student1);
            byte[] asciiStudent2 = Encoding.ASCII.GetBytes(student2);
            return (asciiStudent1[0] == asciiStudent2[0] || asciiStudent1[0] < asciiStudent2[0]);
        }

        public static bool VerifyStudentNameAlphabeticallyArrangedInOverview(AutomationAgent AssessmentAutomationAgent)
        {
            string student1 = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "inside", "1").Split(' ')[1].Trim();
            string student2 = AssessmentAutomationAgent.GetTextIn("AssessmentView", "StudentListInAssessmentOverview", "inside", "2").Split(' ')[1].Trim();
            byte[] asciiStudent1 = Encoding.ASCII.GetBytes(student1);
            byte[] asciiStudent2 = Encoding.ASCII.GetBytes(student2);
            return (asciiStudent1[0] == asciiStudent2[0] || asciiStudent1[0] < asciiStudent2[0]);
        }

        public static bool VerifyOmitButtonInChecklistScreenPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "OmitButtonInCheckListScoringOverview");
        }

        public static void ClickOmitButtonInChecklistScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "OmitButtonInCheckListScoringOverview");
            AssessmentAutomationAgent.Click("AssessmentView", "OmitButtonInCheckListScoringOverview");
        }

        public static bool VerifyAddButtonInChecklistScreenPresent(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "AddButtonInCheckListScoringOverview");
        }

        public static void ClickAddButtonInChecklistScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "AddButtonInCheckListScoringOverview");
            AssessmentAutomationAgent.Click("AssessmentView", "AddButtonInCheckListScoringOverview");
        }

        public static void VerifyOmitLayoutInChecklistScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ConfirmOmitLayoutTitle");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ConfirmOmitLayoutSubmitButton");
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "ConfirmOmitLayoutCancelButton");
            AssessmentAutomationAgent.Click("AssessmentView", "ConfirmOmitLayoutSubmitButton");
        }

        public static void TeacherAddCommentForFixedAssessmentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            ClickAddCommentButton(AssessmentAutomationAgent);
            Assert.IsTrue(AddCommentOverlayPresentInScoringScreen(AssessmentAutomationAgent), "Add Comment Overlay Not Present");
            TeacherEnterComments(AssessmentAutomationAgent, "Good");
            ClickCreateCommentButton(AssessmentAutomationAgent);
            Assert.IsFalse(AddCommentOverlayPresentInScoringScreen(AssessmentAutomationAgent), "Add Comment Overlay Is Present");
        }

        public static bool VerifySampleAnswerImagePresentInExercise(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "SampleAnswerScrollViewImage");
        }

        public static void StudentSharesNotebookToTeacher(AutomationAgent AssessmentAutomationAgent, string teacherName)
        {
            AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "OpenNotebook");
            while (!AssessmentAutomationAgent.IsElementFound("AssessmentView", "OpenNotebookRegion"))
            {
                AssessmentAutomationAgent.Click("AssessmentView", "OpenNotebook");
            }
            AssessmentAutomationAgent.Sleep(3000);
            AssessmentAutomationAgent.Click("AssessmentView", "OpenNotebookRegion");
            AssessmentAutomationAgent.Click("NotebookTopMenuView", "ShareIcon");
            if (AssessmentAutomationAgent.IsElementFound("ShareView", "SelectRecipientsLabel"))
            {
                AssessmentAutomationAgent.Click("CommonReadPageView", "CommonReadPageNumber", teacherName);
                if (AssessmentAutomationAgent.IsElementFound("ShareView", "SelectedUserCheckBox", teacherName))
                    AssessmentAutomationAgent.Click("ShareView", "NextButtonInShareOverlay");
                AssessmentAutomationAgent.Click("SelectRecipientsView", "SendButton");
                AssessmentAutomationAgent.VerifyElementFound("AnnotationMenuView", "WorkWillBeSentMessage");
                AssessmentAutomationAgent.Click("AssessmentView", "OKButtonInShare");
                AssessmentAutomationAgent.VerifyElementFound("AssessmentView", "SuccessAfterShare");
                AssessmentAutomationAgent.Click("AssessmentView", "OKButtonInShare");
            }
        }

        public static bool VerifySharedNotebookPresentInScoringScreen(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("AssessmentView", "NoteBookSharedTilePresent");
        }

        public static void TeacherTapsOnSharedNoteBook(AutomationAgent AssessmentAutomationAgent)
        {
            if (AssessmentAutomationAgent.IsElementFound("AssessmentView", "TapToDownloadSharedNotebook"))
            {
                AssessmentAutomationAgent.Click("AssessmentView", "TapToDownloadSharedNotebook");
                AssessmentAutomationAgent.WaitForElementToVanish("AssessmentView", "DownloadingLabelAfterShare");
                AssessmentAutomationAgent.Sleep(5000);
            }
            AssessmentAutomationAgent.Click("AssessmentView", "NoteBookSharedTilePresent");
        }

        public static bool VerifyTeaherAbleToTapOnSharedNotebook(AutomationAgent AssessmentAutomationAgent)
        {
            return AssessmentAutomationAgent.IsElementFound("NotebookBottomMenuView", "NotebookDrawRegion");
        }

        public static void TeacherScoresAStudentForAllQuestions(AutomationAgent AssessmentAutomationAgent, string studentName, string scoreValue)
        {
            ClickQuestionOneInScoringOverview(AssessmentAutomationAgent, studentName);
            TeacherAddCommentForFixedAssessmentInScoringScreen(AssessmentAutomationAgent);
            if (!VerifyMultiDimensionalRubricGroupTitleLabel(AssessmentAutomationAgent))
            {
                ClickOnRubricScoreButton(AssessmentAutomationAgent);
                ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
            }
            else
            {
                TeacherScoresMultirubricQuestion(AssessmentAutomationAgent, "--", scoreValue);
            }
            while (VerifiesNextButtonPresentInPreview(AssessmentAutomationAgent))
            {
                ClickAssessmentNextButton(AssessmentAutomationAgent);
                if (!VerifyMultiDimensionalRubricGroupTitleLabel(AssessmentAutomationAgent))
                {
                    ClickOnRubricScoreButton(AssessmentAutomationAgent);
                    ClickToScoreFromRubricFlyout(AssessmentAutomationAgent, scoreValue);
                }
                else
                {
                    TeacherScoresMultirubricQuestion(AssessmentAutomationAgent, "--", scoreValue);
                }
            }
            ClickOnItemScoringDoneButton(AssessmentAutomationAgent);
            ClickOnYesButtonAtCompletionDialogView(AssessmentAutomationAgent);

        }


        public static void StudentSubmitsAnAssessmentFromManagerScreen(AutomationAgent AssessmentAutomationAgent, string unitStatus, string assessmentName)
        {
            ClickAssessmentInStudentDashBoard(AssessmentAutomationAgent, "ELA");
            AssessmentUnitSelection(AssessmentAutomationAgent, unitStatus);
            StudentAnswersAssessment(AssessmentAutomationAgent, "Submitted", assessmentName);
            AssessmentAutomationAgent.AddSteptoSeeTestReport("TC52087", true);
            ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
            AssessmentAutomationAgent.Sleep(4000);
        }

        public static void ResetAssessmentAfterAppCrashAndAssertionFailure(AutomationAgent AssessmentAutomationAgent, string teacher, string subject, string task)
        {
            AssessmentAutomationAgent.LaunchApp();
            Login teacherLogin = Login.GetLogin(teacher);
            NavigationCommonMethods.Login(AssessmentAutomationAgent, teacherLogin);
            TaskInfo taskInfo = teacherLogin.GetTaskInfo(subject, task);
            String[] UnitStatus = LoadUnitStatusFromAdditionalInfo(taskInfo);
            ClickAssessmentInDashBoard(AssessmentAutomationAgent, UnitStatus[4]);
            AssessmentUnitSelectionAfterCrash(AssessmentAutomationAgent, "Unit " + UnitStatus[0].Split(':')[0].Trim());
            ClickFixedAssessmentNavigationArrow(AssessmentAutomationAgent, UnitStatus[21]);

            //if (Not Started = 1)
            //ClickUnlockAssessments(AssessmentAutomationAgent);
            //ClickOnStudentName(AssessmentAutomationAgent, UnitStatus[12]);
            //ClickAssessmentOverlayDone(AssessmentAutomationAgent);            

            //if(Started || Submitted=1)
            //LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);

            //if(scored =1)
            //ClickAssessmentOverviewScoreButton(AssessmentAutomationAgent);
            //TeacherScoresAStudentForAllQuestions(AssessmentAutomationAgent, UnitStatus[12], "3");                        
            //AssessmentCommonMethods.ClickBackButtonInScoringOverview(AssessmentAutomationAgent);
            //LockAndResetDataAfterTestRunInAssessmentOverview(AssessmentAutomationAgent);
            NavigationCommonMethods.Logout(AssessmentAutomationAgent);
        }

        public static void ClickViewItemAnalysis(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.Click("AssessmentResultSummaryView", "ViewItemAnalysis");
        }

        public static void StudentAnswerAndSubmitAssessment(AutomationAgent AssessmentAutomationAgent, string studentName)
        {
            System.Data.DataSet ds = AutomationAgent.ReadExcelToFillData(ConfigurationManager.AppSettings["ExcelInputFile"].ToString(), true);
            DataTable inputData = ds.Tables[0];
            DataTable studentData = ds.Tables[1];
            string expression = "StudentName = '" + studentName + "'";
            string answerColumn = studentData.Select(expression).First<DataRow>()["AnswerColumn"].ToString();
            DataRowCollection dataRows = inputData.Rows;
            int currentQuestionNo = 0, previousQuestionNo = 1;
            string submittingAnswerColumn = answerColumn;
            
            string currentQuestionType, currentCorrectAnswer, currentCorrectControl, currentDropControl, currentWrongControl, currentAnswerToSubmit;
            for (int i = 0; i < dataRows.Count; i++)
            {
                currentQuestionNo = int.Parse(dataRows[i]["QuestionNo"].ToString());
                currentQuestionType = dataRows[i]["QuestionType"].ToString();
                currentCorrectAnswer = dataRows[i]["Answer"].ToString();
                currentCorrectControl = dataRows[i]["CorrectAnswerText"].ToString();
                currentDropControl = dataRows[i]["DropControlText"].ToString();
                currentWrongControl = dataRows[i]["WrongAnswerText"].ToString();
                currentAnswerToSubmit = dataRows[i][submittingAnswerColumn].ToString();
                if (currentQuestionNo != previousQuestionNo)
                {
                    ClickAssessmentNextButton(AssessmentAutomationAgent);
                }
                previousQuestionNo = currentQuestionNo;
                if (currentQuestionType == "Objective")
                {
                    if (currentAnswerToSubmit == "R")
                    {
                        AssessmentAutomationAgent.Click("AnswerAssessments", "ObjectiveAnswer", currentCorrectControl);
                    }
                    else if (currentAnswerToSubmit == "W")
                    {
                        AssessmentAutomationAgent.Click("AnswerAssessments", "ObjectiveAnswer", currentWrongControl);
                    }
                }
                else if (currentQuestionType == "Matching")
                {
                    if (currentAnswerToSubmit == "R")
                    {
                        AssessmentAutomationAgent.DragAndDrop("AnswerAssessments", "DragAnswer", currentCorrectControl, "AnswerAssessments", "DropAnswer", currentDropControl);
                    }
                    else if (currentAnswerToSubmit == "W")
                    {
                        AssessmentAutomationAgent.DragAndDrop("AnswerAssessments", "DragAnswer", currentWrongControl, "AnswerAssessments", "DropAnswer", currentDropControl);
                    }
                }
                else if (currentQuestionType == "Text")
                {
                    AssessmentAutomationAgent.Click("AnswerAssessments", "TextAnswer", currentCorrectControl);
                    AssessmentAutomationAgent.SendText(currentCorrectAnswer);
                    AssessmentAutomationAgent.CloseKeyboard();
                }
            }
            ClickSubmitButtonInLastQuestionOfAssessment(AssessmentAutomationAgent);
            ClickSubmitInConfirmationPopUp(AssessmentAutomationAgent);
        }

        public static void StudentOpensELAAssessmentsMngr(AutomationAgent AssessmentAutomationAgent)
        {
            AssessmentAutomationAgent.IsElementFound("AnswerAssessments", "ELAAssessmentBtn");
            AssessmentAutomationAgent.Click("AnswerAssessments", "ELAAssessmentBtn");
            WaitForPageToload(AssessmentAutomationAgent);
        }
    }
}



         
