FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["BasicMicroserviceApp.Author.Service.Api/BasicMicroserviceApp.Author.Service.Api.csproj", "BasicMicroserviceApp.Author.Service.Api/"]
COPY ["BasicMicroserviceApp.Author.Service/BasicMicroserviceApp.Author.Service.csproj", "BasicMicroserviceApp.Author.Service/"]
RUN dotnet restore "BasicMicroserviceApp.Author.Service.Api/BasicMicroserviceApp.Author.Service.Api.csproj"

COPY . .
WORKDIR /src
RUN dotnet build "BasicMicroserviceApp.Author.Service.Api/BasicMicroserviceApp.Author.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicMicroserviceApp.Author.Service.Api/BasicMicroserviceApp.Author.Service.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicMicroserviceApp.Author.Service.Api.dll"]