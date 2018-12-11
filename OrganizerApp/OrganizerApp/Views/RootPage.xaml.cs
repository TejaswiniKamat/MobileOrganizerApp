using OrganizerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrganizerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : MasterDetailPage
	{
        
        public RootPage ()
		{
            InitializeComponent ();
            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                
                Detail = new NavigationPage(page);
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}