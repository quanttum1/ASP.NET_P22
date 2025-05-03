using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebSmonder.Data;
using WebSmonder.Models.Product;

namespace WebSmonder.Controllers;

public class ProductsController(AppSmonderDbContext context, 
    IMapper mapper) : Controller
{
    public IActionResult Index() //Це будь-який web результат - View - сторінка, Файл, PDF, Excel
    {
        ViewBag.Title = "Категорії";
        var model = mapper.ProjectTo<ProductItemViewModel>(context.Products).ToList();
        return View(model);
    }
}
