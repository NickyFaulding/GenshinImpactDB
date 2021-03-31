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
    public class DetailsModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public DetailsModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
