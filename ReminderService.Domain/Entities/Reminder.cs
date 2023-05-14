﻿namespace ReminderService.Domain.Entities
{
    public class Reminder : BaseEntity
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public string Method { get; set; }
        public bool Sent { get; set; }
    }
}
