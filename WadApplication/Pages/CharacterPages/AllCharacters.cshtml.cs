using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class AllCharactersModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public string CurrentElementFilter { get; set; }
        public string CurrentWeaponFilter { get; set; }
        public string CurrentNameFilter { get; set; }
        public string CurrentRarityFilter { get; set; }

        public AllCharactersModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string[] rarity = { "⭐⭐⭐⭐", "⭐⭐⭐⭐⭐" };
        public string[] weaponTypes = { "Bow", "Claymore", "Catalyst", "Polearm", "Sword" };
        public string[] visionTypes = { "Anemo", "Electro", "Cryo", "Hydro", "Pyro", "Geo", "Dendro", "Adaptive" };

        public IList<Character> Characters { get; set; }

        public IActionResult OnGetLoadCharacters(string sortOrder,
            string searchStringRarity,
            string searchStringElement,
            string searchStringName,
            string searchStringWeapon)
        {
            IQueryable<Character> characterIQ = from c in _db.AllCharacters
                                                select c;

            CurrentElementFilter = searchStringElement;
            CurrentRarityFilter = searchStringRarity;
            CurrentWeaponFilter = searchStringWeapon;
            CurrentNameFilter = searchStringName;


            if (!String.IsNullOrEmpty(searchStringName))
            {
                characterIQ = characterIQ.Where(w => w.Name.Contains(searchStringName));
            }
            if (!String.IsNullOrEmpty(searchStringElement))
            {
                characterIQ = characterIQ.Where(w => w.Vision.Contains(searchStringElement));
            }
            if (!String.IsNullOrEmpty(searchStringRarity))
            {
                characterIQ = characterIQ.Where(w => w.Rarity.Equals(searchStringRarity.Length));
            }
            if (!String.IsNullOrEmpty(searchStringWeapon))
            {
                characterIQ = characterIQ.Where(w => w.WeaponType.Contains(searchStringWeapon));
            }

            Characters = characterIQ.AsNoTracking().ToList();

            return new PartialViewResult() { ViewName = "_displayCharacters", ViewData = new ViewDataDictionary<List<Character>>(ViewData, Characters) };
        }

        public async Task OnGetAsync(string sortOrder,
            string searchStringRarity,
            string searchStringElement,
            string searchStringName,
            string searchStringWeapon)
        {
            IQueryable<Character> characterIQ = from c in _db.AllCharacters
                                                select c;

            CurrentElementFilter = searchStringElement;
            CurrentRarityFilter = searchStringRarity;
            CurrentWeaponFilter = searchStringWeapon;
            CurrentNameFilter = searchStringName;


            if (!String.IsNullOrEmpty(searchStringName))
            {
                characterIQ = characterIQ.Where(w => w.Name.Contains(searchStringName));
            }
            if (!String.IsNullOrEmpty(searchStringElement))
            {
                characterIQ = characterIQ.Where(w => w.Vision.Contains(searchStringElement));
            }
            if (!String.IsNullOrEmpty(searchStringRarity))
            {
                characterIQ = characterIQ.Where(w => w.Rarity.Equals(searchStringRarity.Length));
            }
            if (!String.IsNullOrEmpty(searchStringWeapon))
            {
                characterIQ = characterIQ.Where(w => w.WeaponType.Contains(searchStringWeapon));
            }

            Characters = await characterIQ.AsNoTracking().ToListAsync();
        }
    }
}
