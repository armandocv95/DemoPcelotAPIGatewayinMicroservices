# Usa la imagen SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia los archivos de proyecto necesarios
COPY ["Identity/Identity.csproj", "Identity/"]
COPY ["SharedLibrary/SharedLibrary.csproj", "SharedLibrary/"]

# Restaura dependencias
RUN dotnet restore "Identity/Identity.csproj"

# Copia todo el código fuente
COPY . .

# Publica la app
WORKDIR /src/Identity
RUN dotnet publish "Identity.csproj" -c Release -o /app/publish

# Usa la imagen runtime para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Identity.dll"]
