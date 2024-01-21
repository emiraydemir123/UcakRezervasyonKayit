using System.Text.Json.Serialization;

namespace UcakRezervasyon
{
	public class Ucak
	{
		public Ucak() { }

        [JsonInclude]
		public int Id;
        [JsonInclude]
		public string Marka;
        [JsonInclude]
		public int Kapasite;
	}
}
