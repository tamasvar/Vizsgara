using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class Versenyzo
    {
        public Versenyzo()
        {
            Versenyszamoks = new HashSet<Versenyszamok>();
            Versenyzoorszags = new HashSet<Versenyzoorszag>();
        }

        public int VersenyzoId { get; set; }
        public string Nev { get; set; }
        public int Eletkor { get; set; }

        public virtual ICollection<Versenyszamok> Versenyszamoks { get; set; }
        public virtual ICollection<Versenyzoorszag> Versenyzoorszags { get; set; }
    }
}
