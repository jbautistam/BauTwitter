using System;
using System.Security.Cryptography;
using System.Text;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest.Encoders;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Parameters;

namespace Bau.Libraries.LibRest.Authentication.Oauth
{
	/// <summary>
	///		Rutinas de autentificación para sistemas oAuth
	/// </summary>
	public class oAuthAuthenticator : IAuthenticator
	{ // Constantes privadas
			private const string cnstStrVersion = "1.0";
			private const string cnstStrSignatureMethod = "HMAC-SHA1";

		public oAuthAuthenticator(string strConsumerKey = null, string strConsumerSecret = null, 
															string strAccessToken = null, string strAccessTokenSecret = null)
		{ ConsumerKey = strConsumerKey;
			ConsumerSecret = strConsumerSecret;
			AccessToken = strAccessToken;
			AccessTokenSecret = strAccessTokenSecret;
		}

		/// <summary>
		///		Procesa la autentificación
		/// </summary>
		public void Process(RequestMessage objRequest)
		{ string strNonce, strTimestamp, strSignature;

				// Inicializa los valores aleatorios
					strNonce = new Random().Next(int.MaxValue).ToString("X"); // 123400, 9999999
					strTimestamp = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
				// Genera la firma
					strSignature = GetSignature(GetDataToSign(objRequest.MethodDescription, objRequest.URL, objRequest.QueryParameters, strNonce, strTimestamp));
				// Añade la cabecera de autorización
					objRequest.Headers.Add("Authorization", GetAuthorizationData(strSignature, strNonce, strTimestamp)); 
		}

		/// <summary>
		///		Obtiene la firma a partir de los datos
		/// </summary>
		private string GetSignature(string strDataToSign)
		{ HMACSHA1 objSha1 = new HMACSHA1(Encoding.ASCII.GetBytes(string.Format("{0}&{1}", ConsumerSecret.UrlEncode(), AccessTokenSecret.UrlEncode())));
 
				// Devuelve la firma
					return Convert.ToBase64String(objSha1.ComputeHash(Encoding.ASCII.GetBytes(strDataToSign.ToString())));
		}

		/// <summary>
		///		Obtiene los datos a firmar
		/// </summary>
		private string GetDataToSign(string strMethodDescription, string strUrl, ParameterDataCollection objColQueryString, string strNonce, string strTimeStamp)
		{ ParameterDataCollection objColParameters = objColQueryString.Clone();
			string strDataToSign = "";

				// Añade los valores oAuth a los parámetros
					objColParameters.Add("oauth_version", cnstStrVersion);
					objColParameters.Add("oauth_consumer_key", ConsumerKey);
					objColParameters.Add("oauth_nonce", strNonce);
					objColParameters.Add("oauth_signature_method", cnstStrSignatureMethod);
					objColParameters.Add("oauth_timestamp", strTimeStamp);
					objColParameters.Add("oauth_token", AccessToken);
				// Ordena los parámetros
					objColParameters.SortByKey();
				// Añade los parámetros a la cadena
					foreach (ParameterData objParameter in objColParameters)
						strDataToSign = strDataToSign.AddWithSeparator(objParameter.Key + "=" + objParameter.ValueEncoded, "&", false);
				// Codifica los parámetros y lo añade a los datos a firmar
					strDataToSign = strMethodDescription + "&" + NormalizeUrl(strUrl).UrlEncode() + "&" + strDataToSign.UrlEncodeRFC3986();
				// Devuelve los datos a firmar
					return strDataToSign;
		}

