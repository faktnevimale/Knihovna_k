using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_k
{
	internal class Program
	{

		public class Kniha
		{
			public string Nazev { get; set; }
			public string Autor { get; set; }
			public string ID { get; set; }
			public bool Vypujcena { get; set; }

			public Kniha(string nazev, string autor, string id)
			{
				Nazev = nazev;
				Autor = autor;
				ID = id;
				Vypujcena = false;
			}

			public void Vypujcenakniha()
			{
				if (Vypujcena)
				{
					Console.WriteLine("Tato kniha je již vypůjčená.");
				}
				else
				{
					Vypujcena = true;
					Console.WriteLine($"Kniha '{Nazev}' byla úspěšně vypůjčená!");
				}
			}

			public void VracenaKniha()
			{
				if (Vypujcena)
				{
					Console.WriteLine("Tato kniha není vypůjčená.");
				}
				else
				{
					Vypujcena = false;
					Console.WriteLine($"Kniha '{Nazev}' byla úspěšně vrácená!");
				}
			}
			public void DisplayInfo()
			{
				string Stav = Vypujcena ? "vypůjčená" : "dostupná";
				Console.WriteLine($"Název: {Nazev}, Autor: {Autor}, Stav: {Stav}");
			}
		}
	
		public class Knihovna
		{
			private List<Kniha> knihy;

			public Knihovna()
			{
				knihy = new List<Kniha>();
			}

			public void PridatKnihu(Kniha knihaPridana)
			{
				knihy.Add(knihaPridana);
				Console.WriteLine($"Kniha '{knihaPridana.Nazev}' byla přidána.");
			}

			public void SmazatKnihu(string nazev)
			{
				var knihyKeSmazani = knihy.Find(b => b.Nazev.Equals(nazev, StringComparison.OrdinalIgnoreCase));
				if (knihyKeSmazani != null)
				{
					knihy.Remove(knihyKeSmazani);
					Console.WriteLine($"Kniha '{nazev}' byla odstraněna.");
				}
				else
				{
					Console.WriteLine($"Kniha s názvem '{nazev}' nebyla nalezena.");
				}

				Console.WriteLine("Seznam knih:");
				foreach (var book in knihy)
				{
					book.DisplayInfo();
				}
			}

			public void SeznamDostupnychKnih()
			{
				Console.WriteLine("Dostupné knihy:");
				foreach (var kniha in knihy)
				{
					if (!kniha.Vypujcena)
					{
						kniha.DisplayInfo();
					}
				}
			}

			public void SeznamVypujcenychKnih()
			{
				Console.WriteLine("Vypůjčené knihy:");
				foreach (var kniha in knihy)
				{
					if (kniha.Vypujcena)
					{
						kniha.DisplayInfo();
					}
				}
			}
		}
	}
}



