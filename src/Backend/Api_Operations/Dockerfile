#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["src/Backend/Api_Operations/Api_Operations.csproj", "src/Backend/Api_Operations/"]
RUN dotnet restore "src/Backend/Api_Operations/Api_Operations.csproj"
COPY . .
WORKDIR "/src/src/Backend/Api_Operations"
RUN dotnet build "Api_Operations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api_Operations.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api_Operations.dll"]