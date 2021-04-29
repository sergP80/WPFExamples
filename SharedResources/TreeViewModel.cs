using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public class TreeItemViewModel<T>: AbstractObservableViewModel
    {
        
        private T data;
        

        public T Data {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TreeItemViewModel<T>> children;

        public ObservableCollection<TreeItemViewModel<T>> Children
        {
            get => children;
            set
            {
                children = value;
                OnPropertyChanged();
            }
        }

        public bool HasChild
        {
            get => children != null && children.Count > 0;
        }

        public void AddChild(T item)
        {
            if (children == null)
            {
                children = new ObservableCollection<TreeItemViewModel<T>>();
            }
            children.Add(new TreeItemViewModel<T>() { 
                Data = item
            });
        }

        public void RemoveChild(T data)
        {
            if (!HasChild)
            {
                return;
            }
            var node = children.Where(child => child.data.Equals(data)).First();
            if (node != null)
            {
                children.Remove(node);
            }
        }
    }

    public class TreeViewModel<T>: AbstractObservableViewModel
    {
        private ObservableCollection<TreeItemViewModel<T>> root;
        public ObservableCollection<TreeItemViewModel<T>> Root
        {
            get => root;
            set
            {
                root = value;
                OnPropertyChanged();
            }
        }

        public void Add(T data, ObservableCollection<TreeItemViewModel<T>> children = null)
        {
            if (root == null)
            {
                root = new ObservableCollection<TreeItemViewModel<T>>();
            }
            root.Add(new TreeItemViewModel<T>() { Data = data, Children = children });
        }
    }
}
