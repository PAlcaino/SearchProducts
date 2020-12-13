#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ProductsSearch.Web/ProductsSearch.Web.csproj", "ProductsSearch.Web/"]
COPY ["ProductsSearch.Core/ProductsSearch.Core.csproj", "ProductsSearch.Core/"]
COPY ["ProductsSearch.Common/ProductsSearch.Common.csproj", "ProductsSearch.Common/"]
RUN dotnet restore "ProductsSearch.Web/ProductsSearch.Web.csproj"
COPY . .
WORKDIR "/src/ProductsSearch.Web"
RUN dotnet build "ProductsSearch.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsSearch.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsSearch.Web.dll"]