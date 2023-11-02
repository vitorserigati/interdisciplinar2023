using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interdisciplinar2023.Data;
using Microsoft.AspNetCore.Identity;
using Interdisciplinar2023.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        if (!ModelState.IsValid) return View(loginVM);
        var user = await _userManager.FindByEmailAsync(loginVM.Email);

        // User Found check Password
        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (passwordCheck)
            {
                // Password Correct, sign in
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
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
        var response = new RegistrationViewModel();
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationViewModel inputVM)
    {
        if (!ModelState.IsValid) return View(inputVM);

        var user = await _userManager.FindByEmailAsync(inputVM.Email);
        if (user != null)
        {
            TempData["Error"] = "Este e-mail Já está em uso";
        }

        var newUser = new User
        {
            Email = inputVM.Email,
            UserName = inputVM.UserName,
            Celphone = inputVM.Celphone,
            Phone = inputVM.Celphone
        };

        var newUserResponse = await _userManager.CreateAsync(newUser, inputVM.Password);

        return RedirectToAction("Login");
    }

    [Authorize]
    public async Task<IActionResult> Signout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Login");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
