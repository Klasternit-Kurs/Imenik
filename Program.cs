using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija
{
	class Program
	{
		static void Main(string[] args)
		{
			char unos = ' ' ;
			do
			{
				StampajMeni();
				//Jos jedan nacin za parse, vraca true ili false + broj u out 
				//varijalbli ako je uspesan parse
				//int.TryParse(Console.ReadLine(), out int unos)
				
				unos = Console.ReadKey().KeyChar;
				switch(unos)
				{
					case '1':
						UnosOsobe();
						break;
					case '2':
						Izmena();
						break;
					case '3':
						Brisanje();
						break;
					case '4':
						Console.WriteLine();
						/*foreach ( Osoba o in Osoba.Osobe)
						{
							Console.WriteLine(o); //isto kao o.ToString()
						}*/
						for (int indeks = 0; indeks < Osoba.Osobe.Count; indeks++)
						{
							Console.WriteLine($"{indeks+1}. -- {Osoba.Osobe[indeks]}");
						}
						break;
					default:
						Console.WriteLine("\nGreska u unosu!");
						break;
				}

			} while (unos != '5');
		}

		static void Izmena()
		{
			Console.Write("\nUnesite broj telefona: ");
			string br = Console.ReadLine();

			if (!Osoba.ProveriTel(br, out Osoba o))
			{
				Console.Write("\nUnesite ime i prezime: ");
				string[] imeIprezime = Console.ReadLine().Split(' ');
				//"Pera Peric" ---> ["Pera", "Peric"]
				if (imeIprezime.Length != 2)
				{
					Console.WriteLine("Greska u unosu!");
					return;
				}
				o.ime = imeIprezime[0];
				o.prezime = imeIprezime[1];
			}
			else
			{
				Console.WriteLine("Nema tog broja :(");
			}
		}

		static void Brisanje()
		{
			//TODO Napraviti brisanje da radi po indeksima
			//Korisno bi bilo koristiti for petlju standardnu da mozete da 
			//ispisete indekse, i onda koristite Osoba.Osobe.RemoveAt(indeks) :) 
			Console.Write("\nUnesite broj telefona: ");
			string br = Console.ReadLine();

			if (!Osoba.ProveriTel(br, out Osoba o))
			{
				Osoba.Osobe.Remove(o);
			} else
			{
				Console.WriteLine("Nema tog broja :(");
			}
		}

		static void UnosOsobe()
		{ //TODO Za domaci, ova metoda u do while, i nema izlaska dok se ne unese
			//sve tacno :) 
			Console.Write("\nUnesite ime i prezime: ");
			string[] imeIprezime = Console.ReadLine().Split(' ');
			//"Pera Peric" ---> ["Pera", "Peric"]
			if (imeIprezime.Length != 2)
			{
				Console.WriteLine("Greska u unosu!");
				return;
			}
			Console.Write("Unesite broj telefona:");
			//TODO Za domaci: broj telefona mora da se unese u formatu gde ima
			//   / za pozivni i - izmedju dve grupe brojeva, proveriti to :) 
			string broj = Console.ReadLine();


			if (Osoba.ProveriTel(broj, out _))
			{
				//Ne treba nam varijabla jer konstruktor automatski smesta 
				//osobu u list :) 
				new Osoba(imeIprezime[0], imeIprezime[1], broj);
			} else
			{
				Console.WriteLine("Telefon vec postoji!");
			}
		}

		//Primer metode sa out paramterom, kao sto je TryParse
		static bool FooBar(int x, out int rezultat)
		{
			rezultat = 5;
			return false;
		}

		static void StampajMeni()
		{
			Console.WriteLine("\n1. Unos osobe");
			Console.WriteLine("2. Izmena osobe");
			Console.WriteLine("3. Brisanje");
			Console.WriteLine("4. Pregled");
			Console.WriteLine("5. Izlaz");
			Console.WriteLine("--------------------------");
			Console.Write("Unesite broj: ");
		}
	}

	class Osoba
	{
		static public List<Osoba> Osobe = new List<Osoba>();

		static public bool ProveriTel(string t, out Osoba ob)
		{
			foreach(Osoba o in Osobe)
			{
				if (o.broj == t)
				{
					ob = o;
					return false;
				}
			}
			ob = null;
			return true;
		}

		public string ime;
		public string prezime;
		public string broj;

		public Osoba(string i, string p, string b)
		{
			ime = i;
			prezime = p;
			broj = b;
			Osobe.Add(this);
		}
		public Osoba() 
		{
			Osobe.Add(this);
		}

		public override string ToString()
		{
			return $"{ime} {prezime} -- {broj}";
		}
	}
}
