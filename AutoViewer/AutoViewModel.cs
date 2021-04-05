using SharedResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AutoViewer
{
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

        private ImageSource image;
        public ImageSource Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
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
    }
}
