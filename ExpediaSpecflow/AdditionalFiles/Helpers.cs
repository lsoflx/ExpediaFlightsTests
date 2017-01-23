using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ExpediaSpecflow
{
    class Helpers
    {
        private IWebDriver driver;
        private PopupWindowFinder PopUpWF = new PopupWindowFinder(WebBrowser.Current);

        public Helpers(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Selects option from drop menu
        public void SelectFromDropMenu(IWebElement element, string input)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(input);
        }

        //Combines sleep and implicit wait
        public void WaitImplicit(int sleep, int implicitly = 5)
        {
            Thread.Sleep(sleep);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitly));
        }
     
        public void WaitForVisible(By locator, int timeSpanSeconds = 10, int sleep = 1000)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpanSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            Thread.Sleep(sleep);
        }

        public void WaitForClickable(By locator, int timeSpanSeconds = 20, int sleep = 1000)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpanSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            Thread.Sleep(sleep);
        }

        //Exports text in file
        public void AppendTextToFile(string file, string text)
        {
            File.AppendAllText((AppDomain.CurrentDomain.BaseDirectory) + @"\" + file, (text + "\r\n"));
        }

        //Try to click button catching NoSuchElementException
        public void TryClick(IWebElement tryel, IWebElement catchel = null)
        {
            try
            {
                tryel.Click();
            }
            catch (NoSuchElementException)
            {
                if (catchel != null)                   
                    catchel.Click();
            }
        }

        public void TrySendKeys(IWebElement tryel, string value, IWebElement catchel = null)
        {
            try
            {
                tryel.SendKeys(value);
            }
            catch (NoSuchElementException)
            {
                if (catchel != null)
                    catchel.Click();
            }
        }

        public void JSExecutor(string script)
        {
            var executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript(script);
        }

        public object JSExecutorReturn(string script)
        {
            var executor = driver as IJavaScriptExecutor;
            return executor.ExecuteScript(script);
        }

        //Stores imported csv file from given path in constant dictionary
        public void ImportFileWithCityAirportsForCheckTickets(string path)
        {
            Global.cityAirportCodesDict = ImportCsv(path);
        }

        //Stores imported csv file in constant dictionary
        public void ImportFileWithCityAirportsForCheckTickets()
        {
            Global.cityAirportCodesDict = ImportCsv(AppDomain.CurrentDomain.BaseDirectory + @"\\AirportCodes.csv");
        }

        //Parses through csv file on given path into dictionary
        private Dictionary<string, string> ImportCsv(string path)
        {
            //Declares variable dict for dictionary
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //Reads all lines in file on given path and store it in variable
            string[] text = File.ReadAllLines(path);
            //Splits fist line for getting number of columns
            string[] textSplit = text[0].Split(new string[] { "," }, StringSplitOptions.None);
            //Loops through columns 
            for (int i = 0; i < textSplit[0].Length; i++)
            {
                //Adds kyes into dictionary from first row
                dict.Add(textSplit[i], null);
                //Loops htrough rows
                for (int k = 1; k < text.Length; k++)
                {
                    //Splits rows
                    string[] textSplitNext = text[k].Split(new string[] { "," }, StringSplitOptions.None);
                    //Stores in key of dictionary all belonging items in rows into one string
                    dict[textSplit[i]] += textSplitNext[i] + ", ";
                }
                //Removes ", " at the end of value string 
                dict[textSplit[i]] = dict[textSplit[i]].Remove(dict[textSplit[i]].Length - 2);
            }
            return dict;
        }

        //Converts date to MM/dd/yyyy
        public string DateConvertToMMddyyyy(string date, string inputdate)
        {
            string year = DateTime.Parse(inputdate).Year.ToString();
            DateTime result = new DateTime();
            if (date.Contains(year))
            {
                DateTime.TryParse(date, out result);
            }
            else
            {
                DateTime.TryParse(date + " " + year, out result);
            }
            return result.ToString("MM/dd/yyyy");
        }

        //Gets the result amount of adults and children tickets on SearchResult/TravelerInfo/Payment page
        public int GetAdultsChildren(IList<IWebElement> locator)
        {
            //Declares adluts and children lists
            List<string> adults = new List<string>();
            List<string> children = new List<string>();
            //Loops through every element in given locator
            foreach (IWebElement element in locator)
            {
                if (element.Text.Contains("Adult"))
                {
                    //Adds to adults list text from locator if contains 'Adults'
                    adults.Add(element.Text);
                }
                if (element.Text.Contains("Child"))
                {
                    // Adds to children list text from locator if contains 'Child'
                    children.Add(element.Text);
                }
            }
            //Returns integer of whole amount of tickets
            return adults.Count + children.Count;
        }

        //Switch to pop up by clicking on button
        public void SwitchToPopUpOnClick(IWebElement button)
        {
            driver.SwitchTo().Window(PopUpWF.Click(button));
        }

        public void HighlightAndDeleteAllTextInWebelemnt(IWebElement element)
        {
            element.Click();
            element.SendKeys(Keys.Control + "a" + Keys.Control);
            element.SendKeys(Keys.Delete);
        }
    }
}
