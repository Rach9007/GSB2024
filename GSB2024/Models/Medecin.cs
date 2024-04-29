using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSB2024.Models
{
    public partial class Medecin
    {
        public int IdMedecin { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Adresse { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public int IdSpecialite { get; set; }
        public string IdDepartement { get; set; } = null!;

    
        public virtual Departement? IdDepartementNavigation { get; set; } = null!;
       
        public virtual Specialite? IdSpecialiteNavigation { get; set; } = null!;
    }
}
