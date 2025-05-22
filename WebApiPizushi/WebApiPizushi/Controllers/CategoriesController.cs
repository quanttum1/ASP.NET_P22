using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPizushi.Data;
using WebApiPizushi.Data.Entities;
using WebApiPizushi.Interfaces;
using WebApiPizushi.Models.Category;

namespace WebApiPizushi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(AppDbPizushiContext pizushiContext,
    IMapper mapper, IImageService imageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var model = await mapper.ProjectTo<CategoryItemModel>(pizushiContext.Categories)
            .ToListAsync();

        return Ok(model);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var model = await mapper
            .ProjectTo<CategoryItemModel>(pizushiContext.Categories.Where(x => x.Id == id))
            .SingleOrDefaultAsync();
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }



    [HttpPost]
    public async Task<IActionResult> Create(
        //[FromServices] IValidator<CategoryCreateModel> validator,
        [FromForm] CategoryCreateModel model)
    {
        //var result = await validator.ValidateAsync(model);

        //if (!result.IsValid)
        //{
        //    return BadRequest(result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        //}

        var entity = mapper.Map<CategoryEntity>(model);
        entity.Image = await imageService.SaveImageAsync(model.ImageFile!);
        await pizushiContext.Categories.AddAsync(entity);
        await pizushiContext.SaveChangesAsync();
        return Ok(entity);
    }

    [HttpPut] //Якщо є метод Put - це значить змінна даних
    public async Task<IActionResult> Edit([FromForm] CategoryEditModel model)
    {
        var existing = await pizushiContext.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (existing == null)
        {
            return NotFound();
        }

        existing = mapper.Map(model, existing);

        if (model.ImageFile != null)
        {
            await imageService.DeleteImageAsync(existing.Image);
            existing.Image = await imageService.SaveImageAsync(model.ImageFile);
        }
        await pizushiContext.SaveChangesAsync();

        return Ok();
    }
}
