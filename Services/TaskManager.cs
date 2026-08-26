using TaskManagerProC.Models;

namespace TaskManagerProC.Services
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new();
        private readonly AuditService _auditService;
        private int _nextId = 1;

        public TaskManager(AuditService auditService)
        {
            _auditService = auditService;
        }
        public void AddTask(string title, string description)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = title,
                Description = description,
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };

            _tasks.Add(task);
            _auditService.Register($"Tarea creada: '{title}' (ID {task.Id})");
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            return _tasks.AsReadOnly();
        }

        public bool CompleteTask(int id)
        {
         var task = _tasks.FirstOrDefault(task => task.Id == id);

         if(task is null )
         return false;   

        task.IsCompleted = true;
        _auditService.Register($"Tarea completada: '{task.Title}' (ID: {task.Id})");
        return true;
        }

        public bool EditTask(int id, string newTitle, string newDescription)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
             if (task is null)
            return false;
            task.Title       = newTitle;
            task.Description = newDescription;
            _auditService.Register($"Tarea editada: '{newTitle}' (ID: {task.Id})");
            return true;
}

        }
    
    }
}