using OpenQA.Selenium;

namespace DEV_9.PageObjects.Yandex
{
    /// <summary>
    /// Main mail page.
    /// </summary>
    public class MailStartPage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Locator of the latest mail element.
        /// </summary>
        public IWebElement WriteNewLetterButton => this.driver.FindElement(By.XPath("//a[@class='mail-ComposeButton js-main-action-compose']"));

        /// <summary>
        /// Locator of the latest mail element.
        /// </summary>
        public By LatestMailLocatorString => By.XPath("//div[@class='ns-view-container-desc mail-MessagesList js-messages-list']/div[1]");

        /// <summary>
        /// Initializes a new instance of the <see cref="MailStartPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public MailStartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //// TODO think about removing check methods from here.
        
        /// <summary>
        /// Checks if the mail has the correct sender.
        /// </summary>
        /// <param name="mailLocator">
        /// The locator of the mail.
        /// </param>
        /// <param name="sender">
        /// The sender's full mail.
        /// </param>
        /// <returns>
        /// 'True' if the sender is correct.
        /// </returns>
        public bool CheckIfSenderIsCorrect(By mailLocator, string sender) =>
            this.driver.FindElement(By.XPath(
                    $"{mailLocator.ToString().Split(':')[1].Trim()}"
                    + $"//span[@class='mail-MessageSnippet-FromText' and @title='{sender}']")) != null;

        /// <summary>
        /// Checks if the mail is unread.
        /// </summary>
        /// <param name="mailLocator">
        /// The locator of the mail.
        /// </param>
        /// <returns>
        /// 'True' if unread.
        /// </returns>
        public bool CheckIfUnread(By mailLocator) =>
            this.driver.FindElement(By.XPath(
                    $"{mailLocator.ToString().Split(':')[1].Trim()}"
                    + "//span[contains(@class, 'state_toRead')]")) != null;

        /// <summary>
        /// Goes to the reading page for the mail.
        /// </summary>
        /// <param name="mailLocator">
        /// The mail locator.
        /// </param>
        /// <returns>
        /// The <see cref="MailReadPage"/>.
        /// </returns>
        public MailReadPage ReadMail(By mailLocator)
        {
            this.driver.FindElement(mailLocator).Click();
            return new MailReadPage(this.driver);
        }
    }
}