using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSmonder.Data;
using WebSmonder.Data.Entities;
using WebSmonder.Models.Category;

namespace WebSmonder.Controllers;

public class CategoriesController(AppSmonderDbContext context, IMapper mapper) : Controller
{

    public IActionResult Index() //Це будь-який web результат - View - сторінка, Файл, PDF, Excel
    {
        var model = mapper.ProjectTo<CategoryItemViewModel>(context.Categories).ToList();
        return View(model);
    }

    [HttpGet] //Тепер він працює методом GET - це щоб побачити форму
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Create(CategoryCreateViewModel model)
    {
        var item = await context.Categories.SingleOrDefaultAsync(x => x.Name == model.Name);
        if (item != null) 
        {
            ModelState.AddModelError("Name", "Така категорія уже є!!!");
            return View(model);
        }
        item = mapper.Map<CategoryEntity>(model);
        await context.Categories.AddAsync(item);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
