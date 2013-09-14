using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Sci_Time.Resources;
using System.Collections.Generic;
using Sci_Time.Model;

namespace Sci_Time.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        private Database dbase;
        //public bool IsDataLoaded
        //{
        //    get;
        //    private set;
        //}
        public ObservableCollection<ItemViewModel> Items { get; private set; } // For discoveries
        private IEnumerable<Discoveries> discoveries;

        public ListViewModel(Database db) {
            this.dbase = db;
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        public void LoadData(string yearRange){
            this.Items.Clear();
            this.discoveries = dbase.QueryYearRanges(yearRange);
            foreach (var discovery in discoveries) {
                this.Items.Add(new ItemViewModel() { LineOne=discovery.Title });
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
