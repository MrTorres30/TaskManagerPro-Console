using TaskManagerProC.Models;

namespace TaskManagerProC.Services
{
    public class AuditService
    {
        private readonly List<AuditLog> _logs = new ();
        private int _nextId = 1;
       public void Register(string Message)
        {
            var log = new AuditLog
            {
                Id = _nextId++,
                Message = Message,
                Timestamp = DateTime.Now
            };
            _logs.Add(log);
        }
        public IReadOnlyList<AuditLog> GetAll()
        {
            return _logs.AsReadOnly();
        }
    }
}