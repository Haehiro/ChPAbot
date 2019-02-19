using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ChPAbot
{
    public class CommandLink : Command
    {
        public override string Name => CommandsBase.CommandNameLink;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            const string BaseUrl = "http://чпа.арго33.рф/api/";
            var _client = new RestClient(BaseUrl);
            var request = new RestRequest("Search/?text=&genres=12");
            IRestResponse response = _client.Execute(request);
            var content = response.Content;

            var m = JsonConvert.DeserializeObject<InfoAnime[]>(content);

            var c = m[0];
                        
            await client.SendPhotoAsync (chatId, photo: c.Image.Original, caption: $"<a href =\"{c.Url}\"> {c.Name} для друга </a>", parseMode: ParseMode.Html);

        }
    }
}
