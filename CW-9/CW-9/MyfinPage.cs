using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace CW_9
{
    /// <summary>
    /// The class of page object pattern.
    /// </summary>
    public class MyfinPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// List of all currencies available.
        /// </summary>
        public List<IWebElement> CurrenciesNames =>
            this.driver.FindElements(By.XPath("//div[@class = 'table-responsive']//tr/td/a")).ToList();

        /// <summary>
        /// List of currencies rates.
        /// </summary>
        public List<IWebElement> CurrenciesRates =>
            this.driver.FindElements(By.XPath("//div[@class = 'table-responsive']//tr/td[4]")).ToList();

        /// <summary>
        /// Initializes a new instance of the <see cref="MyfinPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public MyfinPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Url = "https://myfin.by/currency/minsk";
        }

        /// <summary>
        /// Gets a list with all currencies.
        /// </summary>
        /// <returns>
        /// The list of currencies.
        /// </returns>
        public List<Currency> GetCurrencies()
        {
            var currencies = new List<Currency>();
            for (int i = 0; i < this.CurrenciesNames.Count; i++)
            {
                currencies.Add(new Currency(this.CurrenciesNames[i].Text, this.CurrenciesRates[i].Text));
            }

            this.driver.Quit();

            return currencies;
        }
    }
}