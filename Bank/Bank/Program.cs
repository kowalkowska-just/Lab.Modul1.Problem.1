using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * PROBLEM 1 - Twoja firma opracowuje program dla banku. Twoim zadaniem jest stworzenie i przetestowanie klasy Konto.
 * Klasa Konto posiada następujące pola: Wlasciciel (typu Osoba (Imie, Nazwisko)), saldo (typu decimal), pin (typu int). 
 * Pola saldo i pin powinny być zainicjalizowane wartością zero. Pole pin można zmienić tylko podając obecną wartość pola. 
 * Wypłatę z konta (zminiejszenie wartości pola saldo) można uzyskać tylko po podaniu prawidłowego PIN-u. Na koncie nie można zrobić debetu. 
 * Dodaj metodę, która zwraca informacje o koncie, oczywiście pod warunkiem, że został podany prawidłowy PIN. 
 */

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Konto[] konto = new Konto[2];

            konto[0] = new Konto();
            konto[0].Wlasciciel = new Osoba();
            konto[0].Wlasciciel.Imie = "Justyna";
            konto[0].Wlasciciel.Nazwisko = "Kowalkowska";

            konto[1] = new Konto();
            konto[1].Wlasciciel = new Osoba();
            konto[1].Wlasciciel.Imie = "Jan";
            konto[1].Wlasciciel.Nazwisko = "Kowalski";

            Console.WriteLine("Próba zmiany pinu: {0}", konto[0].ZmienPin(1111, 0));
            Console.WriteLine("Próba zmiany pinu: {0}", konto[1].ZmienPin(1111, 1111));

            Console.WriteLine("Dokonujemy wpłaty:");
            konto[0].DokonajWplaty(1111,1200);
            konto[1].DokonajWplaty(0,2000);

            Console.WriteLine("Dokonujemy wypłaty: {0}", konto[0].DokonajWyplaty(1111, 300));
            Console.WriteLine("Dokonujemy wypłaty: {0}", konto[0].DokonajWyplaty(1111, 3000));
            Console.WriteLine("Dokonujemy wypłaty: {0}", konto[1].DokonajWyplaty(1111, 200));

            Console.WriteLine("Informacje o koncie: {0}", konto[0].PobierzInformacje(1111));
            Console.WriteLine("Informacje o koncie: {0}", konto[1].PobierzInformacje(1111));
            Console.WriteLine("Informacje o koncie: {0}", konto[1].PobierzInformacje(0));

            Console.ReadKey();
        }
    }
}
