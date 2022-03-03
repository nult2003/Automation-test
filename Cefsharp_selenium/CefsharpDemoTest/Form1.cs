using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;

namespace CefsharpDemoTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_vidu1(object sender, EventArgs e)
        {
            Cef_trying3();
        }

        // not work
        private void Cef_trying1()
        {
            try
            {
                var options = new ChromeOptions();
                // cefclient.exe
                //options.BinaryLocation = @"D:\my studies\study\CefsharpDemo\cef_binary_98.2.0+g78c653a+chromium-98.0.4758.102_windows64_client\Release\cefclient.exe";
                options.BinaryLocation = @"C:\xProject\Study\Cefsharp_selenium\CefsharpDemo\bin\Debug\CefsharpDemo.exe";

                //options.AddArgument("--log-level=3");
                //options.AddArgument("--disable-extensions");
                options.DebuggerAddress = "localhost:55555";// not work
                var driver = new ChromeDriver(options); //chromedriver.exe

                driver.Navigate().GoToUrl("http://stackoverflow.com/");
                //driver.Manage().Window.Maximize();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // not work
        private void Cef_trying2()
        {
            try
            {
                var options = new ChromeOptions();
                // cefclient.exe
                //options.BinaryLocation = @"D:\my studies\study\CefsharpDemo\cef_binary_98.2.0+g78c653a+chromium-98.0.4758.102_windows64_client\Release\cefclient.exe";
                options.BinaryLocation = @"C:\xProject\Study\Cefsharp_selenium\CefsharpDemo\bin\Debug\CefsharpDemo.exe";
                
                //options.AddArgument("--log-level=3");
                //options.AddArgument("--disable-extensions");
                options.AddArgument("--remote-debugging-port=55555");// it works well
                var service = ChromeDriverService.CreateDefaultService();
                //service.HideCommandPromptWindow = true;                
                service.Port = 55555;
                var driver = new ChromeDriver(service, options); //chromedriver.exe

                driver.Navigate().GoToUrl("http://stackoverflow.com/");
                //driver.Manage().Window.Maximize();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // work well
        private void Cef_trying3()
        {
            try
            {
                var options = new ChromeOptions();
                // cefclient.exe
                //options.BinaryLocation = @"D:\my studies\study\CefsharpDemo\cef_binary_98.2.0+g78c653a+chromium-98.0.4758.102_windows64_client\Release\cefclient.exe";
                options.BinaryLocation = @"C:\xProject\Study\Cefsharp_selenium\CefsharpDemo\bin\Debug\CefsharpDemo.exe";

                //options.AddArgument("--log-level=3");
                //options.AddArgument("--disable-extensions");
                options.AddArgument("--remote-debugging-port=55555");// it works well
                var driver = new ChromeDriver(options); //chromedriver.exe

                driver.Navigate().GoToUrl("https://staging.ibwave-cloud.com/");
                //driver.Manage().Window.Maximize();
                driver.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
