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

namespace Universite.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        [BindProperty]
        public Enseigner Enseigner { get; set; }
        public IList<Etudiant> Etudiant { get; set; }

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

            Etudiant = await _context.Etudiant
                .Include(e => e.FormationSuivie).Where(e => e.FormationSuivie.UEdansFormation.Contains(ue))
                .ToListAsync();
            
            return Page();
        }

/*        public async Task<IActionResult> OnPostSecondtAsync()
        {
            return await InsertCategory("Second");
        }*/

    }
}
