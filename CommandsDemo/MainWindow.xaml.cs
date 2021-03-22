using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;
using System.IO;

namespace CommandsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isModified = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = txtArea.GetLineIndexFromCharacterIndex(txtArea.CaretIndex);
            int col = txtArea.CaretIndex - txtArea.GetCharacterIndexFromLineIndex(row);
            txbPosition.Text = string.Format("Row: {0}, Col: {1}", row, col);
        }

        private void txtArea_KeyUp(object sender, KeyEventArgs e)
        {
            this.isModified = true;
        }

        private void loadFile(String fileName)
        {
            using(var reader = new StreamReader(fileName))
            {
              txtArea.Text = reader.ReadToEnd();
            }
        }
        private void saveFile(String fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(txtArea.Text);
            }
        }

        private void openCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var showResult = ofd.ShowDialog();
            if (!showResult.HasValue || !showResult.Value)
            {
                return;
            }

            loadFile(ofd.FileName);
        }

        private void saveCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            var showResult = svd.ShowDialog();
            if (!showResult.HasValue || !showResult.Value)
            {
                return;
            }

            saveFile(svd.FileName);
            this.isModified = false;
        }

        private void saveCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isModified;
        }

        private void exitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.isModified)
            {
                var showResult = MessageBox.Show("Do you want to save changed", "Save changes", MessageBoxButton.YesNoCancel);
                switch (showResult)
                {
                    case MessageBoxResult.Yes:
                        saveCmd_Executed(sender, e);
                        Close();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        Close();
                        break;
                }
            } else
            {
                Close();
            }
            
        }

        private void newCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.isModified = false;
            this.txtArea.Text = "";
        }
    }
}
