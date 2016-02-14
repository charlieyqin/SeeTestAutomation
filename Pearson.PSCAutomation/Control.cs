using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pearson.PSCAutomation.Framework
{
    public class Control
    {
        private string zone;
        private string element;
        private string controlName;
        private int index;
        private string controlType;
        private string controlText;
        private int xcoordinate;
        private int ycoordinate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="element"></param>
        /// <param name="controlName"></param>
        /// <param name="controlType"></param>
        /// <param name="controlText"></param>
        /// <param name="xcoordinate"></param>
        /// <param name="ycoordinate"></param>
        /// <param name="index"></param>
        public Control(string zone, string element, string controlName, string controlType, string controlText, int xcoordinate, int ycoordinate, int index=0)
        {
            this.zone = zone;
            this.element = element;
            this.controlName = controlName;
            this.controlType = controlType;
            this.controlText = controlText;
            this.xcoordinate = xcoordinate;
            this.ycoordinate = ycoordinate;
            this.index = index;
        }

        public Control(XElement controlXElement)
        {
            this.zone = controlXElement.Element("Zone").Value;
            this.element = controlXElement.Element("Element").Value;
            this.controlName = controlXElement.Attribute("ControlName").ToString();
            this.controlType = controlXElement.Element("ControlType").Value;
            this.controlText = controlXElement.Element("ControlText").Value;
            this.index = int.Parse(controlXElement.Element("Index").Value);
            this.xcoordinate = controlXElement.Element("XCoordinate") != null ? int.Parse(controlXElement.Element("XCoordinate").Value) : 0;
            this.ycoordinate = controlXElement.Element("YCoordinate") != null ? int.Parse(controlXElement.Element("YCoordinate").Value) : 0;
        }
        public string Zone
        {
            get
            {
                return zone;
            }
        }
        public string Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }
        public string ControlName
        {
            get
            {
                return controlName;
            }
        }
        public string ControlType
        {
            get
            {
                return controlType;
            }
        }
        public string ControlText
        {
            get
            {
                return controlText;
            }
            set
            {
                controlText = value;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
        }
        public int XCoordinate
        {
            get
            {
                return xcoordinate;
            }
        }
        public int YCoordinate
        {
            get
            {
                return ycoordinate;
            }
        }

    }
}
