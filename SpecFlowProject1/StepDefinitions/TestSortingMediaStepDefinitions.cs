using Mobile_final.Services;
using Mobile_final.ViewModels;
using Moq;
using NUnit.Framework;
using Shared;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class TestSortingMediaStepDefinitions
    {
        private List<Media> latestMediaList;
        private List<User> userList;
        private ObservableCollection<Media> videoList;
        private ObservableCollection<Media> audioList;
        private ObservableCollection<Media> visualList;

        [Given(@"a latest media list with the following items:")]
        public void GivenALatestMediaListWithTheFollowingItems(Table table)
        {
            latestMediaList = table.CreateSet<Media>().ToList();
        }

        [Given(@"a user list with the following items:")]
        public void GivenAUserListWithTheFollowingItems(Table table)
        {
            userList = table.CreateSet<User>().ToList();
        }

        [Given(@"empty video, audio, and visual lists")]
        public void GivenEmptyVideoAudioAndVisualLists()
        {
            videoList = new ObservableCollection<Media>();
            audioList = new ObservableCollection<Media>();
            visualList = new ObservableCollection<Media>();
        }

        [When(@"sorting the media into the video, audio, and visual lists")]
        public void WhenSortingTheMediaIntoTheVideoAudioAndVisualLists()
        {

            var userServiceMock = new Mock<UserService>();

            var homeMediaViewModel = new HomeMediaViewModel(userServiceMock.Object);
            homeMediaViewModel.SortMediaIntoLists(latestMediaList, userList, videoList, audioList, visualList);
        }

        [Then(@"the video list should contain the following items:")]
        public void ThenTheVideoListShouldContainTheFollowingItems(Table table)
        {
            var expectedVideoList = table.CreateSet<Media>().ToList();
            CollectionAssert.AreEqual(expectedVideoList, videoList.ToList());
        }

        [Then(@"the audio list should contain the following items:")]
        public void ThenTheAudioListShouldContainTheFollowingItems(Table table)
        {
            var expectedAudioList = table.CreateSet<Media>().ToList();
            CollectionAssert.AreEqual(expectedAudioList, audioList.ToList());
        }

        [Then(@"the visual list should contain the following items:")]
        public void ThenTheVisualListShouldContainTheFollowingItems(Table table)
        {
            var expectedVisualList = table.CreateSet<Media>().ToList();
            CollectionAssert.AreEqual(expectedVisualList, visualList.ToList());
        }
    }
}
