using TaskManageProC.Services;

namespace TaskManageProC.UI
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

                string input = Console.ReadLine() ?? string.Empty;
            }
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
            Console.WriteLine("5. Salir");
            Console.Write("\nElige una opción: ");
        }
    }
}