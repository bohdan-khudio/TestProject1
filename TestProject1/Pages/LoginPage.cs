using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class LoginPage : APage
    {
        public IWebElement EmailField { get; private set; }
        public IWebElement PasswordField { get; private set; }
        public IWebElement LoginButton { get; private set; }
        public IWebElement ForgotPasswordButton { get; private set; }

        public IWebElement SingUpButton { get; private set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            EmailField = driver.FindElement(By.Id("element-0"));

            PasswordField = driver.FindElement(By.Id("element-3"));

            LoginButton = driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']"));

            ForgotPasswordButton = driver.FindElement(By.LinkText("Forgot your password?"));

            SingUpButton = driver.FindElement(By.LinkText("Sign up"));
        }


        // EmailField
        public void ClickEmailField() => EmailField.Click();
        public void ClearEmailField() => EmailField.Clear();
        public void SetEmailField(string text) => EmailField.SendKeys(text);

        // PasswordField
        public void ClickPasswordField() => PasswordField.Click();
        public void ClearPasswordField() => PasswordField.Clear();
        public void SetPasswordField(string text) => PasswordField.SendKeys(text);

        // LoginButton
        public void ClickLoginButton() => LoginButton.Click();

        public ForgotPasswordPage ClickForgotPasswordButton()
        {
            ForgotPasswordButton.Click();
            return new ForgotPasswordPage(driver);
        }

        public SingUpPage ClickSingUpButton()
        {
            SingUpButton.Click();
            return new SingUpPage(driver);
        }
        private void FillLoginForm(string email, string password)
        {
            ClickEmailField();
            ClearEmailField();
            SetEmailField(email);
            ClickPasswordField();
            ClearPasswordField();
            SetPasswordField(password);
            ClickLoginButton();
        }

        public MainPage SuccessfullLogin(string email, string password)
        {
            FillLoginForm(email, password);
            return new MainPage(driver);
        }

        public LoginMessagePage UnsuccessfullLogin(string email, string password)
        {
            FillLoginForm(email, password);
            return new LoginMessagePage(driver);
        }
    }
}
