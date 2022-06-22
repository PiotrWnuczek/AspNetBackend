namespace Server.Logic
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.IO;
    using Server.Model;

    public class Reader
    {
        public static List<Item> ReadJson(string filename)
        {
            string json = File.ReadAllText(filename);
            List<Item> items = JsonSerializer.Deserialize<List<Item>>(json);
            return items;
        }
    }
}
