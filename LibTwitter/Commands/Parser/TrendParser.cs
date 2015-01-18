using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Commands.Parser
{
	/// <summary>
	///		Intérprete de los mensajes de tipo <see cref="Trend"/>
	/// </summary>
	internal static class TrendParser
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
		///		Interpreta un documento XML con datos de tendencia
		/// </summary>
		internal static Trend Parse(MLFile objMLFile)
		{ Trend objTrend = null;
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals(cnstStrTagUser))
							objTrend = Parse(objMLNode);
				// Devuelve la tendencia
					return objTrend;
		}
		
		/// <summary>
		///		Interpreta un documento XML para obtener una colección de datos de tendencias
		/// </summary>
		internal static TrendsCollection ParseCollection(MLFile objMLFile)
		{ TrendsCollection objColTrends = new TrendsCollection();
			
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals(cnstStrTagUsers))
							foreach (MLNode objMLChild in objMLNode.Nodes)
								if (objMLChild.Name.Equals(cnstStrTagUser))
									objColTrends.Add(Parse(objMLChild));
				// Devuelve las tendencias
					return objColTrends;		
		}	
		
		/// <summary>
		///		Interpreta un nodo XML con un usuario
		/// </summary>
		private static Trend Parse(MLNode objMLNode)
		{ Trend objTrend = new Trend();
		
				// Obtiene los datos del usuario
					objTrend.Name = objMLNode.Nodes[cnstStrTagName].Value;
					objTrend.URL = objMLNode.Nodes[cnstStrTagUrl].Value;
				// Devuelve la tendencia
					return objTrend;
		}
	}
}
