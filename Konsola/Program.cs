namespace Konsola
{
    public class Program
    {
        static void Main()
        {
            Kalkulator k1 = new Kalkulator(67, true, true);
            Kalkulator k2 = new Kalkulator(3600, false, false);

            Console.WriteLine($"1 osoba: brutton = {k1.kwotaBrutto}, netto = {k1.KwotaNetto()}");
            Console.WriteLine($"2 osoba: brutton = {k2.kwotaBrutto}, netto = {k2.KwotaNetto()}");
        }
    }

    /********************************************************
    * nazwa klasy: Kalkulator
    * opis klasy: Klasa licząca kwotę netto z brutto
    * pola: kwotaBrutto, czyZlecenie, czyUlga
    * autor: Wiktor Lutowski
    ********************************************************/

    public class Kalkulator
    {
        public float kwotaBrutto;
        bool czyZlecenie;
        bool czyUlga;

        public Kalkulator(float kwotaBrutto, bool czyZlecenie, bool czyUlga)
        {
            this.kwotaBrutto = kwotaBrutto;
            this.czyZlecenie = czyZlecenie;
            this.czyUlga = czyUlga;
        }

        public float SkladkaZus()
        {
            return (float)Math.Round(kwotaBrutto * 0.1371f, 2);
        }

        public float SkladkaZdrowotna()
        {
            return (float)Math.Round((kwotaBrutto - SkladkaZus()) * 0.09f, 2);
        }

        public float ZaliczkaPit()
        {
            if (czyUlga)
                return 0;
            else
                return (float)Math.Round((kwotaBrutto - SkladkaZus()) * 0.12f, 2);
        }

        public float KwotaNetto()
        {
            return (float)Math.Round(kwotaBrutto - SkladkaZus() - SkladkaZdrowotna() - ZaliczkaPit(),2);
        }

        public bool CzyPoprawne()
        {
            if (kwotaBrutto > 0)
                return true;
            else
                return false;
        }
    }
}
