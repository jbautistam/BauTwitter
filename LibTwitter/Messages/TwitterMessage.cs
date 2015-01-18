using System;

using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Messages
{
	/// <summary>
	///		Clase con los datos de un mensaje de Twitter
	/// </summary>
	public abstract class TwitterMessage : IComparable<TwitterMessage>
	{ // Constantes públicas
			public const string cnstStrFollow = "Follow";
			public const string cnstStrUnfollow = "UnFollow";
			public const string cnstStrSee = "See";
			public const string cnstStrRetweet = "Retweet";
			public const string cnstStrReply = "Reply";
			public const string cnstStrLink = "Link";
			
		public TwitterMessage(long lngID, string strDate)
		{ ID = lngID;
			DateNew = GetDate(strDate);
		}
		
		public TwitterMessage(long lngID, DateTime dtmNew)
		{ ID = lngID;
			DateNew = dtmNew;
		}	
		
		/// <summary>
		///		Obtiene una fecha a partir de una cadena
		/// </summary>
		/// <remarks>
		///		Sat Dec 11 11:23:12 +0000 2010
		///		Sat Dec 11 11:21:58 +0000 2010
		/// </remarks>
		protected DateTime GetDate(string strDate)
		{ bool blnParsed = false;
			DateTime dtmDate = DateTime.Now;

				// Obtiene la fecha
					if (!string.IsNullOrEmpty(strDate))
						{ if (!DateTime.TryParse(strDate, out dtmDate) &&
									!Libraries.LibHelper.Extensors.DateTimeHelper.TryParseRfc(strDate, out dtmDate))
								{ string [] arrStrDate = strDate.Split(' ');
								
										if (arrStrDate.Length == 6)
											{ int intYear, intMonth, intDay, intIncrement;
												int intHour = 0, intMinutes = 0, intSeconds = 0;
												string [] arrStrHour = arrStrDate[3].Split(':');
											
													// Convierte los valores
														intYear = GetInt(arrStrDate[5]);
														intDay = GetInt(arrStrDate[2]);
														intIncrement = GetInt(arrStrDate[4]);
														intMonth = GetMonth(arrStrDate[1]);
														if (arrStrHour.Length == 3)
															{ intHour = GetInt(arrStrHour[0]);
																intMinutes = GetInt(arrStrHour[1]);
																intSeconds = GetInt(arrStrDate[2]);
															}
													// Crea la fecha
														if (intYear > 0 && intMonth > 0 && intDay > 0)
															{	// Crea la fecha
																	dtmDate = new DateTime(intYear, intMonth, intDay, intHour, intMinutes, intSeconds);
																	dtmDate = dtmDate.AddHours(intIncrement);
																// Indica que se ha interpretado
																	blnParsed = true;
															}
											}
								}
							else
								blnParsed = true;
						}
				// Devuelve la fecha
					if (!blnParsed)
						return DateTime.Now;
					else
						return dtmDate;
		}
		
		/// <summary>
		///		Obtiene el mes de una cadena
		/// </summary>
		private int GetMonth(string strMonth)
		{ if (!string.IsNullOrEmpty(strMonth))
				switch (strMonth.ToUpper())
					{ case "JAN":
							return 1;
						case "FEB":
							return 2;
						case "MAR":
							return 3;
						case "APR":
							return 4;
						case "MAY":
							return 5;
						case "JUN":
							return 6;
						case "JUL":
							return 7;
						case "AUG":
							return 8;
						case "SEP":
							return 9;
						case "OCT":
							return 10;
						case "NOV":
							return 11;
						case "DEC":
							return 12;
					}
			return 0;
		}
		
		/// <summary>
		///		Obtiene un entero de una cadena
		/// </summary>
		private int GetInt(string strValue)
		{ int intResult;
		
				if (int.TryParse(strValue, out intResult))
					return intResult;
				else
					return 0;
		}

		/// <summary>
		///		Crea la plantilla HTML para el mensaje
		/// </summary>
		internal string ToHTML(User objUser, string strMessage, string strLinks)
		{ string strHTML;
		
				// Añade la celda de la imagen
					strHTML = "<tr class='" + GetRowClass(IsRowEven) + "'><td rowspan='3'>";
					if (!string.IsNullOrEmpty(objUser.ProfileImage))
						strHTML += "<img width='40px' height='40px' src=\"" + objUser.ProfileImage + "\">";
					else
						strHTML += "&nbsp;";
					strHTML += "</td>";
				// Añade la celda con el usuario
					strHTML += "<td>" + GetLinkFunction(cnstStrSee + "|" + objUser.ScreenName, "@" + objUser.ScreenName) + "</td>";
					strHTML += "<td><span class='dateLabel'>" + string.Format("{0:dd-MM-yyyy HH:mm}", DateNew) + "</span></td>";
					strHTML += "</tr>";
				// Añade la celda con el texto
					strHTML += "<tr class='" + GetRowClass(IsRowEven) + "'><td colspan='2'>" + ParseRefs(strMessage) + "</td></tr>";
				// Añade las celdas con los vínculos
					strHTML += "<tr class='" + GetRowClass(IsRowEven) + "'><td colspan='3' align='right'>" + 
												strLinks + " " + GetLinkFollow(objUser) + "</td></tr>";
				// Devuelve el mensaje
					return strHTML;
		}

		/// <summary>
		///		Obtiene la clase de la fila
		/// </summary>
		private string GetRowClass(bool blnIsRowEven)
		{ if (blnIsRowEven)
				return "rowEven";
			else
				return "rowOdd";
		}
		
		/// <summary>
		///		Obtiene el link para seguir / dejar de seguir
		/// </summary>
		private string GetLinkFollow(User objUser)
		{ if (objUser.Following)
				return GetLinkFunction(cnstStrUnfollow + "|" + objUser.ScreenName, "No seguir");
			else
				return GetLinkFunction(cnstStrFollow + "|" + objUser.ScreenName, "Seguir");
		}
		
		/// <summary>
		///		Obtiene un link a una función JavaScript
		/// </summary>
		protected string GetLinkFunction(string strArgument, string strTitle)
		{ return "<a href='#' onClick=\"window.external.ScriptMessageHandler('" + strArgument + "');return false;\">" + strTitle + "</a>";
		}
		
		/// <summary>
		///		Interpreta las referencias de un texto @xxxx y http://xxxx
		/// </summary>
		private string ParseRefs(string strText)
		{ // Reemplaza los textos
				if (!string.IsNullOrEmpty(strText))
					{ strText = ParseRefsStart("http://", strText, true);
						strText = ParseRefsStart("@", strText, false);
						strText = ParseRefsStart("#", strText, false);
					}
			// Devuelve el texto
				return strText;
		}
		
		/// <summary>
		///		Interpreta las referencias que comienzan por una cadena
		/// </summary>
		private string ParseRefsStart(string strStart, string strText, bool blnIsHref)
		{ int intPosition = strText.IndexOf(strStart);
			string strValue = "";
				
				// Mientras que se encuentre el carácter de inicio
					if (intPosition >= 0)
						do
							{ string strInnerValue;
							
									// Añade la primera parte de la cadena al valor final y la quita del texto inicial
										strValue += CutString(intPosition, ref strText);
									// Busca la posición final
										intPosition = SearchRefEnd(strText, strStart.Length, blnIsHref);
									// Corta la cadena
										strInnerValue = CutString(intPosition, ref strText);
									// Añade el valor a la cadena final
										if (strInnerValue.Length > 1)
											strValue += GetLinkFunction(cnstStrLink + "|" + strInnerValue, strInnerValue);
										else
											strValue += strInnerValue;
									// Obtiene la siguiente posición
										intPosition = strText.IndexOf(strStart);
							}
						while (intPosition >= 0);
				// Devuelve la cadena final
					return strValue + strText;
		}
		
		/// <summary>
		///		Busca el final de una cadena de referencia
		/// </summary>
		private int SearchRefEnd(string strText, int intStart, bool blnIsHref)
		{ // Busca la posición final
				while (intStart < strText.Length &&
							 (char.IsLetterOrDigit(strText[intStart]) || strText[intStart] == '_' || strText[intStart] == '@' ||
							  (blnIsHref && "./-=?&".IndexOf(strText[intStart]) >= 0)))
					intStart++;
			// Devuelve la posición final
				return intStart;							 
		}

		/// <summary>
		///		Corta una cadena en dos
		/// </summary>
		private string CutString(int intPosition, ref string strSource)
		{ string strTarget = "";
		
				// Corga la cadena de origen
					strTarget = strSource.Substring(0, intPosition);
					if (intPosition < strSource.Length)
						strSource = strSource.Substring(intPosition);
					else
						strSource = "";
				// Devuelve la cadena final
					return strTarget;
		}		
		
		/// <summary>
		///		HTML del mensaje
		/// </summary>
		internal abstract string ToHTML();

		/// <summary>
		///		Compara los mensajes
		/// </summary>
		public int CompareTo(TwitterMessage objMessage)
		{ if (objMessage == null)
				return 0;
			else
				return objMessage.DateNew.CompareTo(DateNew);
		}
		
		/// <summary>
		///		ID del mensaje
		/// </summary>
		public long ID { get; set; }
		
		/// <summary>
		///		Fecha de alta del mensaje
		/// </summary>
		public DateTime DateNew { get; private set; }
		
		/// <summary>
		///		Indica si estamos en una fila par o impar
		/// </summary>
		public bool IsRowEven { get; set; }
	}
}
