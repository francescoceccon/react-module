FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY *.sln ./
COPY Squader/*.csproj ./Squader/
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/

RUN dotnet restore

COPY Squader/ ./Squader/
COPY Application/ ./Application/
COPY Domain/ ./Domain/
COPY Infrastructure/ ./Infrastructure/

WORKDIR /src/Squader
RUN dotnet build "Squader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Squader.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
EXPOSE 8080
EXPOSE 8081
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Squader.dll"]