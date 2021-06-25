FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TimeKeeper.Client/TimeKeeper.Client.csproj", "TimeKeeper.Client/"]
COPY ["TimeKeeper.Shared/TimeKeeper.Shared.csproj", "TimeKeeper.Shared/"]

RUN dotnet restore "TimeKeeper.Client/TimeKeeper.Client.csproj"

COPY ["TimeKeeper.Client/.", "TimeKeeper.Client/"]
COPY ["TimeKeeper.Shared/.", "TimeKeeper.Shared/"]

WORKDIR "/src/TimeKeeper.Client"

RUN dotnet publish "TimeKeeper.Client.csproj" -c Release -o /app

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/wwwroot .
COPY TimeKeeper.Client/nginx.conf /etc/nginx/nginx.conf
