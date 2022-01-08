using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Models
{
    public class Echipa
    {
        public int EchipaID { get; set; }
        public int ConferintaID { get; set;}
        public string nume_echipa { get; set;}

        public ICollection<Antrenor> Antrenori { get; set; }
        public ICollection<Jucator> Jucatori { get; set; }

        public Conferinta conferinta { get; set; }
    }
}