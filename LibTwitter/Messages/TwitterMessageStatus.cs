using System;

using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Messages
{
	/// <summary>
	///		Mensaje de estado
	/// </summary>
	public class TwitterMessageStatus : TwitterMessage
	{
		public TwitterMessageStatus(Status objStatus) : base(objStatus.ID, objStatus.CreatedAt)
		{ Status = objStatus;
		}
		
		/// <summary>
		///		Devuelve el HTML del mensaje
		/// </summary>
		internal override string ToHTML()
		{ string strHTML;
		
				// Añade los vínculos de responder y retweet
					strHTML = GetLinkResend(cnstStrReply, Status.User.ScreenName, Status.Text);
					strHTML += "&nbsp;" + GetLinkResend(cnstStrRetweet, Status.User.ScreenName, Status.Text);
				// Devuelve la cadena HTML
					return base.ToHTML(Status.User, Status.Text, strHTML);
		}

		/// <summary>
		///		Obtiene el vínculo de reenvío, retweet...
		/// </summary>
		private string GetLinkResend(string strType, string strUser, string strText)
		{ return base.GetLinkFunction(strType + "|@" + strUser + " " + strText.Replace('\'', '·').Replace('\"', '·'),
																	strType);
		}
		
		/// <summary>
		///		Estado del mensaje
		/// </summary>
		public Status Status { get; set; }
	}
}
