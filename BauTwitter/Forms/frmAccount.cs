using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTwitter;

namespace Bau.Applications.TwitterMarketing.Forms
{
	/// <summary>
	///		Formulario para el mantenimiento de datos de cuenta
	/// </summary>
	public partial class frmAccount : Form
	{
		public frmAccount()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ //	Inicializa la cuenta
				if (Account == null)
					Account = new TwitterAccount(Program.TwitterBotManager);
			// Carga los datos de la cuenta
				LoadAccount();
		}

		/// <summary>
		///		Carga los datos de la cuenta
		/// </summary>
		private void LoadAccount()
		{ // Indica que no está validada
				lblValidated.Text = "No validada";
			// Carga los datos de la cuenta
				if (Account != null)
					{ // Datos de la cuenta
							txtScreenName.Text = Account.ScreenName;
							if (!Account.NeedAuthorization)
								lblValidated.Text = "Validada";
					}
		}		

		/// <summary>
		///		Comprueba los datos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false; // ... supone que los datos no son correctos
		
				// Comprueba los datos
					if (string.IsNullOrEmpty(txtScreenName.Text))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el nombre de usuario");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}
		
		/// <summary>
		///		Graba los datos
		/// </summary>
		private void Save(bool blnClose)
		{ if (ValidateData())
				{ // Asigna las propiedades a la cuenta
						Account.ScreenName = txtScreenName.Text;
					// Añade los datos de la cuenta
						Program.TwitterBotManager.Accounts.RemoveByScreenName(Account.ScreenName);
						Program.TwitterBotManager.Accounts.Add(Account);
					// Graba el archivo de cuentas
						AccountsRepository.Save(Program.TwitterBotManager.Accounts, Classes.TwitterConfiguration.FileNameAccounts);
					// Cierra la ventana
							if (blnClose)
								{ DialogResult = DialogResult.OK;
									Close();
								}
				}
		}
		
		/// <summary>
		///		Valida el usuario
		/// </summary>
		private void ValidateUser()
		{ if (ValidateData())
				{ frmSignTwitter frmNewSign = new frmSignTwitter();
				
						// Graba la cuenta
							Save(false);
						// Muestra el usuario
							frmNewSign.ShowDialog();
						// Recoge los resultados
							if (frmNewSign.DialogResult == System.Windows.Forms.DialogResult.OK)
								{ // Asigna los datos
							      Account.OAuthToken = frmNewSign.OAuthToken;
							      Account.OAuthTokenSecret = frmNewSign.OAuthSecretToken;
							    // Graba los datos
							      Save(false);
							    // Actualiza la cuenta
							      LoadAccount();
								}
				}
			else
				Bau.Controls.Forms.Helper.ShowMessage(this, "Grabe los datos de la cuenta antes de validar");
		}

		/// <summary>
		///		Cuenta
		/// </summary>
		public TwitterAccount Account { get; set; }
		
		private void frmAccount_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save(true);
		}

		private void cmdValidate_Click(object sender, EventArgs e)
		{ ValidateUser();
		}
	}
}
