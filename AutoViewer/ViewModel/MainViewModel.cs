using SharedResources;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace AutoViewer
{

    public class MainViewModel: AbstractObservableModel
    {
        public ImageSource ApplicationIcon
        {
            get
            {
                var uri = "pack://application:,,,/SharedResources;Component/Icons/app_icon2.jpg";
                return new BitmapImage(new Uri(uri));
            }
        }

        private LocalizationViewModel localization = new LocalizationViewModel();
        public LocalizationViewModel Localization
        {
            get => localization;
            set
            {
                localization = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AutoItemModel> items = new ObservableCollection<AutoItemModel>();
        public ObservableCollection<AutoItemModel> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
                OnPropertyChanged();
                NotifyEmptyProps();
            }
        }

        private AutoItemModel selectedItem;

        public AutoItemModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        public bool IsEmpty 
        { 
            get => Items.Count == 0;
        }

        public bool IsNotEmpty
        {
            get => !IsEmpty;
        }

        private void NotifyEmptyProps()
        {
            OnPropertyChanged("IsEmpty");
            OnPropertyChanged("IsNotEmpty");
        }

        public void Add(AutoItemModel item)
        {
            Items.Add(item);
            SelectedItem = Items[Items.Count - 1];
            NotifyEmptyProps();
        }

        public void Add()
        {
            Items.Add
                (
                new AutoItemModel()
                {
                    Model = string.Format("New model {0}",Items.Count + 1),
                    MaxVelocity = 100,
                    Price = 0,
                    ImageUri = "pack://application:,,,/SharedResources;Component/Images/StubCar.jpg"
                }
               );
            SelectedItem = Items[Items.Count - 1];
            NotifyEmptyProps();
        }

        public void RemoveSelected()
        {
            if (SelectedItem == null)
            {
                return;
            }
            
            Items.Remove(SelectedItem);
            
            if (IsNotEmpty)
            {
                SelectedItem = Items[0];
            }

            NotifyEmptyProps();
        }

        public void Clear()
        {
            Items.Clear();
            NotifyEmptyProps();
        }

        public void Save(string path)
        {
            using(var streamWriter = new StreamWriter(path))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<AutoItemModel>));
                serializer.Serialize(streamWriter, Items);
            }
        }

        public void Load(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<AutoItemModel>));
                Items = (ObservableCollection<AutoItemModel>)serializer.Deserialize(streamReader);
                if (IsNotEmpty)
                {
                    SelectedItem = Items[0];
                }
            }
            NotifyEmptyProps();
        }
    }
}