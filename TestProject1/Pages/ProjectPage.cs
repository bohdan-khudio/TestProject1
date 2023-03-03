using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class ProjectPage : APage
    {
        public IWebElement ProjectName { get; private set; }
        public ProjectPage(IWebDriver driver) : base(driver)
        {
            ProjectName = driver.FindElement(By.CssSelector("span[class='simple_content']"));
        }

        public string GetProjectName()
        {
            return ProjectName.Text;
        }
    }
}
