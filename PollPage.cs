using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace PageObjects
{
    class PollPage
    {
        private const string Continue = "ps-input-submit";
        private const string Submit = "ps-vote-button";
        private const string Result = "result-continue-button";

        private IWebDriver driver;

        public PollPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // safer to find element by Id, maybe multiple instances in HTML with this classname
        private IWebElement SubmitButton { get { return driver.FindElement(By.ClassName(Submit)); } }
        private IWebElement ContinueButton { get { return driver.FindElement(By.ClassName(Continue)); } }
        private IWebElement ResultContinueButton { get { return driver.FindElement(By.ClassName(Result)); } }
     
        // for the question types, should probably pass in a variable instead of hard-coding the element so all polls/surveys/forms using these question types can use these 
        private IWebElement GetSingleRadioQuestion()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver.FindElement(By.Id("question-79364"));
        }

        public IWebElement GetRadioDropDownQuestion() { return driver.FindElement(By.Id("answer_id")); }
        public IWebElement GetSingleRadioImageQuestion() { return driver.FindElement(By.Id("ps_answer_PSPoll_268831")); }
        public IWebElement GetRatingRadioQuestion() { return driver.FindElement(By.Id("question-79368")); }
        public IWebElement GetRatingRadioWithNaQuestion() { return driver.FindElement(By.Id("question-79371")); }
        public IWebElement GetRatingDropdownQuestion() { return driver.FindElement(By.Id("question-79370")); }
        public IWebElement GetRatingDropdownNaQuestion() { return driver.FindElement(By.Id("question-79369")); }

        public IWebElement GetDropdownQuestion(string id) { return driver.FindElement(By.Id(id));  } 

        public void SelectSingleRadio()
        {
            GetSingleRadioQuestion().FindElement(By.Id("ps_answer_PSPoll_268840")).Click();
        }

        public void SelectRadioDropDown()
        {
            {
                SelectDropdown(GetRadioDropDownQuestion(), "option[value=':268838|1'");
            }
        }

        public void SelectRadioImage()
        {
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.Id("ps_answer_PSPoll_268831"))).Click().Perform();
            }
        }

        // Radio questions are the same, whether or not NA is included.  I separated them just in case there was a scenario where N/A had to be chosen.
        // Could possibly pass in a boolean in the method to show whether n/a is included or not and adjust method accordingly
        public void SelectRatingRadio(IWebElement radioQuestion)
        {
            SelectRating(GetRatingRadioQuestion(), "ps_answer_PSPoll_268852-3");
            SelectRating(GetRatingRadioQuestion(), "ps_answer_PSPoll_268853-6");
            SelectRating(GetRatingRadioQuestion(), "ps_answer_PSPoll_268854-10");
            SelectRating(GetRatingRadioQuestion(), "ps_answer_PSPoll_268855-1");
        }
        
        public void SelectRatingRadioNa(IWebElement radioNaQuestion)
        {
            SelectRating(GetRatingRadioWithNaQuestion(), "ps_answer_PSPoll_268864-na");
            SelectRating(GetRatingRadioWithNaQuestion(), "ps_answer_PSPoll_268865-na");
            SelectRating(GetRatingRadioWithNaQuestion(), "ps_answer_PSPoll_268866-na");
            SelectRating(GetRatingRadioWithNaQuestion(), "ps_answer_PSPoll_268867-na");
        }

        // Rating dropdown questions are the same,  whether or not NA is included.  I separated them just in case there was a scenario where N/A had to be chosen.
        // Could possibly pass in a boolean in the method to show whether n/a is included or not and adjust method accordingly
        public void SelectRatingDropdown (IWebElement ratingQuestion)
        {
            SelectDropdown(GetRatingDropdownQuestion(), "option[value=':268860|1:1'");
            SelectDropdown(GetRatingDropdownQuestion(), "option[value=':268861|1:2'");
            SelectDropdown(GetRatingDropdownQuestion(), "option[value=':268862|1:3'");
            SelectDropdown(GetRatingDropdownQuestion(), "option[value=':268863|1:4'");
        }

        public void SelectRatingDropdownNa (IWebElement ratingNaQuestion)
        {
            SelectDropdown(GetRatingDropdownNaQuestion(), "option[value=':268856|1:1'");
            SelectDropdown(GetRatingDropdownNaQuestion(), "option[value=':268857|1:2'");
            SelectDropdown(GetRatingDropdownNaQuestion(), "option[value=':268858|1:3'");
            SelectDropdown(GetRatingDropdownNaQuestion(), "option[value=':268859|1:5'");
        }

        public void SubmitButtonClick()
        {
            SubmitButton.Click();
        }

        public void ContinueButtonClick()
        {
            ContinueButton.Click();
        }

        public void ResultContinueButtonClick()
        {
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    ResultContinueButton.Click();
                    staleElement = false;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
        }

        private void SelectRating(IWebElement question, string rating)
        {
            question.FindElement(By.Id(rating)).Click();
        }

        private void SelectDropdown(IWebElement question, string option)
        {
            question.FindElement(By.CssSelector(option)).Click();
        }
       
    }
}
