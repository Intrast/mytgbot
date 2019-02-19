using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            // TODO: Command logic

            await client.SendTextMessageAsync(chatId, $"Hello {message.From.FirstName}!");
        }
    }
}