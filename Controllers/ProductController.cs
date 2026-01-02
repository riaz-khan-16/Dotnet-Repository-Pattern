using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Models;
using Repository_Pattern.Services;
using Repository_Pattern.Entity;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IDBService<Product> _dbService;

    public ProductsController(IDBService<Product> service)
    {
        _dbService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    { 
        
        return Ok( await _dbService.GetAllAsync()); 
    
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var product = await _dbService.GetByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _dbService.CreateAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }



    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _dbService.DeleteAsync(id);
        return NoContent();
    }
}
