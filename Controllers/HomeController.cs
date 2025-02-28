using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Complte_website.Models;

namespace Complte_website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EcomContext context;

    public HomeController(ILogger<HomeController> logger,EcomContext Context)
    {
        _logger = logger;
        context = Context;
        }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(User user)
        {
        user.Role = "user";
        var check= context.Users.FirstOrDefault(x=>x.Email==user.Email && x.Role=="user");
        if (check != null) { 
            TempData["Regerrormsg"] = "Email Already Exists";
            return RedirectToAction("Login");
            }
        context.Users.Add(user);
        context.SaveChanges();
        TempData["Regmsg"]="Registration Successfull";
        return RedirectToAction("Login");
        }
    [HttpPost]
    public IActionResult Login(User user)
        {
        var user1 = context.Users.FirstOrDefault(x=>x.Email==user.Email && x.Password==user.Password);
        if (user1 != null)
            {
            HttpContext.Session.SetString("Email", user1.Email);
            if (user1.Role == "admin")
                {
                return RedirectToAction("Index", "Admin");
                }
            else
                {
                return RedirectToAction("Index");
                }
                }
        else
            {
            TempData["Loginmsg"] = "Invalid Credentials";
            return RedirectToAction("Login");
            }
        }

    public IActionResult Logout()
        {
        HttpContext.Session.Remove("Email");
        return RedirectToAction("Login");
        }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
