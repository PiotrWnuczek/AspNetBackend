namespace Server.Rest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using Server.Logic;
    using Server.Model;

    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase, IData
    {
        public readonly ILogger<Controller> logger;
        private readonly Data items;

        public Controller(ILogger<Controller> logger)
        {
            this.logger = logger;
            this.items = new Data();
        }

        [HttpGet]
        [Route("GetItems")]
        public List<Item> GetItems()
        {
            return this.items.GetItems();
        }

        [HttpGet]
        [Route("GetItem/{id}")]
        public List<Item> GetItem(string id)
        {
            return this.items.GetItem(id);
        }
    }
}
