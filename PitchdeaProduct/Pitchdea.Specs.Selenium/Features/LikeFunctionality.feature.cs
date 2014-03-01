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
    [NUnit.Framework.DescriptionAttribute("Like functionality")]
    public partial class LikeFunctionalityFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LikeFunctionality.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Like functionality", "User can like and dislike ideas, except their own. The amount of likes is shown o" +
                    "n the viewidea page.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User opens an idea and likes it")]
        public virtual void UserOpensAnIdeaAndLikesIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User opens an idea and likes it", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 10
testRunner.Given("\"Maincontent_LikeInfoLabel\" field value is \"You can like this idea below\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
testRunner.When("the user clicks the \"Maincontent_LikeIdeaButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("\"Maincontent_VoteValueLabel\" field value is \"You gave this idea +1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And("\"Maincontent_LikeCountLabel\" field value is increased by 1 point", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User opens an idea and dislikes it")]
        public virtual void UserOpensAnIdeaAndDislikesIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User opens an idea and dislikes it", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 17
testRunner.When("the user clicks the \"Maincontent_DislikeButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("\"Maincontent_LikeInfoLabel\" field value is \"You gave this idea -1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("\"Maincontent_LikeCountLabel\" field value is decreased by 1 point", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User opens and idea which he has already liked and tries to like again")]
        public virtual void UserOpensAndIdeaWhichHeHasAlreadyLikedAndTriesToLikeAgain()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User opens and idea which he has already liked and tries to like again", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 23
testRunner.Given("User opens and idea he has already liked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
testRunner.And("\"Maincontent_LikeInfoLabel\" field value is \"You gave this idea +1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("\"Maincontent_DislikeButton\" button is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("\"Maincontent_LikeButton\" button is enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User opens and idea which he has already disliked and tries to dislike again")]
        public virtual void UserOpensAndIdeaWhichHeHasAlreadyDislikedAndTriesToDislikeAgain()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User opens and idea which he has already disliked and tries to dislike again", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 30
testRunner.Given("User opens and idea he has already disliked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
testRunner.And("\"Maincontent_LikeInfoLabel\" field value is \"You gave this idea -1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("\"Maincontent_DislikeButton\" button is enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("\"Maincontent_LikeButton\" button is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User opens and idea which he has already liked and dislikes it")]
        public virtual void UserOpensAndIdeaWhichHeHasAlreadyLikedAndDislikesIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User opens and idea which he has already liked and dislikes it", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 38
testRunner.When("the user clicks the \"Maincontent_DislikeIdeaButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("\"Maincontent_VoteValueLabel\" field is changed to \"You gave this idea -1 point\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("\"Maincontent_LikeCountLabel\" field value is decreased by 1 point", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User opens their own idea")]
        public virtual void UserOpensTheirOwnIdea()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User opens their own idea", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 43
testRunner.When("user opens their own idea", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("\"Maincontent_LikeButton\" button is disabled and \"Maincontent_DislikeButton\" butto" +
                    "n is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
