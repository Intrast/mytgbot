using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot.Models.Commands
{
    public class ListCommand : Command
    {
        public override string Name => "commandlist";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, "/hello - bot send hello for you");
        }
    }
}