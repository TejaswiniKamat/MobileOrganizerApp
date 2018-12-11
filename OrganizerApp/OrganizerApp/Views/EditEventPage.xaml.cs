using OrganizerApp.Models;
using OrganizerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEventPage : ContentPage
    {
        public Event Event { get; set; }
        
        public string SelectedRepeatType { get; set; }
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

        public IList<string> RepeatTypeNames
        {
            get
            {
                var r = this.RepeatTypes.Select(x => x.Name).ToList();
                return r;
            }
        }
        
        public EditEventPage(Event e)
        {
            InitializeComponent();

            Event = e;
            foreach (var item in RepeatTypeNames)
            {
                dboRepeat.Items.Add(item);
            }
            
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Event.IsRepeat = this.SelectedRepeatType.Equals("No Repeat") ? true : false;
            Event.RepeatTypeId = RepeatTypes.Where(x => x.Name.Equals(this.SelectedRepeatType)).Select(x => x.Id).FirstOrDefault();
            MessagingCenter.Send(this, "EditEvent", Event);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void dboRepeat_OnSelectedIndexChanged(object sender, EventArgs args)
        {
            if (dboRepeat != null && dboRepeat.SelectedIndex <= dboRepeat.Items.Count)
            {
                this.SelectedRepeatType = dboRepeat.Items[dboRepeat.SelectedIndex];
            }
        }
    }
}