using System;

namespace Bau.Libraries.LibTwitter.Core
{
	/// <summary>
	///		Datos de un error de comunicaciones
	/// </summary>
	public class Error
	{
		public Error() : this(null) {}
		
		public Error(string strMessage)
		{ Message = strMessage;
		}
		
		/// <summary>
		///		Mensaje de error
		/// </summary>
		public string Message { get; set; }
	}
}
