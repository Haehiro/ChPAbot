using Telegram.Bot;
using Telegram.Bot.Types;
using RestSharp;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace ChPAbot
{
    public class CommandCheposmotret : Command
    {
        public override string Name => CommandsBase.CommandNameCheposmotret;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            const string BaseUrl = "http://чпа.арго33.рф/api/";
            var _client = new RestClient(BaseUrl);
            var request = new RestRequest("Search/?text=&censored=on");
            IRestResponse response = _client.Execute(request);
            var content = response.Content;

            var m = JsonConvert.DeserializeObject<InfoAnime[]>(content);
            var c = m[0];
            
            await client.SendPhotoAsync(chatId, photo: c.Image.Original, caption: $"<a href =\"{c.Url}\"> {c.Name} {c.Russian} </a>", parseMode: ParseMode.Html);

        }
    }
    public class InfoImage
    {

        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("x96")]
        public string X96 { get; set; }

        [JsonProperty("x48")]
        public string X48 { get; set; }
    }

    public class InfoAnime
    {

        [JsonProperty("episodes")]
        public int Episodes { get; set; }

        [JsonProperty("episodes_aired")]
        public int EpisodesAired { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("russian")]
        public string Russian { get; set; }

        [JsonProperty("image")]
        public InfoImage Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("aired_on")]
        public string AiredOn { get; set; }

        [JsonProperty("released_on")]
        public object ReleasedOn { get; set; }
    }


}
