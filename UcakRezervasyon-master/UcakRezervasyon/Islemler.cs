using System.Diagnostics.Metrics;
using System.Text.Json;

namespace UcakRezervasyon
{
	public class Islemler
	{
		private List<Sefer> seferler;
		private List<Rezervasyon> rezervasyonlar;

		public Islemler(List<Sefer> sefer_listesi)
		{
			seferler = sefer_listesi;
			rezervasyonlar = new List<Rezervasyon>();
			rezervasyonlar = Oku<List<Rezervasyon>>(rezervasyonlar, "rezervasyonlar.json");
		}

		public List<Sefer> GetirSeferListesiKalkisVeVarisVeTariheGore(string kalkis_yeri, string varis_yeri, DateTime zaman)
		{
			var liste = new List<Sefer>();

			foreach (var sefer in seferler)
			{
				if (sefer.Kalkis.Ad == kalkis_yeri
					&& sefer.Varis.Ad == varis_yeri
					&& sefer.Zaman == zaman)
				{
					liste.Add(sefer);
				}
			}

			return liste;
		}

		public int GetirBosKoltukSayisiSefereGore(Sefer sefer)
		{
			var mevcut_koltuk_sayisi = sefer.Tasit.Kapasite;

			var dolu_koltuk_sayisi = 0;
			foreach (var r in rezervasyonlar)
			{
				if (r.Nereye.Id == sefer.Id)
				{
					dolu_koltuk_sayisi += 1;
				}
			}

			return mevcut_koltuk_sayisi - dolu_koltuk_sayisi;
		}

		public Sefer GetirSeferIdYeGore(int sefer_id)
		{
			Sefer d = null;

			foreach (var sefer in seferler)
			{
				if (sefer.Id == sefer_id)
				{
					d = sefer;
				}
			}
			return d;
		}

		public void RezervasyonYap(Sefer sefer, string ad, string soyad, int koltuk_no)
		{
			var m = new Musteri();
			m.Ad = ad;
			m.Soyad = soyad;

			var r = new Rezervasyon();
			r.KimIcin = m;
			r.Nereye = sefer;
			r.KoltukNo = koltuk_no;

			rezervasyonlar.Add(r);
			Kaydet(rezervasyonlar, "rezervasyonlar.json");
		}

		static void Kaydet<T>(T data, string filePath)
		{
			string json = JsonSerializer.Serialize(data);
			File.WriteAllText(filePath, json);
		}

		static T Oku<T>(T default_val, string filePath)
		{
			string json = "";

			try
			{
				json = File.ReadAllText(filePath);
			}
			catch (FileNotFoundException)
			{
				return default_val;
			}

			return JsonSerializer.Deserialize<T>(json);
		}
	}
}
