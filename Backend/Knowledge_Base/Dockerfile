#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/Knowledge_Base/Knowledge_Base.csproj", "Knowledge_Base/"]
COPY ["Backend/BusinessLogicLayer/BusinessLogicLayer.csproj", "BusinessLogicLayer/"]
COPY ["Backend/DataLayer/DataLayer.csproj", "DataLayer/"]
RUN dotnet restore "Knowledge_Base/Knowledge_Base.csproj"
COPY ./Backend/ .
WORKDIR "/src/Knowledge_Base"
RUN dotnet build "Knowledge_Base.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Knowledge_Base.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Knowledge_Base.dll"]