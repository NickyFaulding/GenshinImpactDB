using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WadApplication.Model;

namespace WadApplication.Pages.CharacterCMS
{
    public class CharactersCMS : PageModel
    {
        private readonly ApplicationDbContext _db;

        public string CurrentElementFilter { get; set; }
        public string CurrentWeaponFilter { get; set; }
        public string CurrentNameFilter { get; set; }
        public string CurrentRarityFilter { get; set; }

        public CharactersCMS(ApplicationDbContext db)
        {
            _db = db;
        }

        public string[] rarity = { "⭐⭐⭐⭐", "⭐⭐⭐⭐⭐" };
        public string[] weaponTypes = { "Bow", "Claymore", "Catalyst", "Polearm", "Sword" };
        public string[] visionTypes = { "Anemo", "Electro", "Cryo", "Hydro", "Pyro", "Geo", "Dendro", "Adaptive" };


        public IList<Character> Characters { get; set; }

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
