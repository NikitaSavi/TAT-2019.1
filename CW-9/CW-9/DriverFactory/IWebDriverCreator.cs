using OpenQA.Selenium;

namespace CW_9.DriverFactory
{
    /// <summary>
    /// Defines a WebDriver creator.
    /// </summary>
    public interface IWebDriverCreator
    {
        /// <summary>
        /// Creates a WebDriver
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        IWebDriver Create();
    }
}
