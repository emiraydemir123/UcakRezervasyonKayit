using System.Text.Json.Serialization;

namespace UcakRezervasyon
{
	public class Sefer
	{
		public Sefer() { }

        [JsonInclude]
		public int Id;
        [JsonInclude]
		public Lokasyon Kalkis;
        [JsonInclude]
		public Lokasyon Varis;
        [JsonInclude]
		public DateTime Zaman;
        [JsonInclude]
		public Ucak Tasit;
	}
}
