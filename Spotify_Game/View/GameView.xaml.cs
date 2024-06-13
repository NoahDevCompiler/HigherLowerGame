using Google.Apis.YouTube.v3;
using Spotify_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spotify_Game.View
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public GameView()
        {
            InitializeComponent();
            LoadData();
           
        }
        private async void LoadData() {

            List<VideoModel> videos = await Logic.YoutubeService.GetAsyncVideo(50);
            foreach (var video in videos) {
                Console.Write(video.snippet.Title);
                Console.Write(video.snippet.ThumbnailUrl);
                Console.Write("\t");
                Console.Write(video.statistics.ViewCount);
                Console.Write("\n\n");
            }
            
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close(); 
        }
        

       
    }
}
