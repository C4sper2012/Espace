using System.ComponentModel.DataAnnotations;

namespace Espace.Service.Shared.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public DateTime CreatedTime { get; set; } = DateTime.Now;
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public PriorityLevel Priority { get; set; } = PriorityLevel.Normal;
        [Required] public bool Completed { get; set; } = false;
    }

    public enum PriorityLevel
    {
        Low,
        Normal,
        High
    }
}