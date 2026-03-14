FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Her şeyi kopyala
COPY . .

# İçeride ne var ne yok terminale yazdır (Hata burada kopacak)
RUN ls -R

# Eğer dosya ismi farklıysa (küçük harf vb.) hata vermemesi için wildcard kullanalım
RUN dotnet restore *.csproj

RUN dotnet build *.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish *.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Buraya dikkat: DLL ismini projene göre güncellemen gerekebilir!
ENTRYPOINT ["dotnet", "SimpleMvc.dll"]
