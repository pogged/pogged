FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash - ; \
	apt-get install -y nodejs

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=builder /app/out .

ENTRYPOINT ["./pogged.Web"]