using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data{

    public class TodoRepository : IRepository<Todo>
    {
        private readonly AppDbContext _context;
        public TodoRepository(AppDbContext context){

            _context = context;
        }
        public async Task AddAsync(Todo entity)
        {
            await _context.Todo.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Todo entity)
        {
            _context.Todo.Remove(entity);
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todo.OrderBy(t => t.Date).ThenBy(t => t.Id) 
            .ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {

            var todo= await _context.Todo.FindAsync(id);
            if(todo==null){
                return null;
            }
            return todo;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Todo entity)
        {
          var existing = await _context.Todo.FindAsync(entity.Id);
            if (existing != null)
            {
                existing.IsCompleted = entity.IsCompleted; // Sadece bu alanı güncelle
                await _context.SaveChangesAsync();
            }
                }
    }



}