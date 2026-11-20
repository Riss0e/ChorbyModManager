using System;

namespace ChorbyModManager.Core
{
    [Serializable]
    public class AuthorItem
    {
        public string authorTag; // also what the icon is called in Temp ({user}.png)
        public string name;
        public string steamID;
        public string githubID;
    }
}
