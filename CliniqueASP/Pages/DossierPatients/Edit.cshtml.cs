using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;

namespace Clinique.Pages.DossierPatients
{
    public class EditModel : PageModel
    {
        private readonly GHContext _context;

        public EditModel(GHContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DossierPatient DossierPatient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DossierPatient == null)
            {
                return NotFound();
            }

            var dossierpatient =  await _context.DossierPatient.FirstOrDefaultAsync(m => m.Code == id);
            if (dossierpatient == null)
            {
                return NotFound();
            }
            DossierPatient = dossierpatient;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DossierPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierPatientExists(DossierPatient.Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DossierPatientExists(int id)
        {
          return (_context.DossierPatient?.Any(e => e.Code == id)).GetValueOrDefault();
        }
    }
}
