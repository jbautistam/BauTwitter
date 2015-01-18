using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibTwitter;

namespace Bau.Applications.TwitterMarketing.Forms.UC
{
	/// <summary>
	///		Control para obtener los datos de un mensaje
	/// </summary>
	public partial class ctlMessage : UserControl
	{ 
		public ctlMessage()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl()
		{ 
		}

		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		public bool ValidateData(out string strError)
		{ bool blnValidate = false;
		
				// Inicializa el valor de salida
					strError = "";
				// Comprueba los datos introducidos
					if (string.IsNullOrEmpty(txtTitle.Text))
						strError = "Introduzca el mensaje";
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos introducidos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Mensaje cargado
		/// </summary>
		public string Message 
		{ get { return txtTitle.Text; } 
			set { txtTitle.Text = value; }
		}

		private void txtTitle_TextChanged(object sender, EventArgs e)
		{ lblCharacters.Text = txtTitle.Text.Length.ToString();
		}
	}
}
