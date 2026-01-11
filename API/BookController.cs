
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Models;
using Repository_Pattern.Services;
using Repository_Pattern.Entity;


namespace Repository_Pattern.API;

[ApiController]
[Route("api/[controller]")]
public class BookController:ControllerBase
 {
    private readonly IDBService _dbService;
    public BookController(IDBService dbService) { 

        _dbService = dbService;
    
    }

    [HttpGet]
    public Task<List<Book>> Get()
    {

        return _dbService.GetAllItemAsync<Book>();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await _dbService.GetItemByIdAsync<Book>(id);
        return item == null ? NotFound() : Ok(item);
    }


    [HttpPost]
    public async Task<string> Create(Book item)
    {
        await _dbService.SaveItemAsync<Book>(item);
        return "Project is created";
    }






}

