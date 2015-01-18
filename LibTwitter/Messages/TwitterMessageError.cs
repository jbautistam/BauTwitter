using System;

using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Messages
{
	/// <summary>
	///		Mensaje de error de Twitter
	/// </summary>
	public class TwitterMessageError : TwitterMessage
	{
		public TwitterMessageError(string strMessage) : this(new Error { Message = strMessage }) {}

		public TwitterMessageError(Error objError) : base(-1, DateTime.Now)
		{ Error = objError;
		}
		
		/// <summary>
		///		Devuelve el HTML del mensaje
		/// </summary>
		internal override string ToHTML()
		{ return "<tr><td>" + Error.Message + "</td><tr>";
		}

		/// <summary>
		///		Mensaje de error
		/// </summary>
		public Error Error { get; set; }
	}
}
