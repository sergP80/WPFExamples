using SharedResources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeasonClothes
{
    public class SeasonItemClothesViewModel : AbstractListItemDataViewModel<ImageSource>
    {}

    public class SeasonClothesViewModel : AbstractListItemDataViewModel<ObservableCollection<SeasonItemClothesViewModel>>
    {
        public SeasonClothesViewModel()
        {
            Data = new ObservableCollection<SeasonItemClothesViewModel>();
        }
        public void Clear()
        {
            Data.Clear();
        }

        public void Add(SeasonItemClothesViewModel item)
        {
            Data.Add(item);
        }
    }

    public class SeasonViewModel : AbstractListItemDataViewModel<ObservableCollection<SeasonClothesViewModel>>
    {
        public SeasonViewModel()
        {
            Data = new ObservableCollection<SeasonClothesViewModel>();
        }
        public void Clear()
        {
            Data.Clear();
        }

        public void Add(SeasonClothesViewModel item)
        {
            Data.Add(item);
        }

        private SeasonClothesViewModel selectedClothes;

        public SeasonClothesViewModel SelectedClothes
        {
            get
            {
                return selectedClothes;
            }
            set
            {
                selectedClothes = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Dictionary<string, string[]> seasonDictionary = new Dictionary<string, string[]>();

        private static readonly string ImagePathPattern = "/Resources/Icons/Seasons/{0}/{1}.{2}";

        static MainWindow()
        {
            seasonDictionary.Add(
                "autumn",
                new string[] { "Blouse", "Crosses", "Hat", "Pants"}
            );
            seasonDictionary.Add(
                "spring",
                new string[] { "Blouse", "Crosses", "Hat", "Pants" }
            );
            seasonDictionary.Add(
                "summer",
                new string[] { "Cap", "Crosses", "Pants", "T_shirt" }
            );
            seasonDictionary.Add(
                "winter",
                new string[] { "Boots", "Cap", "Jacket", "Pants" }
            );
        }
        private string GetImagePathAsResource(string season, string image, string ext)
        {
            var pathTemplate = string.Format("pack://application:,,,{0}", ImagePathPattern);
            return string.Format(pathTemplate, season, image, ext);
        }
  
        private void InitData()
        {
            string ext = "png";
           
            foreach(var seasonItem in seasonDictionary)
            {
                SeasonClothesViewModel itemClothesViewModel = new SeasonClothesViewModel()
                { 
                    Label= seasonItem.Key
                };

                foreach (var imageName in seasonItem.Value)
                {
                    var uri = GetImagePathAsResource(seasonItem.Key, imageName, ext);
                    itemClothesViewModel.Add(
                        new SeasonItemClothesViewModel()
                        {
                            Label = imageName,
                            Data = new BitmapImage(new Uri(uri))
                        }
                        
                    );
                }

                SeasonViewModel.Add(itemClothesViewModel);
            }
            
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitData();
        }
    }
}
