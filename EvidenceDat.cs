using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    /// <summary>
    /// Třída představující databazi dat
    /// </summary>
    internal class EvidenceDat
    {
        /// <summary>
        /// Uložiště
        /// </summary>
        private List<Zaznam> zaznamy;
        /// <summary>
        /// Manimulace s daty
        /// </summary>
        public EvidenceDat()
        {
            zaznamy = new List<Zaznam>();
        }
        /// <summary>
        /// Přidání pojištěného do databáze
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="telefonniCislo"></param>
        public void PridejZaznam(string jmeno, string prijmeni, string telefonniCislo, int vek)
        {
            zaznamy.Add(new Zaznam(jmeno, prijmeni, telefonniCislo, vek));
        }
        /// <summary>
        /// Najít pojištěného
        /// </summary>
        /// <param name="jmenoPrijmeni"></param>
        /// <returns></returns>
        public List<Zaznam> NajdiZaznam(string dlePrijmeni, bool dleJmena)
        {
            List<Zaznam> nalezene = new List<Zaznam>();
            foreach (Zaznam z in zaznamy)
            {
                if (((dleJmena) && (z.Prijmeni.ToLower() == dlePrijmeni.ToLower())) // dle jména a příjmení
                ||
                ((!dleJmena) && (z.Prijmeni.ToLower() == dlePrijmeni.ToLower()))) // pouze dle přijmení
                    nalezene.Add(z);
            }
            return nalezene;
        }

        public List<Zaznam> Zaznamy()
        {
            return zaznamy;
        }
    }
}