		/// <summary>
		///		Obtiene los datos de autorización
		/// </summary>
		private string GetAuthorizationData(string strSignature, string strNonce, string strTimestamp)
		{ string strAuthorizationData = "OAuth ";

				// Añade los datos de autorización
					strAuthorizationData += GetAuthorizationParameter("oauth_nonce", strNonce) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_signature_method", cnstStrSignatureMethod) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_timestamp", strTimestamp) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_consumer_key", ConsumerKey) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_token", AccessToken) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_signature", strSignature) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_version", cnstStrVersion);
				// Devuelve la cadena
					return strAuthorizationData;
		}

		/// <summary>
		///		Devuelve un parámetro de la cadena de autorización formateado
		/// </summary>
		private string GetAuthorizationParameter(string strKey, string strValue)
		{ return string.Format("{0}=\"{1}\"", strKey, strValue.UrlEncode());
		}

		/// <summary>
		///		Normaliza una URL
		/// </summary>
		private string NormalizeUrl(string url)
		{ Uri objUri = new Uri(url);
			string strPort = string.Empty;
 
				// Obtiene el puerto si no es el predeterminado
					if (objUri.Scheme.EqualsIgnoreCase("http") && objUri.Port != 80 ||
							objUri.Scheme.EqualsIgnoreCase("https") && objUri.Port != 443 ||
							objUri.Scheme.EqualsIgnoreCase("ftp") && objUri.Port != 20)
						strPort = string.Format(":{0}", objUri.Port);
				// Devuelve la URL normalizada
					return string.Format("{0}://{1}{2}{3}", objUri.Scheme, objUri.Host, strPort, objUri.AbsolutePath);
		}

    /// <summary>
    ///		Obtiene los tokens de autorización a Twitter para que la aplicación pueda validar un usuario
    /// </summary>
    public bool GetAuthorizationTokens(string strUrlRequestToken, string strUrlCallBack, out string strOAuthToken, out string strOAuthTokenSecret)
    {	RequestMessage objRequest = new RequestMessage(RequestMessage.MethodType.Post, strUrlRequestToken);
			ResponseMessage objResponse;
			
				// Añade los parámetros
					objRequest.QueryParameters.Add("oaut_callback", strUrlCallBack);
				// Envía el mensaje al servidor
					objResponse = GetResponseOAuth(objRequest);
				// Si todo ha ido bien, el servidor oAuth nos responde con una cadena del tipo: oauth_token=xxx&oauth_token_secret=xxx&oauth_callback_confirmed=true
					ExtractTokensAccess(objResponse, out strOAuthToken, out strOAuthTokenSecret);
				// Devuelve la cadena
					return !strOAuthToken.IsEmpty() && !strOAuthTokenSecret.IsEmpty();
    }
    
		/// <summary>
		///		Obtiene el token de acceso a partir de un PIN
		/// </summary>
		public bool GetAccessToken(string strUrlRequestAccessToken, string strPin, out string strOAuthToken, out string strOAuthTokenSecret)
		{ RequestMessage objRequest = new RequestMessage(RequestMessage.MethodType.Post, strUrlRequestAccessToken);
			ResponseMessage objResponse;

				// Añade los parámetros
					objRequest.QueryParameters.Add("oauth_verifier", strPin);
				// Envía el mensaje al servidor
					objResponse = GetResponseOAuth(objRequest);
				// Obtiene los tokens de la respuesta
					ExtractTokensAccess(objResponse,  out strOAuthToken, out strOAuthTokenSecret);
				// Devuelve el valor que indica si todo ha ido correcto
					return !strOAuthToken.IsEmpty() && !strOAuthTokenSecret.IsEmpty();
		}

    /// <summary>
    ///		Envía una solicitud Web utilizando oAuth
    /// </summary>
    private ResponseMessage GetResponseOAuth(RequestMessage objRequest)
    { RestController objRestController = new RestController("BauRest", 20000, this);

				// Devuelve la respuesta del servidor
					return objRestController.Send(objRequest);
    }

		/// <summary>
		///		Extrae los tokens de acceso de una respuesta
		/// </summary>
		private void ExtractTokensAccess(ResponseMessage objResponse, out string strOAuthToken, out string strOAuthTokenSecret)
		{ // Inicializa los valores de salida
				strOAuthToken = null;
				strOAuthTokenSecret = null;
			// Obtiene los tokens de la respuesta
				if (!objResponse.IsError && !objResponse.Body.IsEmpty())
						{ string [] arrStrBody = objResponse.Body.Split('&');

								// Recorre el array buscando las cadenas
									if (arrStrBody != null && arrStrBody.Length > 0)
										foreach (string strBody in arrStrBody)
											{ string [] arrStrQuery = strBody.Split('=');

													if (arrStrQuery != null && arrStrQuery.Length == 2)
														{ if (arrStrQuery[0].EqualsIgnoreCase("oauth_token"))
																strOAuthToken = arrStrQuery[1];
															else if (arrStrQuery[0].EqualsIgnoreCase("oauth_token_secret"))
																strOAuthTokenSecret = arrStrQuery[1];
														}
											}
						}
		}

		/// <summary>
		///		Clave de aplicación
		/// </summary>
		public string ConsumerKey { get; set; }

		/// <summary>
		///		Clave secreta de aplicación
		/// </summary>
		public string ConsumerSecret { get; set; }

		/// <summary>
		///		Token de acceso
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		///		Token de acceso secreto
		/// </summary>
		public string AccessTokenSecret { get; set; }
	}
}

