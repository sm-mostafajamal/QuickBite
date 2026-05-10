# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy project files (correct paths)
COPY ["QuickBite.API/QuickBite.API.csproj", "QuickBite.API/"]
COPY ["QuickBite.Application/QuickBite.Application.csproj", "QuickBite.Application/"]
COPY ["QuickBite.Domain/QuickBite.Domain.csproj", "QuickBite.Domain/"]
COPY ["QuickBite.Infrastructure/QuickBite.Infrastructure.csproj", "QuickBite.Infrastructure/"]
COPY ["QuickBite.Contracts/QuickBite.Contracts.csproj", "QuickBite.Contracts/"]

# Restore only API project (it will restore dependencies)
RUN dotnet restore "QuickBite.API/QuickBite.API.csproj"

# Copy everything
COPY . .

# Move into API project
WORKDIR "/src/QuickBite.API"

# Publish
RUN dotnet publish -c Release -o /app/publish

# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "QuickBite.API.dll"]