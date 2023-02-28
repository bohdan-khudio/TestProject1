using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TestProject1
{
    [TestFixture]
    public class TodoTests
    {
        private static IWebDriver driver;

        [SetUp]
        public static void SetupAndLogin()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://todoist.com/auth/login");

            driver.FindElement(By.Id("element-0")).SendKeys("bahdan510@gmail.com");

            driver.FindElement(By.Id("element-3")).SendKeys("SchoolLviv22");

            driver.FindElement(By.CssSelector("button[class='nFxHGeI S7Jh9YX _8313bd46 _7a4dbd5f _95951888 _2a3b75a1 _8c75067a']")).Click();
        }

        [Test]
        public void TestAddTask()
        {

            driver.FindElement(By.CssSelector("button[class='plus_add_button']")).Click();

            driver.FindElement(By.CssSelector("p[data-placeholder='Task name']")).SendKeys("Test task");

            driver.FindElement(By.CssSelector("p[data-placeholder='Description']")).SendKeys("Test description");

            driver.FindElement(By.CssSelector("button[class='_8313bd46 _7a4dbd5f _5e45d59f _2a3b75a1 _56a651f6']")).Click();

            string divText = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _2a3b75a1']")).Text;

            Assert.AreEqual("Task added to Inbox", divText);            

        }

        [Test]
        public void TestDeleteTask()
        {
            driver.FindElement(By.XPath("//div[contains(text(), 'Test task')]")).Click();          
                            
            driver.FindElement(By.CssSelector("button[aria-label='More actions']")).Click();           
            
            driver.FindElement(By.XPath("//div[contains(text(), 'Delete task…')]")).Click();

            driver.FindElement(By.CssSelector("button[class='_8313bd46 _7a4dbd5f _5e45d59f _2a3b75a1 _56a651f6']")).Click();

        }

        [Test]
        public void TestEditTask()
        {
            driver.FindElement(By.XPath("//div[contains(text(), 'Test task')]")).Click();

            driver.FindElement(By.CssSelector("div[aria-label='Task name']")).Click();           

            driver.FindElement(By.CssSelector("div[aria-label='Task name']")).Clear();

            driver.FindElement(By.CssSelector("div[aria-label='Task name']")).SendKeys("Edited task");

            driver.FindElement(By.CssSelector("button[aria-label='Save']")).Click();

            string taskName = driver.FindElement(By.CssSelector("div[aria-label='Task name']")).Text;

            Assert.AreEqual("Edited task\r\nActivate to edit the task name", taskName);

        }

        [Test]
        public void TestCompleteTask()
        {
            driver.FindElement(By.XPath("//div[contains(text(), 'Test task')]")).Click();

            driver.FindElement(By.CssSelector("button[aria-label='Checkbox for Test task']")).Click();

            string divText = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _2a3b75a1']")).Text;

            Assert.AreEqual("1 task completed", divText);           

        }

        [Test]
        public void TestSortByDueDate()
        {
            driver.FindElement(By.CssSelector("button[aria-label='View options menu']")).Click();
            driver.FindElement(By.Id("view_menu__sort_by")).Click();
            Thread.Sleep(1000);

            IWebElement element = driver.FindElement(By.XPath("//span[contains(text(), 'Due date')]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();       
            Thread.Sleep(5000);
        }

        [Test]
        public void TestSortByPriority()
        {
            driver.FindElement(By.CssSelector("button[aria-label='View options menu']")).Click();
            driver.FindElement(By.Id("view_menu__sort_by")).Click();
            Thread.Sleep(1000);

            IWebElement element = driver.FindElement(By.XPath("//span[contains(text(), 'Priority')]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(5000);
        }

        [Test]
        public void TestCreateProgect()
        {
            IWebElement element = driver.FindElement(By.LinkText("Projects"));

            Actions action = new Actions(driver);

            action.MoveToElement(element).Perform();

            driver.FindElement(By.CssSelector("button[aria-label='Add project']")).Click();

            driver.FindElement(By.Id("edit_project_modal_field_name")).SendKeys("Test project");

            driver.FindElement(By.CssSelector("button[class='_8313bd46 _7a4dbd5f _5e45d59f _2a3b75a1 _56a651f6']")).Click();

            string name = driver.FindElement(By.CssSelector("span[class='simple_content']")).Text;

            Assert.AreEqual("Test project", name);
            
        }

        [Test]
        public void TestMoveTask() 
        {
            IWebElement element = driver.FindElement(By.XPath("//div[contains(text(), 'Test task')]"));

            Thread.Sleep(1000);

            Actions action = new Actions(driver);

            action.ContextClick(element).Perform();

            driver.FindElement(By.XPath("//div[contains(text(), 'Move to project')]")).Click();

            driver.FindElement(By.XPath("//div[contains(text(), 'Home')]")).Click();

            string divText = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _2a3b75a1']")).Text;

            Assert.AreEqual("Task moved to Home", divText);

        }

        [TearDown]
        public static void StopBrowser()
        {
            driver.Quit();
        }
    }
}
