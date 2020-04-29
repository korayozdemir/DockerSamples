FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY bin/Release/netcoreapp3.0/publish .
ENTRYPOINT ["dotnet","DockerSamples.Docker02Web.dll"]