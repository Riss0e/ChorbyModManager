using ChorbyModManager.Core;
using System.Collections.ObjectModel;

namespace ChorbyModManager.Views.Model
{
    public class LibraryViewModel : ObservableObject
    {
        public ObservableCollection<ModItem> ModsLoaded { get; set; }

        public LibraryViewModel()
        {
            ModsLoaded = new ObservableCollection<ModItem>();

            // Future Testing
            //AuthorItem test = new AuthorItem { authorTag = "test", name = "TestAuthor" };
            //for (int i = 0; i < 32; i++)
            //{
            //    ModsLoaded.Add(new ModItem { title = $"TestModTitle", author = test, resourceTag = "/Assets/Images/Chorby.png" });
            //}
        }
    }
}
