using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;


namespace SimpleConfig
{
    internal class TreeViewHelper
    {
        public static void TreeViewInit(TreeView treeView,String path)
        {
            treeView.ImageList = CreateImageList();
            LoadAllDirectoryToTree(treeView, path);
        }

        private static ImageList CreateImageList()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add("root", Properties.Resources.root_folder);
            imageList.Images.Add("root_opened", Properties.Resources.root_folder_opened);
            imageList.Images.Add("folder", Properties.Resources.folder);
            imageList.Images.Add("folder_opened", Properties.Resources.folder_opened);
            imageList.Images.Add("file", Properties.Resources.file);
            return imageList;
        }

        public async Task<string> RefreshTreeViewFromPathAsync(TreeView treeView,string path)
        {
            await Task.Run(() =>
            {
                LoadAllDirectoryToTree(treeView, path);
            });
            return "树形图已刷新";
        }

        #region 加载所有文件

        private static void LoadAllDirectoryToTree(TreeView treeView, string rootPath)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            

            TreeNode rootNode = new TreeNode(new DirectoryInfo(rootPath).Name)
            {
                Tag = rootPath,
                ImageKey = "root",
                SelectedImageKey = "root"

            };

            AddAllDirectoryNodes(rootNode, rootPath);
            treeView.Nodes.Add(rootNode);

            treeView.EndUpdate();
        }

        private static void AddAllDirectoryNodes(TreeNode parentNode, string path)
        {
            try
            {
                // 添加子文件夹
                foreach (string dir in Directory.GetDirectories(path))
                {
                    TreeNode dirNode = new TreeNode(Path.GetFileName(dir))
                    {
                        Tag = dir,
                        ImageKey = "folder",
                        SelectedImageKey = "folder"
                    };
                    AddAllDirectoryNodes(dirNode, dir); // 递归
                    parentNode.Nodes.Add(dirNode);
                }

                // 添加文件
                foreach (string file in Directory.GetFiles(path))
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file,
                        ImageKey = "file",
                        SelectedImageKey = "file"
                    };
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 某些系统目录可能无法访问
                TreeNode errorNode = new TreeNode("访问被拒绝");
                parentNode.Nodes.Add(errorNode);
            }
        }

        #endregion

        
    }
}
