namespace Bau.Applications.TwitterMarketing
{
	partial class frmMain
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdNew = new System.Windows.Forms.ToolStripButton();
			this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
			this.cmdRemove = new System.Windows.Forms.ToolStripButton();
			this.cmdProperties = new System.Windows.Forms.ToolStripButton();
			this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.udtMessenger = new Bau.Applications.TwitterMarketing.Forms.UC.ctlTwitterMessenger();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNew,
            this.cmdUpdate,
            this.cmdRemove,
            this.cmdProperties});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(361, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdNew
			// 
			this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdNew.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.New;
			this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdNew.Name = "cmdNew";
			this.cmdNew.Size = new System.Drawing.Size(23, 22);
			this.cmdNew.Text = "Nueva cuenta";
			this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdUpdate.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Update;
			this.cmdUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.Size = new System.Drawing.Size(23, 22);
			this.cmdUpdate.Text = "Modificar cuenta";
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			// 
			// cmdRemove
			// 
			this.cmdRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdRemove.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Remove;
			this.cmdRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(23, 22);
			this.cmdRemove.Text = "Borrar cuenta";
			this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
			// 
			// cmdProperties
			// 
			this.cmdProperties.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdProperties.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Properties;
			this.cmdProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdProperties.Name = "cmdProperties";
			this.cmdProperties.Size = new System.Drawing.Size(23, 22);
			this.cmdProperties.Text = "Propiedades";
			this.cmdProperties.Click += new System.EventHandler(this.cmdProperties_Click);
			// 
			// ntfIcon
			// 
			this.ntfIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.ntfIcon.BalloonTipText = "TwitterMarketing";
			this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
			this.ntfIcon.Text = "TwitterMarketing";
			this.ntfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDoubleClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
			this.statusStrip1.Location = new System.Drawing.Point(0, 431);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(361, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblMessage
			// 
			this.lblMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(346, 17);
			this.lblMessage.Spring = true;
			this.lblMessage.Text = "Preparado";
			// 
			// udtMessenger
			// 
			this.udtMessenger.Accounts = null;
			this.udtMessenger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.udtMessenger.Location = new System.Drawing.Point(4, 28);
			this.udtMessenger.Name = "udtMessenger";
			this.udtMessenger.Size = new System.Drawing.Size(353, 400);
			this.udtMessenger.TabIndex = 3;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(361, 453);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.udtMessenger);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "TwitterMarketing";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdNew;
		private System.Windows.Forms.ToolStripButton cmdUpdate;
		private System.Windows.Forms.ToolStripButton cmdRemove;
		private System.Windows.Forms.ToolStripButton cmdProperties;
		private System.Windows.Forms.NotifyIcon ntfIcon;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblMessage;
		private Forms.UC.ctlTwitterMessenger udtMessenger;
	}
}

