using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Sci_Time
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            App.ViewModel.GetRecents();
        }

        private void YearRange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearRange.SelectedItem == null) return;

            NavigationService.Navigate(new Uri("/List.xaml?selectedItem=" + (YearRange.SelectedItem as ViewModels.ItemViewModel).LineOne, UriKind.Relative));
            YearRange.SelectedItem = null;
        }

        private void recents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (recents.SelectedItem == null) return;

            NavigationService.Navigate(new Uri("/Article.xaml?title=" + (recents.SelectedItem as ViewModels.ItemViewModel).LineOne + "&year=" + (recents.SelectedItem as ViewModels.ItemViewModel).LineTwo, UriKind.Relative));
            recents.SelectedItem = null;

        }
    }
}