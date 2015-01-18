using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Commands.Parser
{
	/// <summary>
	///		Intérprete de <see cref="DirectMessage"/>
	/// </summary>
	internal static class DirectMessageParser
	{ // Constantes internas
			internal const string cnstStrTagMessage = "direct_message";
		// Constantes privadas
			private const string cnstStrTagRoot = "direct-messages";
			private const string cnstStrTagID = "id";
			private const string cnstStrTagSenderID = "sender_id";
			private const string cnstStrTagText = "text";
			private const string cnstStrTagRecipientID = "recipient_id";
			private const string cnstStrTagCreatedAt = "created_at";
			private const string cnstStrTagSenderScreenName = "sender_screen_name";
			private const string cnstStrTagRecipientScreenName = "recipient_screen_name";
			private const string cnstStrTagSender = "sender";
			private const string cnstStrTagRecipient = "recipient";

		/// <summary>
		///		Interpreta un documento XML con datos de un mensaje
		/// </summary>
		internal static DirectMessagesCollection ParseCollection(MLFile objMLFile)
		{ DirectMessagesCollection objColMessages = new DirectMessagesCollection();
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals(cnstStrTagRoot))
							foreach (MLNode objMLMessage in objMLNode.Nodes)
								if (objMLMessage.Name.Equals(cnstStrTagMessage))
									objColMessages.Add(Parse(objMLMessage));
				// Devuelve los mensajes
					return objColMessages;
		}

		/// <summary>
		///		Interpreta un documento XML con datos de un mensaje
		/// </summary>
		internal static DirectMessage Parse(MLFile objMLFile)
		{ DirectMessage objMessage = new DirectMessage();
		
				// Interpreta los datos
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name.Equals(cnstStrTagMessage))
							objMessage = Parse(objMLNode);
				// Devuelve el mensaje
					return objMessage;
		}
				
		/// <summary>
		///		Interpreta un nodo XML con un mensaje
		/// </summary>
		private static DirectMessage Parse(MLNode objMLMessage)
		{ DirectMessage objMessage = new DirectMessage();
		
				// Obtiene los datos del mensaje
					objMessage.ID = objMLMessage.Nodes[cnstStrTagID].GetValue(0);
					objMessage.SenderID = objMLMessage.Nodes[cnstStrTagSenderID].GetValue(0);
					objMessage.Text = objMLMessage.Nodes[cnstStrTagText].Value;
					objMessage.RecipientID = objMLMessage.Nodes[cnstStrTagRecipientID].GetValue(0);
					objMessage.CreatedAt = objMLMessage.Nodes[cnstStrTagCreatedAt].Value;
					objMessage.SenderScreenName = objMLMessage.Nodes[cnstStrTagSenderScreenName].Value;
					objMessage.RecipientScreenName = objMLMessage.Nodes[cnstStrTagRecipientScreenName].Value;
				// Obtiene el emisor y el receptor
					if (!string.IsNullOrEmpty(objMLMessage.Nodes[cnstStrTagSender].Name))
						objMessage.Sender = UserParser.Parse(objMLMessage.Nodes[cnstStrTagSender]);
					if (!string.IsNullOrEmpty(objMLMessage.Nodes[cnstStrTagRecipient].Name))
						objMessage.Recipient = UserParser.Parse(objMLMessage.Nodes[cnstStrTagRecipient]);
				// Devuelve el mensaje
					return objMessage;
		}
	}
}