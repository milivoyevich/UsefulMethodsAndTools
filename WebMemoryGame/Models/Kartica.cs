using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMemoryGame.Models
{
    public class Kartica
    {
        public int id { get; set; }
        public string shifra {get; set;}
        public string tekst { get; set; }
        public string slika { get; set; }
        public bool otvorena { get; set; }
        public bool aktivna { get; set; }
    }
}