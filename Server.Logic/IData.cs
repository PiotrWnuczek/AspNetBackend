namespace Server.Logic
{
    using System.Collections.Generic;
    using Server.Model;

    public interface IData
    {
        public List<Item> GetItems();
        public List<Item> GetItem(string id);
    }
}
