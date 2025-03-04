using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TaskManagementServer.Models;

namespace TaskManagementServer.DAL
{
    public class TaskDAL
    {
        private readonly string _filePath = "tasks.json";

        public TaskDAL()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        // Read all tasks from JSON file
        public List<TaskModel> GetAllTasks()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }

        // Get task by Id
        public TaskModel? GetTaskById(int id)
        {
            return GetAllTasks().FirstOrDefault(t => t.Id == id);
        }

        // Add new task
        public void AddTask(TaskModel task)
        {
            var tasks = GetAllTasks();
            task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1; // Auto-increment ID
            tasks.Add(task);
            SaveTasks(tasks);
        }

        // Update existing task
        public bool UpdateTask(int id, TaskModel updatedTask)
        {
            var tasks = GetAllTasks();
            var index = tasks.FindIndex(t => t.Id == id);
            if (index == -1) return false;

            tasks[index] = updatedTask;
            SaveTasks(tasks);
            return true;
        }

        // Delete a task
        public bool DeleteTask(int id)
        {
            var tasks = GetAllTasks();
            var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);
            if (taskToRemove == null) return false;

            tasks.Remove(taskToRemove);
            SaveTasks(tasks);
            return true;
        }

        // Save tasks to JSON file
        private void SaveTasks(List<TaskModel> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
