using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class SingUpPage : APage
    {
        public IWebElement EmailField { get; private set; }

        public IWebElement PasswordField { get; private set; }

        public IWebElement SingUpButton { get; private set; }
        public SingUpPage(IWebDriver driver) : base(driver) 
        {
            EmailField = driver.FindElement(By.Id("element-6"));

            PasswordField = driver.FindElement(By.Id("element-9"));

            SingUpButton = driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']"));
        }

        // EmailField
        public void ClickEmailField() => EmailField.Click();
        public void ClearEmailField() => EmailField.Clear();
        public void SetEmailField(string text) => EmailField.SendKeys(text);

        // PasswordField
        public void ClickPasswordField() => PasswordField.Click();
        public void ClearPasswordField() => PasswordField.Clear();
        public void SetPasswordField(string text) => PasswordField.SendKeys(text);

        public string GetSingUpButtonText() => SingUpButton.Text;

        private void FillSingUpForm(string email, string password)
        {
            ClickEmailField();
            ClearEmailField();
            SetEmailField(email);
            ClickPasswordField();
            ClearPasswordField();
            SetPasswordField(password);

        }

        public SingUpPage CreateAccount(string email, string password)
        {
            FillSingUpForm(email, password);
            return this;
        }

    }
}
