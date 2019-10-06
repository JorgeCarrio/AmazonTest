using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMAmazon.PageObjects;

namespace POMAmazon
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //The perform is a bit better on Chrome hidden mode
            var options = new ChromeOptions();
            options.AddArguments("--window-size=1920,1080");
            options.AddArguments("--start-maximized");
            options.AddArguments("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.IMPLICIT_WAIT);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// As a user, I want to make a purchase on Amazon.
        /// </summary>
        /// <remarks>
        /// This test validates that the item is in the cart.
        /// </remarks>
        [Test]
        [TestCase("Apple watch")]
        [TestCase("Xiaomi")]
        [TestCase("iPhone 7")]
        public void MakeAPurchase(string item)
        {
            try
            {
                HomePage home = new HomePage(driver);
                home.GoToPage();
                home.SearchItem(item);
                string itemTitle = home.SelectFristItem();
                home.AddToCart();
                home.AccessCart();
                Assert.IsTrue(home.ValidateItemCart(itemTitle));
            }
            catch (Exception ex)
            {
                Assert.Fail(@"Error occurred at " + System.Reflection.MethodBase.GetCurrentMethod().Name + "-> " + ex.ToString());
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
