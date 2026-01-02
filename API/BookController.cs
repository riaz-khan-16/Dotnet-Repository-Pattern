
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Models;
using Repository_Pattern.Services;
using Repository_Pattern.Entity;


namespace Repository_Pattern.API;

[ApiController]
[Route("api/[controller]")]
public class BookController:ControllerBase
 {
    private readonly IDBService<Book> _dbService;
    public BookController(IDBService<Book> dbService) { 

        _dbService = dbService;
    
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        return Ok(await _dbService.GetAllItemAsync());

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await _dbService.GetItemByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }


    [HttpPost]
    public async Task<IActionResult> Create(Book item)
    {
        await _dbService.SaveItemAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }






}

