using OpenQA.Selenium;

namespace DEV_9.PageObjects.TutBy
{
    /// <summary>
    /// Tut.by home page.
    /// Signing in is done here.
    /// </summary>
    public class HomePage
    {
        /// <summary>
        /// The WebDriver.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Locator for the button for popup login box.
        /// </summary>
        private By loginPopupButtonLocator = By.XPath(".//a[@data-target-popup='authorize-form']");

        /// <summary>
        /// Locator for the username box.
        /// </summary>
        private By usernameBoxLocator = By.XPath(".//input[@name='login']");

        /// <summary>
        /// Locator for the password box.
        /// </summary>
        private By passwordBoxLocator = By.XPath(".//input[@name='password']");

        /// <summary>
        /// Locator for the login button.
        /// </summary>
        private By loginButtonLocator = By.XPath(".//input[@class='button auth__enter']");

        /// <summary>
        /// Locator for the login button when it's disabled.
        /// </summary>
        public By DisabledLoginButtonLocator => By.XPath(".//input[@class='button auth__enter disabled']");

        /// <summary>
        /// Locator for button to enter mail page.
        /// </summary>
        private By enterMailButtonLocator = By.XPath(".//a[text()='Почта']");

        /// <summary>
        /// Locator for the login error message.
        /// </summary>
        private By loginErrorMessageLocator = By.XPath(".//div[@class='b-auth__error']");

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver.
        /// </param>
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
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
            // Enter ID in the login box in the upper right corner.
            this.driver.FindElement(this.loginPopupButtonLocator).Click();
            this.driver.FindElement(this.usernameBoxLocator).SendKeys(username);
            this.driver.FindElement(this.passwordBoxLocator).SendKeys(password);
            this.driver.FindElement(this.loginButtonLocator).Click();

            // Access the same box again in order to enter the mail page.
            this.driver.FindElement(this.loginPopupButtonLocator).Click();
            this.driver.FindElement(this.enterMailButtonLocator).Click();
            return this;
        }

        /// <summary>
        /// Method for logging in with provided credentials.
        /// For testing wrong inputs only.
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
            // Enter ID in the login box in the upper right corner.
            this.driver.FindElement(this.loginPopupButtonLocator).Click();
            this.driver.FindElement(this.usernameBoxLocator).SendKeys(username);
            this.driver.FindElement(this.passwordBoxLocator).SendKeys(password);
            this.driver.FindElement(this.loginButtonLocator).Click();

            // After a failed log in, Tut.by refreshes the page. It's required to access the login box in order to see the error message.
            this.driver.FindElement(this.loginPopupButtonLocator).Click();
            return this;
        }

        /// <summary>
        /// Method for trying to log in without entering anything.
        /// For testing purposes only.
        /// </summary>
        /// <returns>
        /// Remains on this <see cref="HomePage"/>.
        /// </returns>
        public HomePage Login_EmptyInput_ExpectingError()
        {
            // On Tut.by the "Войти" button is disabled until login and password are entered.
            this.driver.FindElement(this.loginPopupButtonLocator).Click();
            return this;
        }
    }
}