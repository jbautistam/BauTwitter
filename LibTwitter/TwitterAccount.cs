using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTwitter.Commands;

namespace Bau.Libraries.LibTwitter
{
	/// <summary>
	///		Clase con los datos de una cuenta de Twitter
	/// </summary>
	public class TwitterAccount
	{ // Variables privadas
			private string strID;
			
		public TwitterAccount(ManagerTwitter objManager)
		{ // Asigna el manager
				Manager = objManager;
			// Inicializa los comandos
				MessageCommand = new DirectMessageCommands(this);
				StatusCommand = new StatusCommands(this);
				UserCommand = new UserCommands(this);
				TrendCommand = new TrendCommands(this);
		}
		
		/// <summary>
		///		ID de la cuenta
		/// </summary>
		public string ID
		{ get
				{ // Asigna el ID si no existía
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strID;
				}
			set { strID = value; }
		}
		
		/// <summary>
		///		Cuenta de usuario de Twitter
		/// </summary>
		public string ScreenName { get; set; }
		
		/// <summary>
		///		Idioma del usuario
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		///		Token de OAuth
		/// </summary>
		public string OAuthToken { get; set; }
		
		/// <summary>
		///		Token secreto de OAuth para el usuario
		/// </summary>
		public string OAuthTokenSecret { get; set; }
				
		/// <summary>
		///		Comprueba si la cuenta necesita autorización
		/// </summary>
		public bool NeedAuthorization
		{ get { return string.IsNullOrEmpty(OAuthToken) || string.IsNullOrEmpty(OAuthTokenSecret); }
		}

		/// <summary>
		///		Comandos de mensaje
		/// </summary>
		public DirectMessageCommands MessageCommand { get; private set; }
		
		/// <summary>
		///		Comandos de estado
		/// </summary>
		public StatusCommands StatusCommand { get; private set; }
		
		/// <summary>
		///		Comandos de usuario
		/// </summary>
		public UserCommands UserCommand { get; private set; }

		/// <summary>
		///		Comandos de tendencias
		/// </summary>
		public TrendCommands TrendCommand { get; private set; }		
		
		/// <summary>
		///		Manager de Twitter
		/// </summary>
		public ManagerTwitter Manager { get; set; }
		
		/// <summary>
		///		Ultimo error en el envío de datos
		/// </summary>
		public Core.Error LastError { get; internal set; }
		
		/// <summary>
		///		Comprueba si hay algún error en la cuenta
		/// </summary>
		public bool HasError
		{ get { return LastError != null && !string.IsNullOrEmpty(LastError.Message); }
		}

		/// <summary>
		///		Comprueba si la cuenta está vacía
		/// </summary>
		public bool IsEmpty
		{ get { return ScreenName.IsEmpty(); }
		}
	}
}