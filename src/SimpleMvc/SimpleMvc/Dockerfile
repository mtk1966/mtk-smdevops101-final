# 1. Aşama: Çalışma Ortamı (Base)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Aşama: Derleme (Build)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Sadece .csproj dosyasını kopyalayıp restore yapıyoruz (Cache avantajı için)
COPY ["SimpleMvc/SimpleMvc.csproj", "SimpleMvc/"]
RUN dotnet restore "SimpleMvc/SimpleMvc.csproj"

# Tüm dosyaları kopyalayıp derliyoruz
COPY . .
WORKDIR "/src/SimpleMvc"
RUN dotnet build "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Aşama: Yayınlama (Publish)
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Aşama: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMvc.dll"]