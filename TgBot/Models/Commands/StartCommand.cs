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
        public override string Name => "/start";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var user = db.Profiles.Where(p => p.ChatId == chatId).FirstOrDefault();
            Profile profile = new Profile();
            profile.ChatId = chatId;
            profile.CurrentProperty = "Name";
            if (user == null)
            {
                await client.SendTextMessageAsync(chatId, "Your First and Last Name:");
                db.Profiles.Add(profile);
                await db.SaveChangesAsync();
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "We already have your profile");
            }
        }
    }
}