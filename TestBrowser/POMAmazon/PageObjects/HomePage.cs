using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

/******************************************************************************************
 * Class : HomePage
 * Function : class to control the screen below the navigation menu
 *****************************************************************************************/

namespace POMAmazon.PageObjects
{
    public class HomePage : NavegationPage
    {
        #region Object properties
        private static By itemListed = By.ClassName("s-image");
        private static By addToCart = By.Id("add-to-cart-button");
        private static By itemTitle = By.TagName("H2");
        private static By bladeSideSheet = By.Id("attach-close_sideSheet-link");
        #endregion

        /// <summary>
        /// Constructor by driver
        /// </summary>
        /// <param name="driver"></param>
        public HomePage(IWebDriver driver)
        {
           this.driver = driver;
        }

        /// <summary>
        /// Method for select first element in listed view
        /// </summary>
        /// <returns> first item title </returns>
        public string SelectFristItem()
        {
           try
           {
                IEnumerable<IWebElement> itemList = driver.FindElements(itemTitle);
                string itemName = itemList.First().Text;
                driver.FindElements(itemListed).First().Click();

                return itemName;
            }
            catch (Exception ex)
            {
                throw new Exception("Item list is empty.", ex.InnerException);
            }
            
        }

        /// <summary>
        /// Method for add a item to cart
        /// </summary>
        public void AddToCart()
        {
            driver.FindElement(addToCart).Click();
            CloseSideSheet();
        }

        /// <summary>
        /// Method for validate if a item is at cart
        /// </summary>
        /// <param name="itemName"> Item title to validate </param>
        /// <returns> True if element is displayed </returns>
        public bool ValidateItemCart(string itemName)
        {
            try
            {
                IWebElement item = driver.FindElement(By.LinkText(itemName));
                return item.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverTimeoutException("Item is not in the cart", ex.InnerException) ;
            }
        }

        /// <summary>
        /// Method for close side sheet screen when it is displayed
        /// </summary>
        private void CloseSideSheet()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.SIDE_SHEET_WAIT));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bladeSideSheet));
                if (element.Displayed)
                {
                    element.Click();
                    //the side sheet closes slowly
                    Thread.Sleep(Constants.SIDE_SHEET_CLOSED);
                }
            }
            catch (WebDriverTimeoutException)
            {
                //Ignore when element does not exist
            }
        }
    }

}
