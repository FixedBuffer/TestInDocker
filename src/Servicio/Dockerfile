FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS restore
WORKDIR /source
COPY ["src/Servicio/Servicio.csproj", "src/Servicio/"]
COPY ["test/UnitTests/UnitTests.csproj", "test/UnitTests/"]
COPY ["*.sln", "."]
RUN dotnet restore 


FROM restore AS build
COPY . .
RUN dotnet build  -c Release --no-restore


FROM build AS test
VOLUME ["/source"]
ENTRYPOINT ["/bin/sh", "-c", "dotnet test -c Release --no-build --logger trx"]


FROM build AS publish
RUN dotnet publish "src/Servicio/Servicio.csproj" -c Release --no-build -o /app/publish 


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Servicio.dll"]