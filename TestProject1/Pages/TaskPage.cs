using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    [TestFixture]
    public class TaskPage : APage
    {
        public IWebElement OptionsButton { get; private set; }
        public IWebElement DeleteTaskButton { get; private set; }
        public IWebElement TaskNameFild { get; private set; }
        public IWebElement SaveButton { get; private set; } 
        public IWebElement CompleteButton { get; private set; }

        public IWebElement CompleteAlert { get; private set; }

        public TaskPage(IWebDriver driver) : base(driver) 
        {
            OptionsButton = driver.FindElement(By.CssSelector("button[aria-label='More actions']"));
            TaskNameFild = driver.FindElement(By.CssSelector("div[aria-label='Task name']"));
            CompleteButton = driver.FindElement(By.CssSelector("button[aria-label='Checkbox for Test task']"));
        }

        public TaskPage ClickOptionButton()
        {
            OptionsButton.Click();
            return this;
        }

        public void ClickDeleteTaskButton()
        {
            DeleteTaskButton = driver.FindElement(By.XPath("//div[contains(text(), 'Delete task…')]"));
            DeleteTaskButton.Click();
        }

        public TaskPage EnterNewTaskName(string newName)
        {
            TaskNameFild.Click();
            TaskNameFild = driver.FindElement(By.CssSelector("div[aria-label='Task name']"));
            TaskNameFild.Clear();
            TaskNameFild.SendKeys(newName);
            return this;
        }

        public TaskPage ClickSaveButton()
        {
            SaveButton = driver.FindElement(By.CssSelector("button[aria-label='Save']"));
            SaveButton.Click();
            return this;
        }

        public string GetTaskNameFildText()
        {
            TaskNameFild = driver.FindElement(By.CssSelector("div[aria-label='Task name']"));
            return TaskNameFild.Text;
        }


        public TaskPage ClickCompleteButton()
        {
            CompleteButton.Click();
            return this;
        }

        public string GetCompleteAlertText()
        {
            CompleteAlert = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _2a3b75a1']"));
            return CompleteAlert.Text;
        }

    }
}
