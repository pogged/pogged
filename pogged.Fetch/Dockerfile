FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder

ADD app /app

WORKDIR /app/pogged.Fetch

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app

COPY --from=builder /app/pogged.Fetch/out .

ENTRYPOINT ["./pogged.Fetch"]