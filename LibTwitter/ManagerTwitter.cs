using System;

using Bau.Libraries.LibTwitter.Commands;
using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter
{
	/// <summary>
	///		Manager de una cuenta Twitter
	/// </summary>
	public class ManagerTwitter
	{
		public ManagerTwitter()
		{ Accounts = new TwitterAccountsCollection();
			TwitterMessenger = new Messages.TwitterMessengerManager(this);
		}
		
		/// <summary>
		///		ConsumerKey para OAuth
		/// </summary>
		public string OAuthConsumerKey { get; set; }
		
		/// <summary>
		///		ConsumerSecret para OAuth
		/// </summary>
		public string OAuthConsumerSecret { get; set; }
		
		/// <summary>
		///		Cuentas del manager Twitter
		/// </summary>
		public TwitterAccountsCollection Accounts { get; private set; }

		/// <summary>
		///		Messenger de Twitter
		/// </summary>
		public Messages.TwitterMessengerManager TwitterMessenger { get; private set; }
	}
}
