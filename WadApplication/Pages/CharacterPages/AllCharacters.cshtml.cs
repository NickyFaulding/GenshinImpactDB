using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class AllCharactersModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AllCharactersModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Character> AllCharacters { get; set; }

        public void OnGet()
        {
            AllCharacters = _db.AllCharacters.ToList();
        }
    }
}
