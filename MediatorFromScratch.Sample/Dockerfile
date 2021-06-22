FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MediatorFromScratch.Sample/MediatorFromScratch.Sample.csproj", "MediatorFromScratch.Sample/"]
RUN dotnet restore "MediatorFromScratch.Sample/MediatorFromScratch.Sample.csproj"
COPY . .
WORKDIR "/src/MediatorFromScratch.Sample"
RUN dotnet build "MediatorFromScratch.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediatorFromScratch.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediatorFromScratch.Sample.dll"]
