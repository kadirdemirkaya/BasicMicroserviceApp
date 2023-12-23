FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["BasicMicroserviceApp.Article.Service.Api/BasicMicroserviceApp.Article.Service.Api.csproj", "BasicMicroserviceApp.Article.Service.Api/"]
COPY ["BasicMicroserviceApp.Article.Service/BasicMicroserviceApp.Article.Service.csproj", "BasicMicroserviceApp.Article.Service/"]
RUN dotnet restore "BasicMicroserviceApp.Article.Service.Api/BasicMicroserviceApp.Article.Service.Api.csproj"

COPY . .
WORKDIR /src
RUN dotnet build "BasicMicroserviceApp.Article.Service.Api/BasicMicroserviceApp.Article.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicMicroserviceApp.Article.Service.Api/BasicMicroserviceApp.Article.Service.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicMicroserviceApp.Article.Service.Api.dll"]