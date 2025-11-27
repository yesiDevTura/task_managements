using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetTasksByUserIdAsync(int userId);
        Task<List<TaskItem>> GetTasksByUserIdAndStatusAsync(int userId, TaskItemStatus? status);  // <- Cambiar aquí
        Task<TaskItem?> GetTaskByIdAsync(int taskId);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task<TaskItem?> UpdateTaskAsync(TaskItem task);
        Task<bool> DeleteTaskAsync(int taskId);
    }
}