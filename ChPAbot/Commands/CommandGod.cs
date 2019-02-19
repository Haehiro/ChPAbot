using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChPAbot
{
    public class CommandGod : Command
    {
        public override string Name => CommandsBase.CommandNameGod;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await client.SendPhotoAsync(chatId, "http://integralagile.com/wp-content/uploads/2017/03/montypython.jpg");


        }
    }


}
