namespace TodoApp.Models{

    public class Todo{

        public Guid Id {get; set;} = Guid.NewGuid();

        public required string Title {get; set;}

        public DateTime Date {get; set;}= DateTime.Today;

        public bool IsCompleted {get; set;} = false;

    }




}