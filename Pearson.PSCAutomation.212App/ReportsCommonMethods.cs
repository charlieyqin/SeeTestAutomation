using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Data;
using System.Xml;
using System.Text.RegularExpressions;
using System.Configuration;
namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class ReportsCommonMethods
    {

        public static bool VerifyStudentTileColor(AutomationAgent AssessmentAutomationAgent, string studentNo, string color)
        {
            if (color == "Red")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "StudentTileRed", studentNo);
            }
            else if (color == "Green")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "StudentTileGreen", studentNo);
            }
            else if (color == "Yellow")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "StudentTileYellow", studentNo);
            }
            else if (color == "Gray")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "StudentTileGray", studentNo);
            }
            else
                return false;
        }

        public static bool VerifyOverAllAssessmentTileColorAndText(AutomationAgent AssessmentAutomationAgent, string overallText)
        {
            if (overallText == "At Risk")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "OverallProficiencyAtRisk");
            }
            else if (overallText == "Proficient")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "OverallProficiencyProficient");
            }
            else if (overallText == "Not Proficient")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "OverallProficiencyProficient");
            }
            else
                return false;
        }

        public static bool VerifyStudentName(AutomationAgent AssessmentAutomationAgent, string studentNo, string studentName)
        {
            string firstName = AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "StudentFirstName", studentNo);
            string lastName = AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "StudentLastName", studentNo);
            return (firstName + " " + lastName) == studentName;
        }

        public static bool VerifyStudentProficiencyText(AutomationAgent AssessmentAutomationAgent, string studentNo, string studentProficiency)
        {
            string proficiency = AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "StudentProficiency", studentNo);
            return studentProficiency == proficiency.Trim();
        }

        public static bool VerifyTabSelected(AutomationAgent AssessmentAutomationAgent, string tabName)
        {
            if (tabName == "All Students")
            {
                return AssessmentAutomationAgent.IsElementFound("AssessmentItemAnalysisView", "AllStudentsTabActive");
            }
            else
                return false;
        }

        public static bool VerifyGroupWidePercentageValues(AutomationAgent AssessmentAutomationAgent, List<string> groupWidePercentageValues)
        {
            for (int i = 0; i < groupWidePercentageValues.Count; i++)
            {
                if (AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "GroupWidePercentCorrect", (i + 1).ToString()) != groupWidePercentageValues[i] + "%")
                    return false;
            }
            return true;
        }

        public static bool VerifyPrimarySkillIDValues(AutomationAgent AssessmentAutomationAgent, List<string> primarySkillIDValues)
        {
            for (int i = 0; i < primarySkillIDValues.Count; i++)
            {
                if (AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "PrimarySkillID", (i + 1).ToString()) != primarySkillIDValues[i])
                    return false;
            }
            return true;
        }

        public static bool VerifyPointValues(AutomationAgent AssessmentAutomationAgent, List<string> pointValues)
        {
            for (int i = 0; i < pointValues.Count; i++)
            {
                if (AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "PointValue", (i + 1).ToString()) != pointValues[i])
                    return false;
            }
            return true;
        }

        public static bool VerifyCorrectValues(AutomationAgent AssessmentAutomationAgent, List<string> correctValues)
        {
            for (int i = 0; i < correctValues.Count; i++)
            {
                if (AssessmentAutomationAgent.GetElementText("AssessmentItemAnalysisView", "CorrectValue", (i + 1).ToString()) != correctValues[i])
                    return false;
            }
            return true;
        }


        public static void VerifyItemAnalysisReport(AutomationAgent AssessmentAutomationAgent, int submittedStudents)
        {
            System.Data.DataSet ds1 = AutomationAgent.ReadExcelToFillData(ConfigurationManager.AppSettings["ExcelInputFile"].ToString(), true);
            DataTable studentData = ds1.Tables[1];
            DataRowCollection dataRows = studentData.Rows;

            for (int i = 0; i < submittedStudents; i++)
            {
                Assert.IsTrue(VerifyStudentTileColor(AssessmentAutomationAgent, dataRows[i][0].ToString(), dataRows[i][3].ToString()), "Student Tile color is not " + dataRows[i][3].ToString());
                Assert.IsTrue(VerifyStudentName(AssessmentAutomationAgent, dataRows[i][0].ToString(), dataRows[i][1].ToString()), "Student Name didn't match");
                Assert.IsTrue(VerifyStudentProficiencyText(AssessmentAutomationAgent, dataRows[i][0].ToString(), dataRows[i][2].ToString()), "Student Proficiency didn't match");
            }
            for (int i = submittedStudents; i < dataRows.Count; i++)
            {
                Assert.IsTrue(VerifyStudentTileColor(AssessmentAutomationAgent, dataRows[i][0].ToString(), "Gray"), "Student Tile color is not Gray");
                Assert.IsTrue(VerifyStudentName(AssessmentAutomationAgent, dataRows[i][0].ToString(), dataRows[i][1].ToString()), "Student Name didn't match");
                Assert.IsTrue(VerifyStudentProficiencyText(AssessmentAutomationAgent, dataRows[i][0].ToString(), "Missing"), "Student Proficiency is not missing");

            }
                        
            Assert.IsTrue(VerifyTabSelected(AssessmentAutomationAgent, "All Students"), "All Students is not the selected Tab");

            DataTable inputData = ds1.Tables[0];
            DataRowCollection inputRows = inputData.Rows;
            int currentQuestionNo = 0, previousQuestionNo = 0;
            List<string> groupWidePercentageValues = new List<string>(), primarySkillIDValues = new List<string>(), pointValues = new List<string>(), correctValues = new List<string>();
            for (int i = 0; i < inputRows.Count; i++)
            {
                currentQuestionNo = int.Parse(inputRows[i]["QuestionNo"].ToString());
                if (currentQuestionNo != previousQuestionNo)
                {
                    groupWidePercentageValues.Add(inputRows[i]["GroupPercentage"+submittedStudents.ToString()].ToString());
                    primarySkillIDValues.Add(inputRows[i]["PrimarySkillId"].ToString());
                    pointValues.Add(inputRows[i]["AppPointValue"].ToString());
                    correctValues.Add(inputRows[i]["CorrectValue"].ToString());
                }
                previousQuestionNo = currentQuestionNo;
            }

            Assert.IsTrue(VerifyGroupWidePercentageValues(AssessmentAutomationAgent, groupWidePercentageValues), "Group wide percentage values didn't match");
            Assert.IsTrue(VerifyPrimarySkillIDValues(AssessmentAutomationAgent, primarySkillIDValues), "Primary Skill ID values didn't match");
            Assert.IsTrue(VerifyPointValues(AssessmentAutomationAgent, pointValues), "Point values didn't match");
            Assert.IsTrue(VerifyCorrectValues(AssessmentAutomationAgent, correctValues), "Correct values didn't match");
        }
    }

}

