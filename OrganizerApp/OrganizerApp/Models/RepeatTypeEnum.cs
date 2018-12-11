using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerApp.Models
{
    public enum RepeatTypeEnum
    {
        NoRepeat = 0,
        Monthly = 1,
        Annual = 2
    }

    public class RepeatType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
