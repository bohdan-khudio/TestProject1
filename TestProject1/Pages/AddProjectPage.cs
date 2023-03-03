using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class AddProjectPage : APage
    {
        public IWebElement ProjectNameField { get; private set; }

        public IWebElement AddProjectButton { get; private set; }

        public AddProjectPage(IWebDriver driver) : base(driver) 
        {
            ProjectNameField = driver.FindElement(By.Id("edit_project_modal_field_name"));           
        }

        public AddProjectPage FillProjectName(string name)
        {
            ProjectNameField.SendKeys(name);
            return this;
        }

        public ProjectPage ClickAddProjectButton()
        {
            AddProjectButton = driver.FindElement(By.CssSelector("button[class='_8313bd46 _7a4dbd5f _5e45d59f _2a3b75a1 _56a651f6']"));
            AddProjectButton.Click();
            return new ProjectPage(driver);
        }
    }
}
