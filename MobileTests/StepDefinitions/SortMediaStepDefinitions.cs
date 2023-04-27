using Mobile_final.Services;
using Mobile_final.ViewModels;
using Moq;
using NUnit.Framework;
using Shared;
using System;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MobileTests.StepDefinitions
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
           
            var userServiceMock = new Mock<IUserService>();
            var item = userServiceMock.Object;
            var homeMediaViewModel = new HomeMediaViewModel(item);
            homeMediaViewModel.AudioList = audioList;
            homeMediaViewModel.VideoList = videoList;
            homeMediaViewModel.VisualList = visualList;
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
/*
 * 
 * 
 * 
 * [Binding]
public class MediaSortingSteps
{
    private List<User> _userList;
    private List<Media> _latestMediaList;
    private ObservableCollection<Media> _videoList;
    private ObservableCollection<Media> _audioList;
    private ObservableCollection<Media> _visualList;
    private Category _videoCategory;
    private Category _audioCategory;
    private Category _visualCategory;

    [Given(@"a list of users")]
    public void GivenAListOfUsers()
    {
        // create a list of users
        _userList = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe"
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Username = "janedoe"
            }
        };
    }

    [Given(@"a list of latest media")]
    public void GivenAListOfLatestMedia()
    {
        // create a list of latest media
        _latestMediaList = new List<Media>
        {
            new Media
            {
                Id = 1,
                MediaKey = "video1.mp4",
                UserId = 1,
                DateUpload = DateTime.Now,
                Category = _videoCategory
            },
            new Media
            {
                Id = 2,
                MediaKey = "audio1.mp3",
                UserId = 2,
                DateUpload = DateTime.Now,
                Category = _audioCategory
            },
            new Media
            {
                Id = 3,
                MediaKey = "visual1.jpg",
                UserId = 1,
                DateUpload = DateTime.Now,
                Category = _visualCategory
            }
        };
    }

    [Given(@"a list of categories")]
    public void GivenAListOfCategories()
    {
        // create a list of categories
        _videoCategory = new Category { Id = 1, Category1 = "Videos" };
        _audioCategory = new Category { Id = 2, Category1 = "Audios" };
        _visualCategory = new Category { Id = 3, Category1 = "Pictures" };
    }

    [When(@"I sort the media into lists")]
    public void WhenISortTheMediaIntoLists()
    {
        // create the observable collections for each media type
        _videoList = new ObservableCollection<Media>();
        _audioList = new ObservableCollection<Media>();
        _visualList = new ObservableCollection<Media>();

        // sort the latest media list into the appropriate observable collections
        var mediaSorter = new MediaSorter();
        mediaSorter.SortMediaIntoLists(_latestMediaList, _userList, _videoList, _audioList, _visualList);
    }

    [Then(@"the media should be sorted into the correct lists")]
    public void ThenTheMediaShouldBeSortedIntoTheCorrectLists()
    {
        // check that each media object is in the correct observable collection
        Assert.IsTrue(_videoList.All(m => m.Category.Category1 == "Videos"));
        Assert.IsTrue(_audioList.All(m => m.Category.Category1 == "Audios"));
        Assert.IsTrue(_visualList.All(m => m.Category.Category1 == "Pictures"));
    }
}
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

[Binding]
public class SortMediaIntoListsSteps
{
    private List<Media> latestMediaList;
    private List<User> userList;
    private ObservableCollection<Media> videoList;
    private ObservableCollection<Media> audioList;
    private ObservableCollection<Media> visualList;

    [Given(@"a list of latest media")]
    public void GivenAListOfLatestMedia()
    {
        latestMediaList = new List<Media>()
        {
            new Media()
            {
                Id = 1,
                MediaKey = "video1.mp4",
                UserId = 1,
                CategoryId = 1,
                DateUpload = new DateTime(2023, 04, 27),
                FileName = "video1",
                Likes = 100,
                Category = new Category() { Id = 1, Category1 = "Videos" },
                User = new User() { Id = 1, FirstName = "John", LastName = "Doe", Username = "johndoe" }
            },
            new Media()
            {
                Id = 2,
                MediaKey = "audio1.mp3",
                UserId = 2,
                CategoryId = 2,
                DateUpload = new DateTime(2023, 04, 26),
                FileName = "audio1",
                Likes = 50,
                Category = new Category() { Id = 2, Category1 = "Audios" },
                User = new User() { Id = 2, FirstName = "Jane", LastName = "Doe", Username = "janedoe" }
            },
            new Media()
            {
                Id = 3,
                MediaKey = "picture1.jpg",
                UserId = 3,
                CategoryId = 3,
                DateUpload = new DateTime(2023, 04, 25),
                FileName = "picture1",
                Likes = 25,
                Category = new Category() { Id = 3, Category1 = "Pictures" },
                User = new User() { Id = 3, FirstName = "Bob", LastName = "Smith", Username = "bobsmith" }
            }
        };
    }

    [Given(@"a list of users")]
    public void GivenAListOfUsers()
    {
        userList = new List<User>()
        {
            new User()
Scenario: Sort latest media into respective categories
    Given a list of latest media
    And a list of users
    And empty video, audio and visual lists
    When the latest media is sorted into their respective categories
    Then the video list should only contain media with the category "Videos"
    And the audio list should only contain media with the category "Audios"
    And the visual list should only contain media with the category "Pictures"

*/
