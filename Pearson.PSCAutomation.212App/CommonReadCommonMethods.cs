using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    public static class CommonReadCommonMethods
    {
        /// <summary>
        /// Opens Common Read from Lesson View
        /// Click on Common Read division in Lesson View
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void OpenCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("LessonView", "CommonReadEreader");
            commonReadAutomationAgent.Sleep();
        }

        /// <summary>
        /// Toggles Vellum mode in Common Read
        /// Clicks on Vellum mode icon [available on right hand] in Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ToggleVellumMode(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumMode");
        }

        /// <summary>
        /// Closes common read 
        /// Clicks "Done" button available on left top corner of Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickOnDoneButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadTopMenuView", "DoneButton");
        }

        /// <summary>
        /// Opens annotation in edit mode in Common Read
        /// Clicks on gist annotation sticky in Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickOnGistAnnotationsSideLabel(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadPageView", "GistAnnotationsSticky");
        }

        /// <summary>
        /// Creates new annotation using given text to be annotated in Common Read
        /// 1. Searches and Long click on text given as parameter [textToAnnotate]
        /// 2. Clicks on Annotate contextual menu
        /// 3. Sends text to annotation [annotationText]
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="annotationType">Type of Annotation to be created</param>
        /// <param name="textToAnnotate">text to be annotated</param>
        /// <param name="annotationText">annotation text to be entered</param>
        public static void CreateAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string textToAnnotate, string annotationText)
        {
            commonReadAutomationAgent.WaitforElement("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate, WaitTime.SmallWaitTime);
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
            commonReadAutomationAgent.Sleep(4000);
            if (!commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"))
            {
                NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                commonReadAutomationAgent.Sleep(4000);
            }
            if (commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"))
            {
                commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
            }
            if(commonReadAutomationAgent.IsElementFound("CommonReadAnnotationsPanelView", "DeleteButton"))
            {
                ClickDeleteButton(commonReadAutomationAgent);
                ClickContinueButton(commonReadAutomationAgent);
                NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                commonReadAutomationAgent.Sleep(4000);
                if (!commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"))
                {
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                    commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                    commonReadAutomationAgent.Sleep(4000);
                }
                commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
            }
            commonReadAutomationAgent.Sleep();
            if (commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "ExistingAnnotatioinMessage"))  
            {
                ClickOkButton(commonReadAutomationAgent);
                if (commonReadAutomationAgent.IsElementFound("CommonReadAnnotationsPanelView", "DeleteButton"))
                {
                    ClickDeleteButton(commonReadAutomationAgent);
                    ClickContinueButton(commonReadAutomationAgent);
                }
                else
                {
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                    commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                    if (!commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"))
                    {
                        NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                        commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                        commonReadAutomationAgent.Sleep(4000);
                    }
                    DeleteHighlightFromCommonRead(commonReadAutomationAgent);
                }
                NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                commonReadAutomationAgent.Sleep(4000);
                if (!commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"))
                {
                    NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                    commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                    commonReadAutomationAgent.Sleep(4000);
                }
                commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
                commonReadAutomationAgent.Sleep();
            }
            commonReadAutomationAgent.SendText(annotationText);
        }

        public static void ClickAnnotateDoneButton(AutomationAgent commonReadAutomationAgent) 
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsView", "DoneAnnotate");
        }
        /// <summary>
        /// Retrieves annotation contextual menu in Common Read
        /// Searches and Long click on text given as parameter [textToAnnotate]
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="annotationType">Type of Annotation to be created</param>
        /// <param name="textToAnnotate">text to be annotated</param>
        public static void GetAnnotationMenu(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string textToAnnotate)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
            commonReadAutomationAgent.Sleep(4000);
            if (!commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"))
            {
                NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
                commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
                commonReadAutomationAgent.Sleep(4000);
            }
        }

        public static void ZoomCommonRead(AutomationAgent commonReadAutomationAgent, string wordToZoom)
        {
            CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
            commonReadAutomationAgent.Sleep();
            CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
            commonReadAutomationAgent.Click("CommonReadAnnotationsView", "TextToAnnotate", wordToZoom, 2, WaitTime.DefaultWaitTime);
            commonReadAutomationAgent.Sleep();
        }

        /// <summary>
        /// Retrieves the width of "Copy" contextual menu in Common Read
        /// Retrieves 'width' attribute of Copy contextual menu
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: width of Copy button</returns>
        public static string GetCopyButtonWidth(AutomationAgent commonReadAutomationAgent)
        {
            string[] values = commonReadAutomationAgent.GetAllValues("CommonReadContextMenuView", "Copy", "width");
            return values[0];
        }

        /// <summary>
        /// Selects an already existing annotation using the word which is annotated in Common Read
        /// Searches and clicks on already annotated text given as parameter [textToAnnotate]
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="annotationType">Type of Annotation to be created</param>
        /// <param name="textToAnnotate">text to be annotated</param>
        public static void SelectAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string textToAnnotate)
        {
            commonReadAutomationAgent.WaitforElement("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate, WaitTime.SmallWaitTime);
            commonReadAutomationAgent.Click("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
        }

        /// <summary>
        /// Deletes annotation in Common Read
        /// Cicks on Delete button
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickDeleteButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "DeleteButton");
        }

        /// <summary>
        /// Edits an annotation in Common Read
        /// Cicks on Edit button available to annotation frame
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickEditButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "EditButton");
            commonReadAutomationAgent.Sleep();
        }

        /// <summary>
        /// Verifies if Edit and Delete button
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>true if both eidt and delete icon present</returns>
        public static bool VerifyEditAndDeleteButton(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadAnnotationsPanelView", "DeleteButton") && commonReadAutomationAgent.IsElementFound("CommonReadAnnotationsPanelView", "EditButton");
        }

        /// <summary>
        /// Clicks annotation link in Common Read
        /// Clicks on Annotate contextual menu
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnAnnotationLink(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
        }

        /// <summary>
        /// Annotates the text in Common Read
        /// LongClicks on text 'CourteousImage' word to annotate
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnTextToAnnotate(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.LongClick("CommonReadAnnotationsView", "CourteousImage");
        }

        /// <summary>
        /// Clicks highlighted text in Common Read
        /// LongClicks on highlighted text 'CourteousImage'
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnHighlightedAnnotate(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.LongClick("CommonReadAnnotationsView", "HighlightCourteous");
        }

        /// <summary>
        /// Shares the annotation in Common Read
        /// 1. Clicks on Share Annotaion button
        /// </summary>
        /// <param name="annotationAutomationAgent"></param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnShareAnnotateButton(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadAnnotationsView", "ShareAnnotation");
        }

        /// <summary>
        /// Shares notebook from task top menu
        /// Clicks on Shared Work Icon in task top menu
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnSharedWorkIcon(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("TasksTopMenuView", "SharedWorkIcon");
        }

        /// <summary>
        /// Identifies the latest shared annotation in Common Read
        /// Clicks on 'Zainab Haver sent you annotations for' shared annotation
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnShareAnnotateAsReceiver(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("ReceivedWorkView", "LatestAnnotationShare");
        }

        /// <summary>
        /// Downloads shared annotation in Coomon Read
        /// Clicks on Download annotation label
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickToDownloadNewAnnotationAsReceiver(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("ReceivedWorkView", "DownloadAnnotation");
        }

        /// <summary>
        /// Downloads shared annotation in Coomon Read
        /// Clicks on Download annotation label
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnAnnotationAsReceiver(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("ReceivedWorkView", "DownloadAnnotation");
        }

        /// <summary>
        /// Opens shared annotation in Common Read
        /// Clicks on shared annotation button
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void ClickOnSharedByAnnotation(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadPageView", "SharedAnnotation");
        }

        /// <summary>
        /// Verifies shared annotation found in Common Read
        /// Verifies shared annotation text found
        /// </summary>
        /// <param name="annotationAutomationAgent">AutomationAgent object</param>
        /// <author>Isha Jain(isha.jain)</author>
        public static void VerifySharedAnnotationTextFound(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.VerifyElementFound("CommonReadPageView", "SharedTextAnnotation");
        }

        /// <summary>
        /// Verifies Gist sticky found in Common Read
        /// Verifies gist sticky image found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void VerifyGistAnnotationStickyExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.WaitforElement("CommonReadPageView", "GistAnnotationsSticky", "", WaitTime.SmallWaitTime);
            commonReadAutomationAgent.VerifyElementFound("CommonReadPageView", "GistAnnotationsSticky");
        }

        /// <summary>
        /// Verifies Gist sticky not found in Common Read
        /// Verifies gist sticky image not found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static void VerifyGistAnnotationStickyNotExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Sleep(2000);
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadPageView", "GistAnnotationsSticky");
        }

        /// <summary>
        /// Moves to previous page in Common read
        /// Clicks on left arrow in Common read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void ClickOnLeftArrow(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContentView", "LeftArrow");
        }

        /// <summary>
        /// Moves to next page in Common read
        /// Clicks on right arrow in Common read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void ClickOnRightArrow(AutomationAgent commonReadAutomationAgent)
        {
            if (commonReadAutomationAgent.IsElementFound("CommonReadContentView", "RightArrow"))
            {
                commonReadAutomationAgent.Click("CommonReadContentView", "RightArrow");
            }
        }

        /// <summary>
        /// Verifies left and right navigation don't exist when Common Read is zoomed out
        /// 1. Verifies left arrow is hidden
        /// 2. Verifies right arrow is hidden
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if navigation doesn't exist</returns>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static bool VerifyLeftRightNavigationNotExist(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadContentView", "LeftArrow") && commonReadAutomationAgent.IsElementFound("CommonReadContentView", "RightArrow");
        }

        /// <summary>
        /// Verifies first page of Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if left navigation doesn't exist</returns>
        public static bool VerifyFirstPageOfCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadContentView", "LeftArrow");
        }

        /// <summary>
        /// Verifies timestamp exists in Common Read
        /// Verifies timestamp lable found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="dateTime">dateTime to be verified</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void VerifyTimeStamp(AutomationAgent commonReadAutomationAgent, string dateTime)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "TimeStampLabel", dateTime);
        }

        /// <summary>
        /// Verifies annotation text found in Common Read
        /// Verifies Annotation text is available in text control
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="enteredText">enteredText to be verified</param>
        public static void VerifyAnnotationTextFound(AutomationAgent commonReadAutomationAgent, string enteredText)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsView", "AnnotationsTextEntered", enteredText);
        }

        /// <summary>
        /// Verify annotation delete popup appears
        /// 1. Verifies annotation message dialog
        /// 2. Verifies Cancel button found on dialog
        /// 3. Verifies Continue button found in dialog
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void VerifyDeleteAnnotationPopUpDisplayed(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "AnnotationMessageDialog");
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "CancelButton");
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "ContinueButton");
        }

        /// <summary>
        /// Confirms delete annotation in Common Read
        /// Click on Continue button of annotation dialog
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickContinueButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "ContinueButton");
            commonReadAutomationAgent.Sleep();
        }

        /// <summary>
        /// Clear all contents in Vellum Mode
        /// Clicks on Clear All button in Vellum mode in Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickClearAllButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumModeClearAll");
        }

        /// <summary>
        /// Opens Clear All button in Vellum mode in Common read
        /// Click on clear (x) icon which opens clear all button in Common read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickClearButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumModeClear");
        }

        /// <summary>
        /// Verifies Clear All button in Vellum Mode
        /// Verifies Clear All button image exist in Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void VerifyClearAllButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "VellumModeClearAll");
        }

        /// <summary>
        /// Draws a diamond image in Common Read
        /// Draws a diamond image of length 100 using given x/y coordinates
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="startingX1">left most x coordinate of diamond image</param>
        /// <param name="startingY1">left most y coordinate of diamond image</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void DrawDiamondImage(AutomationAgent commonReadAutomationAgent, int startingX1, int startingY1)
        {
            commonReadAutomationAgent.DrawDiamondImage(startingX1, startingY1);
        }

        /// <summary>
        /// Verifies diamond drawing exists in Common Read
        /// Verifies diaming image exists in common read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void VerifyDiamondImageExistsInCR(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "DiamondImageDrawnInCR");
        }

        /// <summary>
        /// Verifies diamond drawing doesn't exist in Common Read
        /// Verifies diaming image doesn't exist in common read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void VerifyDiamondImageNotExistsInCR(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadSideMenuView", "DiamondImageDrawnInCR");
        }

        /// <summary>
        /// Verifies that contextual menu appears on long click
        /// 1. Verifies Copy menu item found
        /// 2. Verifies Define menu item found
        /// 3. Verifies Highlight menu item found
        /// 4. Verifies Annotate menu item found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="textToAnnotate">text to be annotated</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void VerifyAnnotationContextualMenu(AutomationAgent commonReadAutomationAgent, string textToAnnotate)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
            commonReadAutomationAgent.Sleep(3000);
            commonReadAutomationAgent.VerifyElementFound("CommonReadContextMenuView", "Copy");
            commonReadAutomationAgent.VerifyElementFound("CommonReadContextMenuView", "Define");
            commonReadAutomationAgent.VerifyElementFound("CommonReadContextMenuView", "Highlight");
            commonReadAutomationAgent.VerifyElementFound("CommonReadContextMenuView", "AnnotateButton");
        }

        /// <summary>
        /// Verifies the annotation panel splits window in two halfs
        /// Retrieves width of complete window
        /// Retrieves width of Annotation window
        /// Verifies Annotation Window should be half of complete window
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if Annotation Window is half of complete window</returns>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static bool VerifyAnnotationSplitsCRWindow(AutomationAgent commonReadAutomationAgent)
        {
            int crWindowSize = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadContextMenuView", "CommonReadWebView", "width")[0]);
            int annotationWindowSize = 0;
            if (commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotationView"))
            {
                annotationWindowSize = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadContextMenuView", "AnnotationView", "width")[0]);
            }
            int annotationWindowX = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadContextMenuView", "AnnotationView", "x")[0]);
            return (annotationWindowSize * 2 == crWindowSize) && (annotationWindowX >= crWindowSize / 2) ? true : false;
        }

        /// <summary>
        /// Toggles Annotation layer
        /// Clicks on annotation [A] toggle button
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickAnnotationsLayerToggleButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
        }

        /// <summary>
        /// Verifies annotation off message
        /// Clicks on annotation [A] toggle button
        /// Verifies annotation off message
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Mohammed Saquib(mohammed.saquib)</author> 
        public static void VerifyAnnotationsOffMessage(AutomationAgent commonReadAutomationAgent)
        {
            Assert.AreEqual<string>("Highlight & Annotation Layer:", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerMessage", "text", 10));
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            Assert.AreEqual<string>("OFF", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerOff", "text", 10));
        }

        /// <summary>
        /// Verifies annotation On message
        /// Clicks on annotation [A] toggle button
        /// Verifies annotation On message
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void VerifyAnnotationsOnMessage(AutomationAgent commonReadAutomationAgent)
        {
            Assert.AreEqual<string>("Highlight & Annotation Layer:", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerMessage", "text", 10));
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            Assert.AreEqual<string>("ON", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerOn", "text", 10));
        }

        /// <summary>
        /// Verifies if Vellum clear button exist
        /// Verifies Vellum mode clear button exist
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void VerifyVellumModeButtonExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "VellumModeTools");
        }

        /// <summary>
        /// Clicks on already annotated text to open annotation panel
        /// Clicks on text which is already right annotated and annotation panel appears
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="annotatedText">text to be annotated</param>
        public static void ClickOnAnnotatedText(AutomationAgent commonReadAutomationAgent, string annotatedText)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsView", "TextToAnnotate", annotatedText);
            commonReadAutomationAgent.Sleep();
        }

        /// <summary>
        /// Appends text to already existing annotation
        /// Sends text to annotation panel to append in already existing annotation
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="addedText">text to be appended</param>
        public static void AppendToAnnotationText(AutomationAgent commonReadAutomationAgent, string addedText)
        {
            commonReadAutomationAgent.SendText(addedText);
        }

        /// <summary>
        /// Verifies already saved annotation
        /// Verifies saved text exists in panel
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="savedText">saved annotation text</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void VerifyAnnotationTextSaved(AutomationAgent commonReadAutomationAgent, string savedText)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsView", "AnnotationsTextSaved", savedText);
        }

        /// <summary>
        /// Copy text from Common read using Copy contextual menu
        /// Clicks on Copy contextual menu
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void ClickCopyButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "Copy");
        }

        /// <summary>
        /// Close existing annotation message
        /// Clicks on Ok button to close existing annotation message
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void ClickOkButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "OkButton");
        }

        /// <summary>
        /// Verifies existing annotation message
        /// Verifies existing annotation message dialog found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static bool VerifyExistingAnnotationMessage(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Sleep();
            return commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "ExistingAnnotatioinMessage");
        }

        /// <summary>
        /// Clicks on Highlight contextual menu
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static void ClickHighlightButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "Highlight");
        }

        /// <summary>
        /// Verifies annotation text is highlighted in blue
        /// Retrieves the element enable property for Selection View element
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>string object: enabled</returns>
        public static string CheckSelectionView(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.GetElementProperty("CommonReadContentView", "SelectionView", "enabled");
        }

        /// <summary>
        /// Retrieves position of annotation menu in Common Read to verify zoom in
        /// Retrieves x/y coordinates of Annotate contextual menu
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>stribg object: position of Annotate menu</returns>
        public static string GetPositionOfAnnotateMenu(AutomationAgent commonReadAutomationAgent)
        {
            string positions = commonReadAutomationAgent.GetPosition("CommonReadContextMenuView", "AnnotateButton");
            return positions;
        }

        /// <summary>
        /// Retrieves page number in Common Read
        /// Retrieve text of page number element in Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>string page number</returns>
        public static string GetCommonReadPageNumber(AutomationAgent commonReadAutomationAgent, string pageNumber)
        {
            if (commonReadAutomationAgent.IsElementFound("CommonReadPageView", "CommonReadPageNumber", pageNumber))
            {
                return pageNumber;
            }
            return null;
        }

        /// <summary>
        /// Verifies that when video is added in the notebook that the blue water mark is there or not
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true if water mark is there</returns>
        /// <author>Namrita Agarwal(namrita.agarwal)</author> 
        public static bool VerifyVideoWaterMark(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("LessonBrowserView", "VideoPlayButtonWaterMark");
        }
        /// <summary>
        /// Clicks on the paste button in common read 
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void ClickPasteButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "Paste");
        }
        /// <summary>
        /// Verifies page no. exists in the middle of the screen by
        /// 1.taking the position and width of the page no. 
        /// 2. and equalizing it with the width if annotationwindow size.
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true if the condition satisfies</returns>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static bool VerifyPageNumberExistsInTheMiddleOfPage(AutomationAgent commonReadAutomationAgent)
        {

            int WidthNavigationBar = NotebookCommonMethods.GetWidthOfNavigationBar(commonReadAutomationAgent);
            int widthpagenumber = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadPageView", "CommonReadPageNumber", "width")[0]);
            int pagenumberposition = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadPageView", "CommonReadPageNumber", "x")[0]);
            return WidthNavigationBar / 2 == pagenumberposition + (widthpagenumber) / 2 ? true : false;
        }
        /// <summary>
        /// Verifies that the contextual menu exist or not when vellum mode is On.
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void VerifyAnnotationContextualMenuNotPresent(AutomationAgent commonReadAutomationAgent)
        {
            Assert.AreEqual<bool>(false, commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "Copy"));
            Assert.AreEqual<bool>(false, commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "Define"));
            Assert.AreEqual<bool>(false, commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "Highlight"));
            Assert.AreEqual<bool>(false, commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "AnnotateButton"));
        }

        public static void ConfirmDeleteAnnotation(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("PopUpView", "ContinueAnnotationButton");
        }

        public static void CancelDeleteAnnotation(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("PopUpView", "CancelAnnotationButton");
        }
        /// <summary>
        /// Verifies the state of the vellum button if it is in pressed state or not 
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <author>Namrita Agarwal(namrita.agarwal)</author>
        public static void VerifyVellumButtonState(AutomationAgent commonReadAutomationAgent)
        {
            if (commonReadAutomationAgent.WaitForElement("CommonReadSideMenuView", "VellumModePenTool", WaitTime.SmallWaitTime))
            {
                commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "VellumModeSelected");
            }
            else
            {
                commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "VellumMode");
            }
        }
        /// <summary>
        /// verifies that delete highlight button exist when the word is already highlighted
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object:false if word is highlighted</returns>
        /// <author>Mohammed Saquib(mohammed.saquib)</author>
        public static bool VerifyDeleteHighlightButtonExist(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "DeleteHighlightButton");
        }
        /// <summary>
        /// Clicks on cancel button on edit annotation screen
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickCancelOnEditAnnotation(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "CancelButton");
        }
        /// <summary>
        /// Moves to first page of Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void MoveToFirstPageInCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            while (commonReadAutomationAgent.IsElementFound("CommonReadContentView", "LeftArrow"))
            {
                commonReadAutomationAgent.Click("CommonReadContentView", "LeftArrow");
                commonReadAutomationAgent.Sleep();
            }
        }
        /// <summary>
        /// Verifies Common Read page number
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if page number is same</returns>
        public static bool VerifyPageNumber(AutomationAgent commonReadAutomationAgent, string pageNumber)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadPageView", "CommonReadPageNumber", pageNumber);
        }
        /// <summary>
        /// Verifies 
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Button found), false(if button not found)</returns>
        public static bool VerifyCommonReadButton(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("LessonView", "EreaderDiv");
        }

        /// <summary>
        /// Deletes an existing highlight from Common Read
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void DeleteHighlightFromCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            if (commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "DeleteHighlightButton"))
            {
                commonReadAutomationAgent.Click("CommonReadContextMenuView", "DeleteHighlightButton");
            }
            NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
        }

        /// <summary>
        /// Verifies certain items in Common Read screen
        /// 1. Full screen: Verifies width of Common Read by adding x coordinate of toggle button to its width
        /// 2. Access to Notebook and Global Navigation
        /// 3. Goes back to lesson [where eReader div is present] using Done button
        /// </summary>
        /// <param name="commonReadAutomationAgent"></param>
        public static void VerifyCommonReadScreen(AutomationAgent commonReadAutomationAgent)
        {
            int crWindowSize = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadContextMenuView", "CommonReadWebView", "width")[0]);
            int xOfAnnotationToggleButton = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadSideMenuView", "AnnotationButton", "x")[0]);
            int widthOfAnnotationToggleButton = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadSideMenuView", "AnnotationButton", "width")[0]);
            Assert.AreEqual<int>(xOfAnnotationToggleButton + widthOfAnnotationToggleButton, crWindowSize);
            commonReadAutomationAgent.VerifyElementFound("TasksTopMenuView", "NotebookIcon");
            commonReadAutomationAgent.VerifyElementFound("TasksTopMenuView", "ToolsIcon");
            commonReadAutomationAgent.Click("CommonReadTopMenuView", "DoneButton");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.IsElementFound("LessonView", "EreaderDiv");
        }

        /// <summary>
        /// Verifies if annotation layer button is selected
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if Annotation layer button is selected</returns>
        public static bool VerifyAnnotationLayerOn(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadSideMenuView", "AnnotationLayerOn");
        }

        /// <summary>
        /// Verifies if annotation layer button isn't selected
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if Annotation layer button isn't selected</returns>
        public static bool VerifyAnnotationLayerOff(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadSideMenuView", "AnnotationLayerOff");
        }

        /// <summary>
        /// Verifies if keyboard is present on UI
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if keyboard is present</returns>
        public static bool VerifyKeyboardPresence(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("KeyboardView", "KeyBoardPresenceElement");
        }

        /// <summary>
        /// Verifies if the background of Annotation window is blue in color
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <returns>bool object: true if background is blue</returns>
        public static bool VerifyBlueBackGroundOfAnnotationScreen(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadPageView", "BlueBackground", "1");
        }

        /// <summary>
        /// Changes AnnotationType and filter annotation by type
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        /// <param name="annotationType">AnnotationType object</param>
        public static void ChangeAndFilterAnnotationType(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType)
        {
            ClickEditButton(commonReadAutomationAgent);
            commonReadAutomationAgent.Click("CommonReadPageView", "EditAnnotationType");
            commonReadAutomationAgent.Click("CommonReadPageView", "ChangeAnnotationType");
            commonReadAutomationAgent.Sleep(4000);
            commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
            commonReadAutomationAgent.Sleep(4000);
            commonReadAutomationAgent.VerifyElementFound("CommonReadPageView", "NotificationAvtar");
            commonReadAutomationAgent.Click("CommonReadPageView", "AnnotationType", "1", 1, WaitTime.DefaultWaitTime);
            commonReadAutomationAgent.Sleep();
            Assert.IsFalse(commonReadAutomationAgent.IsElementFound("CommonReadPageView", "NotificationAvtar"), "Avtar still found");
            commonReadAutomationAgent.Click("CommonReadPageView", "AnnotationType", "1", 1, WaitTime.DefaultWaitTime);
            commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
        }
        /// <summary>
        /// Clicks on the share button present in the Annotation menu view 
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickAnnotationShareButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("AnnotationMenuView", "AnnotationShareButton");
            commonReadAutomationAgent.Sleep();
        }
        /// <summary>
        /// Clicks on Send button
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickSend(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("AnnotationMenuView", "AnnotationSendButton");
        }
        /// <summary>
        /// Clicks on Shared Annotations button in Annotation Menu
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickSharedAnnotations(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("AnnotationMenuView", "SharedAnnotationsButton");
        }
        /// <summary>
        /// Clicks on sender named Bruce
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickOnBruceSender(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("AnnotationMenuView", "StudentBruce");
        }
        /// <summary>
        /// Clicks on View My Annotations Button In Common Read Page
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void ClickViewMyAnnotations(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadPageView", "ViewMyAnnotationsButton");
        }

        /// <summary>
        /// Verifies highlighted word is found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static bool VerifyHighlightedWord(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.IsElementFound("CommonReadPageView", "CommonReadHighlightedText");
        }

        /// <summary>
        /// Verifies highlighted word is not found
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void VerifyHighlightedWordNotFound(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadPageView", "CommonReadHighlightedText");
        }

        /// <summary>
        /// Copies text in Common read and keep that in clipboard
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static void CopyTextFromCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "Copy");
        }

        public static bool DragDotIconAndVerify(AutomationAgent commonReadAutomationAgent)
        {
            int xOfLeftDotBeforeDrag = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadSideMenuView", "LeftDragDotIcon", "x")[0]);
            int xOfRightDotBeforeDrag = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadSideMenuView", "RightDragDotIcon", "x")[0]);
            commonReadAutomationAgent.DragElement("CommonReadSideMenuView", "LeftDragDotIcon", -15, 0);
            commonReadAutomationAgent.DragElement("CommonReadSideMenuView", "RightDragDotIcon", 15, 0);
            int xOfLeftDotAfterDrag = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadSideMenuView", "LeftDragDotIcon", "x")[0]);
            int xOfRightDotAfterDrag = Int32.Parse(commonReadAutomationAgent.GetAllValues("CommonReadSideMenuView", "RightDragDotIcon", "x")[0]);
            return (xOfLeftDotBeforeDrag > xOfLeftDotAfterDrag && xOfRightDotBeforeDrag < xOfRightDotAfterDrag);
        }

        // <summary>
        /// Try to create Annotations while user Selected SharedAnnotation
        /// </summary>
        /// <param name="commonReadAutomationAgent">AutomationAgent object</param>
        public static bool CreateAnnotationWhileSharedAnnoation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string textToAnnotate, string annotationText)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
            commonReadAutomationAgent.Sleep(3000);
            commonReadAutomationAgent.VerifyElementFound("ShareView", "AnnotationButton");
            return true;
        }

        public static bool VerifyHighlightExistsOrAnnotation(AutomationAgent commonReadAutomationAgent)
        {
            bool exists = false;
            if(commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "DeleteHighlightButton")) 
            {
                exists = true;
                NotebookCommonMethods.TapOnScreen(commonReadAutomationAgent, 200, 200, 1);
            }
            if (commonReadAutomationAgent.IsElementFound("CommonReadContextMenuView", "ExistingAnnotatioinMessage"))
            {
                exists = true;
                ClickOkButton(commonReadAutomationAgent);
            }
            return exists;
        }
    }

    public enum AnnotationType
    {
        Gist,
        NewThinking,
        NewWord,
        Other
    }
}
