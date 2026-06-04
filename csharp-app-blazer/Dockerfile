FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["csharp-app-blazer/csharp-app-blazer.csproj", "csharp-app-blazer/"]
RUN dotnet restore "csharp-app-blazer/csharp-app-blazer.csproj"

COPY . .
RUN dotnet build "csharp-app-blazer/csharp-app-blazer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "csharp-app-blazer/csharp-app-blazer.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "csharp-app-blazer.dll"]
