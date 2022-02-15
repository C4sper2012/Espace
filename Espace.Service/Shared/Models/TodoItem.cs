namespace Espace.Service.Shared.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;

        public PriorityLevel Priority { get; set; } = PriorityLevel.Normal;

        public bool Completed { get; set; } = false;
    }

    public enum PriorityLevel
    {
        Low,
        Normal,
        High
    }
}