using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerApp.Models
{
    public class ToDoTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int Status { get; set; } //Pending, In Progress, Completed
    }
}
