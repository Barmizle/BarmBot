using Discord;
using Discord.Commands; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmBotIzle
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;
        Random rand;
        string[] textball;
        string[] outmemes;



        public MyBot()
        {
            rand = new Random();
            textball = new string[]
            {
                "Maybe",
                "Just kys",
                "Absolutely",
                "Fuck no",
                "Honestly I don't care",
                "Yeah, sure, whatever",
                "Nah it takes too much time",
                "What the fuck"
            };
            outmemes = new string[]
            {
                "dankmemes/443269ffgif.gif",
                "dankmemes/b2M5wrg.gif"
            };
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;

            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '^';
                x.AllowMentionPrefix = true;
            });
            commands = discord.GetService<CommandService>();
            RegisterMag();
            RegisterKys();
            RegisterBall();
            RegisterRino();
            RegisterIykwim();
 
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQwOTEyNDQzMjI2ODQ5Mjgw.CvKQjw.Nr-Bndl-Ii_Oeha5uOXOOoShBE8", TokenType.Bot);
            });
        }
        private void RegisterMag()
        {
            commands.CreateCommand("mag")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("dankmemes/5LnjvXp.jpg");
                });
        }
        private void RegisterKys()
        {
            commands.CreateCommand("kys")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("dankmemes/1WkxrnBgif.gif");
                });
        }
        private void RegisterBall()
        {
            commands.CreateCommand("?")
                .Do(async (e) =>
                {
                    int randomans = rand.Next(textball.Length);
                    string answer = textball[randomans];
                    await e.Channel.SendMessage(answer);
                });
        }
        private void RegisterRino()
        {
            commands.CreateCommand("rino")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("dankmemes/2r6e7uf.jpg");
                });
        }
        private void RegisterIykwim()
        {
            commands.CreateCommand("iykwim")
                .Do(async (e) =>
                {
                    
                    await e.Channel.SendFile("dankmemes/1433322021546gif.gif");
                 
                });
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
