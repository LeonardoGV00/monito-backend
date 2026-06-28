FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["MonitoNet.Backend.csproj", "."]
RUN dotnet restore "MonitoNet.Backend.csproj"
COPY . .
RUN dotnet publish "MonitoNet.Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MonitoNet.Backend.dll"]
