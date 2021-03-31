using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WadApplication.Model;

namespace WadApplication.Pages.WeaponCMS
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
            return Page();
        }

        [BindProperty]
        public Weapon Weapon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AllWeapons.Add(Weapon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
