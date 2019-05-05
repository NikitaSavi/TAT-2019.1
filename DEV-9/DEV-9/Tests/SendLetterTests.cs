using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEV_9.Tests
{
    /// <summary>
    /// Tests for sending letters back and forth.
    /// </summary>
    [TestFixture]
    public class SendLetterTests
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
            this.driver = new ChromeDriver();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        /// <summary>
        /// Positive test sending email:
        /// check that sender is correct and letter is marked as unread;
        /// read and check that content is correct. 
        /// </summary>
        [Test]
        public void SendLetter()
        {
            var mailruAddress = "niksavi84@mail.ru";
            var yandexAddress = "niksavi84@yandex.by";
            var password = "Tes1Pas5";
            var letterText = "Text of the mail, hey there";

            this.driver.Url = "https://mail.ru";
            var mailruLoginPage = new PageObjects.MailRu.HomePage(this.driver);
            var mailruMailPage = mailruLoginPage.Login(mailruAddress, password);
            var mailruWriterPage = mailruMailPage.WriteNewLetter();
            mailruWriterPage.SendLetter(yandexAddress, letterText);

            this.driver.Url = "https://yandex.by";
            var yandexLoginPage = new PageObjects.Yandex.HomePage(this.driver);
            var yandexMailPage = yandexLoginPage.Login(yandexAddress, password);
            Assert.True(yandexMailPage.CheckIfSenderIsCorrect(yandexMailPage.LatestMailLocatorString, mailruAddress));
            Assert.True(yandexMailPage.CheckIfUnread(yandexMailPage.LatestMailLocatorString));
            var yandexReadPage = yandexMailPage.ReadMail(yandexMailPage.LatestMailLocatorString);
            var letterRecievedText = yandexReadPage.MailText.Text;
            Assert.AreEqual(letterText, letterRecievedText);
        }

        /// <summary>
        /// Tear down: close the driver.
        /// </summary>
        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}