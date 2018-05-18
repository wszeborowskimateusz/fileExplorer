using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class TreeViewBuilder
    {
        TreeView treeView;

        public TreeViewBuilder(TreeView tree)
        {
            treeView = tree;
        }

        public  void ListDirectory(string path)
        {
            treeView.Items.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Items.Add(CreateDirectoryItem(rootDirectoryInfo));
        }

        private  TreeViewItem CreateDirectoryItem(DirectoryInfo directoryInfo)
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemCreate = new MenuItem
            {
                Header = "Create",
            };
            MenuItem menuItemDelete = new MenuItem
            {
                Header = "Delete",
            };

            menuItemCreate.Click += menuItemCreateClickHandler;
            menuItemDelete.Click += menuItemDeleteClickHandler;

            contextMenu.Items.Add(menuItemCreate);
            contextMenu.Items.Add(menuItemDelete);

            var directoryNode = new TreeViewItem
            {
                Header = directoryInfo.Name,
                Tag = directoryInfo.FullName,
                ContextMenu = contextMenu,
            };

            directoryNode.Selected += TreeItemSelected;

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Items.Add(CreateDirectoryItem(directory));
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                ContextMenu contextMenuFile = new ContextMenu();
                MenuItem menuItemOpen = new MenuItem
                {
                    Header = "Open",
                };
            
                MenuItem menuItemDeleteFile = new MenuItem
                {
                    Header = "Delete",
                };

                menuItemOpen.Click += menuItemOpenClickHandler;
                menuItemDeleteFile.Click += menuItemDeleteClickHandler;

                contextMenuFile.Items.Add(menuItemOpen);
                contextMenuFile.Items.Add(menuItemDeleteFile);


                var treeElem = new TreeViewItem
                {
                    Header = file.Name,
                    Tag = file.FullName,
                    ContextMenu = contextMenuFile,
                };

                treeElem.Selected += TreeItemSelected;

                directoryNode.Items.Add(treeElem);
            }
            return directoryNode;
        }

        public void TreeItemSelected(object sender, RoutedEventArgs e)
        {
            StringBuilder rahs = new StringBuilder("----");
            TreeViewItem SelectedItem = treeView.SelectedItem as TreeViewItem;
            FileAttributes attributes = File.GetAttributes(SelectedItem.Tag.ToString());

            if (attributes.HasFlag(FileAttributes.ReadOnly))
            {
                rahs[0] = 'r';
            }
            if (attributes.HasFlag(FileAttributes.Archive))
            {
                rahs[1] = 'a';
            }
            if (attributes.HasFlag(FileAttributes.Hidden))
            {
                rahs[2] = 'h';
            }
            if (attributes.HasFlag(FileAttributes.System))
            {
                rahs[3] = 's';
            }


            ((MainWindow)Application.Current.MainWindow).RAHSLabel.Content = rahs.ToString();
        }

        public void menuItemOpenClickHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem SelectedItem = treeView.SelectedItem as TreeViewItem;
            
            string text = File.ReadAllText(SelectedItem.Tag.ToString());
            ((MainWindow)Application.Current.MainWindow).FileOpenTextBlock.Text = text;
        }
        public void menuItemCreateClickHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem SelectedItem = treeView.SelectedItem as TreeViewItem;

            CreateElementForm form = new CreateElementForm(SelectedItem, this);
            form.Show();
        }

        public void removeReadOnly(TreeViewItem item)
        {
            String path = item.Tag.ToString();
            FileAttributes attributes = File.GetAttributes(item.Tag.ToString());

            if (attributes.HasFlag(FileAttributes.Directory))
            {
                var directoryInfo = new DirectoryInfo(path);
                if (attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                    directoryInfo.Attributes &= (~FileAttributes.ReadOnly);
                }

                foreach(TreeViewItem children in item.Items)
                {
                    removeReadOnly(children);
                }
            }
            else
            {
                var fileInfo = new FileInfo(path);
                if (attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                    File.SetAttributes(path, attributes);
                }
            }
        }

        public void menuItemDeleteClickHandler(object sender, RoutedEventArgs e)
        {
            TreeViewItem SelectedItem = treeView.SelectedItem as TreeViewItem;
            String path = SelectedItem.Tag.ToString();
            FileAttributes attributes = File.GetAttributes(SelectedItem.Tag.ToString());

            if (attributes.HasFlag(FileAttributes.Directory))
            {
                //Delete directory recursively
                removeReadOnly(SelectedItem);
                Directory.Delete(path, true);

                var parent = SelectedItem.Parent as TreeViewItem;
                parent.Items.Remove(SelectedItem);
            }
            else
            {
                var fileInfo = new FileInfo(path);
                if (attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                    File.SetAttributes(path, attributes);
                }

                File.Delete(path);

                var parent = SelectedItem.Parent as TreeViewItem;
                parent.Items.Remove(SelectedItem);
            }
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}
