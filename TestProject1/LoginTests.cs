using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    [TestFixture]
    public class LoginTests
    {

        private static IWebDriver driver;

        [SetUp]
        public static void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://todoist.com/auth/login");
        }

        [Test]
        public void TestLoginWithValidData()
        {

            driver.FindElement(By.Id("element-0")).SendKeys("bahdan510@gmail.com");

            driver.FindElement(By.Id("element-3")).SendKeys("SchoolLviv22");

            driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']")).Click();

            driver.FindElement(By.CssSelector("div[class='+syWHcL _0J7x-Vo settings_avatar _2a3b75a1']")).Click();

            string setingsText = driver.FindElement(By.CssSelector("span[class='user_menu_label']")).Text;

            Assert.AreEqual("Settings", setingsText);


            driver.Quit();

        }

        [Test]
        public void TestLoginWithInvalidData()
        {

            driver.FindElement(By.Id("element-0")).SendKeys("bahdan510@gmail.com");

            driver.FindElement(By.Id("element-3")).SendKeys("InvalidPassword");

            driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']")).Click();

            string errorMassege = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _266d6623 _8f5b5f2b _2a3b75a1']")).Text;


            Assert.AreEqual("Wrong email or password.", errorMassege);

            driver.Quit();
        }

        [Test]
        public void TestForgotPassword()
        {

            driver.FindElement(By.LinkText("Forgot your password?")).Click();

            driver.FindElement(By.Id("element-6")).SendKeys("bahdan510@gmail.com");

            string buttonText = driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']")).Text;

            Assert.AreEqual("Reset my password", buttonText);

            driver.Quit();
        }

        [Test]
        public void TestCreateAccout()
        {

            driver.FindElement(By.LinkText("Sign up")).Click();

            driver.FindElement(By.Id("element-6")).SendKeys("bahdan510@gmail.com");

            driver.FindElement(By.Id("element-9")).SendKeys("ValidPassword");

            string buttonText = driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']")).Text;

            Assert.AreEqual("Sign up with Email", buttonText);

            driver.Quit();

        }


        [TearDown]
        public static void StopBrowser()
        {
            driver.Quit();
        }
    }
}