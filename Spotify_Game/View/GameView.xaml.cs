using Google.Apis.YouTube.v3;
using Spotify_Game.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Threading;

namespace Spotify_Game.View
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        private List<VideoModel> _videos = new List<VideoModel>();
        private int _currentIndex = 0;
        int _score = 0;

        public GameView() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            _videos = await YoutubeService.GetAsyncVideo(50);
            _videos.Shuffle();
            DisplayVideo();
        }

        public void DisplayVideo() {

            versus.Visibility = Visibility.Visible;
            tick.Visibility = Visibility.Collapsed;
            cross.Visibility = Visibility.Collapsed;

            var left = _videos[_currentIndex];
            var right = _videos[_currentIndex + 1];

            LeftTitle.Text = left.snippet.Title;
            LeftChannel.Text = string.Join(", ", left.snippet.ChannelTitle);
            LeftViews.Text = $"Views: {int.Parse(left.statistics.ViewCount):N0}";
            LeftImage.Source = new BitmapImage(new Uri(left.snippet.ThumbnailUrl));

            RightTitle.Text = right.snippet.Title;
            RightChannel.Text = string.Join(", ", right.snippet.ChannelTitle);
           
            RightImage.Source = new BitmapImage(new Uri(right.snippet.ThumbnailUrl));
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private async void HigherButton_Click(object sender, RoutedEventArgs e) {

            var left = Convert.ToInt32(_videos[_currentIndex].statistics.ViewCount);
            var right = Convert.ToInt32(_videos[_currentIndex + 1].statistics.ViewCount);

            string formattedViewCount = right.ToString("N0");
            await AnimateViewCount(right);

            if (left <= right) {
                _score++;
                score.Text = Convert.ToString(_score);

                //UI Element
                tick.Visibility = Visibility.Visible;
                Thread.Sleep(1000);

                _currentIndex++;
                RightViews.Text = "";
                DisplayVideo();
            }
            else {

                MessageBox.Show("Falsch!!!");
                this.Close();
              
            }
            
          
        }
        private async void LowerButton_Click(object sender, RoutedEventArgs e) {

            var left = Convert.ToInt32(_videos[_currentIndex].statistics.ViewCount);
            var right = Convert.ToInt32(_videos[_currentIndex + 1].statistics.ViewCount);

            string formattedViewCount = right.ToString("N0");
            await AnimateViewCount(right);

            if (left >= right) {
                _score++;
                score.Text = Convert.ToString(_score);

                //UI Ecplise Update
                cross.Visibility = Visibility.Visible;

                Thread.Sleep(1000);
               
                _currentIndex++;
                RightViews.Text = "";
                DisplayVideo();

            } else {
                MessageBox.Show("Falsch!!!");
                this.Close();
            }

        }

        private async Task AnimateViewCount(int targetValue) {
            int startValue = 0;
            int totalFrames = 60;

            for (int i = 0; i <= totalFrames; i++) {
                double progress = (double)i / totalFrames;
                int currentCount = (int)(startValue + (targetValue - startValue) * progress);
                RightViews.Text = currentCount.ToString("N0");
                await Task.Delay(1000 / 60);
            }

            RightViews.Text = targetValue.ToString("N0");
            
        }
    }
}
    