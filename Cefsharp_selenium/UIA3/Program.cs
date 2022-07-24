using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIA3
{
    class Program
    {
        static void Main(string[] args)
        {
            //var msApplication = Application.Launch(@"C:\xProject\Study\Automation-test\Cefsharp_selenium\CefsharpDemo\bin\Debug\cefsharpdemo.exe");
            var msApplication = Application.Attach(@"C:\xProject\Study\Automation-test\Cefsharp_selenium\CefsharpDemo\bin\Debug\cefsharpdemo.exe");
            var automation = new UIA3Automation();
            var mainWindow = msApplication.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var btn = mainWindow.FindFirstDescendant(cf.ByName("BIM"))?.AsButton();
            btn?.Invoke();
            //Mouse.LeftClick(point);
        }
    }
}
