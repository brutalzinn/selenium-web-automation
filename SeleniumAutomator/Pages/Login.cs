using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SeleniumAutomator.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomator.Pages
{
    public static class PageLogin
    {
        public static bool LoginWordPress(Page page, IWebDriver driver , IConfiguration config)
        {
            var AuthConfig = config.GetSection("authentication").Get<Authentication>();

            LogTime.Iniciar();
            driver.Navigate().GoToUrl(AuthConfig.LoginUrl);
            LogTime.Finalizar();

            var username = driver.FindElement(By.XPath("//*[@id=\"user_login\"]"));
            username.SendKeys(AuthConfig.Email);

            var password = driver.FindElement(By.XPath("//*[@id=\"user_pass\"]"));
            password.SendKeys(AuthConfig.Password);

            driver.WaitRecaptcha(By.XPath("//*[@id=\"recaptcha-anchor\"]"), () => {
                Console.WriteLine("######PASSOU DO WAIT {0}", DateTime.Now);
                driver.FindElement(By.Id("wp-submit")).Click();
            });

            return true;
        }
    }
}
