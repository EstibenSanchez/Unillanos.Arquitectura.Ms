#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Unillanos.ArquitecturaMs.Usuario/Unillanos.ArquitecturaMs.Usuario.csproj", "Unillanos.ArquitecturaMs.Usuario/"]
RUN dotnet restore "Unillanos.ArquitecturaMs.Usuario/Unillanos.ArquitecturaMs.Usuario.csproj"
COPY . .
WORKDIR "/src/Unillanos.ArquitecturaMs.Usuario"
RUN dotnet build "Unillanos.ArquitecturaMs.Usuario.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unillanos.ArquitecturaMs.Usuario.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unillanos.ArquitecturaMs.Usuario.dll"]