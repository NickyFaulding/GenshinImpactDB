using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class AllWeaponsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty (SupportsGet =true)]
        public string SearchString { get; set; }

        public AllWeaponsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Weapon> AllWeapons { get; set; }
        public List<Weapon> FoundWeapons { get; set; }

        public void OnGet()
        {
            var weapons = from w in _db.AllWeapons
                          select w;

            if (!string.IsNullOrEmpty(SearchString))
            {
                weapons = weapons.Where(s => s.Name.Contains(SearchString));
            }

            FoundWeapons = weapons.ToList();

        }
    }
}
