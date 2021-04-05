using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public float Valeur { get; set; }

        public Etudiant etudiant { get; set; }

        //Lien de composition vers l'UE 
        public int LUEID { get; set; }
        public UE LUE { get; set; }

    }
}

