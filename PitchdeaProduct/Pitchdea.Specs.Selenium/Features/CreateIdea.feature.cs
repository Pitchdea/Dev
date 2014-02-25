﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
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
    [NUnit.Framework.DescriptionAttribute("Create Idea")]
    public partial class CreateIdeaFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateIdea.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create Idea", "User creates an idea.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("user submits an idea")]
        [NUnit.Framework.TestCaseAttribute("My Idea", "I teach parrots to speak", "I am a ph.d. in neuroscience and I would like to found a parrot talk clinic", null)]
        [NUnit.Framework.TestCaseAttribute("Great Idea", "Chaplin movies with dubbing", "I would like to use my expertise to put romanian dubbing on chaplin movies", null)]
        [NUnit.Framework.TestCaseAttribute("So Good Idea", "Virtual piano lessons", "I am an alcoholic and have too much spare time so I could think I would be a good" +
            " teacher", null)]
        public virtual void UserSubmitsAnIdea(string title, string summary, string description, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("user submits an idea", exampleTags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("page \"/createIdeaPage.aspx\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
  testRunner.And("user is logged in as \"test@pitchdea.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
  testRunner.And(string.Format("\"MainContent_titleTextBox\" field value is \"{0}\"", title), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
  testRunner.And(string.Format("\"MainContent_summaryTextBox\" field value is \"{0}\"", summary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And(string.Format("\"MainContent_descriptionTextBox\" field value is \"{0}\"", description), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("user clicks \"MainContent_createIdeaButton\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then(string.Format("page title is \"{0} | Pitchdea\"", title), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
  testRunner.And(string.Format("\"Maincontent_ideatitle\" value is \"{0}\"", title), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And(string.Format("\"MainContent_summaryTextBox\" value is\"{0}\"", summary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And(string.Format("\"MainContent_descriptionTextBox\" value is \"{0}\"", description), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.And("\"MainContent_statusMessage\" field value is \"Your idea has been created succesfull" +
                    "y!\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
