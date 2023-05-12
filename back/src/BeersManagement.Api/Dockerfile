FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["back/BeersManagement.Api/BeersManagement.Api.csproj", "back/BeersManagement.Api/"]
RUN dotnet restore "back/BeersManagement.Api/BeersManagement.Api.csproj"
COPY . .
WORKDIR "/src/back/BeersManagement.Api"
RUN dotnet build "BeersManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeersManagement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeersManagement.Api.dll"]
