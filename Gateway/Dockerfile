# Usa una imagen base de .NET 9.0
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Usa la imagen SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Gateway/Gateway.csproj", "Gateway/"]
COPY ["SharedLibrary/SharedLibrary.csproj", "SharedLibrary/"]  # Incluye SharedLibrary si es necesario

RUN dotnet restore "Gateway/Gateway.csproj"
COPY . .
WORKDIR "/src/Gateway"
RUN dotnet build "Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway.csproj" -c Release -o /app/publish

# Finaliza el contenedor con la app publicada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.dll"]
