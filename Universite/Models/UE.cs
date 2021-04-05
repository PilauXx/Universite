using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class UE
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Intitule { get; set; }

        [Display(Name = "Formation")]
        public int? FormationID { get; set; }
        [Display(Name = "Formation")]
        public Formation formation { get; set; }

        // Lien de navigation ManyToMany 
        [Display(Name = "Enseignants de l’UE")] 
        public ICollection<Enseigner> LesEnseigner { get; set; }

        [Display(Name = "Notes de l’UE")]
        public ICollection<Note> LesNotes { get; set; }
    }
}
