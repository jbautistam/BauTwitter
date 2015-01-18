using System;
using System.Net;
using System.Xml;

using Bau.Libraries.LibMarkupLanguage;

using Bau.Libraries.LibRest;
using Bau.Libraries.LibRest.Authentication.Oauth;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Parameters;

namespace Bau.Libraries.LibTwitter.Network
{
	/// <summary>
	///		Conexión
	/// </summary>
	internal class Connection
	{ 		
		/// <summary>
		///		Obtiene la salida de una URL
		/// </summary>
		internal static MLFile GetResponse(TwitterAccount objAccount, string strURL, bool blnPost)
		{ return GetResponse(objAccount, strURL, null, blnPost);
		}

		/// <summary>
		///		Obtiene la salida de una URL
		/// </summary>
		internal static MLFile GetResponse(TwitterAccount objAccount, string strURL, ParameterDataCollection objColParameters, bool blnPost)
		{	try
				{	RestController objController = new RestController();
					oAuthAuthenticator objAuthenticator = new oAuthAuthenticator();
					RequestMessage objRequest = new RequestMessage(RequestMessage.MethodType.Get, strURL);
					ResponseMessage objResponse;

						// Asigna las propiedades al autentificador
							objAuthenticator.ConsumerKey = objAccount.Manager.OAuthConsumerKey;
							objAuthenticator.ConsumerSecret = objAccount.Manager.OAuthConsumerSecret;
							objAuthenticator.AccessToken = objAccount.OAuthToken;
							objAuthenticator.AccessTokenSecret = objAccount.OAuthTokenSecret;
						// Asigna el autentificador
							objController.Authenticator = objAuthenticator;
						// Asigna el método de envío
							if (blnPost)
								objRequest.Method = RequestMessage.MethodType.Post;
						// Asigna los parámetros
							if (objColParameters != null)
								foreach (ParameterData objParameter in objColParameters)
									objRequest.QueryParameters.Add(objParameter.Key, objParameter.Value);
						// Envía el mensaje
							objResponse = objController.Send(objRequest);
						// Devuelve el documento JSON
							if (objResponse.IsError)
								return GetError("Error en la recepción. Status: " + objResponse.ErrorDescription);
							else
								return new Bau.Libraries.LibMarkupLanguage.MLSerializer().ParseText(objResponse.Body);
					}
				catch (Exception objException)
					{ return GetError(objException); 
					}
		}
		
		/// <summary>
		///		Obtiene el error
		/// </summary>
		private static MLFile GetError(Exception objException)
		{ return GetError(objException.Message);
		}		

		/// <summary>
		///		Obtiene el error
		/// </summary>
		private static MLFile GetError(string strError)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLNode = objMLFile.Nodes.Add(Commands.Parser.ErrorParser.cnstStrTagRoot);
			
				// Añade el mensaje de error
					objMLNode.Nodes.Add(Commands.Parser.ErrorParser.cnstStrTagMessage, strError);
				// Devuelve el documento
					return objMLFile;
		}
	}
}
