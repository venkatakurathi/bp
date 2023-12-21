using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace BPCalculator.Tests
{
    [TestClass]
    public class BloodPressureTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Set up the ChromeDriver
            driver = new ChromeDriver();

            //string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //driver = new ChromeDriver(path + @"\drivers\");

        }                          
        [TestMethod]
        public void SeleniumTest()
        {
            // Navigate to the BloodPressureModel page
            driver.Navigate().GoToUrl("http://localhost:53135/");

            var timeout = 10000; // in milliseconds
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("BP_Systolic")));

            // Find the Systolic input element and enter a value
            var systolicElement = driver.FindElement(By.Id("BP_Systolic")); // Replace with the actual ID of your Systolic input element
            systolicElement.SendKeys("120");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("BP_Diastolic")));


            // Find the Diastolic input element and enter a value
            var diastolicElement = driver.FindElement(By.Id("BP_Diastolic")); // Replace with the actual ID of your Diastolic input element
            diastolicElement.SendKeys("80");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"form1\"]/div[3]/input")));
            // Find the Submit button and click it
            var submitButton = driver.FindElement(By.XPath("//*[@id=\"form1\"]/div[3]/input")); // Replace with the actual ID of your Submit button
            submitButton.Click();

            // Optionally, you can check the result on the page after submission
            var resultElement = driver.FindElement(By.Id("result")); // Replace with the actual ID of the element displaying the result
            var resultText = resultElement.Text;

            // Assert the result
            Assert.AreEqual("Pre-High Blood Pressure", resultText); // Adjust the expected result as needed
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Close the browser after each test
            driver.Quit();
        }

        // ... Other unit tests
    }
}
