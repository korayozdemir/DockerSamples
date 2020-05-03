FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster as build
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . .
Run dotnet restore
Run dotnet publish DockerSamples.Docker03WebCLI.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS="http://*:4500"
ENTRYPOINT ["dotnet","DockerSamples.Docker03WebCLI.dll"]