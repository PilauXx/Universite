using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite.Models;

namespace Universite.VueModel
{
    public class VueModelEtudNote
    {
        public UE Ue { get; set; }
        public Etudiant Etudiant { get; set; }
        public Note Note { get; set; }

        public String NoteToString
        {
            get {
                if (Note == null)
                    return "";
                else
                   return Note.Valeur.ToString();
            }
        }
    }
}
