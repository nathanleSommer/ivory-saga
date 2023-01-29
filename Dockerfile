###########
# Base
###########
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

###########
# Build
###########
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . .
WORKDIR /src/IvorySaga.Domain
RUN dotnet build -c Release -o /app/build

WORKDIR /src/IvorySaga.Infrastructure
RUN dotnet build -c Release -o /app/build

WORKDIR /src/IvorySaga.Application
RUN dotnet build -c Release -o /app/build

WORKDIR /src/IvorySaga.Api
RUN dotnet build -c Release -o /app/build

###########
# Publish
###########
FROM build AS publish
RUN dotnet publish "IvorySaga.Api.csproj" -c Release -o /app/publish

###########
# Final
###########
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IvorySaga.Api.dll"]