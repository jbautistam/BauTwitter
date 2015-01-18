using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Applications.TwitterMarketing.Forms.UC;
using Bau.Libraries.LibTwitter;

namespace Bau.Applications.TwitterMarketing
{
	/// <summary>
	///		Formulario principal
	/// </summary>
	public partial class frmMain : Form
	{ 
		public frmMain()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Crea el directorio de datos
				Libraries.LibHelper.Files.HelperFiles.MakePath(Classes.TwitterConfiguration.PathData);
			// Inicializa el manager de Twitter
				InitTwitterManager();
			// Inicializa el control
				InitControlMessenger();
			// Si no hay claves de aplicación, muestra un mensaje aclaratorio y abre el formulario de opciones
				if (Classes.TwitterConfiguration.OAuthConsumerKey.IsEmpty() || 
						Classes.TwitterConfiguration.OAuthConsumerSecret.IsEmpty())
					{ // Mensaje al usuario
							Bau.Controls.Forms.Helper.ShowMessage(this, "Antes de conectar a Twitter, introduzca sus claves de aplicación");
						// Muestra el formulario de opciones
							OpenProperties();
					}
		}
		
		/// <summary>
		///		Inicializa el manager de Twitter
		/// </summary>
		private void InitTwitterManager()
		{ Classes.TwitterConfiguration.AssignProperties(Program.TwitterBotManager);
		}

		/// <summary>
		///		Inicializa el control con las cuentas
		/// </summary>
		private void InitControlMessenger(string strScreenName = null)
		{ // Carga las cuentas
				Program.TwitterBotManager.Accounts.Clear();
				AccountsRepository.Load(Classes.TwitterConfiguration.FileNameAccounts, Program.TwitterBotManager);
			// Actualiza el control
				udtMessenger.InitControl(Program.TwitterBotManager.Accounts, strScreenName);
		}

		/// <summary>
		///		Modifica una cuenta
		/// </summary>
		private void UpdateAccount(TwitterAccount objAccount)
		{ Forms.frmAccount frmNewAccount = new Forms.frmAccount();
		
				// Asigna las propiedades
					frmNewAccount.Account = objAccount;
				// Muestra el formulario
					frmNewAccount.ShowDialog();
				// Actualiza el formulario
					if (frmNewAccount.DialogResult == DialogResult.OK)
						InitControlMessenger(frmNewAccount.Account.ScreenName);
		}

		/// <summary>
		///		Borra una cuenta
		/// </summary>
		private void DeleteAccount(TwitterAccount objAccount)
		{ if (objAccount == null)
				Bau.Controls.Forms.Helper.ShowMessage(this, "Seleccione una cuenta");
			else if (Bau.Controls.Forms.Helper.ShowQuestion(this, "¿Realmente desea borrar la cuenta " + objAccount.ScreenName + "?"))
				{ // Elimina la cuenta
						Program.TwitterBotManager.Accounts.RemoveByScreenName(objAccount.ScreenName);
						AccountsRepository.Save(Program.TwitterBotManager.Accounts, Classes.TwitterConfiguration.FileNameAccounts);
					// Actualiza el control
						InitControlMessenger();
				}
		}

		/// <summary>
		///		Abre el formulario de propiedades
		/// </summary>
		private void OpenProperties()
		{ Forms.Configuration.frmOptions frmNewOptions = new Forms.Configuration.frmOptions();
		
				// Muestra el formulario
					frmNewOptions.ShowDialog();
				// Actualiza la configuración
					if (frmNewOptions.DialogResult == DialogResult.OK)
						InitTwitterManager();
		}

		/// <summary>
		///		Muestra / oculta el formulario y el icono de notificación
		/// </summary>
		private void ShowForm(bool blnShow)
		{ // Muestra / oculta la ventana
				if (blnShow)
					{ Visible = true;
						WindowState = FormWindowState.Normal;
					}
				else
					Hide();
			// Muestra / oculta el icono
				ntfIcon.Visible = !blnShow;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{ if (WindowState == FormWindowState.Minimized)
				ShowForm(false);
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{	if (Classes.TwitterConfiguration.StartMinimized)
				ShowForm(false);
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{ UpdateAccount(null);
		}

		private void cmdUpdate_Click(object sender, EventArgs e)
		{ UpdateAccount(udtMessenger.SelectedAccount);
		}

		private void cmdRemove_Click(object sender, EventArgs e)
		{ DeleteAccount(udtMessenger.SelectedAccount);
		}

		private void cmdProperties_Click(object sender, EventArgs e)
		{ OpenProperties();
		}

		private void ntfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{ ShowForm(true);
		}
	}
}
