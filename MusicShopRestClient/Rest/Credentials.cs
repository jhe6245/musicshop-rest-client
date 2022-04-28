using System.Text.Json.Serialization;

namespace MusicShopRestClient.Rest
{
	public record Credentials
	{
		[JsonPropertyName("username")] public string UserName { get; init; }
		[JsonPropertyName("password")] public string Password { get; init; }
	}
}
