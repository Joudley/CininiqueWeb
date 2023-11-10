using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;

namespace Clinique.Pages.Medecins
{
    public class EditModel : PageModel
    {
        private readonly GHContext _context;

        public EditModel(GHContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medecin Medecin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medecin == null)
            {
                return NotFound();
            }

            var medecin =  await _context.Medecin.FirstOrDefaultAsync(m => m.MedecinId == id);
            if (medecin == null)
            {
                return NotFound();
            }
            Medecin = medecin;
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

            _context.Attach(Medecin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(Medecin.MedecinId))
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

        private bool MedecinExists(int id)
        {
          return (_context.Medecin?.Any(e => e.MedecinId == id)).GetValueOrDefault();
        }
    }
}
