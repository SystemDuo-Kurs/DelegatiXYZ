using System;
using System.Collections.Generic;

namespace DelegatiXYZ
{
	class Program
	{
		static void Main(string[] args)
		{
			Predavac pred = new();
			Polaznik p1 = new(pred);
			Polaznik p2 = new(pred);
			Diktafon d1 = new(pred);
			
			pred.Govori("Nesto tamo");
	
		}
	}

	class Predavac
	{
		public event Action<string> GovorDelegat;

		public void Govori(string govor)
		{
			//if (GovorDelegat is not null)
			//	GovorDelegat.Invoke(govor);
			//Isto kao:
			GovorDelegat?.Invoke(govor);
		}
	}

	class Polaznik
	{
		public Polaznik(Predavac p)
		{
			p.GovorDelegat += Slusam;
		}
		public void Slusam(string nesto)
		{
			Console.WriteLine($"Cuo sam {nesto}");
		}
	}
	class Diktafon
	{
		public Diktafon(Predavac p)
		{
			p.GovorDelegat += Snimaj;
		}
		public void Snimaj(string bla) => Console.WriteLine("Diktafon sljaka");
	}

}
