using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220920
{
    internal class Kuldetes
    {
        //prop + tab + tab
        public string Kod { get; set; }
        public DateOnly KilovesNapja { get; set; }
        public string SikloNeve { get; set; }
        private int KuldetesenToltottNap { get; set; }
        private int KuldetesenToltottOra { get; set; }
        public int KuldetesHossza => 
            KuldetesenToltottNap * 24 + KuldetesenToltottOra;
        public string ErkezesHelye { get; set; }
        public int UtasokSzama { get; set; }

        //ctor + tab + tab
        public Kuldetes(string fileEgySora)
        {
            var adattagok = fileEgySora.Split(';');
            Kod = adattagok[0];
            KilovesNapja = DateOnly.Parse(adattagok[1]);
            SikloNeve = adattagok[2];
            KuldetesenToltottNap = int.Parse(adattagok[3]);
            KuldetesenToltottOra = int.Parse(adattagok[4]);
            ErkezesHelye = adattagok[5];
            UtasokSzama = int.Parse(adattagok[6]);
        }
    }
}
