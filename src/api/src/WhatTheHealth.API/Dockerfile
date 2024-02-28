#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 4040

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WhatTheHealth.API/WhatTheHealth.API.csproj", "src/WhatTheHealth.API/"]
COPY ["src/WhatTheHealth.Core/WhatTheHealth.Core.csproj", "src/WhatTheHealth.Core/"]
COPY ["src/WhatTheHealth.Domain/WhatTheHealth.Domain.csproj", "src/WhatTheHealth.Domain/"]
COPY ["src/WhatTheHealth.Infrastructure/WhatTheHealth.Infrastructure.csproj", "src/WhatTheHealth.Infrastructure/"]
RUN dotnet restore "./src/WhatTheHealth.API/./WhatTheHealth.API.csproj"
COPY . .
WORKDIR "/src/src/WhatTheHealth.API"
RUN dotnet build "./WhatTheHealth.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WhatTheHealth.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhatTheHealth.API.dll"]