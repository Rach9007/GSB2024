using System;
using System.Collections.Generic;

namespace GSB2024.Models
{
    public partial class Utilsateur
    {
        public int IdUtilisateur { get; set; }
        public string Login { get; set; } = null!;
        public string MotDePasse { get; set; } = null!;
    }
}
