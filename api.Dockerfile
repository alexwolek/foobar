#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["foobar.api/Foobar.Api.csproj", "Foobar.Api/"]
RUN dotnet restore "foobar.api/Foobar.Api.csproj"
COPY . .
WORKDIR "/src/foobar.api"
RUN dotnet build "Foobar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Foobar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Foobar.Api.dll"]
