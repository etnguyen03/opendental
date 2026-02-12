FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["CloudDentalOffice.Portal/CloudDentalOffice.Portal.csproj", "CloudDentalOffice.Portal/"]
RUN dotnet restore "CloudDentalOffice.Portal/CloudDentalOffice.Portal.csproj"
COPY . .
WORKDIR "/src/CloudDentalOffice.Portal"
RUN dotnet build "CloudDentalOffice.Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudDentalOffice.Portal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudDentalOffice.Portal.dll"]
