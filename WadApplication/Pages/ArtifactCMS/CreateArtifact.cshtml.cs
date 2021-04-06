using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WadApplication.Model;

namespace WadApplication.Pages.ArtifactCMS
{
    public class CreateModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public CreateModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ArtifactSet = _context.ArtifactSets.ToList();
            return Page();
        }

        [BindProperty]
        public Artifact Artifact { get; set; }
        [BindProperty]
        public List<ArtifactSet> ArtifactSet { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AllArtifacts.Add(Artifact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
