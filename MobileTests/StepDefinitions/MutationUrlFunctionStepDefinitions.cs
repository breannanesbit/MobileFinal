using Mobile_final;
using Mobile_final.Services;
using Mobile_final.ViewModels;
using Moq;
using Shared;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using NUnit.Framework;


namespace MobileTests.StepDefinitions
{
    [Binding]
    public class MutationUrlFunctionStepDefinitions
    {
        Media media;

        [Given(@"a media with ID (.*), media key ""([^""]*)"", and category ID (.*)")]
        public void GivenAMediaWithIDMediaKeyAndCategoryID(int p0, string p1, int p2)
        {
            media = new Media
            {
                Id = p0,
                MediaKey = p1,
                CategoryId = p2
            };
        }

        [When(@"the MutationUrl function is called on the media")]
        public void WhenTheMutationUrlFunctionIsCalledOnTheMedia()
        {
            HttpClient cli = new HttpClient();
            var userservice = new Mock<IUserService>();
            var navservice = new Mock<INavigationService>();
            var profilevm = new ProfileViewModel(cli,userservice.Object,navservice.Object);
            profilevm.MutateUrl(media);
        }

        [Then(@"the media key should be ""([^""]*)""")]
        public void ThenTheMediaKeyShouldBe(string p0)
        {
            Assert.AreEqual(p0, media.MediaKey);
        }
    }
}
