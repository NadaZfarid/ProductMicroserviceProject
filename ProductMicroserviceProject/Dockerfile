#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProductMicroserviceProject/ProductMicroserviceProject.csproj", "ProductMicroserviceProject/"]
RUN dotnet restore "ProductMicroserviceProject/ProductMicroserviceProject.csproj"
COPY . .
WORKDIR "/src/ProductMicroserviceProject"
RUN dotnet build "ProductMicroserviceProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMicroserviceProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroserviceProject.dll"]