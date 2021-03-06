#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["M.Challenge.Write.Api/M.Challenge.Write.Api.csproj", "M.Challenge.Write.Api/"]
COPY ["M.Challenge.Write.Infrastructure/M.Challenge.Write.Infrastructure.csproj", "M.Challenge.Write.Infrastructure/"]
COPY ["M.Challenge.Write.Domain/M.Challenge.Write.Domain.csproj", "M.Challenge.Write.Domain/"]
COPY ["M.Challenge.Write.Application/M.Challenge.Write.Application.csproj", "M.Challenge.Write.Application/"]
RUN dotnet restore "M.Challenge.Write.Api/M.Challenge.Write.Api.csproj"
COPY . .
WORKDIR "/src/M.Challenge.Write.Api"
RUN dotnet build "M.Challenge.Write.Api.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "M.Challenge.Write.Api.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "M.Challenge.Write.Api.dll", "--environment=Production"]