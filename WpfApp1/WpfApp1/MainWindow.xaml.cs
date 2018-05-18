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
using System.Windows.Forms;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        String outputDIR = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileRoot(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderBrowserDialog() { Description = "Select directory to open" };
            dlg.ShowDialog();
            if (dlg.SelectedPath != "")
            {
                outputDIR = dlg.SelectedPath;

                TreeViewBuilder treeBuilder = new TreeViewBuilder(FileTree);
                treeBuilder.ListDirectory(outputDIR);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
