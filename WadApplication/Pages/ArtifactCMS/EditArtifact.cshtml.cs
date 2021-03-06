using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages.ArtifactCMS
{
    public class EditModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public EditModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]  
        public Artifact Artifact { get; set; }

        [BindProperty]  
        public List<ArtifactSet> ArtifactSet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artifact = await _context.AllArtifacts.FirstOrDefaultAsync(m => m.ArtifactID == id);

            ArtifactSet = _context.ArtifactSets.ToList();


            if (Artifact == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Artifact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtifactExists(Artifact.ArtifactID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArtifactExists(int id)
        {
            return _context.AllArtifacts.Any(e => e.ArtifactID == id);
        }
    }
}
