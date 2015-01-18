using System;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Windows.Forms;

using Bau.Libraries.LibRest.Authentication.Oauth;

namespace Bau.Applications.TwitterMarketing.Forms
{
	/// <summary>
	///		Formulario para localizar los tokens de acceso a Twitter para la aplicación
	/// </summary>
	public partial class frmSignTwitter: Form
	{ // Constantes privadas
			private const string cnstStrUrlRequestToken = "https://api.twitter.com/oauth/request_token";
      private const string cnstStrURLAuthorize = "https://api.twitter.com/oauth/authorize";
      private const string cnstStrURLAccess = "https://api.twitter.com/oauth/access_token";
		// Variables privadas
			private oAuthAuthenticator objOAuthValidator = null;

		public frmSignTwitter()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ string strOAuthToken, strOAuthTokenSecret;

				// Inicializa el validador
					objOAuthValidator = new oAuthAuthenticator(Program.TwitterBotManager.OAuthConsumerKey, Program.TwitterBotManager.OAuthConsumerSecret);
				// Obtiene el token de validación
					if (objOAuthValidator.GetAuthorizationTokens(cnstStrUrlRequestToken, "oob", out strOAuthToken, out strOAuthTokenSecret))
						{ // Guarda los token
								OAuthToken = strOAuthToken;
								OAuthSecretToken = strOAuthTokenSecret;
							// Muestra el texto en el explorador
								wbExplorer.DocumentText = GetHTML(new Uri(cnstStrURLAuthorize + "?oauth_token=" + strOAuthToken));
						}
					else
						Bau.Controls.Forms.Helper.ShowMessage(this, "Error al intentar conectar con el servidor remoto");
		}
		
		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;
		
				// Comprueba los datos
					if (string.IsNullOrEmpty(txtPinCode.Text))
						MessageBox.Show("Introduzca el código de autentificación de Twitter");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}
		
		/// <summary>
		///		Graba los datos
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{	string strOAuthToken, strOAuthTokenSecret;

						// Asigna el token de autentificación para la solicitud
							objOAuthValidator.AccessToken = OAuthToken;
						// Obtiene los tokens de acceso a partir del PIN
							if (objOAuthValidator.GetAccessToken(cnstStrURLAccess, txtPinCode.Text, out strOAuthToken, out strOAuthTokenSecret))
								{	// Recupera los tokens secretos
						        OAuthToken = strOAuthToken;
						        OAuthSecretToken = strOAuthTokenSecret;
									// Cierra el formulario
										DialogResult = DialogResult.OK;
										Close();
						    }
							else
								Bau.Controls.Forms.Helper.ShowMessage(this, "No se han podido verificar las credenciales del usuario");
				}
		}
		
		/// <summary>
		///		Obtiene la cadena HTML que se muestra en el explorador para solicitar la autorización
		///	a Twitter para la aplicación
		/// </summary>
		private string GetHTML(Uri objURL)
		{ string strHTML = "<html><head><title></title>";
		
				// Añade los datos de la cadena HTML
					strHTML += "<style type='text/css'>";
					strHTML += "body {background-color:#5599BB;color:#ffffff;font-family:arial;}";
					strHTML += "img{border:none}";
					strHTML += "</style>";
					strHTML += "</head>";
					strHTML += "<body>";
					strHTML += "<h1>Solicitud de verificación</h1>";
					strHTML += "<p>Antes de utilizar esta aplicación debe iniciar sesión en Twitter.</p>";
					strHTML += "<p>Pulse el botón de inicio de sesión situado debajo e inicie sesión en la página";
					strHTML += " de Twitter.</p>";
					strHTML += "<p>Una vez que inicie la sesión, Twitter le proporcionara un PIN.</p>";
					strHTML += "<p>Copie el PIN en el cuadro de texto del formulario y pulse Aceptar.</p>";
					strHTML += "<p><a href=\"" + objURL.ToString() + "\">";
					strHTML += "<img src=\"https://g.twimg.com/dev/sites/default/files/images_documentation/sign-in-with-twitter-gray.png\"";
					strHTML += " alt=\"Autentificarse en Twitter\" /></a></p>";
					strHTML += "</body></html>";
				// Devuelve la cadena HTML
					return strHTML;
		}
		
		/// <summary>
		///		Token de acceso
		/// </summary>
		public string OAuthToken { get; set; }
		
		/// <summary>
		///		Token secreto
		/// </summary>
		public string OAuthSecretToken { get; set; }
		
		private void frmSignTwitter_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}
