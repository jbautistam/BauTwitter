using System;

namespace Bau.Libraries.LibTwitter.Core
{
	/// <summary>
	///		Usuario de Twitter
	/// </summary>
	public class User
	{
		public long ID { get; set; }
		public string Name { get; set; }
		public string ScreenName { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string ProfileImage { get; set; }
		public string Url { get; set; }
		public bool IsProtected { get; set; }
		public long FollowersCount { get; set; }
		public long FriendsCount { get; set; }
		public string CreatedAt { get; set; }
		public long FavoritesCount { get; set; }
		public bool Verified { get; set; }
		public bool Following { get; set; }
		public long StatusCount { get; set; }
		public string ProfileBackgroundColor { get; set; }
		public string ProfileTextColor { get; set; }
		public string ProfileLinkColor { get; set; }
		public string ProfileSidebarFillColor { get; set; }
		public string ProfileSidebarBordeColor { get; set; }
		public int UtcOffset { get; set; }
		public string TimeZone { get; set; }
		public string ProfileBackgroundImageUrl { get; set; }
		public string ProfileBackgroundTitle { get; set; }
		public string Notifications { get; set; }
		public bool GeoEnabled { get; set; }
		public string Language { get; set; }
		public bool ContributorsEnabled { get; set; }
		public Status Status { get; set; }
	}
}
