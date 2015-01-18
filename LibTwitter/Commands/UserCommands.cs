using System;

using Bau.Libraries.LibTwitter.Core;
using Bau.Libraries.LibTwitter.Network;

namespace Bau.Libraries.LibTwitter.Commands
{
	/// <summary>
	///		Comandos de <see cref="User"/>
	/// </summary>
	public class UserCommands : BaseCommands
	{
		public UserCommands(TwitterAccount objAccount) : base(objAccount) {}
		
		/// <summary>
		///		Obtiene la información ampliada de un usuario
		/// </summary>
		public User GetExtendedInfo(long lngUserID, bool? blnIncludeEntities)
		{ return GetExtendedInfo(lngUserID, null, blnIncludeEntities);			
		}
		
		/// <summary>
		///		Obtiene la información ampliada de un usuario
		/// </summary>
		public User GetExtendedInfo(string strScreenName, bool? blnIncludeEntities)
		{ return GetExtendedInfo(null, strScreenName, blnIncludeEntities);
		}
		
		/// <summary>
		///		Obtiene la información ampliada de un usuario
		/// </summary>
		private User GetExtendedInfo(long? lngUserID, string strScreenName,
																 bool? blnIncludeEntities)
		{ return Parser.UserParser.Parse(SendCommand("https://api.twitter.com/1.1/users/show.json",
																								 lngUserID, strScreenName, blnIncludeEntities, false));
		}
		
		/// <summary>
		///		Consulta la información de un usuario
		/// </summary>
		public User LookUp(long lngUserID, bool? blnIncludeEntities)
		{ return LookUp(lngUserID, null, blnIncludeEntities);
		}
		
		/// <summary>
		///		Consulta la información de un usuario
		/// </summary>
		public User LookUp(string strScreenName, bool? blnIncludeEntities)
		{ return LookUp(null, strScreenName, blnIncludeEntities);
		}
		
		/// <summary>
		///		Consulta la información de un usuario
		/// </summary>
		public User LookUp(long? lngUserID, string strScreenName, bool? blnIncludeEntities)
		{ return Parser.UserParser.Parse(SendCommand("https://api.twitter.com/1.1/users/lookup.json",
																								 lngUserID, strScreenName, blnIncludeEntities, false));
		}
		
		/// <summary>
		///		Obtiene las personas a las que sigue un usuario (inicializa el cursor)
		/// </summary>
		public UsersCollection GetFriends(long lngUserID, bool? blnIncludeEntities)
		{ return GetFriends(lngUserID, null, "-1", blnIncludeEntities);
		}
		
		/// <summary>
		///		Obtiene las personas a las que sigue un usuario
		/// </summary>
		public UsersCollection GetFriends(long lngUserID, string strCursor, bool? blnIncludeEntities)
		{ return GetFriends(lngUserID, null, strCursor, blnIncludeEntities);
		}

		/// <summary>
		///		Obtiene las personas a las que sigue un usuario (inicializa el cursor)
		/// </summary>
		public UsersCollection GetFriends(string strScreenName, bool? blnIncludeEntities)
		{ return GetFriends(null, strScreenName, "-1", blnIncludeEntities);
		}
		
		/// <summary>
		///		Obtiene las personas a las que sigue un usuario
		/// </summary>
		public UsersCollection GetFriends(string strScreenName, string strCursor, bool? blnIncludeEntities)
		{ return GetFriends(null, strScreenName, strCursor, blnIncludeEntities);
		}		
		
		/// <summary>
		///		Obtiene las personas a las que sigue un usuario
		/// </summary>
		public UsersCollection GetFriends(long? lngUserID, string strScreenName, string strCursor, bool? blnIncludeEntities)
		{ // Añade los parámetros
				base.Parameters.Add("screen_name", strScreenName);
				base.Parameters.Add("cursor", strCursor);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Devuelve la colección
				return Parser.UserParser.ParseCollection(base.GetResponse("https://api.twitter.com/1.1/friends/list.json", false));
		}
		
