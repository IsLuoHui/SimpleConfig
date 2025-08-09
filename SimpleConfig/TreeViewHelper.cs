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
            RefreshArtResourceToTree(treeView, path);
        }

        private static ImageList CreateImageList()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add("root", Properties.Resources.root_folder);
            imageList.Images.Add("folder", Properties.Resources.folder);
            imageList.Images.Add("folder_images",Properties.Resources.folder_type_images);
            imageList.Images.Add("folder_audio", Properties.Resources.folder_type_audio); 
            imageList.Images.Add("folder_src", Properties.Resources.folder_type_src);

            imageList.Images.Add("root_opened", Properties.Resources.root_folder_opened);
            imageList.Images.Add("folder_opened", Properties.Resources.folder_opened);
            imageList.Images.Add("folder_images_opened",Properties.Resources.folder_type_images_opened);
            imageList.Images.Add("folder_audio_opened", Properties.Resources.folder_type_audio_opened);
            imageList.Images.Add("folder_src_opened", Properties.Resources.folder_type_src_opened);

            imageList.Images.Add("file", Properties.Resources.file);
            imageList.Images.Add("image", Properties.Resources.file_type_image);
            imageList.Images.Add("audio", Properties.Resources.file_type_audio);
            imageList.Images.Add("protobuf", Properties.Resources.file_type_protobuf);
            return imageList;
        }

        public static (string Name, string ImageKey, string SelectedImageKey)[] FolderInfos
        {
            get
            {
                return new[]
                {
                    ("Charts", "folder_src", "folder_src_opened"),
                    ("Musics", "folder_audio", "folder_audio_opened"),
                    ("Illustrations", "folder_images", "folder_images_opened")
                };
            }
        }

        public static (string Name, string ImageKey)[] FileInfos
        {
            get
            {
                return new[]
                {
                    (".chart", "protobuf"),
                    (".mp3", "audio"),
                    (".png", "image")
                };
            }
        }

        public async Task<string> RefreshTreeViewFromPathAsync(TreeView treeView,string path)
        {
            await Task.Run(() =>
            {
                RefreshArtResourceToTree(treeView, path);
            });
            return "树形图已刷新";
        }



        private static void RefreshArtResourceToTree(TreeView treeView, string rootPath)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            TreeNode rootNode = new TreeNode(new DirectoryInfo(rootPath).Name)
            {
                Tag = rootPath,
                ImageKey = "root",
                SelectedImageKey = "root"
            };


            foreach (var (Name, ImageKey, SelectedImageKey) in FolderInfos)
            {
                string dirPath = Path.Combine(rootPath, Name);
                if (Directory.Exists(dirPath))
                {
                    TreeNode dirNode = new TreeNode(Name)
                    {
                        Tag = dirPath,
                        ImageKey = ImageKey,
                        SelectedImageKey = SelectedImageKey
                    };
                    AddDirectoryNodes(dirNode, dirPath); // 递归遍历内容
                    rootNode.Nodes.Add(dirNode);
                }
            }

            treeView.Nodes.Add(rootNode);
            treeView.EndUpdate();
        }

        private static void AddDirectoryNodes(TreeNode parentNode, string path)
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
                    AddDirectoryNodes(dirNode, dir); // 递归
                    parentNode.Nodes.Add(dirNode);
                }

                // 添加文件
                foreach (string file in Directory.GetFiles(path))
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();
                    var fileInfo = Array.Find(FileInfos, fi => fi.Name.Equals(ext, StringComparison.OrdinalIgnoreCase));

                    if (fileInfo.Name == null) continue; //筛选只显示需要的文件类型

                    string imageKey = fileInfo.Name != null ? fileInfo.ImageKey : "file";

                    TreeNode fileNode = new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file,
                        ImageKey = imageKey,
                        SelectedImageKey = imageKey
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


        #region 加载全部文件到树形图

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
