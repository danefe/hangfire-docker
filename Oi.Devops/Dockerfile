FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY [".", "Oi.Devops/"]
RUN dotnet restore "Oi.Devops/Oi.Devops.csproj"
COPY . .
WORKDIR "/src/Oi.Devops"
RUN dotnet build "Oi.Devops.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Oi.Devops.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Oi.Devops.dll"]