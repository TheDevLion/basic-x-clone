FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore BasicXCloneBackend/BasicXCloneAPI/BasicXCloneAPI.csproj
RUN dotnet publish BasicXCloneBackend/BasicXCloneAPI/BasicXCloneAPI.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "BasicXCloneAPI.dll"]

