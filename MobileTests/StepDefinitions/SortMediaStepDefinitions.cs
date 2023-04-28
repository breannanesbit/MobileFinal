using Shared;
using System;
using Moq;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using Mobile_final.ViewModels;
using Mobile_final.Services;
using NUnit.Framework;

namespace MobileTests.StepDefinitions
{
    [Binding]

    public class SortMediaStepDefinitions
    {
        private List<User> _userList;
        private List<Media> _latestMediaList;
        private ObservableCollection<MediaDisplayOutLine> _videoList;
        private ObservableCollection<MediaDisplayOutLine> _audioList;
        private ObservableCollection<MediaDisplayOutLine> _visualList;
        private Category _videoCategory;
        private Category _audioCategory;
        private Category _visualCategory;


        [Given(@"a list of latest media")]
        public void GivenAListOfLatestMedia()
        {
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

        [Given(@"a list of users")]
        public void GivenAListOfUsers()
        {
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

        [Given(@"empty video, audio and visual lists")]
        public void GivenEmptyVideoAudioAndVisualLists()
        {
            _videoList = new ObservableCollection<MediaDisplayOutLine>();
            _audioList = new ObservableCollection<MediaDisplayOutLine>();
            _visualList = new ObservableCollection<MediaDisplayOutLine>();
        }

        [Given(@"a list of categories")]
        public void GivenAListOfCategories()
        {
            _videoCategory = new Category { Id = 1, Category1 = "Videos" };
            _audioCategory = new Category { Id = 2, Category1 = "Audios" };
            _visualCategory = new Category { Id = 3, Category1 = "Pictures" };
        }


        [When(@"the latest media is sorted into their respective categories")]
        public void WhenTheLatestMediaIsSortedIntoTheirRespectiveCategories()
        {
            var mockservice = new Mock<IUserService>();
            var homemediavm = new HomeMediaViewModel(mockservice.Object);
            homemediavm.SortMediaIntoLists(_latestMediaList, _userList, _videoList, _audioList, _visualList);
        }

        [Then(@"the video list should only contain media with the category ""([^""]*)""")]
        public void ThenTheVideoListShouldOnlyContainMediaWithTheCategory(string videos)
        {
            foreach( var item in _videoList )
            {
                Assert.AreEqual(videos, item.Category.Category1);
            }
        }

        [Then(@"the audio list should only contain media with the category ""([^""]*)""")]
        public void ThenTheAudioListShouldOnlyContainMediaWithTheCategory(string audios)
        {
            foreach (var item in _audioList)
            {
                Assert.AreEqual(audios, item.Category.Category1);
            }
        }

        [Then(@"the visual list should only contain media with the category ""([^""]*)""")]
        public void ThenTheVisualListShouldOnlyContainMediaWithTheCategory(string pictures)
        {
            foreach (var item in _visualList)
            {
                Assert.AreEqual(pictures, item.Category.Category1);
            }
        }
    }
}
