using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages.CharacterCMS
{
    public class IndexModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public IndexModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string VisionSort { get; set; }
        public string CurrentNameFilter { get; set; }
        public string CurrentVisionFilter { get; set; }
        public IList<Character> Character { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchStringName, string searchStringVision)
        {
            NameSort = sortOrder == "Name🔽" ? "Name🔼" : "Name🔽";
            VisionSort = sortOrder == "Vision🔽" ? "Vision🔼" : "Vision🔽";

            CurrentNameFilter = searchStringName;
            CurrentVisionFilter = searchStringVision;

            IQueryable<Character> characterIQ = from c in _context.AllCharacters
                                          select c;

            if (!String.IsNullOrEmpty(searchStringName))
            {
                characterIQ = characterIQ.Where(w => w.Name.Contains(searchStringName));
            }
            if (!String.IsNullOrEmpty(searchStringVision))
            {
                characterIQ = characterIQ.Where(w => w.Vision.Contains(searchStringVision));
            }

            switch (sortOrder)
            {
                case "Name🔼":
                    characterIQ = characterIQ.OrderBy(c => c.Name);
                    break;
                case "Name🔽":
                    characterIQ = characterIQ.OrderByDescending(c => c.Name);
                    break;
                case "Vision🔼":
                    characterIQ = characterIQ.OrderBy(c => c.Vision);
                    break;
                case "Vision🔽":
                    characterIQ = characterIQ.OrderByDescending(c => c.Vision);
                    break;
                default:
                    characterIQ = characterIQ.OrderBy(c => c.CharacterID);
                    break;
            }
            Character = await characterIQ.AsNoTracking().ToListAsync();
        }
    }
}
