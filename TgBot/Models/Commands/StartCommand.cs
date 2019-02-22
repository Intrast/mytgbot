using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot.Models.Commands
{
    public class StartCommand : Command
    {
        private ProfileContext db = new ProfileContext();
        public override string Name => "start";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            Profile profile = new Profile();
            profile.Name = message.From.FirstName;
            profile.ChatId = chatId; 
            db.Profiles.Add(profile);
            await db.SaveChangesAsync();
            await client.SendTextMessageAsync(chatId, "Bot for profile");
        }
    }
}