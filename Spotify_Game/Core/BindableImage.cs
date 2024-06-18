using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Controls;


namespace Spotify_Game.Core
{
    public class BindableImage : Image
    {
        static BindableImage() {
            SourceProperty.OverrideMetadata(typeof(BindableImage), new FrameworkPropertyMetadata(OnSourceChanged));
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var image = d as BindableImage;
            image?.OnSourceChanged(e);
        }

        protected virtual void OnSourceChanged(DependencyPropertyChangedEventArgs e) {
        
            var rightImageStoryboard = (Storyboard)FindResource("RightImageSlideInStoryboard");
            rightImageStoryboard?.Begin();
        }
    }
}
