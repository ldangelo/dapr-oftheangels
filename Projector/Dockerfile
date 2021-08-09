FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
EXPOSE 443

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "Projector.dll"]
