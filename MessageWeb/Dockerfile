FROM mcr.microsoft.com/dotnet/sdk:8.0 AS sdk
WORKDIR /app

COPY ./ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=sdk /app/out .
ENTRYPOINT ["dotnet", "MessageWeb.dll"]