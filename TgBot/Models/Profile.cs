﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TgBot.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public long ChatId { get; set; } 
        public string Name { get; set; }
    }
}