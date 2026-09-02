using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly AppDbContext _context;
    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        try
        {
            var products = _context.Products.AsNoTracking().ToList();
            if (products == null)
            {
                return NotFound();
            }
            return products;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpGet("{id:int}", Name="GetProduct")]
    public ActionResult<Product> Get(int id)
    {
        try
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
            if (product is null)
                return NotFound();
            return product;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpPost]
    public ActionResult Post(Product product)
    {
        try
        {
            if (product is null)
                return BadRequest();

            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        try
        {
            if (id != product.ProductId)
                return BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product is null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }
}
