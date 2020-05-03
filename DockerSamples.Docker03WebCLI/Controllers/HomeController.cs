using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DockerSamples.Docker03WebCLI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.FileProviders;

namespace DockerSamples.Docker03WebCLI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider fileProvider;
        public HomeController(ILogger<HomeController> logger, IFileProvider _fileProvider)
        {
            _logger = logger;
            fileProvider = _fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImageList()
        {
            var imageList = fileProvider.GetDirectoryContents("wwwroot/images").ToList().Select(z => z.Name);
            return View(imageList);
        }

        public IActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageAdd(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
