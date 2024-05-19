using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauracja
{
    public class PosilkiModel
    {
        public required uint ID { get; set; }
        //uint w celu unikniecia ujemnych wartosci
        public required string Nazwa { get; set; }
        public required float Cena { get; set; }
    }

    public class DeserModel : PosilkiModel
    {
        //Klasa dziedziczy po PosilkiModel i zawiera pola ID, Nazwa, Cena
        public float Gramatura { get; set; }
        public string Opis { get; set; }
    }
}
