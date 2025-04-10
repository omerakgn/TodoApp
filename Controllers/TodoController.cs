using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;

public class TodoController :Controller
{
    private readonly IRepository<Todo> _repository;

    public TodoController(IRepository<Todo> repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Todo todo)
    {
       if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }
        }
        else
        {
            todo.Date = DateTime.SpecifyKind(todo.Date, DateTimeKind.Utc);
            // Valid model, proceed with adding the Todo
            await _repository.AddAsync(todo);
            Console.WriteLine("!!!!!  VERİ EKLENİYOR ... !!!!!!");
            return RedirectToAction("Create");
        }

        return View(todo);  
    }

     public IActionResult Create()
    {
        return View();
    }
}