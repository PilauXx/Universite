using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Formation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Intitule { get; set; }
 
        public ICollection<Etudiant> EtudiantsInscrits { get; set; }

        public ICollection<UE> UEdansFormation { get; set; }

        [Display(Name = "Nombre d'inscrits")]
        public int NbInscrits
        {
            get
            {
                if (EtudiantsInscrits != null)
                    return EtudiantsInscrits.Count;
                else 
                    return -1;
            }
        }

        [Display(Name = "Nombre d'UE dans la formation")]
        public int NbUE
        {
            get
            {
                if (UEdansFormation != null)
                    return UEdansFormation.Count;
                else
                    return -1;
            }
        }
    }
}
