using TaskManagerProC.Services;

namespace TaskManagerProC.UI
{
    public class ConsoleInterface
    {
        private readonly TaskManager _taskManager;
        private readonly AuditService _auditService;

        public ConsoleInterface(TaskManager taskManager, AuditService auditService)
        {
            _taskManager = taskManager;
            _auditService = auditService;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                ShowMenu();

                string input  = Console.ReadLine() ?? string.Empty;
                bool   parsed = int.TryParse(input, out int option);

                if (!parsed)
                {
                    Console.WriteLine("\n Opción inválida. Ingresa un número del 1 al 6.\n");
                    continue;
                }

                switch (option)
                {
                    case 1: CreateTask();    break;
                    case 2: ListTasks();     break;
                    case 3: CompleteTask();  break;
                    case 4: ShowAuditLog();  break;
                    case 5: EditTask(); break;
                    case 6: running = false; break;
                    default:
                        Console.WriteLine("\n  Opción fuera de rango. Elige entre 1 y 6.\n");
                        break;
                }
            }

            Console.WriteLine("\n Hasta luego.\n");
        }

        private void ShowMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("      TASK MANAGER PRO          ");
            Console.WriteLine("================================");
            Console.WriteLine("1. Crear nueva tarea");
            Console.WriteLine("2. Listar todas las tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Ver historial de auditoría");
            Console.WriteLine("5. Editar tarea");
            Console.WriteLine("6. Salir");
            Console.Write("\nElige una opción: ");
        }
        private void CreateTask()
        {
                Console.WriteLine("\n--- NUEVA TAREA ---");
                Console.Write("Título: ");
                string title = Console.ReadLine() ?? string.Empty;
              if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(" El título no puede estar vacío.\n");
                return;
            }                                        
            Console.Write("Descripción: ");          
            string description = Console.ReadLine() ?? string.Empty;
            _taskManager.AddTask(title, description);
            Console.WriteLine(" Tarea creada con éxito.\n");
        }

        private void ListTasks()
        {
            Console.WriteLine("\n--- LISTA DE TAREAS ---");
            var tasks = _taskManager.GetAll();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.\n");
                return;
            }
            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? " Completada" : " Pendiente";
                Console.WriteLine($"[{task.Id}] {task.Title} — {status}");
                Console.WriteLine($"     {task.Description}");
                Console.WriteLine($"     Creada: {task.CreatedAt:dd/MM/yyyy HH:mm}");
                Console.WriteLine();
            }
        }

        private void CompleteTask()
        {
        Console.WriteLine("\n--- COMPLETAR TAREA ---");
        Console.Write("Ingresa el ID de la tarea: ");
        string input  = Console.ReadLine() ?? string.Empty;
        bool   parsed = int.TryParse(input, out int id);
        if (!parsed)
        {
            Console.WriteLine("  El ID debe ser un número.\n");
            return;
        }
        bool success = _taskManager.CompleteTask(id);
        if (success)
            Console.WriteLine(" Tarea marcada como completada.\n");
        else
            Console.WriteLine("  No se encontró una tarea con ese ID.\n");
        }
        private void EditTask()
        {  
            Console.WriteLine("\n--- EDITAR TAREA ---");
            Console.Write("Ingresa el ID de la tarea a editar: ");
            string input  = Console.ReadLine() ?? string.Empty;
            bool   parsed = int.TryParse(input, out int id);
            if (!parsed)
            {
                Console.WriteLine("  El ID debe ser un número.\n");
                return;
            }
            Console.Write("Nuevo título: ");
            string newTitle = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("  El título no puede estar vacío.\n");
                return;
            }
            Console.Write("Nueva descripción: ");
            string newDescription = Console.ReadLine() ?? string.Empty;
            bool success = _taskManager.EditTask(id, newTitle, newDescription);
            if (success)
                Console.WriteLine(" Tarea editada con éxito.\n");
            else
                Console.WriteLine("  No se encontró una tarea con ese ID.\n");
        }
        private void ShowAuditLog()
        {
        Console.WriteLine("\n--- HISTORIAL DE AUDITORÍA ---");
        var logs = _auditService.GetAll();
        if (logs.Count == 0)
        {
            Console.WriteLine("El historial está vacío.\n");
            return;
        }
        foreach (var log in logs)
        {
            Console.WriteLine($"[{log.Timestamp:dd/MM/yyyy HH:mm:ss}] {log.Message}");
        }
        Console.WriteLine();
        }
    }
}