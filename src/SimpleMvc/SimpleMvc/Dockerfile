# 1. Aşama: Uygulamanın çalışacağı hafif ortam
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Aşama: Kodun derleneceği SDK ortamı
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Dosyaları direkt bulunduğun yerden kopyalıyoruz
COPY ["SimpleMvc.csproj", "."]
RUN dotnet restore "SimpleMvc.csproj"

COPY . .
RUN dotnet build "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Aşama: Yayınlama
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Aşama: Final (Sadece derlenmiş dosyalar)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMvc.dll"]
