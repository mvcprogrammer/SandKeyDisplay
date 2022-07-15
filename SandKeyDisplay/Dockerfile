FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SandKeyDisplay/SandKeyDisplay.csproj", "SandKeyDisplay/"]
COPY ["Display.Core/Display.Core.csproj", "Display.Core/"]
RUN dotnet restore "SandKeyDisplay/SandKeyDisplay.csproj"
COPY . .
WORKDIR "/src/SandKeyDisplay"
RUN dotnet build "SandKeyDisplay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SandKeyDisplay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SandKeyDisplay.dll"]
