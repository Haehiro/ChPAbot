using System;
using Telegram.Bot;
using System.Net;
using System.Net.Http;
using System.Threading;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using RestSharp;

namespace ChPAbot
{
    class Program
    {
        #region
        #endregion
        private static TelegramBotClient botClient;



        static void Main(string[] args)
        {
            var httpClient = new HttpClient(new HttpClientHandler() { Proxy = new WebProxy(Info.Proxy) });
            botClient = new TelegramBotClient(Info.Token, httpClient);

            var me = botClient.GetMeAsync().Result;
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);


            //const string BaseUrl = "http://чпа.арго33.рф/api/";
            //var _client = new RestClient(BaseUrl);
            //var request = new RestRequest("/Search/?text=");
            //IRestResponse response = _client.Execute(request);
            //var content = response.Content;
        }



        static void Bot_OnMessage(object sender, MessageEventArgs e)
        {

            foreach (var command in CommandsBase.CommandsList)
            {
                if (command.Contains(e.Message.Text))
                {
                    command.Execute(e.Message, sender as TelegramBotClient);
                    break;
                }
            }
            //if (command.Message.Text.ToLower().Contains(Commands.CommandNameHelp))
            //{

            //    Console.WriteLine($"Received a text message in chat {command.Message.Chat.Id}.");

            //    await botClient.SendTextMessageAsync(
            //        chatId: command.Message.Chat,
            //        text: "Не знаешь, что посмотреть введи команду \n /чепосмотреть" /*+ e.Message.Text*/
            //    );

            //}

            //if (command.Message.Text.ToLower().Contains("/god"))
            //{
            //    await botClient.SendPhotoAsync(command.Message.Chat.Id, "http://integralagile.com/wp-content/uploads/2017/03/montypython.jpg");
            //}

            //if (e.Message.Text.ToLower().Contains("/cheposmotret"))
            //{
            //    await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: " https://shikimori.org/animes/1639-boku-no-pico");
            //}


        }
    }

    
}
