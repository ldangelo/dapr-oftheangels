FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "userservice.dll"]
