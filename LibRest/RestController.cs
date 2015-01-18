using System;

namespace Bau.Libraries.LibRest
{
	/// <summary>
	///		Controlador para las comunicaciones REST
	/// </summary>
	public class RestController
	{
		public RestController(string strUserAgent = "BauRest", int intTimeOut = 20000, Authentication.IAuthenticator objAuthenticator = null)
		{ // Asigna las propiedades
				UserAgent = strUserAgent;
				TimeOut = intTimeOut;
				Authenticator = objAuthenticator;
			// Inicializa los objetos
				Proxy = new Proxies.ProxyData(null, null, null, true);
		}

		/// <summary>
		///		Envía un mensaje
		/// </summary>
		public Messages.ResponseMessage Send(Messages.RequestMessage objRequest)
		{ return new Http.HttpSender().Send(this, objRequest);
		}

		/// <summary>
		///		Agente
		/// </summary>
		public string UserAgent { get; set; }

		/// <summary>
		///		Tiempo de espera
		/// </summary>
		public int TimeOut { get; set; }

		/// <summary>
		///		Clase utilizada para autentificación
		/// </summary>
		public Authentication.IAuthenticator Authenticator { get; set; }

		/// <summary>
		///		Proxy que se utiliza en las comunicaciones
		/// </summary>
		public Proxies.ProxyData Proxy { get; set; }

		/// <summary>
		///		Nombre de archivo del certificado
		/// </summary>
		public string CertificateFileName { get; set; }
	}
}
