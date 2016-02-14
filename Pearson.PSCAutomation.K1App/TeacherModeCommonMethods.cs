using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;

using System.Collections;

namespace Pearson.PSCAutomation.K1App
{

    public static class TeacherModeCommonMethods
    {
        /// <summary>
        /// verify that teacher mode is open.
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>return: true if expand button found</returns>
        public static bool VerifyTeacherModeOpen(AutomationAgent TeacherModeAutomationAgent)
        {
            if (TeacherModeAutomationAgent.IsElementFound("TeacherMode", "TeacherModeTopBar"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// verify that today shelf is open.
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTodayShelfOpen(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("UnitSelection", "TodayShelfScroll");
        }

        /// <summary>
        /// Verify that user is on the media library even though Teacher mode is open
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        public static void VerifyMediaLibraryOpenWithTeacherMode(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeTopBar");
            TeacherModeAutomationAgent.VerifyElementFound("MediaLibrary", "MedialibraryUnitTitle");
        }

        /// <summary>
        /// Get the Tecaher Mode bar Width
        /// </summary>
        /// <param name="UnitSelectionAutomationAgent">AutomationAgent object</param>
        /// <returns>return: Tecaher Mode bar width</returns>
        public static int GetTeacherModeBarWidth(AutomationAgent TeacherModeAutomationAgent)
        {
            string[] width = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "TeacherModeTopBar", "width");
            return (Int32.Parse(width[0]));
        }

        /// <summary>
        /// Verify that user is on the Unit Home Screeb even though Teacher mode is open
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyUserOnUnitHomeWithTeacherMode(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeTopBar");
            TeacherModeAutomationAgent.VerifyElementFound("UnitSelection", "TodayButton");
        }

        /// <summary>
        /// Verify Student Roster display in My Classroom and it scrollable 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>return: true if student roster is scrollable</returns>
        public static bool VerifyScrollableStudentRoster(AutomationAgent TeacherModeAutomationAgent)
        {
            string[] StudentName = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "StudentsInRoster", "accessibilityLabel");
            TeacherModeAutomationAgent.SwipeElement("TeacherMode", "TeacherModeStudentRoster", Direction.Left, 1000, 100);
            string[] StudentNameAfterScroll = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "StudentsInRoster", "accessibilityLabel");
            if (!StudentName.Equals(StudentNameAfterScroll))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify My Classroom bar display in Teacher Mode
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyMyClassRoster(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "MyClassRoster");
        }

        /// <summary>
        /// Wait For Name display in Roster
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void WaitForNameDisplayedInRoster(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.WaitForElementToVanish("TeacherMode", "StudentRosterInProgress");
            int tCount = 0;
            while (!TeacherModeAutomationAgent.IsElementFound("TeacherMode", "TeacherModeStudentRoster") && tCount <= 10)
            {
                TeacherModeAutomationAgent.WaitforElement("TeacherMode", "TeacherModeStudentRoster", "", WaitTime.MediumWaitTime);
                if (TeacherModeAutomationAgent.IsElementFound("TeacherMode", "TeacherModeStudentRoster"))
                {
                    break;
                }

                tCount++;
            }

        }

        /// <summary>
        /// Verify the student name is sorted by first name in student roster
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentNameSorting(AutomationAgent TeacherModeAutomationAgent)
        {
            int studentcount = TeacherModeAutomationAgent.GetElementCount("TeacherMode", "StudentsInRoster");
            string[] studentNames = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "StudentsInRoster", "accessibilityLabel");
            ArrayList getStudentsName = new ArrayList();
            for (int i = 0; i < studentcount; i++)
            {
                getStudentsName.Add(studentNames[i]);
            }

            getStudentsName.Sort();

            for (int i = 0; i < studentcount; i++)
            {
                getStudentsName[i].Equals(studentNames[i]);
            }
        }

