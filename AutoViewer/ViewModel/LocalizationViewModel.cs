using SharedResources;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AutoViewer
{
    public class LocalizationViewModel : AbstractObservableModel
    {
        private readonly string LangResourcePrefix = "Resources/langs";

        public LocalizationViewModel()
        {
            var command = new RelayCommand<LangItemViewModel>(ChangeLanguage);
            Items.Add(new LangItemViewModel(true, "en-US", command));
            Items.Add(new LangItemViewModel("ru-RU", command));
            Items.Add(new LangItemViewModel("uk-UA", command));
            SelectedItem = Items[0];
        }

        private ObservableCollection<LangItemViewModel> items = new ObservableCollection<LangItemViewModel>();

        public ObservableCollection<LangItemViewModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        private LangItemViewModel selectedItem;

        public LangItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    SetActive(value);
                    OnPropertyChanged();
                }
            }
        }

        private void SetActive(LangItemViewModel value)
        {
            foreach (var item in Items)
            {
                item.Active = item.Equals(value);
            }
        }

        public void Add(LangItemViewModel item)
        {
            Items.Add(item);
            SelectedItem = item;
        }

        public void Remove(LangItemViewModel item)
        {
            Items.Remove(item);
        }

        private void ChangeLanguage(LangItemViewModel localeViewModel)
        {
            ResourceDictionary dict = new ResourceDictionary();
            try
            {
                var locale = localeViewModel.Culture.Name;
                dict.Source = new Uri(String.Format("{0}/lang.{1}.xaml", LangResourcePrefix, locale), UriKind.Relative);

            }
            catch (Exception)
            {
                dict.Source = new Uri(string.Format("{0}/lang.xaml", LangResourcePrefix), UriKind.Relative);
            }

            SetupLocaleResources(dict);
            SelectedItem = localeViewModel;
        }

        private void SetupLocaleResources(ResourceDictionary resource)
        {
            ResourceDictionary currentDict = (
                from d in Application.Current.Resources.MergedDictionaries
                where d.Source != null && d.Source.OriginalString.StartsWith(string.Format("{0}/lang.", LangResourcePrefix))
                select d).First();

            if (currentDict != null)
            {
                int idx = Application.Current.Resources.MergedDictionaries.IndexOf(currentDict);
                Application.Current.Resources.MergedDictionaries.Remove(currentDict);
                Application.Current.Resources.MergedDictionaries.Insert(idx, resource);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(resource);
            }
        }
    }
}
