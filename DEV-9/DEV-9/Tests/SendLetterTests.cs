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
        /// The Mail.Ru address.
        /// </summary>
        private string mailruAddress = "niksavi84@mail.ru";

        /// <summary>
        /// The yandex address.
        /// </summary>
        private string yandexAddress = "niksavi84@yandex.by";

        /// <summary>
        /// The password to both mailboxes.
        /// </summary>
        private string password = "Tes1Pas5";

        /// <summary>
        /// Set up: initializes the WebDriver. Sets the URL and implicit timer.
        /// </summary>
        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// Positive test for sending email:
        /// check that sender is correct and letter is marked as unread;
        /// read and check that content is correct. 
        /// </summary>
        [Test]
        public void SendLetter()
        {
            var letterText = "Text of the mail, hey there";

            this.driver.Url = "https://mail.ru";
            var mailruLoginPage = new PageObjects.MailRu.HomePage(this.driver);
            var mailruMailPage = mailruLoginPage.Login(this.mailruAddress, this.password);
            var mailruWriterPage = mailruMailPage.WriteNewLetter();
            mailruWriterPage.SendLetter(this.yandexAddress, letterText);
            this.CloseBrowser();

            this.StartBrowser();
            this.driver.Url = "https://yandex.by";
            var yandexLoginPage = new PageObjects.Yandex.HomePage(this.driver);
            var yandexMailPage = yandexLoginPage.Login(this.yandexAddress, this.password);
            Assert.True(yandexMailPage.CheckIfSenderIsCorrect(yandexMailPage.LatestMailLocatorString, this.mailruAddress));
            Assert.True(yandexMailPage.CheckIfUnread(yandexMailPage.LatestMailLocatorString));
            var yandexReadPage = yandexMailPage.ReadMail(yandexMailPage.LatestMailLocatorString);
            var letterRecievedText = yandexReadPage.MailText.Text;
            Assert.AreEqual(letterText, letterRecievedText);
        }

        /// <summary>
        /// Positive test for sending email:
        /// send a new nickname as a reply, change nickname to the received one.
        /// </summary>
        [Test]
        public void SendReplyAndChangeNickname()
        {
            var newNicknameToSend = "NewNickname TheBestOne";

            this.driver.Url = "https://yandex.by";
            var yandexLoginPage = new PageObjects.Yandex.HomePage(this.driver);
            var yandexMailPage = yandexLoginPage.Login(this.yandexAddress, this.password);
            var yandexReadPage = yandexMailPage.ReadMail(yandexMailPage.LatestMailLocatorString);
            yandexReadPage.ReplyToMail(newNicknameToSend);
            this.CloseBrowser();

            this.StartBrowser();
            this.driver.Url = "https://mail.ru";
            var mailruLoginPage = new PageObjects.MailRu.HomePage(this.driver);
            var mailruMailPage = mailruLoginPage.Login(this.mailruAddress, this.password);
            var mailruReadPage = mailruMailPage.ReadMail(mailruMailPage.LatestMail);

            // Split is needed to separate nickname from everything else in the reply.
            var newNicknameRecieved = mailruReadPage.MailText.Text.Split('\r')[0];
            Assert.AreEqual(newNicknameToSend, newNicknameRecieved);

            var settingPage = mailruReadPage.GoToPersonalDataPage();
            settingPage.ChangeNickname(newNicknameRecieved);

            // Cannot think for now of a better way to check new nickname than to open settings again.
            Assert.AreEqual(newNicknameToSend, settingPage.NicknameBox.GetAttribute("value"));
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