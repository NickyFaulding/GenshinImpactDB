﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages.WeaponCMS
{
    public class EditModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public EditModel(WadApplication.Model.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Weapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(Weapon.WeaponID))
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

        private bool WeaponExists(int id)
        {
            return _context.AllWeapons.Any(e => e.WeaponID == id);
        }
    }
}
