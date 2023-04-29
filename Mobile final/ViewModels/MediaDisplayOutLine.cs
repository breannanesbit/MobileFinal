using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinal.ViewModels
{
    public class MediaDisplayOutLine
    {
        public Media MediaItem {  get; set; }
        public string Comment { get; set; }
        public bool LikeSelected { get; set; }

        public string ImageSource { get; set; }

        public MediaDisplayOutLine()
        {
            ImageSource = "musicheart";
            Comment = "";
        }
    }
}
