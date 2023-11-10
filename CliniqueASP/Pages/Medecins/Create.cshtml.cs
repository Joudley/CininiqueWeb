using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hopital.Model;

namespace Clinique.Pages.Medecins
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
        public Medecin Medecin { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Medecin == null || Medecin == null)
            {
                return Page();
            }

            _context.Medecin.Add(Medecin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
