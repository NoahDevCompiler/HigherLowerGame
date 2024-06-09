using Spotify_Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Game.View.ViewModel
{

  
     class MainViewModel : ObservableObject
     {

        public RelayCommand HomeViewCommand { get; set; } 
        public RelayCommand ProfileViewCommand { get; set; }
        public RelayCommand GameViewCommand { get; set; }
        
        public HomeViewModel HomeVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        public GameViewModel GameVM { get; set; }

        private object _currentView;

        public object CurrentView {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }
               
        public MainViewModel() {

            HomeVM = new HomeViewModel();
            ProfileVM = new ProfileViewModel();
            GameVM = new GameViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => {
                CurrentView = HomeVM;
            });

            ProfileViewCommand = new RelayCommand(o => {
                CurrentView = ProfileVM;
            });

            GameViewCommand = new RelayCommand(o => {
                CurrentView = GameVM;
            });
        }
     }
}
