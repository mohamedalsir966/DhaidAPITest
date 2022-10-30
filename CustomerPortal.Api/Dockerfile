#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerPortal.Api/CustomerPortal.Api.csproj", "CustomerPortal.Api/"]
COPY ["CustomerPortal.Infrastructure/CustomerPortal.Infrastructure.csproj", "CustomerPortal.Infrastructure/"]
COPY ["CustomerPortal.Service/CustomerPortal.Service.csproj", "CustomerPortal.Service/"]
COPY ["CustomerPortal.Persistence/CustomerPortal.Persistence.csproj", "CustomerPortal.Persistence/"]
COPY ["CustomerPortal.Domain/CustomerPortal.Domain.csproj", "CustomerPortal.Domain/"]
RUN dotnet restore "CustomerPortal.Api/CustomerPortal.Api.csproj"
COPY . .
WORKDIR "/src/CustomerPortal.Api"
RUN dotnet build "CustomerPortal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerPortal.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerPortal.Api.dll"]