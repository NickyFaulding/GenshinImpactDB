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
    public class DeleteModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public DeleteModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artifact Artifact { get; set; }

        public List<ArtifactSet> ArtifactSets { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artifact = await _context.AllArtifacts.FirstOrDefaultAsync(m => m.ArtifactID == id);

            ArtifactSets = _context.ArtifactSets.ToList();

            if (Artifact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artifact = await _context.AllArtifacts.FindAsync(id);

            if (Artifact != null)
            {
                _context.AllArtifacts.Remove(Artifact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
