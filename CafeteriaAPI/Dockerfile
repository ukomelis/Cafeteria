#Build API image

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as build
WORKDIR /source
COPY . .
RUN dotnet restore "./CafeteriaAPI/CafeteriaAPI.csproj" --disable-parallel
RUN dotnet publish "./CafeteriaAPI/CafeteriaAPI.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as runtime
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
ENTRYPOINT [ "dotnet", "CafeteriaAPI.dll" ]