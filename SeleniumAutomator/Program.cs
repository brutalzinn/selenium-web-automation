using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SeleniumAutomator
{
    internal class Program
    {

        public static bool LoginWordPress(Page page, IWebDriver driver)
        {
            var logTime = page.LogTime;
            driver.Navigate().GoToUrl("");
          
            var username = driver.FindElement(By.XPath("//*[@id=\"user_login\"]"));
            username.SendKeys("");

            var password = driver.FindElement(By.XPath("//*[@id=\"user_pass\"]"));
            password.SendKeys("");

            driver.WaitRecaptcha(By.XPath("//*[@id=\"recaptcha-anchor\"]"), () => {
                Console.WriteLine("######PASSOU DO WAIT {0}", DateTime.Now);
                driver.FindElement(By.Id("wp-submit")).Click();
            });

            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("######INICIADO{0}", DateTime.Now);

            IWebDriver driver = new ChromeDriver();
            List<Page> pages = new List<Page> { new Page("Login", (page) => LoginWordPress(page, driver)) };
            
            foreach(Page item in pages)
            {
                item.LogTime.ToConsoleWriteLine("Página", item.Nome, ConsoleColor.Yellow);
                item.Executar();
                item.LogTime.ToConsoleWriteLine("Tempo(S)", item.LogTime.TempoExecucao.TotalSeconds, ConsoleColor.Green);
                item.LogTime.ToConsoleWriteLine("Tempo(MS)", item.LogTime.TempoExecucao.TotalMilliseconds, ConsoleColor.Green);
            }
    

            Console.ReadLine();
            driver.Quit();
            Environment.Exit(0);
        }

    }
}
