using System;
using System.Collections.Generic;

namespace GSB2024.Models
{
    public partial class Specialite
    {
        public Specialite()
        {
            Medecins = new HashSet<Medecin>();
        }

        public int IdSpecialite { get; set; }
        public string LibelleSpecialite { get; set; } = null!;

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}
