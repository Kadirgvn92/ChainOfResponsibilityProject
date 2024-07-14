using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibilityProject.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(CustomerProcessViewModel model)
    {
        return View(model);
    }
}
