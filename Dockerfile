# Use the official .NET 9.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY MenuDemo/MenuDemo.csproj MenuDemo/
RUN dotnet restore MenuDemo/MenuDemo.csproj

# Copy the rest of the application code
COPY MenuDemo/ MenuDemo/
WORKDIR /src/MenuDemo

# Build the application
RUN dotnet build MenuDemo.csproj -c Release -o /app/build
RUN dotnet publish MenuDemo.csproj -c Release -o /app/publish

# Use the official .NET 9.0 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published application
COPY --from=build /app/publish .

# Expose port 8080 (ASP.NET Core default in containers)
EXPOSE 8080

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

# Run the application
ENTRYPOINT ["dotnet", "MenuDemo.dll"]
