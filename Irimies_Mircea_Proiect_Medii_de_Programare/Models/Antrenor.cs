using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Models
{
    public class Antrenor
    {
        public int AntrenorID { get; set; }
        public int EchipaID { get; set; }

        public string nume { get; set; }
        public string prenume { get; set; }
        public DateTime data_nasterii { get; set; }
        public string statut { get; set; }

        public Echipa echipa { get; set; }

    }
}
