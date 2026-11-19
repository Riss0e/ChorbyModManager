using ChorbyModManager.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChorbyModManager.Views.Model
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand GoToLibrary { get; set; }
        public RelayCommand GoToBrowse { get; set; }
        public RelayCommand GoToOptions { get; set; }
        public RelayCommand GoToAbout { get; set; }

        public LibraryViewModel libraryVM;

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            libraryVM = new LibraryViewModel();
            CurrentView = libraryVM;

            GoToLibrary = new RelayCommand(o => { CurrentView = libraryVM; });
        }
    }
}
