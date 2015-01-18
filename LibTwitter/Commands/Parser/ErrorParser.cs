using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibTwitter.Commands.Parser
{
	/// <summary>
	///		Intérprete de <see cref="Error"/>
	/// </summary>
	internal static class ErrorParser
	{ // Constantes internas
			internal const string cnstStrTagRoot = "Error";
			internal const string cnstStrTagMessage = "Message";
		
		/// <summary>
		///		Interpreta los datos de un error
		/// </summary>
		internal static Core.Error Parse(MLFile objMLFile)
		{ Core.Error objError = new Core.Error();
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals(cnstStrTagRoot))
							foreach (MLNode objMLMessage in objMLNode.Nodes)
								if (objMLMessage.Name.Equals(cnstStrTagMessage))
									objError.Message = objMLMessage.Value;
				// Devuelve el objeto de error
					return objError;
		}
	}
}
