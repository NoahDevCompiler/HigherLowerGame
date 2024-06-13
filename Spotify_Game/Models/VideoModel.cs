using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Game.Models
{
    public class VideoModel
    {
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }

        public class Snippet
        {
            public string Title { get; set; }
            public string ThumbnailUrl { get; set; }
        }

        public class Statistics
        {
            public string ViewCount { get; set; }
        }

       
    }

}
