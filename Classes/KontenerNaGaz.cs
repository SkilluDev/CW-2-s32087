using System;
using Kontenerowce.Exceptions;
using Kontenerowce.Interfaces;

namespace Kontenerowce.Classes;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public KontenerNaGaz(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc) : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc)
    {
    }

    public override void Zaladuj(double nowaMasa, double przelicznik = 1)
    {
        try
        {
            base.Zaladuj(nowaMasa, przelicznik);
        }
        catch (OverfillException e)
        {
            Poinformuj();
            throw e;
        }
    }

    public override void Oproznij(double przelicznik)
    {
        przelicznik = 0.05;
        base.Oproznij(przelicznik);
    }
    
    public override string ZwrocTyp()
    {
        return "G";
    }

    public void Poinformuj()
    {
        Console.WriteLine("Sprobowano wykonac niebezpieczna operacje na kontenerze z gazem.");
    }
}