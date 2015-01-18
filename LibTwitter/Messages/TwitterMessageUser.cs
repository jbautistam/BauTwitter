using System;

using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Messages
{
	/// <summary>
	///		Mensaje de estado
	/// </summary>
	public class TwitterMessageUser : TwitterMessage
	{
		public TwitterMessageUser(User objUser) : base(objUser.ID, objUser.CreatedAt)
		{ User = objUser;
		}
		
		/// <summary>
		///		Devuelve el HTML del mensaje
		/// </summary>
		internal override string ToHTML()
		{ string strHTML;
		
				// Añade la celda con los seguidores
					strHTML = "Seguidores: " + User.FollowersCount.ToString();
					strHTML += " Siguiendo: " + User.FriendsCount.ToString();
				// Devuelve el mensaje
					return base.ToHTML(User, User.Description, strHTML);
		}

		/// <summary>
		///		Usuario del mensaje
		/// </summary>
		public User User { get; set; }
	}
}
