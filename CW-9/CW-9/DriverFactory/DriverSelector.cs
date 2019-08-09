using System;

namespace CW_9.DriverFactory
{
    /// <summary>
    /// Selects the required WebDriver by entered command.
    /// </summary>
    public class DriverSelector
    {
        /// <summary>
        /// Gets the required WebDriver.
        /// </summary>
        /// <param name="browser">
        /// The request.
        /// </param>
        /// <returns>
        /// The required WebDriver.
        /// </returns>
        public IWebDriverCreator GetDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    return new ChromeCreator();
                case "firefox":
                    return new FirefoxCreator();
                default:
                    throw new Exception("Unsupported browser.");
            }
        }
    }
}
