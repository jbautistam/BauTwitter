using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibTwitter.Core
{
	/// <summary>
	///		Colección de <see cref="User"/>
	/// </summary>
	public class UsersCollection : List<User>
	{
		/// <summary>
		///		Ordena aleatoriamente la colección
		/// </summary>
		public void Random()
		{ Random objRandom = new Random(); 

				// Reordena la colección de usuarios		
					for (int intLoop = 0; intLoop < Count; intLoop++)
						{ int intTop = objRandom.Next(Count);
							int intBottom = objRandom.Next(Count);
							User objUser = this[intTop];
							
								// Cambia los datos
									this[intTop] = this[intBottom];
									this[intBottom] = objUser;								
						}
		}

		/// <summary>
		///		Comprueba si existe un usuario en una colección
		/// </summary>
		public bool Exists(string strScreenName) 
		{ // Recorre la colección
				foreach (User objUser in this)
					if (objUser.ScreenName.Equals(strScreenName, StringComparison.CurrentCultureIgnoreCase))
						return true;
			// Si ha llegado hasta aquí es porque no existe o porque la colección está vacía
				return false;
		}

		/// <summary>
		///		Elimina un usuario de la lista
		/// </summary>
		public void RemoveByScreenName(string strScreenName)
		{ for (int intIndex = Count - 1; intIndex >= 0; intIndex--)
				if (this[intIndex].ScreenName.Equals(strScreenName, StringComparison.CurrentCultureIgnoreCase))
					RemoveAt(intIndex);
		}
		
		/// <summary>
		///		Cursor a la siguiente página
		/// </summary>
		public string NextCursor { get; set; }
		
		/// <summary>
		///		Cursor a la página anterior
		/// </summary>
		public string PreviousCursor { get; set; }

		/// <summary>
		///		Indica si ha terminado la lectura de la colección de usuario
		/// </summary>
		public bool HasEndLoad
		{ get { return string.IsNullOrEmpty(NextCursor) || NextCursor == "0"; }
		}
	}
}
