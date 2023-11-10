using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;

namespace Clinique.Pages.DossierPatients
{
    public class DetailsModel : PageModel
    {
        private readonly GHContext _context;

        public DetailsModel(GHContext context)
        {
            _context = context;
        }

      public DossierPatient DossierPatient { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DossierPatient == null)
            {
                return NotFound();
            }

            var dossierpatient = await _context.DossierPatient.FirstOrDefaultAsync(m => m.Code == id);
            if (dossierpatient == null)
            {
                return NotFound();
            }
            else 
            {
                DossierPatient = dossierpatient;
            }
            return Page();
        }
    }
}
