using System;
using System.Windows.Forms;

namespace Bau.Applications.TwitterMarketing.Classes
{
	/// <summary>
	///		Datos de configuración
	/// </summary>
	internal static class TwitterConfiguration
	{
		/// <summary>
		///		Asigna las propiedades de configuración al objeto de configuración de <see cref="Libraries.LibTwitter.ManagerTwitter"/>
		/// </summary>
		internal static void AssignProperties(Libraries.LibTwitter.ManagerTwitter objManager)
		{	objManager.OAuthConsumerKey = OAuthConsumerKey;
			objManager.OAuthConsumerSecret = OAuthConsumerSecret;
		}

		/// <summary>
		///		Graba la configuración
		/// </summary>
		internal static void Save()
		{ Properties.Settings.Default.Save();
		}
		
		/// <summary>
		///		Clave de aplicación
		/// </summary>
		internal static string OAuthConsumerKey
		{ get { return Properties.Settings.Default.OAuthConsumerKey; }
			set { Properties.Settings.Default.OAuthConsumerKey = value; }
		}
		
		/// <summary>
		///		Clave secreta de la aplicación
		/// </summary>
		internal static string OAuthConsumerSecret
		{ get { return Properties.Settings.Default.OAuthConsumerSecret; }
			set { Properties.Settings.Default.OAuthConsumerSecret = value; }
		}
		
		/// <summary>
		///		Número máximo de mensajes de Twitter
		/// </summary>
		internal static int MessagesTwitterMaximum
		{ get { return Properties.Settings.Default.MessagesTwitterMaximum; }
			set { Properties.Settings.Default.MessagesTwitterMaximum = value; }
		}
		
		/// <summary>
		///		Minutos entre descargas de timeline en Twitter
		/// </summary>
		internal static int MinutesBetweenDownloadStatus
		{ get { return Properties.Settings.Default.MinutesBetweenDownloadStatus; }
			set { Properties.Settings.Default.MinutesBetweenDownloadStatus = value; }
		}

		/// <summary>
		///		Directorio de datos
		/// </summary>
		internal static string PathData
		{ get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
		}

		/// <summary>
		///		Nombre del archivo de cuentas
		/// </summary>
		internal static string FileNameAccounts
		{ get { return System.IO.Path.Combine(PathData, "Accounts.xml"); }
		}
				
		/// <summary>
		///		Minutos entre proceso para descarga de blogs
		/// </summary>
		public static int MinutesBetweenDownloadBlogs
		{ get { return Properties.Settings.Default.MinutesBetweenDownloadBlogs; }
			set { Properties.Settings.Default.MinutesBetweenDownloadBlogs = value; }
		}

		/// <summary>
		///		Valor que indica si se debe arrancar minimizado
		/// </summary>
		public static bool StartMinimized
		{ get { return Properties.Settings.Default.StartMinimized; }
			set { Properties.Settings.Default.StartMinimized = value; }
		}		
	}
}