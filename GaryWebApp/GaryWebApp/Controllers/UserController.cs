using System;
using System.Threading.Tasks;
using GaryWebApp.Business.Services;
using GaryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaryWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /User/
        public IActionResult Register()
        {
            return View();
        }

		// POST: /User/Register
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    try{
						await _userService.CreateAsync(model.Username, model.Password);
						return View("RegisterSuccess", model);
                    }
                    catch (Exception ex)
                    {
                        
                    } 
				}
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
