FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["userservice.csproj", "userservice/"]
RUN dotnet restore "userservice/userservice.csproj"
COPY . .
WORKDIR "/src/userservice"
RUN dotnet build "userservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "userservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "userservice.dll"]
