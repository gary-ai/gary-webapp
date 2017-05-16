using GaryWebApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaryWebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
