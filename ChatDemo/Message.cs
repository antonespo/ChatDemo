using System;

namespace ChatDemo
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }
    }
}
