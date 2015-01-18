using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Controls.WebExplorer;
using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTwitter;
using Bau.Libraries.LibTwitter.Messages;

namespace Bau.Applications.TwitterMarketing.Forms.UC
{
	/// <summary>
	///		Control para mostrar los mensajes de Twitter
	/// </summary>
	public partial class ctlTwitterMessages : UserControl
	{ // Enumerados públicos
			public enum ShowType
				{ Messages,
					MyMessages,
					Followers,
					Following
				}
		// Delegados públicos
			public delegate void SendMessageHandler(object objSender, string strMessage);
		// Eventos públicos
			public event SendMessageHandler SendMessage;
		// Variables privadas
			private TwitterMessagesCollection objColMessages = new TwitterMessagesCollection();
			private ShowType intLastType = ShowType.Messages;
			private DateTime dtmLastDownload = DateTime.Now;
			
		public ctlTwitterMessages()
		{ // Inicializa los componentes
				InitializeComponent();
			// Inicializa el temporizador
				tmrDownload.Interval = 60000;
				tmrDownload.Enabled = true;
			// Inicializa el explorador
				wbExplorer.ScriptErrorsSuppressed = true;
				wbExplorer.JavaScriptFunctionCalled += new EventHandler<WebExplorerJavaScriptFunctionEventArgs>(wbExplorer_JavaScriptFunctionCalled);
		}

		/// <summary>
		///		Limpia los mensajes
		/// </summary>
		public void Clear()
		{ objColMessages.Clear();
		}
		
		/// <summary>
		///		Carga los datos
		/// </summary>
		public void LoadData(ShowType intType)
		{ // Oculta el botón de 'Mis mensajes' cuando estamos controlando otra cuenta
				cmdMyMessages.Visible = !HasUser;
			// Selecciona / deselecciona los checkbox
				cmdStatus.Checked = intType == ShowType.Messages;
				cmdMyMessages.Checked = intType == ShowType.MyMessages;
				cmdFollowers.Checked = intType == ShowType.Followers;
				cmdFollowing.Checked = intType == ShowType.Following;
			// Muestra los datos
				switch (intType)
					{ case ShowType.Messages:
								if (intLastType != ShowType.Messages)
									Clear();
								LoadTimeLine();
							break;
						case ShowType.MyMessages:
								if (intLastType != ShowType.MyMessages)
									Clear();
								LoadMyMessages();
							break;
						case ShowType.Followers:
								Clear();
								LoadFollowers();
							break;
						case ShowType.Following:
								Clear();
								LoadFollowing();
							break;
					}
			// Recarga el explorador
				LoadTwitterMesssages(intType);
			// Guarda el tipo mostrado
				intLastType = intType;
		}
		
		/// <summary>
		///		Carga el timeLine
		/// </summary>		
		private void LoadTimeLine()
		{	// Carga los estados
			  if (Account != null)
					if (HasUser)
						LoadStatus(Program.TwitterBotManager.TwitterMessenger.GetUserTimeLine(Account, ScreenName));
					else
						LoadStatus(Program.TwitterBotManager.TwitterMessenger.GetPublicTimeLine(Account));
			// Cambia la fecha de última descarga
			  dtmLastDownload = DateTime.Now;
		}
		
		/// <summary>
		///		Carga los mensajes que ha enviado este usuario
		/// </summary>
		private void LoadMyMessages()
		{ // Carga los estados
			  if (Account != null)
					if (HasUser)
						LoadStatus(Program.TwitterBotManager.TwitterMessenger.GetUserTimeLine(Account, ScreenName));
					else
						LoadStatus(Program.TwitterBotManager.TwitterMessenger.GetUserTimeLine(Account));
			// Cambia la fecha de última descarga
				dtmLastDownload = DateTime.Now;
		}
		
		/// <summary>
		///		Carga una colección de estados
		/// </summary>		
		private void LoadStatus(TwitterMessagesCollection objColStatus)
		{	foreach (TwitterMessage objMessage in objColStatus)
				if (objMessage is TwitterMessageStatus)
					objColMessages.Add(objMessage as TwitterMessageStatus);
		}
		
		/// <summary>
		///		Carga los seguidores
		/// </summary>
		private void LoadFollowers()
		{ if (Account != null)
				{ if (HasUser)
						LoadUsers(Program.TwitterBotManager.TwitterMessenger.GetFollowers(Account));
					else
						LoadUsers(Program.TwitterBotManager.TwitterMessenger.GetFollowers(Account, Account.ScreenName));
				}
		}
		
		/// <summary>
		///		Carga las personas a las que se sigue
		/// </summary>
		private void LoadFollowing()
		{ if (Account != null)
			  { if (HasUser)
			      LoadUsers(Program.TwitterBotManager.TwitterMessenger.GetFriends(Account));
			    else
			      LoadUsers(Program.TwitterBotManager.TwitterMessenger.GetFriends(Account, Account.ScreenName));
			  }
		}
		
		/// <summary>
		///		Carga una colección de mensajes con los usuarios
		/// </summary>
		private void LoadUsers(TwitterMessagesCollection objColUsers)
		{ objColMessages.AddRange(objColUsers);
		}
		
