using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.PageObjects.MailRu
{
    /// <summary>
    /// Mail.ru home page.
    /// Signing in is done here.
    /// </summary>
    public class HomePage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Locator for the username box.
        /// </summary>
        private By usernameBoxLocator = By.XPath(".//input[@id='mailbox:login']");

        /// <summary>
        /// Locator for the password box.
        /// </summary>
        private By passwordBoxLocator = By.XPath(".//input[@id='mailbox:password']");

        /// <summary>
        /// Locator for the login button.
        /// </summary>
        private By loginButtonLocator = By.XPath(".//label[@id='mailbox:submit']");

        /// <summary>
        /// Locator for the login error message.
        /// </summary>
        private By loginErrorMessageLocator = By.XPath(".//div[@id='mailbox:error']");

        /// <summary>
        /// Timer for login error messages to appear for testing purposes.
        /// </summary>
        /// <remarks>
        /// Test for empty input can be passed without this timer, but test for wrong input cannot,
        /// since it takes a small bit of time to check the database and show the error message.
        /// This timer's purpose is to take this delay into account.
        /// </remarks>
        private WebDriverWait errorLoginMsgWait;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.errorLoginMsgWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// Gets the error message element.
        /// </summary>
        public IWebElement ErrorMessage => this.driver.FindElement(this.loginErrorMessageLocator);

        /// <summary>
        /// Method for logging in with provided credentials.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="HomePage"/>.
        /// </returns>
        public HomePage Login(string username, string password)
        {
            this.driver.FindElement(this.usernameBoxLocator).SendKeys(username);
            this.driver.FindElement(this.passwordBoxLocator).SendKeys(password);
            this.driver.FindElement(this.loginButtonLocator).Click();
            return this;
        }

        /// <summary>
        /// Method for logging in with provided credentials.
        /// For testing wrong/empty inputs only.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Remains on this <see cref="HomePage"/>.
        /// </returns>
        public HomePage Login_ExpectingError(string username, string password)
        {
            this.driver.FindElement(this.usernameBoxLocator).SendKeys(username);
            this.driver.FindElement(this.passwordBoxLocator).SendKeys(password);
            this.driver.FindElement(this.loginButtonLocator).Click();
            this.errorLoginMsgWait.Until(x => x.FindElement(this.loginErrorMessageLocator).Displayed);
            return this;
        }
    }
}