namespace Server.Model
{
    public class Item
    {
        public string id { get; private set; }
        public Item(string id)
        {
            this.id = id;
        }
    }
}
