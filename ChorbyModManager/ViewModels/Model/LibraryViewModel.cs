using ChorbyModManager.Core;
using ChorbyModManager.Core.Mods;
using System.Collections.ObjectModel;

namespace ChorbyModManager.Views.Model
{
    public class LibraryViewModel : ObservableObject
    {
        public ObservableCollection<ModItem> ModsInstalled { get; set; }
        public LibraryViewModel()
        {
            ModsInstalled = new ObservableCollection<ModItem>();
        }
    }
}
