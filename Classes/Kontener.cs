using Kontenerowce.Exceptions;
using Kontenerowce.Interfaces;

namespace Kontenerowce.Classes
{
    public abstract class Kontener : IKontener
    {
        public double masa { get; set; } = 0;
        public double wysokosc { get; set; }
        public double wagaWlasna { get; set; }
        public double glebokosc { get; set; }
        public double maxLadownosc { get; set; }

        private static int _lastId = 1;
        public string numerSeryjny { get; protected set; }

        public Kontener(double wysokosc, double wagaWlasna, double glebokosc, double maxLadownosc)
        {
            this.wysokosc = wysokosc;
            this.wagaWlasna = wagaWlasna;
            this.glebokosc = glebokosc;
            this.maxLadownosc = maxLadownosc;

            numerSeryjny = $"KON-{ZwrocTyp()}-{_lastId++}";
        }

        public virtual void Oproznij(double przelicznik=0)
        {
            masa*=przelicznik;
        }

        public virtual void Zaladuj(double nowaMasa, double przelicznik=1)
        {
            masa+=nowaMasa;

            if (masa > maxLadownosc*przelicznik)
            {
                masa-=nowaMasa;
                throw new OverfillException("Maksymalna ladownosc kontenera przekroczona");
            }
        }
        public override string ToString()
        {
            return
                $"{nameof(masa)}: {masa} kg, {nameof(wysokosc)}: {wysokosc} cm, {nameof(wagaWlasna)}: {wagaWlasna} kg, {nameof(glebokosc)}: {glebokosc} cm, {nameof(maxLadownosc)}: {maxLadownosc} kg, {nameof(numerSeryjny)}: {numerSeryjny}";
        }

        public abstract string ZwrocTyp();
    }
}