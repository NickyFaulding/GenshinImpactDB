using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using WadApplication.Model;
using WadApplication.Utilities;

namespace WadApplication.Pages.CharacterCMS
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".png", ".webp", ".jpg" };
        private readonly string _targetFilePath;
        private bool iconUploaded = false;

        public CreateModel(ApplicationDbContext context, IConfiguration config, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }


        [BindProperty]
        public BufferedSingleFileUploadPhysical IconUpload { get; set; }
        [BindProperty]
        public BufferedSingleFileUploadPhysical PortraitUpload { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Character Character { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var IconUploadContent =
                await FileHelpers.ProcessFormFile<BufferedSingleFileUploadPhysical>(
                    IconUpload.iconFile, ModelState, _permittedExtensions, _fileSizeLimit);

            var iconFilePath = Path.Combine(
                _env.ContentRootPath, "wwwroot/images/CharacterImages/CharacterIcons", Character.Name + ".png");

            using (var fileStream = System.IO.File.Create(iconFilePath))
            {
                await IconUpload.iconFile.CopyToAsync(fileStream);
            }

            var PortraitUploadContent =
                await FileHelpers.ProcessFormFile<BufferedSingleFileUploadPhysical>(
                    PortraitUpload.portraitFile, ModelState, _permittedExtensions, _fileSizeLimit);

            var portraitFilePath = Path.Combine(
                _env.ContentRootPath, "wwwroot/images/CharacterImages", Character.Name + ".png");

            using (var fileStream = System.IO.File.Create(portraitFilePath))
            {
                await PortraitUpload.portraitFile.CopyToAsync(fileStream);
            }

            _context.AllCharacters.Add(Character);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    public class BufferedSingleFileUploadPhysical
    {
        [Display(Name ="File")]
        public IFormFile iconFile { get; set; }
        public IFormFile portraitFile { get; set; }

    }
}
