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
    public class AllCharactersModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public string CurrentElementFilter { get; set; }
        public string CurrentRarityFilter { get; set; }

        public AllCharactersModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Character> Characters { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchStringRarity, string searchStringElement)
        {
            IQueryable<Character> characterIQ = from c in _db.AllCharacters
                                          select c;

            CurrentElementFilter = searchStringElement;
            CurrentRarityFilter = searchStringRarity;


            if (!String.IsNullOrEmpty(searchStringElement))
            {
                characterIQ = characterIQ.Where(w => w.Vision.Contains(searchStringElement));
            }
            if (!String.IsNullOrEmpty(searchStringRarity))
            {
                characterIQ = characterIQ.Where(w => w.Rarity.Equals(searchStringRarity.Length));
            }

            Characters = await characterIQ.AsNoTracking().ToListAsync();
        }
    }
}
