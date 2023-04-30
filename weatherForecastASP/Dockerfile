FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["weatherForecastASP/weatherForecastASP.csproj", "weatherForecastASP/"]
RUN dotnet restore "weatherForecastASP/weatherForecastASP.csproj"
COPY . .
WORKDIR "/src/weatherForecastASP"
RUN dotnet build "weatherForecastASP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "weatherForecastASP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "weatherForecastASP.dll"]
