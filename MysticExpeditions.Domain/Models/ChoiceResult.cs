﻿using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Models
{
    public class ChoiceResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }
    }
}
