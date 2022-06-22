#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server.Rest/Server.Rest.csproj", "Server.Rest/"]
COPY ["Server.Model/Server.Model.csproj", "Server.Model/"]
COPY ["Server.Logic/Server.Logic.csproj", "Server.Logic/"]
RUN dotnet restore "Server.Rest/Server.Rest.csproj"
COPY . .
WORKDIR "/src/Server.Rest"
RUN dotnet build "Server.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.Rest.dll"]