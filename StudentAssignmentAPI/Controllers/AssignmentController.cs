using Microsoft.AspNetCore.Mvc;

namespace StudentAssignmentAPI.Controllers;

public class AssignmentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}