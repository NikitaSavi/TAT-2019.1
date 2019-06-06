using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CW_9.DriverFactory
{
    /// <summary>
    /// Creator of a Chrome WebDriver
    /// </summary>
    public class FirefoxCreator : IWebDriverCreator
    {
        /// <summary>
        /// Creates a new <see cref="FirefoxDriver"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="FirefoxDriver"/>.
        /// </returns>
        public IWebDriver Create()
        {
            return new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}