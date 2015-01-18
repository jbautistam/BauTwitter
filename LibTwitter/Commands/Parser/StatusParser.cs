using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Commands.Parser
{
	/// <summary>
	///		Interpreta los mensajes <see cref="StatusCommands"/>
	/// </summary>
	internal static class StatusParser
	{ // Constantes privadas
			private const string cnstStrTagRoot = "statuses";
			private const string cnstStrTagCreatedAt = "created_at";
			private const string cnstStrTagID = "id";
			private const string cnstStrTagText = "text";
			private const string cnstStrTagSource = "source";
			private const string cnstStrTagTruncated = "truncated";
			private const string cnstStrTagInReplyToStatusID = "in_reply_to_status_id";
			private const string cnstStrTagInReplyToUserID = "in_reply_to_user_id";
			private const string cnstStrTagFavorited = "favorited";
			private const string cnstStrTagInReplyToScreenName = "in_reply_to_screen_name";
		// Constantes internas
			internal const string cnstStrTagStatus = "status";
			
		/// <summary>
		///		Interpreta una serie de estados
		/// </summary>
		internal static StatusesCollection ParseCollection(MLFile objMLFile)
		{ StatusesCollection objColStatus = new StatusesCollection();
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals("Root"))
							foreach (MLNode objMLArray in objMLNode.Nodes)
								if (objMLArray.Name == "Array")
									foreach (MLNode objMLStatus in objMLArray.Nodes)
										if (objMLStatus.Name == "Struct")									
											{ Status objStatus = Parse(objMLStatus); 
								
													// Añade el estado a la colección
														if (!string.IsNullOrEmpty(objStatus.Text))
															objColStatus.Add(objStatus);
											}
				// Devuelve la colección
					return objColStatus;
		}
			
		/// <summary>
		///		Interpreta un estado
		/// </summary>
		internal static Status Parse(MLFile objMLFile)
		{ Status objStatus = new Status();
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals(cnstStrTagStatus))
							objStatus = Parse(objMLNode);
				// Devuelve el estado
					return objStatus;
		}
		
		/// <summary>
		///		Interpreta un nodo con un estado
		/// </summary>
		internal static Status Parse(MLNode objMLStatus)
		{ Status objStatus = new Status();
								
				// Asigna las propiedades
					objStatus.CreatedAt = objMLStatus.Attributes[cnstStrTagCreatedAt].Value;
					objStatus.ID = objMLStatus.Attributes[cnstStrTagID].GetValue((long) 0);
					objStatus.Text = objMLStatus.Attributes[cnstStrTagText].Value;
					objStatus.Source = objMLStatus.Attributes[cnstStrTagSource].Value;
					objStatus.Truncated = objMLStatus.Attributes[cnstStrTagTruncated].GetValue(false);
					objStatus.InReplyToStatusID = objMLStatus.Attributes[cnstStrTagInReplyToStatusID].GetValue(0);
					objStatus.InReplyToUserID = objMLStatus.Attributes[cnstStrTagInReplyToUserID].GetValue(0);
					objStatus.Favorited = objMLStatus.Attributes[cnstStrTagFavorited].GetValue(false);
					objStatus.InReplyToUserID = objMLStatus.Attributes[cnstStrTagInReplyToScreenName].GetValue(0);
				// Carga los datos del usuario
					if (!string.IsNullOrEmpty(objMLStatus.Nodes[UserParser.cnstStrTagUser].Name))
						objStatus.User = UserParser.Parse(objMLStatus.Nodes[UserParser.cnstStrTagUser]);
				// Devuelve el estado
					return objStatus;
		}
/*
	<Root_0 created_at = "Tue Sep 03 14:53:28 +0000 2013"  id = "374908002966327297"  id_str = "374908002966327297"  text = "SE VIENE EL FRIO\nLa Justicia pide conocer informes sobre resultado de la Campa\u00f1a Ant\u00e1rtica   http:\/\/t.co\/nv8yxzZpr0 v\u00eda @Infobae"  source = "\u003ca href=\&quot;http:\/\/twitter.com\/tweetbutton\&quot; rel=\&quot;nofollow\&quot;\u003eTweet Button\u003c\/a\u003e"  truncated = "false"  in_reply_to_status_id = "null"  in_reply_to_status_id_str = "null"  in_reply_to_user_id = "null"  in_reply_to_user_id_str = "null"  in_reply_to_screen_name = "null"  geo = "null"  coordinates = "null"  place = "null"  contributors = "null"  retweet_count = "0"  favorite_count = "0"  favorited = "false"  retweeted = "false"  possibly_sensitive = "false"  lang = "es" >
		<user id = "551573256"  id_str = "551573256"  name = "pilar"  screen_name = "ilustremos"  location = "argentina"  description = "luchadora de las causas justas. cr\u00edtica por naturaleza. leal"  url = "null"  protected = "false"  followers_count = "57825"  friends_count = "42536"  listed_count = "89"  created_at = "Thu Apr 12 02:07:30 +0000 2012"  favourites_count = "5"  utc_offset = "-10800"  time_zone = "Brasilia"  geo_enabled = "false"  verified = "false"  statuses_count = "8899"  lang = "es"  contributors_enabled = "false"  is_translator = "false"  profile_background_color = "C0DEED"  profile_background_image_url = "http:\/\/a0.twimg.com\/images\/themes\/theme1\/bg.png"  profile_background_image_url_https = "https:\/\/si0.twimg.com\/images\/themes\/theme1\/bg.png"  profile_background_tile = "false"  profile_image_url = "http:\/\/a0.twimg.com\/profile_images\/3284382559\/1e2348537856c3df0a896b628cd1e3d8_normal.jpeg"  profile_image_url_https = "https:\/\/si0.twimg.com\/profile_images\/3284382559\/1e2348537856c3df0a896b628cd1e3d8_normal.jpeg"  profile_link_color = "0084B4"  profile_sidebar_border_color = "C0DEED"  profile_sidebar_fill_color = "DDEEF6"  profile_text_color = "333333"  profile_use_background_image = "true"  default_profile = "true"  default_profile_image = "false"  following = "true"  follow_request_sent = "null"  notifications = "null" >
			<entities>
				<description>
					<urls/>
</description>
</entities>
</user>
		<entities>
			<hashtags/>
			<symbols/>
			<urls>
				<urls_0 url = "http:\/\/t.co\/nv8yxzZpr0"  expanded_url = "http:\/\/www.infobae.com\/2013\/09\/03\/1506159-la-justicia-pide-conocer-informes-resultado-la-campana-antartica"  display_url = "infobae.com\/2013\/09\/03\/150\u2026" >
					<indices>
						<indices_0>
							<![CDATA[93]]>
						</indices_0>
						<indices_1>
							<![CDATA[115]]>
						</indices_1>
</indices>
</urls_0>
</urls>
			<user_mentions>
				<user_mentions_0 screen_name = "infobae"  name = "infobae"  id = "69416519"  id_str = "69416519" >
					<indices>
						<indices_0>
							<![CDATA[120]]>
						</indices_0>
						<indices_1>
							<![CDATA[128]]>
						</indices_1>
</indices>
</user_mentions_0>
</user_mentions>
</entities>
</Root_0>
*/
	}
}
