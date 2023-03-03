using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestProject1.Pages
{
    public class MainPageWithOptions : MainPage
    {
        public IWebElement SortingMenu { get; private set; }

        public IWebElement DueDateOption { get; private set; }

        public IWebElement PriorityOption { get; private set; }
        public MainPageWithOptions(IWebDriver driver) : base(driver)
        {
            SortingMenu = driver.FindElement(By.Id("view_menu__sort_by"));
        }

        public MainPageWithOptions ClickSortingMenu()
        {
            SortingMenu.Click();
            return this;
        }

        public void SelectDueDateOption()
        {
            DueDateOption = driver.FindElement(By.XPath("//span[contains(text(), 'Due date')]"));
            Actions action = new Actions(driver);
            action.MoveToElement(DueDateOption).Click().Perform();
            Thread.Sleep(5000);
        }
        
        public void SelectPriorityOption() 
        {
            PriorityOption = driver.FindElement(By.XPath("//span[contains(text(), 'Priority')]"));
            Actions action = new Actions(driver);
            action.MoveToElement(PriorityOption).Click().Perform();
            Thread.Sleep(5000);
        }
    }
}
