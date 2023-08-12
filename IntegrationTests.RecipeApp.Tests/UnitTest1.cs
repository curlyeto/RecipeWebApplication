using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTests.RecipeApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver? _webDriver ;

        [TestInitialize]
        public void setup()
        {
            //Setup
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void TestLoginPageTitle()
        {
            _webDriver?.Navigate().GoToUrl("https://localhost:7041/login");
            Assert.IsTrue(_webDriver?.Title.Contains("RecipeApp"));
        }
        [TestMethod]
        public void GotoHomePageGetTitle()
        {
            _webDriver?.Navigate().GoToUrl("https://localhost:7041/login");
            var emailTextArea = _webDriver?.FindElement(By.Id("email"));
            var passwordTextArea = _webDriver?.FindElement(By.Id("password"));
            var loginButton = _webDriver?.FindElement(By.CssSelector("button.btn.btn-primary"));
            emailTextArea?.SendKeys("test@gmail.com");
            passwordTextArea?.SendKeys("1234");
            loginButton?.Click();
            Assert.IsTrue(_webDriver?.Title.Contains("Home"));
        }

        [TestMethod]
        public void GotoHomePageChangeTabAndGetTitle()
        {
            _webDriver?.Navigate().GoToUrl("https://localhost:7041/login");
            var emailTextArea = _webDriver?.FindElement(By.Id("email"));
            var passwordTextArea = _webDriver?.FindElement(By.Id("password"));
            var loginButton = _webDriver?.FindElement(By.CssSelector("button.btn.btn-primary"));
           
            // Login page set textarea default value 
            emailTextArea?.SendKeys("test@gmail.com");
            passwordTextArea?.SendKeys("1234");
            // click login button and go new page
            loginButton?.Click();

           

            // Home Page
            var myRecipeTab = _webDriver?.FindElement(By.CssSelector("i.oi.oi-list-rich"));
            myRecipeTab?.Click();

            Assert.IsTrue(_webDriver?.Title.Contains("My Recipe"));
            
        }


       
        [TestCleanup]
        public void TearDown()
        {
            // Teaar down
            _webDriver?.Quit();
        }
    }
}