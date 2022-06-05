using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomator.Config;
using SeleniumAutomator.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SeleniumAutomator
{
    internal class Program
    {

        static void Automator(IWebDriver driver, IConfiguration config)
        {

            List<Page> pages = new List<Page> { new Page("login", (page) => PageLogin.LoginWordPress(page, driver, config)) };

            foreach (Page item in pages)
            {
                item.Nome.ToConsole("Página", ConsoleColor.Yellow);

                LogTime.Iniciar();
                item.Executar();
                LogTime.Finalizar();

                LogTime.TempoExecucao.TotalMilliseconds.ToConsole("Tempo(MS)", ConsoleColor.Green);
            }
        }
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json", optional: false);

            IConfiguration config = builder.Build();
            IWebDriver driver = new ChromeDriver();

            Automator(driver, config);

            Console.ReadLine();
            driver.Quit();
            Environment.Exit(0);
        }

    }
}
