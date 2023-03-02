using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class MainPage : APage
    {
        public IWebElement ProfileMenu { get; private set; }

        public IWebElement SettingsButon { get; private set; }

        public IWebElement AddTaskButton { get; private set; }

        public IWebElement TaskNameFild { get; private set; }

        public IWebElement TaskDescriptionFild { get; private set; }

        public IWebElement SaveTaskButton { get; private set; }

        public IWebElement SuccessAlert { get; private set; }

        public IWebElement Task { get; private set; }
        public MainPage(IWebDriver driver) : base(driver)
        {
            ProfileMenu = driver.FindElement(By.CssSelector("div[class='+syWHcL _0J7x-Vo settings_avatar _2a3b75a1']"));
            AddTaskButton = driver.FindElement(By.CssSelector("button[class='plus_add_button']"));
            Task = driver.FindElement(By.XPath("//div[contains(text(), 'Test task')]"));

        }

        public MainPage ClickAddTaskButton()
        {
            AddTaskButton.Click();
            return this;

        }
        public MainPage FillNewTaskData(string name, string description)
        {
            
            TaskNameFild = driver.FindElement(By.CssSelector("p[data-placeholder='Task name']"));
            TaskNameFild.SendKeys(name);
            TaskDescriptionFild = driver.FindElement(By.CssSelector("p[data-placeholder='Description']"));
            TaskDescriptionFild.SendKeys(description);
            return this;

        }

        public MainPage ClickSaveTaskButton()
        {
            SaveTaskButton = driver.FindElement(By.CssSelector("button[class='_8313bd46 _7a4dbd5f _5e45d59f _2a3b75a1 _56a651f6']"));
            SaveTaskButton.Click();
            return this;
        }

        public string GetSuccessAlertText()
        {
            SuccessAlert = driver.FindElement(By.CssSelector("div[class='a83bd4e0 _2a3b75a1']"));
            return SuccessAlert.Text;
        }

        public string GetSettingText()
        {
            ProfileMenu.Click();
            SettingsButon = driver.FindElement(By.CssSelector("span[class='user_menu_label']"));
            return SettingsButon.Text;
        }

        public TaskPage OpenTask()
        {
            Task.Click();
            return new TaskPage(driver);
        }
    }
}
