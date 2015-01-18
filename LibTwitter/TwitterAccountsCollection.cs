using System;
using System.Collections.Generic;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibTwitter
{
	/// <summary>
	///		Colección de <see cref="TwitterAccount"/>
	/// </summary>
	public class TwitterAccountsCollection : List<TwitterAccount>
	{
		/// <summary>
		///		Busca una cuenta en la colección
		/// </summary>
		public TwitterAccount Search(string strID)
		{ // Recorre la colección
				foreach (TwitterAccount objAccount in this)
					if (objAccount.ID.Equals(strID, StringComparison.CurrentCultureIgnoreCase))
						return objAccount;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Busca una cuenta en la colección por su nombre de cuenta
		/// </summary>
		public TwitterAccount SearchByUser(string strUserName)
		{ // Recorre la colección
				foreach (TwitterAccount objAccount in this)
					if (objAccount.ScreenName.Equals(strUserName, StringComparison.CurrentCultureIgnoreCase))
						return objAccount;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Elimina una cuenta por su ID
		/// </summary>
		public void RemoveByID(string strID)
		{ for (int intIndex = Count - 1; intIndex >= 0; intIndex--)
				if (this[intIndex].ID == strID)
					RemoveAt(intIndex);
		}

		/// <summary>
		///		Elimina una cuenta por su nombre
		/// </summary>
		public void RemoveByScreenName(string strUserName)
		{ for (int intIndex = Count - 1; intIndex >= 0; intIndex--)
				if (this[intIndex].ScreenName.EqualsIgnoreCase(strUserName))
					RemoveAt(intIndex);
		}
	}
}
