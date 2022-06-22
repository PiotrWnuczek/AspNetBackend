namespace Server.Logic
{
    using System.Collections.Generic;
    using Server.Model;

    public interface IData
    {
        public List<Item> GetItems();
    }
}
