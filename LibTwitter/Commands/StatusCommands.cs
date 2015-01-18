using System;
using System.Xml;

using Bau.Libraries.LibTwitter.Core;
using Bau.Libraries.LibTwitter.Network;

namespace Bau.Libraries.LibTwitter.Commands
{
	/// <summary>
	///		Comandos relacionados con el estado
	/// </summary>
	public class StatusCommands : BaseCommands
	{
		public StatusCommands(TwitterAccount objAccount) : base(objAccount) {}
		
		/// <summary>
		///		Carga los datos de un mensaje de estado concreto
		/// </summary>
		public Status Load(long lngID)
		{	// Añade los parámetros
				base.Parameters.Add("id", lngID);
			// Envía el comando
				return Parser.StatusParser.Parse(base.GetResponse("https://api.twitter.com/1.1/statuses/show.json", false));
		}
		
		/// <summary>
		///		Borra los datos de un mensaje de estado concreto
		/// </summary>
		public Status Delete(long lngID)
		{ return Parser.StatusParser.Parse(base.GetResponse("https://api.twitter.com/1.1/statuses/destroy/:" + lngID.ToString() + ".json", true));
		}

		/// <summary>
		///		Envía un cambio de estado
		/// </summary>
		public void Send(string strStatus, long? lngIDReplyTo = null,
										 double? dblLatitude = null, double? dblLongitude = null, double? dblPlaceID = null,
										 bool? blnDisplayCoordinates = null, bool? blnTrimUser = null, bool? blnIncludeEntities = false)
		{ // Añade los parámetros
				base.Parameters.Add("status", strStatus, LibRest.Messages.Parameters.ParameterData.UrlEncoderType.Rfc3986);
				base.Parameters.Add("in_reply_to_status_id", lngIDReplyTo);
				base.Parameters.Add("lat", dblLatitude);
				base.Parameters.Add("long", dblLongitude);
				base.Parameters.Add("place_id", dblPlaceID);
				base.Parameters.Add("display_coordinates", blnDisplayCoordinates);
				base.Parameters.Add("trim_user", blnTrimUser);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Envía el mensaje
				base.GetResponse("https://api.twitter.com/1.1/statuses/update.json", true);
		}

		
		/// <summary>
		///		Obtiene los estados del usuario actual
		/// </summary>
		public StatusesCollection GetPublicTimeLine()
		{ return GetPublicTimeLine(null, null, null, null, null, null, null);
		}
		
		/// <summary>
		///		Obtiene los estados del usuario actual
		/// </summary>
		public StatusesCollection GetPublicTimeLine(long? lngIDSince)
		{ return GetPublicTimeLine(lngIDSince, null, null, null, null, null, null);
		}
		
		/// <summary>
		///		Obtiene los estados del usuario actual
		/// </summary>
		public StatusesCollection GetPublicTimeLine(long? lngIDSince, long? lngIDMaximum, 
																							  int? intCount, int? intPage, bool? blnTrimUser, 
																								bool? blnWithRetweets, bool? blnWithEntities) 
		{	return Parser.StatusParser.ParseCollection(SendCommand("https://api.twitter.com/1.1/statuses/home_timeline.json",
																														 null, null, lngIDSince, lngIDMaximum, 
																														 intCount, intPage, blnTrimUser,
																														 blnWithRetweets, blnWithEntities, false));
		}
		
		/// <summary>
		///		Returns the 20 most recent statuses posted by the authenticating user. 
		///		It is also possible to request another user's timeline by using the screen_name 
		///		or user_id parameter. The other users timeline will only be visible if they are 
		///		not protected, or if the authenticating user's follow request was accepted by the protected user. 
		///		The timeline returned is the equivalent of the one seen when you view a user's profile 
		///		on twitter.com. 
		///		This method is can only return up to 3200 statuses. If include_rts is set only 3200 
		///		statuses, including retweets if they exist, can be returned.
		///		This method will not include retweets in the XML and JSON responses unless the include_rts 
		///		parameter is set. The RSS and Atom responses will always include retweets as statuses 
		///		prefixed with RT.
		/// </summary>
		public StatusesCollection GetUserTimeLine(long lngIDUser)
		{ return GetUserTimeLine(lngIDUser, null, null, null, null, null, null, null);
		}
		
		/// <summary>
		///		Obtiene los estados de un usuario
		/// </summary>
		public StatusesCollection GetUserTimeLine(string strScreeName)
		{ return GetUserTimeLine(null, strScreeName, null, null, null, null, null, null);
		}
		
