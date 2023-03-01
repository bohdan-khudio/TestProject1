using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class ForgotPasswordPage : APage
    {
        public IWebElement EmailField { get; private set; }
        public IWebElement ResetPassswordButton { get; private set; }
        public ForgotPasswordPage(IWebDriver driver) : base(driver)
        {
            EmailField = driver.FindElement(By.Id("element-6"));

            ResetPassswordButton = driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']"));
        }

        public void ClickEmailField() => EmailField.Click();
        public void ClearEmailField() => EmailField.Clear();
        public void SetEmailField(string text) => EmailField.SendKeys(text);

        public string GetResetPasswordButtonText() => ResetPassswordButton.Text;

        private void FillEmail(string email)
        {
            ClickEmailField();
            ClearEmailField();
            SetEmailField(email);
            
        }

        public ForgotPasswordPage ResetPassword(string email)
        {
            FillEmail(email);
            return this;
        }
    }
}
