# 1. Aşama: Çalışma Ortamı (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Aşama: Derleme (SDK)
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Dosyaları kopyalıyoruz
COPY . .

# Dosyanın olduğu klasöre git
WORKDIR "/src/src/SimpleMvc/SimpleMvc"

# Restore ve Build
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
ENTRYPOINT ["dotnet", "SimpleMvc.dll"]
