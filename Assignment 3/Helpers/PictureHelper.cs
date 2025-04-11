using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Assignment_3.Helpers
{
    public static class PictureHelper
    {
        public static string UploadNewImage(IWebHostEnvironment environment, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null; 
            }

            
            string guid = Guid.NewGuid().ToString();

            
            string ext = Path.GetExtension(file.FileName);

         
            string shortPath = Path.Combine("images/Movies", guid + ext);
            string fullPath = Path.Combine(environment.WebRootPath, shortPath);

           
            Directory.CreateDirectory(Path.Combine(environment.WebRootPath, "images\\Movies"));

            
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/" + shortPath; 
        }
    }
}
