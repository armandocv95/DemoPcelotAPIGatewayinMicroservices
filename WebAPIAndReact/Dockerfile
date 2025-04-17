# Usa la imagen SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia los archivos de proyecto necesarios
COPY ["WebAPIAndReact/WebAPIAndReact.csproj", "WebAPIAndReact/"]
COPY ["SharedLibrary/SharedLibrary.csproj", "SharedLibrary/"]

# Restaura dependencias
RUN dotnet restore "WebAPIAndReact/WebAPIAndReact.csproj"

# Copia todo el código fuente
COPY . .

# Publica la app
WORKDIR /src/WebAPIAndReact
RUN dotnet publish "WebAPIAndReact.csproj" -c Release -o /app/publish

# Usa la imagen runtime para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WebAPIAndReact.dll"]
