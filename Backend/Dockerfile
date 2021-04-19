FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build-env
WORKDIR /KeyboardRacer

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
WORKDIR /KeyboardRacer
COPY --from=build-env /KeyboardRacer/out .
ENTRYPOINT ["dotnet", "KeyboardRacer.dll"]
