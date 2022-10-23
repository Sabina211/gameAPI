#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GameAPI.Web/GameAPI.Web.csproj", "GameAPI.Web/"]
COPY ["GameAPI.Application/GameAPI.Application.csproj", "GameAPI.Application/"]
COPY ["GameAPI.Domain/GameAPI.Domain.csproj", "GameAPI.Domain/"]
COPY ["GameAPI.Infrastructure/GameAPI.Infrastructure.csproj", "GameAPI.Infrastructure/"]
RUN dotnet restore "GameAPI.Web/GameAPI.Web.csproj"
COPY . .
WORKDIR "/src/GameAPI.Web"
RUN dotnet build "GameAPI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameAPI.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameAPI.Web.dll"]