using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Irimies_Mircea_Proiect_Medii_de_Programare.Models;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Data
{
    public class DbInitializer
    {
        public static void Initialize(TeamContext context)
        {
            context.Database.EnsureCreated(); 
         //   if (context.Jucators.Any())
        //    {
         //       return; // BD a fost creata anterior
          //  }

            var conferinte = new Conferinta[]
            {
                new Conferinta{nume_divizie="Eastern Conference",ConferintaID = 1000},
                new Conferinta{nume_divizie="Western Conference",ConferintaID = 1001},
            };
            foreach (Conferinta d in conferinte)
            {
                context.Conferintas.Add(d);
            }
                context.SaveChanges();

            var echipe = new Echipa[]
            {
  new Echipa{nume_echipa="Los Angeles Lakers", EchipaID = 1011, ConferintaID = 1000 },
  new Echipa{nume_echipa="Golden State Warriors", EchipaID = 1012, ConferintaID = 1000},
  new Echipa{nume_echipa="Miami Heat", EchipaID = 1013, ConferintaID = 1001},
            };
            foreach (Echipa e in echipe)
            {
                context.Echipas.Add(e);
            }
            context.SaveChanges();
          
            var jucatori = new Jucator[]
            {
  new Jucator{nume="Lebron",prenume="James", inaltime=(float)1.98, greutate=(int)98,
     data_nasterii=DateTime.Parse("1979-09-01"), pozitie="Power forward", EchipaID = 1011},
  new Jucator{nume="Curry",prenume="Stephen", inaltime=(float)1.90, greutate=(int)85,
     data_nasterii=DateTime.Parse("1985-10-01"), pozitie="Shooting guard", EchipaID = 1011},
  new Jucator{nume="Durant",prenume="Kevin", inaltime=(float)2.03, greutate=(int)95,
     data_nasterii=DateTime.Parse("1987-09-12"), pozitie="Small forward",EchipaID = 1012},
  new Jucator{nume="Davis",prenume="Anthony", inaltime=(float)2.10, greutate=(int)105,
     data_nasterii=DateTime.Parse("1990-03-01"), pozitie="Power forward", EchipaID = 1012},
  new Jucator{nume="Thompson",prenume="Klay", inaltime=(float)1.87, greutate=(int)85,
     data_nasterii=DateTime.Parse("1987-10-10"), pozitie="Shooting guard", EchipaID = 1013},
  new Jucator{nume="Lillard",prenume="Damian", inaltime=(float)1.83, greutate=(int)80,
     data_nasterii=DateTime.Parse("1993-09-09"), pozitie="Small forward",EchipaID = 1013},
            };
            foreach (Jucator j in jucatori)
            {
                context.Jucators.Add(j);
            }
            context.SaveChanges();

            var antrenori = new Antrenor[]
            {
                new Antrenor{nume = "Popovici", prenume="Greg", data_nasterii=DateTime.Parse("1960-07-04"), statut="Head coach", EchipaID = 1011},
                new Antrenor{nume = "Spoulstra", prenume="Eric", data_nasterii=DateTime.Parse("1975-06-02"), statut="Head coach", EchipaID = 1012},
                new Antrenor{nume = "Reily", prenume="Pat", data_nasterii=DateTime.Parse("1955-05-10"), statut="Assistent coach", EchipaID = 1013},
            };
            foreach (Antrenor a in antrenori)
            {
                context.Antrenors.Add(a);
            }
        }
    }
}