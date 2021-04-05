using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Enseignant
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        //Lien ManyToMany 
        [Display(Name = "UEs Enseignées")] 
        public ICollection<Enseigner> LesEnseigner {get; set;}

        public string NomComplet { 
            get { 
                return Nom + " " + Prenom; 
            } 
        }
    }
}
