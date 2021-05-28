using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace FindPriceObjectTestSolution
{
    [TestClass]
    public class UnitTest1
    {
        //global Class member variable
        bool _IsDressFound = false;
        bool _IsPriceCorrect = false;
        bool _isButtonPressed = false;


        /// <summary>
        /// 1.Connects to a website.
        /// 2.Locates Products
        /// 3.Finds Black Blouse(from products)
        /// 4.Verifies the blouse' price
        /// </summary>
        
        [TestMethod]
        public void SelectBlouse_Black_OnPrice()
        {
            IWebDriver driver = new ChromeDriver();                                         //Define IWebDriver driver-object
            driver.Url = "http://automationpractice.com";                                   //Setup URL, and store in driver.Url
            IWebElement CollectionOfULElements = driver.FindElement(By.Id("homefeatured")); //Select UL element that contains nested <li></li> elements

            //Find all elements with a class-name of = "ajax_block_product" inside CollectionOfULElements
            ReadOnlyCollection<IWebElement> dresses = CollectionOfULElements.FindElements(By.ClassName("ajax_block_product"));

            //Once we a have a collection of all <li> elements
            //We can now search for a black dress
            for (int i = 0; i < dresses.Count; i++)
            {
                //Search for a class named: "product-name" in each <li> element inside dresses collection
                //And check wether dresses[i] element are equal to  a search criteria("Blouse")
                IWebElement name = dresses[i].FindElement(By.ClassName("product-name"));

                if (name.Text == "Blouse")
                {
                    _IsDressFound = true;
                    //A match found
                    //Find <span> element that holds the price of "Blouse"
                    IWebElement Price = dresses[i].FindElement(By.ClassName("price"));

                    //Extract text from <span> element
                    string PriceText = Price.GetAttribute("innerText");

                    //Remove \t,\r\n elements from a string
                    string PriceText_Clear = Regex.Replace(PriceText, @"\t|\n|\r", "");

                    //Check the price (Throws expetion in case of fail)
                    Assert.AreEqual("$27.00", PriceText_Clear, "Expected price are not equal to actual price");
                    _IsPriceCorrect = true;

                    //Locate the [Blouse] "add to cart" button
                    IWebElement AddToCartBtn = dresses[i].FindElement(By.ClassName("ajax_add_to_cart_button"));

                    //press the button
                    AddToCartBtn.Click();
                    _isButtonPressed = true;

                    //exit for loop
                    break;
                }

            } //end for...

            //Final Test examination If all true the test  passes, otherwise test fails
            Assert.IsTrue(_IsDressFound, "Dress Element is not found");
            Assert.IsTrue(_IsPriceCorrect, "Price(string) actual, and expected results are not equal");
            Assert.IsTrue(_isButtonPressed, "'Add_to_cart' button element is not found");


        }
    }
}
