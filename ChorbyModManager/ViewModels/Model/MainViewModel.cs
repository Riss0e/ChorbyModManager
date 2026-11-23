using ChorbyModManager.Core;

namespace ChorbyModManager.Views.Model
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand GoToLibrary { get; set; }
        public RelayCommand GoToBrowse { get; set; }
        public RelayCommand GoToOptions { get; set; }
        public RelayCommand GoToAbout { get; set; }

        public LibraryViewModel libraryVM;
        public BrowseViewModel browseVM;
        public OptionsViewModel optionsVM;
        public AboutViewModel aboutVM;

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
            browseVM = new BrowseViewModel();
            optionsVM = new OptionsViewModel();
            aboutVM = new AboutViewModel();

            GoToLibrary = new RelayCommand(o => { CurrentView = libraryVM; });
            GoToBrowse = new RelayCommand(o => { CurrentView = browseVM; });
            GoToOptions = new RelayCommand(o => { CurrentView = optionsVM; });
            GoToAbout = new RelayCommand(o => { CurrentView = aboutVM; });

            CurrentView = libraryVM;
        }
    }
}
