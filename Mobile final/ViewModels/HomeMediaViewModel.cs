using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.Maui.Graphics;
using Azure.Storage.Blobs;
using System.IO;
using Microsoft.Maui.ApplicationModel;
using System.Drawing;
using Mobile_final.Services;
using MauiShared;
using System.Collections.ObjectModel;
using Shared;

namespace Mobile_final.ViewModels
{
    public partial class HomeMediaViewModel : ObservableObject
    {
        private UserService service;
        public HomeMediaViewModel(UserService service)
        {
            this.service = service;
        }

        ObservableCollection<Media> videoList = new();
        ObservableCollection<Media> audioList = new();
        ObservableCollection<Media> visualList= new();
        public async Task Start()
        {
            var latestMediaList = await service.GetMostRecentUploaded();
            foreach(var media in latestMediaList)
            {
                if(await service.GetMediaCategory(media) == "Videos")
                {
                    videoList.Add(media);
                }else if(await service.GetMediaCategory(media) == "Audios")
                {
                    audioList.Add(media);
                }else if(await service.GetMediaCategory(media) == "Pictures")
                {
                    visualList.Add(media);
                }



            }
        }
        /*
         * CollectionView of what happens in PlayMedia
         * 
         * 3 collection views, one for each type (Maybe audio with video?
         * 
         * 
         * How to do it?
         * 
         * Get top 10-15 media by when uploaded
         * get the category a media is in
         * Depending on the category, put it into 1 of 3 lists
         * Use each list as  a CollectionView source
         * 
         * 
         */
    }
}
