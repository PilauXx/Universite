using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;
using Universite.VueModel;

namespace Universite.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        [BindProperty]
        public Enseigner Enseigner { get; set; }
        public List<Etudiant> Etudiant { get; set; }

        public List<Note> Note { get; set; }

        [BindProperty]
        public List<VueModelEtudNote> EtudiantNotes { get; set; }

        public EditModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["LUEID"] = new SelectList(_context.UE, "ID", "Intitule");
            Etudiant = await _context.Etudiant
                .Include(e => e.FormationSuivie)
                .ToListAsync();
            EtudiantNotes = new List<VueModelEtudNote>();
            return Page();
        }

        public async Task<IActionResult> OnPostFirstAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int choise = Enseigner.LUEID;
            UE ue = await _context.UE.FindAsync(choise);
            EtudiantNotes = new List<VueModelEtudNote>();

            Etudiant = await _context.Etudiant
                .Include(e => e.FormationSuivie).Where(e => e.FormationSuivie.UEdansFormation.Contains(ue))
                .ToListAsync();
            Note = await _context.Note
                .Include(e => e.LUE).Where(e => e.LUE.Equals(ue))
                .ToListAsync();

            foreach(Etudiant e in Etudiant)
            {
                VueModelEtudNote etuNote = new VueModelEtudNote();
                etuNote.Ue = ue;
                etuNote.Etudiant = e;

                etuNote.Note = Note.Find(x => x.etudiant.Equals(e));              

                EtudiantNotes.Add(etuNote);
            }            
            return Page();
        }

      public async Task<IActionResult> OnPostSecondAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (VueModelEtudNote e in EtudiantNotes)
            {
                Note note = new Note();
                if(!e.Note.Equals(null))
                {
                    note = e.Note;
                    if (e.Note.etudiant.Equals(null))
                    {
                        note.LUE = e.Ue;
                        note.etudiant = e.Etudiant;
                    }
                    _context.Note.Add(note); 
                }
            }
            await _context.SaveChangesAsync();

            return Page();
        }


    }
}
