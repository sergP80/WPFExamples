using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using FamFamFam.Flags.Wpf;

namespace CountryFlags.ViewModel
{
    public class CountryCultureItemViewModel : AbstractObservableViewModel
    {

        private CountryData countryData;

        public CountryData CountryData
        {
            get => countryData;
            set
            {
                countryData = value;
                OnPropertyChanged();
            }
        }
    }

    public class CountryCultureViewModel : AbstractObservableViewModel
    {
        public CountryCultureViewModel()
        {

            var countryData = CountryData.AllCountries;
            
            foreach (var country in countryData)
            {
                Items.Add(
                    new CountryCultureItemViewModel()
                    {
                        CountryData = country
                    }
                );
            }
        }

        private ObservableCollection<CountryCultureItemViewModel> items = new ObservableCollection<CountryCultureItemViewModel>();

        public ObservableCollection<CountryCultureItemViewModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public virtual void Add(CountryCultureItemViewModel item)
        {
            Items.Add(item);
        }

        public virtual void Remove(CountryCultureItemViewModel item)
        {
            Items.Remove(item);
        }

        public virtual void Clear()
        {
            Items.Clear();
        }
    }
}
