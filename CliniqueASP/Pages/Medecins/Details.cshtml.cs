using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;

namespace Clinique.Pages.Medecins
{
    public class DetailsModel : PageModel
    {
        private readonly GHContext _context;

        public DetailsModel(GHContext context)
        {
            _context = context;
        }

      public Medecin Medecin { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medecin == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin.FirstOrDefaultAsync(m => m.MedecinId == id);
            if (medecin == null)
            {
                return NotFound();
            }
            else 
            {
                Medecin = medecin;
            }
            return Page();
        }
    }
}
