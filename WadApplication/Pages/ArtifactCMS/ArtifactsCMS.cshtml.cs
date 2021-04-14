using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WadApplication.Model;

namespace WadApplication.Pages.ArtifactCMS
{
    public class ArtifactsCMS : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public ArtifactsCMS(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public int[] pageItemsCount = {3, 6, 9, 18, 27 };
        public string CurrentSortOrder { get; set; }
        public int CurrentItemsCount { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSetFilter { get; set; }

        public PaginatedList<Artifact> Artifact { get; set; }

        //public IList<Artifact> Artifact { get; set; }

        public IList<ArtifactSet> ArtifactSet { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string searchStringSet, int itemsCount, int? pageIndex)
        {
            CurrentSortOrder = sortOrder;
            CurrentItemsCount = itemsCount;

            if(CurrentItemsCount == 0)
            {
                CurrentItemsCount = 9;
            }

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Artifact> artifactIQ = from a in _context.AllArtifacts
                                              select a;

            CurrentSetFilter = searchStringSet;

            if (!String.IsNullOrEmpty(searchStringSet))
            {
                artifactIQ = artifactIQ.Where(a => a.SetName.Contains(searchStringSet));
            }

            ArtifactSet = await _context.ArtifactSets.ToListAsync();

            var pageSize = CurrentItemsCount;
            Artifact = await PaginatedList<Artifact>.CreateAsync(
                artifactIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            //Artifact = await artifactIQ.AsNoTracking().ToListAsync();
        }
    }
}
