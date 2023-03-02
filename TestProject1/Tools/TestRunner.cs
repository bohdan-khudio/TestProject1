using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;



namespace TestProject1.Tools
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected string URL { get; set; }
        protected string Email { get; set; }
        protected string Password { get; set; }
        protected string InvalidEmail { get; set; }
        protected string InvalidPassword { get; set; }

        [SetUp]
        public void BeforeEachMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
                        

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
            URL = config.GetValue<string>("url") ?? string.Empty;
            
            driver.Navigate().GoToUrl(URL);

            Email = config.GetValue<string>("email") ?? string.Empty;
            Password = config.GetValue<string>("password") ?? string.Empty;
            InvalidEmail = config.GetValue<string>("invalid_email") ?? string.Empty;
            InvalidPassword = config.GetValue<string>("invalid_password") ?? string.Empty;


        }

        [TearDown]
        public void AfterEachMethod()
        {           
            driver.Quit();
        }

       
    }
}
