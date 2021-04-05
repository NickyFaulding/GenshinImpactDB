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

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string CurrentNameFilter { get; set; }
        public string CurrentTypeFilter { get; set; }
        public string BowFilter { get; set; }
        public string ClaymoreFilter { get; set; }
        public string CatalystFilter { get; set; }
        public string SwordFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Weapon> Weapons { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchStringName, string searchStringType)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";

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
                case "Name":
                    weaponIQ = weaponIQ.OrderBy(w => w.Name);
                    break;
                case "name_desc":
                    weaponIQ = weaponIQ.OrderByDescending(w => w.Name);
                    break;
                case "Type":
                    weaponIQ = weaponIQ.OrderBy(w => w.Type);
                    break;
                case "type_desc":
                    weaponIQ = weaponIQ.OrderByDescending(w => w.Type);
                    break;
                default:
                    weaponIQ = weaponIQ.OrderBy(w => w.WeaponID);
                    break;
            }

            Weapons = await weaponIQ.AsNoTracking().ToListAsync();
        }
    }
}
