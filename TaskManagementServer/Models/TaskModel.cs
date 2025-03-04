﻿namespace TaskManagementServer.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string DueDate { get; set; }
        public string Status { get; set; }

    }

    public class TasksRoot
    {
        public List<TaskModel> tasks { get; set; }
    }
}
