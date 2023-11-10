using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinique.Pages.Medecins
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

        public IList<Medecin> Medecin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var searching = from m in _context.Medecin select m;

            if (_context.Medecin != null)
            {
                if (!string.IsNullOrEmpty(SearchString)){

                searching = searching.Where(s => s.Specialite.ToLower().Contains(SearchString.ToLower()));
                Medecin = searching.ToList();
                    
                }else {
                    
        
                Medecin = await _context.Medecin.ToListAsync();
            }
        }
        }
}
}
