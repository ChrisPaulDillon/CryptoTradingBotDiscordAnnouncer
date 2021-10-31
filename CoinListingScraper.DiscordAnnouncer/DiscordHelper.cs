﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.DiscordAnnouncer
{
    public class DiscordHelper
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        private readonly ulong discordChannelId = 559085045864988694;
        private readonly string discordTokenId = "OTAzMDQ2MTQxNDgwOTM1NDg3.YXnRQQ.zf6JpHTrXHbg7qWRSzIg5K5Pb7I";

        public DiscordHelper()
        {
   
        }

        public async Task<DiscordSocketClient> StartBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            //_client.Log += _client_Log;

            await RegisterCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, discordTokenId);

            await _client.StartAsync();
            return _client;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
            }
        }

        public async Task Announce(string message)
        {
            var chnl = _client.GetChannel(discordChannelId) as IMessageChannel;
            await chnl.SendMessageAsync(message);
        }
    }
}