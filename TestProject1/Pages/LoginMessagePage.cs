using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class LoginMessagePage : LoginPage
    {
        private IWebElement AlertMessage;
        public LoginMessagePage(IWebDriver driver) : base(driver) 
        {
            AlertMessage = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _266d6623 _8f5b5f2b _2a3b75a1']"));
        }

        public string GetAlertMessageText() => AlertMessage.Text;

    }
}
