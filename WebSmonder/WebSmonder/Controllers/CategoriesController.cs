using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebSmonder.Data;
using WebSmonder.Models.Category;

namespace WebSmonder.Controllers;


//public class CategoriesController : Controller
//{
//    private readonly AppSmonderDbContext _context;
//    private readonly IMapper _mapper;
//    public CategoriesController(AppSmonderDbContext context, IMapper maper)
//    {
//        _context = context;
//        _mapper = maper;  
//    }

//    public IActionResult Index() //Це будь-який web результат - View - сторінка, Файл, PDF, Excel
//    {
//        var model = _mapper.ProjectTo<CategoryItemViewModel>(_context.Categories).ToList();
//        return View(model);
//    }
//}


public class CategoriesController(AppSmonderDbContext context, IMapper mapper) : Controller
{

    public IActionResult Index() //Це будь-який web результат - View - сторінка, Файл, PDF, Excel
    {
        var model = mapper.ProjectTo<CategoryItemViewModel>(context.Categories).ToList();
        return View(model);
    }
}
