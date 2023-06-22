#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["src/Frontend/Sgotfhka/Sisgtfhka.csproj", "src/Frontend/Sgotfhka/"]
RUN dotnet restore "src/Frontend/Sgotfhka/Sisgtfhka.csproj"
COPY . .
WORKDIR "/src/src/Frontend/Sgotfhka"
RUN dotnet build "Sisgtfhka.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sisgtfhka.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sisgtfhka.dll"]