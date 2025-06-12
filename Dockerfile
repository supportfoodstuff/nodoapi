# Use the official .NET runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY *.sln .

# Copy all project files
COPY NoDoPayApi/*.csproj ./NoDoPayApi/
COPY ApplicationLayer/*.csproj ./ApplicationLayer/
COPY InfrastructureLayer/*.csproj ./InfrastructureLayer/
COPY CoreLayer/*.csproj ./CoreLayer/

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build the solution
RUN dotnet build -c Release -o /app/build

# Publish the API project
FROM build AS publish
RUN dotnet publish "NoDoPayApi/NoDoPayApi.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NoDoPayApi.dll"]