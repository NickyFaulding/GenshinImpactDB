using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class AllWeaponsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public string CurrentTypeFilter { get; set; }

        public AllWeaponsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Weapon> Weapons { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchStringRarity, string searchStringType)
        {
            IQueryable<Weapon> weaponIQ = from w in _db.AllWeapons
                                          select w;

            CurrentTypeFilter = searchStringType;

            if (!String.IsNullOrEmpty(searchStringType))
            {
                weaponIQ = weaponIQ.Where(w => w.Type.Contains(searchStringType));
            }
            if (!String.IsNullOrEmpty(searchStringRarity))
            {                
                weaponIQ = weaponIQ.Where(w => w.Rarity.Equals(searchStringRarity.Length));
            }

            Weapons = await weaponIQ.AsNoTracking().ToListAsync();
        }
    }
}
