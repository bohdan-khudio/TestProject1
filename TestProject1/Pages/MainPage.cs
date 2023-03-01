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
        public MainPage(IWebDriver driver) : base(driver)
        {
            ProfileMenu = driver.FindElement(By.CssSelector("div[class='+syWHcL _0J7x-Vo settings_avatar _2a3b75a1']"));
        
        }

        public string GetSettingText()
        {
            ProfileMenu.Click();
            SettingsButon = driver.FindElement(By.CssSelector("span[class='user_menu_label']"));
            return SettingsButon.Text;
        }
    }
}
