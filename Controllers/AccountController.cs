using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.Data;
using Microsoft.AspNetCore.Identity;
using Interdisciplinar2023.ViewModels;

namespace Interdisciplinar2023.Controllers;

public class AccountController : Controller
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController
        (ILogger<AccountController> logger, DataContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    public IActionResult Login()
    {
        LoginViewModel model = new LoginViewModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVM)
    {
        if(!ModelState.IsValid) return View(loginVM);
        var user = await _userManager.FindByEmailAsync(loginVM.Email);

        // User Found check Password
        if(user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (passwordCheck)
            {
                // Password Correct, sign in
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            // Password Incorrect
            TempData["Error"] = "Erro de credenciais. Por favor, tente outra vez";
            return View(loginVM);
        }
        // User not found
        TempData["Error"] = "Usuário não encontrado";
        return View(loginVM);
    }

    public IActionResult Register()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
