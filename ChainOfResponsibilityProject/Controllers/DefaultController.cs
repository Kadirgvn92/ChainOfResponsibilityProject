using ChainOfResponsibilityProject.ChainOfResponsibility;
using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibilityProject.Controllers;
public class DefaultController : Controller
{
    private readonly Context _context;

    public DefaultController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(CustomerProcessViewModel model)
    {
        Employee treasure = new Treasurer();
        Employee managerAsistant = new ManagerAsistant(_context);
        Employee manager = new Manager(_context);
        Employee areaManager = new AreaDirector(_context);

        treasure.SetNextApprover(managerAsistant);
        managerAsistant.SetNextApprover(manager);
        manager.SetNextApprover(areaManager);

        treasure.ProcessRequest(model);

        return View();
    }
}
