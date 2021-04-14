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
    public class WeaponCMS : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public WeaponCMS(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string CurrentNameFilter { get; set; }
        public string CurrentTypeFilter { get; set; }

        public string[] types = { "Bow", "Claymore", "Catalyst", "Polearm", "Sword" };

        public IList<Weapon> Weapons { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchStringName, string searchStringType)
        {
            NameSort = sortOrder == "Name🔽" ? "Name🔼" : "Name🔽";
            TypeSort = sortOrder == "Rarity🔽" ? "Rarity🔼" : "Rarity🔽";
            
            CurrentNameFilter = searchStringName;
            CurrentTypeFilter = searchStringType;

            IQueryable<Weapon> weaponIQ = from w in _context.AllWeapons
                                          select w;

            if (!String.IsNullOrEmpty(searchStringName))
            {
                weaponIQ = weaponIQ.Where(w => w.Name.Contains(searchStringName));
            }
            if (!String.IsNullOrEmpty(searchStringType))
            {
                weaponIQ = weaponIQ.Where(w => w.Type.Contains(searchStringType));
            }

            switch (sortOrder)
            {
                case "Name🔼":
                    weaponIQ = weaponIQ.OrderBy(w => w.Name);
                    break;
                case "Name🔽":
                    weaponIQ = weaponIQ.OrderByDescending(w => w.Name);
                    break;
                case "Rarity🔽":
                    weaponIQ = weaponIQ.OrderBy(w => w.Rarity);
                    break;
                case "Rarity🔼":
                    weaponIQ = weaponIQ.OrderByDescending(w => w.Rarity);
                    break;
                default:
                    weaponIQ = weaponIQ.OrderBy(w => w.WeaponID);
                    break;
            }

            Weapons = await weaponIQ.AsNoTracking().ToListAsync();
        }
    }
}
