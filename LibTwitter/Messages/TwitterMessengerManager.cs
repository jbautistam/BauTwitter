using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTwitter;
using Bau.Libraries.LibTwitter.ShortURL;
using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Messages
{
	/// <summary>
	///		Manager de Twitter
	/// </summary>
	public class TwitterMessengerManager
	{
		public TwitterMessengerManager(ManagerTwitter objBotManager)
		{ BotManager = objBotManager;
		}

		/// <summary>
		///		Obtiene una instancia de la librería de Twitter
		/// </summary>
		private ManagerTwitter GetInstance(TwitterAccount objAccount)
		{ ManagerTwitter objTwitter = new ManagerTwitter();

		    // Configura el objeto de envío de Twitter
		      objTwitter.OAuthConsumerKey = BotManager.OAuthConsumerKey;
		      objTwitter.OAuthConsumerSecret = BotManager.OAuthConsumerSecret;
		    // Añade la cuenta
		      objTwitter.Accounts.Add(GetAccount(objTwitter, objAccount));
		    // Devuelve la librería de Twitter inicializada
		      return objTwitter;
		}

		/// <summary>
		///		Obtiene una cuenta para Twitter
		/// </summary>
		private TwitterAccount GetAccount(ManagerTwitter objTwitter, TwitterAccount objAccount)
		{ TwitterAccount objAccountTwitter = new TwitterAccount(objTwitter);

		    // Asigna las propiedades
		      objAccountTwitter.ID = Guid.NewGuid().ToString();
		      objAccountTwitter.ScreenName = objAccount.ScreenName;
		      objAccountTwitter.OAuthToken = objAccount.OAuthToken;
		      objAccountTwitter.OAuthTokenSecret = objAccount.OAuthTokenSecret;
		    // Devuelve la cuenta
		      return objAccountTwitter;
		}

		/// <summary>
		///		Obtiene los datos de una cuenta en Twitter
		/// </summary>
		public TwitterMessageUser GetUserTwitter(TwitterAccount objAccount, string strScreenName)
		{ ManagerTwitter objInstance = GetInstance(objAccount);
			User objUser = objInstance.Accounts[0].UserCommand.GetExtendedInfo(strScreenName, false);

				if (objUser == null)
					return new TwitterMessageUser(new User { ID = 0, CreatedAt = DateTime.Now.ToString() });
				else
					return new TwitterMessageUser(objUser);
		}

		/// <summary>
		///		Añade un amigo a una cuenta
		/// </summary>
		public bool AddFriend(TwitterAccount objAccount, string strScreenName, bool blnFollow, out string strError)
		{ ManagerTwitter objInstance = GetInstance(objAccount);
			bool blnAdded = false;

				// Inicializa los valores de salida
					strError = "";
				// Añade el amigo
					objInstance.Accounts[0].UserCommand.AddFriend(strScreenName, blnFollow);
				// Comprueba los errores
					if (objInstance.Accounts[0].HasError)
						strError = objInstance.Accounts[0].LastError.Message;
					else
						blnAdded = true;
				// Devuelve el valor que indica si se ha añadido el contacto
					return blnAdded;
		}

		/// <summary>
		///		Elimina un amigo de una cuenta
		/// </summary>
		public bool RemoveFriend(TwitterAccount objAccount, string strScreenName, out string strError)
		{ ManagerTwitter objInstance = GetInstance(objAccount);
			bool blnRemoved = false;

				// Inicializa los valores de salida
					strError = "";
				// Añade el amigo
					objInstance.Accounts[0].UserCommand.RemoveFriend(strScreenName);
				// Obtiene el error
					if (objInstance.Accounts[0].HasError)
						strError = objInstance.Accounts[0].LastError.Message;
					else
						blnRemoved = true;
				// Devuelve el valor que indica si se ha eliminado
					return blnRemoved;
		}

		/// <summary>
		///		Obtiene el TimeLine de un usuario
		/// </summary>
		public TwitterMessagesCollection GetUserTimeLine(TwitterAccount objAccount, string strScreenName = null)
		{ ManagerTwitter objInstace = GetInstance(objAccount);
			TwitterMessagesCollection objColMessages = new TwitterMessagesCollection();

				// Añade el timeLine
					if (!strScreenName.IsEmpty())
						objColMessages.AddRange(objInstace.Accounts[0].StatusCommand.GetUserTimeLine(strScreenName));
					else
						objColMessages.AddRange(objInstace.Accounts[0].StatusCommand.GetUserTimeLine(objAccount.ScreenName));
				// Devuelve el timeLine
					return objColMessages;
		}

		/// <summary>
		///		Obtiene los amigos de un usuario
		/// </summary>
		public TwitterMessagesCollection GetFriends(TwitterAccount objAccount, string strScreenName = null)
		{ ManagerTwitter objInstance = GetInstance(objAccount);
			TwitterMessagesCollection objColMessages = new TwitterMessagesCollection();

				// Añade los usuarios
					if (strScreenName.IsEmpty())
						objColMessages.AddRange(objInstance.Accounts[0].UserCommand.GetFriends(objAccount.ScreenName, false));
					else
						objColMessages.AddRange(objInstance.Accounts[0].UserCommand.GetFriends(strScreenName, false));
				// Devuelve la colección
					return objColMessages;
		}

		/// <summary>
		///		Obtiene los seguidores de una cuenta
		/// </summary>
		public TwitterMessagesCollection GetFollowers(TwitterAccount objAccount, string strScreenName = null)
		{ ManagerTwitter objInstance = GetInstance(objAccount);
			TwitterMessagesCollection objColMessages = new TwitterMessagesCollection();

				// Añade los usuarios
					if (strScreenName.IsEmpty())
						objColMessages.AddRange(objInstance.Accounts[0].UserCommand.GetFollowers(objAccount.ScreenName, false));
					else
						objColMessages.AddRange(objInstance.Accounts[0].UserCommand.GetFollowers(strScreenName, false));
				// Devuelve la colección
					return objColMessages;
		}

		/// <summary>
		///		Obtiene el timeLine público
		/// </summary>
		public TwitterMessagesCollection GetPublicTimeLine(TwitterAccount objAccount)
		{ ManagerTwitter objInstance = GetInstance(objAccount);
			TwitterMessagesCollection objColMessages = new TwitterMessagesCollection();
				
				// Añade los mensajes
					objColMessages.AddRange(objInstance.Accounts[0].StatusCommand.GetPublicTimeLine());
				// Devuelve la colección
					return objColMessages;
		}

		/// <summary>
		///		Envía un mensaje
		/// </summary>
		public bool SendMessage(TwitterAccount objAccount, string strMessage, out string strError)
		{ ManagerTwitter objTwitter = GetInstance(objAccount);

				// Inicializa los datos de salida
					strError = "";
				// Envía el mensaje
					objTwitter.Accounts[0].StatusCommand.Send(NormalizeText(strMessage));
				// Obtiene el error
					if (objTwitter.Accounts[0].HasError)
						strError = objTwitter.Accounts[0].LastError.Message;
				// Devuelve el valor que indica si se ha enviado
					return strError.IsEmpty();
		}

		/// <summary>
		///		Codificar caracteres en unicod
		/// </summary>
		private string EncodeNonAsciiCharacters( string strValue ) 
		{ string sb = "";

        foreach( char c in strValue ) 
				{	if( c > 127 ) 
						{	string encodedValue = "\\u" + ((int) c).ToString( "x4" );

                sb += encodedValue;
            }
					else 
						sb += c;
        }
				sb = sb.Replace("\\", "\\\\");
        return sb;
    }

		/// <summary>
		///		Normaliza el texto del mensaje
		/// </summary>
		internal string NormalizeText(string strMessage)
		{ string strCharsWithAccent = "\"ÁÉÍÓÚáéíóúÑñ¿¡çÇ";
			string strCharsWithOutAccent = "'AEIOUaeiouNn  cC";
			string strValue = "";
			
				// Quita los acentos
					foreach (char chrChar in strMessage)
						{ int intIndex = strCharsWithAccent.IndexOf(chrChar);
						
								if (intIndex >= 0)
									strValue += strCharsWithOutAccent[intIndex];
								else
									strValue += chrChar;
						}
				// Sólo 140 caracteres
					if (strValue.Length > 140)
						strValue = strValue.Substring(0, 140);
				// Devuelve el mensaje sin acentos
					return strValue;
		}

		/// <summary>
		///		Manager de Twitter
		/// </summary>
		public ManagerTwitter BotManager { get; private set; }
	}
}