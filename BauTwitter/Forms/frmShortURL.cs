using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibTwitter.ShortURL;

namespace Bau.Applications.TwitterMarketing.Forms.UC.Forms
{
	/// <summary>
	///		Formulario para acortar una URL
	/// </summary>
	public partial class frmShortURL : Form
	{ 				
		public frmShortURL()
		{ InitializeComponent();
		}
		
		/// <summary>
		///		Comprueba si los datos introducidos son correctos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false; // ... supone que los datos no son correctos
		
				// Comprueba los datos
					if (string.IsNullOrEmpty(txtURL.Text))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la URL");
					else
						blnValidate = true;
				// Devuelve el valor que indica si son correctos
					return blnValidate;
		}
		
		/// <summary>
		///		Obtiene la URL
		/// </summary>
		private void Save()
		{ if (ValidateData())
				try
					{ // Asigna la URL
							URL = TinyURL.Convert(txtURL.Text);
						// Cierra el formulario
							DialogResult = DialogResult.OK;
							Close();
					}
				catch (Exception objException)
					{ Bau.Controls.Forms.Helper.ShowMessage(this, "Error al acortar la URL " + Environment.NewLine + objException.Message);
					}
		}
		
		/// <summary>
		///		URL acortada
		/// </summary>
		public string URL { get; private set; }

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}