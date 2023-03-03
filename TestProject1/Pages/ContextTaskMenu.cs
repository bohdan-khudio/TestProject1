using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class ContextTaskMenu : APage
    {
        public IWebElement MoveToProjectButton { get; private set; }

        public IWebElement HomeProject { get; private set; }
        public ContextTaskMenu(IWebDriver driver) : base(driver)
        {
            MoveToProjectButton = driver.FindElement(By.XPath("//div[contains(text(), 'Move to project')]"));
        }

        public ContextTaskMenu ClickMoveToProjectButton()
        {
            MoveToProjectButton.Click();
            return this; 
            
        }

        public MainPage SelectHomeProject()
        {
            HomeProject = driver.FindElement(By.XPath("//div[contains(text(), 'Home')]"));
            HomeProject.Click();
            return new MainPage(driver);
        }
    }
}
