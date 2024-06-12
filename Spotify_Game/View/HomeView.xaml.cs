using Spotify_Game.View.ViewModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spotify_Game.View
{
    /// <summary>
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView() {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

            Window parentWindow = Window.GetWindow(this);

            GameView newWindow = new GameView();

           
            newWindow.Width = 950;
            newWindow.Height = 600;
            newWindow.Left = parentWindow.Left;
            newWindow.Top = parentWindow.Top;

          
          

          
            newWindow.Closed += (s, args) => {                     
                parentWindow.Show();
            };

         
            parentWindow.Hide();
           
            newWindow.Show();
        }

    }
}
