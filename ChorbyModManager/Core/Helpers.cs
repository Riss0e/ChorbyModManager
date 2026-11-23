using System;
using System.IO;
using System.Collections.Generic;

namespace ChorbyModManager.Core
{
    public static class Helpers
    {
        public static List<string> pinnedMods = new List<string>();

        public static readonly string storageModsLink = "https://raw.githubusercontent.com/Riss0e/ChorbyModManager/main/Source/Mods";
        public static readonly string storageAuthorsLink = "https://raw.githubusercontent.com/Riss0e/ChorbyModManager/main/Source/Authors";

        public static readonly string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
        public static readonly string cacheModsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache", "Mods");
        public static readonly string cachePinnedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache", "Pinned");
        public static readonly string modsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache", "ModInfo.json");
        public static readonly string pinsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache", "PinInfo.json");
    }
}