/*
public void UpdateStatus(string message)
{
	// Application tokens
	const string CONSUMER_KEY = "YOUR_CONSUMER_KEY";
	const string CONSUMER_SECRET = "YOUR_CONSUMER_SECRET";
	// Access tokens
	const string ACCESS_TOKEN = "YOUR_ACCESS_TOKEN";
	const string ACCESS_TOKEN_SECRET = "YOUR_ACCESS_TOKEN_SECRET";
	
	// Common parameters
	const string VERSION = "1.0";
	const string SIGNATURE_METHOD = "HMAC-SHA1";
 
	// Parameters specific to this request
	var nonce = new Random().Next(0x0000000, 0x7fffffff).ToString("X8");
	var timestamp = ((int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
 
	// Prepare the text to sign
	var dataToSign = new StringBuilder();
	dataToSign
		.Append("POST")
		.Append("&")
		.Append("http://api.twitter.com/1/statuses/update.xml".EncodeRFC3986())
		.Append("&");
 
	// Values to sign: oauth parameters AND request parameters
	var signatureParts = new Dictionary<string, string>
	{
		{"status", message.EncodeRFC3986()},
		{"oauth_version", VERSION},
		{"oauth_consumer_key", CONSUMER_KEY},
		{"oauth_nonce", nonce},
		{"oauth_signature_method", SIGNATURE_METHOD},
		{"oauth_timestamp", timestamp},
		{"oauth_token", ACCESS_TOKEN}
	};
 
	dataToSign.Append(
		signatureParts
			.OrderBy(x => x.Key)
			.Select(x => "{0}={1}".FormatWith(x.Key, x.Value))
			.Join("&")
			.EncodeRFC3986());
 
	// Calculate the signature key required to sign the request
	var signatureKey = "{0}&{1}".FormatWith(CONSUMER_SECRET.EncodeRFC3986(), ACCESS_TOKEN_SECRET.EncodeRFC3986());
	var sha1 = new HMACSHA1(Encoding.ASCII.GetBytes(signatureKey));
 
	var signatureBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(dataToSign.ToString()));
	var signature = Convert.ToBase64String(signatureBytes);
 
	// Create and setup the actual request
	var request = (HttpWebRequest) WebRequest.Create("http://api.twitter.com/1/statuses/update.xml");
	request.Method = "POST";
	request.ContentType = "application/x-www-form-urlencoded";
 
	// Set authorization header
	request.Headers.Add(
		"Authorization",
		new StringBuilder("OAuth ")
			.AppendFormat("{0}=\"{1}\"", "oauth_nonce".EncodeRFC3986(), nonce.EncodeRFC3986()).Append(",")
			.AppendFormat("{0}=\"{1}\"", "oauth_signature_method".EncodeRFC3986(), SIGNATURE_METHOD.EncodeRFC3986()).Append(",")
			.AppendFormat("{0}=\"{1}\"", "oauth_timestamp".EncodeRFC3986(), timestamp.EncodeRFC3986()).Append(",")
			.AppendFormat("{0}=\"{1}\"", "oauth_consumer_key".EncodeRFC3986(), CONSUMER_KEY.EncodeRFC3986()).Append(",")
			.AppendFormat("{0}=\"{1}\"", "oauth_token".EncodeRFC3986(), ACCESS_TOKEN.EncodeRFC3986()).Append(",")
			.AppendFormat("{0}=\"{1}\"", "oauth_signature".EncodeRFC3986(), signature.EncodeRFC3986()).Append(",")
			.AppendFormat("{0}=\"{1}\"", "oauth_version".EncodeRFC3986(), VERSION.EncodeRFC3986())
			.ToString());
 
	// Add request body with request parameters
	var requestBody = Encoding.ASCII.GetBytes("status={0}".FormatWith(message.EncodeRFC3986()));
	using (var stream = request.GetRequestStream())
		stream.Write(requestBody, 0, requestBody.Length);
 
	// ... and here we go!
	request.GetResponse();
 
	// We could analyze the response, but since we'll get an exception if 
        // something fails, we don't need to mess with response content
}
	
public static string Join<T>(this IEnumerable<T> items, string separator)
{
	return string.Join(separator, items.ToArray());
}
 
public static string FormatWith(this string format, params object[] args)
{
	return string.Format(format, args);
}
 
// From Twitterizer http://www.twitterizer.net/
public static string EncodeRFC3986(this string value)
{
	if (string.IsNullOrEmpty(value))
		return string.Empty;
 
	var encoded = Uri.EscapeDataString(value);
 
	return Regex
		.Replace(encoded, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper())
		.Replace("(", "%28")
		.Replace(")", "%29")
		.Replace("$", "%24")
		.Replace("!", "%21")
		.Replace("*", "%2A")
		.Replace("'", "%27")
		.Replace("%7E", "~");
}

*/