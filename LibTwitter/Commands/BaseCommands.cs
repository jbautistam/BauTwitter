using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibTwitter.Network;
using Bau.Libraries.LibRest.Messages.Parameters;

namespace Bau.Libraries.LibTwitter.Commands
{
	/// <summary>
	///		Clase base para los comandos de Twitter
	/// </summary>
	public class BaseCommands
	{
		public BaseCommands(TwitterAccount objAccount)
		{ Account = objAccount;
			Parameters = new ParameterDataCollection();
		}

		/// <summary>
		///		Obtiene la salida de una URL
		/// </summary>
		internal MLFile GetResponse(string strURL, bool blnPost)
		{ MLFile objMLFile = Connection.GetResponse(Account, strURL, Parameters, blnPost);
		
				// Vacía la colección de parámetros
					Parameters.Clear();
				// Interpreta el error
					Account.LastError = Parser.ErrorParser.Parse(objMLFile);
				// Devuelve el documento
					return objMLFile;
		}
		
		/// <summary>
		///		Cuenta de Twitter
		/// </summary>
		public TwitterAccount Account { get; private set; }
		
		/// <summary>
		///		Parámetros para el envío de mensajes
		/// </summary>
		internal ParameterDataCollection Parameters { get; private set; }
	}
}
