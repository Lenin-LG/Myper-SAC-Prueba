# -------- RUNTIME --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# -------- BUILD --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copiar solución completa
COPY . .

# restaurar usando el proyecto API
RUN dotnet restore "./Trabajadores/Trabajadores.csproj"

# publicar el proyecto API
RUN dotnet publish "./Trabajadores/Trabajadores.csproj" -c Release -o /app/publish

# -------- FINAL --------
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Trabajadores.dll"]
