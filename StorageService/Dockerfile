FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StorageService/StorageService.csproj", "StorageService/"]
COPY ["StorageService.Application/StorageService.Application.csproj", "StorageService.Application/"]
COPY ["StorageService.Domain/StorageService.Domain.csproj", "StorageService.Domain/"]
COPY ["StorageService.DAL/StorageService.DAL.csproj", "StorageService.DAL/"]
RUN dotnet restore "StorageService/StorageService.csproj"
COPY . .
WORKDIR "/src/StorageService"
RUN dotnet build "StorageService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StorageService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StorageService.dll"]