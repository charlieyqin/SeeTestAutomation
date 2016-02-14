using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel1 = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Pearson.PSCAutomation.Framework
{
    public static class ReadContentMethods
    {
       
        static Excel1.Application xlApp;
        static Excel1.Workbook xlWorkBook;
        static Excel1.Worksheet xlWorkSheet;
        static Excel1.Range range;

        public static Excel1.Range ReadExcel(string filePath, int workSheetNumber)
        {
            try
            {
                string startupPath = System.IO.Directory.GetCurrentDirectory();
                string outPutDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                string xmlfilepath = Path.Combine(outPutDirectory + filePath);
                string xmlfile_path = new Uri(xmlfilepath).LocalPath;
                xlApp = new Excel1.Application();
                xlWorkBook = xlApp.Workbooks.Open(xmlfile_path, 0, false, 5, "", "", true, Excel1.XlPlatform.xlWindows, "\t", true, false, 0, true, true, false);
                xlWorkSheet = (Excel1.Worksheet)xlWorkBook.Worksheets.get_Item(workSheetNumber);
                return range = xlWorkSheet.UsedRange;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ReleaseExcelObjects()
        {
            try
            {
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception)
            {

            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            finally
            {
                obj = null;
            }
        }

    }
}
