using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository<Todo> _repository;
    public HomeController(ILogger<HomeController> logger,  IRepository<Todo> repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<IActionResult> IndexAsync()
    {
        
        var todos = await _repository.GetAllAsync(); 
        return View(todos); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    
}
