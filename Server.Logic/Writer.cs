namespace Server.Logic
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.IO;
    using Server.Model;

    public class Writer
    {
        public static void WriteJson(string filename, List<Item> items)
        {
            string json = JsonSerializer.Serialize(items);
            File.WriteAllText(filename, json);
        }
    }
}
