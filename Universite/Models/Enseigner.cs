using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Enseigner
    {
        //Clé primaire 
        public int ID { get; set; } 
        //Lien de composition vers l'enseignant 
        public int LEnseignantID {get; set;} 
        public Enseignant LEnseignant { get; set; } 

        //Lien de composition vers l'UE 
        public int LUEID { get; set; } 
        public UE LUE { get; set; }

    }
}
