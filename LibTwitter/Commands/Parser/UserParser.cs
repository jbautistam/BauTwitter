using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Commands.Parser
{
	/// <summary>
	///		Intérprete de los mensajes de tipo <see cref="User"/>
	/// </summary>
	internal static class UserParser
	{ // Constantes internas
			internal const string cnstStrTagUser = "user";
		// Constantes privadas
			private const string cnstStrTagUsers = "users";
			private const string cnststrTagUsersList = "users_list";
			private const string cnstStrTagID = "id";
			private const string cnstStrTagName = "name";
			private const string cnstStrTagScreenName = "screen_name";
			private const string cnstStrTagLocation = "location";
			private const string cnstStrTagDescription = "description";
			private const string cnstStrTagProfileImageUrl = "profile_image_url";
			private const string cnstStrTagUrl = "url";
			private const string cnstStrTagProtected = "protected";
			private const string cnstStrTagFollowersCount = "followers_count";
			private const string cnstStrTagProfileBackgroundColor = "profile_background_color";
			private const string cnstStrTagProfileTextColor = "profile_text_color";
			private const string cnstStrTagProfileLinkColor = "profile_link_color";
			private const string cnstStrTagProfileSidebarFillColor = "profile_sidebar_fill_color";
			private const string cnstStrTagProfileSidebarBorderColor = "profile_sidebar_border_color";
			private const string cnstStrTagFriendsCount = "friends_count";
			private const string cnstStrTagCreatedAt = "created_at";
			private const string cnstStrTagFavoritesCount = "favourites_count";
			private const string cnstStrTagUtcOfsset = "utc_offset";
			private const string cnstStrTagTimeZone = "time_zone";
			private const string cnstStrTagProfileBackgroundImageUrl = "profile_background_image_url";
			private const string cnstStrTagProfileBackgroundTitle = "profile_background_tile";
			private const string cnstStrTagNotifications = "notifications";
			private const string cnstStrTagGeoEnabled = "geo_enabled";
			private const string cnstStrTagVerified = "verified";
			private const string cnstStrTagFolloging = "following";
			private const string cnstStrTagStatusesCount = "statuses_count";
			private const string cnstStrTagLang = "lang";
			private const string cnstStrTagContributorsEnabled = "contributors_enabled";
			private const string cnstStrTag = "status";
			private const string cnstStrTagNextCursor = "next_cursor";
			private const string cnstStrTagPreviousCursor = "previous_cursor";			

		/// <summary>
		///		Interpreta un documento XML con datos de usuario
		/// </summary>
		internal static User Parse(MLFile objMLFile)
		{ User objUser = null;
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals("Root"))
							objUser = Parse(objMLNode);
				// Devuelve el usuario
					return objUser;
		}
		
		/// <summary>
		///		Interpreta un documento XML para obtener una colección de datos de usuario
		/// </summary>
		internal static UsersCollection ParseCollection(MLFile objMLFile)
		{ UsersCollection objColUsers = new UsersCollection();
			
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals("Root"))
							{ objColUsers.NextCursor = objMLNode.Attributes[cnstStrTagNextCursor].Value;
								objColUsers.PreviousCursor = objMLNode.Attributes[cnstStrTagPreviousCursor].Value;
								foreach (MLNode objMLChild in objMLNode.Nodes)
									if (objMLChild.Name.Equals(cnststrTagUsersList))
										{ foreach (MLNode objMLUser in objMLChild.Nodes)
												if (objMLUser.Name.Equals(cnstStrTagUsers))
													ParseUsers(objMLUser.Nodes, objColUsers);
										}
									else if (objMLChild.Name.Equals(cnstStrTagUsers))
										foreach (MLNode objMLStruct in objMLChild.Nodes)
											if (objMLStruct.Name == "Struct")
												objColUsers.Add(Parse(objMLStruct));
							}
				// Devuelve los usuarios
					return objColUsers;		
		}	
		
		/// <summary>
		///		Interpreta los usuarios de un nodo
		/// </summary>
		private static void ParseUsers(MLNodesCollection objMLColNodes, UsersCollection objColUsers)
		{ foreach (MLNode objMLChild in objMLColNodes)
				if (objMLChild.Name.Equals(cnstStrTagUser))
					objColUsers.Add(Parse(objMLChild));
				else if (objMLChild.Name.Equals(cnstStrTagNextCursor))
					objColUsers.NextCursor = objMLChild.Value;
				else if (objMLChild.Name.Equals(cnstStrTagPreviousCursor))
					objColUsers.PreviousCursor = objMLChild.Value;
		}
		
		/// <summary>
		///		Interpreta un nodo XML con un usuario
		/// </summary>
		internal static User Parse(MLNode objMLUser)
		{ User objUser = new User();
		
				// Obtiene los datos del usuario
					objUser.ID = objMLUser.Attributes[cnstStrTagID].GetValue(0);
					objUser.Name = objMLUser.Attributes[cnstStrTagName].Value;
					objUser.ScreenName = objMLUser.Attributes[cnstStrTagScreenName].Value;
					objUser.Location = objMLUser.Attributes[cnstStrTagLocation].Value;
					objUser.Description = objMLUser.Attributes[cnstStrTagDescription].Value;
					objUser.ProfileImage = objMLUser.Attributes[cnstStrTagProfileImageUrl].Value;
					objUser.Url = objMLUser.Attributes[cnstStrTagUrl].Value;
					objUser.IsProtected = objMLUser.Attributes[cnstStrTagProtected].GetValue(false);
					objUser.FollowersCount = objMLUser.Attributes[cnstStrTagFollowersCount].GetValue(0);
					objUser.ProfileBackgroundColor = objMLUser.Attributes[cnstStrTagProfileBackgroundColor].Value;
					objUser.ProfileTextColor = objMLUser.Attributes[cnstStrTagProfileTextColor].Value;
					objUser.ProfileLinkColor = objMLUser.Attributes[cnstStrTagProfileLinkColor].Value;
					objUser.ProfileSidebarFillColor = objMLUser.Attributes[cnstStrTagProfileSidebarFillColor].Value;
					objUser.ProfileSidebarBordeColor = objMLUser.Attributes[cnstStrTagProfileSidebarBorderColor].Value;
					objUser.FriendsCount = objMLUser.Attributes[cnstStrTagFriendsCount].GetValue(0);
					objUser.CreatedAt = objMLUser.Attributes[cnstStrTagCreatedAt].Value;
					objUser.FavoritesCount = objMLUser.Attributes[cnstStrTagFavoritesCount].GetValue(0);
					objUser.UtcOffset = objMLUser.Attributes[cnstStrTagUtcOfsset].GetValue(0);
					objUser.TimeZone = objMLUser.Attributes[cnstStrTagTimeZone].Value;
					objUser.ProfileBackgroundImageUrl = objMLUser.Attributes[cnstStrTagProfileBackgroundImageUrl].Value;
					objUser.ProfileBackgroundTitle = objMLUser.Attributes[cnstStrTagProfileBackgroundTitle].Value;
					objUser.Notifications = objMLUser.Attributes[cnstStrTagNotifications].Value;
					objUser.GeoEnabled = objMLUser.Attributes[cnstStrTagGeoEnabled].GetValue(false);
					objUser.Verified = objMLUser.Attributes[cnstStrTagVerified].GetValue(false);
					objUser.Following = objMLUser.Attributes[cnstStrTagFolloging].GetValue(false);
					objUser.StatusCount = objMLUser.Attributes[cnstStrTagStatusesCount].GetValue(0);
					objUser.Language = objMLUser.Attributes[cnstStrTagLang].Value;
					objUser.ContributorsEnabled = objMLUser.Attributes[cnstStrTagContributorsEnabled].GetValue(false);
				// Obtiene el estado
					if (!string.IsNullOrEmpty(objMLUser.Nodes[StatusParser.cnstStrTagStatus].Name))
						objUser.Status = StatusParser.Parse(objMLUser.Nodes[StatusParser.cnstStrTagStatus]);
				// Devuelve el usuario
					return objUser;
		}
	}
}
