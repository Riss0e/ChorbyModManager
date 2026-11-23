using ChorbyModManager.Core;
using ChorbyModManager.Core.Mods;
using System.Collections.ObjectModel;

namespace ChorbyModManager.Views.Model
{
    public class BrowseViewModel : ObservableObject
    {
        public ObservableCollection<ModItem> ModsFetched { get; set; }
        public BrowseViewModel()
        {
            ModsFetched = new ObservableCollection<ModItem>();
        }
    }
}
