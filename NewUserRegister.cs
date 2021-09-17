using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Moneygaming
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckDobErrMessage_atNewRegistration()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://moneygaming.qa.gameaccount.com/");
            webDriver.Manage().Window.FullScreen();
            IWebElement JoinNowButton = webDriver.FindElement(By.CssSelector("[href*='/sign-up.shtml']"));
            JoinNowButton.Click();
            IWebElement TitleDropDown = webDriver.FindElement(By.Id("title"));
            SelectElement SelectTitle = new SelectElement(TitleDropDown);
            SelectTitle.SelectByText("Mrs");
            webDriver.FindElement(By.Id("forename")).SendKeys("Elena");
            webDriver.FindElement(By.Name("map(lastName)")).SendKeys("Staneva");
            webDriver.FindElement(By.Name("map(terms)")).Click();
            webDriver.FindElement(By.Id("form")).Click();
            var ActualErrMessageDoB = webDriver.FindElement(By.XPath("//*[@id='signupForm']/fieldset/label[contains(@for, 'dob')]")).Text;
            var ExpectedErrMessageDob = "This field is required";
            Assert.AreEqual(ActualErrMessageDoB, ExpectedErrMessageDob);
        }
    }
}
