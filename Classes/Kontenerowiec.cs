using System;
using System.Collections.Generic;
using System.Linq;
using Kontenerowce.Exceptions;

namespace Kontenerowce.Classes
{
    public class Kontenerowiec
    {
        public Kontenerowiec(double maxPredkosc, int maxIloscKontenerow, double maxWagaKontenerow)
        {
            Kontenery = new List<Kontener>();
            MaxPredkosc = maxPredkosc;
            MaxIloscKontenerow = maxIloscKontenerow;
            MaxWagaKontenerow = maxWagaKontenerow;
        }

        private List<Kontener> Kontenery { get; }
        public double MaxPredkosc { get; set; }
        public int MaxIloscKontenerow { get; set; }
        public double MaxWagaKontenerow { get; set; }

        private double AktualnaWagaKontenerow { get; set; } = 0;
        private double AktualnaIloscKontenerow { get; set; } = 0;


        public void ZaladujKontener(Kontener kontener)
        {
            if (AktualnaWagaKontenerow + kontener.wagaWlasna + kontener.masa < MaxWagaKontenerow * 1000 && AktualnaIloscKontenerow+1<=MaxIloscKontenerow)
            {
                Kontenery.Add(kontener);
                AktualnaWagaKontenerow+=kontener.wagaWlasna;
                AktualnaWagaKontenerow+=kontener.masa;
                AktualnaIloscKontenerow += 1;
            }
            else
            {
                throw new OverfillException("Kontenerowiec nie moze zmiescic kontenera");
            }
        }

        public void ZaladujKontenery(List<Kontener> kontenery)
        {
            foreach (var kontener in kontenery)
            {
                try
                {
                    ZaladujKontener(kontener);
                }
                catch (Exception e)
                {
                    break;
                }
            }
        }

        public bool UsunKontener(Kontener kontener)
        {
            if (Kontenery.Remove(kontener))
            {
                AktualnaIloscKontenerow -= 1;
                AktualnaWagaKontenerow-= kontener.wagaWlasna;
                AktualnaIloscKontenerow -= kontener.masa;
                return true;
            }
            return false;
        }

        public void ZastapKontener(string poprzednieId, Kontener nowyKontener)
        {
            foreach (var k in Kontenery)
            {
                if (k.numerSeryjny == poprzednieId)
                {
                    UsunKontener(k);
                    break;
                }
            }
            ZaladujKontener(nowyKontener);
        }
        
        public void PrzeniesNaKontenerowiec(Kontener kontener, Kontenerowiec kontenerowiec){
            if (UsunKontener(kontener))
            {
                kontenerowiec.ZaladujKontener(kontener);
            }
        }
        public string OpiszKontenery()
        {
            string result = string.Empty;
            for (int i = 0; i<Kontenery.Count;i++)
            {
                result += $"Kontener {i + 1}: {Kontenery.ElementAt(i)}\n ";
            }
            
            return result;
        }
        
        public override string ToString()
        {
            return
                $"Kontenerowiec:\n {nameof(Kontenery)}:\n\n {OpiszKontenery()}\n{nameof(MaxPredkosc)}: {MaxPredkosc} wezlow\n{nameof(MaxIloscKontenerow)}: {MaxIloscKontenerow}\n{nameof(MaxWagaKontenerow)}: {MaxWagaKontenerow} ton(y)\n";
        }
    }
}