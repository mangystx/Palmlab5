FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PalmLab5Main/PalmLab5Main.csproj", "PalmLab5Main/"]
RUN dotnet restore "PalmLab5Main/PalmLab5Main.csproj"
COPY . .
WORKDIR "/src/PalmLab5Main"
RUN dotnet build "PalmLab5Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PalmLab5Main.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PalmLab5Main.dll"]
