using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTwitter;
using Bau.Libraries.LibTwitter.Messages;

namespace Bau.Applications.TwitterMarketing.Forms.UC.Forms
{
	/// <summary>
	///		Formulario para mostrar los datos de un usuario de Twitter
	/// </summary>
	public partial class frmTwitterUser : Form
	{
		public frmTwitterUser()
		{ InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Carga los datos de usuario
				LoadUser(Account, ScreenName);
			// Carga el TimeLine
				udtMessages.LoadData(ctlTwitterMessages.ShowType.Messages);
		}
		
		/// <summary>
		///		Carga los datos del usuario
		/// </summary>
		private void LoadUser(TwitterAccount objAccount, string strScreenName)
		{ if (objAccount != null && !objAccount.IsEmpty)
				{ TwitterMessageUser objUser = Program.TwitterBotManager.TwitterMessenger.GetUserTwitter(objAccount, strScreenName);

					// Muestra los datos del usuario
						if (objUser == null)
					      Bau.Controls.Forms.Helper.ShowMessage(this, "Error al conectar con Twitter");
					    else if (objUser != null)
					      { txtDescription.Text = objUser.User.ScreenName;
					        lblFollowers.Text = objUser.User.FollowersCount.ToString();
					        lblFollowing.Text = objUser.User.FriendsCount.ToString();
					        lblWeb.Text = objUser.User.Url;
					      }
					  // Cambia el título con el nombre de usuario
					    Text = "@" + strScreenName;
				}
		}
		
		/// <summary>
		///		Cuenta
		/// </summary>
		public TwitterAccount Account 
		{ get { return udtMessages.Account; }
			set { udtMessages.Account = value; }
		}

		/// <summary>
		///		Usuario del que se solicita la información
		/// </summary>
		public string ScreenName 
		{ get { return udtMessages.ScreenName; }
			set { udtMessages.ScreenName = value; }
		}

		private void udtMessages_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void lblWeb_Click(object sender, EventArgs e)
		{ if (!string.IsNullOrEmpty(lblWeb.Text))
				Libraries.LibHelper.Files.HelperFiles.OpenBrowser(lblWeb.Text);
		}
	}
}
