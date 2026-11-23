using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ChorbyModManager.Core.Mods;

namespace ChorbyModManager.Core
{
    public class Fetcher // cool idea would be to use the content warning loading spinning thing while an item is loading still
    {
        public enum FetchType
        {
            Icon,
            Data,
            About,
            Banner,
            Mod
        }

        private static readonly FetchType[] stringTypes = new FetchType[] { FetchType.Data, FetchType.About };

        private static readonly string[] fetchStrings = new string[]
        { "icon.png", "data.json", "about.txt", "banner.png", "mod.dll" };

        public static Fetcher instance;
        public Queue<Request> fetchQueueMod = new Queue<Request>();
        public Queue<string> fetchQueueAuthor = new Queue<string>();

        public static void Initialize()
        {
            if (instance == null)
                instance = new Fetcher();
        }

        public static int fetchedCount;
        public static void FetchInitial(int count = 5) // depends on amount of items in a row visually on the ui (3 items = 3 fetches at once) max 5 in a row
        {
            for (int i = fetchedCount; i < fetchedCount + count; i++)
            {
                instance.fetchQueueMod.Enqueue(new Request(fetchedCount, i, FetchType.Data, FetchType.Icon));
            }
            instance.FetchModQueue();
        }

        public static void FetchDetailed(int id)
        {
            instance.fetchQueueMod.Enqueue(new Request(fetchedCount, id, FetchType.About, FetchType.Banner));
            instance.FetchModQueue();
        }

        public static void FetchMod(int id)
        {
            instance.fetchQueueMod.Enqueue(new Request(fetchedCount, id, FetchType.Mod));
            instance.FetchModQueue();
        }

        public static void FetchPin(int id)
        {
            instance.fetchQueueMod.Enqueue(new Request(fetchedCount, id, FetchType.Data, FetchType.About, FetchType.Icon, FetchType.Banner));
            instance.FetchModQueue();
        }

        public static void FetchAuthor(string tag)
        {
            instance.fetchQueueAuthor.Enqueue($"{tag}.json");
            instance.FetchAuthorQueue();
        }

        private async void FetchModQueue()
        {
            while (fetchQueueMod.Count > 0)
            {
                Request current = fetchQueueMod.Dequeue();
                await FetcherMod(current);
                // do stuff here (like displaying the item on the ui)
            }
            // tell code it's done fetching
        }

        private async void FetchAuthorQueue()
        {
            while (fetchQueueAuthor.Count > 0)
            {
                string current = fetchQueueAuthor.Dequeue();
                await FetcherAuthor(current);
                // do stuff here (return the author github link to the mod items for example)
            }
            // tell code it's done
        }

        public class Request
        {
            public Request(int start, int count = 1, params FetchType[] types)
            {
                this.start = start;
                this.count = count;
                this.types = types;
            }

            public int start;
            public int count;
            public FetchType[] types;
        }

        private async Task FetcherMod(Request request)
        {
            for (int i = request.start; i < request.start + request.count; i++)
            {
                string id = i.ToString();
                bool isInstalled = Directory.Exists(Path.Combine(Helpers.cacheModsPath, id)) || request.types.Contains(FetchType.Mod);
                bool isPinned = Helpers.pinnedMods.Contains(id);

                string mods = Path.Combine(Helpers.cacheModsPath, id);
                string pins = Path.Combine(Helpers.cachePinnedPath, id);
                string temp = Path.Combine(Helpers.tempPath, id);

                foreach (FetchType item in request.types)
                {
                    try
                    {
                        string name = fetchStrings[(int)item];
                        string path = string.Empty;

                        if (stringTypes.Contains(item))
                        {
                            string content = await webRequest.GetStringAsync(Path.Combine(Helpers.storageModsLink, id, name));
                            
                            if (isInstalled && item == FetchType.Data)
                                path = mods;
                            else if (isPinned)
                                path = pins;
                            else
                                path = temp;

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            File.WriteAllText(Path.Combine(path, name), content);
                        }
                        else
                        {
                            byte[] content = await webRequest.GetByteArrayAsync(Path.Combine(Helpers.storageModsLink, id, name));

                            if ((isInstalled && item == FetchType.Icon) || item == FetchType.Mod)
                                path = mods;
                            else if (isPinned)
                                path = pins;
                            else
                                path = temp;

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            File.WriteAllBytes(Path.Combine(path, name), content);
                        }
                    }
                    catch { }
                }
            }
        }

        private async Task FetcherAuthor(string author)
        {

        }

        private static readonly HttpClient webRequest = new HttpClient();
    }
}