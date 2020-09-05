FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder

RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash - ; \
	apt-get install -y nodejs

ADD app /app
WORKDIR /app/pogged.Web

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=builder /app/pogged.Web/out .

ENTRYPOINT ["./pogged.Web"]
