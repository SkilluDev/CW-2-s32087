using System;
using System.Collections.Generic;
using Kontenerowce.Classes;

namespace Kontenerowce
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Kontenerowiec kontenerowiec = new Kontenerowiec(123, 13, 5.5);
            Kontenerowiec kontenerowiec2 = new Kontenerowiec(255, 2, 10);
            Kontener kontenerPlyn= new KontenerNaPlyn( 180, 12, 135, 650, true);
            kontenerPlyn.Zaladuj(100);
            Console.WriteLine("Po zaladowaniu\n");
            Console.WriteLine(kontenerPlyn);
            kontenerPlyn.Oproznij();
            Console.WriteLine("Po oproznieniu\n");
            Console.WriteLine(kontenerPlyn);
            Kontener kontenerChlod = new KontenerChlodniczy(180, 12, 135, 650, "Bananas", 13);
            kontenerChlod.Zaladuj(200);
            Kontener kontenerGaz = new KontenerNaGaz(180, 12, 135, 650);
            kontenerGaz.Zaladuj(300);
            
            
            kontenerowiec2.ZaladujKontener(kontenerPlyn);
            kontenerowiec2.ZastapKontener("KON-L-1",kontenerChlod);
            kontenerowiec2.ZaladujKontenery(new List<Kontener>(){kontenerPlyn});

            kontenerowiec.ZaladujKontener(kontenerGaz);
            
            Console.WriteLine(kontenerowiec);
            Console.WriteLine(kontenerowiec2);

            
            kontenerowiec2.PrzeniesNaKontenerowiec(kontenerPlyn, kontenerowiec);
            kontenerowiec2.PrzeniesNaKontenerowiec(kontenerChlod, kontenerowiec);

            Console.WriteLine(kontenerowiec);
            Console.WriteLine(kontenerowiec2);
        }
    }
}