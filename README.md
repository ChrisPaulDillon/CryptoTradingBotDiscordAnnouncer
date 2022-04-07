# Crypto Trading Bot & Discord Announcer

## Overview
Simple bot that polls various cryptocurrency exchanges at a set interval and looks for coin listing announcements. If found, it stores the result in a 
local JSON file and announces the result. If buying and selling is enabled, then the bot will attempt to purchase the same token on the Gate IO exchange, and
continually poll the exchange and compare the price relative to the purchase price. If the price is at the desirable outcome (+10%) the bot will then sell
the purchased crypto for a profit.

To get the bot working you must update the following variables:

DISCORD_CHANNEL_ID, DISCORD_TOKEN_ID, GATE_IO_SECRET, GATE_IO_KEY

To run the bot, right click the CoinListingScraper.DiscordAnnouncer > Debug > Start New Instance

I will no longer be maintaining this project, feel free to fork and create your own custom implementation.

![Discord Bot](https://chrispauldillon.com/images/portfolio/discordbot.png)
