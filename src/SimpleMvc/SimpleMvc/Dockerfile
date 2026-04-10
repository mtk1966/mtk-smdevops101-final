# 1. Aşama: Çalışma Ortamı (Base)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Aşama: Derleme (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Sadece .csproj dosyasını kopyalayıp restore yapıyoruz (Cache avantajı için)
COPY ["SimpleMvc/SimpleMvc.csproj", "SimpleMvc/"]
RUN dotnet restore "SimpleMvc/SimpleMvc.csproj"

# Tüm dosyaları kopyalayıp derliyoruz
COPY . .
WORKDIR "/src/SimpleMvc"
RUN dotnet build "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Aşama: Yayınlama
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Aşama: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER root

# 2. Klasörü zorla oluştur ve sahipliğini kısıtlı 'app' kullanıcısına ver ($APP_UID)
RUN mkdir -p /app/wwwroot/ClientLogs && chown -R $APP_UID /app/wwwroot/ClientLogs

# 3. Güvenlik için tekrar kısıtlı 'app' kullanıcısına dön
USER $APP_UID

ENTRYPOINT ["dotnet", "SimpleMvc.dll"]
