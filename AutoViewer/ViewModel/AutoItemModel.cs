using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoViewer
{
    [Serializable()]
    public class AutoItemModel : AbstractObservableModel
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
            set
            {
                imageUri = value;
                OnPropertyChanged();
            }
        }

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(model)
                    && maxVelocity <= 0
                    && price <= 0
                    && string.IsNullOrEmpty(imageUri);
            }
        }
    }
}
