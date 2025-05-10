using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSmonder.Data;
using WebSmonder.Models.Helpers;
using WebSmonder.Models.Product;

namespace WebSmonder.Controllers;

public class ProductsController(AppSmonderDbContext context, 
    IMapper mapper) : Controller
{
    public async Task<IActionResult> Index() //Це будь-який web результат - View - сторінка, Файл, PDF, Excel
    {
        ViewBag.Title = "Продукти";
        var searchModel = new ProductSearchViewModel();

        searchModel.Categories = await mapper.ProjectTo<SelectItemViewModel>(context.Categories)
            .ToListAsync();

        searchModel.Categories.Insert(0, new SelectItemViewModel
        {
            Id = 0,
            Name = "Оберіть категорію"
        });

        var model = new ProductListViewModel();
        model.Products = mapper.ProjectTo<ProductItemViewModel>(context.Products).ToList();
        model.Search = searchModel;

        return View(model);
    }
}
