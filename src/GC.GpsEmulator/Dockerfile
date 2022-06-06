FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GC.GpsEmulator/GC.GpsEmulator.csproj", "GC.GpsEmulator/"]
RUN dotnet restore "src/GC.GpsEmulator/GC.GpsEmulator.csproj"
COPY . .
WORKDIR "/src/GC.GpsEmulator"
RUN dotnet build "GC.GpsEmulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GC.GpsEmulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GC.GpsEmulator.dll"]
