using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ChatDemo.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ChatController : ControllerBase {
        private readonly DataContext context;

        public ChatController (DataContext context) {
            this.context = context;
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