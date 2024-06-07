using Microsoft.AspNetCore.Identity;

namespace Féléves_Szerveroldali.Models
{
	public class SiteUser : IdentityUser
	{
		public string ContentType { get; set; }
		public byte[] Data { get; set; }
	}
}
