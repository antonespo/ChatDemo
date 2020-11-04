using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> _logger;

        public ChatController(ILogger<ChatController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Message Get()
        {
            var rng = new Random();
            return new Message
            {
                Id = 1, 
                Name = "Antonio", 
                Text = "Ciao ciao da Antonio ", 
                CreatedAt = DateTime.Now
            };
        }
    }
}
