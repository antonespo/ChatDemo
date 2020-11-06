using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatDemo.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ChatController : ControllerBase {
        private readonly ILogger<ChatController> _logger;
        private readonly DataContext context;

        public ChatController (ILogger<ChatController> logger, DataContext context) {
            this.context = context;
            _logger = logger;
        }

        [HttpGet ("all")]
        public List<Message> Get () {
            return context.Messages.ToList ();
        }

        [HttpPost ("new")]
        public bool Post (Message message) {
            message.CreatedAt = DateTime.Now;
            context.Messages.Add (message);
            var success = context.SaveChanges () > 0;

            return success;
        }
    }
}