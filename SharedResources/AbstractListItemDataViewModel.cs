using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public abstract class AbstractListItemDataViewModel<T> : AbstractObservableViewModel
    {
        private string label;
        public virtual string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
                OnPropertyChanged();
            }
        }

        private T data;
        public virtual T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
    }
}
