using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hopital.Model;

namespace Clinique.Pages.Consultations
{
    public class CreateModel : PageModel
    {
        private readonly GHContext _context;

        public CreateModel(GHContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MedecinId"] = new SelectList(_context.Medecin, "MedecinId", "MedecinId");
            return Page();
        }

        [BindProperty]
        public Consultation Consultation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Consultation == null || Consultation == null)
            {
                return Page();
            }

            _context.Consultation.Add(Consultation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
