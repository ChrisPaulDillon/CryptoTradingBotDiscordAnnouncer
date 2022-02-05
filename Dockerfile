FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Production

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY "CoinListingScraper.DiscordAnnouncer/CoinListingScraper.DiscordAnnouncer.csproj" .
RUN dotnet restore "CoinListingScraper.DiscordAnnouncer.csproj"
COPY . .
WORKDIR "/src/CoinListingScraper.DiscordAnnouncer"
RUN dotnet build "CoinListingScraper.DiscordAnnouncer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoinListingScraper.DiscordAnnouncer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoinListingScraper.DiscordAnnouncer.dll"]
