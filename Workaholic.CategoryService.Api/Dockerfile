FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Workaholic.CategoryService.Api/Workaholic.CategoryService.Api.csproj", "Workaholic.CategoryService.Api/"]
COPY ["Workaholic.CategoryService.Repository/Workaholic.CategoryService.Repository.csproj", "Workaholic.CategoryService.Repository/"]
COPY ["Workaholic.CategoryService.Domain/Workaholic.CategoryService.Domain.csproj", "Workaholic.CategoryService.Domain/"]
RUN dotnet restore "Workaholic.CategoryService.Api/Workaholic.CategoryService.Api.csproj"
COPY . .
WORKDIR "/src/Workaholic.CategoryService.Api"
RUN dotnet build "Workaholic.CategoryService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Workaholic.CategoryService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Workaholic.CategoryService.Api.dll"]
