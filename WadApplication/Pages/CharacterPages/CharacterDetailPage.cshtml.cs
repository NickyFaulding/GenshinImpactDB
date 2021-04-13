using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WadApplication.Model;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WadApplication.Pages
{
    public class CharacterDetailPage : PageModel
    {
        private readonly ApplicationDbContext _db;

        private string[] CommonAscension = { 
            "slime", 
            "hilichurl-masks", 
            "hilichurl-arrowheads",
            "samachurl-scrolls",
            "treasure-hoarder-insignias",
            "fatui-insignias",
            "whopperflower-nectar",
            "hilichurl-horns",
            "ley-line",
            "bone-shards",
            "mist-grass",
            "fatui-knives",
            "chaos-parts"
        };

        public Character characterById { get; set; }

        public List<string> ascensionitems { get; set; }

        public CharacterDetailPage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync(int Id)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    using(var response = await httpClient.GetAsync("https://api.genshin.dev/materials/common-ascension"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        JObject apiData = JObject.Parse(apiResponse);


            //    }
            //}

            ViewData["something"] = ascensionitems;
            
            characterById = _db.AllCharacters.Find(Id);
        }
    }
}
