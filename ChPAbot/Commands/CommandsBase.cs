using System;
using System.Collections.Generic;
using System.Text;

namespace ChPAbot
{
    public static class CommandsBase
    {
        //Commands list
        //    help - я тебе помогу
        //    god - help us
        //    cheposmotret - поможет тебе
        //    dlyadruga - ссылка для друга  
        public static string CommandNameHelp { get; set; } = "/help";
        public static string CommandNameGod { get; set; } = "/god";
        public static string CommandNameCheposmotret { get; set; } = "/cheposmotret";
        public static string CommandNameLink { get; set; } = "/dlyadruga";

        private static List<Command> commandsList;
        public static IReadOnlyList<Command> CommandsList { get => commandsList.AsReadOnly(); }

        static CommandsBase()
        {
            commandsList = new List<Command>();
            commandsList.Add(new CommandHelp());
            commandsList.Add(new CommandGod());
            commandsList.Add(new CommandCheposmotret());
            commandsList.Add(new CommandLink());
        }

    }
}
