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
            return RedirectToAction("Index");
        }

        return View(todo);  
    }

     public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> IndexAsync(){
        var todos = await _repository.GetAllAsync(); 
        return View(todos); 
    
    }


[HttpPost]
public async Task<IActionResult> UpdateStatus(Guid id, IFormCollection form)
{
    var todo = await _repository.GetByIdAsync(id);
    Console.WriteLine("TODO ID : "+ todo.Id);

    if (todo == null)
    {
        return NotFound();
    }
   
    todo.IsCompleted = form["isCompleted"].Count > 0;
    await _repository.Update(todo);

   
    return RedirectToAction("Index");
}

[HttpPost]
public async Task<IActionResult> Delete(Guid id)
{
    var todo = await _repository.GetByIdAsync(id);
    if(todo == null){
        return NotFound();
    }
    _repository.Delete(todo);
    await _repository.SaveAsync();

    return RedirectToAction("Index");
}

}