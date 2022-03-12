using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{

    class Osoba
    {
        public string Imie;
        public string Nazwisko;
    }

    internal class Konto
    {
        public Osoba Wlasciciel;
        private decimal saldo = 0;
        private int pin = 0;

        private bool SprawdzPin(int pin)
        {
            if (this.pin == pin) return true;
            return false;
        }

        public void DokonajWplaty(int pin, decimal kwota)
        {
            if (SprawdzPin(pin))
            {
                if (kwota < 0) throw new ArgumentException("Wpłacona kwota nie może być mniejsza od zera.");
                saldo += kwota;
            }
            else Console.WriteLine("Podałeś nieprawidłowy PIN!");
        }

        public string DokonajWyplaty(int pin, decimal kwota)
        {
            if (!SprawdzPin(pin) || saldo < kwota) return "Operacja anulowana.";
            saldo -= kwota;
            return "Operacja zakończona pomyślnie.";
        }

        public bool ZmienPin(int nowy, int stary)
        {
            if (SprawdzPin(stary))
            {
                pin = nowy;
                return true;
            }
            return false;
        }

        public string PobierzInformacje(int pin)
        {
            if (SprawdzPin(pin)) return string.Format("Pan/Pani {0} {1} posiada na koncie {2} zł.", Wlasciciel.Imie, Wlasciciel.Nazwisko, saldo);
            return "Brak dostępu.";
        }
    }
}
