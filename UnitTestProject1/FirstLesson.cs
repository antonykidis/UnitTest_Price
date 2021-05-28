using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace test1021
{
    [TestClass]
    public class FirstLesson
    {
      

        //Exercise #1
        //1 Open website
        [TestMethod]
        public void LoginTest()
        {
            //test login button
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://automationpractice.com";
            IWebElement signIn = driver.FindElement(By.ClassName("login"));
            signIn.Click();


            //test Email
            IWebElement Email = driver.FindElement(By.Id("email"));
            Email.SendKeys("Antony.kidis1@gmail.com");

            //Test Password
            IWebElement Password = driver.FindElement(By.Id("passwd"));
            Password.SendKeys("Automation@123");

            //Click Sign-In button
            IWebElement SubmitButton = driver.FindElement(By.Id("SubmitLogin"));
            SubmitButton.Click();


            //test Name-Autentication
            IWebElement AutenticationDiv = driver.FindElement(By.Id("center_column"));
            AutenticationDiv.FindElement(By.ClassName("page-heading"));

            Assert.AreEqual(AutenticationDiv.Text, "MY ACCOUNT", "IsNot matched");
        }


        //Registration 1
        [TestMethod]
        public void FirstSelenium()
        {
            //test login button
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://automationpractice.com";
            IWebElement signIn = driver.FindElement(By.ClassName("login"));
            signIn.Click();

            //test Email
            IWebElement Email = driver.FindElement(By.Id("email_create"));
            Email.SendKeys("ZhuiHui@gmail.com");

            //test Create
            IWebElement CreasteBtn = driver.FindElement(By.Id("SubmitCreate"));
            CreasteBtn.Click();
        }

        //Registration-2
        [TestMethod]
        public void Registration()
        {
            //drive as
            IWebDriver driver = new ChromeDriver();
           
            //Your Personal Information.............................
            //Select Gender Mister
            IWebElement SelectGender_Mr = driver.FindElement(By.Id("id_gender1"));
            SelectGender_Mr.Click();

            //Select Gender Missis
            IWebElement SelectGender_Mrs = driver.FindElement(By.Id("id_gender1"));
            SelectGender_Mrs.Click();

            //Enter FirsName
            IWebElement FirFirstName = driver.FindElement(By.Id("customer_firstname"));
            FirFirstName.SendKeys("John");

            //Enter FirsName
            IWebElement LastName = driver.FindElement(By.Id("customer_lastname"));
            FirFirstName.SendKeys("Travolta");

            //test Email
            IWebElement Email = driver.FindElement(By.Id("email_create"));
            Email.Equals("ZhuiHui@gmail.com");

            //Password
            IWebElement Password = driver.FindElement(By.Id("passwd"));
            Password.SendKeys("Pass@123");





        }

        [TestMethod] //notation the below function must be public
        public void TestSum()
        {
            //send 2+2 to Sum, and verify the result is 4
            int result = Sum(2, 2);
            Assert.AreEqual(4, result); //we put assert in the end of the test!!!
            Assert.AreEqual(4, result,"result is not 4"); //expected is 4
        }

        //test#2
        [TestMethod] //notation the below function must be public
        public void TestSum1()
        {
            Console.WriteLine("start test");
            //send 2+2 to Sum, and verify the result is 4
            int result = Sum(3, 2);
            Console.WriteLine("end test");
            //Assert.AreEqual(4, result);
            Assert.AreEqual(4, result, "result is not 4");
        }


        //Methods..................................
        public int Sum(int a, int b)
        {
            int sum = a + b;
            return sum;

        }

        public int Seven()
        {
            return 7;
        }

        public string FullName(string FirstName, string LastName)
        {
            //Must be readable...
            string Fullname = "Hello" + FirstName + " " + LastName;
            return Fullname;
        }

        public int Sum(int num1, int num2, int num3)
        {
            int sum = num1 + num2 + num3;
            return sum;
        }
            
    }
}
