using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using Sci_Time.ViewModels;

namespace Sci_Time
{
    public partial class Article : PhoneApplicationPage
    {
        public Article()
        {
            InitializeComponent();

            DataContext = App.Article_model;
        }
        private static string articleName;
        public static string articleYear;
        public static string articlediscoverer;
        public static string articlediscovery;
        public static byte[] img;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.TryGetValue("title", out articleName))
            {
                NavigationContext.QueryString.TryGetValue("year", out articleYear);
                ItemViewModel a = new ItemViewModel() { LineOne = articleName, LineTwo = articleYear };
                bool flag = true;
                foreach (ItemViewModel a1 in MainViewModel.Recents) {
                    if (a1.LineOne.Equals(a.LineOne)) {
                        flag = false;
                    }
                }
                if (flag) {
                    MainViewModel.Recents.Insert(0, a);
                }
                if (MainViewModel.Recents.Count > 10)
                {
                    MainViewModel.Recents.RemoveAt(MainViewModel.Recents.Count - 1);
                }

                App.Article_model.LoadData(articleName,articleYear);
                this.ArticleName.Text = articleName;
                this.Year.Text = articleYear;
                this.name.Text = articlediscoverer;
                this.discover.Text = articlediscovery;
                if (img != null) {
                    this.Image.Source = byteArrayToImage(img);
                }
            }
        }

        public BitmapImage byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            BitmapImage returnImage = new BitmapImage();
            returnImage.SetSource(ms);
            return returnImage;
        }
    }
}