FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GC.Api/GC.Api.csproj", "GC.Api/"]
RUN dotnet restore "src/GC.Api/GC.Api.csproj"
COPY . .
WORKDIR "/src/GC.Api"
RUN dotnet build "GC.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GC.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GC.Api.dll"]
