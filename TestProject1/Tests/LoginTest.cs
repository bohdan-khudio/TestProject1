using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Pages;
using TestProject1.Tools;

namespace TestProject1.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {             

        private const string EXPECTED_SETTINGS_TEXT = "Settings";

        private const string EXPECTED_WARNING_LOGIN = "Wrong email or password.";

        private const string EXPECTED_RESET_BUTTON_TEXT = "Reset my password";

        private const string EXPECTED_SING_UP_BUTTON_TEXT = "Sign up with Email";

        [Test]
        public void LoginWithValidData()
        {
            MainPage mainPage = new LoginPage(driver).SuccessfullLogin(Email, Password);

            Assert.AreEqual(EXPECTED_SETTINGS_TEXT, mainPage.GetSettingText());
            
        }

        [Test]
        public void LoginWithInvalidData()
        {
            LoginMessagePage loginMessagePage = new LoginPage(driver).UnsuccessfullLogin("invalid@email.com", "invalidPassword");

            Assert.AreEqual(EXPECTED_WARNING_LOGIN, loginMessagePage.GetAlertMessageText());
        }

        [Test]
        public void ForgotPassword()
        {
            string ResetPasswordButtonText =  new LoginPage(driver)
                                                  .ClickForgotPasswordButton()
                                                  .ResetPassword(Email)
                                                  .GetResetPasswordButtonText();

            Assert.AreEqual(EXPECTED_RESET_BUTTON_TEXT, ResetPasswordButtonText);

        }

        [Test]
        public void CreateAccount()
        {
            string SingUpButtonText = new LoginPage(driver)
                                      .ClickSingUpButton()
                                      .CreateAccount(Email, Password)
                                      .GetSingUpButtonText();

            Assert.AreEqual(EXPECTED_SING_UP_BUTTON_TEXT, SingUpButtonText);
        }
    }
}
