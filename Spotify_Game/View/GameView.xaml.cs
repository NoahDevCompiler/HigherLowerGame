using Google.Apis.YouTube.v3;
using Spotify_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Spotify_Game.Logic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private List<VideoModel> _videos= new List<VideoModel>();
        private int _currentIndex = 0;
        public GameView()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
           
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            await DisplayVideo();
        }
        private async Task DisplayVideo() {

            _videos = await YoutubeService.GetAsyncVideo(500);
            _videos.Shuffle();
            var left = _videos[_currentIndex];
            var right = _videos[_currentIndex + 1];

            LeftTitle.Text = left.snippet.Title;
            LeftChannel.Text = string.Join(", ", left.snippet.ChannelTitle);
            LeftViews.Text = $"Views: {left.statistics.ViewCount}";
            LeftImage.Source = new BitmapImage(new Uri(left.snippet.ThumbnailUrl));

            RightTitle.Text = right.snippet.Title;
            RightChannel.Text = string.Join(", ", right.snippet.ChannelTitle);
            RightViews.Text = $"Views: {right.statistics.ViewCount}";
            RightImage.Source = new BitmapImage(new Uri(right.snippet.ThumbnailUrl));

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e) {
           
            Close(); 
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e) {
            var leftTrack = _videos[_currentIndex];
            var rightTrack = _videos[_currentIndex + 1];  
            
                _currentIndex++;
            DisplayVideo();
        }
    }
}
