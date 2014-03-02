﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34011
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pitchdea.Specs.Selenium.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Register")]
    public partial class RegisterFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Register.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Register", "I open the register page and fill the required credentials\r\nAfter completing thos" +
                    "e steps I will be given access to the site and sent a confirmation email", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("\"user\" table is empty at first", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
  testRunner.And("register page \"/RegisterPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Email already exists in database")]
        public virtual void EmailAlreadyExistsInDatabase()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email already exists in database", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 12
  testRunner.And("email address \"test@pitchdea.com\" exists in the database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I enter \"test@pitchdea.com\" as email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
  testRunner.And("click \"Maincontent_registerButton\" register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then("I get \"<errorMessage>\" error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Username already exists in database")]
        public virtual void UsernameAlreadyExistsInDatabase()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Username already exists in database", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 24
 testRunner.When("I enter \"test\" in \"Maincontent_usernameTextBox\" username field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.And("I hit enter key while \"Maincontent_passwordConfirmationTextBox\" password confirma" +
                    "tion field is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("I get \"<errorMessage>\" error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User fills valid credentials, is logged in by clicking and gets notification emai" +
            "l.")]
        [NUnit.Framework.TestCaseAttribute("käyttäjä1", "kayttaja@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("user5", "user@gmail.com", null)]
        public virtual void UserFillsValidCredentialsIsLoggedInByClickingAndGetsNotificationEmail_(string username, string email, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User fills valid credentials, is logged in by clicking and gets notification emai" +
                    "l.", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 35
 testRunner.When(string.Format("I fill email field \"Maincontent_emailTextBox\" with \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
  testRunner.And(string.Format("fill the username field \"Maincontent_usernameTextBox\" with \"{0}\"", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
  testRunner.And("fill the password field \"Maincontent_passwordTextBox\" with password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
  testRunner.And("fill confirmation field \"Maincontent_passwordConfirmationTextBox\" with password c" +
                    "onfirmation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("click \"Maincontent_registerButton\" register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then(string.Format("I am logged in with my email address \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User fills valid credentials, is logged in by pressing enter and gets notificatio" +
            "n email.")]
        [NUnit.Framework.TestCaseAttribute("käyttäjä1", "kayttaja@hotmail.com", null)]
        [NUnit.Framework.TestCaseAttribute("user5", "user@gmail.com", null)]
        public virtual void UserFillsValidCredentialsIsLoggedInByPressingEnterAndGetsNotificationEmail_(string username, string email, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User fills valid credentials, is logged in by pressing enter and gets notificatio" +
                    "n email.", exampleTags);
#line 49
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 51
 testRunner.When(string.Format("I fill email field \"Maincontent_emailTextBox\" with \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
  testRunner.And(string.Format("fil username field \"Maincontent_usernameTextBox\" with \"{0}\"", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
  testRunner.And("fill password field \"Maincontent_passwordTextBox\" with password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
  testRunner.And("fill password confirmation field \"\"Maincontent_passwordConfirmationTextBox\" with " +
                    "password confirmation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
  testRunner.And("hit enter key while \"Maincontent_passwordConfirmationTextBox\" password confirmati" +
                    "on field is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then(string.Format("I am logged in with  my email address \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User fills invalid credentials, clicks, gets error message and is not registered." +
            "")]
        [NUnit.Framework.TestCaseAttribute("", "mikko", "passu", "passu", "You forgot to type an email.", null)]
        [NUnit.Framework.TestCaseAttribute("not an email address", "mikko", "passu", "passu", "This doesn\'t seem to be an email address.", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "", "", "You forgot to type a password.", null)]
        [NUnit.Framework.TestCaseAttribute("testi1@pitchea.com", "", "passu", "passu", "You forgot to type a username", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "passu", "salasana", "password and password confirmation do not match.", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "passu", "", "password and password confirmation do not match.", null)]
        public virtual void UserFillsInvalidCredentialsClicksGetsErrorMessageAndIsNotRegistered_(string email, string username, string password, string confpass, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User fills invalid credentials, clicks, gets error message and is not registered." +
                    "", exampleTags);
#line 64
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 66
 testRunner.When(string.Format("I fill email field \"Maincontent_emailTextBox\" with email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
  testRunner.And(string.Format("fill username field \"Maincontent_usernameTextBox\" with username \"{0}\"", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.And("fill password field \"Maincontent_passwordTextBox\" with password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
  testRunner.And("fill password confirmation field \"Maincontent_passwordConfirmationTextBox\" with p" +
                    "assword confirmation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.And("click \"Maincontent_registerButton\" register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.Then(string.Format("I get \"{0}\" error message", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
  testRunner.And("I am not logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User fills invalid credentials, hits enter, gets error message and is not registe" +
            "red.")]
        [NUnit.Framework.TestCaseAttribute("", "mikko", "passu", "passu", "You forgot to type an email.", null)]
        [NUnit.Framework.TestCaseAttribute("not an email address", "mikko", "passu", "passu", "This doesn\'t seem to be an email address.", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "", "", "You forgot to type a password.", null)]
        [NUnit.Framework.TestCaseAttribute("testi1@pitchea.com", "", "passu", "passu", "You forgot to type a username", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "passu", "salasana", "password and password confirmation do not match.", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "passu", "", "password and password confirmation do not match.", null)]
        public virtual void UserFillsInvalidCredentialsHitsEnterGetsErrorMessageAndIsNotRegistered_(string email, string username, string password, string confpass, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User fills invalid credentials, hits enter, gets error message and is not registe" +
                    "red.", exampleTags);
#line 85
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 87
 testRunner.When(string.Format("I fill email field \"Maincontent_emailTextBox\" with \"{0}\" email address", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
  testRunner.And(string.Format("fill username field \"Maincontent_usernameTextBox\" with \"{0}\" username", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
  testRunner.And(string.Format("fill password field \"Maincontent_passwordTextBox\" with \"{0}\" password", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
  testRunner.And(string.Format("fill password confirmation field \"Maincontent_passwordConfirmationTextBox\" \"{0}\" " +
                        "password confirmation", confpass), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
  testRunner.And("hit enter key while \"Maincontent_passwordConfirmationTextBox\" field is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.Then(string.Format("I get \"{0}\" error message", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
  testRunner.And("I am not logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
