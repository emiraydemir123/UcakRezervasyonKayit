using System.Text.Json.Serialization;

namespace UcakRezervasyon
{
	public class Musteri
	{
		public Musteri() { }

        [JsonInclude]
        public string Ad;
        [JsonInclude]
        public string Soyad;
	}
}
