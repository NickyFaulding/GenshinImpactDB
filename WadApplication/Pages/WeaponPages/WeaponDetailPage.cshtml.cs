using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class WeaponDetailPage : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Weapon weaponById { get; set; }
        public WeaponDetailPage(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            weaponById = _db.AllWeapons.Find(Id);
        }
    }
}
