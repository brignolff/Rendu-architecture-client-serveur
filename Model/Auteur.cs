using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Auteur
    {
        public Auteur()
        {
        }

        public int IdAuteur { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public DateTime? DateNaissance { get; set; }
    }
}
