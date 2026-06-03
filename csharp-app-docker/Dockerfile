FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copiar el archivo de proyecto
COPY ["csharp-app/csharp-app.csproj", "csharp-app/"]

# Restaurar dependencias
RUN dotnet restore "csharp-app/csharp-app.csproj"

# Copiar todo el código
COPY . .

# Compilar la aplicación
RUN dotnet build "csharp-app/csharp-app.csproj" -c Release -o /app/build

# Publicar
FROM build AS publish
RUN dotnet publish "csharp-app/csharp-app.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/runtime:9.0

WORKDIR /app

# Copiar archivos publicados
COPY --from=publish /app/publish .

# Variables de entorno
ENV ASPNETCORE_URLS=http://+:5000
ENV DB_HOST=mysql
ENV DB_NAME=mvp_db
ENV DB_USER=mvp_user
ENV DB_PASSWORD=mvp_password

EXPOSE 5000

ENTRYPOINT ["dotnet", "csharp-app.dll"]
