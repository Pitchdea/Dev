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
    [NUnit.Framework.DescriptionAttribute("EditIdea")]
    public partial class EditIdeaFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EditIdea.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EditIdea", "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 3
#line 4
 testRunner.Given("test database is empty at first", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
  testRunner.And("user is logged in (with password) as \"test\" with password \"password123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
  testRunner.And("an idea submitted by \"test\" with password \"password123\"  exists with values: \"tit" +
                    "le1\",\"summary1\",\"description1\",\"question1\" and the page for that idea is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.Then("page title is \"title1\" followed by \" | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.When("I press edit idea button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("edit page for \"title1\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
  testRunner.And("shown image is \"http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.And("editable idea title is \"title1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("editable idea summary is \"summary1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.And("editable idea description is \"description1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And("editable idea question is \"question1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open edit page and overwrite idea values")]
        public virtual void OpenEditPageAndOverwriteIdeaValues()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open edit page and overwrite idea values", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 18
 testRunner.When("I edit idea title to \"Another title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
  testRunner.And("I edit idea summary to \"Something else.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.And("I edit idea description to \"Something totally else.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
  testRunner.And("I edit idea question to \"Another question?\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("I press submit changes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("page title is \"Another title\" followed by \" | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
  testRunner.And("shown image is \"http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
  testRunner.And("idea title is \"Another title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
  testRunner.And("idea summary is \"Something else.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
  testRunner.And("idea description is \"Something totally else.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
  testRunner.And("idea question is \"Another question?\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
  testRunner.And("idea owner is \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open edit page and extend idea values")]
        public virtual void OpenEditPageAndExtendIdeaValues()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open edit page and extend idea values", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 34
 testRunner.When("I extend idea title with \" Another title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 35
  testRunner.And("I extend idea summary with", "\r\nSomething else.", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
  testRunner.And("I extend idea description with", "\r\nSomething totally else.", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
  testRunner.And("I extend idea question with", "\r\nAnother question?", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
  testRunner.And("I press submit changes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("page title is \"title Another title\" followed by \" | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
  testRunner.And("shown image is \"http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
  testRunner.And("idea title is \"title Another title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
  testRunner.And("idea summary is", "summary\r\n\r\nSomething else.", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
  testRunner.And("idea description is", "description\r\n\r\nSomething totally else.", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
  testRunner.And("idea question is", "question\r\n\r\nAnother question?", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
  testRunner.And("idea owner is \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open edit page and upload a new image")]
        public virtual void OpenEditPageAndUploadANewImage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open edit page and upload a new image", ((string[])(null)));
#line 75
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 77
 testRunner.When("I choose to upload a picture \"testImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
  testRunner.And("I click upload image button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
  testRunner.And("I click done button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
  testRunner.And("I press submit changes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.Then("page title is \"title1\" followed by \" | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
  testRunner.And("shown image is not \"http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And("idea title is \"title1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
  testRunner.And("idea summary is \"summary1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.And("idea description is \"description1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
  testRunner.And("idea question is \"question1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
  testRunner.And("idea owner is \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open edit page and change to default image")]
        public virtual void OpenEditPageAndChangeToDefaultImage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open edit page and change to default image", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 92
 testRunner.Given("an idea submitted by \"test\" with password \"password123\" with image exists with va" +
                    "lues: \"titlelabel1\",\"testImage.jpg\",\"summarylabel1\",\"descriptionlabel1\",\"questio" +
                    "nLabel1\" and the page for that idea is open.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.Then("page title is \"title1\" followed by \" | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
 testRunner.When("I press edit idea button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.Then("edit page for \"title1\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
  testRunner.And("shown image is \"http://localhost:28231/img/ideaImages/testImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.When("I press use default picture button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.Then("shown image is \"http://localhost:28231/img/ideaImages/uploaded/testImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.When("I press submit changes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("page title is \"title Another title\" followed by \" | Pitchdea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.And("shown image is \"http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
  testRunner.And("idea title is \"title Another title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
  testRunner.And("idea summary is \"summary Something else.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.And("idea description is \"description Something totally else.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
  testRunner.And("idea question is \"question Another question?\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
  testRunner.And("idea owner is \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
