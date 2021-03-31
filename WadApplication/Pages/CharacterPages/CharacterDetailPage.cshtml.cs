using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class CharacterDetailPage : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Character characterById { get; set; }

        public CharacterDetailPage(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int Id)
        {
            characterById = _db.AllCharacters.Find(Id);
        }
    }
}
