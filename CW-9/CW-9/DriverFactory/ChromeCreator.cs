using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CW_9.DriverFactory
{
    /// <summary>
    /// Creator of a Chrome WebDriver
    /// </summary>
    public class ChromeCreator : IWebDriverCreator
    {
        /// <summary>
        /// Creates a new <see cref="ChromeDriver"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="ChromeDriver"/>.
        /// </returns>
        public IWebDriver Create()
        {
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}
