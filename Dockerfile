# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY MyWebAPI/*.csproj ./MyWebAPI/
RUN dotnet restore ./MyWebAPI/MyWebAPI.csproj

COPY . .
WORKDIR /src/MyWebAPI
RUN dotnet publish -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyWebAPI.dll"]