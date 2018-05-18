using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class CreateElementForm : Window
    {
        
        const String TEXT_BOX_PLACEHOLDER = "Set the name of element";
        TreeViewItem selectedItem;
        TreeViewBuilder treeViewBuilder;

        public CreateElementForm(TreeViewItem selectedItem, TreeViewBuilder treeViewBuilder)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            this.treeViewBuilder = treeViewBuilder;
        }

        private void gotFocus(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = "";
        }

        private void lostFocus(object sender, RoutedEventArgs e)
        {
            //nameTextBox.Text = TEXT_BOX_PLACEHOLDER;
        }

        private void CreateNewDiskElement(object sender, RoutedEventArgs e)
        {
            String name = nameTextBox.Text;
            bool isDirectory = false;
            FileSystemInfo fileToAdd;
           

            if (DirectoryRadio.IsChecked == true)
                isDirectory = true;
            
            bool isNameCorrect = true;

            if (!isDirectory)
            {
                string pattern = "^[a-zA-Z0-9_~-]{1,8}\\.(txt|php|html)$";
                isNameCorrect = Regex.IsMatch(name, pattern);
            }

            if (!isNameCorrect)
            {
                MessageBox.Show("WRONG NAME!", "wrong name", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            String newItemPath = System.IO.Path.Combine(selectedItem.Tag.ToString(), name);
            if (isDirectory)
            {
                Directory.CreateDirectory(newItemPath);
                fileToAdd = new DirectoryInfo(newItemPath);
            }
            else
            {
                if (!File.Exists(newItemPath))
                {
                    File.Create(newItemPath);
                    fileToAdd = new FileInfo(newItemPath);
                }
                else
                {
                    MessageBox.Show("File already exists", "wrong name", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    return;
                }
            }

            ContextMenu contextMenu = new ContextMenu();

            MenuItem menuItemDelete = new MenuItem
            {
                Header = "Delete",
            };

            menuItemDelete.Click += treeViewBuilder.menuItemDeleteClickHandler;

            if (isDirectory)
            {
                MenuItem menuItemCreate = new MenuItem
                {
                    Header = "Create",
                };
                menuItemCreate.Click += treeViewBuilder.menuItemCreateClickHandler;
                contextMenu.Items.Add(menuItemCreate);
            }
            else
            {
                MenuItem menuItemOpen = new MenuItem
                {
                    Header = "Open",
                };
                menuItemOpen.Click += treeViewBuilder.menuItemOpenClickHandler;
                contextMenu.Items.Add(menuItemOpen);
            }


            contextMenu.Items.Add(menuItemDelete);

            TreeViewItem treeItem = new TreeViewItem
            {
                Header = name,
                Tag = newItemPath,
                ContextMenu = contextMenu
            };

            if (ReadOnlyCB.IsChecked == true)
                fileToAdd.Attributes |= FileAttributes.ReadOnly;
            else
                fileToAdd.Attributes &= ~FileAttributes.ReadOnly;

            if (ArchiveCB.IsChecked == true)
                fileToAdd.Attributes |= FileAttributes.Archive;
            else
                fileToAdd.Attributes &= ~FileAttributes.Archive;

            if (HiddenCB.IsChecked == true)
                fileToAdd.Attributes |= FileAttributes.Hidden;
            else
                fileToAdd.Attributes &= ~FileAttributes.Hidden;

            if (SystemCB.IsChecked == true)
                fileToAdd.Attributes |= FileAttributes.System;
            else
                fileToAdd.Attributes &= ~FileAttributes.System;


            treeItem.Selected += treeViewBuilder.TreeItemSelected;

            selectedItem.Items.Add(treeItem);

            this.Close();
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
