using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public abstract class APage
    {
        protected IWebDriver driver;

        public APage(IWebDriver driver) 
        {
            this.driver = driver;
        }

    }
}
