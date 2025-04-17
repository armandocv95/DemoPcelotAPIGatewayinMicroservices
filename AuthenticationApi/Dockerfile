# Usa la imagen SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia los archivos de proyecto
COPY ["AuthenticationApi/AuthenticationApi.csproj", "AuthenticationApi/"]
COPY ["SharedLibrary/SharedLibrary.csproj", "SharedLibrary/"]

# Restaura dependencias
RUN dotnet restore "AuthenticationApi/AuthenticationApi.csproj"

# Copia todo el código fuente
COPY . .

# Publica la app
WORKDIR /src/AuthenticationApi
RUN dotnet publish -c Release -o /app/publish

# Usa la imagen runtime para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AuthenticationApi.dll"]
