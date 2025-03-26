namespace Kontenerowce.Interfaces
{
    public interface IKontener
    {
        void Oproznij(double przelicznik=0);
        void Zaladuj(double nowaMasa, double przelicznik=1);
    }
}