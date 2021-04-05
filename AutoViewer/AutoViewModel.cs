using SharedResources;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace AutoViewer
{
    [Serializable()]
    public class AutoItemModel: AbstractObservableModel
    {
        private string model;
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        private double maxVelocity;
        public double MaxVelocity
        {
            get
            {
                return maxVelocity;
            }

            set
            {
                maxVelocity = value;
                OnPropertyChanged();
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        private string imageUri;
        public string ImageUri
        {
            get => imageUri;
            set {
                imageUri = value;
                OnPropertyChanged();
            }
        }
    }

    public class AutoViewModel: AbstractObservableModel
    {
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
            }
        }

        private AutoItemModel selectedAuto;

        public AutoItemModel SelectedAuto
        {
            get
            {
                return selectedAuto;
            }
            set
            {
                selectedAuto = value;
                OnPropertyChanged();
            }
        }

        public void Add(AutoItemModel item)
        {
            Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
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
            }
        }
    }
}