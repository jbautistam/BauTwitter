using System;

using Bau.Libraries.LibTwitter.Core;
using Bau.Libraries.LibTwitter.Network;

namespace Bau.Libraries.LibTwitter.Commands
{
	/// <summary>
	///		Comandos relacionados con <see cref="Message"/>
	/// </summary>
	public class DirectMessageCommands : BaseCommands
	{
		public DirectMessageCommands(TwitterAccount objAccount) : base(objAccount) {}
		
		/// <summary>
		///		Recibe los 20 últimos mensajes enviados al usuario
		/// </summary>
		public DirectMessagesCollection Received()
		{ return Received(null, null, null, null, null);
		}
		
		/// <summary>
		///		Recibe los últimos mensajes enviados al usuario
		/// </summary>
		public DirectMessagesCollection Received(long? lngSinceID, long? lngMaxID, 
																						 int? intCount, int? intPage, bool? blnIncludeEntities)
		{ return Parser.DirectMessageParser.ParseCollection(SendCommand("http://api.twitter.com/1/direct_messages.xml",
																															lngSinceID, lngMaxID, intCount, 
																															intPage, blnIncludeEntities));
		}
		
		/// <summary>
		///		Recibe los últimos mensajes enviados por el usuario
		/// </summary>
		public DirectMessagesCollection Sent()
		{ return Sent(null, null, null, null, null);
		}
		
		/// <summary>
		///		Recibe los mensajes enviados por el usuario
		/// </summary>
		public DirectMessagesCollection Sent(long? lngSinceID, long? lngMaxID, 
																				 int? intCount, int? intPage, bool? blnIncludeEntities)
		{ return Parser.DirectMessageParser.ParseCollection(SendCommand("http://api.twitter.com/1/direct_messages/sent.xml",
																																		lngSinceID, lngMaxID, intCount, 
																																		intPage, blnIncludeEntities));
		}

		/// <summary>
		///		Envía un mensaje directo
		/// </summary>
		public DirectMessage Send(long lngUserID, string strMessage)
		{ return Send(lngUserID, null, strMessage);
		}
		
		/// <summary>
		///		Envía un mensaje
		/// </summary>
		public DirectMessage Send(string strScreeName, string strMessage)
		{ return Send(null, strScreeName, strMessage);
		}
		
		/// <summary>
		///		Envía un mensaje
		/// </summary>
		public DirectMessage Send(long? lngUserID, string strScreeName, string strMessage)
		{ // Añade los parámetros
				base.Parameters.Add("user_id", lngUserID);
				base.Parameters.Add("screen_name", strScreeName);
				base.Parameters.Add("text", strMessage);
			// Envía el mensaje
				return Parser.DirectMessageParser.Parse(base.GetResponse("http://api.twitter.com/1/direct_messages/new.xml", 
																																true));
		}
		
		/// <summary>
		///		Borra un mensaje directo
		/// </summary>
		public void Delete(long lngID)
		{ base.GetResponse("http://api.twitter.com/1/direct_messages/destroy/:" + lngID.ToString() + ".xml", true);
		}
		
		/// <summary>
		///		Envía un comando
		/// </summary>
		private LibMarkupLanguage.MLFile SendCommand(string strURL, long? lngSinceID, 
																								 long? lngMaxID, int? intCount, 
																								 int? intPage, bool? blnIncludeEntities)
		{ // Añade los parámetros a la colección
				base.Parameters.Add("since_id", lngSinceID);
				base.Parameters.Add("max_id", lngMaxID);
        base.Parameters.Add("count", intCount);
				base.Parameters.Add("page", intPage);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Envía el comando
				return base.GetResponse(strURL, false);
		}
	}
}