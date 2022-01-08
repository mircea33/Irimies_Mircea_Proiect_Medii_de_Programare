using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Models.TeamViewModels
{
    public class ConferintaIndexData
    {
        public IEnumerable<Conferinta> Conferinte { get; set; }
        public IEnumerable<Echipa> Echipe { get; set; }
        public IEnumerable<Jucator> Jucatori { get; set; }
    }
}
