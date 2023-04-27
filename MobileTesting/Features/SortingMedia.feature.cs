﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MobileTesting.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Test Sorting Media")]
    public partial class TestSortingMediaFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "SortingMedia.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Test Sorting Media", "Sorting the media into different lists", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Media Goes where it should")]
        [NUnit.Framework.CategoryAttribute("tag1")]
        public virtual void MediaGoesWhereItShould()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Media Goes where it should", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "MediaKey",
                            "UserId",
                            "DateUpload",
                            "FileName",
                            "Likes",
                            "CategoryId",
                            "Category"});
                table1.AddRow(new string[] {
                            "1",
                            "video1",
                            "1",
                            "2023-04-20T10:30:00.000Z",
                            "null",
                            "null",
                            "1",
                            "Videos"});
                table1.AddRow(new string[] {
                            "2",
                            "audio1",
                            "2",
                            "2023-04-21T14:00:00.000Z",
                            "null",
                            "null",
                            "2",
                            "Audios"});
                table1.AddRow(new string[] {
                            "3",
                            "picture1",
                            "1",
                            "2023-04-22T16:45:00.000Z",
                            "null",
                            "null",
                            "3",
                            "Pictures"});
#line 7
 testRunner.Given("a latest media list with the following items:", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName",
                            "Username"});
                table2.AddRow(new string[] {
                            "1",
                            "John",
                            "Doe",
                            "johndoe"});
                table2.AddRow(new string[] {
                            "2",
                            "Jane",
                            "Smith",
                            "janesmith"});
#line 12
 testRunner.And("a user list with the following items:", ((string)(null)), table2, "And ");
#line hidden
#line 16
 testRunner.And("empty video, audio, and visual lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.When("sorting the media into the video, audio, and visual lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "MediaKey",
                            "UserId",
                            "DateUpload",
                            "FileName",
                            "Likes",
                            "CategoryId",
                            "Category"});
                table3.AddRow(new string[] {
                            "1",
                            "https://mobilemediastorage.blob.core.windows.net/videos/video1",
                            "1",
                            "2023-04-20T10:30:00.000Z",
                            "null",
                            "null",
                            "1",
                            "Videos"});
#line 18
 testRunner.Then("the video list should contain the following items:", ((string)(null)), table3, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "MediaKey",
                            "UserId",
                            "DateUpload",
                            "FileName",
                            "Likes",
                            "CategoryId",
                            "Category"});
                table4.AddRow(new string[] {
                            "2",
                            "https://mobilemediastorage.blob.core.windows.net/audios/audio1",
                            "2",
                            "2023-04-21T14:00:00.000Z",
                            "null",
                            "null",
                            "2",
                            "Audios"});
#line 21
 testRunner.And("the audio list should contain the following items:", ((string)(null)), table4, "And ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "MediaKey",
                            "UserId",
                            "DateUpload",
                            "FileName",
                            "Likes",
                            "CategoryId",
                            "Category"});
                table5.AddRow(new string[] {
                            "3",
                            "https://mobilemediastorage.blob.core.windows.net/pictures/picture1",
                            "1",
                            "2023-04-22T16:45:00.000Z",
                            "null",
                            "null",
                            "3",
                            "Pictures"});
#line 24
 testRunner.And("the visual list should contain the following items:", ((string)(null)), table5, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