		/// <summary>
		///		Descarga todos los usuarios a los que sigue un usuario
		/// </summary>
		public UsersCollection GetAllFriends(string strScreenName)
		{ UsersCollection objColFriends = GetFriends(strScreenName, false);
		
				// Obtiene los siguientes datos por el cursor
					while (!string.IsNullOrEmpty(objColFriends.NextCursor) && !objColFriends.NextCursor.Equals("0") &&
								 !base.Account.HasError)
						{ UsersCollection objColNext = GetFriends(strScreenName, objColFriends.NextCursor, false);
						
								// Añade los usuarios
									objColFriends.AddRange(objColNext);
								// Cambia el cursor
									objColFriends.NextCursor = objColNext.NextCursor;
									objColFriends.PreviousCursor = objColNext.PreviousCursor;
						}
				// Devuelve los amigos de esta cuenta
					return objColFriends;
		}

		/// <summary>
		///		Obtiene el siguiente lote de amigos
		/// </summary>
		public UsersCollection GetNextFriends(UsersCollection objColUsers, string strScreenName)
		{ // Carga el siguiente lote de seguidores
				for (int intIndex = 0; intIndex < 10 && !base.Account.HasError; intIndex++)
					if (objColUsers == null || objColUsers.Count == 0 || !objColUsers.HasEndLoad)
						{	UsersCollection objColNewFollowers;

								// Crea la colección si no existía
									if (objColUsers == null)
										objColUsers = new UsersCollection();
								// Carga los seguidores
									if (objColUsers.Count == 0)
										objColNewFollowers = GetFriends(null, strScreenName, "-1", false);
									else
										objColNewFollowers = GetFriends(null, strScreenName, objColUsers.NextCursor, false);
								// Si no ha habido ningún error, añade los nuevos seguidores, si no, guarda de nuevo el cursor anterior
									if (!base.Account.HasError)
										{ // Añade los usuarios
												objColUsers.AddRange(objColNewFollowers);
											// Asigna los cursores
												objColUsers.NextCursor = objColNewFollowers.NextCursor;
												objColUsers.PreviousCursor = objColNewFollowers.PreviousCursor;
										}
						}
			// Devuelve la colección de seguidores
				return objColUsers;
		}

		/// <summary>
		///		Obtiene los seguidores de un usuario (inicializa el cursor)
		/// </summary>
		public UsersCollection GetFollowers(long lngUserID, bool? blnIncludeEntities)
		{ return GetFollowers(lngUserID, null, "-1", blnIncludeEntities);
		}
		
		/// <summary>
		///		Obtiene los seguidores de un usuario
		/// </summary>
		public UsersCollection GetFollowers(long lngUserID, string strCursor, bool? blnIncludeEntities)
		{ return GetFollowers(lngUserID, null, strCursor, blnIncludeEntities);
		}

		/// <summary>
		///		Obtiene los seguidores de un usuario (inicializa el cursor)
		/// </summary>
		public UsersCollection GetFollowers(string strScreenName, bool? blnIncludeEntities)
		{ return GetFollowers(null, strScreenName, "-1", blnIncludeEntities);
		}
		
		/// <summary>
		///		Obtiene los seguidores de un usuario
		/// </summary>
		public UsersCollection GetFollowers(string strScreenName, string strCursor, bool? blnIncludeEntities)
		{ return GetFollowers(null, strScreenName, strCursor, blnIncludeEntities);
		}		
		
		/// <summary>
		///		Obtiene los seguidores de un usuario
		/// </summary>
		public UsersCollection GetFollowers(long? lngUserID, string strScreenName, string strCursor, bool? blnIncludeEntities)
		{ // Añade los parámetros
				base.Parameters.Add("screen_name", strScreenName);
				base.Parameters.Add("cursor", strCursor);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Devueve la colección
				return Parser.UserParser.ParseCollection(base.GetResponse("https://api.twitter.com/1.1/followers/list.json", false));
		}

		/// <summary>
		///		Obtiene el siguiente lote de seguidores
		/// </summary>
		public UsersCollection GetNextFollowers(UsersCollection objColUsers, string strScreenName)
		{ // Carga el siguiente lote de seguidores
				for (int intIndex = 0; intIndex < 10 && !base.Account.HasError; intIndex++)
					if (objColUsers == null || objColUsers.Count == 0 || !objColUsers.HasEndLoad)
						{	UsersCollection objColNewFollowers;

								// Crea la colección si no existía
									if (objColUsers == null)
										objColUsers = new UsersCollection();
								// Carga los seguidores
									if (objColUsers.Count == 0)
										objColNewFollowers = GetFollowers(null, strScreenName, "-1", false);
									else
										objColNewFollowers = GetFollowers(null, strScreenName, objColUsers.NextCursor, false);
								// Si no ha habido ningún error, añade los nuevos seguidores, si no, guarda de nuevo el cursor anterior
									if (!base.Account.HasError)
										{ // Añade los usuarios
												objColUsers.AddRange(objColNewFollowers);
											// Asigna los cursores
												objColUsers.NextCursor = objColNewFollowers.NextCursor;
												objColUsers.PreviousCursor = objColNewFollowers.PreviousCursor;
										}
						}
			// Devuelve la colección de seguidores
				return objColUsers;
		}

