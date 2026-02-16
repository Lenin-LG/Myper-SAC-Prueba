# -------- RUNTIME --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# -------- BUILD --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "./Trabajadores.Web/Trabajadores.Web.csproj"
RUN dotnet publish "./Trabajadores.Web/Trabajadores.Web.csproj" -c Release -o /app/publish

# -------- FINAL --------
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Trabajadores.Web.dll"]
