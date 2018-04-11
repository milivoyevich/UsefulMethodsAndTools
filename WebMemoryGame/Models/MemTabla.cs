using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMemoryGame.Models
{
    public class MemTabla
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public int rang { get; set; }
        public bool resena { get; set; }
        public bool aktivna { get; set; }
        public IList<Kartica> lista { get; set; } = new List<Kartica>();
    }
}