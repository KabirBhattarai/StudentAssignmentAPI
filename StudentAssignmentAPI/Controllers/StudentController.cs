using Microsoft.AspNetCore.Mvc;

namespace StudentAssignmentAPI.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}