using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.UEs
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public CreateModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FormationID"] = new SelectList(_context.Formation, "ID", "Intitule");
            return Page();
        }

        [BindProperty]
        public UE UE { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UE.Add(UE);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
