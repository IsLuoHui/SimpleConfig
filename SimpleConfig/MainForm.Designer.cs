namespace SimpleConfig
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.artResouceFileTreeView = new System.Windows.Forms.TreeView();
            this.userSplitContainer = new System.Windows.Forms.SplitContainer();
            this.illustration = new System.Windows.Forms.PictureBox();
            this.toolFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userSplitContainer)).BeginInit();
            this.userSplitContainer.Panel1.SuspendLayout();
            this.userSplitContainer.Panel2.SuspendLayout();
            this.userSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustration)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.artResouceFileTreeView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.userSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(785, 600);
            this.mainSplitContainer.SplitterDistance = 166;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // artResouceFileTreeView
            // 
            this.artResouceFileTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.artResouceFileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artResouceFileTreeView.Location = new System.Drawing.Point(0, 0);
            this.artResouceFileTreeView.Name = "artResouceFileTreeView";
            this.artResouceFileTreeView.Size = new System.Drawing.Size(166, 600);
            this.artResouceFileTreeView.TabIndex = 0;
            this.artResouceFileTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.artResouceFileTreeView_AfterCollapse);
            this.artResouceFileTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.artResouceFileTreeView_AfterExpand);
            // 
            // userSplitContainer
            // 
            this.userSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.userSplitContainer.Name = "userSplitContainer";
            this.userSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // userSplitContainer.Panel1
            // 
            this.userSplitContainer.Panel1.Controls.Add(this.illustration);
            // 
            // userSplitContainer.Panel2
            // 
            this.userSplitContainer.Panel2.Controls.Add(this.toolFlowLayoutPanel);
            this.userSplitContainer.Size = new System.Drawing.Size(615, 600);
            this.userSplitContainer.SplitterDistance = 203;
            this.userSplitContainer.TabIndex = 0;
            // 
            // illustration
            // 
            this.illustration.BackColor = System.Drawing.SystemColors.Window;
            this.illustration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.illustration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.illustration.Location = new System.Drawing.Point(0, 0);
            this.illustration.Name = "illustration";
            this.illustration.Size = new System.Drawing.Size(615, 203);
            this.illustration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.illustration.TabIndex = 0;
            this.illustration.TabStop = false;
            // 
            // toolFlowLayoutPanel
            // 
            this.toolFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.toolFlowLayoutPanel.Name = "toolFlowLayoutPanel";
            this.toolFlowLayoutPanel.Size = new System.Drawing.Size(615, 393);
            this.toolFlowLayoutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 600);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainForm";
            this.Text = "SimpleConfig";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.userSplitContainer.Panel1.ResumeLayout(false);
            this.userSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userSplitContainer)).EndInit();
            this.userSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.illustration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView artResouceFileTreeView;
        private System.Windows.Forms.SplitContainer userSplitContainer;
        private System.Windows.Forms.PictureBox illustration;
        private System.Windows.Forms.FlowLayoutPanel toolFlowLayoutPanel;
    }
}

