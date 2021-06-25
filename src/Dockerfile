# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
EXPOSE 80

#COPY *.sln .
COPY Web/WebMVC/*.csproj ./Web/WebMVC/
RUN dotnet restore "Web/WebMVC/WebMVC.csproj"

#
COPY . ./
WORKDIR /app/Web/WebMVC
RUN dotnet build "WebMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMVC.csproj" -c Release -o /app/publish

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMVC.dll"]