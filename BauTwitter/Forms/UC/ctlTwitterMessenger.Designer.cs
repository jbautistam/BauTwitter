namespace Bau.Applications.TwitterMarketing.Forms.UC
{
	partial class ctlTwitterMessenger
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
			this.collapsiblePanelSplitter1 = new Bau.Controls.Split.CollapsiblePanelSplitter();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdSend = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.cboAccounts = new Bau.Controls.Combos.ComboBoxExtended();
			this.lblFollowing = new System.Windows.Forms.Label();
			this.lblCounter = new System.Windows.Forms.Label();
			this.cmdURL = new System.Windows.Forms.Button();
			this.udtMessages = new Bau.Applications.TwitterMarketing.Forms.UC.ctlTwitterMessages();
			((System.ComponentModel.ISupportInitialize)(this.collapsiblePanelSplitter1)).BeginInit();
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
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.label1);
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.cmdSend);
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.txtMessage);
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.cboAccounts);
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.lblFollowing);
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.lblCounter);
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.cmdURL);
			this.collapsiblePanelSplitter1.Panel1MinSize = 0;
			// 
			// collapsiblePanelSplitter1.Panel2
			// 
			this.collapsiblePanelSplitter1.Panel2.Controls.Add(this.udtMessages);
			this.collapsiblePanelSplitter1.Panel2MinSize = 0;
			this.collapsiblePanelSplitter1.Size = new System.Drawing.Size(293, 470);
			this.collapsiblePanelSplitter1.SplitterDistance = 160;
			this.collapsiblePanelSplitter1.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
			this.collapsiblePanelSplitter1.SplitterWidth = 8;
			this.collapsiblePanelSplitter1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cuentas:";
			// 
			// cmdSend
			// 
			this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSend.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Send;
			this.cmdSend.Location = new System.Drawing.Point(217, 27);
			this.cmdSend.Margin = new System.Windows.Forms.Padding(0);
			this.cmdSend.Name = "cmdSend";
			this.cmdSend.Size = new System.Drawing.Size(72, 84);
			this.cmdSend.TabIndex = 6;
			this.cmdSend.Text = "Enviar";
			this.cmdSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdSend.UseVisualStyleBackColor = true;
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(3, 30);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMessage.Size = new System.Drawing.Size(211, 104);
			this.txtMessage.TabIndex = 5;
			this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
			// 
			// cboAccounts
			// 
			this.cboAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccounts.FormattingEnabled = true;
			this.cboAccounts.Location = new System.Drawing.Point(58, 3);
			this.cboAccounts.Name = "cboAccounts";
			this.cboAccounts.SelectedID = null;
			this.cboAccounts.Size = new System.Drawing.Size(232, 21);
			this.cboAccounts.TabIndex = 1;
			this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
			// 
			// lblFollowing
			// 
			this.lblFollowing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblFollowing.AutoSize = true;
			this.lblFollowing.ForeColor = System.Drawing.Color.Black;
			this.lblFollowing.Location = new System.Drawing.Point(3, 140);
			this.lblFollowing.Name = "lblFollowing";
			this.lblFollowing.Size = new System.Drawing.Size(61, 13);
			this.lblFollowing.TabIndex = 8;
			this.lblFollowing.Text = "lblFollowing";
			// 
			// lblCounter
			// 
			this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCounter.AutoSize = true;
			this.lblCounter.ForeColor = System.Drawing.Color.Black;
			this.lblCounter.Location = new System.Drawing.Point(219, 140);
			this.lblCounter.Name = "lblCounter";
			this.lblCounter.Size = new System.Drawing.Size(66, 13);
			this.lblCounter.TabIndex = 8;
			this.lblCounter.Text = "0 caracteres";
			// 
			// cmdURL
			// 
			this.cmdURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdURL.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.URL;
			this.cmdURL.Location = new System.Drawing.Point(217, 111);
			this.cmdURL.Margin = new System.Windows.Forms.Padding(0);
			this.cmdURL.Name = "cmdURL";
			this.cmdURL.Size = new System.Drawing.Size(72, 24);
			this.cmdURL.TabIndex = 7;
			this.cmdURL.Text = "URL";
			this.cmdURL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdURL.UseVisualStyleBackColor = true;
			this.cmdURL.Click += new System.EventHandler(this.cmdURL_Click);
			// 
			// udtMessages
			// 
			this.udtMessages.Account = null;
			this.udtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtMessages.Location = new System.Drawing.Point(0, 0);
			this.udtMessages.Name = "udtMessages";
			this.udtMessages.ScreenName = null;
			this.udtMessages.Size = new System.Drawing.Size(293, 302);
			this.udtMessages.TabIndex = 0;
			this.udtMessages.SendMessage += new Bau.Applications.TwitterMarketing.Forms.UC.ctlTwitterMessages.SendMessageHandler(this.udtMessages_SendMessage);
			// 
			// ctlTwitterMessenger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.collapsiblePanelSplitter1);
			this.Name = "ctlTwitterMessenger";
			this.Size = new System.Drawing.Size(293, 470);
			this.collapsiblePanelSplitter1.Panel1.ResumeLayout(false);
			this.collapsiblePanelSplitter1.Panel1.PerformLayout();
			this.collapsiblePanelSplitter1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.collapsiblePanelSplitter1)).EndInit();
			this.collapsiblePanelSplitter1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Bau.Controls.Split.CollapsiblePanelSplitter collapsiblePanelSplitter1;
		private System.Windows.Forms.Button cmdSend;
		private System.Windows.Forms.Label label1;
		private Bau.Controls.Combos.ComboBoxExtended cboAccounts;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Label lblCounter;
		private System.Windows.Forms.Button cmdURL;
		private ctlTwitterMessages udtMessages;
		private System.Windows.Forms.Label lblFollowing;
	}
}
