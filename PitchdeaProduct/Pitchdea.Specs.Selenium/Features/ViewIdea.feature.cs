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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Idea is created then viewed")]
        [NUnit.Framework.TestCaseAttribute("My Idea.", "ÄÖ \"teksti\" #¤ £$€", "I am a PH.D. in neuroscience and I would like to found a parrot talk clinic.", null)]
        [NUnit.Framework.TestCaseAttribute("GREAT IDEA!", "0123456789", "More NUMBERS for fun 123123", null)]
        [NUnit.Framework.TestCaseAttribute("So-Good-Idea?", "Virtual PIANO lessons `?=)(/&%¤#\"!@£$€{[]} \\ ~*\'^ <>", "weird characters on label `?=)(/&%¤#\"!@£$€{[]} \\ ~*\'^ <>", null)]
        [NUnit.Framework.TestCaseAttribute("this_is_title", "this_is_summary .", "this is\\r\n\\  multiline \\r\n\\text", null)]
        public virtual void IdeaIsCreatedThenViewed(string titlelabel, string summarylabel, string descriptionlabel, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Idea is created then viewed", exampleTags);
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("an idea exists with values: \"<titleLabel>\",\"<summaryLabel>\",\"<desrcriptionLabel>\"" +
                    " and the page for that idea is open.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.Then("title is \"<titleLabel> | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 7
  testRunner.And("\"MainContent_titleLabel\" field value is \"<titleLabel>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
  testRunner.And(string.Format("\"MainContent_summaryLabel\" field value is \"{0}\"", summarylabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
  testRunner.And(string.Format("\"MainContent_descriptionLabel\" field value is \"{0}\"", titlelabel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
