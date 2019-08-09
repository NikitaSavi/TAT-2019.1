using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        /// Text of the mail.
        /// </summary>
        public IWebElement MailText => this.driver.FindElement(By.XPath("//div[@class='mail-Message-Body-Content']"));

        /// <summary>
        /// Activates the quick reply box.
        /// </summary>
        public IWebElement QuickReplyBoxInit => this.driver.FindElement(By.XPath("//div[@class='mail-QuickReply-Placeholder_text']"));

        /// <summary>
        /// The quick reply box element.
        /// </summary>
        public IWebElement QuickReplyBoxWrite => this.driver.FindElement(By.XPath("//div[@role='textbox']"));

        /// <summary>
        /// Button to send the reply.
        /// </summary>
        public IWebElement SendReplyButton => this.driver.FindElement(By.XPath("//button[contains(@class, 'js-send-button')]"));

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

        /// <summary>
        /// Reply to the mail.
        /// </summary>
        /// <param name="text">
        /// Text of the reply.
        /// </param>
        /// <returns>
        /// The <see cref="MailReadPage"/>.
        /// </returns>
        public MailReadPage ReplyToMail(string text)
        {
            this.QuickReplyBoxInit.Click();
            this.QuickReplyBoxWrite.SendKeys(text);
            this.SendReplyButton.Click();
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(3)).Until(
                x => this.driver.FindElement(By.XPath("//div[@data-key='view=quick-reply-done-success']")).Displayed);

            return this;
        }
    }
}