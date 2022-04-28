using System.Collections.Generic;

namespace MusicShopRestClient.Dto
{
	public record SearchResult(string Id, string Title, string Medium, int Stock, double Price);

	public record ProductDetails(string Title, double Price, int Stock, string Medium, List<Recording> Recordings);

	public record Recording(string Title, List<string> Artists, List<string> Genres, int Year, int Duration);
}
