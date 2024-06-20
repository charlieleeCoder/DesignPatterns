using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V123.Network;

namespace Sender;
public class WebPortalFileSender: IFileSender
{
    public void SendFile(string filePath, string endLocation)
    {

        // Run selenium webdriver
        IWebDriver driver = new ChromeDriver();

        // Select file
        if (! File.Exists(filePath))
        {
            throw new ArgumentException($"File does not exist at {filePath}");
        }

        CreateHTTPConnection(driver, endLocation);

        // This is just an example, usually, many steps of navigation are required.
        IWebElement submitButton = driver.FindElement(By.Id("submit-file"));

        // Assuming they don't use a plug-in, ActiveX Controller, etc.,
        // it really is this simple to send to a submit type form element
        submitButton.SendKeys(filePath);
    }

    // Create HTTP connection
    private void CreateHTTPConnection(IWebDriver driver, string webPage)
    {
        // To implement
        driver.Navigate().GoToUrl(webPage);
    }
}
