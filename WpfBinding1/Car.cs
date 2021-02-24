using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBinding1
{
    public class Car: INotifyPropertyChanged
    {
        private string model;
        public string Model { 
            get
            {
                return model;
            }
            set
            {
                model = value;
                this.UpdateProperty("Model");
            }
        }

        public int Year { get; set; }

        private double velocity;
        public double Velocity {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
                UpdateProperty("Velocity");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateProperty(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
