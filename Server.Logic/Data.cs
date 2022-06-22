namespace Server.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Server.Model;

    public class Data : IData
    {
        static readonly List<Item> items = new();
        static readonly string filename = "appdata.json";

        static Data()
        {
            Reader reader = new();
            lock (items)
            {
                items = Reader.ReadJson(filename);
            }
        }

        public List<Item> GetItems()
        {
            lock (items)
            {
                return items;
            }
        }

        public List<Item> GetItem(string id)
        {
            lock (items)
            {
                return items.Where(item => item.id == id).ToList();
            }
        }

        public List<Item> AddItem(Item item)
        {
            Writer writer = new();
            lock (items)
            {
                items.Add(item);
                Writer.WriteJson(filename, items);
                return items;
            }
        }
    }
}
