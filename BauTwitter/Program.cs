using System;
using System.Windows.Forms;

namespace Bau.Applications.TwitterMarketing
{
	static class Program
	{ // Variables privadas
			private static Libraries.LibTwitter.ManagerTwitter objTwitterBotManager;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{	// Captura las excepciones de aplicación
				Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			// Inicializa la aplicación
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new frmMain());
		}
		
		/// <summary>
		///		Tratamiento de excepciones global
		/// </summary>
		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{	Bau.Controls.Forms.Helper.ShowError(null, "Excepción no controlada", e.Exception);
		}

		/// <summary>
		///		Manager para <see cref="TwitterBot"/>
		/// </summary>
		public static Libraries.LibTwitter.ManagerTwitter TwitterBotManager
		{ get
				{ // Crea el objeto (y lo configura) si no estaba en memoria
						if (objTwitterBotManager == null)
							{ // Crea el objeto
									objTwitterBotManager = new Libraries.LibTwitter.ManagerTwitter();
								// Asigna las propiedades
									Classes.TwitterConfiguration.AssignProperties(objTwitterBotManager);
							}
					// Devuelve el objeto
						return objTwitterBotManager;
				}
		}
	}
}
