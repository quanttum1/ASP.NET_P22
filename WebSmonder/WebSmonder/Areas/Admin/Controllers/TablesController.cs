using Microsoft.AspNetCore.Mvc;

namespace WebSmonder.Areas.Admin.Controllers;

[Area("Admin")]
public class TablesController : Controller
{
  public IActionResult Basic() => View();
}
