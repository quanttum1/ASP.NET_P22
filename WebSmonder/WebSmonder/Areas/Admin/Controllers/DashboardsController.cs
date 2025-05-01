using Microsoft.AspNetCore.Mvc;

namespace WebSmonder.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardsController : Controller
{
  public IActionResult Index() => View();
}