		/// <summary>
		///		Obtiene los estados de un usuario
		/// </summary>
		public StatusesCollection GetUserTimeLine(long? lngIDUser,
																							string strScreenName, long? lngIDSince, long? lngIDMaximum, 
																							int? intCount, int? intPage, bool? blnTrimUser, 
																							bool? blnWithEntities) 
		{ return Parser.StatusParser.ParseCollection(SendCommand("https://api.twitter.com/1.1/statuses/user_timeline.json",
																														 lngIDUser, strScreenName, lngIDSince, lngIDMaximum, intCount, intPage, 
																														 blnTrimUser, null, blnWithEntities, false));
		}

		/// <summary>
		///		Obtiene el TimeLine de los amigos de un usuario
		/// </summary>
		public StatusesCollection GetFriendsTimeLine()
		{	return Parser.StatusParser.ParseCollection(SendCommand("https://api.twitter.com/1.1/statuses/home_timeline.json",
																														 null, Account.ScreenName, null, null, null, null, true,
																														 false, false, false));
		}

		/// <summary>
		///		Obtiene las menciones a un usuario
		/// </summary>
		/// <remarks>
		/// The timeline returned is the equivalent of the one seen when you view your mentions on twitter.com.
		/// This method is can only return up to 800 statuses. If include_rts is set only 800 statuses, including retweets if they exist, can be returned.
		/// This method will not include retweets in the XML and JSON responses unless the include_rts parameter is set. The RSS and Atom responses will always include retweets as statuses prefixed with RT.
		/// </remarks>
		public StatusesCollection GetUserMentions(long? lngIDSince, long? lngIDMaximum, int? intCount, 
																							int? intPage, bool? blnTrimUser, bool? blnWithRetweets,
																							bool? blnWithEntities) 
		{ return Parser.StatusParser.ParseCollection(SendCommand("https://api.twitter.com/1.1/statuses/mentions_timeline.json",
																														 null, null, lngIDSince, lngIDMaximum,
																														 intCount, intPage, blnTrimUser, blnWithRetweets, 
																														 blnWithEntities, false));
		}
		
		/// <summary>
		///		Obtiene los Retweets de los mensajes del usuario por otros usuarios
		/// </summary>
		public StatusesCollection GetRetweetsOfMe()
		{ return GetRetweetsOfMe(null, null, null, null, null, null);
		}
		
		/// <summary>
		///		Obtiene los Retweets de los mensajes del usuario por otros usuarios
		/// </summary>
		public StatusesCollection GetRetweetsOfMe(long? lngIDSince, long? lngIDMaximum, int? intCount, 
																							int? intPage, bool? blnTrimUser, bool? blnWithEntities) 
		{ return Parser.StatusParser.ParseCollection(SendCommand("https://api.twitter.com/1.1/statuses/retweets_of_me.json",
																														 null, null, lngIDSince, lngIDMaximum,
																														 intCount, intPage, blnTrimUser, null, 
																														 blnWithEntities, false));



		}

		/// <summary>
		///		Hace un retweet de un mensaje
		/// </summary>
		public void Retweet(int intID)
		{ base.GetResponse("https://api.twitter.com/1.1/statuses/retweet/:" + intID.ToString() + ".json", true);
		}

		/// <summary>
		///		Obtiene los parámetros a enviar a una solicitud de estado
		/// </summary>
		/// <param name="lngIDSince">Código a partir del que se devuelven resultados</param>
		/// <param name="lngIDMaximum">Código máximo del que se devuelve resultados</param>
		/// <param name="intCount">Número de registros a recuperar (hasta 200)</param>
		/// <param name="intPage">Página de resultados a recuperar</param>
		/// <param name="blnTrimUser">Si está a true sólo devuelve los códigos de usuario</param>
		/// <param name="blnWithEntities">Indica si se reciben entidades adicionales</param>
		private LibMarkupLanguage.MLFile SendCommand(string strURL, long? lngIDUser, string strScreenName,
																								 long? lngIDSince, long? lngIDMaximum, int? intCount,
																								 int? intPage, bool? blnTrimUser, 
																								 bool? blnWithRetweets, bool? blnWithEntities,
																								 bool blnPost)
		{ // Asigna los parámetros
				base.Parameters.Add("user_id", lngIDUser);
				if (!string.IsNullOrEmpty(strScreenName))
					base.Parameters.Add("screen_name", strScreenName);
				base.Parameters.Add("since_id", lngIDSince);
				base.Parameters.Add("max_id", lngIDMaximum);
				base.Parameters.Add("count", intCount);
				base.Parameters.Add("page", intPage);
				base.Parameters.Add("trim_user", blnTrimUser);
				base.Parameters.Add("include_rts", blnWithRetweets);
				base.Parameters.Add("include_entities", blnWithEntities);
			// Devuelve la colección
				return base.GetResponse(strURL, blnPost);
		}
	}
}