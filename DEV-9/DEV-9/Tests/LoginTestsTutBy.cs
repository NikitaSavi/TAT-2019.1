using System;
using DEV_9.PageObjects.TutBy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEV_9.Tests
{
    /// <summary>
    /// Tests for logging in on Tut.by.
    /// </summary>
    [TestFixture]
    public class LoginTestsTutBy
    {
        /// <summary>
        /// The WebDriver instance for tests.
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Set up: initializes the WebDriver. Sets the URL and implicit timer.
        /// </summary>
        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver { Url = "https://tut.by" };
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Positive test for logging in:
        /// entering the correct ID.
        /// Moves user to the mail page.
        /// </summary>
        [Test]
        public void Login_CorrectId_Proceed()
        {
            var homePage = new HomePage(this.driver);
            var username = "niksavi84";
            var password = "Tes1Pas5";
            homePage.Login(username, password);
            //// TODO Assert
        }

        /// <summary>
        /// Negative test for logging in:
        /// empty input, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyInput_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            homePage.Login_EmptyInput_ExpectingError();
            Assert.True(this.driver.FindElement(homePage.DisabledLoginButtonLocator).Displayed);
        }

        /// <summary>
        /// Negative test for logging in:
        /// wrong id, results in error message.
        /// </summary>
        [Test]
        public void Login_WrongId_ErrorMessage()
        {
            var homePage = new HomePage(this.driver);
            var username = "werj6ys";
            var password = "wewrw";
            homePage.Login_ExpectingError(username, password);
            Assert.AreEqual("Неверное имя пользователя или пароль", homePage.ErrorMessage.Text);
        }

        /// <summary>
        /// Tear down: closes the driver.
        /// </summary>
        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}