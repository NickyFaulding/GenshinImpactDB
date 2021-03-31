using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class ArtifactSetPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ArtifactSetPageModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ArtifactSetImage> artifacts { get; set; }

        public void OnGet(string Id)
        {
            artifacts = _db.ArtifactSets.Join(_db.AllArtifacts.Where(s => s.SetName == Id), ArtifactSets => ArtifactSets.SetName, AllArtifacts => AllArtifacts.SetName, (ArtifactSets, AllArtifacts) => new ArtifactSetImage
            {
                Image = AllArtifacts.Name,
                SetType = ArtifactSets.SetName,
                ArtifactID = AllArtifacts.ArtifactID
            }).ToList();


            ViewData["ArtifactSet"] = Id + " Set";
        }
    }
}
