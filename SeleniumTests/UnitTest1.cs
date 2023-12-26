using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private string webAppUri;

        [TestInitialize] // Run before each unit test
        public void Setup()
        {
            // Read URL from SeleniumTest.runsettings (configure run settings)
            // this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();

            this.webAppUri = "http://localhost:53135/";
        }

        [TestMethod]
        public void TestPreHighBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("120");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("60");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            IWebElement resultDisplay = driver.FindElement(By.CssSelector("#form1 div:nth-child(4)"));

            // Get the text from the result display
            string resultText = resultDisplay.Text.Trim();

            Debug.WriteLine(resultText);
            // Assert the result
            Assert.AreEqual("Pre-High Blood Pressure", resultText, "Blood pressure category is not as expected");
       
            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }

        [TestMethod]
        public void TestHighBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("170");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("60");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            IWebElement resultDisplay = driver.FindElement(By.CssSelector("#form1 div:nth-child(4)"));

            // Get the text from the result display
            string resultText = resultDisplay.Text.Trim();

            Debug.WriteLine(resultText);
            // Assert the result
            Assert.AreEqual("High Blood Pressure", resultText, "Blood pressure category is not as expected");

            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }

        [TestMethod]
        public void TestIdealBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("119");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("79");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            IWebElement resultDisplay = driver.FindElement(By.CssSelector("#form1 div:nth-child(4)"));

            // Get the text from the result display
            string resultText = resultDisplay.Text.Trim();

            Debug.WriteLine(resultText);
            // Assert the result
            Assert.AreEqual("Ideal Blood Pressure", resultText, "Blood pressure category is not as expected");

            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }

        [TestMethod]
        public void TestLowBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("70");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("50");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            IWebElement resultDisplay = driver.FindElement(By.CssSelector("#form1 div:nth-child(4)"));

            // Get the text from the result display
            string resultText = resultDisplay.Text.Trim();

            Debug.WriteLine(resultText);
            // Assert the result
            Assert.AreEqual("Low Blood Pressure", resultText, "Blood pressure category is not as expected");

            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }

        [TestMethod]
        public void TestLowSystolicAlwaysGreaterThanDiastolicBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("70");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("80");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement validationSummary = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".text-danger.validation-summary-errors")));


            // Capture and print the text of the element
            string errorMessage = validationSummary.Text;

       
            Assert.AreEqual("Systolic must be greater than Diastolic", errorMessage, "Blood pressure category is not as expected");

            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }

        [TestMethod]
        public void TestInvalidSystolicValueBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("50");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("80");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            By elementSelector = By.CssSelector(".text-danger.field-validation-error #BP_Systolic-error");
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(elementSelector));


            // Capture and print the text of the element
            string errorMessage = element.Text;


            Assert.AreEqual("Invalid Systolic Value", errorMessage, "Blood pressure category is not as expected");

            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }

        [TestMethod]
        public void TestInvalidDiastolicValueBloodPressure()
        {
            string chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? "C:\\Users\\venka\\Desktop\\gclynch\\bp2023lab\\bp\\SeleniumTests\\drivers\\chromedriver.exe"; // Use null coalescing operator

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // Navigate to URI for the temperature converter
            driver.Navigate().GoToUrl(webAppUri);

            // Get SystolicValue element
            IWebElement SystolicValue = driver.FindElement(By.Id("BP_Systolic"));
            SystolicValue.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 120 in the element
            SystolicValue.SendKeys("70");

            // Get Diastolic element
            IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
            diastolic.Click();

            // Select all text in the element
            new Actions(driver).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();

            // Enter 60 in the element
            diastolic.SendKeys("30");

            // Submit the form
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            By elementSelector = By.CssSelector(".text-danger.field-validation-error");
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(elementSelector));


            // Capture and print the text of the element
            string errorMessage = element.Text;

            Assert.AreEqual("Invalid Diastolic Value", errorMessage, "Blood pressure category is not as expected");

            Thread.Sleep(1000);

            driver.Quit();

            // Alternative - use Cypress or Playwright
        }


    }
}
