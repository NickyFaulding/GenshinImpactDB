using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages.ArtifactCMS
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CurrentSetFilter { get; set; }

        public IList<Artifact> Artifact { get; set; }

        public IList<ArtifactSet> ArtifactSet { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchStringSet)
        {
            IQueryable<Artifact> artifactIQ = from a in _context.AllArtifacts
                                              select a;

            CurrentSetFilter = searchStringSet;

            if (!String.IsNullOrEmpty(searchStringSet))
            {
                artifactIQ = artifactIQ.Where(a => a.SetName.Contains(searchStringSet));
            }

            ArtifactSet = await _context.ArtifactSets.ToListAsync();
            Artifact = await artifactIQ.AsNoTracking().ToListAsync();
        }
    }
}
