using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Sci_Time.Resources;
using System.Collections.Generic;
using Sci_Time.Model;

namespace Sci_Time.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Database dbase;
        private IEnumerable<YearRange> yeardata;

        public MainViewModel(Database db)
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.Items2 = new ObservableCollection<ItemViewModel>();
            this.dbase = db;
            yeardata = dbase.QueryYearRanges();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; } // For timeline
        public ObservableCollection<ItemViewModel> Items2 { get; private set; } // For recents.

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.Items.Clear();
            foreach (var range in yeardata) {
                this.Items.Add(new ItemViewModel() { LineOne = range.Name.ToString(), LineTwo = range._id.ToString() });
            }
            this.Items2.Clear();
            this.IsDataLoaded = true;
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