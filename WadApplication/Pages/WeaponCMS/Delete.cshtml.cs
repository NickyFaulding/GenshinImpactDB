using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages.WeaponCMS
{
    public class DeleteModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public DeleteModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Weapon Weapon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weapon = await _context.AllWeapons.FirstOrDefaultAsync(m => m.WeaponID == id);

            if (Weapon == null)
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

            Weapon = await _context.AllWeapons.FindAsync(id);

            if (Weapon != null)
            {
                _context.AllWeapons.Remove(Weapon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
