FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Projector/Projector.csproj", "Projector/"]
RUN dotnet restore "Projector/Projector.csproj"
COPY . .
WORKDIR "/src/Projector"
RUN dotnet build "Projector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projector.dll"]
