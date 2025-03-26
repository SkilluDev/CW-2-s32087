using System;
using Kontenerowce.Exceptions;
using Kontenerowce.Interfaces;

namespace Kontenerowce.Classes;

public class KontenerNaPlyn : Kontener, IHazardNotifier
{
    public bool CzyNiebezpieczny { get; set; }
    
    public KontenerNaPlyn(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, bool czyNiebezpieczny) : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc)
    {
        CzyNiebezpieczny = czyNiebezpieczny;
    }

    public override void Zaladuj(double nowaMasa, double przelicznik = 1 )
    {
        try
        {
            if (CzyNiebezpieczny)
            {
                base.Zaladuj(nowaMasa, 0.5);
            }
            else
            {
                base.Zaladuj(nowaMasa, 0.9);
            }
        }
        catch (OverfillException e)
        {
            Poinformuj();
            throw e;
        }
    }

    public override string ZwrocTyp()
    {
        return "L";
    }

    public void Poinformuj()
    {
        Console.WriteLine("Sprobowano wykonac niebezpieczna operacje na kontenerze z plynem.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}\n  {nameof(CzyNiebezpieczny)}: {CzyNiebezpieczny}";
    }
}