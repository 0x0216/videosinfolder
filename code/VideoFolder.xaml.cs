using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

namespace videosInFolder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _folderPathInput;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenVideo(object sender, RoutedEventArgs e)
        {

            if (!Directory.Exists(_folderPathInput))
            {
                MessageBox.Show("Folder does not exist!");
                return;
            }

            var ofd = new OpenFileDialog
            {
                Filter = "Video Files (*.mp4, *.mov, *.avi, *.gif, *.webm)|*.mp4;*.mov;*.avi;*.gif;*.webm|All Files (*.*)|*.*",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Favorites)
            };

            if (ofd.ShowDialog() != true) return;
            Operations.fileNum = 0;
            foreach (var filename in ofd.FileNames)
            {
                Operations.PlaceFile(new FileInfo(filename), _folderPathInput);
            }

            MessageBox.Show("Operation Complete!");
        }

        private void FolderPathChange(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;
            _folderPathInput = box?.Text;
        }
    }
}