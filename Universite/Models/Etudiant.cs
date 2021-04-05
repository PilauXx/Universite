using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Etudiant
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        
        public string NumeroEtudiant { get; set; }

        [Display(Name = "Date naissance")]
        [DataType(DataType.Date)]
        public DateTime Naissance { get; set; }

        // Clé étrangère vers la formation suivie 
        // Porte le nom du lien de navigation suivi du nom de la clé primaire de Formation 
        public int? FormationSuivieID { get; set; }

        // Lien de navigation 
        public Formation FormationSuivie { get; set; }

        [Display(Name = "Notes")]
        public ICollection<Note> LesNotes { get; set; }
    }
}



