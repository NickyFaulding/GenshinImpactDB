using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;

namespace WadApplication.Pages
{
    public class AllArtifactsModel: PageModel
    {
        private readonly ApplicationDbContext _db;

        public AllArtifactsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ArtifactSetImage> ArtifactSetIcons { get; set; }


        public void OnGet()
        {
            ArtifactSetIcons = _db.ArtifactSets.Join(_db.AllArtifacts.Where(s => s.Type == "Flower of Life"), ArtifactSets => ArtifactSets.SetName, AllArtifacts => AllArtifacts.SetName, (ArtifactSets, AllArtifacts) => new ArtifactSetImage
            {
                Image = AllArtifacts.Name,
                SetType = ArtifactSets.SetName
            }).ToList();
        }
    }
}
