using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverWaitExtensions.ExpectedConditions;
namespace SeleniumAutomator
{
    public static class SeleniumExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver">Web Driver</param>
        /// <param name="by">Localização do elemento</param>
        /// <param name="attribute">Atributo</param>
        /// <param name="expected">atributo esperado</param>
        /// <returns></returns>
        private static bool AttributeExpected(this IWebDriver driver, By by, string attribute, string expected)
        {
            try
            {
                var element = driver.FindElement(by);
                return element.GetAttribute(attribute) == expected ? true : false;                 
            }
            catch(NoSuchElementException)
            {
                return false;
            }

        }
        /// <summary>
        /// Espera um captcha ser feito pelo usuário
        /// </summary>
        /// <param name="driver">Instância de web driver</param>
        /// <param name="by">Elemento com o Recaptcha</param>
        /// <param name="callBack">Callback para a ser chamado após a validação</param>
        public static void WaitRecaptcha(this IWebDriver driver, By by, Action callBack)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(10));
            
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(FrameConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[starts-with(@name, 'a-') and starts-with(@src, 'https://www.google.com/recaptcha')]")));
            wait.Until(ElementConditions.ElementToBeClickable(By.CssSelector("div.recaptcha-checkbox-border"))).Click();
            
            wait.Until(d => d.AttributeExpected(by, "aria-checked", "true"));

            driver.SwitchTo().DefaultContent();
            callBack();
        }
    }
}
