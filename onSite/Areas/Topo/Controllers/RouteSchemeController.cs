using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace onSite.Areas.Topo.Controllers
{
    public class RouteSchemeController : Controller
    {
        [Area("Topo")]
        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            var path = @"E:\projekt onSite\onSite\onSite\wwwroot\images\Scheme\22.JPG";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetTypes()[ext], Path.GetFileName(path));
        }

        private Dictionary<string, string> GetTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf","application/pdf"},
                {".jpg","image/jpeg"},
                {".jpeg","image/jpeg"},
                {".gif", "image/gif"},
                {".csv","text/csv"}
            };
        }
    }
}