using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Tools
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected string URL { get => "https://todoist.com/auth/login"; }

        protected string email = "bahdan510@gmail.com";
        protected string password = "SchoolLviv22";

        [SetUp]
        public void BeforeEachMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
        }

        [TearDown]
        public void AfterEachMethod()
        {           
            driver.Quit();
        }

       
    }
}
