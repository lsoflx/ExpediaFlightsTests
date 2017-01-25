using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;
using NUnit.Framework.Interfaces;
using static NUnit.Framework.TestContext;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using System.IO;

namespace ExpediaSpecflow
{
    [Binding]
    public static class WebBrowser
    {
        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    Process pr = new Process();
                    pr.Refresh();

                    //string browser = Environment.GetEnvironmentVariable("Browser").ToLower().Replace(" ", "");
                    string browser = ConfigurationManager.AppSettings["Browser"].ToLower().Replace(" ", "");
                    switch (browser)
                    {
                        case "internetexplorer":
                        case "ie":
                            var options = new InternetExplorerOptions();
                            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                            options.IgnoreZoomLevel = true;
                            ScenarioContext.Current["browser"] = new InternetExplorerDriver();
                            break;
                        case "firefox":
                        case "ff":
                            ScenarioContext.Current["browser"] = new FirefoxDriver();
                            break;
                        case "chrome":
                        case "cr":
                            ChromeOptions optionsChrome = new ChromeOptions();
                            optionsChrome.AddArgument("--start-maximized");
                            ScenarioContext.Current["browser"] = new ChromeDriver(optionsChrome);
                            break;
                        case "phantomjs":
                        case "pjs":
                            ScenarioContext.Current["browser"] = new PhantomJSDriver();
                            break;
                        default:
                            ScenarioContext.Current["browser"] = new FirefoxDriver(); 
                            break;
                    }
                }
                return (IWebDriver)ScenarioContext.Current["browser"];
            }
        }   
          
        [AfterScenario]        
        public static void SnapshotOnFailure()
        {
            if (CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Regex testNamePattern = new Regex(@"\((.*?)\)");
                string testName = testNamePattern.Replace(CurrentContext.Test.Name, "");
                FileInfo creatDir = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + testName + "\\ScreenShots\\");
                creatDir.Directory.Create();
                Regex clearPathPattern = new Regex("[:+|\"+|\r+|\n+|>+|<+|\0+|\t+|\\+|{+|}+|]+|[+|/+]");
                string dateTime = DateTime.Now.ToString("MM-dd-yyyy, HH-mm-ss");
                string outComeMessage = clearPathPattern.Replace(CurrentContext.Result.Message, "");                                            
                string fullPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + testName + "\\ScreenShots\\" + "\\(" + dateTime + ")" + outComeMessage;
                string pathTrimed = fullPath.Substring(0, Math.Min(fullPath.Length, 240));
                Current.TakeScreenshot().SaveAsFile(pathTrimed + ".png", ImageFormat.Png);
            }
        }
        
        [AfterScenario]        
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
            {
                Current.Dispose();
            }
        }

        [AfterScenario]
        public static void KillWebdriverProccess()
        {
            Thread.Sleep(1000);
            string[] drivers = {"geckodriver", "chromedriver", "IEDriverServer", "phantomjs"};
            foreach (string driver in drivers)
            {
                foreach (var process in Process.GetProcessesByName(driver))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (InvalidOperationException) { }
                }
            }
        }
    }
}
