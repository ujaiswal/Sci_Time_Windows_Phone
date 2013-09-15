using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Sci_Time.Resources;
using System.Collections.Generic;
using Sci_Time.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.IO;

namespace Sci_Time.ViewModels
{
    public class ArticleModel : INotifyPropertyChanged
    {
        private Database dbase;
        //public bool IsDataLoaded
        //{
        //    get;
        //    private set;
        //}
        public ObservableCollection<ItemViewModel> Items { get; private set; } // For discoveries
        private IEnumerable<Model.Article> articles;

        public ArticleModel(Database db)
        {
            this.dbase = db;
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        public void LoadData(string title, string yearRange)
        {
            String tmp;
            String[] tmp2;
            this.Items.Clear();
            this.articles = dbase.QueryYearRanges(yearRange, title);
            foreach (var article in articles)
            {
                Sci_Time.Article.articleYear =  article.Year;
                Sci_Time.Article.articlediscovery = article.Discovery;
                Sci_Time.Article.articlediscoverer = article.Discoverer;
                Sci_Time.Article.img = article.Image;
                tmp = article.Tags.Replace(' ','_');
                tmp2 = tmp.Split('\n');
                this.Items.Clear();
                foreach (var st in tmp2)
                {
                    this.Items.Add(new ItemViewModel() { LineOne = st});
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
