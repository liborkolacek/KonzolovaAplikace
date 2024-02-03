using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    /// <summary>
    /// Třída predstavující komunikaci s uživatelem
    /// </summary>
    internal class UzivatelskeRozhrani
    {
        private EvidenceDat evidenceDat;

        public UzivatelskeRozhrani()
        {
            evidenceDat = new EvidenceDat();
        }
        /// <summary>
        /// Vypíše úvodní obrazovku
        /// </summary>
        public void VypisUvodniObrazovku()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("     Evidence pojištěných");
            Console.WriteLine("------------------------------");
        }
        /// <summary>
        /// Metoda pro zadání jména
        /// </summary>
        /// <returns>Vrátí křestní jméno uživatele</returns>
        private string ZjistiJmeno()
        {
            string jmeno;

            do
            {
                Console.WriteLine("Zadejte jméno pojištěného: ");
                jmeno = Console.ReadLine();

                if (int.TryParse(jmeno, out _)) // _ operátor zahození
                {
                    Console.WriteLine("Chybné zadání, zadejte platné jméno znovu: ");
                }
                else if (string.IsNullOrWhiteSpace(jmeno))
                {
                    Console.WriteLine("Chybné zadání, jméno nesmí být prázdné. Zkuste to znovu.");
                }
                else
                {
                    break;
                }
            } while (true);

            return jmeno;
        }
        /// <summary>
        /// Metoda pro získání příjmení uživatele
        /// </summary>
        /// <returns>vrátí příjmení uživatele</returns>
        private string ZjistiPrijmeni()
        {
            string prijmeni;

            do
            {
                Console.WriteLine("Zadejte příjmení pojištěného: ");
                prijmeni = Console.ReadLine();

                if (int.TryParse(prijmeni, out _))
                {
                    Console.WriteLine("Chybné zadání, zadejte platné příjmení znovu: ");
                }
                else if (string.IsNullOrWhiteSpace(prijmeni))
                {
                    Console.WriteLine("Chybné zadání, jméno nesmí být prázdné. Zkuste to znovu.");
                }
                else
                {
                    break;
                }
            } while (true);

            return prijmeni;
        }
        /// <summary>
        /// Metoda pro získání tel. čísla
        /// </summary>
        /// <returns>vrátí tel. číslo duživatele</returns>
        private string ZjistiTelefonniCislo()
        {
            int maximalniDelka = 13;
            int minimalniDelka = 9;
            string telefonniCislo;
            do
            {
                Console.WriteLine("Zadejte telefonní číslo: ");
                telefonniCislo = Console.ReadLine();

                if (telefonniCislo.Length < minimalniDelka)
                {
                    Console.WriteLine("Požadovaná délka telefonního čísla (9) je příliš krátka. Zadajte prosím tel. číslo znova");
                }
                else if (telefonniCislo.Length > maximalniDelka)
                {
                    Console.WriteLine("Zadané telefonní číslo je delší než povolený počet znaků (13). Zadejte prosím tel. číslo znova.");
                }
                else
                {
                    break;
                }
            } while (true);
            return telefonniCislo;
        }
        /// <summary>
        /// Metoda pro získání věku užívatele
        /// </summary>
        /// <returns>vrátí věk uživatele</returns>
        private int ZjistiVek()
        {
            int vek;
            do
            {
                Console.WriteLine("Zadejte věk: ");
                string vstup = Console.ReadLine();
                if (int.TryParse(vstup, out vek))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Chybné zadání, zadejte věk znovu.");
                }
            } while (true);
            return vek;
        }

        /// <summary>
        /// Komunikace s uživatelem (přidá záznam)
        /// </summary>
        public void PridejZaznam()
        {
            string jmeno = ZjistiJmeno();
            string prijmeni = ZjistiPrijmeni();
            string telefonniCislo = ZjistiTelefonniCislo();
            int vek = ZjistiVek();
            evidenceDat.PridejZaznam(jmeno, prijmeni, telefonniCislo, vek);
            Console.WriteLine("Data byla uložena. Pokračujte libovolnou klávesou...");
        }

        /// <summary>
        /// Komunikace s uživatelem (Najde zaznam podle jména a přijmení)
        /// </summary>
        public void NajdiZaznam()
        {
            // zadaní data uživatelem
            string jmeno = ZjistiJmeno();
            // zadaní data uživatelem
            string prijmeni = ZjistiPrijmeni();
            Console.WriteLine(); // odřádkovaní
            List<Zaznam> zaznamy = evidenceDat.NajdiZaznam(prijmeni, false);
            // vypis zaznamu
            if (zaznamy.Count() > 0)
            {
                foreach (Zaznam z in zaznamy)
                {
                    Console.WriteLine(z);
                }
            }
            else
                //Nenalezeno
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
            Console.WriteLine();
            Console.WriteLine("Pro pokračování stiskni libovolnou klávesu...");
        }

        /// <summary>
        /// Vypíše vsechny záznamy
        /// </summary>
        /// <param name="zaznamy"></param>
        public void VypsatZaznamy()
        {
            foreach (Zaznam z in evidenceDat.Zaznamy())
            {
                Console.WriteLine(z);
            }
            Console.WriteLine();
            Console.WriteLine("Pro pokračování stiskni libovolnou klávesu...");
        }
    }
}
