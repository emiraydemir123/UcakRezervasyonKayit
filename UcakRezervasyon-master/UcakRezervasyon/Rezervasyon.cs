using System.Text.Json.Serialization;

namespace UcakRezervasyon
{
	public class Rezervasyon
	{
		public Rezervasyon() { }

        [JsonInclude]
        public Musteri KimIcin;
        [JsonInclude]
        public Sefer Nereye;
        [JsonInclude]
        public int KoltukNo;
	}
}
