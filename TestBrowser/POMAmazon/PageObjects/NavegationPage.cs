using OpenQA.Selenium;

/******************************************************************************************
 * Class : NavegationPage
 * Function : class to control navigation menu
 *****************************************************************************************/

namespace POMAmazon.PageObjects
{
    public abstract class NavegationPage
    {
        #region Object properties
        private static By searchField = By.Id("twotabsearchtextbox");
        private static By handLensButton = By.ClassName("nav-input");
        private static By cartButton = By.Id("nav-cart");
        #endregion

        public IWebDriver driver;
        
        /// <summary>
        /// Method for access to Amazon web
        /// </summary>
        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.es/");
        }

        /// <summary>
        /// Method for select an item
        /// </summary>
        /// <param name="item"> Item to find </param>
        public void SearchItem(string item)
        {
            driver.FindElement(searchField).Clear();
            driver.FindElement(searchField).SendKeys(item);
            driver.FindElement(handLensButton).Click();
        }

        /// <summary>
        /// Method for access at cart
        /// </summary>
        public void AccessCart()
        {
            driver.FindElement(cartButton).Click();
        }
    }
    
}
