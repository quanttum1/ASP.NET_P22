using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using WebSmonder.Data;
using WebSmonder.Data.Entities;
using WebSmonder.Interfaces;
using WebSmonder.Models.Category;

namespace WebSmonder.Controllers;

public class CategoriesController(AppSmonderDbContext context, 
    IMapper mapper, IImageService imageService) : Controller
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
        var entity = await context.Categories.SingleOrDefaultAsync(x => x.Name == model.Name);
        if (entity != null) 
        {
            ModelState.AddModelError("Name", "Така категорія уже є!!!");
            return View(model);
        }

        entity = mapper.Map<CategoryEntity>(model);
        entity.ImageUrl = await imageService.SaveImageAsync(model.ImageFile);
        await context.Categories.AddAsync(entity);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await context.Categories.SingleOrDefaultAsync(x=>x.Id==id);
        if (category == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(category.ImageUrl))
        {
            await imageService.DeleteImageAsync(category.ImageUrl);
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


}
