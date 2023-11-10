using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinique.Pages.Prescriptions
{
    public class IndexModel : PageModel
    {
        private readonly GHContext _context;

        public IndexModel(GHContext context)
        {
            _context = context;
        }


         [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DossierPatientGenre { get; set; }

        public IList<Prescription> Prescription { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Prescription != null)
            {
                Prescription = await _context.Prescription
                .Include(p => p.Consultation).ToListAsync();
            }
        }
    }
}
