using System;
using System.Collections.Generic;
using System.IO;
using Kontenerowce.Exceptions;

namespace Kontenerowce.Classes;

public class KontenerChlodniczy : Kontener
{
    public string Zawartosc { get; set; }
    public double Temperatura { get; set; }
    
    public static Dictionary<String, Double> temperatury = new Dictionary<String, Double>()
    {
        ["Bananas"] = 13.3,
        ["Chocolate"] = 18,
        ["Fish"] = 2,
        ["Meat"] = -15,
        ["Ice cream"] = -18,
        ["Frozen pizza"] = -30,
        ["Cheese"] = 7.2,
        ["Sausages"] = 5,
        ["Butter"] = 20.5,
        ["Eggs"] = 19
    };
    
    public KontenerChlodniczy(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc, string zawartosc, double temperatura) : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc)
    {
        if (temperatury.ContainsKey(zawartosc) && temperatury[zawartosc] >= temperatura)
        {
            Zawartosc = zawartosc;
            Temperatura = temperatura;
        }
        else
        {
            throw new InvalidDataException();
        }
    }

    public override string ZwrocTyp()
    {
        return "C";
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}\n  {nameof(Zawartosc)}: {Zawartosc}\n  {nameof(Temperatura)}: {Temperatura}";
    }
}