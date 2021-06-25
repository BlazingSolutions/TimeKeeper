FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000;

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY TimeKeeper.Api/TimeKeeper.Api.csproj TimeKeeper.Api/

RUN dotnet restore "TimeKeeper.Api/TimeKeeper.Api.csproj"

COPY TimeKeeper.Api/. TimeKeeper.Api/.
COPY TimeKeeper.Shared/. TimeKeeper.Shared/.

COPY ["TimeKeeper.Client/.", "TimeKeeper.Client/"]
COPY ["TimeKeeper.Shared/.", "TimeKeeper.Shared/"]

WORKDIR "/src/TimeKeeper.Api"

RUN dotnet publish "TimeKeeper.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "TimeKeeper.Api.dll"]
