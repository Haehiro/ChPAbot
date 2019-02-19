using System;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace ChPAbot
{
    public class CommandHelp : Command
    {
        public override string Name => CommandsBase.CommandNameHelp;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string listcommand = string.Empty;
            foreach (var command in CommandsBase.CommandsList)
            {
                listcommand = listcommand + "\n"+ command.Name;
                
            }

            await client.SendTextMessageAsync(chatId, $"Не знаешь, что делать введи команду: {listcommand}");
        }
    }

}
