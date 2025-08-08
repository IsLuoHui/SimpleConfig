using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleConfig
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //string rootPath = Application.StartupPath;
            //MessageBox.Show($"当前路径{rootPath}", "标题", MessageBoxButtons.OK, MessageBoxIcon.Information);
            illustration.Image = Image.FromFile("D:\\User\\Desktop\\SimpleArtResources\\Illustrations\\Chapter1\\Img_Augenstern.png");

            ConfigData config = ConfigData.LoadAllConfig("D:\\User\\Desktop\\SimpleArtResources");
            config.Chapters[0].ChapterTitle = "单";
            ConfigData.SaveAllConfig(config, "D:\\User\\Desktop\\SimpleArtResources");
            TreeViewHelper.TreeViewInit(artResouceFileTreeView, "D:\\User\\Desktop\\SimpleArtResources");
            //string result = await TreeViewHelper.RefreshTreeViewFromPathAsync(artResouceFileTreeView, "D:\\User\\Desktop\\SimpleArtResources");
        
        }





        #region TreeView外观

        private void artResouceFileTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.ImageKey = "root_opened";
                e.Node.SelectedImageKey= "root_opened";
            }
            else
            {
                e.Node.ImageKey = "folder_opened";
                e.Node.SelectedImageKey = "folder_opened";
            }
            artResouceFileTreeView.Invalidate();
        }

        private void artResouceFileTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.ImageKey = "root";
                e.Node.SelectedImageKey = "root";
            }
            else
            {
                e.Node.ImageKey = "folder";
                e.Node.SelectedImageKey = "folder";
            }
            artResouceFileTreeView.Invalidate();
        }

        #endregion


    }
}
