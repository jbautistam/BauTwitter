using System;
using System.Net;

namespace Bau.Libraries.LibTwitter.ShortURL
{
	/// <summary>
	///		Clase para convertir URL con TinyURL
	/// </summary>
	public static class TinyURL
	{
		/// <summary>
		///		Convierte una URL
		/// </summary>
		public static string Convert(string strURL)
		{ try
				{ WebRequest objWebRequest = WebRequest.Create("http://tinyurl.com/api-create.php?url=" + strURL);
					WebResponse objWebResponse = objWebRequest.GetResponse();
					string strTargetURL = null;
			
						// Solicita la URL corta
							using (System.IO.StreamReader stmReader = new System.IO.StreamReader(objWebResponse.GetResponseStream()))
								{ // Recoge el contenido del stream
										strTargetURL = stmReader.ReadToEnd();
									// Cierra el stream
										stmReader.Close();
								}
						// Devuelve la URL corta
							return strTargetURL;
				}
			catch
				{ return strURL;
				}
		}
	}
}
