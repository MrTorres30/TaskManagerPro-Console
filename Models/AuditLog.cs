namespace TaskManageProC.Models
{
    public class AuditLog
    {
        public int Id {get; set;}
        public string Message {get; set;} = String.Empty;
        public DateTime TimeStamp {get; set;}
    }
}