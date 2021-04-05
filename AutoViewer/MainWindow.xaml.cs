using Microsoft.Win32;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly string FileFilter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
        private void cmdOpen_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FileFilter;
            var showResult = openFileDialog.ShowDialog();
            if (!showResult.HasValue || !showResult.Value)
            {
                return;
            }
            MainViewModel.Load(openFileDialog.FileName);
        }

        private void cmdSave_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FileFilter;
            var showResult = saveFileDialog.ShowDialog();
            if (!showResult.HasValue || !showResult.Value)
            {
                return;
            }
            saveFileDialog.AddExtension = true;
            MainViewModel.Save(saveFileDialog.FileName);
        }

        private void cmdSave_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MainViewModel.Items.Count > 0;
        }

        private void cmdExit_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Close();
        }

    }
}
