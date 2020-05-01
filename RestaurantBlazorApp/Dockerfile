# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /restaurantApp

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ISI-Restaurant.BlazorApp/*.csproj ./ISI-Restaurant.BlazorApp/
COPY ISI-Restaurant.RestApiClient/*.csproj ./ISI-Restaurant.RestApiClient/
COPY ISI-Restaurant.Shared/*.csproj ./ISI-Restaurant.Shared/
RUN dotnet restore ISI-Restaurant.BlazorApp/ISI-Restaurant.BlazorApp.csproj

# copy everything else and build app
COPY ISI-Restaurant.BlazorApp/ ISI-Restaurant.BlazorApp/
COPY ISI-Restaurant.RestApiClient/ ISI-Restaurant.RestApiClient/
COPY ISI-Restaurant.Shared/ ISI-Restaurant.Shared/
WORKDIR /restaurantApp/ISI-Restaurant.BlazorApp
RUN dotnet build -c release --no-restore

RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ISI-Restaurant.BlazorApp.dll"]
