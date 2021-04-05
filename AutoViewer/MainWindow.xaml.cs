using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AutoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public AutoViewModel ViewModel { get; set; } = new AutoViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly string ResourcePattern = "pack://application:,,,/Resources/autos/{0}";

        private Uri GetResourceUri(string imageName)
        {
            return new Uri(string.Format(ResourcePattern, imageName));
        }

        private void InitViewModel()
        {
            MainViewModel.Add(
                new AutoItemModel()
                {
                    Model = "Ford",
                    MaxVelocity = 320,
                    Price = 20000,
                    Image = new BitmapImage(GetResourceUri("ford.jpg"))
                }
            );
            MainViewModel.Add(
                new AutoItemModel()
                {
                    Model = "Hyuinday Santa Fe",
                    MaxVelocity = 240,
                    Price = 22000,
                    Image = new BitmapImage(GetResourceUri("hyuinday-sf.jpg"))
                }
           );
            MainViewModel.Add(
                new AutoItemModel()
                {
                    Model = "Mazda CX 5",
                    MaxVelocity = 280,
                    Price = 18000,
                    Image = new BitmapImage(GetResourceUri("mazda.jpeg"))
                }
           );

            MainViewModel.Add(
                new AutoItemModel()
                {
                    Model = "Range Rover",
                    MaxVelocity = 360,
                    Price = 45000,
                    Image = new BitmapImage(GetResourceUri("range-rover.jpg"))
                }
           );
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitViewModel();
        }
    }
}
