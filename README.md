# 🚀 mtk-smdevops101-final

![.NET](https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?style=for-the-badge&logo=github-actions&logoColor=white)
![Nginx](https://img.shields.io/badge/Nginx-009639?style=for-the-badge&logo=nginx&logoColor=white)

## 📝 Proje Açıklaması
Bu proje, modern bir **ASP.NET Core MVC** uygulamasının Dockerize edilmesi ve CI/CD süreçlerinin **GitHub Actions** üzerinden yönetilmesini kapsayan bir DevOps bitirme projesidir. Uygulama, **Nginx** ters proxy (reverse proxy) arkasında çalışacak şekilde yapılandırılmıştır.

---

## 🛠 Kullanılan Teknolojiler
* **Framework:** ASP.NET Core MVC (.NET 8.0)
* **Containerization:** Docker & Docker Compose
* **Web Server:** Nginx (Reverse Proxy)
* **CI/CD:** GitHub Actions
* **Database (Opsiyonel):** PostgreSQL (Yapılandırmaya bağlı)

---

## 💻 Local Çalıştırma Adımları
Projeyi Docker olmadan, kendi geliştirme ortamınızda çalıştırmak için:

1.  **Repoyu klonlayın:**
    ```bash
    git clone [https://github.com/mtk1966/mtk-smdevops101-final.git](https://github.com/mtk1966/mtk-smdevops101-final.git)
    cd mtk-smdevops101-final
    ```
2.  **Bağımlılıkları yükleyin:**
    ```bash
    dotnet restore src/SimpleMvc/SimpleMvc.csproj
    ```
3.  **Uygulamayı başlatın:**
    ```bash
    dotnet run --project src/SimpleMvc/SimpleMvc.csproj
    ```

---

## 🐳 Docker ile Çalıştırma Adımları
Sadece uygulama imajını oluşturup tek başına çalıştırmak için:

1.  **İmajı oluşturun:**
    ```bash
    docker build -t mtk-simplemvc -f src/SimpleMvc/Dockerfile .
    ```
2.  **Konteynerı başlatın:**
    ```bash
    docker run -d -p 8080:80 --name mtk-app mtk-simplemvc
    ```

---

## 🏗 Docker Compose ile Çalıştırma Adımları
Tüm yapıyı (Uygulama + Nginx) tek komutla ayağa kaldırmak için en ideal yöntem budur:

```bash
docker-compose up -d --build
