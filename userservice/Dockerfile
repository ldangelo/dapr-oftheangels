FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy domain project and build
COPY Domain/ /app/Domain
WORKDIR /app/Domain
RUN dotnet publish -c release

# Copy csproj and restore as distinct layers
#
# Copy everything else and build
COPY userservice/ /app/userservice
WORKDIR /app/userservice
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/userservice/out .
ENTRYPOINT ["dotnet", "userservice.dll"]
