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
            return await _context.Todo.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Todo entity)
        {
            _context.Todo.Update(entity);
        }
    }



}