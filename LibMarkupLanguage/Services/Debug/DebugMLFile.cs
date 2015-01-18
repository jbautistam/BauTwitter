using System;

namespace Bau.Libraries.LibMarkupLanguage.Services.Debug
{
	/// <summary>
	///		Depuración de <see cref="MLFile"/>
	/// </summary>
	public class DebugMLFile
	{
		/// <summary>
		///		Depura un archivo de nodos
		/// </summary>
		public string Debug(MLFile objMLFile)
		{ return Debug(objMLFile.Nodes, 0);
		}

		/// <summary>
		///		Depura una colección de nodos
		/// </summary>
		private string Debug(MLNodesCollection objColMLNodes, int intIndent)
		{ string strDebug = "";

				// Depura los nodos
					foreach (MLNode objMLNode in objColMLNodes)
						strDebug += Debug(objMLNode, intIndent);
				// Devuelve la cadena de depuración
					return strDebug;
		}

		/// <summary>
		///		Depura un nodo
		/// </summary>
		private string Debug(MLNode objMLNode, int intIndent)
		{ string strDebug = GetIndent(intIndent);

				// Depura el nodo	y sus atributos
					strDebug += objMLNode.Name + " --> ";
					if (!string.IsNullOrEmpty(objMLNode.Value))
						strDebug += objMLNode.Value + " --> ";
					foreach (MLAttribute objMLAttribute in objMLNode.Attributes)
						strDebug += string.Format(" {0} = \"{1}\"", objMLAttribute.Name, Normalize(objMLAttribute.Value));
					strDebug += Environment.NewLine;
				// Depura los nodos hijo
					if (objMLNode.Nodes.Count > 0)
						strDebug += Debug(objMLNode.Nodes, intIndent + 1);
				// Añade una separación
					// strDebug += Environment.NewLine;
				// Devuelve la cadena de depuración
					return strDebug;
		}

		/// <summary>
		///		Normaliza una cadena
		/// </summary>
		private string Normalize(string strValue)
		{ string strResult = strValue;

				// Quita los caracteres extraños
					strValue = strValue.Replace("\r", "\\r");
					strValue = strValue.Replace("\n", "\\n");
				// Devuelve la cadena
					return strValue;
		}

		/// <summary>
		///		Obtiene la cadena de indentación
		/// </summary>
		private string GetIndent(int intIndent)
		{ string strIndent = "";

				// Añade espacios
					for (int intIndex = 0; intIndex < intIndent; intIndex++)
						strIndent += "  ";
				// Devuelve la cadena
					return strIndent;
		}
	}
}
