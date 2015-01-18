namespace Bau.Applications.TwitterMarketing.Forms.UC.Forms
{
	partial class frmTwitterUser
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTwitterUser));
		this.collapsiblePanelSplitter1 = new Bau.Controls.Split.CollapsiblePanelSplitter();
		this.txtDescription = new System.Windows.Forms.TextBox();
		this.lblFollowing = new System.Windows.Forms.Label();
		this.lblWeb = new System.Windows.Forms.Label();
		this.lblFollowers = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.udtMessages = new Bau.Applications.TwitterMarketing.Forms.UC.ctlTwitterMessages();
		this.collapsiblePanelSplitter1.Panel1.SuspendLayout();
		this.collapsiblePanelSplitter1.Panel2.SuspendLayout();
		this.collapsiblePanelSplitter1.SuspendLayout();
		this.SuspendLayout();
		// 
		// collapsiblePanelSplitter1
		// 
		this.collapsiblePanelSplitter1.BackColorSplitter = System.Drawing.SystemColors.Control;
		this.collapsiblePanelSplitter1.CollapseAction = Bau.Controls.Split.CollapsiblePanelSplitter.CollapseMode.CollapsePanel1;
		this.collapsiblePanelSplitter1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.collapsiblePanelSplitter1.Location = new System.Drawing.Point(0, 0);
		this.collapsiblePanelSplitter1.Name = "collapsiblePanelSplitter1";
		this.collapsiblePanelSplitter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// collapsiblePanelSplitter1.Panel1
		// 
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.txtDescription);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.lblFollowing);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.lblWeb);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.lblFollowers);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.label3);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.label4);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.label2);
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.label1);
		this.collapsiblePanelSplitter1.Panel1MinSize = 0;
		// 
		// collapsiblePanelSplitter1.Panel2
		// 
		this.collapsiblePanelSplitter1.Panel2.Controls.Add(this.udtMessages);
		this.collapsiblePanelSplitter1.Panel2MinSize = 0;
		this.collapsiblePanelSplitter1.Size = new System.Drawing.Size(292, 443);
		this.collapsiblePanelSplitter1.SplitterDistance = 102;
		this.collapsiblePanelSplitter1.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
		this.collapsiblePanelSplitter1.SplitterWidth = 8;
		this.collapsiblePanelSplitter1.TabIndex = 0;
		// 
		// txtDescription
		// 
		this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
								| System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.txtDescription.BackColor = System.Drawing.Color.White;
		this.txtDescription.Location = new System.Drawing.Point(88, 8);
		this.txtDescription.Multiline = true;
		this.txtDescription.Name = "txtDescription";
		this.txtDescription.ReadOnly = true;
		this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtDescription.Size = new System.Drawing.Size(198, 45);
		this.txtDescription.TabIndex = 3;
		// 
		// lblFollowing
		// 
		this.lblFollowing.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.lblFollowing.AutoSize = true;
		this.lblFollowing.BackColor = System.Drawing.Color.Transparent;
		this.lblFollowing.Location = new System.Drawing.Point(226, 58);
		this.lblFollowing.Name = "lblFollowing";
		this.lblFollowing.Size = new System.Drawing.Size(61, 13);
		this.lblFollowing.TabIndex = 2;
		this.lblFollowing.Text = "lblFollowing";
		// 
		// lblWeb
		// 
		this.lblWeb.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.lblWeb.AutoSize = true;
		this.lblWeb.BackColor = System.Drawing.Color.Transparent;
		this.lblWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.lblWeb.ForeColor = System.Drawing.Color.Blue;
		this.lblWeb.Location = new System.Drawing.Point(87, 78);
		this.lblWeb.Name = "lblWeb";
		this.lblWeb.Size = new System.Drawing.Size(40, 13);
		this.lblWeb.TabIndex = 2;
		this.lblWeb.Text = "lblWeb";
		this.lblWeb.Click += new System.EventHandler(this.lblWeb_Click);
		// 
		// lblFollowers
		// 
		this.lblFollowers.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.lblFollowers.AutoSize = true;
		this.lblFollowers.BackColor = System.Drawing.Color.Transparent;
		this.lblFollowers.Location = new System.Drawing.Point(87, 58);
		this.lblFollowers.Name = "lblFollowers";
		this.lblFollowers.Size = new System.Drawing.Size(61, 13);
		this.lblFollowers.TabIndex = 2;
		this.lblFollowers.Text = "lblFollowers";
		// 
		// label3
		// 
		this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label3.Location = new System.Drawing.Point(163, 58);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(57, 13);
		this.label3.TabIndex = 0;
		this.label3.Text = "Siguiendo:";
		// 
		// label4
		// 
		this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.label4.AutoSize = true;
		this.label4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label4.Location = new System.Drawing.Point(8, 78);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(33, 13);
		this.label4.TabIndex = 0;
		this.label4.Text = "Web:";
		// 
		// label2
		// 
		this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label2.Location = new System.Drawing.Point(8, 58);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(63, 13);
		this.label2.TabIndex = 0;
		this.label2.Text = "Seguidores:";
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label1.Location = new System.Drawing.Point(8, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(66, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Descripción:";
		// 
		// udtMessages
		// 
		this.udtMessages.Account = null;
		this.udtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
		this.udtMessages.Location = new System.Drawing.Point(0, 0);
		this.udtMessages.Name = "udtMessages";
		this.udtMessages.Size = new System.Drawing.Size(292, 333);
		this.udtMessages.TabIndex = 0;
		this.udtMessages.Load += new System.EventHandler(this.udtMessages_Load);
		// 
		// frmTwitterUser
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(292, 443);
		this.Controls.Add(this.collapsiblePanelSplitter1);
		this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
		this.Name = "frmTwitterUser";
		this.Text = "Usuario";
		this.collapsiblePanelSplitter1.Panel1.ResumeLayout(false);
		this.collapsiblePanelSplitter1.Panel1.PerformLayout();
		this.collapsiblePanelSplitter1.Panel2.ResumeLayout(false);
		this.collapsiblePanelSplitter1.ResumeLayout(false);
		this.ResumeLayout(false);

		}

		#endregion

		private Bau.Controls.Split.CollapsiblePanelSplitter collapsiblePanelSplitter1;
		private ctlTwitterMessages udtMessages;
		private System.Windows.Forms.Label lblFollowing;
		private System.Windows.Forms.Label lblWeb;
		private System.Windows.Forms.Label lblFollowers;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescription;
	}
}