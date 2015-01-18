using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTwitter;
using Bau.Libraries.LibTwitter.Messages;

namespace Bau.Applications.TwitterMarketing.Forms.UC
{
	/// <summary>
	///		Control para enviar y recibir mensajes de Twitter
	/// </summary>
	public partial class ctlTwitterMessenger : UserControl
	{
		public ctlTwitterMessenger()
		{ InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl(TwitterAccountsCollection objColAccounts, string strScreenName = null)
		{ // Inicializa el control
				Accounts = objColAccounts;
			// Limpia los datos
				lblCounter.Text = "0 caracteres";
				lblFollowing.Text = "--";
			// Carga el combo de cuentas
				LoadComboAccounts(objColAccounts, strScreenName);
			// Pasa el foco al cuadro de texto
				txtMessage.Focus();
		}
		
		/// <summary>
		///		Carga el combo de cuentas
		/// </summary>
		private void LoadComboAccounts(TwitterAccountsCollection objColAccounts, string strScreenName = null)
		{ // Limpia el combo
				cboAccounts.Items.Clear();
			// Carga los datos
				for (int intIndex = 0; intIndex < objColAccounts.Count; intIndex++)
				  cboAccounts.AddItem(intIndex, objColAccounts[intIndex].ScreenName);
			// Selecciona el primer elemento
				if (cboAccounts.Items.Count > 0)
					{ if (!string.IsNullOrEmpty(strScreenName))
							cboAccounts.SelectedText = strScreenName;
						else 
							cboAccounts.SelectedIndex = 0;
					}
		}
		
		/// <summary>
		///		Envía el mensaje
		/// </summary>
		private void SendMessage()
		{ TwitterAccount objAccount = SelectedAccount;
		
				if (objAccount != null && !txtMessage.Text.IsEmpty())
					{ string strError;

							// Envía el mensaje
								if (!Program.TwitterBotManager.TwitterMessenger.SendMessage(objAccount, txtMessage.Text, out strError))
									Bau.Controls.Forms.Helper.ShowMessage(ParentForm, "Error: " + strError);
								else
									txtMessage.Text = "";
					}
		}

		/// <summary>
		///		Acorta una URL
		/// </summary>
		private void ShortURL()
		{ Forms.frmShortURL frmNewShort = new Forms.frmShortURL();
		
				// Muestra el formulario
					frmNewShort.ShowDialog();
				// Recoge la URL
					if (frmNewShort.DialogResult == DialogResult.OK)
						txtMessage.AppendText(frmNewShort.URL);
		}
		
		/// <summary>
		///		Muestra el estado de la cuenta
		/// </summary>
		public void ShowStatus()
		{ // Cambia la cuenta
				udtMessages.Account = SelectedAccount;
			// Carga los datos
				udtMessages.Clear();
				udtMessages.LoadData(ctlTwitterMessages.ShowType.Messages);
			// Muestra la información de seguidores
				ShowProfileData();
			// Cambia el foco
				txtMessage.Focus();
		}

		/// <summary>
		///		Muestra los datos del perfil
		/// </summary>
		public void ShowProfileData()
		{	lblFollowing.Text = "";
			if (SelectedAccount != null)
			  { TwitterMessageUser objMessage = Program.TwitterBotManager.TwitterMessenger.GetUserTwitter(SelectedAccount, SelectedAccount.ScreenName);
				
			      if (objMessage != null)
			        lblFollowing.Text = string.Format("Seguidores: {0:#,##0} / Siguiendo: {1:#,##0}", 
			                                          objMessage.User.FollowersCount, objMessage.User.FriendsCount);
			  }
		}
		
		/// <summary>
		///		Cuentas asociadas
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public TwitterAccountsCollection Accounts { get; set; }

		/// <summary>
		///		Obtiene la cuenta seleccionada
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public TwitterAccount SelectedAccount
		{ get
				{ if (cboAccounts.SelectedID != null)
					  return Accounts.SearchByUser(cboAccounts.Text);
					else
					  return null;
				}
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{ SendMessage();
		}

		private void txtMessage_TextChanged(object sender, EventArgs e)
		{ lblCounter.Text = txtMessage.Text.Length + " caracteres";
		}

		private void cmdURL_Click(object sender, EventArgs e)
		{ ShortURL();
		}

		private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
		{ ShowStatus();
		}

		private void udtMessages_SendMessage(object objSender, string strMessage)
		{ txtMessage.AppendText(strMessage);
		}
	}
}