		/// <summary>
		///		Carga los mensajes de Twitter en el explorador
		/// </summary>
		private void LoadTwitterMesssages(ShowType intType)
		{ // En el caso de un timeLine borra los mensajes antiguos
				if (intType == ShowType.Messages)
					objColMessages.ClearOld(Classes.TwitterConfiguration.MessagesTwitterMaximum);
			// Carga el HTML
				wbExplorer.LoadHTML(objColMessages.ToHTML());	
			// Muestra el número de mensajes
				lblMesssages.Text = objColMessages.Count.ToString();
				switch (intType)
					{ case ShowType.Messages:
						case ShowType.MyMessages:
								lblMesssages.Text += " mensajes";
							break;
						case ShowType.Followers:
								lblMesssages.Text += " seguidores";
							break;
						case ShowType.Following:
								lblMesssages.Text += " siguiendo";
							break;
					}
		}
		
		/// <summary>
		///		Trata una llamada de una función JavaScript
		/// </summary>
		private void TreatJavaScript(string strArgument)
		{ string [] arrStrArguments = strArgument.Split('|');
		
				if (arrStrArguments.Length > 1)
					{ string strError = null;

							// Realiza la función
								switch (arrStrArguments[0])
									{ case TwitterMessage.cnstStrSee:
												OpenFormTwitterUser(arrStrArguments[1]);
											break;
										case TwitterMessage.cnstStrFollow:
												Program.TwitterBotManager.TwitterMessenger.AddFriend(Account, arrStrArguments[1], true, out strError);
											break;
										case TwitterMessage.cnstStrUnfollow:
												Program.TwitterBotManager.TwitterMessenger.RemoveFriend(Account, arrStrArguments[1], out strError);
											break;
										case TwitterMessage.cnstStrReply:
												RaiseEventSendMessage("RP " + arrStrArguments[1]);
											break;
										case TwitterMessage.cnstStrRetweet:
												RaiseEventSendMessage("RT " + arrStrArguments[1]);
											break;
										case TwitterMessage.cnstStrLink:
												if (arrStrArguments[1].StartsWith("@"))
													OpenFormTwitterUser(arrStrArguments[1]);
												else if (arrStrArguments[1].StartsWith("#"))
													Bau.Controls.Forms.Helper.ShowMessage(ParentForm, "Aún no se pueden ver los mensajes de una lista");
												else if (arrStrArguments[1].StartsWith("http://"))
													Libraries.LibHelper.Files.HelperFiles.OpenBrowser(arrStrArguments[1]);
											break;
									}
							// Añade el error
								if (!strError.IsEmpty())
								  objColMessages.Add(new TwitterMessageError(strError));
					}
		}
	
		/// <summary>
		///		Abre el formulario para ver los datos de un usuario de Twitter
		/// </summary>
		private void OpenFormTwitterUser(string strScreenName)
		{ Forms.frmTwitterUser frmNewUser = new Forms.frmTwitterUser();
		
				// Asigna los datos
					frmNewUser.Account = Account;
					frmNewUser.ScreenName = strScreenName;
				// Muestra el formulario (no modal)
					frmNewUser.Show();
		}
		
		/// <summary>
		///		Descarga el TimeLine si ha pasado el tiempo necesario
		/// </summary>
		private void DownloadStatus()
		{ if (intLastType == ShowType.Messages && Classes.TwitterConfiguration.MinutesBetweenDownloadStatus > 0 &&
					(DateTime.Now - dtmLastDownload).Minutes >= Classes.TwitterConfiguration.MinutesBetweenDownloadStatus)
				{ // Inhabilita el temporizador
						tmrDownload.Enabled = false;
					// Descarga los datos
						LoadData(ShowType.Messages);
					// Actualiza la fecha de última descarga
						dtmLastDownload = DateTime.Now;
					// Habilita el temporizador
						tmrDownload.Enabled = true;
				}
		}

		/// <summary>
		///		Lanza el evento de envío de mensaje
		/// </summary>
		private void RaiseEventSendMessage(string strMessage)
		{ if (SendMessage != null)
				SendMessage(this, strMessage);
		}
		
		/// <summary>
		///		Cuenta de TwitterBot
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public TwitterAccount Account { get; set; }
		
		/// <summary>
		///		Cuenta de usuario de la que se están viendo los datos
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public string ScreenName { get; set; }

		/// <summary>
		///		Comprueba si tiene un usuario asignado
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		private bool HasUser
		{ get { return Account != null && !Account.ScreenName.IsEmpty() && !ScreenName.IsEmpty(); }
		}

		private void cmdStatus_Click(object sender, EventArgs e)
		{ LoadData(ShowType.Messages);
		}

		private void cmdMyMessages_Click(object sender, EventArgs e)
		{ LoadData(ShowType.MyMessages);
		}

		private void cmdFollowers_Click(object sender, EventArgs e)
		{ LoadData(ShowType.Followers);
		}

		private void cmdFollowing_Click(object sender, EventArgs e)
		{ LoadData(ShowType.Following);
		}

		private void wbExplorer_JavaScriptFunctionCalled(object sender, WebExplorerJavaScriptFunctionEventArgs e)
		{ TreatJavaScript(e.Argument);
		}

		private void tmrDownload_Tick(object sender, EventArgs e)
		{ DownloadStatus();
		}
	}
}
