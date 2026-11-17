using System.Windows.Media;

namespace ChorbyModManager.Core
{
    internal class ModItem
    {
        internal string resourceTag;
        internal string title;
        internal AuthorItem author;
        internal ImageSource icon;
        internal ImageSource banner;
        internal int authorID; // Authors get stored internally with their icon incuded, then when a mod fetches it uses this field and links the author
    }
}
