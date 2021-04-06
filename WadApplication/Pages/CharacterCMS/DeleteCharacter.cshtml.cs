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
    public class DeleteModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public DeleteModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.AllCharacters.FirstOrDefaultAsync(m => m.CharacterID == id);

            if (Character == null)
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

            Character = await _context.AllCharacters.FindAsync(id);

            if (Character != null)
            {
                _context.AllCharacters.Remove(Character);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
