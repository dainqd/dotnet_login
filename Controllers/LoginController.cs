using System.Security.Claims;
using Auth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult UserLogin()
    {
        return View();
    }

    [HttpPost]
    public ActionResult UserLogin([Bind] Users userModel)
    {
        // username = anet  
        var user = new Users().GetUsers().Where(u => u.UserName == userModel.UserName).SingleOrDefault();

        if (user != null)
        {
            var userClaims = new List<Claim>()
            {
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");
        }

        return View(user);
    }

    [HttpGet]
    public ActionResult UserAccessDenied()
    {
        return View();
    }
}