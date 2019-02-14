using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TgBot.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext() : base("MyTgBotDBContext")
        {

        }

        public DbSet<Profile> Profiles { get; set; }

    }
}