        /// <summary>
        /// Verify the student roster retriever offline message
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if message found</returns>
        public static bool VerifyOfflineErrorMessage(AutomationAgent TeacherModeAutomationAgent)
        {
            string offlineMessage = TeacherModeAutomationAgent.GetTextIn("TeacherMode", "StudentsRosterOfflineMessage", "Inside", "");
            return offlineMessage.Contains("You must be connected to the internet to retrieve the class roster");
        }

        /// <summary>
        /// Verify Show password button display above of student name
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyShowPasswordButton(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "ShowPassword");
        }

        /// <summary>
        /// Verify followings items at Show password popup for already setup student:
        /// 1) Student first and last name
        /// 2) Picture Password: Color icon, Captain icon, Fruit icon 
        /// 3) Pop up is styled with standard red (X) in top left corner
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyShowPasswordPopupForSetupStudent(AutomationAgent TeacherModeAutomationAgent, Login login)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "StudentNameAtShowPassword", login.PersonName);
            TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
            TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "CircleColor", "9");
            TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "Fruits", "7");
            TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "Captain", "7");

        }

        /// <summary>
        /// Verify that if student does not have a Picture Password, pop-up displays message indicating that password is not set up: Message: The picture password for this student has not been set up.
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if no set up message displayed</returns>
        public static bool VerifyShowPasswordPopupForNonSetupStudent(AutomationAgent TeacherModeAutomationAgent)
        {
            int tCount = 0;
            while (TeacherModeAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon") && tCount <= 20)
            {
                TeacherModeAutomationAgent.Sleep(WaitTime.MediumWaitTime);
                if (!TeacherModeAutomationAgent.IsElementFound("StudentSetup", "InprogressIcon"))
                {
                    break;
                }
                tCount++;
            }
            string message = TeacherModeAutomationAgent.GetText("TEXT").Replace('\n', ' ');
            return message.Contains("The picture password for this student has not been set up.");
        }

        ///// <summary>
        ///// Verify that "Show Password pop-up" closes when the user taps anywhere on screen.
        ///// </summary>
        ///// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        //public static void VerifyShowPasswordPopupClosed(AutomationAgent TeacherModeAutomationAgent)
        //{
        //    TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
        //}

        /// <summary>
        /// Verify Unit overview is in active mode
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if unit overview is in active mode</returns>
        public static bool VerifyUnitOverView(AutomationAgent TeacherModeAutomationAgent,String unitNumber)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "UnitOverviewTitleInTeacherMode", unitNumber);
        }

        /// <summary>
        /// Verify Lesson overview is in active mode
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if Lesson overview is in active mode</returns>
        public static bool VerifyLessonOverView(AutomationAgent TeacherModeAutomationAgent,int lessonNumber)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "LessonOverviewTitle", lessonNumber.ToString());
        }

        /// <summary>
        /// Verify Lesson Guide is in active mode
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>true: if Lesson Guide bar is in active mode</returns>
        public static bool VerifyLessonGuide(AutomationAgent TeacherModeAutomationAgent)
        {
            string[] getHiddenProperty = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "TeacherOvervieTitle", "WEB", "", "hidden");
            return getHiddenProperty[0].Equals("false");
        }

        /// <summary>
        /// Verify that Lesson number selected from today shel matched with lesson number in right teacher panel
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <param name="selectedLesson">Selected Lesson Number</param>
        /// <returns>treu: if lesson number matched</returns>
        public static bool VerifyLessonNumberInTeacherMode(AutomationAgent TeacherModeAutomationAgent, int selectedLesson)
        {
            string lessonNoInRightPanel;
            
            if(selectedLesson<10)
                lessonNoInRightPanel = TeacherModeAutomationAgent.GetElementText("WEB", "TeacherMode", "LessonOnTeacherPanel", "").Substring(7,1);
            else
                lessonNoInRightPanel = TeacherModeAutomationAgent.GetElementText("WEB", "TeacherMode", "LessonOnTeacherPanel", "").Substring(7,2);

            return Int32.Parse(lessonNoInRightPanel).Equals(selectedLesson);
        }

        /// <summary>
        /// Verify below content when Teacher 
        /// 1. Unit Overview bar
        /// 2. About this Lesson bar
        /// 3. Lesson Guide bar
        /// 4. My Classroom
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherModeContent(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "UnitOverviewTitle", "", "WEB");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "LessonOverviewTitle", "", "WEB");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "TeacherOvervieTitle", "", "WEB");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "MyClassRoster");
        }
        /// <summary>
        /// Verify the notes area open in rectangular area when teacher mode open
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyNotesAreaOpenInWhiteRectangularArea(AutomationAgent TeacherModeAutomationAgent)
        {
            string width = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "NotesArea", "", "width")[0];
            string height = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "NotesArea", "", "height")[0];
            string color = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "NotesArea", "", "backgroundColor")[0];
            if (width != height && color.Equals("0xFFFFFF"))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verify the nores area below shrink app.
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object : true if found</returns>
        public static bool VerifyNotesAreaBelowShrinkApp(AutomationAgent TeacherModeAutomationAgent)
        {
            string YcoordinateofShrinkApp = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "ShrinkApp", "", "y")[0];
            string YcoordinateofNotesArea = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "NotesArea", "", "y")[0];
            if (Int32.Parse(YcoordinateofShrinkApp) < Int32.Parse(YcoordinateofNotesArea))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify the MyLessonNotes Button
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMyLessonNotesButton(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "MyLessonNotes");
        }
        /// <summary>
        /// Verify Mr Class Roster Button
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMyClassRosterButton(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "MyClassRoster");
        }
        /// <summary>
        /// Verify My Lesson Notes Button is the default tab opened
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMyLessonNotesButtonIsDefaultTabOpened(AutomationAgent TeacherModeAutomationAgent)
        {
            string message = (TeacherModeAutomationAgent.GetAllValues("TeacherMode", "MyLessonNotesMessage", "text")[0].Replace("\t\n", "").Replace("\n", ""));
            if (message.Equals("You can create your own notes for each task of any lesson.Just open a lesson and get started!"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click on the my class roster button
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnMyClassRosterButton(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "MyClassRoster");
        }
        /// <summary>
        /// verify that my class roster got selected and is bold
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMyClassRosterGetSelected(AutomationAgent TeacherModeAutomationAgent)
        {
            string[] widthbeforeselection = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "MyClassRosterLabel", "", "width");
            TeacherModeCommonMethods.ClickOnMyClassRosterButton(TeacherModeAutomationAgent);
            string[] widthafterselection = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "MyClassRosterLabel", "", "width");
            if (Int32.Parse(widthbeforeselection[1]) < Int32.Parse(widthafterselection[1]))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify that my lesson notes get selected and is bold
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyMyLessonNotesGetSelected(AutomationAgent TeacherModeAutomationAgent)
        {
            string[] widthbeforeselection = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "MyLessonNotesLabel", "", "width");
            TeacherModeCommonMethods.CLickOnMyLessonNotesButton(TeacherModeAutomationAgent);
            string[] widthafterselection = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "MyLessonNotesLabel", "", "width");
            if (Int32.Parse(widthbeforeselection[1]) < Int32.Parse(widthafterselection[1]))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click on the MY lesson Notes Button
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void CLickOnMyLessonNotesButton(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "MyLessonNotes");
        }
        /// <summary>
        /// Verify the message when no notes is available in the lesson notes area
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyMessageWhenNoNotesAvailable(AutomationAgent TeacherModeAutomationAgent)
        {
            int tCount = 0;
            while (TeacherModeAutomationAgent.IsElementFound("TeacherMode", "EditNotesButton") && tCount <= 20)
            {
                NavigationCommonMethods.ClickToGetNextLesson(TeacherModeAutomationAgent);
                tCount++;
            }
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "MessageToAddNotes");
        }
        /// <summary>
        /// Verify that my lesson notes button is disabled
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyMyLessonNotesButtonIsDisabled(AutomationAgent TeacherModeAutomationAgent)
        {
            string message = (TeacherModeAutomationAgent.GetAllValues("TeacherMode", "MyLessonNotesMessage", "text")[0].Replace("\t\n", "").Replace("\n", ""));
            if (message.Equals("You can create your own notes for each task of any lesson.Just open a lesson and get started!"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click on the black expand button 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeExpandButtonToExpandApp(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "TeacherModeExpandButton");
        }
        /// <summary>
        /// Click to add notes 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickToAddNotes(AutomationAgent TeacherModeAutomationAgent)
        {
            if (TeacherModeAutomationAgent.IsElementFound("TeacherMode", "EditNotesButton"))
            {
                TeacherModeAutomationAgent.Click("TeacherMode", "EditNotesButton");
                TeacherModeCommonMethods.ClickOnDeleteNoteButton(TeacherModeAutomationAgent);
            }
            TeacherModeAutomationAgent.Click("TeacherMode", "MessageToAddNotes");
        }
        /// <summary>
        /// verify add notes pop get close.
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAddNotePopUpClose(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("StudentSetup", "ErrorPopUpCloseIcon");
        }
        /// <summary>
        /// Click on the save button
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnSaveButton(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "SaveButton");
        }
        /// <summary>
        /// Verify notes are saved
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifySavedNotes(AutomationAgent TeacherModeAutomationAgent, string texttosave)
        {
            string savednotes = "null";
            if (TeacherModeAutomationAgent.IsElementFound("TeacherMode", "NotesTextView"))
            {
                savednotes = TeacherModeAutomationAgent.GetElementText("TeacherMode", "NotesTextView");
            }
            if (savednotes.Contains(texttosave))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Click on the cancel button in th e notes overlay
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnCancelButtonInNotesOverlay(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "CancelButton");
        }

        public static bool VerifySaveButtonActive(AutomationAgent TeacherModeAutomationAgent)
        {
            string[] enabledproperty = TeacherModeAutomationAgent.GetAllValues("TeacherMode", "SaveButton", "", "enabled");
            if (enabledproperty[0].Equals("true"))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Verify UI of CreateNote 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyCreateNotesUI(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "TextRegionInCreateNotes");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "AddYourNotesLabel");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "SaveButton");

        }
        /// <summary>
        /// Verify that notes available in My lesson notes 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyNotesAvailableInMyLessonNotes(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "MessageToAddNotes");
        }
        /// <summary>
        /// Click on the edit button when there is notes .
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnEditButton(AutomationAgent TeacherModeAutomationAgent)
        {
            if (TeacherModeAutomationAgent.IsElementFound("TeacherMode", "MessageToAddNotes"))
            {
                TeacherModeAutomationAgent.Click("TeacherMode", "MessageToAddNotes");
                TeacherModeCommonMethods.SendTextToAddNotes(TeacherModeAutomationAgent, " ");
                TeacherModeAutomationAgent.Click("TeacherMode", "SaveButton");
            }
            TeacherModeAutomationAgent.Click("TeacherMode", "EditNotesButton");
        }
        /// <summary>
        /// Verify the Edit Notes UI
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyEditNotesUI(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("StudentSetup", "ErrorPopUpCloseIcon");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "TextRegionInCreateNotes");
            TeacherModeAutomationAgent.VerifyElementFound("InboxView", "EditCommentOverlay");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "DoneButton");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "DeleteNoteButton");
        }
        /// <summary>
        /// Clicks on the delet note button
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDeleteNoteButton(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "DeleteNoteButton");
        }
        /// <summary>
        /// Verify the display of edit button when no notes available for the lesson 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyDisplayOfEditButton(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "EditNotesButton");
        }
        /// <summary>
        /// Verify Edit Note overlay open
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:true if found</returns>
        public static bool VerifyEditNoteOverlay(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "EditNoteLabel");
        }
        /// <summary>
        /// Verify that create notes overlay is display 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyCreateNoteOverlay(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "AddYourNotesLabel");
        }
        /// <summary>
        /// Verify Unit overview open in half view
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUnitOverViewOpenInHalfView(AutomationAgent CAadoptionAutomationAgent)
        {
            int widthexpandbar = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "TeacherModeTopBar", "width")[0]);
            int WidthOfNavigationBar = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);

            if ((widthexpandbar).Equals((WidthOfNavigationBar + widthexpandbar) / 2 - 136))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify elements in Teacher mode open view
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyElementsInTeacherModeOpen(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeExpandBar");
            CAadoptionAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeButtonOnExpandBar");
        }
        /// <summary>
        /// Verify unit number in unit overview
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitNumberInUnitOverview(AutomationAgent CAadoptionAutomationAgent)
        {
            string unitnumber = CAadoptionAutomationAgent.GetTextIn("TeacherMode", "UnitNumber", "Inside", "", "WEB", 0, 0).Replace("\n", "").Replace("\t", "");
            if (unitnumber.Contains("UNIT 1"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify teacher mode close button at the lower left of the unit over view screen
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTeacherModeCLoseButtonAtlowerleft(AutomationAgent CAadoptionAutomationAgent)
        {
            int heightUnitOverViewDiv = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "UnitOverViewDiv", "height")[0]);

            int heightclosebutton = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "TeacherModeExpandButton", "height")[0]);
            int YCoordinate = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "TeacherModeExpandButton", "y")[0]);

            
            if (((heightUnitOverViewDiv / 2)-((YCoordinate - heightclosebutton))) < 50
                || ((heightUnitOverViewDiv / 2) - ((YCoordinate - heightclosebutton))) > 50)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verify unit overview content in shrunk view
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUnitOverviewContentOpenInShrunk(AutomationAgent CAadoptionAutomationAgent)
        {
            int widthexpandbar = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "TeacherModeTopBar", "width")[0]);
            int WidthOfNavigationBar = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);

            if ((widthexpandbar).Equals((WidthOfNavigationBar + widthexpandbar) / 2 - 136))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify elements when teacher mode open in full view mode
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyElementsInTeacherModeOpenInFullView(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeExpandBar");
            CAadoptionAutomationAgent.VerifyElementFound("TeacherMode", "TeacherModeButtonOnExpandBar");
        }
        /// <summary>
        /// Verify that the expand button direction changes.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyExpandButtonDirectionChanges(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("TeacherMode", "OpenExpandButtonImage");
        }
        /// <summary>
        /// Verify Message when Lesson note viewed 
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMessageWhenLessonNotViewed(AutomationAgent CAadoptionAutomationAgent)
        {
            string message = (CAadoptionAutomationAgent.GetAllValues("TeacherMode", "MyLessonNotesMessage", "text")[0].Replace("\t\n", "").Replace("\n", ""));
            if (message.Equals("You can create your own notes for each task of any lesson.Just open a lesson and get started!"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify app full screen view
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyAppFullscreenView(AutomationAgent CAadoptionAutomationAgent)
        {
            int WidthOfNavigationBar = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("UnitSelection", "NavigationBar", "width")[0]);
            if (WidthOfNavigationBar.Equals(2048))
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verify lesson guide active
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <return>bool object: true if found</return>
        public static bool VerifyLessonOverviewActive(AutomationAgent CAadoptionAutomationAgent)
        {
            string hiddenproperty = CAadoptionAutomationAgent.GetAllValues("TeacherMode", "AboutThisLesson", "hidden")[0];
            if (hiddenproperty.Equals("true"))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Click on the unit overview
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnUnitOverview(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Click("TeacherMode", "UnitOverview");
        }

        /// <summary>
        /// Verify Edit note button displayed
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyEditNoteButton(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "EditNotesButton");
        }

        /// <summary>
        /// Verify saved notes is scrollable if exceed 
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <param name="text">Array</param>
        /// <returns>True: if scrollable </returns>
        public static bool VerifySavedNotesIsScrollable(AutomationAgent TeacherModeAutomationAgent, string text)
        {
            TeacherModeAutomationAgent.Swipe(Direction.Down, 100, 500);
            return (TeacherModeCommonMethods.VerifySavedNotes(TeacherModeAutomationAgent, text));
        }
        /// <summary>
        /// Verify teacher guide flyout panel
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyTeacherGuideFlyOutPanel(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.IsElementFound("TeacherMode", "TeacherGuideFlyOut");
        }
        /// <summary>
        /// Verify collapse button right
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyCollapseButtonOnRight(AutomationAgent CAadoptionAutomationAgent)
        {
            int x = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "CollapseButton", "x")[0]);
            if (x < 2048 && x > 1900)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Click to close the teacher guide panel
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickToCloseTeacherGuidePanel(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Click("TeacherMode", "CollapseButton");
        }
        /// <summary>
        /// Verify the unit overview content when open in the full screen
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitOverviewContent(AutomationAgent CAadoptionAutomationAgent)
        {
            int XHeadercoordinate = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "OverviewSubHeader", "x")[0]);
            int XSupportingText = Int32.Parse(CAadoptionAutomationAgent.GetAllValues("TeacherMode", "SupportText", "x")[0]);

            if (XHeadercoordinate < XSupportingText)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify that unit overview content scrollable when open in full screen.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static bool VerifyUnitOverviewContentScrollable(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Swipe(Direction.Down);
            string text = CAadoptionAutomationAgent.GetText("TEXT");

            if (text.Contains("Author"))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Verify that My lesson notes hidden
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object true: if matched</returns>
        public static bool VerifyMyLessonNotesHidden(AutomationAgent CAadoptionAutomationAgent)
        {
            string TopProperty = CAadoptionAutomationAgent.GetAllValues("TeacherMode", "MyLessonNotes", "top")[0];
            if (TopProperty.Equals("false"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Get the lesson content 
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>string object</returns>
        public static string GetTheLessonContent(AutomationAgent CAadoptionAutomationAgent)
        {
            string text = CAadoptionAutomationAgent.GetTextIn("TeacherMode", "WebLessonOverview", "Down", "");
            return text;
        }
        /// <summary>
        /// Click on teacher guide buttton when teacher guide panel is open.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnTeacherModeWhenTeacherGuideOpen(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Click("TeacherMode", "TeacherGuideButton");

        }
        /// <summary>
        /// Click on the lesson overview button
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLessonOverview(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Click("TeacherMode", "LessonOverviewButton");
        }
        /// <summary>
        /// Click on the lesson guide button.
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void ClickOnLessonGuide(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.Click("TeacherMode", "LessonGuide");
        }
        /// <summary>
        /// Verify lesson guide open
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found </returns>
        public static bool VerifyLessonGuideOpen(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.IsElementFound("TeacherMode", "LessonGuide");
        }
        /// <summary>
        /// Verify graphic organizer in todays shelf
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found </returns>
        public static bool VerifyGraphicOrganizerInTodayShelf(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "GraphicOrganizer", "", "Right");
        }
        /// <summary>
        /// Verify Glossary in todays shelf
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found </returns>
        public static bool VerifyGlossaryInTodayShelf(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "Glossary", "", "Right");
        }
        /// <summary>
        /// Verify Table of content in todays shelf
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found </returns>
        public static bool VerifyTableOfContentsInTodayShelf(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "TableOfContents", "", "Right");
        }
        /// <summary>
        /// Verify Standard charts in todays shelf
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found </returns>
        public static bool VerifyStandardChartsInTodayShelf(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "StandardCharts", "", "Right");
        }
        /// <summary>
        /// Verify Reviewer video in todays shelf
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found </returns>
        public static bool VerifyReviewerVideoInTodayShelf(AutomationAgent CAadoptionAutomationAgent)
        {
            return CAadoptionAutomationAgent.ElementSwipeWhileNotFound("UnitSelection", "TodayShelfScroll", "UnitSelection", "ReviewerVideo", "", "Right");
        }

        /// <summary>
        /// use to write text
        /// </summary>
        /// <param name="bookBuilderAutomatinAgent">AutomationAgent object</param>
        /// <param name="value">string object:name to be written</param>
        public static void SendTextToAddNotes(AutomationAgent bookBuilderAutomatinAgent, string value)
        {
            if (bookBuilderAutomatinAgent.IsElementFound("TeacherMode", "DeleteNoteButton"))
            {
                bookBuilderAutomatinAgent.Click("TeacherMode", "DeleteNoteButton");
                bookBuilderAutomatinAgent.Click("TeacherMode", "MessageToAddNotes");
            }

            bookBuilderAutomatinAgent.SetText("TeacherMode", "TextRegionInCreateNotes", "");
            bookBuilderAutomatinAgent.Click("TeacherMode", "TextRegionInCreateNotes", 2, WaitTime.DefaultWaitTime);
            bookBuilderAutomatinAgent.SendText("{BKSP}");
            bookBuilderAutomatinAgent.SendText(value);
        }

        /// <summary>
        /// Verify unformatted text inside the edit note overlay
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyUnformattedTextInTheBoxAndIsScrollable(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.SendText("Tester\n");

            for (int i = 0; i <= 10; i++)
            {
                TeacherModeAutomationAgent.SendText("!@#$%\n");

            }
            TeacherModeAutomationAgent.SwipeElement("TeacherMode", "TextRegionInCreateNotes", Direction.Up, 200, 2000);

            string notes = TeacherModeAutomationAgent.GetText("TEXT");

            if (notes.Contains("Tester"))
                return true;
            else
                return false;

        }


        /// <summary>
        /// Verify My class roster Background colors, fonts and sizes
        /// </summary>
        /// <param name="CAadoptionAutomationAgent">AutomationAgent object</param>
        public static void VerifyMyClassRosterUI(AutomationAgent CAadoptionAutomationAgent)
        {
            CAadoptionAutomationAgent.VerifyElementFound("TeacherMode", "MyRosterClassUI");
        }

        /// <summary>
        /// Verify Teacher mode flyout menu options
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyTeacherModeFlyOutMenu(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "TeacherGuideFlyOut");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "UnitOverviewTitle");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "LessonOverviewButton");
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "LessonGuide");
        }
        /// <summary>
        /// Click on student in the my class roster
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void ClickOnStudent(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "StudentAaron");
        }
        public static void ClickOnNonSetUpStudent(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.Click("TeacherMode", "NonSetUpStudent");
        }
        /// <summary>
        /// Verify My Class Roster Open.
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static bool VerifyMyClassRosterOpen(AutomationAgent TeacherModeAutomationAgent)
        {
            return TeacherModeAutomationAgent.IsElementFound("TeacherMode", "TeacherModeStudentRoster");
        }
        /// <summary>
        /// Verify no roster message
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyNoRosterMessage(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "NoRosterMessage");
        }
        /// <summary>
        /// Verify Student Name And Avatar
        /// </summary>
        /// <param name="TeacherModeAutomationAgent">AutomationAgent object</param>
        public static void VerifyStudentNameAndAvatar(AutomationAgent TeacherModeAutomationAgent)
        {
            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "StudentAaron");

            TeacherModeAutomationAgent.VerifyElementFound("TeacherMode", "StudentAvatar");
        }

        /// <summary>
        /// Click on student avatar from student roster
        /// </summary>
        /// <param name="LoginAutomationAgent">AutomationAgent object</param>
        /// <param name="index">index</param>
        public static void ClickOnStudentAvatar(AutomationAgent LoginAutomationAgent, int index)
        {
        }
    }
}


