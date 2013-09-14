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
    public partial class Article : PhoneApplicationPage
    {
        public Article()
        {
            InitializeComponent();
            
            //DataContext = 
        }

        private string articleName;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out articleName))
            {
                //App.ListModel.LoadData(articleName);
                this.ArticleName.Text = articleName;
            }
        }
    }
}