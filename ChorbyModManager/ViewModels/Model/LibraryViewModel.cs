using ChorbyModManager.Core;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace ChorbyModManager.Views.Model
{
    public class LibraryViewModel : ObservableObject
    {
        private const bool debugLocal = true;

        public ObservableCollection<ModItem> ModsLoaded { get; set; }

        public LibraryViewModel()
        {
            ModsLoaded = new ObservableCollection<ModItem>();
             
            // Mainly for the browser tab which also uses the same ui, just putting this here to test library layout first
            if (debugLocal)
            {
                // How do i make local storage folders for github..
                //foreach (string item in Directory.GetDirectories("Source/Mods"))
                //{
                //    string path = Path.Combine(item, "data.json");
                //    if (File.Exists(path))
                //    {
                //        ModsLoaded.Add(JsonSerializer.Deserialize<ModItem>(File.ReadAllText(path)));
                //    }
                //}
                AuthorItem test = new AuthorItem { authorTag = "test", name = "TestAuthor" };
                ModItem template = new ModItem { modID = 0, title = "test0Mod", resourceTag = "none", author = "none", description = "placeholder", version = "1.2.3" };
                for (int i = 0; i < 32; i++)
                {
                    template.title = $"test{i}_Mod";
                    ModsLoaded.Add(template);
                }
            }
        }
    }
}
