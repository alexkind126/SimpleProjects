        private string SEARCH_FOR_PEACH = "peaches";

        [Test]
        public void loginTwitterThenSearch()
        {
            driver.Navigate().GoToUrl("https://twitter.com/i/flow/login");
            System.Threading.Thread.Sleep(5000);


            // Create an instance of WebDriverWait
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement nextButton = wait3.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layers']/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[6]")));


            // Find the username textbox and enter your username
            IWebElement usernameTextbox = driver.FindElement(By.Name("text"));
            usernameTextbox.SendKeys("cont_alexandru");

  
            System.Threading.Thread.Sleep(2000);
            // Click on the button
            nextButton.Click();
            System.Threading.Thread.Sleep(3000);


            // Find the password textbox and enter your password
            IWebElement passwordTextbox = driver.FindElement(By.Name("password"));
            passwordTextbox.SendKeys("password");


            // Click the login button
            IWebElement loginButton = driver.FindElement(By.CssSelector("[data-testid='LoginForm_Login_Button']"));
            loginButton.Click();
            System.Threading.Thread.Sleep(3000);


            driver.Navigate().GoToUrl("https://twitter.com/explore");
            System.Threading.Thread.Sleep(3000);
            IWebElement searchTextbox = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div/div/div/form/div[1]/div/div/div/label/div[2]/div/input"));

            searchTextbox.SendKeys(SEARCH_FOR_PEACH);
            searchTextbox.SendKeys(Keys.Enter);
            //searchTextbox.Click();
            System.Threading.Thread.Sleep(999999);
        }

        //don't have a TWITTER API so I used Selenium.WebDriver + Twitter API is wirth money now, don't have a subscription
        //will search for peaches, with more than an house at my disposal maybe I would have used the advanced feature to display only
        //tweets with pictures which I have lots of