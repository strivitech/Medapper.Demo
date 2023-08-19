FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Medapper.Demo/Medapper.Demo.csproj", "Medapper.Demo/"]
RUN dotnet restore "Medapper.Demo/Medapper.Demo.csproj"
COPY . .
WORKDIR "/src/Medapper.Demo"
RUN dotnet build "Medapper.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medapper.Demo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medapper.Demo.dll"]
