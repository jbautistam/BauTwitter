using System;

namespace Bau.Libraries.LibTwitter.Core
{
	/// <summary>
	///		Mensaje directo de Twitter
	/// </summary>
	public class DirectMessage
	{
		public long ID { get; set; }
		public long SenderID { get; set; }
		public string SenderScreenName { get; set; }
		public long RecipientID { get; set; }
		public string RecipientScreenName { get; set; }
		public string Text { get; set; }
		public string CreatedAt { get; set; }
		public User Sender { get; set; }
		public User Recipient { get; set; }
	}
}
