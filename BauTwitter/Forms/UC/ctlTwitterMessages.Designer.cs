namespace Bau.Applications.TwitterMarketing.Forms.UC
{
	partial class ctlTwitterMessages
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
		if (disposing && (components != null))
		{
		components.Dispose();
		}
		base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		this.components = new System.ComponentModel.Container();
		this.wbExplorer = new Bau.Controls.WebExplorer.WebExplorerExtended();
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.cmdStatus = new System.Windows.Forms.ToolStripButton();
		this.cmdMyMessages = new System.Windows.Forms.ToolStripButton();
		this.cmdFollowers = new System.Windows.Forms.ToolStripButton();
		this.cmdFollowing = new System.Windows.Forms.ToolStripButton();
		this.lblMesssages = new System.Windows.Forms.ToolStripLabel();
		this.panel1 = new System.Windows.Forms.Panel();
		this.tmrDownload = new System.Windows.Forms.Timer(this.components);
		this.toolStrip1.SuspendLayout();
		this.panel1.SuspendLayout();
		this.SuspendLayout();
		// 
		// wbExplorer
		// 
		this.wbExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.wbExplorer.Location = new System.Drawing.Point(0, 0);
		this.wbExplorer.MinimumSize = new System.Drawing.Size(20, 20);
		this.wbExplorer.Name = "wbExplorer";
		this.wbExplorer.Size = new System.Drawing.Size(265, 427);
		this.wbExplorer.TabIndex = 0;
		// 
		// toolStrip1
		// 
		this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdStatus,
            this.cmdMyMessages,
            this.cmdFollowers,
            this.cmdFollowing,
            this.lblMesssages});
		this.toolStrip1.Location = new System.Drawing.Point(0, 430);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(268, 25);
		this.toolStrip1.TabIndex = 1;
		this.toolStrip1.Text = "toolStrip1";
		// 
		// cmdStatus
		// 
		this.cmdStatus.Checked = true;
		this.cmdStatus.CheckState = System.Windows.Forms.CheckState.Checked;
		this.cmdStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdStatus.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Send;
		this.cmdStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdStatus.Name = "cmdStatus";
		this.cmdStatus.Size = new System.Drawing.Size(23, 22);
		this.cmdStatus.Text = "TimeLine";
		this.cmdStatus.Click += new System.EventHandler(this.cmdStatus_Click);
		// 
		// cmdMyMessages
		// 
		this.cmdMyMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdMyMessages.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.URL;
		this.cmdMyMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdMyMessages.Name = "cmdMyMessages";
		this.cmdMyMessages.Size = new System.Drawing.Size(23, 22);
		this.cmdMyMessages.Text = "Mis mensajes";
		this.cmdMyMessages.Click += new System.EventHandler(this.cmdMyMessages_Click);
		// 
		// cmdFollowers
		// 
		this.cmdFollowers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdFollowers.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Follower;
		this.cmdFollowers.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdFollowers.Name = "cmdFollowers";
		this.cmdFollowers.Size = new System.Drawing.Size(23, 22);
		this.cmdFollowers.Text = "Followers";
		this.cmdFollowers.Click += new System.EventHandler(this.cmdFollowers_Click);
		// 
		// cmdFollowing
		// 
		this.cmdFollowing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdFollowing.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Following;
		this.cmdFollowing.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdFollowing.Name = "cmdFollowing";
		this.cmdFollowing.Size = new System.Drawing.Size(23, 22);
		this.cmdFollowing.Text = "Following";
		this.cmdFollowing.Click += new System.EventHandler(this.cmdFollowing_Click);
		// 
		// lblMesssages
		// 
		this.lblMesssages.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.lblMesssages.Name = "lblMesssages";
		this.lblMesssages.Size = new System.Drawing.Size(15, 22);
		this.lblMesssages.Text = "--";
		// 
		// panel1
		// 
		this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
								| System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.wbExplorer);
		this.panel1.Location = new System.Drawing.Point(0, 1);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(267, 429);
		this.panel1.TabIndex = 2;
		// 
		// tmrDownload
		// 
		this.tmrDownload.Tick += new System.EventHandler(this.tmrDownload_Tick);
		// 
		// ctlTwitterMessages
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.Controls.Add(this.panel1);
		this.Controls.Add(this.toolStrip1);
		this.Name = "ctlTwitterMessages";
		this.Size = new System.Drawing.Size(268, 455);
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		this.panel1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();

		}

		#endregion

		private Bau.Controls.WebExplorer.WebExplorerExtended wbExplorer;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdStatus;
		private System.Windows.Forms.ToolStripButton cmdMyMessages;
		private System.Windows.Forms.ToolStripButton cmdFollowers;
		private System.Windows.Forms.ToolStripButton cmdFollowing;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripLabel lblMesssages;
		private System.Windows.Forms.Timer tmrDownload;

	}
}
