# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy solution and restore
COPY MyWebAPI/*.csproj ./MyWebAPI/
RUN dotnet restore ./MyWebAPI/MyWebAPI.csproj

# Copy source and publish
COPY . .
WORKDIR /src/MyWebAPI
RUN dotnet publish -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyWebAPI.dll"]