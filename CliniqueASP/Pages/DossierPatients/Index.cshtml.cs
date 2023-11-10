using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinique.Pages.DossierPatients
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

        public IList<DossierPatient> DossierPatient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var searching = from m in _context.DossierPatient select m;

            if (_context.DossierPatient != null)
            {
                if (!string.IsNullOrEmpty(SearchString)){

                searching = searching.Where(s => s.Nom.ToLower().Contains(SearchString.ToLower()));
                DossierPatient = searching.ToList();
                    
                }else {

           
               DossierPatient = await _context.DossierPatient.ToListAsync();
             }
        }
    }
    }

}
