using System.Text.Json.Serialization;

namespace NanoSurvery.Domain.Dtos
{
	public class UserDto
	{
		[JsonPropertyName("username")]
		public string? Username { get; set; }

		[JsonPropertyName("password")]
		public string? Password { get; set; }
	}
}