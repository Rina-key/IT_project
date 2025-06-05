#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["./IT_project/IT_project.csproj", "IT_project/"]
#RUN dotnet restore "IT_project/IT_project.csproj"
#COPY . .
#WORKDIR "/src/IT_project"
#RUN dotnet build "IT_project.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "IT_project.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "IT_project.dll"]

# Используем многостадийную сборку
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# 1. Копируем ТОЛЬКО файлы проектов (это важно для кэширования)
COPY ["IT_project/IT_project.csproj", "IT_project/"]
RUN dotnet restore "IT_project/IT_project.csproj"

# 2. Копируем весь исходный код
COPY . .

# 3. Собираем и публикуем проект
WORKDIR "/src/IT_project"
RUN dotnet publish -c Release -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "IT_project.dll"]