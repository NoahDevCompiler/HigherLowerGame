using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Spotify_Game.Models;

namespace Spotify_Game.Logic
{
    class YoutubeService
    {
        public static async Task<List<VideoModel>> GetAsyncVideo (int _results) {

            var youtubeService = new YouTubeService(new BaseClientService.Initializer() {
                ApiKey = "AIzaSyC1T153FHTLromyQAMT4F76bAO3xDK9qTA",
                ApplicationName = "Spotify_Game",
            });

            var request = youtubeService.Videos.List("snippet,contentDetails,statistics");
            request.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
            request.MaxResults = _results;

            var searchListResponse = await request.ExecuteAsync();
            
            List<VideoModel> videoList = new List<VideoModel>();    

            foreach (var video in searchListResponse.Items) {
               
                videoList.Add(new VideoModel {
                    snippet = new VideoModel.Snippet { 
                        Title = $"{video.Snippet.Title}", 
                        ThumbnailUrl = $"{video.Snippet.Thumbnails.Medium.Url}" },
                    statistics = new VideoModel.Statistics {
                        ViewCount = $"{video.Statistics.ViewCount}"
                    }                 
                });
            }
            
            return videoList;

        }

         

    }
}