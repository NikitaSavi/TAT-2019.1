using OpenQA.Selenium;

namespace DEV_9.PageObjects.Yandex
{
    /// <summary>
    /// Page for reading letters.
    /// </summary>
    public class MailReadPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Locator of the letter's text.
        /// </summary>
        public IWebElement MailText => this.driver.FindElement(By.XPath("//div[@class='mail-Message-Body-Content']"));

        /// <summary>
        /// Initializes a new instance of the <see cref="MailReadPage"/> class. 
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public MailReadPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}