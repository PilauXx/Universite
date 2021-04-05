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
    public class IndexModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;
        public Enseignant Enseignant { get; set; }
        public int EnseignantID { get; set; }

        public IndexModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Enseigner> Enseigner { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            //Récupération de l'ID de l'enseignant dont on veut gérer les UEs 
            EnseignantID = (int)id;
            // Récupération des UEs de cet enseignant 
            Enseignant = _context.Enseignant.Find(id);
            // Récupération des UEs de cet enseignant 
            Enseigner = await _context.Enseigner 
                .Include(e => e.LEnseignant).Where(e => e.LEnseignant.ID == id) 
                .Include(e => e.LUE).ToListAsync();

            if(Enseigner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
