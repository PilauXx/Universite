using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DeleteModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enseigner Enseigner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enseigner = await _context.Enseigner
                .Include(e => e.LEnseignant)
                .Include(e => e.LUE).FirstOrDefaultAsync(m => m.ID == id);

            if (Enseigner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enseigner = await _context.Enseigner.FindAsync(id);

            if (Enseigner != null)
            {
                _context.Enseigner.Remove(Enseigner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Enseignement/Index", new { id = Enseigner.LEnseignantID });
        }
    }
}
