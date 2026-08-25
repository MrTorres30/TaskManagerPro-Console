namespace TaskManageProC.Models
{
    public class TaskItem
    {
        public int Id {get; set;}
        public string Title {get; set;} = String.Empty;
        public string Description {get; set;} = String.Empty;
        public bool IsCompleted {get; set;}
        public DateTime CreatedAt {get; set;}
    }
}