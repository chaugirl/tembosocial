using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;
using System;

namespace Task2
{
    public class MyFirstTask
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void myFirstTest()
        {
            
            driver.Navigate().GoToUrl("https://stage1-vote.pollstream.com/8610");

            // Message page
            PollPage pollPage1 = new PollPage(driver);
            pollPage1.ContinueButtonClick();

            PollPage pollPage2 = new PollPage(driver);
            // Q1
            pollPage2.SelectSingleRadio();
            //Q2
            pollPage2.SelectRadioDropDown();
            //Q3
            pollPage2.SelectRadioImage(); 
            pollPage2.SubmitButtonClick();

            //Results page
            PollPage pollPage3 = new PollPage(driver);
            pollPage3.ResultContinueButtonClick();

            // Q4 - Q5
            PollPage pollPage4 = new PollPage(driver);
            pollPage4.SubmitButtonClick();

            //Results page
            PollPage pollPage5 = new PollPage(driver);
            pollPage5.ResultContinueButtonClick();

            PollPage pollPage6 = new PollPage(driver);
            // Q6
            IWebElement RatingRadioQuestion = pollPage6.GetRatingRadioQuestion();
            pollPage6.SelectRatingRadio(RatingRadioQuestion);
            // Q7
            IWebElement RatingRadioNAQuestion = pollPage6.GetRatingRadioWithNaQuestion();
            pollPage6.SelectRatingRadioNa(RatingRadioNAQuestion);
            // Q8
            IWebElement RatingDropdownQuestion = pollPage6.GetRatingDropdownQuestion();
            pollPage6.SelectRatingDropdown(RatingDropdownQuestion);
            // Q9
            IWebElement RatingDropdownNaQuestion = pollPage6.GetRatingDropdownNaQuestion();
            pollPage6.SelectRatingDropdownNa(RatingDropdownNaQuestion);
            pollPage6.SubmitButtonClick();

            // Results page
            PollPage pollPage7 = new PollPage(driver);
            pollPage7.ResultContinueButtonClick();

            PollPage pollPage8 = new PollPage(driver);
            // Q10
            pollPage8.ContinueButtonClick();

            // Results page
            PollPage pollPage9 = new PollPage(driver);
            pollPage9.ResultContinueButtonClick();

            PollPage pollPage10 = new PollPage(driver);
            // Q11
            pollPage10.ContinueButtonClick();

            //Results page
            PollPage pollPage11 = new PollPage(driver);
            pollPage11.ResultContinueButtonClick();

            PollPage pollPage12 = new PollPage(driver);
            var acknowledgementMessage = driver.FindElement(By.ClassName("ps-acknowledgement"));
            Assert.That(acknowledgementMessage.Displayed, "Acknowledgement message is not being displayed");
            Assert.AreEqual("a really short message -thanks", acknowledgementMessage.Text);
        }
    }
}
