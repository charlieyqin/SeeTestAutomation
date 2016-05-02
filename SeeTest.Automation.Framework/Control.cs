using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeeTest.Automation.Framework
{
    public class Control
    {
        public string Zone { get; private set; }
        public string Element { get; private set; }
        public string ControlName { get; private set; }
        public string ControlType { get; private set; }
        public string ControlText { get; private set; }
        public int Index { get; private set; }

        public Control(string zone, string element, string controlName, string controlText, string controlType, int index = 0)
        {
            this.Zone = zone;
            this.Element = element;
            this.ControlType = controlType;
            this.ControlName = controlName;
            this.ControlText = controlText;
            this.Index = index;
        }
        
        public Control(string zone, string element, string controlName, string controlText, string controlType, int index = 0, params string[] dynamicVariable)
        {
            this.Zone = zone;
            this.Element = string.Format(element, dynamicVariable);
            this.ControlType = controlType;
            this.ControlName = controlName;
            this.ControlText = controlText;
            this.Index = index;
        }
    }
}
