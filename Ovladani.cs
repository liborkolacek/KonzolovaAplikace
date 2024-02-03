using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    internal class Ovladani
    {
        public void HlavniOvladani()
        {
            // instance uzivatelského rozhraní
            UzivatelskeRozhrani rozhrani = new UzivatelskeRozhrani();
            char volba = '0';
            // Hlavní cyklus
            while (volba != '4')
            {
                rozhrani.VypisUvodniObrazovku();
                Console.WriteLine();
                Console.WriteLine("Vyberte si akci:");
                Console.WriteLine("1 - Pridat nového pojištěného");
                Console.WriteLine("2 - Vypsat všechny pojištěné");
                Console.WriteLine("3 - Vyhledat pojištěného");
                Console.WriteLine("4 - Konec");
                volba = Console.ReadKey().KeyChar;
                Console.WriteLine();
                // reakce na vybranou operaci
                switch (volba)
                {
                    case '1':
                        rozhrani.PridejZaznam();
                        break;
                    case '2':
                        rozhrani.VypsatZaznamy();
                        break;
                    case '3':
                        rozhrani.NajdiZaznam();
                        break;
                    case '4':
                        Console.WriteLine("Libovolnou klávesou ukončíte program...");
                        break;
                    default:
                        Console.WriteLine("Neplatná volba, stiskni libovolnou klávesu a opakujte volbu.");
                        break;
                }
                Console.ReadKey();
            }
        }    
    }
}
