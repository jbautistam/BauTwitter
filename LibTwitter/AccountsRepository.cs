using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibTwitter
{
	/// <summary>
	///		Repository de <see cref="TwitterAccount"/>
	/// </summary>
	public static class AccountsRepository
	{ // Constantes privadas
			private const string cnstStrTagRoot = "Accounts";
			private const string cnstStrTagAccount = "Account";
			private const string cnstStrTagID = "ID";
			private const string cnstStrTagUser = "User";
			private const string cnstStrTagOAuthToken = "OAuthToken";
			private const string cnstStrTagOAuthTokenSecret = "OAuthTokenSecret";
			
		/// <summary>
		///		Graba las cuentas en un archivo
		/// </summary>
		public static void Save(TwitterAccountsCollection objColAccounts, string strFileName)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLNode = objMLFile.Nodes.Add(cnstStrTagRoot);
			
				// Asigna los nodos de las cuentas
					foreach (TwitterAccount objAccount in objColAccounts)
						{ MLNode objMLAccount = objMLNode.Nodes.Add(cnstStrTagAccount);
						
								// Añade el resto de nodos
									objMLAccount.Nodes.Add(cnstStrTagID, objAccount.ID);
									objMLAccount.Nodes.Add(cnstStrTagUser, objAccount.ScreenName);
									objMLAccount.Nodes.Add(cnstStrTagOAuthToken, objAccount.OAuthToken);
									objMLAccount.Nodes.Add(cnstStrTagOAuthTokenSecret, objAccount.OAuthTokenSecret);
						}
				// Graba el archivo
					new MLSerializer().Save(MLSerializer.SerializerType.XML, objMLFile, strFileName);
		}
		
		/// <summary>
		///		Carga las cuentas de un archivo
		/// </summary>
		public static void Load(string strFileName, ManagerTwitter objManager)
		{ TwitterAccountsCollection objColAccounts = new TwitterAccountsCollection();
		
				if (System.IO.File.Exists(strFileName))
					{	MLFile objMLFile = new MLSerializer().Parse(MLSerializer.SerializerType.XML, strFileName);
						
							// Recorre los nodos
								foreach (MLNode objMLNode in objMLFile.Nodes)
									if (objMLNode.Name == cnstStrTagRoot)
										foreach (MLNode objMLAccount in objMLNode.Nodes)
											if (objMLAccount.Name == cnstStrTagAccount)
												{ TwitterAccount objAccount = new TwitterAccount(objManager);
												
														// Asigna los datos
															objAccount.ID = objMLAccount.Nodes[cnstStrTagID].Value;
															objAccount.ScreenName = objMLAccount.Nodes[cnstStrTagUser].Value;
															objAccount.OAuthToken = objMLAccount.Nodes[cnstStrTagOAuthToken].Value;
															objAccount.OAuthTokenSecret = objMLAccount.Nodes[cnstStrTagOAuthTokenSecret].Value;
														// Añade la cuenta a la colección
															objManager.Accounts.Add(objAccount);
												}
					}
		}
	}
}
