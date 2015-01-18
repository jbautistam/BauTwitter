using System;
using System.Collections.Generic;

using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Messages
{
	/// <summary>
	///		Colección de mensajes de Twitter
	/// </summary>
	public class TwitterMessagesCollection : List<TwitterMessage>
	{
		public TwitterMessagesCollection() {}

		/// <summary>
		///		Añade una serie de mensajes de estado
		/// </summary>
		public void AddRange(StatusesCollection objColStatus)
		{ foreach (Status objStatus in objColStatus)
				Add(objStatus);
		}

		/// <summary>
		///		Añade un mensaje
		/// </summary>
		public void Add(Status objStatus)
		{ Add(new TwitterMessageStatus(objStatus));
		}

		/// <summary>
		///		Añade una serie de mensajes de usuario
		/// </summary>
		public void AddRange(UsersCollection objColUsers)
		{ foreach (User objUser in objColUsers)
				Add(objUser);
		}

		/// <summary>
		///		Añade un mensaje
		/// </summary>
		public void Add(User objUser)
		{ Add(new TwitterMessageUser(objUser));
		}
		
		/// <summary>
		///		Añade un mensaje
		/// </summary>
		public void Add(Error objError)
		{ Add(new TwitterMessageError(objError));
		}
		
		/// <summary>
		///		Añade un mensaje
		/// </summary>
		public new void Add(TwitterMessage objMessage)
		{ if (!Exists(objMessage.ID))
				base.Add(objMessage);
		}
		
		/// <summary>
		///		Comprueba si existe un ID
		/// </summary>
		private bool Exists(long lngID)
		{ if (lngID == -1)
				return false;
			else
				{ // Recorre la colección
						foreach (TwitterMessage objMessage in this)
							if (objMessage.ID == lngID)
								return true;
					// Si ha llegado hasta aquí es porque no ha encontrado nada
						return false;
				}
		}
		
		/// <summary>
		///		Limpia los datos antiguos
		/// </summary>
		public void ClearOld(int intMaximum)
		{ while (Count > intMaximum)
				RemoveAt(0);
		}
		
		/// <summary>
		///		Devuelve el HTML de la colección
		/// </summary>
		public string ToHTML()
		{ string strHTML;
		
				// Ordena los mensajes
					Sort();
				// Asigna el valor que indica si la fila es par o impar
					for (int intIndex = 0; intIndex < Count; intIndex++)
						this[intIndex].IsRowEven = intIndex % 2 == 0;
				// Crea la cabecera del HTML
					strHTML = "<html><head><style type='text/css'>";
					strHTML += "body {background-color:white;font-size:8pt;}";
					strHTML += ".rowEven {background-color:white;}";
					strHTML += ".rowOdd {background-color:yellow;}";
					strHTML += ".dateLabel {text-align:right;font-size:0.8em;}";
					strHTML += "</style></head>";
				// Añade las filas
					strHTML += "<body><table width='100%' border='0' cellpading='0' cellspacing='0'";
					foreach (TwitterMessage objMessage in this)
						strHTML += objMessage.ToHTML();
				// Añade el cierre
					strHTML += "</table></body></html>";
				// Devuelve la cadena HTML
					return strHTML;
		}
	}
}