		/// <summary>
		///		Obtiene todos los seguidores de un usuario
		/// </summary>
		public UsersCollection GetAllFollowers(string strScreenName)
		{ UsersCollection objColUsers = GetFollowers(strScreenName, false);
		
				// Obtiene los siguientes datos por el cursor
					while (!objColUsers.HasEndLoad && !base.Account.HasError)
						{ UsersCollection objColNext = GetFollowers(strScreenName, objColUsers.NextCursor, false);
						
								// Añade los usuarios
									objColUsers.AddRange(objColNext);
								// Cambia el cursor
									objColUsers.NextCursor = objColNext.NextCursor;
									objColUsers.PreviousCursor = objColNext.PreviousCursor;
						}
				// Devuelve los seguidores de esta cuenta
					return objColUsers;
		}
		
		/// <summary>
		///		Añade un amigo a la lista
		/// </summary>
		public User AddFriend(string strScreenName, bool? blnFollow)
		{ return AddFriend(null, strScreenName, blnFollow, null);
		}

		/// <summary>
		///		Añade un amigo a la lista
		/// </summary>
		public User AddFriend(long? lngUserID, string strScreenName, bool? blnFollow, bool? blnIncludeEntities)
		{ // Añade los parámetros
				base.Parameters.Add("screen_name", strScreenName);
				base.Parameters.Add("follow", blnFollow);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Devuelve los datos
				return Parser.UserParser.Parse(base.GetResponse("https://api.twitter.com/1.1/friendships/create.json", true));
		}
		
		/// <summary>
		///		Elimina un amigo de la lista
		/// </summary>
		public User RemoveFriend(long lngUserID)
		{ return RemoveFriend(lngUserID, null, null);
		}
		
		/// <summary>
		///		Elimina un amigo de la lista
		/// </summary>
		public User RemoveFriend(string strScreenName)
		{ return RemoveFriend(null, strScreenName, null);
		}
		
		/// <summary>
		///		Elimina un amigo de la lista
		/// </summary>
		public User RemoveFriend(long? lngUserID, string strScreenName, bool? blnIncludeEntities)
		{ // Añade los parámetros
				base.Parameters.Add("screen_name", strScreenName);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Devuelve los datos
				return Parser.UserParser.Parse(base.GetResponse("https://api.twitter.com/1.1/friendships/destroy.json", true));
		}
		
		/// <summary>
		///		Envía un mensaje
		/// </summary>
		private LibMarkupLanguage.MLFile SendCommand(string strURL, long? lngUserID, string strScreenName, 
																								 bool? blnIncludeEntities, bool blnPost)
		{ // Añade los parámetros
				base.Parameters.Add("user_id", strScreenName);
				base.Parameters.Add("screen_name", strScreenName);
				base.Parameters.Add("include_entities", blnIncludeEntities);					
			// Envía el comando
				return base.GetResponse(strURL, blnPost);
		}
		
		/// <summary>
		///		Busca usuarios en Twitter
		/// </summary>
		public UsersCollection Search(string strSearch, int intPage)
		{ return Search(strSearch, null, intPage, null);
		}

		/// <summary>
		///		Busca usuarios en Twitter con una serie de parámetros
		/// </summary>
		public UsersCollection Search(string strQuery, long? intRecordsPerPage, int? intPage,
																	bool? blnIncludeEntities)
		{	// Añade los parámetros
				base.Parameters.Add("q", strQuery);
				base.Parameters.Add("per_page", intRecordsPerPage);
				base.Parameters.Add("page", intPage);
				base.Parameters.Add("include_entities", blnIncludeEntities);
			// Devuelve los datos
				return Parser.UserParser.ParseCollection(base.GetResponse("http://api.twitter.com/1/users/search.xml", 
																																	false));
		}
	}
}