namespace Bau.Applications.TwitterMarketing.Forms
{
	partial class frmSignTwitter
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
		if(disposing && ( components != null )) {
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
			this.wbExplorer = new System.Windows.Forms.WebBrowser();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPinCode = new System.Windows.Forms.TextBox();
			this.cmdAccept = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// wbExplorer
			// 
			this.wbExplorer.Location = new System.Drawing.Point(-1, 1);
			this.wbExplorer.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbExplorer.Name = "wbExplorer";
			this.wbExplorer.Size = new System.Drawing.Size(694, 543);
			this.wbExplorer.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 557);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Código PIN:";
			// 
			// txtPinCode
			// 
			this.txtPinCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtPinCode.Location = new System.Drawing.Point(91, 550);
			this.txtPinCode.Name = "txtPinCode";
			this.txtPinCode.Size = new System.Drawing.Size(117, 20);
			this.txtPinCode.TabIndex = 2;
			// 
			// cmdAccept
			// 
			this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAccept.Location = new System.Drawing.Point(553, 550);
			this.cmdAccept.Name = "cmdAccept";
			this.cmdAccept.Size = new System.Drawing.Size(67, 22);
			this.cmdAccept.TabIndex = 3;
			this.cmdAccept.Text = "&Aceptar";
			this.cmdAccept.UseVisualStyleBackColor = true;
			this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(626, 550);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(67, 22);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "&Cancelar";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// frmSignTwitter
			// 
			this.AcceptButton = this.cmdAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(696, 577);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdAccept);
			this.Controls.Add(this.txtPinCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.wbExplorer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSignTwitter";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autorizar a la aplicación el uso de su cuenta Twitter";
			this.Load += new System.EventHandler(this.frmSignTwitter_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser wbExplorer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPinCode;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
	}
}