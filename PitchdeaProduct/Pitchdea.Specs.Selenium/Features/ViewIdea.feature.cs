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
    [NUnit.Framework.DescriptionAttribute("View idea")]
    public partial class ViewIdeaFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ViewIdea.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "View idea", "User views an idea", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 4
#line 5
 testRunner.Given("\"idea\" table is empty at first", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
  testRunner.And("\"user\" table is empty at first", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Idea is viewed")]
        [NUnit.Framework.TestCaseAttribute("My Idea.", "ÄÖ \"teksti\" #¤ £$€", "I am a PH.D. in neuroscience and I would like to found a parrot talk clinic.", "This is a question?", null)]
        [NUnit.Framework.TestCaseAttribute("GREAT IDEA!", "0123456789", "More NUMBERS for fun 123123", "Is this a question?", null)]
        [NUnit.Framework.TestCaseAttribute("So-Good-Idea?", "Virtual PIANO lessons `?=)(/&%¤#\"!@£$€{[]} \\ ~*\'^ <>", "weird characters on label `?=)(/&%¤#\"!@£$€{[]} \\ ~*\'^ <>", "Really?", null)]
        public virtual void IdeaIsViewed(string titlelabel, string summarylabel, string descriptionlabel, string questionLabel, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Idea is viewed", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 9
 testRunner.Given(string.Format("an idea exists with values: \"{0}\",\"{1}\",\"{2}\",\"{3}\" and the page for that idea is" +
                        " open.", titlelabel, summarylabel, descriptionlabel, questionLabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.Then(string.Format("page title is \"{0}\" followed by \" | Pitchdea\"", titlelabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
  testRunner.And(string.Format("\"MainContent_titleLabel\" field value is \"{0}\"", titlelabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("shown image is \"http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.And(string.Format("\"MainContent_summaryLabel\" field value is \"{0}\"", summarylabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And(string.Format("\"MainContent_descriptionLabel\" field value is \"{0}\"", descriptionlabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And(string.Format("\"MainContent_questionLabel\" field value is \"{0}\"", questionLabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
  testRunner.And("\"MainContent_ideaOwner\" field value is \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Idea with image is viewed")]
        [NUnit.Framework.TestCaseAttribute("My Idea.", "ÄÖ \"teksti\" #¤ £$€", "I am a PH.D. in neuroscience and I would like to found a parrot talk clinic.", "This is a question?", null)]
        public virtual void IdeaWithImageIsViewed(string titlelabel, string summarylabel, string descriptionlabel, string questionLabel, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Idea with image is viewed", exampleTags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 27
 testRunner.Given(string.Format("an idea with image exists with values: \"{0}\",\"testImage.jpg\",\"{1}\",\"{2}\",\"{3}\" an" +
                        "d the page for that idea is open.", titlelabel, summarylabel, descriptionlabel, questionLabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.Then(string.Format("page title is \"{0}\" followed by \" | Pitchdea\"", titlelabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
  testRunner.And(string.Format("\"MainContent_titleLabel\" field value is \"{0}\"", titlelabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
  testRunner.And("shown image is \"http://localhost:28231//img/ideaImages/testImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
  testRunner.And(string.Format("\"MainContent_summaryLabel\" field value is \"{0}\"", summarylabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And(string.Format("\"MainContent_descriptionLabel\" field value is \"{0}\"", descriptionlabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
  testRunner.And(string.Format("\"MainContent_questionLabel\" field value is \"{0}\"", questionLabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.And("\"MainContent_ideaOwner\" field value is \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Trying to open a non existing idea")]
        public virtual void TryingToOpenANonExistingIdea()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to open a non existing idea", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 42
 testRunner.Given("page \"/viewIdeaPage.aspx?ID=hash123=\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
 testRunner.Then("\"Return to main page.\" link should be on the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
