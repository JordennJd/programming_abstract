using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataBaseCore;
using Microsoft.AspNetCore.Authorization;


namespace PersAcc.Controllers
{
	public class PersonalPageController : Controller
	{
        public async Task<IActionResult> PersonalAccount()
        {
            return View();
        }
    }
}

