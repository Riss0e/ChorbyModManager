using System.Windows.Media;

namespace ChorbyModManager.Core
{
    public class ModItem : ObservableObject
    {
        public string resourceTag; // used for icon/banner getting from Temp/Pinned (both stored in a folder with the name of this string as icon.png and banner.png) mod too, but as a .dll in Mods
        public string title;
        public string version;
        public string authorTag;
        public string description;

        public AuthorItem author;

        public RelayCommand ToggleCommand { get; set; }
        public RelayCommand PinCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
    }
}
