using System.Text.Json.Serialization;

namespace UcakRezervasyon
{
	public class Lokasyon
	{
		public Lokasyon() { }

        [JsonInclude]
		public int Id;
        [JsonInclude]
		public string Ad;
        [JsonInclude]
		public string Ulke;
	}
}
