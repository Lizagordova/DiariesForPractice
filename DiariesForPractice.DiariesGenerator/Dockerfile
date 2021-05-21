FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DiariesForPractice.DiariesGenerator/DiariesForPractice.DiariesGenerator.csproj", "DiariesForPractice.DiariesGenerator/"]
RUN dotnet restore "DiariesForPractice.DiariesGenerator/DiariesForPractice.DiariesGenerator.csproj"
COPY . .
WORKDIR "/src/DiariesForPractice.DiariesGenerator"
RUN dotnet build "DiariesForPractice.DiariesGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiariesForPractice.DiariesGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiariesForPractice.DiariesGenerator.dll"]
