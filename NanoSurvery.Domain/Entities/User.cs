using System.ComponentModel.DataAnnotations;

namespace NanoSurvery.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
		public string?  RefreshToken { get; set; }
		public DateTime TokenCreated { get; set; }
		public DateTime TokenExpires { get; set; }
	}
}
