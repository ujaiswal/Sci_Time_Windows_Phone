using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Sci_Time
{
    public partial class List : PhoneApplicationPage
    {
        public List()
        {
            InitializeComponent();

            DataContext = App.ListModel;
        }

        private string selectedYear = "";
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedYear)) {
                App.ListModel.LoadData(selectedYear);
                this.Year.Text = selectedYear;
            }
        }

        private void Discoveries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         if( Discoveries.SelectedItem == null) return;

            NavigationService.Navigate(new Uri("/Article.xaml?selectedItem=" + (Discoveries.SelectedItem as ViewModels.ItemViewModel).LineOne, UriKind.Relative));
            Discoveries.SelectedItem = null;
        }
    }
}