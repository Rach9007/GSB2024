using System;
using System.Collections.Generic;

namespace GSB2024.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Medecins = new HashSet<Medecin>();
        }

        public string IdDepartement { get; set; } = null!;
        public string? NomDepartement { get; set; }
        public string? CodeRegion { get; set; }
        public string? NomRegion { get; set; }

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}
