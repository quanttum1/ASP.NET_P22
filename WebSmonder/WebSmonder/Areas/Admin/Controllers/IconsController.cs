using Microsoft.AspNetCore.Mvc;

namespace WebSmonder.Areas.Admin.Controllers;

[Area("Admin")]
public class IconsController : Controller
{
  public IActionResult RiIcons() => View();
}
