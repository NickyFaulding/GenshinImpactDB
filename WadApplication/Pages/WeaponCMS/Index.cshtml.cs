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
    public class IndexModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public IndexModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Weapon> Weapon { get;set; }

        public async Task OnGetAsync()
        {
            Weapon = await _context.AllWeapons.ToListAsync();
        }
    }
}
