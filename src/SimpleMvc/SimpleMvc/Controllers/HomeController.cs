using Microsoft.AspNetCore.Mvc;
using SimpleMvc.Models;
using System.Diagnostics;

namespace SimpleMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _cnf;

        public HomeController(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _env = environment;
            _cnf = configuration;
        }
        [HttpGet("health")]
        public IActionResult GetHealth()
        {
            return Ok(new
            {
                timestamp = DateTime.UtcNow, // Good for checking if the app is frozen
                result = StatusCodes.Status200OK
            });
        }
        [HttpGet("info")]
        public IActionResult Info()
        {

            // Env içindeki STUDENT_NAME'i oku
            var studentName = _cnf["STUDENT_NAME"] ?? "İsim Tanımlanmadı";

            // Mevcut ortamı oku (Production/Development)
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            return Ok(new
            {
                machine_Name = Environment.MachineName,
                machine_Os = Environment.OSVersion,
                student = studentName ?? "Isim Bulunamadi",
                notum_lutfen_okuyun = "Merhaba hocam sizinle son kez burda konuşmak beni mutlu ediyor.Kesinlik 6 hafta boyunca çok iyi bir zaman geçirdik bunun için teşekkür ederim ayrıca vir sonraki oyun gününü en yakın zamanda yapalım;) görüşmek üzere.",
                environment = environment,
                serverTimeUtc = DateTime.UtcNow
            });
        }
    }
}
