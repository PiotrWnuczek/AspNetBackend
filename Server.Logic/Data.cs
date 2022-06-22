﻿namespace Server.Logic
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
    }
}