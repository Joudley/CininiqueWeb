using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hopital.Model;

namespace Clinique.Pages.Prescriptions
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
        ViewData["ConsultationId"] = new SelectList(_context.Consultation, "ConsultationId", "ConsultationId");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Prescription == null || Prescription == null)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
