using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly AppDbContext _context;
    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ActionResult<IEnumerable<Category>> GetCategoryProducts()
    {
        try
        {
            return _context.Categories.AsNoTracking().Include(p => p.Products).ToList();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        try
        {
            var categories = _context.Categories.AsNoTracking().ToList();
            if (categories == null)
                return NotFound();
            return categories;
        } 
        catch (Exception) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public ActionResult<Category> Get(int id)
    {
        try
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return NotFound();
            return category;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpPost]
    public ActionResult<Category> Post(Category category)
    {
        try
        {
            if (category == null)
                return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = category.CategoryId }, category);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<Category> Put(int id, Category category)
    {
        try
        {
            if (category == null || category.CategoryId != id)
                return BadRequest();

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Category> Delete(int id)
    {
        try
        {
            var category = _context.Categories.ToList().FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return NotFound($"Categoria com ID {id} não encontrada.");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }
}
