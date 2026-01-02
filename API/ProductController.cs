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
        
        return Ok( await _dbService.GetAllItemAsync()); 
    
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await _dbService.GetItemByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product item)
    {
        await _dbService.SaveItemAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }





    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _dbService.DeleteItemByIdAsync(id);
        return NoContent();
    }
}
