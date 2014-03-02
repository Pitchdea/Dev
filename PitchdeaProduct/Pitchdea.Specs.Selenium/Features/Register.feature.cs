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
                    "e steps I will be given access to the site", ProgrammingLanguage.CSharp, ((string[])(null)));
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
  testRunner.And("page \"/RegisterPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User registers succesfully by clicking")]
        public virtual void UserRegistersSuccesfullyByClicking()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User registers succesfully by clicking", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 13
 testRunner.When("I fill email field with \"test1@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
  testRunner.And("I fill the username field with \"mikko\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And("I fill the password field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.And("I fill password confirmation field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
  testRunner.And("I click register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.Then("page \"/mainPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
  testRunner.And("I am logged in as \"test@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User registers succesfully with Enter")]
        public virtual void UserRegistersSuccesfullyWithEnter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User registers succesfully with Enter", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 24
 testRunner.When("I fill email field with \"test1@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.And("I fill the username field with \"mikko\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
  testRunner.And("I fill the password field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
  testRunner.And("I fill password confirmation field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
  testRunner.And("I hit enter key while password confirmation field is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("page \"/mainPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
  testRunner.And("I am logged in as \"test@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Email already exists in database")]
        public virtual void EmailAlreadyExistsInDatabase()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email already exists in database", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 36
 testRunner.Given("user with email \"test@pitchdea.com\" exists in the database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.When("I fill email field with \"test@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
  testRunner.And("I fill the username field with \"mikko\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("I fill the password field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("I fill password confirmation field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.And("I click register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.Then("page \"/RegisterPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
  testRunner.And("I see \"Oops! That email is already in use\" error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Username already exists in database")]
        public virtual void UsernameAlreadyExistsInDatabase()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Username already exists in database", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 48
 testRunner.Given("user with username \"test\" is exists in the database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.When("I fill email field with \"test1@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
  testRunner.And("I fill the username field with \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
  testRunner.And("I fill the password field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And("I fill password confirmation field with \"passu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
  testRunner.And("I click register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.Then("page \"/RegisterPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
  testRunner.And("I see \"Oops! That username has already been taken\" error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "passu", "salasana", "The passowrds do not match.", null)]
        [NUnit.Framework.TestCaseAttribute("test1@pitchdea.com", "mikko", "passu", "", "The passwords do not match.", null)]
        public virtual void UserFillsInvalidCredentialsClicksGetsErrorMessageAndIsNotRegistered_(string email, string username, string password, string confpass, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User fills invalid credentials, clicks, gets error message and is not registered." +
                    "", exampleTags);
#line 58
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 60
 testRunner.When(string.Format("I fill email field with \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
  testRunner.And(string.Format("I fill username field with \"{0}\"", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
  testRunner.And(string.Format("I fill password field with \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.And(string.Format("I fill password confirmation field with \"{0}\"", confpass), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.And("I click register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("page \"/RegisterPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
  testRunner.And(string.Format("I see \"{0}\" error message", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
