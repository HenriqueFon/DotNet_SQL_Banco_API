#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Concessonaria/Concessonaria.csproj", "Concessonaria/"]
RUN dotnet restore "Concessonaria/Concessonaria.csproj"
COPY . .
WORKDIR "/src/Concessonaria"
RUN dotnet build "Concessonaria.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Concessonaria.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Concessonaria.dll"]