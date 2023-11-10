using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hopital.Model;

namespace Clinique.Pages.DossierPatients
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
            return Page();
        }

        [BindProperty]
        public DossierPatient DossierPatient { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DossierPatient == null || DossierPatient == null)
            {
                return Page();
            }

            _context.DossierPatient.Add(DossierPatient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
