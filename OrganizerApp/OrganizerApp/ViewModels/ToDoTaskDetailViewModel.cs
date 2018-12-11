using System;

using OrganizerApp.Models;

namespace OrganizerApp.ViewModels
{
    public class ToDoTaskDetailViewModel : BaseViewModel
    {
        public ToDoTask Task { get; set; }
        public ToDoTaskDetailViewModel(ToDoTask item = null)
        {
            Title = item?.Description;
            Task = item;
        }
    }
}
