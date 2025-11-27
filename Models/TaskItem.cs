namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.Pendiente;  
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Relación con usuario
        public int UserId { get; set; }
        public User? User { get; set; }
    }
    
    public enum TaskItemStatus  // <- Cambiar aquí
    {
        Pendiente,
        EnProgreso,
        Completada
    }
}