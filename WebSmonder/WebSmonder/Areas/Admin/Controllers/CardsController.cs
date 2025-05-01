using Microsoft.AspNetCore.Mvc;

namespace WebSmonder.Areas.Admin.Controllers;

[Area("Admin")]
public class CardsController : Controller
{
  public IActionResult Basic() => View();
}
