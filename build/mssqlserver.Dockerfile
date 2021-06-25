FROM mcr.microsoft.com/mssql/server:2017-latest

ARG SA_PASSWORD=Password1!
ENV SA_PASSWORD=$SA_PASSWORD
ENV ACCEPT_EULA="Y"

EXPOSE 1433

RUN mkdir -p /usr/work
COPY ./build/*.sql /usr/work/

WORKDIR /usr/work
RUN ( /opt/mssql/bin/sqlservr & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -i create-db.sql
