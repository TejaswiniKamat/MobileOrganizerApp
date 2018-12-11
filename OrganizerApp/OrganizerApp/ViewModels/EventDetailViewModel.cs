using System;
using System.Collections.Generic;
using OrganizerApp.Models;
using System.Linq;

namespace OrganizerApp.ViewModels
{
    public class EventDetailViewModel : BaseViewModel
    {
        public Event Item { get; set; }

        public IList<RepeatType> RepeatTypes
        {
            get
            {
                return new List<RepeatType>()
                {
                    new RepeatType{ Id = (int)RepeatTypeEnum.NoRepeat, Name = "No Repeat" },
                    new RepeatType{ Id = (int)RepeatTypeEnum.Monthly, Name = "Monthly" },
                    new RepeatType{ Id = (int)RepeatTypeEnum.Annual, Name = "Annual" }
                };
            }
        }

        public string RepeatTypeName { get; set; }
        public IList<string> RepeatTypeNames
        {
            get
            {
                return RepeatTypes.Select(x => x.Name).ToList();
            }
        }

        public EventDetailViewModel(Event item = null)
        {
            Title = item?.Name;
            Item = item;
            RepeatTypeName = RepeatTypes.Where(x => x.Id == item.RepeatTypeId).Select(x => x.Name).FirstOrDefault();
        }
    }
}
