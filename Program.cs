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
					case '4':
						Console.WriteLine();
						foreach ( Osoba o in Osoba.Osobe)
						{
							Console.WriteLine($"{o.ime} {o.prezime} -- {o.broj}");
						}
						break;
					default:
						Console.WriteLine("\nGreska u unosu!");
						break;
				}

			} while (unos != '5');
		}

		static void UnosOsobe()
		{ //Za domaci, ova metoda u do while, i nema izlaska dok se ne unese
			//sve tacno :) 
			Console.Write("\nUnesite ime i prezime: ");
			string[] imeIprezime = Console.ReadLine().Split(' ');
			//"Pera Peric" ---> ["Pera", "Peric"]
			if (imeIprezime.Length != 2)
			{
				Console.WriteLine("Greska u unosu!");
				return;
			}
			Console.WriteLine("Unesite broj telefona:");
			//Za domaci: broj telefona mora da se unese u formatu gde ima
			//   / za pozivni i - izmedju dve grupe brojeva, proveriti to :) 
			string broj = Console.ReadLine();


			//Ne treba nam varijabla jer konstruktor automatski smesta 
			//osobu u list :) 
			new Osoba(imeIprezime[0], imeIprezime[1], broj);
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
	}
}
