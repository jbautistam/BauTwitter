using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibRest.Proxies
{
	/// <summary>
	///		Datos del proxy
	/// </summary>
	public class ProxyData
	{
		public ProxyData(string strAddress, string strUser, string strPassword, bool blnMustBypassLocal)
		{ Address = strAddress;
			User = strUser;
			Password = strPassword;
			MustBypassLocal = blnMustBypassLocal;
		}

		/// <summary>
		///		Dirección del proxy
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		///		Usuario del proxy
		/// </summary>
		public string User { get; set; }

		/// <summary>
		///		Contraseña del proxy
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		///		Indica si el proxy debe saltarse las direcciones locales
		/// </summary>
		public bool MustBypassLocal { get; set; }

		/// <summary>
		///		Indica si el proxy está activo
		/// </summary>
		public bool Enabled
		{ get { return !Address.IsEmpty(); }
		}
	}
}
