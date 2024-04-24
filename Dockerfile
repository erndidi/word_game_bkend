FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5029

ENV ASPNETCORE_URLS=http://+:5029

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["word_game_bkend.csproj", "./"]
RUN dotnet restore "word_game_bkend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "word_game_bkend.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "word_game_bkend.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "word_game_bkend.dll"]
