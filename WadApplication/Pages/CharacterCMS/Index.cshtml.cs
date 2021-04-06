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
    public class IndexModel : PageModel
    {
        private readonly WadApplication.Model.ApplicationDbContext _context;

        public IndexModel(WadApplication.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; }

        public async Task OnGetAsync()
        {
            Character = await _context.AllCharacters.ToListAsync();
        }
    }
}
