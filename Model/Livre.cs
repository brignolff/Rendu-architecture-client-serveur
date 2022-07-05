using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Livre
    {
        public int IdLivre { get; set; }
        public string Titre { get; set; } = null!;
        public double Prix { get; set; }
        public int IdAuteur { get; set; }
        public string Genre { get; set; } = null!;
    }
}
