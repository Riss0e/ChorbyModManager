using System;

namespace ChorbyModManager.Core
{
    [Serializable]
    public class ModItem
    {
        public int modID;
        public string resourceTag; // used for icon/banner getting from Temp/Pinned (both stored in a folder with the name of this string as icon.png and banner.png) mod too, but as a .dll in Mods
        public string title;
        public string version;
        public string author;
        public string description;
    }
}
