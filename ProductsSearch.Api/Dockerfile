FROM mcr.microsoft.com/azure-functions/dotnet:3.0 AS base
WORKDIR /home/site/wwwroot
EXPOSE 7071
EXPOSE 27017

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ProductsSearch.Api/ProductsSearch.Api.csproj", "ProductsSearch.Api/"]
COPY ["ProductsSearch.Core/ProductsSearch.Core.csproj", "ProductsSearch.Core/"]
COPY ["ProductsSearch.Common/ProductsSearch.Common.csproj", "ProductsSearch.Common/"]
COPY ["ProductsSearch.Infrastructure/ProductsSearch.Infrastructure.csproj", "ProductsSearch.Infrastructure/"]
RUN dotnet restore "ProductsSearch.Api/ProductsSearch.Api.csproj"
COPY . .
WORKDIR "/src/ProductsSearch.Api"
RUN dotnet build "ProductsSearch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsSearch.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true