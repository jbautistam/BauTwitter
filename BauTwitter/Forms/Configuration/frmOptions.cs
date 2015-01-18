using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.TwitterMarketing.Classes;

namespace Bau.Applications.TwitterMarketing.Forms.Configuration
{
	/// <summary>
	///		Formulario para el mantenimiento de opciones
	/// </summary>
	public partial class frmOptions : Form
	{
		public frmOptions()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ LoadConfiguration();
		}
		
		/// <summary>
		///		Carga la configuración
		/// </summary>
		private void LoadConfiguration()
		{ // Claves de aplicación
				txtAppConsumerKey.Text = TwitterConfiguration.OAuthConsumerKey;
				txtAppConsumerSecret.Text = TwitterConfiguration.OAuthConsumerSecret;
			// Datos de Twitter
				nudTimeLineMaximum.Value = TwitterConfiguration.MessagesTwitterMaximum;
				nudTimeLineMinutes.Value = TwitterConfiguration.MinutesBetweenDownloadStatus;
				chkStartMinimized.Checked = TwitterConfiguration.StartMinimized;
		}
		
		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;
		
				// Comprueba los datos introducidos
					if (string.IsNullOrEmpty(txtAppConsumerKey.Text))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la clave de la aplicación");
					else if (string.IsNullOrEmpty(txtAppConsumerSecret.Text))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la clave secreta de la aplicación");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}
		
		/// <summary>
		///		Graba los datos
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{ // Claves de aplicación
						TwitterConfiguration.OAuthConsumerKey = txtAppConsumerKey.Text;
						TwitterConfiguration.OAuthConsumerSecret = txtAppConsumerSecret.Text;
					// Datos de Twitter
						TwitterConfiguration.MessagesTwitterMaximum = (int) nudTimeLineMaximum.Value;
						TwitterConfiguration.MinutesBetweenDownloadStatus = (int) nudTimeLineMinutes.Value;
						TwitterConfiguration.StartMinimized = chkStartMinimized.Checked;
					// Graba la configuración
						TwitterConfiguration.Save();
					// Asigna las proiedades al objeto de configuración actual
						TwitterConfiguration.AssignProperties(Program.TwitterBotManager);
					// Cierra indicando que se ha procesado correctamente
						DialogResult = DialogResult.OK;
						Close();
				}
		}
		
		private void frmOptions_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}
