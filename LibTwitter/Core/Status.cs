using System;

namespace Bau.Libraries.LibTwitter.Core
{
	/// <summary>
	///		Mensajes de estado de Twitter
	/// </summary>
	public class Status
	{
		/// <summary>
		///		Fecha de creación
		/// </summary>
		public string CreatedAt { get; set; }
		
		/// <summary>
		///		Identificador
		/// </summary>
		public long ID { get; set; }
		
		/// <summary>
		///		Texto
		/// </summary>
		public string Text { get; set; }
		
		/// <summary>
		///		Origen
		/// </summary>
		public string Source { get; set; }
		
		/// <summary>
		///		Indica si se ha encontrado
		/// </summary>
		public bool Truncated { get; set; }
		
		/// <summary>
		///		ID sobre el que se ha lanzado la respuesta
		/// </summary>
		public long InReplyToStatusID { get; set; }
		
		/// <summary>
		///		ID de usuario al que se ha respondido
		/// </summary>
		public long InReplyToUserID { get; set; }
		
		/// <summary>
		///		Indica si es favorito
		/// </summary>
		public bool Favorited { get; set; }
		
		/// <summary>
		///		Nombre de usuario al que se ha respondido
		/// </summary>
		public string InReplyToScreenName { get; set; }
		
		/// <summary>
		///		Datos del usuario
		/// </summary>
		public User User { get; set; }
		
		/// <summary>
		///		Error
		/// </summary>
		public Error Error { get; set; }
	}
}
