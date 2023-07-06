using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataBaseCore;
using PersAcc.Domain.ViewModels.Account;
using PersAcc.Domain.ViewModels.Error;
using PersAcc.Service.Implementations;
using PersAcc.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace PersAcc.Controllers;

public class AccountController : Controller
{

    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult RegistrationUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationUser(RegisterViewModel model)
    {
        // var response = await _accountService.Register(model);
        if (ModelState.IsValid)
        {
            var response = await _accountService.Register(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return RedirectToAction("AuthorizateUser", "Account");
            }
            ModelState.AddModelError("", response.Description);
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult AuthorizateUser() => View();


    [HttpPost]
    public async Task<IActionResult> AuthorizateUser(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _accountService.Login(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return RedirectToAction("PersonalAccount", "PersonalPage");
            }
            ModelState.AddModelError("", response.Description);
        }
        return View(model);

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

