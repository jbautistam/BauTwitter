using System;

namespace Bau.Libraries.LibTwitter.Core
{
	/// <summary>
	///		Datos de tendencia
	/// </summary>
	public class Trend
	{
		public Trend() : this(null, null) {}
		
		public Trend(string strName, string strURL)
		{ Name = strName;
			URL = strURL;
		}
		
		/// <summary>
		///		Nombre de la tendencia
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		///		URL
		/// </summary>
		public string URL { get; set; }
	}
}
