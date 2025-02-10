using System.IO;
using System;

namespace WebApp.ImageUploads
{
    public class CommanImageUploades
    {
        private readonly IWebHostEnvironment environment;
        public CommanImageUploades(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public async void UploadImage(string imagepathMailFO, string imagepathSubFO, IFormFile Image)
        {
            var imageFile = Path.Combine(environment.WebRootPath, imagepathMailFO, imagepathSubFO, Image.FileName);
            using var fileStream = new FileStream(imageFile, FileMode.Create);
            await Image.CopyToAsync(fileStream);
        }
    }
}
