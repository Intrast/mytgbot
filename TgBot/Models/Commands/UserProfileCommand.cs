using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot.Models.Commands
{
    public class UserProfileCommand : Command
    {
        private ProfileContext db = new ProfileContext();
        public override string Name => "UserProfile";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            Profile profile = db.Profiles.Where(p => p.ChatId == chatId).FirstOrDefault();

            switch (profile.CurrentProperty)
            {
                case "Name":
                    Regex regex = new Regex(@"^[a-zA-Zа-яА-Я']{1,50}[ ][a-zA-Zа-яА-Я']{1,50}$");
                    Match match = regex.Match(message.Text);
                    profile.Name = message.Text;
                    profile.CurrentProperty = "Email";
                    db.Entry(profile).State = EntityState.Modified;
                    await client.SendTextMessageAsync(chatId, "Your Email:");
                    await db.SaveChangesAsync();
                    break;
                case "Email":
                    regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    match = regex.Match(message.Text);
                    if (match.Success)
                    {
                        profile.Email = message.Text;
                        profile.CurrentProperty = "PhoneNumber";
                        db.Entry(profile).State = EntityState.Modified;
                        await client.SendTextMessageAsync(chatId, "Your Phone Number:");
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(chatId, "Somethink wrong, please try again)))");
                    }
                    break;
                case "PhoneNumber":
                    regex = new Regex(@"^\+?([0-9]{2})?[ ]?[-. \(]?([0-9]{3})[-. \)]?[ ]?([0-9]{2})[-. ]?([0-9]{2})[-. ]?([0-9]){3}$");
                    match = regex.Match(message.Text);
                    if (match.Success)
                    {
                        profile.Phone = message.Text;
                        profile.CurrentProperty = "Adress";
                        db.Entry(profile).State = EntityState.Modified;
                        await client.SendTextMessageAsync(chatId, "Your Adress(City):");
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(chatId, "Somethink wrong, please try again)))");
                    }
                    break;
                case "Adress":
                    regex = new Regex(@"^[a-zA-Zа-яА-ЯіІїЄ']{1,50}[- ]?[a-zA-Zа-яА-ЯіІї']{1,50}?$");
                    match = regex.Match(message.Text);
                    if (match.Success)
                    {
                        profile.Adress = message.Text;
                        profile.CurrentProperty = "Position";
                        db.Entry(profile).State = EntityState.Modified;
                        await client.SendTextMessageAsync(chatId, "Your current position");
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(chatId, "Somethink wrong, please try again)))");
                    }
                    break;
                case "Position":
                    profile.CurrentPosition = message.Text;
                    profile.CurrentProperty = "Experience";
                    db.Entry(profile).State = EntityState.Modified;
                    await client.SendTextMessageAsync(chatId, "Your experience");
                    await db.SaveChangesAsync();
                    break;
                case "Experience":
                    profile.Experience = message.Text;
                    profile.CurrentProperty = "End";
                    db.Entry(profile).State = EntityState.Modified;
                    await client.SendTextMessageAsync(chatId, "thank you for attention");
                    await db.SaveChangesAsync();
                    break;
                default:
                    await client.SendTextMessageAsync(chatId, "We already have your profile");
                    break;
            }
        }
    }
}