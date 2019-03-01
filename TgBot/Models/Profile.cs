using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TgBot.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string CurrentProperty { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string CurrentPosition { get; set; }
        public string Experience { get; set; }
    }
}