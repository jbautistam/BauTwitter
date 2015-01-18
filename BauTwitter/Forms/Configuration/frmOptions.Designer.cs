namespace Bau.Applications.TwitterMarketing.Forms.Configuration
{
	partial class frmOptions
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtAppConsumerSecret = new System.Windows.Forms.TextBox();
			this.txtAppConsumerKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdAccept = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkStartMinimized = new System.Windows.Forms.CheckBox();
			this.nudTimeLineMinutes = new Bau.Controls.TextBox.NumericUpDowExtended();
			this.nudTimeLineMaximum = new Bau.Controls.TextBox.NumericUpDowExtended();
			this.label20 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeLineMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeLineMaximum)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtAppConsumerSecret);
			this.groupBox1.Controls.Add(this.txtAppConsumerKey);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(363, 148);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Claves de aplicación";
			// 
			// txtAppConsumerSecret
			// 
			this.txtAppConsumerSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAppConsumerSecret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.txtAppConsumerSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAppConsumerSecret.Location = new System.Drawing.Point(113, 43);
			this.txtAppConsumerSecret.Name = "txtAppConsumerSecret";
			this.txtAppConsumerSecret.Size = new System.Drawing.Size(244, 20);
			this.txtAppConsumerSecret.TabIndex = 3;
			// 
			// txtAppConsumerKey
			// 
			this.txtAppConsumerKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAppConsumerKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.txtAppConsumerKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAppConsumerKey.Location = new System.Drawing.Point(113, 19);
			this.txtAppConsumerKey.Name = "txtAppConsumerKey";
			this.txtAppConsumerKey.Size = new System.Drawing.Size(244, 20);
			this.txtAppConsumerKey.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label2.Location = new System.Drawing.Point(16, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Consumer key:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(16, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Consumer secret:";
			// 
			// cmdAccept
			// 
			this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAccept.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Accept;
			this.cmdAccept.Location = new System.Drawing.Point(214, 260);
			this.cmdAccept.Name = "cmdAccept";
			this.cmdAccept.Size = new System.Drawing.Size(74, 26);
			this.cmdAccept.TabIndex = 4;
			this.cmdAccept.Text = "&Aceptar";
			this.cmdAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdAccept.UseVisualStyleBackColor = true;
			this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Image = global::Bau.Applications.TwitterMarketing.Properties.Resources.Remove;
			this.cmdCancel.Location = new System.Drawing.Point(292, 260);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(74, 26);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "&Cancelar";
			this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.chkStartMinimized);
			this.groupBox4.Controls.Add(this.nudTimeLineMinutes);
			this.groupBox4.Controls.Add(this.nudTimeLineMaximum);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Controls.Add(this.label22);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.groupBox4.Location = new System.Drawing.Point(5, 158);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(363, 97);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Timeline de Twitter";
			// 
			// chkStartMinimized
			// 
			this.chkStartMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkStartMinimized.AutoSize = true;
			this.chkStartMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkStartMinimized.ForeColor = System.Drawing.Color.Black;
			this.chkStartMinimized.Location = new System.Drawing.Point(237, 74);
			this.chkStartMinimized.Name = "chkStartMinimized";
			this.chkStartMinimized.Size = new System.Drawing.Size(120, 17);
			this.chkStartMinimized.TabIndex = 4;
			this.chkStartMinimized.Text = "Arrancar minimizado";
			this.chkStartMinimized.UseVisualStyleBackColor = true;
			// 
			// nudTimeLineMinutes
			// 
			this.nudTimeLineMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudTimeLineMinutes.Location = new System.Drawing.Point(223, 44);
			this.nudTimeLineMinutes.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
			this.nudTimeLineMinutes.Name = "nudTimeLineMinutes";
			this.nudTimeLineMinutes.Size = new System.Drawing.Size(64, 20);
			this.nudTimeLineMinutes.TabIndex = 3;
			this.nudTimeLineMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// nudTimeLineMaximum
			// 
			this.nudTimeLineMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudTimeLineMaximum.Location = new System.Drawing.Point(223, 20);
			this.nudTimeLineMaximum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
			this.nudTimeLineMaximum.Name = "nudTimeLineMaximum";
			this.nudTimeLineMaximum.Size = new System.Drawing.Size(64, 20);
			this.nudTimeLineMaximum.TabIndex = 1;
			this.nudTimeLineMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label20.Location = new System.Drawing.Point(16, 46);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(177, 13);
			this.label20.TabIndex = 2;
			this.label20.Text = "Tiempo entre descargas de timeline:";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label22.Location = new System.Drawing.Point(16, 22);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(122, 13);
			this.label22.TabIndex = 0;
			this.label22.Text = "Nº máximo de mensajes:";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label3.Location = new System.Drawing.Point(7, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(352, 67);
			this.label3.TabIndex = 2;
			this.label3.Text = "Nota:";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(21, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(332, 41);
			this.label4.TabIndex = 2;
			this.label4.Text = "Para obtener las claves de aplicación, conéctate a la dirección https://apps.twit" +
    "ter.com/ desde un navegador, selecciona tu usuario de Twitter y pulsa sobre \'Cre" +
    "ar nueva aplicación\'.";
			// 
			// frmOptions
			// 
			this.AcceptButton = this.cmdAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(374, 291);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdAccept);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuración";
			this.Load += new System.EventHandler(this.frmOptions_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeLineMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeLineMaximum)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAppConsumerKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAppConsumerSecret;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox groupBox4;
		private Bau.Controls.TextBox.NumericUpDowExtended nudTimeLineMinutes;
		private Bau.Controls.TextBox.NumericUpDowExtended nudTimeLineMaximum;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.CheckBox chkStartMinimized;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
	}
}