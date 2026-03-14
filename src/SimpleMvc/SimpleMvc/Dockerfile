# 1. Aşama: Çalışma Ortamı
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Aşama: Derleme (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Dosyaları kopyalıyoruz
COPY . .

# SENİN BELİRTTİĞİN KONUMA GİDİYORUZ
WORKDIR "/src/src/SimpleMvc/SimpleMvc"

# Projeyi restore et ve derle
RUN dotnet restore "SimpleMvc.csproj"
RUN dotnet build "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Aşama: Yayınlama
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SimpleMvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Aşama: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Not: Eğer uygulama ismi farklıysa SimpleMvc.dll kısmını ona göre güncelle
ENTRYPOINT ["dotnet", "SimpleMvc.dll"]
