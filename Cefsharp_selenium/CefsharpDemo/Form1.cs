using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefsharpDemo
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
            //InitCef();
        }

        private void InitCef()
        {
            CefSettings settings = new CefSettings();
            settings.RemoteDebuggingPort = 9222;
            settings.UserDataPath = "C:/Temp";
            Cef.Initialize(settings);
            var browserControl = new ChromiumWebBrowser("chrome://version");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var settings = new CefSettings();
            settings.CefCommandLineArgs.Add("enable-npapi", "1");
            settings.IgnoreCertificateErrors = true;
            settings.RemoteDebuggingPort = 55555;
            
            //settings.CefCommandLineArgs.Add("enable-system-flash", "1");
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("https://google.com.vn");        
            browser.Dock = DockStyle.Fill;
            browser.MenuHandler = new SearchContextMenuHandler();
            this.Controls.Add(browser);
        }
    }
    public class SearchContextMenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
            model.AddItem(CefMenuCommand.Back, "Go Back");
            model.AddItem(CefMenuCommand.Reload, "Reload");
            model.AddItem(CefMenuCommand.ReloadNoCache, "Reload (No Cache)");
            model.AddItem(CefMenuCommand.Print, "Open DevTools");
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters,
            CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if (commandId == CefMenuCommand.Reload)
            {
                browser.Reload();
                return true;
            }
            if (commandId == CefMenuCommand.ReloadNoCache)
            {
                browser.Reload(true);
                return true;
            }
            if (commandId == CefMenuCommand.Print)
            {
                CefSharp.WebBrowserExtensions.ShowDevTools(browser);
                return true;
            }
            if (commandId == CefMenuCommand.Back)
            {
                browser.GoBack();
                return true;
            }

            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
