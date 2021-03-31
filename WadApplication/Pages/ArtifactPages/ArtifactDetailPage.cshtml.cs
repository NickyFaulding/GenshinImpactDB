using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class ArtifactDetailPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Artifact artifactById { get; set; }

        public ArtifactDetailPageModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int Id)
        {
            artifactById = _db.AllArtifacts.Find(Id);
        }
    }
}
